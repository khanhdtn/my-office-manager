using System.Text;
using office;
using ProtocolVN.Plugin.TimeSheet;
using ProtocolVN.Framework.Win;
using PermissionOfResource;

namespace pl.office
{
    /// <summary>
    /// Menu cho phiên bản R1
    /// -
    /// </summary>
    public class AppR1Menu : ProtocolMenu
    {
        private static GenID G = new GenID();
        public AppR1Menu()
        {
            FrameworkParams.fwMenu = FWMenu.FW23x;
        }
        public override string CreateMenu()
        {
            return @""
                + ThongTin()
                + HoatDong()
                + CongViec()
                //+ KinhDoanh()
                //+ HanhChinh()
                + NghiepVu()
                + HoTro();
            //+ BaoCao();
        }
        public override string CreateHomePageMenu()
        {
            StringBuilder str = new StringBuilder();
            str.Append(base.CreateHomePageMenu());
            str.Append(MenuBuilder.CreateItem(typeof(ERPDesktop).FullName, "Sơ đồ chức năng", GlobalConst.MENU_HOMEPAGE_MENU_ITEM_ID, true, typeof(ERPDesktop).FullName, true, false, "", true, "", ""));
            return str.ToString();
        }
        public override string CreateSystemPageMenu()
        {
            StringBuilder str = new StringBuilder();
           // str.Append(frmConfigCode.MenuItem(GlobalConst.MENU_SYSTEM_MENU_ITEM_ID, true));
            //str.Append(frmTaiLieuPermission.MenuItem(GlobalConst.MENU_SYSTEM_MENU_ITEM_ID, true));
          //  MenuBuilder.CreateItem(str, "PQDL", "Phân quyền dữ liệu", GlobalConst.MENU_SYSTEM_MENU_ITEM_ID, true, "", true, true, "mnbPhieuPhanHoiKH.png", false, "", "", false);
            str.Append(frmPermissionDataQL.MenuItem(GlobalConst.MENU_SYSTEM_MENU_ITEM_ID, true));
            MenuBuilder.CreateItem(str, typeof(frmCategory).FullName, "Kho danh mục", GlobalConst.MENU_SYSTEM_MENU_ITEM_ID, true, typeof(frmCategory).FullName, true, true, "Forum.png", true, "", "", true);
            str.Append(frmAutoOpenForm.MenuItem(GlobalConst.MENU_SYSTEM_MENU_ITEM_ID, true));

            return str.ToString();
        }
        public override string CreateQuickAccessMenu()
        {
            return "";

        }
        public override string CreateDevelopPageMenu()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(frmSendClientQL.MenuItem(GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, false));
            builder.Append(frmBangChamCongBandedQL.MenuItem(GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true));


            MenuBuilder.CreateItem(builder, typeof(frmThuChiQL).FullName, "Thu chi", GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true, typeof(frmThuChiQL).FullName, true, true, "mnbThuChi.png", false, "", "", true);
            MenuBuilder.CreateItem(builder, typeof(frmPhieuThuChi).FullName, "Tạo mới", typeof(frmThuChiQL).FullName, true, typeof(frmPhieuThuChi).FullName, false, true, "add.png", false, "", "", true);
            builder.Append(MenuBuilder.CreateItem(typeof(frmKyKinhDoanh).FullName,
                "Kỳ kinh doanh",
                GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true,
                typeof(frmKyKinhDoanh).FullName,
                false, false, "HoaDonTaiChinh.png", false, "", ""));

