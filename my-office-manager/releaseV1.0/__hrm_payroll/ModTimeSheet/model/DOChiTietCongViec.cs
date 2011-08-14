using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data;


namespace ProtocolVN.Plugin.TimeSheet.bo
{
    [Serializable]
    public class DOChiTietCongViec : DOPhieu
    {
        public long _CTCCV_ID;
        public long _LCV_ID;
        public long _NV_ID;
        public string _MO_TA;
        public DateTime? _BAT_DAU;
        public DateTime? _KET_THUC;
        public TimeSpan _THOI_GIAN_THUC_HIEN;
        public DateTime? _NGAY_LAM_VIEC;
        public DateTime? _NGAY_CAP_NHAT;
        public long _NGUOI_CAP_NHAT;
        public string _DUYET;
        public long _NGUOI_DUYET;
        public DateTime? _NGAY_DUYET;
        public DataSet _DetailDataset;

        public DOChiTietCongViec() { }
        public DOChiTietCongViec(long CTCCV_ID, long LCV_ID,
            long NV_ID, string MO_TA, DateTime? BAT_DAU, DateTime? KET_THUC,
            DateTime? NGAY_CAP_NHAT, long NGUOI_CAP_NHAT, string DUYET,
            DateTime? NGAY_DUYET, long NGUOI_DUYET)
        {
            this._CTCCV_ID = CTCCV_ID;
            this._LCV_ID = LCV_ID;
            this._NV_ID = NV_ID;
            this._MO_TA = MO_TA;
            this._BAT_DAU = BAT_DAU;
            this._KET_THUC = KET_THUC;
            this._NGAY_CAP_NHAT = NGAY_CAP_NHAT;
            this._NGUOI_CAP_NHAT = NGUOI_CAP_NHAT;
            this._DUYET = DUYET;
            this._NGUOI_DUYET = NGUOI_DUYET;
            this._NGAY_DUYET = NGAY_DUYET;
        }
        public long CTCCV_ID
        {
            get { return _CTCCV_ID; }
            set { _CTCCV_ID = value; }
        }
        public long GetCTCCV_ID() { return _CTCCV_ID; }

        public long LCV_ID
        {
            get { return _LCV_ID; }
            set { _LCV_ID = value; }
        }
        public long GetLCV_ID() { return _LCV_ID; }

        public string MO_TA
        {
            get { return _MO_TA; }
            set { _MO_TA = value; }
        }
        public string GetMO_TA() { return _MO_TA; }
        public DateTime? BAT_DAU
        {
            get { return _BAT_DAU; }
            set { _BAT_DAU = value; }
        }
        public DateTime? GetBAT_DAU() { return _BAT_DAU; }
        public DateTime? KET_THUC
        {
            get { return _KET_THUC; }
            set { _KET_THUC = value; }
        }
        public DateTime? GetKET_THUC() { return _KET_THUC; }
        public TimeSpan THOI_GIAN_THUC_HIEN
        {
            get { return _THOI_GIAN_THUC_HIEN; }
            set { _THOI_GIAN_THUC_HIEN = value; }
        }
        public TimeSpan GetTHOI_GIAN_THUC_HIEN() { return _THOI_GIAN_THUC_HIEN; }
        public DateTime? NGAY_LAM_VIEC
        {
            get { return _NGAY_LAM_VIEC; }
            set { _NGAY_LAM_VIEC = NGAY_LAM_VIEC; }
        }
        public DateTime? GetNGAY_LAM_VIEC() { return _NGAY_LAM_VIEC; }
        public DateTime? NGAY_CAP_NHAT
        {
            get { return _NGAY_CAP_NHAT; }
            set { _NGAY_CAP_NHAT = NGAY_CAP_NHAT; }
        }
        public DateTime? GetNgay_CAP_NHAT() { return _NGAY_CAP_NHAT; }
        public string DUYET
        {
            get { return _DUYET; }
            set { _DUYET = DUYET; }
        }
        public string GetDUYET() { return _DUYET; }
        public long NGUOI_DUYET
        {
            get { return _NGUOI_DUYET; }
            set { _NGUOI_DUYET = NGUOI_DUYET; }
        }
        public long GetNGUOI_DUYET() { return _NGUOI_DUYET; }
        public DateTime? NGAY_DUYET
        {
            get { return _NGAY_DUYET; }
            set { _NGAY_DUYET = value; }
        }
        public DateTime? GetNGAY_DUYET() { return _NGAY_DUYET; }
        public DataSet DetailDataset
        {
            get { return _DetailDataset; }
            set { _DetailDataset = value; }
        }
        public DataSet GetDetailDataset() { return _DetailDataset; }
    }
}
