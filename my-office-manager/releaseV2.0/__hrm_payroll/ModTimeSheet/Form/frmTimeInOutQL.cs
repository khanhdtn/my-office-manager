#region using
using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraBars;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DTO;
using ProtocolVN.DanhMuc;
using pl.office.form;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Text;
using pl.office;
using System.Windows.Forms;
using System.Data.Common;
#endregion

namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmTimeInOutQL : PhieuQuanLy10Change, IDuyetSupport
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
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
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

        #region Các khai báo biến
        private PhieuQuanLy10Fix Fix;
        private DOSystemParams TimeSystem;
        #endregion

        #region Các hàm khởi tạo
        public static FormStatus Status = FormStatus.OK_TEST;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTimeInOutQL).FullName,
                "Thời gian làm việc",
                ParentID, true,
                typeof(frmTimeInOutQL).FullName,
                false, IsSep, "mnbPhieuMuaHang.png", true, "", "");
        }
        public frmTimeInOutQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "ID";
            Fix = new PhieuQuanLy10Fix(this);
            TimeSystem = DASystemParams.Instance.LoadAll(1);
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            Cot_Noi_Dung.Visible = true;
            InitState(false);
            this.barButtonItemDuyet.Glyph = FWImageDic.COMMIT_IMAGE16;
            this.barButtonItemK_Duyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDuyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemK_Duyet.Glyph = FWImageDic.UNCOMMIT_IMAGE16;
            this.barButtonItemPrint.Visibility = BarItemVisibility.Never;
            barButtonItemDuyet.ItemClick += new ItemClickEventHandler(barButtonItemDuyet_ItemClick);
            barButtonItemK_Duyet.ItemClick += new ItemClickEventHandler(barButtonItemK_Duyet_ItemClick);
            gridViewMaster.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(gridViewMaster_CustomDrawCell);
            barSubItem1.Visibility = BarItemVisibility.Always;
        }
        void gridViewMaster_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;
            GridViewInfo vieww = view.GetViewInfo() as GridViewInfo;
            GridDataRowInfo t = vieww.GetGridRowInfo(e.RowHandle) as GridDataRowInfo;
            object Gio_BD = view.GetRowCellValue(e.RowHandle, Cot_GioBatDau);
            object Gio_KT = view.GetRowCellValue(e.RowHandle, Cot_GioKetThuc);
            object Ngay_LV = view.GetRowCellValue(e.RowHandle, Cot_NgayLamViec);
            try
            {
                if (Gio_BD != null && Gio_BD != DBNull.Value)
                {
                    if (System.Convert.ToDateTime(Gio_BD) >= TimeSystem.GIO_BAT_DAU_SANG)
                    {
                        gridViewMaster.Appearance.Reset();
                        t.Cells[Cot_GioBatDau].Appearance.ForeColor = Color.Red;
                        if (System.Convert.ToDateTime(Gio_BD) > TimeSystem.GIO_KET_THUC_SANG)
                        {
                            gridViewMaster.Appearance.Reset();
                            t.Cells[Cot_GioKetThuc].Appearance.ForeColor = Color.Red;
                        }
                    }
                }
                if (Gio_KT != null && Gio_KT != DBNull.Value)
                {
                    if (System.Convert.ToDateTime(Gio_KT) < TimeSystem.GIO_KET_THUC_CHIEU && System.Convert.ToDateTime(Ngay_LV).DayOfWeek != DayOfWeek.Saturday)
                    {
                        gridViewMaster.Appearance.Reset();
                        if (System.Convert.ToDateTime(Gio_KT) < TimeSystem.GIO_BAT_DAU_CHIEU)
                            t.Cells[Cot_GioBatDau].Appearance.ForeColor = Color.Red;
                        gridViewMaster.Appearance.Reset();
                        t.Cells[Cot_GioKetThuc].Appearance.ForeColor = Color.Red;
                    }
                    else if (System.Convert.ToDateTime(Gio_KT) < TimeSystem.GIO_BAT_DAU_SANG && System.Convert.ToDateTime(Ngay_LV).DayOfWeek == DayOfWeek.Saturday)
                    {
                        gridViewMaster.Appearance.Reset();
                        t.Cells[Cot_GioKetThuc].Appearance.ForeColor = Color.Red;
                    }
                }
            }
            catch { }
        }

        private void frmTimeInOutQL_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region Methods of Framework
        public override void InitColumnMaster()
        {
            ID.FieldName = "ID";
            XtraGridSupportExt.TextLeftColumn(Cot_TenNV, "TEN_NV");
            XtraGridSupportExt.DateTimeGridColumn(Cot_NgayLamViec, "NGAY_LAM_VIEC");
            HelpGridColumn.CotPLTimeEdit(Cot_GioBatDau, "GIO_BAT_DAU");
            HelpGridColumn.CotPLTimeEdit(Cot_GioKetThuc, "GIO_KET_THUC");
            HelpGridColumn.CotPLTimeEdit(CotTG_LV, "THOI_GIAN_LAM_VIEC","HH:mm"); 
            HelpGridColumn.CotPLImageCheck(Cot_Cham_Cong, "IS_CHAM_CONG");
            XtraGridSupportExt.TextCenterColumn(Cot_N_Bs, "THOI_GIAN_SANG");
            XtraGridSupportExt.TextCenterColumn(Cot_N_BC, "THOI_GIAN_CHIEU");
            XtraGridSupportExt.BitGridColumn(Cot_NP_Nam, "NGHI_PHEP_NAM");
            XtraGridSupportExt.BitGridColumn(Cot_NP_KL, "NGHI_KHONG_LUONG");
            Cot_NP_Nam.Visible = false;
            Cot_NP_KL.Visible = false;
            XtraGridSupportExt.TextLeftColumn(CotLoaiDT_VS, "LOAI_DI_TRE_VE_SOM");
            XtraGridSupportExt.TextLeftColumn(Cot_Noi_Dung, "NOI_DUNG");
            XtraGridSupportExt.TextLeftColumn(CotLoai, "LOAI");
            XtraGridSupportExt.TextLeftColumn(CotIP_Address, "IP_ADDRESS");
            CotIP_Address.Caption = "Địa chỉ máy";
            CotTG_LV.Caption = "Thời gian làm việc (hh:mm)";
            Cot_N_Bs.Caption = "Sáng (hh:mm)";
            Cot_N_BC.Caption = "Chiều (hh:mm)";
            PLGUIUtil.BestFitMasterColumns(this.gridViewMaster);
        }
        public void InitState(bool State)
        {
            barButtonItemDuyet.Enabled = State;
            barButtonItemK_Duyet.Enabled = State;
        }
        public override void InitColumDetail()
        {
            ////Format 1 dòng lưới
            StyleFormatCondition cn = new StyleFormatCondition(FormatConditionEnum.NotEqual, CotLoai, null, "1");
            cn.Appearance.ForeColor = Color.Red;
            cn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            cn.Column = CotLoai;
            cn.ApplyToRow = true;
            gridViewMaster.FormatConditions.Add(cn);
        }

        void gridViewMaster_CustomDrawRowPreview(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Red;
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            e.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Italic);
        }
        public override void PLLoadFilterPart()
        {
            ShowFooter();
            DMNhanVienX.I.InitCtrl(PLNhanVien, true);
            HelpControl.RedCheckEdit(chkDaChamCong);
            HelpControl.RedCheckEdit(chkChuaChamCong);
            HelpControl.RedCheckEdit(chkDi_tre);
            HelpControl.RedCheckEdit(chkVe_som);
            chkDaChamCong.Checked = true;
            chkChuaChamCong.Checked = true;
            this.ApplyPermissionData(PLNhanVien, PLPermission.FXemThoiGianLamViecToanBo.featureName);
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            PLOptions.ReSetData();
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            filter.addID("NLV.NV_ID", PLNhanVien._getSelectedID());
            if (this.getISChamCong().Length == 3)
                filter.addCondition("(IS_CHAM_CONG in ('Y','N','') or IS_CHAM_CONG is null )");
            else
                filter.addIn("IS_CHAM_CONG", this.getISChamCong());
            StringBuilder s_condition = new StringBuilder("");
            if (chkDi_tre.Checked)
                s_condition.Append("GIO_BAT_DAU>='" + PLOptions.GIO_DI_TRE.TimeOfDay.ToString() + "'");
            if (chkVe_som.Checked && chkDi_tre.Checked)
                s_condition.Append("OR GIO_KET_THUC<CASE WHEN EXTRACT(WEEKDAY FROM NLV.NGAY_LAM_VIEC)=6 THEN '" + PLOptions.GIO_NGHI_TRUA.TimeOfDay.ToString() + "' ELSE '" + PLOptions.GIO_VE_SOM.TimeOfDay.ToString() + "' END");
            else if (chkVe_som.Checked)
                s_condition.Append("GIO_KET_THUC<CASE WHEN EXTRACT(WEEKDAY FROM NLV.NGAY_LAM_VIEC)=6 THEN '" + PLOptions.GIO_NGHI_TRUA.TimeOfDay.ToString() + "' ELSE '" + PLOptions.GIO_VE_SOM.TimeOfDay.ToString() + "' END");
            if (s_condition.Length > 0)
                filter.addCondition(s_condition.ToString());
            filter.addDateFromTo("NLV.NGAY_LAM_VIEC", TuNgay.DateTime, DenNgay.DateTime);
            filter.setDescOrderBy("NLV.NGAY_LAM_VIEC");
            filter.setAscOrderBy("NV.TEN_NV");
            return filter;
        }
        public override void ShowViewForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
            {
                frmNghiPhep frm = new frmNghiPhep(id, null);
                ProtocolForm.ShowModalDialog(this, frm);
            }
            else if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.DiSomVeTre)
            {
                frmDiTreVeSom frm = new frmDiTreVeSom(id, null);
                ProtocolForm.ShowModalDialog(this, frm);
            }
            else
            {
                frmTimeInOut frm = new frmTimeInOut(HelpNumber.ParseInt64(row["NV_ID"]), (DateTime)row["NGAY_LAM_VIEC"], null);
                ProtocolForm.ShowModalDialog(this, frm);
            }
        }
        public override void ShowUpdateForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
            {
                frmNghiPhep frm = new frmNghiPhep(id, false);
                ProtocolForm.ShowModalDialog(this, frm);
            }
            else if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.DiSomVeTre)
            {
                frmDiTreVeSom frm = new frmDiTreVeSom(id, false);
                ProtocolForm.ShowModalDialog(this, frm);
            }
            else
            {
                frmTimeInOut frm = new frmTimeInOut(HelpNumber.ParseInt64(row["NV_ID"]), (DateTime)row["NGAY_LAM_VIEC"], false);
                frm.ReFindData += new frmTimeInOut.RefreshGird(Fix.PLRefresh);
                ProtocolForm.ShowModalDialog(this, frm);
            }
        }
        public override long[] ShowAddForm()
        {
            frmTimeInOut frm = new frmTimeInOut();
            frm.ReFindData += new frmTimeInOut.RefreshGird(Fix.PLRefresh);
            ProtocolForm.ShowModalDialog(this, frm);
            return null;
        }
        public override bool XoaAction(long id)
        {
            return DATimeInOut.Instance.Delete(id);

        }

        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                new string[] { "Chuyển thời gian sang chấm công", "Chuyển nghỉ phép sang chấm công", "Đi trễ về sớm", "Thay đổi giờ bắt đầu/giờ kết thúc" },
                new string[] { "mnsMoveTimeInOut.png", "mnsMoveTimeInOut.png", "mnsDiTreVeSom.png", "fwEdit.png" },
                "ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    MoveTimeInOut,
                    MoveNghiPhep,
                    DiTreVeSom,ThaydoiGDBGKT                    
               }, new PermissionItem[]{
                        PLPermission.OChamCongAuto.GetPermissionItem(PermissionType.EDIT),
                        PLPermission.OChamCongAuto.GetPermissionItem(PermissionType.EDIT),
                        PLPermission.OThoiGianLamViec.GetPermissionItem(PermissionType.EDIT),
                        PLPermission.OThoiGianLamViec.GetPermissionItem(PermissionType.EDIT)
                    }
               );
            return menu;
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        public override string UpdateRow()
        {
            return @"SELECT NLV.ID,NLV.NGAY_LAM_VIEC,NLV.GIO_BAT_DAU,NLV.GIO_KET_THUC,
                            NLV.IS_CHAM_CONG,NGHI_BUOI_CHIEU,NGHI_BUOI_SANG,NOI_DUNG,LOAI,DUYET,
                            THOI_GIAN_LAM_VIEC,NLV.NV_ID,NV.TEN_NV,NGHI_PHEP_NAM,NGHI_KHONG_LUONG,IP_ADDRESS,THOI_GIAN_SANG,THOI_GIAN_CHIEU                                                      
                           ,CASE LOAI_DI_TRE_VE_SOM
                                WHEN 1 THEN 'Trễ buổi sáng'
                                WHEN 2 THEN 'Trễ buổi chiều'
                                WHEN 3 THEN 'Về sớm buổi sáng'
                                WHEN 4 THEN 'Về sớm buổi chiều'
                            END LOAI_DI_TRE_VE_SOM 
                           ,EXTRACT(HOUR FROM THOI_GIAN_LAM_VIEC) + cast((EXTRACT(MINUTE FROM THOI_GIAN_LAM_VIEC)) as numeric(15,2))/60 TG,
                            CASE NLV.GIO_BAT_DAU
                                WHEN NLV.GIO_KET_THUC THEN 'Tự động kết thúc'                                  
                                ELSE 'Có kết thúc'
                            END AUTOTHEEND
                          FROM CAPNHAT_NGAYLAMVIEC NLV, DM_NHAN_VIEN NV WHERE
                          NV.ID = NLV.NV_ID 
                          AND 1=1";
        }
        public override void HookFocusRow()
        {
            decimal ThoiGian = HelpNumber.ParseDecimal(CotTG_LV.SummaryItem.SummaryValue);
            CotTG_LV.SummaryItem.DisplayFormat = ThoiGian + " giờ " + "(" + HelpNumber.RoundDecimal((ThoiGian / 8), 4) + " ngày)";
            if (gridViewMaster.DataSource != null && gridViewMaster.RowCount > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (row == null) return;
                if (row["LOAI"].ToString() != ((Int32)TimeInOutType.GhiThoiGian).ToString() && gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle) == false)
                {
                    if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                    {
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDuyet.Enabled = true;
                    }
                    else if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                    {
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDuyet.Enabled = false;
                    }
                    else
                    {
                        barButtonItemK_Duyet.Enabled = false;
                        barButtonItemDuyet.Enabled = true;
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
            DateTime Ngay_duyet = DABase.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (PLGUIUtil.IsDuyet(row[PLDBUtil.FIELD_DUYET]))
                {
                    if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
                        PLMessageBox.ShowNotificationMessage("Thông tin nghỉ phép của '" + row["TEN_NV"] + "' đã duyệt!");
                    else
                        PLMessageBox.ShowNotificationMessage("Thông tin đi trễ về sớm của '" + row["TEN_NV"] + "' đã duyệt!");
                }
                else
                {
                    if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
                    {
                        if (PLMessageBox.ShowConfirmMessage("Duyệt thông tin nghỉ phép của '" + row["TEN_NV"] + "' ?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (DuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                            {
                                row[PLDBUtil.FIELD_DUYET] = ((Int32)DuyetSupportStatus.Duyet).ToString();
                                barButtonItemUpdate.Enabled = false;
                                barButtonItemDelete.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        if (PLMessageBox.ShowConfirmMessage("Duyệt thông tin đi trễ về sớm của '" + row["TEN_NV"] + "' ?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (DuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                            {
                                row[PLDBUtil.FIELD_DUYET] = ((Int32)DuyetSupportStatus.Duyet).ToString();
                                barButtonItemUpdate.Enabled = false;
                                barButtonItemDelete.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        void barButtonItemK_Duyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DateTime Ngay_duyet = DABase.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (PLGUIUtil.IsKhongDuyet(row[PLDBUtil.FIELD_DUYET]))
                {
                    if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
                        PLMessageBox.ShowNotificationMessage("Thông tin nghỉ phép của '" + row["TEN_NV"] + "' đã không duyệt!");
                    else
                        PLMessageBox.ShowNotificationMessage("Thông tin đi trễ về sớm của '" + row["TEN_NV"] + "' đã không duyệt!");
                }
                else
                {
                    if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
                    {
                        if (PLMessageBox.ShowConfirmMessage("Không duyệt thông tin nghỉ phép của '" + row["TEN_NV"] + "' ?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (KhongDuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                            {
                                row[PLDBUtil.FIELD_DUYET] = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();
                                barButtonItemUpdate.Enabled = true;
                                barButtonItemDelete.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        if (PLMessageBox.ShowConfirmMessage("Không duyệt thông tin đi trễ về sớm của '" + row["TEN_NV"] + "' ?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (KhongDuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                            {
                                row[PLDBUtil.FIELD_DUYET] = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();
                                barButtonItemUpdate.Enabled = true;
                                barButtonItemDelete.Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        private void ThaydoiGDBGKT(List<object> ids)
        {
            frmChangeTimeInOut frm = new frmChangeTimeInOut();
            ProtocolForm.ShowModalDialog(this, frm);
            Fix.PLRefresh();
        }

        private void DiTreVeSom(List<object> ids)
        {
            if (ids != null)
            {
                frmDiTreVeSom frm = new frmDiTreVeSom();
                ProtocolForm.ShowModalDialog(this, frm);
                Fix.PLRefresh();
            }
        }

        private void XinNghiPhep(List<object> ids)
        {
            if (ids != null)
            {
                if (ids != null)
                {
                    frmNghiPhep frm = new frmNghiPhep();
                    ProtocolForm.ShowModalDialog(this, frm);
                    Fix.PLRefresh();
                }
            }
        }

        //Chuyển dữ liệu tập trung cả 2 loại : Ghi thời gian và nghỉ phép
        private void ChuyenDenBangChamCongAuto(List<object> ids)
        {
            bool bFlag = true;
            if (ids != null)
            {
                try
                {
                    Application.DoEvents();
                    FrameworkParams.wait = new WaitingMsg();
                    foreach (DataRow row in ((DataView)gridViewMaster.DataSource).Table.Rows)
                    {
                        bool IsChamCong = (row["IS_CHAM_CONG"].ToString() != "Y");
                        if ((HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.GhiThoiGian && IsChamCong) || (HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep && IsChamCong))
                        {
                            long NV_ID = HelpNumber.ParseInt64(row["NV_ID"]);
                            DOChamCongAuto phieu = DAChamCongAuto.Instance.LoadAll(NV_ID, (DateTime)row["NGAY_LAM_VIEC"]);
                            if (phieu.DetailDataSet.Tables[0].Select("NV_ID=" + NV_ID + " and NGAY='" + System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]) + "'").Length == 0)
                            {
                                phieu.NV_ID = NV_ID;
                                phieu.NGAY = System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]);
                            }
                            if (HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.GhiThoiGian)
                            {
                                if (row["THOI_GIAN_SANG"] != null && row["THOI_GIAN_SANG"].ToString() != string.Empty)
                                {
                                    string[] TGSang = row["THOI_GIAN_SANG"].ToString().Split(':');
                                    phieu.SANG = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal((HelpNumber.ParseInt32(TGSang[0]) + (HelpNumber.ParseInt32(TGSang[1]) / 60.0))), 2).ToString();
                                }
                                if (row["THOI_GIAN_CHIEU"] != null && row["THOI_GIAN_CHIEU"].ToString() != string.Empty)
                                {
                                    string[] TGChieu = row["THOI_GIAN_CHIEU"].ToString().Split(':');
                                    phieu.CHIEU = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal((HelpNumber.ParseInt32(TGChieu[0]) + (HelpNumber.ParseInt32(TGChieu[1]) / 60.0))), 2).ToString(); 
                                }
                            }
                            else
                            {
                                if (row["THOI_GIAN_SANG"] != null && row["THOI_GIAN_SANG"].ToString() != string.Empty) phieu.SANG = row["THOI_GIAN_SANG"].ToString();
                                if (row["THOI_GIAN_CHIEU"] != null && row["THOI_GIAN_CHIEU"].ToString() != string.Empty) phieu.CHIEU = row["THOI_GIAN_CHIEU"].ToString();
                            }
                            bool bflag = DAChamCongAuto.Instance.Update(phieu);
                            #region Cập nhật tình trạng chấm công tự động
                            if (bFlag)
                            {
                                DOTimeInOut doPhieu = DATimeInOut.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                doPhieu.IS_CHAM_CONG = "Y";
                                if (DATimeInOut.Instance.Update(doPhieu))
                                    DATimeInOut.Instance.UpdatePhieu(doPhieu);
                            }
                            #endregion
                        }
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                    Fix.PLRefresh();
                }
            }
        }
        //Chỉ chuyển dữ liệu thời gian làm việc
        private void MoveTimeInOut(List<object> ids)
        {
            bool bFlag = true;
            if (ids != null)
            {
                try
                {
                    DataSet forDBTime = DABase.getDatabase().LoadTable(DATimeInOut.TABLE_MAP);
                    DataSet forDBChamCongAuto = DABase.getDatabase().LoadTable(DAChamCongAuto.TABLE_MAP);

                    Application.DoEvents();
                    FrameworkParams.wait = new WaitingMsg();
                    foreach (DataRow row in ((DataView)gridViewMaster.DataSource).Table.Rows)
                    {
                        bool IsChamCong = (row["IS_CHAM_CONG"].ToString() != "Y");
                        if ((HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.GhiThoiGian && IsChamCong))
                        {
                            long NV_ID = HelpNumber.ParseInt64(row["NV_ID"]);
                            DOChamCongAuto phieu = DAChamCongAuto.Instance.LoadAll(NV_ID, (DateTime)row["NGAY_LAM_VIEC"]);
                            if (phieu.DetailDataSet.Tables[0].Select("NV_ID=" + NV_ID + " and NGAY='" + System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]) + "'").Length == 0)
                            {
                                phieu.NV_ID = NV_ID;
                                phieu.NGAY = System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]);
                            }
                            if (HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.GhiThoiGian)
                            {
                                phieu.SANG = "";
                                phieu.CHIEU = "";
                                if (row["THOI_GIAN_SANG"] != null && row["THOI_GIAN_SANG"].ToString() != string.Empty)
                                {
                                    string[] TGSang = row["THOI_GIAN_SANG"].ToString().Split(':');
                                    phieu.SANG = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal((System.Convert.ToInt32(TGSang[0]) + (System.Convert.ToInt32(TGSang[1]) / 60.0))), 2).ToString();
                                }
                                if (row["THOI_GIAN_CHIEU"] != null && row["THOI_GIAN_CHIEU"].ToString() != string.Empty)
                                {
                                    string[] TGChieu = row["THOI_GIAN_CHIEU"].ToString().Split(':');
                                    phieu.CHIEU = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal((System.Convert.ToInt32(TGChieu[0]) + (System.Convert.ToInt32(TGChieu[1]) / 60.0))), 2).ToString();
                                }
                            }
                            bool bflag = DAChamCongAuto.Instance.MergeDataSet(forDBChamCongAuto, phieu);

                            #region Cập nhật tình trạng chấm công tự động
                            if (bFlag)
                            {
                                DOTimeInOut doPhieu = DATimeInOut.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                doPhieu.IS_CHAM_CONG = "Y";
                                bFlag = DATimeInOut.Instance.MergeDataSet(forDBTime, doPhieu);
                            }
                            #endregion
                        }
                    }
                    DatabaseFB db = DABase.getDatabase();
                    DbTransaction trans = db.BeginTransaction(db.OpenConnection());
                    try
                    {
                        bFlag = db.UpdateDataSet(forDBChamCongAuto, trans);
                        bFlag = db.UpdateDataSet(forDBTime, trans);
                        trans.Commit();
                    }
                    catch (Exception err)
                    {
                        PLException.AddException(err);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                    Fix.PLRefresh();
                }
            }
        }
        //Chỉ chuyển dữ liệu xin phép
        private void MoveNghiPhep(List<object> ids)
        {
            bool bFlag = true;
            if (ids != null)
            {
                try
                {
                    DataSet forDBTime = DABase.getDatabase().LoadTable(DATimeInOut.TABLE_MAP);
                    DataSet forDBChamCongAuto = DABase.getDatabase().LoadTable(DAChamCongAuto.TABLE_MAP);

                    Application.DoEvents();
                    FrameworkParams.wait = new WaitingMsg();
                    foreach (DataRow row in ((DataView)gridViewMaster.DataSource).Table.Rows)
                    {
                        bool IsChamCong = (row["IS_CHAM_CONG"].ToString() != "Y");
                        if ((HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep && IsChamCong))
                        {
                            long NV_ID = HelpNumber.ParseInt64(row["NV_ID"]);
                            DOChamCongAuto phieu = DAChamCongAuto.Instance.LoadAll(NV_ID, (DateTime)row["NGAY_LAM_VIEC"]);
                            if (phieu.DetailDataSet.Tables[0].Select("NV_ID=" + NV_ID + " and NGAY='" + System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]) + "'").Length == 0)
                            {
                                phieu.NV_ID = NV_ID;
                                phieu.NGAY = System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]);
                            }
                            if (row["THOI_GIAN_SANG"] != null && row["THOI_GIAN_SANG"].ToString() != string.Empty) phieu.SANG = row["THOI_GIAN_SANG"].ToString();
                            if (row["THOI_GIAN_CHIEU"] != null && row["THOI_GIAN_CHIEU"].ToString() != string.Empty) phieu.CHIEU = row["THOI_GIAN_CHIEU"].ToString();
                            bool bflag = DAChamCongAuto.Instance.MergeDataSet(forDBChamCongAuto, phieu);

                            #region Cập nhật tình trạng chấm công tự động
                            if (bFlag)
                            {
                                DOTimeInOut doPhieu = DATimeInOut.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                doPhieu.IS_CHAM_CONG = "Y";
                                bFlag = DATimeInOut.Instance.MergeDataSet(forDBTime, doPhieu);
                            }
                            #endregion
                        }
                    }
                    DatabaseFB db = DABase.getDatabase();
                    DbTransaction trans = db.BeginTransaction(db.OpenConnection());
                    try
                    {
                        bFlag = db.UpdateDataSet(forDBChamCongAuto, trans);
                        bFlag = db.UpdateDataSet(forDBTime, trans);
                        trans.Commit();
                    }
                    catch (Exception err)
                    {
                        PLException.AddException(err);
                        trans.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                    Fix.PLRefresh();
                }
            }
        }

        /// <summary>Lấy tình trạng chọn xem những người đã chấm công, chưa chấm công
        /// ....
        /// </summary>
        public string[] getISChamCong()
        {
            if ((chkDaChamCong.Checked && chkChuaChamCong.Checked)
                || (chkChuaChamCong.Checked == false && chkDaChamCong.Checked == false))
                return new string[] { "'Y'", "'N'", "''" };
            if (chkDaChamCong.Checked)
                return new string[] { "'Y'" };
            else
                return new string[] { "'N'" };
        }
        public void ShowFooter()
        {
            gridViewMaster.OptionsView.ShowFooter = true;
            CotTG_LV.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "Thời gian: {0:#.###}(giờ)");
            HelpGridExt.SetFontFooter(gridViewMaster, new string[] { "THOI_GIAN_LAM_VIEC" }, Color.Blue, Color.Empty, FontStyle.Regular);
        }
        /// <summary>
        ///CHAUTV : Phân quyền xem dữ liệu
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="featureName"></param>
        private void ApplyPermissionData(PLDMGrid Input, string featureName)
        {
            List<Feature> features = Permission.loadAllFeatureByUser(FrameworkParams.currentUser.username);
            bool IsFull = false;
            foreach (Feature f in features)
            {
                if ((f.featureName == featureName && f.isRead == true) || FrameworkParams.currentUser.username.Equals("admin"))
                {
                    IsFull = true;
                    break;
                }
            }
            if (FrameworkParams.isPermision.getPublicForm().Contains(typeof(frmTimeInOutQL).FullName) == false && !IsFull)
            {
                Input._setSelectedID(FrameworkParams.currentUser.employee_id);
                Input.Enabled = false;
            }
        }
        #endregion

        #region IDuyetSupport Members

        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.Duyet))
            {
                barButtonItemDuyet.Enabled = false;
                barButtonItemK_Duyet.Enabled = true;
                return true;
            }
            return false;
        }

        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.KhongDuyet))
            {
                barButtonItemDuyet.Enabled = true;
                barButtonItemK_Duyet.Enabled = false;
                return true;
            }
            return false;
        }

        #endregion
    }
}