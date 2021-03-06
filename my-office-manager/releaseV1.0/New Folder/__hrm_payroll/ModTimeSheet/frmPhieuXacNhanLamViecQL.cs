using System;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Collections.Generic;
using DevExpress.XtraBars;
using ProtocolVN.DanhMuc;
using DAO;
using DTO;
using ProtocolVN.Plugin.TimeSheet;
using ProtocolVN.App.Office;
using DevExpress.XtraGrid;
using System.Drawing;
using System.IO;

namespace office
{
    public partial class frmPhieuXacNhanLamViecQL : PhieuQuanLy10Change, IDuyetSupport,IFormRefresh
    //public partial class frmPhieuXacNhanLamViecQL : XtraFormPL
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
            return MenuBuilder.CreateItem(typeof(frmPhieuXacNhanLamViecQL).FullName,
                "Xác nhận làm việc",
                ParentID, true,
                typeof(frmPhieuXacNhanLamViecQL).FullName,
                true, IsSep, "", true, "", "");
        }
        private PhieuQuanLy10Fix that;
        public frmPhieuXacNhanLamViecQL()
        {
            InitializeComponent();
            IDField =  "ID";
            DisplayField = "LY_DO";
            that = new PhieuQuanLy10Fix(this);
        } 
      
        public override void InitColumnMaster()
        {
            DataSet DsData = HelpDB.getDatabase().LoadDataSet("Select * from DM_NHAN_VIEN");
            HelpGridColumn.CotTextLeft(ColMaster_ID, "ID");
            HelpGridColumn.CotCombobox(ColMaster_NhanVien, DsData, "ID", "NAME", "NV_ID");
            HelpGridColumn.CotPLTimeEdit(ColMasterNgay, "NGAY_LAM_VIEC", "ddd, dd/MM/yyyy");
            HelpGridColumn.CotPLTimeEdit(ColMaster_TG_Tu, "GIO_BAT_DAU", PLConst.FORMAT_TIME_HH_MM);
            HelpGridColumn.CotPLTimeEdit(ColMaster_TG_Den, "GIO_KET_THUC", PLConst.FORMAT_TIME_HH_MM);
            HelpGridColumn.CotTextLeft(ColMaster_NoiDung, "LY_DO");
            HelpGridColumn.CotPLTimeEdit(cotThoiGianCN, "THOI_GIAN_GHI_NHAN", PLConst.FORMAT_DATETIME_STRING);
            DsData = DATimeInOut.Instance.LoaiXacNhan();
            HelpGridColumn.CotCombobox(CoMaster_LoaiXacNhan, DsData, "ID", "NAME", "XAC_NHAN_ID");
            ColMaster_NhanVien.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            HelpGridExt1.colMultiline(ColMaster_NoiDung, "LY_DO");
            gridViewMaster.OptionsView.RowAutoHeight = true;
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
            this.barButtonItemDuyet.Glyph = FWImageDic.COMMIT_IMAGE16;
            this.barButtonItemK_Duyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDuyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemK_Duyet.Glyph = FWImageDic.UNCOMMIT_IMAGE16;
            this.barButtonItemDuyet.Enabled = this.barButtonItemK_Duyet.Enabled = false;
            this.barButtonItemPrint.Visibility = BarItemVisibility.Never;
            barButtonItemDuyet.ItemClick += new ItemClickEventHandler(barButtonItemDuyet_ItemClick);
            barButtonItemK_Duyet.ItemClick += new ItemClickEventHandler(barButtonItemK_Duyet_ItemClick);
            HelpControl.RedCheckEdit(this.chkCompany,false);
            HelpControl.RedCheckEdit(this.chkCus,false);
            chkCompany.Checked = chkCus.Checked = true; 
           // DMNhanVienX.I.InitCtrl(NhanVien, true, true);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            gridViewMaster.OptionsBehavior.Editable = false;
            splitContainerControl1.Collapsed = true;
            splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
            HelpGridExt1.SetDefaultGroupPanel(this.gridViewMaster);
            PLTimeSheetUtil.PermissionForControl(NhanVien, barButtonItemDuyet.Visibility == BarItemVisibility.Always, NhanVien.Visible == true);
            //ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromDateToDate;
            ngayLamViec.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            this.DuyetSelect.unCheck(3);
            this.DuyetSelect.unCheck(2);
            this.DuyetSelect._initRedCheckEdit();
            this.DuyetSelect.unCheck(1);
            this.DuyetSelect.check(3);
            this.DuyetSelect.check(1);
            this.DuyetSelect.check(2);
            chkCompany.CheckedChanged += delegate(object chkCom, EventArgs checkedChanged) {
                if (chkCompany.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkCus.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    chkCompany.Checked = true;
            };
            chkCus.CheckedChanged += delegate(object chkCustom, EventArgs checkedChanged) {
                if (chkCus.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkCompany.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    chkCus.Checked = true;
            };
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
            filter.addID("NV_ID", NhanVien._getSelectedID());
            filter.addDateFromTo("NGAY_LAM_VIEC", ngayLamViec.FromDate, ngayLamViec.ToDate);
            filter.addDuyet(PLConst.FIELD_DUYET, DuyetSelect.layTrangThai());
            filter.addIn("LOAI_XAC_NHAN", this.getLoaiXacNhan());
            msg.Finish();
            return filter;
        }

        //public override DataTable PLLoadDataDetailPart(long MasterID)
        //{
        //    return null;
        //}

        public override void ShowViewForm(long id)
        {
            frmPhieuXNLamViec frm = new frmPhieuXNLamViec(id, null);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        public override void ShowUpdateForm(long id)
        {
            frmPhieuXNLamViec frm = new frmPhieuXNLamViec(id, false);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        public override long[] ShowAddForm()
        {
            frmPhieuXNLamViec frm = new frmPhieuXNLamViec();
            //frm.RefreshData += new frmPhieuXNLamViec.RefreshPhieuXacNhan(PLBuildQueryFilter);
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }

        public override bool XoaAction(long id)
        {
            DOTimeInOut phieu = DATimeInOut.Instance.LoadAll(id);
            if (DATimeInOut.Instance.Delete(id))
            {
                PLTimeSheetUtil._SendThongBao(phieu, string.Empty, null, LoaiPhieu.PhieuXacNhanLamViec);
                return true;
            }
            return false; 
        }

        public override string UpdateRow()
        {
            return
                @"SELECT NLV.*,CAST(LOAI_XAC_NHAN AS NUMERIC) XAC_NHAN_ID
                FROM CAPNHAT_NGAYLAMVIEC NLV WHERE LOAI =" + ((Int32)TimeInOutType.XacNhanLamViec).ToString() + " AND 1=1";
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }

        public override _MenuItem GetBusinessMenuList()
        {
            return new _MenuItem(new string[] { "Gửi tin nhắn" },
                 new string[] { "email.png" },
                IDField,
                 new DelegationLib.CallFunction_MulIn_NoOut[] { SendMail },
                 new PermissionItem[] { 
                     AppPermission.FQuanTriXNLamViec.GetPermissionItem(PermissionType.EDIT)
                 });
        }
        private void SendMail(List<object> ids)
        {
            DataRow row = gridViewMaster.GetFocusedDataRow();
            if (row == null) return;
            frmSendEmail frm = new frmSendEmail(HelpNumber.ParseInt64(row[IDField]),
                typeof(frmPhieuXNLamViec).FullName,
                HelpNumber.ParseInt64(row["NV_ID"]), gridViewMaster, false);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

      
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }

        public override void HookFocusRow()
        {
            if (gridViewMaster.DataSource != null && gridViewMaster.RowCount > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (row == null)
                    return;
                if (row["LOAI"].ToString() != ((Int32)TimeInOutType.GhiThoiGian).ToString() && gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle) == false)
                {

                    if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                    {
                        if (string.Compare(FrameworkParams.currentUser.username, "admin") == 0
                            || string.Compare(FrameworkParams.currentUser.employee_id.ToString(), row["NV_ID"].ToString()) == 0)
                            barButtonItemUpdate.Enabled = true;
                        else barButtonItemUpdate.Enabled = false;
                        barButtonItemDuyet.Enabled = barButtonItemK_Duyet.Enabled = true;
                    }
                    else if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                    {
                        barButtonItemUpdate.Enabled = false;
                        barButtonItemDuyet.Enabled = false;
                        barButtonItemK_Duyet.Enabled = true;
                    }
                    else
                    {
                        if (string.Compare(FrameworkParams.currentUser.username, "admin") == 0
                            || string.Compare(FrameworkParams.currentUser.employee_id.ToString(), row["NV_ID"].ToString()) == 0)
                            barButtonItemUpdate.Enabled = true;
                        else barButtonItemUpdate.Enabled = false;
                        barButtonItemK_Duyet.Enabled = false;
                        barButtonItemDuyet.Enabled = true;
                    }
                }
                else {
                    barButtonItemDuyet.Enabled = barButtonItemK_Duyet.Enabled = false;
                }
                barSubItem1.Enabled = true;
            }
        }

        #region IDuyetSupport Members

        void barButtonItemK_Duyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DateTime Ngay_duyet = HelpDB.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc không duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
                    if (KhongDuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                    {
                        row[PLConst.FIELD_DUYET] = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();
                        barButtonItemUpdate.Enabled = true;
                        barButtonItemDelete.Enabled = true;
                    }
            }
        }

        void barButtonItemDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DateTime Ngay_duyet = HelpDB.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
                    if (DuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                    {
                        row[PLConst.FIELD_DUYET] = ((Int32)DuyetSupportStatus.Duyet).ToString();
                        barButtonItemUpdate.Enabled = false;
                        barButtonItemDelete.Enabled = false;
                    }
            }
        }


        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.Duyet))
            {
                PLTimeSheetUtil._SendThongBao(DATimeInOut.Instance.LoadAll(ID), PLConst.DUYET, null, LoaiPhieu.PhieuXacNhanLamViec);
                barButtonItemDuyet.Enabled = false;
                barButtonItemK_Duyet.Enabled = true;
                return true;
            }
            else return false;
        }
        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.KhongDuyet)) {
                PLTimeSheetUtil._SendThongBao(DATimeInOut.Instance.LoadAll(ID), PLConst.KHONG_DUYET, null, LoaiPhieu.PhieuXacNhanLamViec);
                barButtonItemDuyet.Enabled = true;
                barButtonItemK_Duyet.Enabled = false;
                return true; 
            }
            else return false;
        }
        #endregion

        private string[] getLoaiXacNhan() {
            if ((this.chkCompany.Checked && this.chkCus.Checked) ||
                (this.chkCompany.Checked == false && this.chkCus.Checked == false))
            {
                return new string[] { "1", "2" };
            }
            if (this.chkCompany.Checked && this.chkCus.Checked == false)
                return new string[] { "2" };
            if (this.chkCus.Checked && this.chkCompany.Checked == false)
                return new string[] { "1" };

            return new string[] {"1","2"};
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