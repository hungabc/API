using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IDonhangRepository
    {
        List<DonhangModel> GetDataAll(int pageIndex, int pageSize, out long total);
        DonhangModel Create(DonhangModel model);
        bool Update(DonhangModel model);
        bool Delete(int id);
        List<ChitietDHModel> GetChiTiet(int madonhang);
        DonhangModel Thaydoitrangthai(int madh);
        DonhangModel huydon(int madh);
        List<DonhangModel> Getbytrangthai(int pageIndex, int pageSize, string trangthai, out long total);
    }
}