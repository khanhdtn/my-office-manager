using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    class DOLoaiDanhBa:DOPhieu
    {
        #region Fields
        private long _ID;

        public long ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public long GetID() { return this._ID; }
        private string _Ten_Loai;

        public string Ten_Loai
        {
            get { return _Ten_Loai; }
            set { _Ten_Loai = value; }
        }
        public string GetTEN_LOAI() { return this._Ten_Loai; }
        private DataSet _DetailDataSet;

        public DataSet DetailDataSet
        {
            get { return _DetailDataSet; }
            set { _DetailDataSet = value; }
        }
        public DataSet GetDetailDataSet() { return this._DetailDataSet; }
        #endregion

        #region Initiated Function(s)
        public DOLoaiDanhBa() { }
        public DOLoaiDanhBa(long ID,string Ten_Loai)
        {
            this._ID = ID;
            this._Ten_Loai = Ten_Loai;
        }
        #endregion
    }
}
