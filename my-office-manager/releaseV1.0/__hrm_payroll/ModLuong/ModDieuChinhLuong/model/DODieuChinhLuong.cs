using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DODieuChinhLuong
    {
        protected long _NV_ID;
        protected DateTime _TU_NGAY;
        protected string _HINH_THUC;
        protected string _IS_THU_VIEC;
        protected int _PHAN_TRAM;
        protected decimal _MUC_LUONG;
        public DODieuChinhLuong()
        {

        }
        public DODieuChinhLuong(long nv_id, DateTime tu_ngay, string hinh_thuc, string is_thu_viec, int phan_tram, decimal muc_luong)
        {
            this._NV_ID = nv_id;
            this._TU_NGAY = tu_ngay;
            this._HINH_THUC = hinh_thuc;
            this._IS_THU_VIEC = is_thu_viec;
            this._PHAN_TRAM = phan_tram;
            this._MUC_LUONG = muc_luong;
        }
        public long NV_ID
        {
            get
            {
                return _NV_ID;
            }
            set
            {
                _NV_ID = value;
            }
        }
        public DateTime TU_NGAY
        {
            get
            {
                return _TU_NGAY;
            }
            set
            {
                _TU_NGAY = value;
            }
        }
        public string HINH_THUC
        {
            get
            {
                return _HINH_THUC;
            }
            set
            {
                _HINH_THUC = value;
            }
        }
        public string IS_THU_VIEC
        {
            get
            {
                return _IS_THU_VIEC;
            }
            set
            {
                _IS_THU_VIEC = value;
            }
        }
        public int PHAN_TRAM
        {
            get
            {
                return _PHAN_TRAM;
            }
            set
            {
                _PHAN_TRAM = value;
            }
        }
        public decimal MUC_LUONG
        {
            get
            {
                return _MUC_LUONG;
            }
            set
            {
                _MUC_LUONG = value;
            }
        }
    }
}
