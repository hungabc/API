using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class ThanhvienBusiness : IThanhvienBusiness
    {
        private IThanhvienRepository _res;
        public ThanhvienBusiness(IThanhvienRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<ThanhvienModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
