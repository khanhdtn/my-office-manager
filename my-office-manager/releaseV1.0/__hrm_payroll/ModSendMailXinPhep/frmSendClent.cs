using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Core;
using LumiSoft.Net.Mime;
using LumiSoft.Net.SMTP.Client;
using System.Net;
using System.IO;
using DevExpress.XtraEditors.DXErrorProvider;
/*
 * Tác giả : Trần Văn Châu
 */
namespace office
{
    public enum SendType
    {
        SmartHost = 1,
        DNS = 2
    }

    public partial class frmSendClient : XtraFormPL
    {
        public DXErrorProvider errorProvider;

        public frmSendClient()
        {
            InitializeComponent();
            this.InitControls();
            this.InitDOData();
            cmbSendType.SelectedIndexChanged += new EventHandler(cmbSendType_SelectedIndexChanged);
            this.errorProvider = new DXErrorProvider();
            PLGUIUtil.setDefaultSize(this);
        }

        private void InitControls() {
            DMNhanVienX.I.InitCtrl(cmbFrom, true, true);
            cmbCC._init(this.GetListMail().Tables[0], "NAME", "ID");
            cmbTo._init(this.GetListMail().Tables[0], "NAME", "ID");
            cmbFrom._init(this.GetListMail().Tables[0], "NAME", "ID");
            HelpXtraForm.SetCloseForm(this, this.btnClose, null);
            
            DataSet dsSendType = new DataSet();
            DataTable tbSendType = new DataTable("SEND_TYPE");
            tbSendType.Columns.Add("ID", typeof(System.Int64));
            tbSendType.Columns.Add("NAME", typeof(System.String));
            tbSendType.Rows.Add(1, "Smart Host");
            tbSendType.Rows.Add(2, "Direct with DNS");
            dsSendType.Tables.Add(tbSendType);
            cmbSendType._init(dsSendType.Tables["SEND_TYPE"], "NAME", "ID");
            cmbFrom._setSelectedID(FrameworkParams.currentUser.id);
        }

        private void InitDOData() {
            this.cmbSendType._setSelectedID((Int64)SendType.SmartHost);
            this.textSmartHost.Text = "protocolvn.net";
            cmbSendType.Enabled = false;
        }

        private bool CheckValidation(){
            bool bFlag = true;
            this.errorProvider.ClearErrors();
            bFlag = GUIValidation.ShowRequiredError(this.errorProvider, new object[] { 
                    this.textSmartHost,this.lblSmartHost.Text,
                    this.textSubject,"Tiêu đề"
                });

            if (this.cmbFrom._getSelectedID() == -1)
            {
                this.errorProvider.SetError(this.cmbFrom.imgCombo, @"Vui lòng chọn Người gửi.");
                bFlag = false;
            }
            if (this.cmbSendType._getSelectedID() == -1)
            {
                this.cmbSendType.SetError(this.errorProvider, "Send Type");
                bFlag = false;
            }
            if (this.cmbTo._getSelectedIDs().Length == 0) {
                bFlag = false;
                this.errorProvider.SetError(this.cmbTo, "Vui lòng chọn Người nhận.");
            }
            return bFlag;
        }

        private Mime CreateMessage() {

            Mime m = new Mime();
            MimeEntity texts_enity = null;
            MimeEntity attachments_entity = null;

            ///Văn bản
            if (pathFile.Text.Trim()!=string.Empty)
            {
                m.MainEntity.ContentType = MediaType_enum.Multipart_mixed;
                texts_enity = m.MainEntity.ChildEntities.Add();
                texts_enity.ContentType = MediaType_enum.Multipart_alternative;
                attachments_entity = m.MainEntity;

                MimeEntity attachment_entity = attachments_entity.ChildEntities.Add();
                attachment_entity.ContentType = MediaType_enum.Application_octet_stream;
                attachment_entity.ContentTransferEncoding = ContentTransferEncoding_enum.Base64;
                attachment_entity.ContentDisposition = ContentDisposition_enum.Attachment;
                attachment_entity.ContentDisposition_FileName = Path.GetFileName(pathFile.Text);
                attachment_entity.Data = File.ReadAllBytes(pathFile.Text);
            }
            else {
                m.MainEntity.ContentType = MediaType_enum.Multipart_alternative;
                texts_enity = m.MainEntity;    
            }

            ///Thông tin mail
            m.MainEntity.From = this.GetAddressList(new long[] {this.cmbFrom._getSelectedID()});
            m.MainEntity.To = this.GetAddressList(cmbTo._getSelectedIDs());
            m.MainEntity.Subject = this.textSubject.Text;
            if (cmbCC._getSelectedIDs().Length > 0)
            {
                m.MainEntity.Cc = this.GetAddressList(cmbCC._getSelectedIDs());
            }
            m.MainEntity.Bcc = this.GetAddressList(new long[] { this.cmbFrom._getSelectedID() });
            
            ///Nội dung
            MimeEntity text_entity = texts_enity.ChildEntities.Add();
            text_entity.ContentType = MediaType_enum.Text_plain;
            text_entity.ContentType_CharSet = "utf-8";
            text_entity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
            text_entity.DataText = this.PLNoidung._getHTMLText();

            MimeEntity rtfText_entity = texts_enity.ChildEntities.Add();
            rtfText_entity.ContentType = MediaType_enum.Text_html;
            rtfText_entity.ContentType_CharSet = "utf-8";
            rtfText_entity.ContentTransferEncoding = ContentTransferEncoding_enum.Base64;
            rtfText_entity.DataText = this.PLNoidung._getHTMLText();

            return m;
        }

