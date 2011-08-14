using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    [Serializable]
    public class DODmNhanVien : DOPhieu
    {
        #region Fields
        public long ID;
        public string MA_NV;
        public string CMND;
        public DateTime? NGAY_SINH;
        public string DIEN_THOAI;
        public string DIA_CHI ;
        public string EMAIL;
        public string VISIBLE_BIT;
        public long? DEPARTMENT_ID;
        public string NAME;   
        public DataSet DetailDataSet;
        #endregion

        #region Gets
        public long GetID()
        {
            return this.ID;
        }
        public string GetMA_NV()
        {
            return this.MA_NV;
        }
        public string GetCMND()
        {
            return this.CMND;
        }
        public DateTime? GetNGAY_SINH()
        {
            return this.NGAY_SINH;
        }
        public string GetDIEN_THOAI()
        {
            return this.DIEN_THOAI;
        }
        public string GetDIA_CHI()
        {
            return this.DIA_CHI;
        }
        public string GetEMAIL()
        {
            return this.EMAIL;
        }
        public string GetVISIBLE_BIT()
        {
            return this.VISIBLE_BIT;
        }
        public long? GetDEPARTMENT_ID()
        {
            return this.DEPARTMENT_ID;
        }
        public string GetNAME()
        {
            return this.NAME;
        }
        public DataSet GetDetailDataSet()
        {
            return (this.DetailDataSet != null) ? this.DetailDataSet : new DataSet();
        }
        #endregion

        #region Contructors
        public DODmNhanVien() { }
        #endregion
    }
}
