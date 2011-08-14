using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.Framework.Core;
using office;
using ProtocolVN.DanhMuc;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraRichEdit;
using DTO;

namespace office.Training.ModDienDan
{
    public partial class ucBaiViet : UserControl
    {
        #region Các khai báo biến
        private long NguoiTaoBaiVietGoc;
        private DOBaiViet doBaiViet;
        private string FieldFileName = "TEN_FILE";
        private string FieldNoiDung = "NOI_DUNG";
        public delegate void _AfterDeleteSuccessfully(ucBaiViet sender);
        public event _AfterDeleteSuccessfully AfterDeleteSuccessfully;
        public delegate void _AfterUpdateSuccessfully(ucBaiViet sender);
        public event _AfterUpdateSuccessfully AfterUpdateSuccessfully;
        public delegate void _AfterReplySuccessFully(DTO.DOBaiViet BaiViet);
        public event _AfterReplySuccessFully AfterReplySuccessFully;
        private DataTable dtListFile;
        private Form parentForm;
        private DevExpress.XtraEditors.VScrollBar richVSrollBar;
        #endregion

        #region Các hàm khởi tạo 
        public ucBaiViet()
        {
            InitializeComponent();
        }
        public ucBaiViet(Form parentForm, long NguoiTaoBaiVietGoc, DOBaiViet doBaiViet)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.doBaiViet = doBaiViet;
            this.NguoiTaoBaiVietGoc = NguoiTaoBaiVietGoc;
            lblNguoi_gui.Text = DMFWNhanVien.GetFullName(doBaiViet.NGUOI_GUI);
            lblThoiGian.Text = doBaiViet.NGAY_GUI.ToString(PLConst.FORMAT_DATETIME_STRING);
            richVSrollBar = GetVScrollBar(richEditContent);
            UpdateContent(doBaiViet.NOI_DUNG, doBaiViet.DSTapTinDinhKem);
        }

        //private void Web_BaiViet_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    if (this.Web_BaiViet.Document.Body != null)
        //    {

        //        this.Height = this.Web_BaiViet.Document.Body.ScrollRectangle.Height + (this.groupControl1.Height - Web_BaiViet.Height) + 30;
               
        //    }
        //}

        
        #endregion

        private DevExpress.XtraEditors.VScrollBar GetVScrollBar(RichEditControl rich)
        {
            foreach (Control c in rich.Controls)
            {
                if (c is DevExpress.XtraEditors.VScrollBar)
                {
                    return ((DevExpress.XtraEditors.VScrollBar)c);
                }
            }
            return null;
        }

