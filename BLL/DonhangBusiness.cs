using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class DonhangBusiness : IDonhangBusiness
    {
        private IDonhangRepository _res;
        public DonhangBusiness(IDonhangRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<DonhangModel> GetDataAll(int pageIndex, int pageSize, out long total)
        {
            var kq= _res.GetDataAll(pageIndex,pageSize,out total);
            foreach(var item in kq)
            {
                item.chitiet = _res.GetChiTiet(item.MADH);
            }
            return kq;
        }
        public List<ChitietDHModel> GetChiTiet(int madonhang)
        {
            var kq = _res.GetChiTiet(madonhang);
           
            return kq;
        }
        public List<DonhangModel> Getbytrangthai(int pageIndex, int pageSize,string trangthai, out long total)
        {
            var kq = _res.Getbytrangthai(pageIndex, pageSize, trangthai, out total);
            foreach (var item in kq)
            {
                item.chitiet = _res.GetChiTiet(item.MADH);
            }
            return kq;
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool Update(DonhangModel model)
        {
            return _res.Update(model);
        }
        public DonhangModel Create(DonhangModel model)
        {
            return _res.Create(model);
        }
        public DonhangModel Thaydoitrangthai(int masp)
        {
            return _res.Thaydoitrangthai(masp);
        }
        public DonhangModel huydon(int masp)
        {
            return _res.huydon(masp);
        }
    }
}
