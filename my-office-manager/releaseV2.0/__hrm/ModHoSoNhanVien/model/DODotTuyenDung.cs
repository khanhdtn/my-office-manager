using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DODotTuyenDung
    {
        private long _ID;
        private string _NAME;
        public long ID {
            get { return _ID; }
            set { this._ID = value; }
        }
        public string NAME
        {
            get { return _NAME; }
            set { this._NAME = value; }
        }
        public long getID() { return _ID; }
        public string getName() { return _NAME; }
        public DODotTuyenDung (string Name)
        {
            this._NAME = Name;
        }
        public DODotTuyenDung(long Id, string Name)
        {
            this._ID = Id;
            this._NAME = Name;
        }
    }
}
