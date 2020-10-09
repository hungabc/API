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
        private ILoaispBusiness _LoaispBusiness;
        public LoaispController(ILoaispBusiness LoaispBusiness)
        {
            _LoaispBusiness = LoaispBusiness;
        }
        // GET: api/<LoaispController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<LoaispModel> GetDataAll()
        {
            return _LoaispBusiness.GetDataAll();
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

        [Route("them-loai")]
        [HttpPost]
        public LoaispModel CreateItem([FromBody] LoaispModel model)
        {
            _LoaispBusiness.Create(model);
            return model;
        }

        [Route("getmaloai/{id}")]
        [HttpGet]
        public LoaispModel GetDatabyID(string id)
        {
            return _LoaispBusiness.GetDatabyID(id);
        }
    }
}
