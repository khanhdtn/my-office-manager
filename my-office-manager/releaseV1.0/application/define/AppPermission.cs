using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;

namespace ProtocolVN.App.Office
{
    public class AppPermission
    {
        public AppPermission() {
            #region Phân quyền của FW
            FWPermission.Init();
            #endregion
            #region Phân quyền của Ứng dụng
            #region Phân quyền Danh mục
            DMFWNhanVien.isPermission = true;
            DMFWPhongBan.isPermission = true;

            DMNhanVienX.isPermission = true;
            DMDotTuyenDung.isPermission = true;
            DMViTriUngTuyen.isPermission = true;
            DMBangChonPhongVan.isPermission = true;
            DMTinhTrangHoSo.isPermission = true;
            DMLoaiChiPhi.isPermission = true;
            DMLoaiYeuCau.isPermission = true;
            DMTinhTrangCongViec.isPermission = true;
            DMNhomTinTuc.isPermission = true;
            DMLoaiCongViec.isPermission = true;
            DMBank.isPermission = true;
            DMNhomDienDan.isPermission = true;
            DMWebsite.isPermission = true;
            DMFolderRSS.isPermission = true;
            DMFolderPictures.isPermission = true;
            DMLoaiTaiLieu.isPermission = true;
            DMLoaiDuAn.isPermission = true;
            DMNhomKhachHang.isPermission = true;
            DMNhomDanhBaExt.isPermission = true;
            DMLienKetRSS.isPermission = true;
            DMChuyenMuc.isPermission = true;
            #endregion

            #region Phân quyền đối tượng
            
            #endregion

            #region Phân quyền báo biểu
            #endregion

            #region Phân quyền Chức năng
            #endregion
            #endregion
        }

        #region Function : VIEW 
        public static Permission FDuyetNhatKyLamViec = new Permission("FDuyetNhatKyLamViec", "Duyá»‡t nháº­t kÃ½ lÃ m viá»‡c");

        public static Permission FQuanTriChamCong = new Permission("FQuanTriChamCong", "");
        public static Permission FBienTapChamCong = new Permission("FBienTapChamCong", "");

        public static Permission FChotBoChotChamCongAuto = new Permission("FChotBoChotChamCongAuto", "Chá»‘t - bá» chá»‘t cháº¥m cÃ´ng Auto");

        public static Permission FQuanTriNghiPhep = new Permission("FQuanTriNghiPhep", "Quáº£n trá»‹ nghá»‰ phÃ©p");
        public static Permission FBienTapNghiPhep = new Permission("FBienTapNghiPhep", "BiÃªn táº­p nghá»‰ phÃ©p");

        public static Permission FQuanTriRaVaoCty = new Permission("FQuanTriRaVaoCty", "");
        public static Permission FBienTapRaVaoCty = new Permission("FBienTapRaVaoCty", "");


        public static Permission FQuanTriXNLamViec = new Permission("FQuanTriXNLamViec", "");
        public static Permission FBienTapXNLamViec = new Permission("FBienTapXNLamViec", "");

        public static Permission FQuanTriThoiGianLamViec = new Permission("FQuanTriThoiGianLamViec", "");

        public static Permission FDuyetTaiLieu = new Permission("FDuyetTaiLieu", "Duyet/Khong duyet Tài liệu");
        
        public static Permission FXemBCCToanBo = new Permission("FXemBCCToanBo", "");
        
        public static Permission FPhanHoiYeuCauHoTro = new Permission("FPhanHoiYeuCauHoTro", "");
        public static Permission FDuyetPhieuRaVaoCty = new Permission("FDuyetPhieuRaVaoCty", "Duyá»‡t/khÃ´ng duyá»‡t phiáº¿u ra vÃ o cÃ´ng ty");
        public static Permission FDuyetPhieuXNLamViec = new Permission("FDuyetPhieuXNLamViec", "Duyá»‡t/khÃ´ng duyá»‡t phiáº¿u xÃ¡c nháº­n lÃ m viá»‡c");
        public static Permission FDuyetCuocHop = new Permission("FDuyetCuocHop", "Duyá»‡t/KhÃ´ng duyá»‡t cuá»™c há»p");
        #endregion

        #region Object : VIEW | ADD | DELETE | EDIT
        public static Permission OThoiGianLamViec = new Permission("OThoiGianLamViec", "Thá»i gian lÃ m viá»‡c");

        public static Permission ONhatKyLamViec = new Permission("ONhatKyLamViec", "Nháº­t kÃ½ lÃ m viá»‡c");
        public static Permission FQuanTriNhatKyLamViec = new Permission("FQuanTriNhatKyLamViec", "");
        public static Permission FBienTapNhatKyLamViec = new Permission("FBienTapNhatKyLamViec", "");


        public static Permission OCongViec = new Permission("OCongViec", "CÃ´ng viá»‡c");
        public static Permission FQuanTriCongViec = new Permission("FQuanTriCongViec", "");
        public static Permission FBienTapCongViec = new Permission("FBienTapCongViec", "");

        public static Permission OYeuCauHoTro = new Permission("OYeuCauHoTro", "YÃªu cáº§u há»— trá»£");
        public static Permission FQuanTriHoTro = new Permission("FQuanTriHoTro", "");
        
        public static Permission OHoSoUngVien = new Permission("OHoSoUngVien", "Há»“ sÆ¡ á»©ng viÃªn");
        public static Permission FQuanTriHoSoUngVien = new Permission("FQuanTriHoSoUngVien", "");


        public static Permission OPhongVan = new Permission("OPhongVan", "Phá»ng váº¥n");

