using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using ProtocolVN.Framework.Win;

namespace DTO
{
    public class DOBangLuong : DOPhieu
    {
        public Int64 ID;
        public Int64 NV_ID;
        public string THANG_NAM;
        public decimal TONG_THU_NHAP;
        public decimal TAM_UNG;
        public string IS_CHOT;

        public decimal DA_THANH_TOAN;
        public decimal TT_CON_LAI;
        public string IS_KET_CHUYEN;
        public DataSet DetailDataSet;

        public DOBangLuong() { }
        
    }
}
