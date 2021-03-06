using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraScheduler;
using System;
using ProtocolVN.DanhMuc;
using DAO;
using System.Drawing;
using DTO;
namespace office
{
    public partial class frmMeetingQL : PhieuQLCustomChange//, IDuyetSupport
    {
    //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
    //public partial class frmMeetingQL : XtraFormPL
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
    //    protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
    //    protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
    //    protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
    //    protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
    //    protected DevExpress.XtraGrid.GridControl gridControlMaster;
    //    protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
    //    protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
    //    protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
    //    protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
    //    protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
    //    protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    //    protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    //    protected DevExpress.XtraBars.BarButtonItem barButtonItemTaoPhieuMuaHang;
    //    private System.ComponentModel.IContainer components;
    //    private DevExpress.XtraBars.BarSubItem barSubItem1;
    //    private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
    //    protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
    //    private DevExpress.XtraBars.PopupMenu popupMenuFilter;
    //    protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
    //    private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
    //    private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    //    private DevExpress.XtraBars.PopupMenu popupMenu1;
    //    private DevExpress.XtraBars.BarButtonItem barButtonItem4;
    //#endregion

         #region Các hàm khởi tạo
         public static FormStatus Status = FormStatus.OK_TEST;
         public static string MenuItem(string ParentID, bool IsSep)
         {
             return MenuBuilder.CreateItem(typeof(frmMeetingQL).FullName,
                 "Cuộc họp",
                 ParentID, true,
                 typeof(frmMeetingQL).FullName,
                 true, IsSep, "mnbQTriNguoiDung.png", true, "", "");
         }
         PhieuQLCustomChangeFix that;
         DateTime ngayBD;
         DateTime ngayKT; 
         DataTable dtMeeting = new DataTable();
         DateTime date ;
         bool refresh = false;
         public frmMeetingQL()
         {
             InitializeComponent();
             that = new PhieuQLCustomChangeFix(this);
             DMNhanVienX.I.ChonNhanVienLamViec(cboNguoiToChuc,true,true);
             DMTinhChatMeeting.I.InitCtrl(cboTinhChat, true, true);
             DMLoaiMeeting.I.InitCtrl(cboLoai,true, true);
             this.barButtonItemXem.Enabled = false;
             schedulerControl.SelectedAppointments.CollectionChanged += new DevExpress.Utils.CollectionChangedEventHandler<Appointment>(SelectedAppointments_CollectionChanged);
             schedulerControl.PreparePopupMenu +=new PreparePopupMenuEventHandler(schedulerControl_PreparePopupMenu);
         }

         private void InitSchedulerStorage(SchedulerStorage storage, object appointmentsDataSource)
         {
             storage.Appointments.Labels.Clear();
             storage.Appointments.Labels.Add(System.Drawing.Color.LightBlue, "Sáng");
             storage.Appointments.Labels.Add(System.Drawing.Color.Orange, "Chiều");
             schedulerControl.Storage.Appointments.DataSource = appointmentsDataSource;
             storage.Appointments.Mappings.Label = "THOI_GIAN";
             storage.Appointments.Mappings.Subject = "CUOC_HOP";
             storage.Appointments.Mappings.Start = "GIO_BAT_DAU";
             storage.Appointments.Mappings.End = "GIO_KET_THUC";
         }

         void frmMeetingQL_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
         {
             try 
             {
                 System.Windows.Forms.Application.DoEvents();
             }
             catch {}
         }

         private void frmMeetingQL_Load(object sender, EventArgs e)
         {             
             schedulerControl.Start = HelpDB.getDatabase().GetSystemCurrentDateTime().Date;
             splitContainerControl1.Collapsed = true;
             splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;
             Tuan.Checked = true;
             this.barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
             date = Ngaythuchien.SelectionStart;
             schedulerControl.VisibleIntervalChanged += new EventHandler(schedulerControl_VisibleIntervalChanged);             
             Find(PLBuildQueryFilter());
         }

         #endregion                                         
          
         #region 1.Khởi tạo cho phần Detail
         #endregion

