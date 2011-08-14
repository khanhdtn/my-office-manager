namespace office
{
    partial class frmAddNewNV
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
            this.PLMulNhanVien = new ProtocolVN.Framework.Win.PLMultiCombobox();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.PLMulNhanVien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 57;
            this.labelControl1.Text = "Nhân viên";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // PLMulNhanVien
            // 
            this.PLMulNhanVien.DataSource = null;
            this.PLMulNhanVien.DisplayField = null;
            this.PLMulNhanVien.EditValue = "";
            this.PLMulNhanVien.Location = new System.Drawing.Point(66, 12);
            this.PLMulNhanVien.Name = "PLMulNhanVien";
            this.PLMulNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.PLMulNhanVien.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("1", "Thời gian làm việc"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("2", "Đi trễ về sớm"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("3", "Nghỉ phép")});
            this.PLMulNhanVien.Size = new System.Drawing.Size(229, 20);
            this.PLMulNhanVien.TabIndex = 56;
            this.PLMulNhanVien.ValueField = null;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(144, 44);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 23);
            this.btnOK.TabIndex = 58;
            this.btnOK.Text = "Đồng ý";
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Location = new System.Drawing.Point(222, 44);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(72, 23);
            this.btnThoat.TabIndex = 59;
            this.btnThoat.Text = "Thoát";
            // 
            // frmAddNewNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 83);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.PLMulNhanVien);
            this.Name = "frmAddNewNV";
            this.Text = "Thêm nhân viên chấm công";
            ((System.ComponentModel.ISupportInitialize)(this.PLMulNhanVien.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PLLabel labelControl1;
        private ProtocolVN.Framework.Win.PLMultiCombobox PLMulNhanVien;
        public DevExpress.XtraEditors.SimpleButton btnOK;
        public DevExpress.XtraEditors.SimpleButton btnThoat;
    }
}