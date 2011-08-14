using System;
using System.Collections.Generic;
using System.Text;

namespace pl.office.Training.ModDiemTheoDoi.model
{
    public class DODanhGiaViPham
    {
        #region 1. Thuộc tính bảng DANH_GIA_VI_PHAM
        private long _DG_ID;
        private long _VP_ID;
        #endregion

        #region 2. Định nghĩa thuộc tính

        public long DG_ID
        {
            get { return this._DG_ID; }
            set { this._DG_ID = value; }
        }

        public long VP_ID
        {
            get { return this._VP_ID; }
            set { this._VP_ID = value; }
        }
        #endregion

        #region 3. Khởi tạo
        public DODanhGiaViPham()
        { }

        public DODanhGiaViPham(long dg_id, long vp_id)
        {
            this._DG_ID = dg_id;
            this._VP_ID = vp_id;
        }
        #endregion
    }
}
