using System;
using System.Collections;


namespace DTO
{
    public class DOPhieuThuChi
    {
        #region 1.Khai báo các thuộc tính
        private long _ID;
        private string _MA_PHIEU;
        private DateTime? _NGAY_PHAT_SINH;
        private DateTime? _NGAY_CAP_NHAT;
        private long _NGUOI_CAP_NHAT_ID;
        private long _NV_ID;
        private string _DIEN_GIAI;
        private string _IS_THU_CHI;
        private decimal _SO_TIEN;
        private int _LCP_ID;
        private string _DON_VI_LIEN_QUAN;
        #endregion

        #region 2.Định nghĩa thuộc tính
        public long ID
        {
            get { return _ID; }
            set { this._ID = value; }
        }
        public long GetID() { return _ID; }
        public string MA_PHIEU
        {
            get { return _MA_PHIEU; }
            set { this._MA_PHIEU = value; }
        }
        public string GetMaPhieu() { return _MA_PHIEU; }
        public DateTime? NGAY_PHAT_SINH
        {
            get { return _NGAY_PHAT_SINH; }
            set { this._NGAY_PHAT_SINH = value; }
        }
        public DateTime? GetNgayPhatSinh() { return _NGAY_PHAT_SINH; }
        public DateTime? NGAY_CAP_NHAT
        {
            get { return _NGAY_CAP_NHAT; }
            set { this._NGAY_CAP_NHAT = value; }
        }
        public DateTime? GetNgayCapNhat() { return _NGAY_CAP_NHAT; }
        public long NGUOI_CAP_NHAT_ID
        {
            get { return _NGUOI_CAP_NHAT_ID; }
            set { this._NGUOI_CAP_NHAT_ID = value; }
        }
        public long GetNguoiCapNhat() { return _NGUOI_CAP_NHAT_ID; }
        public long NV_ID
        {
            get { return _NV_ID; }
            set { this._NV_ID = value; }
        }
        public long GetNguoiLienQuan() { return _NV_ID; }
        public string DIEN_GIAI
        {
            get { return _DIEN_GIAI; }
            set { this._DIEN_GIAI = value; }
        }
        public string GetDienGiai() { return _DIEN_GIAI;}
        public string IS_THU_CHI
        {
            get { return _IS_THU_CHI; }
            set { this._IS_THU_CHI = value; }
        }
        public string GetIsThuChi() { return _IS_THU_CHI; }
        public decimal SO_TIEN
        {
            get { return _SO_TIEN; }
            set { this._SO_TIEN = value; }
        }
        public decimal GetSoTien() { return _SO_TIEN; }
        public int LCP_ID
        {
            get { return _LCP_ID; }
            set { this._LCP_ID = value; }
        }
        public int GetLoaiChiPhi() { return _LCP_ID; }
        public string DON_VI_LIEN_QUAN
        {
            get { return _DON_VI_LIEN_QUAN; }
            set { this._DON_VI_LIEN_QUAN = value; }
        }
        public string GetDonViLienQuan() { return _DON_VI_LIEN_QUAN; }
        #endregion

        #region 3.Hàm khởi tạo phiếu
        public DOPhieuThuChi()
        {
            
        }

        public DOPhieuThuChi(
            long Id,
            string MaPhieu,
            DateTime? NgayPhatSinh,
            DateTime? NgayCapNhat,
            long NguoiCapNhatID,
            long NVID,
            string DienGiai,
            string IsThuChi,
            decimal SoTien,
            int LcpID,
            string DON_VI_LIEN_QUAN
        )
        {
            this.ID = Id;
            this.MA_PHIEU = MaPhieu;
            this.NGAY_PHAT_SINH = NgayPhatSinh;
            this.NGAY_CAP_NHAT = NgayCapNhat;
            this.NGUOI_CAP_NHAT_ID = NguoiCapNhatID;
            this.NV_ID = NVID;
            this.DIEN_GIAI = DienGiai;
            this.IS_THU_CHI = IsThuChi;
            this.SO_TIEN = SoTien;
            this.LCP_ID = LcpID;
            this.DON_VI_LIEN_QUAN = DON_VI_LIEN_QUAN;
        }
        #endregion

    }
}

