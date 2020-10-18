using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IHoadonbanRepository
    {
        List<HoadonbanModel> GetDataAll();
        bool Create(HoadonbanModel model);
    }
}