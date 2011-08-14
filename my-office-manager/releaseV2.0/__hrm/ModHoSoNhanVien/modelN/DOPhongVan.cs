using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{

    [Serializable]
    public class DOPhongVan : DOPhieu
    {
        #region Fields
        private long _ID ;
        private DateTime _NGAY_GIO_PHONG_VAN ;
        private int _VONG_PHONG_VAN;
        private int _LAN_MOI_PHONG_VAN ;
        private string _MOI_PHONG_VAN ;
        private string _UNG_VIEN_XAC_NHAN;
        private string _UNG_VIEN_XAC_NHAN_GHI_CHU;
        private string _THAM_DU;
        private string _THAM_DU_GHI_CHU ;
        private string _KET_QUA ;
        private DateTime? _NGAY_BAT_DAU;
        private string _THOI_GIAN_LAM_VIEC;
        private string _UNG_VIEN_DA_CHAP_NHAN;
        private decimal _MUC_LUONG;
        private long _DTD_ID;
        private long _R_ID;
        private string  _KET_QUA_GHI_CHU;
        private string _THONG_BAO_KET_QUA ;
        private string _THONG_TIN_KHAC;

        private DataSet _DetailDataSet;
        #endregion

        #region Members
        public long ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }
        public long GetID()
        {
            return this._ID;
        }
        public DateTime NGAY_GIO_PHONG_VAN { get { return this._NGAY_GIO_PHONG_VAN; } set { this._NGAY_GIO_PHONG_VAN = value; } }
        public DateTime GetNGAY_GIO_PHONG_VAN()
        {
            return this._NGAY_GIO_PHONG_VAN;
        }
        public int VONG_PHONG_VAN
        {
            get { return this._VONG_PHONG_VAN; }
            set { this._VONG_PHONG_VAN = value; }
        }
        public int GetVONG_PHONG_VAN()
        {
            return this._VONG_PHONG_VAN;
        }
        public int LAN_MOI_PHONG_VAN
        {
            get { return this._LAN_MOI_PHONG_VAN; }
            set { this._LAN_MOI_PHONG_VAN = value; }
        }
        public int GetLAN_MOI_PHONG_VAN()
        {
            return this._LAN_MOI_PHONG_VAN;
        }
        public string MOI_PHONG_VAN
        {
            get { return this._MOI_PHONG_VAN; }
            set { this._MOI_PHONG_VAN = value; }
        }
        public string GetMOI_PHONG_VAN()
        {
            return this._MOI_PHONG_VAN;
        }
        public string UNG_VIEN_XAC_NHAN
        {
            get { return this._UNG_VIEN_XAC_NHAN; }
            set { this._UNG_VIEN_XAC_NHAN = value; }
        }
        public string GetUNG_VIEN_XAC_NHAN()
        {
            return this._UNG_VIEN_XAC_NHAN;
        }
        public string UNG_VIEN_XAC_NHAN_GHI_CHU
        {
            get { return this._UNG_VIEN_XAC_NHAN_GHI_CHU; }
            set { this._UNG_VIEN_XAC_NHAN_GHI_CHU = value; }
        }
        public string GetUNG_VIEN_XAC_NHAN_GHI_CHU()
        {
            return this._UNG_VIEN_XAC_NHAN_GHI_CHU;
        }
        public string THAM_DU
        {
            get { return this._THAM_DU; }
            set { this._THAM_DU = value; }
        }
        public string GetTHAM_DU()
        {
            return this._THAM_DU;
        }
        public string THAM_DU_GHI_CHU
        {
            get { return this._THAM_DU_GHI_CHU; }
            set { this._THAM_DU_GHI_CHU = value; }
                
        }
        public string GetTHAM_DU_GHI_CHU()
        {
            return this._THAM_DU_GHI_CHU;
        }
        public string KET_QUA
        {
            get { return this._KET_QUA; }
            set { this._KET_QUA = value; }
        }
        public string GetKET_QUA()
        {
            return this._KET_QUA;
        }

        public DateTime? NGAY_BAT_DAU
        {
            get { return this._NGAY_BAT_DAU; }
            set { this._NGAY_BAT_DAU = value; }
        }
        public DateTime? GetNGAY_BAT_DAU()
        {
            return this._NGAY_BAT_DAU;
        }
        public string THOI_GIAN_LAM_VIEC
        {
            get { return this._THOI_GIAN_LAM_VIEC; }
            set { this._THOI_GIAN_LAM_VIEC = value; }
        }
        public string GetTHOI_GIAN_LAM_VIEC()
        {
            return this._THOI_GIAN_LAM_VIEC;
        }

        public string UNG_VIEN_DA_CHAP_NHAN
        {
            get { return this._UNG_VIEN_DA_CHAP_NHAN; }
            set { this._UNG_VIEN_DA_CHAP_NHAN = value; }
        }
        public string GetUNG_VIEN_DA_CHAP_NHAN()
        {
            return this._UNG_VIEN_DA_CHAP_NHAN; 
        }
        public decimal MUC_LUONG
        {
            get { return this._MUC_LUONG; }
            set { this._MUC_LUONG = value; }

        }
        public decimal GetMUC_LUONG()
        {
             return this._MUC_LUONG; 
        }
        public long DTD_ID
        {
            get { return this._DTD_ID; }
            set { this._DTD_ID = value; }
        }
        public long GetDTD_ID()
        {
            return this._DTD_ID; 
        }
     
        public long R_ID {
            get { return this._R_ID; }
            set { this._R_ID = value; }
        }
        public long GetR_ID()
        {
            return this._R_ID; 
        }
        public string KET_QUA_GHI_CHU
        {
            get { return this._KET_QUA_GHI_CHU; }
            set { this._KET_QUA_GHI_CHU = value; }
        }
        public string GetKET_QUA_GHI_CHU()
        {
            return this._KET_QUA_GHI_CHU; 
        }
        public  string THONG_BAO_KET_QUA { 
            get{ return this._THONG_BAO_KET_QUA;}
            set { this._THONG_BAO_KET_QUA = value; }
        }
        public string GetTHONG_BAO_KET_QUA()
        {
            return this._THONG_BAO_KET_QUA; 
        }
        public string THONG_TIN_KHAC
        {
            get { return this._THONG_TIN_KHAC; }
            set { this._THONG_TIN_KHAC = value; }
        }
        public string GetTHONG_TIN_KHAC()
        {
            return this._THONG_TIN_KHAC;
        }
        public DataSet DetailDataSet
        {
            get { return this._DetailDataSet; }
            set { this._DetailDataSet = value; }
        }
        public DataSet GetDetailDataSet()
        {
            return this._DetailDataSet;
        }
        #endregion

        #region DO
        public DOPhongVan() { }
        public DOPhongVan(
             long _ID ,
             DateTime _NGAY_GIO_PHONG_VAN ,
             int _VONG_PHONG_VAN,
             int _LAN_MOI_PHONG_VAN ,
             string _MOI_PHONG_VAN ,
             string _UNG_VIEN_XAC_NHAN,
             string _UNG_VIEN_XAC_NHAN_GHI_CHU,
             string _THAM_DU,
             string _THAM_DU_GHI_CHU ,
             string _KET_QUA ,
             DateTime? _NGAY_BAT_DAU,
             string _THOI_GIAN_LAM_VIEC,
             string _UNG_VIEN_DA_CHAP_NHAN,
             decimal _MUC_LUONG,
             long _DTD_ID,
             long _R_ID,
             string  _KET_QUA_GHI_CHU,
             string _THONG_BAO_KET_QUA ,
             string _THONG_TIN_KHAC
            )
        {
             this._ID   = _ID;
             this._NGAY_GIO_PHONG_VAN  =  _NGAY_GIO_PHONG_VAN;
             this._VONG_PHONG_VAN = _VONG_PHONG_VAN;
             this._LAN_MOI_PHONG_VAN  = _LAN_MOI_PHONG_VAN;
             this. _MOI_PHONG_VAN  = _MOI_PHONG_VAN;
             this. _UNG_VIEN_XAC_NHAN = _UNG_VIEN_XAC_NHAN;
             this. _UNG_VIEN_XAC_NHAN_GHI_CHU = _UNG_VIEN_XAC_NHAN_GHI_CHU;
             this._THAM_DU = _THAM_DU;
             this. _THAM_DU_GHI_CHU  = _THAM_DU_GHI_CHU;
             this. _KET_QUA = _KET_QUA;
             this._NGAY_BAT_DAU = _NGAY_BAT_DAU;
             this._THOI_GIAN_LAM_VIEC = _THOI_GIAN_LAM_VIEC;
             this._UNG_VIEN_DA_CHAP_NHAN = _UNG_VIEN_DA_CHAP_NHAN;
             this._MUC_LUONG = _MUC_LUONG;
             this._DTD_ID = _DTD_ID;
             this._R_ID = _R_ID;
             this.  _KET_QUA_GHI_CHU = _KET_QUA_GHI_CHU;
             this._THONG_BAO_KET_QUA  = _THONG_BAO_KET_QUA;
             this._THONG_TIN_KHAC = _THONG_TIN_KHAC;
        }
        #endregion
    }
}
