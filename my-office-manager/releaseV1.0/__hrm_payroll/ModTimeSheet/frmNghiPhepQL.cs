using System;
using System.Data;
using DevExpress.XtraBars;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using ProtocolVN.DanhMuc;
using office;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win.Trial;
using System.Text;
using DevExpress.XtraGrid;
using DTO;
using ProtocolVN.App.Office;
namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmNghiPhepQL : PhieuQuanLy10Change, IDuyetSupport, IFormRefresh
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //public partial class frmNghiPhepQL : XtraFormPL
        //{
        //    protected DevExpress.XtraBars.BarManager barManager1;
        //    protected DevExpress.XtraBars.Bar MainBar;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemView;
        //    protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        //    protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //    protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //    protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        //    protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //    protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //    protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //    protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //    protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //    protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //    protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //    protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //    protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //    protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //    protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemTaoPhieuMuaHang;
        //    private System.ComponentModel.IContainer components;
        //    private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //    protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //    private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //    protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //    private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //    private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //    private DevExpress.XtraBars.PopupMenu popupMenu1;
        //    private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //    protected DevExpress.XtraBars.BarSubItem barSubItem1;
        //#endregion

        #region Các khai báo biến
        private PhieuQuanLy10Fix Fix;
        #region Các hằng số khởi tạo giờ bắt đầu,kết thúc và nghỉ trưa
        #endregion
        #endregion

        #region Các hàm khởi tạo
        public static FormStatus Status = FormStatus.OK_TEST;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTimeInOutQL).FullName,
                "Theo dõi nghỉ phép",
                ParentID, true,
                typeof(frmTimeInOutQL).FullName,
                false, IsSep, "ATinhTrangBaoHanh.png", true, "", "");
        }
        public frmNghiPhepQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "LY_DO";
            Fix = new PhieuQuanLy10Fix(this);

            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            Cot_Ly_Do.Visible = true;
            InitState(false);
            this.barButtonItemDuyet.Glyph = FWImageDic.COMMIT_IMAGE16;
            this.barButtonItemK_Duyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDuyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemK_Duyet.Glyph = FWImageDic.UNCOMMIT_IMAGE16;
            this.barButtonItemPrint.Visibility = BarItemVisibility.Never;
            barButtonItemDuyet.ItemClick += new ItemClickEventHandler(barButtonItemDuyet_ItemClick);
            barButtonItemK_Duyet.ItemClick += new ItemClickEventHandler(barButtonItemK_Duyet_ItemClick);
            barSubItem1.Visibility = BarItemVisibility.Always;
        }

        private void frmTimeInOutQL_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region Methods of Framework
        public override void InitColumnMaster()
        {
            ID.FieldName = "ID";
            XtraGridSupportExt.TextLeftColumn(Cot_TenNV, "NAME");
            Cot_TenNV.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            HelpGridColumn.CotPLTimeEdit(Cot_NgayLamViec, "NGAY_LAM_VIEC", "ddd, dd/MM/yyyy");
            HelpGridColumn.CotPLImageCheck(Cot_N_Bs, "NGHI_BUOI_SANG");
            HelpGridColumn.CotPLImageCheck(Cot_N_BC, "NGHI_BUOI_CHIEU");
            HelpGridColumn.CotPLTimeEdit(cotThoiGianCN, "THOI_GIAN_GHI_NHAN", PLConst.FORMAT_DATETIME_STRING);

            DataTable dt = HelpDataSetExt.CreateDataTable(new string[] { "ID", "NAME" },
                new object[] { string.Empty, string.Empty },
                new object[] {"Y","Nghỉ phép năm",
                              "N","Nghỉ không lương"});
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            HelpGridColumn.CotCombobox(Loai_NP, ds, "ID", "NAME", "LOAI_NGHI_PHEP");
            XtraGridSupportExt.TextLeftColumn(Cot_Ly_Do, "LY_DO");
            //HelpGridColumn.CotCombobox(HelpGridColumn.ThemCot(this.gridViewMaster, "Người duyệt", 8, 100),"DM_NHAN_VIEN","ID","NAME","NGUOI_DUYET");
            PLGUIUtil.BestFitMasterColumns(this.gridViewMaster);
            HelpGridExt1.SetDefaultGroupPanel(this.gridViewMaster);
            gridViewMaster.OptionsView.ShowGroupPanel = false;

            HelpGridExt1.colMultiline(Cot_Ly_Do, "LY_DO");
            gridViewMaster.OptionsView.RowAutoHeight = true;

        }
        public void InitState(bool State)
        {
            barButtonItemDuyet.Enabled = State;
            barButtonItemK_Duyet.Enabled = State;
        }
        public override void InitColumDetail()
        {
            //Format dòng trên lưới
            StyleFormatCondition condition = new StyleFormatCondition();
            condition.Appearance.Options.UseForeColor = true;
            condition.Appearance.ForeColor = Color.Red;
            condition.Condition = FormatConditionEnum.Expression;
            condition.Expression = string.Format(@"(AddDays(AddTimeSpan([NGAY_LAM_VIEC],#{0}#),1) <= [THOI_GIAN_GHI_NHAN])
            AND [DUYET] == '1'", new TimeSpan(0, 0, 1));
            condition.ApplyToRow = true;
            gridViewMaster.FormatConditions.Add(condition);
        }

        public override void PLLoadFilterPart()
        {
            ShowFooter();
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            PLTimeSheetUtil.PermissionForControl(NhanVien, barButtonItemDuyet.Visibility == BarItemVisibility.Always, NhanVien.Visible == true);
            //ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromDateToDate;
            ngayLamViec.ReturnType = TimeType.Date;
            HelpControl.RedCheckEdit(this.chkNghi_KLuong, false);
            HelpControl.RedCheckEdit(this.checkNghi_Nam, false);
            chkNghi_KLuong.Checked = checkNghi_Nam.Checked = true;
            this.DuyetSelect.unCheck(3);
            this.DuyetSelect.unCheck(2);
            this.DuyetSelect._initRedCheckEdit();
            this.DuyetSelect.unCheck(1);
            this.DuyetSelect.check(3);
            this.DuyetSelect.check(1);
            this.DuyetSelect.check(2);
            checkNghi_Nam.CheckedChanged += delegate(object checkNN, EventArgs checkedChanged)
            {
                if (checkNghi_Nam.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkNghi_KLuong.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    checkNghi_Nam.Checked = true;
            };
            chkNghi_KLuong.CheckedChanged += delegate(object chechNKL, EventArgs checkedChanged)
            {
                if (chkNghi_KLuong.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && checkNghi_Nam.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    chkNghi_KLuong.Checked = true;
            };
            gridViewMaster.OptionsMenu.EnableFooterMenu = false;
            gridViewMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewMaster_FocusedRowChanged);
        }

        void gridViewMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle))
                barButtonItemDuyet.Enabled = barButtonItemK_Duyet.Enabled = false;
        }

        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            filter.addID("NLV.NV_ID", NhanVien._getSelectedID());
            filter.addCondition("NLV.LOAI=" + (Int32)TimeInOutType.NghiPhep);
            if (ngayLamViec.Types != SelectionTypes.None)
                filter.addDateFromTo("NLV.NGAY_LAM_VIEC", ngayLamViec.FromDate, ngayLamViec.ToDate);
            filter.setDescOrderBy("NLV.NGAY_LAM_VIEC");
            filter.setAscOrderBy("NAME");
            filter.addDuyet(PLConst.FIELD_DUYET, DuyetSelect.layTrangThai());
            StringBuilder str = new StringBuilder();
            if (chkNghi_KLuong.Checked && checkNghi_Nam.Checked)
                filter.addCondition("NGHI_KHONG_LUONG = 'Y' OR NGHI_PHEP_NAM ='Y'");
            else
            {
                if (chkNghi_KLuong.Checked) filter.addBoolean("NGHI_KHONG_LUONG", true);
                if (checkNghi_Nam.Checked) filter.addBoolean("NGHI_PHEP_NAM", true);
            }
            DataSet ds = HelpDB.getDatabase().LoadDataSet(filter);
            //ds.Tables[0].Columns.Add("IS_NGHI_BUOI_SANG",typeof(Int32));
            if (ds == null || ds.Tables[0].Rows.Count == 0) barButtonItemDuyet.Enabled = barButtonItemK_Duyet.Enabled = false;
            else
            {
                barButtonItemDuyet.Enabled = barButtonItemK_Duyet.Enabled = true;
            }
            msg.Finish();
            return filter;
        }
        public override void ShowViewForm(long id)
        {
            frmNghiPhep frm = new frmNghiPhep(id, null);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }
        public override void ShowUpdateForm(long id)
        {
            frmNghiPhep frm = new frmNghiPhep(id, false);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }
        
        void frm__RefreshAfterUpdateData(DOTimeInOut doNghiPhep)
        {
            Fix.PLRefresh();
        }
        public override long[] ShowAddForm()
        {
            //isRefresh = true;
            frmNghiPhep frm = new frmNghiPhep();
            //frm._RefreshAfterUpdateData+=new frmNghiPhep.RefreshAfterUpdateData(frm__RefreshAfterUpdateData);
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }
        public override bool XoaAction(long id)
        {
            DOTimeInOut phieu = DATimeInOut.Instance.LoadAll(id);
            if (DATimeInOut.Instance.Delete(id))
            {
                PLTimeSheetUtil._SendThongBao(phieu, string.Empty, null, LoaiPhieu.PhieuXinNghiPhep);
                return true;
            }
            return false;

        }

        public override _MenuItem GetBusinessMenuList()
        {
            return null;
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        //iif(NGHI_BUOI_CHIEU ='Y',1,0) IS_NGHI_BUOI_CHIEU,
        //iif(NGHI_BUOI_SANG ='Y',1,0) IS_NGHI_BUOI_SANG,
        public override string UpdateRow()
        {
            return @"SELECT NLV.ID,NLV.NGAY_LAM_VIEC
                            ,NLV.GIO_BAT_DAU,NLV.GIO_KET_THUC,LY_DO,
                            NGHI_BUOI_CHIEU,NGHI_BUOI_SANG,NOI_DUNG,LOAI,DUYET,NGUOI_GHI_NHAN,NGUOI_DUYET,THOI_GIAN_GHI_NHAN,
                            CASE NGHI_PHEP_NAM WHEN 'Y' THEN 'Y'
                            ELSE 'N' END LOAI_NGHI_PHEP,
                            IIF(NGHI_BUOI_CHIEU ='Y' AND DUYET != 3,1,0) IS_NGHI_BUOI_CHIEU,
                            IIF(NGHI_BUOI_SANG ='Y'AND DUYET != 3,1,0) IS_NGHI_BUOI_SANG,                            
                            NLV.NV_ID,(SELECT NAME FROM DM_NHAN_VIEN WHERE ID = NLV.NV_ID) NAME,NGHI_PHEP_NAM,NGHI_KHONG_LUONG,THOI_GIAN_SANG,THOI_GIAN_CHIEU                                                                                 
                           ,EXTRACT(HOUR FROM THOI_GIAN_LAM_VIEC) + cast((EXTRACT(MINUTE FROM THOI_GIAN_LAM_VIEC)) as numeric(15,2))/60 TG                                       
                          FROM CAPNHAT_NGAYLAMVIEC NLV WHERE 1=1";
        }
        public override void HookFocusRow()
        {
            if (gridViewMaster.DataSource != null && gridViewMaster.RowCount > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (row == null)
                {
                    barButtonItemK_Duyet.Enabled = false;
                    barButtonItemDuyet.Enabled = false;
                    return;
                }
                if (row["LOAI"].ToString() != ((Int32)TimeInOutType.GhiThoiGian).ToString() && gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle) == false)
                {
                    if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                    {
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDuyet.Enabled = true;
                        if (string.Compare(FrameworkParams.currentUser.username, "admin") == 0
                            || string.Compare(FrameworkParams.currentUser.employee_id.ToString(), row["NV_ID"].ToString()) == 0)
                            barButtonItemUpdate.Enabled = true;
                        else barButtonItemUpdate.Enabled = false;
                    }
                    else if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                    {
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDuyet.Enabled = false;
                        barButtonItemUpdate.Enabled = false;
                    }
                    else
                    {
                        barButtonItemK_Duyet.Enabled = false;
                        barButtonItemDuyet.Enabled = true;
                        if (string.Compare(FrameworkParams.currentUser.username, "admin") == 0
                            || string.Compare(FrameworkParams.currentUser.employee_id.ToString(), row["NV_ID"].ToString()) == 0)
                            barButtonItemUpdate.Enabled = true;
                        else barButtonItemUpdate.Enabled = false;
                    }
                }
                else
                {
                    InitState(false);
                }
                barSubItem1.Enabled = true;
            }
        }
        #endregion

        #region Khác
        void barButtonItemDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DateTime Ngay_duyet = HelpDB.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                    {
                        row[PLConst.FIELD_DUYET] = ((Int32)DuyetSupportStatus.Duyet).ToString();
                        barButtonItemDelete.Enabled = false;
                        barButtonItemUpdate.Enabled = false;
                    }
                }
            }
        }
        void barButtonItemK_Duyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DateTime Ngay_duyet = HelpDB.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);

                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc không duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
                {
                    if (KhongDuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                    {
                        row[PLConst.FIELD_DUYET] = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();
                        barButtonItemDelete.Enabled = true;
                        barButtonItemUpdate.Enabled = true;
                    }
                }
            }
        }
        /// <summary>Lấy tình trạng chọn xem những người đã chấm công, chưa chấm công
        /// ....
        /// </summary>        
        public void ShowFooter()
        {
            gridViewMaster.OptionsView.ShowFooter = true;
            CotTG_LV.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "Thời gian: {0:#.###}(giờ)");
            HelpGridExt.SetFontFooter(gridViewMaster, new string[] { "THOI_GIAN_LAM_VIEC" }, Color.Blue, Color.Empty, FontStyle.Regular);
        }
        private void InitSaveQueryDialog()
        {
            HelpControl.addSaveQueryDialog(this, this.barManager1, this.gridControlMaster, this.gridViewMaster._GetPLGUI(), this.UpdateRow());
        }
        #endregion

        #region IDuyetSupport Members

        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.Duyet))
            {
                PLTimeSheetUtil._SendThongBao(DATimeInOut.Instance.LoadAll(ID), PLConst.DUYET, null, LoaiPhieu.PhieuXinNghiPhep);
                DataTable tb = ((DataView)this.gridViewMaster.DataSource).Table;
                tb.Rows[this.gridViewMaster.FocusedRowHandle]["NGUOI_DUYET"] = NguoiDuyetID;
                barButtonItemK_Duyet.Enabled = true;
                barButtonItemDuyet.Enabled = false;
                return true;
            }
            return false;
        }

        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.KhongDuyet))
            {
                PLTimeSheetUtil._SendThongBao(DATimeInOut.Instance.LoadAll(ID), PLConst.KHONG_DUYET, null, LoaiPhieu.PhieuXinNghiPhep);
                DataTable tb = ((DataView)this.gridViewMaster.DataSource).Table;
                tb.Rows[this.gridViewMaster.FocusedRowHandle]["NGUOI_DUYET"] = NguoiDuyetID;
                barButtonItemK_Duyet.Enabled = false;
                barButtonItemDuyet.Enabled = true;
                return true;
            }
            return false;
        }

        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        }

        #endregion
    }
}