using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{   
    public class DOChiTietPhanCong
    {
        #region Khai báo thuộc tính
        private Int64 _PCCV_ID;
        private Int64 _MA_NV;
        private Int32 _PHAN_TRAM_THAM_GIA;
        private Int32 _TIEN_DO;
        private DateTime _THOI_GIAN_CAP_NHAT;
        private String _GHI_CHU;
        #endregion

        #region Hàm khởi tạo 
        public DOChiTietPhanCong()
        {
                    
        }       
        public DOChiTietPhanCong(Int64 pccv_id, Int64 ma_nv, Int32 phan_tram_tham_gia, Int32 tien_do, DateTime thoi_gian_cap_nhat, String ghi_chu)
        {
            this._PCCV_ID = pccv_id;
            this._MA_NV = ma_nv;
            this._PHAN_TRAM_THAM_GIA = phan_tram_tham_gia;
            this._TIEN_DO = tien_do;
            this._THOI_GIAN_CAP_NHAT = thoi_gian_cap_nhat;
            this._GHI_CHU = ghi_chu;
        }
        #endregion

        #region Xây dựng thuộc tính
        public Int64 PCCV_ID
        {
            get { return _PCCV_ID; }
            set { _PCCV_ID = value; }
        }
        public Int64 MA_NV
        {
            get { return _MA_NV; }
            set { _MA_NV = value; }
        }
        public Int32 PHAN_TRAM_THAM_GIA
        {
            get { return _PHAN_TRAM_THAM_GIA; }
            set { _PHAN_TRAM_THAM_GIA = value; }
        }
        public Int32 TIEN_DO
        {
            get { return _TIEN_DO; }
            set { _TIEN_DO = value; }
        }
        public DateTime THOI_GIAN_CAP_NHAT
        {
            get { return _THOI_GIAN_CAP_NHAT; }
            set { _THOI_GIAN_CAP_NHAT = value; }
        }
        public String GHI_CHU
        {
            get { return _GHI_CHU; }
            set { _GHI_CHU = value; }
        }
        #endregion
    }
}
