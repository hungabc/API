using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class NccBusiness : INccBusiness
    {
        private INccRepository _res;
        public NccBusiness(INccRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<NccModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
