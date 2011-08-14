using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraNavBar;
using DevExpress.XtraGrid.Columns;
using DAO;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Common;
using DTO;

namespace office
{
    public partial class frmDanhBaQL : XtraFormPL,IFormRefresh
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDanhBaQL).FullName,
                PMSupport.UpdateTitle("Danh bạ địa chỉ", Status),
                ParentID, true,
                typeof(frmDanhBaQL).FullName,
                true, IsSep, "mnsNotePad.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private long Selected_Loai_Danh_Ba;
        private NavBarItem Selected_NavBarItem;
        DODanhBa doDanhBa = new DODanhBa();
        private DataSet gridDataSet = new DataSet();
        private bool finish_load_nav = false;
        private int select_index_nav=-1;
        private DataTable Table_Field_Name;
        private DataSet ds1;
        private DXErrorProvider error;
        private bool IsKhongLuu = false;
        private bool IsSuaNhom = false;
        DataRow[] Rows_Field_Names, Rows_Columms_Size, Columns_Size;
        NavBarItemLink SelectItem;
        #endregion

        #region Hàm dựng
        public frmDanhBaQL()
        {
            InitializeComponent();
            this.barButtonItemThemNhom.Glyph = FWImageDic.ADD_IMAGE20;
            this.barButtonItemXoaNhom.Glyph = FWImageDic.DELETE_IMAGE20;
            this.barButtonItemDoiTenNhom.Glyph = FWImageDic.EDIT_IMAGE20;
            this.barButtonItemThemNguoiLL.Glyph = FWImageDic.ADD_IMAGE20;
            this.barButtonItemXoaNguoiLL.Glyph = FWImageDic.DELETE_IMAGE20;
            this.barButtonItemSuaNguoiLL.Glyph = FWImageDic.EDIT_IMAGE20;
            this.barButtonItemLuu.Glyph = FWImageDic.SAVE_IMAGE20;
            this.barButtonItemKhongLuu.Glyph = FWImageDic.NO_SAVE_IMAGE20;
            this.barButtonItemSuaNhom.Glyph = FWImageDic.EDIT_IMAGE20;
            this.barButtonItemIn.Glyph = FWImageDic.PRINT_IMAGE20;
            this.barButtonItemIn.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            Table_Field_Name = new DataTable();
            error = new DXErrorProvider();
            InitData();
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewThongtin);
            this.InitSaveQueryDialog();
        }
        #endregion

        #region Init Form
        private void frmDanhba_Load(object sender, EventArgs e)
        {
            PMSupport.SetTitle(this, Status);
            Get_Schema_Table();
            gridControlThongtin.Load += new EventHandler(gridControlThongtin_Load);                     
            initGridview();
        }
        private void Get_Schema_Table()
        {
            DataTable Schema_Table = new DataTable();
            DatabaseFB db = DABase.getDatabase();            
            DbConnection con = db.OpenConnection();
            Schema_Table = con.GetSchema("Columns");
            ds1 = db.LoadDataSet("select * from LOAI_DANH_BA");
            Load_navbar(ds1);
            Rows_Columms_Size=Schema_Table.Select("TABLE_NAME='DANH_BA'");
        }
        void gridControlThongtin_Load(object sender, EventArgs e)
        {
            gridViewThongtin.BestFitColumns();
            cot_name.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            HelpGrid.SetTitle(this.gridViewThongtin, "DANH BẠ ĐỊA CHỈ");
        }
        public void InitData()
        {
            doDanhBa = DADanhBa.Instance.LoadAll(-2);
            gridDataSet = doDanhBa.DetailDataSet.Copy();
            gridControlThongtin.DataSource = gridDataSet.Tables[0];
        }
        public void Load_navbar(DataSet ds1)
        {
            finish_load_nav = false;
            navBarGroup1.ItemLinks.Clear();            
            foreach (DataRow r1 in ds1.Tables[0].Rows)
            {
                if (HelpNumber.ParseInt64(r1["ID"]) != 1)
                {
                    NavBarItem item1 = new NavBarItem();
                    item1.Caption = r1["TEN_LOAI"].ToString();
                    item1.Name = r1["ID"].ToString();
                    item1.SmallImage = imageList1.Images[0];
                    item1.LargeImage = imageList1.Images[0];

                    navBarGroup1.ItemLinks.Add(item1);
                }
            }
            finish_load_nav = true;
            navBarGroup1.SelectedLinkIndex = -1;                       
            navBarControl1.SelectedLink = null;
        }
        private void Add_Danh_Ba(long ID,string Name)
        {
            NavBarItem new_item = new NavBarItem();
            new_item.Caption = Name;
            new_item.Name = ID.ToString();
            new_item.SmallImage = imageList1.Images[0];
            new_item.LargeImage = imageList1.Images[0];

            navBarGroup1.ItemLinks.Add(new_item);
        }
        public void Load_gridview(List<string> list_cot)
        {
            for (int i = 0; i < list_cot.Count; i++)
            {
                GridColumn column = new GridColumn();
                column.Name = i.ToString();
                HelpGridColumn.CotTextLeft(column, list_cot[i]);
                gridViewThongtin.Columns.Add(column);
            }
        }
        public void initGridview()
        {
            gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            XtraGridSupportExt.TextLeftColumn(ID, "ID");            
            XtraGridSupportExt.TextLeftColumn(cot_name, "NAME");
            XtraGridSupportExt.TextLeftColumn(cot_diachi, "DIA_CHI");            
            XtraGridSupportExt.TextLeftColumn(cot_cmnd, "SO_CMND");
            XtraGridSupportExt.TextLeftColumn(cot_dienthoai, "SO_DIEN_THOAI");
            XtraGridSupportExt.TextLeftColumn(cot_fax, "SO_FAX");
            XtraGridSupportExt.TextLeftColumn(cot_nguoidaidien, "NGUOI_DAI_DIEN");
            XtraGridSupportExt.TextLeftColumn(cot_chucvu, "CHUC_VU");
            XtraGridSupportExt.TextLeftColumn(cot_bophan, "BO_PHAN");
            XtraGridSupportExt.TextLeftColumn(cot_taikhoan, "TAI_KHOAN");
            XtraGridSupportExt.TextLeftColumn(cot_loaidanhba, "LOAI_DANH_BA");
            XtraGridSupportExt.TextLeftColumn(cot_email, "EMAIL");

            #region Ẩn cột
            ID.Visible = false;
            cot_name.Visible = false;
            cot_diachi.Visible = false;
            cot_dienthoai.Visible = false;
            cot_cmnd.Visible = false;
            cot_fax.Visible = false;
            cot_nguoidaidien.Visible = false;
            cot_chucvu.Visible = false;
            cot_bophan.Visible = false;
            cot_taikhoan.Visible = false;
            cot_loaidanhba.Visible = false;
            cot_email.Visible = false;
            #endregion

            gridViewThongtin.OptionsSelection.MultiSelect = true;
            this.gridViewThongtin.FocusRectStyle = DrawFocusRectStyle.RowFocus;           
                      
            barButtonItemThemNhom.Enabled = true;
            barButtonItemXoaNhom.Enabled = false;
            barButtonItemSuaNhom.Enabled = false;
            barButtonItemDoiTenNhom.Enabled = false;
            barButtonItemThemNguoiLL.Enabled = false;
            barButtonItemXoaNguoiLL.Enabled = false;
            barButtonItemSuaNguoiLL.Enabled = false;
            barButtonItemLuu.Enabled = false;
            barButtonItemKhongLuu.Enabled = false;
            barButtonItemIn.Enabled = false;
            gridViewThongtin.OptionsNavigation.AutoFocusNewRow = true; ;
        

        }
        public void set_ancot_gridview()
        {                                              
            gridControlThongtin.DataSource = null;
            
        }
        #endregion

        #region Xử lý nút
        private void barButtonItemThemNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Thêm ListItem để kiểm tra trùng tên mà ko cần load lại dữ liệu
            List<NavBarItem> ListItem = new List<NavBarItem>();         
            foreach (NavBarItem item in navBarControl1.Items)
                ListItem.Add(item);
            frmThemNhom frm = new frmThemNhom(ListItem);
            frm.Add_Danh_Ba += new frmThemNhom.Refresh_Nhom_Danh_Ba(Add_Danh_Ba);
            ProtocolForm.ShowModalDialog(this, frm);            
            navBarGroup1.SelectedLinkIndex = select_index_nav;          
        }

        private void barButtonItemDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItemThemNguoiLL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridViewThongtin.AddNewRow();
            gridViewThongtin.ShowEditor();
            gridViewThongtin.SelectRow(-2147483647);           
            barButtonState(false);           
        }

        private void barButtonItemXoaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Xóa nhóm đang chọn?") == DialogResult.Yes)
            {
                if (navBarControl1.SelectedLink != null)
                {
                    try
                    {
                        if (DALoaiDanhBa.Instance.Delete(Selected_Loai_Danh_Ba))
                        {
                            Selected_NavBarItem = new NavBarItem();
                            Selected_NavBarItem = navBarControl1.SelectedLink.Item;
                            navBarControl1.Items.Remove(Selected_NavBarItem);
                            navBarGroup1.SelectedLinkIndex = -1;                            
                            barButtonItemThemNhom.Enabled = true;
                            barButtonItemXoaNhom.Enabled = false;
                            barButtonItemSuaNhom.Enabled = false;
                            barButtonItemDoiTenNhom.Enabled = false;
                            barButtonItemThemNguoiLL.Enabled = false;
                            barButtonItemXoaNguoiLL.Enabled = false;
                            barButtonItemSuaNguoiLL.Enabled = false;
                            barButtonItemLuu.Enabled = false;
                            barButtonItemKhongLuu.Enabled = false;
                            barButtonItemIn.Enabled = false;                            
                        }

                        else
                            PLMessageBox.ShowNotificationMessage("Dữ liệu đang sử dụng nên không thể xóa!");
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                    }
                }
                else
                    PLMessageBox.ShowNotificationMessage("Vui lòng chọn tên nhóm cần xóa!");
            }
        }

        private void barButtonItemDoiTenNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (navBarControl1.SelectedLink != null)
            {
                try
                {
                    Selected_NavBarItem = new NavBarItem();
                    Selected_NavBarItem = navBarControl1.SelectedLink.Item;
                    List<NavBarItem> ListItem = new List<NavBarItem>();
                    foreach (NavBarItem item in navBarControl1.Items)
                        ListItem.Add(item);
                    frmDoiTenNhom frm = new frmDoiTenNhom(ListItem);
                    ProtocolForm.ShowModalDialog(this, frm);
                    if (DALoaiDanhBa.New_Name != string.Empty)
                    {
                        Selected_NavBarItem.Caption = DALoaiDanhBa.New_Name;
                        DALoaiDanhBa.Instance.RenameLoaiDanhBa(Selected_Loai_Danh_Ba, Selected_NavBarItem.Caption);
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
            }
            else
                PLMessageBox.ShowNotificationMessage("Vui lòng chọn nhóm cần đổi tên!");
        }       
        private void barButtonItemLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (gridViewThongtin.EditingValue != null)
                    gridViewThongtin.SetFocusedValue(gridViewThongtin.EditingValue);
                if (gridViewThongtin.UpdateCurrentRow())
                {
                    foreach (DataRow row in gridDataSet.Tables[0].Rows)
                    {
                        if (row.RowState != DataRowState.Deleted && HelpNumber.ParseInt64(row["ID"]) == 0)
                            row["ID"] = DABase.getDatabase().GetID("G_NGHIEP_VU");
                    }
                    doDanhBa.DetailDataSet = DABase.getDatabase().LoadDataSet("select * from DANH_BA", "DANH_BA");
                    HelpDataSet.MergeDataSet(new string[] { "ID" }, doDanhBa.DetailDataSet, gridDataSet);

                    if (!DADanhBa.Instance.Update(doDanhBa))
                    {
                        PLMessageBox.ShowNotificationMessage("Lưu dữ liệu không thành công!");
                    }
                    barButtonState(true);
                    gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gridViewThongtin.FocusRectStyle = DrawFocusRectStyle.None; 
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }


        private void barButtonItemXoaNguoiLL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewThongtin.GetSelectedRows().Length > 0)
            {                               
                if (PLMessageBox.ShowConfirmMessage("Xóa chi tiết danh bạ đang chọn ?") == DialogResult.Yes)
                {
                    int TopIndex = -1;
                    try
                    {
                        foreach (int row_index in gridViewThongtin.GetSelectedRows())
                        {
                            if (TopIndex == -1) TopIndex = row_index;
                            DataRowView r = (DataRowView)gridViewThongtin.GetRow(row_index);
                            long id_danhba = HelpNumber.ParseInt64(r["ID"].ToString());
                            DADanhBa.Xoa_DanhBa(id_danhba);
                        }                        
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                    }
                    gridViewThongtin.DeleteSelectedRows();
                    gridViewThongtin.RefreshData();
                    gridViewThongtin.FocusRectStyle = DrawFocusRectStyle.None;
                    if (TopIndex - 1 >= 0)
                        gridViewThongtin.SelectRow(TopIndex - 1);
                    else {
                        gridViewThongtin.SelectRow(gridViewThongtin.TopRowIndex);
                    }
                    if (gridViewThongtin.RowCount < 1)
                    {
                        barButtonItemXoaNguoiLL.Enabled = false;
                        barButtonItemSuaNguoiLL.Enabled = false;
                        barButtonItemIn.Enabled = false;
                    }                   
                }
            }
        }

        private void barButtonItemSuaNguoiLL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barButtonState(false);
            gridViewThongtin.ShowEditor();                  
        }
        private void gridViewThongtin_DoubleClick(object sender, EventArgs e)
        {
            barButtonState(false);           
        }
        private void barButtonItemKhongLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IsKhongLuu = true;
            if (gridViewThongtin.EditingValue != null)
                gridViewThongtin.SetFocusedValue(gridViewThongtin.EditingValue);
            if (gridViewThongtin.UpdateCurrentRow())
            {
                gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                barButtonState(true);
                if (gridViewThongtin.RowCount > 1)
                {
                    barButtonItemSuaNguoiLL.Enabled = true;
                    barButtonItemXoaNguoiLL.Enabled = true;
                }
                else {
                    barButtonItemSuaNguoiLL.Enabled = false;
                    barButtonItemXoaNguoiLL.Enabled = false;
                }
                try
                {
                    gridControlThongtin.DataSource = DADanhBa.Load_danhba(Selected_Loai_Danh_Ba).Tables[0];
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
            }
        }
        #endregion

        #region Sự kiện       

        private void navBarControl1_SelectedLinkChanged(object sender, DevExpress.XtraNavBar.ViewInfo.NavBarSelectedLinkChangedEventArgs e)
        {
            barButtonState(true);
            if (finish_load_nav)
            {
                #region Ẩn cột gridview
                ID.Visible = false;
                cot_name.Visible = false;
                cot_diachi.Visible = false;
                cot_dienthoai.Visible = false;
                cot_cmnd.Visible = false;
                cot_fax.Visible = false;
                cot_nguoidaidien.Visible = false;
                cot_chucvu.Visible = false;
                cot_bophan.Visible = false;
                cot_taikhoan.Visible = false;
                cot_loaidanhba.Visible = false;
                cot_email.Visible = false;
                #endregion
                gridControlThongtin.DataSource = null;
                //Trường hợp khi sửa nhóm
                if (IsSuaNhom) NavBarControl_IndexChange(SelectItem.Item.Name);
                //Trường hợp khi thay đổi nhóm được chọn
                if (e.Link != null && navBarGroup1.SelectedLinkIndex != -1) NavBarControl_IndexChange(e.Link.Item.Name);
            }
        }
        /// <summary>
        /// Lấy size của các field
        /// </summary>
        /// <param name="Field_Names"></param>
        private void Get_MaxLength_Field_Name(DataRow[] Field_Names)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FIELD_NAME", Type.GetType("System.String"));
            dt.Columns.Add("MO_TA", Type.GetType("System.String"));
            dt.Columns.Add("COLUMN_SIZE", Type.GetType("System.String"));
            foreach (DataRow item in Field_Names)
            {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = item["FIELD_NAME"];
                row["MO_TA"] = item["MO_TA"];
                foreach (DataRow item1 in Rows_Columms_Size)
                {
                    if (item["FIELD_NAME"].ToString() == item1["COLUMN_NAME"].ToString())
                    {
                        row["COLUMN_SIZE"] = item1["COLUMN_SIZE"];
                        break;
                    }
                }
                dt.Rows.Add(row);
            }
            Columns_Size = dt.Select("1=1");
        }
        private void gridViewThongtin_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (IsKhongLuu) {
                IsKhongLuu = false;
                return;
            }
            if( gridControlThongtin.DataSource == null) return;
            GridView view = (GridView)sender;           
            DataRow row = gridViewThongtin.GetDataRow(e.RowHandle);
            if (row == null)return;
            try
            {
                if (!GUIValidation.ValidateRow(gridViewThongtin, row, DADanhBa.Instance.GetRule(Rows_Field_Names)))
                {
                    e.Valid = false;
                    gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;                    
                    return;
                }                
                if (!GUIValidation.ValidateRow(gridViewThongtin, row, DADanhBa.Instance.GetRule_MaxLength(Columns_Size)))
                {
                    e.Valid = false;
                    return;
                }
                if (CheckHasCol_Email(Rows_Field_Names))
                {
                    if (!GUIValidation.ValidateRow(gridViewThongtin, row, DADanhBa.Instance.GetIsEmail(Rows_Field_Names)))
                    {
                        e.Valid = false;
                        return;
                    }
                }
                gridDataSet = (gridControlThongtin.DataSource as DataTable).DataSet;
                DADanhBa.Instance.CheckDuplicate(view, gridDataSet, e);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            if (row !=null && row["LOAI_DANH_BA"].ToString() == string.Empty)
                row["LOAI_DANH_BA"] = Selected_Loai_Danh_Ba;

        }
        private void barButtonState(bool State)
        {            
            barButtonItemThemNguoiLL.Enabled = State;
            barButtonItemXoaNguoiLL.Enabled = State;
            barButtonItemSuaNguoiLL.Enabled = State;
            barButtonItemIn.Enabled = State;
            barButtonItemLuu.Enabled = !State;
            barButtonItemKhongLuu.Enabled = !State;
            gridViewThongtin.OptionsBehavior.Editable = !State;
        }
        //Xử lý khi sửa nhóm thành công
        private void UpdateSuaNhom() {
            int Pre_LinkIndex = navBarGroup1.SelectedLinkIndex;
            foreach (DataRow item in Rows_Field_Names)
            {
                Table_Field_Name.Rows.Remove(item);
                Table_Field_Name.AcceptChanges();
            }
            navBarGroup1.SelectedLinkIndex = -1;
            IsSuaNhom = true;
            navBarGroup1.SelectedLinkIndex = Pre_LinkIndex;
            IsSuaNhom = false;
        }
        /// <summary>
        /// Xử lý khi thay đổi nhóm được chọn
        /// </summary>
        /// <param name="SelectedName"></param>
        private void NavBarControl_IndexChange(string SelectedName) {
            gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

            #region Ẩn hiện các nút
            barButtonItemThemNhom.Enabled = true;
            barButtonItemSuaNhom.Enabled = true;
            barButtonItemXoaNhom.Enabled = true;
            barButtonItemDoiTenNhom.Enabled = true;
            barButtonItemThemNguoiLL.Enabled = true;
            barButtonItemSuaNguoiLL.Enabled = false;
            barButtonItemXoaNguoiLL.Enabled = false;
            barButtonItemLuu.Enabled = false;
            barButtonItemKhongLuu.Enabled = false;
            barButtonItemIn.Enabled = false;
            #endregion
            try
            {
                Selected_Loai_Danh_Ba = HelpNumber.ParseInt64(SelectedName);
                select_index_nav = navBarGroup1.SelectedLinkIndex;
                if (Table_Field_Name.Rows.Count > 0)
                {
                    Rows_Field_Names = Table_Field_Name.Select("LOAI_DANH_BA=" + Selected_Loai_Danh_Ba);
                    if (Rows_Field_Names.Length == 0)
                    {
                        string sql = @"select c.loai_danh_ba,c.field_name,
                                    (select c1.mo_ta from cau_hinh_danh_ba c1 where c.field_name=c1.field_name and c1.loai_danh_ba=1)
                                    from cau_hinh_danh_ba c
                                    where c.loai_danh_ba=" + SelectedName;
                        DataSet ds = DABase.getDatabase().LoadDataSet(sql);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DataRow row_add = Table_Field_Name.NewRow();

                            row_add["LOAI_DANH_BA"] = row["LOAI_DANH_BA"];
                            row_add["FIELD_NAME"] = row["FIELD_NAME"];
                            row_add["MO_TA"] = row["MO_TA"];
                            Table_Field_Name.Rows.Add(row_add);
                        }
                        Rows_Field_Names = Table_Field_Name.Select("LOAI_DANH_BA=" + Selected_Loai_Danh_Ba);
                    }
                }
                else
                {
                    string sql = @"select c.loai_danh_ba,c.field_name,
                                (select c1.mo_ta from cau_hinh_danh_ba c1 where c.field_name=c1.field_name and c1.loai_danh_ba=1)
                                from cau_hinh_danh_ba c
                                where c.loai_danh_ba=" + SelectedName;
                    DataSet ds = DABase.getDatabase().LoadDataSet(sql);
                    Table_Field_Name = ds.Tables[0].Copy();
                    Rows_Field_Names = Table_Field_Name.Select("LOAI_DANH_BA=" + Selected_Loai_Danh_Ba);
                }
                Get_MaxLength_Field_Name(Rows_Field_Names);
                for (int i = 0; i < gridViewThongtin.Columns.Count; i++)
                {
                    foreach (DataRow r in Rows_Field_Names)
                    {
                        string field_name = r["FIELD_NAME"].ToString();
                        if (gridViewThongtin.Columns[i].FieldName == field_name)
                        {
                            gridViewThongtin.Columns[i].Visible = true;
                            gridViewThongtin.Columns[i].VisibleIndex = i;
                            break;
                        }
                    }
                }
                DataSet dataset = DADanhBa.Load_danhba(Selected_Loai_Danh_Ba);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    barButtonItemXoaNguoiLL.Enabled = true;
                    barButtonItemSuaNguoiLL.Enabled = true;
                    barButtonItemIn.Enabled = true;
                }
                gridControlThongtin.DataSource = dataset.Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        private void barButtonItemSuaNhom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (navBarControl1.SelectedLink != null)
            {
                Selected_NavBarItem = new NavBarItem();
                Selected_NavBarItem = navBarControl1.SelectedLink.Item;
                List<NavBarItem> ListItem = new List<NavBarItem>();
                SelectItem = navBarControl1.SelectedLink;
                foreach (NavBarItem item in navBarControl1.Items)
                    ListItem.Add(item);
                frmThemNhom frm = new frmThemNhom(Selected_NavBarItem, Rows_Field_Names, ListItem, true);
                frm.Sua_Nhom += new frmThemNhom.Refresh_Sua_Nhom(UpdateSuaNhom);
                ProtocolForm.ShowModalDialog(this, frm);
            }
            else
                PLMessageBox.ShowNotificationMessage("Vui lòng chọn nhóm cần sửa!");
        }
        #endregion

        #region Extension
        private bool CheckHasCol_Email(DataRow [] Rows_Field_Name) {
            foreach (DataRow row in Rows_Field_Names)
            {
                if (row["FIELD_NAME"].ToString() == "EMAIL") return true;
            }
            return false;
        }
        #endregion

        private void InitSaveQueryDialog()
        {
            string view = "SELECT * FROM DANH_BA WHERE 1=1";
            HelpControl.addSaveQueryDialog(this, this.barManager1, this.gridControlThongtin, this.gridViewThongtin._GetPLGUI(),view);
        }

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            return null;
        }

        #endregion
    }
}

