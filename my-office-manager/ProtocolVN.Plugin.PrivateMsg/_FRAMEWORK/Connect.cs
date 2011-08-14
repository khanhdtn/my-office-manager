using System.Data;
using System.IO;
using System.Windows.Forms;
using Chilkat;
//using LumiSoft.MailServer.API.UserAPI;
using System;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using Email_Client;
using LumiSoft.MailServer.API.UserAPI;

namespace pl.mail
{
    public class Connect
    {
        protected  static Imap imapClient;
        protected  static MailMan popClient;
        protected static string Host;
        protected static int Port;
        protected static bool SSL;
        protected static string HostSMTP;
        protected static int PortSMTP;
        protected static bool SSLSMTP;
        protected static string UserName;
        protected static string Password;
        protected static int Login;
        public static string domain;
        private static string fileName = FrameworkParams.CONF_FOLDER + "/mailserver.cpl";

        /********************************************************************************/
        /******************************** Khởi tạo class ********************************/
        #region Initialization
        public Connect()
        {            
        }
        public Connect(string hostSMTP, int portSMTP, bool sslSMTP, string host, int port, bool ssl, string userMail, string password,int login)
        {
            HostSMTP = hostSMTP;
            PortSMTP = portSMTP;
            SSLSMTP = sslSMTP;
            Host = host;
            Port = port;
            SSL = ssl;
            UserName = userMail;
            Password = password;
            Login = login;
        }
        #endregion                

        /********************************************************************************/
        /********************* Kết nối và hủy kết nối cới server Imap *******************/
        #region imapConnect & imapDisconnect
        public bool imapConnect()   //connect to Mail server throught IMAP
        {
            imapClient = new Imap();
            if (!imapClient.UnlockComponent("IMAP-TEAMBEAN_17BDEB05021V"))
                return false;

            //SSL support                
            if (SSL)      
                imapClient.Ssl = true;
            else
                imapClient.Ssl = false;
            imapClient.Port = Port;

            //Connect
            if (!imapClient.Connect(Host))
                return false;

            if (!imapClient.Login(AccountLogin(UserName), Password))
                return false;

            return true;
        }

        public bool imapDisconnect()    //Disconnect with Mail server
        {
            if (imapClient.Logout())
                return false;
            if (imapClient.Disconnect())
                return false;
            return true;
        }

        public bool TestConnectServer(ref string Error)
        {
            imapClient = new Imap();
            if (!imapClient.UnlockComponent("IMAP-TEAMBEAN_17BDEB05021V"))
                return false;

            if (SSL)      //if SSL support                
                imapClient.Ssl = true;
            else
                imapClient.Ssl = false;

            imapClient.Port = Port;
            imapClient.ConnectTimeout = 10;
            //connect
            if (!imapClient.Connect(Host))
            {
                Error = "Server";
                return false;
            }

            if (!imapClient.Login(AccountLogin(UserName), Password))
            {
                AddMessageAccount();
                if (imapClient.Login(AccountLogin(UserName), Password))
                    return true;
                Error = "Account";
                return false;
            }
            return true;
        }

        public static bool TestImapConnect(string host, int port, string username, string password, ref string Error)   //connect to Mail server throught IMAP
        {
            Imap subimapClient = new Imap();
            if (!subimapClient.UnlockComponent("IMAP-TEAMBEAN_17BDEB05021V"))
                return false;

            if (SSL)      //if SSL support                
                subimapClient.Ssl = true;
            else
                subimapClient.Ssl = false;

            subimapClient.Port = port;
            //connect
            if (!subimapClient.Connect(host))
            {
                Error = "Server";
                return false;
            }

            if (!subimapClient.Login(username, password))
            {
                Error = "Account";
                return false;
            }
            return true;
        }

        #endregion

        /********************************************************************************/
        /**************************** Kiểm tra server POP3 ******************************/
        #region TestPopConnect

