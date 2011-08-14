using DevExpress.XtraEditors;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmTapTinInAn
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
            this.FileDinhKem = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.PLLabel();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.spinSo_ban = new DevExpress.XtraEditors.SpinEdit();
            this.GhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            ((System.ComponentModel.ISupportInitialize)(this.FileDinhKem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSo_ban.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GhiChu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // FileDinhKem
            // 
            this.FileDinhKem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.FileDinhKem.Location = new System.Drawing.Point(78, 13);
            this.FileDinhKem.Name = "FileDinhKem";
            this.FileDinhKem.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.FileDinhKem.Properties.ReadOnly = true;
            this.FileDinhKem.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.FileDinhKem_Properties_ButtonClick);
            this.FileDinhKem.Size = new System.Drawing.Size(239, 20);
            this.FileDinhKem.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "File đính kèm";
            this.label2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(217, 125);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(296, 125);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 42);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Số bản";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 68);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Yêu cầu";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // spinSo_ban
            // 
            this.spinSo_ban.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSo_ban.Location = new System.Drawing.Point(78, 39);
            this.spinSo_ban.Name = "spinSo_ban";
            this.spinSo_ban.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.spinSo_ban.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.spinSo_ban.Size = new System.Drawing.Size(63, 20);
            this.spinSo_ban.TabIndex = 2;
            // 
            // GhiChu
            // 
            this.GhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GhiChu.EditValue = "";
            this.GhiChu.Location = new System.Drawing.Point(78, 66);
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Size = new System.Drawing.Size(290, 53);
            this.GhiChu.TabIndex = 4;
            // 
            // plLabel1
            // 
            this.plLabel1.Location = new System.Drawing.Point(323, 16);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(45, 13);
            this.plLabel1.TabIndex = 0;
            this.plLabel1.Text = "(< 20MB)";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // frmTapTinInAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 153);
            this.Controls.Add(this.spinSo_ban);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.GhiChu);
            this.Controls.Add(this.FileDinhKem);
            this.Controls.Add(this.label2);
            this.Name = "frmTapTinInAn";
            this.Text = "File in ấn";
            this.Load += new System.EventHandler(this.frmThemTaiLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FileDinhKem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSo_ban.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GhiChu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ButtonEdit FileDinhKem;
        public SimpleButton btnLuu;
        public SimpleButton btnDong;
        private SpinEdit spinSo_ban;
        private PLLabel label2;
        private PLLabel labelControl1;
        private PLLabel labelControl2;
        private MemoEdit GhiChu;
        private PLLabel plLabel1;
    }
}