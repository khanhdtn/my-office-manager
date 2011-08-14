using System;
using System.Collections.Generic;
using System.Text;

namespace office.model
{
    public class DOLenLop
    {
        #region 1. Các thuộc tính của bảng BANG_THEO_DOI
        private long _DTD_ID;
        private DateTime? _NGAY_LEN_LOP;
        private DateTime _THOI_GIAN_BAT_DAU;
        private DateTime _THOI_GIAN_KET_THUC;
        private long _NHAN_SU;
        private long _NGUOI_GIAO;
        private DateTime? _NGAY_GIAO;
        private string _GHI_CHU;
        private string _THONG_BAO;
        private long _BTD_ID;
        private long _LCV_ID;
        private long _NGUOI_CAP_NHAT;
        private DateTime? _NGAY_CAP_NHAT;
        #endregion

        #region 2. Định nghĩa thuộc tính
        public long DTD_ID
        {
            get { return this._DTD_ID; }
            set { this._DTD_ID = value; }
        }

        public DateTime? NGAY_LEN_LOP
        {
            get { return this._NGAY_LEN_LOP; }
            set { this._NGAY_LEN_LOP = value; }
        }

        public DateTime THOI_GIAN_BAT_DAU
        {
            get { return _THOI_GIAN_BAT_DAU; }
            set { _THOI_GIAN_BAT_DAU = value; }
        }
        public DateTime THOI_GIAN_KET_THUC
        {
            get { return _THOI_GIAN_KET_THUC; }
            set { _THOI_GIAN_KET_THUC = value; }
        }

        public long NHAN_SU
        {
            get { return this._NHAN_SU; }
            set { this._NHAN_SU = value; }
        }

        public long NGUOI_GIAO
        {
            get { return this._NGUOI_GIAO; }
            set { this._NGUOI_GIAO = value; }
        }

        public string GHI_CHU
        {
            get { return _GHI_CHU; }
            set { _GHI_CHU = value; }
        }

        public string THONG_BAO
        {
            get { return _THONG_BAO; }
            set { _THONG_BAO = value; }
        }

        public long BTD_ID
        {
            get { return this._BTD_ID; }
            set { this._BTD_ID = value; }
        }

        public long LCV_ID
        {
            get { return this._LCV_ID; }
            set { this._LCV_ID = value; }
        }

        public DateTime? NGAY_GIAO
        {
            get { return this._NGAY_GIAO; }
            set { this._NGAY_GIAO = value; }
        }

        public long NGUOI_CAP_NHAT
        {
            get { return this._NGUOI_CAP_NHAT; }
            set { this._NGUOI_CAP_NHAT = value; }
        }

        public DateTime? NGAY_CAP_NHAT
        {
            get { return this._NGAY_CAP_NHAT; }
            set { this._NGAY_CAP_NHAT = value; }
        }
        #endregion

        #region Khởi tạo
        public DOLenLop()
        { }

        public DOLenLop(long dtd_id, DateTime ngay_len_lop, DateTime thoi_gian_bat_dau, DateTime thoi_gian_ket_thuc, long nhan_su, long nguoi_giao, DateTime ngay_giao, string ghi_chu, string thong_bao, long btd_id, long lcv_id, long nguoi_cap_nhat, DateTime ngay_cap_nhat)
        {
            this._DTD_ID = dtd_id;
            this._NGAY_LEN_LOP = ngay_len_lop;
            this._THOI_GIAN_BAT_DAU = thoi_gian_bat_dau;
            this._THOI_GIAN_KET_THUC = thoi_gian_ket_thuc;
            this._NHAN_SU = nhan_su;
            this._NGUOI_GIAO = nguoi_giao;
            this._NGAY_GIAO = ngay_giao;
            this._GHI_CHU = ghi_chu;
            this._THONG_BAO = thong_bao;
            this._BTD_ID = btd_id;
            this._LCV_ID = lcv_id;
            this._NGUOI_CAP_NHAT = nguoi_cap_nhat;
            this._NGAY_CAP_NHAT = ngay_cap_nhat;
        }
        #endregion

    }
}
