namespace office
{
    partial class frmThemLichTuan
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
            this.btn_thoat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_thuchien = new DevExpress.XtraEditors.SimpleButton();
            this.dateEdit_NgayDauTuan = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_NgayDauTuan.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_NgayDauTuan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_thoat
            // 
            this.btn_thoat.Location = new System.Drawing.Point(200, 49);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(72, 23);
            this.btn_thoat.TabIndex = 2;
            this.btn_thoat.Text = "Đón&g";
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // btn_thuchien
            // 
            this.btn_thuchien.Location = new System.Drawing.Point(122, 49);
            this.btn_thuchien.Name = "btn_thuchien";
            this.btn_thuchien.Size = new System.Drawing.Size(72, 23);
            this.btn_thuchien.TabIndex = 2;
            this.btn_thuchien.Text = "&Lưu";
            this.btn_thuchien.Click += new System.EventHandler(this.btn_thuchien_Click);
            // 
            // dateEdit_NgayDauTuan
            // 
            this.dateEdit_NgayDauTuan.EditValue = null;
            this.dateEdit_NgayDauTuan.Location = new System.Drawing.Point(50, 16);
            this.dateEdit_NgayDauTuan.Name = "dateEdit_NgayDauTuan";
            this.dateEdit_NgayDauTuan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit_NgayDauTuan.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit_NgayDauTuan.Size = new System.Drawing.Size(223, 20);
            this.dateEdit_NgayDauTuan.TabIndex = 1;
            this.dateEdit_NgayDauTuan.EditValueChanged += new System.EventHandler(this.dateEdit_NgayDauTuan_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(7, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ ngày";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // frmThemLichTuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 93);
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_thuchien);
            this.Controls.Add(this.dateEdit_NgayDauTuan);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(218, 120);
            this.Name = "frmThemLichTuan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm lịch tuần làm việc";
            this.Load += new System.EventHandler(this.frmThemLichTuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_NgayDauTuan.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit_NgayDauTuan.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_thoat;
        private DevExpress.XtraEditors.DateEdit dateEdit_NgayDauTuan;
        public DevExpress.XtraEditors.SimpleButton btn_thuchien;
        private System.Windows.Forms.PLLabel labelControl1;
    }
}