            /*
             * builder.Append(frmPhieuThuChiMan.MenuItem(GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true));
            builder.Append(frmPhieuThu.MenuItem(typeof(frmPhieuThuChiMan).FullName, false));
            builder.Append(frmPhieuChi.MenuItem(typeof(frmPhieuThuChiMan).FullName, false));
            builder.Append(frmKhoaMoSoCongNo.MenuItem(GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, false));
             
            
            builder.Append(pl.office.form.frmViewForum.MenuItem(GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true));

            builder.Append(pl.office.ZTest.UnboundExpression.frmDemo.MenuItem(GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true));
            builder.Append(pl.office.ZTest.DemoControl.MenuItem(GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, false));

            builder.Append(MenuBuilder.CreateItem("BC1", "Thông tin ứng viên NC", GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true, HelpFURL.FURLReport(typeof(RPT_UNG_VIEN)), true, true, "mnbHSoUngVien.png", false, "", ""));
            builder.Append(MenuBuilder.CreateItem("BC2", "Bảng chấm công", GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true, HelpFURL.FURLReport(typeof(RPT_CHAM_CONG)), true, true, "pl-product.png", false, "", ""));
            MenuBuilder.CreateItem(builder, "BC3", "Công việc", GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true, "", true, true, "fwExplorer.png", false, "", "", true);
            builder.Append(MenuBuilder.CreateItem("BC3.1", "Thời gian làm việc", "BC3", true, HelpFURL.FURLReport(typeof(RPT_TIME_INOUT)), true, true, "country.gif", false, "", ""));
            builder.Append(MenuBuilder.CreateItem("BC3.2", "Nhật ký công việc", "BC3", true, HelpFURL.FURLReport(typeof(RPT_NHAT_KY_CONG_VIEC)), true, true, "ATinhTrangBaoHanh.png", false, "", ""));
            *
            */

            //KINH DOANH
            //MenuBuilder.CreateItem(builder, "SU_KIEN", "Sự kiện", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            //MenuBuilder.CreateItem(builder, "SU_KIEN_ADD", "Tạo mới", "SU_KIEN", true, "Form", false, false, "add.png", false, "", "", true);

            //MenuBuilder.CreateItem(builder, "LICH_SU", "Lịch sử làm việc", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            //MenuBuilder.CreateItem(builder, "LICH_SU_ADD", "Tạo mới", "LICH_SU", true, "Form", false, false, "add.png", false, "", "", true);

            //MenuBuilder.CreateItem(builder, "GUI_MAIL_KH", "Gửi mail khách hàng", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            //MenuBuilder.CreateItem(builder, "GUI_MAIL_KH_ADD", "Tạo mới", "GUI_MAIL_KH", true, "Form", false, false, "add.png", false, "", "", true);

            //MenuBuilder.CreateItem(builder, "HOP_DONG", "Hợp đồng ", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            //builder.Append(frmHopDong.MenuItem("HOP_DONG", true));

            //MenuBuilder.CreateItem(builder, "CO_HOI_KD", "Cơ hội kinh doanh", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            //MenuBuilder.CreateItem(builder, "CO_HOI_KD_ADD", "Tạo mới", "CO_HOI_KD", true, "Form", false, false, "add.png", false, "", "", true);

            //MenuBuilder.CreateItem(builder, "BAO_GIA", "Báo giá", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            //MenuBuilder.CreateItem(builder, "BAO_GIA_ADD", "Tạo mới", "BAO_GIA", true, "Form", false, false, "add.png", false, "", "", true);
            ////HO TRO
            //MenuBuilder.CreateItem(builder, "PHAN_QUYEN_NV_TL", "Phân quyền NV - TL", G.CurrentGroup(), true, ProtocolVN.DanhMuc.PL.FURL(typeof(PhanQuyenTaiNguyenMethodExec).FullName, "ShowPhanQuyenNhanVienTaiLieu"), true, false, "mnbCHinhNghiepVu.png", false, "", "", false);

