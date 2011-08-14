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
    
    public partial class frmBaiVietEtx : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmBaiVietEtx).FullName,
                PMSupport.UpdateTitle("Bài viết", Status),
                ParentID, true,
                typeof(frmBaiVietEtx).FullName,
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
        private long _ID=0;
        private DXErrorProvider Error;
        #endregion
       
        #region Các hàm khởi tạo
        public frmBaiVietEtx(DOBaiViet BaiViet, bool? IsAdd)
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
        public frmBaiVietEtx(long BaiVietID)
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
        public frmBaiVietEtx()
        {
            Init(null, true);
        }

        private void Init(DOBaiViet BaiViet, bool? IsAdd)
        {
            InitializeComponent();
            DienDanPermission.I.Init();
            this.IsAdd = IsAdd;
            InitControl();
            InitData(BaiViet);
            UpdateControl();
        }
     
        private void InitControl()
        {
            Error = new DXErrorProvider();
            plMultiChoiceFiles1._Init(IsAdd);
            PLDienDan.InitChonDienDan(PLNhomDienDan, true);
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
                }            
                doBaiViet.NGUOI_GUI = FrameworkParams.currentUser.employee_id;
                doBaiViet.NGAY_GUI = HelpDB.getDatabase().GetSystemCurrentDateTime();
            }
            else
            {
                doBaiViet = BaiViet;
            }
        }
        private void UpdateControl()
        {
            lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(doBaiViet.NGUOI_GUI);
            lblThoiGianCapNhat.Text = doBaiViet.NGAY_GUI.ToString(PLConst.FORMAT_DATETIME_STRING);
            txtTieude.Text = doBaiViet.CHU_DE;
            PLNhomDienDan._setSelectedID(doBaiViet.ID_NHOM_DIEN_DAN);
            PLChuyenMuc._setSelectedID(doBaiViet.ID_CHUYEN_MUC);
            //PLNoidung._setHTMLText(HelpByte.BytesToUTF8String(doBaiViet.NOI_DUNG));
          
            ProtocolVN.App.Office.AppCtrl.SetRichText(NoiDung.richEditControl, doBaiViet.NOI_DUNG,false);

            plMultiChoiceFiles1._DataSource = doBaiViet.DSTapTinDinhKem;
            if (doBaiViet.ID_BAI_VIET_PARENT <= 0 && DABaiViet.Instance.Da_tra_loi(doBaiViet.ID))
            {
                PLNhomDienDan.Enabled = false;
                PLChuyenMuc.Enabled = false;
                txtTieude.Enabled = false;
            }
        }
        #endregion

        #region Khởi tạo Data
     

       
        #endregion

        #region InitForm
        private void frmTinTuc_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            GUIValidation.SetMaxLength(new object[]{
                txtTieude,200});                                                                                                            
            PMSupport.SetTitle(this, Status);            

            if (IsAdd == true)
            {
            }
            PLGUIUtil.Customizebar_PLRichTextBox(NoiDung);
        }
        #endregion
      
        #region Validate(ktra lỗi)

        public bool IsValidate()
        {
            Error.ClearErrors();
            GUIValidation.ShowRequiredError(Error,
                   new object[]{
                        PLNhomDienDan, "Nhóm diễn đàn",
                        PLChuyenMuc,"Chuyên mục",
                        txtTieude,"Chủ đề"
                   }
            );
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
                    if (IsAdd == true && 
                        DienDanPermission.I._checkPermissionRes(doBaiViet.ID_CHUYEN_MUC, 
                        PermissionOfResource.RES_PERMISSION_TYPE.CREATE) == false)
                    {
                        HelpMsgBox.ShowNotificationMessage("Bạn không quyền có thêm bài viết vào chuyên mục đang chọn!");
                        return;
                    }
                    if (DABaiViet.Instance.Update(doBaiViet) )
                    {                        
                        try
                        {                          
                            if (IsAdd == true && AfterAddSuccesfully != null)
                            {
                                AfterAddSuccesfully(doBaiViet);
                            }
                            if (IsAdd == false && AfterUpdateSuccesfully != null)
                                AfterUpdateSuccesfully(this.NoiDung.richEditControl,doBaiViet);
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
                if (this.doBaiViet.ID_BAI_VIET_PARENT <= 0 &&
                DienDanPermission.I._checkPermissionRes(doBaiViet.ID_CHUYEN_MUC, PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa bài viết này!");
                    return;
                }
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
            doBaiViet.ID_NHOM_DIEN_DAN = PLNhomDienDan._getSelectedID();
            doBaiViet.ID_CHUYEN_MUC = PLChuyenMuc._getSelectedID();
            doBaiViet.NOI_DUNG = NoiDung._getValue();// HelpByte.UTF8StringToBytes(PLNoidung._getHTMLText());
            doBaiViet.NGAY_GUI = HelpDB.getDatabase().GetSystemCurrentDateTime();
            doBaiViet.NGUOI_GUI = FrameworkParams.currentUser.employee_id;
            doBaiViet.CHU_DE = txtTieude.Text;           
            doBaiViet.DSTapTinDinhKem = plMultiChoiceFiles1._DataSource;
           
        }
        private void PLNhomDienDan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PLDienDan.InitChonChuyenMuc(PLChuyenMuc, PLNhomDienDan._getSelectedID());
                PLChuyenMuc.Enabled = PLNhomDienDan._getSelectedID() != -1 ? true : false;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        private void btnTaptin_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }   
        #endregion        
       
       
    }
}