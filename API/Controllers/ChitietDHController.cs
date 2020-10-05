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
    public class ChitietDHController : ControllerBase
    {
        private IChitietDHBusiness abc;
        public ChitietDHController(IChitietDHBusiness cba)
        {
            abc = cba;
        }

        // GET: api/<ChitietDHController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ChitietDHModel> GetDataAll()
        {
            return abc.GetDataAll();
        }

        // GET api/<ChitietDHController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ChitietDHController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ChitietDHController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChitietDHController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
