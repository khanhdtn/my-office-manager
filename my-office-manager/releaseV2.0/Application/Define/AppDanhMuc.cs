using ProtocolVN.DanhMuc;
using ProtocolVN.Plugin.WarningSystem;


namespace pl.office
{
    public class AppDanhMuc
    {
        public static string CreateDanhMuc()
        {
            return
                @"<?xml version='1.0' encoding='utf-8' standalone='yes'?>
                <basiccats>
                    <group id ='1'>
                        <lang id='vn'>Tổ chức</lang>
                        <lang id='en'></lang>
                        " + DMNhanVienX.I.Item() + @"
                        " + DMFWPhongBanExt.I.Item() + @"
                    </group>
                    <group id ='2'>
                        <lang id='vn'>Thông tin</lang>
                        <lang id='en'></lang>
                        " + DMNhomTinTuc.I.Item() + @"
                        " + DMNhomDienDan.I.Item() + @"
                        " + DMChuyenMuc.I.Item() + @"
                        " + DMWebsite.I.Item() + @"
                        " + DMFolderRSS.I.Item() + @"
                        " + DMLienKetRSS.I.Item() + @"
                        " + DMFolderPictures.I.Item() + @"                                                                      
                        " + DMLoaiTaiLieu.I.Item() + @"
                        " + DMNhomDanhBaExt.I.Item() + @"
                    </group>    
                    <group id ='3'>
                        <lang id='vn'>Công việc</lang>
                        <lang id='en'></lang>
                        " + DMLoaiYeuCau.I.Item() + @"
                        " + DMLoaiCongViec.I.Item() + @"
                        " + DMLoaiDuAn.I.Item() + @"
                        " + DMNghiepVu.I.Item() + @"
                        " + DMNhomKhachHangX.I.Item() + @"
                    </group>    
                    <group id ='4'>
                        <lang id='vn'>Hành chính</lang>
                        <lang id='en'></lang>
                        " + DMDotTuyenDung.I.Item() + @"
                        " + DMViTriUngTuyen.I.Item() + @"
                        " + DMTinhTrangHoSo.I.Item() + @"
                        " + DMNguonThongTin.I.Item() + @"
                    </group>
                    <group id ='5'>
                        <lang id='vn'>Tài chính</lang>
                        <lang id='en'></lang>
                        " + DMLoaiChiPhi.I.Item() + @"
                        " + DMBank.I.Item() + @"
                    </group>
                    <group id ='6'>
                        <lang id='vn'>Trưng cầu ý kiến</lang>
                        <lang id='en'></lang>
                        " + DMVanDeGopY.I.Item() + @"
                        " + DMLoaiVanDe.I.Item() + @"
                    </group> 
                </basiccats>";                        
         }
    }
}
