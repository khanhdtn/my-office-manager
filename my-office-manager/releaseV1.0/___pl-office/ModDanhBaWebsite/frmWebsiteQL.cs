using System;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

using DevExpress.XtraBars.Demos.BrowserDemo;
using DAO;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;

namespace office
{
    
    public partial class frmWebsiteQL :PhieuQuanLy10Change ,IFormRefresh 
    //public partial class frmWebsiteQL : XtraFormPL      
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

        #region Các khai báo biến        
        PhieuQuanLy10Fix fix = null;
        long selectedPhanLoai = 0;
        public static FormStatus Status = FormStatus.FIX;
        bool isShown = false;
        #endregion

        #region Các hàm khởi tạo 
        public frmWebsiteQL()
        {
            InitializeComponent();
            WebsitesPermission.I.Init();
            IDField = "ID";
            DisplayField = "DIA_CHI";
            this._UsingExportToFileItem = false;
            fix = new PhieuQuanLy10Fix(this);
            PMSupport.SetTitle(this, Status);
        }
        private void frmKhachHangQL1N_Load(object sender, EventArgs e)
        {
            this.barButtonItemSearch.Visibility = BarItemVisibility.Never;
            this.barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemNoCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemPrint.Visibility = BarItemVisibility.Never;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            //this.gridViewMaster.OptionsBehavior.Editable = false;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridControlMaster.Load += new EventHandler(gridControlMaster_Load);
            navBarControl1.SelectedLinkChanged += new DevExpress.XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventHandler(navBarControl1_SelectedLinkChanged);
            this.Shown += new EventHandler(frmWebsiteQL_Shown);
            Load_navbar();
            
        }

        void frmWebsiteQL_Shown(object sender, EventArgs e)
        {
            isShown = true;
            GetState = false;
        }

        void navBarControl1_SelectedLinkChanged(object sender, DevExpress.XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventArgs e)
        {
            if (!isShown) return;
            selectedPhanLoai=HelpNumber.ParseInt64(e.Link.Item.Name);
            this.gridControlMaster.DataSource = HelpDB.getDBService().LoadDataSet(this.PLBuildQueryFilter()).Tables[0];
            GetState = (gridControlMaster.DataSource as DataTable).Rows.Count > 0;
        }

        public void Load_navbar()
        {
            try
            {
                navBarControl1.Items.Clear();
                QueryBuilder query = new QueryBuilder(
                @"SELECT * FROM DM_WEBSITE 
                WHERE 1=1");
                query.addCondition("VISIBLE_BIT = 'Y' AND ID <> ID_ROOT");
                query.setAscOrderBy("NAME");

                DataSet ds1 = WebsitesPermission.I._LoadDataSetWithResGroupPermission(query, "ID");
                foreach (DataRow r1 in ds1.Tables[0].Rows)
                {
                    if (HelpNumber.ParseInt64(r1["ID"]) != 1)
                    {
                        NavBarItem item1 = new NavBarItem();
                        item1.Caption = r1["NAME"].ToString();
                        item1.Name = r1["ID"].ToString();
                        item1.SmallImage = imageList1.Images[0];
                        item1.LargeImage = imageList1.Images[0];
                        navBarGroup1.ItemLinks.Add(item1);
                    }
                }
                navBarGroup1.SelectedLinkIndex = -1;
                navBarGroup1.ItemLinks.SortByCaption();
                navBarControl1.SelectedLink = null;
            }
            catch(Exception ex){
                PLException.AddException(ex);

            }
        }
        void gridControlMaster_Load(object sender, EventArgs e)
        {
            gridViewMaster.BestFitColumns();
        }
        #endregion

        #region InitControl 
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(CotPhanLoai, "NAME");
            XtraGridSupportExt.TextLeftColumn(CotDiaChi, "DIA_CHI");
            CotDiaChi.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            HelpGrid.CotMemoExEdit(CotMo_ta, "MO_TA");
           HelpGrid.SetReadOnlyHaveMemoCtrl(gridViewMaster);
        }
        public override void PLLoadFilterPart()
        {
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);           
        }
        public override void InitColumDetail()
        {

        }
        #endregion

        #region Các xử lý trên form 
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
            QueryBuilder query = new QueryBuilder(@"SELECT * 
                                                    FROM DANH_BA_WEBSITE DB INNER JOIN DM_WEBSITE DM on DB.PHAN_LOAI=DM.ID 
                                                    WHERE 1=1");
            query.addID("PHAN_LOAI", selectedPhanLoai);
            return query;
        }
        public override void ShowViewForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row != null)
            {
                frmWebBrowser frm = new frmWebBrowser(row["DIA_CHI"].ToString());
                frm.FavoritesStatus = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
                frm.Show();
            }
        }
        
        public override void ShowUpdateForm(long id)
        {
            DataRow row = gridViewMaster.GetFocusedDataRow();
            if (row == null) return;

            if (WebsitesPermission.I._checkPermissionResGroup(HelpNumber.ParseInt64(row["PHAN_LOAI"]), 
                PermissionOfResource.RES_PERMISSION_TYPE.UPDATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền sửa liên kết thuộc phân loại website đang chọn!");
                return;
            }
            frmThemMoi frm = new frmThemMoi(HelpNumber.ParseInt64(row["ID"]), false);
            frm.Refresh_data += new frmThemMoi.Update_Grid(Update_data);
            ProtocolForm.ShowModalDialog(this, frm);              
            fix.PLRefresh();            
        }        
        public override long[] ShowAddForm()
        {
            frmThemMoi frm = new frmThemMoi();
            //frm.Refresh_data += new frmThemMoi.Update_Grid(Update_data);
            ProtocolForm.ShowModalDialog(this, frm);          
            return null;
        }
        public void Update_data()
        {
            fix.PLRefresh();
        }
        public override string UpdateRow()
        {
            return @"SELECT * FROM DANH_BA_WEBSITE DB INNER JOIN DM_WEBSITE DM on DB.PHAN_LOAI=DM.ID WHERE 1=1";
        }
        public override bool XoaAction(long id)
        {
            DataRow row = gridViewMaster.GetFocusedDataRow();
            if (row == null) return true;

            if (WebsitesPermission.I._checkPermissionResGroup(HelpNumber.ParseInt64(row["PHAN_LOAI"]),
                PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xoá liên kết thuộc phân loại website đang chọn!");
                return false;
            }
            return DAWebsite.Instance.Delete(HelpNumber.ParseInt64(row["ID"]));
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        public override void HookFocusRow()
        {           
        }
        public bool GetState {
            set {
                barButtonItemXem.Enabled = value;
                barButtonItemUpdate.Enabled = value;
                barButtonItemDelete.Enabled = value;
            }
        }

        private void InitSaveQueryDialog()
        {
            HelpControl.addSaveQueryDialog(this, this.barManager1, this.gridControlMaster, this.gridViewMaster._GetPLGUI(), 
                @"SELECT NAME, DIA_CHI, MO_TA, DB.ID FROM DANH_BA_WEBSITE DB INNER JOIN DM_WEBSITE DM on DB.PHAN_LOAI=DM.ID");
        }
        #endregion        

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            Load_navbar();
            return null;
        }

        #endregion
    }
}
