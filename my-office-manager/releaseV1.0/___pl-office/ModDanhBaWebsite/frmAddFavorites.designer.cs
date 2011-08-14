namespace DevExpress.XtraBars.Demos.BrowserDemo {
    partial class frmAddFavorites {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if(disposing) {
                if(components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 =  new  System.Windows.Forms.PLLabel () ;
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 =  new  System.Windows.Forms.PLLabel () ;
            this.label3 =  new  System.Windows.Forms.PLLabel () ;
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new DevExpress.XtraEditors.TextEdit();
            this.textBox2 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Browser will add this page to your Favorites list.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "URL:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(312, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(312, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            // 
            // textBox1
            // 
            this.textBox1.EditValue = "textBox1";
            this.textBox1.Location = new System.Drawing.Point(44, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 20);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.EditValue = "textBox2";
            this.textBox2.Location = new System.Drawing.Point(44, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(252, 20);
            this.textBox2.TabIndex = 7;
            // 
            // frmAddFavorites
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(398, 99);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddFavorites";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Favorite";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl label2;
        private DevExpress.XtraEditors.LabelControl label3;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit textBox1;
        private DevExpress.XtraEditors.TextEdit textBox2;
        private System.ComponentModel.Container components = null;

    }
}
