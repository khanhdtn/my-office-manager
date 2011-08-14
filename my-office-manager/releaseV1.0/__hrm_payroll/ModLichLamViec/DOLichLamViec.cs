using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DOLichLamViec
    {
        private long _ID;
        private long _NV_ID;
        private DateTime _NGAY_DAU_TUAN;
        private string[] _NGAY = new string[14];
        private String _GHI_CHU;

        public string NAME;

        public long ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }
        public long NV_ID
        {
            get { return this._NV_ID; }
            set { this._NV_ID = value; }
        }
        public DateTime NGAY_DAU_TUAN
        {
            get { return this._NGAY_DAU_TUAN; }
            set { this._NGAY_DAU_TUAN = value; }
        }
        public String[] NGAY
        {
            get { return this._NGAY; }
            set { this._NGAY = value; }
        }
        public string GHI_CHU
        {
            get { return this._GHI_CHU; }
            set { this._GHI_CHU = value; }
        }

    }
}
