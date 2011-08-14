using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DOLuongChiTiet
    {
        protected long _luong_id;
        protected DateTime _tu_ngay;
        protected DateTime _den_ngay;
        protected string _hinh_thuc;
        protected string _is_thu_viec;
        protected int _phan_tram;
        protected decimal _so_ngay;
        protected decimal _thu_nhap;
        protected decimal _muc_luong;
        public DOLuongChiTiet()
        {
        }
        public DOLuongChiTiet(long luong_id, DateTime tu_ngay, DateTime den_ngay, string hinh_thuc, string is_thu_viec, int phan_tram,decimal muc_luong, int so_gio, decimal thu_nhap)
        {
            this._luong_id = luong_id;
            this._tu_ngay = tu_ngay;
            this._den_ngay = den_ngay;
            this._hinh_thuc = hinh_thuc;
            this._is_thu_viec = is_thu_viec;
            this._phan_tram = phan_tram;
            this._muc_luong = muc_luong;
            this._so_ngay = so_gio;
            this._thu_nhap = thu_nhap;
        }
        public long LUONG_ID
        {
            get
            {
                return _luong_id;
            }
            set
            {
                _luong_id = value;
            }
        }
        public DateTime TU_NGAY
        {
            get
            {
                return _tu_ngay;
            }
            set
            {
                _tu_ngay = value;
            }
        }
        public DateTime DEN_NGAY
        {
            get
            {
                return _den_ngay;
            }
            set
            {
                _den_ngay = value;
            }
        }
        public string HINH_THUC
        {
            get
            {
                return _hinh_thuc;
            }
            set
            {
                _hinh_thuc = value;
            }
        }
        public string IS_THU_VIEC
        {
            get
            {
                return _is_thu_viec;
            }
            set
            {
                _is_thu_viec = value;
            }
        }
        public int PHAN_TRAM
        {
            get
            {
                return _phan_tram;
            }
            set
            {
                _phan_tram=value;
            }
        }
        public decimal MUC_LUONG
        {
            get
            {
                return _muc_luong;
            }
            set
            {
                _muc_luong = value;
            }
        }
        public decimal SO_NGAY
        {
            get
            {
                return _so_ngay;
            }
            set
            {
                _so_ngay = value;
            }
        }
        public decimal THU_NHAP
        {
            get
            {
                return _thu_nhap;
            }
            set
            {
                _thu_nhap = value;
            }
        }
    }
}
