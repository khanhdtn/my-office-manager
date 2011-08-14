using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DTO;
using DevExpress.XtraBars.Demos.BrowserDemo;
using System.Text.RegularExpressions;

using System.Drawing;

namespace office
{
    public partial class frmThemMoi : XtraFormPL
    {
        public delegate void Update_Grid();
        public Update_Grid Refresh_data;
        #region Vùng đặt Static 
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmThemMoi).FullName,
                PMSupport.UpdateTitle("Thêm mới", Status),
                ParentID, true,
                typeof(frmThemMoi).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến         
        private DOWebsite Phieu = null;
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _ID;
        private DXErrorProvider Error;   
        #endregion        

        #region Hàm dựng 
        public frmThemMoi(long ID, bool? IsAdd)
        {
            InitializeComponent();
            WebsitesPermission.I.Init();
            Error = new DXErrorProvider();            
            this.IsAdd = IsAdd;
            this._ID = ID;                        
            Phieu = DAWebsite.Instance.LoadAll(ID);
        }
        public frmThemMoi() : this(-2, true) { }
        #endregion

        #region InitForm  
        private void frmThemMoi_Load(object sender, EventArgs e)
        {
            PMSupport.SetTitle(this, Status);
            HelpXtraForm.SetFix(this);
            HelpXtraForm.SetCloseForm(this, btnDong, IsAdd);
            DAWebsite.InitChonPhanLoai(PhanLoai);
            GUIValidation.SetMaxLength(new object[] 
                    {
                        TxtLinkWeb,200,
                        MeMoTa,200
                    });
            #region Init control
            if (IsAdd == false || IsAdd == null)
            {
                PhanLoai._setSelectedID(Phieu.PhanLoai);
                TxtLinkWeb.Text = Phieu.DiaChi;
                MeMoTa.Text = Phieu.MoTa;
            }
            if (IsAdd == null)
            {
                btnSave.Visible = false;
            }
            else if (IsAdd == true)
            {
                PhanLoai.Focus();
            }
            #endregion
        }        
        #endregion             

        #region Xử lý nút 
        private void btnSave_Click(object sender, EventArgs e)   
        {
            Error.ClearErrors();
            #region Kiểm tra dữ liệu               
            if(!GUIValidation.ShowRequiredError(Error,new object[]
                {
                    PhanLoai,"Phân loại",
                    TxtLinkWeb,"Liên kết"
                })) return; 
            else
            {                
                Regex rg = new Regex(DAWebsite.RegexWebsite(TxtLinkWeb.Text));
                if (!rg.IsMatch(TxtLinkWeb.Text))
                {
                    Error.SetError(TxtLinkWeb, "Liên kết không hợp lệ,vui lòng kiểm tra lại!");
                    return;
                }
                //if (!Regex.IsMatch(TxtLinkWeb.Text, PLConst.EXPRESSION_WEBSITE)) {
                //    Error.SetError(TxtLinkWeb, "Liên kết không hợp lệ,vui lòng kiểm tra lại!");
                //    return;
                //}
            }
            if (!(PhanLoai._getSelectedID() != -1 && TxtLinkWeb.Text.Length != 0)) return;
                #endregion

            if (IsAdd == true && WebsitesPermission.I._checkPermissionResGroup(PhanLoai._getSelectedID(), PermissionOfResource.RES_PERMISSION_TYPE.CREATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền thêm liên kết vào phân loại website đang chọn!");
                return;
            }
            if (DAWebsite.Instance.CheckExists(Phieu,PhanLoai._getSelectedID(), TxtLinkWeb.Text,IsAdd))
            {
                Error.SetError(TxtLinkWeb, "Liên kết này đã tồn tại trong phân loại \"" + PhanLoai.Text + "\" !");
                return;
            }
                #region Lưu dữ liệu
                    Phieu.PhanLoai = PhanLoai._getSelectedID();
                    TxtLinkWeb.Text.Trim(); ;
                    MeMoTa.Text.Trim();
                    Phieu.DiaChi = TxtLinkWeb.Text;
                    Phieu.MoTa = MeMoTa.Text;
                    try
                    {
                        if (DAWebsite.Instance.Update(Phieu))
                        {
                            try
                            {
                                if (Refresh_data != null) Refresh_data();
                            }
                            catch { }
                            HelpXtraForm.CloseFormNoConfirm(this);
                        }
                    }
                    catch(Exception ex)
                    {
                        PLException.AddException(ex);
                        return;
                    }
                    #endregion                          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa?") == DialogResult.Yes)
            {
                if (WebsitesPermission.I._checkPermissionResGroup(Phieu.PhanLoai, PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa liên kết này!");
                    return;
                }
                if (!DAWebsite.Instance.Delete(Phieu.ID))
                    HelpMsgBox.ShowConfirmMessage("Xóa không thành công!");
                else
                    HelpXtraForm.CloseFormNoConfirm(this);
            }
        }
        #endregion
        private void TxtLinkWeb_EditValueChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(TxtLinkWeb.Text, DAWebsite.RegexWebsite(TxtLinkWeb.Text)))
            {
                TxtLinkWeb.ForeColor = Color.Blue;
                TxtLinkWeb.Font = new Font(TxtLinkWeb.Font, FontStyle.Underline);
            }
            else
            {
                TxtLinkWeb.ForeColor = Color.Black;
                TxtLinkWeb.Font = new Font(TxtLinkWeb.Font, FontStyle.Regular);
            }            
        }

        private void TxtLinkWeb_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(TxtLinkWeb.Text, DAWebsite.RegexWebsite(TxtLinkWeb.Text)))
            {
                frmWebBrowser frm = new frmWebBrowser(TxtLinkWeb.Text);
                frm.Show();
            }
        }

        private void TxtLinkWeb_MouseMove(object sender, MouseEventArgs e)
        {
            if (Regex.IsMatch(TxtLinkWeb.Text, DAWebsite.RegexWebsite(TxtLinkWeb.Text)))
            {
                if ((e.X + 1) / 5 <= TxtLinkWeb.Text.Length)
                    TxtLinkWeb.Cursor = Cursors.Hand;
                else TxtLinkWeb.Cursor = Cursors.Default;
            }    
        }                                  
    }
}