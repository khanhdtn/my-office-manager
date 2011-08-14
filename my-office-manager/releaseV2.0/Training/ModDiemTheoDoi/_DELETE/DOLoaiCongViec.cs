using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DOLoaiCongViec
    {
        #region 1. Thuộc tính bảng LOAI_CONG_VIEC
        private long _LCV_ID;
        private string _MA_LCV;
        private string _NAME;
        private string _MO_TA;
        private string _VISIBLE_BIT;
        #endregion

        #region 2. Định nghĩa thuộc tính

        public long LCV_ID
        {
            get 
            {
                    return this._LCV_ID;
            }
            set { this._LCV_ID = value; }
        }

        public string MA_LCV
        {
            get { return _MA_LCV; }
            set { _MA_LCV = value; }
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

        #endregion

        #region Khởi tạo
        public DOLoaiCongViec()
        {
            //_LCV_ID = -1;
            //_NAME = "";
            //_MO_TA = "";
            //_VISIBLE_BIT = "1";
        }

        public DOLoaiCongViec(long lcv_id, string ma_lcv, string name, string mo_ta, string visible_bit)
        {
            this._LCV_ID = lcv_id;
            this._MA_LCV = ma_lcv;
            this._NAME = name;
            this._MO_TA = mo_ta;
            this._VISIBLE_BIT = visible_bit;
        }
        #endregion
    }
}
