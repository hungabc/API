using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class ChitietHDNBusiness : IChitietHDNBusiness
    {
        private IChitietHDNRepository _res;
        public ChitietHDNBusiness(IChitietHDNRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<ChitietHDNModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
