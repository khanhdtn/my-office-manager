using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System;
using System.Data;
using DevExpress.XtraGrid.Columns;
using System.Data.Common;
using System.Windows.Forms;

namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmKeHoachLamViecQL : TimPopupChange
    {
        //#region Các biến của form quản lý tuyệt đối không thay đổi
        //public DevExpress.XtraBars.BarManager barManager1;
        //public DevExpress.XtraBars.Bar MainBar;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //public DevExpress.XtraBars.BarDockControl barDockControlTop;
        //public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //public DevExpress.XtraBars.BarDockControl barDockControlRight;
        //public DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //public DevExpress.XtraGrid.GridControl gridControlMaster;
        //public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //public DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //public DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //public DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //public DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //public DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //public DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //public DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //public DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //public DevExpress.XtraBars.PopupMenu popupMenu1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemChon;
        //#endregion
        public frmKeHoachLamViecQL()
        {
            InitializeComponent();
            IDField = "DA_ID";
            this.SupportIn = false;
            this.SupportThem = true;
            this.SupportChon = false;
            new TimPopupFix(this);
            DataSet dsGrid = GetData(DABase.getDatabase().GetSystemCurrentDateTime(),0);
            this.gridControlMaster.DataSource = dsGrid.Tables[0];
            gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewMaster.OptionsCustomization.AllowGroup = true;
        }
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(Cotduan, "DUAN");
            XtraGridSupportExt.TextLeftColumn(Cotcongviec, "CONGVIEC");
            XtraGridSupportExt.TextLeftColumn(Cotmota, "MO_TA");
            HelpGridColumn.CotPLTimeEdit(Cotbatdau, "BAT_DAU", "HH:mm");
            HelpGridColumn.CotPLTimeEdit(Cotketthuc, "KET_THUC", "HH:mm");
            HelpGridColumn.CotPLTimeEdit(Cotthoigian, "THOI_GIAN_THUC_HIEN", "HH:mm");
            HelpGridColumn.CotReadOnlyDate(cotngaylamviec, "NGAY_LAM_VIEC");
            XtraGridSupportExt.TextLeftColumn(cotnhanvien, "NHANVIEN");
            GridColumn column = new GridColumn();
            XtraGridSupportExt.CreateDuyetGridColumn(column);
            this.gridViewMaster.Columns.Add(column);
            this.cotnhanvien.Visible = false;
            this.cotngaylamviec.Visible = false;
        }

        public override void PLLoadFilterPart()
        {
            DenNgay.DateTime = DateTime.Now;
            PLTimeSheetCtrl.ChonDuAn(Duan);
            PLTimeSheetCtrl.ChonNhanVien_LookupEdit(nhanvien);
            PLTimeSheetCtrl.ChonLoaiDuAn(loaiduan);
            PLTimeSheetCtrl.ChonCongViec(plCombobox1);
            HelpDate.Today(TuNgay, DenNgay);
        }

        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder f = null;
            string sql = "select b.name as DUAN,DUYET, a.DA_ID, a.NV_ID,a.CV_ID,a.NGAY_LAM_VIEC, e.NAME as NHANVIEN, c.name as CONGVIEC, a.mo_ta , a.bat_dau, a.ket_thuc,a.thoi_gian_thuc_hien from KE_HOACH_LAM_VIEC a, du_an b, cong_viec c, user_cat d, DM_NHAN_VIEN e where a.cv_id = c.id and a.da_id = b.id and a.nv_id = d.employee_id and d.employee_id = e.id and 1=1";
            f = new QueryBuilder(sql);
            f.addID("DA_ID", Duan._getSelectedID());
            f.addID("NV_ID", nhanvien._getSelectedID());
            f.addID("CV_ID",plCombobox1._getSelectedID());
            f.addDateFromTo("a.NGAY_LAM_VIEC", TuNgay.DateTime, DenNgay.DateTime);
            f.addDuyet("DUYET", DuyetSelect.layTrangThai());
            f.setAscOrderBy("a.NGAY_CAP_NHAT");
            DataSet ds = DABase.getDatabase().LoadDataSet(f);
            return f;
        }

        public override void ShowViewForm(long id)
        {
            //NOOP
        }

        public override bool ShowAddForm()
        {
            frmTimeTable frm = new frmTimeTable();
            ProtocolForm.ShowDialog(this, frm);
            return true;
        }

        public override _MenuItem GetMenuAppendGridList()
        {
            //NOOP
            return null;
        }
        private _Print GetPrint()
        {
            _Print print = new _Print();
          
            return print;
        }
       
        #region CSDL
        public static long ID_LDA(long ID)
        {
            string sql = "select LOAI_DU_AN from DU_AN where ID=" + ID;
            DataSet ds = new DataSet();
            DatabaseFB db = DABase.getDatabase();
            ds = db.LoadDataSet(sql, "DA");
            if (ds.Tables[0].Rows.Count > 0)
                return HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["LOAI_DU_AN"].ToString());
            else
                return -1;

        }
        public static DataSet GetData(DateTime ngaylamviec, long nv_id)
        {
            DataSet ds = new DataSet();
            string sql = "select b.name as DUAN,DUYET, a.DA_ID, a.NV_ID,a.CV_ID,a.NGAY_LAM_VIEC, e.NAME as NHANVIEN, c.name as CONGVIEC, a.mo_ta , a.bat_dau, a.ket_thuc,a.thoi_gian_thuc_hien from KE_HOACH_LAM_VIEC a, du_an b, cong_viec c, user_cat d, DM_NHAN_VIEN e where a.cv_id = c.id and a.da_id = b.id and a.nv_id = d.employee_id and d.employee_id = e.id and NGAY_LAM_VIEC='" + ngaylamviec.ToString("MM/dd/yyyy") + "'and NV_ID=" + nv_id;
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            //db.AddInParameter(cmd, "NGAY_LAM_VIEC", DbType.Date, ngaylamviec);
            db.LoadDataSet(cmd, ds, "CTCV");
            return ds;
        }
        public DataSet GetData()
        {
            QueryBuilder f = null;
            string sql = "select b.name as DUAN,DUYET, a.DA_ID, a.NV_ID,a.CV_ID,a.NGAY_LAM_VIEC, e.NAME as NHANVIEN, c.name as CONGVIEC, a.mo_ta , a.bat_dau, a.ket_thuc,a.thoi_gian_thuc_hien from KE_HOACH_LAM_VIEC a, du_an b, cong_viec c, user_cat d, DM_NHAN_VIEN e where a.cv_id = c.id and a.da_id = b.id and a.nv_id = d.employee_id and d.employee_id = e.id and 1=1";
            f = new QueryBuilder(sql);
            f.addID("DA_ID", Duan._getSelectedID());
            f.addID("NV_ID", nhanvien._getSelectedID());
            f.addID("CV_ID", plCombobox1._getSelectedID());
            f.addDateFromTo("a.NGAY_LAM_VIEC", TuNgay.DateTime, DenNgay.DateTime);
            f.addDuyet("DUYET", DuyetSelect.layTrangThai());
            f.setAscOrderBy("a.NGAY_CAP_NHAT");
            DataSet ds = DABase.getDatabase().LoadDataSet(f, "ABC");
            return DABase.getDatabase().LoadDataSet(filter, "ABC");
        }
        public static void loadcongviec(PLCombobox input, long id)
        {

            string sql = "select * from cong_viec where loai_du_an=" + id;
            DataSet ds = DABase.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();

        }
        public static void Xoadulieu(DateTime ngaycapnhat,long NV_ID)
        {
            string sql = "delete from KE_HOACH_LAM_VIEC where NV_ID =" + NV_ID + " and NGAY_LAM_VIEC ='" + ngaycapnhat.ToString("MM/dd/yyyy") + "'";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.ExecuteNonQuery(cmd);
        }
        #endregion
        #region Xử lý xự kiện và Nút
        private void Duan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Duan._getSelectedID() != -1)
            {
                loadcongviec(plCombobox1, ID_LDA(Duan._getSelectedID()));
            }
            else
            {
                PLTimeSheetCtrl.ChonCongViec(plCombobox1);
            }
        }
        private void gridViewMaster_DoubleClick(object sender, EventArgs e)
        {
            DataSet ds = (gridControlMaster.DataSource as DataTable).DataSet;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                DateTime ngay = Convert.ToDateTime(r["NGAY_LAM_VIEC"]);
                long ID = HelpNumber.ParseInt64(r["NV_ID"]);
                frmKeHoachLamViec frm = new frmKeHoachLamViec(ngay, ID, true);
                ProtocolForm.ShowDialog(this, frm);
            }
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataSet ds = (gridControlMaster.DataSource as DataTable).DataSet;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                DateTime ngay = Convert.ToDateTime(r["NGAY_LAM_VIEC"]);
                long ID = HelpNumber.ParseInt64(r["NV_ID"]);
                frmKeHoachLamViec frm = new frmKeHoachLamViec(ngay, ID, true);
                ProtocolForm.ShowDialog(this, frm);
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                DataSet ds = (gridControlMaster.DataSource as DataTable).DataSet;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                    if (r["DUYET"].ToString() != "2")
                    {
                        if (HelpMsgBox.ShowConfirmMessage("Bạn có thật sự muốn xóa!") == DialogResult.Yes)
                        {
                            DateTime ngay = Convert.ToDateTime(r["NGAY_LAM_VIEC"]);
                            long ID = HelpNumber.ParseInt64(r["NV_ID"]);
                            Xoadulieu(ngay, ID);
                            DataSet dsGrid = GetData();
                            this.gridControlMaster.DataSource = dsGrid.Tables[0];
                        }
                    }
                    else
                    {
                        HelpMsgBox.ShowNotificationMessage("Xóa không thành công.Công việc của bạn đã được duyệt!");
                    }
                }

        }
        private void barBtnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataSet ds = (gridControlMaster.DataSource as DataTable).DataSet;
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);

                DateTime ngay = Convert.ToDateTime(r["NGAY_LAM_VIEC"]);
                long ID = HelpNumber.ParseInt64(r["NV_ID"]);
                frmKeHoachLamViec frm = new frmKeHoachLamViec(ngay, ID);
                ProtocolForm.ShowDialog(this, frm);
            }
        }
        #endregion

        private void frmKeHoachLamViecQL_Load(object sender, EventArgs e)
        {
            gridViewMaster.OptionsView.ShowGroupedColumns = true;
        }

       
    }
}
