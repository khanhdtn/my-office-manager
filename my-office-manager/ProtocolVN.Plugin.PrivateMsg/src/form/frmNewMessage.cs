using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Chilkat;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.Win32;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.Plugin;

namespace pl.mail
{
    public partial class frmNewMessage : DevExpress.XtraEditors.XtraForm
    {
        private Email Mail= new Email();       
        
        private List<string> toLocal = new List<string>();
        private List<string> toGlobal = new List<string>();
        private List<string> ccLocal = new List<string>();
        private List<string> ccGlobal = new List<string>();
        private List<string> bccLocal = new List<string>();
        private List<string> bccGlobal = new List<string>();
        private DataSet ds = new DataSet();
        private bool haveCC = false;
        private int numOfOldAttach = 0;
        private string state;
        private string UserMail ;
        private string Password ;
        private string UserId ;
        private frmMessage parentForm;
        private DataTable dtFileAtt = null;
        private IPlugin iPluginAddBook;
        #region Initialization 
        public frmNewMessage()
        {
            InitializeComponent();
            UserMail =FrameworkParams.currentUser.username + "@" + Connect.domain;          
            //HUYLX : Set lại password từ framework
            //Password = FrameworkParams.currentUser.password;
            Password = FrameworkParams.currentUser.id + "_protocolvn";
            UserId = FrameworkParams.currentUser.id.ToString();
            state = "None";
            _initAtt();
            loadmail();
            LoadPlugin();
        }

        public frmNewMessage(Email mail, string state,frmMessage form)//state = "Reply" or "Forward" or "Drafts"
        {
            
            InitializeComponent();
            UserMail = FrameworkParams.currentUser.username + "@" + Connect.domain;
            //HUYLX : Set lại password từ framework
            //Password = FrameworkParams.currentUser.password;
            Password = FrameworkParams.currentUser.id + "_protocolvn";
            UserId = FrameworkParams.currentUser.id.ToString();           
            this.state = state;
            if ((state == "Reply") | (state == "Forward"))
            {
                string to = "";
                for (int i = 0; i < mail.NumTo; i++)
                    to += mail.GetTo(i);

                string stringHTML = mail.GetHtmlBody();
                if ((mail.HasHtmlBody()) & (mail.NumRelatedItems > 0))//show image
                {
                    string path = FrameworkParams.TEMP_FOLDER + @"\MailImage";
                    if (!System.IO.Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                    }
                    for (int i = 0; i < mail.NumRelatedItems; i++)
                    {
                        mail.SaveRelatedItem(i, path);
                        string replace = mail.GetRelatedContentID(i);
                        int pos = stringHTML.IndexOf(replace);
                        pos--;
                        while (stringHTML[pos].ToString() != "\"")
                        {
                            replace = stringHTML[pos].ToString() + replace;
                            pos--;
                        }
                        stringHTML = stringHTML.Replace(replace, path + "\\\\" + mail.GetRelatedFilename(i));
                    }
                }
                editor.DocumentText = "<HTML><BODY>"
                                               + "</br>" + "</br>"
                                               + "------------- Thư gốc ------------- </br>"
                                               + "Từ: " + mail.From + "</br>"
                                               + "Ngày: " + mail.EmailDate.ToString() + "</br>"
                                               + "Tiêu đề: " + mail.Subject + "</br>"
                                               + "Đến: " + to + "</br>" + "</br>"
                                               + "Nội dung: </br>" + ((mail.HasHtmlBody()) ? stringHTML : mail.GetPlainTextBody())
                                               + "</BODY></HTML>";
                if (state == "Reply")
                {
                    Mail = mail.CreateReply();

                }
                else
                {
                    if (state == "Forward")
                        Mail = mail.CreateForward();
                    else
                        Mail = mail;
                }                
            }
            numOfOldAttach = Mail.NumAttachments;
            parentForm = form;
            _initAtt();
            loadmail();
            LoadPlugin();
        }      
        #endregion

