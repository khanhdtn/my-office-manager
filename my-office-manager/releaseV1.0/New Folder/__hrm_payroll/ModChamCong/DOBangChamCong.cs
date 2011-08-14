using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DOBangChamCong
    {
        private long _ID;
        private long _NV_ID;
        private string _THANG_NAM;
        private DateTime _NGAY;
        private string _SANG;
        private string _CHIEU;
        private string _IS_CHOT;
        public DOBangChamCong()
        {

        }
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }

        }
        public long NV_ID
        {
            get { return _NV_ID; }
            set { _NV_ID = value; }

        }
        public string THANG_NAM
        {
            get { return _THANG_NAM; }
            set { _THANG_NAM = value; }

        }
        public DateTime NGAY
        {
            get { return _NGAY; }
            set { _NGAY = value; }

        }
        public string SANG
        {
            get { return _SANG; }
            set { _SANG = value; }

        }
        public string CHIEU
        {
            get { return _CHIEU; }
            set { _CHIEU = value; }

        }
        public string IS_CHOT
        {
            get { return _IS_CHOT; }
            set { _IS_CHOT = value; }

        }

    }
}
