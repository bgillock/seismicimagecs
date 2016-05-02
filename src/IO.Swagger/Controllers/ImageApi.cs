using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Swashbuckle.SwaggerGen.Annotations;
using IO.Swagger.Models;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class ImageApiController : Controller
    { 

        /// <summary>
        /// Return a png file
        /// </summary>
        /// <remarks>Returns a png file rendered from seismic cube data at orientation, and with specified color nap and resolution</remarks>
        /// <param name="cubeId">ID of cube</param>
        /// <param name="orientation">Inline, Crossline or Slice</param>
        /// <param name="number">Inline, crossline or slice number to extract</param>
        /// <param name="colorMap">Colormap to use for rendering (Default=black/white)</param>
        /// <param name="resolution">Resolution of image (low,med,actual,high) (Default=actual)</param>
        /// <response code="200">PNG image</response>
        [HttpGet]
        [Route("/cubes/{cubeId}/image")]
        [SwaggerOperation("CubesCubeIdImageGET")]
        [SwaggerResponse(200, type: typeof(byte[]))]
        public IActionResult CubesCubeIdImageGET([FromRoute]string cubeId, [FromQuery]string orientation, [FromQuery]double? number, [FromQuery]string colorMap, [FromQuery]string resolution)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<byte[]>(exampleJson)
            : default(byte[]);
            
            return new ObjectResult(example);
        }
    }
}
