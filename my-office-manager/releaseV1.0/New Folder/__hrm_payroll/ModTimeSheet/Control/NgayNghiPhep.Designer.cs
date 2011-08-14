namespace office
{
    partial class NgayNghiPhep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NgayNghiPhep));
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.gridControlNgayNghiPhep = new DevExpress.XtraGrid.GridControl();
            this.gridViewNgayNghiPhep = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.colSang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNghiPhep = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repXoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNgayNghiPhep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNgayNghiPhep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repXoa)).BeginInit();
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
            this.popupContainerEdit1.Size = new System.Drawing.Size(193, 20);
            this.popupContainerEdit1.TabIndex = 1;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.gridControlNgayNghiPhep);
            this.popupContainerControl1.Location = new System.Drawing.Point(3, 26);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(364, 159);
            this.popupContainerControl1.TabIndex = 2;
            // 
            // gridControlNgayNghiPhep
            // 
            this.gridControlNgayNghiPhep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlNgayNghiPhep.BackgroundImage")));
            this.gridControlNgayNghiPhep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlNgayNghiPhep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlNgayNghiPhep.Location = new System.Drawing.Point(0, 0);
            this.gridControlNgayNghiPhep.MainView = this.gridViewNgayNghiPhep;
            this.gridControlNgayNghiPhep.Name = "gridControlNgayNghiPhep";
            this.gridControlNgayNghiPhep.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repXoa});
            this.gridControlNgayNghiPhep.Size = new System.Drawing.Size(364, 159);
            this.gridControlNgayNghiPhep.TabIndex = 0;
            this.gridControlNgayNghiPhep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNgayNghiPhep});
            // 
            // gridViewNgayNghiPhep
            // 
            this.gridViewNgayNghiPhep.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewNgayNghiPhep.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewNgayNghiPhep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSang,
            this.colChieu,
            this.colNgayNghiPhep,
            this.colXoa});
            this.gridViewNgayNghiPhep.GridControl = this.gridControlNgayNghiPhep;
            this.gridViewNgayNghiPhep.IndicatorWidth = 40;
            this.gridViewNgayNghiPhep.Name = "gridViewNgayNghiPhep";
            this.gridViewNgayNghiPhep.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewNgayNghiPhep.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewNgayNghiPhep.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewNgayNghiPhep.OptionsPrint.UsePrintStyles = true;
            this.gridViewNgayNghiPhep.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewNgayNghiPhep.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewNgayNghiPhep.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewNgayNghiPhep.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewNgayNghiPhep.OptionsView.ShowFooter = true;
            this.gridViewNgayNghiPhep.OptionsView.ShowGroupedColumns = true;
            this.gridViewNgayNghiPhep.OptionsView.ShowGroupPanel = false;
            // 
            // colSang
            // 
            this.colSang.Caption = "Sáng";
            this.colSang.MaxWidth = 54;
            this.colSang.Name = "colSang";
            this.colSang.Visible = true;
            this.colSang.VisibleIndex = 0;
            this.colSang.Width = 36;
            // 
            // colChieu
            // 
            this.colChieu.Caption = "Chiều";
            this.colChieu.MaxWidth = 54;
            this.colChieu.Name = "colChieu";
            this.colChieu.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colChieu.Visible = true;
            this.colChieu.VisibleIndex = 1;
            this.colChieu.Width = 39;
            // 
            // colNgayNghiPhep
            // 
            this.colNgayNghiPhep.Caption = "Ngày";
            this.colNgayNghiPhep.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.colNgayNghiPhep.Name = "colNgayNghiPhep";
            this.colNgayNghiPhep.Visible = true;
            this.colNgayNghiPhep.VisibleIndex = 2;
            this.colNgayNghiPhep.Width = 37;
            // 
            // colXoa
            // 
            this.colXoa.ColumnEdit = this.repXoa;
            this.colXoa.MaxWidth = 25;
            this.colXoa.MinWidth = 25;
            this.colXoa.Name = "colXoa";
            this.colXoa.Visible = true;
            this.colXoa.VisibleIndex = 3;
            this.colXoa.Width = 25;
            // 
            // repXoa
            // 
            this.repXoa.AutoHeight = false;
            this.repXoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repXoa.Name = "repXoa";
            this.repXoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repXoa.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repXoa_ButtonClick);
            // 
            // NgayNghiPhep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popupContainerEdit1);
            this.Name = "NgayNghiPhep";
            this.Size = new System.Drawing.Size(193, 22);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNgayNghiPhep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNgayNghiPhep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repXoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colChieu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNghiPhep;
        private DevExpress.XtraGrid.Columns.GridColumn colSang;
        public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewNgayNghiPhep;
        public DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        public DevExpress.XtraGrid.GridControl gridControlNgayNghiPhep;
        private DevExpress.XtraGrid.Columns.GridColumn colXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repXoa;
    }
}
