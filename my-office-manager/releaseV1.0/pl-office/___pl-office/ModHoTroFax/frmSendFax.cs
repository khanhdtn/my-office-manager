using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using FAXCOMLib;

namespace office
{
    public partial class frmSendFax : XtraFormPL
    {
        private string _FileName;
        private string _RecipientName;
        private string _FaxNumber;
        private byte[] _NoiDungFile;
        public frmSendFax(string FileName, string RecipientName,string FaxNumber,byte[] NoiDungFile)
        {
            InitializeComponent();
            _FileName = FileName;
            _RecipientName = RecipientName;
            _FaxNumber = FaxNumber;
            _NoiDungFile = NoiDungFile;
        }

        private void frmSendFax_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetCloseForm(this, btnClose, null);
            HelpXtraForm.SetFix(this);
            txtNguoiNhan.Text = _RecipientName;
            txtGuiDenSo.Text = _FaxNumber;
            txtTenFile.Text = _FileName;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {                
                FAXCOMLib.FaxServer faxServer = new FAXCOMLib.FaxServerClass();
                faxServer.Connect(Environment.MachineName);
                //Create a temp file.
                string pathFile = FrameworkParams.TEMP_FOLDER + @"\" + _FileName;
                HelpByte.BytesToFile(_NoiDungFile, pathFile);
                //-------------------

                FAXCOMLib.FaxDoc faxDoc = (FAXCOMLib.FaxDoc)faxServer.CreateDocument(pathFile);

                faxDoc.RecipientName = _RecipientName;
                faxDoc.FaxNumber = _FaxNumber;

                int Response = faxDoc.Send();

                faxServer.Disconnect();

                //Delete the temp file.
                System.IO.File.Delete(pathFile);
                //---------------------
            }
            catch {
                HelpMsgBox.ShowNotificationMessage("Chưa cài đặt máy Fax.");
            }
        }
    }
}