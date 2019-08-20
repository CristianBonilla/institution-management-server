using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institution.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Institution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IAlumnoService alumnoService;
        public ValuesController(IAlumnoService alumnoService)
        {
            this.alumnoService = alumnoService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<AlumnoEntity>> Get()
        {
            return Ok(alumnoService.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
