namespace ProtocolVN.Plugin.TimeSheet.report
{
    partial class CT_RPT_DUAN
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
            this.DenNgay = new DevExpress.XtraEditors.DateEdit();
            this.TuNgay = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 =  new  System.Windows.Forms.PLLabel () ;
            this.labelControl3 =  new  System.Windows.Forms.PLLabel () ;
            this.PLcbdu_an = new ProtocolVN.Framework.Win.PLCombobox();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(9, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 77;
            this.labelControl1.Text = "Dự án";
            // 
            // DenNgay
            // 
            this.DenNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DenNgay.EditValue = null;
            this.DenNgay.Location = new System.Drawing.Point(61, 55);
            this.DenNgay.Name = "DenNgay";
            this.DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DenNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DenNgay.Size = new System.Drawing.Size(122, 20);
            this.DenNgay.TabIndex = 81;
            // 
            // TuNgay
            // 
            this.TuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TuNgay.EditValue = null;
            this.TuNgay.Location = new System.Drawing.Point(61, 29);
            this.TuNgay.Name = "TuNgay";
            this.TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.TuNgay.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TuNgay.Size = new System.Drawing.Size(122, 20);
            this.TuNgay.TabIndex = 80;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 79;
            this.labelControl2.Text = "Đến ngày ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(6, 32);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 13);
            this.labelControl3.TabIndex = 78;
            this.labelControl3.Text = "Từ ngày ";
            // 
            // PLcbdu_an
            // 
            this.PLcbdu_an.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PLcbdu_an.DataSource = null;
            this.PLcbdu_an.DisplayField = null;
            this.PLcbdu_an.Location = new System.Drawing.Point(61, 3);
            this.PLcbdu_an.Name = "PLcbdu_an";
            this.PLcbdu_an.Size = new System.Drawing.Size(122, 20);
            this.PLcbdu_an.TabIndex = 76;            
            // 
            // CT_RPT_DUAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DenNgay);
            this.Controls.Add(this.TuNgay);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.PLcbdu_an);
            this.Name = "CT_RPT_DUAN";
            this.Size = new System.Drawing.Size(191, 79);
            this.Load += new System.EventHandler(this.RPT_DUAN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TuNgay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProtocolVN.Framework.Win.PLCombobox PLcbdu_an;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit DenNgay;
        private DevExpress.XtraEditors.DateEdit TuNgay;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;

    }
}
