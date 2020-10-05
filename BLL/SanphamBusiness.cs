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
        public SanphamBusiness(ISanphamRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<SanphamModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
