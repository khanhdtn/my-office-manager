namespace pl.mail
{
    partial class frmAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccount));
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnBoqua = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUserMail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPort = new DevExpress.XtraEditors.TextEdit();
            this.ckSSL = new System.Windows.Forms.CheckBox();
            this.rbIMAP = new System.Windows.Forms.RadioButton();
            this.rbPOP = new System.Windows.Forms.RadioButton();
            this.txtHost = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPortSMTP = new DevExpress.XtraEditors.TextEdit();
            this.ckSMTPSSL = new System.Windows.Forms.CheckBox();
            this.txtSMTPHost = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenThuMuc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cbTaiKhoan = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserMail.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortSMTP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPHost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenThuMuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTaiKhoan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.ImageIndex = 2;
            this.btnLuu.ImageList = this.imageCollection1;
            this.btnLuu.Location = new System.Drawing.Point(342, 392);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(69, 24);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // btnBoqua
            // 
            this.btnBoqua.ImageIndex = 5;
            this.btnBoqua.ImageList = this.imageCollection1;
            this.btnBoqua.Location = new System.Drawing.Point(416, 392);
            this.btnBoqua.Name = "btnBoqua";
            this.btnBoqua.Size = new System.Drawing.Size(81, 24);
            this.btnBoqua.TabIndex = 9;
            this.btnBoqua.Text = "Không lưu";
            this.btnBoqua.Click += new System.EventHandler(this.btCancel_Click_1);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupBox3);
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Location = new System.Drawing.Point(12, 64);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(547, 320);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Thông tin tài khoản";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPassword);
            this.groupBox3.Controls.Add(this.txtUserMail);
            this.groupBox3.Controls.Add(this.labelControl2);
            this.groupBox3.Controls.Add(this.labelControl1);
            this.groupBox3.Location = new System.Drawing.Point(5, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 85);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tài khoản của bạn";
            // 
            // txtPassword
            // 
            this.txtPassword.EditValue = "";
            this.txtPassword.Location = new System.Drawing.Point(96, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPassword.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPassword.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.txtPassword.Properties.NullText = "123456789";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(435, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUserMail
            // 
            this.txtUserMail.EditValue = "";
            this.txtUserMail.Location = new System.Drawing.Point(96, 20);
            this.txtUserMail.Name = "txtUserMail";
            this.txtUserMail.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtUserMail.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtUserMail.Properties.NullText = "abc@gmail.com";
            this.txtUserMail.Size = new System.Drawing.Size(435, 20);
            this.txtUserMail.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mật khẩu:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Email:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.ckSSL);
            this.groupBox2.Controls.Add(this.rbIMAP);
            this.groupBox2.Controls.Add(this.rbPOP);
            this.groupBox2.Controls.Add(this.txtHost);
            this.groupBox2.Controls.Add(this.labelControl8);
            this.groupBox2.Controls.Add(this.labelControl7);
            this.groupBox2.Location = new System.Drawing.Point(5, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 106);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhận thư";
            // 
            // txtPort
            // 
            this.txtPort.EditValue = "";
            this.txtPort.Location = new System.Drawing.Point(96, 61);
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPort.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPort.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPort.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPort.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPort.Properties.NullText = "0";
            this.txtPort.Size = new System.Drawing.Size(435, 20);
            this.txtPort.TabIndex = 5;
            // 
            // ckSSL
            // 
            this.ckSSL.AutoSize = true;
            this.ckSSL.Checked = true;
            this.ckSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSSL.Location = new System.Drawing.Point(96, 87);
            this.ckSSL.Name = "ckSSL";
            this.ckSSL.Size = new System.Drawing.Size(76, 17);
            this.ckSSL.TabIndex = 6;
            this.ckSSL.Text = "Hỗ trợ SSL";
            this.ckSSL.UseVisualStyleBackColor = true;
            // 
            // rbIMAP
            // 
            this.rbIMAP.AutoSize = true;
            this.rbIMAP.Checked = true;
            this.rbIMAP.Location = new System.Drawing.Point(96, 11);
            this.rbIMAP.Name = "rbIMAP";
            this.rbIMAP.Size = new System.Drawing.Size(50, 17);
            this.rbIMAP.TabIndex = 0;
            this.rbIMAP.TabStop = true;
            this.rbIMAP.Text = "IMAP";
            this.rbIMAP.UseVisualStyleBackColor = true;
            // 
            // rbPOP
            // 
            this.rbPOP.AutoSize = true;
            this.rbPOP.Location = new System.Drawing.Point(162, 11);
            this.rbPOP.Name = "rbPOP";
            this.rbPOP.Size = new System.Drawing.Size(51, 17);
            this.rbPOP.TabIndex = 1;
            this.rbPOP.Text = "POP3";
            this.rbPOP.UseVisualStyleBackColor = true;
            // 
            // txtHost
            // 
            this.txtHost.EditValue = "";
            this.txtHost.Location = new System.Drawing.Point(96, 35);
            this.txtHost.Name = "txtHost";
            this.txtHost.Properties.Appearance.Options.UseTextOptions = true;
            this.txtHost.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtHost.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHost.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtHost.Properties.NullText = "imap.gmail.com";
            this.txtHost.Size = new System.Drawing.Size(435, 20);
            this.txtHost.TabIndex = 3;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(21, 64);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(29, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "Cổng:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(21, 40);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(50, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Máy chủ : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPortSMTP);
            this.groupBox1.Controls.Add(this.ckSMTPSSL);
            this.groupBox1.Controls.Add(this.txtSMTPHost);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Location = new System.Drawing.Point(5, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 92);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gửi thư";
            // 
            // txtPortSMTP
            // 
            this.txtPortSMTP.EditValue = "";
            this.txtPortSMTP.Location = new System.Drawing.Point(96, 44);
            this.txtPortSMTP.Name = "txtPortSMTP";
            this.txtPortSMTP.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPortSMTP.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.txtPortSMTP.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPortSMTP.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtPortSMTP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPortSMTP.Properties.NullText = "0";
            this.txtPortSMTP.Size = new System.Drawing.Size(435, 20);
            this.txtPortSMTP.TabIndex = 3;
            // 
            // ckSMTPSSL
            // 
            this.ckSMTPSSL.AutoSize = true;
            this.ckSMTPSSL.Checked = true;
            this.ckSMTPSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSMTPSSL.Location = new System.Drawing.Point(96, 70);
            this.ckSMTPSSL.Name = "ckSMTPSSL";
            this.ckSMTPSSL.Size = new System.Drawing.Size(76, 17);
            this.ckSMTPSSL.TabIndex = 4;
            this.ckSMTPSSL.Text = "Hỗ trợ SSL";
            this.ckSMTPSSL.UseVisualStyleBackColor = true;
            // 
            // txtSMTPHost
            // 
            this.txtSMTPHost.EditValue = "";
            this.txtSMTPHost.Location = new System.Drawing.Point(96, 18);
            this.txtSMTPHost.Name = "txtSMTPHost";
            this.txtSMTPHost.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSMTPHost.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtSMTPHost.Properties.NullText = "smtp.gmail.com";
            this.txtSMTPHost.Size = new System.Drawing.Size(435, 20);
            this.txtSMTPHost.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Máy chủ SMTP";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(21, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 13);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Cổng SMTP:";
            // 
            // txtTenThuMuc
            // 
            this.txtTenThuMuc.EditValue = "";
            this.txtTenThuMuc.Location = new System.Drawing.Point(113, 38);
            this.txtTenThuMuc.Name = "txtTenThuMuc";
            this.txtTenThuMuc.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTenThuMuc.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txtTenThuMuc.Properties.NullText = "[Tên thư mục]";
            this.txtTenThuMuc.Size = new System.Drawing.Size(446, 20);
            this.txtTenThuMuc.TabIndex = 6;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(16, 41);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 13);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Tên thư mục:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(16, 15);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Tài khoản";
            // 
            // cbTaiKhoan
            // 
            this.cbTaiKhoan.EditValue = "[Chọn tài khoản]";
            this.cbTaiKhoan.Location = new System.Drawing.Point(113, 12);
            this.cbTaiKhoan.Name = "cbTaiKhoan";
            this.cbTaiKhoan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTaiKhoan.Properties.NullText = "[Chọn tài khoản]";
            this.cbTaiKhoan.Size = new System.Drawing.Size(263, 20);
            this.cbTaiKhoan.TabIndex = 1;
            this.cbTaiKhoan.EditValueChanged += new System.EventHandler(this.cbTaiKhoan_EditValueChanged_1);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 3;
            this.btnAdd.ImageList = this.imageCollection1;
            this.btnAdd.Location = new System.Drawing.Point(382, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.ToolTip = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.ImageIndex = 1;
            this.btnXoa.ImageList = this.imageCollection1;
            this.btnXoa.Location = new System.Drawing.Point(446, 9);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(51, 23);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.ToolTip = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXóa_Click);
            // 
            // btnSua
            // 
            this.btnSua.ImageIndex = 4;
            this.btnSua.ImageList = this.imageCollection1;
            this.btnSua.Location = new System.Drawing.Point(502, 9);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(57, 23);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.ToolTip = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSữa_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageIndex = 0;
            this.btnClose.ImageList = this.imageCollection1;
            this.btnClose.Location = new System.Drawing.Point(502, 392);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 24);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 422);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cbTaiKhoan);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtTenThuMuc);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBoqua);
            this.MaximizeBox = false;
            this.Name = "frmAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình tài khoản";
            this.Load += new System.EventHandler(this.frmAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserMail.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHost.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPortSMTP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSMTPHost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenThuMuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTaiKhoan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnBoqua;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUserMail;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckSSL;
        private System.Windows.Forms.RadioButton rbIMAP;
        private System.Windows.Forms.RadioButton rbPOP;
        private DevExpress.XtraEditors.TextEdit txtHost;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckSMTPSSL;
        private DevExpress.XtraEditors.TextEdit txtSMTPHost;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTenThuMuc;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cbTaiKhoan;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.TextEdit txtPort;
        private DevExpress.XtraEditors.TextEdit txtPortSMTP;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.Utils.ImageCollection imageCollection1;


    }
}