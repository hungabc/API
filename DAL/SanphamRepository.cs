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
    }
}

