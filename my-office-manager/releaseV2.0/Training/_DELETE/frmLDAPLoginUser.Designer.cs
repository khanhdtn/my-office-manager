namespace pl.khachhang.form
{
    partial class frmUser
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
            this.gctrl_Thong_Tin = new DevExpress.XtraEditors.GroupControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtTenDangNhap = new DevExpress.XtraEditors.TextEdit();
            this.lbPassword = new DevExpress.XtraEditors.LabelControl();
            this.lbTen = new DevExpress.XtraEditors.LabelControl();
            this.btDangNhap = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gctrl_Thong_Tin)).BeginInit();
            this.gctrl_Thong_Tin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gctrl_Thong_Tin
            // 
            this.gctrl_Thong_Tin.Controls.Add(this.txtPassword);
            this.gctrl_Thong_Tin.Controls.Add(this.txtTenDangNhap);
            this.gctrl_Thong_Tin.Controls.Add(this.lbPassword);
            this.gctrl_Thong_Tin.Controls.Add(this.lbTen);
            this.gctrl_Thong_Tin.Location = new System.Drawing.Point(2, 13);
            this.gctrl_Thong_Tin.Name = "gctrl_Thong_Tin";
            this.gctrl_Thong_Tin.Size = new System.Drawing.Size(354, 100);
            this.gctrl_Thong_Tin.TabIndex = 0;
            this.gctrl_Thong_Tin.Text = "Nhập Thông Tin: ";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(94, 66);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(221, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(94, 33);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(221, 20);
            this.txtTenDangNhap.TabIndex = 2;
            // 
            // lbPassword
            // 
            this.lbPassword.Location = new System.Drawing.Point(5, 69);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "Password: ";
            // 
            // lbTen
            // 
            this.lbTen.Location = new System.Drawing.Point(6, 33);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(82, 13);
            this.lbTen.TabIndex = 0;
            this.lbTen.Text = "Tên Đăng Nhập: ";
            // 
            // btDangNhap
            // 
            this.btDangNhap.Location = new System.Drawing.Point(7, 130);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btDangNhap.TabIndex = 1;
            this.btDangNhap.Text = "Đăng Nhập";
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 165);
            this.Controls.Add(this.btDangNhap);
            this.Controls.Add(this.gctrl_Thong_Tin);
            this.Name = "frmUser";
            this.Text = "Protocol - User Test";
            ((System.ComponentModel.ISupportInitialize)(this.gctrl_Thong_Tin)).EndInit();
            this.gctrl_Thong_Tin.ResumeLayout(false);
            this.gctrl_Thong_Tin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gctrl_Thong_Tin;
        private DevExpress.XtraEditors.LabelControl lbPassword;
        private DevExpress.XtraEditors.LabelControl lbTen;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtTenDangNhap;
        private DevExpress.XtraEditors.SimpleButton btDangNhap;

    }
}