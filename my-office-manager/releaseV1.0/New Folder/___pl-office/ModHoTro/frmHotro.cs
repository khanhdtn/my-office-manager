using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using ProtocolVN.DanhMuc;

using System.Collections.Generic;
using ProtocolVN.App.Office;
using LumiSoft.Net.Mime;
using System.Text;


namespace office
{
    public partial class frmHotro : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmHotro).FullName,
                PMSupport.UpdateTitle("Tạo mới", Status),
                ParentID, true,
                typeof(frmHotro).FullName,
                false, IsSep, "add.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến 
        private DXErrorProvider Error;
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _YEU_CAU_ID, _NguoiGuiID, _TinhTrang, _YEU_CAU_TL_ID;
        private string _NguoiNhanID;
        DataTable Bang_yeu_cau;
        public delegate void _AfterUpdateSupportSuccesfully(DOYeuCau doYeuCau);
        public event _AfterUpdateSupportSuccesfully AfterUpdateSupportSuccesfully;

        public delegate void _AfterAddReplySuccesfully(DOPhanHoi doPhanHoi);
        public event _AfterAddReplySuccesfully AfterAddReplySuccesfully;

        public delegate void _AfterUpdateReplySuccesfully(DOPhanHoi doPhanHoi);
        public event _AfterUpdateReplySuccesfully AfterUpdateReplySuccesfully;

        public delegate void _AfterUpdateStatusOfSupport(long TinhTrang, object[] infos);
        public event _AfterUpdateStatusOfSupport AfterUpdateStatusOfSupport;

        public delegate void RefreshData(DOYeuCau doYeuCau);
        public event RefreshData RefreshAfterInsert;
        
        #endregion        

        #region Hàm dựng 
        public frmHotro(long ID, long NguoiGuiID, string NguoiNhanID, long TinhTrang, bool? IsAdd,params long[] YeuCauTL_ID) {
            InitializeComponent();
            this.IsAdd = IsAdd;
            _YEU_CAU_ID = ID;
            _YEU_CAU_TL_ID = YeuCauTL_ID.Length > 0 ? YeuCauTL_ID[0] : -1;
            _NguoiGuiID = NguoiGuiID;
            _NguoiNhanID = NguoiNhanID;
            _TinhTrang = TinhTrang;
            Error = new DXErrorProvider();
            lblNguoiYeuCau.Text = "Người phản hồi";
            lblTGYeuCau.Text = "Thời gian phản hồi";
            lblNguoiGui.Text = DMNhanVienX.I.GetEmployeeFullName(FrameworkParams.currentUser.employee_id);
            PLLoaiYeuCau.Enabled = txtChude.Enabled = PLMucuutien.Enabled = false;
        }
        public frmHotro(long ID,bool? IsAdd)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            this._YEU_CAU_ID = ID;
            Error = new DXErrorProvider();
        }
        public frmHotro(object ID)
            : this(HelpNumber.ParseInt64(ID), null)
        {
        }
        public frmHotro() : this(-2, true) { }
        #endregion

        #region InitForm 
        private void frmHotroSupport_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            HelpDebug.SetTitle(this, Status);
            AppCtrl.InitTreeChonNhanVien(NguoiHoTro, true,false);
            AppCtrl.InitTreeChonNhanVien(NguoiNhanEmail, true);
            NguoiHoTro._AfterSelected += delegate(object senderr, EventArgs ee)
            {
                NguoiNhanEmail._SelectedIDs = NguoiHoTro._SelectedIDs;
            };

            HelpInputData.SetMaxLength(new object[] { 
                txtChude,200
            });
            lblThoiGianGui.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            HelpDanhMuc.ChonTinhTrangXuLy(PLTinhtrang);
            PLTinhtrang._init(DAYeuCau.Bang_tinh_trang(), "NAME", "ID");
            DMCMucDoUuTien.I.InitCtrl(PLMucuutien, false, true);
            DMLoaiYeuCau.I.InitCtrl(PLLoaiYeuCau, true, true);
            if (IsAdd == true && AfterAddReplySuccesfully == null)
            {
                lblNguoiGui.Text = DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id);
                PLTinhtrang._setSelectedID(1);
            }
            else if (IsAdd == null) btnLuu.Visible = false;
            else btnLuu.Visible = true;
            plMultiChoiceFiles1._Init(IsAdd);
            plMultiChoiceFiles1._DataSource = DALuuTruTapTin.Instance.GetTapTinByObjectID(-2, -2);
            Hien_thi_yeu_cau();
            PLGUIUtil.Customizebar_PLRichTextBox(NoiDung);
            PLTinhtrang.SelectedIndexChanged += new EventHandler(PLTinhtrang_SelectedIndexChanged);
        }

        void PLTinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAdd == true && AfterUpdateReplySuccesfully == null
                && AfterAddReplySuccesfully == null) PLTinhtrang._setSelectedID(1);
        }

        #endregion

        #region Validate 

        private bool IsValidate()
        {
            bool flag;
            Error.ClearErrors();
            flag = HelpInputData.ShowRequiredError(Error,
                   new object[]{
                        PLLoaiYeuCau, "Loại yêu cầu",                       
                        txtChude,"Yêu cầu"                        
                    }
               );            
            if (PLMucuutien._getSelectedID() == -1)            
                PLMucuutien.SetError(Error, "Vui lòng vào thông tin \"Độ ưu tiên\" !");            
            if (PLTinhtrang._getSelectedID() == -1)            
                PLTinhtrang.SetError(Error, "Vui lòng vào thông tin \"Tình trạng\" !");
            if (NguoiHoTro._CountSelectedIDs==0)
                NguoiHoTro._SetError(Error, "Vui lòng vào thông tin \"Người hỗ trợ\" !");
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
                    this.Close();
            }                     
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                //try...catch dùng trong TH người dùng chọn định dạng giờ của hệ thống trong đó có chứa "t"(AM/PM)
                try
                {
                    System.Convert.ToDateTime(lblThoiGianGui.Text);
                }
                catch {
                    lblThoiGianGui.Text += "M";
                }
                
                List<long> lstUser = new List<long>(NguoiNhanEmail._SelectedIDs);
                DataTable dt = new DataTable();
                string title = "";
                //Thêm người hỗ trợ vào danh sách gửi mail trong trường hợp ko chọn
                foreach (long id in NguoiHoTro._SelectedIDs)
                    if (!lstUser.Contains(id))
                        lstUser.Add(id);
                //----------------------
                if (IsAdd == true && AfterAddReplySuccesfully == null)
                {
                    try
                    {
                        title = "Có yêu cầu hỗ trợ mới được cập nhật";
                        if (DAYeuCau.Insert(out _YEU_CAU_ID, FrameworkParams.currentUser.employee_id, System.Convert.ToDateTime(lblThoiGianGui.Text), NguoiHoTro._SelectedStrIDs, PLTinhtrang._getSelectedID(), PLLoaiYeuCau._getSelectedID(), PLMucuutien._getSelectedID()
                            , txtChude.Text, NoiDung._getValue(), plMultiChoiceFiles1._DataSource))
                            HelpXtraForm.CloseFormNoConfirm(this);
                    }
                    catch
                    {
                        ErrorMsg.ErrorSave(this);
                    }
                }
                //Save in case ReplySupport.
                else if (IsAdd == true && AfterAddReplySuccesfully != null)
                {
                    DateTime currentDate = HelpDB.getDatabase().GetSystemCurrentDateTime();
                    DOPhanHoi doPhanHoi = new DOPhanHoi(_YEU_CAU_ID, FrameworkParams.currentUser.employee_id,NguoiHoTro._SelectedStrIDs , currentDate, NoiDung._getValue(), FrameworkParams.currentUser.employee_id, currentDate);
                    doPhanHoi.DSTapTinDinhKem = plMultiChoiceFiles1._DataSource;
                    if (DAPhanHoi.Insert(doPhanHoi))
                    {
                        title = "Có phản hồi yêu cầu hỗ trợ mới được cập nhật";
                        HelpXtraForm.CloseFormNoConfirm(this);
                        AfterAddReplySuccesfully(doPhanHoi);
                        //Update status of Support
                        DAYeuCau.UpdateTinhTrangYeuCau(_YEU_CAU_ID, PLTinhtrang._getSelectedID());
                        if (AfterUpdateStatusOfSupport != null) AfterUpdateStatusOfSupport(PLTinhtrang._getSelectedID(), null);
                    }
                    else
                        ErrorMsg.ErrorSave(this);

                }
                else if (IsAdd == false)
                {
                    if (AfterAddReplySuccesfully == null && AfterUpdateReplySuccesfully == null)
                    {
                        title = "Có yêu cầu hỗ trợ mới được cập nhật";
                        DOYeuCau doYeuCau = new DOYeuCau(this._YEU_CAU_ID, FrameworkParams.currentUser.employee_id
                            , NguoiHoTro._SelectedStrIDs, PLLoaiYeuCau._getSelectedID()
                            , HelpNumber.ParseInt32(PLMucuutien._getSelectedID())
                            , txtChude.Text.ToString(), NoiDung._getValue(), System.Convert.ToDateTime(lblThoiGianGui.Text), FrameworkParams.currentUser.employee_id, DateTime.Now, HelpNumber.ParseInt32(PLTinhtrang._getSelectedID()));
                        if (DAYeuCau.Update(this._YEU_CAU_ID, NguoiHoTro._SelectedStrIDs, PLTinhtrang._getSelectedID(), PLLoaiYeuCau._getSelectedID(), PLMucuutien._getSelectedID(), txtChude.Text, NoiDung._getValue(), plMultiChoiceFiles1._DataSource))
                        {
                            if (this.RefreshAfterInsert != null) this.RefreshAfterInsert(doYeuCau);
                            if (AfterUpdateSupportSuccesfully != null) AfterUpdateSupportSuccesfully(doYeuCau);
                            if (AfterUpdateStatusOfSupport != null) AfterUpdateStatusOfSupport(PLTinhtrang._getSelectedID()
                                , new object[]{PLLoaiYeuCau._getSelectedID(),txtChude.Text
                                    ,PLMucuutien._getSelectedID(),NguoiHoTro._SelectedStrIDs,System.Convert.ToDateTime(lblThoiGianGui.Text)});
                            HelpXtraForm.CloseFormNoConfirm(this);
                        }
                        else ErrorMsg.ErrorSave(this);
                    }
                    else
                    {
                        DateTime currentDate = HelpDB.getDatabase().GetSystemCurrentDateTime();
                        DOPhanHoi doPhanHoi = new DOPhanHoi(_YEU_CAU_ID, FrameworkParams.currentUser.employee_id, NguoiHoTro._SelectedStrIDs, currentDate, NoiDung._getValue(), FrameworkParams.currentUser.employee_id, currentDate);
                        doPhanHoi.ID = _YEU_CAU_TL_ID;
                        doPhanHoi.DSTapTinDinhKem = plMultiChoiceFiles1._DataSource;
                        if (DAPhanHoi.Update(doPhanHoi))
                        {
                            title = "Có phản hồi yêu cầu hỗ trợ mới được cập nhật";
                            HelpXtraForm.CloseFormNoConfirm(this);
                            doPhanHoi.DSTapTinDinhKem = plMultiChoiceFiles1._DataSource;
                            if (AfterUpdateReplySuccesfully != null) AfterUpdateReplySuccesfully(doPhanHoi);
                            //Update status of Support
                            DAYeuCau.UpdateTinhTrangYeuCau(_YEU_CAU_ID, PLTinhtrang._getSelectedID());
                            if (AfterUpdateStatusOfSupport != null) AfterUpdateStatusOfSupport(PLTinhtrang._getSelectedID(), null);
                        }
                        else ErrorMsg.ErrorSave(this);
                    }
                }
                //Gửi mail
                if (lstUser.Count > 0 )
                {
                    AddressList To = new AddressList();

                    title = HelpStringBuilder.GetTitleMailNewPageper(title);
                    StringBuilder Subject = new StringBuilder();
                    IDataReader reader = FWDBService.LoadRecord("DM_LOAI_YEU_CAU", "ID", this.PLLoaiYeuCau._getSelectedID());
                    using (reader)
                    {
                        if (reader.Read())
                        {
                            Subject.Append(string.Format(PLConst.DES_MAIL_YCHT, txtChude.Text, reader["NAME"].ToString(), lblNguoiGui.Text, NoiDung.richEditControl.HtmlText));
                        }
                    }
                    if (!lstUser.Contains(FrameworkParams.currentUser.employee_id))
                        lstUser.Add(FrameworkParams.currentUser.employee_id);
                    To = HelpZPLOEmail.GetAddressList(lstUser.ToArray());
                    HelpZPLOEmail.SendSmartHost(
                        HelpAutoOpenForm.GeneratingCodeFromForm(this, _YEU_CAU_ID),
                        title, null, To, null, null, Subject.ToString(), "");
                }
                //-----------------------------------------
            }
        }

        #endregion
       
        #region Data Process 

        /// <summary>
        /// Display data from YEU_CAU table
        /// </summary>
        /// 
        private void Hien_thi_yeu_cau()
        {
            Bang_yeu_cau = DAYeuCau.Get_Bang_yeu_cau(this._YEU_CAU_ID);
            if (Bang_yeu_cau.Rows.Count == 0) return;
            PLLoaiYeuCau._setSelectedID(HelpNumber.ParseInt64(Bang_yeu_cau.Rows[0]["Loai_yeu_cau_ID"].ToString()));
            txtChude.Text = Bang_yeu_cau.Rows[0]["Chu_de"].ToString();
            PLTinhtrang._setSelectedID(HelpNumber.ParseInt64(Bang_yeu_cau.Rows[0]["Tinh_Trang"].ToString()));
            PLMucuutien._setSelectedID(HelpNumber.ParseInt64(HelpNumber.ParseInt64(Bang_yeu_cau.Rows[0]["Muc_uu_tien"].ToString())));
            if (AfterAddReplySuccesfully == null && AfterUpdateReplySuccesfully == null)// Not load this information in case ReplySupport.
            {
                lblNguoiGui.Text = DMFWNhanVien.GetFullName(HelpNumber.ParseInt64(Bang_yeu_cau.Rows[0]["Nguoi_gui_ID"]));
                lblThoiGianGui.Text = Convert.ToDateTime(Bang_yeu_cau.Rows[0]["Ngay_gui"].ToString()).ToString(PLConst.FORMAT_DATETIME_STRING);
                NguoiHoTro._SelectedStrIDs = Bang_yeu_cau.Rows[0]["NGUOI_NHAN_ID"].ToString();
                NguoiNhanEmail._SelectedStrIDs = Bang_yeu_cau.Rows[0]["NGUOI_NHAN_ID"].ToString();
                if (Bang_yeu_cau.Rows[0]["Noi_dung"].ToString().Length != 0)
                    NoiDung._setValue((byte[])Bang_yeu_cau.Rows[0]["Noi_dung"]);
                plMultiChoiceFiles1._DataSource = DALuuTruTapTin.Instance.GetTapTinByObjectID(_YEU_CAU_ID, 10);
                //Tình trạng là hoàn tất hoặc đã có phản hồi thì không cho chỉnh sửa.
                if (PLTinhtrang._getSelectedID() == 4 || HelpNumber.ParseInt32(Bang_yeu_cau.Rows[0]["SO_PHAN_HOI"]) > 0)
                    btnLuu.Visible = false;
                else btnLuu.Visible = true;
            }
            else if (AfterUpdateReplySuccesfully != null)
            {
                if (_YEU_CAU_TL_ID > 0)
                {
                    DataTable Bang_yeu_cau_TL = DAYeuCau.Get_Bang_yc_tra_loi(_YEU_CAU_TL_ID);
                    lblNguoiGui.Text = DMFWNhanVien.GetFullName(HelpNumber.ParseInt64(Bang_yeu_cau_TL.Rows[0]["Nguoi_gui_ID"]));
                    lblThoiGianGui.Text = Convert.ToDateTime(Bang_yeu_cau_TL.Rows[0]["Ngay_gui"].ToString()).ToString(PLConst.FORMAT_DATETIME_STRING);
                    NguoiHoTro._SelectedStrIDs = Bang_yeu_cau_TL.Rows[0]["NGUOI_NHAN_ID"].ToString();
                    NguoiNhanEmail._SelectedStrIDs = Bang_yeu_cau.Rows[0]["NGUOI_NHAN_ID"].ToString();
                    if (Bang_yeu_cau_TL.Rows[0]["Noi_dung"].ToString().Length != 0)
                        NoiDung._setValue((byte[])Bang_yeu_cau_TL.Rows[0]["Noi_dung"]);
                    plMultiChoiceFiles1._DataSource = DALuuTruTapTin.Instance.GetTapTinByObjectID(_YEU_CAU_TL_ID, 10);
                }
            }
        }

        /// <summary>
        /// Convert HTML to String
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        /// 
        private string Convert_String(string HTML)
        {
            string []tag={"</A>","</EM>","</U>","</FONT>","</STRONG>","</P>","</body>"};
            //Delete tags </A>,</EM>,</U>...
            for (int i = 0; i < tag.Length; i++)
            {
                if (HTML.IndexOf(tag[i]) > 0)
                {
                    HTML = HTML.Remove(HTML.IndexOf(tag[i]));
                }
            }
            //Delete tag <IMG>
            while(HTML.IndexOf("<IMG")>0)
            {   
                char[] Str = HTML.ToCharArray();
                int i = HTML.IndexOf("<IMG");
                for (int j = i; j < HTML.Length; j++)
                {
                    if (Str[j] == '>')
                    {
                        HTML = HTML.Remove(i, j - i + 1);
                        break;
                    }
                }
            }
            //Delete tag <A>
            while(HTML.IndexOf("<A")>0)
            {
                char[] Str = HTML.ToCharArray();
                int i = HTML.IndexOf("<A");
                for (int j = i; j < HTML.Length; j++)
                {
                    if (Str[j] == '>')
                    {
                        HTML = HTML.Remove(i, j - i + 1);
                        break;
                    }
                }
            }
            HTML=HTML.Remove(0,HTML.LastIndexOf('>')+1);
            return HTML;
        }
        /// <summary>
        /// Convert HTML to Text
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        private string HTMLtoText(string HTML)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string s=reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");            
        }

        #endregion
    }
}