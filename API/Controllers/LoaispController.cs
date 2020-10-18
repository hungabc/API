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
        [Route("them-LSP")]
        [HttpPost]
        public LoaispModel CreateLSP([FromBody] LoaispModel model)
        {
            _LoaispBusiness.Create(model);
            return model;
        }
        public void Post([FromBody] string value)
        {
        }
        // PUT api/<LoaispController>/5
        [Route("update-LSP")]
        [HttpPost]
        public LoaispModel UpdateLSP([FromBody] LoaispModel model)
        {
            _LoaispBusiness.Create(model);
            return model;
        }
        // DELETE api/<LoaispController>/5
        [Route("delete-LSP")]
        [HttpPost]
        public IActionResult DeleteLSP([FromBody] Dictionary<string, object> formData)
        {
            string user_id = "";
            if (formData.Keys.Contains("user_id") && !string.IsNullOrEmpty(Convert.ToString(formData["user_id"]))) { user_id = Convert.ToString(formData["user_id"]); }
            _LoaispBusiness.Delete(user_id);
            return Ok();
        }
        //
        [Route("getmaloai/{id}")]
        [HttpGet]
        public LoaispModel GetDatabyID(string id)
        {
            return _LoaispBusiness.GetDatabyID(id);
        }
    }
}
