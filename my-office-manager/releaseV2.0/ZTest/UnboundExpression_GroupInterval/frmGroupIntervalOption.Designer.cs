namespace ProtocolVN.Framework.Win
{
    partial class frmGroupIntervalOption
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
            this.cmbColumns = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTypeGroupInterval = new ProtocolVN.Framework.Win.PLImgCombobox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.chkReset = new DevExpress.XtraEditors.CheckEdit();
            this.chkMergeCell = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbTypeSum = new ProtocolVN.Framework.Win.PLMultiCombobox();
            ((System.ComponentModel.ISupportInitialize)(this.chkReset.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMergeCell.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTypeSum.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbColumns
            // 
            this.cmbColumns.DataSource = null;
            this.cmbColumns.DisplayField = null;
            this.cmbColumns.Location = new System.Drawing.Point(90, 24);
            this.cmbColumns.Name = "cmbColumns";
            this.cmbColumns.Size = new System.Drawing.Size(240, 20);
            this.cmbColumns.TabIndex = 4;
            this.cmbColumns.ValueField = "";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Chọn cột";
            // 
            // cmbTypeGroupInterval
            // 
            this.cmbTypeGroupInterval.DataSource = null;
            this.cmbTypeGroupInterval.DisplayField = null;
            this.cmbTypeGroupInterval.Location = new System.Drawing.Point(90, 51);
            this.cmbTypeGroupInterval.Name = "cmbTypeGroupInterval";
            this.cmbTypeGroupInterval.Size = new System.Drawing.Size(240, 20);
            this.cmbTypeGroupInterval.TabIndex = 4;
            this.cmbTypeGroupInterval.ValueField = "";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Kiểu gom nhóm";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(172, 156);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "&OK";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(253, 156);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Đón&g";
            // 
            // chkReset
            // 
            this.chkReset.Location = new System.Drawing.Point(87, 101);
            this.chkReset.Name = "chkReset";
            this.chkReset.Properties.Caption = "Xóa hết gom nhóm hiện có";
            this.chkReset.Size = new System.Drawing.Size(209, 19);
            this.chkReset.TabIndex = 7;
            // 
            // chkMergeCell
            // 
            this.chkMergeCell.Location = new System.Drawing.Point(87, 126);
            this.chkMergeCell.Name = "chkMergeCell";
            this.chkMergeCell.Properties.Caption = "Tự động gộp ô";
            this.chkMergeCell.Size = new System.Drawing.Size(209, 19);
            this.chkMergeCell.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 81);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Kiểu Sum";
            // 
            // cmbTypeSum
            // 
            this.cmbTypeSum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTypeSum.DataSource = null;
            this.cmbTypeSum.DisplayField = null;
            this.cmbTypeSum.EditValue = "";
            this.cmbTypeSum.Location = new System.Drawing.Point(90, 77);
            this.cmbTypeSum.Name = "cmbTypeSum";
            this.cmbTypeSum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTypeSum.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("1", "Thời gian làm việc"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("2", "Đi trễ về sớm"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("3", "Nghỉ phép")});
            this.cmbTypeSum.Size = new System.Drawing.Size(240, 20);
            this.cmbTypeSum.TabIndex = 53;
            this.cmbTypeSum.ValueField = null;
            // 
            // frmGroupIntervalOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 191);
            this.Controls.Add(this.cmbTypeSum);
            this.Controls.Add(this.chkMergeCell);
            this.Controls.Add(this.chkReset);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbTypeGroupInterval);
            this.Controls.Add(this.cmbColumns);
            this.Name = "frmGroupIntervalOption";
            this.Text = "Tùy chọn gom nhóm";
            this.Load += new System.EventHandler(this.frmGroupIntervalOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkReset.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMergeCell.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTypeSum.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PLImgCombobox cmbColumns;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private PLImgCombobox cmbTypeGroupInterval;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.CheckEdit chkReset;
        private DevExpress.XtraEditors.CheckEdit chkMergeCell;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private PLMultiCombobox cmbTypeSum;
    }
}