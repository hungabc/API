using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ITintucRepository
    {
        List<TintucModel> GetDataAll();
        bool Create(TintucModel model);
    }
}