        private void LoadPlugin()
        {
            try
            {
                if (PLPlugin.ExistPlugin("So dia chi"))
                {                 
                    iPluginAddBook = PLPlugin.GetPlugin("So dia chi");
                    Register(iPluginAddBook);
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }            
        }
        private void _initAtt()
        {
            repositoryItemImageComboBox1.SmallImages = imageList1;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsMenu.EnableColumnMenu = false;
            gridView1.OptionsMenu.EnableFooterMenu = false;
            gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsView.ShowIndicator = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsBehavior.Editable = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            gridView1.OptionsView.ShowVertLines = false;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            dtFileAtt = new DataTable("FILEATT");
            dtFileAtt.Columns.Add(new DataColumn("NAME"));
            dtFileAtt.Columns.Add(new DataColumn("SIZE"));
            dtFileAtt.Columns.Add(new DataColumn("TYPE"));
            dtFileAtt.Columns.Add(new DataColumn("DATE"));
            gridControl1.DataSource = dtFileAtt;
        }

        #region Function Procedure

        // load mail to form
        private void loadmail()
        {
            DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM MAILINFO WHERE IDUSER=" + UserId);
            ds = new DataSet();
            ds = DABase.getDatabase().LoadDataSet(command,"MailInfo");
            for (int i = 0; i < ds.Tables["MailInfo"].Rows.Count; i++)
            {
                DataRow dr = ds.Tables["MailInfo"].Rows[i];
                cbFrom.Properties.Items.Add(dr["UserMail"]);
            }

            command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM DM_LOAI_THU");           
            DataSet dsTypeMail = DABase.getDatabase().LoadDataSet(command, "TYPEMAIL");
            
            for (int i = 0; i < dsTypeMail.Tables["TYPEMAIL"].Rows.Count; i++)
            {
                DataRow dr = dsTypeMail.Tables["TYPEMAIL"].Rows[i];
                cbTypeMessage.Properties.Items.Add(dr[1]);
            }
            
            cbTypeMessage.SelectedIndex = 0;
            cbFrom.SelectedIndex = 0;
            string tempTypeMessage = Mail.GetHeaderField("TypeMessage");
            if (tempTypeMessage != null)
            {
                cbTypeMessage.SelectedIndex = int.Parse(tempTypeMessage);
            }
            
                
            if (state == "None")
            {
                editor.BodyHtml = string.Empty;
            }
            else
            {
                for (int i = 0; i < Mail.NumTo; i++)
                {
                    txtTo.Text += Mail.GetTo(i) + "; ";
                }
                for (int i = 0; i < Mail.NumCC; i++)
                {
                    txtCc.Text += Mail.GetCC(i) + "; ";
                }
                for (int i = 0; i < Mail.NumBcc; i++)
                {
                    txtbcc.Text += Mail.GetBcc(i) + "; ";
                }
                txtSubject.Text = Mail.Subject;
                if (Mail.NumAttachments > 0)
                {
                    for (int i = 0; i < Mail.NumAttachments; i++)
                    {
                        string fileType = SysIcon.FileType(Mail.GetAttachmentFilename(i));
                        string fileName = Mail.GetAttachmentFilename(i);
                        
                        if (imageList1.Images[fileType] == null)
                        {
                            imageList1.Images.Add(fileType, SysIcon.GetIcon(fileType).ToBitmap());
                        }
                        SetInfo(fileName, fileType);
                    }
                }
                
               
                
                if (state == "Drafts")
                {
                    cbFrom.Text = Mail.FromAddress;
                    editor.DocumentText = Mail.Body;
                    if ((Mail.NumCC > 0)|(Mail.NumBcc > 0))
                    {
                        panel1.Location = new Point(0, panel1.Location.Y + 46);
                        panel1.Height -= 46;
                        barBtCC.Caption = "Bỏ Cc,Bcc";
                        haveCC = true;
                        for (int k = 0; k < Mail.NumCC; k++)
                        {
                            txtCc.Text = Mail.GetCC(k);
                        }
                        for (int k = 0; k < Mail.NumBcc; k++)
                        {
                            txtbcc.Text = Mail.GetBcc(k); 
                        }
                       
                    }                    
                }                
            }
        }

        // create body HTML for message
        private void bodyHTML()
        {
            string stringHTML = editor.BodyHtml;
            Mail.DropRelatedItems();
            int oldpos = 0;
            int pos = 0;
            do
            {
                pos = stringHTML.IndexOf("<IMG",oldpos) + 4;
                if (pos == 3)
                    break;
                pos = stringHTML.IndexOf("src=",pos) + 4;
                if (pos == 3)
                    break;
                string replace = "";
                while (stringHTML[pos].ToString() != "\"") pos++;
                pos++;
                while (stringHTML[pos].ToString() != "\"")
                {
                    replace += stringHTML[pos].ToString();
                    pos++;
                }
                if (System.IO.File.Exists(replace))
                {
                    string cid = Mail.AddRelatedFile(replace);
                    stringHTML = stringHTML.Replace(replace, "cid:" + cid);
                }
                oldpos = pos + 1;
            }
            while (true);
            Mail.SetHtmlBody(stringHTML);

        }
        // return true if mail adress s is mail local
        private bool localMail(string s)  
        {
            if (s.IndexOf(Connect.domain) != -1)
                return true;
            else
                return false;
        }
        
        // return true if all infomation of user is valid
        private bool validation()
        {
            if ((txtTo.Text.Length == 0) & (txtCc.Text.Length == 0) & (txtbcc.Text.Length == 0))
            {
                PLMessageBox.ShowErrorMessage("Bạn chưa nhập người nhận");
                return false;
            }
            
            if (editor.BodyHtml == null )
            {
                PLMessageBox.ShowErrorMessage("Bạn chưa nhập nội dung thư");
                return false;
            }
            if (txtSubject.Text.Length == 0)
            {
                DialogResult result = PLMessageBox.ShowConfirmMessage("Bạn có muốn nhập tiêu đề cho thư không?");
                if (result == DialogResult.No)
                    return true;
                else
                    return false;
            }
            return true;
        }

        // distinguish mail local, mail global
        private void address(string s, ref List<string> local, ref List<string> global)  
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if ((s[i].ToString() == ";") | (s[i].ToString() == " "))
                    s = s.Remove(i);
                else
                    break;
            }
            s += ";";
            string item = "";
            local.Clear();
            global.Clear();
            for (int i = 0; i < s.Length; i++)
            {
                if ((s[i].ToString() != ",") & (s[i].ToString() != ";"))
                {
                    item += s[i].ToString();
                }
                else
                {
                    if (item != "")
                    {
                        if (localMail(item))
                            local.Add(item);
                        else
                            global.Add(item);
                    }
                    item = "";
                }
            }

        }

