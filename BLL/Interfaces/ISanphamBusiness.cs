using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface ISanphamBusiness
    {
        bool Create(SanphamModel model);
        List<SanphamModel> PhanTrang(int pageIndex, int pageSize, out long total);
        SanphamModel GetDatabyID(string id);
        List<SanphamModel> GetDataAll();
        List<SanphamModel> Search(int pageIndex, int pageSize, out long total, int MALOAI);
    }
}
