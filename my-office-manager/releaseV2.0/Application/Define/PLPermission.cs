using System;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using office;
using ProtocolVN.Plugin.TimeSheet;
using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Win;

using ProtocolVN.App.Office;
using ProtocolVN.Plugin.NoteBook;
using ProtocolVN.Plugin.ImpExp;
using PermissionOfResource;

namespace pl.office
{   
    public class PLPermission : AppPermission,IPermission
    {
        public PLPermission() : base()
        {
            #region Phân quyền của FW
            
            #endregion

            #region Phân quyền của Ứng dụng
            #region Phân quyền Danh mục
            DMVanDeGopY.isPermission = true;
            DMNghiepVu.isPermission = true;
            DMNhomKhachHangX.isPermission = true;
            #endregion

            #region Phân quyền đối tượng
                    
            #endregion

            #region Phân quyền báo biểu
            #endregion

            #region Phân quyền Chức năng
            #endregion
            #endregion
        }

        #region Phân quyền chức năng
        /// <summary>Step 1: Định nghĩa danh sách các màn hình mà người nào cũng có thể thao tác trên nó.        
        /// </summary>
        /// <returns></returns>
        public List<string> getPublicForm()
        {
            List<string> publics = new List<string>();
            publics.Add(typeof(frmDesktopNewsPaper).FullName);
            publics.Add(typeof(frmSendClient).FullName);
            publics.Add(typeof(frmAddressBook).FullName);
            publics.Add(typeof(frmStickiesMain).FullName);
            publics.Add(typeof(frmImport).FullName);
            publics.Add(typeof(ERPDesktop).FullName);
            publics.Add(typeof(frmBroadCast).FullName);
            publics.Add(typeof(frmLiveSupport).FullName);
            publics.Add(typeof(frmAutoOpenForm).FullName);
            //publics.Add(typeof(frmNote).FullName);


            return publics;
        }

        /// <summary>Step 2: Định nghĩa danh sách các FEATURE có trong ứng dụng.
        /// Chú ý tất cả các thể hiện của FeaturePerm trong 1 ứng dụng không cho phép trùng tên FEATURE_NAME
        /// Danh sách các FEATURE này phải thêm trong DB (FEATURE_CAT table).
        /// </summary>
        #region FEATURE_CAT
        #region Object : VIEW | ADD | DELETE | EDIT (Đã di chuyển sang App)
        public static Permission OPhieuRaVaoCty = new Permission("OPhieuRaVaoCty", "");
        public static Permission OPhieuXNLamViec = new Permission("OPhieuXNLamViec", "");

        public static Permission OFax = new Permission("OFax", "");
        public static Permission FQuanTriFax = new Permission("FQuanTriFax", "");
        public static Permission FBienTapFax = new Permission("FBienTapFax", "");


        public static Permission OHomThuGopY = new Permission("OHomThuGopY", "");
        public static Permission FQuanTriHomThuGopY = new Permission("FQuanTriHomThuGopY", "");


        public static Permission OTiepNhanThongTin = new Permission("OTiepNhanThongTin", "");
        public static Permission FQuanTriTiepNhanThongTin = new Permission("FQuanTriTiepNhanThongTin", "");
        #endregion

        //Function : VIEW  (Đã di chuyển vào AppPermission)   
           
        public static Permission FMoKhoaSo = new Permission("FMoKhoaSo", "");
        public static Permission FKyKinhDoanh = new Permission("FKyKinhDoanh", "");
        public static Permission FDuyetGopY = new Permission("FDuyetGopY", "");
        public static Permission FXemNguoiGopY = new Permission("FXemNguoiGopY", "");

        #endregion

        #region Step 3: Xác định dùng của Type nào
        public static String permissionForm = typeof(frmTreeUserManExt).FullName;
        #endregion

