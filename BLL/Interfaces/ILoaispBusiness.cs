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
        LoaispModel GetDatabyID(string id);
        bool Update(LoaispModel model);
        bool Delete(string id);
    }
}
