using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    [Serializable]
    public class DOTiepNhanInfo : DOPhieu
    {
        public Int64 ID;
        public Int64 NGUON_THONG_TIN;
        public string VAN_DE_TIEP_NHAN;
        public byte[] NOI_DUNG;
        public Int64 NGUOI_CAP_NHAT;
        public DateTime NGAY_CAP_NHAT;
        public string NGUOI_XU_LY;
        public Int64 TINH_TRANG;

        public DataSet DataSetMaster = null;
        public DOTiepNhanInfo() { }
    }

    public class TiepNhanInfoFields {
        public const string ID = "ID";
        public const string NGUON_THONG_TIN = "NGUON_THONG_TIN";
        public const string VAN_DE_TIEP_NHAN = "VAN_DE_TIEP_NHAN";
        public const string NOI_DUNG = "NOI_DUNG";
        public const string NGUOI_CAP_NHAT = "NGUOI_CAP_NHAT";
        public const string NGAY_CAP_NHAT = "NGAY_CAP_NHAT";
        public const string NGUOI_XU_LY = "NGUOI_XU_LY";
        public const string TINH_TRANG = "TINH_TRANG";
    }
    
}
