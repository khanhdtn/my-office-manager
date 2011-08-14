using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;

namespace DTO
{
    public class DODuAn:DOPhieu
    {
        #region Các thuộc tính
        private long _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return _ID; }
        private string _NAME;

        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string GetNAME() { return _NAME; }
        private long _LOAI_DU_AN;

        public long LOAI_DU_AN
        {
            get { return _LOAI_DU_AN; }
            set { _LOAI_DU_AN = value; }
        }
        public long GetLOAI_DU_AN() { return _LOAI_DU_AN; }
        private long _NGUOI_QUAN_LY;

        public long NGUOI_QUAN_LY
        {
            get { return _NGUOI_QUAN_LY; }
            set { _NGUOI_QUAN_LY = value; }
        }
        public long GetNGUOI_QUAN_LY() { return _NGUOI_QUAN_LY; }
        private DateTime _NGAY_BAT_DAU;

        public DateTime NGAY_BAT_DAU
        {
            get { return _NGAY_BAT_DAU; }
            set { _NGAY_BAT_DAU = value; }
        }
        public DateTime GetNGAY_BAT_DAU() { return _NGAY_BAT_DAU; }
        private DateTime _NGAY_KET_THUC;

        public DateTime NGAY_KET_THUC
        {
            get { return _NGAY_KET_THUC; }
            set { _NGAY_KET_THUC = value; }
        }
        public DateTime GetNGAY_KET_THUC() { return _NGAY_KET_THUC; }
        private int _TIEN_DO;

        public int TIEN_DO
        {
            get { return _TIEN_DO; }
            set { _TIEN_DO = value; }
        }
        public int GetTIEN_DO() { return _TIEN_DO; }
        private long _MUC_UU_TIEN;

        public long MUC_UU_TIEN
        {
            get { return _MUC_UU_TIEN; }
            set { _MUC_UU_TIEN = value; }
        }
        public long GetMUC_UU_TIEN() { return _MUC_UU_TIEN; }
        private long _TINH_TRANG;

        public long TINH_TRANG
        {
            get { return _TINH_TRANG; }
            set { _TINH_TRANG = value; }
        }
        public long GetTINH_TRANG() { return _TINH_TRANG; }

        private string _MO_TA;

        public string MO_TA
        {
            get { return _MO_TA; }
            set { _MO_TA = value; }
        }
        public string GetMO_TA() { return _MO_TA; }

        private string _THONG_TIN_THEM;

        public string THONG_TIN_THEM
        {
            get { return _THONG_TIN_THEM; }
            set { _THONG_TIN_THEM = value; }
        }
        public string GetTHONG_TIN_THEM() { return _THONG_TIN_THEM; }
        #endregion

        #region Các hàm khởi tạo 
        public DODuAn() { }
        public DODuAn(long ID,string Name,long Loai_du_an,long Nguoi_quan_ly,DateTime Ngay_bat_dau,DateTime Ngay_ket_thuc,int Tien_do,long Muc_uu_tien,long Tinh_trang,string Mo_ta,string Thong_tin_them)
        {
            _ID = ID;
            _NAME = Name;
            _LOAI_DU_AN = Loai_du_an;
            _NGUOI_QUAN_LY = Nguoi_quan_ly;
            _NGAY_BAT_DAU = Ngay_bat_dau;
            _NGAY_KET_THUC = Ngay_ket_thuc;
            _TIEN_DO = Tien_do;
            _MUC_UU_TIEN = Muc_uu_tien;
            _TINH_TRANG = Tinh_trang;
            _MO_TA = Mo_ta;
            _THONG_TIN_THEM = Thong_tin_them;
        }
        #endregion
    }   
}
