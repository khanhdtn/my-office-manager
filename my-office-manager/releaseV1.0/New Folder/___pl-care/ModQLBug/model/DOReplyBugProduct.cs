using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;

namespace DTO
{
    public class DOReplyBugProduct:DOPhieu
    {
        #region Field
        private Int64 id;
        private Int64 bug_id;
        private Int64 nguoi_gui;
        private string nguoi_nhan;
        private DateTime ngay_gui;
        private byte[] noi_dung;
        private DataSet _DSFile;

        public DataSet DSFile
        {
            get { return _DSFile; }
            set { _DSFile = value; }
        }
        public DataSet GetDSFile() { return _DSFile; }
        public Int64 ID
        {
            get { return id; }
            set { id = value; }
        }
        public Int64 GetID() { return id; }
        public Int64 BUG_ID
        {
            get { return bug_id; }
            set { bug_id = value; }

        }
        public Int64 GetBUG_ID() { return bug_id; }
        public Int64 NGUOI_GUI
        {
            get { return nguoi_gui; }
            set { nguoi_gui = value; }
        }
        public Int64 GetNGUOI_GUI() { return nguoi_gui; }
        public string NGUOI_NHAN
        {
            get { return nguoi_nhan; }
            set { nguoi_nhan = value; }
        }
        public string GetNGUOI_NHAN() { return nguoi_nhan; }
        public DateTime NGAY_GUI
        {
            get { return ngay_gui; }
            set { ngay_gui = value; }
        }
        public DateTime GetNGAY_GUI() { return ngay_gui; }
        public byte[] NOI_DUNG
        {
            get { return noi_dung; }
            set { noi_dung = value; }
        }
        public byte[] GetNOI_DUNG() { return noi_dung; }
            
        #endregion

        #region Contructor
        public DOReplyBugProduct() { }
        public DOReplyBugProduct(DataRow r)
        {
            id=HelpNumber.ParseInt64(r["ID"]);
            bug_id=HelpNumber.ParseInt64(r["BUG_ID"]);
            nguoi_gui=HelpNumber.ParseInt64(r["NGUOI_GUI"]);
            nguoi_nhan = r["NGUOI_NHAN"].ToString();
            ngay_gui=(DateTime)r["NGAY_GUI"];
            noi_dung=(byte[])r["NOI_DUNG"];
        }
        public DOReplyBugProduct(long ID, long BugID, long NguoiGuiID, string NguoiNhanID, DateTime NgayGui, byte[] NoiDung) {
            this.id = ID;
            this.bug_id = BugID;
            this.nguoi_gui = NguoiGuiID;
            this.nguoi_nhan = NguoiNhanID;
            this.ngay_gui = NgayGui;
            this.noi_dung = NoiDung;
        }
        #endregion
    }
}
