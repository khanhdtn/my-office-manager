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
using System.Data.Common;
using DevExpress.XtraGrid.Columns;
/*
 * Tác giả : Trần Văn Châu
 */
namespace office
{
    //public enum SendType
    //{
    //    SmartHost = 1,
    //    DNS = 2
    //}

    public partial class frmSendEmail : XtraFormPL
    {
        public DXErrorProvider errorProvider;
        private AddressList EmailNguoiNhan;
        private AddressList EmailNguoiGui;
        private long NguoiNhan;
        private long IDPhieu;
        string formClass;

        public frmSendEmail(long IDPhieu, string formClass, long NguoiNhan,
            DevExpress.XtraGrid.Views.Grid.GridView gridViewMaster, bool UseExport)
        {
            if (Init(IDPhieu,formClass,NguoiNhan) == false) return;
            string line = "______________________________________________________________________________";
            if (UseExport)
            {
                string path = Path.GetTempFileName();
                bool temp = gridViewMaster.OptionsPrint.PrintSelectedRowsOnly;
                gridViewMaster.OptionsPrint.PrintSelectedRowsOnly = true;
                gridViewMaster.OptionsPrint.AutoWidth = true;
                gridViewMaster.ExportToHtml(path);

                gridViewMaster.OptionsPrint.PrintSelectedRowsOnly = temp;
                NoiDung.richEditControl.LoadDocument(path, DevExpress.XtraRichEdit.DocumentFormat.Html);
                try
                {
                    File.Delete(path);
                }
                catch
                {

                }
                NoiDung.richEditControl.Document.InsertText(NoiDung.richEditControl.Document.Range.End, line);


            }
            else
            {
                int focus = gridViewMaster.FocusedRowHandle;
                if (focus <= -1)
                {
                    HelpXtraForm.CloseFormNoConfirm(this);
                    return;
                }
                NoiDung.richEditControl.Document.InsertText(NoiDung.richEditControl.Document.Range.Start,line);
                NoiDung.richEditControl.Document.InsertParagraph(NoiDung.richEditControl.Document.Range.End);
                foreach (GridColumn col in gridViewMaster.VisibleColumns)
                {
                    NoiDung.richEditControl.Document.InsertSingleLineText(
                        NoiDung.richEditControl.Document.Range.End,
                    col.Caption + ": " + gridViewMaster.GetRowCellDisplayText(focus, col));
                    NoiDung.richEditControl.Document.InsertParagraph(NoiDung.richEditControl.Document.Range.End);
                }
                NoiDung.richEditControl.Document.InsertText(NoiDung.richEditControl.Document.Range.End,line);
                

            }
            
        }


