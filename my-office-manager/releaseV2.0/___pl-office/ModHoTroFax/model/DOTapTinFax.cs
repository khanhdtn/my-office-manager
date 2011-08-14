using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;

namespace DTO
{
    /// <summary>
    /// Lớp hỗ trợ In ấn
    /// </summary>
    [Serializable]
    public class DOTapTinFax : DOPhieu
    {
        #region Fields 
        private long _TAP_TIN_ID;

        public long TAP_TIN_ID
        {
            get { return _TAP_TIN_ID; }
            set { _TAP_TIN_ID = value; }
        }
        public long GetTAP_TIN_ID() { return this._TAP_TIN_ID; }
        private long _HO_TRO_FAX_ID;

        public long HO_TRO_FAX_ID
        {
            get { return _HO_TRO_FAX_ID; }
            set { _HO_TRO_FAX_ID = value; }
        }
        public long GetHO_TRO_FAX_ID() { return this._HO_TRO_FAX_ID; }
        private decimal _SO_TO;

        public decimal SO_TO
        {
            get { return _SO_TO; }
            set { _SO_TO = value; }
        }
        public decimal GetSO_TO() { return this._SO_TO; }
        private string _YEU_CAU;

        public string YEU_CAU
        {
            get { return _YEU_CAU; }
            set { _YEU_CAU = value; }
        }
        public string GetYEU_CAU() { return this._YEU_CAU; }
        #endregion

        #region Contructor(s)
        public DOTapTinFax() { }
        public DOTapTinFax(long HoTroFaxID, long TapTinID, decimal SoTo, string YeuCau) 
        {
            this._TAP_TIN_ID = TapTinID;
            this._HO_TRO_FAX_ID = HoTroFaxID;
            this._SO_TO = SoTo;
            this._YEU_CAU = YeuCau;
        }
        #endregion
    }
}
