using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DOLuong
    {
        private long _ID;
        private long _NV_ID;
        private string _THANG_NAM;
        private decimal _TAM_UNG;
        private decimal _TONG_THU_NHAP;
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
            set { this._THANG_NAM = value; }
        }
        public decimal TAM_UNG
        {
            get { return this._TAM_UNG; }
            set { this._TAM_UNG = value; }
        }
        public decimal TONG_THU_NHAP
        {
            get { return _TONG_THU_NHAP; }
            set { _TONG_THU_NHAP = value; }
        }
    }
}
