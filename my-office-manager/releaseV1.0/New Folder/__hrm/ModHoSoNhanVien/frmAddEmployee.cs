#region using
using System;
using System.Collections.Generic;
using System.Data;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Columns;
using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Core;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Common;
using DevExpress.XtraGrid;
#endregion

//CHAUTV
namespace office
{
    public partial class frmAddEmployee : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.OK_TEST;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmAddEmployee).FullName,
                PMSupport.UpdateTitle("Chuyển ứng viên tới nhân viên", Status),
                ParentID, true,
                typeof(frmAddEmployee).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        #region Fields
        private List<long> Ids = null;
        public delegate void RefreshParrentForm();
        public RefreshParrentForm _Refresh;
        #endregion

        #region Hàm dựng
        public frmAddEmployee(List<object> ids)
        {
            InitializeComponent();
            this.Ids = ConvertToLongArray(ids);
            this.InitColumns();
            this.InitData(this.Ids);
            this.InitControls();
            this.gridViewMaster.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridViewMaster_ValidateRow);
        }
        public frmAddEmployee() : this(null) { }
        #endregion

        #region Khởi tạo
        private void InitControls() {
            HelpXtraForm.SetCloseForm(this, btnClose, true);
            this.btnSave.Image = FWImageDic.SAVE_IMAGE16;
            this.btnClose.Image = FWImageDic.CLOSE_IMAGE16;
        }
        private void InitColumns() {
            CreateDM_NHAN_VIEN(this.gridControlMaster, this.gridViewMaster);
            GridColumn ColPhongBan = this.gridViewMaster.Columns["DEPARTMENT_ID"];
            ColPhongBan.OptionsColumn.AllowEdit = true;
            ColPhongBan.OptionsColumn.AllowFocus = true;
            ColPhongBan.OptionsColumn.ReadOnly = false;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
            GridColumn xoaCol = XtraGridSupportExt.CloseButton(gridControlMaster, gridViewMaster);
            this.gridViewMaster.RowCountChanged += delegate(object grid, EventArgs deleteRow)
            {
                xoaCol.Visible = (gridViewMaster.RowCount > 1);
            };
        }
        private void InitData(List<long> ids) {
            #region 1.Lấy thông tin bên bảng RESUME (Thông tin ứng viên)
            QueryBuilder query = new QueryBuilder(@"
                SELECT  MA_HO_SO as MA_NV,
                        HO_TEN as NAME,
                        NGAY_SINH,DIA_CHI,EMAIL,DIEN_THOAI
                FROM RESUME
                WHERE 1=1");
            query.addID("ID", ids.ToArray());
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query, "DM_NHAN_VIEN");
            ds.Tables["DM_NHAN_VIEN"].Columns.Add("ID", typeof(System.Int64)); 
            #endregion

            #region 2.Lấy cấu trúc bảng DM_NHAN_VIEN & Merge dữ liệu từ thông tin ứng viên sang
            DataSet dsMain = DABase.getDatabase().LoadDataSet(new QueryBuilder(@"SELECT * FROM DM_NHAN_VIEN WHERE 1=0 and 1=1"), "DM_NHAN_VIEN");
            HelpDataSet.MergeDataSet(new string[] { "ID" }, dsMain, ds);
            foreach (DataRow row in dsMain.Tables["DM_NHAN_VIEN"].Rows)
            {
                row["VISIBLE_BIT"] = "Y";
            } 
            #endregion

            this.gridControlMaster.DataSource = dsMain.Tables["DM_NHAN_VIEN"];
        }
        private List<long> ConvertToLongArray(List<object> arr) {
            List<long> ar = new List<long>();
            foreach (object item in arr)
            {
                ar.Add(HelpNumber.ParseInt64(item));
            }
            return ar;
        }
        #endregion

        #region Sự kiện
        private void gridViewMaster_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView grid = sender as GridView;
            DataRow row = grid.GetDataRow(e.RowHandle);
            row.ClearErrors();
            if (!GUIValidation.ValidateRow(grid, row, GetRuleDM_NHAN_VIEN(null)))
                e.Valid = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseFB db = DABase.getDatabase();

            #region Thông tin trên lưới
            
                DataSet ds = ((DataTable)this.gridControlMaster.DataSource).DataSet;

                foreach (DataRow row in ds.Tables["DM_NHAN_VIEN"].Rows)
                    row.ClearErrors();
                foreach (DataRow row in ds.Tables["DM_NHAN_VIEN"].Rows)
                {
                    row["ID"] = db.GetID(PLConst.G_DANH_MUC);
                    row["TEN_NV"] = row["NAME"].ToString();
                    //row["CMND"] = "  ";
                    if (string.Compare(row["DEPARTMENT_ID"].ToString(), string.Empty) == 0)
                        row.SetColumnError("DEPARTMENT_ID", "Vui lòng vào thông tin \"Phòng ban\"!");
                }
                if (ds.Tables[0].HasErrors) return;
            #endregion

            #region Thông tin ứng viên
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM RESUME WHERE 1=1");
            query.addID("ID", this.Ids.ToArray());
            DataSet dsResume = DABase.getDatabase().LoadDataSet(query, "RESUME");
            foreach (DataRow _row in dsResume.Tables["RESUME"].Rows)
            {
                _row["IS_EMPLOYEE"] = "Y";
                
            } 
            #endregion

            DatabaseFB dbUpdate = DABase.getDatabase();
            PLTransaction trans = PLTransaction.I(dbUpdate);
            try
            {
                bool bFlag = dbUpdate.UpdateDataSet(ds, trans.dbTrans);
                bFlag = dbUpdate.UpdateDataSet(dsResume, trans.dbTrans);
                trans.Commit();
                if (bFlag)
                {
                    _Refresh();
                    PLGUIUtil.ClosePhieu(this, true);
                }
            }
            catch (Exception ex)
            {
                trans.Rollback();
                PLException.AddException(ex);
                ErrorMsg.ErrorSave("Lưu không thành công.");
            }
        }
        #endregion

        public FieldNameCheck[] GetRuleDM_NHAN_VIEN(object param)
        {
            FieldNameCheck[] checkArray2 = new FieldNameCheck[6];
            object[] other = new object[2];
            other[1] = 200;
            checkArray2[0] = new FieldNameCheck("NAME", new CheckType[] { CheckType.Required, CheckType.RequireMaxLength }, "Họ tên nhân viên", other);
            checkArray2[1] = new FieldNameCheck("CMND", new CheckType[] { CheckType.OptionMaxLength }, "CMND", new object[] { 100 });
            checkArray2[2] = new FieldNameCheck("DIEN_THOAI", new CheckType[] { CheckType.OptionMaxLength }, "Điện thoại", new object[] { 100 });
            checkArray2[3] = new FieldNameCheck("DIA_CHI", new CheckType[] { CheckType.OptionMaxLength }, "Địa chỉ", new object[] { 200 });
            checkArray2[4] = new FieldNameCheck("DEPARTMENT_ID", new CheckType[] { CheckType.Required }, "Phòng ban",null);
            other = new object[2];
            other[0] = 200;
            checkArray2[5] = new FieldNameCheck("EMAIL", new CheckType[] { CheckType.OptionMaxLength, CheckType.OptionEmail }, "Email", other);
            return checkArray2;

        }
        public GridColumn[] CreateDM_NHAN_VIEN(GridControl gridControl, GridView gridView)
        {
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "ID", -1, -1), "ID");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Mã nhân viên", 0, 150), "MA_NV");
            GridColumn Ten = XtraGridSupportExt.CreateGridColumn(gridView, "Tên nhân viên", 1, 150);
            XtraGridSupportExt.TextLeftColumn(
                Ten, "NAME");
            GridColumn ColPhongBan = XtraGridSupportExt.CreateGridColumn(gridView, "Tên phòng ban", 2, 150);
            ColPhongBan.FieldName = "DEPARTMENT_ID";
            //XtraGridSupportExt.IDGridColumn(ColPhongBan, "ID", "NAME", "DEPARTMENT", "DEPARTMENT_ID");
            HelpGridColumn.CotCombobox(ColPhongBan, HelpDB.getDatabase().LoadDataSet(@"SELECT * 
                                            FROM DEPARTMENT WHERE PARENT_ID IS NOT NULL"), "ID", "NAME", "DEPARTMENT_ID");
            ColPhongBan.OptionsColumn.AllowEdit = true;
            ColPhongBan.OptionsColumn.AllowFocus = false;
            ColPhongBan.OptionsColumn.ReadOnly = true;
            Ten.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "CMND", 3, 150), "CMND");
            XtraGridSupportExt.DateTimeGridColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Ngày sinh", 4, 150), "NGAY_SINH");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Điện thoại", 5, 150), "DIEN_THOAI");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Địa chỉ", 6, 150), "DIA_CHI");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Email", 7, 150), "EMAIL");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Hiển thị", 8, 100), "VISIBLE_BIT");
            gridView.OptionsView.ShowGroupedColumns = false;
            gridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView.OptionsView.ColumnAutoWidth = true;
            return null;
        }
    }
}