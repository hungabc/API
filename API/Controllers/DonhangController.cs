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
    public class DonhangController : ControllerBase
    {
        private IDonhangBusiness abc;
        public DonhangController(IDonhangBusiness cba)
        {
            abc = cba;
        }

        // GET: api/<DonhangController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<DonhangModel> GetDataAll()
        {
            return abc.GetDataAll();
        }

        // GET api/<DonhangController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DonhangController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DonhangController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DonhangController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
