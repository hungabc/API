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
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool Update(NccModel model)
        {
            return _res.Update(model);
        }
        public bool Create(NccModel model)
        {
            return _res.Create(model);
        }
    }
}
