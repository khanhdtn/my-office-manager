using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DAO
{
    public class DODocument:DOPhieu
    {
        private long _ID;
        private string _NAME;
        private string _PHIEN_BAN;
        private string _MO_TA;
        private long _LOAI_TAI_LIEU_ID;
        private string _VISIBLE_BIT;
        private long _NGUOI_CAP_NHAT;
        private DateTime _NGAY_CAP_NHAT;
        private long _DATA_ID;
        private DataSet _DetailDataSet;
          
        public long ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }

        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string GetNAME() { return _NAME; }
        public string PHIEN_BAN
        {
            get { return _PHIEN_BAN; }
            set { _PHIEN_BAN = value; }
        }
        public string GetPHIEN_BAN() { return _PHIEN_BAN; }
        public string MO_TA
        {
            get { return _MO_TA; }
            set { _MO_TA = value; }
        }
        public string GetMO_TA() { return _MO_TA; }
        public long LOAI_TAI_LIEU_ID
        {
            get { return _LOAI_TAI_LIEU_ID; }
            set { _LOAI_TAI_LIEU_ID = value; }
        }
        public long GetLOAI_TAI_LIEU_ID() { return _LOAI_TAI_LIEU_ID; }
        public string VISIBLE_BIT
        {
            get { return _VISIBLE_BIT; }
            set { _VISIBLE_BIT = value; }
        }
        public string GetVISIBLE_BIT() { return _VISIBLE_BIT; }
        
        public long NGUOI_CAP_NHAT
        {
            get { return _NGUOI_CAP_NHAT; }
            set { _NGUOI_CAP_NHAT = value; }
        }
        public long GetNGUOI_CAP_NHAT() { return _NGUOI_CAP_NHAT; }
        public DateTime NGAY_CAP_NHAT
        {
            get { return _NGAY_CAP_NHAT; }
            set { _NGAY_CAP_NHAT = value; }
        }
        public DateTime GetNGAY_CAP_NHAT() { return _NGAY_CAP_NHAT; }
        public long DATA_ID
        {
            get { return this._DATA_ID; }
            set { this._DATA_ID = value; }
        }
        public long GetDATA_ID() { return _DATA_ID; }
        public DataSet DetailDataSet
        {
            get { return this._DetailDataSet; }
            set { this._DetailDataSet = value; }
        }
        public DataSet GetDetailDataset() { return _DetailDataSet; }
        public DODocument() { }

        public DODocument
        (
            long Id,
            string TenTaiLieu,
            string PhienBan,
            string MoTa,
            long LoaiTaiLieuId,
            string VisibleBit,
            long NguoiCapNhat,
            DateTime NgayCapNhat,
            long DataId
        )
        {
            this._ID = Id;
            this._NAME = TenTaiLieu;
            this._PHIEN_BAN = PhienBan;
            this._MO_TA = MoTa;
            this._LOAI_TAI_LIEU_ID = LoaiTaiLieuId;
            this._VISIBLE_BIT = VisibleBit;
            this._NGUOI_CAP_NHAT = NguoiCapNhat;
            this._NGAY_CAP_NHAT = NgayCapNhat;
            this._DATA_ID = DataId;
            
        }
     //   public DODocument
     //(
     //    long Id,
     //    string TenTaiLieu,
     //    string PhienBan,
     //    string MoTa,
     //    long LoaiTaiLieuId,
     //    string VisibleBit,
     //    long NguoiCapNhat,
     //    DateTime NgayCapNhat,
     //    long DataId
     //)
     //   {
     //       this._ID = Id;
     //       this._NAME = TenTaiLieu;
     //       this._PHIEN_BAN = PhienBan;
     //       this._MO_TA = MoTa;
     //       this._LOAI_TAI_LIEU_ID = LoaiTaiLieuId;
     //       this._VISIBLE_BIT = VisibleBit;
     //       this._NGUOI_CAP_NHAT = NguoiCapNhat;
     //       this._NGAY_CAP_NHAT = NgayCapNhat;
     //       this._DATA_ID = DataId;
     //   }
        
    }
}
