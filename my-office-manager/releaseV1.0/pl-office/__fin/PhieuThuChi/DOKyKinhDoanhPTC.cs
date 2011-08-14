using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;

namespace DTO
{
    [Serializable]
    public class DOKyKinhDoanhPTC : DOPhieu
    {
        public Int64 KKD_ID;
        public DateTime TU_NGAY;
        public DateTime? DEN_NGAY;
        public Int64? NGUOI_TAO_ID;
        public Int64? NGUOI_KHOA_SO_ID;
        public string KHOA_SO_BIT;

        public DataSet MasterDataSet = new DataSet();
        public DOKyKinhDoanhPTC() { }

    }
}
