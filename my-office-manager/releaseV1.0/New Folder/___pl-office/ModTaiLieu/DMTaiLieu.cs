using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using office;
using System.Threading;
using DAO;
using System.Globalization;
using ProtocolVN.Framework.Core;

namespace office.DanhMuc
{
    //TRANGDTT_NC Xây dựng lại theo chuẩn danh mục
    public class DMTaiLieu
    {
        public static GridColumn[] CreateDM_TAI_LIEU(GridControl gridControl, GridView gridView)
        {
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "ID", -1, -1), "ID");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Tên tài liệu", 0, 150), "NAME");

            GridColumn ColLoai = XtraGridSupportExt.CreateGridColumn(gridView, "Loại tài liệu", 1, 150);
            ColLoai.FieldName = "LOAI_TAI_LIEU_ID";
            XtraGridSupportExt.IDGridColumn(ColLoai, "ID", "NAME", "DM_LOAI_TAI_LIEU", "LOAI_TAI_LIEU_ID");
            ColLoai.OptionsColumn.AllowEdit = true;
            ColLoai.OptionsColumn.AllowFocus = false;
            ColLoai.OptionsColumn.ReadOnly = true;
            gridView.GroupCount = 1;
            gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(ColLoai, DevExpress.Data.ColumnSortOrder.Ascending)}
            );
            HelpGridColumn.CotMemoEdit(gridView,
                XtraGridSupportExt.CreateGridColumn(gridView, "Mô tả", 3, 150), "MO_TA");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Phiên bản", 4, 150), "PHIEN_BAN");
            XtraGridSupportExt.ComboboxGridColumn(
               XtraGridSupportExt.CreateGridColumn(gridView, "Người gửi", 5, 150), DADocument.getDM_NHAN_VIEN(), "ID", "NAME", "NGUOI_GUI");
            XtraGridSupportExt.DateTimeGridColumn(
               XtraGridSupportExt.CreateGridColumn(gridView, "Ngày gửi", 6, 150), "NGAY_GUI");
            XtraGridSupportExt.ComboboxGridColumn(
               XtraGridSupportExt.CreateGridColumn(gridView, "Người cập nhật", 7, 150), DADocument.getDM_NHAN_VIEN(), "ID", "NAME", "NGUOI_CAP_NHAT");
            XtraGridSupportExt.DateTimeGridColumn(
               XtraGridSupportExt.CreateGridColumn(gridView, "Ngày cập nhật", 8, 150), "NGAY_CAP_NHAT");
            gridView.GroupPanelText = "Danh sách tài liệu";
            gridView.BestFitColumns();
            gridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;

            gridView.Columns["NGUOI_GUI"].OptionsColumn.AllowEdit = false;
            gridView.Columns["NGAY_GUI"].OptionsColumn.AllowEdit = false;
            gridView.Columns["NGUOI_CAP_NHAT"].OptionsColumn.AllowEdit = false;
            gridView.Columns["NGAY_CAP_NHAT"].OptionsColumn.AllowEdit = false;
            gridView.OptionsView.ColumnAutoWidth = false;
            return null;
        }

        public static void addChildRow(DevExpress.XtraGrid.Views.Grid.GridView view, int indexRow)
        {
            int newRowHandle = view.FocusedRowHandle;
            object newRow = view.GetRow(newRowHandle);
            if (view.GroupedColumns.Count > 0)
            {
                for (int i = 0; i < view.GroupedColumns.Count; i++)
                {
                    view.SetRowCellValue(newRowHandle, view.GroupedColumns[i], indexRow);
                }
            }
        }

        public static void returnRowUpdate(DevExpress.XtraGrid.Views.Grid.GridView view, object row)
        {
            for (int n = 0; n < view.DataRowCount; n++)
            {
                if (view.GetRow(n).Equals(row))
                {
                    view.FocusedRowHandle = n;
                    break;
                }
            }
        }

        public static void setRowCellDefaultValue(DataRow row, DODocument doTailieu)
        {
            row.BeginEdit();
            //row["NGUOI_GUI"] = doTailieu.NGUOI_GUI;
            //row["NGAY_GUI"] = doTailieu.NGAY_GUI;
            row["NGUOI_CAP_NHAT"] = doTailieu.NGUOI_CAP_NHAT;
            row["NGAY_CAP_NHAT"] = doTailieu.NGAY_CAP_NHAT;
        }

    }
}
