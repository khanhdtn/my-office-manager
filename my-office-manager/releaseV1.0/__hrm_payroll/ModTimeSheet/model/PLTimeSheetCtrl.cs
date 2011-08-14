using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data;
using DevExpress.XtraGrid.Columns;
namespace ProtocolVN.Plugin.TimeSheet
{
    public class PLTimeSheetCtrl
    {
        #region CHON
        public static void ChonNhanVien_LookupEdit(PLLookupEdit input)
        {
            string Sql = "Select NV.* from DM_NHAN_VIEN NV inner join USER_CAT US on nv.id=us.employee_id where 1=1";
            QueryBuilder query = new QueryBuilder(Sql);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            string[] fieldnames = { "NAME", "NGAY_SINH", "DIA_CHI", "DIEN_THOAI", "EMAIL" };
            string[] titlers = { "TenNV", "Ngày sinh", "Địa chỉ", "Điện thoại", "Email" };
            int[] widths = { 100, 100, 100, 100, 100 };
            input._init(ds.Tables[0], "NAME", "ID", "", fieldnames, titlers, widths);
            input._lookUpEdit.AutoSizeInLayoutControl = true;
            input._lookUpEdit.Properties.PopupWidth = 500;
        }
        public static void ChonLoaiCongViec(PLCombobox input)
        {
            string sql = "select NAME, ID from DM_LOAI_CONG_VIECN where VISIBLE_BIT = 'Y'";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._init();
        }
        public static void ChonDuAn(PLCombobox input)
        {
            string sql = "select NAME, ID from DU_AN where VISIBLE_BIT = 'Y'";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();

        }

        //PHUOCNC : Tại sao có 2 cái phân biệt thế này.
        public static void ChonNhanVienRPT(PLCombobox input)
        {
            string sql = "select * from DM_NHAN_VIEN";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();
        } 

        public static void ChonNhanVien(PLCombobox input)
        {
            string sql = "Select NV.* from DM_NHAN_VIEN NV inner join USER_CAT US on nv.id=us.employee_id";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();

        }        
        public static void ChonLoaiDuAn(PLCombobox input)
        {
            string sql = "select * from DM_LOAI_DU_AN where VISIBLE_BIT='Y'";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource=ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();
        }
        public static void ChonCongViec(PLCombobox input)
        {
            string sql = "select * from CONG_VIEC where VISIBLE_BIT='Y'";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();
        }
        #endregion

        #region Cot
        public static void CotLoaiDuAn(GridColumn column, string input)
        {
            column.FieldName = input;
            XtraGridSupportExt.IDGridColumn(column, "ID", "NAME", "DM_LOAI_DU_AN");
        }
        public static void CotDuAn(GridColumn column, string input)
        {
            column.FieldName = input;
            XtraGridSupportExt.IDGridColumn(column, "ID", "NAME", "DU_AN");
        }
        public static void CotCongViec(GridColumn column, string input)
        {
            column.FieldName = input;
            XtraGridSupportExt.IDGridColumn(column, "ID", "NAME", "CONG_VIEC");
        }
        public static void CotNhanVien(GridColumn column, string input)
        {
            column.FieldName = input;
            XtraGridSupportExt.IDGridColumn(column, "ID", "NAME", "DM_NHAN_VIEN");
        }
        #endregion
    }
}
