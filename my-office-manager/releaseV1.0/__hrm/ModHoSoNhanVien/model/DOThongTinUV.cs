using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DOResume
    {
        #region 1.Thuộc tính bảng UNG_VIEN
        private long _ID;
        private string _MA_HO_SO;
        private string _TEN;
        private DateTime? _NGAY_SINH;
        private string _DIA_CHI;
        private string _DIEN_THOAI;
        private string _EMAIL;
        private string _GIOI_TINH;
        private string _TRINH_DO_CHUYEN_MON;
        private string _QUA_TRINH_CONG_TAC;
        private string _QUA_TRINH_DAO_TAO;
        private string _TINH_TRANG_HON_NHAN;
        private string _LUONG_MONG_DOI;
        private string _TRINH_DO_NGOAI_NGU;
        private string _THONG_TIN_KHAC;
        private DateTime _NGAY_CAP_NHAT_HO_SO;
        private string _LOAI_HO_SO;
        private long _TINH_TRANG_HO_SO;
        #endregion

        #region 2.Định nghĩa thuộc tính
        public long ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }
        public string TEN
        {
            get { return _TEN; }
            set { _TEN = value; }
        }
        public DateTime? NGAY_SINH
        {
            get { return _NGAY_SINH; }
            set { _NGAY_SINH = value; }
        }
        public string DIA_CHI
        {
            get { return _DIA_CHI; }
            set { _DIA_CHI = value; }
        }
        public string DIEN_THOAI
        {
            get { return _DIEN_THOAI; }
            set { _DIEN_THOAI = value; }
        }
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public string GIOI_TINH
        {
            get { return _GIOI_TINH; }
            set { _GIOI_TINH = value; }
        }
        public string TRINH_DO_CHUYEN_MON
        {
            get { return _TRINH_DO_CHUYEN_MON; }
            set { _TRINH_DO_CHUYEN_MON = value; }
        }
        public string QUA_TRINH_CONG_TAC
        {
            get { return _QUA_TRINH_CONG_TAC; }
            set { _QUA_TRINH_CONG_TAC = value; }
        }
        public string QUA_TRINH_DAO_TAO
        {
            get { return _QUA_TRINH_DAO_TAO; }
            set { _QUA_TRINH_DAO_TAO = value; }
        }
        public string TINH_TRANG_HON_NHAN
        {
            get { return _TINH_TRANG_HON_NHAN; }
            set { _TINH_TRANG_HON_NHAN = value; }
        }
        public string LUONG_MONG_DOI
        {
            get { return _LUONG_MONG_DOI; }
            set { _LUONG_MONG_DOI = value; }
        }
        public string TRINH_DO_NGOAI_NGU
        {
            get { return _TRINH_DO_NGOAI_NGU; }
            set { _TRINH_DO_NGOAI_NGU = value; }
        }
        public string THONG_TIN_KHAC
        {
            get { return _THONG_TIN_KHAC; }
            set { _THONG_TIN_KHAC = value; }
        }
        public DateTime NGAY_CAP_NHAT_HO_SO
        {
            get { return _NGAY_CAP_NHAT_HO_SO; }
            set { this._NGAY_CAP_NHAT_HO_SO = value; }
        }
        public string LOAI_HO_SO
        {
            get { return this._LOAI_HO_SO; }
            set { this._LOAI_HO_SO = value; }
        }
        public long TINH_TRANG_HO_SO
        {
            get { return this._TINH_TRANG_HO_SO; }
            set { this._TINH_TRANG_HO_SO = value; }
        }
         public string MA_HO_SO
        {
            get { return this._MA_HO_SO; }
            set { this._MA_HO_SO = value; }
        }
        #endregion

        #region 3.Hàm khởi tạo
        public DOResume() { }
        public DOResume(
            long Id,
            string MA_HO_SO,
            string Ten,
            DateTime? NgaySinh,
            string DiaChi,
            string DienThoai,
            string Email,
            string GioiTinh,
            string TrinhDoChuyenMon,
            string QuaTrinhCongTac,
            string QuaTrinhDaoTao,
            string TinhTrangHonNhan,
            string LuongMongDoi,
            string TrinhDoNgoaiNgu,
            string ThongTinKhac,
            DateTime NgayCapNhatHoSo,
            string LoaiHoSo,
            long TinhTrangHoSo
        )
        {
            this.ID = Id;
            this.MA_HO_SO=MA_HO_SO;
            this.TEN = Ten;
            this.NGAY_SINH = NgaySinh;
            this.DIA_CHI = DiaChi;
            this.DIEN_THOAI = DienThoai;
            this.EMAIL = Email;
            this.GIOI_TINH = GioiTinh;
            this.TRINH_DO_CHUYEN_MON = TrinhDoChuyenMon;
            this.QUA_TRINH_CONG_TAC = QuaTrinhCongTac;
            this.QUA_TRINH_DAO_TAO = QuaTrinhDaoTao;
            this.TINH_TRANG_HON_NHAN = TinhTrangHonNhan;
            this.LUONG_MONG_DOI = LuongMongDoi;
            this.TRINH_DO_NGOAI_NGU = TrinhDoNgoaiNgu;
            this.THONG_TIN_KHAC = ThongTinKhac;
            this.NGAY_CAP_NHAT_HO_SO = NgayCapNhatHoSo;
            this.LOAI_HO_SO = LoaiHoSo;
            this.TINH_TRANG_HO_SO = TinhTrangHoSo;
        }
        #endregion
        
    }
}
