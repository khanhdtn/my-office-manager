using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System;
using System.Data;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using DAO;
using ProtocolVN.DanhMuc;
using office;
using DevExpress.XtraGrid;
using System.Drawing;
using ProtocolVN.App.Office;

namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmTimeRecordQL : TimPopupChange,IFormRefresh
    {
        #region Các biến của form quản lý tuyệt đối không thay đổi
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
        #endregion

        #region Hàm dựng và khởi tạo
        TimPopupFix Fix;
        public frmTimeRecordQL()
        {
            InitializeComponent();
            IDField = "CTCCV_ID";
            this.SupportIn = false;
            this.SupportThem = true;
            this.SupportChon = false;
             string view = @"
                select ctccv_id,(select name from dm_loai_cong_viecn lcv where lcv.id=ctcv.lcv_id) TEN_CV,            
                nv.NAME NHANVIEN,
                ctcv.ngay_lam_viec,ctcv.ngay_cap_nhat,ctcv.lcv_id,ctcv.nv_id,ctcv.mo_ta,ctcv.thoi_gian_thuc_hien,ctcv.duyet
                from chi_tiet_cong_viec ctcv inner join dm_nhan_vien nv on nv.id=ctcv.nv_id
                where nv.visible_bit='Y' and  1=1";
            Fix = new TimPopupFix(this,view);
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
            HelpGrid.SetTitle(this.gridViewMaster, "DANH SÁCH NHẬT KÝ LÀM VIỆC");
        }

        public void InitControl(bool State)
        {
            barBtnXem.Enabled = State;
            barBtnCapNhat.Enabled = State;
            barBtnXoa.Enabled = State;
            //barButtonItemDuyet.Enabled = State;
            //barButtonItemK_Duyet.Enabled = State;
        }

        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(Cotloai_cv, "TEN_CV");
            XtraGridSupportExt.TextLeftColumn(CotCTCCV_ID, "CTCCV_ID");           
            XtraGridSupportExt.TextLeftColumn(Cotmota, "MO_TA");            
            HelpGridColumn.CotPLTimeEdit(Cotthoigian, "THOI_GIAN_THUC_HIEN", PLConst.FORMAT_TIME_HH_MM);
            HelpGridColumn.CotPLTimeEdit(cotngaylamviec, "NGAY_LAM_VIEC", "ddd, dd/MM/yyyy");
            HelpGridColumn.CotReadOnlyDate(CotNgaycapnhat, "NGAY_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            XtraGridSupportExt.TextLeftColumn(cotnhanvien, "NHANVIEN");
            GridColumn column = new GridColumn();
            //XtraGridSupportExt.CreateDuyetGridColumn(column);
            this.gridViewMaster.Columns.Add(column);
            this.cotnhanvien.Visible = false;
            this.cotngaylamviec.Visible = false;
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            //Nếu ngày cập nhật > ngày làm việc 1 ngày -> Đỏ
            StyleFormatCondition condition = new StyleFormatCondition();
            condition.Appearance.Options.UseForeColor = true;
            condition.Appearance.ForeColor = Color.Red;
            condition.Condition = FormatConditionEnum.Expression;
            condition.Expression = string.Format(@"(AddDays(AddTimeSpan([NGAY_LAM_VIEC],#{0}#),1) <= [NGAY_CAP_NHAT])", new TimeSpan(0, 0, 1));
            condition.ApplyToRow = true;
            gridViewMaster.FormatConditions.Add(condition); 
            //-----------------------------
        }

        public override void PLLoadFilterPart()
        {
            PLTimeSheetCtrl.ChonLoaiCongViec(Loai_Cv);
           // DMNhanVienX.I.InitCtrl(NhanVien, true, true);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            //ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromDateToDate;
            ngayLamViec.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.gridViewMaster.ViewCaption = gridViewMaster.GroupPanelText;
            this.gridViewMaster.OptionsView.ShowViewCaption = true;
            PLTimeSheetUtil.PermissionForControl(NhanVien, NhanVien.Visible == true, NhanVien.Visible == true);
            this.DuyetSelect.unCheck(3);
            this.DuyetSelect.unCheck(2);
            this.DuyetSelect._initRedCheckEdit();
            this.DuyetSelect.unCheck(1);
            this.DuyetSelect.check(3);
            this.DuyetSelect.check(1);
            this.DuyetSelect.check(2);

            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            HelpGrid.SetUpperTitle(this.gridViewMaster, "DANH SÁCH NHẬT KÝ LÀM VIỆC");
            //-------
            PLTimeSheetUtil.InVisibleShowNumOfRecord(gridControlMaster);
            //-------
        }
        #endregion

        #region Xử lý xự kiện và Nút
        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            QueryBuilder filter = null;
            string sql = @"SELECT CTCCV_ID,(SELECT NAME FROM DM_LOAI_CONG_VIECN LCV WHERE LCV.ID=CTCV.LCV_ID) TEN_CV,            
                    NV.NAME NHANVIEN,CTCV.NGAY_LAM_VIEC,CTCV.NGAY_CAP_NHAT
                    ,CTCV.LCV_ID,CTCV.NV_ID,CTCV.MO_TA,CAST(CTCV.THOI_GIAN_THUC_HIEN AS TIME) THOI_GIAN_THUC_HIEN
            FROM CHI_TIET_CONG_VIEC CTCV INNER JOIN DM_NHAN_VIEN NV ON NV.ID=CTCV.NV_ID
            WHERE NV.VISIBLE_BIT='Y' AND  1=1";
            filter = new QueryBuilder(sql);
            filter.addID("LCV_ID", Loai_Cv._getSelectedID());
            filter.addID("NV_ID", NhanVien._getSelectedID());
            filter.addDateFromTo("NGAY_LAM_VIEC", ngayLamViec.FromDate, ngayLamViec.ToDate);
            filter.addGroupBy("CTCCV_ID,LCV_ID,NV.NAME,NGAY_LAM_VIEC,NGAY_CAP_NHAT,NV_ID,MO_TA,THOI_GIAN_THUC_HIEN");
            filter.setDescOrderBy("NGAY_LAM_VIEC");
            //DataSet ds = DABase.getDatabase().LoadDataSet(filter);
            //gridControlMaster.DataSource = ds.Tables[0];
            msg.Finish();
            return filter;
        }

        public override void ShowViewForm(long id)
        {
            //NOOP
            
        }

        public override bool ShowAddForm()
        {
            frmTimeTable frm = new frmTimeTable();
            ProtocolForm.ShowModalDialog(this, frm);
            //PLBuildQueryFilter();
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
                    frmTimeTable frm = new frmTimeTable(ngay, ID, HelpNumber.ParseInt64(r["CTCCV_ID"]), null);
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
                HelpMsgBox.ShowNotificationMessage("Chỉ cho phép cập nhật dữ liệu trên 1 dòng!");
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
                    //PLBuildQueryFilter();
                    Fix.PLRefresh();
                }
            }
        }
       
        private void barBtnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataSet ds = (gridControlMaster.DataSource as DataTable).DataSet;
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                    DateTime ngay = Convert.ToDateTime(r["NGAY_LAM_VIEC"]);
                    long ID = HelpNumber.ParseInt64(r["NV_ID"]);
                    frmTimeTable frm = new frmTimeTable(ngay, ID, HelpNumber.ParseInt64(r["CTCCV_ID"]), null);
                    ProtocolForm.ShowModalDialog(this, frm);
                }
            }
            catch
            {
            }
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
                //if (dr["DUYET"].ToString() == "2")
                //    HelpMsgBox.ShowNotificationMessage("Công việc '" + dr["MO_TA"] + "' đã được duyệt.Không thể xóa!");
                //else
                //{
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn 'Xóa' phiếu \": '" + dr["MO_TA"] + "\"?") == DialogResult.Yes)
                    {
                        DAChiTietCongViec.Instance.DeleteCTCV(HelpNumber.ParseInt64(dr["CTCCV_ID"]));                                        
                        dr.Delete();
                    }
                //}
            }            

        }
        
        private void gridViewMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (r != null && gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle) == false)
            {
                //Set_trang_thai(r["DUYET"].ToString());
                InitControl(true);
            }
            else
                InitControl(false);
        }
       

        

        #endregion
        private void InitSaveQueryDialog()
        {
            string view = @"
                SELECT CTCCV_ID,(SELECT NAME FROM DM_LOAI_CONG_VIECN LCV WHERE LCV.ID=CTCV.LCV_ID) TEN_CV,            
                NV.NAME NHANVIEN,
                CTCV.NGAY_LAM_VIEC,CTCV.NGAY_CAP_NHAT,CTCV.LCV_ID,CTCV.NV_ID,CTCV.MO_TA,CTCV.THOI_GIAN_THUC_HIEN
                FROM CHI_TIET_CONG_VIEC CTCV INNER JOIN DM_NHAN_VIEN NV ON NV.ID=CTCV.NV_ID
                WHERE NV.VISIBLE_BIT='Y' AND  1=1";
            HelpControl.addSaveQueryDialog(this, this.barManager1, this.gridControlMaster, this.gridViewMaster._GetPLGUI(), view);
        }
        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        }

        #endregion
        
    }
}
