using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    public class DOBaiViet:DOPhieu
    {
        #region Các thuộc tính
        private long _ID=-1;
        private string _CHU_DE;
        private byte[] _NOI_DUNG;
        private long _SO_LAN_XEM;
        private long _SO_LAN_TRA_LOI;
        private DateTime _NGAY_GUI;
        private long _NGUOI_GUI;
        private long _ID_NHOM_DIEN_DAN=-1;
        private long _ID_CHUYEN_MUC=-1;
        private long _ID_BAI_VIET_PARENT=-1;
        private DataSet _DSTapTinDinhKem;

      
        #endregion
        #region Định nghĩa các thuộc tính
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return _ID; }
        public string CHU_DE
        {
            get { return _CHU_DE; }
            set { _CHU_DE = value; }
        }
        public string GetCHU_DE() { return _CHU_DE; }
        public byte[] NOI_DUNG
        {
            get { return _NOI_DUNG; }
            set { _NOI_DUNG = value; }
        }
        public byte[] GetNOI_DUNG() { return _NOI_DUNG; }
        public long SO_LAN_XEM
        {
            get { return _SO_LAN_XEM; }
            set { _SO_LAN_XEM = value; }
        }
        public long GetSO_LAN_XEM() { return _SO_LAN_XEM; }
        public long SO_LAN_TRA_LOI
        {
            get { return _SO_LAN_TRA_LOI; }
            set { _SO_LAN_TRA_LOI=value; }
        }
        public long GetSO_LAN_TRA_LOI() { return _SO_LAN_TRA_LOI; }
        public DateTime NGAY_GUI
        {
            get { return _NGAY_GUI; }
            set { _NGAY_GUI = value; }
        }
        public DateTime GetNGAY_GUI() { return _NGAY_GUI; }
        public long NGUOI_GUI
        {
            get { return _NGUOI_GUI; }
            set { _NGUOI_GUI = value; }
        }
        public long GetNGUOI_GUI() { return _NGUOI_GUI; }
        public long ID_NHOM_DIEN_DAN
        {
            get { return _ID_NHOM_DIEN_DAN; }
            set { _ID_NHOM_DIEN_DAN = value; }
        }
        public long GetID_NHOM_DIEN_DAN() { return _ID_NHOM_DIEN_DAN; }
        public long ID_CHUYEN_MUC
        {
            get { return _ID_CHUYEN_MUC; }
            set { _ID_CHUYEN_MUC = value; }
        }
        public long GetID_CHUYEN_MUC() { return _ID_CHUYEN_MUC; }
        public long ID_BAI_VIET_PARENT
        {
            get { return _ID_BAI_VIET_PARENT; }
            set { _ID_BAI_VIET_PARENT = value; }
        }
        public long GetID_BAI_VIET_PARENT() { return _ID_BAI_VIET_PARENT; }
        public DataSet DSTapTinDinhKem
        {
            get { return _DSTapTinDinhKem; }
            set { _DSTapTinDinhKem = value; }
        }
        
        #endregion
        #region Các hàm khởi tạo
        public DOBaiViet() { }
        public DOBaiViet(long ID, string CHU_DE, byte[] NOI_DUNG, long SO_LAN_XEM, long SO_LAN_TRA_LOI,
            DateTime NGAY_GUI, long NGUOI_GUI, long ID_NHOM_DIEN_DAN,long ID_CHUYEN_MUC, long ID_BAI_VIET_PARENT)
        {
            this._ID = ID;
            this._CHU_DE = CHU_DE;
            this._NOI_DUNG = NOI_DUNG;
            this._SO_LAN_XEM = SO_LAN_XEM;
            this._SO_LAN_TRA_LOI = SO_LAN_TRA_LOI;
            this._NGAY_GUI = NGAY_GUI;
            this._NGUOI_GUI = NGUOI_GUI;
            this._ID_NHOM_DIEN_DAN = ID_NHOM_DIEN_DAN;
            this._ID_CHUYEN_MUC = ID_CHUYEN_MUC;
            this._ID_BAI_VIET_PARENT = ID_BAI_VIET_PARENT;
        }
        #endregion
    }
}
