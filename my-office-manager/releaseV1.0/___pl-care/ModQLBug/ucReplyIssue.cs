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

namespace office
{
    public partial class ucReplyIssue : UserControl
    {
        #region Các khai báo biến
        private long _ID;
        private long _Nguoi_gui;
        private DateTime _Thoi_gian_gui;
        private byte[] _Noi_dung;
        private long NguoiTaoChuDe;
        private string FieldFileName;
        private string FieldNoiDung;
        private Form parentForm;
        private DevExpress.XtraEditors.VScrollBar richVSrollBar;

        public delegate void _AfterUpdateSuccessfully(ucReply sender);
        public event _AfterUpdateSuccessfully AfterUpdateSuccessfully;

        public delegate void _AfterDeleteSuccessfully();
        public event _AfterDeleteSuccessfully AfterDeleteSuccessfully;
        #endregion

        #region Các hàm khởi tạo 
        public ucReplyIssue()
        {
            InitializeComponent();
        }
        public ucReplyIssue(Form parentForm, long ID, long Nguoi_gui,
            DateTime Thoi_gian_gui,
            object Bytes_Noi_dung, DataSet dsListFile, string FieldFileName, string FieldNoiDung,long TinhTrang,params string[] ThongTinVanDe)
        {
            InitializeComponent();
            this._ID = ID;
            this.parentForm = parentForm;
            this.FieldFileName = FieldFileName;
            this.FieldNoiDung = FieldNoiDung;
            //Tình trạng là hoàn tất thì không cho chỉnh sửa.
            btnUpdate.Visible = TinhTrang == 3 ? false : true;
            UpdateContent(Nguoi_gui, Thoi_gian_gui, Bytes_Noi_dung, dsListFile, FieldFileName, FieldNoiDung);
            if (ThongTinVanDe.Length > 0)
            {
                groupControl1.Text = ThongTinVanDe[0];
                groupControl1.ShowCaption = true;
                lblTinhTrang.Text = ThongTinVanDe[1];
                btnDelete.Tag = "Delete_Issue";
            }
            else {
                btnDelete.Tag = "Delete_ReplyOfIssue";
                groupControl1.ShowCaption = false;
            }
            richVSrollBar = GetVScrollBar(richEditContent);
            richEditContent.DocumentLoaded += new EventHandler(richEditContent_DocumentLoaded);
        }

        void richEditContent_DocumentLoaded(object sender, EventArgs e)
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

        #endregion       

