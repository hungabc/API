using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class SanphamBusiness : ISanphamBusiness
    {
        private ISanphamRepository _res;
        public SanphamBusiness(ISanphamRepository SanphamGroupRes)
        {
            _res = SanphamGroupRes;
        }
        public List<SanphamModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<SanphamModel> PhanTrang(int pageIndex, int pageSize, out long total)
        {
            return _res.Phantrang(pageIndex, pageSize, out  total);
        }
        public List<SanphamModel> SPMoi(int soluong)
        {
            return _res.SanPhamMoi(soluong);
        }
        public bool Create(SanphamModel model)
        {
            return _res.Create(model);
        }
        public SanphamModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<SanphamModel> Search(int pageIndex, int pageSize, out long total, int MALOAI)
        {
            return _res.Search(pageIndex, pageSize, out total, MALOAI);
        }
        public List<SanphamModel> SanPhamTheoLoai(int pageIndex, int pageSize, out long total, string url)
        {
            return _res.SpTheoLoai(pageIndex, pageSize, out total, url);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(SanphamModel model)
        {
            return _res.Update(model);
        }
    }
}
