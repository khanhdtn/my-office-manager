using System;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;

namespace ProtocolVN.Framework.Win
{
    /// <summary>
    /// DUYVT: Màn hình quản lý tài nguyên - 
    /// Phát triển dựa trên form frmPhanQuyenNhanVienDoiTac
    /// </summary>
    public partial class frmPhanQuyenNhanVienTaiNguyen : XtraFormPL
    {
        #region "Variables"
        private DMTreeGroupElement dmTreeTN = null;
        private DataSet dsNguoiDung = null;
        private DataTable dtPhanQuyenNhomTaiNguyen;
        private DataTable dtPhanQuyenTaiNguyen;
        private TaiNguyen tainguyen;
        private string title = "";
        #endregion

        public frmPhanQuyenNhanVienTaiNguyen(TaiNguyen tainguyen, string title)
        {
            InitializeComponent();
            this.tainguyen = tainguyen;
            this.title = title;
            
            InitNguoiDung();
            InitPhanQuyenNhomTaiNguyen();
            InitPhanQuyenTaiNguyen();
            InitCayTaiNguyen();
            HelpXtraForm.SetCloseForm(this, this.btnDong, true);
            HelpPhieuForm.InitBtnPhieu(this, true, null, null, null, btnLuu, null, btnDong);
            lblMessage.Text = "";
            SetToolTips();
            UpdateLayout();
        }

        #region "Người dùng"

        public void InitNguoiDung()
        {
            // Init grid người dùng
            ((PLGridView)gridViewNguoiDung)._SetUserLayout("VIEW");
            HelpGridColumn.CotTextLeft(CotUserTenTruyCap, "USERNAME");
            HelpGridColumn.CotTextLeft(CotUserHoTen, "TENNV");
            HelpGridColumn.CotTextLeft(CotUserPhongBan, "TENPHONGBAN");
            HelpGridColumn.CotCheckEdit(CotUserApDung, tainguyen.FieldUserAllow);

            // Init grid Chọn đối tượng
            HelpGridColumn.CotTextLeft(gridColumnNhomTaiNguyenName, "");
            gridViewNguoiDung.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            dsNguoiDung = HelpDB.getDatabase().LoadDataSet(
                @"select case when x." + tainguyen.FieldUserAllow
                    + @" is null then 'N' else x." + tainguyen.FieldUserAllow + @" end "
                    + tainguyen.FieldUserAllow + @", g.username, g.tennv, g.tenphongban, g.user_id as userid
                from (select us.userid as user_id, us.username, nv.name as tennv, 
                    nv.id as nv_id, depart.name as tenphongban from user_Cat us
                    inner join dm_nhan_vien nv on us.employee_id=nv.id
                    inner join department depart on nv.department_id=depart.id
                order by lower(us.username)) g 
                    left join user_cat_ex x on g.user_id=x.userid", "user_cat_ex");
            if (dsNguoiDung != null && dsNguoiDung.Tables.Count > 0)
            {
                gridControlNguoiDung.DataSource = dsNguoiDung.Tables[0];
                gridViewNguoiDung.BestFitColumns();
                gridViewNguoiDung.ExpandAllGroups();
            }
        }

        private void gridViewNguoiDung_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            this.ApplyFilter(gridViewNhomTaiNguyen);
            this.ApplyFilter(gridViewTaiNguyen);
            DataRow rUser = gridViewNguoiDung.GetFocusedDataRow();
            ApDungPhanQuyen = (rUser != null && rUser[tainguyen.FieldUserAllow].ToString() == "Y");
            SetToolTips();
            UpdateLayout();
        }

