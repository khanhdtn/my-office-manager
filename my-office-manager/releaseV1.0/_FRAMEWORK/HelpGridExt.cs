using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace ProtocolVN.Framework.Win
{
    public class HelpGridExt1
    {
        /// <summary>
        /// Chỉnh font chữ trong phần GroupPanel của lưới theo font chung
        /// </summary>
        /// <param name="Grid"></param>
        public static void SetDefaultGroupPanel(GridView Grid) {
            DisableCaptionGroupCol(Grid);
            Grid.OptionsView.ShowGroupedColumns = false;
        }
        
        public static void DisableCaptionGroupCol(GridView Grid) {
            Grid.GroupFormat = "[#image]{1} {2}";
        }

        public static void SetCellDisable(GridView view, string FieldName, string KeyField, long KeyValue)
        {
            long[] ids = new long[] { KeyValue };
            SetCellDisable(view, FieldName, KeyField, KeyValue);
        }
        public static void SetCellDisable(GridView view, string FieldName, string KeyField, long[] KeyValues)
        {
            view.CustomDrawCell += delegate(object sender, RowCellCustomDrawEventArgs e)
            {
                if (e.RowHandle == view.FocusedRowHandle) return;

                if (e.Column.FieldName == FieldName)
                {
                    for (int vt = 0; vt <= KeyValues.Length - 1; vt++)
                    {
                        if (Convert.ToInt64(view.GetRowCellDisplayText(e.RowHandle, KeyField)) == KeyValues[vt])
                        {
                            e.Appearance.BackColor = Color.Gray;
                        }
                    }
                }
            };
            view.ShowingEditor += delegate(object sender, CancelEventArgs e)
            {
                int index = view.FocusedRowHandle;
                if (index >= 0)
                {
                    for (int vt = 0; vt <= KeyValues.Length - 1; vt++)
                    {
                        if (Convert.ToInt64(view.GetRowCellDisplayText(index, KeyField)) == KeyValues[vt]
                            && view.FocusedColumn.FieldName == FieldName)
                        {
                            e.Cancel = true;
                        }
                    }
                }
            };
        }
        //Columns has a lot of rows.
        public static void colMultiline(DevExpress.XtraGrid.Columns.GridColumn column, String fielName)
        {
            RepositoryItemMemoEdit colMemo = new RepositoryItemMemoEdit();
            column.ColumnEdit = colMemo;
            column.FieldName = fielName;
            column.OptionsColumn.AllowEdit = false;
            column.OptionsColumn.AllowFocus = false;
            column.OptionsColumn.ReadOnly = true;
        }
        /// <summary>
        /// CHAUTV: Định dạng cột dạng RichTextBox
        /// </summary>
        public RepositoryItemRichTextEdit CotRichTextBox(GridColumn column, string ColumnField)
        {
            RepositoryItemRichTextEdit repRich = new RepositoryItemRichTextEdit();
            column.FieldName = ColumnField;
            column.ColumnEdit = repRich;
            return repRich;
        }
    }
}
