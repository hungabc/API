﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface INccBusiness
    {
        List<NccModel> GetDataAll();
        bool Update(NccModel model);
        bool Delete(string id);
        bool Create(NccModel model);
    }
}
