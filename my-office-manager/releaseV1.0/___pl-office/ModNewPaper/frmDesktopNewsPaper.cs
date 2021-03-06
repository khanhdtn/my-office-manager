using System;
using System.Drawing;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;


namespace office
{
    //Điều kiện hiển thị tin giới thiệu ưu tiên theo thứ tự sau
    //1.Nổi bật + Duyệt + Còn hạn
    //2.Mới nhất + Duyệt + Còn hạn
    //3.Không hiển thị gì hết
    public partial class frmDesktopNewsPaper : XtraFormPL,IFormRefresh
    {
        #region Các khai báo biến
        private DOTinTuc do_TT;
        #endregion

        #region Các hàm khởi tạo
        public frmDesktopNewsPaper()
        {
            InitializeComponent();
        }
        private void frmTT_Load(object sender, EventArgs e)
        {
            popupControlContainer1.Visible = true;
            do_TT = DATinTuc.Instance.get_TinTuc(null,true);
            if (do_TT != null)
            {
                do_TT.DSTapTinDinhKem = DALuuTruTapTin.Instance.GetTapTinByObjectID(do_TT.ID, 1);
                this.ThongTinNoiBat(do_TT);
            }
            else {
                popupControlContainer1.Visible = false;
                richEditContent.Visible = false;
                pictureEdit1.Visible = true;
            }
        }

        #endregion

      

        #region Các hàm xử lý khác
        private void ThongTinNoiBat(DOTinTuc TTNew)
        {
            ///Định dạng font chữ
            this.Chu_de.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Thoi_gian_cap_nhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNguoi_cap_nhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            try
            {
                if (TTNew != null)
                {
                    do_TT = TTNew;
                    Chu_de.Text = TTNew.TIEU_DE;
                    if (do_TT.DSTapTinDinhKem != null && do_TT.DSTapTinDinhKem.Tables.Count > 0 && do_TT.DSTapTinDinhKem.Tables[0].Rows.Count > 0)
                    {

                        labelControl1.Visible = true;
                        int wi = 0;
                        foreach (DataRow r in do_TT.DSTapTinDinhKem.Tables[0].Rows)
                        {
                            Label lb = new Label();
                            lb.AutoSize = true;
                            lb.ForeColor = Color.Blue;
                            lb.Font = new Font(label3.Font, FontStyle.Underline);
                            lb.Cursor = System.Windows.Forms.Cursors.Hand;
                            lb.MouseHover += new EventHandler(lb_MouseHover);
                            lb.MouseLeave += new EventHandler(lb_MouseLeave);
                            lb.Click += new EventHandler(lb_Click);
                            lb.Text = r["TEN_FILE"].ToString();
                            if (r["NOI_DUNG"] != DBNull.Value)
                                lb.Tag = (byte[])r["NOI_DUNG"];
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
                    else
                    {

                        labelControl1.Visible = false;
                    }
                    lblNguoi_cap_nhat.Text = ProtocolVN.DanhMuc.DMFWNhanVien.GetFullName(TTNew.NGUOI_CAP_NHAT);
                    lbl_Thoi_gian_cap_nhat.Text = TTNew.NGAY_CAP_NHAT.ToString(PLConst.FORMAT_DATETIME_STRING);
                    ProtocolVN.App.Office.AppCtrl.SetRichText(richEditContent,TTNew.NOI_DUNG,true);
                    popupControlContainer1.Visible = true;
                }
                else
                {
                    popupControlContainer1.Visible = false;
                    richEditContent.Visible = false;
                    pictureEdit1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                HelpMsgBox.ShowErrorMessage(ex.Message);
            }
        }
        private void lb_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb.Tag == null) return;
            frmSaveOpen frm = new frmSaveOpen((byte[])lb.Tag, lb.Text);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }
        private void lb_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void lb_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Red;
        }
       
        #endregion


        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            do_TT = DATinTuc.Instance.get_TinTuc(null, true);
            do_TT.DSTapTinDinhKem = DALuuTruTapTin.Instance.GetTapTinByObjectID(do_TT.ID, 1);
            this.ThongTinNoiBat(do_TT);
            return null;
        }

        #endregion
    }
}