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
    public class GiamgiaController : ControllerBase
    {
        private IGiamgiaBusiness abc;
        public GiamgiaController(IGiamgiaBusiness cba)
        {
            abc = cba;
        }
        // GET: api/<GiamgiaController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<GiamgiaModel> GetDataAll()
        {
            return abc.GetDataAll();
        }

        // GET api/<GiamgiaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GiamgiaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GiamgiaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GiamgiaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
