using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ChitietDHRepository : IChitietDHRepository
    {

        private IDatabaseHelper _dbHelper;
        public ChitietDHRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<ChitietDHModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getChitietDH");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChitietDHModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

