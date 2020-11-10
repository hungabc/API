using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanphamController : ControllerBase
    {
        private ISanphamBusiness _SanphamBusiness;
        private string _path;
        public SanphamController(ISanphamBusiness SanphamBusiness, IConfiguration configuration)
        {
            _SanphamBusiness = SanphamBusiness;
            _path = configuration["AppSettings:PATH"];
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
                    var savePath = $@"{arrData[0]}";
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
                    var savePath = $@"{arrData[0]}";
                    model.HINH = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _SanphamBusiness.Update(model);
            return model;
        }
        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        // DELETE api/<SanphamController>/5
        [Route("delete-SP/{masp}")]
        [HttpGet]
        public IActionResult DeleteSP(int masp)
        {

            if (GetDatabyID(masp) != null)
                _SanphamBusiness.Delete(masp);
            return Ok();
        }
        [Route("sp-phan-trang")]
        [HttpPost]
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
                int MALOAI = 1;
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
        public SanphamModel GetDatabyID(int id)
        {
            return _SanphamBusiness.GetDatabyID(id);
        }
        [Route("sp-theo-loai/{url}/{page}/{size}")]
        [HttpGet]
        public List<SanphamModel> Sptheoloai(string url, int? page, int? size)
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
