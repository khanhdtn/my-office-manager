using System;
using System.Data;
using ProtocolVN.Framework.Core;

namespace DTO
{
    public class DOBangTheoDoi : DOPhieu
    {
        #region 1. Thuộc tính bảng BANG_THEO_DOI
        private long _BTD_ID;
        private string _MA_BTD;
        private string _NAME;
        private DateTime? _NGAY_LAP;
        private long _NGUOI_LAP;
        private DateTime? _NGAY_KY;
        private long _NGUOI_KY;
        private DateTime? _NGAY_HIEU_LUC;
        private long _NGUOI_QUAN_LY;
        private byte[] _TAI_LIEU;
        private string _TEN_TAI_LIEU;
        private long _TINH_TRANG;
        private int _HINH_THUC_THONG_BAO;
        private string _GHI_CHU;
        private long _NGUOI_CAP_NHAT;
        private DateTime? _NGAY_CAP_NHAT;
        private DataSet _DetailDataSet;
        #endregion

        #region 2. Định nghĩa thuộc tính
        public DataSet DetailDataSet
        {
            get { return _DetailDataSet; }
            set { _DetailDataSet = value; }
        }
        
        public long BTD_ID
        {
            get { return this._BTD_ID; }
            set { this._BTD_ID = value; }
        }

        public string MA_BTD
        {
            get { return _MA_BTD; }
            set { _MA_BTD = value; }
        }

        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        public DateTime? NGAY_LAP
        {
            get { return _NGAY_LAP; }
            set { _NGAY_LAP = value; }
        }

        public long NGUOI_LAP
        {
            get { return this._NGUOI_LAP; }
            set { this._NGUOI_LAP = value; }
        }

        public DateTime? NGAY_KY
        {
            get { return _NGAY_KY; }
            set { _NGAY_KY = value; }
        }

        public long NGUOI_KY
        {
            get { return this._NGUOI_KY; }
            set { this._NGUOI_KY = value; }
        }
        
        public DateTime? NGAY_HIEU_LUC
        {
            get { return _NGAY_HIEU_LUC; }
            set { _NGAY_HIEU_LUC = value; }
        }

        public long NGUOI_QUAN_LY
        {
            get { return this._NGUOI_QUAN_LY; }
            set { this._NGUOI_QUAN_LY = value; }
        }

        public byte[] TAI_LIEU
        {
            get { return this._TAI_LIEU; }
            set { this._TAI_LIEU = value; }
        }

        public string TEN_TAI_LIEU
        {
            get { return _TEN_TAI_LIEU; }
            set { _TEN_TAI_LIEU = value; }
        }

        public long TINH_TRANG
        {
            get { return this._TINH_TRANG; }
            set { this._TINH_TRANG = value; }
        }

        public int HINH_THUC_THONG_BAO
        {
            get { return _HINH_THUC_THONG_BAO; }
            set { _HINH_THUC_THONG_BAO = value; }
        }

        public string GHI_CHU
        {
            get { return _GHI_CHU; }
            set { _GHI_CHU = value; }
        }

        public DateTime? NGAY_CAP_NHAT
        {
            get { return _NGAY_CAP_NHAT; }
            set { _NGAY_CAP_NHAT = value; }
        }

        public long NGUOI_CAP_NHAT
        {
            get { return this._NGUOI_CAP_NHAT; }
            set { this._NGUOI_CAP_NHAT = value; }
        }
        #endregion

        #region Khởi tạo
        public DOBangTheoDoi()
        { }

        public DOBangTheoDoi(long btd_id, string ma_btd, string name, DateTime? ngay_lap, long nguoi_lap, DateTime? ngay_ky, long nguoi_ky, DateTime? ngay_hieu_luc, long nguoi_quan_ly, byte[] tai_lieu, string ten_tai_lieu, long tinh_trang, int hinh_thuc_thong_bao, string ghi_chu, long nguoi_cap_nhat, DateTime? ngay_cap_nhat)
        {
            this._BTD_ID = btd_id;
            this._MA_BTD = ma_btd;
            this._NAME = name;
            this._NGAY_LAP = ngay_lap;
            this._NGUOI_LAP = nguoi_lap;
            this._NGAY_KY = ngay_ky;
            this._NGUOI_KY = nguoi_ky;
            this._NGAY_HIEU_LUC = ngay_hieu_luc;
            this._NGUOI_QUAN_LY = nguoi_quan_ly;
            this._TAI_LIEU = tai_lieu;
            this._TEN_TAI_LIEU = ten_tai_lieu;
            this._TINH_TRANG = tinh_trang;
            this._HINH_THUC_THONG_BAO = hinh_thuc_thong_bao;
            this._GHI_CHU = ghi_chu;
            this._NGUOI_CAP_NHAT = nguoi_cap_nhat;
            this._NGAY_CAP_NHAT = ngay_cap_nhat;
        }
        #endregion
    }
}
