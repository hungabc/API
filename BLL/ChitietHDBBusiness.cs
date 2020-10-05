using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class ChitietHDBBusiness : IChitietHDBBusiness
    {
        private IChitietHDBRepository _res;
        public ChitietHDBBusiness(IChitietHDBRepository LoaispGroupRes)
        {
            _res = LoaispGroupRes;
        }
        public List<ChitietHDBModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
