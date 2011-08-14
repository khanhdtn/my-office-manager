using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
using Chilkat;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.Data.Common;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace pl.mail
{
    public class Node  
    {
        private string _FROM;
        public string FROM
        {
            get { return _FROM; }
            set
            {
                _FROM = value;
            }
        }
        private DateTime _DATE;
        public DateTime DATE
        {
            get { return _DATE; }
            set
            {
                _DATE = value;
            }
        }
        
        public Node()
        {            
        }
        public Node(DateTime date, string from)
        {
            this._DATE = date;
            this._FROM = from;
        }
    }

    class Message : Connect
    {
        #region Initailization
        public Message()
        {
        }
        public Message(string userMail, string password)
        {
            UserName = userMail;
            Password = password;
        }
        public Message(string hostSMTP, int portSMTP, bool sslSupport, string userMail, string password)
        {
            HostSMTP = hostSMTP;
            PortSMTP = portSMTP;
            SSLSMTP = sslSupport;
            UserName = userMail;
            Password = password;
        }
        #endregion

        /********************************************************************************/
        /*************************** GET MESSAGE FROM FOLDER ****************************/
        #region GetMessage
        public Email GetMessage(string FolderName, int MessageId)    //get message from local server
        {
            Email Mail;
            if (!imapConnect())
                return null;
           
            if (!imapClient.SelectMailbox(FolderName))
                return null;
            
            Mail = imapClient.FetchSingle(MessageId,true);
            
            imapDisconnect() ;
            // retrieve message success
            return Mail;           
        }

        /* TrungVD: Hàm hỗ trợ lấy danh sách các thư cũ đã được lấy từ server bên ngoài trước đó
        // list of old messages
        private list<node> getlistoldmessage(string foldername)
        {
            list<node> lstmailinfo = new list<node>(); //list message's info in current folder
            if (!imapconnect())
                return null;

            //choose current folfer
            if (!imapclient.selectmailbox(foldername))
            {   // if folder is not exist, create new folder
                imapclient.createmailbox(foldername);
                imapclient.selectmailbox(foldername);
            }

            messageset msset = imapclient.search("all", true);

            if (msset == null)
                return null;

            emailbundle list = imapclient.fetchbundle(msset);

            for (int i = 0; i < list.messagecount; i++)
            {
                email item = list.getemail(i);
                node newnode = new node(item.emaildate, item.fromaddress);
                lstmailinfo.add(newnode);
            }
            return lstmailinfo;

        }

        // list of old messages (int)daysago days ago
        private list<node> getlistoldmessage(string foldername, int daysago)
        {
            datetime date = datetime.today.adddays(-daysago);

            list<node> lstmailinfo = new list<node>(); //list message's info in current folder
            if (!imapconnect())
                return null;

            //choose current folfer
            if (!imapclient.selectmailbox(foldername))
            {   // if folder is not exist, create new folder
                imapclient.createmailbox(foldername);
                imapclient.selectmailbox(foldername);
            }

            messageset msset = imapclient.search("all", true);

            if (msset == null)
                return null;

            emailbundle list = imapclient.fetchbundle(msset);

            for (int i = 0; i < list.messagecount; i++)
            {
                email item = list.getemail(i);
                if (system.math.abs((date - item.emaildate).days) <= daysago)
                {
                    node newnode = new node(item.emaildate, item.fromaddress);
                    lstmailinfo.add(newnode);
                }

            }
            return lstmailinfo;         
        }
         */
         
        /* TrungVD: chức năng này chưa cần, và chưa được hoàn thiện
        // POP3: Get message normal, get all of messages which don't exist in folder (FolderName)
        public bool GetMailPOP(string FolderName,string HostPOP, int PortPOP, bool SSLSupport ,string MailName, string PWstring)
        {
            List<Node> lstMailInfo = GetListOldMessage(FolderName);//list message's info in current folder
            
            // new connect to pop3 server mail
            MailMan subpopClient = new MailMan();
            if (!(subpopClient.UnlockComponent("MAIL-TEAMBEAN_4895F76A292K")))
                return false;

            subpopClient.MailHost = HostPOP;
            subpopClient.MailPort = PortPOP;
            subpopClient.PopUsername = MailName;
            subpopClient.PopPassword = PWstring;

            if (SSLSupport)            
                subpopClient.PopSsl = true;     //SSL support            
            else                            
                subpopClient.PopSsl = false;    //connect without SSL support            
                        
            EmailBundle  colecMessageInfo = subpopClient.CopyMail();
            
            if (colecMessageInfo==null)
                return false;
            else
            {
                for(int i=0;i<colecMessageInfo.MessageCount;i++)
                {
                    Email msif =colecMessageInfo.GetEmail(i);               
                    
                    bool exist = false;
                    if (lstMailInfo != null)
                    {
                        foreach (Node node in lstMailInfo)
                        {
                            if ((node.DATE == msif.EmailDate) & (node.FROM == msif.FromAddress))
                            {
                                exist = true;
                                break;
                            }
                        }
                    }
                    if (!exist)
                    {                        
                        imapClient.AppendMail(FolderName, msif);                        
                    }                    
                }
                
                imapDisconnect();
                return true;        // get message success
            }
            
        }

        // POP3: Get messages which was sent in (int)daysAgo days ago and not exist in folder (FolderName)
        public bool GetMailPOP(string FolderName, string HostPOP, int PortPOP, bool SSLSupport, string MailName, string PWstring, int daysAgo)
        {
            DateTime date = DateTime.Today.AddDays(-daysAgo);

            List<Node> lstMailInfo = GetListOldMessage(FolderName,daysAgo); //list message's info in current folder
            
            // new connect to pop3 server mail
            MailMan subpopClient = new MailMan ();
            if (!subpopClient.UnlockComponent("MAIL-TEAMBEAN_4895F76A292K"))
                return false;
            subpopClient.MailHost = HostPOP;
            subpopClient.MailPort = PortPOP;
            subpopClient.PopUsername = MailName;
            subpopClient.PopPassword = PWstring;

            if (SSLSupport)
                subpopClient.PopSsl = true;     //SSL support            
            else
                subpopClient.PopSsl = false;    //connect without SSL support    
            
            EmailBundle colecMessageInfo = subpopClient.CopyMail();            

            if (colecMessageInfo == null)
                return false;
            else
            {
                for (int i = 0; i < colecMessageInfo.MessageCount; i++)
                {
                    Email msif = colecMessageInfo.GetEmail(i);

                    if (System.Math.Abs((date - msif.EmailDate).Days) <= daysAgo)
                    {
                        bool exist = false;
                        if (lstMailInfo != null)
                        {
                            foreach (Node node in lstMailInfo)
                            {
                                if ((node.DATE == msif.EmailDate) & (node.FROM == msif.FromAddress))
                                {
                                    exist = true;
                                    break;
                                }
                            }
                        }
                        if (!exist)
                        {                            
                            imapClient.AppendMail(FolderName, msif);
                        }
                    }
                }
                imapDisconnect();
                return true;        // get message success
            }

        }       
        */

        // POP3: Get all messages in server (HostPOP) and after that, delete all od messages in that server
        public int GetMailPOPDelete(string FolderName, string HostPOP, int PortPOP, bool SSLSupport, string MailName, string PWstring)
        {
            if (!imapConnect())
                return -1;

            //choose current folfer
            if (!imapClient.SelectMailbox(FolderName))
            {   
                // if folder is not exist, create new folder
                imapClient.CreateMailbox(FolderName);
                imapClient.SelectMailbox(FolderName);
            }
            MessageSet OLdMSSet = imapClient.Search("ALL", true);

            MailMan subpopClient = new MailMan ();
            if (!subpopClient.UnlockComponent("MAIL-TEAMBEAN_4895F76A292K"))
                return -1;
            // config info of pop server
            subpopClient.MailHost = HostPOP;
            subpopClient.MailPort = PortPOP;
            subpopClient.PopUsername = MailName;
            subpopClient.PopPassword = PWstring;

            if (SSLSupport)
                subpopClient.PopSsl = true;     //SSL support            
            else
                subpopClient.PopSsl = false;    //connect without SSL support      

            subpopClient.ConnectTimeout = 15;   // defaulf timeout = 30, so when it can't connect, it's too slow
            EmailBundle colecMessageInfo = subpopClient.CopyMail();  //Copy all of mail in mailbox of pop server

            if (colecMessageInfo == null) //connect fail, or don't have any new message
            {
                imapDisconnect();
                return -1;
            }
            else
            {
                //copy new message to folder on our server
                for (int i = 0; i < colecMessageInfo.MessageCount; i++)
                {
                    Email msif = colecMessageInfo.GetEmail(i);
                    imapClient.AppendMail(FolderName, msif);
                }
            }
            subpopClient.DeleteBundle(colecMessageInfo);    //delete all messages on pop server

            // mark new message unread
            // it's a little complex here, contact me if you need support
            imapClient.SelectMailbox(FolderName);
            MessageSet NewMSSet = imapClient.Search("ALL", true);
            for (int i = 0; i < OLdMSSet.Count; i++)
                NewMSSet.RemoveId(OLdMSSet.GetId(i));
            imapClient.SetFlags(NewMSSet, "Seen", 0);            
            imapDisconnect();
            return colecMessageInfo.MessageCount;
           
        }

        /* TrungVD: chức năng này chưa cần, và chưa được hoàn thiện
        // IMAP: Get message normal, get all of messages which don't exist in folder (FolderName)
        public bool GetMailIMAP(string FolderName, string HostIMAP, int PortIMAP, bool SSLSupport, string MailName, string PWstring)
        {
            List<Node> lstMailInfo = GetListOldMessage(FolderName); //list message's info in current folder            

            // new connect to pop3 server mail
            Imap subimapClient = new Imap ();
            if (!subimapClient.UnlockComponent("IMAP-TEAMBEAN_17BDEB05021V"))
                return false;

            if (SSLSupport)      //if SSL support                
                subimapClient.Ssl = true;
            else
                subimapClient.Ssl = false;

            subimapClient.Port = PortIMAP;
            //connect
            if (!subimapClient.Connect(HostIMAP))
                return false;

            if (!subimapClient.Login(MailName, PWstring))
                return false;

            Mailboxes mailbox = subimapClient.ListMailboxes("", "*");
            for (int i = 0; i < mailbox.Count; i++)
            {
                if (mailbox.GetName(i).ToUpper() == "INBOX")
                {
                    if (!subimapClient.SelectMailbox(mailbox.GetName(i)))
                        return false;
                    break;
                }
            }

            MessageSet MSSet = subimapClient.Search("ALL", true);
            
            if (MSSet == null)
                return false;

            EmailBundle colecMesageInfo = subimapClient.FetchBundle(MSSet);           

            if (colecMesageInfo.MessageCount==0)
                return false;
            else
            {   
                for (int i = 0; i < colecMesageInfo.MessageCount; i++)
                {
                    Email msif = colecMesageInfo.GetEmail(i);
                    bool exist = false;
                    if (lstMailInfo != null)
                    {
                        foreach (Node node in lstMailInfo)
                        {
                            if ((node.DATE == msif.EmailDate) & (node.FROM == msif.FromAddress))
                            {
                                exist = true;
                                break;
                            }
                        }
                    }
                    if (!exist)
                    {
                        imapClient.AppendMail(FolderName, subimapClient.FetchSingle(MSSet.GetId(i), true));
                    }       
                }
                imapDisconnect();
                return true;
            }
                
        }

        // IMAP: Get messages which was sent in (int)daysAgo days ago and not exist in folder (FolderName)
        public bool GetMailIMAP(string FolderName, string HostIMAP, int PortIMAP, bool SSLSupport, string MailName, string PWstring,int daysAgo)
        {
            DateTime date = DateTime.Today.AddDays(-daysAgo);

            List<Node> lstMailInfo = GetListOldMessage(FolderName,daysAgo); //list message's info in current folder
            
            Imap subimapClient = new Imap ();
            if (!subimapClient.UnlockComponent("IMAP-TEAMBEAN_17BDEB05021V"))
                return false;

            if (SSLSupport)      //if SSL support                
                subimapClient.Ssl = true;
            else
                subimapClient.Ssl = false;

            subimapClient.Port = PortIMAP;
            //connect
            if (!subimapClient.Connect(HostIMAP))
                return false;

            if (!subimapClient.Login(MailName, PWstring))
                return false;

            Mailboxes mailbox = subimapClient.ListMailboxes("", "*");
            for (int i = 0; i < mailbox.Count; i++)
            {
                if (mailbox.GetName(i).ToUpper() == "INBOX")
                {
                    if (!subimapClient.SelectMailbox(mailbox.GetName(i)))
                        return false;
                    break;
                }
            }

            MessageSet MSSet = subimapClient.Search("ALL", true);

            if (MSSet == null)
                return false;

            EmailBundle bundle = subimapClient.FetchBundle(MSSet);

            if (bundle.MessageCount == 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < bundle.MessageCount; i++)
                {
                    Email msif = bundle.GetEmail(i);

                    if (System.Math.Abs((date - msif.EmailDate).Days) <= daysAgo)
                    {
                        bool exist = false;
                        if (lstMailInfo != null)
                        {
                            foreach (Node node in lstMailInfo)
                            {
                                if ((node.DATE == msif.EmailDate) & (node.FROM == msif.FromAddress))
                                {
                                    exist = true;
                                    break;
                                }
                            }
                        }
                        if (!exist)
                        {
                            imapClient.AppendMail(FolderName, subimapClient.FetchSingle(MSSet.GetId(i),true));
                        }
                    }
                }
                imapDisconnect();
                return true;        // get message success
            }           
        }
        */

        // IMAP: GGet all messages in server (HostPOP) and after that, delete all od messages in that server
        public int GetMailIMAPDelete(string FolderName, string HostIMAP, int PortIMAP, bool SSLSupport, string MailName, string PWstring)
        {
            if (!imapConnect())
                return -1;

            //choose current folfer
            if (!imapClient.SelectMailbox(FolderName))
            {   
                // if folder is not exist, create new folder
                imapClient.CreateMailbox(FolderName);
                imapClient.SelectMailbox(FolderName);
            }

            Imap subimapClient = new Imap();
            if (!subimapClient.UnlockComponent("IMAP-TEAMBEAN_17BDEB05021V"))
                return -1;
            //config info of imap server
            if (SSLSupport)      //if SSL support                
                subimapClient.Ssl = true;
            else
                subimapClient.Ssl = false;
            subimapClient.Port = PortIMAP;
            //connect
            subimapClient.ConnectTimeout = 15;  // defaulf timeout = 30, so when it can't connect, it's too slow
            if (!subimapClient.Connect(HostIMAP))
                return -1;   // if can't connect to imap server

            if (!subimapClient.Login(MailName, PWstring))
                return -1;   // if can't login to imap server

            // choose folder Inbox on imap server
            // it's a little complex because the name of Inbox folder is diffirent on each imap server, such as INBOX, InBox, or InBox
            Mailboxes mailbox = subimapClient.ListMailboxes("", "*");
            for (int i = 0; i < mailbox.Count; i++)
            {
                if (mailbox.GetName(i).ToUpper() == "INBOX")
                {
                    if (!subimapClient.SelectMailbox(mailbox.GetName(i)))
                        return -1;
                    break;
                }
            }
                        
            MessageSet OLdMSSet = imapClient.Search("ALL", true);   //info of all old messages in our server
            MessageSet MSSet = subimapClient.Search("ALL", true);   //info of all  messages in imap server
            if (MSSet.Count !=0)           
            {
                // add new message
                for (int i = 0; i < MSSet.Count; i++)
                {
                    Email mail = subimapClient.FetchSingle(MSSet.GetId(i), true);                    
                    imapClient.AppendMail(FolderName, mail);                    
                }

                //delete message on server
                subimapClient.SetFlags(MSSet, "Deleted", 1);
                subimapClient.Expunge();  
                
                // mark new message is unread
                imapClient.SelectMailbox(FolderName);
                MessageSet NewMSSet = imapClient.Search("ALL", true);
                for (int i = 0; i < OLdMSSet.Count; i++)
                    NewMSSet.RemoveId(OLdMSSet.GetId(i));
                imapClient.SetFlags(NewMSSet, "Seen", 0);
                //Email agwag = imapClient.FetchSingle(NewMSSet.GetId(0), true);
            }            
            subimapClient.Disconnect();            
            imapDisconnect();
            return MSSet.Count;
        }
            
        #endregion

        /********************************************************************************/
        /************************* MOVE, COPY, DELETE MESSAGE ***************************/
        #region Move, Copy and Delete message
        public bool MoveMessage(int[] MessageID, string OldFolder, string NewFolder)
        {
            if (!imapConnect())
                return false;
            bool test;
            imapClient.SelectMailbox(OldFolder);
            foreach (int s in MessageID)
            {                
                test = imapClient.Copy(s,true,NewFolder);
                imapClient.SelectMailbox(OldFolder);
                test = imapClient.SetFlag(s, true, "Deleted", 1);               
            }
            if(!imapClient.Expunge())
                return false ;
            imapDisconnect();
            // move message success
            return true;            
        }
        public bool MoveMessage(Email Mail, string FolderName)
        {
            if (!imapConnect())
                return false;
            try
            {
                imapClient.AppendMail(FolderName, Mail);
                imapDisconnect();
                // move message success
                return true;
            }
            catch // move message fail
            {
                return false;
            }
        }

        public bool CopyMessage(int[] MessageID, string OldFolder, string NewFolder)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(OldFolder);
            foreach (int s in MessageID)
                if(!imapClient.Copy(s,true, NewFolder))
                    return false;

            imapDisconnect();
            // copy message success
            return true;            
        }

        public bool DeleteMessage(int[] MessageID, string FolderName)
        {
            if (!imapConnect())
                return false;
            
            imapClient.SelectMailbox(FolderName);
            foreach (int s in MessageID)
                imapClient.SetFlag(s, true, "Deleted", 1);
            if(!imapClient.Expunge())
                return false;
            imapDisconnect();
            // delete message success
            return true;            
        }
        #endregion

        /********************************************************************************/
        /************************ MARK, UNMARK MESSAGE'S FLAGS **************************/
        #region Mark, Unmark Flags
        public bool MarkReaded(int MessageID, String FolderName)
        {
            if (!imapConnect())
                return false;
            
            imapClient.SelectMailbox(FolderName);           
            if(imapClient.SetFlag(MessageID,true,"Seen",1))
                return false;
            imapDisconnect();
            // mark message success
            return true;
            
        }
        public bool UnMarkReaded(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Seen", 0))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        public bool MarkAnwsered(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Answered", 1))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        public bool UnMarkAnwsered(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Answered", 0))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        public bool MarkDrafts(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Draft", 1))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        public bool UnMarkDratfs(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Draft", 0))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        public bool MarkDeleted(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Deleted", 1))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        public bool UnMarkDeleted(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Deleted", 0))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        public bool MarkFlagged(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Flagged", 1))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        public bool UnMarkFlagged(int MessageId, String FolderName)
        {
            if (!imapConnect())
                return false;
            imapClient.SelectMailbox(FolderName);
            if (imapClient.SetFlag(MessageId, true, "Flagged", 0))
                return false;
            imapDisconnect();
            // mark message success
            return true;
        }
        #endregion

        /********************************************************************************/
        /**************** SENT MESSAGE & SAVE MESSAGE TO A FOLDER ***********************/
        #region Sent message & Save message to a specify folder
        //Sent message local
        public static bool SentMessage(Email Mail)
        {
            MailMan smtp = new MailMan();
            if (!(smtp.UnlockComponent("MAIL-TEAMBEAN_4895F76A292K")))
                return false;

            if (!Connect.SetConfigInfo())
                return false;
            if (UserName == null)
            {
                UserName = FrameworkParams.currentUser.username + "@" + Connect.domain;
                Password = FrameworkParams.currentUser.id + "_protocolvn";
            }
            smtp.SmtpHost = HostSMTP;
            smtp.SmtpPort = PortSMTP;
            smtp.SmtpUsername = AccountLogin(UserName);
            smtp.SmtpPassword = Password;

            Mail.From = UserName;

            if (SSLSMTP)
                smtp.PopSsl = true;     //SSL support            
            else
                smtp.PopSsl = false;    //connect without SSL support 

            if (smtp.SendEmail(Mail))
                return true;
            else
                return false;
        }


        /// <summary>
        /// Sent message throught server outside
        /// </summary>
        /// <param name="hostSMTP"></param>
        /// <param name="portSMTP"></param>
        /// <param name="sslSMTP"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="Mail"></param>
        /// <returns></returns>
        public static bool SentMessage(string hostSMTP, int portSMTP, bool sslSMTP, string username, string password, Email Mail)
        {
            MailMan smtp = new MailMan();
            if (!(smtp.UnlockComponent("MAIL-TEAMBEAN_4895F76A292K")))
                return false;

            smtp.SmtpHost = hostSMTP;
            smtp.SmtpPort = portSMTP;
            smtp.SmtpUsername = username;
            smtp.SmtpPassword = password;

            Mail.Charset = "utf-8";
            if (sslSMTP)
                smtp.PopSsl = true;     //SSL support            
            else
                smtp.PopSsl = false;    //connect without SSL support 

            if (smtp.SendEmail(Mail))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Sent mail from a template word with content is text body 
        /// </summary>
        /// <param name="EmailReceive">Sent mail to list mail address with same mail body</param>
        /// <param name="DataFill">DataSet to fill file word template</param>
        /// <param name="SubjectEmail">Subject of mail</param>
        /// <param name="PathWordTemplate">String path to file word template</param>
        /// <param name="PathAttachment">List paths to files will be sent with email</param>
        /// <returns></returns>
        public static bool SentMessageTemplateTextOutside(List<string> EmailReceive, DataSet DataFill, string SubjectEmail, string PathWordTemplate, List<string> PathAttachment)
        {
            DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM FW_EMAIL_INFO WHERE IDUSER=" + FrameworkParams.currentUser.id.ToString());
            DataSet ds = new DataSet();
            ds = DABase.getDatabase().LoadDataSet(command, "MailInfo");
            DataRow dr = ds.Tables["MailInfo"].Rows[0];

            Email Mail = new Email();

            if (!TEXTBody(DataFill, PathWordTemplate, ref Mail))
                return false;

            if (!FillMail(EmailReceive, SubjectEmail, PathAttachment, ref Mail))
                return false;

            Mail.From = dr["UserMail"].ToString();

            if (!SentMessage((string)dr["HostSMTP"], (int)dr["PortSMTP"], (dr["SSLSMTP"].ToString() == "Y" ? true : false), (string)dr["UserMail"], (string)dr["Password"], Mail))
                return false;
            return true;
        }

        /// <summary>
        /// Sent mail from a template word with content is text body 
        /// </summary>
        /// <param name="EmailReceive">Sent mail to list mail address with same mail body</param>
        /// <param name="DataFill">DataSet to fill file word template</param>
        /// <param name="SubjectEmail">Subject of mail</param>
        /// <param name="PathWordTemplate">String path to file word template</param>
        /// <param name="PathAttachment">List paths to files will be sent with email</param>      
        /// <returns></returns>
        public static bool SentMessageTemplateHTMLOutside(List<string> EmailReceive, DataSet DataFill, string SubjectEmail, string PathWordTemplate, List<string> PathAttachment)
        {
            DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM FW_EMAIL_INFO WHERE IDUSER=" + FrameworkParams.currentUser.id.ToString());
            DataSet ds = new DataSet();
            ds = DABase.getDatabase().LoadDataSet(command, "MailInfo");
            DataRow dr = ds.Tables["MailInfo"].Rows[0];
            Email Mail = new Email();


            if (!HTMLBody(DataFill, PathWordTemplate, ref Mail))
                return false;

            if (!FillMail(EmailReceive, SubjectEmail, PathAttachment, ref Mail))
                return false;

            Mail.From = dr["UserMail"].ToString();

            if (!SentMessage((string)dr["HostSMTP"], (int)dr["PortSMTP"], (dr["SSLSMTP"].ToString() == "Y" ? true : false), (string)dr["UserMail"], (string)dr["Password"], Mail))
                return false;
            return true;
        }

        /// <summary>
        /// Sent mail local from a template word with content is text body 
        /// </summary>
        /// <param name="EmailReceive">Sent mail to list mail address with same mail body</param>
        /// <param name="DataFill">DataSet to fill file word template</param>
        /// <param name="SubjectEmail">Subject of mail</param>
        /// <param name="PathWordTemplate">String path to file word template</param>
        /// <param name="PathAttachment">List paths to files will be sent with email</param>
        /// <returns></returns>
        public static bool SentMessageTemplateTextLocal(List<string> EmailReceive, DataSet DataFill, string SubjectEmail, string PathWordTemplate, List<string> PathAttachment)
        {
            Email Mail = new Email();

            if (!TEXTBody(DataFill, PathWordTemplate, ref Mail))
                return false;

            if (!FillMail(EmailReceive, SubjectEmail, PathAttachment, ref Mail))
                return false;

            Mail.From = FrameworkParams.currentUser.username + "@" + Connect.domain;

            if (!SentMessage(Mail))
                return false;
            return true;
        }

        /// <summary>
        /// Sent mail local from a template word with content is text body 
        /// </summary>
        /// <param name="EmailReceive">Sent mail to list mail address with same mail body</param>
        /// <param name="DataFill">DataSet to fill file word template</param>
        /// <param name="SubjectEmail">Subject of mail</param>
        /// <param name="PathWordTemplate">String path to file word template</param>
        /// <param name="PathAttachment">List paths to files will be sent with email</param>      
        /// <returns></returns>
        public static bool SentMessageTemplateHTMLLocal(List<string> EmailReceive, DataSet DataFill, string SubjectEmail, string PathWordTemplate, List<string> PathAttachment)
        {
            Email Mail = new Email();

            if (!HTMLBody(DataFill, PathWordTemplate, ref Mail))
                return false;

            if (!FillMail(EmailReceive, SubjectEmail, PathAttachment, ref Mail))
                return false;                     

            if (!SentMessage(Mail))
                return false;

            return true;
        }

        // like MoveMessage, it save message to a folder
        public bool SaveMessage(string FolderName, Email Mail)
        {
            if (!imapConnect())
                return false;

            if (!imapClient.AppendMail(FolderName, Mail))
                return false;

            imapDisconnect();
            return true;
        }
        #endregion


        /********************************************************************************/
        /**************************** DOWNLOAD ATTACHMENT *******************************/
        #region Download Attachment
        public bool DownAttach(string FolderName, int MessageId, string[] AttachNames, string Path)
        {
            Email Mail;
            if (!imapConnect())
                return false;
            
            imapClient.SelectMailbox(FolderName);
            Mail = imapClient.FetchSingle(MessageId,true);
            for (int i= 0 ;i<Mail.NumAttachments;i++)
            {
                for (int j=0;j< AttachNames.Length;j++)
                {
                    if (Mail.GetAttachmentFilename(i)==AttachNames[j])
                        if (!Mail.SaveAttachedFile(i,Path + "\\"))
                            return false ;
                }
            }
            imapDisconnect();
            // mark message success
            return true;
           
        }
        #endregion

        /********************************************************************************/
        /******************************* FUNCTION SUPPORT *******************************/
        #region Function support
        /// <summary>
        /// cover file word to body hmtl of mail,which embed fictures
        /// </summary>
        /// <param name="PathWordTemplate">path to word template file</param>
        /// <param name="Mail">Mail is embed body</param>
        /// <returns></returns>
        private static bool HTMLBody(DataSet DataFill, string PathWordTemplate, ref Email Mail)
        {
            string path = FrameworkParams.TEMP_FOLDER + @"\WordTemp";
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);
            path += PathWordTemplate.Substring(PathWordTemplate.LastIndexOf("\\"));
            WordDocument WordDoc = new WordDocument();
            try
            {
                WordDoc.Open(PathWordTemplate);
                for (int i = 0; i < DataFill.Tables.Count; i++)
                {
                    WordDoc.MailMerge.ExecuteGroup(DataFill.Tables[i]);
                }
                WordDoc.Save(path);

                Word.ApplicationClass wd = new Word.ApplicationClass();
                Word.Document document = new Word.Document();
                object fileName = (object)path;
                object newTemplate = false;
                object docType = 0;
                object isVisible = true;
                object missing = System.Reflection.Missing.Value;

                document = wd.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);


                object oFileName = (object)(path.Substring(0, path.LastIndexOf(".")) + ".html");
                object oSaveFormat = (object)(Word.WdSaveFormat.wdFormatHTML);

                if (System.IO.File.Exists(oFileName.ToString()))
                    System.IO.File.Delete(oFileName.ToString());

                document.SaveAs(ref oFileName,
                                ref oSaveFormat,
                                ref missing,
                                ref missing,
                                ref missing,
                                ref missing,
                                ref missing,
                                ref missing,
                                ref missing,
                                ref missing,
                                ref missing);                
                wd.Quit(ref missing, ref missing, ref missing);

                Mht mailbody = new Mht();
                mailbody.UnlockComponent("MHT-TEAMBEAN_1E1F4760821H");
                mailbody.UseCids = true;
                Mail = mailbody.GetEmail(oFileName.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool TEXTBody(DataSet DataFill, string PathWordTemplate, ref Email Mail)
        {
            WordDocument WordDoc = new WordDocument();
            try
            {
                WordDoc.Open(PathWordTemplate);
                for (int i = 0; i < DataFill.Tables.Count; i++)
                {
                    WordDoc.MailMerge.ExecuteGroup(DataFill.Tables[i]);
                }
                Mail.Body = WordDoc.GetText();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool FillMail(List<string> EmailReceive, string SubjectEmail, List<string> PathAttachment, ref Email Mail)
        {
            if (EmailReceive == null)
                return false;

            for (int i = 0; i < EmailReceive.Count; i++)
                if (!Mail.AddTo("", EmailReceive[i]))
                    return false;

            Mail.Subject = SubjectEmail;
            if (PathAttachment != null)
                for (int i = 0; i < PathAttachment.Count; i++)
                    Mail.AddFileAttachment(PathAttachment[i]);
            return true;
        }
        #endregion

    }
}
