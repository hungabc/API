using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface IDonhangBusiness
    {
        List<DonhangModel> GetDataAll(int pageIndex, int pageSize, out long total);
        bool Update(DonhangModel model);
        bool Delete(int id);
        DonhangModel Create(DonhangModel model);
        DonhangModel Thaydoitrangthai(int masp);
        DonhangModel huydon(int masp);
        List<ChitietDHModel> GetChiTiet(int madonhang);
        List<DonhangModel> Getbytrangthai(int pageIndex, int pageSize, string trangthai, out long total);
    }
}