        // save infomation is given
        private void updateMail()
        {
            try
            {
                if (cbTypeMessage.SelectedIndex == 0)
                {
                    Mail.RemoveHeaderField("TypeMessage");
                }
                else
                {
                    if (Mail.GetHeaderField("TypeMessage")!=null)
                        Mail.RemoveHeaderField("TypeMessage");
                    Mail.AddHeaderField("TypeMessage", cbTypeMessage.SelectedIndex.ToString());                    
                }

                address(txtTo.Text, ref toLocal, ref toGlobal);

                if (haveCC)
                {
                    if (txtCc.Text.Length > 0)
                        address(txtCc.Text, ref ccLocal, ref ccGlobal);
                    if (txtbcc.Text.Length > 0)
                        address(txtbcc.Text, ref bccLocal, ref bccGlobal);
                }

                Mail.Subject = txtSubject.Text;
                int numNewAttach = Mail.NumAttachments;
                for (int i = numOfOldAttach; i < numNewAttach; i++)
                {
                    Mail.DropSingleAttachment(numOfOldAttach);
                }

                //AttachFile 
                
                for (int i = numOfOldAttach; i < gridView1.RowCount; i++)
                {                    
                    Mail.AddFileAttachment(gridView1.GetDataRow(i)["NAME"].ToString());
                }

                if (editor.BodyHtml != null)
                {
                    if (editor.State == "HTML")
                    {
                        bodyHTML();
                    }
                    else
                    {
                        Mail.Body=editor.BodyText;
                    }
                }
            }
            catch { }
        }

        // save message to a folder
        private bool saveMessage(string FolderName, Email mail) 
        {
            Message mess = new Message(UserMail, Password);
            if (mess.SaveMessage(FolderName, mail))
                return true;
            else
                return false;
        }            

