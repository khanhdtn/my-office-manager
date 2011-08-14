using System;
using System.Data;
using System.IO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace pl.mail
{
    public partial class frmConfigServer : DevExpress.XtraEditors.XtraForm
    {
        private int Login = 0;
        private Connect connect;
        //HUYLX: Lay thong tin file mailserver tu framework
        private string fileName = FrameworkParams.CONF_FOLDER + "/mailserver.cpl";
        private frmMessage parentForm;
        private bool connectSuccess = false;

        public frmConfigServer(frmMessage parent)
        {
            InitializeComponent();
            this.parentForm = parent;
        }

        private bool CreateFileConfigMail()
        {
            try
            {
                string content = @"<?xml version='1.0' encoding='utf-8' ?> 
                                    <Config>
                                      <Host>localhost</Host> 
                                      <Domain>example.com</Domain>
                                      <Port>143</Port> 
                                      <PortSMTP>25</PortSMTP> 
                                      <SSL>0</SSL> 
                                      <SSLSMTP>0</SSLSMTP> 
                                      <Login>0</Login>  
                                      </Config>";
                return ConfigFile.WriteXML(fileName, content);
            }
            catch { return false; }
        }

        private void frmConfigServer_Load(object sender, EventArgs e)
        {
            if (!File.Exists(fileName))
                CreateFileConfigMail();

            DataSet ds = new DataSet();
            ConfigFile.ReadXML(fileName, ds);

            txtMailServer.Text =  ds.Tables[0].Rows[0]["Host"].ToString();
            txtDomain.Text = ds.Tables[0].Rows[0]["Domain"].ToString();
            spPort.EditValue = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["Port"].ToString());
            spPortSMTP.EditValue = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["PortSMTP"].ToString());
            chkSSL.Checked = ((ds.Tables[0].Rows[0]["SSL"].ToString().Equals("0")) ? false : true);
            chkSSLSMTP.Checked = ((ds.Tables[0].Rows[0]["SSLSMTP"].ToString().Equals("0")) ? false : true);
            switch (HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["Login"].ToString()))
            {
                case 0: 
                    CENormal.Checked = true;
                    break;
                case 1:
                    CESimple.Checked = true;
                    break;
                case 2:
                    CEPrefix.Checked = true;
                    break;
            }
        }


        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            string error="";
            //HUYLX: UserMail va Password lay tu framework.

            connect = new Connect(txtMailServer.Text, HelpNumber.ParseInt32(spPortSMTP.EditValue.ToString()), 
                chkSSLSMTP.Checked, txtMailServer.Text, HelpNumber.ParseInt32(spPort.EditValue.ToString()),
                chkSSL.Checked, FrameworkParams.currentUser.username+"@"+txtDomain.Text,
                FrameworkParams.currentUser.id.ToString() + "_protocolvn", Login);
            if (connect.TestConnectServer(ref error))
            {
                PLMessageBox.ShowNotificationMessage("Kết nối với máy chủ thành công");
                connectSuccess = true;
            }
            else
            {
                if (error == "Server")
                    PLMessageBox.ShowErrorMessage("Kết nối với máy chủ không thành công");
                else
                    PLMessageBox.ShowErrorMessage("Bạn không thể đăng nhập với server");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string content = @"<?xml version='1.0' encoding='utf-8' ?> 
                                    <Config>
                                      <Host>" + txtMailServer.Text + "</Host> " +
                                      "<Port>" + spPort.EditValue.ToString() + "</Port> " +
                                      "<Domain>" + txtDomain.Text +"</Domain> " +
                                      "<PortSMTP>" + spPortSMTP.EditValue.ToString() + "</PortSMTP> " +
                                      "<SSL>" + ((chkSSL.Checked) ? "1" : "0") + "</SSL> " +
                                      "<SSLSMTP>" + ((chkSSLSMTP.Checked) ? "1" : "0") + "</SSLSMTP> " +
                                      "<Login>" + Login + "</Login>" +
                                      "</Config>";
                ConfigFile.WriteXML(fileName, content);
            }
            catch { }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (!connectSuccess)
                parentForm.closeform();
        }



        private void CENormal_CheckedChanged(object sender, EventArgs e)
        {
            if (CENormal.Checked)
            {
                CESimple.Checked = false;
                CEPrefix.Checked = false;
                Login = 0;
            }
        }

        private void CESimple_CheckedChanged(object sender, EventArgs e)
        {
            if (CESimple.Checked)
            {
                CENormal.Checked = false;
                CEPrefix.Checked = false;
                Login = 1;
            }
        }

        private void CEPrefix_CheckedChanged(object sender, EventArgs e)
        {
            if (CEPrefix.Checked)
            {
                CENormal.Checked = false;
                CESimple.Checked = false;
                Login = 2;
            }
        }

        
    }
}