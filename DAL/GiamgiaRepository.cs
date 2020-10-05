using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class GiamgiaRepository : IGiamgiaRepository
    {

        private IDatabaseHelper _dbHelper;
        public GiamgiaRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<GiamgiaModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getgia");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiamgiaModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

