using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.Data;
namespace ProtocolVN.Framework.Win
{
    //Người thực hiện: chautv
    public partial class frmGroupIntervalOption : XtraFormPL
    {
        /// <summary>
        /// Lưới áp dụng
        /// </summary>
        private GridView _gridView = null;

        /// <summary>
        /// Áp dụng Tùy biến gom nhóm cho lưới
        /// </summary>
        /// <param name="gridView"></param>
        public frmGroupIntervalOption(GridView gridView)
        {
            this._gridView = gridView;
            InitializeComponent();
            HelpXtraForm.SetCloseForm(this, btnClose, null);
        }

        public frmGroupIntervalOption() : this(new GridView()) { 

        }

        private void frmGroupIntervalOption_Load(object sender, EventArgs e)
        {
            this.cmbColumns.imgCombo.SelectedIndexChanged += new EventHandler(imgCombo_SelectedIndexChanged);
            this._init();
            HelpXtraForm.SetFix(this);
            this.cmbColumns.imgCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// Chọn cột --> Load các kiểu gom nhóm tương ứng kiểu dữ liệu của cột
        /// </summary>
        private void imgCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Danh sách GroupInterval tùy thuộc vào kiểu dữ liệu của cột chọn
            GridColumn column = cmbColumns.imgCombo.EditValue as GridColumn;
            DataTable tbGroupInterval = new DataTable("COLUMNS");
            tbGroupInterval.Columns.Add("ID", typeof(Int32));
            tbGroupInterval.Columns.Add("NAME", typeof(System.String));
            tbGroupInterval.Rows.Add(ColumnGroupInterval.Default, "Mặc định");
            tbGroupInterval.Rows.Add(ColumnGroupInterval.Alphabetical, "Bảng chữ cái");

            if (column.ColumnEdit is RepositoryItemDateEdit||
                column.ColumnEdit is RepositoryItemTimeEdit)
            {
                tbGroupInterval.Rows.Add(ColumnGroupInterval.Date, "Ngày,tháng,năm");
                tbGroupInterval.Rows.Add(ColumnGroupInterval.DateMonth, "Tháng");
                tbGroupInterval.Rows.Add(ColumnGroupInterval.DateRange, "Vùng");
                tbGroupInterval.Rows.Add(ColumnGroupInterval.DateYear, "Năm");
            }
            tbGroupInterval.Rows.Add(ColumnGroupInterval.DisplayText, "Giá trị hiển thị");
            tbGroupInterval.Rows.Add(ColumnGroupInterval.Value, "Giá trị");

            DataSet dstbGroupInterval = new DataSet();
            dstbGroupInterval.Tables.Add(tbGroupInterval);
            this.cmbTypeGroupInterval._init(dstbGroupInterval.Tables[0], "NAME", "ID");
        }
      
        private void _init() { 
            
            foreach (GridColumn column in this._gridView.Columns)
            {
                //Add danh sách cột vào combobox chọn cột
                if(column.VisibleIndex>=0)
                    cmbColumns.imgCombo.Properties.Items.Add(new ImageComboBoxItem(column.GetTextCaption(), column, column.ImageIndex));
                //Gán GroupInterval mặc định cho các cột
                column.GroupInterval = ColumnGroupInterval.Default;
            }

            DataTable tb = new DataTable("ABC");
            tb.Columns.Add("ID", typeof(Int64));
            tb.Columns.Add("NAME", typeof(System.String));
            DataSet ds = new DataSet();
            ds.Tables.Add(tb);

            foreach (object value in Enum.GetValues(typeof(SummaryItemType)))
            {
                ds.Tables[0].Rows.Add(value, Enum.GetName(typeof(SummaryItemType), value));
            }
            
            DataSet dsSummary = new DataSet();

            this.cmbTypeSum._init(ds.Tables[0], "NAME", "ID");

            HelpControl.RedCheckEdit(this.chkReset, false);
            HelpControl.RedCheckEdit(this.chkMergeCell, false);
            cmbColumns.imgCombo.SelectedIndex = 0;
            this.chkReset.Checked = true;
            this.chkMergeCell.Checked = true;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                this._gridView.BeginSort();
                if (this.chkReset.Checked)
                    this._gridView.ClearGrouping();

                GridColumn column = cmbColumns.imgCombo.EditValue as GridColumn;
                column.GroupInterval = (ColumnGroupInterval)((Int32)this.cmbTypeGroupInterval._getSelectedID());
                if (column.GroupIndex == -1)
                    column.GroupIndex = this._gridView.GroupCount + 1;

                //Nếu chọn xóa gom nhóm hiện tại và có chọn kiểu gom nhóm
                if (chkReset.Checked)
                    column.GroupIndex = 0;

                //Nếu không chọn kiểu nào -->Bỏ gom nhóm
                if (this.cmbTypeGroupInterval._getSelectedID() == -1)
                {
                    column.GroupIndex = -1;
                }
                //Áp dụng summary trên cột gom nhóm
                this.AppGroupSummary(column,cmbTypeSum._getSelectedIDs());
                this._gridView.OptionsView.AllowCellMerge = this.chkMergeCell.Checked;
                this._gridView.EndSort();
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }

        private void AppGroupSummary(GridColumn column,long[]typeIDs)
        {
            this._gridView.GroupSummary.Clear();
            foreach (Int64 item in typeIDs)
            {
                this._gridView.GroupSummary.AddRange(
                new DevExpress.XtraGrid.GridGroupSummaryItem[] {
                new DevExpress.XtraGrid.GridGroupSummaryItem((SummaryItemType)item, column.FieldName,null, "")});    
            }
        }
    }
}