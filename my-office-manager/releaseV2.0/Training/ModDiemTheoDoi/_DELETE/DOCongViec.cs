using System;
using System.Collections.Generic;
using System.Text;

namespace pl.office.Training.ModDiemTheoDoi.model
{
    public class DOCongViec
    {
        #region 1. Thuộc tính bảng DM_CONG_VIEC
        private long _CV_ID;
        private string _NAME;
        private string _MO_TA;
        private string _VISIBLE_BIT;
        private long _LCV_ID;
        #endregion

        #region 2. Định nghĩa thuộc tính

        public long CV_ID
        {
            get { return this._CV_ID; }
            set { this._CV_ID = value; }
        }

        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }

        public string MO_TA
        {
            get { return _MO_TA; }
            set { _MO_TA = value; }
        }

        public string VISIBLE_BIT
        {
            get { return _VISIBLE_BIT; }
            set { _VISIBLE_BIT = value; }
        }

        public long LCV_ID
        {
            get { return this._LCV_ID; }
            set { this._LCV_ID = value; }
        }
        #endregion

        #region 3. Khởi tạo
        public DOCongViec()
        { }

        public DOCongViec(long cv_id, string name, string mo_ta, string visible_bit, long lcv_id)
        {
            this._CV_ID = cv_id;
            this._NAME = name;
            this._MO_TA = mo_ta;
            this._VISIBLE_BIT = visible_bit;
            this._LCV_ID = lcv_id;
        }
        #endregion

    }
}
