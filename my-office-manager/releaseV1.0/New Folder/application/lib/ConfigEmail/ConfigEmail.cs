using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;

namespace office
{
    public class ConfigEmail
    {
        private DataRow RowConfig=null;
        public ConfigEmail()
        {
            try
            {
                string sql = @"select SMTP, SMTP_PORT,POP,POP_PORT,               
                        EMAIL_USERNAME, EMAIL, PASS , PRIVATE_MAIL_SSLSMTP_BIT,TEN_NGUON_GUI from 
                        FW_SERVER_OPTION";
                DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    RowConfig = ds.Tables[0].Rows[0];
            }
            catch
            {
            }
        }
        public string SMTP
        {
            get
            {
                if (RowConfig != null)
                    return RowConfig["SMTP"].ToString();
                return "";
            }
        }
        public int SMTP_PORT
        {
            get
            {
                if (RowConfig != null)
                    return HelpNumber.ParseInt32(RowConfig["SMTP_PORT"]);
                return 25;

            }
        }
        public string POP
        {
            get
            {
                if (RowConfig != null)
                    return RowConfig["POP"].ToString();
                return "";
            }
        }
        public int POP_PORT
        {
            get
            {
                if (RowConfig != null)
                    return HelpNumber.ParseInt32(RowConfig["POP_PORT"]);
                return 25;
            }
        }
        public bool SMTP_REQUIRES_AUTHENTICATIONS
        {
            get
            {
                if (RowConfig != null)
                    return RowConfig["PRIVATE_MAIL_SSLSMTP_BIT"].ToString() == "Y";
                return false;
            }
        }
        public string EMAIL_REQUIRES_AUTHENTICATIONS
        {
            get
            {
                if (RowConfig != null)
                    return RowConfig["EMAIL_USERNAME"].ToString();
                return "";
            }
        }
        public string PASS_REQUIRES_AUTHENTICATIONS
        {
            get
            {
                if (RowConfig != null)
                    return RowConfig["PASS"].ToString();
                return "";
            }
        }
        public string SOURCES_EMAIL
        {
            get
            {
                if (RowConfig != null)
                    return RowConfig["EMAIL"].ToString();
                return "";
            }
        }
        public string SOURCES_NAME
        {
            get
            {
                if (RowConfig != null)
                    return RowConfig["TEN_NGUON_GUI"].ToString();
                return "";
            }
        }
    }
    public class FrameworkParamsExt
    {
        public static ConfigEmail ConfigEmail;
    }
}
