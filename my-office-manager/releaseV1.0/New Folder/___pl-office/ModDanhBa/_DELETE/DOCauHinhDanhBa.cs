using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    public class DOCauHinhDanhBa:DOPhieu
    {
        #region Field
        private long _Loai_Danh_Ba;

        public long Loai_Danh_Ba
        {
            get { return _Loai_Danh_Ba; }
            set { _Loai_Danh_Ba = value; }
        }
        public long GetLOAI_DANH_BA() { return this._Loai_Danh_Ba; }
        private string _Field_Name;

        public string Field_Name
        {
            get { return _Field_Name; }
            set { _Field_Name = value; }
        }
        public string GetFIELD_NAME() { return this._Field_Name; }
        private string _Mo_Ta;

        public string Mo_Ta
        {
            get { return _Mo_Ta; }
            set { _Mo_Ta = value; }
        }
        public string GetMO_TA() { return this._Mo_Ta; }

        public Int32? _STT;
        public Int32? GetSTT() { return _STT; }
        private DataSet _DetailDataSet;

        public DataSet DetailDataSet
        {
            get { return _DetailDataSet; }
            set { _DetailDataSet = value; }
        }
        public DataSet GetDetailDataSet() { return this._DetailDataSet; }
        #endregion
        #region Initiated Function(s)
        public DOCauHinhDanhBa() { }
        public DOCauHinhDanhBa(long Loai_Danh_ba, string Field_Name, string Mo_Ta,Int32? stt)
        {
            this._Loai_Danh_Ba = Loai_Danh_ba;
            this._Field_Name = Field_Name;
            this._Mo_Ta = Mo_Ta;
            this._STT = stt;
        }
        #endregion
    }
}
