﻿using System;
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
    public class ThanhvienController : ControllerBase
    {
        private IThanhvienBusiness abc;
        public ThanhvienController(IThanhvienBusiness cba)
        {
            abc = cba;
        }

        // GET: api/<ThanhvienController>
        [Route("get-all")]
        [HttpGet]
        public IEnumerable<ThanhvienModel> GetDataAll()
        {
            return abc.GetDataAll();
        }
        // GET api/<ThanhvienController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<ThanhvienController>
        [Route("them-KH")]
        [HttpPost]
        public ThanhvienModel CreateKH([FromBody] ThanhvienModel model)
        {

            if (abc.KiemTraUser(model.TENDANGNHAP, model.DIENTHOAI, model.EMAIL))
            {

                return null;
            }
            ThanhvienModel result = new ThanhvienModel();
            abc.Create(model);
            result.TENDANGNHAP = model.TENDANGNHAP;
            result.DIACHI = model.DIACHI;
            result.DIENTHOAI = model.DIENTHOAI;
            result.EMAIL = model.EMAIL;
            result.HOTEN = model.HOTEN;
            result.KICHHOAT = model.KICHHOAT;
            result.QUYEN = model.QUYEN;
            result.NGAYDANGKY = model.NGAYDANGKY;
            result.GIOITINH = model.GIOITINH;
            return result; //không nên return model vì sẽ bị lộ mật khaaur
        }
        [Route("login")]
        [HttpPost]
        public ThanhvienModel Login([FromBody] ThanhvienModel model)
        {
            var kq = abc.Login(model);
            return kq;
        }
        // PUT api/<ThanhvienController>/5
        [Route("update-KH")]
        [HttpPost]
        public ThanhvienModel UpdateKH([FromBody] ThanhvienModel model)
        {
            abc.Update(model);
            return model;
        }
        // DELETE api/<ThanhvienController>/5
        [Route("delete-KH")]
        [HttpPost]
        public IActionResult DeleteKH([FromBody] Dictionary<string, object> formData)
        {
            string TENDANGNHAP = "";
            if (formData.Keys.Contains("user_id") && !string.IsNullOrEmpty(Convert.ToString(formData["TENDANGNHAP"]))) { TENDANGNHAP = Convert.ToString(formData["TENDANGNHAP"]); }
            abc.Delete(TENDANGNHAP);
            return Ok();
        }
    }
}
