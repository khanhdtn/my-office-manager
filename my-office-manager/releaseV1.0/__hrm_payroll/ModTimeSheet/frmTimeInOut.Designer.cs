namespace ProtocolVN.Plugin.TimeSheet
{
    partial class frmTimeInOut
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
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch
            {
                
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.PLLabel();
            this.label2 = new System.Windows.Forms.PLLabel();
            this.btnEnd = new DevExpress.XtraEditors.SimpleButton();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.lblGioBatDauKetThuc = new System.Windows.Forms.PLLabel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.PLLabel();
            this.timeEditBatDau = new DevExpress.XtraEditors.TimeEdit();
            this.timeEditKetThuc = new DevExpress.XtraEditors.TimeEdit();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.txtNgayLamViec = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditKetThuc.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân viên";
            this.label1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // label2
            // 
            this.label2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.label2.Appearance.Options.UseFont = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày làm việc";
            this.label2.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // btnEnd
            // 
            this.btnEnd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEnd.Appearance.Options.UseFont = true;
            this.btnEnd.Location = new System.Drawing.Point(88, 3);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(72, 23);
            this.btnEnd.TabIndex = 5;
            this.btnEnd.Text = "&Kết thúc ";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStart.Appearance.Options.UseFont = true;
            this.btnStart.Location = new System.Drawing.Point(10, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "&Bắt đầu";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblGioBatDauKetThuc
            // 
            this.lblGioBatDauKetThuc.Location = new System.Drawing.Point(7, 61);
            this.lblGioBatDauKetThuc.Name = "lblGioBatDauKetThuc";
            this.lblGioBatDauKetThuc.Size = new System.Drawing.Size(57, 13);
            this.lblGioBatDauKetThuc.TabIndex = 4;
            this.lblGioBatDauKetThuc.Text = "Thời gian từ";
            this.lblGioBatDauKetThuc.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(166, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đón&g";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thời gian đến";
            this.label3.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // timeEditBatDau
            // 
            this.timeEditBatDau.EditValue = new System.DateTime(2009, 7, 6, 0, 0, 0, 0);
            this.timeEditBatDau.Location = new System.Drawing.Point(79, 57);
            this.timeEditBatDau.Name = "timeEditBatDau";
            this.timeEditBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditBatDau.Size = new System.Drawing.Size(200, 20);
            this.timeEditBatDau.TabIndex = 2;
            // 
            // timeEditKetThuc
            // 
            this.timeEditKetThuc.EditValue = new System.DateTime(2009, 7, 6, 0, 0, 0, 0);
            this.timeEditKetThuc.Location = new System.Drawing.Point(79, 80);
            this.timeEditKetThuc.Name = "timeEditKetThuc";
            this.timeEditKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEditKetThuc.Size = new System.Drawing.Size(200, 20);
            this.timeEditKetThuc.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnEnd);
            this.flowLayoutPanel1.Controls.Add(this.btnStart);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(40, 109);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(241, 30);
            this.flowLayoutPanel1.TabIndex = 134;
            // 
            // txtNhanVien
            // 
            this.txtNhanVien.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVien.Appearance.Options.UseFont = true;
            this.txtNhanVien.Location = new System.Drawing.Point(79, 10);
            this.txtNhanVien.Name = "txtNhanVien";
            this.txtNhanVien.Size = new System.Drawing.Size(123, 16);
            this.txtNhanVien.TabIndex = 135;
            this.txtNhanVien.Text = "Lầm Trần Thiên Lộc";
            // 
            // txtNgayLamViec
            // 
            this.txtNgayLamViec.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayLamViec.Appearance.Options.UseFont = true;
            this.txtNgayLamViec.Location = new System.Drawing.Point(79, 35);
            this.txtNgayLamViec.Name = "txtNgayLamViec";
            this.txtNgayLamViec.Size = new System.Drawing.Size(79, 13);
            this.txtNgayLamViec.TabIndex = 136;
            this.txtNgayLamViec.Text = "Chưa xác định";
            // 
            // frmTimeInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 149);
            this.Controls.Add(this.txtNgayLamViec);
            this.Controls.Add(this.txtNhanVien);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.timeEditKetThuc);
            this.Controls.Add(this.timeEditBatDau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblGioBatDauKetThuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmTimeInOut";
            this.Text = "Ghi thời gian";
            this.Load += new System.EventHandler(this.frmNgaylamviec_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeEditBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEditKetThuc.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private  System.Windows.Forms.PLLabel  label1;
        private  System.Windows.Forms.PLLabel  label2;
        public DevExpress.XtraEditors.SimpleButton btnEnd;
        public DevExpress.XtraEditors.SimpleButton btnStart;
        public  System.Windows.Forms.PLLabel  lblGioBatDauKetThuc;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        private  System.Windows.Forms.PLLabel  label3;
        private DevExpress.XtraEditors.TimeEdit timeEditBatDau;
        private DevExpress.XtraEditors.TimeEdit timeEditKetThuc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl txtNhanVien;
        private DevExpress.XtraEditors.LabelControl txtNgayLamViec;
    }
}