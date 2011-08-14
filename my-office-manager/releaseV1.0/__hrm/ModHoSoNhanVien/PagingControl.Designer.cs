namespace pl.hrm.form
{
    partial class PagerGrid
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnNextPage = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevPage = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.PLLabel();
            this.lblTongSoDong = new System.Windows.Forms.PLLabel();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "";
            this.textEdit1.Enabled = false;
            this.textEdit1.Location = new System.Drawing.Point(40, 1);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.AllowFocused = false;
            this.textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(46, 18);
            this.textEdit1.TabIndex = 1;
            // 
            // btnLast
            // 
            this.btnLast.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLast.Appearance.Options.UseFont = true;
            this.btnLast.Image = global::ProtocolVN.App.Office.Properties.Resources.Last;
            this.btnLast.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLast.Location = new System.Drawing.Point(106, 0);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(21, 21);
            this.btnLast.TabIndex = 4;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.Appearance.Options.UseFont = true;
            this.btnNextPage.Image = global::ProtocolVN.App.Office.Properties.Resources.Next;
            this.btnNextPage.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnNextPage.Location = new System.Drawing.Point(86, 0);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(21, 21);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.Appearance.Options.UseFont = true;
            this.btnPrevPage.Image = global::ProtocolVN.App.Office.Properties.Resources.Pre;
            this.btnPrevPage.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPrevPage.Location = new System.Drawing.Point(20, 0);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(21, 21);
            this.btnPrevPage.TabIndex = 0;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(132, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tổng số mẫu tin:";
            this.label1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // lblTongSoDong
            // 
            this.lblTongSoDong.Location = new System.Drawing.Point(219, 4);
            this.lblTongSoDong.Name = "lblTongSoDong";
            this.lblTongSoDong.Size = new System.Drawing.Size(0, 13);
            this.lblTongSoDong.TabIndex = 5;
            this.lblTongSoDong.ToolTip = "Dữ liệu bắt buộc nhập";
            this.lblTongSoDong.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // btnFirst
            // 
            this.btnFirst.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFirst.Appearance.Options.UseFont = true;
            this.btnFirst.Image = global::ProtocolVN.App.Office.Properties.Resources.First;
            this.btnFirst.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnFirst.Location = new System.Drawing.Point(0, 0);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(21, 21);
            this.btnFirst.TabIndex = 3;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // PagerGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTongSoDong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.btnPrevPage);
            this.Name = "PagerGrid";
            this.Size = new System.Drawing.Size(264, 21);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPrevPage;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton btnNextPage;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private  System.Windows.Forms.PLLabel  label1;
        private  System.Windows.Forms.PLLabel  lblTongSoDong;

    }
}
