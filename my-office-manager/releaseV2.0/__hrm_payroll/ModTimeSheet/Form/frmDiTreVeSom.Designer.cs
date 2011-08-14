using ProtocolVN.Framework.Win;
namespace pl.office.form
{
    partial class frmDiTreVeSom
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.Ngay_lien_quan = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.txtNguoiGhiNhan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.txtTG_GhiNhan = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.Duyet = new ProtocolVN.Framework.Win.PLDuyetCombobox();
            this.label3 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.CapNhat_TT = new DevExpress.XtraEditors.TextEdit();
            this.PLNguoiLQ = new ProtocolVN.Framework.Win.PLCombobox();
            this.rtxNoi_dung = new DevExpress.XtraEditors.MemoEdit();
            this.err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.PLLabel();
            this.PLMulDT_VS = new ProtocolVN.Framework.Win.PLMultiCombobox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ngay_lien_quan.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ngay_lien_quan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiGhiNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTG_GhiNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapNhat_TT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxNoi_dung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLMulDT_VS.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(41, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(71, 13);
            this.labelControl5.TabIndex = 47;
            this.labelControl5.Text = "Ngày liên quan";
            this.labelControl5.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 13);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(74, 13);
            this.labelControl7.TabIndex = 45;
            this.labelControl7.Text = "Người liên quan";
            this.labelControl7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(363, 222);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 30);
            this.flowLayoutPanel1.TabIndex = 133;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(119, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đón&g";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // Ngay_lien_quan
            // 
            this.Ngay_lien_quan.EditValue = null;
            this.Ngay_lien_quan.Location = new System.Drawing.Point(92, 35);
            this.Ngay_lien_quan.Name = "Ngay_lien_quan";
            this.Ngay_lien_quan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Ngay_lien_quan.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Ngay_lien_quan.Size = new System.Drawing.Size(172, 20);
            this.Ngay_lien_quan.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(281, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(73, 13);
            this.labelControl2.TabIndex = 142;
            this.labelControl2.Text = "Người ghi nhận";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // txtNguoiGhiNhan
            // 
            this.txtNguoiGhiNhan.Enabled = false;
            this.txtNguoiGhiNhan.Location = new System.Drawing.Point(382, 9);
            this.txtNguoiGhiNhan.Name = "txtNguoiGhiNhan";
            this.txtNguoiGhiNhan.Size = new System.Drawing.Size(172, 20);
            this.txtNguoiGhiNhan.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(281, 38);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(88, 13);
            this.labelControl3.TabIndex = 144;
            this.labelControl3.Text = "Thời gian ghi nhận";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // txtTG_GhiNhan
            // 
            this.txtTG_GhiNhan.Enabled = false;
            this.txtTG_GhiNhan.Location = new System.Drawing.Point(382, 35);
            this.txtTG_GhiNhan.Name = "txtTG_GhiNhan";
            this.txtTG_GhiNhan.Size = new System.Drawing.Size(172, 20);
            this.txtTG_GhiNhan.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 112);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 13);
            this.labelControl4.TabIndex = 146;
            this.labelControl4.Text = "Nội dung";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // Duyet
            // 
            this.Duyet.Enabled = false;
            this.Duyet.Location = new System.Drawing.Point(92, 87);
            this.Duyet.Name = "Duyet";
            this.Duyet.Size = new System.Drawing.Size(172, 20);
            this.Duyet.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Tình trạng";
            this.label3.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(281, 65);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(95, 13);
            this.labelControl1.TabIndex = 151;
            this.labelControl1.Text = "Cập nhật tình trạng";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // CapNhat_TT
            // 
            this.CapNhat_TT.Enabled = false;
            this.CapNhat_TT.Location = new System.Drawing.Point(382, 61);
            this.CapNhat_TT.Name = "CapNhat_TT";
            this.CapNhat_TT.Size = new System.Drawing.Size(172, 20);
            this.CapNhat_TT.TabIndex = 6;
            // 
            // PLNguoiLQ
            // 
            this.PLNguoiLQ.AutoSize = true;
            this.PLNguoiLQ.DataSource = null;
            this.PLNguoiLQ.DisplayField = null;
            this.PLNguoiLQ.Location = new System.Drawing.Point(92, 9);
            this.PLNguoiLQ.Name = "PLNguoiLQ";
            this.PLNguoiLQ.Size = new System.Drawing.Size(172, 20);
            this.PLNguoiLQ.TabIndex = 0;
            this.PLNguoiLQ.ValueField = null;
            // 
            // rtxNoi_dung
            // 
            this.rtxNoi_dung.Location = new System.Drawing.Point(12, 131);
            this.rtxNoi_dung.Name = "rtxNoi_dung";
            this.rtxNoi_dung.Size = new System.Drawing.Size(542, 78);
            this.rtxNoi_dung.TabIndex = 7;
            // 
            // err
            // 
            this.err.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 152;
            this.label1.Text = "Đi trễ về sớm";
            this.label1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // PLMulDT_VS
            // 
            this.PLMulDT_VS.DataSource = null;
            this.PLMulDT_VS.DisplayField = null;
            this.PLMulDT_VS.EditValue = "";
            this.PLMulDT_VS.Location = new System.Drawing.Point(92, 61);
            this.PLMulDT_VS.Name = "PLMulDT_VS";
            this.PLMulDT_VS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PLMulDT_VS.Size = new System.Drawing.Size(172, 20);
            this.PLMulDT_VS.TabIndex = 2;
            this.PLMulDT_VS.ValueField = null;
            // 
            // frmDiTreVeSom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 253);
            this.Controls.Add(this.PLMulDT_VS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtxNoi_dung);
            this.Controls.Add(this.PLNguoiLQ);
            this.Controls.Add(this.CapNhat_TT);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.Duyet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtTG_GhiNhan);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtNguoiGhiNhan);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Ngay_lien_quan);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Name = "frmDiTreVeSom";
            this.Text = "Đi trễ về sớm";
            this.Load += new System.EventHandler(this.frmHotroSupport_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Ngay_lien_quan.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ngay_lien_quan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiGhiNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTG_GhiNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapNhat_TT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtxNoi_dung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.err)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLMulDT_VS.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.DateEdit Ngay_lien_quan;
        private DevExpress.XtraEditors.TextEdit txtNguoiGhiNhan;
        private DevExpress.XtraEditors.TextEdit txtTG_GhiNhan;
        private PLDuyetCombobox Duyet;
        private System.Windows.Forms.PLLabel label3;
        private DevExpress.XtraEditors.TextEdit CapNhat_TT;
        private PLCombobox PLNguoiLQ;
        private DevExpress.XtraEditors.MemoEdit rtxNoi_dung;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider err;
        private  System.Windows.Forms.PLLabel  label1;
        private PLMultiCombobox PLMulDT_VS;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl1;
    }
}