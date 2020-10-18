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
    public class HoadonbanController : ControllerBase
    {
        private IHoadonbanBusiness abc;
        public HoadonbanController(IHoadonbanBusiness cba)
        {
            abc = cba;
        }
        // GET: api/<HoadonbanController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<HoadonbanModel> GetDataAll()
        {
            return abc.GetDataAll();
        }
        // GET api/<HoadonbanController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<HoadonbanController>
        [Route("them-HDB")]
        [HttpPost]
        public HoadonbanModel CreateHDB([FromBody] HoadonbanModel model)
        {
            abc.Create(model);
            return model;
        }
    }
}
