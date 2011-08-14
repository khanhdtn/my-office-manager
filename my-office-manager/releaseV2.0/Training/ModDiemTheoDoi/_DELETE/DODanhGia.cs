using System;
using System.Collections.Generic;
using System.Text;

namespace pl.office.Training.ModDiemTheoDoi.model
{
    public class DODanhGia
    {
        #region 1. Thuộc tính bảng DM_DANH_GIA
        private long _DG_ID;
        private long _NAME;
        #endregion

        #region 2. Định nghĩa thuộc tính

        public long DG_ID
        {
            get { return this._DG_ID; }
            set { this._DG_ID = value; }
        }

        public long NAME
        {
            get { return this._NAME; }
            set { this._NAME = value; }
        }
        #endregion

        #region 3. Khởi tạo
        public DODanhGia()
        { }

        public DODanhGia(long dg_id, long name)
        {
            this._DG_ID = dg_id;
            this._NAME = name;
        }
        #endregion
    }
}
