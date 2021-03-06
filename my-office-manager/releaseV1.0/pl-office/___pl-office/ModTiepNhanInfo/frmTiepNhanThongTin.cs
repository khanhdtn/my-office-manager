using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using DTO;
using DAO;
using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.App.Office;

namespace office
{
    //Lưu ý : Khi thực hiện lưu hoặc sửa thì tự động gửi mail đến cho người xử lý
    public partial class frmTiepNhanThongTin : XtraFormPL
    {
        #region Khai báo MenuItem
        public static FormStatus Status = FormStatus.OK_DEV;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTiepNhanThongTin).FullName,
                PMSupport.UpdateTitle("Tạo mới", Status),
                ParentID, true,
                typeof(frmTiepNhanThongTin).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        #region Khai báo biến
        private DOTiepNhanInfo doData;
        private bool ?isAdd;
        private DXErrorProvider error;

        public delegate void AfterUpdateSuccessfully(DOTiepNhanInfo doData);
        public event AfterUpdateSuccessfully _AfterUpdateSuccessfully;

        #endregion

        #region Contructors
        public frmTiepNhanThongTin(object IDKey,bool?IsAdd)
        {
            InitializeComponent();
            this.isAdd = IsAdd;
            InitControl();
            InitData(HelpNumber.ParseInt64(IDKey));
            this.Load += new EventHandler(frmTiepNhanThongTin_Load);
        }
        public frmTiepNhanThongTin(object IDKey)
            : this(IDKey, null)
        {

        }
        void frmTiepNhanThongTin_Load(object sender, EventArgs e)
        {
            GUIValidation.SetMaxLength(new object[] {
                txtVanDe, 200,
            });
            PLTinhtrang.SelectedIndexChanged += new EventHandler(PLTinhtrang_SelectedIndexChanged);
        }

