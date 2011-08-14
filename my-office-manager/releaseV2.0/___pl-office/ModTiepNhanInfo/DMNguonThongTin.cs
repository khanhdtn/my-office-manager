using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using ProtocolVN.Framework.Core;
using pl.office;
using System.Data;
using office;

namespace ProtocolVN.DanhMuc
{
    /// <summary>
    /// -Danh mục nguồn thông tin 
    /// -Bảng dữ liệu : DM_NGUON_THONG_TIN
    /// </summary>
    public class DMNguonThongTin : IDanhMuc
    {
        public static DMNguonThongTin I = new DMNguonThongTin();
        public string TABLE_MAP = "DM_NGUON_THONG_TIN";
        public static String N = typeof(DMNguonThongTin).FullName;
        public static bool isPermission = false;

        #region IDanhMuc Members

        public DevExpress.XtraEditors.XtraUserControl Init()
        {
            DMGrid basic = new DMGrid(TABLE_MAP, "ID", "NAME", "Nguồn thông tin", CreateDM_NGUON_INFO, GetRuleDM_NGUON_INFO);
            ((PLGridView)basic.Grid).BestFitColumns();
            if (isPermission) basic.DefinePermission(DanhMucParams.GetPermission(basic, N, "Nguồn thông tin"));
            return basic;
        }

        public string Item()
        {
            return
            @"<cat table='" + HelpFURL.FURL(N, "Init") + @"' type='action' picindex='mnbHopDongLienKet.png'>
                  <lang id='vn'>Nguồn thông tin</lang>
                  <lang id='en'></lang>
                </cat>";
        }

        public string MenuItem(string MainCat, string ParentID, bool IsSep)
        {
            return MenuItem(MainCat, "Nguồn thông tin", ParentID, IsSep);
        }

        public string MenuItem(string MainCat, string Title, string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(N, Title, ParentID, true,
                   HelpFURL.FURL(MainCat, N, "Init"), true, IsSep, "mnbHopDongLienKet.png   ", false, "", "");
        }

        #endregion
        public void InitCtrl(PLImgCombobox Input, bool? IsAdd)
        {
            DataSet ds = new DataSet();
            QueryBuilder query = null;
            if (IsAdd == true)
                query = new QueryBuilder("SELECT * FROM DM_NGUON_THONG_TIN where VISIBLE_BIT = 'Y' AND 1=1");
            else
                query = new QueryBuilder("SELECT * FROM DM_NGUON_THONG_TIN where 1=1");
            ds = HelpDB.getDatabase().LoadDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
            query.setAscOrderBy("ID");
        }
        public GridColumn[] CreateDM_NGUON_INFO(GridControl gridControl, GridView gridView)
        {
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "ID", -1, -1), "ID");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Nguồn thông tin", 0, 450), "NAME");
            HelpGridColumn.CotCheckEdit(
                XtraGridSupportExt.CreateGridColumn(gridView, "Đang dùng", 11, 150), "VISIBLE_BIT");
            gridView.OptionsView.ShowGroupedColumns = false;
            gridView.GroupPanelText = "Danh sách nguồn thông tin";
            gridView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            gridView.OptionsView.ColumnAutoWidth = true;
            PLGUIUtil.TrimSpaceForGrid(gridView, new string[] { "NAME" });
            ((PLGridView)gridView)._SetDesignLayout();
            return null;
        }
        public FieldNameCheck[] GetRuleDM_NGUON_INFO(object param)
        {
            return new FieldNameCheck[] { new FieldNameCheck("NAME"
                , new CheckType[] { CheckType.Required, CheckType.RequireMaxLength }
                , new string[]{HelpErrorMsg.errorRequired("Nguồn thông tin"),string.Format("Vui lòng vào thông tin \"Nguồn thông tin\" ngắn hơn ({0} ký tự)!",100)}
                , new object[] { null, 100 }) };
        }
    }
}
