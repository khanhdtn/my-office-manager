using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Chilkat;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace pl.mail
{
    public class NodeId
    {
        private int _POS;
        public int POS
        {
            get { return _POS; }
            set
            {
                _POS = value;
            }
        }
        private Int32 _ID;
        public Int32 ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }

        public NodeId()
        {
        }
        public NodeId(Int32 id, int pos)
        {
            this._ID = id;
            this._POS = pos;
        }
    }

    public class Folder : Connect
    {
        #region Initialization
        public Folder() { }
        public Folder(string userMail, string password)
        {
            UserName = userMail;
            Password = password;
        }
        #endregion

        /********************************************************************************/
        /* INFOMATION ABOUT: 
         * - List: Folder's name
         * - Datatable: how many messages in each folder, how many maeesages unread
         * - Datatable: infomations of messages in a folder 
         * - Update infomation of messages for a table
         */
        #region ListFolder, FolderMessage, ListMessage
        public List<string> ListFolder()    // list name of folders
        {
            List<string> lst = new List<string>();

            if (frmMessage.isConnectPrivateMailServer == false) return null;
            if (!imapConnect()) return null;

            Mailboxes mailbox = imapClient.ListMailboxes("", "*");
            for (int i =0;i<mailbox.Count;i++)            
                lst.Add(mailbox.GetName(i));

            imapDisconnect();            
            return lst;
        }

        public DataTable FolderMessage(string UserId)//Info about each folder, group it's belong and unread message in that folder of UesrID
        {
            DataTable dtb = new DataTable("FolderMessage");
            dtb.Columns.Add("Folder");
            dtb.Columns.Add("Group"); // 0= System group; 1= Mailbox outside; 2= Mailbox private;
            dtb.Columns.Add("UnReads", Type.GetType("System.Int32"));

            if (frmMessage.isConnectPrivateMailServer == false) return dtb;
            if (!imapConnect()) return dtb;
           
            Mailboxes mailbox = imapClient.ListMailboxes("", "*");
            // iterate through the collection to get folder info one by one
            for (int i =0;i < mailbox.Count;i++)
            {
                //Console.WriteLine("Folder name is " + nameFolder);
                string nameFolder = mailbox.GetName(i);
                DataRow dr = dtb.NewRow();
                dr["Folder"] = nameFolder;
                dr["Group"] = 2;

                if ((nameFolder == "Inbox") | (nameFolder == "Deleted Items") | (nameFolder == "Drafts")
                    | (nameFolder == "Junk E-mail") | (nameFolder == "Sent Items"))
                {
                    dr["Group"] = 0;
                }
                else
                {
                    DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM MAILINFO WHERE IDUSER=" + UserId);
                    DataSet ds = new DataSet();
                    ds = DABase.getDatabase().LoadDataSet(command, "MAILINFO");
                    foreach (DataRow sdr in ds.Tables["MAILINFO"].Rows)
                    {
                        if (nameFolder == sdr["FOLDER"].ToString())
                        {
                            dr["Group"] = 1;
                            break;
                        }
                    }
                }
                if ((nameFolder == "Deleted Items") | (nameFolder == "Drafts")
                    | (nameFolder == "Junk E-mail") | (nameFolder == "Sent Items"))
                {
                    dr["UnReads"] = 0;
                }
                else
                {
                    if (imapClient.SelectMailbox(nameFolder))
                    {
                        MessageSet mailSet = imapClient.Search("UNFLAGGED", true);
                        //MessageSet mailSet = imapClient.Search("UNSEEN", true);
                        dr["UnReads"] = mailSet.Count;
                    }
                    else
                        dr["UnReads"] = 0;
                }

                dtb.Rows.Add(dr);
            }      
        
            imapDisconnect();            
            return dtb;
        }

        public DataTable ListMessage(string FolderName, int? NumLastMessage) // table of messages's info in FolderName
        {
            DataTable dtb = new DataTable(FolderName);
            dtb.Columns.Add("ID", Type.GetType("System.Int32"));
            dtb.Columns.Add("Answered");
            dtb.Columns.Add("TypeMessage");
            dtb.Columns.Add("Readed");
            dtb.Columns.Add("From");
            dtb.Columns.Add("Subject");
            dtb.Columns.Add("Date", Type.GetType("System.DateTime"));
            dtb.Columns.Add("Attachments");

            DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM FW_DM_EMAIL_TYPE");
            DataSet ds = new DataSet();
            ds = DABase.getDatabase().LoadDataSet(command, "TYPEMAIL");

            if (frmMessage.isConnectPrivateMailServer == false) return dtb;
            if (!imapConnect()) return dtb;
            
           
            if(!imapClient.SelectMailbox(FolderName))
                return dtb;
            MessageSet mess = imapClient.Search("ALL", true);
            EmailBundle bundle = imapClient.FetchBundle(mess);

            int intStart;
            if (NumLastMessage == null)
                intStart = 0;
            else
                intStart = bundle.MessageCount - NumLastMessage.Value;
            for (int i = intStart; i < bundle.MessageCount; i++)
            {
                Email msif = bundle.GetEmail(i);

                DataRow dr = dtb.NewRow();
                dr["ID"] = mess.GetId(i);
                for (int j = msif.NumHeaderFields - 1; j >= 0; j--)
                {
                    if (msif.GetHeaderFieldName(j) == "ckx-imap-answered")
                    {
                        if (msif.GetHeaderFieldValue(j) == "YES")
                            dr["Answered"] = "Reply";
                        else
                            dr["Answered"] = "None";
                        break;
                    }
                }                

                bool read = false;
                for (int j = msif.NumHeaderFields - 1; j >= 0; j--)
                {
                    if (msif.GetHeaderFieldName(j) == "ckx-imap-flagged")
                    {
                        if (msif.GetHeaderFieldValue(j) == "YES")
                            read = true;
                        else
                            read = false;
                        break;
                    }
                }
                
                if (read)
                    dr["Readed"] = "Read";
                else
                    dr["Readed"] = "Unread";
                dr["From"] = (msif.FromName != "") ? msif.FromName : msif.FromAddress;
                dr["Subject"] = msif.Subject;
                dr["Date"] = msif.LocalDate;
                if (msif.NumAttachments > 0)
                    dr["Attachments"] = "Attach";
                else
                    dr["Attachments"] = "None";

                string typeMessage = msif.GetHeaderField("TypeMessage");
                if (typeMessage != null)
                {
                    for (int j = 1; j < ds.Tables["TYPEMAIL"].Rows.Count; j++)
                    {
                        DataRow newdr = ds.Tables["TYPEMAIL"].Rows[j];
                        if (typeMessage == newdr[0].ToString())
                        {
                            dr["TypeMessage"] = newdr[1].ToString();
                            break;
                        }
                    }
                }

                if (!read)
                {
                    if (((FolderName == "Deleted Items") | (FolderName == "Drafts")
                            | (FolderName == "Junk E-mail") | (FolderName == "Sent Items")))
                        dr["Readed"] = "Read";
                    
                }

                dtb.Rows.Add(dr);
            }
            imapDisconnect();
            
            return dtb;
        }

        public int UpdateTableMessage(ref DataTable table)
        {
            string FolderName = table.TableName;

            DbCommand command = DABase.getDatabase().GetSQLStringCommand("SELECT * FROM DM_LOAITHU");
            DataSet ds = new DataSet();
            ds = DABase.getDatabase().LoadDataSet(command, "TYPEMAIL");

            if (frmMessage.isConnectPrivateMailServer == false) return -1;
            if (!imapConnect()) return -1;                   
            
            if (!imapClient.SelectMailbox(FolderName)) return -1;
            
            MessageSet mess = imapClient.Search("ALL", true);
            EmailBundle bundle = imapClient.FetchBundle(mess);                
            if (bundle.MessageCount == table.Rows.Count)//don't have new message
                return 0;
            
            List<int> SetOldID = new List<int>();
            foreach (DataRow dr in table.Rows) //get id of messages in table
            {
                SetOldID.Add((int)dr["ID"]);
            }

            List<NodeId> SetNewID = new List<NodeId>();
            for (int i = 0; i < bundle.MessageCount; i++) // get id of messages in Folder
            {
                //Email msif = bundle.GetEmail(i);
                NodeId node = new NodeId(mess.GetId(i), i);
                SetNewID.Add(node);
            }
                
            foreach (int oldId in SetOldID) // Xor to get new message
            {                    
                foreach(NodeId node in SetNewID)
                {
                    if (oldId == node.ID)
                    {
                        SetNewID.Remove(node);
                        break;
                    }
                }                   
            }

            foreach (NodeId node in SetNewID)   // add infomation of new message to table 
            {                
                Email msif = bundle.GetEmail(node.POS);
                imapClient.SetFlag(node.ID, true, "Seen", 0);
                DataRow dr = table.NewRow();

                dr["ID"] = mess.GetId(node.POS);
                for (int j = msif.NumHeaderFields - 1; j >= 0; j--)
                {
                    if (msif.GetHeaderFieldName(j) == "ckx-imap-answered")
                    {
                        if (msif.GetHeaderFieldValue(j) == "YES")
                            dr["Answered"] = "Reply";
                        else
                            dr["Answered"] = "None";
                        break;
                    }
                }    
                            
                
                dr["Readed"] = "Unread";
                dr["From"] = (msif.FromName != "") ? msif.FromName : msif.FromAddress;
                dr["Subject"] = msif.Subject;
                dr["Date"] = msif.LocalDate;
                if (msif.NumAttachments > 0)
                    dr["Attachments"] = "Attach";
                else
                    dr["Attachments"] = "None";

                string typeMessage = msif.GetHeaderField("TypeMessage");
                if (typeMessage != null)
                {
                    for (int j = 1; j < ds.Tables["TYPEMAIL"].Rows.Count; j++)
                    {
                        DataRow newdr = ds.Tables["TYPEMAIL"].Rows[j];
                        if (typeMessage == newdr[0].ToString())
                        {
                            dr["TypeMessage"] = newdr[1].ToString();
                            break;
                        }
                    }
                }
                               
                table.Rows.Add(dr);
            }
            
            imapDisconnect();
            return SetNewID.Count;
        }
        #endregion

        /********************************************************************************/
        /************************ NEW, RENAME, AND DELETE FOLDER ************************/
        #region New, Rename, Delete Folder
        public bool NewFolder(string FolderName)    // Make new folder
        {
            if (frmMessage.isConnectPrivateMailServer == false) return false;
            if (!imapConnect()) return false;
           
            if (imapClient.CreateMailbox(FolderName))
            {
                imapDisconnect();
                return true;
            }
            else
            {
                imapDisconnect();            
                return false;
            }
        }

        public bool RenameFolder(string FolderName, string NewFolderName) //Rename folder
        {
            if (frmMessage.isConnectPrivateMailServer == false) return false;
            if (!imapConnect()) return false;
            if (imapClient.RenameMailbox(FolderName,NewFolderName))
            {
                imapDisconnect();
                return true;
            }
            else
            {
                imapDisconnect();
                return false;
            }
        }

        public bool DeleteFolder(string FolderName) //Rename folder
        {
            if (frmMessage.isConnectPrivateMailServer == false) return false;
            if (!imapConnect()) return false;
            if (imapClient.DeleteMailbox(FolderName))
            {
                imapDisconnect();
                return true;
            }
            else
            {
                imapDisconnect();
                return false;
            }
        }
        #endregion
        
    }
}
