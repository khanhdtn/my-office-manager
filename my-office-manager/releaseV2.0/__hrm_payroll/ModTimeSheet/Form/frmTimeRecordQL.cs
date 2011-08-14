using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System;
using System.Data;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using DAO;
using ProtocolVN.DanhMuc;

namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmTimeRecordQL : TimPopupChange
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

        #region Hàm dựng và khởi tạo
        TimPopupFix Fix;
        public frmTimeRecordQL()
        {
            InitializeComponent();
            IDField = "CTCCV_ID";
            this.SupportIn = false;
            this.SupportThem = true;
            this.SupportChon = false;
            Fix = new TimPopupFix(this);                       
            gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            this.barBtnXem.Glyph = FWImageDic.VIEW_IMAGE20;
            this.barBtnXoa.Glyph = FWImageDic.DELETE_IMAGE20;
            this.barBtnCapNhat.Glyph = FWImageDic.EDIT_IMAGE20;
            this.barButtonItemDuyet.Glyph = FWImageDic.COMMIT_IMAGE16;
            this.barButtonItemK_Duyet.Glyph = FWImageDic.UNCOMMIT_IMAGE16;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            InitControl(false);
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            gridViewMaster.OptionsSelection.MultiSelect = true;
            gridViewMaster.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridViewMaster.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }

        public void InitControl(bool State)
        {
            barBtnXem.Enabled = State;
            barBtnCapNhat.Enabled = State;
            barBtnXoa.Enabled = State;
            barButtonItemDuyet.Enabled = State;
            barButtonItemK_Duyet.Enabled = State;
        }

        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(Cotloai_cv, "TEN_CV");
            XtraGridSupportExt.TextLeftColumn(CotCTCCV_ID, "CTCCV_ID");           
            XtraGridSupportExt.TextLeftColumn(Cotmota, "MO_TA");            
            HelpGridColumn.CotPLTimeEdit(Cotthoigian, "THOI_GIAN_THUC_HIEN", "HH:mm");
            HelpGridColumn.CotReadOnlyDate(cotngaylamviec, "NGAY_LAM_VIEC");
            HelpGridColumn.CotReadOnlyDate(CotNgaycapnhat, "NGAY_CAP_NHAT","dd/MM/yyyy HH:mm");
            XtraGridSupportExt.TextLeftColumn(cotnhanvien, "NHANVIEN");
            GridColumn column = new GridColumn();
            XtraGridSupportExt.CreateDuyetGridColumn(column);
            this.gridViewMaster.Columns.Add(column);
            this.cotnhanvien.Visible = false;
            this.cotngaylamviec.Visible = false;
        }

        public override void PLLoadFilterPart()
        {            
            PLTimeSheetCtrl.ChonLoaiCongViec(Loai_Cv);                        
            DMNhanVienX.I.InitCtrl(Nhan_vien, true);  
        }
        #endregion

        #region Xử lý xự kiện và Nút
        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder filter = null;
            string sql = @"select ctccv_id,(select name from dm_loai_cong_viecn lcv where lcv.id=ctcv.lcv_id) TEN_CV,            
            nv.ten_nv NHANVIEN,
            ctcv.ngay_lam_viec,ctcv.ngay_cap_nhat,ctcv.lcv_id,ctcv.nv_id,ctcv.mo_ta,ctcv.thoi_gian_thuc_hien,ctcv.duyet
            from chi_tiet_cong_viec ctcv inner join dm_nhan_vien nv on nv.id=ctcv.nv_id
            where nv.visible_bit='Y' and  1=1";
            filter = new QueryBuilder(sql);
            filter.addID("LCV_ID", Loai_Cv._getSelectedID());
            filter.addID("NV_ID", Nhan_vien._getSelectedID());            
            filter.addDateFromTo("NGAY_LAM_VIEC", TuNgay.DateTime, DenNgay.DateTime);
            filter.addDuyet("DUYET", DuyetSelect.layTrangThai());
            filter.addGroupBy("ctccv_id,lcv_id,nv.ten_nv,ngay_lam_viec,ngay_cap_nhat,nv_id,mo_ta,thoi_gian_thuc_hien,duyet");
            filter.setDescOrderBy("NGAY_LAM_VIEC");
            DataSet ds = DABase.getDatabase().LoadDataSet(filter);
            gridControlMaster.DataSource = ds.Tables[0];
            return null;
        }

        public override void ShowViewForm(long id)
        {
            //NOOP
            
        }

        public override bool ShowAddForm()
        {
            frmTimeTable frm = new frmTimeTable();
            ProtocolForm.ShowDialog(this, frm);
            PLBuildQueryFilter();
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
      
        private void gridViewMaster_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = (gridControlMaster.DataSource as DataTable).DataSet;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                    DateTime ngay = Convert.ToDateTime(r["NGAY_LAM_VIEC"]);
                    long ID = HelpNumber.ParseInt64(r["NV_ID"]);
                    frmTimeTable frm = new frmTimeTable(ngay, ID, HelpNumber.ParseInt64(r["CTCCV_ID"]), false);
                    ProtocolForm.ShowModalDialog(this, frm);
                }
            }
            catch
            { 
            }
        }       
        
        private void barBtnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewMaster.GetSelectedRows().Length > 1)
                PLMessageBox.ShowNotificationMessage("Chỉ cho phép cập nhật dữ liệu trên 1 dòng!");
            else
            {
                DataSet ds = (gridControlMaster.DataSource as DataTable).DataSet;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                    DateTime ngay = Convert.ToDateTime(r["NGAY_LAM_VIEC"]);
                    long ID = HelpNumber.ParseInt64(r["NV_ID"]);
                    frmTimeTable frm = new frmTimeTable(ngay, ID, HelpNumber.ParseInt64(r["CTCCV_ID"]), true);
                    ProtocolForm.ShowModalDialog(this, frm);
                    PLBuildQueryFilter();
                }
            }
        }
       
        private void barBtnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            gridViewMaster_DoubleClick(sender, e);
        }

        private void barBtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DataRow[] row=new DataRow[Selected_row.Length];
            int j=0;
            foreach (int i in Selected_row)
            {
                 row[j]= gridViewMaster.GetDataRow(i);
                 j++;
            }
            foreach (DataRow dr in row)
            {
                if (dr["DUYET"].ToString() == "2")
                    PLMessageBox.ShowNotificationMessage("Công việc '" + dr["MO_TA"] + "' đã được duyệt.Không thể xóa!");
                else
                {
                    if (PLMessageBox.ShowConfirmMessage("Xóa công việc '" + dr["MO_TA"] + "'?") == DialogResult.Yes)
                    {
                        DAChiTietCongViec.Instance.DeleteCTCV(HelpNumber.ParseInt64(dr["CTCCV_ID"]));                                        
                        dr.Delete();
                    }
                }
            }            

        }
        
        private void gridViewMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (r != null && gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle)==false)
            {
                Set_trang_thai(r["DUYET"].ToString());
            }
            else
                InitControl(false);
        }
       

        private void barButtonItemDuyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] Selected_row=gridViewMaster.GetSelectedRows();
            DateTime Ngay_cap_nhat = DABase.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (row["DUYET"].ToString() == "2")
                    PLMessageBox.ShowNotificationMessage("Công việc '" + row["MO_TA"] + "' đã duyệt!");
                else
                {
                    if (PLMessageBox.ShowConfirmMessage("Duyệt công việc '" + row["MO_TA"] + "' ?") == DialogResult.Yes)
                    {
                        if (DAChiTietCongViec.Instance.UpdateDuyet(HelpNumber.ParseInt64(row["CTCCV_ID"]), "2", DAChiTietCongViec.Instance.GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id))))
                        {
                            row["DUYET"] = "2";
                            row["Ngay_cap_nhat"] = Ngay_cap_nhat;
                            Set_trang_thai("2");
                        }
                    }
                }
            }                       
        }

        private void barButtonItemK_Duyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DateTime Ngay_cap_nhat = DABase.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (row["DUYET"].ToString() == "3")
                    PLMessageBox.ShowNotificationMessage("Công việc '" + row["MO_TA"] + "' đã không duyệt!");
                else
                {
                    if (PLMessageBox.ShowConfirmMessage("Không duyệt công việc '" + row["MO_TA"] + "' ?") == DialogResult.Yes)
                    {
                        if (DAChiTietCongViec.Instance.UpdateDuyet(HelpNumber.ParseInt64(row["CTCCV_ID"]), "3", null))
                        {
                            row["Duyet"] = "3";
                            row["Ngay_cap_nhat"] = Ngay_cap_nhat;
                            Set_trang_thai("3");
                        }
                    }
                }
            }           
        }

        public void Set_trang_thai(string Duyet)
        {
            if (Duyet == "2")
            {
                barBtnXoa.Enabled = false;
                barBtnCapNhat.Enabled = false;
                barButtonItemK_Duyet.Enabled = true;
                barButtonItemDuyet.Enabled = false;
            }
            else if (Duyet == "1")
            {
                barBtnXoa.Enabled = true;
                barBtnCapNhat.Enabled = true;
                barButtonItemDuyet.Enabled = true;
                barButtonItemK_Duyet.Enabled = true;
            }
            else
            {
                barBtnXoa.Enabled = true;
                barBtnCapNhat.Enabled = true;
                barButtonItemDuyet.Enabled = true;
                barButtonItemK_Duyet.Enabled = false;
            }
            barBtnXem.Enabled = true;
        }
        #endregion

      
    }
}
