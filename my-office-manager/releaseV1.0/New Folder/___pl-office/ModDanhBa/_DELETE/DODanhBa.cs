using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    public class DODanhBa : DOPhieu
    {
        private long _ID;
        private string _NAME;
        private string _DIA_CHI;
        private string _SO_DIEN_THOAI;
        private string _SO_CMND;
        private string _SO_FAX;              
        private string _NGUOI_DAI_DIEN;
        private string _CHUC_VU;
        private string _BO_PHAN;
        private string _TAI_KHOAN;
        private long _LOAI_DANH_BA;
        private string _EMAIL;
        private DataSet _DetailDataSet;
       

         public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return _ID; }




        public string NAME
        {
            get { return _NAME; }
            set { _NAME = value; }
        }
        public string GetNAME() { return _NAME; }



        public string DIA_CHI
        {
            get { return _DIA_CHI; }
            set { _DIA_CHI = value; }
        }
        public string GetDIA_CHI() { return _DIA_CHI; }



        public string SO_DIEN_THOAI
        {
            get { return _SO_DIEN_THOAI; }
            set { _SO_DIEN_THOAI = value; }
        }
        public string GetSO_DIEN_THOAI() { return _SO_DIEN_THOAI; }

        public string SO_CMND
        {
            get { return _SO_CMND; }
            set { _SO_DIEN_THOAI = value; }
        }
        public string GetSO_CMND() { return _SO_CMND; }

        public string SO_FAX
        {
            get { return _SO_FAX; }
            set { _SO_FAX = value; }
        }
        public string GetSO_FAX() { return _SO_FAX; }
      
     
        public string NGUOI_DAI_DIEN
        {
            get { return _NGUOI_DAI_DIEN; }
            set { _NGUOI_DAI_DIEN = value; }
        }
        public string GetNGUOI_DAI_DIEN() { return _NGUOI_DAI_DIEN; }
        
        public string CHUC_VU
        {
            get { return _CHUC_VU; }
            set { _CHUC_VU = value; }
        }
        public string GetCHUC_VU() { return _CHUC_VU; }


        public string BO_PHAN
        {
            get { return _BO_PHAN; }
            set { _BO_PHAN = value; }
        }
        public string GetBO_PHAN() { return _BO_PHAN; }

        public string SO_TAI_KHOAN
        {
            get{return _TAI_KHOAN;}
            set { _TAI_KHOAN = value; }
        }
        public string GetTAI_KHOAN() { return _TAI_KHOAN; }
        public string EMAIL
        {
            get { return _EMAIL; }
            set { _EMAIL = value; }
        }
        public string GetEMAIL() { return _EMAIL; }

        public DataSet DetailDataSet
        {
            get { return this._DetailDataSet; }
            set { this._DetailDataSet = value; }
        }
        public DataSet GetDetailDataset() { return _DetailDataSet; }
        public DODanhBa() { }

        public DODanhBa
        (
             long ID,
             string NAME,
             string DIA_CHI,
             string DIEN_THOAI,
             string CMND,
             string FAX,            
             string NGUOI_DAI_DIEN,
             string CHUC_VU,
             string BO_PHAN,      
             long LOAI_DANH_BA,
             string EMAIL
        )
        {
            this._ID = ID;
            this._NAME = NAME;
            this._DIA_CHI = DIA_CHI;
            this._SO_CMND = CMND;
            this._SO_FAX = FAX;
            this._NGUOI_DAI_DIEN = NGUOI_DAI_DIEN;
            this.CHUC_VU = CHUC_VU;
            this._BO_PHAN = BO_PHAN;
            this._LOAI_DANH_BA = LOAI_DANH_BA;
            this.EMAIL = EMAIL;

        }    

    }
}
