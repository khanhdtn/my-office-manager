using ProtocolVN.Framework.Win;
using DTO;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.DanhMuc;
using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Data.Common;
using ProtocolVN.App.Office;
using ProtocolVN.Plugin.TimeSheet;

namespace office
{
    public partial class frmPhieuTamUng : PhieuPopupBase
    //public partial class frmPhieuTamUng : XtraFormPL
    {
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhieuTamUng).FullName,
                "Tạo mới",
                ParentID, true,
                typeof(frmPhieuTamUng).FullName,
                false, IsSep, "add.png", true, "", "");
        }

        private DOPhieuTamUng Phieu = null;
        private PhieuPopupFix fix;
        private bool? IsDuyet = null;
        DataRow RowTamUng = null;
        //Delegate cho việc Refresh dữ liệu trên form QL
        public delegate void RefreshDataQL();
        public RefreshDataQL RefreshData;
        //----------------------------------------------
        public frmPhieuTamUng() : this("-2", true, null) { }

        public frmPhieuTamUng(object id) : this(id, true, null) { } //CHAUTV : Sử dụng trong trường hợp kết chuyển tạm ứng

        /// <summary>
        /// Sử dụng trong trường hợp kết chuyển tạm ứng.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="IsAdd"></param>
        /// <param name="row"></param>
        public frmPhieuTamUng(object id, bool? IsAdd, DataRow row)
            : base()
        {
            InitializeComponent();
            RowTamUng = row;
            PLGUIUtil.InitBtnPhieu(this, IsAdd, null, null, null, this.btnSave, null, this.btnDong);
            fix = new PhieuPopupFix(this, id, IsAdd);
        }
        /// <summary>
        /// Sử dụng cho chức năng duyệt và không duyệt trên form QL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="IsAdd"></param>
        /// <param name="IsDuyet">,'null' : Xem,Sua,Them,'true' : Duyet,'false' : Khong duyet </param>
        public frmPhieuTamUng(object id, bool? IsAdd, bool IsDuyet)
            : base()
        {
            InitializeComponent();
            this.IsDuyet = IsDuyet;
            PLGUIUtil.InitBtnPhieu(this, IsAdd, null, null, null, this.btnSave, null, this.btnDong);
            fix = new PhieuPopupFix(this, id, IsAdd);
            
        }

        public override void InitDataControls()
        {
            //LOOP : Khởi tạo controls
            dateNgayDeNghi.Enabled = true;
            dateNgayDeNghi.DateTime = HelpDB.getDatabase().GetSystemCurrentDateTime();
            HelpXtraForm.SetCloseForm(this, btnDong, base.IsAdd);
            //DMNhanVienX.I.InitCtrl(PLDMTreeNguoiDeNghi, true, IsAdd);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, IsAdd);
            AppCtrl.InitTreeChonNhanVien(NguoiNhanMail, true);
            NhanVien.popupContainerEdit1.CloseUp += delegate(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
            {
                NguoiNhanMail._SelectedIDs = ProtocolVN.Plugin.TimeSheet.PLTimeSheetUtil.GetNguoiNhanMail(PLConst.QUYET_DUYET_TAM_UNG, NhanVien._getSelectedID());
                
            };
            NhanVien._setSelectedID(FrameworkParams.currentUser.employee_id);
            dateThangNam._timeEdit.Time = DABase.getDatabase().GetSystemCurrentDateTime();
            //Format calcSoTienXinUng với 0 số thập phân sau dấu phẩy.
            ApplyFormatAction.applyElement(calcSoTienXinUng.Properties, 0);
            calcSoTienXinUng.Properties.Precision = 0;
            //----------------------
            //Các khởi tạo cho trường hợp kết chuyển tạm ứng
            if (RowTamUng != null)
            {
                dateThangNam._timeEdit.Time = Convert.ToDateTime(RowTamUng["THANG_NAM"].ToString());
                dateThangNam._timeEdit.Time = dateThangNam._timeEdit.Time.AddMonths(1);
                calcSoTienXinUng.Enabled = false;
                NhanVien.Enabled = false;
                NhanVien._setSelectedID(HelpNumber.ParseInt64(RowTamUng["NV_ID"]));
                calcSoTienXinUng.Value = Math.Abs(HelpNumber.ParseDecimal(RowTamUng["TT_CON_LAI"]));
                mboSoTienXinUng.Text = DAPhieuTamUng.DecimalToString(calcSoTienXinUng.Value);
                radioGroup.Enabled = false;
                dateThangNam.Enabled = plLabel16.Enabled = false;
            }
            //-----------------------
            if (base.ID is DOBangLuong)
            {
                ///CHAUTV : 
                DOBangLuong data = (DOBangLuong)base.ID;
                NhanVien._setSelectedID(data.NV_ID);
                dateThangNam._timeEdit.Time = this.GetMonthNext(GetDateTimeTo(data.THANG_NAM));
                calcSoTienXinUng.EditValue = Math.Abs(data.TT_CON_LAI);
            }
            //Focus
            this.NhanVien.Focus();
            
        }

        public override void InitGridColumns()
        {
            //LOOP : Không dùng
        }

        public override bool IsValidate()
        {
            if (base.ID is DOBangLuong)
            {
                ///...
                return true;
            }
            return true;
        }

        public override bool InitDOData()
        {
            if (base.ID is DOBangLuong)
            {
                DOBangLuong data = (DOBangLuong)base.ID;
                ///....    
                return (data != null);
            }
            else
            {
                Phieu = DAPhieuTamUng.I.LoadAll(HelpNumber.ParseInt64(base.ID));
                cmbDuyet._init(true);
                if (Phieu != null && Phieu.MasterDataSet.Tables[0].Rows.Count > 0)
                {
                    dateNgayDeNghi.DateTime = Phieu.NGAY_XIN_TAM_UNG;
                    NhanVien._setSelectedID(Phieu.NGUOI_DE_NGHI_ID);
                    calcSoTienXinUng.Value = Phieu.SO_TIEN_XIN_UNG;
                    mboSoTienXinUng.Text = DAPhieuTamUng.DecimalToString(calcSoTienXinUng.Value);
                    if (Phieu.LY_DO != null && Phieu.LY_DO.Length > 0) {
                        mboLyDo.Text = Phieu.LY_DO;
                        radioGroup.SelectedIndex = 1;
                        mboLyDo.Enabled = true;
                    }
                    if (IsDuyet == false) Phieu.DUYET = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();
                    else if (IsDuyet == true) Phieu.DUYET = ((Int32)DuyetSupportStatus.Duyet).ToString();
                    cmbDuyet.SetDuyet(Phieu);
                    if (Phieu.THANG_TAM_UNG != null)
                        dateThangNam._timeEdit.Time = Convert.ToDateTime(Phieu.THANG_TAM_UNG);
                    if (IsDuyet == true && (Phieu.DUYET == ((Int32)DuyetSupportStatus.ChoDuyet).ToString() || Phieu.DUYET == ((Int32)DuyetSupportStatus.KhongDuyet).ToString())) btnSave.Enabled = false;
                }
                else
                {
                    Phieu.MA_PHIEU = DAPhieuTamUng.I.GetPhieuTamUng();
                }
                if (RowTamUng != null) Phieu.KET_CHUYEN_TU_LUONG = "Y";//Trường hợp kết chuyển tạm ứng.
                else Phieu.KET_CHUYEN_TU_LUONG = "N";
                return (Phieu != null);
            }
        }

        private void frmPhieuTamUng_Load(object sender, EventArgs e)
        {
            PLTimeSheetUtil.PermissionForControl(NhanVien, NhanVien.Visible == true, NhanVien.Visible == true);
            GUIValidation.SetMaxLength(new object[]{
                    mboLyDo,200
                });
            calcSoTienXinUng.LostFocus += new EventHandler(calcSoTienXinUng_LostFocus);
            calcSoTienXinUng.EditValueChanged += new EventHandler(calcSoTienXinUng_EditValueChanged);
            radioGroup.SelectedIndexChanged += delegate(object radio, EventArgs indexChanged)
            {
                mboLyDo.Enabled = radioGroup.SelectedIndex == 1;
                dateThangNam.Enabled = !mboLyDo.Enabled;
            };
            HelpXtraForm.SetFix(this);
        }

        void calcSoTienXinUng_EditValueChanged(object sender, EventArgs e)
        {
            calcSoTienXinUng.Value = Math.Abs(calcSoTienXinUng.Value);
            mboSoTienXinUng.Text = DAPhieuTamUng.DecimalToString(calcSoTienXinUng.Value);
        }

        void calcSoTienXinUng_LostFocus(object sender, EventArgs e)
        {
            
        }
        private void btnDuyet_Click(object sender, EventArgs e)
        {
            base.errorProvider.ClearErrors();
        }
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (base.ID is DOBangLuong)
            {
                //CHAUTV : 
                if (!this.Validate()) return;
                DOPhieuTamUng phieuTamUng = DAPhieuTamUng.I.LoadAll(-2);
                phieuTamUng.MA_PHIEU = DAPhieuTamUng.I.GetPhieuTamUng();
                phieuTamUng.NGAY_XIN_TAM_UNG = HelpDB.getDatabase().GetSystemCurrentDateTime();
                phieuTamUng.NGUOI_DE_NGHI_ID = NhanVien._getSelectedID();
                phieuTamUng.SO_TIEN_XIN_UNG = HelpNumber.ParseDecimal(calcSoTienXinUng.EditValue);
                phieuTamUng.LY_DO = mboLyDo.Text;
                phieuTamUng.THANG_TAM_UNG = dateThangNam._timeEdit.Text;
                if (DAPhieuTamUng.I.Update(phieuTamUng))
                {
                    HelpXtraForm.CloseFormNoConfirm(this);
                    DOBangLuong data = (DOBangLuong)base.ID;
                    data.TT_CON_LAI = 0;
                    DABangLuong.Instance.Update(data);
                }
                else ErrorMsg.ErrorSave(this);
            }
            else
            {
                //DATHQ : 
                if (GetData())
                {
                    bool result = false;
                        if (RowTamUng != null)
                        {
                            Phieu.DUYET = ((Int32)DuyetSupportStatus.Duyet).ToString();
                            result = (DAPhieuTamUng.I.Update(Phieu) && DABangLuong.Instance.UpdateIsKetChuyenTamUng(RowTamUng));
                            if (!result) {
                                ErrorMsg.ErrorSave(this);
                                return;
                            }
                        }
                        else
                           result= DAPhieuTamUng.I.Update(Phieu);
                        if (result)
                        {
                            DAPhieuTamUng.I._GuiMailTamUng(Phieu, GetNguoiNhanMail(Phieu));
                            HelpXtraForm.CloseFormNoConfirm(this);
                            if (RefreshData != null) RefreshData();
                        }
                        else ErrorMsg.ErrorSave(this);
                }
            }
        }
        #region Ext
        private bool GetData()
        {
            base.errorProvider.ClearErrors();
            if (IsDuyet == null)
            {
                if (radioGroup.SelectedIndex == 1)
                {
                    if (!HelpInputData.ShowRequiredError(base.errorProvider, new object[]{
                    dateNgayDeNghi,"Ngày đề nghị",                    
                    NhanVien,"Người đề nghị",
                    calcSoTienXinUng,"Số tiền ứng",
                    mboLyDo,"Lý do"                
                })) return false;
                }
                else
                {
                    if (!HelpInputData.ShowRequiredError(base.errorProvider, new object[]{
                    dateNgayDeNghi,"Ngày đề nghị",                    
                    NhanVien,"Người đề nghị",
                    calcSoTienXinUng,"Số tiền ứng"
                })) return false;
                }
                if (HelpIsCheck.IsALessB(HelpDB.getDatabase().GetSystemCurrentDateTime(), dateNgayDeNghi.DateTime))
                {
                    base.errorProvider.SetError(dateNgayDeNghi, "Ngày đề nghị không được lớn hơn ngày hiện tại!");
                    return false;
                }
                if (DAPhieuTamUng.I.CheckIsChot(NhanVien._getSelectedID(), dateThangNam._timeEdit.Text, "Y") == "Y")
                {
                    ErrorMsg.ShowBizRuleProblems(string.Format("Bảng lương của nhân viên \"{0}\" trong tháng \"{1}\" đã được chốt. Không cho phép tạm ứng!"
                        , DMNhanVienX.I.GetEmployeeFullName(NhanVien._getSelectedID()), dateThangNam._timeEdit.Text),string.Empty,"Lỗi nghiệp vụ");
                    return false;
                }
                if (calcSoTienXinUng.Value <= 0 || calcSoTienXinUng.Value > 99999999999999)
                {
                    base.errorProvider.SetError(calcSoTienXinUng, "Vui lòng nhập vào \"Số tiền\" từ 1 đến 99.999.999.999.999!");
                    return false;
                }
            }
            Phieu.NGAY_XIN_TAM_UNG = dateNgayDeNghi.DateTime;
            Phieu.NGUOI_DE_NGHI_ID = NhanVien._getSelectedID();
            Phieu.SO_TIEN_XIN_UNG = HelpNumber.ParseDecimal(calcSoTienXinUng.Value);
            Phieu.LY_DO = mboLyDo.Text.Length > 0 ? mboLyDo.Text : null;
            if (IsDuyet == null) Phieu.NGUOI_DUYET = 0;
            else Phieu.NGUOI_DUYET = FrameworkParams.currentUser.employee_id;
            Phieu.DUYET = base.IsAdd == true ? ((Int32)DuyetSupportStatus.ChoDuyet).ToString() : Phieu.DUYET;
            Phieu.THANG_TAM_UNG = dateThangNam._timeEdit.Time.ToShortDateString().Substring(3, 7);
            return true;
        }
        private DateTime GetMonthNext(DateTime Now)
        {
            if (DateTime.IsLeapYear(Now.Year) && Now.Month == 2)
                return Now.AddDays(29);
            if (!DateTime.IsLeapYear(Now.Year) && Now.Month == 2)
                return Now.AddDays(28);
            switch (Now.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: return Now.AddDays(31); break;
            }
            return Now.AddDays(30);
        }
        private DateTime GetDateTimeTo(string Month)
        {
            string[] M = Month.Split('/');
            return new DateTime(HelpNumber.ParseInt32(M[1]), HelpNumber.ParseInt32(M[0]), 1);
        }
        private void CheckSendMail(string ThangTamUng, string NguoiGui, long NguoiNhanMail, string LiDo)
        {
            DataRow rowEmail = DAPhieuTamUng.getEmailNhanVien(NguoiNhanMail);
            if (rowEmail == null) return;
            Dictionary<string, string> dToAddress = new Dictionary<string, string>();
            dToAddress.Add(rowEmail["EMAIL"].ToString(), rowEmail["NAME"].ToString());
            Dictionary<string, string> dCC = new Dictionary<string, string>();
            
            StringBuilder Content = new StringBuilder("");
            if (IsDuyet == true)
                Content.Append("Xin tạm ứng lương tháng " + ThangTamUng + " đã được duyệt!");
            else if (IsDuyet == false)
                Content.Append("Xin tạm ứng lương tháng " + ThangTamUng + " không được duyệt!");
            else
                Content.Append("Tôi tên là : " + NguoiGui + "\n Vì lí do:" + LiDo + "\n Nên tôi xin được ứng lương tháng " + ThangTamUng);
            if (rowEmail["EMAIL"].ToString() == string.Empty)
                HelpMsgBox.ShowNotificationMessage("Người nhận không có địa chỉ email. Gửi email không thành công!");
            else
            {
                HelpZPLOEmail.SendEmails("Về việc tạm ứng", dToAddress, "Về việc tạm ứng", "Về việc tạm ứng lương tháng " + ThangTamUng, Content.ToString(), dCC, string.Empty);
            }
        }
        private long[] GetNguoiNhanMail(DOPhieuTamUng phieu) {
            List<long> lstUser = new List<long>(NguoiNhanMail._SelectedIDs);
          
            if(!lstUser.Contains(phieu.NGUOI_DE_NGHI_ID)) lstUser.Add(phieu.NGUOI_DE_NGHI_ID);
            return lstUser.ToArray();
        }
        #endregion

                
    }
}