﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
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
        [Route("them-SP")]
        [HttpPost]
        public SanphamModel CreateSP([FromBody] SanphamModel model)
        {
            if (model.HINH != null)
            {
                var arrData = model.HINH.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/hinhanh/Products/{arrData[0]}";
                    model.HINH = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _SanphamBusiness.Create(model);
            return model;
        }
        // PUT api/<SanphamController>/5
        [Route("update-SP")]
        [HttpPost]
        public SanphamModel UpdateSP([FromBody] SanphamModel model)
        {
            if (model.HINH != null)
            {
                var arrData = model.HINH.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/hinhanh/Products/{arrData[0]}";
                    model.HINH = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _SanphamBusiness.Create(model);
            return model;
        }
        private void SaveFileFromBase64String(string savePath, string v)
        {
            throw new NotImplementedException();
        }
        // DELETE api/<SanphamController>/5
        [Route("delete-SP")]
        [HttpPost]
        public IActionResult DeleteSP([FromBody] Dictionary<string, object> formData)
        {
            string user_id = "";
            if (formData.Keys.Contains("user_id") && !string.IsNullOrEmpty(Convert.ToString(formData["user_id"]))) { user_id = Convert.ToString(formData["user_id"]); }
            _SanphamBusiness.Delete(user_id);
            return Ok();
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

        [Route("gettheomasp/{id}")]
        [HttpGet]
        public SanphamModel GetDatabyID(string id)
        {
            return _SanphamBusiness.GetDatabyID(id);
        }
        [Route("sp-theo-loai/{url}/{page}/{size}")]
        [HttpGet]
        public List<SanphamModel> Sptheoloai(string url,int?  page,  int?size)
        {
            size = size ?? 10;
            page = page ?? 1;
            long total = 0;
            var kq = _SanphamBusiness.SanPhamTheoLoai(page.Value, size.Value, out total, url);
            total = kq.Count;
            return kq;
        }
    }
}
