using ProtocolVN.Framework.Win;
namespace ProtocolVN.Framework.Win
{
    partial class frmBroadCast
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.ChuDe = new DevExpress.XtraEditors.MemoEdit();
            this.NoiDung = new System.Windows.Forms.RichTextBox();
            this.NguoiNhap = new DevExpress.XtraEditors.LabelControl();
            this.NgayNhap = new DevExpress.XtraEditors.LabelControl();
            this.pldmTreeMultiChoice1 = new ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ChuDe.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Người thông báo";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(10, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(96, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Thời gian thông báo";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(307, 359);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(54, 23);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "&Gửi";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(367, 359);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(52, 23);
            this.btnDong.TabIndex = 10;
            this.btnDong.Text = "Đón&g";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // ChuDe
            // 
            this.ChuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ChuDe.EditValue = "";
            this.ChuDe.Location = new System.Drawing.Point(84, 83);
            this.ChuDe.Name = "ChuDe";
            this.ChuDe.Properties.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ChuDe.Properties.Appearance.Options.UseForeColor = true;
            this.ChuDe.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ChuDe.Size = new System.Drawing.Size(339, 37);
            this.ChuDe.TabIndex = 11;
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(84, 130);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(339, 219);
            this.NoiDung.TabIndex = 12;
            this.NoiDung.Text = "";
            // 
            // NguoiNhap
            // 
            this.NguoiNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NguoiNhap.Appearance.Options.UseFont = true;
            this.NguoiNhap.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.NguoiNhap.Location = new System.Drawing.Point(116, 9);
            this.NguoiNhap.Name = "NguoiNhap";
            this.NguoiNhap.Size = new System.Drawing.Size(187, 14);
            this.NguoiNhap.TabIndex = 15;
            this.NguoiNhap.Text = "Hồ Sỹ Đức";
            // 
            // NgayNhap
            // 
            this.NgayNhap.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NgayNhap.Appearance.Options.UseFont = true;
            this.NgayNhap.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.NgayNhap.Location = new System.Drawing.Point(114, 27);
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Size = new System.Drawing.Size(143, 13);
            this.NgayNhap.TabIndex = 16;
            this.NgayNhap.Text = "24/8/2010 5:64:54 AM";
            // 
            // pldmTreeMultiChoice1
            // 
            this.pldmTreeMultiChoice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pldmTreeMultiChoice1.Location = new System.Drawing.Point(84, 56);
            this.pldmTreeMultiChoice1.Name = "pldmTreeMultiChoice1";
            this.pldmTreeMultiChoice1.Size = new System.Drawing.Size(339, 20);
            this.pldmTreeMultiChoice1.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 56);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 13);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "Người nhận";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 85);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 13);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Chủ đề";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 127);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(42, 13);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Nội dung";
            // 
            // frmBroadCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 390);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.ChuDe);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.NguoiNhap);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pldmTreeMultiChoice1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.NgayNhap);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnLuu);
            this.Name = "frmBroadCast";
            this.Text = "Gửi thông báo nội bộ";
            ((System.ComponentModel.ISupportInitialize)(this.ChuDe.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.MemoEdit ChuDe;
        private System.Windows.Forms.RichTextBox NoiDung;
        private DevExpress.XtraEditors.LabelControl NguoiNhap;
        private DevExpress.XtraEditors.LabelControl NgayNhap;
        private ProtocolVN.App.Office.ApplicationCore.PLDMTreeMultiChoice pldmTreeMultiChoice1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}