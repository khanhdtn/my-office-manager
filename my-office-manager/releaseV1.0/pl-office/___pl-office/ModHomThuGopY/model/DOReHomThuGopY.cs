using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    public class DOReHomThuGopY : DOPhieu
    {
        #region Fields
        public long ID;
        public long GOP_Y_ID;
        public byte[] NOI_DUNG_PHAN_HOI;
        public long NGUOI_PHAN_HOI_ID;
        public DateTime NGAY;
        #endregion
        public DataSet MasterDataSet = null;
        public DOReHomThuGopY() { }
    }
}
