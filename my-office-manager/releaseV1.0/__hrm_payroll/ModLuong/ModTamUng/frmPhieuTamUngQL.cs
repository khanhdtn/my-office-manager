using System;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Collections.Generic;
using DAO;
using ProtocolVN.DanhMuc;
using System.Data;
using System.Text;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraBars;
using System.Data.Common;
using DevExpress.XtraEditors;
using ProtocolVN.App.Office;
using ProtocolVN.Plugin.TimeSheet;

namespace office
{
    public partial class frmPhieuTamUngQL :PhieuQuanLy10Change , IDuyetSupport,IFormRefresh
    //public partial class frmPhieuTamUngQL : XtraFormPL
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //protected DevExpress.XtraBars.BarManager barManager1;
        //protected DevExpress.XtraBars.Bar MainBar;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemView;
        //protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        //protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        //protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemTaoPhieuMuaHang;
        //private System.ComponentModel.IContainer components;
        //private DevExpress.XtraBars.BarSubItem barSubItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //#endregion

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhieuTamUngQL).FullName,
                "Tạm ứng",
                ParentID, true,
                typeof(frmPhieuTamUngQL).FullName,
                true, IsSep, "", true, "", "");
        }
        private PhieuQuanLy10Fix that;
        private bool IsSave = false;
        #region Contructor(s)
        public frmPhieuTamUngQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "MA_PHIEU";
            that = new PhieuQuanLy10Fix(this,typeof(frmPhieuTamUngQL).FullName,this.UpdateRow());
            this.barButtonItemPrint.Visibility = BarItemVisibility.Never;
            gridViewMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewMaster_FocusedRowChanged);
            //Các thiết lập cho nút duyệt và không duyệt
            barButtonItemDuyet.Enabled = false;
            barButtonItemKoDuyet.Enabled = false;
            barButtonItemDuyet.Glyph = FWImageDic.COMMIT_IMAGE16;            
            barButtonItemKoDuyet.Glyph = FWImageDic.UNCOMMIT_IMAGE16;
            barButtonItemCommit.Visibility = BarItemVisibility.Never;
            barButtonItemNoCommit.Visibility = BarItemVisibility.Never;
            //------------------------------------------
            
        }

        void gridViewMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (((DataTable)this.gridControlMaster.DataSource).Rows.Count > 0 && gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle) == false)
            {
                if (row == null) return;
                if (row[PhieuTamUngFields.CHUYEN_DEN_LUONG_BIT].ToString().Equals("Y") 
                    || row[PhieuTamUngFields.KET_CHUYEN_TU_LUONG].ToString().Equals("Y"))
                {
                    barButtonItemDelete.Enabled = false;
                    barButtonItemUpdate.Enabled = false;
                    barButtonItemDuyet.Enabled = false;
                    barButtonItemKoDuyet.Enabled = false;
                }
                else
                {
                    //Xử lý enable cho nút duyệt và không duyệt
                    barButtonItemDuyet.Enabled = true;
                    barButtonItemKoDuyet.Enabled = true;
                    if (row[PhieuTamUngFields.DUYET].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                    {
                        barButtonItemDuyet.Enabled = false;
                        barButtonItemKoDuyet.Enabled = true;
                    }
                    else if (row[PhieuTamUngFields.DUYET].ToString() == ((Int32)DuyetSupportStatus.KhongDuyet).ToString())
                    {
                        barButtonItemKoDuyet.Enabled = false;
                        barButtonItemDuyet.Enabled = true;
                    }
                    else
                    {
                        barButtonItemDuyet.Enabled = true;
                        barButtonItemKoDuyet.Enabled = true;
                    }
                    //-----------------------------------------
                }
            }
            else
            {
                barButtonItemDuyet.Enabled = false;
                barButtonItemKoDuyet.Enabled = false;
            }
        }                       
        #endregion
        #region Methods of Framework
        public override void InitColumnMaster()
        {
            DataSet tableNhanVien = DMNhanVienX.I.LoadAll();            
            HelpGridColumn.CotTextLeft(colMaphieu, PhieuTamUngFields.MA_PHIEU);
            HelpGridColumn.CotCombobox(colNguoiDeNghi, tableNhanVien, "ID", "NAME", PhieuTamUngFields.NGUOI_DE_NGHI_ID);
            HelpGridColumn.CotCalcEdit(colSoTien, PhieuTamUngFields.SO_TIEN_XIN_UNG, 0);
            HelpGridColumn.CotMemoExEdit(colLyDo, PhieuTamUngFields.LY_DO);
            HelpGridColumn.CotCombobox(colNguoiDuyet, "DM_NHAN_VIEN", "ID", "NAME", PhieuTamUngFields.NGUOI_DUYET);
            HelpGridColumn.CotTextLeft(colGhichu, PhieuTamUngFields.GHI_CHU);
            HelpGridColumn.CotTextCenter(colThangTamUng, PhieuTamUngFields.THANG_TAM_UNG);
            HelpGridColumn.CotDateEdit(colNgayXinTamUng, PhieuTamUngFields.NGAY_XIN_TAM_UNG);
            HelpGridColumn.CotPLImageCheck(colQuaLuong, PhieuTamUngFields.CHUYEN_DEN_LUONG_BIT);
            HelpGridColumn.CotPLImageCheck(colKetChuyen, PhieuTamUngFields.KET_CHUYEN_TU_LUONG);
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            colThangTamUng.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            #region Summary
            this.colSoTien.SummaryItem.FieldName = PhieuTamUngFields.SO_TIEN_XIN_UNG;
            this.colSoTien.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            #endregion
        }
        public override void InitColumDetail()
        {
            
        }       
        public override void PLLoadFilterPart()
        {
            dateThangNam._timeEdit.Time = HelpDB.getDatabase().GetSystemCurrentDateTime().AddMonths(-1);
            dateThangNamDen._timeEdit.Time = DABase.getDatabase().GetSystemCurrentDateTime();
           // DMNhanVienX.I.InitCtrl(NhanVien, true, true);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            PLTimeSheetUtil.PermissionForControl(NhanVien, barButtonItemDuyet.Visibility == BarItemVisibility.Always, NhanVien.Visible == true);
            this.gridViewMaster.OptionsView.ShowFooter = true;
            HelpControl.RedCheckEdit(chkEditKetChuyen, false);
            HelpControl.RedCheckEdit(chkEditQuaLuong, false);
            this.DuyetSelect.unCheck(3);
            this.DuyetSelect.unCheck(2);
            this.DuyetSelect._initRedCheckEdit();
            this.DuyetSelect.unCheck(1);
            this.DuyetSelect.check(3);
            this.DuyetSelect.check(1);
            this.DuyetSelect.check(2);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            chkEditKetChuyen.CheckedChanged += delegate(object checkEdit, EventArgs checkChanged) {
                colKetChuyen.Visible = chkEditKetChuyen.Checked;
            };
            chkEditQuaLuong.CheckedChanged += delegate(object checkEdit, EventArgs checkChanged) {
                colQuaLuong.Visible = chkEditQuaLuong.Checked;
            };
            HelpGrid.SetReadOnlyHaveMemoCtrl(gridViewMaster);
            
        }

        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            filter.addCondition(PhieuTamUngFields.THANG_TAM_UNG + GetStringThangTamUng(dateThangNam,dateThangNamDen));
            filter.addID(PhieuTamUngFields.NGUOI_DE_NGHI_ID, NhanVien._getSelectedID());            
            filter.addDuyet(PhieuTamUngFields.DUYET, DuyetSelect.layTrangThai());
            filter.addCondition(" 1=1 ");
            msg.Finish();
            return filter;
        }       
        public override void ShowViewForm(long id)
        {
            ProtocolForm.ShowModalDialog(this, new frmPhieuTamUng(id, null, null));
        }
        public override void ShowUpdateForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row[PhieuTamUngFields.KET_CHUYEN_TU_LUONG].ToString() == "Y"){
                return;
            }
            ProtocolForm.ShowModalDialog(this, new frmPhieuTamUng(id, false, null));
        }        
        public override long[] ShowAddForm()
        {
            frmPhieuTamUng frm = new frmPhieuTamUng();
            //frm.RefreshData += new frmPhieuTamUng.RefreshDataQL(SetIsSave);
            ProtocolForm.ShowModalDialog(this, frm);
            //if (IsSave)
            //{
            //    //that.PLRefresh();
            //    IsSave = false;
            //} 
            return null;
        }
        public override bool XoaAction(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row[PhieuTamUngFields.KET_CHUYEN_TU_LUONG].ToString() == "Y"){
                HelpMsgBox.ShowNotificationMessage("Dữ liệu đang chọn được tạo từ nghiệp vụ \"Kết chuyển tạm ứng\".  Không cho phép xóa!");
                return false;
            }
            return DAPhieuTamUng.I.Delete(id);
        }
        public override string UpdateRow()
        {
            return @"SELECT ID,MA_PHIEU,NGUOI_DE_NGHI_ID,
                        SO_TIEN_XIN_UNG,NGUOI_DUYET,GHI_CHU,
                        THANG_TAM_UNG,NGAY_XIN_TAM_UNG,DUYET,KET_CHUYEN_TU_LUONG,CHUYEN_DEN_LUONG_BIT,
                        CASE 
                        WHEN LY_DO IS NULL THEN 'Tạm ứng lương'
                        ELSE 'Tạm ứng công tác phí. Lý do: ' || LY_DO END LY_DO
                    FROM " + DAPhieuTamUng.TABLE_MAP + " WHERE 1=1";
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        public override _MenuItem GetBusinessMenuList()
        {            
            return null;          
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        public override void HookFocusRow()
        {
        }
        #endregion
        #region Ext        
        private void barButtonItemDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridViewMaster.SelectedRowsCount < 1)
            {
                HelpMsgBox.ShowNotificationMessage("Chưa chọn dữ liệu.");
            }
            else
            {
                foreach (int num in gridViewMaster.GetSelectedRows())
                {
                    long iD = HelpNumber.ParseInt64(gridViewMaster.GetRowCellValue(num, this.IDField));
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc duyệt dữ liệu đang chọn không?")==System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            if (((IDuyetSupport)this).DuyetAction(iD, FrameworkParams.currentUser.employee_id, HelpDB.getDatabase().GetSystemCurrentDateTime()))
                            {
                                this.gridViewMaster.SetRowCellValue(num, "DUYET", "2");
                                that.gridViewMaster_FocusedRowChanged(null, null);
                                this.gridViewMaster_FocusedRowChanged(null, null);
                            }
                            else
                            {
                                HelpMsgBox.ShowNotificationMessage("Thực hiện không thành công.");
                            }
                        }
                        catch (Exception exception)
                        {
                            PLException.AddException(exception);
                        }
                    }
                }
            }

        }

        private void barButtonItemKoDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row != null)
            {
                if (row[PhieuTamUngFields.KET_CHUYEN_TU_LUONG].ToString() == "Y")
                {
                    //HelpMsgBox.ShowNotificationMessage(string.Format("Phiếu tạm ứng \"{0}\" được tạo từ nghiệp vụ \"Kết chuyển tạm ứng\" của form \" Quản lý lương\", không cho phép không duyệt!", row["MA_PHIEU"]));
                    HelpMsgBox.ShowNotificationMessage("Dữ liệu đang chọn được tạo từ nghiệp vụ \"Kết chuyển tạm ứng\".  Không cho phép không duyệt!");
                    return;
                }
            }
            if (this.gridViewMaster.SelectedRowsCount < 1)
            {
                HelpMsgBox.ShowNotificationMessage("Chưa chọn dữ liệu.");
            }
            else
            {
                foreach (int num in this.gridViewMaster.GetSelectedRows())
                {
                    long iD = HelpNumber.ParseInt64(this.gridViewMaster.GetRowCellValue(num, this.IDField));
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc không duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            if (((IDuyetSupport)this).KhongDuyetAction(iD, FrameworkParams.currentUser.employee_id, HelpDB.getDatabase().GetSystemCurrentDateTime()))
                            {
                                    this.gridViewMaster.SetRowCellValue(num, "DUYET", "3");
                                    that.gridViewMaster_FocusedRowChanged(null, null);
                                    this.gridViewMaster_FocusedRowChanged(null, null);
                            }
                            else
                            {
                                HelpMsgBox.ShowNotificationMessage("Thực hiện không thành công.");
                            }
                        }
                        catch (Exception exception)
                        {
                            PLException.AddException(exception);
                        }
                    }
                }
            }


        }
        private void SetIsSave() {
            IsSave = true;
        }
        /// <summary>
        /// Lấy ra chuỗi thời gian của tháng tạm ứng
        /// </summary>
        /// <param name="ThangTamUngTu"></param>
        /// <param name="ThangTamUngDen"></param>
        /// <returns></returns>
        private string GetStringThangTamUng(PLMonthYearTimeEdit ThangTamUngTu, PLMonthYearTimeEdit ThangTamUngDen)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("LAYSOTHANG");
            db.AddInParameter(cmd, "@TUNGAY", DbType.DateTime, ThangTamUngTu._timeEdit.Time);
            db.AddInParameter(cmd, "@DENNGAY", DbType.DateTime, ThangTamUngDen._timeEdit.Time);
            int SoThang = HelpNumber.ParseInt32(db.ExecuteScalar(cmd));
            PLMonthYearTimeEdit ThangTang = new PLMonthYearTimeEdit();            
            StringBuilder StrThangNam = new StringBuilder("") ;
            if (SoThang > 0)
            {
                ThangTang._timeEdit.Time = ThangTamUngTu._timeEdit.Time;
                StrThangNam.Append(" in('" + ThangTamUngTu._timeEdit.Text + "'");
                for (int i = 0; i < SoThang; i++)
                {
                    ThangTang._timeEdit.Time = ThangTang._timeEdit.Time.AddMonths(1);
                    StrThangNam.Append(",'" + ThangTang._timeEdit.Text + "'");
                }
            }
            else if (SoThang < 0)
            {
                StrThangNam.Append(" in(' '");
            }
            else StrThangNam.Append(" in('" + ThangTamUngTu._timeEdit.Text + "'").ToString();
            return StrThangNam.Append(")").ToString();
        }
        #endregion

        #region IDuyetSupport Members

        bool IDuyetSupport.DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            DataRow row = this.gridViewMaster.GetDataRow(this.gridViewMaster.FocusedRowHandle);
            if (PLGUIUtil.UpdateDuyetPhieu("PHIEU_TAM_UNG", "ID",
                    ID,
                    FrameworkParams.currentUser.employee_id
                    , HelpDB.getDatabase().GetSystemCurrentDateTime(), DuyetSupportStatus.Duyet)) 
            {
                row["DUYET"] = "3";
                DAPhieuTamUng.I._GuiMailTamUng(row, HelpNumber.ParseInt64(row[PhieuTamUngFields.NGUOI_DE_NGHI_ID]));
                return true;
            }
            return false;
        }

        bool IDuyetSupport.KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (PLGUIUtil.UpdateDuyetPhieu("PHIEU_TAM_UNG", "ID",
                    ID,
                    FrameworkParams.currentUser.employee_id
                    , HelpDB.getDatabase().GetSystemCurrentDateTime(), DuyetSupportStatus.KhongDuyet))
            {
                row["DUYET"] = "2";
                DAPhieuTamUng.I._GuiMailTamUng(row, HelpNumber.ParseInt64(row[PhieuTamUngFields.NGUOI_DE_NGHI_ID]));
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