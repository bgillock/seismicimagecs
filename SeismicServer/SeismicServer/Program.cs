using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace WebServer
{
    using System;
    using System.Net;
    using System.Threading;
    using System.Linq;
    using System.Text;
    using IO.Swagger.Models;



    public class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private readonly Func<HttpListenerRequest, string> _responderMethod;

        public WebServer(string[] prefixes, Func<HttpListenerRequest, string> method)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");

            // URI prefixes are required, for example 
            // "http://localhost:8080/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            // A responder method is required
            if (method == null)
                throw new ArgumentException("method");

            foreach (string s in prefixes)
                _listener.Prefixes.Add(s);

            _responderMethod = method;
            _listener.Start();
        }

        public WebServer(Func<HttpListenerRequest, string> method, params string[] prefixes)
            : this(prefixes, method) { }

        public void Run()
        {
            ThreadPool.QueueUserWorkItem((o) =>
            {
                Console.WriteLine("Webserver running...");
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                string rstr = _responderMethod(ctx.Request);
                                byte[] buf = Encoding.UTF8.GetBytes(rstr);
                                ctx.Response.ContentLength64 = buf.Length;
                                ctx.Response.OutputStream.Write(buf, 0, buf.Length);
                            }
                            catch { } // suppress any exceptions
                            finally
                            {
                                // always close the stream
                                ctx.Response.OutputStream.Close();
                            }
                        }, _listener.GetContext());
                    }
                }
                catch { } // suppress any exceptions
            });
        }

        public void Stop()
        {
            _listener.Stop();
            _listener.Close();
        }
    }
   

    class Program
    {
        private static string _seismicRootPath;
        static void Main(string[] args)
        {
            _seismicRootPath = @"C:\Users\Bill\nodejs\seismicimage\";
            WebServer ws = new WebServer(SendResponse, "http://localhost:3001/seismic/v1/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            Debug.WriteLine("request=" + request.Url.ToString());
            string[] parser = request.Url.ToString().Split(new char[] { '/' });
            Debug.WriteLine("n=" + parser.Length);
            Debug.WriteLine("Query=" + request.QueryString);

            // Return list of cubes
            if ((parser.Length == 6) && (parser[5] == "cubes"))
            {

                var fileNames = System.IO.Directory.GetFiles(_seismicRootPath);
                List<Cube> retCubes = new List<Cube>();
                foreach (var file in fileNames)
                {
                    Console.WriteLine("file=" + file);
                    if (System.IO.Path.GetExtension(file) == ".jsz")
                    {
                        retCubes.Add(new SeismicFile(file).header);
                    }
                }
                return JsonConvert.SerializeObject(retCubes, Formatting.Indented);

            }
            if ((parser.Length == 7) && (parser[5] == "cubes"))
            {
                return JsonConvert.SerializeObject(new 
                       SeismicFile(_seismicRootPath + Path.DirectorySeparatorChar + parser[6]).header,
                       Formatting.Indented);
            }
            if ((parser.Length == 8) && (parser[5] == "cubes") && (parser[7].IndexOf("inline") == 0))
            {
                int inlineNumber = int.MinValue;
                foreach (var key in request.QueryString.AllKeys)
                {
                    if (key == "number")
                    {
                        inlineNumber = Int16.Parse(request.QueryString.Get(key));
                        break;
                    }

                    Debug.WriteLine("Query=" + key + "," + request.QueryString.Get(key));
                }
                if (inlineNumber == int.MinValue) return "Invalid line number";

                var _cube = new SeismicFile(_seismicRootPath + Path.DirectorySeparatorChar + parser[6]);
                return JsonConvert.SerializeObject(new Plane(_cube.header.CubeId,
                                                             "Inline",
                                                             inlineNumber,
                                                             _cube.GetGeometry("Inline",inlineNumber),
                                                             _cube.GetImage());
                
            }
            return "";
        }
    }
}
