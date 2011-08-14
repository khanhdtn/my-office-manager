namespace PermissionOfResource
{
    partial class frmPermissionDataPopUp
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissionDataPopUp));
            this.lblCreatedDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCreater = new DevExpress.XtraEditors.LabelControl();
            this.lblCaptionCreatedDate = new System.Windows.Forms.PLLabel();
            this.lblCaptionCreater = new System.Windows.Forms.PLLabel();
            this.lblCaptionResource = new System.Windows.Forms.PLLabel();
            this.lblCaptionResourceGroup = new System.Windows.Forms.PLLabel();
            this.lblResource = new DevExpress.XtraEditors.LabelControl();
            this.lblResourceGroup = new DevExpress.XtraEditors.LabelControl();
            this.treeListPermission = new DevExpress.XtraTreeList.PLTreeList();
            this.ColEmpName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColFullPermission = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsRead = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsUpdate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsDelete = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsDepartment = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsCreate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.treeListPermission)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreatedDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedDate.Appearance.Options.UseFont = true;
            this.lblCreatedDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCreatedDate.Location = new System.Drawing.Point(588, 49);
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(195, 13);
            this.lblCreatedDate.TabIndex = 15;
            this.lblCreatedDate.Text = "Chưa xác định";
            // 
            // lblCreater
            // 
            this.lblCreater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreater.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreater.Appearance.Options.UseFont = true;
            this.lblCreater.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCreater.Location = new System.Drawing.Point(588, 22);
            this.lblCreater.Name = "lblCreater";
            this.lblCreater.Size = new System.Drawing.Size(195, 13);
            this.lblCreater.TabIndex = 14;
            this.lblCreater.Text = "Chưa xác định";
            // 
            // lblCaptionCreatedDate
            // 
            this.lblCaptionCreatedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaptionCreatedDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblCaptionCreatedDate.Appearance.Options.UseFont = true;
            this.lblCaptionCreatedDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaptionCreatedDate.Location = new System.Drawing.Point(483, 49);
            this.lblCaptionCreatedDate.Name = "lblCaptionCreatedDate";
            this.lblCaptionCreatedDate.Size = new System.Drawing.Size(89, 13);
            this.lblCaptionCreatedDate.TabIndex = 12;
            this.lblCaptionCreatedDate.Text = "Thời gian cập nhật";
            this.lblCaptionCreatedDate.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // lblCaptionCreater
            // 
            this.lblCaptionCreater.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaptionCreater.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblCaptionCreater.Appearance.Options.UseFont = true;
            this.lblCaptionCreater.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaptionCreater.Location = new System.Drawing.Point(483, 22);
            this.lblCaptionCreater.Name = "lblCaptionCreater";
            this.lblCaptionCreater.Size = new System.Drawing.Size(74, 13);
            this.lblCaptionCreater.TabIndex = 13;
            this.lblCaptionCreater.Text = "Người cập nhật";
            this.lblCaptionCreater.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // lblCaptionResource
            // 
            this.lblCaptionResource.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblCaptionResource.Appearance.Options.UseFont = true;
            this.lblCaptionResource.Location = new System.Drawing.Point(12, 22);
            this.lblCaptionResource.Name = "lblCaptionResource";
            this.lblCaptionResource.Size = new System.Drawing.Size(34, 13);
            this.lblCaptionResource.TabIndex = 13;
            this.lblCaptionResource.Text = "Tài liệu";
            this.lblCaptionResource.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // lblCaptionResourceGroup
            // 
            this.lblCaptionResourceGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.lblCaptionResourceGroup.Appearance.Options.UseFont = true;
            this.lblCaptionResourceGroup.Location = new System.Drawing.Point(12, 49);
            this.lblCaptionResourceGroup.Name = "lblCaptionResourceGroup";
            this.lblCaptionResourceGroup.Size = new System.Drawing.Size(54, 13);
            this.lblCaptionResourceGroup.TabIndex = 12;
            this.lblCaptionResourceGroup.Text = "Loại tài liệu";
            this.lblCaptionResourceGroup.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // lblResource
            // 
            this.lblResource.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResource.Appearance.Options.UseFont = true;
            this.lblResource.Location = new System.Drawing.Point(109, 22);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(48, 13);
            this.lblResource.TabIndex = 14;
            this.lblResource.Text = "tài liệu a";
            // 
            // lblResourceGroup
            // 
            this.lblResourceGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResourceGroup.Appearance.Options.UseFont = true;
            this.lblResourceGroup.Location = new System.Drawing.Point(109, 49);
            this.lblResourceGroup.Name = "lblResourceGroup";
            this.lblResourceGroup.Size = new System.Drawing.Size(70, 13);
            this.lblResourceGroup.TabIndex = 15;
            this.lblResourceGroup.Text = "loại tài liệu c";
            // 
            // treeListPermission
            // 
            this.treeListPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListPermission.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeListPermission.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListPermission.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColEmpName,
            this.ColFullPermission,
            this.ColIsRead,
            this.ColIsUpdate,
            this.ColIsDelete,
            this.ColID,
            this.ColIsDepartment,
            this.ColIsCreate});
            this.treeListPermission.Location = new System.Drawing.Point(12, 68);
            this.treeListPermission.Name = "treeListPermission";
            this.treeListPermission.OptionsBehavior.AutoFocusNewNode = true;
            this.treeListPermission.OptionsView.EnableAppearanceEvenRow = true;
            this.treeListPermission.OptionsView.EnableAppearanceOddRow = true;
            this.treeListPermission.OptionsView.ShowIndicator = false;
            this.treeListPermission.Size = new System.Drawing.Size(821, 406);
            this.treeListPermission.StateImageList = this.imageList1;
            this.treeListPermission.TabIndex = 16;
            this.treeListPermission.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeListPermission_CustomDrawNodeCell);
            this.treeListPermission.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListPermission_FocusedNodeChanged);
            this.treeListPermission.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(this.treeListPermission_FocusedColumnChanged);
            this.treeListPermission.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeListPermission_GetStateImage);
            this.treeListPermission.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.treeListPermission_CellValueChanging);
            // 
            // ColEmpName
            // 
            this.ColEmpName.Caption = "Nhân viên";
            this.ColEmpName.FieldName = "Nhân viên";
            this.ColEmpName.MinWidth = 23;
            this.ColEmpName.Name = "ColEmpName";
            this.ColEmpName.OptionsColumn.AllowEdit = false;
            this.ColEmpName.OptionsColumn.AllowFocus = false;
            this.ColEmpName.OptionsColumn.AllowMove = false;
            this.ColEmpName.OptionsColumn.AllowSort = false;
            this.ColEmpName.OptionsColumn.ReadOnly = true;
            this.ColEmpName.Visible = true;
            this.ColEmpName.VisibleIndex = 0;
            this.ColEmpName.Width = 146;
            // 
            // ColFullPermission
            // 
            this.ColFullPermission.Caption = "Toàn quyền";
            this.ColFullPermission.FieldName = "Toàn quyền";
            this.ColFullPermission.Name = "ColFullPermission";
            this.ColFullPermission.OptionsColumn.AllowSort = false;
            this.ColFullPermission.Visible = true;
            this.ColFullPermission.VisibleIndex = 1;
            this.ColFullPermission.Width = 133;
            // 
            // ColIsRead
            // 
            this.ColIsRead.Caption = "Được quyền xem";
            this.ColIsRead.FieldName = "Được quyền xem";
            this.ColIsRead.Name = "ColIsRead";
            this.ColIsRead.OptionsColumn.AllowSort = false;
            this.ColIsRead.Visible = true;
            this.ColIsRead.VisibleIndex = 3;
            this.ColIsRead.Width = 131;
            // 
            // ColIsUpdate
            // 
            this.ColIsUpdate.Caption = "Được quyền sửa";
            this.ColIsUpdate.FieldName = "Được quyền sửa";
            this.ColIsUpdate.Name = "ColIsUpdate";
            this.ColIsUpdate.OptionsColumn.AllowSort = false;
            this.ColIsUpdate.Visible = true;
            this.ColIsUpdate.VisibleIndex = 4;
            this.ColIsUpdate.Width = 131;
            // 
            // ColIsDelete
            // 
            this.ColIsDelete.Caption = "Được quyền xóa";
            this.ColIsDelete.FieldName = "Được quyền xóa";
            this.ColIsDelete.Name = "ColIsDelete";
            this.ColIsDelete.OptionsColumn.AllowSort = false;
            this.ColIsDelete.Visible = true;
            this.ColIsDelete.VisibleIndex = 5;
            this.ColIsDelete.Width = 131;
            // 
            // ColID
            // 
            this.ColID.Caption = "ID";
            this.ColID.FieldName = "id";
            this.ColID.Name = "ColID";
            this.ColID.OptionsColumn.AllowEdit = false;
            this.ColID.OptionsColumn.AllowFocus = false;
            this.ColID.OptionsColumn.ReadOnly = true;
            this.ColID.OptionsColumn.ShowInCustomizationForm = false;
            this.ColID.Width = 133;
            // 
            // ColIsDepartment
            // 
            this.ColIsDepartment.Caption = "Is Department";
            this.ColIsDepartment.FieldName = "Is Department";
            this.ColIsDepartment.Name = "ColIsDepartment";
            this.ColIsDepartment.OptionsColumn.AllowEdit = false;
            this.ColIsDepartment.OptionsColumn.AllowFocus = false;
            this.ColIsDepartment.OptionsColumn.ReadOnly = true;
            this.ColIsDepartment.OptionsColumn.ShowInCustomizationForm = false;
            this.ColIsDepartment.Width = 84;
            // 
            // ColIsCreate
            // 
            this.ColIsCreate.Caption = "Được quyền thêm";
            this.ColIsCreate.FieldName = "treeListColumn1";
            this.ColIsCreate.Name = "ColIsCreate";
            this.ColIsCreate.Visible = true;
            this.ColIsCreate.VisibleIndex = 2;
            this.ColIsCreate.Width = 128;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "navViTriHang.png");
            this.imageList1.Images.SetKeyName(1, "mnbKhachHang.png");
            this.imageList1.Images.SetKeyName(2, "DM_KhachHang.png");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(542, 480);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(291, 28);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(213, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đó&ng";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(132, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPermissionDataPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 510);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.treeListPermission);
            this.Controls.Add(this.lblResourceGroup);
            this.Controls.Add(this.lblCreatedDate);
            this.Controls.Add(this.lblResource);
            this.Controls.Add(this.lblCaptionResourceGroup);
            this.Controls.Add(this.lblCreater);
            this.Controls.Add(this.lblCaptionResource);
            this.Controls.Add(this.lblCaptionCreatedDate);
            this.Controls.Add(this.lblCaptionCreater);
            this.Name = "frmPermissionDataPopUp";
            this.Text = "frmPermissionEmployeeResource";
            ((System.ComponentModel.ISupportInitialize)(this.treeListPermission)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblCreatedDate;
        private DevExpress.XtraEditors.LabelControl lblCreater;
        private System.Windows.Forms.PLLabel lblCaptionCreatedDate;
        private System.Windows.Forms.PLLabel lblCaptionCreater;
        private System.Windows.Forms.PLLabel lblCaptionResource;
        private System.Windows.Forms.PLLabel lblCaptionResourceGroup;
        private DevExpress.XtraEditors.LabelControl lblResource;
        private DevExpress.XtraEditors.LabelControl lblResourceGroup;
        private DevExpress.XtraTreeList.PLTreeList treeListPermission;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColEmpName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColFullPermission;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColIsRead;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColIsUpdate;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColIsDelete;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColIsDepartment;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColIsCreate;
    }
}