         #region 2.Khởi tạo phần master
         private void InitState(bool State)
         {
             barButtonItemXem.Enabled = State;
             barButtonItemUpdate.Enabled = State;
             barButtonItemDelete.Enabled = State;
             barButtonItemPrint.Enabled = State;
             barSubItem1.Enabled = State;
         }
        
         #endregion

         #region 3.Dựng câu truy vấn tìm
         public override QueryBuilder PLBuildQueryFilter()
         {
             QueryBuilder query = new QueryBuilder(@"SELECT ID,GIO_BAT_DAU,GIO_KET_THUC,
'Chủ đề: ' || CHU_DE ||'.
Lúc: '
||extract(hour from GIO_BAT_DAU) || ':'
||iif((extract(minute from GIO_BAT_DAU))=0,'00',extract(minute from GIO_BAT_DAU))
|| ' ~ '||
extract(hour from GIO_KET_THUC) || ':'
||iif((extract(minute from GIO_KET_THUC))=0,'00',extract(minute from GIO_KET_THUC))
||'.
Tại: ' || DIA_DIEM ||' .' CUOC_HOP,
iif((extract(hour from GIO_BAT_DAU)<=12),'0','1') THOI_GIAN
FROM MEETING_MANAGEMENT WHERE 1=1");

             return query;
         }
         
         #endregion

         #region 4.Lấy dữ liệu cho phần details
//        
         #endregion

         #region 5.Khởi tạo phần tìm
         
         public override void PLLoadFilterPart()
         {
             HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
             popupControlContainerFilter.Visible = false;
         }
         public override void Find(QueryBuilder query)
         {
             DataTable dtTemp = new DataTable();
             if (refresh)
             {
                 query.addDateFromTo("NGAY", ngayBD, ngayKT);
                 dtMeeting = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
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
                     query.addDateFromTo("NGAY", ngayBD, ngayKT);
                     dtMeeting = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
                 }
                 else
                 {
                     if (Ngaythuchien.SelectionStart < ngayBD)
                     {
                         query.addDateFromTo("NGAY", Ngaythuchien.SelectionStart, ngayBD);
                         dtTemp = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
                         ngayBD = Ngaythuchien.SelectionStart;
                     }
                     else if (Ngaythuchien.SelectionEnd > ngayKT)
                     {
                         query.addDateFromTo("NGAY", ngayKT, Ngaythuchien.SelectionEnd);
                         dtTemp = HelpDB.getDatabase().LoadDataSet(query).Tables[0];
                         ngayKT = Ngaythuchien.SelectionEnd;
                     }
                 }
                 if (dtTemp.Rows.Count > 0)
                 {
                     dtMeeting.Merge(dtTemp);
                 }                 
             }
             if (dtMeeting.Rows.Count > 0)
             {
                 schedulerControl.Storage.Appointments.DataSource = dtMeeting;
                 InitSchedulerStorage(schedulerStorage, dtMeeting);
             }
             else
             {
                 schedulerControl.Storage.Appointments.DataSource = null;
                 InitSchedulerStorage(schedulerStorage, null);
             }
         }
        
         #endregion

         #region 6.Sự kiện

         public override long[] ShowAddForm()
         {
             frmMeeting frm = new frmMeeting();
             frm.RefreshData += new frmMeeting.UpdateDataScheduler(UpdateSchedulerControl);
             HelpProtocolForm.ShowModalDialog(this, frm);
             return null;
         }

         public override void ShowUpdateForm(long id)
         {
             frmMeeting frm = new frmMeeting(id, false);
             frm.RefreshData += new frmMeeting.UpdateDataScheduler(UpdateSchedulerControl);
             HelpProtocolForm.ShowModalDialog(this, frm);
         }

         public override void ShowViewForm(long id)
         {
             frmMeeting frm = new frmMeeting(id, null);
             HelpProtocolForm.ShowModalDialog(this, frm);
         }

