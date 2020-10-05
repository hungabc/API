using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class NhomtinBusiness : INhomtinBusiness
    {
        private INhomtinRepository _res;
        public NhomtinBusiness(INhomtinRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<NhomtinModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
