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
    public class LoaispController : ControllerBase
    {
        private ILoaispBusiness abc;
        public LoaispController(ILoaispBusiness cba)
        {
            abc = cba;
        }
        // GET: api/<LoaispController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<LoaispModel> GetDataAll()
        {
            return abc.GetDataAll();
        }

        // GET api/<LoaispController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoaispController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LoaispController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoaispController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("themsp")]
        [HttpPost]
        public LoaispModel Createloaisp([FromBody] LoaispModel model)
        {
            abc.Create(model);
            return model;
        }

        [Route("getmaloai/{id}")]
        [HttpGet]
        public LoaispModel GetDatabyID(string id)
        {
            return abc.GetDatabyID(id);
        }
    }
}
