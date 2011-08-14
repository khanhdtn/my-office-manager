namespace office
{
    partial class frmReplyForum
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
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cachedPLHeader1 = new ProtocolVN.App.Office.Report.CachedPLHeader();
            this.NoiDung = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            this.plMultiChoiceFiles1 = new office.PLMultiChoiceFiles();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(10, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "File đính kèm";
            this.labelControl1.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(169, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đón&g";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(91, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(72, 23);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(13, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(72, 23);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnXoa);
            this.flowLayoutPanel1.Controls.Add(this.btnLuu);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(551, 453);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 30);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // NoiDung
            // 
            this.NoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.NoiDung.Location = new System.Drawing.Point(1, 38);
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Size = new System.Drawing.Size(801, 409);
            this.NoiDung.TabIndex = 21;
            // 
            // plMultiChoiceFiles1
            // 
            this.plMultiChoiceFiles1._DataSource = null;
            this.plMultiChoiceFiles1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.plMultiChoiceFiles1.Location = new System.Drawing.Point(77, 12);
            this.plMultiChoiceFiles1.Name = "plMultiChoiceFiles1";
            this.plMultiChoiceFiles1.Size = new System.Drawing.Size(725, 20);
            this.plMultiChoiceFiles1.TabIndex = 19;
            // 
            // frmReplyForum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 488);
            this.Controls.Add(this.NoiDung);
            this.Controls.Add(this.plMultiChoiceFiles1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmReplyForum";
            this.Text = "Diễn đàn thảo luận";
            this.Load += new System.EventHandler(this.frmTinTuc_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PLLabel labelControl1;
        private ProtocolVN.App.Office.Report.CachedPLHeader cachedPLHeader1;
        private PLMultiChoiceFiles plMultiChoiceFiles1;
        private DevExpress.XtraRichEdit.Demos.PLRichTextBox NoiDung;
    }
}