using System;
using System.Collections.Generic;
using System.Text;

namespace pl.office.Training.ModDiemTheoDoi.model
{
    public class DOThuocTinhCongViec
    {
        #region Thuộc tính bảng DM_THUOC_TINH_CONG_VIEC
        private long _TTCV_ID;
        private string _NAME;
        private string _TYPE;
        private string _DESCRIPTION;
        private string _KEY;
        #endregion

        #region Đinh nghĩa thuộc tính
        public long TTCV_ID
        {
            get { return this._TTCV_ID; }
            set { this._TTCV_ID = value; }
        }

        public string NAME
        {
            get { return this._NAME; }
            set { this._NAME = value; }
        }

        public string TYPE
        {
            get { return this._TYPE; }
            set { this._TYPE = value; }
        }

        public string DESCRIPTION
        {
            get { return this._DESCRIPTION; }
            set { this._DESCRIPTION = value; }
        }

        public string KEY
        {
            get { return this._KEY; }
            set { this._KEY = value; }
        }
        #endregion
    
        #region Khởi tạo
        public DOThuocTinhCongViec()
        { }

        public DOThuocTinhCongViec(long ttcv_id, string name, string type, string description, string key)
        {
            this._TTCV_ID = ttcv_id;
            this._NAME = name;
            this._TYPE = type;
            this._DESCRIPTION = description;
            this._KEY = key;
        }
        #endregion
    }
}