        private void gridViewNguoiDung_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2 && e.Column == CotUserApDung)
            {
                DataRow r = gridViewNguoiDung.GetDataRow(e.RowHandle);
                if (r != null)
                {
                    if (r[CotUserApDung.FieldName].ToString() == "N")
                        r[CotUserApDung.FieldName] = "Y";
                    else
                        r[CotUserApDung.FieldName] = "N";
                    ApDungPhanQuyen = r[CotUserApDung.FieldName].ToString() == "Y";
                    foreach (DataRow rDT in dtPhanQuyenTaiNguyen.Select("USERID=" + r["USERID"]))
                    {
                        rDT[tainguyen.FieldUserAllow] = r[CotUserApDung.FieldName];
                    }
                    foreach (DataRow rNDT in dtPhanQuyenNhomTaiNguyen.Select("USERID=" + r["USERID"]))
                    {
                        rNDT[tainguyen.FieldUserAllow] = r[CotUserApDung.FieldName];
                    }
                }
            }
        }

        #endregion

        #region "Phân quyền"

        private void xtraTabControlPhanQuyen_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            this.ApplyFilter(gridViewNhomTaiNguyen);
            this.ApplyFilter(gridViewTaiNguyen);
            SetToolTips();
        }

        #region "Nhóm tài nguyên"

        private void InitPhanQuyenNhomTaiNguyen()
        {
            gridViewNhomTaiNguyen.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            gridViewNhomTaiNguyen.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gridViewNhomTaiNguyen.OptionsView.ShowVertLines = false;
            HelpGridColumn.CotTextLeft(gridColumnNhomTaiNguyenName, "NAME");
            HelpGridColumn.CotCheckEdit(gridColumnNhomIsCreate, "ISCREATE_BIT");
            HelpGridColumn.CotCheckEdit(gridColumnNhomIsRead, "ISREAD_BIT");
            HelpGridColumn.CotCheckEdit(gridColumnNhomIsUpdate, "ISUPDATE_BIT");
            HelpGridColumn.CotCheckEdit(gridColumnNhomIsDelete, "ISDELETE_BIT");
            HelpGridColumn.CotCheckEdit(gridColumnNhomFull, "ISFULL_BIT");
            CotImageNhomTaiNguyen(gridColumnNhomTaiNguyenIDRoot, "ID_ROOT");
            gridColumnNhomTaiNguyenUser_ID.FieldName = "USERID";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(
                @"Select us.USERID, us." + tainguyen.RefFieldPerResGroupName 
                + @", us.ISCREATE_BIT, us.ISREAD_BIT, us.ISUPDATE_BIT, us.ISDELETE_BIT, 
                (case when (us.ISCREATE_BIT='Y' and us.ISREAD_BIT='Y' and us.ISUPDATE_BIT='Y' 
                    and us.ISDELETE_BIT='Y') then 'Y' else 'N' end) as ISFULL_BIT, 
                ndt.name, ndt.id_root, 'Y' " + tainguyen.FieldUserAllow + @"
                from " + tainguyen.PerTableResGroupName + @" us
                left join " + tainguyen.DMTableResGroupName + " ndt on us." 
                            + tainguyen.RefFieldPerResGroupName + "=ndt.id", tainguyen.PerTableResGroupName);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].PrimaryKey = new DataColumn[] {
                    ds.Tables[0].Columns["USERID"],
                    ds.Tables[0].Columns[tainguyen.RefFieldPerResGroupName] };
                dtPhanQuyenNhomTaiNguyen = ds.Tables[0];
                gridControlNhomTaiNguyen.DataSource = dtPhanQuyenNhomTaiNguyen;
                this.ApplyFilter(gridViewNhomTaiNguyen);
            }
        }

        private int AddPhanQuyenNhomTaiNguyen(TreeListNode treeNode, bool addChild)
        {
            if (treeNode == null) return 0;
            int countAdd = 0;
            DataRow rowUser = gridViewNguoiDung.GetFocusedDataRow();
            if (rowUser == null)
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng chọn người dùng!");
                return 0;
            }
            if (!dtPhanQuyenNhomTaiNguyen.Rows.Contains(new object[] { rowUser["USERID"], treeNode["ID"] }))
            {
                DataRow r = dtPhanQuyenNhomTaiNguyen.NewRow();
                r["USERID"] = rowUser["USERID"];
                r[tainguyen.FieldUserAllow] = rowUser[tainguyen.FieldUserAllow];
                r[tainguyen.RefFieldPerResGroupName] = treeNode["ID"];
                r["NAME"] = treeNode["NAME"];
                r["ISCREATE_BIT"] = "N";
                r["ISREAD_BIT"] = "N";
                r["ISUPDATE_BIT"] = "N";
                r["ISDELETE_BIT"] = "N";
                r["ISFULL_BIT"] = "N";
                r["ID_ROOT"] = treeNode["ID_ROOT"];

                dtPhanQuyenNhomTaiNguyen.Rows.Add(r);
                countAdd++;
            }
            if (addChild == true)
            {
                foreach (TreeListNode childNode in treeNode.Nodes)
                {
                    countAdd += AddPhanQuyenNhomTaiNguyen(childNode, true);
                }
            }
            if (countAdd > 0)
            {
                foreach (int select in gridViewNhomTaiNguyen.GetSelectedRows())
                {
                    gridViewNhomTaiNguyen.UnselectRow(select);
                }
                gridViewNhomTaiNguyen.FocusedRowHandle = gridViewNhomTaiNguyen.RowCount - 1;
                gridViewNhomTaiNguyen.SelectRows(gridViewNhomTaiNguyen.RowCount - countAdd, gridViewNhomTaiNguyen.FocusedRowHandle);
            }
            MSThemNhomTaiNguyen(countAdd, rowUser);
            return countAdd;
        }

        private void gridControlNhomTaiNguyen_DragDrop(object sender, DragEventArgs e)
        {
            //AddPhanQuyenNhomTaiNguyen(e.Data.GetData(typeof(TreeListNode)) as TreeListNode, checkChonNhomCon.Checked);

        }
        private void gridControlNhomTaiNguyen_DragOver(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(TreeListNode)))
            //{
            //    e.Effect = DragDropEffects.All;
            //}
            //else if (e.Data.GetDataPresent(typeof(DataRow[])))
            //{
            //    xtraTabControlPhanQuyen.SelectedTabPage = xtraTabPageTaiNguyen;
            //}
            //else
            //{
            //    MSDuLieuKoHopLe();
            //    e.Effect = DragDropEffects.None;
            //}
        }

        private void gridViewNhomTaiNguyen_MouseLeave(object sender, EventArgs e)
        {
            //gridControlTaiNguyen.DoDragDrop(GetSelectRows(gridViewNhomTaiNguyen), DragDropEffects.Move);
        }
        
        private void gridViewNhomTaiNguyen_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            SetCheckAllColumnStatus(gridViewNhomTaiNguyen, e);
        }

        private void gridViewNhomTaiNguyen_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                try
                {
                    GridViewColumnMenu menu = (GridViewColumnMenu)e.Menu;
                    if (menu.Column == null)
                    {
                        e.Allow = false;
                        return;
                    }
                    DXMenuCheckItem menuItemCheckAll = new DXMenuCheckItem("Chọn tất cả",
                               IsShowCheckForCheckAllItem(gridViewNhomTaiNguyen, menu.Column), null,
                               new EventHandler(ProcessCheckAllNhom));
                    menuItemCheckAll.BeginGroup = true;
                    DXMenuCheckItem menuItemUnCheckAll = new DXMenuCheckItem("Bỏ chọn tất cả",
                               IsShowCheckForUnCheckAllItem(gridViewNhomTaiNguyen, menu.Column), null,
                               new EventHandler(ProcessUnCheckAllNhom));
                    if (menu.Column.FieldName == "ISCREATE_BIT"
                        || menu.Column.FieldName == "ISREAD_BIT"
                        || menu.Column.FieldName == "ISUPDATE_BIT"
                        || menu.Column.FieldName == "ISDELETE_BIT"
                        || menu.Column.FieldName == "ISFULL_BIT")
                    {
                        menuItemCheckAll.Tag = menu.Column;
                        menuItemUnCheckAll.Tag = menu.Column;
                        menu.Items.Add(menuItemCheckAll);
                        menu.Items.Add(menuItemUnCheckAll);
                    }
                }
                catch
                {
                    HelpMsgBox.ShowErrorMessage(
                        "Chương trình xảy ra lỗi.\nXin vui lòng liên hệ với quản trị hệ thống!");
                    e.Allow = false;
                }
            }
        }

        private void ProcessCheckAllNhom(object sender, System.EventArgs e)
        {
            DXMenuCheckItem Item = (DXMenuCheckItem)sender;
            GridColumn column = (GridColumn)Item.Tag;
            ProcessCheckAll(gridViewNhomTaiNguyen, column);
        }

        private void ProcessUnCheckAllNhom(object sender, System.EventArgs e)
        {
            DXMenuCheckItem Item = (DXMenuCheckItem)sender;
            GridColumn column = (GridColumn)Item.Tag;
            ProcessUnCheckAll(gridViewNhomTaiNguyen, column);
        }

        #endregion

        #region "Tài nguyên"

        private void InitPhanQuyenTaiNguyen()
        {
            gridViewTaiNguyen.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            gridViewTaiNguyen.OptionsView.ShowFilterPanelMode = ShowFilterPanelMode.Never;
            gridViewTaiNguyen.OptionsView.ShowVertLines = false;

            HelpGridColumn.CotTextLeft(gridColumnTaiNguyenName, "NAME");
            HelpGridColumn.CotCheckEdit(gridColumnIsCreate, "ISCREATE_BIT");
            HelpGridColumn.CotCheckEdit(gridColumnIsRead, "ISREAD_BIT");
            HelpGridColumn.CotCheckEdit(gridColumnIsUpdate, "ISUPDATE_BIT");
            HelpGridColumn.CotCheckEdit(gridColumnIsDelete, "ISDELETE_BIT");
            HelpGridColumn.CotCheckEdit(gridColumnFull, "ISFULL_BIT");
            CotImageTaiNguyen(gridColumnTaiNguyenNDT_ROOT, "NDT_ROOT");
            gridColumnTaiNguyenUser_ID.FieldName = "USERID";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(
                @"Select us.USERID, us." + tainguyen.RefFieldPerResName
                + @", us.ISCREATE_BIT, us.ISREAD_BIT, us.ISUPDATE_BIT, us.ISDELETE_BIT, 
                (case when (us.ISCREATE_BIT='Y' and us.ISREAD_BIT='Y' and us.ISUPDATE_BIT='Y' 
                    and us.ISDELETE_BIT='Y') then 'Y' else 'N' end) as ISFULL_BIT, 
                ndt.id_root as ndt_root, dt.NAME, 'Y' " + tainguyen.FieldUserAllow + @"
                from " + tainguyen.PerTableResName + @" us
                left join " + tainguyen.DMTableResName + @" dt on dt.id=us." 
                            + tainguyen.RefFieldPerResName + @"
                left join " + tainguyen.DMTableResGroupName + " ndt on dt." 
                            + tainguyen.RefFieldDMResName + "=ndt.id", tainguyen.PerTableResName);
            if (ds != null && ds.Tables.Count > 0)
            {
                ds.Tables[0].PrimaryKey = new DataColumn[] {
                    ds.Tables[0].Columns["USERID"], 
                    ds.Tables[0].Columns[tainguyen.RefFieldPerResName] };

                dtPhanQuyenTaiNguyen = ds.Tables[0];
                gridControlTaiNguyen.DataSource = dtPhanQuyenTaiNguyen;
                this.ApplyFilter(gridViewTaiNguyen);
            }
        }

        private int AddPhanQuyenTaiNguyen(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return 0;
            DataRow rowUser = gridViewNguoiDung.GetFocusedDataRow();
            if (rowUser == null)
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng chọn người dùng!");
                return 0;
            }
            int countAdd = 0;
            foreach (DataRow row in rows)
            {
                if (dtPhanQuyenTaiNguyen.Rows.Contains(
                    new object[] { rowUser["USERID"], row["ID"] })) continue;
                DataRow r = dtPhanQuyenTaiNguyen.NewRow();
                r["USERID"] = rowUser["USERID"];
                r[tainguyen.FieldUserAllow] = rowUser[tainguyen.FieldUserAllow];
                r[tainguyen.RefFieldPerResName] = row["ID"];
                r["NAME"] = row["NAME"];
                r["ISCREATE_BIT"] = "N";
                r["ISREAD_BIT"] = "N";
                r["ISUPDATE_BIT"] = "N";
                r["ISDELETE_BIT"] = "N";
                r["ISFULL_BIT"] = "N";
                if (dmTreeTN.TreeList_1.FocusedNode != null)
                {
                    r["NDT_ROOT"] = dmTreeTN.TreeList_1.FocusedNode["ID_ROOT"];
                }
                dtPhanQuyenTaiNguyen.Rows.Add(r);
                countAdd++;
            }
            if (countAdd > 0)
            {
                foreach (int select in gridViewTaiNguyen.GetSelectedRows())
                {
                    gridViewTaiNguyen.UnselectRow(select);
                }
                gridViewTaiNguyen.FocusedRowHandle = gridViewTaiNguyen.RowCount - 1;
                gridViewTaiNguyen.SelectRows(
                    gridViewTaiNguyen.RowCount - countAdd, gridViewTaiNguyen.FocusedRowHandle);
            }
            MSThemTaiNguyen(countAdd, rowUser);
            return countAdd;
        }

        private void gridControlTaiNguyen_DragDrop(object sender, DragEventArgs e)
        {
            //AddPhanQuyenTaiNguyen(e.Data.GetData(typeof(DataRow[])) as DataRow[]);
        }

        private void gridControlTaiNguyen_DragOver(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(DataRow[])))
            //{
            //    e.Effect = DragDropEffects.Copy;
            //}
            //else if (e.Data.GetDataPresent(typeof(TreeListNode)))
            //{
            //    xtraTabControlPhanQuyen.SelectedTabPage = xtraTabPageNhomTaiNguyen;
            //}
            //else
            //{
            //    MSDuLieuKoHopLe();
            //    e.Effect = DragDropEffects.None;
            //}
        }

        private void gridViewTaiNguyen_MouseLeave(object sender, EventArgs e)
        {
            //gridControlTaiNguyen.DoDragDrop(GetSelectRows(gridViewTaiNguyen), DragDropEffects.Move);
        }

        private void gridViewTaiNguyen_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            SetCheckAllColumnStatus(gridViewTaiNguyen, e);
        }

        private void gridViewTaiNguyen_ShowGridMenu(object sender, GridMenuEventArgs e)
        {
            if (e.MenuType == GridMenuType.Column)
            {
                try
                {
                    GridViewColumnMenu menu = (GridViewColumnMenu)e.Menu;
                    if (menu.Column == null)
                    {
                        e.Allow = false;
                        return;
                    }
                    DXMenuCheckItem menuItemCheckAll = new DXMenuCheckItem("Chọn tất cả",
                               IsShowCheckForCheckAllItem(gridViewTaiNguyen, menu.Column), null,
                               new EventHandler(ProcessCheckAll));
                    menuItemCheckAll.BeginGroup = true;
                    DXMenuCheckItem menuItemUnCheckAll = new DXMenuCheckItem("Bỏ chọn tất cả",
                               IsShowCheckForUnCheckAllItem(gridViewTaiNguyen, menu.Column), null,
                               new EventHandler(ProcessUnCheckAll));
                    if (menu.Column.FieldName == "ISCREATE_BIT"
                        || menu.Column.FieldName == "ISREAD_BIT"
                        || menu.Column.FieldName == "ISUPDATE_BIT"
                        || menu.Column.FieldName == "ISDELETE_BIT"
                        || menu.Column.FieldName == "ISFULL_BIT")
                    {
                        menuItemCheckAll.Tag = menu.Column;
                        menuItemUnCheckAll.Tag = menu.Column;
                        menu.Items.Add(menuItemCheckAll);
                        menu.Items.Add(menuItemUnCheckAll);
                    }
                }
                catch
                {
                    HelpMsgBox.ShowErrorMessage(
                        "Chương trình xảy ra lỗi.\nXin vui lòng liên hệ với quản trị hệ thống!");
                    e.Allow = false;
                }
            }
        }

        private void ProcessCheckAll(object sender, System.EventArgs e)
        {
            DXMenuCheckItem Item = (DXMenuCheckItem)sender;
            GridColumn column = (GridColumn)Item.Tag;
            ProcessCheckAll(gridViewTaiNguyen, column);
        }

        private void ProcessUnCheckAll(object sender, System.EventArgs e)
        {
            DXMenuCheckItem Item = (DXMenuCheckItem)sender;
            GridColumn column = (GridColumn)Item.Tag;
            ProcessUnCheckAll(gridViewTaiNguyen, column);
        }

        #endregion

        #endregion

        #region "Cây tài nguyên"

        public void InitCayTaiNguyen()
        {
            dmTreeTN = (DMTreeGroupElement)tainguyen.DMRes.Init();
            dmTreeTN.btnAdd.Owner.Visible = false;
            dmTreeTN.TreeList_1.OptionsSelection.MultiSelect = true;
            dmTreeTN.gridView_1.OptionsSelection.MultiSelect = true;
            dmTreeTN.Location = new Point(0, 0);
            dmTreeTN.Dock = DockStyle.Fill;

            DockPanel dock = dmTreeTN.Controls["dockPanel1"] as DockPanel;
            if (dock != null)
            {
                if (dock.Controls.Count > 0 && dock.Controls[0] is ControlContainer)
                {
                    ControlContainer container = dock.Controls[0] as ControlContainer;
                    if (container.Controls.Count == 0) return;              
                    container.Controls[0].Dock = DockStyle.None;
                    checkChonNhomCon.Parent.Controls.Remove(checkChonNhomCon);
                    checkChonNhomCon.Dock = DockStyle.Top;
                    container.Controls.Add(checkChonNhomCon);
                    container.Controls[0].Dock = DockStyle.Fill;
                }
            }
            panelControl4.Controls.Add(dmTreeTN);
            dmTreeTN.gridView_1.GridControl.AllowDrop = true;
            dmTreeTN.gridView_1.Appearance.GroupPanel.Font = new Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Inch);
            dmTreeTN.gridView_1.Appearance.GroupPanel.Options.UseFont = true;
            dmTreeTN.gridView_1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            dmTreeTN.gridView_1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            dmTreeTN.TreeList_1.AllowDrop = false;
            dmTreeTN.TreeList_1.OptionsBehavior.DragNodes = true;

            dmTreeTN.gridView_1.MouseLeave += new EventHandler(gridView_1_MouseLeave);

            dmTreeTN.gridView_1.GridControl.DragOver += new DragEventHandler(GridControl_DragOver);
            dmTreeTN.gridView_1.GridControl.DragDrop += new DragEventHandler(GridControl_DragDrop);
            dmTreeTN.gridView_1.GridControl.DragLeave += new EventHandler(GridControl_DragLeave);

            dmTreeTN.TreeList_1.MouseLeave += new EventHandler(TreeList_1_MouseLeave);
            dmTreeTN.TreeList_1.DragDrop += new DragEventHandler(TreeList_1_DragDrop);
            dmTreeTN.TreeList_1.DragLeave += new EventHandler(TreeList_1_DragLeave);
            dmTreeTN.TreeList_1.DragEnter += new DragEventHandler(TreeList_1_DragEnter);
        }
       
        #region "TreeList"

        private void TreeList_1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow[])))
            {
                DataRow[] rowsDelete = e.Data.GetData(typeof(DataRow[])) as DataRow[];
                foreach (DataRow row in rowsDelete)
                {
                    row.Table.Rows.Remove(row);
                }
                MSXoaNhomTaiNguyen(rowsDelete.Length);
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void TreeList_1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow[])))
            {
                DataRow[] rows = e.Data.GetData(typeof(DataRow[])) as DataRow[];
                if (rows.Length == 0 || rows[0].Table.TableName != tainguyen.PerTableResGroupName)
                {
                    e.Effect = DragDropEffects.None;
                    MSDuLieuKoHopLe();

                }
                else
                {
                    lblMessage.Text = "";
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                if (!e.Data.GetDataPresent(typeof(TreeListNode)))
                    MSDuLieuKoHopLe();
                e.Effect = DragDropEffects.None;
            }
        }     

        private void TreeList_1_DragLeave(object sender, EventArgs e)
        {
            if (!this.CurrentPermision)
                MSNotPermision();
        }

        private void TreeList_1_MouseLeave(object sender, EventArgs e)
        {
            dmTreeTN.TreeList_1.DoDragDrop(dmTreeTN.TreeList_1.FocusedNode, DragDropEffects.All);
          
        }

        #endregion

        #region "GridView"

        private void GridControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow[])))
            {
                DataRow[] rowsDelete=e.Data.GetData(typeof(DataRow[])) as DataRow[];
                foreach (DataRow row in rowsDelete)
                {
                    row.Table.Rows.Remove(row);
                }
                MSXoaNhomTaiNguyen(rowsDelete.Length);
            }
        }

        private void GridControl_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow[])))
            {
                DataRow[] rows = e.Data.GetData(typeof(DataRow[])) as DataRow[];
                if (rows.Length == 0 || (rows.Length > 0 && rows[0].Table.TableName != tainguyen.PerTableResName))
                {
                    if (rows[0].Table.TableName != tainguyen.DMTableResName)
                        MSDuLieuKoHopLe();
                    e.Effect = DragDropEffects.None;
                }
                else
                {
                    lblMessage.Text = "";
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                if (!e.Data.GetDataPresent(typeof(Int64)))
                {
                    MSDuLieuKoHopLe();
                }
                e.Effect = DragDropEffects.None;
            }
        }

        private void GridControl_DragLeave(object sender, EventArgs e)
        {
            if (!this.CurrentPermision)
                MSNotPermision();
        }

        private void gridView_1_MouseLeave(object sender, EventArgs e)
        {
            dmTreeTN.gridView_1.GridControl.DoDragDrop(GetSelectRows(dmTreeTN.gridView_1), DragDropEffects.All);
          
        }

        #endregion

        #endregion

        #region "Sự kiện nút"

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageTaiNguyen)
                {
                    AddPhanQuyenTaiNguyen(GetSelectRows(dmTreeTN.gridView_1));
                }
                else if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageNhomTaiNguyen)
                {
                    AddPhanQuyenNhomTaiNguyen(dmTreeTN.TreeList_1.FocusedNode, checkChonNhomCon.Checked);
                }
            }
            catch
            {
                HelpMsgBox.ShowErrorMessage(
                        "Chương trình xảy ra lỗi.\nXin vui lòng liên hệ với quản trị hệ thống!");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageTaiNguyen)
            {
                this.DeleteSelectRows(gridViewTaiNguyen);
            }
            else if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageNhomTaiNguyen)
            {
                this.DeleteSelectRows(gridViewNhomTaiNguyen);
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageTaiNguyen)
                {
                    DataTable dt = dmTreeTN.gridView_1.GridControl.DataSource as DataTable;
                    DataRow[] rowsAll = new DataRow[dt.Rows.Count];
                    dt.Rows.CopyTo(rowsAll, 0);
                    AddPhanQuyenTaiNguyen(rowsAll);
                }
                else if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageNhomTaiNguyen)
                {
                    AddPhanQuyenNhomTaiNguyen(dmTreeTN.TreeList_1.Nodes[0], true);
                }
            }
            catch
            {
                HelpMsgBox.ShowErrorMessage(
                        "Chương trình xảy ra lỗi.\nXin vui lòng liên hệ với quản trị hệ thống!");
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageTaiNguyen)
            {
                gridViewTaiNguyen.SelectAll();
                this.DeleteSelectRows(gridViewTaiNguyen);
            }
            else if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageNhomTaiNguyen)
            {
                gridViewNhomTaiNguyen.SelectAll();
                this.DeleteSelectRows(gridViewNhomTaiNguyen);
            }
        }

        bool resultSave = true;
        private void btnLuu_Click(object sender, EventArgs e)
        {
            WaitingMsg.LongProcess(Save);
            if (resultSave == false)
            {
                HelpMsgBox.ShowNotificationMessage("Lưu không thành công!");
            }
            else
            {
                MSSaveSuccess();
            }
        }
       
        #endregion

        #region "Hàm hỗ trợ"

        private void SetCheckAllColumnStatus(PLGridView gridView, CellValueChangedEventArgs e)
        {
            DataRow row = gridView.GetDataRow(e.RowHandle);
            if (e.Column.FieldName == "ISFULL_BIT")
            {
                string bit_str = e.Value.ToString();
                row["ISFULL_BIT"] = bit_str;
                row["ISCREATE_BIT"] = bit_str;
                row["ISREAD_BIT"] = bit_str;
                row["ISUPDATE_BIT"] = bit_str;
                row["ISDELETE_BIT"] = bit_str;
            }
            else
            {
                string bit_str = e.Value.ToString();
                row[e.Column.FieldName] = bit_str;
                row["ISFULL_BIT"] = (row["ISCREATE_BIT"].ToString() == "N"
                    || row["ISREAD_BIT"].ToString() == "N"
                    || row["ISUPDATE_BIT"].ToString() == "N"
                    || row["ISDELETE_BIT"].ToString() == "N") ? "N" : "Y";
                gridView.UpdateCurrentRow();
            }            
        }

        private DataRow[] GetSelectRows(GridView gridView)
        {
            return Array.ConvertAll<int, DataRow>(gridView.GetSelectedRows(),
                new Converter<int, DataRow>(gridView.GetDataRow));
        }

        private void DeleteSelectRows(GridView gridView)
        {
            if (gridView.SelectedRowsCount == 0) return;
            int bfFocus = gridView.GetSelectedRows()[0];
            if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageTaiNguyen)
            {
                MSXoaTaiNguyen(gridView.SelectedRowsCount);
            }
            else
            {
                MSXoaNhomTaiNguyen(gridView.SelectedRowsCount);
            }
            gridView.DeleteSelectedRows();
            if (gridView.RowCount > 0)
            {
                if (gridView.GetNextVisibleRow(bfFocus) < 0
                    && gridView.GetPrevVisibleRow(bfFocus) >= 0)
                {
                    bfFocus--;
                }
                gridView.SelectRow(bfFocus);
                gridView.FocusedRowHandle = bfFocus;
            }
            ((DataTable)gridView.GridControl.DataSource).AcceptChanges();
        }

        private RepositoryItemImageComboBox CotImageNhomTaiNguyen(
            GridColumn colNhomTaiNguyen, string fieldName)
        {
            ImageCollection images = new ImageCollection();
            images.AddImage(ResourceMan.getImage48("DM_NhomKhachHang.png"));
            images.AddImage(ResourceMan.getImage48("DM_NhomNhaCungCap.png"));
            images.AddImage(ResourceMan.getImage48("DM_Nhom_KhachHang_NhaCungCap.png"));
            RepositoryItemImageComboBox icb = new RepositoryItemImageComboBox();
            icb.LargeImages = images;
            icb.Items.AddRange(new object[]{
                new ImageComboBoxItem((Int64)1,0),
                new ImageComboBoxItem((Int64)2,1),
                new ImageComboBoxItem((Int64)3,2)
            });
            icb.GlyphAlignment = HorzAlignment.Center;
            colNhomTaiNguyen.ColumnEdit = icb;
            colNhomTaiNguyen.Width = 20;
            colNhomTaiNguyen.OptionsColumn.FixedWidth = true;
            colNhomTaiNguyen.OptionsColumn.AllowEdit = false;
            colNhomTaiNguyen.OptionsColumn.AllowSize = false;
            colNhomTaiNguyen.FieldName = fieldName;
            colNhomTaiNguyen.OptionsColumn.ShowCaption = false;
            colNhomTaiNguyen.OptionsFilter.AllowFilter = false;
            colNhomTaiNguyen.OptionsFilter.AllowAutoFilter = false;
            colNhomTaiNguyen.Caption = ".";
            colNhomTaiNguyen.OptionsColumn.AllowFocus = false;
            return icb;
        }

        private RepositoryItemImageComboBox CotImageTaiNguyen(
            GridColumn colNhomTaiNguyen, string fieldName)
        {
            ImageCollection images = new ImageCollection();
            images.AddImage(ResourceMan.getImage48("DM_KhachHang.png"));
            images.AddImage(ResourceMan.getImage48("DM_NhaCungCap.png"));
            images.AddImage(ResourceMan.getImage48("DM_KhachHang_NhaCungCap.png"));
            RepositoryItemImageComboBox icb = new RepositoryItemImageComboBox();
            icb.LargeImages = images;
            icb.Items.AddRange(new object[]{
                new ImageComboBoxItem((Int64)1,0),
                new ImageComboBoxItem((Int64)2,1),
                new ImageComboBoxItem((Int64)3,2)
            });
            icb.GlyphAlignment = HorzAlignment.Center;
            colNhomTaiNguyen.ColumnEdit = icb;
            colNhomTaiNguyen.Width = 20;
            colNhomTaiNguyen.OptionsColumn.FixedWidth = true;
            colNhomTaiNguyen.OptionsColumn.AllowEdit = false;
            colNhomTaiNguyen.OptionsColumn.AllowSize = false;
            colNhomTaiNguyen.FieldName = fieldName;
            colNhomTaiNguyen.OptionsColumn.ShowCaption = false;
            colNhomTaiNguyen.OptionsFilter.AllowFilter = false;
            colNhomTaiNguyen.OptionsFilter.AllowAutoFilter = false;
            colNhomTaiNguyen.Caption = ".";
            colNhomTaiNguyen.OptionsColumn.AllowFocus = false;
            return icb;
        }

        private void ApplyFilter(GridView gridView)
        {
            try
            {
                if (gridView.GridControl.DataSource != null && gridControlNguoiDung.DataSource != null)
                {
                    gridView.ActiveFilterString = null;
                    gridView.ActiveFilterString = "[USERID]=" 
                        + gridViewNguoiDung.GetFocusedDataRow()["USERID"];
                }
                if (gridView.SelectedRowsCount == 0)
                {
                    gridView.FocusedRowHandle = 0;
                    gridView.SelectRow(0);
                }
            }
            catch { }
        }

        private bool ApDungPhanQuyen
        {
            set
            {
                btnAdd.Enabled = value;
                btnAddAll.Enabled = value;
                gridControlTaiNguyen.AllowDrop = value;
                gridControlNhomTaiNguyen.AllowDrop = value;
            }
        }

        private void Save()
        {
            DatabaseFB db = null;
            DbTransaction dbTrans = null;
            try
            {
                DataSet dsUserCatEx = HelpDB.getDatabase().LoadDataSet(
                    "select * from USER_CAT_EX", "USER_CAT_EX");
                DataSet dsPhanQuyenNDTSource = HelpDB.getDatabase().LoadDataSet(
                    "select * from " + tainguyen.PerTableResGroupName, tainguyen.PerTableResGroupName);
                //Đặt khóa chính
                dsPhanQuyenNDTSource.Tables[0].PrimaryKey = new DataColumn[] {
                dsPhanQuyenNDTSource.Tables[0].Columns["USERID"],
                dsPhanQuyenNDTSource.Tables[0].Columns[tainguyen.RefFieldPerResGroupName]};

                DataSet dsPhanQuyenDTSource = HelpDB.getDatabase().LoadDataSet(
                    "select * from " + tainguyen.PerTableResName, tainguyen.PerTableResName);
                //Đặt khóa chính
                dsPhanQuyenDTSource.Tables[0].PrimaryKey = new DataColumn[] {
                dsPhanQuyenDTSource.Tables[0].Columns["USERID"],
                dsPhanQuyenDTSource.Tables[0].Columns[tainguyen.RefFieldPerResName]};

                HelpDataSet.MergeDataSet(new string[] { "USERID" }, dsUserCatEx, dsNguoiDung);

                DataRow rFind = null;

                #region "Merge Dataset Nhóm tài nguyên"

                DataTable dtPhanQuyenNDTCoppy = dtPhanQuyenNhomTaiNguyen.Copy();
                dtPhanQuyenNDTCoppy.AcceptChanges();
                dtPhanQuyenNDTCoppy.PrimaryKey = new DataColumn[] {
                dtPhanQuyenNDTCoppy.Columns["USERID"],
                dtPhanQuyenNDTCoppy.Columns[tainguyen.RefFieldPerResGroupName]};
                foreach (DataRow rNDT in dsPhanQuyenNDTSource.Tables[0].Rows)
                {
                    rFind = dtPhanQuyenNDTCoppy.Rows.Find(
                        new object[] { rNDT["USERID"], rNDT[tainguyen.RefFieldPerResGroupName] });
                    if (rFind == null)  //Đã xóa trên lưới
                    {
                        rNDT.Delete();
                        continue;
                    }
                    if (rFind[tainguyen.FieldUserAllow].ToString() == "N")  //Không áp dụng phân quyền
                    {
                        rNDT.Delete();
                        continue;
                    }
                    if (rFind["ISCREATE_BIT"].ToString() != rNDT["ISCREATE_BIT"].ToString()
                        || rFind["ISREAD_BIT"].ToString() != rNDT["ISREAD_BIT"].ToString()
                        || rFind["ISUPDATE_BIT"].ToString() != rNDT["ISUPDATE_BIT"].ToString()
                        || rFind["ISDELETE_BIT"].ToString() != rNDT["ISDELETE_BIT"].ToString())
                    {
                        //Thực hiện cập nhật dòng thay đổi
                        rNDT["ISCREATE_BIT"] = rFind["ISCREATE_BIT"];
                        rNDT["ISREAD_BIT"] = rFind["ISREAD_BIT"];
                        rNDT["ISUPDATE_BIT"] = rFind["ISUPDATE_BIT"];
                        rNDT["ISDELETE_BIT"] = rFind["ISDELETE_BIT"];
                    }
                    else
                    {
                        //Xóa đi dòng không thay đổi, chỉ chừa lại dòng thêm mới
                        rFind.Delete();
                    }
                }
                dtPhanQuyenNDTCoppy.AcceptChanges();
                //Lúc này chỉ còn lại dòng thêm mới và bị thay đổi
                foreach (DataRow rNDTnew in dtPhanQuyenNDTCoppy.Rows)
                {
                    if (rNDTnew[tainguyen.FieldUserAllow].ToString() == "N") continue;
                    rFind = dsPhanQuyenNDTSource.Tables[0].Rows.Find(
                        new object[] { rNDTnew["USERID"], rNDTnew[tainguyen.RefFieldPerResGroupName] });
                    if (rFind == null)
                    {
                        //Trường hợp là dòng thêm mới
                        rNDTnew.SetAdded();
                        dsPhanQuyenNDTSource.Tables[0].ImportRow(rNDTnew);
                    }
                    else
                    {
                        //Trường hợp là dòng bị thay đổi
                        rFind["ISCREATE_BIT"] = rNDTnew["ISCREATE_BIT"];
                        rFind["ISREAD_BIT"] = rNDTnew["ISREAD_BIT"];
                        rFind["ISUPDATE_BIT"] = rNDTnew["ISUPDATE_BIT"];
                        rFind["ISDELETE_BIT"] = rNDTnew["ISDELETE_BIT"];
                    }
                }

                #endregion

                #region "Merge Tài nguyên"

                DataTable dtPhanQuyenDTCoppy = dtPhanQuyenTaiNguyen.Copy();
                dtPhanQuyenDTCoppy.AcceptChanges();
                dtPhanQuyenDTCoppy.PrimaryKey = new DataColumn[] {
                dtPhanQuyenDTCoppy.Columns["USERID"],
                dtPhanQuyenDTCoppy.Columns[tainguyen.RefFieldPerResName]};
                foreach (DataRow rDT in dsPhanQuyenDTSource.Tables[0].Rows)
                {
                    rFind = dtPhanQuyenDTCoppy.Rows.Find(
                        new object[] { rDT["USERID"], rDT[tainguyen.RefFieldPerResName] });
                    if (rFind == null)
                    {
                        //Trường hợp đã xóa trên lưới
                        rDT.Delete();
                        continue;
                    }
                    if (rFind[tainguyen.FieldUserAllow].ToString() == "N")
                    {
                        //Trường hợp không áp dụng phân quyền
                        rDT.Delete();
                        continue;
                    }
                    if(rFind["ISCREATE_BIT"].ToString() != rDT["ISCREATE_BIT"].ToString()
                        || rFind["ISREAD_BIT"].ToString() != rDT["ISREAD_BIT"].ToString()
                        || rFind["ISUPDATE_BIT"].ToString() != rDT["ISUPDATE_BIT"].ToString()
                        || rFind["ISDELETE_BIT"].ToString() != rDT["ISDELETE_BIT"].ToString())
                    {
                        //Thực hiện cập nhật dòng thay đổi
                        rDT["ISCREATE_BIT"] = rFind["ISCREATE_BIT"];
                        rDT["ISREAD_BIT"] = rFind["ISREAD_BIT"];
                        rDT["ISUPDATE_BIT"] = rFind["ISUPDATE_BIT"];
                        rDT["ISDELETE_BIT"] = rFind["ISDELETE_BIT"];
                    }
                    else
                    {
                        //Xóa đi dòng không thay đổi, chỉ chừa lại dòng thêm mới
                        rFind.Delete();
                    }
                }
                dtPhanQuyenDTCoppy.AcceptChanges();
                //Lúc này chỉ còn lại dòng thêm mới và bị thay đổi
                foreach (DataRow rDTnew in dtPhanQuyenDTCoppy.Rows)
                {
                    if (rDTnew[tainguyen.FieldUserAllow].ToString() == "N") continue;
                    rFind = dsPhanQuyenDTSource.Tables[0].Rows.Find(
                        new object[] { rDTnew["USERID"], rDTnew[tainguyen.RefFieldPerResName] });
                    if (rFind == null)
                    {
                        //Trường hợp là dòng thêm mới
                        rDTnew.SetAdded();
                        dsPhanQuyenDTSource.Tables[0].ImportRow(rDTnew);
                    }
                    else
                    {
                        //Trường hợp là dòng bị thay đổi
                        rFind["ISCREATE_BIT"] = rDTnew["ISCREATE_BIT"];
                        rFind["ISREAD_BIT"] = rDTnew["ISREAD_BIT"];
                        rFind["ISUPDATE_BIT"] = rDTnew["ISUPDATE_BIT"];
                        rFind["ISDELETE_BIT"] = rDTnew["ISDELETE_BIT"];
                    }
                }

                #endregion

                db = HelpDB.getDatabase();
                dbTrans = PLTransaction.BeginTrans(db);
                bool flag = true;

                if (db.UpdateDataSet(dsUserCatEx, dbTrans) == false)
                {
                    flag = false;
                }
                else if (db.UpdateDataSet(dsPhanQuyenNDTSource, dbTrans) == false)
                {
                    flag = false;
                }
                else if (db.UpdateDataSet(dsPhanQuyenDTSource, dbTrans) == false)
                {
                    flag = false;
                }
                if (flag == true)
                {
                    PLTransaction.Commit(dbTrans);
                    InitPhanQuyenTaiNguyen();
                    InitPhanQuyenNhomTaiNguyen();
                    dsNguoiDung.AcceptChanges();
                    resultSave = true;
                }
                else
                {
                    PLTransaction.Rollback(dbTrans);
                    resultSave = false;
                }
            }
            catch
            {
                PLTransaction.Rollback(dbTrans);
                resultSave = false;
            }           
        }

        private void MSDuLieuKoHopLe()
        {
            lblMessage.Text = "Dữ liệu đang kéo không hợp lệ.";
        }

        private void MSThemTaiNguyen(int sodong,DataRow rowUser)
        {
            lblMessage.Text = string.Format("Vừa thêm quyền trên {0} " 
                + tainguyen.ResName.ToLower() + " cho người dùng {1}.", 
                sodong, rowUser["USERNAME"].ToString().ToUpper());
        }

        private void MSThemNhomTaiNguyen(int sodong, DataRow rowUser)
        {
            lblMessage.Text = string.Format("Vừa thêm quyền trên {0} nhóm " 
                + tainguyen.ResName.ToLower() + " cho người dùng {1}.", 
                sodong, rowUser["USERNAME"].ToString().ToUpper());
        }

        private void MSXoaNhomTaiNguyen(int sodong)
        {
            lblMessage.Text = string.Format("Vừa xóa quyền trên {0} nhóm " 
                + tainguyen.ResName.ToLower() + " của người dùng {1}.", 
                sodong, gridViewNguoiDung.GetFocusedDataRow()["USERNAME"].ToString().ToUpper());
        }

        private void MSXoaTaiNguyen(int sodong)
        {
            lblMessage.Text = string.Format("Vừa xóa quyền trên {0} " 
                + tainguyen.ResName.ToLower() + " của người dùng {1}.", 
                sodong, gridViewNguoiDung.GetFocusedDataRow()["USERNAME"].ToString().ToUpper());
        }     
 
        private void MSNotPermision()
        {       
            lblMessage.Text = string.Format("Không áp dụng phân quyền cho {0}.", 
                gridViewNguoiDung.GetFocusedDataRow()["USERNAME"].ToString().ToUpper());
        }

        private void MSSaveSuccess()
        {
            lblMessage.Text = "Đã lưu dữ liệu.";
        }

        private bool CurrentPermision
        {
            get
            {
                return gridViewNguoiDung.GetFocusedDataRow()[tainguyen.FieldUserAllow].ToString() == "Y";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        private void lblMessage_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            if (lblMessage.Text != "") timer1.Start();
        }

        private void SetToolTips()
        {
            string nameNguoiDung = gridViewNguoiDung.GetFocusedDataRow()["TENNV"].ToString();
            if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageTaiNguyen)
            {
                btnAdd.ToolTip = "Thêm phân quyền trên " + tainguyen.ResName.ToLower() 
                    + " cho người dùng " + nameNguoiDung;
                btnAddAll.ToolTip = "Thêm phân quyền trên tất cả " + tainguyen.ResName.ToLower() 
                    + " cho người dùng " + nameNguoiDung;
                btnRemove.ToolTip = "Xóa phân quyền trên " + tainguyen.ResName.ToLower() 
                    + " của người dùng " + nameNguoiDung;
                btnRemoveAll.ToolTip = "Xóa phân quyền trên tất cả " + tainguyen.ResName.ToLower() 
                    + " của người dùng " + nameNguoiDung;
            }
            else if (xtraTabControlPhanQuyen.SelectedTabPage == xtraTabPageNhomTaiNguyen)
            {
                btnAdd.ToolTip = "Thêm phân quyền trên nhóm " + tainguyen.ResName.ToLower()
                    + " cho người dùng " + nameNguoiDung;
                btnAddAll.ToolTip = "Thêm phân quyền trên tất cả nhóm " 
                    + tainguyen.ResName.ToLower() + " cho người dùng " + nameNguoiDung;
                btnRemove.ToolTip = "Xóa phân quyền trên nhóm " 
                    + tainguyen.ResName.ToLower() + " của người dùng " + nameNguoiDung;
                btnRemoveAll.ToolTip = "Xóa phân quyền trên tất cả nhóm " 
                    + tainguyen.ResName.ToLower() + " của người dùng " + nameNguoiDung;
            }
        }

        private void UpdateLayout()
        {
            string nameNguoiDung = gridViewNguoiDung.GetFocusedDataRow()["TENNV"].ToString();
            gridViewNhomTaiNguyen.GroupPanelText = "Người dùng: " + nameNguoiDung
                + " - Danh sách nhóm " + tainguyen.ResName.ToLower() + " được chọn";
            gridViewTaiNguyen.GroupPanelText = "Người dùng: " + nameNguoiDung
                + " - Danh sách " + tainguyen.ResName.ToLower() + " được chọn";

            gridColumnNhomTaiNguyenName.Caption =
                "Nhóm " + tainguyen.ResName.ToLower() + " được chọn";
            gridColumnTaiNguyenName.Caption =
                UpperStartChar(tainguyen.ResName) + " được chọn";

            xtraTabPageTaiNguyen.Text = UpperStartChar(tainguyen.ResName);
            xtraTabPageNhomTaiNguyen.Text = "Nhóm " + tainguyen.ResName.ToLower();

            btnDong.ToolTip = "Đóng màn hình " + title.ToLower();
            this.Text = title;
        }

        private string UpperStartChar(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1).ToLower();
        }

        private bool IsShowCheckForCheckAllItem(PLGridView gridView, GridColumn column)
        {            
            DataTable source = (DataTable)gridView.GridControl.DataSource;
            foreach (DataRow row in source.Rows)
                if (row[column.FieldName].ToString() == "N")
                    return false;
            return true;
        }

        private bool IsShowCheckForUnCheckAllItem(PLGridView gridView, GridColumn column)
        {
            DataTable source = (DataTable)gridView.GridControl.DataSource;
            foreach (DataRow row in source.Rows)
                if (row[column.FieldName].ToString() == "Y")
                    return false;
            return true;
        }

        private void ProcessCheckAll(PLGridView gridView, GridColumn column)
        {
            DataTable source = (DataTable)gridView.GridControl.DataSource;
            foreach (DataRow row in source.Rows)
            {
                if (column.FieldName == "ISFULL_BIT")
                {
                    row["ISFULL_BIT"] = "Y";
                    row["ISCREATE_BIT"] = "Y";
                    row["ISREAD_BIT"] = "Y";
                    row["ISUPDATE_BIT"] = "Y";
                    row["ISDELETE_BIT"] = "Y";
                }
                else
                {
                    row[column.FieldName] = "Y";
                    if (row["ISCREATE_BIT"].ToString() == "Y"
                        && row["ISREAD_BIT"].ToString() == "Y"
                        && row["ISUPDATE_BIT"].ToString() == "Y"
                        && row["ISDELETE_BIT"].ToString() == "Y")
                        row["ISFULL_BIT"] = "Y";
                }
            }
        }

        private void ProcessUnCheckAll(PLGridView gridView, GridColumn column)
        {
            DataTable source = (DataTable)gridView.GridControl.DataSource;
            foreach (DataRow row in source.Rows)
            {
                if (column.FieldName == "ISFULL_BIT")
                {
                    row["ISFULL_BIT"] = "N";
                    row["ISCREATE_BIT"] = "N";
                    row["ISREAD_BIT"] = "N";
                    row["ISUPDATE_BIT"] = "N";
                    row["ISDELETE_BIT"] = "N";
                }
                else
                {
                    row[column.FieldName] = "N";
                    row["ISFULL_BIT"] = "N";
                }
            }
        }

        #endregion
    }
}