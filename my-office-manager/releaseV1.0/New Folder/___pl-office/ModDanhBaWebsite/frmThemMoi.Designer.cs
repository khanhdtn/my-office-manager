using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmThemMoi
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
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.PhanLoai = new ProtocolVN.Framework.Win.PLCombobox();
            this.TxtLinkWeb = new DevExpress.XtraEditors.TextEdit();
            this.MeMoTa = new DevExpress.XtraEditors.MemoEdit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtLinkWeb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeMoTa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(115, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 13);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(43, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Phân loại";
            this.labelControl7.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl7.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(106, 134);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(268, 30);
            this.flowLayoutPanel1.TabIndex = 133;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(193, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đón&g";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 65);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Mô tả";
            this.labelControl4.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Liên kết";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // PhanLoai
            // 
            this.PhanLoai.DataSource = null;
            this.PhanLoai.DisplayField = null;
            this.PhanLoai.Location = new System.Drawing.Point(61, 9);
            this.PhanLoai.Name = "PhanLoai";
            this.PhanLoai.Size = new System.Drawing.Size(310, 20);
            this.PhanLoai.TabIndex = 1;
            // 
            // TxtLinkWeb
            // 
            this.TxtLinkWeb.Location = new System.Drawing.Point(61, 35);
            this.TxtLinkWeb.Name = "TxtLinkWeb";
            this.TxtLinkWeb.Size = new System.Drawing.Size(310, 20);
            this.TxtLinkWeb.TabIndex = 2;
            // 
            // MeMoTa
            // 
            this.MeMoTa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MeMoTa.Location = new System.Drawing.Point(61, 61);
            this.MeMoTa.Name = "MeMoTa";
            this.MeMoTa.Size = new System.Drawing.Size(310, 63);
            this.MeMoTa.TabIndex = 3;
            // 
            // frmThemMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 173);
            this.Controls.Add(this.MeMoTa);
            this.Controls.Add(this.TxtLinkWeb);
            this.Controls.Add(this.PhanLoai);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl7);
            this.Name = "frmThemMoi";
            this.Text = "Danh bạ website";
            this.Load += new System.EventHandler(this.frmThemMoi_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtLinkWeb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MeMoTa.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public DevExpress.XtraEditors.SimpleButton btnDong;
        private PLCombobox PhanLoai;
        private System.Windows.Forms.PLLabel labelControl7;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtLinkWeb;
        private DevExpress.XtraEditors.MemoEdit MeMoTa;
    }
}