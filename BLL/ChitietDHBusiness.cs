using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class ChitietDHBusiness : IChitietDHBusiness
    {
        private IChitietDHRepository _res;
        public ChitietDHBusiness(IChitietDHRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<ChitietDHModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
