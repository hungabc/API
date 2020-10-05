using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface INhomtinRepository
    {
        List<NhomtinModel> GetDataAll();
    }
}