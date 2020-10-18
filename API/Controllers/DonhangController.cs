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
        [Route("them-DH")]
        [HttpPost]
        public DonhangModel CreateDH([FromBody] DonhangModel model)
        {
            abc.Create(model);
            return model;
        }
        // PUT api/<DonhangController>/5
        [Route("update-HD")]
        [HttpPost]
        public DonhangModel UpdateDH([FromBody] DonhangModel model)
        {
            abc.Create(model);
            return model;
        }
        // DELETE api/<DonhangController>/5
        [Route("delete-DH")]
        [HttpPost]
        public IActionResult DeleteDH([FromBody] Dictionary<string, object> formData)
        {
            string user_id = "";
            if (formData.Keys.Contains("user_id") && !string.IsNullOrEmpty(Convert.ToString(formData["user_id"]))) { user_id = Convert.ToString(formData["user_id"]); }
            abc.Delete(user_id);
            return Ok();
        }
    }
}
