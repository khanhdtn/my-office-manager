using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DTO;
using DAO;
using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System.Drawing;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraGrid;
using ProtocolVN.App.Office;
using LumiSoft.Net.Mime;
using System.Text;


namespace office
{
    public partial class frmBugProduct : XtraFormPL
    {
        #region Vùng đặt Static

        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmBugProduct).FullName,
                PMSupport.UpdateTitle("Tạo mới", Status),
                ParentID, true,
                typeof(frmBugProduct).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private DXErrorProvider Error;
        private bool? IsAdd = true;
        private long _ID_Bug;
        private long _ID_Bug_Reply = 0;
        private DOBugProduct doBugProduct = null;
        private DOReplyBugProduct doReplyBugProduct = null;

        public delegate void _AfterAddIssueSuccessfully(DOBugProduct doBugProduct);
        public event _AfterAddIssueSuccessfully AfterAddIssueSuccessfully;

        public delegate void _AfterUpdateIssueSuccessfully(DOBugProduct doBugProduct);
        public event _AfterUpdateIssueSuccessfully AfterUpdateIssueSuccessfully;

        public delegate void _AfterAddReplyIssueSuccessfully(DOReplyBugProduct doReplyBugProduct);
        public event _AfterAddReplyIssueSuccessfully AfterAddReplyIssueSuccessfully;

        public delegate void _AfterUpdateReplyIssueSuccessfully(DOReplyBugProduct doReplyBugProduct);
        public event _AfterUpdateReplyIssueSuccessfully AfterUpdateReplyIssueSuccessfully;

        public delegate void _AfterUpdateStatusOfIssue(long TinhTrang, object[] infos);
        public event _AfterUpdateStatusOfIssue AfterUpdateStatusOfIssue;

        #endregion

        #region Hàm dựng
        public frmBugProduct(long ID, bool? IsAdd,params long[] ID_Bug_Reply)
        {
            InitializeComponent();
            
            this._ID_Bug = ID;
            if (ID_Bug_Reply.Length > 0) this._ID_Bug_Reply = ID_Bug_Reply[0];
            this.IsAdd = IsAdd;
            Error = new DXErrorProvider();
            InitForm();
        }
        public frmBugProduct() : this(-2, true) { }
        public frmBugProduct(long ID)
            : this(ID, null)
        {

        }
        #endregion

        #region InitForm
        private void frmBugProduct_Load(object sender, EventArgs e)
        {            
            _LoadDataForm();
            HelpXtraForm.SetFix(this);
            if (AfterAddReplyIssueSuccessfully != null || AfterUpdateReplyIssueSuccessfully != null)
            {
                loaiVanDe.Enabled = memoVanDe.Enabled = false;
            }
            Tinh_trang.SelectedIndexChanged += new EventHandler(Tinh_trang_SelectedIndexChanged);
        }

