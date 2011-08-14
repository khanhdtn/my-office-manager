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
    /// Khanhdtn: hổ trợ phân quyền nhân viên - danh bạ
    /// </summary>
    public class DMDanhBa : IDanhMuc
    {
        public static DMDanhBa I = new DMDanhBa();
        public static String N = typeof(DMDanhBa).FullName;
        public static bool isPermission = false;

        #region IDanhMuc Members

        public XtraUserControl Init()
        {
            DataSet dt = HelpDB.getDatabase().LoadDataSet("select * from DANH_BA where id=-1", "DANH_BA");
            DMTreeGroupElement pl = new DMTreeGroupElement();
            pl.Init(GroupElementType.ONLY_INPUT,
                "DM_NHOM_DANH_BA", null, "ID", "PARENT_ID",
                 new string[] { "NAME" }, new string[] { "Tên nhóm danh bạ" }, dt,
                "ID", "LOAI_DANH_BA", "NAME", HelpGen.G_FW_DM_ID, CreateDM_DANH_BA, GetRuleDM_DANHBA);
            if (isPermission) pl.DefinePermission(DanhMucParams.GetPermission(pl, DMTaiLieu.N, "Danh má»¥c tÃ i liá»‡u"));
            return pl;
        }

        public string Item()
        {
            return
            @"<cat table='" + PL.FURL(N, "Init") + @"' type='action' picindex='navHanghoa.png'>
                  <lang id='vn'>Danh bạ</lang>
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

        public GridColumn[] CreateDM_DANH_BA(GridControl gridControl, GridView gridView)
        {
            HelpGridColumn.CotTextLeft(
                HelpGridColumn.ThemCot(gridView, "ID", -1, -1), "ID");
            HelpGridColumn.CotTextLeft(
                HelpGridColumn.ThemCot(gridView, "Tên tài liệu", 0, 150), "NAME");
            HelpGridColumn.CotTextLeft(
                HelpGridColumn.ThemCot(gridView, "Địa chỉ", 1, 150), "DIA_CHI");
            HelpGridColumn.CotTextLeft(
              HelpGridColumn.ThemCot(gridView, "Số điện thoại", 2, 150), "SO_DIEN_THOAI");
            HelpGridColumn.CotTextLeft(
            HelpGridColumn.ThemCot(gridView, "Di động", 3, 150), "DI_DONG");
            HelpGridColumn.CotTextLeft(
              HelpGridColumn.ThemCot(gridView, "Fax", 4, 150), "SO_FAX");
            HelpGridColumn.CotTextLeft(
              HelpGridColumn.ThemCot(gridView, "Người đại diện", 5, 150), "NGUOI_DAI_DIEN");
            HelpGridColumn.CotTextLeft(
              HelpGridColumn.ThemCot(gridView, "Chức vụ", 6, 150), "CHUC_VU");
          
            HelpGridColumn.CotTextLeft(
              HelpGridColumn.ThemCot(gridView, "Số tài khoản", 7, 150), "TAI_KHOAN");
            XtraGridSupportExt.ComboboxGridColumn(HelpGridColumn.ThemCot(gridView, "Ngân hàng", 1, 150), " DM_BANK", "ID", "NAME", "TEN_NGAN_HANG").NullText = string.Empty;
            gridView.OptionsView.ColumnAutoWidth = false;
            gridView.OptionsView.ShowAutoFilterRow = false;
            gridView.OptionsView.ShowGroupedColumns = false;
            gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;

          

            ((PLGridView)gridView).DefaultNewRow = ProtocolVN.Framework.Win.HelpGrid.CheckVisibleDefault;
            ((PLGridView)gridView)._SetUserLayout();
            return null;
        }

        public FieldNameCheck[] GetRuleDM_DANHBA(object param)
        {
            return new FieldNameCheck[] {                         
                        
                        new FieldNameCheck("NAME",
                            new CheckType[]{ CheckType.Required , CheckType.OptionMaxLength },
                            "Tên danh bạ", 
                            new object[]{ null, 200 }),
                    };
        }
    }
}
