using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.Plugin.TimeSheet.bo;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DAO;
using office;


namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmTimeTable : XtraFormPL
    {
        private DXErrorProvider Error;
        private DOChiTietCongViec chitietcongviec;
        private bool? IsUpdate;
        private bool? Is_Add ;
        private long NV_ID;
        string dsid = "";

        #region Hàm dựng và Form Load

        public frmTimeTable()
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            InitGrid();
            Duyet._init(true);
            this.Is_Add = true;
            this.NV_ID = DAChiTietCongViec.Instance.GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id));
            InitControl();
            //gridViewDSCongviec.OptionsView.ColumnAutoWidth = true;
            this.gridDSCongviec.DataSource = DAChiTietCongViec.Instance.GetData(NgayNhap.DateTime, -1).Tables[0];
            gridViewDSCongviec.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
        }

        public frmTimeTable(DateTime Ngaylamviec, long ID_NV, long CTCV_ID, bool? is_update)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            this.Is_Add = this.IsUpdate = is_update;
            this.NV_ID = ID_NV;
            InitGrid();
            //Duyet._init(true);
            InitControl();
            InnitDodata(Ngaylamviec, ID_NV, CTCV_ID);
            gridViewDSCongviec.OptionsView.NewItemRowPosition = (is_update != null ? NewItemRowPosition.Bottom : NewItemRowPosition.None);
            gridViewDSCongviec.OptionsBehavior.Editable = (is_update != null ? true : false);
            btnSave.Visible = (is_update == null ? false : true);
            //gridViewDSCongviec.OptionsView.ColumnAutoWidth = true;
            CotXoa.Visible = is_update == true;
        }

        #endregion

        #region Xu ly khoi tao
        public static void CloseDong(GridControl gridcontrol, GridView Gridview, bool? isadd)
        {
            GridColumn column = XtraGridSupportExt.CloseButton(gridcontrol, Gridview);
            column.Visible = isadd == null ? false : true;

        }

        public void InitControl()
        {
            NgayNhap.DateTime = HelpDB.getDatabase().GetSystemCurrentDateTime();
            lblThoiGianCapNhat.Text = DABase.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            DataTable dt = DAChiTietCongViec.Instance.GetNAME(this.NV_ID).Tables[0];
            if (dt.Rows.Count > 0)
                lblNhanVien.Text = dt.Rows[0]["NAME"].ToString();
            else
                lblNhanVien.Text = string.Empty;
            HelpGrid.SetTitle(this.gridViewDSCongviec, "DANH SÁCH CÔNG VIỆC TRONG NGÀY");
        }

        public void InitGrid()
        {
            XtraGridSupportExt.ComboboxGridColumn(Cotloai_cv, "v_dm_loai_cong_viec", "ID", "NAME", "LCV_ID");
            XtraGridSupportExt.TextLeftColumn(Cotmota, "MO_TA");
            HelpGridColumn.CotPLTimeEdit(CotTGTH, "THOI_GIAN_THUC_HIEN", "HH:mm");


        }

        public void InnitDodata(DateTime ngaylamviec, long ID_NV, long CTCCV_ID)
        {
            DataSet ds = new DataSet();
            if (CTCCV_ID != -1 && Is_Add == false)
            {
                chitietcongviec = DAChiTietCongViec.Instance.GetCTCV(ngaylamviec, ID_NV, CTCCV_ID);
                ds = DAChiTietCongViec.Instance.GetData_Update(CTCCV_ID);
                lblThoiGianCapNhat.Text = System.Convert.ToDateTime(chitietcongviec.NGAY_CAP_NHAT).ToString(PLConst.FORMAT_DATETIME_STRING);
            }
            else
            {
                ds = DAChiTietCongViec.Instance.GetData(ngaylamviec, ID_NV);
                lblThoiGianCapNhat.Text = System.Convert.ToDateTime(ds.Tables[0].Rows[0]["NGAY_CAP_NHAT"]).ToString(PLConst.FORMAT_DATETIME_STRING);
            }
            //else if (ngaylamviec.ToString() != "" && ID_NV.ToString() != "")
            //{
            //    chitietcongviec = DAChiTietCongViec.Instance.GetCTCV(ngaylamviec, ID_NV, -1);
            //    ds = DAChiTietCongViec.Instance.GetData(ngaylamviec, ID_NV);
            //}
            NgayNhap.DateTime = ngaylamviec;
            this.gridDSCongviec.DataSource = ds.Tables[0];
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    Info.Enabled = true;

            //    PLTimeSheetUtil.UpdateInfo_Duyet(Info, chitietcongviec);
            //    foreach (DataRow r in ds.Tables[0].Rows)
            //    {
            //        if (r["DUYET"].ToString() == "1")
            //        {
            //            chitietcongviec._DUYET = "1";
            //            Duyet.SetDuyet(chitietcongviec);
            //            Allow(true, gridViewDSCongviec);
            //            break;
            //        }
            //        else if (r["DUYET"].ToString() == "2")
            //        {

            //            Duyet.SetDuyet(chitietcongviec);
            //            Allow(false, gridViewDSCongviec);
            //            break;
            //        }
            //        else if (r["DUYET"].ToString() == "3")
            //        {

            //            Duyet.SetDuyet(chitietcongviec);
            //            Allow(true, gridViewDSCongviec);
            //            break;
            //        }

            //    }
            //}
            //else
            //{
            //    Info.Enabled = false;
            //    chitietcongviec._DUYET = "1";
            //    Duyet.SetDuyet(chitietcongviec);
            //    Allow(true, gridViewDSCongviec);
            //}
        }

        #endregion

        #region Xử lý nút

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gridViewDSCongviec.RowCount == 1)
                HelpMsgBox.ShowErrorMessage("Vui lòng nhập dữ liệu vào lưới!");
            else
            {
                bool flag = false;
                string[] dsidct = dsid.Split(',');
                for (int i = 1; i < dsidct.Length; i++)
                {
                    if (dsidct.Length > 0)
                        DAChiTietCongViec.Instance.DeleteCTCV(Int64.Parse(dsidct[i]));
                }
                flag = DAChiTietCongViec.Instance.Update_CTCV(((DataView)gridViewDSCongviec.DataSource).Table.DataSet, this.NV_ID, NgayNhap.DateTime, chitietcongviec);
                if (flag != true)
                    HelpMsgBox.ShowErrorMessage("Lưu không thành công. Vui lòng kiểm tra số liệu!");
                else
                {

                    HelpXtraForm.CloseFormNoConfirm(this);
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //if (IsUpdate == false)
            //    this.Close();
            //else
            //{
            //    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng ?") == DialogResult.Yes)
            //    {
            //        this.Close();
            //    }
            //}
        }

        private void rep_Xoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (row != null)
            {
                //    if (row["DUYET"].ToString() == "2")
                //        HelpMsgBox.ShowNotificationMessage("Xóa không thành công.Công việc của bạn đã được duyệt!");
                //    else
                //    {
                dsid += "," + row["CTCCV_ID"].ToString();
                gridViewDSCongviec.DeleteRow(gridViewDSCongviec.FocusedRowHandle);
            }
            //}
        }
        #endregion

        #region Validate
        private FieldNameCheck[] GetMaxLength()
        {
            return new FieldNameCheck[]{
                new FieldNameCheck("MO_TA",new CheckType[]{CheckType.OptionMaxLength},new string []{ErrorMsgLib.errorMaxLength("Công việc")},new object[]{200})
            };
        }
        private void gridViewDSCongviec_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataSet ds1 = (gridDSCongviec.DataSource as DataTable).DataSet;
            GridView grid = (GridView)sender;
            DataRow row = grid.GetDataRow(e.RowHandle);
            bool flag = true;
            row.ClearErrors();
            if (row["LCV_ID"].ToString() == "")
            {
                row.SetColumnError("LCV_ID", "Vui lòng vào thông tin \"Loại công việc\"!");
                e.Valid = false;
                return;
            }
            if (row["MO_TA"].ToString() == "")
            {
                row.SetColumnError("MO_TA", "Vui lòng vào thông tin \"Mô tả công việc\"!");
                e.Valid = false;
                return;
            }
            TimeSpan dt;
            if (row["THOI_GIAN_THUC_HIEN"].ToString() != "")
            {
                dt = System.Convert.ToDateTime(row["THOI_GIAN_THUC_HIEN"]).TimeOfDay;
                if (dt.Hours == 0 && dt.Minutes == 0)
                {
                    row.SetColumnError("THOI_GIAN_THUC_HIEN", "Vui lòng vào thông tin \"Thời gian thực hiện\"!");
                    e.Valid = false;
                    return;
                }
            }
            if (row["THOI_GIAN_THUC_HIEN"].ToString() == "")
            {
                row.SetColumnError("THOI_GIAN_THUC_HIEN", "Vui lòng vào thông tin \"Thời gian thực hiện\"!");
                e.Valid = false;
                return;
            }
            if (!GUIValidation.ValidateRow(gridViewDSCongviec, row, GetMaxLength()))
            {
                e.Valid = false;
                return;
            }
            //Kiểm tra trùng lặp dữ liệu trên lưới
            DataSet ds = DAChiTietCongViec.Instance.CheckDuplicate(NgayNhap.DateTime, this.NV_ID);
            flag = Kiem_tra_dl(ds, row);//Kiểm tra dl dưới DB
            if (flag == false)
            {
                e.Valid = false;
                return;
            }
            ds.Clear();
            ds = (gridDSCongviec.DataSource as DataTable).DataSet;//Kiểm tra dl trên lưới
            flag = Kiem_tra_dl(ds, row);
            if (flag == false)
            {
                e.Valid = false;
                return;
            }
        }
        bool Kiem_tra_dl(DataSet ds, DataRow row)
        {
            if (ds != null)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (r.RowState != DataRowState.Deleted)
                    {
                        if (r["CTCCV_ID"].ToString() != row["CTCCV_ID"].ToString())
                        {

                            if (row["LCV_ID"].ToString() == r["LCV_ID"].ToString() && row["MO_TA"].ToString().ToLower() == r["MO_TA"].ToString().ToLower())
                            {
                                row.SetColumnError("LCV_ID", "Công việc và mô tả công việc nhập bị trùng lặp!");
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        Int64 i = 0;
        private void gridViewDSCongviec_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (row["CTCCV_ID"].ToString() == "")
                row["CTCCV_ID"] = i++;
        }
        #endregion

        private void frmTimeTable_Load(object sender, EventArgs e)
        {
            //gridViewDSCongviec.OptionsView.ColumnAutoWidth = true;
            HelpXtraForm.SetCloseForm(this, btnClose, Is_Add);
            gridViewDSCongviec.InitNewRow += delegate(object gridView, InitNewRowEventArgs newRow)
            {
                DataRow row = gridViewDSCongviec.GetDataRow(newRow.RowHandle);
                row["THOI_GIAN_THUC_HIEN"] = "01:00";
            };
            HelpXtraForm.SetFix(this);
            gridViewDSCongviec.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewDSCongviec_FocusedRowChanged);
        }

        void gridViewDSCongviec_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridViewDSCongviec.GetDataRow(gridViewDSCongviec.FocusedRowHandle);
            if (row == null || row.RowState == DataRowState.Added) return;
            lblThoiGianCapNhat.Text = 
                System.Convert.ToDateTime(row["NGAY_CAP_NHAT"]).ToString(PLConst.FORMAT_DATETIME_STRING);
        }

    }
}