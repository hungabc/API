using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class HoadonbanBusiness : IHoadonbanBusiness
    {
        private IHoadonbanRepository _res;
        public HoadonbanBusiness(IHoadonbanRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<HoadonbanModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
