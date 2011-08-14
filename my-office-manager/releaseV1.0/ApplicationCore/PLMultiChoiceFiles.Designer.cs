namespace office
{
    partial class PLMultiChoiceFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PLMultiChoiceFiles));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.gridControlListFiles = new DevExpress.XtraGrid.GridControl();
            this.gridViewListFiles = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.ColFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repImageFax = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlListFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewListFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImageFax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.gridControlListFiles);
            this.popupContainerControl1.Location = new System.Drawing.Point(3, 26);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(459, 261);
            this.popupContainerControl1.TabIndex = 1;
            // 
            // gridControlListFiles
            // 
            this.gridControlListFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlListFiles.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlListFiles.BackgroundImage")));
            this.gridControlListFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlListFiles.Location = new System.Drawing.Point(0, 0);
            this.gridControlListFiles.MainView = this.gridViewListFiles;
            this.gridControlListFiles.Name = "gridControlListFiles";
            this.gridControlListFiles.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repImageFax});
            this.gridControlListFiles.Size = new System.Drawing.Size(459, 258);
            this.gridControlListFiles.TabIndex = 0;
            this.gridControlListFiles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewListFiles});
            // 
            // gridViewListFiles
            // 
            this.gridViewListFiles.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewListFiles.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewListFiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColFax,
            this.ColFileName,
            this.ID});
            this.gridViewListFiles.GridControl = this.gridControlListFiles;
            this.gridViewListFiles.IndicatorWidth = 40;
            this.gridViewListFiles.Name = "gridViewListFiles";
            this.gridViewListFiles.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewListFiles.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewListFiles.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewListFiles.OptionsPrint.UsePrintStyles = true;
            this.gridViewListFiles.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewListFiles.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewListFiles.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewListFiles.OptionsView.ShowGroupedColumns = true;
            this.gridViewListFiles.OptionsView.ShowGroupPanel = false;
            // 
            // ColFileName
            // 
            this.ColFileName.Caption = "Tên tập tin";
            this.ColFileName.Name = "ColFileName";
            this.ColFileName.Visible = true;
            this.ColFileName.VisibleIndex = 0;
            this.ColFileName.Width = 64;
            // 
            // ColFax
            // 
            this.ColFax.Caption = "Fax";
            this.ColFax.ColumnEdit = this.repImageFax;
            this.ColFax.FieldName = "IMAGE";
            this.ColFax.Name = "ColFax";
            this.ColFax.Width = 30;
            // 
            // repImageFax
            // 
            this.repImageFax.Name = "repImageFax";
            // 
            // ID
            // 
            this.ID.Name = "ID";
            this.ID.Width = 28;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.popupContainerEdit1.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, false, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "ADD_FILE", null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", "SHOW_POPUP", null, true)});
            this.popupContainerEdit1.Properties.CloseOnLostFocus = false;
            this.popupContainerEdit1.Properties.CloseOnOuterMouseClick = false;
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.popupContainerEdit1.Size = new System.Drawing.Size(459, 20);
            this.popupContainerEdit1.TabIndex = 0;
            this.popupContainerEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.popupContainerEdit1_ButtonClick);
            // 
            // PLMultiChoiceFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerEdit1);
            this.Controls.Add(this.popupContainerControl1);
            this.Name = "PLMultiChoiceFiles";
            this.Size = new System.Drawing.Size(462, 20);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlListFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewListFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repImageFax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion



        public DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraGrid.GridControl gridControlListFiles;
        public DevExpress.XtraGrid.Columns.GridColumn ColFileName;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        public DevExpress.XtraGrid.Columns.GridColumn ColFax;
        public DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repImageFax;
        public DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewListFiles;
    }
}
