using System;
using System.Collections.Generic;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data;
using System.Windows.Forms;
using office;

namespace ProtocolVN.DanhMuc
{
    public class DMNhomDanhBaExt : IDanhMuc
    {
        public static DMNhomDanhBaExt I = new DMNhomDanhBaExt();
        public string TABLE_MAP = "DM_NHOM_DANH_BA";
        public static String N = typeof(DMNhomDanhBaExt).FullName;
        public static bool isPermission = false;

        #region IDanhMuc Members

        public DevExpress.XtraEditors.XtraUserControl Init()
        {
            DMGrid basic = new DMGrid(TABLE_MAP, "ID", "NAME", "Tên nhóm", CreateDM_NHOM_DB, GetRuleDM_NHOM_DB);
            if (isPermission) basic.DefinePermission(DanhMucParams.GetPermission(basic, N, "Nhóm danh bạ"));
            return basic;
        }

        public string Item()
        {
            return
            @"<cat table='" + HelpFURL.FURL(N, "Init") + @"' type='action' picindex='blockContact.png'>
                  <lang id='vn'>Nhóm danh bạ</lang>
                  <lang id='en'></lang>
                </cat>";
        }

        public string MenuItem(string MainCat, string ParentID, bool IsSep)
        {
            return MenuItem(MainCat, "Nhóm danh bạ", ParentID, IsSep);
        }

        public string MenuItem(string MainCat, string Title, string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(N, Title, ParentID, true,
                  HelpFURL.FURL(MainCat, N, "Init"), true, IsSep, "blockContact.png", false, "", "");
        }

        #endregion

        public void InitCtrl(PLDMGrid Input, bool ReadOnly, bool? IsAdd)
        {
            QueryBuilder query = new QueryBuilder(string.Format("SELECT * FROM {0} WHERE 1=1", TABLE_MAP));
            if (IsAdd != null)
            {
                query.addBoolean("VISIBLE_BIT", true);
            }
            Input._init((ReadOnly == true ? GroupElementType.ONLY_CHOICE : GroupElementType.CHOICE_N_ADD), HelpDB.getDatabase().LoadDataSet(query, TABLE_MAP).Tables[0], "ID", "NAME",
                new string[] { "ID" }, new string[] { "ID" }, HelpDanhMuc.CreateDM_BASIC_V, HelpDanhMuc.GetRuleDM_BASIC, null, null, null, null);
            if (ReadOnly)
            {
                try
                {
                    Input.GetDMGrid.btnUpdate.Visible = false;
                    Input.GetDMGrid.btnDel.Visible = false;
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
            }
        }

        public GridColumn[] CreateDM_NHOM_DB(GridControl gridControl, GridView gridView)
        {
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "ID", -1, -1), "ID");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Tên nhóm", 0, 150), "NAME");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Tên liên lạc", 1, 150), "NAME_BIT");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Người liên hệ", 2, 150), "NGUOI_DAI_DIEN");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Chức vụ", 3, 150), "CHUC_VU");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Điạ chỉ", 4, 150), "DIA_CHI");
            HelpGridColumn.CotCheckEdit(
               XtraGridSupportExt.CreateGridColumn(gridView, "Điện thoại bàn", 5, 150), "SO_DIEN_THOAI");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Di động", 6, 150), "DI_DONG");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Fax", 7, 150), "SO_FAX");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Email", 8, 150), "EMAIL");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Số tài khoản", 9, 150), "TAI_KHOAN");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Tên ngân hàng", 10, 150), "TEN_NGAN_HANG");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Đang dùng", 11, 150), "VISIBLE_BIT");
            gridView.OptionsView.ShowGroupedColumns = false;
            gridView.GroupPanelText = "Danh sách nhóm danh bạ";
            gridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView.OptionsView.ColumnAutoWidth = true;
            ((PLGridView)gridView).DefaultNewRow = new PLGridView.DefaultValueNewRow(DefaultRow);
            ((PLGridView)gridView)._SetDesignLayout();
            return null;
        }

        private static void DefaultRow(DataRow row)
        {
            //row["NAME"] = "Y";
        }

        public FieldNameCheck[] GetRuleDM_NHOM_DB(object param)
        {
            return new FieldNameCheck[] { new FieldNameCheck("NAME", new CheckType[] { CheckType.Required, CheckType.RequireMaxLength }, "Tên nhóm", new object[] { null, 200 }) };
        }
    }
}

