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
    public class ThanhvienController : ControllerBase
    {
        private IThanhvienBusiness abc;
        public ThanhvienController(IThanhvienBusiness cba)
        {
            abc = cba;
        }

        // GET: api/<ThanhvienController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ThanhvienModel> GetDataAll()
        {
            return abc.GetDataAll();
        }

        // GET api/<ThanhvienController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ThanhvienController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ThanhvienController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ThanhvienController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