         public override bool XoaAction(long id)
         {
             if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa cuộc họp này?") == System.Windows.Forms.DialogResult.Yes)
             {
                 schedulerControl.Storage.Appointments.Remove(schedulerControl.SelectedAppointments[0]);
                 return DatabaseFB.DeleteRecord("MEETING_MANAGEMENT", "ID", id);
             }
             else
                 return false;
         }
               
         private void Ngay_CheckedChanged(object sender, System.EventArgs e)
         {
             if (Ngay.Checked)
                 schedulerControl.ActiveViewType = SchedulerViewType.Day;
             schedulerControl.DayView.AppointmentDisplayOptions.AppointmentHeight = 60;
         }

         private void Tuan_CheckedChanged(object sender, System.EventArgs e)
         {
             if (Tuan.Checked)
                 schedulerControl.ActiveViewType = SchedulerViewType.Week;
             schedulerControl.WeekView.AppointmentDisplayOptions.AppointmentHeight = 60;
         }

         private void Thang_CheckedChanged(object sender, System.EventArgs e)
         {
             if (Thang.Checked)
                 schedulerControl.ActiveViewType = SchedulerViewType.Month;
             schedulerControl.MonthView.AppointmentDisplayOptions.AppointmentHeight = 60;
         }
         
         void schedulerControl_VisibleIntervalChanged(object sender, EventArgs e)
         {
             DevExpress.XtraEditors.Controls.DatesCollection col = Ngaythuchien.Selection;
             if (col.Count == 1)
             {
                 Ngay.Checked = true;
                 schedulerControl.DayView.AppointmentDisplayOptions.AppointmentHeight = 60;
             }
             if (col.Count == 7)
             {
                 Tuan.Checked = true;
                 schedulerControl.WeekView.AppointmentDisplayOptions.AppointmentHeight = 60;
             }
             if (col.Count > 7)
             {
                 Thang.Checked = true;
                 schedulerControl.MonthView.AppointmentDisplayOptions.AppointmentHeight = 60;
             }
             Find(PLBuildQueryFilter());
         }
         void SelectedAppointments_CollectionChanged(object sender, DevExpress.Utils.CollectionChangedEventArgs<Appointment> e)
         {       
             try
             {                 
                 if (schedulerControl.SelectedAppointments.Count > 0)
                 {
                     InitState(true);
                     StateSplitContainer(false);
                 }
                 else
                 {
                     InitState(false);
                     barButtonItemDuyet.Enabled = false;
                     barButtonItemK_Duyet.Enabled = false;
                     StateSplitContainer(true);
                 }
             }
             catch (Exception ex) { PLException.AddException(ex); }
         }
              
         #endregion                                                                                   

        #region Khác
         public void StateSplitContainer(bool State)
         {
             if (State)                                           
                 splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel2;                              
             else                              
                 splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.None;             
         }
         public void UpdateSchedulerControl()
         {
             refresh = true;
             Find(PLBuildQueryFilter());
         }
        #endregion


         public override long GetIDKey()
         {
             long idKey;
             try
             {
                 idKey = HelpNumber.ParseInt64(schedulerControl.SelectedAppointments[0].GetValue(schedulerStorage, "ID").ToString());
             }
             catch
             {
                 return idKey = -1;                
             }
             return idKey;
         }

         public override void InitDetail()
         {
             this.splitContainerControl1.Panel2.Visible = false;
         }

         public override void InitMaster()
         {
             InitState(false);
         }

         public override DataTable[] PLLoadDataDetailPart(long MasterID)
         {
             return new DataTable []{new DataTable()};
         }

         private void schedulerControl_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
         {
             Appointment app = e.Appointment;
             try
             {
                 if (app.GetValue(this.schedulerStorage, "ID") != null)
                 {
                     frmMeeting frm = new frmMeeting(HelpNumber.ParseInt64(app.GetValue(this.schedulerStorage, "ID")), null);
                     HelpProtocolForm.ShowModalDialog(this, frm);                     
                 }
                 e.Handled = true;
             }
             catch 
             {
                 e.Handled = true; return;
             }
         }

         private void schedulerControl_PreparePopupMenu(object sender, PreparePopupMenuEventArgs e)
         {
             e.Menu = null;
         }
    }
}