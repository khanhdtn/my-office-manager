namespace ProtocolVN.Plugin.TimeSheet.report
{
    partial class CT_TONGHOPDUAN
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
            this.labelControl1 =  new  System.Windows.Forms.PLLabel () ;
            this.PLcbdu_an = new ProtocolVN.Framework.Win.PLCombobox();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 79;
            this.labelControl1.Text = "Dự án";
            // 
            // PLcbdu_an
            // 
            this.PLcbdu_an.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PLcbdu_an.DataSource = null;
            this.PLcbdu_an.DisplayField = null;
            this.PLcbdu_an.Location = new System.Drawing.Point(44, 3);
            this.PLcbdu_an.Name = "PLcbdu_an";
            this.PLcbdu_an.Size = new System.Drawing.Size(122, 20);
            this.PLcbdu_an.TabIndex = 78;
            this.PLcbdu_an.ValueField = null;
            // 
            // CT_TONGHOPDUAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.PLcbdu_an);
            this.Name = "CT_TONGHOPDUAN";
            this.Size = new System.Drawing.Size(169, 27);
            this.Load += new System.EventHandler(this.CT_TONGHOPDUAN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private ProtocolVN.Framework.Win.PLCombobox PLcbdu_an;
    }
}
