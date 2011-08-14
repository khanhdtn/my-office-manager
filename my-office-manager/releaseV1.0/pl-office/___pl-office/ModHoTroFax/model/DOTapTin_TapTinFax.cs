using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;

namespace DTO
{
    public class DOTapTin_TapTinFax : DOPhieu
    {
        #region Khai báo các thuộc tính của đối tượng
        private long _ID;
        private string _TIEU_DE;
        private string _TEN_FILE;
        private byte[] _NOI_DUNG;
        private long _NGUOI_CAP_NHAT;
        private DateTime _NGAY_CAP_NHAT;
        private string _GHI_CHU;
        private DataSet _DetailDataset;
        private long _HO_TRO_FAX_ID;
        private decimal _SO_TO;
        private string _YEU_CAU;
        #endregion

        #region Khởi tạo đối tượng
        public DOTapTin_TapTinFax() { }
        public DOTapTin_TapTinFax(long ID, string TIEU_DE, string TEN_FILE, byte[] NOI_DUNG, 
                        long NGUOI_CAP_NHAT, DateTime NGAY_CAP_NHAT, string GHI_CHU,
                        long HO_TRO_FAX_ID, decimal SO_TO, string YEU_CAU) 
        {
            this._ID = ID;
            this._TIEU_DE = TIEU_DE;
            this._TEN_FILE = TEN_FILE;
            this._NOI_DUNG = NOI_DUNG;
            this._NGUOI_CAP_NHAT = NGUOI_CAP_NHAT;
            this._NGAY_CAP_NHAT = NGAY_CAP_NHAT;
            this._GHI_CHU = GHI_CHU;
            this._HO_TRO_FAX_ID = HO_TRO_FAX_ID;
            this._YEU_CAU = YEU_CAU;
            this._SO_TO = SO_TO;

        }
        #endregion

        #region Khởi tạo các thuộc tính
        public long ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public long GetID() { return this._ID; }
        public string TIEU_DE
        {
            set { _TIEU_DE = value; }
            get { return _TIEU_DE; }
        }
        public string GetTIEU_DE() {return this._TIEU_DE; }
        public string TEN_FILE
        {
            set { _TEN_FILE = value; }
            get { return _TEN_FILE; }
        }
        public string GetTEN_FILE() { return this._TEN_FILE; }   
        public byte[] NOI_DUNG
        {
            set { _NOI_DUNG = value; }
            get { return _NOI_DUNG; }
        }
        public byte[] GetNOI_DUNG() { return this._NOI_DUNG; }
        public long NGUOI_CAP_NHAT
        {
            set { _NGUOI_CAP_NHAT = value; }
            get { return _NGUOI_CAP_NHAT; }
        }
        public long GetNGUOI_CAP_NHAT() { return this._NGUOI_CAP_NHAT; }
        public DateTime NGAY_CAP_NHAT
        {
            set { _NGAY_CAP_NHAT = value; }
            get { return _NGAY_CAP_NHAT; }
        }
        public DateTime GetNGAY_CAP_NHAT() { return this._NGAY_CAP_NHAT; }
        public string GHI_CHU
        {
            set { _GHI_CHU = value; }
            get { return _GHI_CHU; }
        }
        public string GetGHI_CHU() { return this._GHI_CHU; }
        public DataSet DetailDataset
        {
            set { _DetailDataset = value; }
            get { return _DetailDataset; }
        }
        public DataSet GetDetailDataset() { return this._DetailDataset; }
        public long HO_TRO_FAX_ID
        {
            get { return _HO_TRO_FAX_ID; }
            set { _HO_TRO_FAX_ID = value; }
        }
        public long GetHO_TRO_FAX_ID() { return this._HO_TRO_FAX_ID; }
        
        public decimal SO_TO
        {
            get { return _SO_TO; }
            set { _SO_TO = value; }
        }
        public decimal GetSO_TO() { return this._SO_TO; }
        
        public string YEU_CAU
        {
            get { return _YEU_CAU; }
            set { _YEU_CAU = value; }
        }
        public string GetYEU_CAU() { return this._YEU_CAU; }
        #endregion
    }
}


