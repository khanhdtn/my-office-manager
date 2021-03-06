using System;
using System.Drawing;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.Framework.Core;
using DTO;
using DevExpress.XtraEditors;
using office;


namespace ProtocolVN.App.Office
{
    //Điều kiện hiển thị tin giới thiệu ưu tiên theo thứ tự sau
    //1.Nổi bật + Duyệt + Còn hạn
    //2.Mới nhất + Duyệt + Còn hạn
    //3.Không hiển thị gì hết
    public partial class CurrentNews : XtraUserControl , IFormRefresh
    {
        /// <summary>
        /// Gắn CurrentNews vào PanelControl
        /// </summary>
        /// <param name="panel"></param>
        public static CurrentNews InitLastestNews(PanelControl panel)
        {
            CurrentNews ctr = new CurrentNews();
            ctr.Dock = DockStyle.Fill;
            panel.Controls.Add(ctr);
            return ctr;
        }
        /// <summary>
        /// Gắn CurrentNews vào form
        /// </summary>
        /// <param name="form"></param>
        public static CurrentNews InitLastestNews(XtraForm form)
        {
            CurrentNews ctr = new CurrentNews();
            ctr.Dock = DockStyle.Fill;
            form.Controls.Add(ctr);
            return ctr;
        }

        #region Các khai báo biến
        private DOTinTuc do_TT;
        private DOLuuTruTapTin do_Luu_Tru_TT;
        #endregion

        #region Các hàm khởi tạo
        public CurrentNews()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //Lấy tin mới hiển thị (Phải comment đoạn này lại trước khi mở xem Design)
            do_TT = DATinTuc.Instance.get_TinTuc(null, true);
            if (do_TT != null) do_Luu_Tru_TT = DATinTuc.Instance.get_TapTin(do_TT.ID);
            this.ThongTinNoiBat(do_TT, do_Luu_Tru_TT);
        }
        #endregion

        #region Các hàm xử lý nút
        private void lbl_TTDK_Click(object sender, EventArgs e)
        {
            frmSaveOpen frm = new frmSaveOpen(do_Luu_Tru_TT.NOI_DUNG, do_Luu_Tru_TT.TEN_FILE);
            HelpProtocolForm.ShowModalDialog((XtraForm)this.FindForm(), frm);
        }

        private void lbl_TTDK_MouseLeave(object sender, EventArgs e)
        {
            lbl_TTDK.ForeColor = Color.Blue;
        }

        private void lbl_TTDK_MouseMove(object sender, MouseEventArgs e)
        {
            lbl_TTDK.ForeColor = Color.Red;
        }
        #endregion

        #region Các hàm xử lý khác
        private void ThongTinNoiBat(DOTinTuc TTNew, DOLuuTruTapTin TAP_TIN)
        {
            ///Định dạng font chữ
            this.Chu_de.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Thoi_gian_cap_nhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNguoi_cap_nhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_TTDK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            try
            {
                if (TTNew != null)
                {
                    do_TT = TTNew;
                    Chu_de.Text = TTNew.TIEU_DE;
                    if (TAP_TIN.TEN_FILE != string.Empty)
                    {
                        if (TAP_TIN.TEN_FILE != string.Empty)
                        {
                            lbl_TTDK.Text = TAP_TIN.TEN_FILE;
                            lbl_TTDK.Visible = true;
                            labelControl1.Visible = true;
                        }
                    }
                    else
                    {
                        lbl_TTDK.Visible = false;
                        labelControl1.Visible = false;
                    }
                    lblNguoi_cap_nhat.Text = ProtocolVN.DanhMuc.DMFWNhanVien.GetFullName(TTNew.NGUOI_CAP_NHAT);
                    lbl_Thoi_gian_cap_nhat.Text = TTNew.NGAY_CAP_NHAT.ToString(PLConst.FORMAT_DATETIME_STRING);
                    Web_QuaTrinhDaoTao.DocumentText = HelpByte.BytesToUTF8String(TTNew.NOI_DUNG);
                    popupControlContainer1.Visible = true;
                }
                else
                {
                    popupControlContainer1.Visible = false;
                    Web_QuaTrinhDaoTao.Visible = false; ;
                    pictureEdit1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                HelpMsgBox.ShowErrorMessage(ex.Message);
            }
        }
        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            do_TT = DATinTuc.Instance.get_TinTuc(null,true);
            if (do_TT != null) do_Luu_Tru_TT = DATinTuc.Instance.get_TapTin(do_TT.ID);
            this.ThongTinNoiBat(do_TT, do_Luu_Tru_TT);
            return null;
        }

        #endregion

    }
}