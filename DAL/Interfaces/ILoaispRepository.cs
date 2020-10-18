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
        LoaispModel GetDatabyID(int id);
        bool Update(LoaispModel model);
        bool Delete(int id);
        List<LoaispModel> GetData();
    }
}