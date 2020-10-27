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
        public List<DonhangModel> GetDataAll()
        {
            var kq= _res.GetDataAll();
            foreach(var item in kq)
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
    }
}
