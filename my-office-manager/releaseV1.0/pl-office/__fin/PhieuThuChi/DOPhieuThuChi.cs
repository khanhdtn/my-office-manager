using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    [Serializable]
    public class DOPhieuThuChiExt : DOPhieu
    {
        public  Int64 PTC_ID;
        public  string CODE;
        public  Int64 LCP_ID;
        public  DateTime NGAY_PHAT_SINH;
        public  DateTime NGAY_TAO_PHIEU;
        public  Int64 NGUOI_TAO_PHIEU;
        public  Int64 EMP_ID;
        public  decimal SO_TIEN_THU;
        public  decimal SO_TIEN_CHI;
        public  string DON_VI_LIEN_QUAN;
        public  string DIEN_GIAI;
        public Int64 KKD_ID;
        public  string THU_CHI_BIT;
        public DataSet MasterDataSet = new DataSet();

        public DOPhieuThuChiExt()
        { 
        }

    }
}