        void Tinh_trang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAdd == true && AfterAddReplyIssueSuccessfully == null)
            {
                Tinh_trang._setSelectedID(1);
            }
        }

        private void _LoadDataForm()
        {
            lblNguoiGui.Text = DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id);
            this.lblThoiGianGui.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            plMultiChoiceFiles1._Init(IsAdd);
            plMultiChoiceFiles1._DataSource = DALuuTruTapTin.Instance.GetTapTinByObjectID(-2, 9);
            if (IsAdd == true && AfterAddReplyIssueSuccessfully == null)
            {
                Tinh_trang._setSelectedID(1);
                doBugProduct = DABugProduct.Instance.LoadAll(-2);
            }
            else
            {
                doBugProduct = DABugProduct.Instance.LoadAll(this._ID_Bug);
                this.loaiVanDe._setSelectedID(doBugProduct.LOAI_VAN_DE);
                this.Tinh_trang._setSelectedID(doBugProduct.GetTINH_TRANG());
                memoVanDe.Text = doBugProduct.NAME;
                btnSave.Visible = !(IsAdd == null);
                //Not load this information when Reply Issue
                if (AfterAddReplyIssueSuccessfully == null && AfterUpdateReplyIssueSuccessfully == null)
                {
                    this.lblNguoiGui.Text = DMFWNhanVien.GetFullName(doBugProduct.NGUOI_GUI);
                    this.lblThoiGianGui.Text = doBugProduct.NGAY_GUI.ToString(PLConst.FORMAT_DATETIME_STRING);
                    this.NoiDung._setValue(doBugProduct.MO_TA_BUG);
                    this.NguoiNhan._SelectedStrIDs = doBugProduct.NGUOI_NHAN;
                    this.NguoiNhanEmail._SelectedStrIDs = doBugProduct.NGUOI_NHAN;
                    this.NoiDung._setValue(doBugProduct.MO_TA_BUG);
                    plMultiChoiceFiles1._DataSource = DALuuTruTapTin.Instance.GetTapTinByObjectID(_ID_Bug, 9);
                    if (Tinh_trang._getSelectedID() == 3 || DAReplyBugProduct.HasReplyIssue(doBugProduct.ID)) btnSave.Visible = false;
                    else btnSave.Visible = true;
                }
                else if(AfterUpdateReplyIssueSuccessfully != null){ 
                    if(_ID_Bug_Reply > 0){
                        doReplyBugProduct = DAReplyBugProduct.Instance.LoadAll(_ID_Bug_Reply);
                        this.lblNguoiGui.Text = DMFWNhanVien.GetFullName(doReplyBugProduct.NGUOI_GUI);
                        this.lblThoiGianGui.Text = doReplyBugProduct.NGAY_GUI.ToString();
                        this.NoiDung._setValue(doReplyBugProduct.NOI_DUNG);
                        this.NguoiNhan._SelectedStrIDs = doReplyBugProduct.NGUOI_NHAN;
                        this.NguoiNhanEmail._SelectedStrIDs = doReplyBugProduct.NGUOI_NHAN;
                        this.NoiDung._setValue(doReplyBugProduct.NOI_DUNG);
                        plMultiChoiceFiles1._DataSource = DALuuTruTapTin.Instance.GetTapTinByObjectID(_ID_Bug_Reply, 9);
                    }
                }                
            }
        }

        private void _InitControl()
        {
            HelpInputData.SetMaxLength(new object[] { memoVanDe, 200 });
            DABugProduct.ChonDuAn(loaiVanDe);
            DMLoaiVanDe.I.InitCtrl(loaiVanDe, IsAdd);
            HelpDanhMuc.ChonTinhTrang(Tinh_trang);
            AppCtrl.InitTreeChonNhanVien(NguoiNhan, true,false);
            NguoiNhan._AfterSelected += new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice.AfterSelected(NguoiNhan__AfterSelected);
            AppCtrl.InitTreeChonNhanVien(NguoiNhanEmail, true);
            PLGUIUtil.Customizebar_PLRichTextBox(NoiDung);
        }

        void NguoiNhan__AfterSelected(object sender, EventArgs e)
        {
            NguoiNhanEmail._SelectedIDs = NguoiNhan._SelectedIDs;            
        }

        void popupContainerEdit1_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
        }

        public void InitForm()
        {
            _InitControl();
        }

        #endregion

        #region Validate       
        private bool IsValidate()
        {
            Error.ClearErrors();
            HelpInputData.ShowRequiredError(Error,
                   new object[]{
                        loaiVanDe, "Loại vấn đề"
                        ,memoVanDe,"Vấn đề"                       
                    });
            if (Tinh_trang._getSelectedID() == -1)
                Tinh_trang.SetError(Error, "Vui lòng vào thông tin \"Tình trạng\" !");
            if (NguoiNhan._CountSelectedIDs==0 )
                NguoiNhan._SetError(Error, "Vui lòng vào thông tin \"Người nhận\" !");
            if (NoiDung._getValue().Length < 0 || NoiDung.richEditControl.Text.Trim() == "")
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Nội dung\"!");
                return false;
            }
            return !Error.HasErrors;
        }

        #endregion

        #region Xử lý nút

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (IsAdd == null)
                this.Close();
            else
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn đóng?") == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Thực hiện kiểm tra tính hợp lệ của dữ liệu và lưu
            #region GetData
            doBugProduct.NAME = memoVanDe.Text;
            doBugProduct.LOAI_VAN_DE = loaiVanDe._getSelectedID();
            doBugProduct.TINH_TRANG = Tinh_trang._getSelectedID();
            if (doBugProduct.NGUOI_GUI == 0)//Trường hợp thêm mới
                doBugProduct.NGUOI_GUI = FrameworkParams.currentUser.employee_id;
            try
            {
                doBugProduct.NGAY_GUI = System.Convert.ToDateTime(this.lblThoiGianGui.Text);
            }
            catch
            {
                doBugProduct.NGAY_GUI = System.Convert.ToDateTime(this.lblThoiGianGui.Text + "M");
            }
            doBugProduct.MO_TA_BUG = NoiDung._getValue();
            doBugProduct.NGUOI_NHAN = NguoiNhan._SelectedStrIDs;
            #endregion
            if (IsValidate())
            {
                List<long> lstUser = new List<long>(NguoiNhanEmail._SelectedIDs);
                string title = "";
                //Thêm người hỗ trợ vào danh sách gửi mail trong trường hợp ko chọn
                foreach (long id in NguoiNhan._SelectedIDs)
                    if (!lstUser.Contains(id))
                        lstUser.Add(id);
                if (NoiDung._getValue().Length > 0)
                {
                    if (IsAdd == true && AfterAddReplyIssueSuccessfully == null)
                    {
                        title = "Có vấn đề vừa được cập nhật.";
                        doBugProduct.DSFile = plMultiChoiceFiles1._DataSource;
                        if (!DABugProduct.Instance.Update(doBugProduct))
                            ErrorMsg.ErrorSave(this);
                        else
                        {
                            _ID_Bug = doBugProduct.ID;
                            if (AfterAddIssueSuccessfully != null) AfterAddIssueSuccessfully(doBugProduct);
                            HelpXtraForm.CloseFormNoConfirm(this);
                        }
                    }
                    else if (IsAdd == true && AfterAddReplyIssueSuccessfully != null)
                    {
                        title = "Có phản hồi vấn đề vừa được cập nhật.";

                        doReplyBugProduct = new DOReplyBugProduct(HelpGen.DT(), _ID_Bug
                            , FrameworkParams.currentUser.employee_id,NguoiNhan._SelectedStrIDs, DateTime.Now,
                            NoiDung._getValue());
                        doReplyBugProduct.DSFile = plMultiChoiceFiles1._DataSource;
                        if (!DAReplyBugProduct.Instance.Update(doReplyBugProduct))
                            ErrorMsg.ErrorSave(this);
                        else
                        {
                            AfterAddReplyIssueSuccessfully(doReplyBugProduct);
                            //Update status of issue if changed.
                            DABugProduct.UpdateStatusIssue(doBugProduct.ID, Tinh_trang._getSelectedID());
                            if (AfterUpdateStatusOfIssue != null) AfterUpdateStatusOfIssue(Tinh_trang._getSelectedID(),null);
                            HelpXtraForm.CloseFormNoConfirm(this);
                        }
                    }
                    else if (IsAdd == false && AfterUpdateReplyIssueSuccessfully == null)
                    {
                        title = "Có vấn đề vừa được cập nhật!";
                        doBugProduct.DSFile = plMultiChoiceFiles1._DataSource;
                        if (!DABugProduct.Instance.Update(doBugProduct))
                            ErrorMsg.ErrorSave(this);
                        else
                        {
                            if (AfterAddIssueSuccessfully != null) AfterAddIssueSuccessfully(doBugProduct);
                            if (AfterUpdateIssueSuccessfully != null) AfterUpdateIssueSuccessfully(doBugProduct);
                            if (AfterUpdateStatusOfIssue != null) AfterUpdateStatusOfIssue(Tinh_trang._getSelectedID(), new object[]{
                                loaiVanDe._getSelectedID(),memoVanDe.Text,Tinh_trang._getSelectedID()
                                ,HelpDB.getDatabase().GetSystemCurrentDateTime(),NguoiNhan._SelectedStrIDs});
                            HelpXtraForm.CloseFormNoConfirm(this);
                        }
                    }
                    else if (IsAdd == false && AfterUpdateReplyIssueSuccessfully != null)
                    {
                        title = "Có phản hồi vấn đề vừa được cập nhật!";
                        doReplyBugProduct = new DOReplyBugProduct(_ID_Bug_Reply, _ID_Bug
                            , FrameworkParams.currentUser.employee_id, NguoiNhan._SelectedStrIDs, DateTime.Now,
                            NoiDung._getValue());
                        doReplyBugProduct.DSFile = plMultiChoiceFiles1._DataSource;
                        if (!DAReplyBugProduct.Instance.Update(doReplyBugProduct))
                            ErrorMsg.ErrorSave(this);
                        else
                        {
                            AfterUpdateReplyIssueSuccessfully(doReplyBugProduct);
                            //Update status of issue if changed.
                            DABugProduct.UpdateStatusIssue(doBugProduct.ID, Tinh_trang._getSelectedID());
                            if (AfterUpdateStatusOfIssue != null) AfterUpdateStatusOfIssue(Tinh_trang._getSelectedID(), null);
                            HelpXtraForm.CloseFormNoConfirm(this);
                        }
                    }

                    if (lstUser.Count > 0)
                    {
                        AddressList To = new AddressList();

                        title = HelpStringBuilder.GetTitleMailNewPageper(title);
                        StringBuilder Subject = new StringBuilder();
                        IDataReader reader = FWDBService.LoadRecord("DM_LOAI_VAN_DE", "ID", this.loaiVanDe._getSelectedID());
                        using (reader)
                        {
                            if (reader.Read())
                            {
                                Subject.Append(string.Format(PLConst.DES_MAIL_VAN_DE, memoVanDe.Text, reader["NAME"].ToString(), lblNguoiGui.Text, NoiDung.richEditControl.HtmlText));
                            }
                        }
                        if (!lstUser.Contains(FrameworkParams.currentUser.employee_id))
                            lstUser.Add(FrameworkParams.currentUser.employee_id);
                        To = HelpZPLOEmail.GetAddressList(lstUser.ToArray());
                        HelpZPLOEmail.SendSmartHost(
                            HelpAutoOpenForm.GeneratingCodeFromForm(this, _ID_Bug),
                            title, null, To, null, null, Subject.ToString(), "");
                    }
                }
                else
                {
                    HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Mô tả vấn đề\"!");
                    return;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_ID_Bug != -2)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn muốn xóa?") == DialogResult.Yes)
                {
                    if (DABugProduct.Instance.Delete(_ID_Bug))
                    {
                        HelpMsgBox.ShowNotificationMessage("Bạn đã xóa thành công");
                    }
                    else ErrorMsg.ErrorSave(this);
                    this.Close();
                }
            }
            else
                HelpMsgBox.ShowNotificationMessage("Không cho phép xóa bug đã có phản hồi!");
        }

        private void btnThem_TT_Click(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Data Process
        /// <summary>
        /// Convert HTML to Text
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        private string HTMLtoText(string HTML)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string s = reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");
        }
        #endregion
    }
}