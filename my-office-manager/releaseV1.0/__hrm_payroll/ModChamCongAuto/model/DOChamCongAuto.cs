using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;
/*
 * Author : Trần Văn Châu
 * Email : chautv@protocolvn.net
 */
namespace DTO
{
    [Serializable]
    public class DOChamCongAuto : DOPhieu
    {
        #region Fields
        public long         ID;
        public long         NV_ID;
        public DateTime     NGAY;
        public string       SANG;
        public string       CHIEU;
        public decimal      THOI_GIAN_LAM_VIEC;
        public DataSet DetailDataSet;
        #endregion

        #region Gets
        public long GetID() {
            return this.ID;
        }
        public long GetNV_ID() {
            return this.NV_ID;
        }
        public DateTime GetNGAY() {
            return this.NGAY;
        }
        public string GetSANG() {
            return this.SANG;
        }
        public string GetCHIEU() {
            return this.CHIEU;
        }
        public decimal GetTHOI_GIAN_LAM_VIEC() {
            return this.THOI_GIAN_LAM_VIEC;
        }
        public DataSet GetDetailDataSet() {
            return (this.DetailDataSet!=null) ? this.DetailDataSet : new DataSet();
        }
        #endregion

        #region Contructors
        public DOChamCongAuto() { }
        #endregion
    }
}
