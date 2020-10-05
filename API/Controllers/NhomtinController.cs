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
    public class NhomtinController : ControllerBase
    {
        private INhomtinBusiness abc;
        public NhomtinController(INhomtinBusiness cba)
        {
            abc = cba;
        }

        // GET: api/<NhomtinController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<NhomtinModel> GetDataAll()
        {
            return abc.GetDataAll();
        }

        // GET api/<NhomtinController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NhomtinController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NhomtinController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NhomtinController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
