namespace office
{
    partial class CustomerTree
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
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeListNhomKH = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumnNhomKH = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumnSelect = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCheckEdit = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListNhomKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colCheckEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupContainerEdit1.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(254, 20);
            this.popupContainerEdit1.TabIndex = 0;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.treeListNhomKH);
            this.popupContainerControl1.Location = new System.Drawing.Point(3, 29);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(368, 224);
            this.popupContainerControl1.TabIndex = 1;
            // 
            // treeListNhomKH
            // 
            this.treeListNhomKH.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumnNhomKH,
            this.treeListColumnID,
            this.treeListColumnSelect});
            this.treeListNhomKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListNhomKH.Location = new System.Drawing.Point(0, 0);
            this.treeListNhomKH.Name = "treeListNhomKH";
            this.treeListNhomKH.OptionsView.ShowHorzLines = false;
            this.treeListNhomKH.OptionsView.ShowIndicator = false;
            this.treeListNhomKH.OptionsView.ShowVertLines = false;
            this.treeListNhomKH.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.colCheckEdit});
            this.treeListNhomKH.Size = new System.Drawing.Size(368, 224);
            this.treeListNhomKH.TabIndex = 0;
            // 
            // treeListColumnNhomKH
            // 
            this.treeListColumnNhomKH.Caption = "Tên nhóm";
            this.treeListColumnNhomKH.FieldName = "NAME";
            this.treeListColumnNhomKH.MinWidth = 270;
            this.treeListColumnNhomKH.Name = "treeListColumnNhomKH";
            this.treeListColumnNhomKH.OptionsColumn.AllowEdit = false;
            this.treeListColumnNhomKH.OptionsColumn.ReadOnly = true;
            this.treeListColumnNhomKH.Visible = true;
            this.treeListColumnNhomKH.VisibleIndex = 0;
            this.treeListColumnNhomKH.Width = 270;
            // 
            // treeListColumnID
            // 
            this.treeListColumnID.Caption = "ID";
            this.treeListColumnID.FieldName = "ID";
            this.treeListColumnID.Name = "treeListColumnID";
            this.treeListColumnID.Width = 68;
            // 
            // treeListColumnSelect
            // 
            this.treeListColumnSelect.Caption = ".";
            this.treeListColumnSelect.ColumnEdit = this.colCheckEdit;
            this.treeListColumnSelect.FieldName = "IS_CHON";
            this.treeListColumnSelect.Name = "treeListColumnSelect";
            this.treeListColumnSelect.Visible = true;
            this.treeListColumnSelect.VisibleIndex = 1;
            this.treeListColumnSelect.Width = 68;
            // 
            // colCheckEdit
            // 
            this.colCheckEdit.AutoHeight = false;
            this.colCheckEdit.Name = "colCheckEdit";
            // 
            // CustomerTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popupContainerEdit1);
            this.Name = "CustomerTree";
            this.Size = new System.Drawing.Size(254, 25);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListNhomKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colCheckEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraTreeList.TreeList treeListNhomKH;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnNhomKH;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit colCheckEdit;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumnID;
    }
}
