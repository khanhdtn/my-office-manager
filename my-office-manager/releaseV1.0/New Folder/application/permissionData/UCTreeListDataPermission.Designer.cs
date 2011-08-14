namespace PermissionOfResource
{
    partial class UCTreeListDataPermission
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
            this.TreePermission = new DevExpress.XtraTreeList.PLTreeList();
            this.ColName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColFull_Bit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsCreate_Bit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsRead_Bit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsUpdate_Bit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsDelete_Bit = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColISUseCreate = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TreePermission)).BeginInit();
            this.SuspendLayout();
            // 
            // TreePermission
            // 
            this.TreePermission.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.TreePermission.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.TreePermission.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColName,
            this.ColFull_Bit,
            this.ColIsCreate_Bit,
            this.ColIsRead_Bit,
            this.ColIsUpdate_Bit,
            this.ColIsDelete_Bit,
            this.ColISUseCreate});
            this.TreePermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreePermission.Location = new System.Drawing.Point(0, 0);
            this.TreePermission.Name = "TreePermission";
            this.TreePermission.OptionsBehavior.AutoFocusNewNode = true;
            this.TreePermission.OptionsView.EnableAppearanceEvenRow = true;
            this.TreePermission.OptionsView.EnableAppearanceOddRow = true;
            this.TreePermission.OptionsView.ShowIndicator = false;
            this.TreePermission.Size = new System.Drawing.Size(610, 424);
            this.TreePermission.TabIndex = 0;
            this.TreePermission.AfterCollapse += new DevExpress.XtraTreeList.NodeEventHandler(this.TreePermission_AfterCollapse);
            this.TreePermission.AfterExpand += new DevExpress.XtraTreeList.NodeEventHandler(this.TreePermission_AfterExpand);
            this.TreePermission.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreePermission_FocusedNodeChanged);
            this.TreePermission.FocusedColumnChanged += new DevExpress.XtraTreeList.FocusedColumnChangedEventHandler(this.TreePermission_FocusedColumnChanged);
            this.TreePermission.CellValueChanging += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.TreePermission_CellValueChanging);
            // 
            // ColName
            // 
            this.ColName.Caption = "Tên";
            this.ColName.FieldName = "Tên";
            this.ColName.Name = "ColName";
            this.ColName.OptionsColumn.AllowEdit = false;
            this.ColName.OptionsColumn.AllowFocus = false;
            this.ColName.OptionsColumn.ReadOnly = true;
            this.ColName.Visible = true;
            this.ColName.VisibleIndex = 0;
            // 
            // ColFull_Bit
            // 
            this.ColFull_Bit.Caption = "Toàn quyền";
            this.ColFull_Bit.FieldName = "Toàn quyền";
            this.ColFull_Bit.Name = "ColFull_Bit";
            this.ColFull_Bit.Visible = true;
            this.ColFull_Bit.VisibleIndex = 1;
            // 
            // ColIsCreate_Bit
            // 
            this.ColIsCreate_Bit.Caption = "Được quyền thêm";
            this.ColIsCreate_Bit.FieldName = "Được quyền thêm";
            this.ColIsCreate_Bit.Name = "ColIsCreate_Bit";
            this.ColIsCreate_Bit.Visible = true;
            this.ColIsCreate_Bit.VisibleIndex = 2;
            // 
            // ColIsRead_Bit
            // 
            this.ColIsRead_Bit.Caption = "Được quyền xem";
            this.ColIsRead_Bit.FieldName = "Được quyền xem";
            this.ColIsRead_Bit.Name = "ColIsRead_Bit";
            this.ColIsRead_Bit.Visible = true;
            this.ColIsRead_Bit.VisibleIndex = 3;
            // 
            // ColIsUpdate_Bit
            // 
            this.ColIsUpdate_Bit.Caption = "Được quyền sửa";
            this.ColIsUpdate_Bit.FieldName = "Được quyền sửa";
            this.ColIsUpdate_Bit.Name = "ColIsUpdate_Bit";
            this.ColIsUpdate_Bit.Visible = true;
            this.ColIsUpdate_Bit.VisibleIndex = 4;
            // 
            // ColIsDelete_Bit
            // 
            this.ColIsDelete_Bit.Caption = "Được quyền xóa";
            this.ColIsDelete_Bit.FieldName = "Được quyền xóa";
            this.ColIsDelete_Bit.Name = "ColIsDelete_Bit";
            this.ColIsDelete_Bit.Visible = true;
            this.ColIsDelete_Bit.VisibleIndex = 5;
            // 
            // ColISGroup
            // 
            this.ColISUseCreate.Caption = "Là nhóm";
            this.ColISUseCreate.FieldName = "Là nhóm";
            this.ColISUseCreate.Name = "ColISGroup";
            this.ColISUseCreate.OptionsColumn.AllowEdit = false;
            this.ColISUseCreate.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // UCTreeListDataPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TreePermission);
            this.Name = "UCTreeListDataPermission";
            this.Size = new System.Drawing.Size(610, 424);
            ((System.ComponentModel.ISupportInitialize)(this.TreePermission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraTreeList.PLTreeList TreePermission;
        public DevExpress.XtraTreeList.Columns.TreeListColumn ColName;
        public DevExpress.XtraTreeList.Columns.TreeListColumn ColFull_Bit;
        public DevExpress.XtraTreeList.Columns.TreeListColumn ColIsCreate_Bit;
        public DevExpress.XtraTreeList.Columns.TreeListColumn ColIsRead_Bit;
        public DevExpress.XtraTreeList.Columns.TreeListColumn ColIsUpdate_Bit;
        public DevExpress.XtraTreeList.Columns.TreeListColumn ColIsDelete_Bit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColISUseCreate;

    }
}