            return builder.ToString();
        }
        public override string CreateHelpPageMenu()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(frmLiveSupport.MenuItem(GlobalConst.MENU_HELP_MENU_ITEM_ID, true));
            return builder.ToString();
        }

        #region MenuItems
        private string ThongTin()
        {

            StringBuilder str = new StringBuilder("");
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Thông tin", ""));
            MenuBuilder.CreateItem(str, typeof(frmTinTucQL).FullName, "Tin tức", G.CurrentGroup(), true, typeof(frmTinTucQL).FullName, true, false, "newspaper.gif", true, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmNewsPaper).FullName, "Tạo mới", typeof(frmTinTucQL).FullName, true, typeof(frmNewsPaper).FullName, false, true, "add.png", false, "", "", true);
            str.Append(frmRSS.MenuItem(G.CurrentGroup(), false));
            MenuBuilder.CreateItem(str, typeof(frmForumQL).FullName, "Diễn đàn thảo luận", G.CurrentGroup(), true, typeof(frmForumQL).FullName, true, false, "Forum.png", true, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmBaiViet).FullName, "Tạo mới", typeof(frmForumQL).FullName, true, typeof(frmBaiViet).FullName, false, true, "add.png", false, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmBaiVietEtx).FullName, "Tạo mới", typeof(frmForumQL).FullName, true, typeof(frmBaiVietEtx).FullName, false, true, "add.png", false, "", "", true);

            str.Append(frmDanhBaExtQL.MenuItem(G.CurrentGroup(), true));
            MenuBuilder.CreateItem(str, typeof(frmWebsiteQL).FullName, "Danh bạ Website", G.CurrentGroup(), true, typeof(frmWebsiteQL).FullName, true, false, "Web.png", true, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmThemMoi).FullName, "Tạo mới", typeof(frmWebsiteQL).FullName, true, typeof(frmThemMoi).FullName, false, true, "add.png", false, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmDocumentQL).FullName, "Quản lý tài liệu", G.CurrentGroup(), true, typeof(frmDocumentQL).FullName, true, true, "Document.png", true, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmAddFile).FullName, "Tạo mới", typeof(frmDocumentQL).FullName, true, typeof(frmAddFile).FullName, false, true, "add.png", false, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmImageGallery).FullName, "Quản lý ảnh", G.CurrentGroup(), true, typeof(frmImageGallery).FullName, true, false, "Picture.png", true, "", "", true);
            str.Append(frmBroadCast.MenuItem(G.CurrentGroup(), true));

            return str.ToString();
        }
        private string HoatDong()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Hoạt động", ""));
            MenuBuilder.CreateItem(str, typeof(frmTimeInOut).FullName, "Chấm công", G.CurrentGroup(), true, typeof(frmTimeInOut).FullName, false, false, "add.png", false, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmNghiPhepQL).FullName, "Theo dõi nghỉ phép", G.CurrentGroup(), true, typeof(frmNghiPhepQL).FullName, true, false, "ATinhTrangBaoHanh.png", true, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmNghiPhep).FullName, "Tạo mới", typeof(frmNghiPhepQL).FullName, true, typeof(frmNghiPhep).FullName, false, false, "add.png", false, "", "", true);
            str.Append(frmPhieuXacNhanLamViecQL.MenuItem(G.CurrentGroup(), false));
            str.Append(frmPhieuXNLamViec.MenuItem(typeof(frmPhieuXacNhanLamViecQL).FullName, false));
            str.Append(frmPhieuRaVaoCtyQL.MenuItem(G.CurrentGroup(), false));
            str.Append(frmPhieuRaVaoCty.MenuItem(typeof(frmPhieuRaVaoCtyQL).FullName, false));

            MenuBuilder.CreateItem(str, typeof(frmTimeInOutQL).FullName, "Thời gian làm việc", G.CurrentGroup(), true, typeof(frmTimeInOutQL).FullName, true, false, "country.gif", true, "", "", true);
            str.Append(frmChamCongAutoQL.MenuItem(G.CurrentGroup(), true));

            str.Append(frmBugProductQL.MenuItem(G.CurrentGroup(), true));
            str.Append(frmBugProduct.MenuItem(typeof(frmBugProductQL).FullName, false));
            

            return str.ToString();
        }
        private string CongViec()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Công việc", ""));

            MenuBuilder.CreateItem(str, typeof(frmTimeRecordQL).FullName, "Nhật ký làm việc", G.CurrentGroup(), true, typeof(frmTimeRecordQL).FullName, true, false, "ATinhTrangBaoHanh.png", true, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmTimeTable).FullName, "Tạo mới", typeof(frmTimeRecordQL).FullName, true, typeof(frmTimeTable).FullName, false, true, "add.png", false, "", "", true);



            str.Append(frmLichlamviec.MenuItem(G.CurrentGroup(), false));
            str.Append(frmQLCongviecQL1N.MenuItem(G.CurrentGroup(), true));
            MenuBuilder.CreateItem(str, typeof(Congviec).FullName, "Tạo mới", typeof(frmQLCongviecQL1N).FullName, true, typeof(Congviec).FullName, false, false, "add.png", false, "", "", true);

            str.Append(frmMeetingQL.MenuItem(G.CurrentGroup(), true));
            MenuBuilder.CreateItem(str, typeof(frmMeeting).FullName, "Tạo mới", typeof(frmMeetingQL).FullName, true, typeof(frmMeeting).FullName, false, true, "add.png", false, "", "", true);

            str.Append(frmTiepNhanThongTinVerticalQL.MenuItem(G.CurrentGroup(), true));
            str.Append(frmTiepNhanThongTin.MenuItem(typeof(frmTiepNhanThongTinVerticalQL).FullName, false));

            return str.ToString();
        }
        private string KinhDoanh()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Kinh doanh", ""));
            //     MenuBuilder.CreateItem(builder, typeof(frmKhachHangQL1N).FullName, "Quan hệ khách hàng", G.CurrentGroup(), true, typeof(frmKhachHangQL1N).FullName, true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            MenuBuilder.CreateItem(builder, typeof(frmKhachHangQL).FullName, "Quan hệ khách hàng", G.CurrentGroup(), true, typeof(frmKhachHangQL).FullName, true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            builder.Append(frmTaoKhachHangMoi.MenuItem(typeof(frmKhachHangQL).FullName, false));
            return builder.ToString();
        }
        private string HanhChinh()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Hành chính", ""));
            MenuBuilder.CreateItem(str, typeof(frmHoSoQL).FullName, "Hồ sơ ứng viên", G.CurrentGroup(), true, typeof(frmHoSoQL).FullName, true, false, "mnbHSoUngVien.png", false, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmHoSoUngVien).FullName, "Tạo mới", typeof(frmHoSoQL).FullName, true, typeof(frmHoSoUngVien).FullName, false, false, "add.png", false, "", "", true);
            str.Append(frmPhongVanQL.MenuItem(G.CurrentGroup(), false));
            str.Append(frmLichLamViecQL.MenuItem(G.CurrentGroup(), true));

            str.Append(frmTiepNhanThongTinVerticalQL.MenuItem(G.CurrentGroup(), true));
            str.Append(frmTiepNhanThongTin.MenuItem(typeof(frmTiepNhanThongTinVerticalQL).FullName, false));
            return str.ToString();
        }
        private string NghiepVu()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Nghiệp vụ", ""));
            //
            str.Append(frmDuAnQL.MenuItem(G.CurrentGroup(), false));
            str.Append(frmDuAn.MenuItem(typeof(frmDuAnQL).FullName, false));


            //
            //builder.Append(MenuBuilder.CreateItem("BC1", "Thông tin ứng viên NC", GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true, HelpFURL.FURLReport(typeof(RPT_UNG_VIEN)), true, true, "mnbHSoUngVien.png", false, "", ""));
            //builder.Append(MenuBuilder.CreateItem("BC2", "Bảng chấm công", GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true, HelpFURL.FURLReport(typeof(RPT_CHAM_CONG)), true, true, "pl-product.png", false, "", ""));
            //MenuBuilder.CreateItem(builder, "BC3", "Công việc", GlobalConst.MENU_DEVELOP_MENU_ITEM_ID, true, "", true, true, "fwExplorer.png", false, "", "", true);
            //builder.Append(MenuBuilder.CreateItem("BC3.1", "Thời gian làm việc", "BC3", true, HelpFURL.FURLReport(typeof(RPT_TIME_INOUT)), true, true, "country.gif", false, "", ""));
            //builder.Append(MenuBuilder.CreateItem("BC3.2", "Nhật ký công việc", "BC3", true, HelpFURL.FURLReport(typeof(RPT_NHAT_KY_CONG_VIEC)), true, true, "ATinhTrangBaoHanh.png", false, "", ""));




            MenuBuilder.CreateItem(str, typeof(frmKhachHangQL).FullName, "Quan hệ khách hàng", G.CurrentGroup(), true, typeof(frmKhachHangQL).FullName, true, true, "mnbChiTietNoKhachHang.png", false, "", "", true);
            str.Append(frmTaoKhachHangMoi.MenuItem(typeof(frmKhachHangQL).FullName, false));
            //

            MenuBuilder.CreateItem(str, "QTNS", "Quản trị nhân sự", G.CurrentGroup(), true, "", true, true, "mnbChiTietNoKhachHang.png", false, "", "", true);

            str.Append(MenuBuilder.CreateItem("QTNS.1", "Hồ sơ ứng viên", "QTNS", true, typeof(frmHoSoQL).FullName, true, true, "mnbHSoUngVien.png", false, "", ""));
            str.Append(MenuBuilder.CreateItem("QTNS.2", "Phỏng vấn", "QTNS", true, typeof(frmPhongVanQL).FullName, true, true, "mnbPhongVan.png", false, "", ""));

            str.Append(frmLichLamViecQL.MenuItem(G.CurrentGroup(), false));


            //

            MenuBuilder.CreateItem(str, "L", "Lương", G.CurrentGroup(), true, "", true, true, "mnbDieuChinhLuong.png", false, "", "", true);
            str.Append(MenuBuilder.CreateItem("L.1", "Tiền lương", "L", true, typeof(frmLuongQL).FullName, true, true, "mnbTinhLuong.gif", false, "", ""));
            str.Append(MenuBuilder.CreateItem("L.2", "Thang bảng lương", "L", true, typeof(frmThangBangLuongQL).FullName, true, true, "mnbDieuChinhLuong.png", false, "", ""));

            //MenuBuilder.CreateItem(str, typeof(frmThangBangLuongQL).FullName, "Thang bảng lương", G.CurrentGroup(), true, typeof(frmThangBangLuongQL).FullName, true, true, "mnbDieuChinhLuong.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, typeof(frmDieuChinhLuong).FullName, "Tạo mới", typeof(frmThangBangLuongQL).FullName, true, typeof(frmDieuChinhLuong).FullName, false, false, "add.png", false, "", "", true);

            str.Append(frmPhieuTamUngQL.MenuItem(G.CurrentGroup(), false));
            str.Append(frmPhieuTamUng.MenuItem(typeof(frmPhieuTamUngQL).FullName, false));


            return str.ToString();
        }
        private string HoTro()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Hỗ trợ", ""));

            MenuBuilder.CreateItem(str, typeof(frmYeuCauHoTroQL).FullName, "Yêu cầu hỗ trợ", G.CurrentGroup(), true, typeof(frmYeuCauHoTroQL).FullName, true, false, "mnbCHinhHeThong.png", false, "", "", true);
            str.Append(frmHotro.MenuItem(typeof(frmYeuCauHoTroQL).FullName, true));

            MenuBuilder.CreateItem(str, typeof(frmHoTroInAnQL).FullName, "Hỗ trợ in ấn", G.CurrentGroup(), true, typeof(frmHoTroInAnQL).FullName, true, true, "fwPrint.png", false, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmYeuCauInAn).FullName, "Tạo mới", typeof(frmHoTroInAnQL).FullName, true, typeof(frmYeuCauInAn).FullName, false, true, "add.png", false, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmHoTroFaxQL).FullName, "Hỗ trợ fax", G.CurrentGroup(), true, typeof(frmHoTroFaxQL).FullName, true, false, "Fax.png", false, "", "", true);
            MenuBuilder.CreateItem(str, typeof(frmYeuCauFax).FullName, "Tạo mới", typeof(frmHoTroFaxQL).FullName, true, typeof(frmYeuCauFax).FullName, false, true, "add.png", false, "", "", true);
            str.Append(frmHomThuGopYQL.MenuItem(G.CurrentGroup(), true));
            str.Append(frmHomThuGopY.MenuItem(typeof(frmHomThuGopYQL).FullName, false));
            str.Append(frmLiveSupportCustomize.MenuItem(G.CurrentGroup(), true));

            
            return str.ToString();
        }
        //private string BaoCao() {
        //StringBuilder str = new StringBuilder();
        //str.Append(MenuBuilder.CreateRootItem("4.0", "Báo cáo", ""));
        //str.Append(MenuBuilder.CreateItem("4.1", "Thông tin ứng viên NC", "4.0", true, HelpFURL.FURLReport(typeof(RPT_UNG_VIEN)), true, false, "mnbHSoUngVien.png", false, "", ""));
        //str.Append(MenuBuilder.CreateItem("4.2", "Bảng chấm công", "4.0", true, HelpFURL.FURLReport(typeof(RPT_CHAM_CONG)), true, true, "pl-product.png", false, "", ""));
        //MenuBuilder.CreateItem(str, "4.3", "Công việc", "4.0", true, "", true, true, "fwExplorer.png", false, "", "", true);
        //str.Append(MenuBuilder.CreateItem("4.3.1", "Thời gian làm việc", "4.3", true, HelpFURL.FURLReport(typeof(RPT_TIME_INOUT)), true, true, "country.gif", false, "", ""));
        //str.Append(MenuBuilder.CreateItem("4.3.2", "Nhật ký công việc", "4.3", true, HelpFURL.FURLReport(typeof(RPT_NHAT_KY_CONG_VIEC)), true, true, "ATinhTrangBaoHanh.png", false, "", ""));
        //return str.ToString();
        //}
        #endregion
    }

    /// <summary>
    /// Menu cho phiên bản R2 với các tính năng thêm mới & mở rộng 
    /// -
    /// </summary>
    public class AppR2Menu : ProtocolMenu
    {
        private static GenID G = new GenID();
        public AppR2Menu()
        {
            FrameworkParams.fwMenu = FWMenu.FW22x;
        }
        public override string CreateMenu()
        {
            return @""
                + ThongTin()
                + CongViec()
                + KinhDoanh()
                + HanhChinh()
                + TaiChinh()
                + HoTro()
                + BaoCao()
                + "";
        }

        public override string CreateToolPageMenu()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.CreateToolPageMenu());
            return builder.ToString();
        }

        public override string CreateHomePageMenu()
        {
            StringBuilder str = new StringBuilder();
            str.Append(base.CreateHomePageMenu());
            str.Append(MenuBuilder.CreateItem(typeof(ERPDesktop).FullName, "Sơ đồ chức năng", GlobalConst.MENU_HOMEPAGE_MENU_ITEM_ID, true, typeof(ERPDesktop).FullName, true, true, "", true, "", ""));
            return str.ToString();
        }
        public override string CreateSystemPageMenu()
        {
            StringBuilder str = new StringBuilder();
           str.Append(frmConfigCode.MenuItem(GlobalConst.MENU_SYSTEM_MENU_ITEM_ID, true));
            return str.ToString();
        }
        #region MeuuItem
        private string ThongTin()
        {
            StringBuilder str = new StringBuilder("");
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Thông tin", ""));

            return str.ToString();
        }
        private string CongViec()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Công việc", ""));
            return str.ToString();
        }
        private string KinhDoanh()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Kinh doanh", ""));

            MenuBuilder.CreateItem(builder, "SU_KIEN", "Sự kiện", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            MenuBuilder.CreateItem(builder, "SU_KIEN_ADD", "Tạo mới", "SU_KIEN", true, "Form", false, false, "add.png", false, "", "", true);

            MenuBuilder.CreateItem(builder, "LICH_SU", "Lịch sử làm việc", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            MenuBuilder.CreateItem(builder, "LICH_SU_ADD", "Tạo mới", "LICH_SU", true, "Form", false, false, "add.png", false, "", "", true);

            MenuBuilder.CreateItem(builder, "GUI_MAIL_KH", "Gửi mail khách hàng", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            MenuBuilder.CreateItem(builder, "GUI_MAIL_KH_ADD", "Tạo mới", "GUI_MAIL_KH", true, "Form", false, false, "add.png", false, "", "", true);

            MenuBuilder.CreateItem(builder, "HOP_DONG", "Hợp đồng ", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            builder.Append(frmHopDong.MenuItem("HOP_DONG", true));

            MenuBuilder.CreateItem(builder, "CO_HOI_KD", "Cơ hội kinh doanh", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            MenuBuilder.CreateItem(builder, "CO_HOI_KD_ADD", "Tạo mới", "CO_HOI_KD", true, "Form", false, false, "add.png", false, "", "", true);

            MenuBuilder.CreateItem(builder, "BAO_GIA", "Báo giá", G.CurrentGroup(), true, "Form", true, false, "mnbChiTietNoKhachHang.png", false, "", "", true);
            MenuBuilder.CreateItem(builder, "BAO_GIA_ADD", "Tạo mới", "BAO_GIA", true, "Form", false, false, "add.png", false, "", "", true);
            return builder.ToString();
        }
        private string HanhChinh()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Hành chính", ""));
            return str.ToString();
        }
        private string TaiChinh()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Tài chính", ""));

            return str.ToString();
        }
        private string HoTro()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem(G.NewGroup(), "Hỗ trợ", ""));

            str.Append(frmHomThuGopYQL.MenuItem(G.CurrentGroup(), false));
            str.Append(frmHomThuGopY.MenuItem(typeof(frmHomThuGopYQL).FullName, false));
            return str.ToString();
        }
        private string BaoCao()
        {
            StringBuilder str = new StringBuilder();
            str.Append(MenuBuilder.CreateRootItem("4.0", "Báo cáo", ""));
            return str.ToString();
        }
        #endregion
    }
}
