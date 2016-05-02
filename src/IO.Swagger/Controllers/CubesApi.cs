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
    public class CubesApiController : Controller
    { 

        /// <summary>
        /// Get cube definition
        /// </summary>
        /// <remarks>Get the meta definition of a cube</remarks>
        /// <param name="cubeId">ID of cube</param>
        /// <response code="200">Cube definition</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/cubes/{cubeId}")]
        [SwaggerOperation("CubesCubeIdGET")]
        [SwaggerResponse(200, type: typeof(Cube))]
        public IActionResult CubesCubeIdGET([FromRoute]string cubeId)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Cube>(exampleJson)
            : default(Cube);
            
            return new ObjectResult(example);
        }


        /// <summary>
        /// Get a list of cubes
        /// </summary>
        /// <remarks>Returns a list of cubes.</remarks>
        /// <param name="domain">Time or Depth</param>
        /// <response code="200">An array cube definitions</response>
        /// <response code="0">Unexpected error</response>
        [HttpGet]
        [Route("/cubes")]
        [SwaggerOperation("CubesGET")]
        [SwaggerResponse(200, type: typeof(List<Cube>))]
        public IActionResult CubesGET([FromQuery]string domain)
        { 
            string exampleJson = null;
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<List<Cube>>(exampleJson)
            : default(List<Cube>);
            
            return new ObjectResult(example);
        }
    }
}
