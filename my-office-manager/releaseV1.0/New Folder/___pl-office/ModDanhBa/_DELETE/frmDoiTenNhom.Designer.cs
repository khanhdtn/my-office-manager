namespace office
{
    partial class frmDoiTenNhom
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
            this.txtNew_name = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.btnDong_Y = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtNew_name.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNew_name
            // 
            this.txtNew_name.Location = new System.Drawing.Point(12, 31);
            this.txtNew_name.Name = "txtNew_name";
            this.txtNew_name.Size = new System.Drawing.Size(325, 20);
            this.txtNew_name.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(258, 13);
            this.labelControl3.TabIndex = 146;
            this.labelControl3.Text = "Nhập tên mới cần thay đổi cho nhóm đang được chọn!";
            this.labelControl3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // btnDong_Y
            // 
            this.btnDong_Y.Location = new System.Drawing.Point(209, 58);
            this.btnDong_Y.Name = "btnDong_Y";
            this.btnDong_Y.Size = new System.Drawing.Size(61, 23);
            this.btnDong_Y.TabIndex = 2;
            this.btnDong_Y.Text = "Đồng ý";
            this.btnDong_Y.Click += new System.EventHandler(this.btnDong_Y_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(276, 58);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(61, 23);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmDoiTenNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 90);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnDong_Y);
            this.Controls.Add(this.txtNew_name);
            this.Controls.Add(this.labelControl3);
            this.Name = "frmDoiTenNhom";
            this.Text = "Đổi tên nhóm";
            this.Load += new System.EventHandler(this.frmDoiTenNhom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNew_name.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNew_name;
        private DevExpress.XtraEditors.SimpleButton btnDong_Y;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private System.Windows.Forms.PLLabel labelControl3;
    }
}