using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using ProtocolVN.DanhMuc;
using office.model;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DAO;

namespace office.form
{
    public partial class frmBangTheoDoiQL : XtraFormPL
    {
        

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(new GenID().NewItem(),
                "Thu chi",
                ParentID, true,
                typeof(frmBangTheoDoiQL).FullName,
                true, IsSep, "mnbBangTheoDoiQL.png", true, "", "");
        }



        #region Init
        public frmBangTheoDoiQL()
        {
            InitializeComponent();
            this.barButtonItemDelete.Glyph = FWImageDic.DELETE_IMAGE20;
            this.barButtonItemSearch.Glyph = FWImageDic.FIND_IMAGE20;
            this.barButtonItemUpdate.Glyph = FWImageDic.EDIT_IMAGE20;
            this.barButtonItemAdd.Glyph = FWImageDic.ADD_IMAGE20;
            this.barButtonItemXem.Glyph = FWImageDic.VIEW_IMAGE20;
            this.barCheckItemFilter.Glyph = FWImageDic.FILTER_IMAGE20;
            this.barButtonItemClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;    
            this.barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemNoCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemXem.Enabled = false;
            barButtonItemUpdate.Enabled = false;
            barButtonItemDelete.Enabled = false;
            barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemSearch.Enabled = true;
            barButtonItemClose.Enabled = true;
            barButtonItemCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemAdd_ItemClick);
            barButtonItemXem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemXem_ItemClick);
            barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemDelete_ItemClick);
            barButtonItemUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemUpdate_ItemClick);
            barButtonItemSearch.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemSearch_ItemClick);
            barButtonItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemClose_ItemClick);
            gridViewMaster.DoubleClick += new EventHandler(gridViewMaster_DoubleClick);
            gridViewMaster.Click += new EventHandler(gridViewMaster_Click);
            InitCtrl();
            InitGrid();
        }
        public void InitGrid()
        {
            gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            XtraGridSupportExt.TextLeftColumn(Cot_BTD_ID, "BTD_ID");
            XtraGridSupportExt.TextLeftColumn(Cot_Ma_BTD, "MA_BTD");
            XtraGridSupportExt.TextLeftColumn(Cot_NAME, "NAME");
            XtraGridSupportExt.TextLeftColumn(Cot_NgayLap, "NGAY_LAP");
            XtraGridSupportExt.IDGridColumn(Cot_NguoiLap, "ID", "TEN_NV", "DM_NHAN_VIEN", "NGUOI_LAP");
            XtraGridSupportExt.TextLeftColumn(Cot_NgayKy, "NGAY_KY");
            XtraGridSupportExt.IDGridColumn(Cot_NguoiKy, "ID", "TEN_NV", "DM_NHAN_VIEN", "NGUOI_KY");
            XtraGridSupportExt.TextLeftColumn(Cot_NgayHieuLuc, "NGAY_HIEU_LUC");
            XtraGridSupportExt.IDGridColumn(Cot_NguoiQuanLy, "ID", "TEN_NV", "DM_NHAN_VIEN", "NGUOI_QUAN_LY");
            XtraGridSupportExt.TextLeftColumn(Cot_TenTaiLieu, "TEN_TAI_LIEU");
            XtraGridSupportExt.IDGridColumn(Cot_TinhTrang, "ID", "NAME", "DM_TINH_TRANG", "TINH_TRANG");
            XtraGridSupportExt.TextLeftColumn(Cot_HinhThucThongBao, "HINH_THUC_THONG_BAO");
            XtraGridSupportExt.TextLeftColumn(Cot_GhiChu, "GHI_CHU");
            XtraGridSupportExt.TextLeftColumn(Cot_NgayCapNhat, "NGAY_CAP_NHAT");
            XtraGridSupportExt.IDGridColumn(Cot_NguoiCapNhat, "ID", "TEN_NV", "DM_NHAN_VIEN", "NGUOI_LAP");
        }
        public void InitCtrl()
        {
            DMFWNhanVien.I.InitCtrl(NguoiQuanLy, true, true);
            DMFWNhanVien.I.InitCtrl(NguoiLap, true, true);
            DMFWNhanVien.I.InitCtrl(NguoiQuanLy, true, true);
            DMTinhTrangCongViec.I.InitCtrl(TinhTrang, true, true);
            HelpDate.OneWeekAgo(NgayLapTu, NgayLapDen);
        }
        #endregion

        #region Xử lý dữ liệu
        public DataTable PLBuildQueryFilter()
        {
            QueryBuilder filter = null;
            string sql = "SELECT BTD_ID, MA_BTD, NAME, NGAY_LAP, NGUOI_LAP, NGAY_KY, NGUOI_KY, NGAY_HIEU_LUC, NGUOI_QUAN_LY, TEN_TAI_LIEU, TINH_TRANG, HINH_THUC_THONG_BAO, GHI_CHU, NGUOI_CAP_NHAT, NGAY_CAP_NHAT FROM BANG_THEO_DOI WHERE 1=1";
            filter = new QueryBuilder(sql);
            filter.addSoPhieu("MA_BTD", SoPhieu.Text.Trim());
            filter.addID("NGUOI_QUAN_LY", NguoiQuanLy._getSelectedID());
            filter.addID("NGUOI_LAP", NguoiLap._getSelectedID());
            filter.addID("TINH_TRANG", TinhTrang._getSelectedID());
            filter.addDateFromTo("NGAY_LAP", NgayLapTu.DateTime, NgayLapDen.DateTime);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(filter);
            if (ds != null)
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
            return null;
        }
        private void gridViewMaster_Click(object sender, EventArgs e)
        {
            //Lấy ra vị trí click của Muose trên gridview
            GridHitInfo gHitInfo = gridViewMaster.CalcHitInfo(gridViewMaster.GridControl.PointToClient(Control.MousePosition));
            if (gHitInfo.InRowCell)//Nếu vị trí click là cell trong row
            {
                if (gHitInfo.Column.FieldName == "TEN_TAI_LIEU")
                {
                    object o = HelpDB.getDatabase().LoadDataSet("select TAI_LIEU from BANG_THEO_DOI where BTD_ID = " + gridViewMaster.GetRowCellValue(gHitInfo.RowHandle, gridViewMaster.Columns["BTD_ID"])).Tables[0].Rows[0]["TAI_LIEU"];
                    if (o != null)
                        if(o != System.DBNull.Value)
                            DANopBai.Instance.openSaveFile(gHitInfo, gridViewMaster, null, (byte[])o);
                        else if (HelpMsgBox.ShowConfirmMessage("Tài liệu không tồn tại, bạn có muốn cập nhật lại không?") == DialogResult.Yes)
                    {
                        frmBangTheoDoi frm = new frmBangTheoDoi(HelpNumber.ParseInt64(gridViewMaster.GetRowCellValue(gridViewMaster.FocusedRowHandle, Cot_BTD_ID).ToString()), false);
                        ProtocolForm.ShowModalDialog(this, frm);
                        searchData();
                    }
                }
            }
        }
        public void gridViewMaster_DoubleClick(object sender, EventArgs e)
        {
            if (barButtonItemXem.Enabled == true)
            {
                frmBangTheoDoi frm = new frmBangTheoDoi(HelpNumber.ParseInt64(gridViewMaster.GetRowCellValue(gridViewMaster.FocusedRowHandle, Cot_BTD_ID).ToString()), null);
                ProtocolForm.ShowDialog(this, frm);
            }
        }
        #endregion
        
        #region Xử lý nút
        public void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangTheoDoi frm = new frmBangTheoDoi();
            ProtocolForm.ShowModalDialog(this, frm);
            barButtonItemSearch_ItemClick(sender, e);
        }
        public void barButtonItemXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangTheoDoi frm = new frmBangTheoDoi(HelpNumber.ParseInt64(gridViewMaster.GetRowCellValue(gridViewMaster.FocusedRowHandle, Cot_BTD_ID).ToString()), null);
            ProtocolForm.ShowDialog(this, frm);
        }
        public void barButtonItemDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn xóa bảng theo dõi này không?") == DialogResult.Yes)
            {
                DABangTheoDoi.Instance.Delete(HelpNumber.ParseInt64(gridViewMaster.GetRowCellValue(gridViewMaster.FocusedRowHandle, Cot_BTD_ID).ToString()));
                gridViewMaster.DeleteRow(gridViewMaster.FocusedRowHandle);
                if (gridViewMaster.RowCount == 0)
                {
                    barButtonItemXem.Enabled = false;
                    barButtonItemUpdate.Enabled = false;
                    barButtonItemDelete.Enabled = false;
                }
            }
        }
        public void barButtonItemUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangTheoDoi frm = new frmBangTheoDoi(HelpNumber.ParseInt64(gridViewMaster.GetRowCellValue(gridViewMaster.FocusedRowHandle, Cot_BTD_ID).ToString()), false);
            ProtocolForm.ShowModalDialog(this, frm);
            barButtonItemSearch_ItemClick(sender, e);
        }
        public void barButtonItemSearch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            searchData();
        }
        public void searchData()
        {
            DataTable dt = PLBuildQueryFilter();
            if (dt == null)
                return;
            if (dt.Rows.Count > 0)
            {
                barButtonItemXem.Enabled = true;
                barButtonItemUpdate.Enabled = true;
                barButtonItemDelete.Enabled = true;
            }
            else
            {
                barButtonItemXem.Enabled = false;
                barButtonItemUpdate.Enabled = false;
                barButtonItemDelete.Enabled = false;
            }
            gridControlMaster.DataSource = dt;
        }
        public void barButtonItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn thoát không?") == DialogResult.Yes)
                this.Close();
        }
        #endregion
  }
}