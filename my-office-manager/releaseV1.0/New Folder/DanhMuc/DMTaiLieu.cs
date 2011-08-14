using System;
using System.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace ProtocolVN.DanhMuc
{
    /// <summary>
    /// DUYVT: Hổ trợ cho màn hình Phân quyền Nhân viên - Tài liệu
    /// </summary>
    public class DMTaiLieu : IDanhMuc
    {
        public static DMTaiLieu I = new DMTaiLieu();
        public static String N = typeof(DMTaiLieu).FullName;
        public static bool isPermission = false;

        #region IDanhMuc Members

        public XtraUserControl Init()
        {
            DataSet dt = HelpDB.getDatabase().LoadDataSet("select * from DM_TAI_LIEU where id=-1", "DM_TAI_LIEU");
            DMTreeGroupElement pl = new DMTreeGroupElement();
            pl.Init(GroupElementType.ONLY_INPUT,
                "DM_LOAI_TAI_LIEU", null, "ID", "PARENT_ID",
                 new string[] { "NAME" }, new string[] { "Tên loại tài liệu" }, dt,
                "ID", "LOAI_TAI_LIEU_ID", "NAME", HelpGen.G_FW_DM_ID, CreateDM_TAI_LIEU, GetRuleDM_TAI_LIEU);
            if (isPermission) pl.DefinePermission(DanhMucParams.GetPermission(pl, DMTaiLieu.N, "Danh má»¥c tÃ i liá»‡u"));
            return pl;
        }

        public string Item()
        {
            return
            @"<cat table='" + PL.FURL(N, "Init") + @"' type='action' picindex='navHanghoa.png'>
                  <lang id='vn'>Tài liệu</lang>
                  <lang id='en'></lang>
                </cat>";
        }

        public string MenuItem(string MainCat, string ParentID, bool IsSep)
        {
            return MenuItem(MainCat, "Tài liệu", ParentID, IsSep);
        }

        public string MenuItem(string MainCat, string Title, string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(N, Title, ParentID, true,
                           PL.FURL(MainCat, N, "Init"), true, IsSep, "navHanghoa.png", false, "", "");
        }

        #endregion

        public GridColumn[] CreateDM_TAI_LIEU(GridControl gridControl, GridView gridView)
        {
            HelpGridColumn.CotTextLeft(
                HelpGridColumn.ThemCot(gridView, "ID", -1, -1), "ID");
            HelpGridColumn.CotTextLeft(
                HelpGridColumn.ThemCot(gridView, "Tên tài liệu", 0, 150), "NAME");
            HelpGridColumn.CotTextLeft(
                HelpGridColumn.ThemCot(gridView, "Phiên bản", 1, 150), "PHIEN_BAN");

            GridColumn ColLoaiTL = HelpGridColumn.ThemCot(gridView, "Tên loại tài liệu", 2, -1);
            XtraGridSupportExt.IDGridColumn(ColLoaiTL, "ID", "NAME", "DM_LOAI_TAI_LIEU", "LOAI_TAI_LIEU_ID");
            ColLoaiTL.OptionsColumn.AllowEdit = true;
            ColLoaiTL.OptionsColumn.AllowFocus = false;
            ColLoaiTL.OptionsColumn.ReadOnly = true;
            GridColumn ColNguoiCapNhat = HelpGridColumn.ThemCot(gridView, "Người cập nhật", 3, 150);
            XtraGridSupportExt.IDGridColumn(ColNguoiCapNhat, "ID", "NAME", "DM_NHAN_VIEN", "NGUOI_CAP_NHAT");
            gridView.GroupCount = 1;
            gridView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
                new DevExpress.XtraGrid.Columns.GridColumnSortInfo(ColLoaiTL, DevExpress.Data.ColumnSortOrder.Ascending)}
            );            
            
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsView.ShowAutoFilterRow = false;
            gridView.OptionsView.ShowGroupedColumns = false;
            gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

            GridColumn CotVisible = HelpGridColumn.ThemCot(gridView, "Đang dùng", 18, 50);
            CotVisible.OptionsColumn.AllowEdit = false;
            CotVisible.OptionsColumn.AllowFocus = false;
            CotVisible.OptionsColumn.ReadOnly = true;
            HelpGridColumn.CotCheckEdit(CotVisible, "VISIBLE_BIT");

            ((PLGridView)gridView).DefaultNewRow = ProtocolVN.Framework.Win.HelpGrid.CheckVisibleDefault;
            ((PLGridView)gridView)._SetUserLayout();
            return null;
        }

        public FieldNameCheck[] GetRuleDM_TAI_LIEU(object param)
        {
            return new FieldNameCheck[] {                         
                        
                        new FieldNameCheck("NAME",
                            new CheckType[]{ CheckType.Required , CheckType.OptionMaxLength },
                            "Tên tài liệu", 
                            new object[]{ null, 200 }),
                    };
        }
    }
}
