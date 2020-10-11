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
        SanphamModel GetDatabyID(string id);
        List<SanphamModel> Search(int pageIndex, int pageSize, out long total, int MALOAI);
        List<SanphamModel> Phantrang(int pageIndex, int pageSize, out long total);
    }
}