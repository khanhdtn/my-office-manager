using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmBugProduct
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
            this.components = new System.ComponentModel.Container();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.labelControl8 = new System.Windows.Forms.PLLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.Tinh_trang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.lblThoiGianGui = new DevExpress.XtraEditors.LabelControl();
            this.lblNguoiGui = new DevExpress.XtraEditors.LabelControl();
            this.loaiVanDe = new ProtocolVN.Framework.Win.PLCombobox();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.memoVanDe = new DevExpress.XtraEditors.MemoEdit();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.NguoiNhan = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.plMultiChoiceFiles1 = new office.PLMultiChoiceFiles();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            this.NguoiNhanEmail = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoVanDe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Vấn đề";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(340, 34);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(63, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Thời gian gửi";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(340, 11);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(48, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Người gửi";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl8.Location = new System.Drawing.Point(340, 57);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(55, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Người nhận";
            this.labelControl8.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl8.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(414, 436);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(316, 30);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(241, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Đón&g";
            this.btnDong.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(163, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(72, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(85, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // Tinh_trang
            // 
            this.Tinh_trang.DataSource = null;
            this.Tinh_trang.DisplayField = null;
            this.Tinh_trang.Location = new System.Drawing.Point(73, 78);
            this.Tinh_trang.Name = "Tinh_trang";
            this.Tinh_trang.Size = new System.Drawing.Size(224, 20);
            this.Tinh_trang.TabIndex = 3;
            this.Tinh_trang.ValueField = "";
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.LightYellow;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Loại vấn đề";
            this.toolTip1.SetToolTip(this.labelControl3, "Dữ liệu bắt buộc nhập");
            this.labelControl3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // lblThoiGianGui
            // 
            this.lblThoiGianGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianGui.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianGui.Appearance.Options.UseFont = true;
            this.lblThoiGianGui.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThoiGianGui.Location = new System.Drawing.Point(414, 31);
            this.lblThoiGianGui.Name = "lblThoiGianGui";
            this.lblThoiGianGui.Size = new System.Drawing.Size(148, 18);
            this.lblThoiGianGui.TabIndex = 17;
            this.lblThoiGianGui.Text = "lblThoiGianGui";
            // 
            // lblNguoiGui
            // 
            this.lblNguoiGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiGui.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiGui.Appearance.Options.UseFont = true;
            this.lblNguoiGui.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNguoiGui.Location = new System.Drawing.Point(414, 8);
            this.lblNguoiGui.Name = "lblNguoiGui";
            this.lblNguoiGui.Size = new System.Drawing.Size(148, 18);
            this.lblNguoiGui.TabIndex = 16;
            this.lblNguoiGui.Text = "lblNguoiGui";
            // 
            // loaiVanDe
            // 
            this.loaiVanDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.loaiVanDe.DataSource = null;
            this.loaiVanDe.DisplayField = null;
            this.loaiVanDe.Location = new System.Drawing.Point(73, 7);
            this.loaiVanDe.Name = "loaiVanDe";
            this.loaiVanDe.Size = new System.Drawing.Size(224, 20);
            this.loaiVanDe.TabIndex = 1;
            this.loaiVanDe.ValueField = null;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(12, 82);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(49, 13);
            this.plLabel1.TabIndex = 18;
            this.plLabel1.Text = "Tình trạng";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel4
            // 
            this.plLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plLabel4.Location = new System.Drawing.Point(12, 442);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(120, 13);
            this.plLabel4.TabIndex = 155;
            this.plLabel4.Text = "Gửi e-mail thông báo đến";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(340, 82);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 156;
            this.labelControl1.Text = "File đính kèm";
            this.labelControl1.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // memoVanDe
            // 
            this.memoVanDe.Location = new System.Drawing.Point(73, 34);
            this.memoVanDe.Name = "memoVanDe";
            this.memoVanDe.Size = new System.Drawing.Size(224, 37);
            this.memoVanDe.TabIndex = 2;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(12, 111);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(42, 13);
            this.plLabel2.TabIndex = 0;
            this.plLabel2.Text = "Nội dung";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // NguoiNhan
            // 
            this.NguoiNhan.Location = new System.Drawing.Point(414, 50);
            this.NguoiNhan.Name = "NguoiNhan";
            this.NguoiNhan.Size = new System.Drawing.Size(282, 20);
            this.NguoiNhan.TabIndex = 4;
            // 
            // plMultiChoiceFiles1
            // 
            this.plMultiChoiceFiles1._DataSource = null;
            this.plMultiChoiceFiles1.Location = new System.Drawing.Point(414, 78);
            this.plMultiChoiceFiles1.Name = "plMultiChoiceFiles1";
            this.plMultiChoiceFiles1.Size = new System.Drawing.Size(285, 20);
            this.plMultiChoiceFiles1.TabIndex = 5;
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(2, 129);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(736, 296);
            this.NoiDung.TabIndex = 6;
            // 
            // NguoiNhanEmail
            // 
            this.NguoiNhanEmail.Location = new System.Drawing.Point(138, 439);
            this.NguoiNhanEmail.Name = "NguoiNhanEmail";
            this.NguoiNhanEmail.Size = new System.Drawing.Size(221, 20);
            this.NguoiNhanEmail.TabIndex = 7;
            this.NguoiNhanEmail.ZZZWidthFactor = 2F;
            // 
            // frmBugProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 478);
            this.Controls.Add(this.NguoiNhanEmail);
            this.Controls.Add(this.NguoiNhan);
            this.Controls.Add(this.memoVanDe);
            this.Controls.Add(this.plMultiChoiceFiles1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.Tinh_trang);
            this.Controls.Add(this.lblThoiGianGui);
            this.Controls.Add(this.lblNguoiGui);
            this.Controls.Add(this.loaiVanDe);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Name = "frmBugProduct";
            this.Text = "Thông tin vấn đề";
            this.Load += new System.EventHandler(this.frmBugProduct_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoVanDe.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private PLImgCombobox Tinh_trang;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl8;
        private DevExpress.XtraEditors.LabelControl lblThoiGianGui;
        private DevExpress.XtraEditors.LabelControl lblNguoiGui;
        private System.Windows.Forms.PLLabel labelControl3;
        private PLCombobox loaiVanDe;
        private System.Windows.Forms.PLLabel plLabel1;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
        private System.Windows.Forms.PLLabel plLabel4;
        private PLMultiChoiceFiles plMultiChoiceFiles1;
        private System.Windows.Forms.PLLabel labelControl1;
        private DevExpress.XtraEditors.MemoEdit memoVanDe;
        private System.Windows.Forms.PLLabel plLabel2;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhan;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice NguoiNhanEmail;
        
    }
}