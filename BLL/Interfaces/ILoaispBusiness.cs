using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface ILoaispBusiness
    {
        List<LoaispModel> GetDataAll();
        bool Create(LoaispModel model);
        LoaispModel GetDatabyID(int id);
        bool Update(LoaispModel model);
        bool Delete(int id);
    }
}