        /// <summary>Step 4: Định nghĩa ánh xạ MENU và FEATURE
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> getFormFeatureMap()
        {
            Dictionary<string, string> mitemPermissionMap =
                new Dictionary<string, string>(FWPermission.GetFormFeatureMap());

            #region Thông tin
            mitemPermissionMap.Add(typeof(frmTinTucQL).FullName, OTinTuc.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmNewsPaper).FullName, OTinTuc.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmRSS).FullName, ORSS.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmForumQL).FullName, ODienDan.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmBaiVietEtx).FullName, ODienDan.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmDanhBaExtQL).FullName, ODanhBaDiaChi.GetPermissionStr(PermissionType.VIEW));
            
            mitemPermissionMap.Add(typeof(frmWebsiteQL).FullName, ODanhBaWebsite.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmThemMoi).FullName, ODanhBaWebsite.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmDocumentQL).FullName, OTaiLieu.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmAddFile).FullName, ODanhBaWebsite.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmImageGallery).FullName, OHinhAnh.GetPermissionStr(PermissionType.VIEW));
            #endregion

            #region Công việc
            mitemPermissionMap.Add(typeof(frmTimeInOutQL).FullName, OThoiGianLamViec.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmTimeInOut).FullName, OThoiGianLamViec.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmNghiPhepQL).FullName, OTheoDoiNghiPhep.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmNghiPhep).FullName, OTheoDoiNghiPhep.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmTimeRecordQL).FullName, ONhatKyLamViec.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmTimeTable).FullName, ONhatKyLamViec.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmYeuCauHoTroQL).FullName, OYeuCauHoTro.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmHotro).FullName, OYeuCauHoTro.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmQLCongviecQL1N).FullName, OCongViec.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(Congviec).FullName, OCongViec.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmChamCongAutoQL).FullName, OChamCong.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmChamCongQL).FullName, OChamCong.GetPermissionStr(PermissionType.VIEW));

            //Dev
            mitemPermissionMap.Add(typeof(frmBugProductQL).FullName, OQuanLyVanDe.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmBugProduct).FullName, OQuanLyVanDe.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmDuAnQL).FullName, ODuAn.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmDuAn).FullName, ODuAn.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmLichlamviec).FullName, OLichLamViecCaNhan.GetPermissionStr(PermissionType.VIEW));

            #endregion

            #region Kinh doanh
            mitemPermissionMap.Add(typeof(frmKhachHangQL).FullName, OKhachHang.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmTaoKhachHangMoi).FullName, OKhachHang.GetPermissionStr(PermissionType.ADD_EDIT));
            #endregion

            #region Hành chính
            mitemPermissionMap.Add(typeof(frmHoSoQL).FullName, OHoSoUngVien.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmHoSoUngVien).FullName, OHoSoUngVien.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmLichLamViecQL).FullName, OLichLamViec.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmPhongVanQL).FullName, OPhongVan.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmMeeting).FullName, OMeeting.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmMeetingQL).FullName, OMeeting.GetPermissionStr(PermissionType.VIEW));

            mitemPermissionMap.Add(typeof(frmTiepNhanThongTin).FullName, OTiepNhanThongTin.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmTiepNhanThongTinVerticalQL).FullName, OTiepNhanThongTin.GetPermissionStr(PermissionType.VIEW));

            #endregion

            #region Tài chính
            mitemPermissionMap.Add(typeof(frmThangBangLuongQL).FullName, OBangLuong.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmDieuChinhLuong).FullName, OBangLuong.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmLuongQL).FullName, OLuong.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmThuChiQL).FullName, OThuChi.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmPhieuThuChi).FullName, OThuChi.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmPhieuTamUngQL).FullName, OPhieuTamUng.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmPhieuTamUng).FullName, OPhieuTamUng.GetPermissionStr(PermissionType.ADD_EDIT));
            
            mitemPermissionMap.Add(typeof(frmKhoaMoSoCongNo).FullName, FMoKhoaSo.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmPhieuThuChiEdit).FullName, OThuChi.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmPhieuThuChiMan).FullName, OThuChi.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmKyKinhDoanh).FullName, FKyKinhDoanh.GetPermissionStr(PermissionType.VIEW));

            mitemPermissionMap.Add(typeof(frmPhieuThu).FullName, OThuChi.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmPhieuChi).FullName, OThuChi.GetPermissionStr(PermissionType.ADD_EDIT));
            #endregion

            #region Hỗ trợ
            mitemPermissionMap.Add(typeof(frmYeuCauInAn).FullName, OHelpPrinter.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmHoTroInAnQL).FullName, OHelpPrinter.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmHomThuGopY).FullName, OHomThuGopY.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmHomThuGopYQL).FullName, OHomThuGopY.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmYeuCauFax).FullName, OFax.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmHoTroFaxQL).FullName, OFax.GetPermissionStr(PermissionType.VIEW));
            #endregion

            #region Báo cáo

            #endregion

            #region Hệ thống
            //mitemPermissionMap.Add(typeof(frmAppReportParams).FullName, OSystemParams.GetPermissionStr(PermissionType.EDIT));
            //mitemPermissionMap.Add(typeof(frmConfigCode).FullName, OMauPhieu.GetPermissionStr(PermissionType.EDIT));
            mitemPermissionMap.Add(typeof(frmCompanyInfo).FullName, FCapNhatThongTinDonVi.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmUserLog).FullName, FXemNhatKySuDung.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmConfigServer).FullName, FCauHinhThamSoHeThong.GetPermissionStr(PermissionType.VIEW));
            //mitemPermissionMap.Add(typeof(frmTaiLieuPermission).FullName, FWPhanQuyenNV_TN.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(AppMethodExec).FullName, FCauHinhNghiepVu.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmPermissionDataQL).FullName, FPhanQuyenDuLieu.GetPermissionStr(PermissionType.VIEW));
            #endregion

            #region Nghiep vu
            
            #endregion

            #region R2
            //Công việc
            mitemPermissionMap.Add(typeof(frmPhieuRaVaoCtyQL).FullName, OPhieuRaVaoCty.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmPhieuRaVaoCty).FullName, OPhieuRaVaoCty.GetPermissionStr(PermissionType.ADD_EDIT));
            mitemPermissionMap.Add(typeof(frmPhieuXacNhanLamViecQL).FullName, OPhieuXNLamViec.GetPermissionStr(PermissionType.VIEW));
            mitemPermissionMap.Add(typeof(frmPhieuXNLamViec).FullName, OPhieuXNLamViec.GetPermissionStr(PermissionType.ADD_EDIT));


            #endregion
            return mitemPermissionMap;
        }

        public List<object> GetObjectItems(XtraForm form)
        {
            List<Object> items = new List<Object>();
            FWPermission.GetObjectItems(form, items);

            #region OBJECT Ho So Nhan Vien
            if (form is frmHoSoQL)
            {
                frmHoSoQL that = (frmHoSoQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OHoSoUngVien.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OHoSoUngVien.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OHoSoUngVien.GetPermissionItem(PermissionType.EDIT));

                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriHoSoUngVien.GetPermissionItem(PermissionType.VIEW_HIDE));
            }

            if (form is frmHoSoUngVien)
            {
                frmHoSoUngVien that = (frmHoSoUngVien)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    OHoSoUngVien.GetPermissionItem(PermissionType.ADD_EDIT));                                    
            }

            #endregion

            #region OBJECT Phỏng vấn
            if (form is frmPhongVanQL)
            {
                frmPhongVanQL that = (frmPhongVanQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OPhongVan.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OPhongVan.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OPhongVan.GetPermissionItem(PermissionType.EDIT));
            } 
            #endregion

            #region OBJECT Thoi Gian Lam Viec
            if (form is frmTimeInOutQL)
            {   
                frmTimeInOutQL that = (frmTimeInOutQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OThoiGianLamViec.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OThoiGianLamViec.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OThoiGianLamViec.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemK_Duyet,
                    FQuanTriThoiGianLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDuyet,
                    FQuanTriThoiGianLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FQuanTriThoiGianLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            #endregion

            #region OBJECT Nhat ky lam viec
            if (form is frmTimeRecordQL)
            {                
                frmTimeRecordQL that = (frmTimeRecordQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    ONhatKyLamViec.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barBtnXem,
                    ONhatKyLamViec.GetPermissionItem(PermissionType.VIEW));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barBtnCapNhat,
                    ONhatKyLamViec.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barBtnXoa,
                    ONhatKyLamViec.GetPermissionItem(PermissionType.DELETE));

                //
                string username = FrameworkParams.currentUser.username;
                Feature fQuanTri = Permission.loadFeature(FQuanTriNhatKyLamViec.id, FQuanTriNhatKyLamViec.featureName, username);
                if (fQuanTri.isRead == false)
                {
                    Feature fBienTap = Permission.loadFeature(FBienTapNhatKyLamViec.id, FBienTapNhatKyLamViec.featureName, username);
                    that.NhanVien.Visible = fBienTap.isRead != false;
                }
                else that.NhanVien.Visible = true;
            }

            if (form is frmTimeTable)
            {
                frmTimeTable that = (frmTimeTable)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    ONhatKyLamViec.GetPermissionItem(PermissionType.ADD_EDIT));

            }
            #endregion

            #region OBJECT Lich Lam Viec Ca Nhan
            if (form is frmLichlamviec) {
                frmLichlamviec that = (frmLichlamviec)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FQuanTriLichLamViecCaNhan.GetPermissionItem(PermissionType.VIEW_HIDE));

            }
            #endregion

            #region OBJECT Cong Viec
            if (form is frmQLCongviecQL1N)
            {
                frmQLCongviecQL1N that = (frmQLCongviecQL1N)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OCongViec.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OCongViec.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OCongViec.GetPermissionItem(PermissionType.EDIT));

                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriCongViec.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FBienTapCongViec.GetPermissionItem(PermissionType.VIEW_HIDE));
            }

            if (form is Congviec)
            {
                Congviec that = (Congviec)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.sbtnLuu,
                    OCongViec.GetPermissionItem(PermissionType.ADD_EDIT));
                //
                string username = FrameworkParams.currentUser.username;
                Feature fQuanTri = Permission.loadFeature(FQuanTriCongViec.id, FQuanTriCongViec.featureName, username);
                if (fQuanTri.isRead == false)
                {
                    Feature fBienTap = Permission.loadFeature(FBienTapCongViec.id, FBienTapCongViec.featureName, username);
                    that.cmbNguoiGiao.Visible = fBienTap.isRead != false;
                }
                else that.cmbNguoiGiao.Visible = true;
            }
            if (form is frmCapNhatTienDo)
            {
                frmCapNhatTienDo that = (frmCapNhatTienDo)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.buttonLuu,
                    OCongViec.GetPermissionItem(PermissionType.ADD_EDIT));
            }
            //Meeting
            if (form is frmMeetingQL) {
                frmMeetingQL that = (frmMeetingQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items,that.barButtonItemAdd
                    ,OMeeting.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate
                    , OMeeting.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete
                    , OMeeting.GetPermissionItem(PermissionType.DELETE));
                //ApplyPermissionAction.ApplyPermissionObject(items,that.barButtonItemDuyet
                //    ,FDuyetCuocHop.GetPermissionItem(PermissionType.VIEW_HIDE));
                //ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemK_Duyet
                //    , FDuyetCuocHop.GetPermissionItem(PermissionType.VIEW_HIDE));
            }

            if (form is frmMeeting) {
                frmMeeting that = (frmMeeting)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnLuu
                    , OMeeting.GetPermissionItem(PermissionType.ADD_EDIT));

            }
            #endregion

            #region Lich Lam Viec
            if (form is frmLichLamViecQL)
            {
                frmLichLamViecQL that = (frmLichLamViecQL)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemNoCommit,
                    FLichLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    FLichLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FLichLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
            }

            if (form is frmThemLichTuan)
            {
                frmThemLichTuan that = (frmThemLichTuan)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.btn_thuchien,
                    OLichLamViec.GetPermissionItem(PermissionType.ADD));
            }
            #endregion

            #region OBJECT Luong
            if (form is frmLuongQL)
            {
                frmLuongQL that = (frmLuongQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                   FQuanTriTienLuong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    FQuanTriTienLuong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    FQuanTriTienLuong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriTienLuong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemChot,
                   FQuanTriTienLuong.GetPermissionItem(PermissionType.VIEW_HIDE));
            }

            if (form is frmThangBangLuongQL)
            {
                frmThangBangLuongQL that = (frmThangBangLuongQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OBangLuong.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OBangLuong.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OBangLuong.GetPermissionItem(PermissionType.EDIT));

                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriThangBangLuong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.Filter_TenNhanVien,
                    FBienTapThangBangLuong.GetPermissionItem(PermissionType.VIEW_HIDE));
            }

            if (form is frmDieuChinhLuong)
            {
                frmDieuChinhLuong that = (frmDieuChinhLuong)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.btLuu,
                    OLuong.GetPermissionItem(PermissionType.ADD_EDIT));
            }
            #endregion

            #region OBJECT Thu chi
            if (form is frmThuChiQL)
            {
                frmThuChiQL that = (frmThuChiQL)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OThuChi.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemXem,
                    OThuChi.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OThuChi.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OThuChi.GetPermissionItem(PermissionType.EDIT));
            }
            if (form is frmPhieuThuChi)
            {
                frmPhieuThuChi that = (frmPhieuThuChi)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    OThuChi.GetPermissionItem(PermissionType.ADD_EDIT));
            }

            #region NEW
            if (form is frmPhieuThuChiMan)
            {
                frmPhieuThuChiMan that = (frmPhieuThuChiMan)form;
                ApplyPermissionAction.ApplyPermissionObject(items,
                    new object[]{
                        that.barButtonItemAdd,
                        that.barButtonItemDelete,
                        that.barButtonItemUpdate,
                        that.barSubItem2,
                        that.barButtonItemThu,
                        that.barButtonItemChi
                        
                    },
                    new PermissionItem[]{
                        OThuChi.GetPermissionItem(PermissionType.ADD),
                        OThuChi.GetPermissionItem(PermissionType.DELETE),
                        OThuChi.GetPermissionItem(PermissionType.EDIT),
                        OThuChi.GetPermissionItem(PermissionType.VIEW),
                        OThuChi.GetPermissionItem(PermissionType.ADD),
                        OThuChi.GetPermissionItem(PermissionType.ADD)
                    }
                );
            }
            if (form is frmKhoaMoSoCongNo)
            {
                frmKhoaMoSoCongNo that = (frmKhoaMoSoCongNo)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnKhoa,
                    FMoKhoaSo.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnMoKhoa,
                    FMoKhoaSo.GetPermissionItem(PermissionType.EDIT));
            } 
            #endregion
            #endregion

            #region Yêu cầu hỗ trợ
            if (form is frmYeuCauHoTroQL)
            {
                frmYeuCauHoTroQL that = (frmYeuCauHoTroQL)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OYeuCauHoTro.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OYeuCauHoTro.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OYeuCauHoTro.GetPermissionItem(PermissionType.EDIT));

                ApplyPermissionAction.ApplyPermissionObject(items, that.cmbNguoiYC,
                    FQuanTriHoTro.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            if (form is frmHotro)
            {
                frmHotro that = (frmHotro)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnLuu,
                    OYeuCauHoTro.GetPermissionItem(PermissionType.ADD_EDIT));
                //ApplyPermissionAction.ApplyPermissionObject(items, that.btnPhanhoi,
                //    OYeuCauHoTro.GetPermissionItem(PermissionType.ADD_EDIT));
            }
            if (form is frmPhanhoi)
            {
                frmPhanhoi that = (frmPhanhoi)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnLuu,
                    OYeuCauHoTro.GetPermissionItem(PermissionType.ADD_EDIT));
            }

            #endregion

            #region Chấm công bằng tay
            if (form is frmChamCongQL)
            {
                frmChamCongQL that = (frmChamCongQL)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemThemNhanVien,
                    OChamCong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OChamCong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItem_Chot,
                    FChotBoChotChamCongAuto.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItem_KhongChot,
                    FChotBoChotChamCongAuto.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            #endregion

            #region Chấm công tự động
            if (form is frmChamCongAutoQL)
            {
                frmChamCongAutoQL that = (frmChamCongAutoQL)form;

                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemThemNhanVien,
                    FQuanTriChamCong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    FQuanTriChamCong.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItem_Chot,
                    FQuanTriChamCong.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FBienTapChamCong.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            #endregion

            #region OBJECT Theo dõi nghỉ phép
            if (form is frmNghiPhepQL)
            {
                frmNghiPhepQL that = (frmNghiPhepQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OTheoDoiNghiPhep.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OTheoDoiNghiPhep.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OTheoDoiNghiPhep.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDuyet,
                    FQuanTriNghiPhep.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemK_Duyet,
                    FQuanTriNghiPhep.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FBienTapNghiPhep.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            if (form is frmNghiPhep)
            {
                frmNghiPhep that = (frmNghiPhep)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    OTheoDoiNghiPhep.GetPermissionItem(PermissionType.ADD_EDIT));
                //
                string username = FrameworkParams.currentUser.username;
                Feature fQuanTri = Permission.loadFeature(FQuanTriNghiPhep.id, FQuanTriNghiPhep.featureName, username);
                if (fQuanTri.isRead == false)
                {
                    Feature fBienTap = Permission.loadFeature(FBienTapNghiPhep.id, FBienTapNghiPhep.featureName, username);
                    that.NhanVien.Visible = fBienTap.isRead != false;
                }
                else that.NhanVien.Visible = true;
            }
            #endregion

            #region OBJECT Hỗ trợ in ấn
            if (form is frmHoTroInAnQL)
            {
                frmHoTroInAnQL that = (frmHoTroInAnQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OHelpPrinter.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OHelpPrinter.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OHelpPrinter.GetPermissionItem(PermissionType.DELETE));

                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriPrinter.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.cboNguoi_gui,
                    FBienTapPrinter.GetPermissionItem(PermissionType.VIEW_HIDE));

            }
            if (form is frmYeuCauInAn)
            {
                frmYeuCauInAn that = (frmYeuCauInAn)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnLuu,
                    OHelpPrinter.GetPermissionItem(PermissionType.ADD_EDIT));
            }
            #endregion


            #region OBJECT quan hệ khách hàng
            if (form is frmKhachHangQL)
            {
                frmKhachHangQL that = (frmKhachHangQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OKhachHang.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OKhachHang.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OKhachHang.GetPermissionItem(PermissionType.DELETE));
            }
            if (form is frmTaoKhachHangMoi)
            {
                frmTaoKhachHangMoi that = (frmTaoKhachHangMoi)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnLuu,
                    OKhachHang.GetPermissionItem(PermissionType.ADD_EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnThem,
                    OKhachHang.GetPermissionItem(PermissionType.ADD_EDIT));
            }
            #endregion

            #region OBJECT Phiếu tạm ứng
            if (form is frmPhieuTamUngQL)
            {
                frmPhieuTamUngQL that = (frmPhieuTamUngQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OPhieuTamUng.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OPhieuTamUng.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OPhieuTamUng.GetPermissionItem(PermissionType.ADD));

                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDuyet,
                    FQuanTriTamUng.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemKoDuyet,
                    FQuanTriTamUng.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriTamUng.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FBienTapTamUng.GetPermissionItem(PermissionType.VIEW_HIDE));
            }

            if (form is frmPhieuTamUng) {
                frmPhieuTamUng that = (frmPhieuTamUng)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    OPhieuTamUng.GetPermissionItem(PermissionType.ADD_EDIT));
                //
                string username = FrameworkParams.currentUser.username;
                Feature fQuanTri = Permission.loadFeature(FQuanTriTamUng.id, FQuanTriTamUng.featureName, username);
                if (fQuanTri.isRead == false)
                {
                    Feature fBienTap = Permission.loadFeature(FBienTapTamUng.id, FBienTapTamUng.featureName, username);
                    that.NhanVien.Visible = fBienTap.isRead != false;
                }
                else that.NhanVien.Visible = true;

            }

            #endregion

            #region OBJECT Tin tức
            if (form is frmTinTucQL)
            {
                frmTinTucQL that = (frmTinTucQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OTinTuc.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OTinTuc.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OTinTuc.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDuyet,
                    FQuanTriTinTuc.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemK_Duyet,
                    FQuanTriTinTuc.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriTinTuc.GetPermissionItem(PermissionType.VIEW_HIDE));

            }
            #endregion

            #region OBJECT RSS
            if (form is frmRSS)
            {
                frmRSS that = (frmRSS)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                  ORSS.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                  ORSS.GetPermissionItem(PermissionType.EDIT));
            }
            #endregion

            #region OBJECT Diễn đàn
            if (form is frmForumQL)
            {
                frmForumQL that = (frmForumQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    ODienDan.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    ODienDan.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    ODienDan.GetPermissionItem(PermissionType.ADD));
            }
            #endregion

            #region OBJECT Danh bạ địa chỉ
            if (form is frmDanhBaExtQL)
            {
                frmDanhBaExtQL that = (frmDanhBaExtQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemXoaNguoiLL,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemXoaNhom,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemSuaNguoiLL,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDoiTenNhom,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemLuu,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.ADD_EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemKhongLuu,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.ADD_EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemSuaNhom,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemThemNhom,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemThemNguoiLL,
                    ODanhBaDiaChi.GetPermissionItem(PermissionType.ADD));
            }
            #endregion

            #region OBJECT Danh bạ website
            if (form is frmWebsiteQL)
            {
                frmWebsiteQL that = (frmWebsiteQL)form;
                 ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    ODanhBaWebsite.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    ODanhBaWebsite.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    ODanhBaWebsite.GetPermissionItem(PermissionType.ADD));
            }
            #endregion

            #region OBJECT Tài liệu
            if (form is frmDocumentQL)
            {
                frmDocumentQL that = (frmDocumentQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.Xoa,
                    OTaiLieu.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.Sua,
                    OTaiLieu.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.Them,
                    OTaiLieu.GetPermissionItem(PermissionType.ADD));
            }
            #endregion

            #region OBJECT BUG
            if (form is frmBugProductQL)
            {
                frmBugProductQL that = (frmBugProductQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OQuanLyVanDe.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OQuanLyVanDe.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OQuanLyVanDe.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FQuanTriVanDe.GetPermissionItem(PermissionType.VIEW_HIDE));

            }
            #endregion

            #region OBJECT DU AN
            if (form is frmDuAnQL)
            {
                frmDuAnQL that = (frmDuAnQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    ODuAn.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    ODuAn.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    ODuAn.GetPermissionItem(PermissionType.ADD));

                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriDuAn.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FBienTapDuAn.GetPermissionItem(PermissionType.VIEW_HIDE));
            }

            if (form is frmDuAn) {
                frmDuAn that = (frmDuAn)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    ODuAn.GetPermissionItem(PermissionType.ADD_EDIT));
                //
                string username = FrameworkParams.currentUser.username;
                Feature fQuanTri = Permission.loadFeature(FQuanTriDuAn.id, FQuanTriDuAn.featureName, username);
                if (fQuanTri.isRead == false)
                {
                    Feature fBienTap = Permission.loadFeature(FBienTapDuAn.id, FBienTapDuAn.featureName, username);
                    that.NhanVien.Visible = fBienTap.isRead != false;
                }
                else that.NhanVien.Visible = true;
            }
            #endregion

            #region OBJECT PHIỄU RA VÀO CÔNG TY
            if (form is frmPhieuRaVaoCtyQL)
            {
                frmPhieuRaVaoCtyQL that = (frmPhieuRaVaoCtyQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OPhieuRaVaoCty.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OPhieuRaVaoCty.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OPhieuRaVaoCty.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemCommit,
                    FQuanTriRaVaoCty.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemNoCommit,
                    FQuanTriRaVaoCty.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FBienTapRaVaoCty.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            if (form is frmPhieuRaVaoCty) {
                frmPhieuRaVaoCty that = (frmPhieuRaVaoCty)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    OPhieuRaVaoCty.GetPermissionItem(PermissionType.ADD_EDIT));

                string username = FrameworkParams.currentUser.username;
                Feature fQuanTri = Permission.loadFeature(FQuanTriRaVaoCty.id, FQuanTriRaVaoCty.featureName, username);
                if (fQuanTri.isRead == false)
                {
                    Feature fBienTap = Permission.loadFeature(FBienTapRaVaoCty.id, FBienTapRaVaoCty.featureName, username);
                    that.NhanVien.Visible = fBienTap.isRead != false;
                }
                else that.NhanVien.Visible = true;
            }
            #endregion

            #region OBJECT PHIỄU XÁC NHẬN LÀM VIỆC
            if (form is frmPhieuXacNhanLamViecQL)
            {
                frmPhieuXacNhanLamViecQL that = (frmPhieuXacNhanLamViecQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OPhieuXNLamViec.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OPhieuXNLamViec.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OPhieuXNLamViec.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDuyet,
                    FQuanTriXNLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemK_Duyet,
                    FQuanTriXNLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.NhanVien,
                    FBienTapXNLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            if (form is frmPhieuXNLamViec) {
                frmPhieuXNLamViec that = (frmPhieuXNLamViec)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    OPhieuXNLamViec.GetPermissionItem(PermissionType.VIEW_HIDE));

                string username = FrameworkParams.currentUser.username;
                Feature fQuanTri = Permission.loadFeature(FQuanTriXNLamViec.id, FQuanTriXNLamViec.featureName, username);
                if (fQuanTri.isRead == false)
                {
                    Feature fBienTap = Permission.loadFeature(FBienTapXNLamViec.id, FBienTapXNLamViec.featureName, username);
                    that.NhanVien.Visible = fBienTap.isRead != false;
                }
                else that.NhanVien.Visible = true;
            }
            #endregion

            #region OBJECT FAX
            if (form is frmHoTroFaxQL)
            {
                frmHoTroFaxQL that = (frmHoTroFaxQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OFax.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OFax.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OFax.GetPermissionItem(PermissionType.ADD));

                ApplyPermissionAction.ApplyPermissionObject(items, that.barSubItem1,
                    FQuanTriFax.GetPermissionItem(PermissionType.VIEW_HIDE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.cmbNguoiGui,
                    FBienTapFax.GetPermissionItem(PermissionType.VIEW_HIDE));
                
            }
            if (form is frmYeuCauFax) { 
                frmYeuCauFax that=(frmYeuCauFax)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnLuu,
                    OFax.GetPermissionItem(PermissionType.ADD_EDIT));

            }
            #endregion

            #region OBJECT HÒM THƯ GÓP Ý
            if (form is frmHomThuGopYQL)
            {
                frmHomThuGopYQL that = (frmHomThuGopYQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OHomThuGopY.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OHomThuGopY.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OHomThuGopY.GetPermissionItem(PermissionType.ADD));

                ApplyPermissionAction.ApplyPermissionObject(items, that.nguoiGui,
                     FQuanTriHomThuGopY.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            if (form is frmHomThuGopY) {
                frmHomThuGopY that = (frmHomThuGopY)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    OHomThuGopY.GetPermissionItem(PermissionType.ADD_EDIT));

            }

            #endregion

            #region OBJECT TIẾP NHẬN THÔNG TIN
            if (form is frmTiepNhanThongTinVerticalQL)
            {
                frmTiepNhanThongTinVerticalQL that = (frmTiepNhanThongTinVerticalQL)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemDelete,
                    OTiepNhanThongTin.GetPermissionItem(PermissionType.DELETE));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemUpdate,
                    OTiepNhanThongTin.GetPermissionItem(PermissionType.EDIT));
                ApplyPermissionAction.ApplyPermissionObject(items, that.barButtonItemAdd,
                    OTiepNhanThongTin.GetPermissionItem(PermissionType.ADD));
                ApplyPermissionAction.ApplyPermissionObject(items, that.cmbNguoiXuLy,
                    FQuanTriTiepNhanThongTin.GetPermissionItem(PermissionType.VIEW_HIDE));
            }
            if (form is frmTiepNhanThongTin)
            {
                frmTiepNhanThongTin that = (frmTiepNhanThongTin)form;
                ApplyPermissionAction.ApplyPermissionObject(items, that.btnSave,
                    OTiepNhanThongTin.GetPermissionItem(PermissionType.ADD_EDIT));
            }
            #endregion
            return items;
        }

        #endregion
        
        /// <summary>Ham nay khong dung nua        
        /// </summary>
        public List<Control> GetPermisionableControls(XtraForm form)
        {
            return null;
        }
    }
}