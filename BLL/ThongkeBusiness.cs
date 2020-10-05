using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class ThongkeBusiness : IThongkeBusiness
    {
        private IThongkeRepository _res;
        public ThongkeBusiness(IThongkeRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<ThongkeModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
