using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DAO
{
    [Serializable]
    public class DOMeeting  : DOPhieu
    {
        #region Fields
        private long _ID;
        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return _ID; }

        private byte[] _NOI_DUNG;

        public byte[] NOI_DUNG
        {
            get { return _NOI_DUNG; }
            set { _NOI_DUNG = value; }
        }
        public byte[] GetNOI_DUNG() { return _NOI_DUNG; }
        private DateTime _GIO_BAT_DAU;

        public DateTime GIO_BAT_DAU
        {
            get { return _GIO_BAT_DAU; }
            set { _GIO_BAT_DAU = value; }
        }
        public DateTime GetGIO_BAT_DAU() { return _GIO_BAT_DAU; }
        private DateTime _GIO_KET_THUC;

        public DateTime GIO_KET_THUC
        {
            get { return _GIO_KET_THUC; }
            set { _GIO_KET_THUC = value; }
        }
        public DateTime GetGIO_KET_THUC() { return _GIO_KET_THUC; }
        private DateTime _NGAY;

        public DateTime NGAY
        {
            get { return _NGAY; }
            set { _NGAY = value; }
        }
        public DateTime GetNGAY() { return _NGAY; }
        private string _DIA_DIEM;

        public string DIA_DIEM
        {
            get { return _DIA_DIEM; }
            set { _DIA_DIEM = value; }
        }
        public string GetDIA_DIEM() { return _DIA_DIEM; }
        private long _NGUOI_TO_CHUC_ID;

        public long NGUOI_TO_CHUC_ID
        {
            get { return _NGUOI_TO_CHUC_ID; }
            set { _NGUOI_TO_CHUC_ID = value; }
        }
        public long GetNGUOI_TO_CHUC_ID() { return _NGUOI_TO_CHUC_ID; }
        //private long _TC_MEETING_ID;

        //public long TC_MEETING_ID
        //{
        //    get { return _TC_MEETING_ID; }
        //    set { _TC_MEETING_ID = value; }
        //}
        //public long GetTC_MEETING_ID() { return _TC_MEETING_ID; }
        //private long _LOAI_MEETING_ID;

        //public long LOAI_MEETING_ID
        //{
        //    get { return _LOAI_MEETING_ID; }
        //    set { _LOAI_MEETING_ID = value; }
        //}
        //public long GetLOAI_MEETING_ID() { return _LOAI_MEETING_ID; }
        private string _KET_QUA;

        public string KET_QUA
        {
            get { return _KET_QUA; }
            set { _KET_QUA = value; }
        }
        public string GetKET_QUA() { return _KET_QUA; }
        private long _NGUOI_CAP_NHAT_ID;

        public long NGUOI_CAP_NHAT_ID
        {
            get { return _NGUOI_CAP_NHAT_ID; }
            set { _NGUOI_CAP_NHAT_ID = value; }
        }
        public long GetNGUOI_CAP_NHAT_ID() { return _NGUOI_CAP_NHAT_ID; }
        private DateTime _NGAY_CAP_NHAT;

        public DateTime NGAY_CAP_NHAT
        {
            get { return _NGAY_CAP_NHAT; }
            set { _NGAY_CAP_NHAT = value; }
        }
        public DateTime GetNGAY_CAP_NHAT() { return _NGAY_CAP_NHAT; }
        //private string _NGUOI_THUC_HIEN;

        //public string NGUOI_THUC_HIEN
        //{
        //    get { return _NGUOI_THUC_HIEN; }
        //    set { _NGUOI_THUC_HIEN = value; }
        //}
        //public string GetNGUOI_THUC_HIEN() { return _NGUOI_THUC_HIEN; }
        private string _GHI_CHU;

        public string GHI_CHU
        {
            get { return _GHI_CHU; }
            set { _GHI_CHU = value; }
        }
        public string GetGHI_CHU() { return _GHI_CHU; }
        private string _THANH_PHAN_THAM_DU;

        public string THANH_PHAN_THAM_DU
        {
            get { return _THANH_PHAN_THAM_DU; }
            set { _THANH_PHAN_THAM_DU = value; }
        }
        public string GetTHANH_PHAN_THAM_DU() { return _THANH_PHAN_THAM_DU; }

        private string _THANH_PHAN_VANG_MAT;

        public string THANH_PHAN_VANG_MAT
        {
            get { return _THANH_PHAN_VANG_MAT; }
            set { _THANH_PHAN_VANG_MAT = value; }
        }
        public string GetTHANH_PHAN_VANG_MAT() { return _THANH_PHAN_VANG_MAT; }


        private string _CHU_DE;

        public string CHU_DE
        {
            get { return _CHU_DE; }
            set { _CHU_DE = value; }
        }
        public string GetCHU_DE() { return _CHU_DE; }

        private string _MUC_DICH;

        public string MUC_DICH
        {
            get { return _MUC_DICH; }
            set { _MUC_DICH = value; }
        }
        public string GetMUC_DICH() { return _MUC_DICH; }

        private long _THU_KY;

        public long THU_KY
        {
            get { return _THU_KY; }
            set { _THU_KY = value; }
        }
        public long GetTHU_KY() { return _THU_KY; }
        
        private long _LOAI_CUOC_HOP;
        public long LOAI_CUOC_HOP
        {
            get { return _LOAI_CUOC_HOP; }
            set { _LOAI_CUOC_HOP = value; }
        }
        public long GetLOAI_CUOC_HOP() { return _LOAI_CUOC_HOP; }

        private DataSet _DsFile;

        public DataSet DsFile
        {
            get { return _DsFile; }
            set { _DsFile = value; }
        }

        private DataSet _DetailDataSet;
        public DataSet DetailDataSet
        {
            get { return _DetailDataSet; }
            set { _DetailDataSet = value; }
        }
        public DataSet GetDetailDataSet() { return _DetailDataSet; }
        #endregion
        #region Inits method
        public DOMeeting() { }
        public DOMeeting(long ID, byte[] NoiDung, DateTime GioBD, DateTime GioKT, DateTime Ngay, string DiaDiem
            , long NguoiToChucID,string KetQua, long NguoiCapNhatID
            , DateTime NgayCapNhat, string GhiChu, string ThanhPhanThamDu, string ThanhPhanVangMat
            , string ChuDe, string MucDich, long ThuKy,long LoaiCuocHop)
        {
            _ID = ID;
            _NOI_DUNG = NoiDung;
            _GIO_BAT_DAU = GioBD;
            _GIO_KET_THUC = GioKT;
            _NGAY = Ngay;
            _DIA_DIEM = DiaDiem;
            _NGUOI_TO_CHUC_ID = NguoiToChucID;
            _LOAI_CUOC_HOP = LoaiCuocHop;
            _KET_QUA = KetQua;
            _NGUOI_CAP_NHAT_ID = NguoiCapNhatID;
            _NGAY_CAP_NHAT = NgayCapNhat;
            _GHI_CHU = GhiChu;
            _THANH_PHAN_THAM_DU = ThanhPhanThamDu;
            _THANH_PHAN_VANG_MAT = ThanhPhanVangMat;
            _THU_KY = ThuKy;
            _MUC_DICH = MucDich;
            _CHU_DE = ChuDe;
        }
        #endregion
    }
}