        private AddressList GetAddressList(long []Keys ) {
            QueryBuilder query = new QueryBuilder(@"SELECT e.NAME, cat.USERID as ID, cat.USERNAME FROM USER_CAT cat left join DM_NHAN_VIEN e on e.ID=cat.EMPLOYEE_ID WHERE 1=1");
            query.addBoolean("e.VISIBLE_BIT", true);
            query.addID("cat.USERID", Keys);
            DataSet dsTo = HelpDB.getDatabase().LoadDataSet(query, "CAT");

            AddressList to = new AddressList();
            foreach (DataRow row in dsTo.Tables[0].Rows)
            {
                to.Add(new MailboxAddress(row["NAME"].ToString(), row["USERNAME"].ToString() + "@" + this.textSmartHost.Text));
            }
            return to;
        }

        private DataSet GetListMail() {
            QueryBuilder query = new QueryBuilder(@"SELECT e.NAME, cat.USERID as ID, cat.USERNAME FROM USER_CAT cat left join DM_NHAN_VIEN e on e.ID=cat.EMPLOYEE_ID WHERE 1=1");
            query.addBoolean("e.VISIBLE_BIT", true);
            query.addCondition(@"(cat.USERNAME<>'')");
            DataSet dsTo = HelpDB.getDatabase().LoadDataSet(query);
            return dsTo;
        }

        #region Sự kiện

        private void btnSend_Click(object sender, EventArgs e)
        {
            GUIValidation.TrimAllData(new object[] { 
                this.textSubject,
                this.textSmartHost
            });

            if (!this.CheckValidation())
                return;
            this.Cursor = Cursors.WaitCursor;
            bool bFlag = true;
            try
            {
                FrameworkParams.wait = new WaitingMsg();
                Mime message = CreateMessage();
                if (cmbSendType._getSelectedID() == (Int64)SendType.SmartHost)
                {
                    SmtpClientEx.QuickSendSmartHost(this.textSmartHost.Text, 25, "",message);
                }
                else if (cmbSendType._getSelectedID()== (Int64)SendType.DNS)
                {
                    using (SmtpClientEx smtp = new SmtpClientEx())
                    {
                        smtp.DnsServers = new string[] { this.textSmartHost.Text};
                        IPAddress[] ips = smtp.GetDestinations(this.textSmartHost.Text);
                        SmtpClientEx.QuickSendSmartHost(ips[0].ToString(), 25, "", message);
                    }
                }
            }
            catch (Exception ex)
            {
                HelpMsgBox.ShowErrorMessage("Gửi mail không thành công.\nVui lòng kiểm tra lại thông tin hoặc dữ liệu đang được sử dụng!");
                bFlag = false;
            }
            finally
            {
                if (FrameworkParams.wait != null) { 
                    FrameworkParams.wait.Finish(); 
                }
            }
            this.Cursor = Cursors.Default;
            if (bFlag)
                this.Close();
        }

        private void pathFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn tập tin";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pathFile.Text = openFile.FileName;
                if (!HelpFile.CheckFileSize(openFile.FileName, 20))
                {
                    HelpMsgBox.ShowNotificationMessage("Kích thước file không được vượt quá" +  "20 MB");
                    pathFile_Click(sender, e);
                }
            }
        }

        private void cmbSendType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSendType._getSelectedID() == (Int64)SendType.DNS)
            {
                this.lblSmartHost.Text = "Dns server";
                this.textSmartHost.Text = "";
            }
            else
            {
                this.lblSmartHost.Text = "Smart Host";
                this.textSmartHost.Text = "";
            }
        }

        #endregion
    }
}