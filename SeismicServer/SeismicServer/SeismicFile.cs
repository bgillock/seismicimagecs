using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Models;

namespace WebServer
{
    class Buffer
    {
        private byte[] _buffer;
        public Buffer(string file, int offset, int size)
        {
            try
            {
                var _fs = new FileStream(file, FileMode.Open);

                _buffer = new byte[size];

                if (_fs.Read(_buffer, offset, size) != size)
                {
                    Debug.WriteLine("Error reading " + file);
                }               
                _fs.Close();
            }
            catch
            {
                
            }
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
        public Cube header { get { return _header; }}
        public SeismicFile(string filename)
        {            
            Buffer buffer = new Buffer(filename,0,113);
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

            _header = new Cube(name,
                               Path.GetFileName(filename),
                               "Seismic",
                               nlines, // n inlines
                               nxlines, // n cross lines
                               nsamples, // n samples
                               samplerate, // sample rate
                               "Time",
                               new CubeLocationXY(
                                    "UTM31",
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
            var bitspersample = buffer.readInt16LE(111);
        }
        public Geometry GetGeometry(string type, double num)
        {
            Geometry g = new Geometry(new GeometryTranslate(_header.LocationXY.OriginX,
                                                            _header.LocationXY.OriginY,
                                                            0.0),
                                      new GeometryRotate(0.0, 0.0, 0.0));
            return g;
        }
        public Image GetImage(string type, double num, string color, string resolution)
        {
            string url = @"http://localhost:3001/seismic/v1/cubes/" +
                        _header.CubeId + "/image?orientation=" + type +
                        "&number=" + num +
                        "&colorMap=" + color +
                        "&resolution=" + resolution;

            Image i = new Image((int)_header.NCrosslines, (int)_header.NSamples, url);
            return g;
        }
    }
}
