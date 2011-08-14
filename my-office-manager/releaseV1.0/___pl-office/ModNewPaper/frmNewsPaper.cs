using System;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using DAO;
using DTO;
using System.Data;
using System.Collections.Generic;
using System.IO;

using ProtocolVN.DanhMuc;
namespace office
{
    
    public partial class frmNewsPaper : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmNewsPaper).FullName,
                HelpDebug.UpdateTitle("Quản lý tin tức", Status),
                ParentID, true,
                typeof(frmNewsPaper).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        public delegate void _AfterUpdateSuccessfully(DOTinTuc doTinTuc);
        public event _AfterUpdateSuccessfully AfterUpdateSuccessfully;
       
        public delegate void _AfterAddSuccessfully(DOTinTuc doTinTuc);
        public event _AfterAddSuccessfully AfterAddSuccessfully;
        private bool? IsAdd; //true:new,false:edit,null:view        
        private DOTinTuc doTinTuc = null;
        private int _maxFileSize = 20;
        private long _ID;
        private DXErrorProvider Error;
        private string pathSource = string.Empty;
        private string pathNew = string.Empty;
        public delegate void gridControlMasterUpdateHandler(object sender, DOTinTuc e);
        #endregion
       
        #region Các hàm khởi tạo
        public frmNewsPaper(long ID,bool? _isAdd)
        {
            InitializeComponent();
            TinTucPermission.I.Init();
            Error = new DXErrorProvider();
            this._ID = ID;
            this.IsAdd = _isAdd;
            PLTinTuc.ChonNhomTin(PLNhomTT, true);
            Duyet._init(true);
            HelpControl.RedCheckEdit(this.chkHieuLuc, false);
            FileDinhKem._Init(IsAdd,_maxFileSize);           
            InitData(_ID);
            Init_State(IsAdd);
            HelpXtraForm.SetCloseForm(this, this.btnDong, this.IsAdd);
            PLGUIUtil.Customizebar_PLRichTextBox(NoiDung);

        }

        public frmNewsPaper() : this(-2,true) { }
        public frmNewsPaper(object id) : this(HelpNumber.ParseInt64(id),null) { }
        #endregion

        #region Khởi tạo Data
        /// <summary>
        /// Khởi tạo dữ liệu 
        /// </summary>
        /// <param name="ID"></param>
        private void InitData(long ID)
        {
            try
            {
                if (this.IsAdd == true)
                {
                    doTinTuc = DATinTuc.Instance.LoadAll(-2);
                    lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id);
                    lblThoiGianCapNhat.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
                    doTinTuc.DUYET = "1";
                    this.seSoNgay.EditValue = null;
                }
                else
                {
                    doTinTuc = DATinTuc.Instance.LoadAll(ID);
                    lblNguoiCapNhat.Text = DMFWNhanVien.GetFullName(doTinTuc.NGUOI_CAP_NHAT);
                    lblThoiGianCapNhat.Text = doTinTuc.NGAY_CAP_NHAT.ToString(PLConst.FORMAT_DATETIME_STRING);
                    PLNhomTT._setSelectedID(doTinTuc.NHOM_TIN);
                    checkTin_noi_bat.Checked = (doTinTuc.PRIOR == "Y");
                    txtTieude.Text = doTinTuc.TIEU_DE;
                    // PLNoidung._setHTMLText(HelpByte.BytesToUTF8String(doTinTuc.NOI_DUNG));
                    //NoiDung._setValue(doTinTuc.NOI_DUNG);
                    ProtocolVN.App.Office.AppCtrl.SetRichText(NoiDung.richEditControl, doTinTuc.NOI_DUNG, false);


                    seSoNgay.Value = doTinTuc.SO_NGAY_HIEU_LUC;
                    if (seSoNgay.Value == 0)
                    {
                        this.chkHieuLuc.Checked = false;
                        this.seSoNgay.EditValue = null;
                        this.seSoNgay.Enabled = false;
                    }
                    else this.chkHieuLuc.Checked = true;
                }
                FileDinhKem._DataSource = doTinTuc.DSTapTinDinhKem;
                Duyet.SetDuyet(doTinTuc);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        /// <summary>
        /// Khởi tạo trạng thái cho các nút
        /// </summary>
        /// <param name="IsAdd"></param>
        private void Init_State(bool? IsAdd)
        {
            if (IsAdd == null)
            {
                btnSave.Visible = false;                
                btnDong.Visible = true;                
            }
            else if (IsAdd == false)
            {                
                btnSave.Visible = true;
                btnDong.Visible = true;
            }
            else
            {
                btnSave.Visible = true;
                btnDong.Visible = true;                
            }            
        }        
        #endregion

        #region InitForm
        private void frmTinTuc_Load(object sender, EventArgs e)
        {
            try
            {
                HelpXtraForm.SetFix(this);
                QueryBuilder query = new QueryBuilder(@"SELECT * FROM DM_NHAN_VIEN WHERE 1=1");
                query.addBoolean("VISIBLE_BIT", true);
                DataSet Employs = HelpDB.getDatabase().LoadDataSet(query);                
                List<long> IDs = new List<long>();
                foreach (DataRow row in Employs.Tables[0].Rows)
                {
                    IDs.Add(HelpNumber.ParseInt64(row["ID"]));
                }                
                GUIValidation.SetMaxLength(new object[] { 
                    txtTieude,200
                });
                PMSupport.SetTitle(this, Status);

                if (IsAdd == true)
                {
                    PLTinTuc.ChonNhomTin(PLNhomTT, IsAdd);
                    this.chkHieuLuc.Checked = true;
                }
               
                if (this.btnSave.Visible == true) {
                    //if (DATinTuc.Instance.getNguoiDuyet(143).Contains(FrameworkParams.currentUser.employee_id))
                      //  this.Duyet.Enabled = true;
                }
                //HelpXtraForm.SetFix(this);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }       
        #endregion
      
        #region Validate(ktra lỗi)

        public bool IsValidate()
        {           
            Error.ClearErrors();
            GUIValidation.ShowRequiredError(Error,
                   new object[]{
                        txtTieude,"Chủ đề"
                   }
            );
            if (PLNhomTT._getSelectedID() == -1) {
                PLNhomTT.SetError(Error, "Vui lòng vào thông tin \"Nhóm tin\"!");
            }
            //if (PLNoidung.BodyText != null || PLNoidung.Document.Images.Count > 0)
            if (NoiDung.richEditControl.Text.Trim()!= "" || NoiDung.richEditControl.Document.GetImages(NoiDung.richEditControl.Document.Range).Count>0)
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
                if (!Get_Data()) return;
                if (IsAdd == true)
                {
                    if (TinTucPermission.I._checkPermissionResGroup(doTinTuc.NHOM_TIN,
                        PermissionOfResource.RES_PERMISSION_TYPE.CREATE) == false)
                    {
                        HelpMsgBox.ShowNotificationMessage("Bạn không có quyền thêm tin tức vào nhóm tin tức đang chọn.");
                        return;
                    }
                }
                if (DATinTuc.Instance.Update(doTinTuc))
                {
                    try
                    {
                        if (IsAdd == true && AfterUpdateSuccessfully != null)
                            AfterUpdateSuccessfully(doTinTuc);
                        if (IsAdd == false && AfterAddSuccessfully != null)
                            AfterAddSuccessfully(doTinTuc);
                    }
                    catch { }
                    finally
                    {
                        PLGUIUtil.ClosePhieu(this, true);
                    }
                }
                else
                    HelpMsgBox.ShowNotificationMessage("Lưu không thành công !");
                if (IsAdd == true)
                {
                    if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.Duyet).ToString())
                        DATinTuc.Instance._SendThongBao(doTinTuc, "DUYET");
                    if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                        DATinTuc.Instance._SendThongBao(doTinTuc, "ADD");
                    if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.KhongDuyet).ToString())
                        DATinTuc.Instance._SendThongBao(doTinTuc, "KHONG_DUYET");
                }
                else
                {
                    if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.Duyet).ToString())
                        DATinTuc.Instance._SendThongBao(doTinTuc, "DUYET");
                    if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                        DATinTuc.Instance._SendThongBao(doTinTuc, "EDIT");
                    if (doTinTuc.DUYET == ((Int32)DuyetSupportStatus.KhongDuyet).ToString())
                        DATinTuc.Instance._SendThongBao(doTinTuc, "KHONG_DUYET");
                }
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn xóa không!") == DialogResult.Yes)
            {
                if (TinTucPermission.I._checkPermissionResGroup(doTinTuc.NHOM_TIN,
                           PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa tin tức này.");
                    return;
                }
                DATinTuc.Instance.Delete(doTinTuc.ID);
                this.Close();
            }
        }        

        #endregion  
           
        #region Các hàm chức năng 
        /// <summary>
        /// Lấy dữ liệu để cập nhật
        /// </summary>
        private bool Get_Data()
        {
            //Get data cho TIN_TUC
            doTinTuc.NHOM_TIN = PLNhomTT._getSelectedID();
            doTinTuc.TIEU_DE = txtTieude.Text;
            //doTinTuc.NOI_DUNG = HelpByte.UTF8StringToBytes(PLNoidung._getHTMLText());
            doTinTuc.NOI_DUNG = NoiDung._getValue();
            doTinTuc.NGAY_CAP_NHAT = HelpDB.getDatabase().GetSystemCurrentDateTime();
            doTinTuc.NGUOI_CAP_NHAT = FrameworkParams.currentUser.employee_id;
            doTinTuc.PRIOR = (checkTin_noi_bat.Checked == true ? "Y" : "N");
            doTinTuc.DSTapTinDinhKem = FileDinhKem._DataSource;
            if (this.seSoNgay != null)
                doTinTuc.SO_NGAY_HIEU_LUC = HelpNumber.ParseInt64(seSoNgay.EditValue);
            else doTinTuc.SO_NGAY_HIEU_LUC = 0;

            if (doTinTuc.DUYET == null)
                doTinTuc.DUYET = "1";
            
            //Get data cho LUU_TRU_TAP_TIN
            Duyet.GetDuyet(doTinTuc);
            
            //if (pathSource.IndexOf(@"\") > 0) {
            //    FileStream fs=null;
            //    try
            //    {
            //        fs = new FileStream(pathSource, FileMode.Open, FileAccess.Read);
            //    }
            //    catch (IOException ex) {
            //        if (ex.Message.ToString().IndexOf("The process cannot access the file") >= 0)
            //            HelpMsgBox.ShowNotificationMessage("Vui lòng đóng các ứng dụng đang truy cập đến tập tin này trước!");
            //        else
            //        {
            //            if (fs != null) fs.Close();
            //        }
            //        return false;
            //    }                
            //    do_luu_tru_tt.NOI_DUNG = HelpByte.FileToBytes(pathSource);
            //}        
            return true;
        }                        
                            
        #endregion

        private void btnTaptin_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void chkHieuLuc_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHieuLuc.Checked)
            {
                this.seSoNgay.Enabled = true;
                this.seSoNgay.EditValue = 30;
            }
            else {
                this.seSoNgay.EditValue = null;
                this.seSoNgay.Enabled = false;
            }
        }

        private void seSoNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (this.seSoNgay.EditValue != null && this.seSoNgay.Value == 0)
                this.seSoNgay.EditValue = null;
        }
    }
}