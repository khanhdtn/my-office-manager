using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;

namespace DTO
{
    public class DOKhachHang : DOPhieu
    {
        #region Định nghĩa thuộc tính
        private long _KH_ID;
        private string _TEN_KHACH_HANG;
        private string _DIA_CHI;
        private string _DIEN_THOAI;
        private string _FAX;
        private string _EMAIL;
        private string _WEBSITE;
        private string _NKH_ID;
        private string _LINH_VUC_HOAT_DONG;
        private string _THONG_TIN_THEM;
        private DataSet _DetailDataSetTTLH;
        private DataSet _DetailDataSetTTLL;
        private DataSet _DetailDataSetCV;
        private DataSet _DetailDataSetTL;
        #endregion

        #region Khởi tạo đối tượng
        public DOKhachHang() { }
        public DOKhachHang(long KH_ID, string TEN_KHACH_HANG, string DIA_CHI, string DIEN_THOAI, string FAX, string EMAIL, string WEBSITE, string NKH_ID, string LINH_VUA_HOAT_DONG, string THONG_TIN_THEM)
        {
            this._KH_ID = KH_ID;
            this._TEN_KHACH_HANG = TEN_KHACH_HANG;
            this._DIA_CHI = DIA_CHI;
            this._DIEN_THOAI = DIEN_THOAI;
            this._FAX = FAX;
            this._EMAIL = EMAIL;
            this._WEBSITE = WEBSITE;
            this._NKH_ID = NKH_ID;
            this._LINH_VUC_HOAT_DONG = LINH_VUA_HOAT_DONG;
            this._THONG_TIN_THEM = THONG_TIN_THEM;
        }
        #endregion

        #region Khởi tạo các thuộc tính
        public long KH_ID
        {
            get { return _KH_ID; }
            set { _KH_ID = value; }
        }
        public long GetKH_ID() { return _KH_ID; }

        public string TEN_KHACH_HANG
        {
            get { return _TEN_KHACH_HANG; }
            set { _TEN_KHACH_HANG = value; }
        }
        public string GetTEN_KHACH_HANG() { return _TEN_KHACH_HANG; }

        public string DIA_CHI
        {
            get { return _DIA_CHI; }
            set { _DIA_CHI = value; }
        }
        public string GetDIA_CHI() { return _DIA_CHI; }

        public string DIEN_THOAI
        {
            get { return _DIEN_THOAI; }
            set { _DIEN_THOAI = value; }
        }
        public string GetDIEN_THOAI() { return _DIEN_THOAI; }

        public string FAX
        {
            get { return _FAX; }
            set { _FAX = value; }
        }
        public string GetFAX() { return _FAX; }

        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public string GetEMAIL() { return _EMAIL; }

        public string WEBSITE
        {
            get { return _WEBSITE; }
            set { _WEBSITE = value; }
        }
        public string GetWEBSITE() { return _WEBSITE; }

        public string NKH_ID
        {
            get { return _NKH_ID; }
            set { _NKH_ID = value; }
        }
        public string GetNKH_ID() { return _NKH_ID; }

        public string LINH_VUC_HOAT_DONG
        {
            get { return _LINH_VUC_HOAT_DONG; }
            set { _LINH_VUC_HOAT_DONG = value; }
        }
        public string GetLINH_VUC_HOAT_DONG() { return _LINH_VUC_HOAT_DONG; }

        public string THONG_TIN_THEM
        {
            get { return _THONG_TIN_THEM; }
            set { _THONG_TIN_THEM = value; }
        }
        public string GetTHONG_TIN_THEM() { return _THONG_TIN_THEM; }

        public DataSet DetailDataSetTTLH
        {
            get { return _DetailDataSetTTLH; }
            set { _DetailDataSetTTLH = value; }
        }
        public DataSet GetDetailDataSetTTLH() { return _DetailDataSetTTLH; }

        public DataSet DetailDataSetCV
        {
            get { return _DetailDataSetCV; }
            set { _DetailDataSetCV = value; }
        }
        public DataSet GetDetailDataSetCV() { return _DetailDataSetCV; }

        public DataSet DetailDataSetTTLL
        {
            get { return _DetailDataSetTTLL; }
            set { _DetailDataSetTTLL = value; }
        }
        public DataSet GetDetailDataSetTTLL() { return _DetailDataSetTTLL; }

        public DataSet DetailDataSetTL
        {
            get { return _DetailDataSetTL; }
            set { _DetailDataSetTL = value; }
        }
        public DataSet GetDetailDataSetTL() { return _DetailDataSetTL; }
        #endregion
    }
}
