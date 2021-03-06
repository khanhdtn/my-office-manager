namespace PermissionOfResource
{
    partial class frmPermissionDataQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissionDataQL));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblMessage = new DevExpress.XtraEditors.LabelControl();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeListPermission = new DevExpress.XtraTreeList.PLTreeList();
            this.ColEmpName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsDepartment = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.xtraTabControlPermission = new DevExpress.XtraTab.XtraTabControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlPermission)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblMessage);
            this.panelControl1.Controls.Add(this.btnDong);
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 514);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(923, 36);
            this.panelControl1.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.lblMessage.Appearance.Options.UseForeColor = true;
            this.lblMessage.Location = new System.Drawing.Point(5, 12);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(42, 13);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "Message";
            this.lblMessage.TextChanged += new System.EventHandler(this.lblMessage_TextChanged);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(843, 3);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 27);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.ToolTip = "Đóng màn hình phân quyền nhân viên đối tác";
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(762, 3);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 27);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.ToolTip = "Lưu phân quyền đang chọn";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeListPermission);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControlPermission);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(923, 514);
            this.splitContainerControl1.SplitterPosition = 213;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // treeListPermission
            // 
            this.treeListPermission.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeListPermission.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListPermission.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColEmpName,
            this.ColID,
            this.ColIsDepartment});
            this.treeListPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListPermission.Location = new System.Drawing.Point(0, 0);
            this.treeListPermission.Name = "treeListPermission";
            this.treeListPermission.OptionsBehavior.AutoFocusNewNode = true;
            this.treeListPermission.OptionsView.EnableAppearanceEvenRow = true;
            this.treeListPermission.OptionsView.EnableAppearanceOddRow = true;
            this.treeListPermission.OptionsView.ShowIndicator = false;
            this.treeListPermission.Size = new System.Drawing.Size(213, 514);
            this.treeListPermission.StateImageList = this.imageList1;
            this.treeListPermission.TabIndex = 17;
            this.treeListPermission.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeListPermission_FocusedNodeChanged);
            this.treeListPermission.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeListPermission_GetStateImage);
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
            this.ColEmpName.Width = 144;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "navViTriHang.png");
            this.imageList1.Images.SetKeyName(1, "mnbKhachHang.png");
            this.imageList1.Images.SetKeyName(2, "DM_KhachHang.png");
            // 
            // xtraTabControlPermission
            // 
            this.xtraTabControlPermission.AllowDrop = true;
            this.xtraTabControlPermission.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.xtraTabControlPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlPermission.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControlPermission.Name = "xtraTabControlPermission";
            this.xtraTabControlPermission.Size = new System.Drawing.Size(704, 514);
            this.xtraTabControlPermission.TabIndex = 4;
            this.xtraTabControlPermission.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControlPermission_SelectedPageChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.splitContainerControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(923, 514);
            this.panelControl2.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmPermissionDataQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 550);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmPermissionDataQL";
            this.Text = "Phân quyền dữ liệu";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlPermission)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.LabelControl lblMessage;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraTreeList.PLTreeList treeListPermission;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColEmpName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColIsDepartment;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlPermission;
        private System.Windows.Forms.ImageList imageList1;

    }
}