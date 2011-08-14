using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;


namespace DTO
{
    public class DOWebsite:DOPhieu
    {
        #region Các thuộc tính 
        private long _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return this._ID; }
        private long _PhanLoai;

        public long PhanLoai
        {
            get { return _PhanLoai; }
            set { _PhanLoai = value; }
        }
        public long GetPHAN_LOAI() { return this._PhanLoai; }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        public string GetDIA_CHI() { return this._DiaChi; }
        private string _MoTa;

        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }
        public string GetMO_TA() { return this._MoTa; }
        private string _IS_RSS;
        
        #endregion

        #region Các hàm khởi tạo
        public DOWebsite() { }
        public DOWebsite(long ID,long PhanLoai,string DiaChi,string MoTa)
        {
            this._ID = ID;
            this._PhanLoai = PhanLoai;
            this._DiaChi = DiaChi;
            this._MoTa = MoTa;            
        }
        #endregion
    }
}
