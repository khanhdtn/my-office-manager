using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;

namespace office
{
    public partial class frmAutoOpenForm : DevExpress.XtraEditors.XtraForm
    {
        #region Vùng đặt Static
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmAutoOpenForm).FullName,
               "Mở màn hình",
                ParentID, true,
                typeof(frmAutoOpenForm).FullName,
                false, IsSep, "navDiemGiaoNhan.png", true, "", "");
        }
        #endregion
        public frmAutoOpenForm()
        {
            InitializeComponent();
            
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            labelControl1.Text = "";
            if (txtCode.Text.Trim() != "")
            {
                if (HelpAutoOpenForm.OpenFormFromCode(txtCode.Text) == false)
                    labelControl1.Text = "Không tìm thấy màn hình phù hợp với đoạn mã cần mở!";
            }
            else
            {
                labelControl1.Text = "Vui lòng nhập đoạn mã để mở màn hình!";
            }
            if (labelControl1.Text != "")
                timer1.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAutoOpenForm_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelControl1.Text = "";
            timer1.Stop();
        }
    }
}