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
using ProtocolVN.Plugin.TimeSheet;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace office
{
    public partial class GuiMail : DevExpress.XtraEditors.XtraUserControl
    {
        #region Properties
        public DataSet dsSource;
        #endregion

        public GuiMail()
        {
            InitializeComponent();
            popupContainerEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(popupContainerEdit1_CloseUp);
        }

        void popupContainerEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            StringBuilder str = new StringBuilder();
            if (gridViewNguoiTheoDoi.EditingValue != null)
            {
                gridViewNguoiTheoDoi.SetFocusedValue(gridViewNguoiTheoDoi.EditingValue);
                if (!gridViewNguoiTheoDoi.UpdateCurrentRow()) return;
            }

            foreach (DataRow row in dsSource.Tables[0].Rows)
            {
                if (row["CHON"].ToString() == "Y")
                    str.Append(row["NAME"].ToString() + ";");
            }
            if (str.Length > 0)
                e.Value = popupContainerEdit1.ToolTip = str.Remove(str.Length - 1, 1).ToString();
            else
                e.Value = popupContainerEdit1.ToolTip = string.Empty;
        }

        public void CreateDataset(long perForCurrentFormID, params long[] idNguoiNhan)
        {
            InitColumn(false);
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM DM_NHAN_VIEN WHERE 1=1");
            query.addCondition("(DEPARTMENT_ID IS NOT NULL )");
            query.addBoolean("VISIBLE_BIT", true);
            dsSource = HelpDB.getDatabase().LoadDataSet(query);
            dsSource.Tables[0].Columns.Add("CHON", typeof(System.String));
            foreach (DataRow row in dsSource.Tables[0].Rows)
            {
                row["CHON"] = "N";
            }
            this.gridControlNguoiTheoDoi.DataSource = _SetDefault(dsSource.Tables[0], perForCurrentFormID, idNguoiNhan);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewNguoiTheoDoi);
            this.gridViewNguoiTheoDoi.BestFitColumns();
            this.gridViewNguoiTheoDoi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        public void CreateDataset(bool isNguoiThucHienDA, params long[] nguoiThucHien)
        {
            InitColumn(isNguoiThucHienDA);
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM DM_NHAN_VIEN WHERE 1=1");
            query.addCondition("(DEPARTMENT_ID IS NOT NULL )");
            query.addBoolean("VISIBLE_BIT", true);
            dsSource = HelpDB.getDatabase().LoadDataSet(query);
            dsSource.Tables[0].Columns.Add("CHON", typeof(System.String));
            foreach (DataRow row in dsSource.Tables[0].Rows)
            {
                row["CHON"] = "N";
            }
            if (nguoiThucHien.Length > 0)
                this.gridControlNguoiTheoDoi.DataSource = _SetDefault(dsSource.Tables[0], 0, nguoiThucHien);
            else
                this.gridControlNguoiTheoDoi.DataSource = dsSource.Tables[0];
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewNguoiTheoDoi);
            this.gridViewNguoiTheoDoi.BestFitColumns();
            this.gridViewNguoiTheoDoi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            
            
        }

        public DataSet GetDataSet
        {
            get
            {
                return null;
            }
        }
        private void InitColumn(bool isNguoiThucHienDA)
        {
            HelpGridColumn.CotTextLeft(colHoTen, "NAME");
            HelpGridColumn.CotCombobox(colPhongBan, "DEPARTMENT", "ID", "NAME", "DEPARTMENT_ID");
            HelpGridColumn.CotTextLeft(colEmail, "EMAIL");
            HelpGridColumn.CotCheckEdit(colChon, "CHON");
            if (isNguoiThucHienDA)
            {
                colEmail.Visible = false;
                colChon.Caption = ".";
            }
            //colChon.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            gridViewNguoiTheoDoi.Click += delegate(object gridView, EventArgs clicked)
            {
                GridHitInfo gHitInfo = gridViewNguoiTheoDoi.CalcHitInfo(gridViewNguoiTheoDoi.GridControl.PointToClient(Control.MousePosition));
                if (gHitInfo.InRowCell)
                    if (gHitInfo.Column.FieldName == "CHON")
                        gridViewNguoiTheoDoi.ShowEditor();
            };
            this.gridViewNguoiTheoDoi.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colChon, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colHoTen, DevExpress.Data.ColumnSortOrder.Descending)});
        }
        public DataTable _SetDefault(DataTable table,long perForCurrentFormID , params long[] idNguoiNhan)
        {
            StringBuilder str = new StringBuilder();
            if (idNguoiNhan!= null && idNguoiNhan.Length > 0 )
            {
                StringBuilder strNguoiNhanMail = new StringBuilder(",");
                //List những người có quyền duyệt/không duyệt
                if (perForCurrentFormID > 0)
                {
                    List<long> lstUser = PLTimeSheetUtil.getQuyen(perForCurrentFormID);
                    foreach (long item in lstUser)
                        strNguoiNhanMail.Append(item.ToString() + ",");
                }
                foreach (long item in idNguoiNhan)
                    if (!strNguoiNhanMail.ToString().Contains("," + item.ToString() + ","))
                        strNguoiNhanMail.Append(item.ToString() + ",");
                foreach (DataRow row in table.Rows)
                {
                    if (strNguoiNhanMail.ToString().Contains("," + row["ID"].ToString() + ","))
                    {
                        row["CHON"] = "Y";
                        str.Append(row["NAME"].ToString() + ";");
                    }
                    else row["CHON"] = "N";
                }
            }
            else if(perForCurrentFormID > 0)
            {
                List<long> lstUser = PLTimeSheetUtil.getQuyen(perForCurrentFormID);
                foreach (DataRow row in table.Rows)
                {
                    if (lstUser.Contains(HelpNumber.ParseInt64(row["ID"])))
                    {
                        row["CHON"] = "Y";
                        str.Append(row["NAME"].ToString() + ";");
                    }
                }
            }
            if (str.Length > 0)
                popupContainerEdit1.Text = str.Remove(str.Length - 1, 1).ToString();
            else popupContainerEdit1.Text = string.Empty;
            return table;
        }

        /// <summary>
        /// Dùng cho quản lý dự án
        /// </summary>
        /// <returns></returns>
        public string GetStringNguoiThucHien()
        {
            StringBuilder str = new StringBuilder();
            foreach (DataRow row in dsSource.Tables[0].Rows)
            {
                if (string.Compare(row["CHON"].ToString(), "Y") == 0)
                    str.Append(row["ID"].ToString() + ",");
            }
            if (str.Length > 0)
                return str.Remove(str.Length - 1, 1).ToString();
            return string.Empty;
        }
        /// <summary>
        /// Dùng cho quản lý dự án
        /// </summary>
        /// <param name="strIDs"></param>
        /// <returns></returns>
        public long[] GetLongNguoiThucHien(string strIDs)
        {
            if (strIDs.Length == 0 || strIDs ==null) return null;
            List<long> lstNguoiThucHien = new List<long>();
            string[] str = strIDs.Split(',');
            foreach (string item in str)
                lstNguoiThucHien.Add(HelpNumber.ParseInt64(item));
            return lstNguoiThucHien.ToArray();
        }
        public string GetTenNguoiThucHien(string strIDs)
        {
            if (strIDs.Length == 0 || strIDs == null) return null;
            string qr = "select NAME from DM_NHAN_VIEN where id = " + strIDs + "";
            DataTable dt = HelpDB.getDatabase().LoadDataSet(qr).Tables[0];
            string ten = dt.Rows[0]["NAME"].ToString();
            return ten;
        }
    }
}
