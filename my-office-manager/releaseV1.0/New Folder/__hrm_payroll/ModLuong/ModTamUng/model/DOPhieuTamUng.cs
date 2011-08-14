using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
//CHAUTV :
namespace DTO
{
    public class DOPhieuTamUng : DOPhieu
    {
        #region Fields
        public long ID;
        public string MA_PHIEU;
        public long NGUOI_DE_NGHI_ID;
        public DateTime NGAY_XIN_TAM_UNG;
        public long? BP_ID;
        public decimal SO_TIEN_XIN_UNG;
        public string LY_DO;
        public decimal SO_TIEN_NHAN;
        public string DA_NHAN_BIT;
        public long? NGUOI_NHAN_ID;
        public DateTime? NGAY_NHAN;
        public string GHI_CHU;
        public long? NGUOI_DUYET;
        public DateTime? NGAY_DUYET;
        public string DUYET;
        public string CHUYEN_DEN_LUONG_BIT;
        public string THANG_TAM_UNG;        
        public string KET_CHUYEN_TU_LUONG;
        #endregion

        public DataSet MasterDataSet = null;
        public DOPhieuTamUng() { }
    }
}
