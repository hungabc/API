using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class LoaispBusiness:ILoaispBusiness
    {
        private ILoaispRepository _res;
        public LoaispBusiness(ILoaispRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<LoaispModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public bool Create(LoaispModel model)
        {
            return _res.Create(model);
        }
    }
}
