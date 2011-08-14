using System;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using System.IO;
using DAO;
using DTO;

namespace office
{
    public partial class frmTapTinInAn : XtraFormPL
    {
        #region khai báo biến
        public long _maxFilesize = 20;
        private DOLuuTruTapTin doLuuTruTapTin = new DOLuuTruTapTin();
        private DOTapTinInAn doTapTinInAn = new DOTapTinInAn();
        private DOTapTin_TapTinInAn do_InAn = new DOTapTin_TapTinInAn();
        private bool? _IsAdd = true;
        private long _ID;
        private long _ID_TapTin;
        private long _ID_HoTroInAn;
        private DXErrorProvider Error = new DXErrorProvider();
        public delegate void UpdateTapTinHandler(object sender, DOTapTin_TapTinInAn do_InAn);
        public event UpdateTapTinHandler UpdateTapTinIn;
        private bool is_new_file = false;
        #endregion

        #region InitForm
        public frmTapTinInAn()
        {
            InitializeComponent();
        }
        public frmTapTinInAn(long id_tt,long ID_HoTroInAn, bool? isadd,DOTapTin_TapTinInAn do_TT_IN)
        {
            InitializeComponent();
            this._IsAdd = isadd;         
            this._ID_TapTin = id_tt;
            this._ID_HoTroInAn = ID_HoTroInAn;
            do_InAn = do_TT_IN;
            if (id_tt != -2)
            {
                Invalidate();
                InitData();
            }
        }
        public void InitData()
        {
            try
            {
                doLuuTruTapTin = DALuuTruTapTin.Instance.Load(_ID_TapTin);
                doTapTinInAn = DATapTinInAn.Instance.Load(_ID_TapTin, _ID_HoTroInAn);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            if (_IsAdd == true)
            {
                this.FileDinhKem.EditValue = "";
                this.GhiChu.EditValue = "";
            }
            if (_IsAdd == false)
            {
                if (do_InAn == null)
                {
                    this.FileDinhKem.EditValue = doLuuTruTapTin.TEN_FILE;
                    this.GhiChu.EditValue = doLuuTruTapTin.GHI_CHU;
                    this.spinSo_ban.Value = doTapTinInAn.SO_TO;
                }
                else
                {
                    this.FileDinhKem.EditValue = do_InAn.TEN_FILE;
                    this.GhiChu.EditValue = do_InAn.GHI_CHU;
                    this.spinSo_ban.Value = do_InAn.SO_TO;
                }
            }
            if (_IsAdd == null)
            {
                this.GhiChu.Properties.ReadOnly = true;
                this.btnLuu.Visible = false;
                this.FileDinhKem.Properties.Buttons[0].Visible = false;
            }
        }
        private void frmThemTaiLieu_Load(object sender, EventArgs e)
        {
            ApplyFormatAction.applyElement(spinSo_ban.Properties, 0);

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

            if (FileDinhKem.Text == "")
            {
                flag = false;
                Error.SetError(FileDinhKem, "Vui lòng vào thông tin \"File đính kèm\" !");
            }
            if (spinSo_ban.Value < 1 || spinSo_ban.Value > 99999999999999) //Max dưới db decimal 15
            {
                flag = false;
                Error.SetError(spinSo_ban, "Vui lòng nhập vào \"Số bản in\" từ 1 đến 99.999.999.999.999!");
            }
            return flag;
        }
        public bool GetData()
        {
            do_InAn = new DOTapTin_TapTinInAn();
            GUIValidation.TrimAllData(new object[]{
                    GhiChu
                });
            if (ValidateData())
            {
                do_InAn.TEN_FILE = Path.GetFileName(FileDinhKem.Text);
                do_InAn.HO_TRO_IN_AN_ID = _ID_HoTroInAn;
                do_InAn.SO_TO = spinSo_ban.Value;
                do_InAn.YEU_CAU =GhiChu.Text;
                if (_ID_TapTin == -2)
                { _ID_TapTin = HelpDB.getDatabase().GetID("G_NGHIEP_VU"); }
                do_InAn.ID = _ID_TapTin;
                if (is_new_file)
                {
                    if (!FileIsRead(FileDinhKem.Text))
                    {
                        HelpMsgBox.ShowErrorMessage("Tập tin này đang được sử dụng. Vui lòng đóng lại");
                        return false;
                    }
                }
                //if (FileDinhKem.Text != do_InAn.TEN_FILE)
                do_InAn.NOI_DUNG = HelpFile.FileToBytes(FileDinhKem.Text);
                do_InAn.NGUOI_CAP_NHAT = FrameworkParams.currentUser.employee_id;
                do_InAn.NGAY_CAP_NHAT = HelpDB.getDatabase().GetSystemCurrentDateTime();
                do_InAn.GHI_CHU = GhiChu.Text;
                return true;
            }
            return false;
        }
        public static bool FileIsRead(string fullPath)
        {
            try
            {
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
            DialogResult value = openFile.ShowDialog();
            if (value == DialogResult.OK)
            {
                is_new_file = true;                
                //Kiểm tra độ lớn của file
                if (!HelpFile.CheckFileSize(openFile.FileName, _maxFilesize))
                {
                    //Độ lớn của file lớn hơn độ lớn qui định
                    HelpMsgBox.ShowNotificationMessage("Bạn không được chọn file lớn hơn " + _maxFilesize.ToString() + "MB.");
                    //FileDinhKem.Text = "";
                    FileDinhKem_Properties_ButtonClick(sender, e);
                }
                else { FileDinhKem.Text = openFile.FileName; }
            }
            else if (value == DialogResult.Cancel)
                return;
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (GetData())
            {
                FWWaitingMsg m = new FWWaitingMsg();
                try
                {                    
                    if (UpdateTapTinIn != null)
                    {
                        this.UpdateTapTinIn(_IsAdd, do_InAn);
                        this.Tag = "Q";
                        HelpXtraForm.CloseFormNoConfirm(this);
                    }
                    else
                    {                        
                        //HelpMsgBox.ShowNotificationMessage("Lưu không thành công.");
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                    ErrorMsg.ErrorSave(this);
                }
                finally
                {
                    m.Finish();
                }
            }
        }        

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DALuuTruTapTin.Instance.Delete(do_InAn.ID);
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn đóng?") == DialogResult.Yes)
            {
                this.Tag = "Q";
                this.Close();
            }
        }
        #endregion                                  
    }
}