using System;
using System.Collections.Generic;
using System.Text;
using LumiSoft.Net.Mime;
using ProtocolVN.Framework.Core;
using System.Data;
using LumiSoft.Net.SMTP.Client;
using ProtocolVN.Framework.Win;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace ProtocolVN.App.Office
{
    public class HelpZPLOEmail
    {
        public static AddressList GetAddressList(long[] Keys)
        {
            QueryBuilder query = new QueryBuilder(@"SELECT e.ID, e.NAME, cat.USERID as ID, cat.USERNAME, e.EMAIL FROM USER_CAT cat left join DM_NHAN_VIEN e on e.ID=cat.EMPLOYEE_ID WHERE 1=1");
            query.addBoolean("e.VISIBLE_BIT", true);
            query.addCondition("(EMAIL<>'')");
            if (Keys.Length > 0)
                query.addID("e.ID", Keys);
            DataSet dsTo = HelpDB.getDatabase().LoadDataSet(query, "CAT");

            AddressList to = new AddressList();
            foreach (DataRow row in dsTo.Tables[0].Rows)
            {
                if (!to.ToAddressListString().Contains(row["EMAIL"].ToString()))
                    to.Add(new MailboxAddress(row["NAME"].ToString(), row["EMAIL"].ToString()));
            }

            return to;
        }

        #region Chuyển sang dùng hàm SendMail của lớp Help
        public static bool SendSmartHost(string codeOpenForm, string Title, string DisplayFrom, AddressList To,
            AddressList CC, AddressList Bcc, string Subject, string File)
        {
            if (codeOpenForm != null && codeOpenForm != "")
            {
                Subject += "<br>__________________________________________</br>";
                Subject += "<br><i>" + codeOpenForm + "<i></br>";
            }
            return HelpEmail.SendSmartHost(Title, DisplayFrom, To, CC, Bcc, Subject, File);
        }
        #endregion

        /// <summary>
        /// CHAUTV : 
        /// </summary>
        public static bool SendEmails(string sTitle, Dictionary<string, string> dToAddress, 
            string sToTitle, string sSubject, string sBody, Dictionary<string, string> dCC, 
            string sFile)
        {
            return HelpEmail.SendEmails(sTitle, dToAddress, sToTitle, sSubject, sBody, dCC, sFile);
        }
    }
}