        public static Permission OLichLamViec = new Permission("OLichLamViec", "Lá»‹ch lÃ m viá»‡c");
        public static Permission FLichLamViec = new Permission("FLichLamViec", "");

        public static Permission OLuong = new Permission("OLuong", "LÆ°Æ¡ng");
        public static Permission FQuanTriTienLuong = new Permission("FQuanTriTienLuong", "");

        public static Permission OBangLuong = new Permission("OBangLuong", "LÆ°Æ¡ng");
        public static Permission FQuanTriThangBangLuong = new Permission("FQuanTriThangBangLuong", "");
        public static Permission FBienTapThangBangLuong = new Permission("FBienTapThangBangLuong", "");


        public static Permission OThuChi = new Permission("OThuChi", "Thu - Chi - Táº¡m á»©ng");
        public static Permission OChamCongAuto = new Permission("OChamCongAuto", "Cháº¥m cÃ´ng tá»± Ä‘á»™ng");
        public static Permission OMeeting = new Permission("OMeeting", "Cuá»™c há»p");
        public static Permission OTrungTamDieuKhien = new Permission("OTrungTamDieuKhien", "Trung tÃ¢m Ä‘iá»u khiá»ƒn");
        public static Permission OTheoDoiNghiPhep = new Permission("OTheoDoiNghiPhep", "Theo dÃµi nghá»‰ phÃ©p");
        public static Permission OChamCong = new Permission("OChamCong", "Cháº¥m cÃ´ng");
        public static Permission OKhachHang = new Permission("OKhachHang", "KhÃ¡ch hÃ ng");
        public static Permission OHoTroInAn = new Permission("OHoTroInAn", "Há»— trá»£ in áº¥n");
        public static Permission OSystemParams = new Permission("OSystemParams", "Tham sá»‘ há»‡ thá»‘ng");


        public static Permission OHelpPrinter = new Permission("OHelpPrinter", "Há»— trá»£ in áº¥n");
        public static Permission FQuanTriPrinter = new Permission("FQuanTriPrinter", "");
        public static Permission FBienTapPrinter = new Permission("FBienTapPrinter", "");

        
        
        public static Permission OPhieuTamUng = new Permission("OPhieuTamUng", "Phiáº¿u táº¡m á»©ng");
        public static Permission FQuanTriTamUng = new Permission("FQuanTriTamUng", "");
        public static Permission FBienTapTamUng = new Permission("FBienTapTamUng", "");
        

        public static Permission OLichLamViecCaNhan = new Permission("OLichLamViecCaNhan", "Lá»‹ch lÃ m viá»‡c cÃ¡ nhÃ¢n");
        public static Permission FQuanTriLichLamViecCaNhan = new Permission("FQuanTriLichLamViecCaNhan", "");



        public static Permission OTinTuc = new Permission("OTinTuc", "");
        public static Permission FQuanTriTinTuc = new Permission("FQuanTriTinTuc", "");

        public static Permission ORSS = new Permission("ORSS", "Tin tá»©c RSS");
        public static Permission ODienDan = new Permission("ODienDan", "Diá»…n Ä‘Ã n");
        public static Permission ODanhBaDiaChi = new Permission("ODanhBaDiaChi", "Danh báº¡ Ä‘á»‹a chá»‰");
        public static Permission ODanhBaWebsite = new Permission("ODanhBaWebsite", "Danh báº¡ website");
        public static Permission OTaiLieu = new Permission("OTaiLieu", "TÃ i liá»‡u");
        public static Permission OHinhAnh = new Permission("OHinhAnh", "HÃ¬nh áº£nh");
        public static Permission OMauPhieu = new Permission("OMauPhieu", "Máº«u phiáº¿u");

        public static Permission OQuanLyVanDe = new Permission("OQuanLyVanDe", "");
        public static Permission FQuanTriVanDe = new Permission("FQuanTriVanDe", "");

        public static Permission ODuAn = new Permission("ODuAn", "Quáº£n lÃ½ dá»± Ã¡n");
        public static Permission FQuanTriDuAn = new Permission("FQuanTriDuAn", "");
        public static Permission FBienTapDuAn = new Permission("FBienTapDuAn", "");

        #endregion

        #region SYSTEM
        public static Permission FCapNhatThongTinDonVi = new Permission("FCapNhatThongTinDonVi", "Cáº­p nháº­t thÃ´ng tin Ä‘Æ¡n vá»‹");
        public static Permission FXemNhatKySuDung = new Permission("FXemNhatKySuDung", "Xem nháº­t kÃ½ sá»­ dá»¥ng");
        public static Permission FCauHinhThamSoHeThong = new Permission("FCauHinhThamSoHeThong", "Cáº¥u hÃ¬nh tham sá»‘ há»‡ thá»‘ng");
        public static Permission FThamSoBaoCao = new Permission("FThamSoBaoCao", "Tham sá»‘ bÃ¡o cÃ¡o");
        public static Permission FSaoluuphuchoi = new Permission("FSaoluuphuchoi", "Sao lÆ°u & Phá»¥c há»“i");
        public static Permission FWPhanQuyenNV_TN = new Permission("FWPhanQuyenNV_TN", "PhÃ¢n quyá»n nhÃ¢n viÃªn-tÃ i nguyÃªn");
        public static Permission FCauHinhNghiepVu = new Permission("FCauHinhNghiepVu", "Cáº¥u hÃ¬nh nghiá»‡p vá»¥");
        public static Permission FPhanQuyenDuLieu = new Permission("FPhanQuyenDuLieu", "Phần quyền dữ liệu");
        #endregion
    }
}
