using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface IThanhvienBusiness
    {
        List<ThanhvienModel> GetDataAll();
        bool Update(ThanhvienModel model);
        bool Delete(string id);
        bool Create(ThanhvienModel model);
        ThanhvienModel Login(ThanhvienModel thanhvien);
        bool KiemTraUser(string tenDangNhap, string soDienThoai, string email);
    }
}
