using System;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    /// <summary>
    /// Lớp hỗ trợ In ấn
    /// </summary>
    [Serializable]
    public class DOHoTroInAn : DOPhieu
    {
        #region Fields 
        private long _ID;        
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return this._ID; }
        private string _MUC_DICH;

        public string MUC_DICH
        {
            get { return _MUC_DICH; }
            set { _MUC_DICH = value; }
        }
        public string GetMUC_DICH() { return this._MUC_DICH; }
        private long _NGUOI_GUI_ID;

        public long NGUOI_GUI_ID
        {
            get { return _NGUOI_GUI_ID; }
            set { _NGUOI_GUI_ID = value; }
        }
        public long GetNGUOI_GUI_ID() { return this._NGUOI_GUI_ID; }
        private long _NGUOI_NHAN_ID;

        public long NGUOI_NHAN_ID
        {
            get { return _NGUOI_NHAN_ID; }
            set { _NGUOI_NHAN_ID = value; }
        }
        public long GetNGUOI_NHAN_ID() { return this._NGUOI_NHAN_ID; }
        private DateTime _THOI_GIAN_CAP_NHAT;

        public DateTime THOI_GIAN_CAP_NHAT
        {
            get { return _THOI_GIAN_CAP_NHAT; }
            set { _THOI_GIAN_CAP_NHAT = value; }
        }
        public DateTime GetTHOI_GIAN_CAP_NHAT() { return this._THOI_GIAN_CAP_NHAT; }
        private long _TINH_TRANG_IN_ID;

        public long TINH_TRANG_IN_ID
        {
            get { return _TINH_TRANG_IN_ID; }
            set { _TINH_TRANG_IN_ID = value; }
        }
        public long GetTINH_TRANG_IN_ID() { return this._TINH_TRANG_IN_ID; }
        private long _MUC_DO_UU_TIEN_ID;

        public long MUC_DO_UU_TIEN_ID
        {
            get { return _MUC_DO_UU_TIEN_ID; }
            set { _MUC_DO_UU_TIEN_ID = value; }
        }
        public long GetMUC_DO_UU_TIEN_ID() { return this._MUC_DO_UU_TIEN_ID; }
        private DataSet _DetailDataset;

        public DataSet DetailDataset
        {
            get { return _DetailDataset; }
            set { _DetailDataset = value; }
        }
        public DataSet GetDetailDataset() { return this._DetailDataset; }
        #endregion

        #region Contructor
        public DOHoTroInAn() { }
        public DOHoTroInAn(long Id,string MucDich,long NguoiGuiID,long NguoiNhanID,DateTime ThoiGianCapNhat,long TinhTrangID,long DoUuTienID)
        {
            this._ID=Id;
            this._MUC_DICH=MucDich;
            this._NGUOI_NHAN_ID=NguoiNhanID;
            this._NGUOI_GUI_ID=NguoiGuiID;
            this._THOI_GIAN_CAP_NHAT=ThoiGianCapNhat;
            this._TINH_TRANG_IN_ID=TinhTrangID;            
            this._MUC_DO_UU_TIEN_ID=DoUuTienID;
        }
        #endregion
    }
}
