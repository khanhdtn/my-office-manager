namespace ProtocolVN.App.Office.ApplicationCore
{
    partial class PLDMTreeMultiChoice
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLDMTreeMultiChoice));
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.treeList = new DevExpress.XtraTreeList.PLTreeList();
            this.ColID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ColIsDepartment = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.popupContainerEdit1.Properties.ShowPopupCloseButton = false;
            this.popupContainerEdit1.Size = new System.Drawing.Size(367, 20);
            this.popupContainerEdit1.TabIndex = 0;
            this.popupContainerEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.popupContainerEdit1_CloseUp);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.popupContainerControl1.AutoSize = true;
            this.popupContainerControl1.Controls.Add(this.treeList);
            this.popupContainerControl1.Controls.Add(this.flowLayoutPanel1);
            this.popupContainerControl1.Location = new System.Drawing.Point(3, 26);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(361, 331);
            this.popupContainerControl1.TabIndex = 1;
            // 
            // treeList
            // 
            this.treeList.Appearance.FocusedRow.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.treeList.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.White;
            this.treeList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.treeList.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ColID,
            this.ColIsDepartment});
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.AutoFocusNewNode = true;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList.OptionsView.EnableAppearanceOddRow = true;
            this.treeList.OptionsView.ShowCheckBoxes = true;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.Size = new System.Drawing.Size(361, 295);
            this.treeList.StateImageList = this.imageCollection1;
            this.treeList.TabIndex = 21;
            this.treeList.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList_BeforeCheckNode);
            this.treeList.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList_GetStateImage);
            this.treeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterCheckNode);
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
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(20, 20);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnOK);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 295);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(361, 36);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(309, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đó&ng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(253, 8);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(50, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Đồn&g ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PLDMTreeMultiChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popupContainerEdit1);
            this.Name = "PLDMTreeMultiChoice";
            this.Size = new System.Drawing.Size(367, 20);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.Columns.TreeListColumn ColID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ColIsDepartment;
        public DevExpress.XtraTreeList.PLTreeList treeList;
        public DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.Utils.ImageCollection imageCollection1;
        public DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
    }
}
