using ProtocolVN.Framework.Win;
namespace office
{
    partial class frmChotPhieu
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
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.KyKinhDoanh = new ProtocolVN.Framework.Win.PLCombobox();
            this.NgayChot = new DevExpress.XtraEditors.DateEdit();
            this.lblKieuChot = new System.Windows.Forms.PLLabel();
            ((System.ComponentModel.ISupportInitialize)(this.NgayChot.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayChot.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(177, 65);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(72, 23);
            this.btnThucHien.TabIndex = 2;
            this.btnThucHien.Text = "&Chốt";
            this.btnThucHien.Click += new System.EventHandler(this.btnChot_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(255, 65);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(72, 23);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Đón&g";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // KyKinhDoanh
            // 
            this.KyKinhDoanh.DataSource = null;
            this.KyKinhDoanh.DisplayField = null;
            this.KyKinhDoanh.Location = new System.Drawing.Point(141, 27);
            this.KyKinhDoanh.Name = "KyKinhDoanh";
            this.KyKinhDoanh.Size = new System.Drawing.Size(186, 20);
            this.KyKinhDoanh.TabIndex = 61;
            this.KyKinhDoanh.ValueField = null;
            // 
            // NgayChot
            // 
            this.NgayChot.EditValue = null;
            this.NgayChot.Location = new System.Drawing.Point(141, 27);
            this.NgayChot.Name = "NgayChot";
            this.NgayChot.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayChot.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NgayChot.Size = new System.Drawing.Size(186, 20);
            this.NgayChot.TabIndex = 62;
            // 
            // lblKieuChot
            // 
            this.lblKieuChot.Location = new System.Drawing.Point(29, 30);
            this.lblKieuChot.Name = "lblKieuChot";
            this.lblKieuChot.Size = new System.Drawing.Size(74, 13);
            this.lblKieuChot.TabIndex = 63;
            this.lblKieuChot.Text = "Kỳ kinh doanh :";
            this.lblKieuChot.ToolTip = "Dữ liệu bắt buộc nhập";
            this.lblKieuChot.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // frmChotPhieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 103);
            this.Controls.Add(this.lblKieuChot);
            this.Controls.Add(this.NgayChot);
            this.Controls.Add(this.KyKinhDoanh);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnThucHien);
            this.Name = "frmChotPhieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chốt phiếu";
            this.Load += new System.EventHandler(this.frmChotPhieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NgayChot.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayChot.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PLCombobox KyKinhDoanh;
        private DevExpress.XtraEditors.DateEdit NgayChot;
        public DevExpress.XtraEditors.SimpleButton btnThucHien;
        public DevExpress.XtraEditors.SimpleButton btnThoat;
        private System.Windows.Forms.PLLabel lblKieuChot;
    }
}