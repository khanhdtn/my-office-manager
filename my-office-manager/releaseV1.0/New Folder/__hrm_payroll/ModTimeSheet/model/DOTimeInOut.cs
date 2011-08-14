using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    [Serializable]
    public class DOTimeInOut : DOPhieu
    {
        private long _ID;
        private long NVID;
        private DateTime NgayLamViec;
        private TimeSpan? GioBatDau;
        private TimeSpan? GioKetThuc;
        private TimeSpan? ThoiGianLamViec;
        private string IsChamCong;
        private string _NghiBuoiSang;
        private string _NghiBuoiChieu;
        private string _NghiPhepNam;
        private string _NghiKhongLuong;
        private string _NoiDung;               
        private long _NGUOI_GHI_NHAN;
        private DateTime? _THOI_GIAN_GHI_NHAN;
        private int _Loai;
        private string _DUYET;
        private long _NGUOI_DUYET;
        private DateTime _NGAY_DUYET;
        private string _IP_ADDRESS;
        private int _LoaiDiTreVeSom;
        private string _ThoiGianSang;
        private string _ThoiGianChieu;
        private string _LoaiXacNhan;
        private string _TaiDonVi;
        private string _CongViec;
        private string _LyDo;
        private DataSet _DetailDataSet;
        

        public DOTimeInOut() { }
        public DOTimeInOut(long ID, long nvID, DateTime NgayLamViec, TimeSpan? GioBatDau, TimeSpan? GioKetThuc, TimeSpan? ThoiGianLamViec,
            string IsChamCong, string NghiBuoiSang, string NghiBuoiChieu,string NghiPhepNam,string NghiKhongLuong, string NoiDung,
            long NGUOI_GHI_NHAN, DateTime? TG_GHI_NHAN, int Loai,string DUYET,long NGUOI_DUYET,DateTime NGAY_DUYET,
            string IP_ADDRESS,int LoaiDiTreVeSom,string ThoiGianSang,string ThoiGianChieu,string LoaiXacNhan,string TaiDonVi,string CongViec,string LyDo)
        {
            this._ID = ID;
            this.NVID = nvID;
            this.NgayLamViec = NgayLamViec;
            this.GioBatDau = GioBatDau;
            this.GioKetThuc = GioKetThuc;
            this.ThoiGianLamViec = ThoiGianLamViec;
            this.IsChamCong = IsChamCong;
            this._NghiBuoiSang = NghiBuoiSang;
            this._NghiBuoiChieu = NghiBuoiChieu;
            this._NghiPhepNam = NghiPhepNam;
            this._NghiKhongLuong = NghiKhongLuong;
            this._NoiDung = NoiDung;                                              
            this._NGUOI_GHI_NHAN = NGUOI_GHI_NHAN;
            this._THOI_GIAN_GHI_NHAN = TG_GHI_NHAN;
            this._Loai = Loai;
            this._DUYET = DUYET;
            this._NGUOI_DUYET = NGUOI_DUYET;
            this._NGAY_DUYET = NGAY_DUYET;
            this._IP_ADDRESS = IP_ADDRESS;
            this._LoaiDiTreVeSom = LoaiDiTreVeSom;
            this._ThoiGianSang = ThoiGianSang;
            this._ThoiGianChieu = ThoiGianChieu;
            this._LoaiXacNhan = LoaiXacNhan;
            this._TaiDonVi = TaiDonVi;
            this._CongViec = CongViec;
            this._LyDo = LyDo;
        }
        public long ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }
        public long GetID()
        {
            return this._ID;
        }

        public long NV_ID
        {
            get { return this.NVID; }
            set { this.NVID = value; }
        }
        public long GetNV_ID()
        {
            return this.NVID;
        }
        public DateTime NGAY_LAM_VIEC
        {
            get { return this.NgayLamViec; }
            set { this.NgayLamViec = value; }
        }
        public DateTime GetNGAY_LAM_VIEC() { return this.NgayLamViec; }

        public TimeSpan? GIO_BAT_DAU
        {
            get { return this.GioBatDau; }
            set { this.GioBatDau = value; }
        }
        public TimeSpan? GetGIO_BAT_DAU() { return this.GioBatDau; }

        public TimeSpan? GIO_KET_THUC 
        {
            get { return this.GioKetThuc; }
            set { this.GioKetThuc = value; }
        }
        public TimeSpan? GetGIO_KET_THUC() { return this.GioKetThuc; }

        public TimeSpan? THOI_GIAN_LAM_VIEC
        {
            get { return this.ThoiGianLamViec; }
            set { this.ThoiGianLamViec = value; }
        }
        public TimeSpan? GetTHOI_GIAN_LAM_VIEC() { return this.ThoiGianLamViec; }

        public string IS_CHAM_CONG
        {
            get { return this.IsChamCong; }
            set { this.IsChamCong = value; }
        }
        public string GetIS_CHAM_CONG() { return this.IsChamCong; }
        public string NGHI_BUOI_SANG
        {
            get { return this._NghiBuoiSang; }
            set { this._NghiBuoiSang = value; }
        }
        public string GetNGHI_BUOI_SANG() { return this._NghiBuoiSang; }
        public string NGHI_BUOI_CHIEU
        {
            get { return this._NghiBuoiChieu; }
            set { this._NghiBuoiChieu = value; }
        }
        public string GetNGHI_BUOI_CHIEU() { return this._NghiBuoiChieu; }
        public string NGHI_PHEP_NAM
        {
            get { return _NghiPhepNam; }
            set { _NghiPhepNam = value; }
        }
        public string GetNGHI_PHEP_NAM() { return _NghiPhepNam; }
        public string NGHI_KHONG_LUONG
        {
            get { return _NghiKhongLuong; }
            set { _NghiKhongLuong = value; }
        }
        public string GetNGHI_KHONG_LUONG() { return _NghiKhongLuong; }
        public string NOI_DUNG
        {
            get { return this._NoiDung; }
            set { this._NoiDung = value; }
        }
        public string GetNOI_DUNG() { return this._NoiDung; }               
        public long NGUOI_GHI_NHAN
        {
            get { return this._NGUOI_GHI_NHAN; }
            set { this._NGUOI_GHI_NHAN = value; }
        }
        public long GetNGUOI_GHI_NHAN() { return this._NGUOI_GHI_NHAN; }
        public DateTime? THOI_GIAN_GHI_NHAN
        {
            get { return this._THOI_GIAN_GHI_NHAN; }
            set { this._THOI_GIAN_GHI_NHAN = value; }
        }
        public DateTime? GetTHOI_GIAN_GHI_NHAN() { return this._THOI_GIAN_GHI_NHAN; }
        public int LOAI
        {
            get { return this._Loai; }
            set { this._Loai = value; }
        }
        public int GetLOAI() { return this._Loai; }
        public string DUYET
        {
            get { return this._DUYET; }
            set { this._DUYET = value; }
        }
        public string GetDUYET() { return this._DUYET; }
        public long NGUOI_DUYET
        {
            get { return this._NGUOI_DUYET; }
            set { this._NGUOI_DUYET = value; }
        }
        public long GetNGUOI_DUYET() { return this._NGUOI_DUYET; }
        public DateTime NGAY_DUYET
        {
            get { return this._NGAY_DUYET; }
            set { this._NGAY_DUYET = value; }
        }
        public DateTime GetNGAY_DUYET() { return this._NGAY_DUYET; }
        public string IP_ADDRESS
        {
            get { return this._IP_ADDRESS; }
            set { this._IP_ADDRESS = value; }
        }
        public string GetIP_ADDRESS() { return this._IP_ADDRESS; }
        public int LOAI_DI_TRE_VE_SOM
        {
            get { return this._LoaiDiTreVeSom; }
            set { this._LoaiDiTreVeSom = value; }
        }
        public int GetLOAI_DI_TRE_VE_SOM() { return this._LoaiDiTreVeSom; }
        public string THOI_GIAN_CHIEU
        {
            get { return this._ThoiGianChieu; }
            set { this._ThoiGianChieu = value; }
        }
        public string GetTHOI_GIAN_CHIEU() { return this._ThoiGianChieu; }
        public string THOI_GIAN_SANG
        {
            get { return this._ThoiGianSang; }
            set { this._ThoiGianSang = value; }
        }
        public string GetTHOI_GIAN_SANG() { return this._ThoiGianSang; }

        public string LOAI_XAC_NHAN {
            get { return this._LoaiXacNhan; }
            set { this._LoaiXacNhan = value; }
        }
        public string GetLOAI_XAC_NHAN() { return this._LoaiXacNhan; }

        public string TAI_DON_VI
        {
            get { return this._TaiDonVi; }
            set { this._TaiDonVi = value; }
        }
        public string GetTAI_DON_VI() { return this._TaiDonVi; }

        public string CONG_VIEC
        {
            get { return this._CongViec; }
            set { this._CongViec = value; }
        }
        public string GetCONG_VIEC() { return this._CongViec; }

        public string LY_DO
        {
            get { return this._LyDo; }
            set { this._LyDo = value; }
        }
        public string GetLY_DO() { return this._LyDo; }

        public DataSet DetailDataSet 
        {
            get { return this._DetailDataSet; }
            set { this._DetailDataSet = value; }
        }
        public DataSet GetDetailDataSet() { return this._DetailDataSet; }
    }
}
