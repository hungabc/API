using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface ISanphamRepository
    {
        bool Create(SanphamModel model);
        List<SanphamModel> GetDataAll();
        SanphamModel GetDatabyID(int id);
        List<SanphamModel> SanPhamMoi(int soluong);
        List<SanphamModel> Search(int pageIndex, int pageSize, out long total, int MALOAI);
        List<SanphamModel> Phantrang(int pageIndex, int pageSize, out long total);
        List<SanphamModel> SpTheoLoai(int pageIndex, int pageSize, out long total, string url);
        bool Update(SanphamModel model);
        bool Delete(int id);
        List<SanphamModel> TimKiemSanPham(string keyWord, int? maLoai, int? minPrice, int? maxPrice, int? sapXep, int? index, int? size, out long total);
    }
}