using System;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace office
{
    public partial class frmSaveOpen : XtraFormPL
    {
        #region Các khai báo biến 
        private byte[] _TT_dinh_kem;
        private string _Ten_tap_tin = string.Empty;
        string P_source = string.Empty;
        int i = 0;
        #endregion

        #region Hàm khởi tạo
        public frmSaveOpen(byte[] TT_dinh_kem, string Ten_tap_tin)
        {
            InitializeComponent();
            this._TT_dinh_kem = TT_dinh_kem;
            this._Ten_tap_tin = Ten_tap_tin;
        }
        private void frmSaveOpen_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            i = this._Ten_tap_tin.LastIndexOf('.');
        }        
        #endregion

        #region Các hàm xử lý nút
        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string Path_new = FrameworkParams.TEMP_FOLDER + @"\" + _Ten_tap_tin;
                HelpByte.BytesToFile(_TT_dinh_kem, Path_new);
                HelpFile.OpenFile(Path_new);
            }
            catch
            {
                HelpMsgBox.ShowNotificationMessage("Tập tin đã bị xóa hoặc không tồn tại !");
            }
            this.Close();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = -1;
            saveFileDialog1.AddExtension = false;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Save as";
            saveFileDialog1.InitialDirectory = FrameworkParams.TEMP_FOLDER + @"\";
            saveFileDialog1.FileName = this._Ten_tap_tin;

            string[] M = this._Ten_tap_tin.Split('.');
            string type = M[M.Length - 1];

            saveFileDialog1.Filter = "Media files(*." + type + ")|*." + type + "|All file(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    HelpByte.BytesToFile(this._TT_dinh_kem, saveFileDialog1.FileName + this._Ten_tap_tin.Substring(i, this._Ten_tap_tin.Length - i));
                }
                catch
                {
                    HelpMsgBox.ShowNotificationMessage("Lưu tập tin không thành công !");
                }
                this.Close();
            }
            else
                this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
       
       
    }
}