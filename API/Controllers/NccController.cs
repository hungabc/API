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
    public class NccController : ControllerBase
    {
        private INccBusiness abc;
        public NccController(INccBusiness cba)
        {
            abc = cba;
        }
        // GET: api/<NccController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<NccModel> GetDataAll()
        {
            return abc.GetDataAll();
        }
        // GET api/<NccController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<NccController>
        [Route("them-NCC")]
        [HttpPost]
        public NccModel CreateNCC([FromBody] NccModel model)
        {
            abc.Create(model);
            return model;
        }
        // PUT api/<NccController>/5
        [Route("update-NCC")]
        [HttpPost]
        public NccModel UpdateNCC([FromBody] NccModel model)
        {
            abc.Create(model);
            return model;
        }
        // DELETE api/<NccController>/5
        [Route("delete-NCC")]
        [HttpPost]
        public IActionResult DeleteNCC([FromBody] Dictionary<string, object> formData)
        {
            int MANCC = 1;
            if (formData.Keys.Contains("MANCC") && !string.IsNullOrEmpty(Convert.ToString(formData["MANCC"]))) { MANCC = Convert.ToInt32(formData["MANCC"]); }
            abc.Delete(MANCC);
            return Ok();
        }
    }
}
