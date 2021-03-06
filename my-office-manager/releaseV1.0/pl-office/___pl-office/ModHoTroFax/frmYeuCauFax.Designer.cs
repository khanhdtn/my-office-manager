namespace office
{
    partial class frmYeuCauFax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYeuCauFax));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.cboMuc_uu_tien = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.plLabel2 = new System.Windows.Forms.PLLabel();
            this.plLabel3 = new System.Windows.Forms.PLLabel();
            this.plLabel4 = new System.Windows.Forms.PLLabel();
            this.txtGuiDenSo = new DevExpress.XtraEditors.TextEdit();
            this.txtNguoiNhan = new DevExpress.XtraEditors.TextEdit();
            this.memoNoiDung = new DevExpress.XtraEditors.MemoEdit();
            this.lblThoiGianGui = new DevExpress.XtraEditors.LabelControl();
            this.lblNguoiGui = new DevExpress.XtraEditors.LabelControl();
            this.PLTinhtrang = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.plLabel5 = new System.Windows.Forms.PLLabel();
            this.plMultiChoiceFiles1 = new office.PLMultiChoiceFiles();
            this.NguoiThucHien = new ProtocolVN.Framework.Win.PLDMTreeGroup();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGuiDenSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoNoiDung.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnLuu);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(374, 201);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(166, 29);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(91, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đón&g";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(13, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Visible = false;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(284, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Người yêu cầu";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(284, 68);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Người thực hiện";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(284, 42);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Thời gian yêu cầu";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Độ ưu tiên";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // cboMuc_uu_tien
            // 
            this.cboMuc_uu_tien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMuc_uu_tien.DataSource = null;
            this.cboMuc_uu_tien.DisplayField = null;
            this.cboMuc_uu_tien.Location = new System.Drawing.Point(93, 38);
            this.cboMuc_uu_tien.Name = "cboMuc_uu_tien";
            this.cboMuc_uu_tien.Size = new System.Drawing.Size(171, 20);
            this.cboMuc_uu_tien.TabIndex = 1;
            this.cboMuc_uu_tien.ValueField = "";
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.LightYellow;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(13, 68);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(51, 13);
            this.plLabel1.TabIndex = 0;
            this.plLabel1.Text = "Gửi đến số";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel2
            // 
            this.plLabel2.Location = new System.Drawing.Point(13, 94);
            this.plLabel2.Name = "plLabel2";
            this.plLabel2.Size = new System.Drawing.Size(75, 13);
            this.plLabel2.TabIndex = 0;
            this.plLabel2.Text = "Tên người nhận";
            this.plLabel2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel3
            // 
            this.plLabel3.Location = new System.Drawing.Point(14, 119);
            this.plLabel3.Name = "plLabel3";
            this.plLabel3.Size = new System.Drawing.Size(42, 13);
            this.plLabel3.TabIndex = 0;
            this.plLabel3.Text = "Nội dung";
            this.plLabel3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plLabel4
            // 
            this.plLabel4.Location = new System.Drawing.Point(284, 94);
            this.plLabel4.Name = "plLabel4";
            this.plLabel4.Size = new System.Drawing.Size(55, 13);
            this.plLabel4.TabIndex = 0;
            this.plLabel4.Text = "File cần fax";
            this.plLabel4.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.plLabel4.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // txtGuiDenSo
            // 
            this.txtGuiDenSo.Location = new System.Drawing.Point(93, 64);
            this.txtGuiDenSo.Name = "txtGuiDenSo";
            this.txtGuiDenSo.Size = new System.Drawing.Size(171, 20);
            this.txtGuiDenSo.TabIndex = 2;
            // 
            // txtNguoiNhan
            // 
            this.txtNguoiNhan.Location = new System.Drawing.Point(93, 90);
            this.txtNguoiNhan.Name = "txtNguoiNhan";
            this.txtNguoiNhan.Size = new System.Drawing.Size(171, 20);
            this.txtNguoiNhan.TabIndex = 3;
            // 
            // memoNoiDung
            // 
            this.memoNoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memoNoiDung.EditValue = "";
            this.memoNoiDung.Location = new System.Drawing.Point(93, 116);
            this.memoNoiDung.Name = "memoNoiDung";
            this.memoNoiDung.Size = new System.Drawing.Size(449, 76);
            this.memoNoiDung.TabIndex = 6;
            // 
            // lblThoiGianGui
            // 
            this.lblThoiGianGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianGui.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianGui.Appearance.Options.UseFont = true;
            this.lblThoiGianGui.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThoiGianGui.Location = new System.Drawing.Point(378, 42);
            this.lblThoiGianGui.Name = "lblThoiGianGui";
            this.lblThoiGianGui.Size = new System.Drawing.Size(163, 13);
            this.lblThoiGianGui.TabIndex = 24;
            this.lblThoiGianGui.Text = "lblThoiGianGui";
            // 
            // lblNguoiGui
            // 
            this.lblNguoiGui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiGui.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiGui.Appearance.Options.UseFont = true;
            this.lblNguoiGui.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNguoiGui.Location = new System.Drawing.Point(378, 16);
            this.lblNguoiGui.Name = "lblNguoiGui";
            this.lblNguoiGui.Size = new System.Drawing.Size(163, 13);
            this.lblNguoiGui.TabIndex = 23;
            this.lblNguoiGui.Text = "lblNguoiGui";
            // 
            // PLTinhtrang
            // 
            this.PLTinhtrang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PLTinhtrang.DataSource = null;
            this.PLTinhtrang.DisplayField = null;
            this.PLTinhtrang.Location = new System.Drawing.Point(93, 12);
            this.PLTinhtrang.Name = "PLTinhtrang";
            this.PLTinhtrang.Size = new System.Drawing.Size(171, 20);
            this.PLTinhtrang.TabIndex = 0;
            this.PLTinhtrang.ValueField = "";
            // 
            // plLabel5
            // 
            this.plLabel5.Location = new System.Drawing.Point(13, 16);
            this.plLabel5.Name = "plLabel5";
            this.plLabel5.Size = new System.Drawing.Size(49, 13);
            this.plLabel5.TabIndex = 25;
            this.plLabel5.Text = "Tình trạng";
            this.plLabel5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // plMultiChoiceFiles1
            // 
            this.plMultiChoiceFiles1.Location = new System.Drawing.Point(378, 90);
            this.plMultiChoiceFiles1.Name = "plMultiChoiceFiles1";
            this.plMultiChoiceFiles1.Size = new System.Drawing.Size(166, 20);
            this.plMultiChoiceFiles1.TabIndex = 5;
            // 
            // NguoiThucHien
            // 
            this.NguoiThucHien.Location = new System.Drawing.Point(378, 64);
            this.NguoiThucHien.Name = "NguoiThucHien";
            this.NguoiThucHien.Size = new System.Drawing.Size(163, 20);
            this.NguoiThucHien.TabIndex = 4;
            // 
            // frmYeuCauFax
            // 
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmYeuCauFax.Appearance.Image")));
            this.Appearance.Options.UseImage = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 237);
            this.Controls.Add(this.NguoiThucHien);
            this.Controls.Add(this.PLTinhtrang);
            this.Controls.Add(this.plLabel5);
            this.Controls.Add(this.lblThoiGianGui);
            this.Controls.Add(this.lblNguoiGui);
            this.Controls.Add(this.plMultiChoiceFiles1);
            this.Controls.Add(this.memoNoiDung);
            this.Controls.Add(this.txtNguoiNhan);
            this.Controls.Add(this.txtGuiDenSo);
            this.Controls.Add(this.cboMuc_uu_tien);
            this.Controls.Add(this.plLabel4);
            this.Controls.Add(this.plLabel3);
            this.Controls.Add(this.plLabel2);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmYeuCauFax";
            this.Text = "Yêu cầu fax";
            this.Load += new System.EventHandler(this.frmThem_TL_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGuiDenSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoNoiDung.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private System.Windows.Forms.OpenFileDialog openFile;
        private ProtocolVN.Framework.Win.PLImgCombobox cboMuc_uu_tien;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel plLabel2;
        private System.Windows.Forms.PLLabel plLabel3;
        private System.Windows.Forms.PLLabel plLabel4;
        private DevExpress.XtraEditors.MemoEdit memoNoiDung;
        private PLMultiChoiceFiles plMultiChoiceFiles1;
        private DevExpress.XtraEditors.LabelControl lblThoiGianGui;
        private DevExpress.XtraEditors.LabelControl lblNguoiGui;
        private ProtocolVN.Framework.Win.PLImgCombobox PLTinhtrang;
        private System.Windows.Forms.PLLabel plLabel5;
        public DevExpress.XtraEditors.TextEdit txtGuiDenSo;
        public DevExpress.XtraEditors.TextEdit txtNguoiNhan;
        private ProtocolVN.Framework.Win.PLDMTreeGroup NguoiThucHien;

    }
}