using System;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DTO;
using DAO;

namespace office
{
    public partial class frmKhachHangQL1N : PhieuQuanLy10Change,IFormRefresh
    //public partial class frmKhachHangQL1N : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.FIX;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmKhachHangQL1N).FullName,
                PMSupport.UpdateTitle("Quản trị quan hệ khách hàng", Status),
                ParentID, true,
                typeof(frmKhachHangQL1N).FullName,
                true, IsSep, "mnbHSoUngVien.png", true, "", "");
        }
        #endregion
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
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
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
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //#endregion
        PhieuQuanLy10Fix fix = null;

        public frmKhachHangQL1N()
        {
            InitializeComponent();
            IDField = "KH_ID";
            DisplayField = "TEN_KHACH_HANG";
            fix = new PhieuQuanLy10Fix(this);
            PMSupport.SetTitle(this, Status);
        }
        private void frmKhachHangQL1N_Load(object sender, EventArgs e)
        {
            this.barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemNoCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            HelpGridExt1.SetDefaultGroupPanel(this.gridViewMaster);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
        }
        public override void InitColumnMaster()
        {
            HelpGridColumn.CotTextLeft(Cot_gridControlMaster_TenKH, "TEN_KHACH_HANG");
            HelpGridColumn.CotTextLeft(Cot_gridControlMaster_Thongtin, "TTT");
            HelpGridColumn.CotTextLeft(Cot_gridControlMaster_Linhvuc, "LVHD");
            HelpGridColumn.CotTextLeft(Cot_gridControlMaster_Website, "WS");
            HelpGridColumn.CotCombobox(Cot_gridControlMaster_NKH,"DM_KHACH_HANG_NHOM", "ID", "NAME", "NKH_ID");
        }
        public override void InitColumDetail()
        {

        }
        public static void InitChonKhachHang(PLCombobox PLKhachhang)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT distinct TEN_KHACH_HANG, KH_ID FROM KHACH_HANG where 1=1");
            DataSet ds = DABase.getDatabase().LoadDataSet(query);
            PLKhachhang._init(ds.Tables[0], "TEN_KHACH_HANG", "KH_ID");
        }
        public override void PLLoadFilterPart()
        {
            InitChonKhachHang(Khachhang);
            DataTable dt1 = DABase.getDatabase().LoadDataSet("select t.id,t.ho_ten,t.chuc_vu,t.bo_phan from thong_tin_lien_he t").Tables[0];
            NguoiLienHe._init(dt1, "HO_TEN", "ID", "[Chọn giá trị]",
                                     new string[] { "HO_TEN", "CHUC_VU", "BO_PHAN" },
                                     new string[] { "Họ tên", "Chức vụ", "Bộ phận" },
                                     new int[] { 100, 100, 100 });
            NguoiLienHe._lookUpEdit.Properties.PopupWidth = 400;
            //DataTable dt = DABase.getDatabase().LoadDataSet("select distinct(kh.website) website from khach_hang kh where kh.website is not null and char_length(trim(kh.website))>0").Tables[0];
            DataTable dt = DABase.getDatabase().LoadDataSet("SELECT * FROM DM_KHACH_HANG_NHOM WHERE ID_CHA > 0").Tables[0];
            plCbbWebsite._init(dt, "NAME", "ID");
        }
        public override _MenuItem GetBusinessMenuList()
        {
            return null;
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            string str = @"SELECT DISTINCT KH.KH_ID, KH.TEN_KHACH_HANG , KH.WEBSITE WS,
                            KH.LINH_VUC_HOAT_DONG LVHD, KH.THONG_TIN_THEM TTT,KH.NKH_ID
                            FROM KHACH_HANG KH LEFT JOIN THONG_TIN_LIEN_HE TT ON TT.KH_ID = KH.KH_ID      
                            WHERE  1=1";
            QueryBuilder query = new QueryBuilder(str);
            query.addID("KH.KH_ID", Khachhang._getSelectedID());
            query.addID("TT.ID", NguoiLienHe._getSelectedID());
            //if (plCbbWebsite.Text != "" && plCbbWebsite.Text != "Chọn giá trị") query.addLike("kh.website", plCbbWebsite.Text);
            query.addID("KH.NKH_ID", plCbbWebsite._getSelectedID());
            query.addLike("UPPER(KH.LINH_VUC_HOAT_DONG)", txtLVHD.Text.Trim().ToUpper());
            DataSet ds = DABase.getDatabase().LoadDataSet(query);
            gridControlMaster.DataSource = ds.Tables[0];
            return null;
        }
        public override void ShowViewForm(long id)
        {
            ProtocolForm.ShowModalDialog(this, new frmTaoKhachHangMoi(id, null));
        }
        public override void ShowUpdateForm(long id)
        {
            frmTaoKhachHangMoi frm = new frmTaoKhachHangMoi(id, false);
            ProtocolForm.ShowModalDialog(this, frm);
        }
       
        public override long[] ShowAddForm()
        {
            frmTaoKhachHangMoi frm = new frmTaoKhachHangMoi(-2, true);
            ProtocolForm.ShowModalDialog(this, frm);
            return null;
        }
        public override bool XoaAction(long id)
        {
            bool value = DAKhachHangX.Instance.Delete(id);
            return value;
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        public override string UpdateRow()
        {
            return @"SELECT DISTINCT KH.KH_ID, KH.TEN_KHACH_HANG , KH.WEBSITE WS,
                        KH.LINH_VUC_HOAT_DONG LVHD, KH.THONG_TIN_THEM TTT
                    FROM (KHACH_HANG KH LEFT JOIN THONG_TIN_LIEN_HE TT ON TT.KH_ID = KH.KH_ID )     
                    WHERE  1=1";
        }

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        }

        #endregion
    }
}
