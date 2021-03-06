namespace office
{
    partial class frmSendClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendClient));
            this.PLNoidung = new ProtocolVN.Framework.Win.PLEditor();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.pathFile = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.cmbSendType = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.textSmartHost = new DevExpress.XtraEditors.TextEdit();
            this.textSubject = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.lblSmartHost = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl6 = new System.Windows.Forms.PLLabel();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.cmbFrom = new ProtocolVN.Framework.Win.PLCombobox();
            this.cmbCC = new ProtocolVN.Framework.Win.PLMultiCombobox();
            this.cmbTo = new ProtocolVN.Framework.Win.PLMultiCombobox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pathFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSmartHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // PLNoidung
            // 
            this.PLNoidung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PLNoidung.BodyHtml = null;
            this.PLNoidung.BodyText = null;
            this.PLNoidung.DocumentText = resources.GetString("PLNoidung.DocumentText");
            this.PLNoidung.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.PLNoidung.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.PLNoidung.FontSize = ProtocolVN.Framework.Win.FontSize.Three;
            this.PLNoidung.Location = new System.Drawing.Point(12, 159);
            this.PLNoidung.Name = "PLNoidung";
            this.PLNoidung.Size = new System.Drawing.Size(771, 286);
            this.PLNoidung.State = "HTML";
            this.PLNoidung.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSend);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(626, 455);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(156, 30);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(81, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đón&g";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(3, 3);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(72, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "&Gửi thư";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pathFile
            // 
            this.pathFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pathFile.Location = new System.Drawing.Point(458, 39);
            this.pathFile.Name = "pathFile";
            this.pathFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.pathFile.Size = new System.Drawing.Size(325, 20);
            this.pathFile.TabIndex = 3;
            this.pathFile.Click += new System.EventHandler(this.pathFile_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(374, 43);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(78, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Tập tin đính kèm";
            this.labelControl1.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // cmbSendType
            // 
            this.cmbSendType.DataSource = null;
            this.cmbSendType.DisplayField = null;
            this.cmbSendType.Location = new System.Drawing.Point(98, 12);
            this.cmbSendType.Name = "cmbSendType";
            this.cmbSendType.Size = new System.Drawing.Size(257, 20);
            this.cmbSendType.TabIndex = 0;
            this.cmbSendType.ValueField = "";
            // 
            // textSmartHost
            // 
            this.textSmartHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textSmartHost.Location = new System.Drawing.Point(458, 12);
            this.textSmartHost.Name = "textSmartHost";
            this.textSmartHost.Size = new System.Drawing.Size(325, 20);
            this.textSmartHost.TabIndex = 1;
            // 
            // textSubject
            // 
            this.textSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textSubject.Location = new System.Drawing.Point(98, 122);
            this.textSubject.Name = "textSubject";
            this.textSubject.Size = new System.Drawing.Size(685, 20);
            this.textSubject.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 16);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Send type";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // lblSmartHost
            // 
            this.lblSmartHost.Location = new System.Drawing.Point(374, 15);
            this.lblSmartHost.Name = "lblSmartHost";
            this.lblSmartHost.Size = new System.Drawing.Size(52, 13);
            this.lblSmartHost.TabIndex = 18;
            this.lblSmartHost.Text = "Smart host";
            this.lblSmartHost.ToolTip = "Dữ liệu bắt buộc nhập";
            this.lblSmartHost.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(8, 70);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(89, 13);
            this.labelControl4.TabIndex = 18;
            this.labelControl4.Text = "Địa chỉ người nhận";
            this.labelControl4.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(8, 98);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(49, 13);
            this.labelControl5.TabIndex = 18;
            this.labelControl5.Text = "Địa chỉ CC";
            this.labelControl5.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 126);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(35, 13);
            this.labelControl6.TabIndex = 18;
            this.labelControl6.Text = "Tiêu đề";
            this.labelControl6.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl6.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(8, 43);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(80, 13);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "Địa chỉ người gửi";
            this.labelControl7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // cmbFrom
            // 
            this.cmbFrom.DataSource = null;
            this.cmbFrom.DisplayField = null;
            this.cmbFrom.Location = new System.Drawing.Point(98, 39);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(257, 21);
            this.cmbFrom.TabIndex = 2;
            this.cmbFrom.ValueField = null;
            // 
            // cmbCC
            // 
            this.cmbCC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCC.DataSource = null;
            this.cmbCC.DisplayField = null;
            this.cmbCC.EditValue = "";
            this.cmbCC.Location = new System.Drawing.Point(98, 94);
            this.cmbCC.Name = "cmbCC";
            this.cmbCC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCC.Size = new System.Drawing.Size(685, 20);
            this.cmbCC.TabIndex = 5;
            this.cmbCC.ValueField = null;
            // 
            // cmbTo
            // 
            this.cmbTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTo.DataSource = null;
            this.cmbTo.DisplayField = null;
            this.cmbTo.EditValue = "";
            this.cmbTo.Location = new System.Drawing.Point(98, 66);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTo.Size = new System.Drawing.Size(685, 20);
            this.cmbTo.TabIndex = 4;
            this.cmbTo.ValueField = null;
            // 
            // frmSendClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 493);
            this.Controls.Add(this.cmbFrom);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lblSmartHost);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cmbCC);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.textSubject);
            this.Controls.Add(this.textSmartHost);
            this.Controls.Add(this.cmbSendType);
            this.Controls.Add(this.pathFile);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.PLNoidung);
            this.Name = "frmSendClient";
            this.Text = "Send Mail";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pathFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSmartHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProtocolVN.Framework.Win.PLEditor PLNoidung;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.ButtonEdit pathFile;
        private ProtocolVN.Framework.Win.PLImgCombobox cmbSendType;
        private DevExpress.XtraEditors.TextEdit textSmartHost;
        private ProtocolVN.Framework.Win.PLMultiCombobox cmbTo;
        private ProtocolVN.Framework.Win.PLMultiCombobox cmbCC;
        private DevExpress.XtraEditors.TextEdit textSubject;
        private ProtocolVN.Framework.Win.PLCombobox cmbFrom;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel lblSmartHost;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl6;
        private System.Windows.Forms.PLLabel labelControl7;
    }
}