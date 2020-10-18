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
            int MALOAI = 1;
            if (formData.Keys.Contains("MALOAI") && !string.IsNullOrEmpty(Convert.ToString(formData["user_id"]))) { MALOAI = Convert.ToInt32(formData["MALOAI"]); }
            _LoaispBusiness.Delete(MALOAI);
            return Ok();
        }
        //
        [Route("getmaloai/{id}")]
        [HttpGet]
        public LoaispModel GetDatabyID(int id)
        {
            return _LoaispBusiness.GetDatabyID(id);
        }
    }
}
