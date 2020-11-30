using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IThanhvienRepository
    {
        List<ThanhvienModel> GetDataAll();
        bool Create(ThanhvienModel model);
        bool Update(ThanhvienModel model);
        bool Delete(string id);
        ThanhvienModel Login(ThanhvienModel thanhvien);
    }
}