using System;
using DAO;
using DevExpress.XtraEditors.DXErrorProvider;
using DTO;
using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using pl.office;
using System.Data;
using ProtocolVN.Plugin.TimeSheet;
using ProtocolVN.App.Office;

namespace office
{
    public partial class frmPhieuRaVaoCty : XtraFormPL
    {
        #region Fields
        bool? IsAdd = true;
        DOTimeInOut Data_Obj = null;
        DXErrorProvider Error;

        #endregion
        #region Initiate methods
        public frmPhieuRaVaoCty(object Id, bool? IsAdd)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            InitControl();
            InitData(Id);
        }
        public frmPhieuRaVaoCty(object Id)
            : this(Id, null)
        {
        }
        public frmPhieuRaVaoCty() : this("-2", true) { }
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhieuRaVaoCty).FullName,
                "Tạo mới",
                ParentID, true,
                typeof(frmPhieuRaVaoCty).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        #region Initiate
        private void InitControl()
        {
            Error = new DXErrorProvider();
            //DMNhanVienX.I.InitCtrl(cmbEmp, true, IsAdd);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, IsAdd);
            cmbDuyet._init(true);
            btnSave.Visible = !(IsAdd == null);
            AppCtrl.InitTreeChonNhanVien(NguoiNhanEmail, true);
            NhanVien.popupContainerEdit1.CloseUp += delegate(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
            {
                NguoiNhanEmail._SelectedIDs = PLTimeSheetUtil.GetNguoiNhanMail(PLConst.QUYET_DUYET_RA_VAO_CTY, NhanVien._getSelectedID());
            };
            if (this.IsAdd == true)
            {
                NhanVien._setSelectedID(FrameworkParams.currentUser.employee_id);
                HelpDate.SetDateEdit(this.DateTuNgay, HelpDB.getDBService().GetSystemCurrentDateTime());
            }
        }

        private void InitData(object Id)
        {
            Data_Obj = DATimeInOut.Instance.LoadAll(HelpNumber.ParseInt64(Id));
            if (Data_Obj != null && Data_Obj.DetailDataSet.Tables[0].Rows.Count > 0)
            {
                NhanVien._setSelectedID(Data_Obj.NV_ID);
                DateTuNgay.DateTime = Data_Obj.NGAY_LAM_VIEC;
                timeEditBatDau.EditValue = Convert.ToDateTime(Data_Obj.GIO_BAT_DAU.ToString()).ToString("HH:mm");
                timeEditKetThuc.EditValue = Convert.ToDateTime(Data_Obj.GIO_KET_THUC.ToString()).ToString("HH:mm");
                cmbDuyet.SetDuyet(Data_Obj);
                textLyDo.Text = Data_Obj.LY_DO;
            }
            else
            {
                Data_Obj.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                Data_Obj.NGAY_LAM_VIEC = DABase.getDatabase().GetSystemCurrentDateTime();
                Data_Obj.THOI_GIAN_GHI_NHAN = Data_Obj.NGAY_LAM_VIEC;
                Data_Obj.NGUOI_GHI_NHAN = FrameworkParams.currentUser.employee_id;
                Data_Obj.DUYET = ((Int32)DuyetSupportStatus.ChoDuyet).ToString();
            }
            //nguoiNhanMail.CreateDataset(PLConst.QUYET_DUYET_RA_VAO_CTY, cmbEmp._getSelectedID());
            NguoiNhanEmail._SelectedIDs = PLTimeSheetUtil.GetNguoiNhanMail(PLConst.QUYET_DUYET_RA_VAO_CTY, NhanVien._getSelectedID());
            lblNgayLapPhieu.Text = Data_Obj.THOI_GIAN_GHI_NHAN.Value.ToString(PLConst.FORMAT_DATETIME_STRING);
            lblNguoiLapPhieu.Text = DMNhanVienX.I.GetEmployeeFullName(Data_Obj.NGUOI_GHI_NHAN);
        }
        #endregion
        #region Validate
        private bool IsHasError()
        {
            Error.ClearErrors();
            HelpInputData.TrimAllData(new object[] { textLyDo });
            HelpInputData.ShowRequiredError(Error,
                new object[] {NhanVien,"Nhân viên",
                              DateTuNgay,"Ngày liên quan",
                              textLyDo,"Lý do"});
            if (timeEditBatDau.Time.TimeOfDay < AppGetSysParam.GetGIO_BAT_DAU_SANG
                || timeEditBatDau.Time.TimeOfDay > ((DateTime)frmAppParamsHelp.GetThamSo("GIO_KET_THUC_CHIEU")).TimeOfDay)
                Error.SetError(timeEditBatDau, "Vui lòng chọn thời gian trong khoảng giờ làm việc của công ty!");
            if (timeEditKetThuc.Time.TimeOfDay < AppGetSysParam.GetGIO_BAT_DAU_SANG
                || timeEditKetThuc.Time.TimeOfDay > ((DateTime)frmAppParamsHelp.GetThamSo("GIO_KET_THUC_CHIEU")).TimeOfDay)
                Error.SetError(timeEditKetThuc, "Vui lòng chọn thời gian trong khoảng giờ làm việc của công ty!");
            if (timeEditBatDau.Time.TimeOfDay == timeEditKetThuc.Time.TimeOfDay)
                Error.SetError(timeEditKetThuc, "Giá trị phải lớn hơn \"" + timeEditBatDau.Time.TimeOfDay.ToString() + "\"!");
            return Error.HasErrors;

        }
        #endregion
        #region Get Data
        private void GetData()
        {
            HelpInputData.TrimAllData(new object[] { this.textLyDo });
            Data_Obj.NV_ID = NhanVien._getSelectedID();
            Data_Obj.NGAY_LAM_VIEC = DateTuNgay.DateTime;
            Data_Obj.GIO_BAT_DAU = timeEditBatDau.Time.TimeOfDay;
            Data_Obj.GIO_KET_THUC = timeEditKetThuc.Time.TimeOfDay;
            Data_Obj.THOI_GIAN_LAM_VIEC = null;
            Data_Obj.LY_DO = textLyDo.Text;
            Data_Obj.NOI_DUNG = "Ra vào công ty: " + Data_Obj.LY_DO;
            Data_Obj.LOAI = (Int32)TimeInOutType.RaVaoCongTy;
        }
        #endregion
        #region Process events
        private void frmPhieuRaVaoCty_Load(object sender, EventArgs e)
        {
            HelpInputData.SetMaxLength(new object[] { textLyDo, 200 });
            HelpXtraForm.SetCloseForm(this, btnClose, IsAdd);
            HelpXtraForm.SetFix(this);
            PLTimeSheetUtil.PermissionForControl(NhanVien, NhanVien.Visible == true, NhanVien.Visible == true);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsHasError())
            {
                GetData();
                DATimeInOut.Instance.Update(Data_Obj);
                if (DATimeInOut.Instance.UpdatePhieu(Data_Obj))
                {
                    PLTimeSheetUtil._SendThongBao(NguoiNhanEmail._SelectedIDs, Data_Obj, PLConst.CHO_DUYET, LoaiPhieu.PhieuRaVaoCty);
                    HelpXtraForm.CloseFormNoConfirm(this);
                }
                else
                {
                    ErrorMsg.ErrorSave(this);
                }
            }
        }
        #endregion


    }
}