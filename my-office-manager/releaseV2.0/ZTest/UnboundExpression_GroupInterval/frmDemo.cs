using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using ProtocolVN.Framework.Core;

namespace pl.office.ZTest.UnboundExpression
{
    
    public partial class frmDemo : XtraFormPL
    {
        #region Khai báo MenuItem
        public static FormStatus Status = FormStatus.OK_DEV;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDemo).FullName,
                PMSupport.UpdateTitle("Demo FW", Status),
                ParentID, true,
                typeof(frmDemo).FullName,
                false, IsSep, "fwAdd.png", true, "", "");
        }
        #endregion


        public frmDemo()
        {
            InitializeComponent();
            HelpGridColumn.CotTextLeft(cotID, "ID");
            HelpGridColumn.CotTextLeft(cotName, "NAME");
            HelpGridColumn.CotCalcEdit(cotA, "A", 0);
            HelpGridColumn.CotCalcEdit(cotB, "B", 0);
            HelpGridColumn.CotCalcEdit(cotC, "C", 0);
            HelpGridColumn.CotDateEdit(cotDate, "DATE");
            this.gridControlDemo.DataSource = this.getDataSet.Tables[0];
            this.gridViewDemo.OptionsBehavior.AutoExpandAllGroups = true;

            //Áp dụng tính toán trên cột
            Help.AppUnboundExpression(this.gridViewDemo);
            
            //Áp dụng tùy biến gom nhóm
            Help.AppGroupInterval(this.gridViewDemo);
        }

        public DataSet getDataSet {
            get {
                DataTable tb = new DataTable("DEMO");
                tb.Columns.Add("ID", typeof(System.Int64));
                tb.Columns.Add("NAME", typeof(System.String));
                tb.Columns.Add("A", typeof(System.Decimal));
                tb.Columns.Add("B", typeof(System.Decimal));
                tb.Columns.Add("C", typeof(System.Decimal));
                tb.Columns.Add("DATE", typeof(DateTime));

                tb.Rows.Add(1, "Bánh mì", 1, 1, 2,DateTime.Today);
                tb.Rows.Add(2, "Phở gà", 3, 1, 6,DateTime.Today.AddDays(1));
                tb.Rows.Add(3, "Mỳ tôm", 6, 7, 2,DateTime.Today.AddDays(1));
                tb.Rows.Add(4, "Kẹo", 1, 10, 8,DateTime.Today.AddDays(10));
                tb.Rows.Add(5, "Nước ngọt", 11, 10, 8, DateTime.Today.AddDays(-200));
                DataSet ds = new DataSet();
                ds.Tables.Add(tb);
                return ds;    
            }
        }

    }
}