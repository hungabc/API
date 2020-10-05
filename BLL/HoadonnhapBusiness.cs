using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class HoadonnhapBusiness : IHoadonnhapBusiness
    {
        private IHoadonnhapRepository _res;
        public HoadonnhapBusiness(IHoadonnhapRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<HoadonnhapModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
