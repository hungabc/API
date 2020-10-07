using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class ChitietHDBRepository : IChitietHDBRepository
    {

        private IDatabaseHelper _dbHelper;
        public ChitietHDBRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<ChitietHDBModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getchitiethdb");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChitietHDBModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(ChitietHDBModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "themchitiethdb",
                "@MACHITIETHDB", model.MACHITIETHDB,
                "@MAHDB", model.MAHDB,
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

