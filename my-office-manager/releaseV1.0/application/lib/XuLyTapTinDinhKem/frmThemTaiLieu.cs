using System;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using System.IO;
using System.Data.Common;
using DTO;
using DAO;

namespace office
{
    public partial class frmThemTaiLieu : XtraFormPL
    {
        public long _maxFilesize = 20;
        private DOLuuTruTapTin doLuuTruTapTin;
        private bool? _IsAdd;
        private bool _IsFilterWord;
        long[] _object_type;
        bool IS_bug;
        long ID_bug=0;
        long ID_DeAn = 0;
        private DXErrorProvider Error = new DXErrorProvider();

        //public delegate void UpdateTapTinHandler(object sender, DOLuuTruTapTin doLuuTruTapTin);
        //public event UpdateTapTinHandler UpdateTapTin_DuAn;
        //public event UpdateTapTinHandler UpdateTapTin_CongViec;
        //public event UpdateTapTinHandler UpdateTapTin_TaiLieu;
        //public event UpdateTapTinHandler UpdateTapTin_Meeting;
        //public event UpdateTapTinHandler UpdateTapTin_KhachHang;
        //public event UpdateTapTinHandler UpdateTapTin_VanDe;
        //public event UpdateTapTinHandler UpdateTapTin_PhanHoi;
        public delegate void VisibleButton();
        public VisibleButton frmMeeting_btnThemVanBan;
        #region InitForm
        public frmThemTaiLieu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Lưu trữ tập tin
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isadd"></param>
        /// <param name="object_type">Bắt buộc phải thêm.</param>
        public frmThemTaiLieu(long id, bool? isadd, params long[] object_type )
        {
            InitializeComponent();
            this._IsAdd = isadd;
            this._object_type = object_type;
            Invalidate();
            InitData(id);
            
        }
        public frmThemTaiLieu(long id, bool? isadd,bool IsFilterWord)
        {
            InitializeComponent();
            this._IsFilterWord = IsFilterWord;
            this._IsAdd = isadd;
            Invalidate();
            InitData(id);

        }
        public frmThemTaiLieu(long id, bool? isadd,long id_bug,bool is_bug)
        {
            InitializeComponent();
            this.IS_bug = is_bug;
            this.ID_bug = id_bug;
            this._IsAdd = isadd;
            Invalidate();
            InitData(id);
        }
        public frmThemTaiLieu(long id, bool? isadd, long id_DeAn)
        {
            InitializeComponent();
            this.ID_DeAn = id_DeAn;
            
            this._IsAdd = isadd;
            Invalidate();
            InitData(id);
        }

        private void InitValidation()
        {
            this.Error = GUIValidation.GetErrorProvider(this);
            GUIValidation.SetMaxLength(
                new object[]{
                        TieuDe, 400,
                        GhiChu, 2000
                    }
            );
           
        }
        public void InitData(long id)
        {
            doLuuTruTapTin = DALuuTruTapTin.Instance.Load(id);

            if (_IsAdd == true)
            {
                this.TieuDe.EditValue = "";
                this.FileDinhKem.EditValue = "";
                this.GhiChu.EditValue = "";
            }
            else if (this._IsAdd != true)
            {

                this.TieuDe.EditValue = doLuuTruTapTin.TIEU_DE;
                this.FileDinhKem.EditValue = doLuuTruTapTin.TEN_FILE;
                this.GhiChu.EditValue = doLuuTruTapTin.GHI_CHU;
                if (_IsAdd == null)
                {
                    this.TieuDe.Properties.ReadOnly = true;
                    this.GhiChu.Properties.ReadOnly = true;
                    this.btnLuu.Visible = false;
                    this.FileDinhKem.Properties.Buttons[0].Visible = false;
                }
            }
        }
      
