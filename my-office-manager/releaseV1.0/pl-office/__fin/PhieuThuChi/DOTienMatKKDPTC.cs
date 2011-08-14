using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;

namespace DTO
{
    [Serializable]
    public class DOTienMatKKDPTC : DOPhieu
    {
        public Int64 KKD_ID;
        public decimal TM_DAU_KY;
        public decimal PHAT_SINH_TANG;
        public decimal PHAT_SINH_GIAM;
        public decimal TM_CUOI_KY;
        public DataSet MasterDataSet = new DataSet();
        public DOTienMatKKDPTC() { }

    }
}
