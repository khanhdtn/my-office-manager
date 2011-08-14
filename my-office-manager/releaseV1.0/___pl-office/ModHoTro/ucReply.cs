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
    public partial class ucReply : UserControl
    {
        #region Các khai báo biến
        private long _ID;
        private long _Nguoi_gui;
        private DateTime _Thoi_gian_gui;
        private byte[] _Noi_dung;
        private string FieldFileName;
        private string FieldNoiDung;
        private Form parentForm;
        private DevExpress.XtraEditors.VScrollBar richVSrollBar;
        private static DataTable dtNhanVien;

        public delegate void _AfterUpdateSuccessfully(ucReply sender);
        public event _AfterUpdateSuccessfully AfterUpdateSuccessfully;

        public delegate void _AfterDeleteSuccessfully(bool isDeleteSupport);
        public event _AfterDeleteSuccessfully AfterDeleteSuccessfully;
        #endregion

        #region Các hàm khởi tạo
        public ucReply()
        {
            InitializeComponent();
        }
        public ucReply(Form parentForm, long ID, long Nguoi_gui, string nguoiHoTro,
            DateTime Thoi_gian_gui,
            object Bytes_Noi_dung, DataSet dsListFile, string FieldFileName, string FieldNoiDung, long TinhTrang, params string[] ThongTinYC)
        {
            InitializeComponent();
            this._ID = ID;
            this.parentForm = parentForm;
            this.FieldFileName = FieldFileName;
            this.FieldNoiDung = FieldNoiDung;
            if (dtNhanVien == null)
                dtNhanVien = HelpDB.getDatabase().LoadDataSet("SELECT * FROM DM_NHAN_VIEN WHERE VISIBLE_BIT = 'Y'").Tables[0];
            //Tình trạng là hoàn tất thì không cho chỉnh sửa.
            btnUpdate.Visible = TinhTrang == 4 ? false : true;
            UpdateContent(Nguoi_gui, nguoiHoTro, Thoi_gian_gui, Bytes_Noi_dung, dsListFile, FieldFileName, FieldNoiDung);
            if (ThongTinYC.Length > 0)
            {
                groupControl1.Text = ThongTinYC[0];
                groupControl1.ShowCaption = true;
                lblTinhTrang.Text = ThongTinYC[1];
                btnDelete.Tag = "Delete_Support";
            }
            else
            {
                btnDelete.Tag = "Delete_ReplyOfSupport";
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

        public void UpdateContent(long Nguoi_gui, string nguoiHoTro,
            DateTime Thoi_gian_gui, object Bytes_Noi_dung,
            DataSet dsListFile, string FieldFileName, string FieldNoiDung, params object[] ThongTinYeuCau)
        {
            flowLayoutPanel2.Controls.Clear();
            GetNameOfRecipient(nguoiHoTro);
            if (FrameworkParams.currentUser.username != "admin" &&
                FrameworkParams.currentUser.employee_id != Nguoi_gui)
            {
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            if (ThongTinYeuCau.Length > 0)
            {
                groupControl1.Text = ThongTinYeuCau[0].ToString();
                switch ((int)ThongTinYeuCau[1])
                {
                    case 1:
                        lblTinhTrang.Text = "Mới tạo";
                        break;
                    case 2:
                        lblTinhTrang.Text = "Đang xử lý";
                        break;
                    case 3:
                        lblTinhTrang.Text = "Không hỗ trợ";
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
                    if (r.RowState == DataRowState.Deleted) continue;
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
                if (btnDelete.Tag.Equals("Delete_ReplyOfSupport"))
                {
                    if (DAPhanHoi.Delete(this.ID))
                    {
                        this.Parent.Controls.Remove(this);
                        if (AfterDeleteSuccessfully != null) AfterDeleteSuccessfully(false);
                    }
                    else
                        HelpPhieuMsg.ErrorDeleted();
                }
                else
                {
                    if (DAYeuCau.Delete(this.ID))
                    {
                        HelpXtraForm.CloseFormNoConfirm((XtraForm)this.FindForm());
                        if (AfterDeleteSuccessfully != null) AfterDeleteSuccessfully(true);
                    }
                    else
                        HelpPhieuMsg.ErrorDeleted();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dtYeuCauOfYCTraLoi = DAYeuCau.GetYeuCauOfYCTraLoi(_ID);
            if (dtYeuCauOfYCTraLoi.Rows.Count > 0)
            {
                DataRow row = dtYeuCauOfYCTraLoi.Rows[0];
                frmHotro frm = new frmHotro(HelpNumber.ParseInt64(row["ID"]),
                HelpNumber.ParseInt64(row["NGUOI_GUI_ID"]), row["NGUOI_NHAN_ID"].ToString(), HelpNumber.ParseInt64(row["TINH_TRANG"]), false, _ID);
                frm.AfterUpdateReplySuccesfully += new frmHotro._AfterUpdateReplySuccesfully(frm_AfterUpdateReplySuccesfully);
                frm.AfterUpdateStatusOfSupport += new frmHotro._AfterUpdateStatusOfSupport(frm_AfterUpdateStatusOfSupport);
                ProtocolForm.ShowModalDialog((XtraFormPL)this.FindForm(), frm);
            }
            //Cập nhật yêu cầu
            else
            {
                frmHotro frm = new frmHotro(_ID, false);
                frm.AfterUpdateSupportSuccesfully += new frmHotro._AfterUpdateSupportSuccesfully(frm_AfterUpdateSupportSuccesfully);
                frm.AfterUpdateStatusOfSupport += new frmHotro._AfterUpdateStatusOfSupport(frm_AfterUpdateStatusOfSupport);
                ProtocolForm.ShowModalDialog((XtraFormPL)this.FindForm(), frm);
            }
        }

        void frm_AfterUpdateStatusOfSupport(long TinhTrang, object[] infos)
        {
            frmViewThreadSupport frmViewSupport = (frmViewThreadSupport)this.FindForm();
            ucReply ucReply1 = (ucReply)frmViewSupport.flowLayoutPanel1.Controls[0];
            switch (TinhTrang)
            {
                case 1:
                    ucReply1.lblTinhTrang.Text = "Mới tạo";
                    break;
                case 2:
                    ucReply1.lblTinhTrang.Text = "Đang xử lý";
                    break;
                case 3:
                    ucReply1.lblTinhTrang.Text = "Không hỗ trợ";
                    break;
                case 4:
                    ucReply1.lblTinhTrang.Text = "Hoàn tất";
                    for (int i = 1; i < frmViewSupport.flowLayoutPanel1.Controls.Count; i++)
                    {
                        ucReply _ucReply = (ucReply)frmViewSupport.flowLayoutPanel1.Controls[i];
                        _ucReply.btnUpdate.Visible = false;
                        frmViewSupport.btn_TL.Visible = false;
                    }
                    break;
            }
            frmViewSupport.UpdateTinhTrang(TinhTrang, infos);
        }

        void frm_AfterUpdateSupportSuccesfully(DAO.DOYeuCau doYeuCau)
        {
            this.UpdateContent(doYeuCau.NGUOI_GUI_ID, doYeuCau.NGUOI_NHAN_ID,
                doYeuCau.NGAY_GUI, doYeuCau.NOI_DUNG, doYeuCau.DSTapTinDinhKem,
                FieldFileName, FieldNoiDung, new object[] { doYeuCau.CHU_DE, doYeuCau.TINH_TRANG });
        }

        void frm_AfterUpdateReplySuccesfully(DAO.DOPhanHoi doPhanHoi)
        {
            this.UpdateContent(doPhanHoi.NGUOI_GUI_ID, doPhanHoi.NGUOI_NHAN_ID,
                doPhanHoi.NGAY_GUI, doPhanHoi.NOI_DUNG, doPhanHoi.DSTapTinDinhKem,
                FieldFileName, FieldNoiDung);
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
        private void GetNameOfRecipient(string RecipientIDs)
        {
            flowLayoutPanel3.Controls.Clear();
            if (RecipientIDs.Length == 0) return ;
            DataRow[] rows = dtNhanVien.Select(string.Format("ID in ({0})", RecipientIDs));
            foreach (DataRow row in rows)
            {
                Label lb = new Label();
                lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))); ;
                lb.AutoSize = true;
                lb.Text = row["NAME"].ToString();
                flowLayoutPanel3.Controls.Add(lb);
            }
        }
    }
}
