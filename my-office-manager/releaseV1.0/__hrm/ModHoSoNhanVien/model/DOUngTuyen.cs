using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DOUngTuyen
    {
        private long _ID;
        private long _UV_ID;
        private long _VT_ID;
        public DOUngTuyen(long Id, int UngVienID, long ViTriTuyenID)
        {
            this._ID = Id;
            this._UV_ID = UngVienID;
            this._VT_ID = ViTriTuyenID;
        }
        public DOUngTuyen(long UngVienID, long ViTriTuyenID)
        {
            this._UV_ID = UngVienID;
            this._VT_ID = ViTriTuyenID;
        }
        public long ID
        {
            get { return this._ID; }
            set { this._ID = value;}
        }
        public long UV_ID
        {
            get { return this._UV_ID; }
            set { this._UV_ID = value; }
        }
        public long VTUT_ID
        {
            get { return this._VT_ID; }
            set { this._VT_ID = value; }
        }

    }
}
