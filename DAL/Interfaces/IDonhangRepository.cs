using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IDonhangRepository
    {
        List<DonhangModel> GetDataAll();
        bool Create(DonhangModel model);
        bool Update(DonhangModel model);
        bool Delete(int id);
    }
}