using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    public class DOHomThuGopY : DOPhieu
    {
        #region Fields
        public long ID;
        public string TIEU_DE;
        public long VAN_DE_GOP_Y_ID;
        public DateTime NGAY;
        public long NGUOI_GOP_Y;
        public byte[] NOI_DUNG;
        public string NGUOI_NHAN_GOP_Y;
        public string IS_HIEN;
        #endregion
        public DataSet MasterDataSet = null;
        public DOHomThuGopY() { }
    }
}
