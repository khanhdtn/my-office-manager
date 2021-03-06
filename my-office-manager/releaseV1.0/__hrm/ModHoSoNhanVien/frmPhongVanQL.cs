using System;
using System.Data;
using DAO;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;

using ProtocolVN.App.Office;
using ProtocolVN.Framework.Win.Trial;

namespace office
{
    public partial class frmPhongVanQL :  PhieuQuanLyChange,IFormRefresh
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
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //protected DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        //private System.ComponentModel.IContainer components;
        //private DevExpress.XtraBars.BarSubItem barSubItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //#endregion

        #region Vùng đặt Static
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhongVanQL).FullName,
                "Phỏng vấn",
                ParentID, true,
                typeof(frmPhongVanQL).FullName,
                true, IsSep, "mnbPhongVan.png", true, "", "");
          
        }
        #endregion

        #region 1.Phần chỉ được thay đổi code trong phương thức không được thay đổi tên phương thức, kiểu dữ liệu, tham số
        PhieuQuanLyFix that;
        public frmPhongVanQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "HO_TEN";
            that = new PhieuQuanLyFix(this);
            Web_HienThiThongTin.IsWebBrowserContextMenuEnabled = false;
        }
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(Cot_Ten, "HO_TEN");
            XtraGridSupportExt.TextCenterColumn(Cot_NgayPhongVan, "NGAY_GIO_PHONG_VAN");
            HelpGridColumn.CotPLTimeEdit(Cot_GioPhongVan, "GIO_PHONG_VAN", PLConst.FORMAT_TIME_STRING);
            XtraGridSupportExt.TextCenterColumn(Cot_LanMoiPV, "LAN_MOI_PHONG_VAN");
            XtraGridSupportExt.TextCenterColumn(Cot_VongPhongVan, "VONG_PHONG_VAN");
            DataSet ds = HelpDB.getDatabase().LoadDataSet("SELECT * FROM DM_TINH_TRANG_HO_SO WHERE VISIBLE_BIT = 'Y'");
            HelpGridColumn.CotCombobox(Cot_TinhTrangHoSo, ds, "ID", "NAME", "TTHS_ID");
            Cot_LanMoiPV.Visible = false;
            Cot_VongPhongVan.Visible = false;
        }
        public override void InitColumDetail()
        {
            XtraGridSupportExt.TextLeftColumn(CotD_QuaTrinhCongTac, "QUA_TRINH_CONG_TAC");
            XtraGridSupportExt.TextLeftColumn(CotD_QuaTrinhDaoTao, "QUA_TRINH_DAO_TAO");
            XtraGridSupportExt.TextLeftColumn(CotD_TrinhDoChuyenMon, "TRINH_DO_CHUYEN_MON");
            XtraGridSupportExt.TextLeftColumn(CotD_TrinhDoNgoaiNgu, "TRINH_DO_NGOAI_NGU");
            XtraGridSupportExt.TextLeftColumn(CotD_ThongTinKhac, "THONG_TIN_KHAC");
        }
        public override void PLLoadFilterPart()
        {
            Filter_TinhTrangHoSo._init("DM_TINH_TRANG_HO_SO", "NAME", "ID");
            Filter_GioPVDen.Time = Filter_GioPVDen.Time.AddHours(17);
            Filter_GioPVTu.Time = Filter_GioPVTu.Time.AddHours(8);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            //ngayLamViec.Default = SelectionTypes.FromDateToDate;
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            filter.addLike("UPPER(HO_TEN)",Filter_TenUV.Text.Trim().ToUpper());
            if (Filter_VongPV.Text != "")
                filter.add("VONG_PHONG_VAN", Operator.Equal, (int)Filter_VongPV.Value, DbType.Int32);
            filter.addDateFromTo("NGAY_GIO_PHONG_VAN", ngayLamViec.FromDate, ngayLamViec.ToDate);
            filter.addHourFrom(Filter_GioPVTu.Time, "NGAY_GIO_PHONG_VAN");
            filter.addHourTo(Filter_GioPVDen.Time, "NGAY_GIO_PHONG_VAN");
            filter.addID("TTHS_ID", Filter_TinhTrangHoSo._getSelectedID());
            filter.setAscOrderBy("HO_TEN");
            filter.addCondition(" 1=1 ");
            msg.Finish();
            return filter;
           
        }
        public override DataTable PLLoadDataDetailPart(long MasterID)
        {
            try
            {
                DOResume TTUngVien = DAResume.getUngVien(MasterID);
                string filename = Application.StartupPath;
                filename = filename + @"\template\ThongTinUV.html";
                DAResume.ThongTinResume(Web_HienThiThongTin, filename, TTUngVien);
            }
            catch (Exception ex)
            {
                HelpMsgBox.ShowErrorMessage(ex.Message);
            }
            return null;
        }
        public override void ShowViewForm(long id)
        {
            long DTD_ID = HelpNumber.ParseInt64(gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["DTD_ID"]);
            HelpProtocolForm.ShowModalDialog(this, new frmPhongVan(id, DTD_ID, null));      
        }
        public override void ShowUpdateForm(long id)
        {
            long DTD_ID = HelpNumber.ParseInt64( gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["DTD_ID"]);
            HelpProtocolForm.ShowModalDialog(this, new frmPhongVan(id, DTD_ID, false));
        }
        public override long[] ShowAddForm()
        {
            return null;
        }
        public override bool XoaAction(long id)
        {
            return DAHenPhongVan.Delete(id);
        }
        public override _MenuItem GetBusinessMenuList()
        {            
            return null;
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
            
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        public override string UpdateRow()
        {
            return @"SELECT * FROM QL_PHONGVAN WHERE 1=1";
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