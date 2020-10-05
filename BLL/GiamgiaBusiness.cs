using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial class GiamgiaBusiness:IGiamgiaBusiness
    {
        private IGiamgiaRepository _res;
        public GiamgiaBusiness(IGiamgiaRepository GiamgiaGroupRes)
        {
            _res = GiamgiaGroupRes;
        }
        public List<GiamgiaModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
       
    }
}
