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
    public class HoadonnhapController : ControllerBase
    {
        private IHoadonnhapBusiness abc;
        public HoadonnhapController(IHoadonnhapBusiness cba)
        {
            abc = cba;
        }

        // GET: api/<HoadonnhapController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HoadonnhapModel> GetDataAll()
        {
            return abc.GetDataAll();
        }

        // GET api/<HoadonnhapController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HoadonnhapController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HoadonnhapController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HoadonnhapController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
