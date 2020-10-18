using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ILoaispRepository
    {
        List<LoaispModel> GetDataAll();
        bool Create(LoaispModel model);
        LoaispModel GetDatabyID(string id);
        bool Update(LoaispModel model);
        bool Delete(string id);
        List<LoaispModel> GetData();
    }
}