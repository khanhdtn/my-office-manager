namespace office
{
    partial class frmAddForum
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
            this.labelControl10 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.PLNhomDienDan = new ProtocolVN.Framework.Win.PLComboboxAdd();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.PLChuyenMuc = new ProtocolVN.Framework.Win.PLComboboxAdd();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.txtTieude = new DevExpress.XtraEditors.TextEdit();
            this.lblThoiGianCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.lblNguoiCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.fileDinhKem = new ProtocolVN.Framework.Trial.PLButtonEdit();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PLNhomDienDan.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PLChuyenMuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTieude.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(281, 15);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(59, 13);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Chuyên mục";
            this.labelControl10.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl10.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tập tin đính kèm";
            this.labelControl1.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(169, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đón&g";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(91, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(72, 23);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(13, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(71, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Nhóm diễn đàn";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // PLNhomDienDan
            // 
            this.PLNhomDienDan.DataSource = null;
            this.PLNhomDienDan.DisplayField = null;
            this.PLNhomDienDan.GenID = "G_FW_DM_ID";
            this.PLNhomDienDan.IDField = null;
            this.PLNhomDienDan.Location = new System.Drawing.Point(91, 11);
            this.PLNhomDienDan.Name = "PLNhomDienDan";
            this.PLNhomDienDan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.PLNhomDienDan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PLNhomDienDan.Properties.ImmediatePopup = true;
            this.PLNhomDienDan.Properties.NullText = "Chọn giá trị";
            this.PLNhomDienDan.Size = new System.Drawing.Size(184, 20);
            this.PLNhomDienDan.TabIndex = 0;
            this.PLNhomDienDan.ToolTip = "Sử dụng: \n Ctrl-Insert: Thêm mục đang nhập. \n Ctrl-Delete: Xóa mục đang chọn.";
            this.PLNhomDienDan.SelectedIndexChanged += new System.EventHandler(this.PLNhomDienDan_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Controls.Add(this.btnLuu);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(562, 418);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 30);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(554, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Người thảo luận";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(554, 41);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Thời gian cập nhật";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // PLChuyenMuc
            // 
            this.PLChuyenMuc.DataSource = null;
            this.PLChuyenMuc.DisplayField = null;
            this.PLChuyenMuc.Enabled = false;
            this.PLChuyenMuc.GenID = "G_FW_DM_ID";
            this.PLChuyenMuc.IDField = null;
            this.PLChuyenMuc.Location = new System.Drawing.Point(346, 11);
            this.PLChuyenMuc.Name = "PLChuyenMuc";
            this.PLChuyenMuc.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.PLChuyenMuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PLChuyenMuc.Properties.ImmediatePopup = true;
            this.PLChuyenMuc.Properties.NullText = "Chọn giá trị";
            this.PLChuyenMuc.Size = new System.Drawing.Size(183, 20);
            this.PLChuyenMuc.TabIndex = 1;
            this.PLChuyenMuc.ToolTip = "Sử dụng: \n Ctrl-Insert: Thêm mục đang nhập. \n Ctrl-Delete: Xóa mục đang chọn.";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 41);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(34, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Chủ đề";
            this.labelControl6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // txtTieude
            // 
            this.txtTieude.Location = new System.Drawing.Point(91, 37);
            this.txtTieude.Name = "txtTieude";
            this.txtTieude.Size = new System.Drawing.Size(438, 20);
            this.txtTieude.TabIndex = 3;
            // 
            // lblThoiGianCapNhat
            // 
            this.lblThoiGianCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.lblThoiGianCapNhat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThoiGianCapNhat.Location = new System.Drawing.Point(649, 39);
            this.lblThoiGianCapNhat.Name = "lblThoiGianCapNhat";
            this.lblThoiGianCapNhat.Size = new System.Drawing.Size(148, 18);
            this.lblThoiGianCapNhat.TabIndex = 17;
            this.lblThoiGianCapNhat.Text = "lblThoiGianCapNhat";
            // 
            // lblNguoiCapNhat
            // 
            this.lblNguoiCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNguoiCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiCapNhat.Appearance.Options.UseFont = true;
            this.lblNguoiCapNhat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNguoiCapNhat.Location = new System.Drawing.Point(649, 13);
            this.lblNguoiCapNhat.Name = "lblNguoiCapNhat";
            this.lblNguoiCapNhat.Size = new System.Drawing.Size(148, 18);
            this.lblNguoiCapNhat.TabIndex = 16;
            this.lblNguoiCapNhat.Text = "lblNguoiCapNhat";
            // 
            // fileDinhKem
            // 
            this.fileDinhKem.Location = new System.Drawing.Point(91, 63);
            this.fileDinhKem.Name = "fileDinhKem";
            this.fileDinhKem.Size = new System.Drawing.Size(438, 24);
            this.fileDinhKem.TabIndex = 18;
            // 
            // NoiDung
            // 
            this.NoiDung.Location = new System.Drawing.Point(7, 93);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(801, 322);
            this.NoiDung.TabIndex = 19;
            // 
            // frmAddForum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 453);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.fileDinhKem);
            this.Controls.Add(this.lblThoiGianCapNhat);
            this.Controls.Add(this.lblNguoiCapNhat);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtTieude);
            this.Controls.Add(this.PLChuyenMuc);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.PLNhomDienDan);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl10);
            this.Name = "frmAddForum";
            this.Text = "Diễn đàn thảo luận";
            this.Load += new System.EventHandler(this.frmTinTuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PLNhomDienDan.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PLChuyenMuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTieude.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private ProtocolVN.Framework.Win.PLComboboxAdd PLNhomDienDan;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private ProtocolVN.Framework.Win.PLComboboxAdd PLChuyenMuc;
        private DevExpress.XtraEditors.TextEdit txtTieude;
        private System.Windows.Forms.PLLabel labelControl10;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl6;
        private DevExpress.XtraEditors.LabelControl lblThoiGianCapNhat;
        private DevExpress.XtraEditors.LabelControl lblNguoiCapNhat;
        private ProtocolVN.Framework.Trial.PLButtonEdit fileDinhKem;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
    }
}