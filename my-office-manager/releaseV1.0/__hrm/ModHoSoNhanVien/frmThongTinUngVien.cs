using System;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DTO;
using System.Windows.Forms;
using System.IO;

namespace office
{
    public partial class frmThongTinUngVien : XtraFormPL
    {
        #region 1.0.Danh sách biến toàn cục
        public long Id = -2;
        #endregion

        #region 2.0.Hàm khởi tạo
        public frmThongTinUngVien(object id)
        {
            InitializeComponent();
            InitButtonImage();
            if (id != null)
            {
                Id = HelpNumber.ParseInt64(id);
            }
            HienThongTinUngVien(Id);
            
        }

        public void InitButtonImage()
        {
            btn_Dong.Image = FWImageDic.CLOSE_IMAGE20;
        }
        
        #endregion

        #region 4.0.Phần mở rộng

        #endregion

        #region 5.0.Phần giữ chỗ
        public void HienThongTinUngVien(long _Id)
        {
            if (_Id != -2)
            {
                try
                {
                    DOResume TTUngVien = DAResume.getUngVien(_Id);
                    string filename = Application.StartupPath;
                    filename = filename + @"\template\ThongTinUV.html";
                    DAResume.ThongTinResume(ThongTinUngVien, filename, TTUngVien);
                }
                catch (Exception ex)
                {
                    HelpMsgBox.ShowErrorMessage(ex.Message);
                }
                
            }
        }

        #endregion

        #region 6.0.Phần xử lý Validation
        public bool IsValidate()
        {
            return true;
        }
        #endregion

        private void frmThongTinUngVien_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetCloseForm(this, this.btn_Dong, null);
            this.WindowState = FormWindowState.Maximized;
            this.MaximizeBox = false;
            btn_Dong.Image = FWImageDic.CLOSE_IMAGE16;
        }

        private void KetSuatWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "word (*.doc)|*.doc";

            DialogResult Open = save.ShowDialog();
            if (Open == DialogResult.OK)
            {
                StreamWriter ghi = new StreamWriter(save.FileName);
                ghi.Write(ThongTinUngVien.DocumentText);
                ghi.Close();
            }
        }

        
        
    }
}