        private bool Init(long IDPhieu, string formClass,long NguoiNhan)
        {
            try
            {
                InitializeComponent();
                this.IDPhieu = IDPhieu;
                this.formClass = formClass;
                HelpXtraForm.SetCloseForm(this, this.btnClose, null);
                this.NguoiNhan = NguoiNhan;
                NoiDung.richEditControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;               
                this.labelControl3.Text = DMFWNhanVien.GetFullName(NguoiNhan);
                plMultiChoiceFiles1._Init(true, "TEN_FILE", "NOI_DUNG", -1);
                DataTable dt = new DataTable();
                dt.Columns.Add("TEN_FILE");
                dt.Columns.Add("NOI_DUNG", typeof(byte[]));
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                plMultiChoiceFiles1._DataSource = ds;

                this.errorProvider = new DXErrorProvider();
                PLGUIUtil.setDefaultSize(this);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool CheckValidation()
        {
            bool bFlag = true;
            this.errorProvider.ClearErrors();
            bFlag = GUIValidation.ShowRequiredError(this.errorProvider, new object[] { 
                    this.textSubject,"Tiêu đề"
                });
            if (radioGroup1.EditValue.ToString() == "Y")
            {
                EmailNguoiGui = this.GetAddressList(FrameworkParams.currentUser.employee_id);
                if (EmailNguoiGui.Count == 0)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn hiện chưa có địa chỉ email hoặc địa chỉ email không hợp lệ, vui lòng kiểm tra lại!");
                    return false;
                }
                EmailNguoiNhan = this.GetAddressList(NguoiNhan);
                if (EmailNguoiNhan.Count == 0)
                {
                    HelpMsgBox.ShowNotificationMessage("Người nhận hiện chưa có địa chỉ email hoặc địa chỉ email không hợp lệ, vui lòng kiểm tra lại!");
                    return false;
                }
            }
            return bFlag;
        }

        private Mime CreateMessage()
        {

            Mime m = new Mime();
            MimeEntity texts_enity = null;
            MimeEntity attachments_entity = null;

            //Văn bản
            if (plMultiChoiceFiles1._DataSource != null)
                plMultiChoiceFiles1._DataSource.AcceptChanges();
            if (plMultiChoiceFiles1._DataSource != null && plMultiChoiceFiles1._DataSource.Tables.Count > 0 && plMultiChoiceFiles1._DataSource.Tables[0].Rows.Count > 0)
            {
                m.MainEntity.ContentType = MediaType_enum.Multipart_mixed;
                texts_enity = m.MainEntity.ChildEntities.Add();
                texts_enity.ContentType = MediaType_enum.Multipart_alternative;
                attachments_entity = m.MainEntity;
                foreach (DataRow row in plMultiChoiceFiles1._DataSource.Tables[0].Rows)
                {
                    MimeEntity attachment_entity = attachments_entity.ChildEntities.Add();
                    attachment_entity.ContentType = MediaType_enum.Application_octet_stream;
                    attachment_entity.ContentTransferEncoding = ContentTransferEncoding_enum.Base64;
                    attachment_entity.ContentDisposition = ContentDisposition_enum.Attachment;
                    attachment_entity.ContentDisposition_FileName = row["TEN_FILE"].ToString();
                    attachment_entity.Data = (byte[])row["NOI_DUNG"];
                }
            }
            else
            {
                m.MainEntity.ContentType = MediaType_enum.Multipart_alternative;
                texts_enity = m.MainEntity;
            }

            ///Thông tin mail
            m.MainEntity.From = EmailNguoiGui;
            m.MainEntity.To = EmailNguoiNhan;
            m.MainEntity.Subject = this.textSubject.Text;


            ///Nội dung
            ///
            string html= this.NoiDung.richEditControl.HtmlText;
            html = html.Insert(html.IndexOf("</body>"),
              "<br>____________________________</br><br><i>" 
              + HelpAutoOpenForm.GeneratingCodeFromForm(formClass, IDPhieu) + "<i><br>");
            MimeEntity text_entity = texts_enity.ChildEntities.Add();
            text_entity.ContentType = MediaType_enum.Text_plain;
            text_entity.ContentType_CharSet = "utf-8";
            text_entity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
            text_entity.DataText =html;

            MimeEntity rtfText_entity = texts_enity.ChildEntities.Add();
            rtfText_entity.ContentType = MediaType_enum.Text_html;
            rtfText_entity.ContentType_CharSet = "utf-8";
            rtfText_entity.ContentTransferEncoding = ContentTransferEncoding_enum.Base64;
            rtfText_entity.DataText = html;
            return m;
        }

        private AddressList GetAddressList(long IDNhanVien)
        {
            QueryBuilder query = new QueryBuilder(@"SELECT e.NAME,e.email from  DM_NHAN_VIEN e WHERE 1=1");
            query.addID("e.ID", IDNhanVien);
            DataSet dsTo = HelpDB.getDatabase().LoadDataSet(query, "CAT");
            AddressList to = new AddressList();
            foreach (DataRow row in dsTo.Tables[0].Rows)
            {
                if (row["EMAIL"].ToString() == "") continue;
                to.Add(new MailboxAddress(row["NAME"].ToString(), row["EMAIL"].ToString()));
            }
            return to;
        }
        private DataSet GetListMail()
        {
            QueryBuilder query = new QueryBuilder(@"SELECT e.NAME, cat.USERID as ID, cat.USERNAME FROM USER_CAT cat left join DM_NHAN_VIEN e on e.ID=cat.EMPLOYEE_ID WHERE 1=1");
            query.addBoolean("e.VISIBLE_BIT", true);
            query.addCondition(@"(cat.USERNAME<>'')");
            DataSet dsTo = HelpDB.getDatabase().LoadDataSet(query);
            return dsTo;
        }
        private bool CreateBroadcast()
        {
            try
            {
                DateTime dt = HelpDB.getDatabase().GetSystemCurrentDateTime();
                FWDBService dbb = HelpDB.getDBService();
                DbCommand cmmd = dbb.GetSQLStringCommand(string.Format("select list(id,',') from dm_nhan_vien where id <> {0}", NguoiNhan));
                object obj = dbb.ExecuteScalar(cmmd);
                string id = "-1";
                if (obj != null && obj != DBNull.Value)
                {
                    id = id + "," + obj;
                }

                FWDBService db = HelpDB.getDBService();
                long ID = db.GetID("G_FW_ID");
                string str = @"insert into FW_BROADCAST 
                           values(@id,@nguoi_nhap,@ngay_nhap,@chu_de,@noi_dung,@NKCB) ";
                DbCommand cmd = db.GetSQLStringCommand(str);
                db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
                db.AddInParameter(cmd, "@NGUOI_NHAP", DbType.Int64, FrameworkParams.currentUser.employee_id);
                db.AddInParameter(cmd, "@NGAY_NHAP", DbType.DateTime, dt);
                db.AddInParameter(cmd, "@CHU_DE", DbType.String, textSubject.Text);
                db.AddInParameter(cmd, "@NOI_DUNG", DbType.Binary, HelpByte.UTF8StringToBytes(NoiDung.richEditControl.Text));
                db.AddInParameter(cmd, "@NKCB", DbType.String, id);
               return db.ExecuteNonQuery(cmd)>0;

            }
            catch { return false; }
        }
        #region Sự kiện

        private void btnSend_Click(object sender, EventArgs e)
        {
            GUIValidation.TrimAllData(new object[] { 
                this.textSubject,
            });

            if (!this.CheckValidation())
                return;
            this.Cursor = Cursors.WaitCursor;
            bool bFlag = true;
            try
            {
                FrameworkParams.wait = new WaitingMsg();

                if (radioGroup1.EditValue.ToString() == "Y")
                {
                    Mime message = CreateMessage();
                    SmtpClientEx.QuickSendSmartHost(
                        FrameworkParamsExt.ConfigEmail.SMTP,
                        FrameworkParamsExt.ConfigEmail.SMTP_PORT,
                        FrameworkParamsExt.ConfigEmail.SMTP_REQUIRES_AUTHENTICATIONS,"",
                        "",
                        "",
                        message);
                }
                else
                {
                    if (CreateBroadcast() == false)
                        bFlag = false;
                }
            }
            catch (Exception ex)
            {
                bFlag = false;
            }

            finally
            {
                if (FrameworkParams.wait != null)
                {
                    FrameworkParams.wait.Finish();
                }
            }
            this.Cursor = Cursors.Default;
            if (bFlag)
                this.Close();
            else
                HelpMsgBox.ShowErrorMessage("Gửi tin nhắn không thành công.\nVui lòng kiểm tra lại thông tin hoặc dữ liệu đang được sử dụng!");

        }
        #endregion

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            plMultiChoiceFiles1.Enabled = radioGroup1.EditValue.ToString() == "Y";
        }
    }
}