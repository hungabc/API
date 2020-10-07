using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class TintucRepository : ITintucRepository
    {

        private IDatabaseHelper _dbHelper;
        public TintucRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<TintucModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "gettintuc");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TintucModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(TintucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "themtintuc",
                "@MATT", model.MATT,
                "@TIEUDE", model.TIEUDE,
                "@URL", model.URL,
                "@HINH", model.HINH,
                "@NGAYDANG", model.NGAYDANG,
                "@TOMTAT", model.TOMTAT,
                "@NOIDUNG", model.NOIDUNG,
                "@TENDANGNHAP", model.TENDANGNHAP,
                "@MANHOM", model.MANHOM,
                "@KEYWORD", model.KEYWORD
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

