using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class TintucBusiness : ITintucBusiness
    {
        private ITintucRepository _res;
        public TintucBusiness(ITintucRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<TintucModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
