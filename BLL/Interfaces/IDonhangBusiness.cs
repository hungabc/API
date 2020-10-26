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
        bool Delete(int id);
        DonhangModel Create(DonhangModel model);
    }
}
