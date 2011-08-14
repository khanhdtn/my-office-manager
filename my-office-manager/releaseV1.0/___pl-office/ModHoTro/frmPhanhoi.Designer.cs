using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmPhanhoi
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
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Nguoi_gui = new System.Windows.Forms.PLLabel();
            this.Ngay_gui = new System.Windows.Forms.PLLabel();
            this.nguoiNhanMail = new office.GuiMail();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.PLTinhtrang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(3, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(81, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đón&g";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nội dung";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(245, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Người phản hồi";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(245, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(89, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Thời gian phản hồi";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnLuu);
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(515, 376);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(159, 29);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // Nguoi_gui
            // 
            this.Nguoi_gui.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Nguoi_gui.Appearance.Options.UseFont = true;
            this.Nguoi_gui.Location = new System.Drawing.Point(338, 12);
            this.Nguoi_gui.Name = "Nguoi_gui";
            this.Nguoi_gui.Size = new System.Drawing.Size(79, 13);
            this.Nguoi_gui.TabIndex = 6;
            this.Nguoi_gui.Text = "Chưa xác định";
            this.Nguoi_gui.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // Ngay_gui
            // 
            this.Ngay_gui.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Ngay_gui.Appearance.Options.UseFont = true;
            this.Ngay_gui.Location = new System.Drawing.Point(338, 37);
            this.Ngay_gui.Name = "Ngay_gui";
            this.Ngay_gui.Size = new System.Drawing.Size(79, 13);
            this.Ngay_gui.TabIndex = 7;
            this.Ngay_gui.Text = "Chưa xác định";
            this.Ngay_gui.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // nguoiNhanMail
            // 
            this.nguoiNhanMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nguoiNhanMail.Location = new System.Drawing.Point(137, 379);
            this.nguoiNhanMail.Name = "nguoiNhanMail";
            this.nguoiNhanMail.Size = new System.Drawing.Size(181, 24);
            this.nguoiNhanMail.TabIndex = 156;
            // 
            // plLabel4
            // 
            this.plLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plLabel4.Location = new System.Drawing.Point(11, 382);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(120, 13);
            this.plLabel4.TabIndex = 157;
            this.plLabel4.Text = "Gửi e-mail thông báo đến";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // PLTinhtrang
            // 
            this.PLTinhtrang.DataSource = null;
            this.PLTinhtrang.DisplayField = null;
            this.PLTinhtrang.Location = new System.Drawing.Point(67, 10);
            this.PLTinhtrang.Name = "PLTinhtrang";
            this.PLTinhtrang.Size = new System.Drawing.Size(130, 20);
            this.PLTinhtrang.TabIndex = 159;
            this.PLTinhtrang.ValueField = "";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 12);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(49, 13);
            this.labelControl6.TabIndex = 158;
            this.labelControl6.Text = "Tình trạng";
            this.labelControl6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(2, 56);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(675, 314);
            this.NoiDung.TabIndex = 160;
            // 
            // frmPhanhoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 414);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.PLTinhtrang);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.nguoiNhanMail);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.Ngay_gui);
            this.Controls.Add(this.Nguoi_gui);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmPhanhoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "office.source.form.hotro.frmPhanhoi";
            this.Text = "Phản hồi yêu cầu hỗ trợ";
            this.Load += new System.EventHandler(this.frmPhanhoi_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel Nguoi_gui;
        private System.Windows.Forms.PLLabel Ngay_gui;
        private GuiMail nguoiNhanMail;
        private System.Windows.Forms.PLLabel plLabel4;
        private PLImgCombobox PLTinhtrang;
        private System.Windows.Forms.PLLabel labelControl6;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
    }
}