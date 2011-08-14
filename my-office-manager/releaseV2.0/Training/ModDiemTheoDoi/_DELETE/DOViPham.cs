using System;
using System.Collections.Generic;
using System.Text;

namespace pl.office.Training.ModDiemTheoDoi.model
{
    public class DOViPham
    {
        #region 1. Thuộc tính bảng DM_VI_PHAM
        private long _VP_ID;
        private long _NAME;
        #endregion

        #region 2. Định nghĩa thuộc tính

        public long VP_ID
        {
            get { return this._VP_ID; }
            set { this._VP_ID = value; }
        }

        public long NAME
        {
            get { return this._NAME; }
            set { this._NAME = value; }
        }
        #endregion

        #region 3. Khởi tạo
        public DOViPham()
        { }

        public DOViPham(long vp_id, long name)
        {
            this._VP_ID = vp_id;
            this._NAME = name;
        }
        #endregion
    }
}
