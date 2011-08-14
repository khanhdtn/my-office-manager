using System;
using System.Data;
using DevExpress.XtraScheduler;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors;
using DAO;
using ProtocolVN.DanhMuc;
using ProtocolVN.Plugin.TimeSheet;
using ProtocolVN.App.Office;


namespace office
{
    public partial class frmLichlamviec : XtraFormPL,IFormRefresh
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.OK_TEST;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmLichlamviec).FullName,
                PMSupport.UpdateTitle("Lịch làm việc cá nhân", Status),
                ParentID, true,
                typeof(frmLichlamviec).FullName,
                true, IsSep, "mnbLichLamViec.png", true, "", "");
        }
        #endregion
        
        #region Hàm dựng
        DateTime ngayBD;
        DateTime ngayKT;
        DataTable dtLichLamViec = new DataTable();
        DateTime date;
        bool refresh = false;
        public frmLichlamviec()
        {
            InitializeComponent();
            InitGrid();
        }
        #endregion

        #region InitForm
        private void frmPersonEventLog_Load(object sender, EventArgs e)
        {
            PMSupport.SetTitle(this, Status);
            this.schedulerControl1.Start = HelpDB.getDatabase().GetSystemCurrentDateTime().Date;
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            PLTimeSheetUtil.PermissionForControl(NhanVien, NhanVien.Visible == true, NhanVien.Visible == true);
            this.gridViewCongViec.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewCongViec.OptionsSelection.EnableAppearanceFocusedRow = true;
            this.gridViewCongViec.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewCongViec.OptionsBehavior.Editable = false;
             date = Ngaythuchien.SelectionStart;
            LoadSchedulerControl();
            NhanVien.popupContainerEdit1.CloseUp += delegate(object dmGrid, DevExpress.XtraEditors.Controls.CloseUpEventArgs closeUp)
            {
                refresh = true;
                LoadSchedulerControl();
            };
            schedulerControl1.VisibleIntervalChanged += new EventHandler(schedulerControl1_VisibleIntervalChanged);
            gridViewCongViec.BestFitColumns();
            CotTenCongViec.MinWidth = 200;
        }       
            
        #endregion
        #region  InitGridViewCongViec + NhatKy
        private void InitGrid()
        {
            HelpGridColumn.CotTextRight(CotPhanTramThamGia, "PHAN_TRAM_THAM_GIA_PT");
            HelpGridColumn.CotTextLeft(CotTenCongViec, "TEN_CV");
            HelpGridColumn.CotTextLeft(CotDoUuTien, "DO_UU_TIEN");
            HelpGridColumn.CotTextCenter(CotNgaybatdau, "NGAY_BAT_DAU");
            HelpGridColumn.CotTextCenter(CotNgayketthuc, "NGAY_KET_THUC_DU_KIEN");
            HelpGridColumn.CotTextRight(CotTiendo, "TIEN_DO_PT");
            HelpGridColumn.CotReadOnlyDate(CotThoiGianCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            this.gridViewCongViec.OptionsBehavior.Editable = false;
            gridViewCongViec.BestFitColumns();
            gridViewCongViec.OptionsBehavior.AutoExpandAllGroups = true;

            gridViewNhatKy.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewNhatKy.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewNhatKy.OptionsBehavior.Editable = false;
            HelpGridColumn.CotPLTimeEdit(cotNKNgayLamVec, "NGAY_LAM_VIEC", PLConst.FORMAT_DATE_STRING);
            HelpGridColumn.CotPLTimeEdit(cotNKThoiGianThucHien, "THOI_GIAN_THUC_HIEN", PLConst.FORMAT_TIME_HH_MM);
            HelpGridColumn.CotTextLeft(cotNKCongViec, "MO_TA");
        }
        #endregion
        #region Invalidate

        private void InitSchedulerStorage(SchedulerStorage storage, object appointmentsDataSource)
        {                     
            storage.Appointments.Labels.Clear();
            storage.Appointments.Labels.Add(System.Drawing.Color.Empty, string.Empty);
            storage.Appointments.Labels.Add(System.Drawing.Color.Red, "Cao nhất");
            storage.Appointments.Labels.Add(System.Drawing.Color.Orange, "Cao");
            storage.Appointments.Labels.Add(System.Drawing.Color.Cyan, "Trung bình");
            storage.Appointments.Labels.Add(System.Drawing.Color.YellowGreen, "Thấp nhất");
            storage.Appointments.Labels.Add(System.Drawing.Color.Yellow, "Thấp");
            storage.Appointments.Mappings.Label = "MUC_UU_TIEN";
            storage.Appointments.Mappings.Status = "TINH_TRANG";
            storage.Appointments.Mappings.Start = "NGAY_BAT_DAU";
            storage.Appointments.Mappings.End = "NGAY_KET_THUC_DU_KIEN";
            storage.Appointments.Mappings.Description = "MO_TA";
            storage.Appointments.Mappings.Subject = "TIEN_DO";
            schedulerControl1.OptionsCustomization.AllowAppointmentEdit = UsedAppointmentType.All;
            schedulerControl1.OptionsCustomization.AllowInplaceEditor = UsedAppointmentType.None;
            schedulerControl1.DayView.AppointmentDisplayOptions.AppointmentHeight = 40;
            schedulerControl1.WeekView.AppointmentDisplayOptions.AppointmentHeight = 40;
            schedulerControl1.MonthView.AppointmentDisplayOptions.AppointmentHeight = 40;
        }

        private void schedulerControl1_PreparePopupMenu(object sender, PreparePopupMenuEventArgs e)
        {
            e.Menu = null;
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            Appointment apt = e.Appointment;
            try
            {
                if (apt.GetValue(this.schedulerStorage1, "PCCV_ID").ToString() != null )
                {
                    string a = apt.GetValue(this.schedulerStorage1, "TINH_TRANG").ToString();
                    if (apt.GetValue(this.schedulerStorage1, "TINH_TRANG").ToString() != "4")
                    {
                        //Nếu nhân viên đang đăng nhập không phải là nhân viên thực hiện công việc thì 
                        //không cho phép cập nhật tiến độ công việc.
                        //if (HelpNumber.ParseInt64(apt.GetValue(this.schedulerStorage1, "MA_NV")) != FrameworkParams.currentUser.employee_id)
                        //{
                        //    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền cập nhật tiến độ cho công việc này!");
                        //    e.Handled = true;
                        //    return;
                        //}
                        frmCapNhatTienDo frm = new frmCapNhatTienDo(HelpNumber.ParseInt64(apt.GetValue(this.schedulerStorage1, "PCCV_ID")));
                        HelpProtocolForm.ShowModalDialog(this, frm);
                        refresh = true;
                        LoadSchedulerControl();
                        e.DialogResult = frm.DialogResult;
                        e.Handled = true;
                    }
                    else
                    {
                        HelpMsgBox.ShowNotificationMessage("Công việc đã hoàn tất.\n Bạn không được cập nhật tiến độ cho công việc này!");
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex) { e.Handled = true; return; }
        }

        private void Ngay_CheckedChanged(object sender, EventArgs e)
        {
            if (Ngay.Checked)
            {
                this.schedulerControl1.ActiveViewType = SchedulerViewType.Day;
                this.schedulerControl1.DayView.TopRowTime = TimeSpan.FromHours(8);
                this.schedulerControl1.DayView.LayoutChanged();
            }                
        }
        private void Tuan_CheckedChanged(object sender, EventArgs e)
        {
            if (Tuan.Checked)
            {
                this.schedulerControl1.ActiveViewType = SchedulerViewType.Week;
            }
        }

        private void Thang_CheckedChanged(object sender, EventArgs e)
        {
            if (Thang.Checked)
            {
                this.schedulerControl1.ActiveViewType = SchedulerViewType.Month;
            }
        }

        private void LoadSchedulerControl()
        {
            QueryBuilder query = new QueryBuilder(@"SELECT PC.PCCV_ID,PC.TINH_TRANG,CT.MA_NV,NV.NAME,LCV.ID AS ID_LCV,LCV.NAME AS TEN_LCV,
                                PC.CONG_VIEC TEN_CV,PC.MUC_UU_TIEN,PC.TINH_TRANG,
                                PC.NGAY_BAT_DAU,PC.NGAY_KET_THUC_DU_KIEN,'Công việc: ' || PC.CONG_VIEC || '
Tiến độ: ' || CT.TIEN_DO ||'%' AS TIEN_DO
                                FROM  (PHAN_CONG_CONG_VIEC PC INNER JOIN
                                (CHI_TIET_PHAN_CONG CT INNER JOIN DM_NHAN_VIEN NV ON CT.MA_NV=NV.ID)  ON CT.PCCV_ID=PC.PCCV_ID) INNER JOIN
                                DM_LOAI_CONG_VIECN LCV ON PC.LCV_ID = LCV.ID
                                WHERE CT.thoi_gian_cap_nhat = (SELECT max(ctpc.thoi_gian_cap_nhat)
                                FROM CHI_TIET_PHAN_CONG CTPC
                                WHERE CTPC.PCCV_ID = PC.PCCV_ID AND NV.ID = CTPC.MA_NV
                                GROUP BY CTPC.PCCV_ID) and 1=1");
            query.addID("CT.MA_NV", NhanVien._getSelectedID());
            DataTable dtTemp = new DataTable();
            if (refresh)
            {
                query.addDateFromTo("NGAY_BAT_DAU", ngayBD, ngayKT);
                dtLichLamViec = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
                refresh = false;
            }
            else
            {
                if (ngayBD.Year == 1 && ngayKT.Year == 1)
                {
                    if (date.Month == 1)
                    {
                        ngayBD = HelpDate.GetStartOfMonth(12, date.Year - 1);
                        ngayKT = HelpDate.GetEndOfMonth(date.Month + 1, date.Year);
                    }
                    else if (date.Month == 12)
                    {
                        ngayBD = HelpDate.GetStartOfMonth(date.Month - 1, date.Year);
                        ngayKT = HelpDate.GetEndOfMonth(1, date.Year + 1);
                    }
                    else
                    {
                        ngayBD = HelpDate.GetStartOfMonth(date.Month - 1, date.Year);
                        ngayKT = HelpDate.GetEndOfMonth(date.Month + 1, date.Year);
                    }
                    query.addDateFromTo("NGAY_BAT_DAU", ngayBD, ngayKT);
                    dtLichLamViec = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
                }
                else
                {
                    if (Ngaythuchien.SelectionStart < ngayBD)
                    {
                        query.addDateFromTo("NGAY_BAT_DAU", Ngaythuchien.SelectionStart, ngayBD);
                        dtTemp = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
                        ngayBD = Ngaythuchien.SelectionStart;
                    }
                    else if (Ngaythuchien.SelectionEnd > ngayKT)
                    {
                        query.addDateFromTo("NGAY_BAT_DAU", ngayKT, Ngaythuchien.SelectionEnd);
                        dtTemp = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
                        ngayKT = Ngaythuchien.SelectionEnd;
                    }
                }
                if (dtTemp.Rows.Count > 0)
                {
                    dtLichLamViec.Merge(dtTemp);
                }
                
            }
            if (dtLichLamViec.Rows.Count > 0)
            {
                schedulerControl1.Storage.Appointments.DataSource = dtLichLamViec;
                InitSchedulerStorage(schedulerStorage1, dtLichLamViec);
            }
            else
            {
                schedulerControl1.Storage.Appointments.DataSource = null;
                InitSchedulerStorage(schedulerStorage1, null);
            }         
            InitData();
            TabChange();
        }       

        void schedulerControl1_VisibleIntervalChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.Controls.DatesCollection col = Ngaythuchien.Selection;
            if (col.Count == 1) Ngay.Checked = true;
            if (col.Count == 7) Tuan.Checked = true;
            if (col.Count > 7) Thang.Checked = true;
            LoadSchedulerControl();
        }        
        private void InitData()
        {
            string query = @"SELECT PC.PCCV_ID,CT.MA_NV,NV.NAME,LCV.ID, LCV.NAME TEN_LCV,PC.CONG_VIEC AS TEN_CV,PC.MO_TA,
                            TT.NAME TINH_TRANG,PC.NGAY_BAT_DAU,PC.NGAY_KET_THUC_DU_KIEN,
                            CT.TIEN_DO,CT.TIEN_DO||'%' TIEN_DO_PT,CT.PHAN_TRAM_THAM_GIA,CT.PHAN_TRAM_THAM_GIA ||'%' PHAN_TRAM_THAM_GIA_PT,
                            CT.THOI_GIAN_CAP_NHAT,
                            (CASE PC.MUC_UU_TIEN WHEN 1 THEN 'Cao nhất' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 2 THEN 'Cao' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 3 THEN 'Trung bình' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 4 THEN 'Thấp' ELSE(
                                   CASE PC.MUC_UU_TIEN WHEN 5 THEN 'Thấp nhất' ELSE NULL END) END ) END ) END) END) DO_UU_TIEN
                            ,(SELECT N.NAME FROM DM_NHAN_VIEN N WHERE PC.NGUOI_GIAO=N.ID) NGUOI_GIAO
                            FROM(PHAN_CONG_CONG_VIEC PC INNER JOIN DM_TINH_TRANG TT ON PC.TINH_TRANG=TT.ID INNER JOIN
                            (CHI_TIET_PHAN_CONG CT INNER JOIN DM_NHAN_VIEN NV ON CT.MA_NV=NV.ID) ON CT.PCCV_ID=PC.PCCV_ID) INNER JOIN
                            DM_LOAI_CONG_VIECN LCV ON PC.LCV_ID = LCV.ID
                            WHERE CT.THOI_GIAN_CAP_NHAT = (SELECT MAX(CTPC.THOI_GIAN_CAP_NHAT)
                                    FROM CHI_TIET_PHAN_CONG CTPC
                                    WHERE CTPC.PCCV_ID = PC.PCCV_ID AND NV.ID = CTPC.MA_NV 
                                    GROUP BY CTPC.PCCV_ID) AND 1=1  
                            AND CT.MA_NV=" + NhanVien._getSelectedID() +
                           " AND (cast(PC.NGAY_BAT_DAU as date)>='" + Ngaythuchien.SelectionStart.ToString("MM/dd/yyyy") + "' AND cast(PC.NGAY_BAT_DAU as date)<='" + Ngaythuchien.SelectionEnd.ToString("MM/dd/yyyy") +
                           "' or cast(PC.NGAY_BAT_DAU as date) <='" + Ngaythuchien.SelectionStart.ToString("MM/dd/yyyy") + "' and cast(PC.NGAY_KET_THUC_DU_KIEN as date)> '" + Ngaythuchien.SelectionStart.ToString("MM/dd/yyyy") +
                                       "' )order by CT.THOI_GIAN_CAP_NHAT desc ";
         
            DataTable dt = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
            this.gridControlCongViec.DataSource = dt;
        }
        
        #endregion       
        public object _RefreshAction(params object[] input)
        {
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);            
            return null;
        }
        
        private void xtraTabControlCongViec_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControlCongViec.SelectedTabPageIndex == 1)
            {
                TabChange();
            }
        }

        private void TabChange()
        {            
            string query = string.Format(@"select ctcv.ngay_lam_viec,ctcv.thoi_gian_thuc_hien,ctcv.mo_ta
                                                from chi_tiet_cong_viec ctcv
                                                WHERE ctcv.nv_id={0} and
                                                ctcv.ngay_lam_viec between '{1}' and '{2}'", NhanVien._getSelectedID(),
                                           Ngaythuchien.SelectionStart.ToString("MM/dd/yyyy"),
                                           Ngaythuchien.SelectionEnd.ToString("MM/dd/yyyy"));
            DataTable dt = HelpDB.getDatabase().LoadDataSet(query).Tables[0];

            this.gridControlNhatKy.DataSource = dt;
        }

        private void gridControlCongViec_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridViewCongViec.GetDataRow(gridViewCongViec.FocusedRowHandle);
            if (row == null) return;
            Congviec obj = new Congviec(HelpNumber.ParseInt64(row["PCCV_ID"].ToString()), null);
            HelpProtocolForm.ShowModalDialog(this, obj);
        }
    }
}