        public static bool TestPopConnect(string host, int port, string username, string password,ref string error)   //connect to Mail server throught POP3
        {
            popClient = new MailMan();
            if (!popClient.UnlockComponent("MAIL-TEAMBEAN_4895F76A292K"))
                return false;
            popClient.MailHost = host;
            popClient.MailPort = port;
            popClient.PopUsername = username;
            popClient.PopPassword = password;

            if (SSL)
                popClient.PopSsl = true;
            else
                popClient.PopSsl = false;

            if (!popClient.VerifyPopConnection()) 
            {
                error = "Server";
                return false;
            }
            if (!popClient.VerifyPopLogin())
            {
                error = "Account";
                return false;
            }
            return true;
            
        }        
        #endregion

        /********************************************************************************/
        /***************************** Kiểm tra kết nối SMTP ****************************/
        #region smtpAuthentication
        public static bool smtpAuthentication(string hostSMTP, int portSMTP, string userName, string password)
        {
            #region Dùng Chilkat
            MailMan smtpTest = new MailMan();
            smtpTest.SmtpHost = hostSMTP;
            smtpTest.SmtpPort = portSMTP;
            smtpTest.SmtpUsername = userName;
            smtpTest.SmtpPassword = password;
            
            if (SSL)
                smtpTest.PopSsl = true;
            else
                smtpTest.PopSsl = false;

            Email mail = new Email();
            mail.From = userName;
            mail.AddTo("", userName);
            mail.Subject = "Test mail";
            mail.SetHtmlBody("<html><body><b><font color='red' size='+1'>Thư kiểm tra</font></b></html>");

            if (smtpTest.SendEmail(mail))
                return true;
            else
                return false;
            #endregion
            
        }

        #endregion 

        /********************************************************************************/
        /******************************** Các hàm hỗ trợ ********************************/
        #region Functions support
        public static string AccountLogin(string EmailAddress)
        {
            string s = EmailAddress;
            switch (Login)
            {
                case 1:
                    s = EmailAddress.Substring(0, EmailAddress.LastIndexOf("@"));
                    break;
                case 2:
                    s = domain + "_" + s.Substring(0, EmailAddress.LastIndexOf("@"));
                    break;
            }
            return s;
        }

        public static bool SetConfigInfo()
        {
            if (File.Exists(fileName))
            {
                DataSet ds = new DataSet();
                ConfigFile.ReadXML(fileName, ds);
                Host = HostSMTP = ds.Tables[0].Rows[0]["Host"].ToString();
                Port = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["Port"]);
                domain = ds.Tables[0].Rows[0]["Domain"].ToString();
                PortSMTP = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["PortSMTP"].ToString());
                SSL = ((ds.Tables[0].Rows[0]["SSL"].ToString().Equals("0")) ? false : true);
                SSLSMTP = ((ds.Tables[0].Rows[0]["SSLSMTP"].ToString().Equals("0")) ? false : true);
                Login = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["Login"].ToString());
                if (domain[0].ToString() == "@")
                    domain.Remove(0, 1);
                return true;
            }
            else
                return false;
        }

        public static bool AddMessageAccount()
        {
            Server server = new Server();
            try
            {
                server.Connect(Host, "Administrator", "");
                LumiSoft.MailServer.API.UserAPI.User newAccount = server.VirtualServers[0].Users.Add(FrameworkParams.currentUser.username,
                    ((FrameworkParams.currentUser.fullname!=null)? FrameworkParams.currentUser.fullname: ""),
                    (FrameworkParams.currentUser.id.ToString() + "_protocolvn"),
                    "", 0, true, UserPermissions_enum.All);
                newAccount.EmailAddresses.Add(FrameworkParams.currentUser.username.ToString() + "@" + domain);
                newAccount.Commit();
                server.Disconnect();      
                
                return true;
            }
            catch(Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }
        
        #endregion
    }
}
