using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DOViTriUngTuyen
    {
        private long _ID;
        private string _NAME;
        public DOViTriUngTuyen(int Id, string Name)
        {
            this._ID = Id;
            this._NAME = Name;
        }
        public DOViTriUngTuyen()
        {

        }
        public long ID
        {
            get { return _ID; }
            set { this._ID = value; }
        }
        public string NAME
        {
            get { return this._NAME; }
            set { this._NAME = value; }
        }
    }
}