        void PLTinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isAdd==true) PLTinhtrang._setSelectedID(1);
        }

        public frmTiepNhanThongTin() : this("-2", true) { }
        #endregion

        #region Khởi tạo dữ liệu, lấy dữ liệu, gán dữ liệu

        private void InitControl() 
        {
            error = new DXErrorProvider();
            DMNguonThongTin.I.InitCtrl(cmbNguonTin, isAdd);
            AppCtrl.InitTreeChonNhanVien(NguoiXuLy, true,false);
            AppCtrl.InitTreeChonNhanVien(NguoiNhanMail, true);
            NguoiXuLy._AfterSelected += new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice.AfterSelected(NguoiXuLy__AfterSelected);
            PLTinhtrang._init(DAYeuCau.Bang_tinh_trang(), "NAME", "ID");
            HelpXtraForm.SetCloseForm(this, btnClose, this.isAdd);
            if (this.isAdd == null)
                this.btnSave.Visible = false;
            PLGUIUtil.Customizebar_PLRichTextBox(NoiDung);
        }

        void NguoiXuLy__AfterSelected(object sender, EventArgs e)
        {
            NguoiNhanMail._SelectedIDs = NguoiXuLy._SelectedIDs;
        }
       
        private void InitData(long id) 
        {
            doData = DATiepNhanInfo.I.LoadAll(id);
            if (doData != null && doData.DataSetMaster != null && doData.DataSetMaster.Tables[0].Rows.Count > 0)
            {
                txtVanDe.Text = doData.VAN_DE_TIEP_NHAN;
                cmbNguonTin._setSelectedID(doData.NGUON_THONG_TIN);
                NguoiXuLy._SelectedStrIDs = doData.NGUOI_XU_LY;
                NguoiNhanMail._SelectedStrIDs = doData.NGUOI_XU_LY;
                lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(doData.NGUOI_CAP_NHAT);
                lblThoiGianCapNhat.Text = doData.NGAY_CAP_NHAT.ToString(FrameworkParams.option.DateTimeFomat);
                NoiDung._setValue(doData.NOI_DUNG);
                PLTinhtrang._setSelectedID(doData.TINH_TRANG);
            }
            else {
                lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id);
                lblThoiGianCapNhat.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(FrameworkParams.option.DateTimeFomat);
                PLTinhtrang._setSelectedID(1);//Tình trạng là "Mới tạo".
            }
        }

        #endregion

        #region Sự kiện

        #endregion

        #region Kiểm tra tính hợp lệ

        private bool IsHasError() {
            error.ClearErrors();
            HelpInputData.TrimAllData(new object[] { 
                this.txtVanDe
            });
            HelpInputData.ShowRequiredError(error, new object[] {
                txtVanDe, "Vấn đề tiếp nhận",
            });
            if (cmbNguonTin._getSelectedID() == -1)
                cmbNguonTin.SetError(error, "Vui lòng vào thông tin \"Nguồn thông tin\"!");
            if (PLTinhtrang._getSelectedID() == -1)
                PLTinhtrang.SetError(error, "Vui lòng vào thông tin \"Tình trạng\" !");
            if (NguoiXuLy._CountSelectedIDs == 0)
                NguoiXuLy._SetError(error, "Vui lòng vào thông tin \"Người xử lý\" !");
            if (NoiDung._getValue().Length < 0 || NoiDung.richEditControl.Text.Trim()=="")
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Nội dung tiếp nhận\"!");
                return true;
            }
            return error.HasErrors;
        }

        #endregion

        #region Mở rộng khác
        private void GetData() {
            if (this.isAdd == true)
            {
                doData.ID = HelpGen.DT();
                doData.NGUOI_CAP_NHAT = FrameworkParams.currentUser.employee_id;
            }
            doData.VAN_DE_TIEP_NHAN = txtVanDe.Text;
            doData.NGUON_THONG_TIN = cmbNguonTin._getSelectedID();
            doData.NGUOI_XU_LY = NguoiXuLy._SelectedStrIDs;
            doData.NGAY_CAP_NHAT = DABase.getDatabase().GetSystemCurrentDateTime();
            doData.NOI_DUNG = NoiDung._getValue();
            doData.TINH_TRANG = PLTinhtrang._getSelectedID();
        }
        #endregion

        private void frmTiepNhanThongTin_Load_1(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsHasError())
            {
                GetData();

                if (DATiepNhanInfo.I.Update(doData))
                {
                    if (_AfterUpdateSuccessfully != null) _AfterUpdateSuccessfully(doData);
                    //gửi mail
                    string title = "[PL-Office]: Có tiếp nhận thông tin mới được cập nhật";
                    string subject = string.Format(PLConst.DES_MAIL_NEW_INFO, txtVanDe.Text
                        , lblThoiGianCapNhat.Text, (cmbNguonTin.DataSource as DataTable).Select(string.Format("ID={0}", cmbNguonTin._getSelectedID()))[0]["NAME"].ToString()
                        , DATiepNhanInfo.I.GetNameOfProcessor(doData.NGUOI_XU_LY,
                          HelpDB.getDatabase().LoadDataSet(@"SELECT ID,NAME FROM DM_NHAN_VIEN").Tables[0],", ")
                        , DMFWNhanVien.GetFullName(doData.NGUOI_CAP_NHAT));
                    
                    List<long> listID = new List<long>();
                    foreach (long id in NguoiXuLy._SelectedIDs)
                        if (!listID.Contains(id)) listID.Add(id);
                    foreach (long id in NguoiNhanMail._SelectedIDs)
                        if (!listID.Contains(id)) listID.Add(id);
                    if (listID.Count > 0)
                    {
                        HelpZPLOEmail.SendSmartHost(HelpAutoOpenForm.GeneratingCodeFromForm(this, doData.ID),
                            title, null, HelpZPLOEmail.GetAddressList(listID.ToArray()), null, null, subject, "");
                    }
                    HelpXtraForm.CloseFormNoConfirm(this);
                }

                else
                    ErrorMsg.ErrorSave(this);
            }
        }

    }
}