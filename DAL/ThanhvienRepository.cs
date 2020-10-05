using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ThanhvienRepository : IThanhvienRepository
    {

        private IDatabaseHelper _dbHelper;
        public ThanhvienRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<ThanhvienModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getthanhvien");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThanhvienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

