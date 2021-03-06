using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Core;
using DevExpress.XtraNavBar;
using DAO;


namespace office
{
    public partial class frmDoiTenNhom : XtraFormPL
    {            
        private DXErrorProvider error;
        private List<NavBarItem> _ListItem;
        public frmDoiTenNhom(List<NavBarItem> ListItem)
        {
            InitializeComponent();           
            error = new DXErrorProvider();
            this._ListItem = ListItem;
        }
        private void frmDoiTenNhom_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            GUIValidation.SetMaxLength(new object[] { 
                this.txtNew_name,100
            });
        }
        private void btnDong_Y_Click(object sender, EventArgs e)
        {
            GUIValidation.TrimAllData(new object[] { txtNew_name });
            if (GUIValidation.ShowRequiredError(error, new object[] { txtNew_name, "Tên nhóm" })) 
            {
                try
                {
                    if (DALoaiDanhBa.Instance.isDuplicateNameDirectory(this._ListItem, txtNew_name.Text))
                    {
                        error.SetError(txtNew_name, "Tên nhóm bị trùng.Vui lòng kiểm tra lại!");
                        return;
                    }
                    DALoaiDanhBa.New_Name = txtNew_name.Text;
                    this.Close();
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Đóng \"Đổi tên nhóm\" ?") == DialogResult.Yes)
                this.Close();
        }        
    }
}