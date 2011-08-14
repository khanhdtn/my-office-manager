namespace pl.hrm.form
{
    partial class TimeEdit1
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
            this.TimeEditSub = new DevExpress.XtraEditors.TimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeEditSub.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // TimeEditSub
            // 
            this.TimeEditSub.EditValue = new System.DateTime(2008, 4, 26, 0, 0, 0, 0);
            this.TimeEditSub.Location = new System.Drawing.Point(1, 3);
            this.TimeEditSub.Name = "TimeEditSub";
            this.TimeEditSub.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.TimeEditSub.Properties.Mask.EditMask = "t";
            this.TimeEditSub.Size = new System.Drawing.Size(100, 20);
            this.TimeEditSub.TabIndex = 0;
            this.TimeEditSub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.timeEdit2_KeyPress);
            this.TimeEditSub.KeyUp += new System.Windows.Forms.KeyEventHandler(this.timeEdit2_KeyUp);
            this.TimeEditSub.Click += new System.EventHandler(this.timeEdit2_Click);
            // 
            // TimeEdit1
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TimeEditSub);
            this.Name = "TimeEdit1";
            this.Size = new System.Drawing.Size(103, 28);
            this.Load += new System.EventHandler(this.TimeEdit1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TimeEditSub.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TimeEdit TimeEditSub;
    }
}
