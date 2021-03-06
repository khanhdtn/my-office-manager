using System;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;

using office.Training.ModTinTuc;
using DAO;
using System.Collections.Generic;
using DTO;
using ProtocolVN.App.Office;

namespace office
{
    public partial class frmForumQL :  PhieuQuanLy10Change, IFormRefresh
    //public partial class frmForumQL : XtraFormPL
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

        #region Vùng đặt Static
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmForumQL).FullName,
                "Diễn đàn",
                ParentID, true,
                typeof(frmForumQL).FullName,
                true, IsSep, "mnbHSoUngVien.png", true, "", "");
        }
        #endregion        

        #region Các khai báo biến        
        PhieuQuanLy10Fix fix = null;
        #endregion

        #region Các hàm khởi tạo 
        public frmForumQL()
        {
            InitializeComponent();
            DienDanPermission.I.Init();
            IDField = "ID";
            DisplayField = "CHU_DE";
            this._UsingExportToFileItem = false;
            fix = new PhieuQuanLy10Fix(this);
        }
        private void frmKhachHangQL1N_Load(object sender, EventArgs e)
        {
            this.barButtonItemCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemNoCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridControlMaster.Load += new EventHandler(gridControlMaster_Load);
        }

        void gridControlMaster_Load(object sender, EventArgs e)
        {
            gridViewMaster.BestFitColumns();
        }
        
        #endregion

        #region InitControl 
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.ComboboxGridColumn(CotNhomDienDan, HelpDB.getDatabase().LoadDataSet("Select * from NHOM_DIEN_DAN").Tables[0], "ID", "NAME", "ID_NHOM_DIEN_DAN");
            XtraGridSupportExt.ComboboxGridColumn(CotChuyenMuc, HelpDB.getDatabase().LoadDataSet("Select * from CHUYEN_MUC").Tables[0], "ID", "NAME", "ID_CHUYEN_MUC");
            XtraGridSupportExt.TextLeftColumn(CotChuDe, "CHU_DE");
            CotChuDe.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            XtraGridSupportExt.ComboboxGridColumn(CotNguoiGui, DABase.getDatabase().LoadDataSet("Select * from DM_NHAN_VIEN ").Tables[0], "ID", "NAME", "NGUOI_GUI");
            HelpGridColumn.CotReadOnlyDate(CotTG_Gui, "NGAY_GUI", PLConst.FORMAT_DATETIME_STRING);
            XtraGridSupportExt.TextRightColumn(CotLanXem, "SO_LAN_XEM");
            XtraGridSupportExt.TextRightColumn(CotLanTraLoi, "SO_LAN_TRA_LOI");
        }
        DMTreeGroup tree;
        public override void PLLoadFilterPart()
        {
            AppCtrl.InitTreeChonNhanVien_Choice1(NguoiGui, true);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            ngayLamViec.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            tree = AppCtrl.InitTreeChonDienDan(treeDienDan, true);
        }
        public override void InitColumDetail()
        {}
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
            FWWaitingMsg msg = new FWWaitingMsg();
            QueryBuilder query = new QueryBuilder(UpdateRow());
            if (tree != null && tree.SelectedNode != null)
            {
                if (tree.SelectedNode["IS_GROUP"].ToString() == "Y")
                {
                    query.addID("ID_NHOM_DIEN_DAN", treeDienDan._getSelectedID());
                }
                else
                {
                    query.addID("ID_CHUYEN_MUC", treeDienDan._getSelectedID());
                }
            }
            query.addID("NGUOI_GUI", NguoiGui._getSelectedID());
            query.addDateFromTo("NGAY_GUI", ngayLamViec.FromDate, ngayLamViec.ToDate);
            msg.Finish();
            DataSet ds = new DataSet();
            if (tree != null && tree.SelectedNode != null)
            {
                if (tree.SelectedNode["IS_GROUP"].ToString() == "Y")
                {
                    ds = DienDanPermission.I._LoadDataSetWithResPermission(query, "ID_NHOM_DIEN_DAN", treeDienDan._getSelectedID());
                }
                else
                {
                    ds = DienDanPermission.I._LoadDataSetWithResPermission(query, "ID_CHUYEN_MUC", treeDienDan._getSelectedID());
                }
            }
            else
            {
                ds = DienDanPermission.I._LoadDataSetWithResPermission(query, "ID_CHUYEN_MUC", -1);
            }
            if (ds != null && ds.Tables.Count > 0)
                gridControlMaster.DataSource = ds.Tables[0];
            return null;
        }
        public override void ShowViewForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row != null)
            {
                frmViewListThreadFR frm = new frmViewListThreadFR(HelpNumber.ParseInt64(row["ID"]), row["DIEN_DAN"].ToString(), row["C_MUC"].ToString(),
                    HelpNumber.ParseInt64(row["ID_CHUYEN_MUC"]), HelpNumber.ParseInt64(row["ID_DD"]), row["CHU_DE"].ToString());
                frm._UpdateNumberOfAnswer += delegate(bool isIncrease) {
                    if (isIncrease)
                        row["SO_LAN_TRA_LOI"] = HelpNumber.ParseInt32(row["SO_LAN_TRA_LOI"]) + 1;
                    else row["SO_LAN_TRA_LOI"] = HelpNumber.ParseInt32(row["SO_LAN_TRA_LOI"]) - 1;
                };
                HelpProtocolForm.ShowModalDialog(this, frm, true);
                row["SO_LAN_XEM"] = HelpNumber.ParseInt32(row["SO_LAN_XEM"]) + 1;
            }
        }

        public override void ShowUpdateForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row == null) return;
            if (DienDanPermission.I._checkPermissionRes(HelpNumber.ParseInt64(row["ID_CHUYEN_MUC"]), PermissionOfResource.RES_PERMISSION_TYPE.UPDATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền sửa bài viết thuộc chuyên mục \"" + row["C_MUC"] + "\" của nhóm diễn đàn \"" + row["DIEN_DAN"] + "\"");
                return;
            }
            frmBaiVietEtx frm = new frmBaiVietEtx(id);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }        
        public override long[] ShowAddForm()
        {
            frmBaiVietEtx frm= new frmBaiVietEtx();
            HelpProtocolForm.ShowModalDialog(this, frm);           
            return null;
        }
        public override bool XoaAction(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row == null) return false;
            if (DienDanPermission.I._checkPermissionRes(HelpNumber.ParseInt64(row["ID_CHUYEN_MUC"]), PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa bài viết thuộc chuyên mục \"" + row["C_MUC"] + "\" của nhóm diễn đàn \"" + row["DIEN_DAN"] + "\"");
                return false;
            }
            return DABaiViet.Instance.Delete(HelpNumber.ParseInt64(row["ID"]));
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        public override void HookFocusRow()
        {
            if (this.gridViewMaster.FocusedRowHandle >= 0) this.barSubItem1.Enabled = true;
            else this.barSubItem1.Enabled = false;
        }
        #endregion

        #region Các hàm chức năng khác 
      
        public override string UpdateRow()
        {
            return @"SELECT B.*,(SELECT NAME FROM CHUYEN_MUC C WHERE C.ID=B.ID_CHUYEN_MUC) C_MUC,
                (SELECT ID FROM NHOM_DIEN_DAN N WHERE N.ID=B.ID_NHOM_DIEN_DAN) ID_DD,
                (SELECT NAME FROM NHOM_DIEN_DAN N WHERE N.ID=B.ID_NHOM_DIEN_DAN) DIEN_DAN,
                (SELECT NAME FROM DM_NHAN_VIEN NV WHERE NV.ID=B.NGUOI_GUI) N_GUI
                FROM BAI_VIET B 
                WHERE (ID_BAI_VIET_PARENT is null OR ID_BAI_VIET_PARENT<=0) AND 1=1";
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
