﻿using DAL.Helper;
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

        public List<DonhangModel> GetDataAll( int pageIndex,int pageSize,out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdonhang"," @page_index",pageIndex, @"page_size",pageSize);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];

                return dt.ConvertTo<DonhangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonhangModel GetByID(int id)
        {
            
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetDHByID", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                
                return dt.ConvertTo<DonhangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<DonhangModel> Getbytrangthai(int pageIndex, int pageSize,string trangthai, out long total)
        {
            total = 0;
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "getdhbytrangthai", " @page_index", pageIndex, @"page_size", pageSize, "@trang_thai", trangthai) ;
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];

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
        public List<ChitietDHModel> GetChiTiet(int madonhang) 
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "laytheomadh", "@MADH",madonhang);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChitietDHModel>().ToList();
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
        public DonhangModel Thaydoitrangthai(int madh)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "thaydoitrangthaidonhang","@madh",madh);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonhangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DonhangModel huydon(int madh)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "huydon", "@madh", madh);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DonhangModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

