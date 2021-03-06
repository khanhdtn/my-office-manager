
namespace ProtocolVN.Framework.Win
{
    partial class frmCauHinhExt
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
            this.groupControlConfig = new DevExpress.XtraEditors.GroupControl();
            this.groupControlExample = new DevExpress.XtraEditors.GroupControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnXemTruoc = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlExample)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControlConfig
            // 
            this.groupControlConfig.Location = new System.Drawing.Point(12, 6);
            this.groupControlConfig.Name = "groupControlConfig";
            this.groupControlConfig.Size = new System.Drawing.Size(353, 113);
            this.groupControlConfig.TabIndex = 0;
            this.groupControlConfig.Text = "Cấu hình mẫu mã phiếu";
            // 
            // groupControlExample
            // 
            this.groupControlExample.Location = new System.Drawing.Point(201, 12);
            this.groupControlExample.Name = "groupControlExample";
            this.groupControlExample.Size = new System.Drawing.Size(129, 30);
            this.groupControlExample.TabIndex = 4;
            this.groupControlExample.Text = "Minh họa";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(100, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(181, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đón&g";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnXemTruoc
            // 
            this.btnXemTruoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemTruoc.Location = new System.Drawing.Point(3, 3);
            this.btnXemTruoc.Name = "btnXemTruoc";
            this.btnXemTruoc.Size = new System.Drawing.Size(91, 23);
            this.btnXemTruoc.TabIndex = 1;
            this.btnXemTruoc.Text = "Xem t&rước";
            this.btnXemTruoc.Click += new System.EventHandler(this.btnXemTruoc_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnXemTruoc);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(364, 136);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 31);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // frmCauHinhX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 166);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupControlConfig);
            this.Controls.Add(this.groupControlExample);
            this.Name = "frmCauHinhX";
            this.Text = "Cấu hình mẫu mã phiếu";
            ((System.ComponentModel.ISupportInitialize)(this.groupControlConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControlExample)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControlConfig;
        private DevExpress.XtraEditors.GroupControl groupControlExample;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnXemTruoc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}