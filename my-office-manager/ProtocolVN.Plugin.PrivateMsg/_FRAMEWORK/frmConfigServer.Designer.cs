namespace pl.mail
{
    partial class frmConfigServer
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMailServer = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.spPort = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chkSSL = new DevExpress.XtraEditors.CheckEdit();
            this.chkSSLSMTP = new DevExpress.XtraEditors.CheckEdit();
            this.spPortSMTP = new DevExpress.XtraEditors.SpinEdit();
            this.btnKetNoi = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblDomain = new DevExpress.XtraEditors.LabelControl();
            this.txtDomain = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.CENormal = new DevExpress.XtraEditors.CheckEdit();
            this.CESimple = new DevExpress.XtraEditors.CheckEdit();
            this.CEPrefix = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMailServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSSL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSSLSMTP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPortSMTP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDomain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CENormal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CESimple.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEPrefix.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mail server";
            // 
            // txtMailServer
            // 
            this.txtMailServer.Location = new System.Drawing.Point(66, 13);
            this.txtMailServer.Name = "txtMailServer";
            this.txtMailServer.Size = new System.Drawing.Size(243, 20);
            this.txtMailServer.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Port";
            // 
            // spPort
            // 
            this.spPort.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spPort.Location = new System.Drawing.Point(66, 38);
            this.spPort.Name = "spPort";
            this.spPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spPort.Size = new System.Drawing.Size(85, 20);
            this.spPort.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(171, 42);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Port SMTP";
            // 
            // chkSSL
            // 
            this.chkSSL.Location = new System.Drawing.Point(63, 85);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Properties.Caption = "SSL";
            this.chkSSL.Size = new System.Drawing.Size(43, 19);
            this.chkSSL.TabIndex = 4;
            // 
            // chkSSLSMTP
            // 
            this.chkSSLSMTP.Location = new System.Drawing.Point(169, 85);
            this.chkSSLSMTP.Name = "chkSSLSMTP";
            this.chkSSLSMTP.Properties.Caption = "SSL SMTP";
            this.chkSSLSMTP.Size = new System.Drawing.Size(79, 19);
            this.chkSSLSMTP.TabIndex = 4;
            // 
            // spPortSMTP
            // 
            this.spPortSMTP.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spPortSMTP.Location = new System.Drawing.Point(224, 39);
            this.spPortSMTP.Name = "spPortSMTP";
            this.spPortSMTP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spPortSMTP.Size = new System.Drawing.Size(85, 20);
            this.spPortSMTP.TabIndex = 3;
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Location = new System.Drawing.Point(8, 195);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(73, 23);
            this.btnKetNoi.TabIndex = 5;
            this.btnKetNoi.Text = "Kết nối thử";
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(156, 195);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu cấu hình";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(237, 195);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblDomain
            // 
            this.lblDomain.Location = new System.Drawing.Point(8, 67);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(43, 13);
            this.lblDomain.TabIndex = 7;
            this.lblDomain.Text = "Tên miền";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(66, 63);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(243, 20);
            this.txtDomain.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(11, 114);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(120, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Phương thức đăng nhập:";
            // 
            // CENormal
            // 
            this.CENormal.EditValue = true;
            this.CENormal.Location = new System.Drawing.Point(66, 131);
            this.CENormal.Name = "CENormal";
            this.CENormal.Properties.Caption = "Bình thường: abc@example.com";
            this.CENormal.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.CENormal.Size = new System.Drawing.Size(182, 19);
            this.CENormal.TabIndex = 9;
            this.CENormal.CheckedChanged += new System.EventHandler(this.CENormal_CheckedChanged);
            // 
            // CESimple
            // 
            this.CESimple.Location = new System.Drawing.Point(66, 150);
            this.CESimple.Name = "CESimple";
            this.CESimple.Properties.Caption = "Đơn giản: abc";
            this.CESimple.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.CESimple.Size = new System.Drawing.Size(204, 19);
            this.CESimple.TabIndex = 10;
            this.CESimple.CheckedChanged += new System.EventHandler(this.CESimple_CheckedChanged);
            // 
            // CEPrefix
            // 
            this.CEPrefix.Location = new System.Drawing.Point(66, 168);
            this.CEPrefix.Name = "CEPrefix";
            this.CEPrefix.Properties.Caption = "Tiền tố: example.com_abc";
            this.CEPrefix.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.CEPrefix.Size = new System.Drawing.Size(204, 19);
            this.CEPrefix.TabIndex = 11;
            this.CEPrefix.CheckedChanged += new System.EventHandler(this.CEPrefix_CheckedChanged);
            // 
            // frmConfigServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 230);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.CEPrefix);
            this.Controls.Add(this.CESimple);
            this.Controls.Add(this.CENormal);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.chkSSLSMTP);
            this.Controls.Add(this.chkSSL);
            this.Controls.Add(this.spPortSMTP);
            this.Controls.Add(this.spPort);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtMailServer);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.Name = "frmConfigServer";
            this.Text = "frmConfigServer";
            this.Load += new System.EventHandler(this.frmConfigServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMailServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSSL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSSLSMTP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spPortSMTP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDomain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CENormal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CESimple.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CEPrefix.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtMailServer;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit spPort;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkSSL;
        private DevExpress.XtraEditors.CheckEdit chkSSLSMTP;
        private DevExpress.XtraEditors.SpinEdit spPortSMTP;
        private DevExpress.XtraEditors.SimpleButton btnKetNoi;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.LabelControl lblDomain;
        private DevExpress.XtraEditors.TextEdit txtDomain;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit CENormal;
        private DevExpress.XtraEditors.CheckEdit CESimple;
        private DevExpress.XtraEditors.CheckEdit CEPrefix;
    }
}