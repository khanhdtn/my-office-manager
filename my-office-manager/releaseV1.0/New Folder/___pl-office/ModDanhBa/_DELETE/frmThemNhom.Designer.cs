namespace office
{
    partial class frmThemNhom
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
            this.checklistField_Name = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.txtTen_Loai = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.btnDongy = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.checklistField_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Loai.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checklistField_Name
            // 
            this.checklistField_Name.CheckOnClick = true;
            this.checklistField_Name.Location = new System.Drawing.Point(60, 33);
            this.checklistField_Name.MultiColumn = true;
            this.checklistField_Name.Name = "checklistField_Name";
            this.checklistField_Name.Size = new System.Drawing.Size(221, 209);
            this.checklistField_Name.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(4, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tên nhóm";
            this.labelControl1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // txtTen_Loai
            // 
            this.txtTen_Loai.Location = new System.Drawing.Point(60, 8);
            this.txtTen_Loai.Name = "txtTen_Loai";
            this.txtTen_Loai.Size = new System.Drawing.Size(221, 20);
            this.txtTen_Loai.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(4, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Thông tin";
            this.labelControl2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // btnDongy
            // 
            this.btnDongy.Location = new System.Drawing.Point(15, 3);
            this.btnDongy.Name = "btnDongy";
            this.btnDongy.Size = new System.Drawing.Size(72, 23);
            this.btnDongy.TabIndex = 3;
            this.btnDongy.Text = "&Lưu";
            this.btnDongy.Click += new System.EventHandler(this.btnDongy_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(93, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(72, 23);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnDong);
            this.flowLayoutPanel1.Controls.Add(this.btnDongy);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(115, 252);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(168, 28);
            this.flowLayoutPanel1.TabIndex = 133;
            // 
            // frmThemNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 285);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtTen_Loai);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.checklistField_Name);
            this.Name = "frmThemNhom";
            this.Text = "Thêm nhóm mới";
            this.Load += new System.EventHandler(this.frmThemnhom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.checklistField_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen_Loai.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl checklistField_Name;
        private DevExpress.XtraEditors.TextEdit txtTen_Loai;
        private DevExpress.XtraEditors.SimpleButton btnDongy;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
    }
}