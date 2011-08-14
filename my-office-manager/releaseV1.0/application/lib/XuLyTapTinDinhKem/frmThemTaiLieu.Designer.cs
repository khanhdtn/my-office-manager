using DevExpress.XtraEditors;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmThemTaiLieu
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
            this.label1 = new System.Windows.Forms.PLLabel();
            this.TieuDe = new DevExpress.XtraEditors.TextEdit();
            this.FileDinhKem = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.PLLabel();
            this.GhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.label3 = new System.Windows.Forms.PLLabel();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.TieuDe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileDinhKem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GhiChu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiêu đề";
            this.label1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // TieuDe
            // 
            this.TieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TieuDe.Location = new System.Drawing.Point(89, 8);
            this.TieuDe.Name = "TieuDe";
            this.TieuDe.Size = new System.Drawing.Size(385, 20);
            this.TieuDe.TabIndex = 1;
            // 
            // FileDinhKem
            // 
            this.FileDinhKem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileDinhKem.Location = new System.Drawing.Point(89, 34);
            this.FileDinhKem.Name = "FileDinhKem";
            this.FileDinhKem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FileDinhKem.Properties.ReadOnly = true;
            this.FileDinhKem.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.FileDinhKem_Properties_ButtonClick);
            this.FileDinhKem.Size = new System.Drawing.Size(385, 20);
            this.FileDinhKem.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "File đính kèm";
            this.label2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // GhiChu
            // 
            this.GhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GhiChu.Location = new System.Drawing.Point(89, 60);
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Size = new System.Drawing.Size(385, 109);
            this.GhiChu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.label3.Appearance.Options.UseFont = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ghi chú";
            this.label3.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.label3.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(318, 175);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(399, 175);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmThemTaiLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 203);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.GhiChu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FileDinhKem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TieuDe);
            this.Controls.Add(this.label1);
            this.Name = "frmThemTaiLieu";
            this.Text = "Tài liệu";
            this.Load += new System.EventHandler(this.frmThemTaiLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TieuDe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileDinhKem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GhiChu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextEdit TieuDe;
        private ButtonEdit FileDinhKem;
        private MemoEdit GhiChu;
        public SimpleButton btnLuu;
        public SimpleButton btnDong;
        private PLLabel label1;
        private PLLabel label2;
        private PLLabel label3;
    }
}