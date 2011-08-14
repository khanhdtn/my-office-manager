using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using ProtocolVN.DanhMuc;
using System.Collections.Generic;
using DTO;

using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using System.Drawing;
using ProtocolVN.App.Office;
using System.IO;

namespace office
{
    public partial class frmMeeting : PhieuPopupBase, IPhieuPopup<DOMeeting>
    //public partial class frmMeeting : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmMeeting).FullName,
                PMSupport.UpdateTitle("Tạo mới", Status),
                ParentID, true,
                typeof(frmMeeting).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        public delegate void UpdateDataScheduler();
        public UpdateDataScheduler RefreshData;
        private DOMeeting doMeeting = null;

        #endregion

        #region Hàm dựng
        PhieuPopupFix thatPopup;
        public frmMeeting(long ID, bool? IsAdd)
        {
            InitializeComponent();
            thatPopup = new PhieuPopupFix(this, ID, IsAdd);
        }
        public frmMeeting(object id) : this(HelpNumber.ParseInt64(id), null) { }
        public frmMeeting() : this(-2, true) { }
        private void frmMeeting_Load(object sender, EventArgs e)
        {
            PLGUIUtil.setDefaultSize(this);
            if (btnLuu.Visible != false)//Nếu btnLuu.Visible = false là do phân quyền thì không set.
                btnLuu.Visible = this.IsAdd != null;
            HelpXtraForm.SetFix(this);

        }
        #endregion

        #region InitForm
        public override void InitDataControls()
        {
            HelpXtraForm.SetCloseForm(this, btnClose, this.IsAdd);
            DMNhanVienX.I.ChonNhanVienLamViec(PLNguoiToChuc, true, this.IsAdd);
            DMNhanVienX.I.ChonNhanVienLamViec(cboThuKy, true, IsAdd);
            DMLoaiMeeting.I.InitCtrl(PLLoaiCuocHop, base.IsAdd, true);
            this.SetMaxLength();
            AppCtrl.InitTreeChonNhanVien(NguoiThamDu, true,false);
            AppCtrl.InitTreeChonNhanVien(NguoiVangMat, true,false);
            AppCtrl.InitTreeChonNhanVien(NguoiNhanMail, true);
            NguoiThamDu._AfterSelected += new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice.AfterSelected(NguoiThamDu__AfterSelected);
        }

        void NguoiThamDu__AfterSelected(object sender, EventArgs e)
        {
            NguoiNhanMail._SelectedIDs = NguoiThamDu._SelectedIDs;
        }

        public override void InitGridColumns()
        {
            PLGUIUtil.Customizebar_PLRichTextBox(NoiDung);
        }

