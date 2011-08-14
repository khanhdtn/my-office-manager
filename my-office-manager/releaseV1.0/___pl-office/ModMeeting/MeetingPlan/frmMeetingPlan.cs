using System;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using ProtocolVN.DanhMuc;
using System.Drawing;
using System.Collections.Generic;
using DTO;
using System.Data;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraReports.Import.Interop.Access;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
namespace office
{
    public partial class frmMeetingPlan : PhieuPopupBase, IPhieuPopup<DOMeeting>
    {
        #region Vùng đặt Static MenuItem
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmMeetingPlan).FullName,
                PMSupport.UpdateTitle("Tạo mới", Status),
                ParentID, true,
                typeof(frmMeetingPlan).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến  
        private DOMeeting doMeeting = null;
        private List<DOLuuTruTapTin> _listDOTapTin = new List<DOLuuTruTapTin>();
        private List<long> _idTapTinDangXoa = new List<long>();       
        #endregion        

        #region Hàm dựng 
        PhieuPopupFix thatPopup;
        public frmMeetingPlan(long ID,bool?IsAdd)
        {
            InitializeComponent();
            thatPopup = new PhieuPopupFix(this,ID,IsAdd);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmMeetingPlan_FormClosed);
        }
        
        public frmMeetingPlan() : this(-2, true) { }

        private void frmMeetingPlan_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            btnThemVanBan.Visible = this.IsAdd != null;
            btnLuu.Visible = this.IsAdd != null;
        }
       
        #endregion

        public override void InitDataControls()
        {
            HelpXtraForm.SetCloseForm(this, btnClose, this.IsAdd);
            DMNhanVienX.I.ChonNhanVienLamViec(PLNguoiToChuc, this.IsAdd);
            DMTinhChatMeeting.I.InitCtrl(PLTinhChat, base.IsAdd, true);
            DMLoaiMeeting.I.InitCtrl(PLLoaiCuocHop, base.IsAdd, true);
            PLNguoiToChuc.ToolTip = PLLoaiCuocHop.ToolTip = PLTinhChat.ToolTip = string.Empty;
            Duyet._init(true);
            this.SetMaxLength();
        }

        public override void InitGridColumns()
        {
            XtraGridSupportExt.TextLeftColumn(cot_xoa, "mo_file");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "xoa_file");
            XtraGridSupportExt.TextLeftColumn(cot_suafile, "sua_file");            
            lVVanBan.OptionsCustomization.AllowSort = false;
            lVVanBan.OptionsCustomization.AllowFilter = false;           
        }       
        public override bool IsValidate()
        {
            errorProvider.ClearErrors();
            bool TGBD, TGKT;
            TGBD = TGKT = true;
            if (ThoiGianBatDau.Time.TimeOfDay == new TimeSpan(0, 0, 0))
            {
                errorProvider.SetError(ThoiGianBatDau, "Vui lòng chọn \"Thời gian bắt đầu\"!");
                TGBD = false;
            }
            if (ThoiGianKetThuc.Time.TimeOfDay == new TimeSpan(0, 0, 0))
            {
                errorProvider.SetError(ThoiGianKetThuc, "Vui lòng chọn \"Thời gian kết thúc\"!");
                TGKT = false;
            }
            if (ThoiGianKetThuc.Time.TimeOfDay <= ThoiGianBatDau.Time.TimeOfDay)
            {
                errorProvider.SetError(ThoiGianKetThuc, "\"Thời gian kết thúc\" phải lớn hơn \"Thời gian bắt đầu\"!");
                TGKT = false;
            }  
            return GUIValidation.ShowRequiredError(this.errorProvider,
                new object[]{
                    memoNoiDung,"Nội dung", 
                    NgayKH,"Ngày",
                    PLNguoiToChuc,"Người tổ chức",
                    memoDiaDiem,"Địa điểm",
                    PLTinhChat,"Tính chất",
                    PLLoaiCuocHop,"Loại cuộc họp",
                }) && TGBD && TGKT;
        }

        public override bool InitDOData()
        {
            bool flag = true;
            try
            {                
                    doMeeting = this.getObject();                    
                    if (this.IsAdd == true) {
                        NgayKH.DateTime = DateTime.Today;
                        return true;
                    }
                    //memoNoiDung.Text = doMeeting.NOI_DUNG;
                    ThoiGianBatDau.EditValue = doMeeting.GIO_BAT_DAU;
                    ThoiGianKetThuc.EditValue = doMeeting.GIO_KET_THUC;
                    NgayKH.DateTime = doMeeting.NGAY;
                    memoDiaDiem.Text = doMeeting.DIA_DIEM;
                    PLNguoiToChuc._setSelectedID(doMeeting.NGUOI_TO_CHUC_ID);
                    //PLTinhChat._setSelectedID(doMeeting.TC_MEETING_ID);
                    //PLLoaiCuocHop._setSelectedID(doMeeting.LOAI_MEETING_ID);
                    Duyet.SetDuyet(doMeeting);
                    gridControlVanBan.DataSource= DAMeeting.Instance.LoadTapTin(doMeeting.ID, _idTapTinDangXoa, imageList_layout, _listDOTapTin).Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Khởi tạo đối tượng \"DOMeeting\"!");
                flag = false;
            }
            return flag;
        }

        #region IPhieuPopup<DOMeeting> Members

        public DOMeeting getObject()
        {
            if (this.IsAdd == true){
                doMeeting = DAMeeting.Instance.LoadAll(-2);
                doMeeting.ID = HelpDB.getDatabase().GetID(PLConst.G_NGHIEP_VU);
                return doMeeting;
            }                
            else {
                return DAMeeting.Instance.LoadAll(HelpNumber.ParseInt64(this.ID));
            }
        }

        public DOMeeting getDataOjbect()
        {
            if (doMeeting != null)
            {
                //doMeeting.NOI_DUNG = memoNoiDung.Text;
                doMeeting.GIO_BAT_DAU = new DateTime(NgayKH.DateTime.Year, NgayKH.DateTime.Month, NgayKH.DateTime.Day, ThoiGianBatDau.Time.Hour, ThoiGianBatDau.Time.Minute, ThoiGianBatDau.Time.Second);
                doMeeting.GIO_KET_THUC = new DateTime(NgayKH.DateTime.Year, NgayKH.DateTime.Month, NgayKH.DateTime.Day, ThoiGianKetThuc.Time.Hour, ThoiGianKetThuc.Time.Minute, ThoiGianKetThuc.Time.Second);
                doMeeting.NGAY = (DateTime)HelpDate.GetDateEdit(NgayKH);
                doMeeting.DIA_DIEM = memoDiaDiem.Text;
                doMeeting.NGUOI_TO_CHUC_ID = PLNguoiToChuc._getSelectedID();
                //doMeeting.TC_MEETING_ID = PLTinhChat._getSelectedID();
                //doMeeting.LOAI_MEETING_ID = PLLoaiCuocHop._getSelectedID();
                doMeeting.KET_QUA = string.Empty;
                doMeeting.NGUOI_CAP_NHAT_ID = FrameworkParams.currentUser.employee_id;
                doMeeting.NGAY_CAP_NHAT = HelpDB.getDatabase().GetSystemCurrentDateTime();
            }
            return doMeeting;
        }

        #endregion

        #region Su kien
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (this.IsValidate())
            {
                this.getDataOjbect();                
                try
                {

                    if (!DAMeeting.Instance.Update(doMeeting))
                        ErrorMsg.ErrorSave("");
                    else
                    {
                        foreach (DOLuuTruTapTin do_tt in _listDOTapTin)
                        {
                            DAMeeting.Luu_VanBanMeeting(doMeeting.ID, do_tt.ID);
                        }
                        _listDOTapTin.Clear();
                        foreach (long id_tailieu in _idTapTinDangXoa)
                        {
                            DAMeeting.Xoa_VanbanMeeting(id_tailieu);
                            DALuuTruTapTin.Instance.Delete(id_tailieu);

                        }                                            
                        PLGUIUtil.ClosePhieu(this, true);
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                    HelpSysLog.AddException(ex, "Lưu dữ liệu MeetingPlan");
                }
            }
        }
        private void btnThemVanBan_Click(object sender, EventArgs e)
        {
            frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, doMeeting.ID, (long)LoaiTapTin.TapTinCuocHop);
            //frm.UpdateTapTin_DuAn += new frmThemTaiLieu.UpdateTapTinHandler(frm_InsertVanBan);
            ProtocolForm.ShowModalDialog(this, frm);
            gridControlVanBan.DataSource= DAMeeting.Instance.LoadTapTin(doMeeting.ID,_idTapTinDangXoa, imageList_layout, _listDOTapTin).Tables[0];
        }
        /// <summary>
        /// Sự kiện khi nhấn "Mở văn bản" trên LayoutView lVVanBan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow r = lVVanBan.GetDataRow(lVVanBan.FocusedRowHandle);
            try
            {
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(r["ID"]));
                DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Mở văn bản MeetingPlan.");
            }
        }
        /// <summary>
        /// Sự kiện khi nhấn "Lưu văn bản" trên LayoutView lVVanBan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_luufile_Click(object sender, EventArgs e)
        {
            DataRow r = lVVanBan.GetDataRow(lVVanBan.FocusedRowHandle);
            try
            {
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(r["ID"]));
                DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Lưu văn bản MeetingPlan.");
            }
        }
        /// <summary>
        /// Sự kiện khi nhấn "Xóa văn bản" trên LayoutView lVVanBan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_xoa_Click(object sender, EventArgs e)
        {
            if (this.IsAdd != null)
            {
                DataRow r = lVVanBan.GetDataRow(lVVanBan.FocusedRowHandle);
                if (r != null)
                {
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn xóa văn bản \"" + r["TEN_FILE"].ToString() + "\" này không?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                            DALuuTruTapTin.Instance.Delete(id_taptin);
                            foreach (DOLuuTruTapTin do_tt in _listDOTapTin)
                            {
                                if (do_tt.ID == id_taptin)
                                {
                                    _listDOTapTin.Remove(do_tt);
                                    break;
                                }
                            }
                            _idTapTinDangXoa.Add(id_taptin);
                            lVVanBan.DeleteSelectedRows();
                        }
                        catch (Exception ex)
                        {
                            PLException.AddException(ex);
                            HelpSysLog.AddException(ex, "Xoá văn bản MeetingPlan.");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Sự kiện khi nhấn "Sửa văn bản" trên LayoutView lVVanBan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_sua_Click(object sender, EventArgs e)
        {
            if (this.IsAdd != null)
            {
                DataRow r = lVVanBan.GetDataRow(lVVanBan.FocusedRowHandle);
                if (r != null)
                {
                    frmThemTaiLieu frm = new frmThemTaiLieu(HelpNumber.ParseInt64(r["ID"]), false, doMeeting.ID, (long)LoaiTapTin.TapTinCuocHop);
                    try
                    {
                        //frm.UpdateTapTin_DuAn += new frmThemTaiLieu.UpdateTapTinHandler(frm_UpdateVanBan);
                        ProtocolForm.ShowModalDialog(this, frm);
                        gridControlVanBan.DataSource = DAMeeting.Instance.LoadTapTin(doMeeting.ID, _idTapTinDangXoa, imageList_layout, _listDOTapTin).Tables[0];
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                        HelpSysLog.AddException(ex, "Sửa văn bản MeetingPlan!");
                    }
                }
            }
        }
        void frmMeetingPlan_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            try
            {
                foreach (DOLuuTruTapTin do_tt in _listDOTapTin)
                    DALuuTruTapTin.Instance.Delete(do_tt.ID);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Đóng frmMeetingPlan.");
            }
        }
        #endregion

        #region Mo rong
        private void SetMaxLength()
        {
            GUIValidation.SetMaxLength(new object[]{
                memoDiaDiem , 2000 ,
                memoNoiDung, 2000
            });
        }
        public void frm_InsertVanBan(object sender, DOLuuTruTapTin doLuuTruTapTin)
        {
            _listDOTapTin.Add(doLuuTruTapTin);
        }
        #endregion
        
        /// <summary>
        /// Delegate gọi sau khi sửa 1 văn bản mới thêm vào
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="doLuuTruTapTin"></param>
        public void frm_UpdateVanBan(object sender, DOLuuTruTapTin doLuuTruTapTin)
        {            
            foreach (DOLuuTruTapTin do_lttt in _listDOTapTin)
            {
                if (do_lttt.ID == doLuuTruTapTin.ID)
                {
                    do_lttt.TIEU_DE = doLuuTruTapTin.TIEU_DE;
                    do_lttt.NOI_DUNG = doLuuTruTapTin.NOI_DUNG;
                    do_lttt.GHI_CHU = doLuuTruTapTin.GHI_CHU;
                    do_lttt.TEN_FILE = doLuuTruTapTin.TEN_FILE;
                }
            }
        }                   
    }
}