using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace office
{
    public partial class NgayNghiPhep : DevExpress.XtraEditors.XtraUserControl
    {
        #region Properties
        private DataSet ds = new DataSet();
        private DataSet dsforValidate = new DataSet();
        private bool? IsAdd;
        public object ngayNPUpdate = new object();
        public long nvNghiPhep = -1;
        #endregion

        public NgayNghiPhep()
        {
            InitializeComponent();
            popupContainerEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(popupContainerEdit1_CloseUp);
            popupContainerEdit1.Popup += new EventHandler(popupContainerEdit1_Popup);
            gridViewNgayNghiPhep.OptionsView.ShowIndicator = false;
            gridViewNgayNghiPhep.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridViewNgayNghiPhep_ValidateRow);
        }


        void popupContainerEdit1_Popup(object sender, EventArgs e)
        {
            dsforValidate.Clear();
            dsforValidate = HelpDB.getDatabase().LoadDataSet(string.Format(@"Select NGHI_BUOI_SANG as SANG,
                                                        NGHI_BUOI_CHIEU as CHIEU,
                                                        NGAY_LAM_VIEC as NGAY
                                                        from CAPNHAT_NGAYLAMVIEC Where LOAI = 2 AND NV_ID = {0} ", nvNghiPhep));
        }

        void gridViewNgayNghiPhep_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = gridViewNgayNghiPhep.GetDataRow(e.RowHandle);
            if (row == null) return;
            row.ClearErrors();
            ds = (gridControlNgayNghiPhep.DataSource as DataTable).DataSet;
            if (!HelpInputData.ValidateRow(gridViewNgayNghiPhep, row, GetRule()))
            {
                e.Valid = false;
                return;
            }
            if (string.Compare(row["SANG"].ToString(), "Y") != 0 && string.Compare(row["CHIEU"].ToString(), "Y") != 0) {
                e.Valid = false;
                row.SetColumnError("SANG","Vui lòng vào thông tin \"Sáng\"!");
                row.SetColumnError("CHIEU", "Vui lòng vào thông tin \"Chiều\"!");
                return;
            }
            DataSet newDs = new DataSet();
            newDs = ds.Copy();
            HelpDataSet.MergeDataSet(new string[] { "NGAY" }, newDs, dsforValidate);
            if (CheckDuplicate(row, newDs))
            {
                e.Valid = false;
                row.SetColumnError("NGAY", "Thông tin \"Ngày nghỉ phép\" đã được sử dụng!");
                return;
            }
        }

        void popupContainerEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            if (gridViewNgayNghiPhep.EditingValue != null)
            {
                gridViewNgayNghiPhep.SetFocusedValue(gridViewNgayNghiPhep.EditingValue);
                if (gridViewNgayNghiPhep.UpdateCurrentRow()) goto GetDate;
            }
            else if (ds.Tables[0].Rows.Count > 0) goto GetDate;
            else e.Value = string.Empty;
            return;
            GetDate:
                    StringBuilder strNgay = new StringBuilder();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (row.HasErrors || row["NGAY"].ToString().Length == 0) break;
                        strNgay.Append(Convert.ToDateTime(row["NGAY"]).ToString("dd/MM/yyyy"));
                        strNgay.Append(";");
                    }
                    if (strNgay.Length > 0)
                        e.Value = popupContainerEdit1.ToolTip = strNgay.ToString().Remove(strNgay.ToString().LastIndexOf(";"));
                    else
                        e.Value = popupContainerEdit1.ToolTip = string.Empty;
        }

        public void CreateDataset(bool? IsAdd)
        {
            DataTable dt = new DataTable("NGAY_NGHI_PHEP");
            dt.Columns.AddRange(new DataColumn[] {new DataColumn("SANG",typeof(String))
                ,new DataColumn("CHIEU",typeof(String)), new DataColumn("NGAY",typeof(DateTime))});
            InitColumn(IsAdd);
            ds.Tables.Add(dt);
            gridControlNgayNghiPhep.DataSource = ds.Tables[0];
            gridViewNgayNghiPhep.OptionsBehavior.AutoExpandAllGroups = true;
            this.IsAdd = IsAdd;
        }
        public DataSet GetDataSet {
            get {
                return ds;
            }
        }
        private void InitColumn(bool? IsAdd)
        {
            HelpGridColumn.CotCheckEdit(colSang, "SANG");
            HelpGridColumn.CotCheckEdit(colChieu, "CHIEU");
            XtraGridSupportExt.DateTimeGridColumn(colNgayNghiPhep, "NGAY");
            //HelpGridColumn.CotPLDong(gridControlNgayNghiPhep, gridViewNgayNghiPhep).Visible = IsAdd == true;
        }

        private FieldNameCheck[] GetRule()
        {
            return new FieldNameCheck[]{ new FieldNameCheck("NGAY",
                        new CheckType[] { CheckType.Required },
                        new string[] { HelpErrorMsg.errorRequired("Ngày nghỉ phép") },
                        new object[] { })};
               
        }
        private bool CheckDuplicate(DataRow row, DataSet newDs) {
            if (IsAdd == true) {
                if (newDs.Tables[0].Select(string.Format("NGAY = '{0}'", Convert.ToDateTime(row["NGAY"]))).Length > 0) return true;
            }
            else if (IsAdd == false) {
                if (newDs.Tables[0].Select(string.Format("NGAY = '{0}' AND NGAY <> '{1}'", Convert.ToDateTime(row["NGAY"]), Convert.ToDateTime(ngayNPUpdate))).Length > 0) return true;
            }
            return false;   
        }

        private void repXoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridViewNgayNghiPhep.DeleteSelectedRows();
        }
    }
}
