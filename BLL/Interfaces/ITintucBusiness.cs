using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface ITintucBusiness
    {
        List<TintucModel> GetDataAll();
        bool Create(TintucModel model);
    }
}
