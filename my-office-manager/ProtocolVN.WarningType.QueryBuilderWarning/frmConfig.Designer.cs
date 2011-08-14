namespace ProtocolVN.WarningType.QueryBuilderWarning
{
    partial class frmConfig
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(102, 17);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNoSave
            // 
            this.btnNoSave.Location = new System.Drawing.Point(184, 17);
            this.btnNoSave.Click += new System.EventHandler(this.btnNoSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(265, 17);
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(78, 12);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(197, 20);
            this.textEdit1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tên bảng";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 101);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit1);
            this.Name = "frmConfig";
            this.Text = "frmConfig";
            this.Controls.SetChildIndex(this.textEdit1, 0);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}