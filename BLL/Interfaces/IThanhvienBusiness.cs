using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface IThanhvienBusiness
    {
        List<ThanhvienModel> GetDataAll();
    }
}
