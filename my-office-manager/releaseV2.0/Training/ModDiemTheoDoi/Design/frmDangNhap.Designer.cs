namespace office
{
    partial class frmDangNhap
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
            this.labelControl1 =  new  System.Windows.Forms.PLLabel () ;
            this.labelControl2 =  new  System.Windows.Forms.PLLabel () ;
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtPassWord = new DevExpress.XtraEditors.TextEdit();
            this.btnDangNhap = new DevExpress.XtraEditors.SimpleButton();
            this.btnTuChoi = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(27, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên đăng nhập";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(106, 19);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(153, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(105, 50);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Properties.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(153, 20);
            this.txtPassWord.TabIndex = 3;
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(62, 88);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(84, 31);
            this.btnDangNhap.TabIndex = 4;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Location = new System.Drawing.Point(166, 88);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(82, 31);
            this.btnTuChoi.TabIndex = 5;
            this.btnTuChoi.Text = "Từ chối";
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 131);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangNhap";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassWord.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private DevExpress.XtraEditors.TextEdit txtPassWord;
        private DevExpress.XtraEditors.SimpleButton btnDangNhap;
        private DevExpress.XtraEditors.SimpleButton btnTuChoi;
    }
}