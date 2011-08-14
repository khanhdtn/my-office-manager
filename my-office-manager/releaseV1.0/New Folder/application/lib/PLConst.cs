using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace office
{
    public class HelpStringBuilder { 
        public static string GetTitleMailNewPageper(string title){
            return string.Format(PLConst.TITLE_MAIL, title);
        }
        public static string GetDesMailNewPageper(string personUpdate, string dateUpdate, string groupNewPageper, string chuDe) {
            return string.Format(PLConst.DES_MAIL_NEW_PAGEPER, personUpdate, dateUpdate, groupNewPageper, chuDe);
        }

    }
    #region Danh sách các tham số cố định
    public class PLConst
    {
        public const string TRUE = "Y";
        public const string FALSE = "N";
        /// <summary>
        /// Nếu sửa lại chuỗi "<Chưa thực hiện>" thì phải sửa luôn store produre "ST_TONG_TIEN_DO_CV" trong DB.
        /// </summary>
        public const string GHI_CHU_PCCV = "<Bắt đầu thực hiện>";
        public const string EXPRESSION_WEBSITE = @"^(((h|H?)(t|T?)(t|T?)(p|P?)(s|S?))\://)?(www.|[a-zA-Z0-9].){3}[a-zA-Z0-9\-\.]+\.[a-zA-Z]*$";
        public const string EXPRESSION_EMAIL = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string CHO_DUYET = "CHO_DUYET";
        public const string DUYET = "DUYET";
        public const string KHONG_DUYET = "KHONG_DUYET";
        public const long QUYEN_DUYET_NGHI_PHEP = 141;
        public const long QUYET_DUYET_RA_VAO_CTY = 160;
        public const long QUYET_DUYET_XN_LAM_VIEC = 161;
        public const long QUYET_DUYET_TAM_UNG = 133;
        /// <summary>
        /// Bảng nghiệp vụ liên quan đến Khách hàng, Dự án, Công việc.
        /// </summary>
        public const string bangKH_DA_CV = "KH_DA_CV";

        public static string FORMAT_DATETIME_STRING
        { 
            get { return FrameworkParams.option.dateFormat + " " + FrameworkParams.option.timeFormat; } 
        }
        public static string FORMAT_DATE_STRING {
            get {
                return FrameworkParams.option.dateFormat;
            }
        }
        public static string FORMAT_TIME_STRING 
        {
            get { return FrameworkParams.option.timeFormat; }
        } 
        public static Size SIZE_POPUP_FORM = new Size(800, 500);

        public static string FORMAT_TIME_HH_MM = "HH:mm";

        #region Send mail
        public static string TITLE_MAIL = @"[PL-Office]: {0}";
        public static string DES_MAIL_NEW_PAGEPER = @"
                        Người cập nhật:&nbsp;{0}
                    <br>Ngày cập nhật:&nbsp;&nbsp;{1}</br>
                    <br>Nhóm tin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{2}</br>
                    <br>Chủ đề:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}</br>
            ";
        public static string DES_MAIL_XNP = @"
                        Người nghỉ phép:&nbsp;{0}
                    <br>Ngày nghỉ phép:&nbsp;&nbsp;&nbsp;{1}. {2}</br>
                    <br>Loại nghỉ phép:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}</br>
                    <br>Lý do:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{4}</br>
            ";
        public static string DES_MAIL_RVCTY = @"
                           Nhân viên:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{0}
                    <br>Ngày làm việc:&nbsp;{1}</br>
                    <br>Thời gian từ:&nbsp;&nbsp;&nbsp;&nbsp;{2}&nbsp;đến&nbsp;{3}</br>
                    <br>Lý do:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{4}</br>
            ";
        public static string DES_MAIL_XNLV = @"
                        Nhân viên:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{0}
                    <br>Ngày làm việc:&nbsp;{1}</br>
                    <br>Thời gian từ:&nbsp;&nbsp;&nbsp;&nbsp;{2}&nbsp;đến&nbsp;{3}</br>
                    <br>Lý do:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{4}</br>
            ";
        public static string DES_MAIL_NEW_INFO = @"Vấn đề tiếp nhận:&nbsp;&nbsp;&nbsp;&nbsp;{0}
                    <br>Người tiếp nhận:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{4}</br>
                    <br>Thời gian tiếp nhận:&nbsp;{1}</br>
                    <br>Nguồn thông tin:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{2}</br>
                    <br>Người xử lý:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}</br>";
        public static string DES_MAIL_YCHT = @"
                        Chủ đề:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{0}
                    <br>Loại yêu cầu:&nbsp;{1}</br>  
                    <br>Người gửi:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{2}</br>            
                    <br>Nội dung:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}</br>                    
            ";
        public static string DES_MAIL_VAN_DE = @"
                        Vấn đề:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{0}
                    <br>Loại vấn đề:&nbsp;{1}</br>  
                    <br>Người gửi:&nbsp;&nbsp;&nbsp;{2}</br>            
                    <br>Nội dung:&nbsp;&nbsp;{3}</br>                    
            ";
        public static string DES_MAIL_HTGY = @"
                        Vấn đề góp ý:&nbsp;{0}
                    <br>Người gửi:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{1}</br>            
                    <br>Nội dung:&nbsp;&nbsp;{2}</br>                    
            ";
        public static string DES_MAIL_YCHT_PH = @"
                        Phản hồi từ chủ đề:&nbsp;{0}
                    <br>Loại yêu cầu:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{1}</br>  
                    <br>Người phản hồi:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{2}</br>          
                    <br>Nội dung:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{3}</br>                    
            ";

        public static string DES_MAIL_MEETING = @"
                        Ngày:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{0}, thời gian từ {1} đến {2}
                    <br>Địa điểm:&nbsp;&nbsp;&nbsp;{3}
                    <br>Nội dung:&nbsp;&nbsp;&nbsp;{4}
                    <br>Những người nhận được e-mail này vui lòng tới đúng thời gian và địa điểm trên để tham gia.
                    <br>Chân thành cám ơn!
            ";

        #endregion
        public static string G_NGHIEP_VU = "G_NGHIEP_VU";
        //public static string G_NGHIEP_VU = HelpGen.G_FW_PHIEU_ID;
        public static string G_DANH_MUC = "G_DANH_MUC";
        public static string FIELD_DUYET = "DUYET";
        public static string FIELD_NGUOI_DUYET = "NGUOI_DUYET";
        public static string FIELD_NGAY_DUYET = "NGAY_DUYET";
        public static string FIELD_ID = "ID";
        public static string FIELD_NAME = "NAME";
        public static long GetGenIDNghiepVu()
        {
            return HelpDB.getDatabase().GetID(G_NGHIEP_VU);
        }
    }
    #endregion

    #region Danh sách enum
    /// <summary>Tình trạng Duyệt
    /// </summary>
    public enum DuyetSupportStatus
    {
        /// <summary>
        /// Duyệt = 2
        /// </summary>
        Duyet = 2,
        /// <summary>
        /// Chờ duyệt = 1
        /// </summary>
        ChoDuyet = 1,
        /// <summary>
        /// Không duyệt = 3
        /// </summary>
        KhongDuyet = 3,
        /// <summary>
        /// Ra vào công ty = 4
        /// </summary>
        RaVaoCongTy = 4
    }

    /// <summary>Kiểu mẫu tin Ghi thời gian/Xin nghỉ phép, Đi trễ về sớm
    /// </summary>
    public enum TimeInOutType
    {
        /// <summary>
        /// 1.Ghi thời gian làm việc
        /// </summary>
        GhiThoiGian = 1,
        /// <summary>
        /// 2.Nghỉ phép
        /// </summary>
        NghiPhep = 2,
        /// <summary>
        /// 3.Đi sớm về trễ
        /// </summary>
        DiSomVeTre = 3,
        /// <summary>
        /// 4.Ra vào công ty
        /// </summary>
        RaVaoCongTy = 4,
        /// <summary>
        /// 5.Xác nhận làm việc
        /// </summary>
        XacNhanLamViec = 5
    }
    public enum LoaiXacNhan { 
        /// <summary>
        /// 1.Công tác ngoài
        /// </summary>
        CongTacNgoai = 1,
        /// <summary>
        /// 2.Tại công ty
        /// </summary>
        TaiCongTy = 2
    }
    public enum TrangThaiForm
    {
        Add,
        Update,
        Show,
        Other
    }

    public enum LoaiPhieu { 
        /// <summary>
        /// Loại phiếu là "Xin nghỉ phép"
        /// </summary>
        PhieuXinNghiPhep = 1 ,
        /// <summary>
        /// Loại phiếu là "Xác nhận làm việc"
        /// </summary>
        PhieuXacNhanLamViec = 2,
        /// <summary>
        /// Loại phiếu là "Ra vào công ty"
        /// </summary>
        PhieuRaVaoCty = 3
    }

    public enum LoaiTapTin
    {
        /// <summary>
        /// Tập tin của tin tức
        /// </summary>
        TapTinTinTuc = 1,
        /// <summary>
        /// Tập tin của diễn đàn
        /// </summary>
        TapTinDienDan = 2,
        /// <summary>
        /// Tập tin của tài liệu
        /// </summary>
        TapTinTaiLieu = 3,
        /// <summary>
        /// Tập tin của hình ảnh
        /// </summary>
        TapTinHinhAnh = 4,
        /// <summary>
        /// Tập tin của công việc
        /// </summary>
        TapTinCongViec = 5,
        /// <summary>
        /// Tập tin của cuộc họp
        /// </summary>
        TapTinCuocHop = 6,
        /// <summary>
        /// Tập tin của dự án
        /// </summary>
        TapTinDuAn = 7,
        /// <summary>
        /// Tập tin của khách hàng
        /// </summary>
        KhachHangTaptin = 8,
        /// <summary>
        ///Tập tin của Vấn đề 
        /// </summary>
        VanDeTaptin = 9,
        /// <summary>
        /// tập tin của phản hồi vấn đề
        /// </summary>
        PhanHoiVanDeTaptin = 10


    }
    #endregion

}