        // Save message when it's send success to Sent Items
        private void SaveMessageSend()
        {
            if (true)
            {
                if (cbFrom.Text.ToString().Length > 0)
                {
                    Mail.From = cbFrom.Text.ToString();
                }
                else
                {
                    Mail.From = UserMail;
                }

                Mail.ClearTo();
                Mail.ClearCC();
                Mail.ClearBcc();
                addAddress(toLocal, ccLocal, bccLocal);
                addAddress(toGlobal, ccGlobal, bccGlobal);                
                saveMessage("Sent Items", Mail);
            }
        }
        
        // Add address to mail
        private void addAddress(List<string> To, List<string> CC, List<string> BCC)
        {
            foreach (string s in To)
            {
                Mail.AddTo("", s);
            }
            foreach (string s in CC)
            {
                Mail.AddCC("", s);
            }
            foreach (string s in BCC)
            {
                Mail.AddBcc("", s);
            }
        }

        #endregion

        #region Event Solve
        //Button save drafts
        private void barbtSaveDraft_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            updateMail();
            if (cbFrom.Text.Length > 0)
                Mail.FromAddress = cbFrom.Text;
            Mail.ClearTo();
            Mail.ClearCC();
            Mail.ClearBcc();
            addAddress(toLocal, ccLocal, bccLocal);
            addAddress(toGlobal, ccGlobal, bccGlobal);

