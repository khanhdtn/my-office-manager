namespace office
{
    partial class frmThongTinUngVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Dong = new DevExpress.XtraEditors.SimpleButton();
            this.ThongTinUngVien = new System.Windows.Forms.WebBrowser();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.KetSuatWord = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Dong
            // 
            this.btn_Dong.Location = new System.Drawing.Point(113, 9);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(72, 23);
            this.btn_Dong.TabIndex = 2;
            this.btn_Dong.Text = "Đón&g";
            // 
            // ThongTinUngVien
            // 
            this.ThongTinUngVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ThongTinUngVien.Location = new System.Drawing.Point(0, 1);
            this.ThongTinUngVien.MinimumSize = new System.Drawing.Size(20, 20);
            this.ThongTinUngVien.Name = "ThongTinUngVien";
            this.ThongTinUngVien.Size = new System.Drawing.Size(752, 373);
            this.ThongTinUngVien.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.ThongTinUngVien);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(753, 415);
            this.panelControl1.TabIndex = 4;
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.KetSuatWord);
            this.panelControl2.Controls.Add(this.btn_Dong);
            this.panelControl2.Location = new System.Drawing.Point(553, 375);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(200, 40);
            this.panelControl2.TabIndex = 4;
            // 
            // KetSuatWord
            // 
            this.KetSuatWord.Location = new System.Drawing.Point(29, 9);
            this.KetSuatWord.Name = "KetSuatWord";
            this.KetSuatWord.Size = new System.Drawing.Size(72, 23);
            this.KetSuatWord.TabIndex = 3;
            this.KetSuatWord.Text = "&Xuất Word";
            this.KetSuatWord.Click += new System.EventHandler(this.KetSuatWord_Click);
            // 
            // frmThongTinUngVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 415);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmThongTinUngVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin ứng viên";
            this.Load += new System.EventHandler(this.frmThongTinUngVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Dong;
        private System.Windows.Forms.WebBrowser ThongTinUngVien;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton KetSuatWord;
    }
}