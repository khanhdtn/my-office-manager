using System;
using System.Data;
using System.Windows.Forms;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using System.Drawing;

using DevExpress.XtraEditors;
using System.Collections.Generic;
using ProtocolVN.Framework.Win.Trial;

namespace office
{
    public partial class frmThuChiQL : PhieuQuanLyChange,IFormRefresh
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //protected DevExpress.XtraBars.BarManager barManager1;
        //protected DevExpress.XtraBars.Bar MainBar;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        //protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        //protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraBars.BarSubItem barSubItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //private System.ComponentModel.IContainer components;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;

        //#endregion

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmThuChiQL).FullName,
                "Thu chi",
                ParentID, true,
                typeof(frmThuChiQL).FullName,
                true, IsSep, "mnbThuChi.png", true, "", "");
        }

        PhieuQuanLyFix that;
      
        #region 1. Hàm dựng và Form Load
        
        public frmThuChiQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "O_MA_PHIEU";
            that = new PhieuQuanLyFix(this);
            this.barSubItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSubItem2.Glyph = FWImageDic.BUSINESS_IMAGE20;
            this.barSubItem1.Glyph = FWImageDic.BUSINESS_IMAGE20;
            this.barButtonItem_Chot.Glyph = FWImageDic.CHOICE_IMAGE20;
            this.barButtonItem_NoChot.Glyph = FWImageDic.ADD_IMAGE20;
            this.barSubItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
        }
        
        private void frmThuChiQL_Load(object sender, EventArgs e)
        {
            splitContainerControl1.Panel1.Dock = DockStyle.Fill;
         }
        
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextCenterColumn(Cot_NgayPhatSinh , "O_NGAY_PHAT_SINH");
            XtraGridSupportExt.TextLeftColumn(Cot_MaPhieu, "O_MA_PHIEU");
            XtraGridSupportExt.TextLeftColumn(Cot_DienGiai, "O_DIEN_GIAI");
            XtraGridSupportExt.TextLeftColumn(Cot_LoaiChiPhi, "O_LOAI_CHI_PHI");
            XtraGridSupportExt.TextLeftColumn(Cot_DonViLienQuan, "O_VU_VIEC");
            XtraGridSupportExt.TextLeftColumn(Cot_NguoiLienQuan, "O_NHAN_VIEN");
            HelpGridColumn.CotReadOnlyNumber(Cot_Thu, "O_THU");
            HelpGridColumn.CotReadOnlyNumber(Cot_Chi, "O_CHI");
            HelpGridColumn.CotReadOnlyNumber(Cot_TonDauKy, "O_DAU_KY");
            HelpGridColumn.CotReadOnlyNumber(Cot_TonCuoiKy, "O_CUOI_KY");
            XtraGridSupportExt.TextCenterColumn(Cot_TrangThai, "O_IS_CHOT");
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
        }
        
        public override void InitColumDetail()
        {
            
        }
        
        public override void PLLoadFilterPart()
        {
            DMLoaiChiPhi.I.InitCtrl(Filter_LoaiChiPhi, true, true);
            DMNhanVienX.I.InitCtrl(Filter_NguoiLienQuan, true, true);
            Footer();
            HelpControl.RedCheckEdit(chk_Chi,false);
            HelpControl.RedCheckEdit(chk_Thu,false);
            chk_Chi.Checked = chk_Thu.Checked = true;
            HelpGrid.SetUpperTitle(this.gridViewMaster, "DANH SÁCH THU/CHI");
            chk_Chi.CheckedChanged += delegate(object check, EventArgs checkedChanged) {
                if (chk_Chi.CheckState == CheckState.Unchecked
                    && chk_Thu.CheckState == CheckState.Unchecked) chk_Chi.Checked = true;
            };
            chk_Thu.CheckedChanged += delegate(object check, EventArgs checkedChanged) {
                if (chk_Thu.CheckState == CheckState.Unchecked
                    && chk_Chi.CheckState == CheckState.Unchecked) chk_Thu.Checked = true;
            };
            //Format Calc_SoTienTu,Calc_SoTienDen với 2 số thập phân sau dấu phẩy.
            ApplyFormatAction.applyElement(Calc_SoTienTu.Properties, 0);
            Calc_SoTienTu.Properties.Precision = 2;
            ApplyFormatAction.applyElement(Calc_SoTienDen.Properties, 0);
            Calc_SoTienDen.Properties.Precision = 2;
        }
        
        public override QueryBuilder PLBuildQueryFilter()
        {
            LoadMasterByFilter();
            return null;
        }
        
        public override DataTable PLLoadDataDetailPart(long MasterID)
        {
            return null;
        }
        
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem mnu = new _MenuItem(
               new string[] { "Chốt kỳ kinh doanh", "Mở chốt kỳ kinh doanh"},
               new string[] { "add.png", "add.png" },
               "ID",
               new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    FChotKyKinhDoanh,FMoChotKyKinhDoanh
                },
               new PermissionItem[]{
                    null,null
               });
            return mnu;

        }
        public void FChotKyKinhDoanh(List<object> ids) {
            ProtocolForm.ShowModalDialog(this, new frmChotPhieu("Y"));
            LoadMasterByFilter();
        }
        public void FMoChotKyKinhDoanh(List<object> ids)
        {
            ProtocolForm.ShowModalDialog(this, new frmChotPhieu("N"));
            LoadMasterByFilter();
        }

        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        
        #endregion

        #region 2.Xử lý sự kiện Nút
      
        public override void ShowViewForm(long id)
        {
            ProtocolForm.ShowModalDialog(this, new frmPhieuThuChi(null,id));
        }
        
        public override void ShowUpdateForm(long id)
        {
            if (DAPhieuThuChi.ChotPhieu(id)!= 1)
                ProtocolForm.ShowModalDialog(this, new frmPhieuThuChi(false,id));
            else
                HelpMsgBox.ShowErrorMessage("Phiếu này đã bị chốt, bạn không thể chỉnh sửa");

        }
       
        public override bool XoaAction(long id)
        {
            if (DAPhieuThuChi.ChotPhieu(id)!=1)
            {
                if (DAPhieuThuChi.Delete(id))
                    return true;
                return false;
            }
            return false;
        }
       
        public override long[] ShowAddForm()
        {
            frmPhieuThuChi frm = new frmPhieuThuChi(true);
            //frm.RefreshData += new frmPhieuThuChi.RefreshDataQL(LoadMasterByFilter);
            ProtocolForm.ShowModalDialog(this, frm);
            return null;
        }
       
        #endregion

        #region 3.Xử lý trên lưới
     
        public override string UpdateRow()
        {
            LoadMasterByFilter();
            return "";
        }
        
        #endregion

        #region 4.Xử lý Kiểm tra dữ liệu

        #endregion

        #region 5.Xử lý In Ấn
      
        public override _Print InAction(long[] ids)
        {
            return null;
        }
       
        #endregion

        #region 6.Xử lý Nghiệp vụ
        
        private void barButtonItemCommit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProtocolForm.ShowModalDialog(this, new frmChotPhieu("N"));
        }
        
        private void barButtonItemNoCommit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProtocolForm.ShowModalDialog(this, new frmChotPhieu("Y"));
        }

        private void barButtonItem_Chot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProtocolForm.ShowModalDialog(this, new frmChotPhieu("Y"));
            LoadMasterByFilter();
        }
        
        private void barButtonItem_NoChot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProtocolForm.ShowModalDialog(this, new frmChotPhieu("N"));
            LoadMasterByFilter();
        }
       
        #endregion

        #region 7.Xử lý Chọn

        #endregion

        #region 8.Phần mở rộng
        private void LoadMasterByFilter()
        {
            string strThuChi = "Y";
            if (chk_Thu.Checked == true && chk_Chi.Checked == false)
                strThuChi = "Y";
            if (chk_Thu.Checked == false && chk_Chi.Checked == true)
                strThuChi = "N";
            if ((chk_Chi.Checked == true && chk_Thu.Checked == true) || (chk_Chi.Checked == false && chk_Thu.Checked == false))
                strThuChi = "A";

            DateTime TuNgay = new DateTime(1979, 1, 1);// TKThongKeThuChi.Get_NGAYDAUKY_MAX();
            DateTime DenNgay = new DateTime(3000, 1, 1);
            decimal SoTienTu = -1;
            decimal SoTienDen = -1;

            if (ngayKT.FromDate != new DateTime(1, 1, 1))
                TuNgay = ngayKT.FromDate;
            if (ngayKT.ToDate != new DateTime(1, 1, 1))
                DenNgay = ngayKT.ToDate;
            if (Calc_SoTienTu.Value > 0)
                SoTienTu = Calc_SoTienTu.Value;
            if (Calc_SoTienDen.Value > 0)
                SoTienDen = Calc_SoTienDen.Value;
            if (SoTienTu > SoTienDen)
                gridControlMaster.DataSource = null;
            else
            gridControlMaster.DataSource = TKThongKeThuChi.ThongKe(
                                                (int)Filter_LoaiChiPhi._getSelectedID(),
                                                TuNgay,
                                                DenNgay,
                                                (int)Filter_NguoiLienQuan._getSelectedID(),
                                                SoTienTu,
                                                SoTienDen,
                                                strThuChi
                                            ).Tables[0];

        }
        private void Footer()
        {
            gridViewMaster.OptionsView.ShowFooter = true;
            Cot_Thu.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Cot_Thu.SummaryItem.DisplayFormat = "Thu : {0:0,##0}";
            Cot_Chi.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Cot_Chi.SummaryItem.DisplayFormat = "Chi : {0:0,##0}";
            
            Cot_NguoiLienQuan.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            Cot_NguoiLienQuan.SummaryItem.DisplayFormat = "Đầu kỳ : {0}";
            Cot_DienGiai.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            Cot_DienGiai.SummaryItem.DisplayFormat = "Cuối kỳ : {0}";

            HelpGridExt.SetFontFooter(gridViewMaster, new string[] { "O_THU", "O_CHI", "O_NHAN_VIEN", "O_DIEN_GIAI" }, Color.Blue, Color.Empty, FontStyle.Regular);
            
        }
        #endregion

        #region Xử lý sự kiện  
        public decimal _DauKy = 0;
        public decimal _CuoiKy = 0;
        public override void HookFocusRow()
        {
            Cot_Thu.Width = 130;
            Cot_Chi.Width = 130;
            Cot_NguoiLienQuan.Width = 120;
            Cot_DienGiai.Width = 120;

            DataTable dt = gridControlMaster.DataSource as DataTable;
            decimal Thu = 0, Chi = 0;
            Thu = HelpNumber.ParseDecimal(Cot_Thu.SummaryItem.SummaryValue);
            Chi = HelpNumber.ParseDecimal(Cot_Chi.SummaryItem.SummaryValue);
            _DauKy = HelpNumber.DecimalToInt64(dt.Rows[0]["O_DAU_KY"]);
            _CuoiKy = (HelpNumber.ParseDecimal(dt.Rows[0]["O_DAU_KY"]) + Thu - Chi);
            Cot_NguoiLienQuan.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            Cot_NguoiLienQuan.SummaryItem.DisplayFormat = "Đầu kỳ : " + HelpString .NganCachHangNgan(_DauKy) + "{0}";
            Cot_DienGiai.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            Cot_DienGiai.SummaryItem.DisplayFormat = "Cuối kỳ : " + HelpString.NganCachHangNgan(_CuoiKy) + "{0}";
        }
        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        }

        #endregion
       
    }
}