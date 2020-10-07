using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ChitietHDNRepository : IChitietHDNRepository
    {

        private IDatabaseHelper _dbHelper;
        public ChitietHDNRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<ChitietHDNModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getchitiethdn");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChitietHDNModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(ChitietHDNModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "themchitiethdn",
                "@MACHITIETHDN", model.MACHITIETHDN,
                "@MAHDN", model.MAHDN,
                "@MANCC", model.MANCC,
                "@MASP", model.MASP,
                "@MASP", model.MASP,
                "@SOLUONG", model.SOLUONG,
                "@DONGIA", model.DONGIA,
                "@THANHTIEN", model.THANHTIEN
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

