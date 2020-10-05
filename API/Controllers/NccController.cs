using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NccController : ControllerBase
    {
        private INccBusiness abc;
        public NccController(INccBusiness cba)
        {
            abc = cba;
        }

        // GET: api/<NccController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<NccModel> GetDataAll()
        {
            return abc.GetDataAll();
        }

        // GET api/<NccController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NccController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NccController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NccController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
