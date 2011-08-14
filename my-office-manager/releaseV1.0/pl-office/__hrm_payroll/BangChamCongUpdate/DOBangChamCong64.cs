using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    [Serializable]
    public class DOBangChamCong64 : DOPhieu
    {
        public Int64 ID;
        public Int64 EMP_ID;
        public string THANG_NAM;

        public string N01_SANG;
        public string N01_CHIEU;
        public string N02_SANG;
        public string N02_CHIEU;
        public string N03_SANG;
        public string N03_CHIEU;
        public string N04_SANG;
        public string N04_CHIEU;
        public string N05_SANG;
        public string N05_CHIEU;
        public string N06_SANG;
        public string N06_CHIEU;
        public string N07_SANG;
        public string N07_CHIEU;
        public string N08_SANG;
        public string N08_CHIEU;
        public string N09_SANG;
        public string N09_CHIEU;
        public string N10_SANG;
        public string N10_CHIEU;
        public string N11_SANG;
        public string N11_CHIEU;
        public string N12_SANG;
        public string N12_CHIEU;
        public string N13_SANG;
        public string N13_CHIEU;
        public string N14_SANG;
        public string N14_CHIEU;
        public string N15_SANG;
        public string N15_CHIEU;
        public string N16_SANG;
        public string N16_CHIEU;
        public string N17_SANG;
        public string N17_CHIEU;
        public string N18_SANG;
        public string N18_CHIEU;
        public string N19_SANG;
        public string N19_CHIEU;
        public string N20_SANG;
        public string N20_CHIEU;
        public string N21_SANG;
        public string N21_CHIEU;
        public string N22_SANG;
        public string N22_CHIEU;
        public string N23_SANG;
        public string N23_CHIEU;
        public string N24_SANG;
        public string N24_CHIEU;
        public string N25_SANG;
        public string N25_CHIEU;
        public string N26_SANG;
        public string N26_CHIEU;
        public string N27_SANG;
        public string N27_CHIEU; 
        public string N28_SANG;
        public string N28_CHIEU;
        public string N29_SANG;
        public string N29_CHIEU;
        public string N30_SANG;
        public string N30_CHIEU;
        public string N31_SANG;
        public string N31_CHIEU;

        public decimal NGHI_CO_PHEP;
        public decimal NGHI_KHONG_PHEP;
        public decimal SO_NGAY_LAM_VIEC;
        public decimal SO_NGAY_KHONG_LUONG;
        public decimal SO_NGAY_TRO_CAP;
        public decimal SO_NGAY_HUONG_LUONG;

        public DataSet MasterDataSet = new DataSet();
        public DOBangChamCong64() { }
    }
}
