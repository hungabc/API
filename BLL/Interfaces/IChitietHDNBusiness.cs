﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface IChitietHDNBusiness
    {
        List<ChitietHDNModel> GetDataAll();
    }
}