            if (saveMessage("Drafts", Mail))
            {
                if (state == "Reply")
                    parentForm.reply();
                PLMessageBox.ShowNotificationMessage("Thư đã được lưu");
            }
            else
                PLMessageBox.ShowErrorMessage("Không lưu được thư");
        }

        //Button sent mail
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) // when clisk sent mail
        {
            updateMail();
            if (!validation())
                return;
            // Sent mail global
            if ((toGlobal.Count > 0) | (ccGlobal.Count > 0) | (bccGlobal.Count > 0))
            {
                if (cbFrom.Text.ToString() == "")
                {
                    PLMessageBox.ShowErrorMessage("Bạn chưa có hộp thư bên ngoài");
                    return;
                }
                Mail.From = cbFrom.Text.ToString();
                DataRow dr = ds.Tables["MailInfo"].NewRow();
                for (int i=0; i<ds.Tables["MailInfo"].Rows.Count;i++)
                {   
                    dr = ds.Tables["MailInfo"].Rows[i];
                    if (dr["UserMail"].ToString()== cbFrom.Text)                    
                        break;                                        
                }

                Mail.ClearTo();
                Mail.ClearCC();
                Mail.ClearBcc();

                //add adress mail global
                addAddress(toGlobal, ccGlobal, bccGlobal);
                //sent mail
                if (!Message.SentMessage((string)dr["HostSMTP"], (int)dr["PortSMTP"], (dr["SSLSMTP"].ToString() == "Y" ? true : false), (string)dr["UserMail"], (string)dr["Password"], Mail))
                {
                    PLMessageBox.ShowErrorMessage("Gửi mail thất bại");
                    return;
                }
            }

            //sent mail to local
            if ((toLocal.Count > 0) | (ccLocal.Count > 0) | (bccLocal.Count > 0))
            {
                Mail.From = UserMail;
                Message mess = new Message(UserMail, Password);
                //remove adress mail of glogal server
                Mail.ClearTo();
                Mail.ClearCC();
                Mail.ClearBcc();

                // add adress mail local
                addAddress(toLocal , ccLocal, bccGlobal);
                //sent mail
                if (!Message.SentMessage(Mail))
                {
                    PLMessageBox.ShowErrorMessage("Gửi mail thất bại");
                    return;
                }
            }
            SaveMessageSend();
            if (state =="Reply")
                parentForm.reply();
            Close();
        }

        // add CC or BCC
        private void barBtCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!haveCC)
            {
                panel1.Location = new Point(0, panel1.Location.Y + 46);
                panel1.Height -= 46;
                barBtCC.Caption = "Bỏ Cc,Bcc";
                haveCC = true;
            }
            else
            {
                panel1.Location = new Point(0, panel1.Location.Y - 46);
                barBtCC.Caption = "Thêm Cc,Bcc";
                panel1.Height += 46;
                haveCC = false;
            }
        }

    

        //Button add attachment
        public void SetInfo(string fileName,string fileType)
        {
            FileInfo finf = new FileInfo(fileName);
            string exts = finf.Extension;
            RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(exts);
            string descKey = rkey.GetValue("").ToString();
            rkey = Registry.ClassesRoot.OpenSubKey(descKey);

            long? kt = null;
            try
            {
                kt = finf.Length;
            }
            catch { }

            SetDataSource(finf.FullName,kt, rkey.GetValue("").ToString(), ((finf.LastWriteTime.Year == 1601))?"":finf.LastWriteTime.ToString(), fileType);
        }

        private void SetDataSource(string tenFile, long? kichthuoc, string loai, string ngaytao, string fileType)
        {
            string name = tenFile;
            DataRow dr = dtFileAtt.NewRow();
            if (!System.IO.File.Exists(tenFile))
            {
                name = name.Substring(name.LastIndexOf("\\")+1);
            }
            ImageComboBoxItem item = new ImageComboBoxItem(name,imageList1.Images.IndexOfKey(fileType));
            repositoryItemImageComboBox1.Items.Add(item);

            dr["NAME"] = name;
            if (kichthuoc != null)
                dr["SIZE"] = (((kichthuoc / 1024) < 1) ? 1 : (kichthuoc / 1024)).ToString() + " KB";
            else
                dr["SIZE"] = "";
            dr["TYPE"] = loai;
            dr["DATE"] = ngaytao;
            dtFileAtt.Rows.Add(dr);
            gridControl1.DataSource = dtFileAtt;
        }
        private void btAddAttach_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] path = openFileDialog1.FileNames;
                foreach (string s in path)
                {
                    
                    string fileType = SysIcon.FileType(s);
                    string type="";
                    if (imageList1.Images[fileType] == null)
                        imageList1.Images.Add(fileType, SysIcon.GetIcon(fileType).ToBitmap());
                    SetInfo(s, fileType);
                }
            }
        }

        //Button remove attachment
        private void btRemoveAttach_Click(object sender, EventArgs e)
        {
            int[] index = gridView1.GetSelectedRows();
            foreach (int i in index)
            {
                if (Mail.NumAttachments > 0)
                {
                    for (int j = 0; j < Mail.NumAttachments; j++)
                    {
                        if (gridView1.GetDataRow(i)["NAME"].ToString().LastIndexOf( Mail.GetAttachmentFilename(j))!= -1)
                        {
                            Mail.DropSingleAttachment(j);
                            numOfOldAttach--;
                            break;
                        }
                    }
                }
            }
            gridView1.DeleteSelectedRows();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion        
    
        #region IPluginHost Members

        public bool Register(IPlugin ipi)
        {
            txtTo.Width = 476;
            SimpleButton btAddressBook = new SimpleButton();
            btAddressBook.Location = new System.Drawing.Point(574, 53);
            btAddressBook.Size = new System.Drawing.Size(85, 20);
            btAddressBook.TabIndex = 41;
            btAddressBook.Text = ipi.Name;
            btAddressBook.Click += new System.EventHandler(this.btAddressBook_Click);
            this.Controls.Add(btAddressBook);
            return true;
        }

        // add mail address from address book
        private void btAddressBook_Click(object sender, EventArgs e)
        {
            //frmTest frm = new frmTest();
            //ProtocolForm.ShowModalDialog(this, frm);
            List<object> lstMail = new List<object>();
            if (iPluginAddBook != null)
            {
                frmAddressBook frm = new frmAddressBook();
                ProtocolForm.ShowModalDialog(this, frm);
                lstMail = frmAddressBook.ListEmail;
                try
                {
                    string mail = "";
                    foreach (object m in lstMail)
                        mail += m.ToString() + "; ";
                    txtTo.Text = ((txtTo.Text == "") ? "" : txtTo.Text) + mail;
                }
                catch { }
            }
            else
            {
                PLMessageBox.ShowNotificationMessage("Chưa đăng ký sử dụng AddressBook Plugin");
            }
        }        
        #endregion

        

        
    }
}