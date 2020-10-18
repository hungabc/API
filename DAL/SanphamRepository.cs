using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class SanphamRepository : ISanphamRepository
    {

        private IDatabaseHelper _dbHelper;
        public SanphamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<SanphamModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getsanpham");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanphamModel> Phantrang(int pageIndex, int pageSize, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "phantrang", "@page_index", pageIndex,
                    "@page_size", pageSize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanphamModel> SanPhamMoi(int soluong)
        { 
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sanphammoi", "@SOLUONG", soluong);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
          
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(SanphamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "themsanpham",
                "@MASP", model.MASP,
                "@MACODE", model.MACODE,
                "@TENSP", model.TENSP,
                "@URL", model.URL,
                "@GIA", model.GIA,
                "@MAGIAMGIA", model.MAGIAMGIA,
                "@HINH", model.HINH,
                "@SOLUONGTON", model.SOLUONGTON,
                "@NGAYNHAP", model.NGAYNHAP,
                "@BANCHAY", model.BANCHAY,
                "@MOTA", model.MOTA,
                "@KEYWORD", model.KEYWORD,
                "@ANHIEN", model.ANHIEN,
                "@MANCC", model.MANCC,
                "@MALOAI", model.MALOAI
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanphamModel> Search(int pageIndex, int pageSize, out long total, int MALOAI)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "timkiemphantrang",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@MALOAI", MALOAI);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanphamModel> SpTheoLoai(int pageIndex, int pageSize, out long total, string url)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getsanphamtheoloai",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@url", url);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanphamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SanphamModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "laytheomasp",
                     "@MASP", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanphamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "xoasanpham",
                "@MASP", id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(SanphamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "suasanpham",
                "@MASP", model.MASP,
                "@MACODE", model.MACODE,
                "@TENSP", model.TENSP,
                "@URL", model.URL,
                "@GIA", model.GIA,
                "@MAGIAMGIA", model.MAGIAMGIA,
                "@HINH", model.HINH,
                "@SOLUONGTON", model.SOLUONGTON,
                "@NGAYNHAP", model.NGAYNHAP,
                "@BANCHAY", model.BANCHAY,
                "@MOTA", model.MOTA,
                "@KEYWORD", model.KEYWORD,
                "@ANHIEN", model.ANHIEN,
                "@MANCC", model.MANCC,
                "@MALOAI", model.MALOAI
                );
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

