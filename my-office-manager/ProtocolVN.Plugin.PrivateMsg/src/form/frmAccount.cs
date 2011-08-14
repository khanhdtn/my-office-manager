using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace pl.mail
{
    enum Operation
    {
        New = 0,
        Edit = 1
    }
    public partial class frmAccount : DevExpress.XtraEditors.XtraForm
    {
        private string UserMail;
        private string Password;
        private string UserId;
        private int maxID = 0;
        private OleDbConnection conn;
        private OleDbDataAdapter da;
        private DataSet ds;
        private frmMessage formFather;
        private Operation state; //state = "Add" or "Edit"
        private bool testSuccessful = false ;
        private string NameOldFolder="";

        public frmAccount(frmMessage frmFather )
        {
            InitializeComponent();
            formFather = frmFather;
            //HUYLX : Set thông tin cấu hình
            UserMail =FrameworkParams.currentUser.username + "@" + Connect.domain;
            Password = FrameworkParams.currentUser.id + "_protocolvn";
            UserId = FrameworkParams.currentUser.id.ToString();
            frmAccount_load();
            cbTaiKhoan.EditValueChanged += new EventHandler(cbTaiKhoan_EditValueChanged);
            EnableControl(false);
            EnableButtonOpe(true);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private  void cbTaiKhoan_EditValueChanged(object sender, EventArgs e)
        {
            LoadDataSelect();
        }

        private void EnableControl(bool value)
        {
            txtTenThuMuc.Enabled = value;
            txtUserMail.Enabled = value;
            txtPassword.Enabled = value;
            txtSMTPHost.Enabled = value;
            txtPortSMTP.Enabled = value;
            ckSMTPSSL.Enabled = value;
            txtHost.Enabled = value;
            txtPort.Enabled = value;
            rbIMAP.Enabled = value;
            rbPOP.Enabled = value;
            ckSSL.Enabled = value;
        }
        private void frmAccount_load()
        {
            DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM MAILINFO WHERE IDUSER=" + UserId);
            ds = new DataSet();
            ds = DABase.getDatabase().LoadDataSet(command,"MAILINFO");
            foreach (DataRow dr in ds.Tables["MailInfo"].Rows)
                cbTaiKhoan.Properties.Items.Add(dr["UserMail"].ToString());
        }

        private void testAccount()
        {
            //Connect test = new Connect(txtSMTPHost.Text, int.Parse(txtPortSMTP.EditValue.ToString()), ckSMTPSSL.Checked,
            //                            txtHost.Text, int.Parse(txtPort.EditValue.ToString()), ckSSL.Checked,
            //                            txtUserMail.Text, txtPassword.Text);
            if ((formFather.FolderExist(txtTenThuMuc.Text))&(state !=Operation.Edit))
            {
                testSuccessful = false;
                return;
            }

            //if (!Connect.smtpAuthentication(txtSMTPHost.Text,HelpNumber.ParseInt32(txtPortSMTP.EditValue.ToString()), txtUserMail.Text,txtPassword.Text))
            //{
            //    testSuccessful = false;
            //    return;
            //}
            //else
            //    testSuccessful = true;


            if (rbIMAP.Checked)
            {
                string error = "";
                if (Connect.TestImapConnect(txtHost.Text,HelpNumber.ParseInt32(txtPort.EditValue.ToString()),txtUserMail.Text,txtPassword.Text,ref error))
                {
                    testSuccessful = true;               
                }
                else
                {
                    testSuccessful = false;
                    return;
                }
            }
            else
            {
                string error = "";
                if (Connect.TestPopConnect(txtHost.Text,HelpNumber.ParseInt32(txtPort.EditValue.ToString()),txtUserMail.Text,txtPassword.Text, ref error))
                {
                    testSuccessful = true;                    
                }
                else
                {
                    testSuccessful = false;
                    return;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            EnableButtonOpe(false);
            cbTaiKhoan.Text = cbTaiKhoan.Properties.NullText;
            cbTaiKhoan.Enabled = false;
            txtUserMail.Text = txtUserMail.Properties.NullText;
            txtPassword.Text = txtPassword.Properties.NullText;
            txtSMTPHost.Text = txtSMTPHost.Properties.NullText;
            txtPortSMTP. EditValue = 465;
            txtHost.Text = txtHost.Properties.NullText;
            txtPort.EditValue = 993;
            state = Operation.New;
        }
     

        private void LoadDataSelect()
        {
            try
            {
                DataRow[] dr = ds.Tables[0].Select("UserMail = '" + cbTaiKhoan.EditValue + "'");

                txtTenThuMuc.Text = dr[0]["Folder"].ToString();
                txtUserMail.Text = dr[0]["UserMail"].ToString();
                txtPassword.Text = dr[0]["Password"].ToString();
                txtSMTPHost.Text = dr[0]["HostSMTP"].ToString();
                txtPortSMTP.EditValue = dr[0]["PortSMTP"].ToString();
                ckSMTPSSL.Checked = (dr[0]["SSLSMTP"].ToString().Equals("Y") ? true : false);
                txtHost.Text = dr[0]["Host"].ToString();
                txtPort.EditValue = dr[0]["Port"];
                if (dr[0]["IsIMAP"].ToString().Equals("Y")) rbIMAP.Checked = true;
                else rbPOP.Checked = true;
                ckSSL.Checked = (dr[0]["SSL"].ToString().Equals("Y") ? true : false);
            }
            catch { }
        }



        private void btnXóa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = PLMessageBox.ShowConfirmMessage("Bạn có chắc muốn xóa không");
                if (result == DialogResult.Yes)
                {
                    (ds.Tables[0].Select("UserMail='" + cbTaiKhoan.EditValue.ToString() + "'"))[0].Delete();
                    formFather.DeleteFolder(txtTenThuMuc.Text);
                    if (DABase.getDatabase().UpdateTable(ds, "MAILINFO") > 0)
                    {
                        cbTaiKhoan.Properties.Items.Remove(cbTaiKhoan.EditValue);
                        txtTenThuMuc.Text = txtTenThuMuc.Properties.NullText;
                        cbTaiKhoan.Text = cbTaiKhoan.Properties.NullText;
                        txtUserMail.Text = txtUserMail.Properties.NullText;
                        txtPassword.Text = txtPassword.Properties.NullText;
                        txtSMTPHost.Text = txtSMTPHost.Properties.NullText;
                        txtPortSMTP.EditValue = 0;
                        txtHost.Text = txtHost.Properties.NullText;
                        txtPort.EditValue = 0;
                    }
                }
            }
            catch { }
        }
        private void EnableButtonOpe(bool value)
        {
            btnAdd.Enabled = value;
            btnXoa.Enabled = value;
            btnSua.Enabled = value;
            btnLuu.Enabled = !value;
            btnBoqua.Enabled = !value;
        }
        private void btnSữa_Click(object sender, EventArgs e)
        {
            EnableControl(true);
            cbTaiKhoan.Enabled = false;
            state = Operation.Edit;
            EnableButtonOpe(false);
            NameOldFolder = txtTenThuMuc.Text;
        }
        private void btCancel_Click_1(object sender, EventArgs e)
        {
            cbTaiKhoan.Enabled = true; 
            EnableControl(false);
            EnableButtonOpe(true);
            LoadDataSelect();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            WaitingMsg.LongProcess(testAccount);
            
            if (!testSuccessful)
            {
                PLMessageBox.ShowErrorMessage("Thông tin tài khoản không hợp lệ . Vui lòng kiểm tra lại !");
                return;
            }

            if (state == Operation.New)
            {
                DataRow newRow = ds.Tables[0].NewRow();
                newRow["ID"] = DABase.getDatabase().GetID(HelpGen.G_FW_DM_ID);
                newRow["UserMail"] = txtUserMail.Text;
                newRow["Folder"] = txtTenThuMuc.Text;
                newRow["IDUser"] = FrameworkParams.currentUser.id;
                newRow["Password"] = txtPassword.Text;
                newRow["HostSMTP"] = txtSMTPHost.Text;
                newRow["PortSMTP"] = HelpNumber.ParseInt32(txtPortSMTP.EditValue.ToString());
                if (ckSMTPSSL.Checked) newRow["SSLSMTP"] = "Y"; else newRow["SSLSMTP"] = "N";
                newRow["Host"] = txtHost.Text;
                newRow["Port"] = HelpNumber.ParseInt32(txtPort.EditValue.ToString());
                if (ckSSL.Checked) newRow["SSL"] = "Y"; else newRow["SSL"] = "N";
                if (rbIMAP.Checked) newRow["IsIMAP"] = "Y"; else newRow["IsIMAP"] = "N";
                ds.Tables[0].Rows.Add(newRow);
                if (DABase.getDatabase().UpdateTable(ds, "MAILINFO") > 0)
                {
                    cbTaiKhoan.Properties.Items.Add(txtUserMail.Text);
                    cbTaiKhoan.EditValue = txtUserMail.Text;
                    cbTaiKhoan.Enabled = true;
                    EnableControl(false);
                    EnableButtonOpe(true);
                }
                formFather.AddFolder(txtTenThuMuc.Text);
            }
            else
            {
                DataRow[] dr = ds.Tables[0].Select("UserMail = '" + cbTaiKhoan.EditValue.ToString() + "'");
                dr[0]["UserMail"] = txtUserMail.Text;
                dr[0]["Folder"] = txtTenThuMuc.Text;
                dr[0]["Password"] = txtPassword.Text;
                dr[0]["HostSMTP"] = txtSMTPHost.Text;
                dr[0]["PortSMTP"] = HelpNumber.ParseInt32(txtPortSMTP.EditValue.ToString());
                if (ckSMTPSSL.Checked) dr[0]["SSLSMTP"] = "Y"; else dr[0]["SSLSMTP"] = "N";
                dr[0]["Host"] = txtHost.Text;
                dr[0]["Port"] = HelpNumber.ParseInt32(txtPort.EditValue.ToString());
                if (ckSSL.Checked) dr[0]["SSL"] = "Y"; else dr[0]["SSL"] = "N";
                if (rbIMAP.Checked) dr[0]["IsIMAP"] = "Y"; else dr[0]["IsIMAP"] = "N";
                if (DABase.getDatabase().UpdateTable(ds, "MAILINFO") > 0)
                {
                    cbTaiKhoan.Properties.Items.Remove(cbTaiKhoan.EditValue);
                    cbTaiKhoan.Properties.Items.Add(txtUserMail.Text);
                    cbTaiKhoan.EditValue = txtUserMail.Text;
                    cbTaiKhoan.Enabled = true;
                    EnableControl(false);
                    EnableButtonOpe(true);
                }
                if (NameOldFolder != txtTenThuMuc.Text)
                    formFather.RenameFolder(NameOldFolder, txtTenThuMuc.Text);
            }
           
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTaiKhoan_EditValueChanged_1(object sender, EventArgs e)
        {
            if (cbTaiKhoan.EditValue != cbTaiKhoan.Properties.NullText)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
        }
    }
}