        public void UpdateContent(long Nguoi_gui,
            DateTime Thoi_gian_gui, object Bytes_Noi_dung,
            DataSet dsListFile,string FieldFileName,string FieldNoiDung,params object[] ThongTinYeuCau )
        {
            if (FrameworkParams.currentUser.username != "admin" &&
                FrameworkParams.currentUser.employee_id != Nguoi_gui)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            if (ThongTinYeuCau.Length > 0) {
                groupControl1.Text = ThongTinYeuCau[0].ToString();
                switch (ThongTinYeuCau[1].ToString()) { 
                    case "1":
                        lblTinhTrang.Text = "Mới tạo";
                            break;
                    case "2":
                        lblTinhTrang.Text = "Đang xử lý";
                        break;
                    default:
                        lblTinhTrang.Text = "Hoàn tất";
                        break;
                }
            }
            this._Nguoi_gui = Nguoi_gui;
            this._Thoi_gian_gui = Thoi_gian_gui;

            if (dsListFile != null && dsListFile.Tables.Count > 0)
            {
                int wi = 0;
                foreach (DataRow r in dsListFile.Tables[0].Rows)
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
            lblNguoi_gui.Text = DMFWNhanVien.GetFullName(Nguoi_gui);
            lblThoiGian.Text = Thoi_gian_gui.ToString(PLConst.FORMAT_DATETIME_STRING);
            if (Bytes_Noi_dung != null && Bytes_Noi_dung != DBNull.Value)
            {
                this._Noi_dung = (byte[])Bytes_Noi_dung;
                richEditContent.RtfText = HelpByte.BytesToUTF8String(this._Noi_dung);
            }
            else
                this._Noi_dung = new byte[0];

        }
       
        public long ID
        {
            get
            {
                return this._ID;
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
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa dữ liệu đang chọn không?") == DialogResult.Yes)
            {
                if (btnDelete.Tag.Equals("Delete_ReplyOfIssue"))
                {
                    if (DAReplyBugProduct.Instance.Delete(this.ID))
                        this.Parent.Controls.Remove(this);
                    else
                        HelpPhieuMsg.ErrorDeleted();
                }
                else {
                    if (DABugProduct.Instance.Delete(this.ID))
                    {
                        HelpXtraForm.CloseFormNoConfirm((XtraForm)this.FindForm());
                        if (AfterDeleteSuccessfully != null) AfterDeleteSuccessfully();
                    }
                    else
                        HelpPhieuMsg.ErrorDeleted();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dtReplyIssue = DABugProduct.Get_Reply_Issue(_ID);
            if (dtReplyIssue.Rows.Count > 0)
            {
                DataRow row = dtReplyIssue.Rows[0];
                frmBugProduct frm = new frmBugProduct(HelpNumber.ParseInt64(row["BUG_ID"]), false, new long[] { _ID });
                frm.AfterUpdateReplyIssueSuccessfully += new frmBugProduct._AfterUpdateReplyIssueSuccessfully(frm_AfterUpdateReplyIssueSuccessfully);
                frm.AfterUpdateStatusOfIssue += new frmBugProduct._AfterUpdateStatusOfIssue(frm_AfterUpdateStatusOfIssue);
                HelpProtocolForm.ShowModalDialog((XtraFormPL)this.FindForm(), frm);
            }
            //Update issue
            else {
                frmBugProduct frm = new frmBugProduct(_ID, false);
                frm.AfterUpdateIssueSuccessfully +=new frmBugProduct._AfterUpdateIssueSuccessfully(frm_AfterUpdateIssueSuccessfully);
                frm.AfterUpdateStatusOfIssue += new frmBugProduct._AfterUpdateStatusOfIssue(frm_AfterUpdateStatusOfIssue);
                HelpProtocolForm.ShowModalDialog((XtraFormPL)this.FindForm(), frm);
                
            }
        }

        void frm_AfterUpdateStatusOfIssue(long TinhTrang, object[] infos)
        {
            frmViewThreadIssue frmViewIssue = (frmViewThreadIssue)this.FindForm();
            ucReplyIssue ucReplyIssue1 = (ucReplyIssue)frmViewIssue.flowLayoutPanel1.Controls[0];
            switch (TinhTrang) { 
                case 1:
                    ucReplyIssue1.lblTinhTrang.Text = "Mới tạo";
                    break;
                case 2:
                    ucReplyIssue1.lblTinhTrang.Text = "Đang xử lý";
                    break;
                default:
                    ucReplyIssue1.lblTinhTrang.Text = "Hoàn tất";
                    for (int i = 1; i < frmViewIssue.flowLayoutPanel1.Controls.Count; i++) {
                        ucReplyIssue _ucReplyIssue = (ucReplyIssue)frmViewIssue.flowLayoutPanel1.Controls[i];
                        _ucReplyIssue.btnUpdate.Visible = false;
                        frmViewIssue.btn_TL.Visible = false;
                    }
                    break;
            }
            frmViewIssue.UpdateIssue(TinhTrang, infos);
        }

        void frm_AfterUpdateReplyIssueSuccessfully(DTO.DOReplyBugProduct doReplyBugProduct)
        {
            this.UpdateContent(doReplyBugProduct.NGUOI_GUI,
                doReplyBugProduct.NGAY_GUI, doReplyBugProduct.NOI_DUNG, doReplyBugProduct.DSFile,
                FieldFileName, FieldNoiDung);
        }

        void frm_AfterUpdateIssueSuccessfully(DTO.DOBugProduct doBugProduct)
        {
            this.UpdateContent(doBugProduct.NGUOI_GUI,
                doBugProduct.NGAY_GUI, doBugProduct.MO_TA_BUG, doBugProduct.DSFile,
                FieldFileName, FieldNoiDung, new object[] { doBugProduct.NAME, doBugProduct.TINH_TRANG });
        }

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
    }
}
