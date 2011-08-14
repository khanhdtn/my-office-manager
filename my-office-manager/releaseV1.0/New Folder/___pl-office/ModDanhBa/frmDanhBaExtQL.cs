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
using PermissionOfResource;

namespace office
{
    public partial class frmDanhBaExtQL : XtraFormPL,IFormRefresh
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDanhBaExtQL).FullName,
                PMSupport.UpdateTitle("Danh bạ địa chỉ", Status),
                ParentID, true,
                typeof(frmDanhBaExtQL).FullName,
                true, IsSep, "mnsNotePad.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private long Selected_Loai_Danh_Ba;
        private NavBarItem Selected_NavBarItem;
        DODanhBaExt doDanhBa = new DODanhBaExt();
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
        public frmDanhBaExtQL()
        {
            InitializeComponent();
            DanhBaDCPermission.I.Init();
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
            barButtonItemPhanQuyenDanhBa.Glyph = ResourceMan.getImage20("lvmnbQuanLyHopDong.png");
            barButtonItemPhanQuyenNhomDanhBa.Glyph = ResourceMan.getImage20("navLienHe.png");
            Table_Field_Name = new DataTable();
            error = new DXErrorProvider();
            InitData();
        }
        #endregion

        #region Init Form
        private void frmDanhba_Load(object sender, EventArgs e)
        {
            PMSupport.SetTitle(this, Status);
            Get_Schema_Table();
            gridControlThongtin.Load += new EventHandler(gridControlThongtin_Load);   
            gridViewThongtin.ValidateRow +=new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridViewThongtin_ValidateRow);      
            gridViewThongtin.DoubleClick +=new EventHandler(gridViewThongtin_DoubleClick);
            initGridview();
        }
        private void Get_Schema_Table()
        {
            DataTable Schema_Table = new DataTable();
            DatabaseFB db = DABase.getDatabase();
            DbConnection con = db.OpenConnection();
            Schema_Table = con.GetSchema("Columns");
            //ds1 = db.LoadDataSet("SELECT * FROM DM_NHOM_DANH_BA WHERE VISIBLE_BIT = 'Y' ");
            ds1 = DanhBaDCPermission.I._LoadDataSetWithResGroupPermission(
               "SELECT * FROM DM_NHOM_DANH_BA WHERE VISIBLE_BIT = 'Y'", "DM_NHOM_DANH_BA", "ID");
            Load_navbar(ds1);
            Rows_Columms_Size = Schema_Table.Select("TABLE_NAME='DANH_BA'");
        }
        void gridControlThongtin_Load(object sender, EventArgs e)
        {
            gridViewThongtin.BestFitColumns();
            cot_name.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            HelpGrid.SetTitle(this.gridViewThongtin, "DANH BẠ ĐỊA CHỈ");
        }
        public void InitData()
        {
            doDanhBa = DADanhBaExt.Instance.LoadAll(-2);
            gridDataSet = doDanhBa.DetailDataSet.Copy();
            gridControlThongtin.DataSource = gridDataSet.Tables[0];
        }
        public void Load_navbar(DataSet ds1)
        {
            finish_load_nav = false;
            navBarControl1.Items.Clear();
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
            finish_load_nav = true;
            navBarGroup1.SelectedLinkIndex = -1;
            navBarGroup1.ItemLinks.SortByCaption();       
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
            XtraGridSupportExt.ComboboxGridColumn(cot_ten_NH, " DM_BANK", "ID", "NAME", "TEN_NGAN_HANG").NullText=string.Empty;
            XtraGridSupportExt.TextLeftColumn(cot_dienthoai, "SO_DIEN_THOAI");
            XtraGridSupportExt.TextLeftColumn(cot_fax, "SO_FAX");
            XtraGridSupportExt.TextLeftColumn(cot_nguoidaidien, "NGUOI_DAI_DIEN");
            XtraGridSupportExt.TextLeftColumn(cot_chucvu, "CHUC_VU");
            XtraGridSupportExt.TextLeftColumn(cot_didong, "DI_DONG");
            XtraGridSupportExt.TextLeftColumn(cot_taikhoan, "TAI_KHOAN");
            XtraGridSupportExt.TextLeftColumn(cot_loaidanhba, "LOAI_DANH_BA");
            XtraGridSupportExt.TextLeftColumn(cot_email, "EMAIL");

            #region Ẩn cột
            ID.Visible = false;
            cot_name.Visible = false;
            cot_diachi.Visible = false;
            cot_dienthoai.Visible = false;
            cot_ten_NH.Visible = false;
            cot_fax.Visible = false;
            cot_nguoidaidien.Visible = false;
            cot_chucvu.Visible = false;
            cot_didong.Visible = false;
            cot_taikhoan.Visible = false;
            cot_loaidanhba.Visible = false;
            cot_email.Visible = false;
            #endregion

            gridViewThongtin.OptionsSelection.MultiSelect = true;
            this.gridViewThongtin.FocusRectStyle = DrawFocusRectStyle.RowFocus;           
                      
            barButtonItemThemNguoiLL.Enabled = false;
            barButtonItemXoaNguoiLL.Enabled = false;
            barButtonItemSuaNguoiLL.Enabled = false;
            barButtonItemLuu.Enabled = false;
            barButtonItemKhongLuu.Enabled = false;
            barButtonItemIn.Enabled = false;
            gridViewThongtin.OptionsNavigation.AutoFocusNewRow = true; ;
            PLGUIUtil.TrimSpaceForGrid(this.gridViewThongtin, new string[] { "NAME", "NGUOI_DAI_DIEN" });

        }
        public void set_ancot_gridview()
        {                                              
            gridControlThongtin.DataSource = null;
            
        }
        #endregion

        #region Xử lý nút

        private void barButtonItemDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItemThemNguoiLL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (navBarControl1.SelectedLink == null) return;
            if (DanhBaDCPermission.I._checkPermissionResGroup(HelpNumber.ParseInt64(navBarControl1.SelectedLink.Item.Name),
                RES_PERMISSION_TYPE.CREATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền thêm danh bạ vào nhóm danh bạ đang chọn!");
                return;
            }
            gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            gridViewThongtin.AddNewRow();
            gridViewThongtin.ShowEditor();
            gridViewThongtin.SelectRow(-2147483647);           
            barButtonState(false);      
            
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

                    if (!DADanhBaExt.Instance.Update(doDanhBa))
                    {
                        HelpMsgBox.ShowNotificationMessage("Lưu dữ liệu không thành công!");
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
                if (HelpMsgBox.ShowConfirmMessage("Xóa chi tiết danh bạ đang chọn ?") == DialogResult.Yes)
                {
                    int TopIndex = -1;
                    try
                    {
                        int[] indexs=gridViewThongtin.GetSelectedRows();
                        if (indexs.Length > 0)
                        {
                            DataRow row = gridViewThongtin.GetDataRow(indexs[0]);
                            if (DanhBaDCPermission.I._checkPermissionResGroup(HelpNumber.ParseInt64(row["LOAI_DANH_BA"]), RES_PERMISSION_TYPE.DELETE) == false)
                            {
                                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa trên nhóm danh bạ đang chọn!");
                                return;
                            }
                        }

                        foreach (int row_index in indexs)
                        {
                            if (TopIndex == -1) TopIndex = row_index;
                            DataRowView r = (DataRowView)gridViewThongtin.GetRow(row_index);
                            long id_danhba = HelpNumber.ParseInt64(r["ID"].ToString());


                            DADanhBaExt.Xoa_DanhBa(id_danhba);
                            gridViewThongtin.DeleteRow(row_index);

                        }                        
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                    }
                  //  gridViewThongtin.DeleteSelectedRows();
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
            DataRow row = gridViewThongtin.GetFocusedDataRow();
            if (row == null) return;
            if (DanhBaDCPermission.I._checkPermissionResGroup(HelpNumber.ParseInt64(row["LOAI_DANH_BA"]),
              RES_PERMISSION_TYPE.UPDATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền sửa trên nhóm danh bạ đang chọn!");
                return;
            }
            barButtonState(false);
            gridViewThongtin.ShowEditor();
        }
        private void gridViewThongtin_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridViewThongtin.GetFocusedDataRow();
            if (row == null) return;
            if (DanhBaDCPermission.I._checkPermissionRes(HelpNumber.ParseInt64(row["LOAI_DANH_BA"]),
              RES_PERMISSION_TYPE.UPDATE) == false)
            {
              //  HelpMsgBox.ShowNotificationMessage("Bạn không có quyền sửa trên nhóm danh bạ đang chọn!");
                return;
            }
            barButtonState(false);
            gridViewThongtin.ShowEditor();
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
                try
                {
                    gridControlThongtin.DataSource = DADanhBaExt.Load_danhba(Selected_Loai_Danh_Ba).Tables[0];
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
                if ((gridControlThongtin.DataSource as DataTable).Rows.Count > 0)
                {
                    barButtonItemSuaNguoiLL.Enabled = true;
                    barButtonItemXoaNguoiLL.Enabled = true;
                }
                else
                {
                    barButtonItemSuaNguoiLL.Enabled = false;
                    barButtonItemXoaNguoiLL.Enabled = false;
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
                cot_ten_NH.Visible = false;
                cot_fax.Visible = false;
                cot_nguoidaidien.Visible = false;
                cot_chucvu.Visible = false;
                cot_didong.Visible = false;
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
            barButtonItemPhanQuyenNhomDanhBa.Enabled = navBarControl1.SelectedLink != null;

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
                if (!GUIValidation.ValidateRow(gridViewThongtin, row, DADanhBaExt.Instance.GetRule(Rows_Field_Names)))
                {
                    e.Valid = false;
                    gridViewThongtin.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;                    
                    return;
                }                
                if (!GUIValidation.ValidateRow(gridViewThongtin, row, DADanhBaExt.Instance.GetRule_MaxLength(Columns_Size)))
                {
                    e.Valid = false;
                    return;
                }
                if (CheckHasCol_Email(Rows_Field_Names) && row["EMAIL"].ToString() != string.Empty)
                {
                    if (!GUIValidation.ValidateRow(gridViewThongtin, row, DADanhBaExt.Instance.GetIsEmail(Rows_Field_Names)))
                    {
                        e.Valid = false;
                        return;
                    }
                }
                gridDataSet = (gridControlThongtin.DataSource as DataTable).DataSet;
                //DADanhBaExt.Instance.CheckDuplicate(view, gridDataSet, e);
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

                DataSet dsColumn = HelpDB.getDatabase().LoadDataSet(
                    new QueryBuilder(@"SELECT * FROM DM_NHOM_DANH_BA WHERE ID = " + Selected_Loai_Danh_Ba + " AND 1=1"));
                if (dsColumn != null && dsColumn.Tables[0].Rows.Count == 1)
                {
                    DataRow r = dsColumn.Tables[0].Rows[0];
                    this.cot_name.Visible =  (r["NAME_BIT"]!=null && r["NAME_BIT"].ToString().Equals("Y"));
                    this.cot_fax.Visible = (r["SO_FAX"] != null && r["SO_FAX"].ToString().Equals("Y"));
                    this.cot_email.Visible = (r["EMAIL"] != null && r["EMAIL"].ToString().Equals("Y"));
                    this.cot_dienthoai.Visible = (r["SO_DIEN_THOAI"] != null && r["SO_DIEN_THOAI"].ToString().Equals("Y"));
                    this.cot_diachi.Visible = (r["DIA_CHI"] != null && r["DIA_CHI"].ToString().Equals("Y"));
                    this.cot_ten_NH.Visible = (r["TEN_NGAN_HANG"] != null && r["TEN_NGAN_HANG"].ToString().Equals("Y"));
                    this.cot_chucvu.Visible = (r["CHUC_VU"] != null && r["CHUC_VU"].ToString().Equals("Y"));
                    this.cot_didong.Visible = (r["DI_DONG"] != null && r["DI_DONG"].ToString().Equals("Y"));
                    this.cot_taikhoan.Visible = (r["TAI_KHOAN"] != null && r["TAI_KHOAN"].ToString().Equals("Y"));
                    this.cot_nguoidaidien.Visible = (r["NGUOI_DAI_DIEN"] != null && r["NGUOI_DAI_DIEN"].ToString().Equals("Y"));
                    
                }
                select_index_nav = navBarGroup1.SelectedLinkIndex;
                if (Table_Field_Name.Rows.Count > 0)
                {
                    Rows_Field_Names = Table_Field_Name.Select("ID = " + Selected_Loai_Danh_Ba);
                    if (Rows_Field_Names.Length == 0)
                    {
                        string sql = @"SELECT * FROM DM_NHOM_DANH_BA
                                WHERE ID =" + SelectedName;
                        DataSet ds = DABase.getDatabase().LoadDataSet(sql);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            DataRow row_add = Table_Field_Name.NewRow();

                            row_add["ID"] = row["ID"];
                            row_add["NAME"] = row["NAME"];
                            row_add["DI_DONG"] = row["DI_DONG"];
                            row_add["CHUC_VU"] = row["CHUC_VU"];
                            row_add["DIA_CHI"] = row["DIA_CHI"];
                            row_add["EMAIL"] = row["EMAIL"];
                            row_add["NAME_BIT"] = row["NAME_BIT"];
                            row_add["NGUOI_DAI_DIEN"] = row["NGUOI_DAI_DIEN"];
                            row_add["TEN_NGAN_HANG"] = row["TEN_NGAN_HANG"];
                            row_add["SO_DIEN_THOAI"] = row["SO_DIEN_THOAI"];
                            row_add["SO_FAX"] = row["SO_FAX"];
                            row_add["TAI_KHOAN"] = row["TAI_KHOAN"];
                            Table_Field_Name.Rows.Add(row_add);
                        }
                    }
                    Rows_Field_Names = GetVisibleColumns(Table_Field_Name.Select("ID = " + Selected_Loai_Danh_Ba));
                }
                else
                {
                    string sql = @"SELECT * FROM DM_NHOM_DANH_BA
                                WHERE ID =" + SelectedName;
                    DataSet ds = DABase.getDatabase().LoadDataSet(sql);
                    Table_Field_Name = ds.Tables[0].Copy();
                    Rows_Field_Names = GetVisibleColumns(Table_Field_Name.Select(" ID = " + Selected_Loai_Danh_Ba));
                }
                Get_MaxLength_Field_Name(Rows_Field_Names);
                
                //for (int i = 0; i < gridViewThongtin.Columns.Count; i++)
                //{
                //    foreach (DataRow r in Rows_Field_Names)
                //    {
                //        string field_name = r["FIELD_NAME"].ToString();
                //        if (gridViewThongtin.Columns[i].FieldName == field_name)
                //        {
                //            gridViewThongtin.Columns[i].Visible = true;
                //            gridViewThongtin.Columns[i].VisibleIndex = i;
                //            break;
                //        }
                //    }
                //}
                DataSet dataset = DADanhBaExt.Load_danhba(Selected_Loai_Danh_Ba);
                if (dataset.Tables[0].Rows.Count > 0)
                {
                    barButtonItemXoaNguoiLL.Enabled = true;
                    barButtonItemSuaNguoiLL.Enabled = true;
                    barButtonItemIn.Enabled = true;
                }
                gridControlThongtin.DataSource = dataset.Tables[0];
                if (Rows_Field_Names.Length > 0) barButtonItemThemNguoiLL.Enabled = true;
                else {
                    barButtonItemThemNguoiLL.Enabled = false;
                    return;
                }
                //Số thứ tự hiển thị
                if (this.cot_name.Visible) {
                    this.cot_name.VisibleIndex = 0;
                    this.cot_name.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }
                if (this.cot_nguoidaidien.Visible) {
                    this.cot_nguoidaidien.VisibleIndex = 1;
                    if (!this.cot_name.Visible)
                        this.cot_nguoidaidien.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    else this.cot_nguoidaidien.SortOrder = DevExpress.Data.ColumnSortOrder.None;
                }
                if (this.cot_chucvu.Visible)
                    this.cot_chucvu.VisibleIndex = 2;
                if (this.cot_diachi.Visible)
                    this.cot_diachi.VisibleIndex = 3;
                if (this.cot_dienthoai.Visible)
                    this.cot_dienthoai.VisibleIndex = 4;
                if (this.cot_didong.Visible)
                    this.cot_didong.VisibleIndex = 5;
                if (this.cot_fax.Visible)
                    this.cot_fax.VisibleIndex = 6;
                if (this.cot_email.Visible)
                    this.cot_email.VisibleIndex = 7;
                if (this.cot_taikhoan.Visible)
                    this.cot_taikhoan.VisibleIndex = 8;
                if (this.cot_ten_NH.Visible)
                    this.cot_ten_NH.VisibleIndex = 9;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
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
        /// <summary>
        /// Return an array DataRow which contains visible columns
        /// </summary>
        /// <param name="arrRow"></param>
        /// <returns></returns>
        private DataRow[] GetVisibleColumns(DataRow[] arrRow) {
            DataTable dt = new DataTable();
            dt.Columns.Add("FIELD_NAME", typeof(System.String));
            dt.Columns.Add("MO_TA",typeof(System.String));
            if (arrRow[0]["NAME_BIT"].ToString().Equals("Y"))
            {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "NAME";
                row["MO_TA"] = "Tên liên lạc";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["NGUOI_DAI_DIEN"].ToString().Equals("Y"))
            {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "NGUOI_DAI_DIEN";
                row["MO_TA"] = "Người liên hệ";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["CHUC_VU"].ToString().Equals("Y"))
            {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "CHUC_VU";
                row["MO_TA"] = "Chức vụ";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["DIA_CHI"].ToString().Equals("Y"))
            {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "DIA_CHI";
                row["MO_TA"] = "Địa chỉ";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["SO_DIEN_THOAI"].ToString().Equals("Y"))
            {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "SO_DIEN_THOAI";
                row["MO_TA"] = "Số điện thoại";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["DI_DONG"].ToString().Equals("Y")) {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "DI_DONG";
                row["MO_TA"] = "Di động";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["SO_FAX"].ToString().Equals("Y"))
            {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "SO_FAX";
                row["MO_TA"] = "Số fax";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["EMAIL"].ToString().Equals("Y")) {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "EMAIL";
                row["MO_TA"] = "Email";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["TAI_KHOAN"].ToString().Equals("Y"))
            {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "TAI_KHOAN";
                row["MO_TA"] = "Số tài khoản";
                dt.Rows.Add(row);
            }
            if (arrRow[0]["TEN_NGAN_HANG"].ToString().Equals("Y")) {
                DataRow row = dt.NewRow();
                row["FIELD_NAME"] = "TEN_NGAN_HANG";
                row["MO_TA"] = "Tên ngân hàng";
                dt.Rows.Add(row);
            }
            return dt.Select("1=1");
        }
        #endregion

        private void InitSaveQueryDialog()
        {
            string view = "SELECT * FROM DANH_BA WHERE 1=1";
            HelpControl.addSaveQueryDialog(this, this.barManager1, this.gridControlThongtin, this.gridViewThongtin._GetPLGUI(), view);
        }

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            DataSet ds =
               DanhBaDCPermission.I._LoadDataSetWithResGroupPermission(
                "SELECT * FROM DM_NHOM_DANH_BA WHERE VISIBLE_BIT = 'Y'", "DM_NHOM_DANH_BA", "ID");
            Load_navbar(ds);
            Table_Field_Name.Clear();
            return null;
        }

        #endregion

        private void barButtonItemPhanQuyenNhomDanhBa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (navBarControl1.SelectedLink == null) return;
            long nhomDanhBaID = HelpNumber.ParseInt64(navBarControl1.SelectedLink.Item.Name);
            if (nhomDanhBaID <= 0) return;
            frmPermissionDataPopUp frm = new frmPermissionDataPopUp(DanhBaDCPermission.I,new DOResource(-1, nhomDanhBaID, -1, null));
            HelpProtocolForm.ShowModalDialog(this, frm);
          
        }
        private void gridViewThongtin_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridViewThongtin.GetFocusedDataRow();
            if (row == null)
            {
                barButtonItemPhanQuyenDanhBa.Enabled = false;
                return;
            }
            barButtonItemPhanQuyenDanhBa.Enabled = true;
        }
    }
}

