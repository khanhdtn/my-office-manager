namespace pl.office.Report
{
    partial class RPT_TRA_LUONG
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
            this.dateThang = new DevExpress.XtraEditors.TimeEdit();
            this.label2 = new  System.Windows.Forms.PLLabel ();
            this.cmbNhanVien = new ProtocolVN.Framework.Win.PLMultiCombobox();
            this.label1 = new  System.Windows.Forms.PLLabel ();
            ((System.ComponentModel.ISupportInitialize)(this.dateThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhanVien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dateThang
            // 
            this.dateThang.EditValue = new System.DateTime(2008, 5, 19, 0, 0, 0, 0);
            this.dateThang.Location = new System.Drawing.Point(72, 15);
            this.dateThang.Name = "dateThang";
            this.dateThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateThang.Properties.DisplayFormat.FormatString = "MM/yyyy";
            this.dateThang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateThang.Properties.EditFormat.FormatString = "MM/yyyy";
            this.dateThang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dateThang.Properties.Mask.EditMask = "MM/yyyy";
            this.dateThang.Size = new System.Drawing.Size(115, 20);
            this.dateThang.TabIndex = 199;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 198;
            this.label2.Text = "Lương tháng";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DataSource = null;
            this.cmbNhanVien.DisplayField = null;
            this.cmbNhanVien.EditValue = "";
            this.cmbNhanVien.Location = new System.Drawing.Point(72, 41);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNhanVien.Size = new System.Drawing.Size(115, 20);
            this.cmbNhanVien.TabIndex = 200;
            this.cmbNhanVien.ValueField = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 201;
            this.label1.Text = "Nhân viên";
            // 
            // RPT_TraLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.dateThang);
            this.Controls.Add(this.label2);
            this.Name = "RPT_TraLuong";
            this.Size = new System.Drawing.Size(191, 75);
            ((System.ComponentModel.ISupportInitialize)(this.dateThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhanVien.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit dateThang;
        private  System.Windows.Forms.PLLabel  label2;
        private ProtocolVN.Framework.Win.PLMultiCombobox cmbNhanVien;
        private  System.Windows.Forms.PLLabel  label1;
    }
}
