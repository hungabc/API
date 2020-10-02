using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class Sanpham : ISanpham
    {
        private IDatabaseHelper _dbHelper;
        public Sanpham(IDatabaseHelper dbHelper)
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
 
    }
}