        public void UpdateContent(object Bytes_Noi_dung,
            DataSet DSListFile)
        {
            UpdateButton();
            if (doBaiViet.ID_BAI_VIET_PARENT <= 0)
            {
                this.groupControl1.ShowCaption = true;
                this.groupControl1.Text = "Chủ đề: " + doBaiViet.CHU_DE.ToUpper();
            }
            flowLayoutPanel2.Controls.Clear();
            dtListFile = DSListFile.Tables[0];
            flowLayoutPanel2.Height = 26;
            if (DSListFile != null && DSListFile.Tables.Count > 0)
            {
                int wi = 0;
                foreach (DataRow r in dtListFile.Rows)
                {
                    Label lb = new Label();
                    lb.AutoSize = true;
                    lb.ForeColor = Color.Blue;
                    lb.Font = new Font(lblNguoi_gui.Font, FontStyle.Underline);
                    lb.Cursor = System.Windows.Forms.Cursors.Hand;
                    lb.MouseHover += new EventHandler(lb_MouseHover);
                    lb.MouseLeave += new EventHandler(lb_MouseLeave);
                    lb.Click += new EventHandler(lb_Click);
                    lb.Text = r[FieldFileName].ToString();
                    if (r[FieldNoiDung] != DBNull.Value)
                        lb.Tag = (byte[])r[FieldNoiDung];
                    flowLayoutPanel2.Controls.Add(lb);
                    wi += lb.Width;
                    if (wi >= flowLayoutPanel2.Width)
                    {
                        flowLayoutPanel2.Height += lb.Height;
                        wi = 0;
                    }
                }
                xtraScrollableControl1.HorizontalScroll.Visible = false;

            }

            if (Bytes_Noi_dung != null && Bytes_Noi_dung != DBNull.Value)
            {
                doBaiViet.NOI_DUNG = (byte[])Bytes_Noi_dung;

                //richEditContent.RtfText = HelpByte.BytesToUTF8String(doBaiViet.NOI_DUNG);
                ProtocolVN.App.Office.AppCtrl.SetRichText(richEditContent, doBaiViet.NOI_DUNG,true);


            }
            else
                this.doBaiViet.NOI_DUNG = new byte[0];

        }
        public void UpdateButton()
        {
            if (FrameworkParams.currentUser.username != "admin" &&
               FrameworkParams.currentUser.employee_id != doBaiViet.NGUOI_GUI)
            {
                if (FrameworkParams.currentUser.employee_id == NguoiTaoBaiVietGoc)
                    btnUpdate.Visible = false;
                else
                {
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                }
            }

        }
        public DOBaiViet DoBaiViet
        {
            get
            {
                return doBaiViet;
            }
        }
        private void lb_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb.Tag == null) return;
            frmSaveOpen frm = new frmSaveOpen((byte[])lb.Tag, lb.Text);
            HelpProtocolForm.ShowModalDialog((XtraFormPL)parentForm, frm);
        }

        private void lb_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void lb_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Red;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa?") == DialogResult.Yes)
            {
                if (this.doBaiViet.ID_BAI_VIET_PARENT <= 0 &&
                DienDanPermission.I._checkPermissionRes(doBaiViet.ID_CHUYEN_MUC, PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa bài viết này!");
                    return;
                }
                if (DABaiViet.Instance.Delete(this.doBaiViet.ID))
                {
                    this.Parent.Controls.Remove(this);
                    AfterDeleteSuccessfully(this);
                }
                else
                {
                    HelpPhieuMsg.ErrorDeleted();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.doBaiViet.ID_BAI_VIET_PARENT <= 0 &&
                DienDanPermission.I._checkPermissionRes(doBaiViet.ID_CHUYEN_MUC, PermissionOfResource.RES_PERMISSION_TYPE.UPDATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền sửa bài viết này!");
                return;
            }
            if (this.doBaiViet.ID_BAI_VIET_PARENT<=0 && DABaiViet.Instance.Da_tra_loi(this.doBaiViet.ID)==false)
            {
                frmBaiVietEtx frm = new frmBaiVietEtx(doBaiViet,false);
                frm.AfterUpdateSuccesfully += new frmBaiVietEtx._AfterUpdateSuccesfully(frm_AfterUpdateSuccesfully);
                frm.AfterDeleteSuccesfully += new frmBaiVietEtx._AfterDeleteSuccesfully(frm_AfterDeleteSuccesfully);
                ProtocolForm.ShowModalDialog((XtraFormPL)parentForm, frm);
                
            }
            else
            {
                frmReplyForum frm = new frmReplyForum(doBaiViet, false);
                frm.AfterUpdateSuccesfully += new frmReplyForum._AfterUpdateSuccesfully(frm_AfterUpdateSuccesfully);
                frm.AfterDeleteSuccesfully += new frmReplyForum._AfterDeleteSuccesfully(frm_AfterDeleteSuccesfully);
                ProtocolForm.ShowModalDialog((XtraFormPL)this.parentForm, frm);
            }

            if (AfterUpdateSuccessfully != null)
                AfterUpdateSuccessfully(this);
        }
        private void frm_AfterDeleteSuccesfully(DTO.DOBaiViet BaiViet)
        {
            this.Parent.Controls.Remove(this);
            AfterDeleteSuccessfully(this);
        }
        
        private void frm_AfterUpdateSuccesfully(RichEditControl sender,DTO.DOBaiViet BaiViet)
        {
            DevExpress.XtraEditors.VScrollBar vs = this.GetVScrollBar(sender);
            this.richVSrollBar.Maximum = vs.Maximum;
            this.UpdateContent(
               BaiViet.NOI_DUNG, BaiViet.DSTapTinDinhKem
               );
        }  
        private void btnReply_Click(object sender, EventArgs e)
        {
            frmReplyForum frm = new frmReplyForum(true,doBaiViet);
            frm.AfterAddSuccesfully += new frmReplyForum._AfterAddSuccesfully(frm_AfterAddSuccesfully);
            ProtocolForm.ShowModalDialog((XtraFormPL)parentForm, frm);
        }
        private void frm_AfterAddSuccesfully(DTO.DOBaiViet BaiViet)
        {
            if (AfterReplySuccessFully != null)
                AfterReplySuccessFully(BaiViet);
        }

        private void richEditControl1_DocumentLoaded(object sender, EventArgs e)
        {
            if (richVSrollBar != null)
            {
                double contentheight = (double)richVSrollBar.Maximum / (3);
                this.Height = ((int)contentheight) + (this.groupControl1.Height - richEditContent.Height) + 10;
            }
            else
            {
                richEditContent.Options.VerticalScrollbar.Visibility = RichEditScrollbarVisibility.Auto;
            }
        }

       
       

     

     
        //private string GetRTFLink(DataTable dt)
        //{
        //    string init = @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}{\*\cs2\sbasedon1\cf0 Line Number;}{\*\cs3\ul\cf1\ulc1 Hyperlink;}}\sectd\pard\plain\qr@%$#&\ul\fs17\par}";
        //    //string init = @"{\rtf1\deff0{\fonttbl{\f0 Times New Roman;}}{\colortbl\red0\green0\blue0 ;\red0\green0\blue255 ;}{\*\listoverridetable}{\stylesheet {\ql\cf0 Normal;}{\*\cs1\cf0 Default Paragraph Font;}{\*\cs2\sbasedon1\cf0 Line Number;}{\*\cs3\ul\cf1\ulc1 Hyperlink;}}\sectd\pard\plain\ql@%$#&\par}";
        //    string oneLink = @"{\field{\*\fldinst{\cf0 HYPERLINK `!*&?_}}{\fldrslt{\ul\cf1\ulc1\cs3 %$%&*@!#}}}";
        //    string space = @"{\cf0 ; }";
        //    string strLink = "";
        //    int i = 0;
        //    foreach (DataRow r in dt.Rows)
        //    {
        //        string p = "\"" + r["ID"] + "\"";
        //        strLink += oneLink.Replace("`!*&?_", p).Replace("%$%&*@!#", r[FieldFileName].ToString());
        //        if (i < dt.Rows.Count)
        //            strLink += space;
        //        i++;
        //    }
        //    return init.Replace("@%$#&", strLink);
        //}
        
    }
}
