using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    public class DOBugProduct:DOPhieu
    {
        #region Các thuộc tính
        private long _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return _ID; }
        private string _NAME;

        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string GetNAME() { return _NAME; }
        private long _NGUOI_GUI;

        public long NGUOI_GUI
        {
            get { return _NGUOI_GUI; }
            set { _NGUOI_GUI = value; }
        }
        public long GetNGUOI_GUI() { return _NGUOI_GUI; }
        private DateTime _NGAY_GUI;

        public DateTime NGAY_GUI
        {
            get { return _NGAY_GUI; }
            set { _NGAY_GUI = value; }
        }
        public DateTime GetNGAY_GUI() { return _NGAY_GUI; }
        private string _NGUOI_NHAN;

        public string NGUOI_NHAN
        {
            get { return _NGUOI_NHAN; }
            set { _NGUOI_NHAN = value; }
        }
        public string GetNGUOI_NHAN() { return _NGUOI_NHAN; }
        
        private long _MUC_UT;

        public long MUC_UT
        {
            get { return _MUC_UT; }
            set { _MUC_UT = value; }
        }
        public long GetMUC_UT() { return _MUC_UT; }
        private long _TINH_TRANG;

        public long TINH_TRANG
        {
            get { return _TINH_TRANG; }
            set { _TINH_TRANG = value; }
        }
        public long GetTINH_TRANG() { return _TINH_TRANG; }
        private byte[] _MO_TA_BUG;

        public byte[] MO_TA_BUG
        {
            get { return _MO_TA_BUG; }
            set { _MO_TA_BUG = value; }
        }
        public byte[] GetMO_TA_BUG() { return _MO_TA_BUG; }

        private long _LOAI_VAN_DE;

        public long LOAI_VAN_DE
        {
            get { return _LOAI_VAN_DE; }
            set { _LOAI_VAN_DE = value; }
        }
        public long GetLOAI_VAN_DE() { return _LOAI_VAN_DE; }

        private DataSet _DSFile;

        public DataSet DSFile
        {
            get { return _DSFile; }
            set { _DSFile = value; }
        }
        public DataSet GetDSFile() { return _DSFile; }
        #endregion

        #region Các hàm khởi tạo 
        public DOBugProduct() { }
        public DOBugProduct(long ID, string Name, long Nguoi_gui, DateTime Ngay_gui, string Nguoi_nhan, long Muc_ut, long Tinh_Trang, byte[] Mo_ta_bug, long Loai_van_de)
        {
            _ID = ID;
            _NAME = Name;
            _NGUOI_GUI = Nguoi_gui;
            _NGAY_GUI = Ngay_gui;
            _NGUOI_NHAN = Nguoi_nhan;
            _MUC_UT = Muc_ut;
            _TINH_TRANG = Tinh_Trang;
            _MO_TA_BUG = Mo_ta_bug;
            _LOAI_VAN_DE = Loai_van_de;
        }
        #endregion
    }
}
