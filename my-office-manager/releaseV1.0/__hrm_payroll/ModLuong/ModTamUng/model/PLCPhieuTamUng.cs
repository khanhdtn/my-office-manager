using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Views.Grid;
using ProtocolVN.Framework.Core;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;

namespace office
{
    public class PLCPhieuTamUng : PLCPhieu
    {
        public static PLCPhieuTamUng I = new PLCPhieuTamUng();
        #region PLCPhieu Members

        public List<System.Windows.Forms.Control> GetFormatControls(DevExpress.XtraEditors.XtraForm formModPhieu)
        {
            throw new NotImplementedException();
        }

        public List<object> GetObjectItems(DevExpress.XtraEditors.XtraForm formModPhieu)
        {
            throw new NotImplementedException();
        }

        public PhieuType GetPhieuType()
        {
            throw new NotImplementedException();
        }

        public _Print GetPrintObj(DevExpress.XtraEditors.XtraForm frmMain, long[] IDs)
        {
            throw new NotImplementedException();
        }

        public FieldNameCheck[] GetRule(object DAModPhieu)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Init PLDMGrid
        private static GridColumn[] CreateDepartmentGrid(GridControl gridControl, GridView gridView)
        {
            HelpGridColumn.CotTextLeft(
                HelpGridColumn.ThemCot(gridView, "ID", -1, -1), "ID");
            HelpGridColumn.CotTextLeft(
                HelpGridColumn.ThemCot(gridView, "Tên bộ phận", 0, 450), "NAME");                       
            gridView.GroupCount = 1;            
            ((PLGridView)gridView).DefaultNewRow = ProtocolVN.Framework.Win.HelpGrid.CheckVisibleDefault; ;
            gridView.OptionsView.ShowGroupedColumns = true;
            gridView.OptionsView.ColumnAutoWidth = false;
            return null;
        }
        private static FieldNameCheck[] GetRuleHopDongGrid(object param)
        {
            return new FieldNameCheck[] { 
                        new FieldNameCheck("NAME",
                            new CheckType[]{ CheckType.RequiredID , CheckType.RequiredID },
                            "Tên bộ phận", 
                            new object[]{ null, 100 })                                                                    
            };
        }
        public void InitCtrl(PLDMGrid Input, bool ReadOnly)
        {
            Input._init((ReadOnly == true ? GroupElementType.ONLY_CHOICE : GroupElementType.CHOICE_N_ADD), HelpDB.getDatabase().LoadDataSet("SELECT * FROM DM_VI_TRI_UNG_TUYEN WHERE VISIBLE_BIT='Y'", "DM_VI_TRI_UNG_TUYEN").Tables[0], "ID", "NAME",
                new string[] { "ID" }, new string[] { "ID" }, CreateDepartmentGrid, GetRuleHopDongGrid, null, null, null, null);
            if (ReadOnly)
            {
                try
                {
                    ((System.Windows.Forms.ToolStrip)Input.Controls[0].Controls[0].Controls[1]).Items[4].Visible = true;// Ẩn nút sửa
                    ((System.Windows.Forms.ToolStrip)Input.Controls[0].Controls[0].Controls[1]).Items[5].Visible = true;// Ẩn nút Xóa
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion        
    }
}
