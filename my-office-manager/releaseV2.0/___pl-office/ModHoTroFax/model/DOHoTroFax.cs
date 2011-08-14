using System;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    /// <summary>
    /// Lớp hỗ trợ In ấn
    /// </summary>
    [Serializable]
    public class DOHoTroFax : DOPhieu
    {
        #region Fields 
        private long _ID;        
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return this._ID; }
        
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
        private long _TINH_TRANG_FAX_ID;

        public long TINH_TRANG_FAX_ID
        {
            get { return _TINH_TRANG_FAX_ID; }
            set { _TINH_TRANG_FAX_ID = value; }
        }
        public long GetTINH_TRANG_FAX_ID() { return this._TINH_TRANG_FAX_ID; }
        private long _MUC_DO_UU_TIEN_ID;

        public long MUC_DO_UU_TIEN_ID
        {
            get { return _MUC_DO_UU_TIEN_ID; }
            set { _MUC_DO_UU_TIEN_ID = value; }
        }
        public long GetMUC_DO_UU_TIEN_ID() { return this._MUC_DO_UU_TIEN_ID; }

        private string _GUI_DEN_SO;

        public string GUI_DEN_SO
        {
            get { return _GUI_DEN_SO; }
            set { _GUI_DEN_SO = value; }
        }
        public string GetGUI_DEN_SO() { return this._GUI_DEN_SO; }

        private string _TEN_NGUOI_NHAN;

        public string TEN_NGUOI_NHAN
        {
            get { return _TEN_NGUOI_NHAN; }
            set { _TEN_NGUOI_NHAN = value; }
        }
        public string GetTEN_NGUOI_NHAN() { return this._TEN_NGUOI_NHAN; }

        private string _NOI_DUNG_KEM_THEO;

        public string NOI_DUNG_KEM_THEO
        {
            get { return _NOI_DUNG_KEM_THEO; }
            set { _NOI_DUNG_KEM_THEO = value; }
        }
        public string GetNOI_DUNG_KEM_THEO() { return this._NOI_DUNG_KEM_THEO; }

        private DataSet _DsFile;

        public DataSet DsFile
        {
            get { return _DsFile; }
            set { _DsFile = value; }
        }

        private DataSet _DetailDataset;

        public DataSet DetailDataset
        {
            get { return _DetailDataset; }
            set { _DetailDataset = value; }
        }
        public DataSet GetDetailDataset() { return this._DetailDataset; }
        #endregion

        #region Contructor
        public DOHoTroFax() { }
        public DOHoTroFax(long Id,long NguoiGuiID,long NguoiNhanID
            ,DateTime ThoiGianCapNhat,long TinhTrangID,long DoUuTienID
            ,string GuiDenSo,string TenNguoiNhan,string NoiDungKemTheo)
        {
            this._ID=Id;
            this._NGUOI_NHAN_ID=NguoiNhanID;
            this._NGUOI_GUI_ID=NguoiGuiID;
            this._THOI_GIAN_CAP_NHAT=ThoiGianCapNhat;
            this._TINH_TRANG_FAX_ID=TinhTrangID;            
            this._MUC_DO_UU_TIEN_ID=DoUuTienID;
            this._GUI_DEN_SO = GuiDenSo;
            this._TEN_NGUOI_NHAN = TenNguoiNhan;
            this._NOI_DUNG_KEM_THEO = NoiDungKemTheo;
        }
        #endregion
    }
}
