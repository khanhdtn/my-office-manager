using System;
using System.Collections.Generic;
using System.Text;

namespace pl.office.Training.ModDiemTheoDoi.model
{
    public class DOCongViecThuocTinh
    {
        #region 1. Thuộc tính bảng CONG_VIEC_THUOC_TINH
        private long _TTCV_ID;
        private long _CV_ID;
        #endregion

        #region 2. Định nghĩa thuộc tính

        public long TTCV_ID
        {
            get { return this._TTCV_ID; }
            set { this._TTCV_ID = value; }
        }

        public long CV_ID
        {
            get { return this._CV_ID; }
            set { this._CV_ID = value; }
        }
        #endregion

        #region 3. Khởi tạo
        public DOCongViecThuocTinh()
        { }

        public DOCongViecThuocTinh(long ttcv_id, long cv_id)
        {
            this._TTCV_ID = ttcv_id;
            this._CV_ID = cv_id;
        }
        #endregion

    }
}
