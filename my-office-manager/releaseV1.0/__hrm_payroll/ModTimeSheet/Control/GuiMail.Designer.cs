namespace office
{
    partial class GuiMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuiMail));
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.gridControlNguoiTheoDoi = new DevExpress.XtraGrid.GridControl();
            this.gridViewNguoiTheoDoi = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colPhongBan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNguoiTheoDoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNguoiTheoDoi)).BeginInit();
            this.SuspendLayout();
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupContainerEdit1.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.CloseOnOuterMouseClick = false;
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Size = new System.Drawing.Size(209, 20);
            this.popupContainerEdit1.TabIndex = 1;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.gridControlNguoiTheoDoi);
            this.popupContainerControl1.Location = new System.Drawing.Point(3, 26);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(444, 202);
            this.popupContainerControl1.TabIndex = 2;
            // 
            // gridControlNguoiTheoDoi
            // 
            this.gridControlNguoiTheoDoi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlNguoiTheoDoi.BackgroundImage")));
            this.gridControlNguoiTheoDoi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlNguoiTheoDoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNguoiTheoDoi.Location = new System.Drawing.Point(0, 0);
            this.gridControlNguoiTheoDoi.MainView = this.gridViewNguoiTheoDoi;
            this.gridControlNguoiTheoDoi.Name = "gridControlNguoiTheoDoi";
            this.gridControlNguoiTheoDoi.Size = new System.Drawing.Size(444, 202);
            this.gridControlNguoiTheoDoi.TabIndex = 156;
            this.gridControlNguoiTheoDoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNguoiTheoDoi});
            // 
            // gridViewNguoiTheoDoi
            // 
            this.gridViewNguoiTheoDoi.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewNguoiTheoDoi.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewNguoiTheoDoi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPhongBan,
            this.colHoTen,
            this.colEmail,
            this.colChon});
            this.gridViewNguoiTheoDoi.GridControl = this.gridControlNguoiTheoDoi;
            this.gridViewNguoiTheoDoi.GroupCount = 1;
            this.gridViewNguoiTheoDoi.IndicatorWidth = 40;
            this.gridViewNguoiTheoDoi.Name = "gridViewNguoiTheoDoi";
            this.gridViewNguoiTheoDoi.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewNguoiTheoDoi.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewNguoiTheoDoi.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewNguoiTheoDoi.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewNguoiTheoDoi.OptionsPrint.UsePrintStyles = true;
            this.gridViewNguoiTheoDoi.OptionsSelection.MultiSelect = true;
            this.gridViewNguoiTheoDoi.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridViewNguoiTheoDoi.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewNguoiTheoDoi.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewNguoiTheoDoi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewNguoiTheoDoi.OptionsView.ShowGroupedColumns = true;
            this.gridViewNguoiTheoDoi.OptionsView.ShowGroupPanel = false;
            this.gridViewNguoiTheoDoi.OptionsView.ShowIndicator = false;
            this.gridViewNguoiTheoDoi.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPhongBan, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colPhongBan
            // 
            this.colPhongBan.Caption = "Phòng ban";
            this.colPhongBan.Name = "colPhongBan";
            this.colPhongBan.Width = 76;
            // 
            // colHoTen
            // 
            this.colHoTen.Caption = "Họ tên";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.OptionsColumn.AllowEdit = false;
            this.colHoTen.Visible = true;
            this.colHoTen.VisibleIndex = 0;
            this.colHoTen.Width = 44;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 1;
            this.colEmail.Width = 36;
            // 
            // colChon
            // 
            this.colChon.Caption = "Chọn";
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 2;
            this.colChon.Width = 37;
            // 
            // GuiMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popupContainerEdit1);
            this.Name = "GuiMail";
            this.Size = new System.Drawing.Size(209, 24);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNguoiTheoDoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNguoiTheoDoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        public DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewNguoiTheoDoi;
        private DevExpress.XtraGrid.Columns.GridColumn colPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn colHoTen;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
        public DevExpress.XtraGrid.GridControl gridControlNguoiTheoDoi;
    }
}