        public override bool IsValidate()
        {
            errorProvider.ClearErrors();
            if (ThoiGianBatDau.Time.TimeOfDay == new TimeSpan(0, 0, 0))
                errorProvider.SetError(ThoiGianBatDau, "Vui lòng chọn \"Thời gian bắt đầu\"!");
            if (ThoiGianKetThuc.Time.TimeOfDay == new TimeSpan(0, 0, 0))
                errorProvider.SetError(ThoiGianKetThuc, "Vui lòng chọn \"Thời gian kết thúc\"!");
            if (ThoiGianKetThuc.Time.TimeOfDay <= ThoiGianBatDau.Time.TimeOfDay)
                errorProvider.SetError(ThoiGianKetThuc, "\"Thời gian kết thúc\" phải lớn hơn \"Thời gian bắt đầu\"!");
            GUIValidation.ShowRequiredError(this.errorProvider,
                new object[]{
                    txtChuDe,"Chủ đề", 
                    NgayKH,"Ngày",
                    memoMucDich,"Mục đích",
                    PLNguoiToChuc,"Người chủ trì",
                    cboThuKy,"Thư ký"
                });
            if (NguoiThamDu._CountSelectedIDs == 0)
                NguoiThamDu._SetError(errorProvider, "Vui lòng vào thông tin \"Thành phần tham dự\" !");
            if (NoiDung._getValue().Length < 0 || NoiDung.richEditControl.Text.Trim() == "")
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Nội dung\"!");
                return false;
            }
            return !errorProvider.HasErrors;
        }

        public override bool InitDOData()
        {
            bool flag = true;
            try
            {
                plMulTTDK._Init(IsAdd);
                doMeeting = this.getObject();
                plMulTTDK._DataSource = doMeeting.DsFile;
                if (this.IsAdd == true)
                {
                    NgayKH.DateTime = DateTime.Today;
                    return true;
                }
                memoKL.Text = doMeeting.KET_QUA;
                if (doMeeting.THANH_PHAN_THAM_DU.Length > 0)
                {
                    NguoiThamDu._SelectedStrIDs = doMeeting.THANH_PHAN_THAM_DU;
                    NguoiNhanMail._SelectedStrIDs = doMeeting.THANH_PHAN_THAM_DU;
                }
                if (doMeeting.THANH_PHAN_VANG_MAT.Length > 0)
                {
                    NguoiVangMat._SelectedStrIDs = doMeeting.THANH_PHAN_VANG_MAT;
                }
                txtChuDe.Text = doMeeting.CHU_DE;
                ThoiGianBatDau.EditValue = Convert.ToDateTime(doMeeting.GIO_BAT_DAU.ToString()).ToString("HH:mm");
                ThoiGianKetThuc.EditValue = Convert.ToDateTime(doMeeting.GIO_KET_THUC.ToString()).ToString("HH:mm");
                NgayKH.DateTime = doMeeting.NGAY;
                memoDiaDiem.Text = doMeeting.DIA_DIEM;
                PLNguoiToChuc._setSelectedID(doMeeting.NGUOI_TO_CHUC_ID);
                NoiDung._setValue(doMeeting.NOI_DUNG);
                cboThuKy._setSelectedID(doMeeting.THU_KY);
                memoGhiChu.Text = doMeeting.GHI_CHU;
                memoMucDich.Text = doMeeting.MUC_DICH;
                if (doMeeting.LOAI_CUOC_HOP >= 0) PLLoaiCuocHop._setSelectedID(doMeeting.LOAI_CUOC_HOP);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Khởi tạo đối tượng \"DOMeeting\"!");
                flag = false;
            }
            return flag;
        }
        #endregion

        #region IPhieuPopup<DOMeeting> Members

        public DOMeeting getObject()
        {
            if (this.IsAdd == true)
            {
                doMeeting = DAMeeting.Instance.LoadAll(-2);
                doMeeting.ID = HelpDB.getDatabase().GetID(PLConst.G_NGHIEP_VU);
                return doMeeting;
            }
            else
            {
                return DAMeeting.Instance.LoadAll(HelpNumber.ParseInt64(this.ID));
            }
        }

        public DOMeeting getDataOjbect()
        {
            if (doMeeting != null)
            {
                doMeeting.KET_QUA = memoKL.Text;
                doMeeting.NOI_DUNG = NoiDung._getValue();
                doMeeting.GIO_BAT_DAU = new DateTime(NgayKH.DateTime.Year, NgayKH.DateTime.Month, NgayKH.DateTime.Day, ThoiGianBatDau.Time.Hour, ThoiGianBatDau.Time.Minute, ThoiGianBatDau.Time.Second);
                doMeeting.GIO_KET_THUC = new DateTime(NgayKH.DateTime.Year, NgayKH.DateTime.Month, NgayKH.DateTime.Day, ThoiGianKetThuc.Time.Hour, ThoiGianKetThuc.Time.Minute, ThoiGianKetThuc.Time.Second);
                doMeeting.NGAY = (DateTime)HelpDate.GetDateEdit(NgayKH);
                doMeeting.DIA_DIEM = memoDiaDiem.Text;
                doMeeting.NGUOI_TO_CHUC_ID = PLNguoiToChuc._getSelectedID();
                doMeeting.LOAI_CUOC_HOP = PLLoaiCuocHop._getSelectedID();
                doMeeting.NGUOI_CAP_NHAT_ID = FrameworkParams.currentUser.employee_id;
                doMeeting.NGAY_CAP_NHAT = HelpDB.getDatabase().GetSystemCurrentDateTime();
                doMeeting.CHU_DE = txtChuDe.Text;
                doMeeting.THU_KY = cboThuKy._getSelectedID();
                doMeeting.MUC_DICH = memoMucDich.Text;
                doMeeting.GHI_CHU = memoGhiChu.Text;
                doMeeting.KET_QUA = memoKL.Text;
                doMeeting.THANH_PHAN_THAM_DU = NguoiThamDu._SelectedStrIDs;
                doMeeting.THANH_PHAN_VANG_MAT = NguoiVangMat._SelectedStrIDs;
                doMeeting.DsFile = plMulTTDK._DataSource;
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
                        if (RefreshData != null) RefreshData();
                        //gửi mail
                        DAMeeting.SendThongBao(doMeeting,NguoiNhanMail._SelectedIDs);
                        if (this.IsAdd == false)
                        {
                            PLGUIUtil.ClosePhieu(this, true);
                        }
                        else
                        {
                            HelpMsgBox.ShowNotificationMessage("Lưu thành công.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                    HelpSysLog.AddException(ex, "Lưu dữ liệu Meeting");
                }
            }
        }

        #endregion

        #region Mo rong
        private void SetMaxLength()
        {
            HelpInputData.SetMaxLength(new object[]{
                memoGhiChu , 2000,
                txtChuDe, 1000,
                memoDiaDiem,1000,
                memoGhiChu,2000,
                memoKL, 2000
            });
        }
        #endregion
    }
}