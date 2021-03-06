using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data.Common;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Collections;

namespace pl.office.form
{
    public partial class frmThemNhanVienQL : XtraFormPL,IFormChild
    {
        #region 1.0.Danh sách biến toàn cục
        public DataTable dsNhanVienAdd = new DataTable();
        #endregion
        #region 2.0.Hàm khởi tạo
        public frmThemNhanVienQL(string Input)
        {
            InitializeComponent();
            InitGrid();
            InitButtonImage();
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(Input);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            ds.Tables[0].Columns.Add("CHON",Type.GetType("System.String"));
            gridControlMaster.DataSource = ds.Tables[0];
        }

        public void InitControl()
        {
            
        }
        
        public void InitData()
        {
            
        }

        public void InitEnabledControl()
        {
           
        }

        public void InitNghiepVu()
        {
            
        }

        public void InitButtonImage()
        {
            btn_DongY.Image = FWImageDic.SAVE_ALL_IMAGE20;
            btn_Dong.Image = FWImageDic.CLOSE_IMAGE20;
        }

        public void InitGrid()
        {
            XtraGridSupportExt.TextLeftColumn(Cot_ID, "ID");
            XtraGridSupportExt.TextLeftColumn(Cot_HoTen, "TEN_NV");
            XtraGridSupportExt.CloseButton(gridControlMaster, gridViewMaster);
            this.GridColumnsCheckEdit(Cot_Chon, "CHON", "Y", "N");
        }
        #endregion

        #region 3.0.Xử lý sự kiện (Lưu,Thêm,...)

        #endregion

        #region 4.0.Phần mở rộng
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit GridColumnsCheckEdit(GridColumn InputCoulumn, string FieldName,object ValueChecked,object ValueUnchecked)
        {
            RepositoryItemCheckEdit rep = new RepositoryItemCheckEdit();
            rep.ValueChecked = ValueChecked;
            rep.ValueUnchecked = ValueUnchecked;
            rep.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            InputCoulumn.ColumnEdit = rep;
            return rep;
        }
        #endregion

        #region 5.0.Phần giữ chỗ
        #endregion

        #region 6.0.Phần xử lý Validation
        public bool IsValidate()
        {
            return true;
        }
        #endregion

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            //DataTable tb = gridControlMaster.DataSource as DataTable;
            //tb.AcceptChanges();
            //IEnumerable <DataRow> DanhSach = from r in tb.
            

            //dsNhanVienAdd.AcceptChanges();
            //this.Close();
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}