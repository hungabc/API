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
    public class TintucController : ControllerBase
    {
        private ITintucBusiness abc;
        public TintucController(ITintucBusiness cba)
        {
            abc = cba;
        }
        // GET: api/<TintucController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<TintucModel> GetDataAll()
        {
            return abc.GetDataAll();
        }
        // GET api/<TintucController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<TintucController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // PUT api/<TintucController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<TintucController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
