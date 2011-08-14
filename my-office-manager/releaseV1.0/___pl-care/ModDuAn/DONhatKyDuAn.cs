using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{    
    public class DONhatKyDuAn
    {
        
        #region Khai báo thuộc tính
        private Int64 _ID;
        private Int64 _DA_ID;
        private Int64 _MA_NV;
        private DateTime _THOI_GIAN_CAP_NHAT;
        private String _GHI_CHU;
        #endregion

        #region Hàm khởi tạo 
        public DONhatKyDuAn()
        {
                    
        }
        public DONhatKyDuAn(Int64 id, Int64 da_id, Int64 ma_nv, DateTime thoi_gian_cap_nhat, String ghi_chu)
        {
            this._ID = id;
            this._DA_ID = da_id;
            this._MA_NV = ma_nv;
            this._THOI_GIAN_CAP_NHAT = thoi_gian_cap_nhat;
            this._GHI_CHU = ghi_chu;
        }
        #endregion

        #region Xây dựng thuộc tính
        public Int64 ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public Int64 DA_ID
        {
            get { return _DA_ID; }
            set { _DA_ID = value; }
        }
        public Int64 MA_NV
        {
            get { return _MA_NV; }
            set { _MA_NV = value; }
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
