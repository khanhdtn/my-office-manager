namespace pl.office.Report
{
    partial class RPT_NHAN_VIEN
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PLNhanVien = new ProtocolVN.Framework.Win.PLCombobox();
            this.labelControl1 =  new  System.Windows.Forms.PLLabel () ;
            this.SuspendLayout();
            // 
            // PLNhanVien
            // 
            this.PLNhanVien.DataSource = null;
            this.PLNhanVien.DisplayField = null;
            this.PLNhanVien.Location = new System.Drawing.Point(59, 7);
            this.PLNhanVien.Name = "PLNhanVien";
            this.PLNhanVien.Size = new System.Drawing.Size(158, 23);
            this.PLNhanVien.TabIndex = 0;
            this.PLNhanVien.ValueField = null;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Nhân viên";
            // 
            // rpNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.PLNhanVien);
            this.Name = "rpNhanVien";
            this.Size = new System.Drawing.Size(220, 39);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProtocolVN.Framework.Win.PLCombobox PLNhanVien;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
