using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace BLL
{
    public partial class ThanhvienBusiness : IThanhvienBusiness
    {
        private IThanhvienRepository _res;
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(ThanhvienModel model)
        {
            return _res.Update(model);
        }
        public ThanhvienBusiness(IThanhvienRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<ThanhvienModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public ThanhvienModel Login(ThanhvienModel thanhvien)
        {
            var kq = _res.Login(thanhvien);
            return kq;
        }
        public bool Create(ThanhvienModel model)
        {
            return _res.Create(model);
        }
    }
}
