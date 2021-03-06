namespace ProtocolVN.Plugin.TimeSheet
{
    partial class frmTimeRecord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeRecord));
            this.gio = new System.Windows.Forms.Timer(this.components);
            this.btnBatDau = new DevExpress.XtraEditors.SimpleButton();
            this.btnKetThuc = new DevExpress.XtraEditors.SimpleButton();
            this.icontimesheet = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelControl1 =  new  System.Windows.Forms.PLLabel () ;
            this.labelControl2 =  new  System.Windows.Forms.PLLabel () ;
            this.labelControl3 =  new  System.Windows.Forms.PLLabel () ;
            this.lblTime =  new  System.Windows.Forms.PLLabel () ;
            this.labelControl4 =  new  System.Windows.Forms.PLLabel () ;
            this.PLcbdu_an = new ProtocolVN.Framework.Win.PLCombobox();
            this.Plcb_congviec = new ProtocolVN.Framework.Win.PLCombobox();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gio
            // 
            this.gio.Interval = 1000;
            this.gio.Tick += new System.EventHandler(this.gio_Tick);
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(109, 310);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(65, 22);
            this.btnBatDau.TabIndex = 72;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click_1);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Enabled = false;
            this.btnKetThuc.Location = new System.Drawing.Point(180, 310);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(65, 22);
            this.btnKetThuc.TabIndex = 73;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click_1);
            // 
            // icontimesheet
            // 
            this.icontimesheet.ContextMenuStrip = this.contextMenuStrip1;
            this.icontimesheet.Icon = ((System.Drawing.Icon)(resources.GetObject("icontimesheet.Icon")));
            this.icontimesheet.Text = "Time Sheet";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 70);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(121, 22);
            this.toolStripMenuItem1.Text = "Ẩn";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.showToolStripMenuItem.Text = "Hiển thị";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "Thoát";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(18, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "Dự án";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(18, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 67;
            this.labelControl2.Text = "Công việc";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(18, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 13);
            this.labelControl3.TabIndex = 69;
            this.labelControl3.Text = "Chi tiết công việc";
            // 
            // lblTime
            // 
            this.lblTime.Appearance.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTime.Appearance.Options.UseFont = true;
            this.lblTime.Appearance.Options.UseForeColor = true;
            this.lblTime.Location = new System.Drawing.Point(155, 254);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(144, 39);
            this.lblTime.TabIndex = 70;
            this.lblTime.Text = "00:00:00";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(18, 267);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(124, 13);
            this.labelControl4.TabIndex = 71;
            this.labelControl4.Text = "Thời gian đã thực hiện";
            // 
            // PLcbdu_an
            // 
            this.PLcbdu_an.DataSource = null;
            this.PLcbdu_an.DisplayField = null;
            this.PLcbdu_an.Location = new System.Drawing.Point(92, 12);
            this.PLcbdu_an.Name = "PLcbdu_an";
            this.PLcbdu_an.Size = new System.Drawing.Size(295, 20);
            this.PLcbdu_an.TabIndex = 75;
            this.PLcbdu_an.ValueField = null;
            this.PLcbdu_an.SelectedIndexChanged += new System.EventHandler(this.PLcbdu_an_SelectedIndexChanged);
            // 
            // Plcb_congviec
            // 
            this.Plcb_congviec.DataSource = null;
            this.Plcb_congviec.DisplayField = null;
            this.Plcb_congviec.Location = new System.Drawing.Point(92, 38);
            this.Plcb_congviec.Name = "Plcb_congviec";
            this.Plcb_congviec.Size = new System.Drawing.Size(295, 20);
            this.Plcb_congviec.TabIndex = 74;
            this.Plcb_congviec.ValueField = null;
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(18, 86);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(369, 161);
            this.memoEdit1.TabIndex = 76;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(251, 310);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(65, 22);
            this.simpleButton1.TabIndex = 77;
            this.simpleButton1.Text = "Ẩn";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(322, 310);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 22);
            this.btnClose.TabIndex = 77;
            this.btnClose.Text = "Đóng";
            // 
            // frmTimeRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 344);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.Plcb_congviec);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.PLcbdu_an);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnBatDau);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmTimeRecord";
            this.Text = "Ghi nhận công việc";
            this.Load += new System.EventHandler(this.frmDemo_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDemo_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gio;
        private DevExpress.XtraEditors.SimpleButton btnBatDau;
        private DevExpress.XtraEditors.SimpleButton btnKetThuc;
        private System.Windows.Forms.NotifyIcon icontimesheet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblTime;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private ProtocolVN.Framework.Win.PLCombobox PLcbdu_an;
        private ProtocolVN.Framework.Win.PLCombobox Plcb_congviec;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}