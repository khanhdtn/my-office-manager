using System;
using System.Drawing;

namespace office
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private String _userName = "";
        private String _passWord = "";
        public frmDangNhap()
        {
            InitializeComponent();
        }

   
        public String getUserName()
        {
            return this._userName;
        }
        public String getPassWord()
        {
            return this._passWord;
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.Location = new Point(500, 300);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            _userName = txtUserName.Text;
            _passWord = txtPassWord.Text;
            this.Close();
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}