        private void frmThemTaiLieu_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            this.FormClosing += delegate(object abc, FormClosingEventArgs eabc)
            {
                if (this.Tag != null && this.Tag.Equals("Q")) { eabc.Cancel = false; return; }
                if (_IsAdd == null) { eabc.Cancel = false; return; }
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes) eabc.Cancel = false;
                else eabc.Cancel = true;
            };
        }
        #endregion
        
        #region Validate
        public bool ValidateData()
        {
            bool flag = true;
            Error.ClearErrors();
            flag = GUIValidation.ShowRequiredError(Error,
                new object[]{
                        TieuDe, "Tiêu đề",
                        
                        
                    }
            );
            if (FileDinhKem.Text == "")
            {
                flag = false;
                Error.SetError(FileDinhKem, "Vui lòng vào thông tin \"File đính kèm\" !");
            }
            return flag;
        }
        public bool GetData()
        {
            GUIValidation.TrimAllData(new object[]{
                    TieuDe,
                    GhiChu
                });
            if (ValidateData())
            {
                doLuuTruTapTin.TIEU_DE = TieuDe.Text;
                doLuuTruTapTin.TEN_FILE = Path.GetFileName(FileDinhKem.Text);
                
                
                if (!FileIsRead(FileDinhKem.Text))
                {
                    HelpMsgBox.ShowErrorMessage("Tập tin này đang được sử dụng. Vui lòng đóng lại.");
                    return false;
                }
                if (FileDinhKem.Text != doLuuTruTapTin.TEN_FILE)
                    doLuuTruTapTin.NOI_DUNG = HelpByte.FileToBytes(FileDinhKem.Text);
                doLuuTruTapTin.NGUOI_CAP_NHAT = FrameworkParams.currentUser.employee_id;
                doLuuTruTapTin.NGAY_CAP_NHAT = HelpDB.getDatabase().GetSystemCurrentDateTime();
                doLuuTruTapTin.GHI_CHU = GhiChu.Text;
                return true;
            }
            return false;
        }
        public bool FileIsRead(string fullPath)
        {
            try
            {
                if (_IsAdd != false)
                    File.ReadAllBytes(fullPath);
                
            }
            catch
            {
                return false;
            }
            return true;            
        }
        #endregion

        #region Xử lý nút
        private void FileDinhKem_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn file đính kèm:";
            if (this._IsFilterWord) openFile.Filter = "Word Files|*.doc;*.docx";
            DialogResult value = openFile.ShowDialog();
            if (value == DialogResult.OK)
            {
                FileDinhKem.Text = openFile.FileName;
                //Kiểm tra độ lớn của file
                if (!HelpFile.CheckFileSize(FileDinhKem.Text, _maxFilesize))
                {
                    //Độ lớn của file lớn hơn độ lớn qui định
                    HelpMsgBox.ShowNotificationMessage("Bạn không được chọn file lớn hơn " + _maxFilesize.ToString() + "MB.");
                    FileDinhKem_Properties_ButtonClick(sender, e);
                }
            }
            else if (value == DialogResult.Cancel)
                return;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (GetData())
            {
                if (DALuuTruTapTin.Instance.Update(doLuuTruTapTin))
                {
                    if (_IsAdd == true)
                    {
                        if (DALuuTruTapTin.Instance.InputObject_Taptin(doLuuTruTapTin.ID, _object_type[0], _object_type[1]))
                        {
                            HelpXtraForm.CloseFormNoConfirm(this);
                        }
                        else
                        {
                            DALuuTruTapTin.Instance.Delete(doLuuTruTapTin.ID);
                            HelpMsgBox.ShowErrorMessage("Lưu thông tin không thành công!");
                        }
                    }
                    else
                    {
                        HelpXtraForm.CloseFormNoConfirm(this);
                    }
                }
                else
                    HelpMsgBox.ShowErrorMessage("Lưu thông tin không thành công!");
            }
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DALuuTruTapTin.Instance.Delete(doLuuTruTapTin.ID);
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn đóng") == DialogResult.Yes)
            {
                this.Tag = "Q";
                this.Close();
            }
        }
        #endregion
    }
}