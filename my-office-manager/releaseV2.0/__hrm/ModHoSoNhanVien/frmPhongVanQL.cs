using System;
using System.Data;
using DAO;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;
using ProtocolVN.Framework.Dev.Open;

namespace pl.office.form
{
    public partial class frmPhongVanQL :  PhieuQuanLyChange
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
            Uncategory.setEnterAsTab(this);
        }
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(Cot_Ten, "HO_TEN");
            XtraGridSupportExt.TextCenterColumn(Cot_NgayPhongVan, "NGAY_GIO_PHONG_VAN");
            HelpGridColumn.CotPLTimeEdit(Cot_GioPhongVan, "GIO_PHONG_VAN","HH:mm");
            XtraGridSupportExt.TextCenterColumn(Cot_LanMoiPV, "LAN_MOI_PHONG_VAN");
            XtraGridSupportExt.TextCenterColumn(Cot_VongPhongVan, "VONG_PHONG_VAN");
            XtraGridSupportExt.TextLeftColumn(Cot_TinhTrangHoSo, "TTHS_NAME");
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
            Filter_GioPVDen.TimeEditSub.Time = Filter_GioPVDen.TimeEditSub.Time.AddHours(17);
            Filter_GioPVTu.TimeEditSub.Time = Filter_GioPVTu.TimeEditSub.Time.AddHours(8);
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder filter = new QueryBuilder
            (
                 "SELECT uv.ID as ID,hpv.DTD_ID,uv.HO_TEN,hpv.VONG_PHONG_VAN,hpv.NGAY_GIO_PHONG_VAN, hpv.LAN_MOI_PHONG_VAN,tths.NAME as TTHS_NAME, " +
                 " hpv.NGAY_GIO_PHONG_VAN  as GIO_PHONG_VAN " + 
                 "FROM RESUME uv, HEN_PHONG_VAN hpv,DM_TINH_TRANG_HO_SO tths " +
                 "WHERE uv.ID=hpv.R_ID AND tths.ID = uv.TTHS_ID AND 1=1" 
            );
            filter.add("uv.HO_TEN", Operator.Like, "%" + PLHeplString.PLHelpFortmatName(Filter_TenUV.Text) + "%", DbType.String);
            if (Filter_VongPV.Text != "")
                filter.add("hpv.VONG_PHONG_VAN", Operator.Equal, (int)Filter_VongPV.Value, DbType.Int32);
            filter.addDateFromTo("hpv.NGAY_GIO_PHONG_VAN", Filter_NgayPVTu.DateTime.Date, Filter_NgayPVDen.DateTime.Date);
            filter.addHourFrom(Filter_GioPVTu.TimeEditSub.Time, "hpv.NGAY_GIO_PHONG_VAN");
            filter.addHourTo(Filter_GioPVDen.TimeEditSub.Time, "hpv.NGAY_GIO_PHONG_VAN");
            filter.addID("uv.TTHS_ID", Filter_TinhTrangHoSo._getSelectedID());
            filter.setAscOrderBy("uv.HO_TEN");
            return filter;
           
        }
        public override DataTable PLLoadDataDetailPart(long MasterID)
        {
            try
            {
                DOResume TTUngVien = DAResume.getUngVien(MasterID);
                string filename = Application.StartupPath;
                filename = filename + @"\ModHoSoNhanVien\template\a.html";
                DAResume.ThongTinResume(Web_HienThiThongTin, filename, TTUngVien);
            }
            catch (Exception ex)
            {
                PLMessageBox.ShowErrorMessage(ex.Message);
            }
            return null;
        }
        public override void ShowViewForm(long id)
        {
            long DTD_ID = HelpNumber.ParseInt64(gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["DTD_ID"]);
            ProtocolForm.ShowModalDialog(this, new frmPhongVan(id, DTD_ID, TrangThaiForm.Show));      
        }
        public override void ShowUpdateForm(long id)
        {
            long DTD_ID = HelpNumber.ParseInt64( gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["DTD_ID"]);
            ProtocolForm.ShowModalDialog(this, new frmPhongVan(id, DTD_ID, TrangThaiForm.Update));
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
            return "";
        }
        #endregion
        
    }
}