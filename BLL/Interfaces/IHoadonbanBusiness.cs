using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface IHoadonbanBusiness
    {
        List<HoadonbanModel> GetDataAll();
        bool Create(HoadonbanModel model);
    }
}
