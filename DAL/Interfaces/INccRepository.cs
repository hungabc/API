using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface INccRepository
    {
        List<NccModel> GetDataAll();
        bool Create(NccModel model);
        bool Update(NccModel model);
        bool Delete(int id);
    }
}