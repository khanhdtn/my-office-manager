using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using DAO;
using DTO;
using ProtocolVN.DanhMuc;


namespace office
{

    public partial class frmReplyForum : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmReplyForum).FullName,
                PMSupport.UpdateTitle("Bài viết", Status),
                ParentID, true,
                typeof(frmReplyForum).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến

        public delegate void _AfterAddSuccesfully(DOBaiViet BaiViet);
        public event _AfterAddSuccesfully AfterAddSuccesfully;
        public delegate void _AfterUpdateSuccesfully(DevExpress.XtraRichEdit.RichEditControl sender, DOBaiViet BaiViet);
        public event _AfterUpdateSuccesfully AfterUpdateSuccesfully;
        public delegate void _AfterDeleteSuccesfully(DOBaiViet BaiViet);
        public event _AfterDeleteSuccesfully AfterDeleteSuccesfully;

        private bool? IsAdd; //true:new,false:edit,null:view        
        private DOBaiViet doBaiViet = null;
        private DXErrorProvider Error;
        private bool TrichDan = false;
        #endregion

        #region Các hàm khởi tạo
        public frmReplyForum(DOBaiViet BaiViet, bool? IsAdd)
        {
            if (BaiViet != null)
            {
                Init(BaiViet, IsAdd);
            }
            else
            {
                Init(null, true);
            }
        }
        public frmReplyForum(long BaiVietID)
        {
            if (BaiVietID <= -2)
            {
                Init(null, true);
            }
            else
            {
                Init(DABaiViet.Instance.LoadAll(BaiVietID), false);
            }
        }
        public frmReplyForum()
        {
            Init(null, true);
        }
        public frmReplyForum(bool TrichDan, DOBaiViet BaiViet)
        {
            this.TrichDan = TrichDan;
            Init(BaiViet, true);
        }
        private void Init(DOBaiViet BaiViet, bool? IsAdd)
        {
            InitializeComponent();
            this.IsAdd = IsAdd;
            InitControl();
            InitData(BaiViet);
            UpdateControl(BaiViet);
        }

        private void InitControl()
        {
            Error = new DXErrorProvider();
            plMultiChoiceFiles1._Init(IsAdd);
            NoiDung.richEditControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;

            if (this.IsAdd == true)
            {
                btnLuu.Enabled = true;
                btnClose.Enabled = true;
                btnXoa.Enabled = false;
            }
            else if (IsAdd == null)
            {
                btnLuu.Enabled = false;
                btnClose.Enabled = true;
                btnXoa.Enabled = false;
            }
            else if (IsAdd == false)
            {
                btnXoa.Enabled = true;
                btnLuu.Enabled = true;
                btnClose.Enabled = true;
            }
        }
        private void InitData(DOBaiViet BaiViet)
        {
            if (IsAdd == true)
            {
                doBaiViet = DABaiViet.Instance.LoadAll(-2);
                if (BaiViet != null)
                {
                    doBaiViet.CHU_DE = BaiViet.CHU_DE;
                    doBaiViet.ID_CHUYEN_MUC = BaiViet.ID_CHUYEN_MUC;
                    doBaiViet.ID_NHOM_DIEN_DAN = BaiViet.ID_NHOM_DIEN_DAN;
                    if (BaiViet.ID_BAI_VIET_PARENT <= 0)
                        doBaiViet.ID_BAI_VIET_PARENT = BaiViet.ID;
                    else doBaiViet.ID_BAI_VIET_PARENT = BaiViet.ID_BAI_VIET_PARENT;

                    if (TrichDan)
                    {
                        doBaiViet.NOI_DUNG = BaiViet.NOI_DUNG;

                    }

                }
                doBaiViet.NGUOI_GUI = FrameworkParams.currentUser.employee_id;
                doBaiViet.NGAY_GUI = HelpDB.getDatabase().GetSystemCurrentDateTime();
            }
            else
            {
                doBaiViet = BaiViet;
            }
        }
        private void UpdateControl(DOBaiViet BaiViet)
        {
            //PLNoidung._setHTMLText(HelpByte.BytesToUTF8String(doBaiViet.NOI_DUNG));
            if (doBaiViet.NOI_DUNG != null)
            {
                string name = "";
                if (TrichDan)
                {
                    name = DMFWNhanVien.GetFullName(BaiViet.NGUOI_GUI);
                    NoiDung.richEditControl.Text = name;
                    name = NoiDung.richEditControl.RtfText;
                    int lastcf0 = name.LastIndexOf(@"{\cf0");
                    name = name.Substring(lastcf0 + 6, name.IndexOf(@"}\par}") - lastcf0 - 6);
                    NoiDung.richEditControl.RtfText = "";
                }
                ProtocolVN.App.Office.AppCtrl.SetRichText(NoiDung.richEditControl, doBaiViet.NOI_DUNG, false);
                if (TrichDan)
                {
                    foreach (DevExpress.XtraRichEdit.API.Native.Paragraph p in NoiDung.richEditControl.Document.Paragraphs)
                    {
                        p.LeftIndent = p.LeftIndent + 70;
                    }
                    string hed = DefaultRichText.HeaderRTF.Replace("@@Name#", name).Replace("@@Date#", BaiViet.NGAY_GUI.ToString(FrameworkParams.option.DateTimeFomat));
                    NoiDung.richEditControl.Document.InsertRtfText(NoiDung.richEditControl.Document.Range.Start, hed);
                    NoiDung.richEditControl.Document.InsertParagraph(NoiDung.richEditControl.Document.Range.End);
                    NoiDung.richEditControl.Document.InsertRtfText(NoiDung.richEditControl.Document.Range.End, DefaultRichText.FooterRTF);
                }
            }
            plMultiChoiceFiles1._DataSource = doBaiViet.DSTapTinDinhKem;
        }
        #endregion

        #region Khởi tạo Data



        #endregion

        #region InitForm
        private void frmTinTuc_Load(object sender, EventArgs e)
        {

            PMSupport.SetTitle(this, Status);


        }
        #endregion

        #region Validate(ktra lỗi)

        public bool IsValidate()
        {
            Error.ClearErrors();

            if (NoiDung.richEditControl.Text.Trim() != "" || NoiDung.richEditControl.Document.GetImages(NoiDung.richEditControl.Document.Range).Count > 0)
                return !Error.HasErrors;
            else
            {
                HelpMsgBox.ShowNotificationMessage("Vui lòng vào thông tin \"Nội dung\"!");
                return false;
            }
        }
        #endregion

        #region Xử lý nút

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                Get_Data();
                if (DABaiViet.Instance.Update(doBaiViet))
                {
                    try
                    {
                        if (IsAdd == true && AfterAddSuccesfully != null)
                        {
                            AfterAddSuccesfully(doBaiViet);
                        }
                        if (IsAdd == false && AfterUpdateSuccesfully != null)
                            AfterUpdateSuccesfully(this.NoiDung.richEditControl, doBaiViet);
                    }
                    catch (Exception ex) { HelpMsgBox.ShowConfirmMessage(ex.ToString()); }
                    finally
                    {
                        HelpXtraForm.CloseFormNoConfirm(this);

                    }
                }
                else
                    HelpMsgBox.ShowNotificationMessage("Lưu không thành công !");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn xóa không!") == DialogResult.Yes)
            {
                if (DABaiViet.Instance.Delete(doBaiViet.ID))
                {
                    if (AfterDeleteSuccesfully != null)
                        AfterDeleteSuccesfully(doBaiViet);
                    this.Close();
                }
                else
                {
                    HelpPhieuMsg.ErrorDeleted();
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn đóng ?") == DialogResult.Yes)
                this.Close();
        }

        #endregion

        #region Các hàm chức năng
        /// <summary>
        /// Lấy dữ liệu để cập nhật
        /// </summary>
        private void Get_Data()
        {
            //Get data cho BAI_VIET
            doBaiViet.NOI_DUNG = NoiDung._getValue();// HelpByte.UTF8StringToBytes(PLNoidung._getHTMLText());
            doBaiViet.NGAY_GUI = HelpDB.getDatabase().GetSystemCurrentDateTime();
            doBaiViet.DSTapTinDinhKem = plMultiChoiceFiles1._DataSource;

        }

        #endregion


    }
    internal class DefaultRichText
    {
        public static string HeaderRTF = @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}{\*\cs2\sbasedon1\cf0 Line Number;}{\*\cs3\ul\cf1\ulc1 Hyperlink;}}\sectd\pard\plain\ql{\cf0 _________________________________________________________________________________________}\par\pard\plain\ql{\i\cf0 ""}{\i\cf0 Ng\u432\'75\u7901\'3fi th\u7843\'3fo lu\u7853\'3fn:}{\b\i\cf0  @@Name#}\i\par\pard\plain\ql{\i\cf0 Th\u7901\'3fi gian c\u7853\'3fp nh\u7853\'3ft:}{\b\i\cf0  @@Date#}{\i\cf0 ""}\par}";
        public static string FooterRTF = @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}{\*\cs2\sbasedon1\cf0 Line Number;}{\*\cs3\ul\cf1\ulc1 Hyperlink;}}\sectd\pard\plain\ql{\cf0 _________________________________________________________________________________________}\par}";
        //public static string FooterTXT = @"_________________________________________________________________________________________";
    }
}