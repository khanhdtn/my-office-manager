namespace pl.office
{
    partial class PagingControl
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
            this.btnPrevPage = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btnNextPage = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.Appearance.Options.UseFont = true;
            this.btnPrevPage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPrevPage.Location = new System.Drawing.Point(30, 0);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(30, 21);
            this.btnPrevPage.TabIndex = 0;
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(60, 1);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.textEdit1.Size = new System.Drawing.Size(75, 20);
            this.textEdit1.TabIndex = 1;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.Appearance.Options.UseFont = true;
            this.btnNextPage.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnNextPage.Location = new System.Drawing.Point(135, 0);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(28, 21);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.Text = ">";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFirst.Appearance.Options.UseFont = true;
            this.btnFirst.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnFirst.Location = new System.Drawing.Point(0, 0);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(31, 21);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnLast
            // 
            this.btnLast.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLast.Appearance.Options.UseFont = true;
            this.btnLast.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnLast.Location = new System.Drawing.Point(163, 0);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(28, 21);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // PagingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.btnPrevPage);
            this.Name = "PagingControl";
            this.Size = new System.Drawing.Size(192, 21);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPrevPage;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnNextPage;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnLast;

    }
}
