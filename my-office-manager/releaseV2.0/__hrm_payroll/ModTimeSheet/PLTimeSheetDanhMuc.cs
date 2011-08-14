using DevExpress.XtraEditors;
using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using System;
using DevExpress.XtraEditors.Repository;
namespace ProtocolVN.Plugin.TimeSheet
{
    public class PLTimeSheetDanhMuc
    {
        public static string CreateDanhMuc()
        {
            String clsName = typeof(PLTimeSheetDanhMuc).FullName;
            return
                @"<?xml version='1.0' encoding='utf-8' standalone='yes'?>
                <basiccats>
                  <group id ='1'>
                    <lang id='vn'>Dự án</lang>
                    <cat table='"+clsName+@"?param=DM_LOAI_DU_AN' type='action' picindex='navPhongBan.png'>
                      <lang id='vn'>Loại dự án</lang>
                      <lang id='en'></lang>
                    </cat>  
                    <cat table='"+clsName+@"?param=DU_AN' type='action' picindex='navPhongBan.png'>
                      <lang id='vn'>Dự án</lang>
                      <lang id='en'></lang>
                    </cat>  
                    <cat table='" + clsName + @"?param=CONG_VIEC' type='action' picindex='navNhanVien.png'>
                      <lang id='vn'>Công việc</lang>
                      <lang id='en'></lang>
                    </cat>
                  </group>  
                </basiccats>";

        }

        #region DM_LOAI_DU_AN
        private GridColumn[] CreateLOAI_DU_AN(GridControl gridControl, GridView gridView)
        {
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "ID", -1, -1), "ID");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Loại dự án", 0, 150), "NAME");
            HelpGridColumn.CotPLHienThi(
                XtraGridSupportExt.CreateGridColumn(gridView, GlobalConst.VISIBLE_TITLE, 1, 150), "VISIBLE_BIT");
            return null;

        }
        private FieldNameCheck[] GetRuleLOAI_DU_AN(object param)
        {
            return new FieldNameCheck[] { 
                        new FieldNameCheck("NAME",
                            new CheckType[]{ CheckType.Required, CheckType.RequireMaxLength },
                            "Loại dự án", 
                            new object[]{ null, 200 }),
                        new FieldNameCheck("VISIBLE_BIT",
                            new CheckType[]{ CheckType.OptionMaxLength },
                            GlobalConst.VISIBLE_TITLE, 
                            new object[]{ 1 })
                          
            };
        }
        public XtraUserControl DM_LOAI_DU_AN()
        {
            DMGrid basic = new DMGrid("DM_LOAI_DU_AN", "ID", "NAME", "Loại dự án", CreateLOAI_DU_AN, GetRuleLOAI_DU_AN);
            basic.DefinePermission(HelpPermission.CategoryPermission(basic, "Quan tri Timesheet"));
            return basic;
        }
        #endregion

        #region DM_DU_AN
        private GridColumn[] CreateDU_AN(GridControl gridControl, GridView gridView)
        {
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "ID", -1, -1), "ID");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Tên dự án", 0, 150), "NAME");
            GridColumn cotloaiduan = XtraGridSupportExt.CreateGridColumn(gridView, "Loại dự án", 1, -1);
            XtraGridSupportExt.ComboboxGridColumn(cotloaiduan, "DM_LOAI_DU_AN", "ID", "NAME", "LOAI_DU_AN");
            cotloaiduan.Width = 100;
            HelpGridColumn.CotPLHienThi(
                XtraGridSupportExt.CreateGridColumn(gridView, GlobalConst.VISIBLE_TITLE, 1, 150), "VISIBLE_BIT");
            return null;

        }
        private FieldNameCheck[] GetRuleDU_AN(object param)
        {
            return new FieldNameCheck[] { 
                        new FieldNameCheck("NAME",
                            new CheckType[]{ CheckType.Required, CheckType.RequireMaxLength },
                            "Tên dự án",
                            new object[]{ null, 200 }),
                        new FieldNameCheck("LOAI_DU_AN",
                            new CheckType[]{ CheckType.Required, CheckType.RequireMaxLength },
                            "Loại dự án",
                            new object[]{ null, 200 }),
                        new FieldNameCheck("VISIBLE_BIT",
                            new CheckType[]{ CheckType.OptionMaxLength },
                            GlobalConst.VISIBLE_TITLE, 
                            new object[]{ 1 })
                          
            };
        }
        public XtraUserControl DU_AN()
        {
            DMGrid basic = new DMGrid("DU_AN", "ID", "NAME", "Dự án", CreateDU_AN, GetRuleDU_AN);
            basic.DefinePermission(HelpPermission.CategoryPermission(basic, "Quan tri Timesheet"));
            return basic;
        }
        #endregion

        #region CONG_VIEC
        private GridColumn[] CreateCONG_VIEC(GridControl gridControl, GridView gridView)
        {
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "ID", -1, -1), "ID");
            XtraGridSupportExt.TextLeftColumn(
                XtraGridSupportExt.CreateGridColumn(gridView, "Tên công việc", 0, 150), "NAME");
            GridColumn cotloaiduan = XtraGridSupportExt.CreateGridColumn(gridView, "Loại dự án", 1, -1);
            XtraGridSupportExt.ComboboxGridColumn(cotloaiduan, "DM_LOAI_CONG_VIECN", "ID", "NAME", "LOAI_CONG_VIEC");
            cotloaiduan.Width = 100;
            HelpGridColumn.CotPLHienThi(
                XtraGridSupportExt.CreateGridColumn(gridView, "Hiển thị", 2, 150), "VISIBLE_BIT");
            return null;

        }
        private FieldNameCheck[] GetRuleCONG_VIEC(object param)
        {
            return new FieldNameCheck[] { 
                        new FieldNameCheck("NAME",
                            new CheckType[]{ CheckType.Required, CheckType.RequireMaxLength },
                            "Tên công việc", 
                            new object[]{ null, 200 }),
                        new FieldNameCheck("LOAI_CONG_VIEC",
                            new CheckType[]{ CheckType.Required, CheckType.RequireMaxLength },
                            "Loại công việc",
                            new object[]{ null, 200 }),
                        new FieldNameCheck("VISIBLE_BIT",
                            new CheckType[]{ CheckType.OptionMaxLength },
                            GlobalConst.VISIBLE_TITLE, 
                            new object[]{ 1 })
                          
            };
        }
        public XtraUserControl CONG_VIEC()
        {
            DMGrid basic = new DMGrid("CONG_VIEC", "ID", "NAME", "Công việc", CreateCONG_VIEC, GetRuleCONG_VIEC);
            basic.DefinePermission(HelpPermission.CategoryPermission(basic, "Quan tri Timesheet"));
            return basic;
        }
        #endregion
    }
}
