using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class DonhangRepository : IDonhangRepository
    {

        private IDatabaseHelper _dbHelper;
        public DonhangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<DonhangModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdonhang");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonhangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonhangModel Create(DonhangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "themdonhang",
                
                "@TENDANGNHAP", model.TENDANGNHAP,
                "@DIACHINGUOINHAN", model.DIACHINGUOINHAN,
                "@TENKH",model.TENKH, "@EMAIL",model.EMAIL," @SDT",model.SDT
                );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return result.ConvertTo<DonhangModel>().FirstOrDefault();
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "xoadonhang",
                "@MADH", id);
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
        public bool Update(DonhangModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "suadonhang",
                "@MADH", model.MADH,
                "@TENDANGNHAP", model.TENDANGNHAP,
                "@NGAYDATHANG", model.NGAYDATHANG,
                "@NGAYYEUCAU", model.NGAYYEUCAU,
                "@DIACHINGUOINHAN", model.DIACHINGUOINHAN,
                "@TINHTRANG", model.TINHTRANG
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

