using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using ProtocolVN.Framework.Win;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace pl.office.ZTest.UnboundExpression
{
    public class Help
    {
        /// <summary>
        /// Áp dụng UnboundExpression cho lưới
        /// </summary>
        /// <param name="gridView">Lưới áp dụng</param>
        public static void AppUnboundExpression(GridView gridView)
        {
            gridView.ShowGridMenu += delegate(object sender, GridMenuEventArgs e) {
                if (e.Menu is GridViewColumnMenu)
                {
                    GridViewColumnMenu menu = (GridViewColumnMenu)e.Menu;
                    if (menu.Column != null)
                    {
                        #region Cột tính trên lưới
                        DXSubMenuItem item = new DXSubMenuItem("Thêm cột tính");
                        item.BeginGroup = true;
                        menu.Items.Add(item);
                        item.Click += delegate(object senderItem, EventArgs eItem)
                        {
                            InputBoxResult input = HelpMsgBox._showMsgInput("Nhập tên cột cần tạo");
                            if (input.ReturnCode == DialogResult.OK)
                            {
                                string Field = input.Text.Trim();
                                GridColumn column = HelpGridColumn.ThemCot(gridView, Field, gridView.Columns.Count + 1, 100);
                                column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
                                column.FieldName = Field;
                                column.OptionsColumn.AllowEdit = false;
                                column.ShowUnboundExpressionMenu = true;
                            }
                        };

                        if (menu.Column.ShowUnboundExpressionMenu)
                        {
                            DXSubMenuItem itemXoa = new DXSubMenuItem("Xóa cột tính này");
                            menu.Items.Add(itemXoa);
                            itemXoa.Click += delegate(object senderXoa, EventArgs eXoa)
                            {
                                gridView.Columns.Remove(menu.Column);
                            };
                        } 
                        #endregion
                    }
                }
            };
        }

        /// <summary>
        /// Tùy chọn gom nhóm
        /// </summary>
        /// <param name="gridView"></param>
        public static void AppGroupInterval(GridView gridView)
        {
            gridView.ShowGridMenu += delegate(object sender, GridMenuEventArgs e)
            {
                if (e.Menu is GridViewColumnMenu)
                {
                    GridViewColumnMenu menu = (GridViewColumnMenu)e.Menu;
                    if (menu.Column != null)
                    {
                        #region Thêm item GroupInterval
                        DXSubMenuItem itemDateInterval = new DXSubMenuItem("Tùy chọn gom nhóm (GroupInterval)");
                        itemDateInterval.BeginGroup = true;
                        menu.Items.Add(itemDateInterval);
                        itemDateInterval.Click += delegate(object senderDateInterval, EventArgs eDateInterval)
                        {
                            HelpProtocolForm.ShowModalDialog((XtraForm)gridView.GridControl.FindForm(), new frmGroupIntervalOption(gridView));
                        };
                        #endregion
                    }
                }
            };
        }
    }
}
