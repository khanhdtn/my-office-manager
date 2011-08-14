using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;

namespace DTO
{
    public class DOHenPhongVan : DOPhieu
    {
        public long ID;                        
        public DateTime NGAY_GIO_PHONG_VAN;
        public TimeSpan? GIO_PHONG_VAN;
        public int VONG_PHONG_VAN;             
        public int LAN_MOI_PHONG_VAN;           
        public string MOI_PHONG_VAN;              
        public string UNG_VIEN_XAC_NHAN;           
        public string UNG_VIEN_XAC_NHAN_GHI_CHU;   
        public string THAM_DU ;                    
        public string THAM_DU_GHI_CHU ;            
        public string KET_QUA;                     
        public DateTime NGAY_BAT_DAU;
        public decimal MUC_LUONG;               
        public string THOI_GIAN_LAM_VIEC;          
        public string KET_QUA_GHI_CHU;
        public string THONG_BAO_KET_QUA;                
        public string UNG_VIEN_DA_CHAP_NHAN;       
        public long R_ID;
        public string THONG_TIN_KHAC;
        //Them
        //public DateTime DEN_NGAY;
        //public string ISHL_TV_TT;
        public long SO_NGAY;
        

        public DOHenPhongVan() { }
        public DOHenPhongVan(
             long ID,                        
             DateTime NgayGioPV,TimeSpan? GioPV,         
             int VongPV,             
             int LanMoiPV,           
             string MoiPV,              
             string IsXacNhan,           
             string XacNhanGhiChu,   
             string IsThamDu ,                    
             string ThamDuGhiChu ,            
             string KetQua,                     
             DateTime NgayBatDau,
             decimal MucLuong,     
             string IsThoiGianLamViec,
             string KetQuaGhiChu,
             string IsThongBaoKetQua,
             string IsChapNhan,       
             long R_ID,
             string ThongTinKhac,
             //string IsHL_TV_TT,
             long SoNgay
             //DateTime DenNgay
        )
        {
            this.ID = ID;
            this.NGAY_GIO_PHONG_VAN = NgayGioPV;
            this.GIO_PHONG_VAN = GioPV;
            this.VONG_PHONG_VAN = VongPV;
            this.LAN_MOI_PHONG_VAN = LanMoiPV;
            this.MOI_PHONG_VAN = MoiPV;
            this.UNG_VIEN_XAC_NHAN = IsXacNhan;
            this.UNG_VIEN_XAC_NHAN_GHI_CHU = XacNhanGhiChu;
            this.THAM_DU = IsThamDu;
            this.THAM_DU_GHI_CHU = ThamDuGhiChu;
            this.KET_QUA = KetQua;
            this.NGAY_BAT_DAU = NgayBatDau;
            this.THOI_GIAN_LAM_VIEC = IsThoiGianLamViec;
            this.KET_QUA_GHI_CHU = KetQuaGhiChu;
            this.UNG_VIEN_DA_CHAP_NHAN = IsChapNhan;
            this.THONG_BAO_KET_QUA = IsThongBaoKetQua;
            this.MUC_LUONG = MucLuong;
            this.R_ID = R_ID;
            this.THONG_TIN_KHAC = ThongTinKhac;

            //
            //this.ISHL_TV_TT = IsHL_TV_TT;
            this.SO_NGAY = SoNgay;
            //this.DEN_NGAY = DenNgay;
        }
    }
}
