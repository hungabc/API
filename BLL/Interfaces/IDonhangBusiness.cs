using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface IDonhangBusiness
    {
        List<DonhangModel> GetDataAll();
        bool Update(DonhangModel model);
        bool Delete(string id);
        bool Create(DonhangModel model);
    }
}
