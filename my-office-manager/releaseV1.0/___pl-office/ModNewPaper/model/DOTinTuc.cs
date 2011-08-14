using System;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    public class DOTinTuc: DOPhieu
    {
        #region Thuộc tính bảng TIN_TUC

        private long _ID;
        private string _TIEU_DE;
        private byte[] _NOI_DUNG;             
        private long _NGUOI_CAP_NHAT;
        private DateTime _NGAY_CAP_NHAT;
        private string _PRIOR;
        private long _NHOM_TIN;
        private string _DUYET;
        private long _NGUOI_DUYET;
        private long _SO_NGAY_HIEU_LUC;



        private DataSet _DSTapTinDinhKem;

     
        private DataSet _DetailDataSet;
        #endregion

        #region Định nghĩa thuộc tính

        public long ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }
        public long GetID() { return this._ID; }
        public string TIEU_DE
        {
            get { return this._TIEU_DE; }
            set { this._TIEU_DE=value; }
        }
        public string GetTIEU_DE() { return this._TIEU_DE; }
        public byte[] NOI_DUNG
        {
            get { return this._NOI_DUNG; }
            set { this._NOI_DUNG = value; }
        }
        public byte[] GetNOI_DUNG() { return this._NOI_DUNG;  }             
        public long NGUOI_CAP_NHAT
        {
            get { return this._NGUOI_CAP_NHAT; }
            set { this._NGUOI_CAP_NHAT = value; }
        }
        public long GetNGUOI_CAP_NHAT() { return this._NGUOI_CAP_NHAT; }
        public DateTime NGAY_CAP_NHAT
        {
            get { return this._NGAY_CAP_NHAT; }
            set { this._NGAY_CAP_NHAT = value; }
        }
        public DateTime GetNGAY_CAP_NHAT() { return this._NGAY_CAP_NHAT; }
        public string PRIOR
        {
            get { return this._PRIOR; }
            set { this._PRIOR = value; }
        }
        public string GetPRIOR() { return this._PRIOR; }
        public long NHOM_TIN
        {
            get { return this._NHOM_TIN; }
            set { this._NHOM_TIN = value; }
        }
        public long GetNHOM_TIN() { return this._NHOM_TIN; }
        public string DUYET
        {
            get { return this._DUYET; }
            set { this._DUYET = value; }
        }
        public string GetDUYET() { return this._DUYET; }
        public long NGUOI_DUYET
        {
            get { return _NGUOI_DUYET; }
            set { _NGUOI_DUYET = value; }
        }
        public long GetNGUOI_DUYET() { return this._NGUOI_DUYET; }
        public long SO_NGAY_HIEU_LUC
        {
            get { return _SO_NGAY_HIEU_LUC; }
            set { _SO_NGAY_HIEU_LUC = value; }
        }
        public long GetSO_NGAY_HIEU_LUC() { return this._SO_NGAY_HIEU_LUC; }
        private DateTime? _NGAY_DUYET;

        public DateTime? NGAY_DUYET
        {
            get { return _NGAY_DUYET; }
            set { _NGAY_DUYET = value; }
        }
        public DateTime? GetNGAY_DUYET() { return this._NGAY_DUYET; }
        public DataSet DetailDataSet
        {
            get { return this._DetailDataSet; }
            set { this._DetailDataSet = value; }
        }
        public DataSet GetDetailDataSet() { return this._DetailDataSet; }
        public DataSet DSTapTinDinhKem
        {
            get { return _DSTapTinDinhKem; }
            set { _DSTapTinDinhKem = value; }
        }
        #endregion

        #region Constructor

        public DOTinTuc()
        { 
            
        }
        public DOTinTuc(long id,string tieuDe,byte[] noiDung,string tapTin)
        {
            this._ID = id;
            this._TIEU_DE = tieuDe;
            this._NOI_DUNG = noiDung;           
        }

        public DOTinTuc(long Id, string TieuDe, byte[] NoiDung,
           long NguoiCapNhat,DateTime NgayCapNhat,string Prior,
           long NhomTin,string Duyet,long NguoiDuyet,DateTime? NgayDuyet,long SoNgayHieuLuc)
        {
            this._ID = Id;
            this._TIEU_DE = TieuDe;
            this._NOI_DUNG = NoiDung;                      
            this._NGUOI_CAP_NHAT = NguoiCapNhat;
            this._NGAY_CAP_NHAT = NgayCapNhat;
            this._PRIOR = Prior;
            this._NHOM_TIN = NhomTin;
            this._DUYET = Duyet;
            this._NGUOI_DUYET = NguoiDuyet;
            this._NGAY_DUYET = NgayDuyet;
            this._SO_NGAY_HIEU_LUC = SoNgayHieuLuc;
        }
        #endregion
    }
}
