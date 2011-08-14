using System;
using System.Collections.Generic;
using System.Text;

namespace pl.office
{
    public class AppParams
    {
        public static string G_NGHIEP_VU = "G_NGHIEP_VU";
        public static string SUBJECT_THONG_BAO = @"[PL-Office] Thông báo: {0}";
        public static string CONTENT_THONG_BAO_TAM_UNG = @"Trên hệ thống [PL-Office] có nhận được một phiếu đề nghị tạm ứng của "
                                            + @"\nNhân viên: {0},"
                                            + @"\nNgày: {1},"
                                            + @"\nSố tiền: {2},"
                                            + @"\nLý do: {3}";
        public static string CONTENT_DUYET_TAM_UNG = @"[PL-Office] Thông báo Duyệt phiếu tạm ứng:\n"
                                            + @"Nhân viên xin tạm ứng: {0}"
                                            + @"\nKết quả duyệt: {1}"
                                            + @"\nNgười duyệt: {2}";
    }
}
