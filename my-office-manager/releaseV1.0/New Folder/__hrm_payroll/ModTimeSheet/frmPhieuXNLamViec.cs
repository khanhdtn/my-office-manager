using System;
using ProtocolVN.Framework.Win;
using DTO;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.DanhMuc;
using DAO;
using ProtocolVN.Framework.Core;
using office;
using ProtocolVN.Plugin.TimeSheet;
using System.Data;
using ProtocolVN.App.Office;
//CHAUTV: Giấy xác nhận làm việc
namespace office
{
    public partial class frmPhieuXNLamViec : XtraFormPL
    {
        #region Fields
        /// <summary>
        /// true : Thêm mới
        /// false: Sửa
        /// null : Xem
        /// </summary>
        private bool? IsAdd = true;
        DOTimeInOut Data_Obj = null;
        //private DOSystemParams TimeSystem = null;
        DXErrorProvider Error;
        /// <summary>
        /// Delegate dùng cho việc refresh dữ liệu khi thêm mới hoặc chỉnh sửa
        /// </summary>
        /// <returns></returns>
        public delegate QueryBuilder RefreshPhieuXacNhan();
        public RefreshPhieuXacNhan RefreshData;
        #endregion
        #region Initiate methods
        public frmPhieuXNLamViec(object Id,bool? IsAdd)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            Initiate_Control();
            Initiata_Data(Id);
        }
        public frmPhieuXNLamViec() : this("-2", true) { }
        public frmPhieuXNLamViec(object id)
            : this(id, null)
        {
        }
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhieuXNLamViec).FullName,
                "Tạo mới",
                ParentID, true,
                typeof(frmPhieuXNLamViec).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion
        #region Initiate
        private void Initiate_Control(){
            Error = new DXErrorProvider();
            //TimeSystem = DASystemParams.Instance.LoadAll(1);
            HelpControl.RedCheckEdit(this.chkDiCongTac,false);
            HelpControl.RedCheckEdit(this.chkViecRieng,false);
            //DMNhanVienX.I.InitCtrl(cmbEmp, true, IsAdd);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, IsAdd);
            cmbDuyet._init(true);
            chkDiCongTac.Checked = chkViecRieng.Checked = true;
            btnSave.Visible = !(IsAdd == null);
            if (this.IsAdd == true)
            {
                this.NhanVien._setSelectedID(FrameworkParams.currentUser.employee_id);
                
                NhanVien.popupContainerEdit1.CloseUp += delegate(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
                {
                    NguoiNhanEmail._SelectedIDs = PLTimeSheetUtil.GetNguoiNhanMail(PLConst.QUYET_DUYET_XN_LAM_VIEC, NhanVien._getSelectedID());
                };
            }
        }
        private void Initiata_Data(object Id) {
            Data_Obj = DATimeInOut.Instance.LoadAll(HelpNumber.ParseInt64(Id));
            if (Data_Obj != null && Data_Obj.DetailDataSet.Tables[0].Rows.Count > 0)
            {
                NhanVien._setSelectedID(Data_Obj.NV_ID);
                DateTuNgay.DateTime = Data_Obj.NGAY_LAM_VIEC;
                timeEditBatDau.EditValue = Convert.ToDateTime(Data_Obj.GIO_BAT_DAU.ToString()).ToString("HH:mm");
                timeEditKetThuc.EditValue = Convert.ToDateTime(Data_Obj.GIO_KET_THUC.ToString()).ToString("HH:mm");
                cmbDuyet.SetDuyet(Data_Obj);
                if (Data_Obj.LOAI_XAC_NHAN == ((Int32)LoaiXacNhan.CongTacNgoai).ToString())
                {
                    chkViecRieng.Checked = false;
                    chkDiCongTac.Checked = true;
                    textTaiDonVi.Text = Data_Obj.TAI_DON_VI;
                    textCongViec.Text = Data_Obj.LY_DO;
                }
                else {
                    chkDiCongTac.Checked = false;
                    chkViecRieng.Checked = true;
                    textLyDo.Text = Data_Obj.LY_DO;
                }
            }
            else {
                Data_Obj.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                Data_Obj.NGAY_LAM_VIEC=DABase.getDatabase().GetSystemCurrentDateTime();
                Data_Obj.THOI_GIAN_GHI_NHAN = Data_Obj.NGAY_LAM_VIEC;
                Data_Obj.NGUOI_GHI_NHAN = FrameworkParams.currentUser.employee_id;
                Data_Obj.DUYET = ((Int32)DuyetSupportStatus.ChoDuyet).ToString();
            }
            AppCtrl.InitTreeChonNhanVien(NguoiNhanEmail, true);
            lblNgayLapPhieu.Text = Data_Obj.THOI_GIAN_GHI_NHAN.Value.ToString(PLConst.FORMAT_DATETIME_STRING);
            lblNguoiLapPhieu.Text = DMNhanVienX.I.GetEmployeeFullName(Data_Obj.NGUOI_GHI_NHAN);
        }
        #endregion
        #region Validate
        private bool IsHasError()
        {
            Error.ClearErrors();
            GUIValidation.TrimAllData(new object[] { textTaiDonVi, textCongViec, textLyDo });
            GUIValidation.ShowRequiredError(Error,
                new object[] {NhanVien,"Nhân viên",
                              DateTuNgay,"Ngày liên quan"});
            //CHAUTV: Tạm thời bỏ để sử dụng (Xin feedback từ anh Lộc)
            //if (timeEditBatDau.Time.TimeOfDay < new TimeSpan(TimeSystem.GIO_BAT_DAU_SANG.Hour, TimeSystem.GIO_BAT_DAU_SANG.Minute, TimeSystem.GIO_BAT_DAU_SANG.Second)
            //    || timeEditBatDau.Time.TimeOfDay > new TimeSpan(TimeSystem.GIO_KET_THUC_CHIEU.Hour, TimeSystem.GIO_KET_THUC_CHIEU.Minute, TimeSystem.GIO_KET_THUC_CHIEU.Second))
            //    Error.SetError(timeEditBatDau, "Vui lòng chọn thời gian trong khoảng giờ làm việc của công ty!");
            //if (timeEditKetThuc.Time.TimeOfDay < new TimeSpan(TimeSystem.GIO_BAT_DAU_SANG.Hour, TimeSystem.GIO_BAT_DAU_SANG.Minute, TimeSystem.GIO_BAT_DAU_SANG.Second)
            //    || timeEditKetThuc.Time.TimeOfDay > new TimeSpan(TimeSystem.GIO_KET_THUC_CHIEU.Hour, TimeSystem.GIO_KET_THUC_CHIEU.Minute, TimeSystem.GIO_KET_THUC_CHIEU.Second))
            //    Error.SetError(timeEditKetThuc, "Vui lòng chọn thời gian trong khoảng giờ làm việc của công ty!");
            //END CHAUTV
            if (timeEditBatDau.Time.TimeOfDay >= timeEditKetThuc.Time.TimeOfDay )
                Error.SetError(timeEditKetThuc, "Giá trị phải lớn hơn \"" + timeEditBatDau.Time.ToString("HH:mm") + "\"!");
            
            if (chkDiCongTac.Checked)
            {
                GUIValidation.ShowRequiredError(Error,
                    new object[] {textTaiDonVi,"Tại đơn vị",
                        textCongViec,"Công việc"
                    });
            }
            else GUIValidation.ShowRequiredError(Error, new object[] {textLyDo,"Lý do" });
            return Error.HasErrors;
        }
        #endregion
        #region Get Data
        private void GetData()
        {
            //TimeSpan? Tglv = new TimeSpan(0, 0, 0);
            Data_Obj.NV_ID = NhanVien._getSelectedID();
            Data_Obj.NGAY_LAM_VIEC = DateTuNgay.DateTime;
            Data_Obj.GIO_BAT_DAU = timeEditBatDau.Time.TimeOfDay;
            Data_Obj.GIO_KET_THUC = timeEditKetThuc.Time.TimeOfDay;
            //Tglv = new TimeSpan((timeEditKetThuc.Time.TimeOfDay - timeEditBatDau.Time.TimeOfDay).Hours, (timeEditKetThuc.Time.TimeOfDay - timeEditBatDau.Time.TimeOfDay).Minutes, (timeEditKetThuc.Time.TimeOfDay - timeEditBatDau.Time.TimeOfDay).Seconds);//DATimeInOut.getThoiGianLamViec(timeEditBatDau.EditValue, timeEditKetThuc.EditValue);
            Data_Obj.THOI_GIAN_LAM_VIEC = null;// new DateTime(1970, 1, 1, Tglv.Value.Hours, Tglv.Value.Minutes, Tglv.Value.Seconds);
            Data_Obj.TAI_DON_VI = textTaiDonVi.Text;
            Data_Obj.LOAI = (Int32)TimeInOutType.XacNhanLamViec;
            if (chkDiCongTac.Checked)
            {
                Data_Obj.LY_DO = textCongViec.Text;
                Data_Obj.LOAI_XAC_NHAN = ((Int32)LoaiXacNhan.CongTacNgoai).ToString();
                Data_Obj.NOI_DUNG = "Xác nhận làm việc công tác ngoài. Tại \"" + textTaiDonVi.Text + "\". Lý do: " + Data_Obj.LY_DO;
            }
            else {
                Data_Obj.LY_DO = textLyDo.Text;
                Data_Obj.LOAI_XAC_NHAN = ((Int32)LoaiXacNhan.TaiCongTy).ToString();
                Data_Obj.NOI_DUNG = "Xác nhận làm việc tại công ty. Lý do: " + Data_Obj.LY_DO;
            }
        }
        #endregion
        #region Process events
        private void frmPhieuXNLamViec_Load(object sender, EventArgs e)
        {
            
            GUIValidation.SetMaxLength(new object[] {
                textTaiDonVi,200,
                textCongViec,7000,
                textLyDo,7000
            });
            HelpXtraForm.SetCloseForm(this, btnClose, IsAdd);
            HelpXtraForm.SetFix(this);
            PLTimeSheetUtil.PermissionForControl(NhanVien, NhanVien.Visible == true, NhanVien.Visible == true);
        }

        private void chkDiCongTac_CheckedChanged(object sender, EventArgs e)
        {
            this.chkViecRieng.Checked = !this.chkDiCongTac.Checked;
            textTaiDonVi.Enabled = textCongViec.Enabled = chkDiCongTac.Checked;
            if (this.chkDiCongTac.Checked)
                this.textLyDo.Text = "";
        }

        private void chkViecRieng_CheckedChanged(object sender, EventArgs e)
        {
            this.chkDiCongTac.Checked = !this.chkViecRieng.Checked;
            textLyDo.Enabled = chkViecRieng.Checked;
            if (chkViecRieng.Checked) {
                this.textCongViec.Text = "";
                this.textTaiDonVi.Text = "";
            }
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsHasError())
            {
                GetData();
                DATimeInOut.Instance.Update(Data_Obj);
                if (DATimeInOut.Instance.UpdatePhieu(Data_Obj))
                {
                    PLTimeSheetUtil._SendThongBao(NguoiNhanEmail._SelectedIDs, Data_Obj, PLConst.CHO_DUYET,LoaiPhieu.PhieuXacNhanLamViec);
                    HelpXtraForm.CloseFormNoConfirm(this);
                    if (RefreshData != null) RefreshData();
                }
                else
                {
                    ErrorMsg.ErrorSave(this);
                }
            }
        }
    }
}