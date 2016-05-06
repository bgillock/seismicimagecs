using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Models;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SeismicServer
{
    class Buffer
    {
        public byte[] _buffer;
        private FileStream _fs = null;
        private string _filename;

        public Buffer(string file, long offset, int size)
        {
            try
            {
                _fs = new FileStream(file, FileMode.Open);
                _filename = file;
                _buffer = new byte[size];
                long seek = _fs.Seek(offset,SeekOrigin.Begin);
                if (_fs.Read(_buffer, 0, size) != size)
                {
                    Debug.WriteLine("Error reading " + file);
                }               
                _fs.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error reading from " + file + ": " + ex.Message);
            }
        }
        ~Buffer()
        {
            _fs.Close();
        }
        
        public unsafe Int16 readInt16LE(int offset)
        {
            Int16 output = 0;
            try
            {
                fixed (byte* b = _buffer)
                {
                    byte* c = b + offset;

                    Int16* i = (Int16*)c;
                    output = *i;
                }
            }
            catch (Exception ex)
            {
            }
            return output;
        }
        public unsafe double readDoubleLE(int offset)
        {
            double output = 0;
            try
            {
                fixed (byte* b = _buffer)
                {
                    byte* c = b + offset;

                    double* i = (double*)c;
                    output = *i;
                }
            }
            catch (Exception ex)
            {
            }
            return output;
        }
        public string toString(int offset, int length)
        {
            return System.Text.Encoding.UTF8.GetString(_buffer, offset, length);
        }
    }
    class SeismicFile
    {
        private Cube _header;
        private string _filename;
        private const int _headerSize = 217;
        public Cube header { get { return _header; }}
        public SeismicFile(string filename)
        {            
            Buffer buffer = new Buffer(filename,0,_headerSize);
            var name = buffer.toString(0, 25).Trim();
            var nlines = buffer.readInt16LE(25);
            var nxlines = buffer.readInt16LE(27);
            var nsamples = buffer.readInt16LE(29);
            var originx = buffer.readDoubleLE(31);
            var originy = buffer.readDoubleLE(39);
            var inlineendx = buffer.readDoubleLE(47);
            var inlineendy = buffer.readDoubleLE(55);
            var xlineendx = buffer.readDoubleLE(63);
            var xlineendy = buffer.readDoubleLE(71);
            var samplerate = buffer.readDoubleLE(79);
            var annotinlinestart = buffer.readInt16LE(87);
            var annotinlineinc = buffer.readInt16LE(89);
            var annotinlineend = annotinlinestart + annotinlineinc * (nlines - 1);
            var annotxlinestart = buffer.readInt16LE(91);
            var annotxlineinc = buffer.readInt16LE(93);
            var annotxlineend = annotxlinestart + annotxlineinc * (nxlines - 1);
            var minamp = buffer.readDoubleLE(95);
            var maxamp = buffer.readDoubleLE(103);
            var bitspersample = buffer.readInt16LE(111);
            var bricksizei = buffer.readInt16LE(113);
            var bricksizej = buffer.readInt16LE(115);
            var bricksizek = buffer.readInt16LE(117);
            var originz = buffer.readDoubleLE(119);
            var crsname = buffer.toString(127, 25).Trim();
            var domain = buffer.toString(152, 25).Trim();
            var id = buffer.toString(177, 40).Trim();

            _filename = filename;
            _header = new Cube(name,
                               id,
                               "Seismic",
                               nlines, // n inlines
                               nxlines, // n cross lines
                               originz,
                               nsamples, // n samples
                               samplerate, // sample rate
                               domain,
                               new CubeLocationXY(
                                    crsname,
                                    originx, 
                                    originy,
                                    inlineendx,
                                    xlineendx,
                                    inlineendy,
                                    xlineendy),
                                new CubeAnnotation(
                                     annotxlinestart,
                                     annotinlinestart,
                                    annotinlineinc,
                                    annotxlineinc,
                                    annotinlineend,
                                    annotxlineend),
                                new CubeAmplitude(
                                     minamp,
                                     maxamp));

        }
        private Point3 linear(Point3 a, Point3 b, double ratio)
        {
            Point3 ret = new Point3(a.X,a.Y,a.Z);

            ret.X = a.X + ((b.X-a.X)*ratio);
            ret.Y = a.Y + ((b.Y-a.Y)*ratio);
            return ret;
        }

        public IO.Swagger.Models.Geometry GetGeometry(string type, double num)
        {
            Point3 origin = new Point3((double)_header.LocationXY.OriginX,(double)_header.LocationXY.OriginY,0.0);
            Point3 endinline = new Point3((double)_header.LocationXY.EndFirstInlineX,(double)_header.LocationXY.EndFirstInlineY,0.0);
            Point3 endxline = new Point3((double)_header.LocationXY.EndFirstCrosslineX,(double)_header.LocationXY.EndFirstCrosslineY,0.0);
            Point3 opposite = new Point3(endinline.X - (origin.X - endxline.X),endinline.Y - (origin.Y - endxline.Y),0.0);
            double height = ((double)_header.NSamples * (double)_header.SampleRate);

            switch (type)
            {
                case "Inline": 
                {
                    double lineOffset = (num - (int)_header.Annotation.MinInline) / ((int)_header.Annotation.MaxInline - (int)_header.Annotation.MinInline);
                       
                    Point3 startline = linear(origin,endxline,lineOffset);
                    Point3 endline = linear(endinline,opposite,lineOffset);
                    double width = Math.Sqrt(((endline.X-startline.X)*(endline.X-startline.X))+((endline.Y-startline.Y)*(endline.Y-startline.Y)));

                    Point3 midPoint = linear(startline,endline,0.5);
                    midPoint.Z = (double)_header.StartZ + (height / 2.0); 

                    GeometryTranslate tr = new GeometryTranslate(midPoint.X,midPoint.Y,midPoint.Z);
                    GeometryRotate rot = new GeometryRotate(0.0,0.0,Math.Atan2(endline.Y-startline.Y, endline.X-startline.X));

                    IO.Swagger.Models.Geometry g = new IO.Swagger.Models.Geometry(width,
                                            height,
                                            tr, rot);
                    return g;
                }
                default:
                {
                    return null;
                }

            }
        }
        public Image GetImageUrl(string type, double num, string color, string resolution)
        {
            string url = @"http://localhost:3001/seismic/v1/cubes/" +
                        _header.CubeId + "/image?orientation=" + type +
                        "&number=" + num +
                        "&colorMap=" + color +
                        "&resolution=" + resolution;

            Image i = new Image((int)_header.NCrosslines, (int)_header.NSamples, url);
            return i;
        }
        private byte[,] BlackWhiteColorTable()
        {
            byte[,] retTable = new byte[256,3];
            for (int i=0;i<256;i++)
            {
                retTable[i,0] = (byte)i;
                retTable[i,1] = (byte)i;
                retTable[i,2] = (byte)i;
            }
            return retTable;
        }

        //
        private byte[] RGB24Pixels(byte[] inArray, int xinc, int yinc, int inWidth, int inHeight, byte[,] colortable, out int outWidth, out int outHeight, out int stride)
        {
            outWidth = inWidth/xinc;
            outHeight = inHeight/yinc;
            int bytesPerPixel = 3;
            stride = 4 * ((outWidth * bytesPerPixel + 3) / 4);
            byte[] pixels = new byte[stride * outHeight];

            int i=0;
            for (int x = 0; x<inWidth; x+=xinc)
            {
               int j = 0;
               for (int y=0; y<inHeight; y+=yinc)
               {
                   int pixelIndex = (j * stride) + (i * 3);
                   byte b = inArray[(x*inHeight)+y];
                   pixels[pixelIndex] = colortable[b,0];
                   pixels[pixelIndex+1] = colortable[b,1];
                   pixels[pixelIndex+2] = colortable[b,2];
                   j++;
               }
               i++;
            }
            return pixels;
        }
        public byte[] GetJPEG(string type, double num, string color, string resolution)
        {
            byte[,] colorTable = null;
            if (color == "BlackWhite")
                colorTable = BlackWhiteColorTable();
            switch (type)
            {
                case "Inline":
                    {
                        int size = (int)_header.NSamples * (int)_header.NCrosslines;
                        byte[] data = new byte[size];
                        int line = ((int)num - (int)_header.Annotation.MinInline)/(int)_header.Annotation.IncInline;
                        long offset = _headerSize + (line * size);
                        Buffer buffer = new Buffer(_filename, offset, size);
  
                        int width = (int)_header.NCrosslines;
                        int height = (int)_header.NSamples;

                        int imageWidth = width;
                        int imageHeight = height;
                        int stride = width;

                        // Define the image palette
                        BitmapPalette myPalette = BitmapPalettes.Halftone256;

                        byte[] pixels = RGB24Pixels(buffer._buffer, 1, 1, width, height, colorTable, out imageWidth, out imageHeight, out stride);

                        // Creates a new empty image with the pre-defined palette
                        BitmapSource image = BitmapSource.Create(
                            width,
                            height,
                            96,
                            96,
                            PixelFormats.Rgb24,
                            myPalette,
                            pixels,
                            stride);

                        MemoryStream stream = new MemoryStream();
                        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                       
                        encoder.Frames.Add(BitmapFrame.Create(image));
                        encoder.Save(stream);
                        Debug.WriteLine(stream.ToString());
                        return stream.ToArray();
                    }
                default:
                    break;
            }
            
            return Encoding.UTF8.GetBytes("");
        }
    }
}
