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
    public class SanphamController : ControllerBase
    {
        private ISanphamBusiness _SanphamBusiness;
        public SanphamController(ISanphamBusiness SanphamBusiness)
        {
            _SanphamBusiness = SanphamBusiness;
        }

        // GET: api/<SanphamController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<SanphamModel> GetDataAll()
        {
            return _SanphamBusiness.GetDataAll();
        }

        // GET api/<SanphamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SanphamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SanphamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SanphamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [Route("sp-phan-trang")]
        public ResponseModel PhanTrang([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                long total = 0;
                var data = _SanphamBusiness.PhanTrang(page, pageSize, out total);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
  
        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int MALOAI= 1;
                if (formData.Keys.Contains("MALOAI") && !string.IsNullOrEmpty(Convert.ToString(formData["MALOAI"]))) { MALOAI = Convert.ToInt32(formData["MALOAI"]); }
                long total = 0;
                var data = _SanphamBusiness.Search(page, pageSize, out total, MALOAI);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    
        [Route("them-sanpham")]
        [HttpPost]
        public SanphamModel CreateItem([FromBody] SanphamModel model)
        {
            _SanphamBusiness.Create(model);
            return model;
        }

        [Route("gettheomasp/{id}")]
        [HttpGet]
        public SanphamModel GetDatabyID(string id)
        {
            return _SanphamBusiness.GetDatabyID(id);
        }
        [Route("sp-theo-loai")]
        [HttpGet]
        public ResponseModel Sptheoloai([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string MALOAI = "";
                if (formData.Keys.Contains("MALOAI") && !string.IsNullOrEmpty(Convert.ToString(formData["MALOAI"]))) { MALOAI = Convert.ToString(formData["MALOAI"]); }
                long total = 0;
                var data = _SanphamBusiness.SanPhamTheoLoai(page, pageSize, out total, MALOAI);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
