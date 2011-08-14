using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;

namespace office.model
{
    public class DONopBai:DOPhieu
    {
        #region 1. Các thuộc tính của bảng DIEM_THEO_DOI_NOP_BAI
        private long _DTD_ID;
        private DateTime? _HAN_NOP;
        private DateTime? _NGAY_NOP;
        private byte[] _NOI_DUNG;
        private string _TEN_TAI_LIEU;
        private long _NHAN_SU;
        private long _NGUOI_GIAO;
        private DateTime? _NGAY_GIAO;
        private long _NGUOI_CAP_NHAT;
        private DateTime? _NGAY_CAP_NHAT;
        private string _GHI_CHU;
        private string _THONG_BAO;
        private long _BTD_ID;
        private long _LCV_ID;
        #endregion

        #region 2. Định nghĩa thuộc tính
        public long DTD_ID
        {
            get { return this._DTD_ID; }
            set { this._DTD_ID = value; }
        }

        public DateTime? HAN_NOP
        {
            get { return this._HAN_NOP; }
            set { this._HAN_NOP = value; }
        }

        public DateTime? NGAY_NOP
        {
            get { return _NGAY_NOP; }
            set { _NGAY_NOP = value; }
        }

        public byte[] NOI_DUNG
        {
            get { return _NOI_DUNG; }
            set { _NOI_DUNG = value; }
        }

        public string TEN_TAI_LIEU
        {
            get { return this._TEN_TAI_LIEU; }
            set { this._TEN_TAI_LIEU = value; }
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

        public DateTime? NGAY_GIAO
        {
            get { return _NGAY_GIAO; }
            set { _NGAY_GIAO = value; }
        }

        public long NGUOI_CAP_NHAT
        {
            get { return this._NGUOI_CAP_NHAT; }
            set { this._NGUOI_CAP_NHAT = value; }
        }

        public DateTime? NGAY_CAP_NHAT
        {
            get { return _NGAY_CAP_NHAT; }
            set { _NGAY_CAP_NHAT = value; }
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

        #endregion

        #region Khởi tạo
        public DONopBai()
        { }

        public DONopBai(long dtd_id, DateTime han_nop, DateTime ngay_nop, byte[] noi_dung, string ten_tai_lieu, long nhan_su, long nguoi_giao, DateTime ngay_giao, long nguoi_cap_nhat, DateTime ngay_cap_nhat, string ghi_chu, string thong_bao, long btd_id, long lcv_id)
        {
            this._DTD_ID = dtd_id;
            this._HAN_NOP = han_nop;
            this._NGAY_NOP = ngay_nop;
            this._NOI_DUNG = noi_dung;
            this._TEN_TAI_LIEU = ten_tai_lieu;
            this._NHAN_SU = nhan_su;
            this._NGUOI_GIAO = nguoi_giao;
            this._NGAY_GIAO = ngay_giao;
            this._NGUOI_CAP_NHAT = nguoi_cap_nhat;
            this._NGAY_CAP_NHAT = ngay_cap_nhat;
            this._GHI_CHU = ghi_chu;
            this._THONG_BAO = thong_bao;
            this._BTD_ID = btd_id;
            this._LCV_ID = lcv_id;
        }
        #endregion

    }
}
