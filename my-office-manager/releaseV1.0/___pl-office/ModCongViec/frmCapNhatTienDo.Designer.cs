namespace office
{
    partial class frmCapNhatTienDo
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
            this.labelControl1 = new System.Windows.Forms.PLLabel();
            this.labelControl2 = new System.Windows.Forms.PLLabel();
            this.labelControl3 = new System.Windows.Forms.PLLabel();
            this.ztbarTienDoThucHien = new DevExpress.XtraEditors.ZoomTrackBarControl();
            this.memoGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.gridCtrlTienDoThucHien = new DevExpress.XtraGrid.GridControl();
            this.gridViewTienDoThuHien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNgayCapNhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTienDoThuHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTienDo = new System.Windows.Forms.PLLabel();
            this.buttonLuu = new DevExpress.XtraEditors.SimpleButton();
            this.buttonThoat = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelControl5 = new System.Windows.Forms.PLLabel();
            this.labelControl4 = new System.Windows.Forms.PLLabel();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.txtTenDuAn = new System.Windows.Forms.PLLabel();
            this.txtNguoiCapNhat = new System.Windows.Forms.PLLabel();
            this.txtThoiGianCapNhat = new System.Windows.Forms.PLLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ztbarTienDoThucHien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbarTienDoThucHien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlTienDoThucHien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTienDoThuHien)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(370, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Người cập nhật";
            this.labelControl1.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(370, 39);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Thời gian cập nhật";
            this.labelControl2.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 39);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Tiến độ";
            this.labelControl3.ToolTip = "Dữ liệu bắt buộc nhập";
            this.labelControl3.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // ztbarTienDoThucHien
            // 
            this.ztbarTienDoThucHien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ztbarTienDoThucHien.EditValue = null;
            this.ztbarTienDoThucHien.Location = new System.Drawing.Point(85, 39);
            this.ztbarTienDoThucHien.Name = "ztbarTienDoThucHien";
            this.ztbarTienDoThucHien.Properties.Maximum = 100;
            this.ztbarTienDoThucHien.Properties.ScrollThumbStyle = DevExpress.XtraEditors.Repository.ScrollThumbStyle.ArrowDownRight;
            this.ztbarTienDoThucHien.Size = new System.Drawing.Size(187, 18);
            this.ztbarTienDoThucHien.TabIndex = 4;
            this.ztbarTienDoThucHien.EditValueChanged += new System.EventHandler(this.ztbarTienDoThucHien_EditValueChanged);
            this.ztbarTienDoThucHien.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.ztbarTienDoThucHien_EditValueChanging);
            // 
            // memoGhiChu
            // 
            this.memoGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memoGhiChu.Location = new System.Drawing.Point(85, 66);
            this.memoGhiChu.Name = "memoGhiChu";
            this.memoGhiChu.Size = new System.Drawing.Size(544, 67);
            this.memoGhiChu.TabIndex = 5;
            // 
            // gridCtrlTienDoThucHien
            // 
            this.gridCtrlTienDoThucHien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCtrlTienDoThucHien.Location = new System.Drawing.Point(12, 139);
            this.gridCtrlTienDoThucHien.MainView = this.gridViewTienDoThuHien;
            this.gridCtrlTienDoThucHien.Name = "gridCtrlTienDoThucHien";
            this.gridCtrlTienDoThucHien.Size = new System.Drawing.Size(617, 185);
            this.gridCtrlTienDoThucHien.TabIndex = 5;
            this.gridCtrlTienDoThucHien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTienDoThuHien});
            // 
            // gridViewTienDoThuHien
            // 
            this.gridViewTienDoThuHien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNgayCapNhat,
            this.colTienDoThuHien,
            this.colGhiChu});
            this.gridViewTienDoThuHien.GridControl = this.gridCtrlTienDoThucHien;
            this.gridViewTienDoThuHien.Name = "gridViewTienDoThuHien";
            this.gridViewTienDoThuHien.OptionsBehavior.Editable = false;
            this.gridViewTienDoThuHien.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewTienDoThuHien.OptionsView.ShowFooter = true;
            this.gridViewTienDoThuHien.OptionsView.ShowGroupPanel = false;
            this.gridViewTienDoThuHien.OptionsView.ShowIndicator = false;
            this.gridViewTienDoThuHien.OptionsView.ShowViewCaption = true;
            // 
            // colNgayCapNhat
            // 
            this.colNgayCapNhat.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayCapNhat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayCapNhat.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayCapNhat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayCapNhat.Caption = "Thời gian cập nhật";
            this.colNgayCapNhat.Name = "colNgayCapNhat";
            this.colNgayCapNhat.Visible = true;
            this.colNgayCapNhat.VisibleIndex = 0;
            this.colNgayCapNhat.Width = 155;
            // 
            // colTienDoThuHien
            // 
            this.colTienDoThuHien.Caption = "Tiến độ thực hiện";
            this.colTienDoThuHien.Name = "colTienDoThuHien";
            this.colTienDoThuHien.Visible = true;
            this.colTienDoThuHien.VisibleIndex = 1;
            this.colTienDoThuHien.Width = 177;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 2;
            this.colGhiChu.Width = 182;
            // 
            // lblTienDo
            // 
            this.lblTienDo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTienDo.Appearance.Options.UseTextOptions = true;
            this.lblTienDo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTienDo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTienDo.Location = new System.Drawing.Point(278, 42);
            this.lblTienDo.Name = "lblTienDo";
            this.lblTienDo.Size = new System.Drawing.Size(18, 13);
            this.lblTienDo.TabIndex = 11;
            this.lblTienDo.Text = "0";
            this.lblTienDo.ToolTip = "Dữ liệu bắt buộc nhập";
            this.lblTienDo.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // buttonLuu
            // 
            this.buttonLuu.Location = new System.Drawing.Point(7, 3);
            this.buttonLuu.Name = "buttonLuu";
            this.buttonLuu.Size = new System.Drawing.Size(72, 23);
            this.buttonLuu.TabIndex = 6;
            this.buttonLuu.Text = "Lưu";
            this.buttonLuu.Click += new System.EventHandler(this.buttonLuu_Click);
            // 
            // buttonThoat
            // 
            this.buttonThoat.Location = new System.Drawing.Point(85, 3);
            this.buttonThoat.Name = "buttonThoat";
            this.buttonThoat.Size = new System.Drawing.Size(72, 23);
            this.buttonThoat.TabIndex = 7;
            this.buttonThoat.Text = "Đóng";
            this.buttonThoat.Click += new System.EventHandler(this.buttonThoat_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.buttonThoat);
            this.flowLayoutPanel1.Controls.Add(this.buttonLuu);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(472, 338);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(160, 29);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(12, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(67, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Tên công việc";
            this.labelControl5.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(12, 69);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(35, 13);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Ghi chú";
            this.labelControl4.ToolTip = "Dữ liệu không bắt buộc nhập";
            this.labelControl4.ZZZType = System.Windows.Forms.PLLabel.LabelType.OPTION;
            // 
            // plLabel1
            // 
            this.plLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.plLabel1.Location = new System.Drawing.Point(297, 42);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(11, 13);
            this.plLabel1.TabIndex = 15;
            this.plLabel1.Text = "%";
            this.plLabel1.ToolTip = "Dữ liệu bắt buộc nhập";
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // txtTenDuAn
            // 
            this.txtTenDuAn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTenDuAn.Appearance.Options.UseFont = true;
            this.txtTenDuAn.Location = new System.Drawing.Point(85, 16);
            this.txtTenDuAn.Name = "txtTenDuAn";
            this.txtTenDuAn.Size = new System.Drawing.Size(39, 13);
            this.txtTenDuAn.TabIndex = 0;
            this.txtTenDuAn.Text = "<Tên>";
            this.txtTenDuAn.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // txtNguoiCapNhat
            // 
            this.txtNguoiCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNguoiCapNhat.Appearance.Options.UseFont = true;
            this.txtNguoiCapNhat.Location = new System.Drawing.Point(465, 16);
            this.txtNguoiCapNhat.Name = "txtNguoiCapNhat";
            this.txtNguoiCapNhat.Size = new System.Drawing.Size(102, 13);
            this.txtNguoiCapNhat.TabIndex = 1;
            this.txtNguoiCapNhat.Text = "<Người cập nhật>";
            this.txtNguoiCapNhat.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // txtThoiGianCapNhat
            // 
            this.txtThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.txtThoiGianCapNhat.Location = new System.Drawing.Point(465, 39);
            this.txtThoiGianCapNhat.Name = "txtThoiGianCapNhat";
            this.txtThoiGianCapNhat.Size = new System.Drawing.Size(121, 13);
            this.txtThoiGianCapNhat.TabIndex = 2;
            this.txtThoiGianCapNhat.Text = "<Thời gian cập nhật>";
            this.txtThoiGianCapNhat.ZZZType = System.Windows.Forms.PLLabel.LabelType.NORMAL;
            // 
            // frmCapNhatTienDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 372);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.gridCtrlTienDoThucHien);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.memoGhiChu);
            this.Controls.Add(this.txtTenDuAn);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTienDo);
            this.Controls.Add(this.ztbarTienDoThucHien);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtThoiGianCapNhat);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtNguoiCapNhat);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmCapNhatTienDo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật tiến độ thực hiện";
            this.Load += new System.EventHandler(this.frmCapNhatTienDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ztbarTienDoThucHien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztbarTienDoThucHien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCtrlTienDoThucHien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTienDoThuHien)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ZoomTrackBarControl ztbarTienDoThucHien;
        private DevExpress.XtraEditors.MemoEdit memoGhiChu;
        private DevExpress.XtraGrid.GridControl gridCtrlTienDoThucHien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTienDoThuHien;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayCapNhat;
        private DevExpress.XtraGrid.Columns.GridColumn colTienDoThuHien;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        public DevExpress.XtraEditors.SimpleButton buttonLuu;
        private DevExpress.XtraEditors.SimpleButton buttonThoat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PLLabel labelControl1;
        private System.Windows.Forms.PLLabel labelControl2;
        private System.Windows.Forms.PLLabel labelControl3;
        private System.Windows.Forms.PLLabel lblTienDo;
        private System.Windows.Forms.PLLabel labelControl5;
        private System.Windows.Forms.PLLabel labelControl4;
        private System.Windows.Forms.PLLabel plLabel1;
        private System.Windows.Forms.PLLabel txtTenDuAn;
        private System.Windows.Forms.PLLabel txtNguoiCapNhat;
        private System.Windows.Forms.PLLabel txtThoiGianCapNhat;
    }
}