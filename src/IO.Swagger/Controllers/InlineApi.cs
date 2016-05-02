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
    public class InlineApiController : Controller
    { 

        /// <summary>
        /// Extract an inline from a cube and render it at desired resolution
        /// </summary>
        /// <remarks>Extract an inline from a cube and render it at desired resolution</remarks>
        /// <param name="number">Inline number to extract</param>
        /// <param name="cubeId">ID of cube</param>
        /// <response code="200">Description of plane</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/cubes/{cubeId}/inline")]
        [SwaggerOperation("CubesCubeIdInlineGET")]
        [SwaggerResponse(200, type: typeof(Plane))]
        public IActionResult CubesCubeIdInlineGET([FromQuery]double? number, [FromRoute]string cubeId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Plane>(exampleJson)
            : default(Plane);
            
            return new ObjectResult(example);
        }
    }
}
