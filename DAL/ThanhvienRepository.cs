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
        public ThanhvienModel Login(ThanhvienModel thanhvien)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "dangnhap",
                    "@tendangnhap",thanhvien.TENDANGNHAP,"@matkhau",thanhvien.MATKHAU,
                    "@dienthoai",thanhvien.DIENTHOAI,"@email",thanhvien.EMAIL
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThanhvienModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool KiemTraUser(string tendangnhap, string sodienthoai,string email)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "kiemtra_user",
                    "@tendangnhap", tendangnhap, "@sodienthoai", sodienthoai,
                    "@email", email
                    );
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return (int)dt.Rows[0]["userS_count"]>0;//nếu >0 là return true, tức là trùng
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(ThanhvienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "themkhachhang",
                "@TENDANGNHAP", model.TENDANGNHAP,
                "@MATKHAU", model.MATKHAU,
                "@HOTEN", model.HOTEN,
                "@GIOITINH", model.GIOITINH,
                "@DIACHI", model.DIACHI,
                "@DIENTHOAI", model.DIENTHOAI,
                "@EMAIL", model.EMAIL,
                "@QUYEN", model.QUYEN,
                "@MAKICHHOAT", model.MAKICHHOAT,
                "@KICHHOAT", model.KICHHOAT
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
        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "xoakhachhang",
                "@TENDANGNHAP", id);
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
        public bool Update(ThanhvienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "suakhachhang",
                "@TENDANGNHAP", model.TENDANGNHAP,
                "@MATKHAU", model.MATKHAU,
                "@HOTEN", model.HOTEN,
                "@GIOITINH", model.GIOITINH,
                "@DIACHI", model.DIACHI,
                "@DIENTHOAI", model.DIENTHOAI,
                "@EMAIL", model.EMAIL,
                "@QUYEN", model.QUYEN,
                "@NGAYDANGKY", model.NGAYDANGKY,
                "@MAKICHHOAT", model.MAKICHHOAT,
                "@KICHHOAT", model.KICHHOAT
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

