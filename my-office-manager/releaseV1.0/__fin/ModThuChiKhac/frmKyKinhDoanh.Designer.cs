namespace office
{
    partial class frmKyKinhDoanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKyKinhDoanh));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.ColTuNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDenNgay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDuDauKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColPhatSinhTang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColPhatSinhGiam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColDuCuoiKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ColKetChuyen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_GioPhongVan = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_GioPhongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(116, 9);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Đóng";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(35, 9);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Thực hiện";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(641, 379);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(84, 23);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đón&g";
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMaster.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlMaster.BackgroundImage")));
            this.gridControlMaster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlMaster.Location = new System.Drawing.Point(0, 0);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_GioPhongVan});
            this.gridControlMaster.Size = new System.Drawing.Size(729, 374);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewMaster.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColTuNgay,
            this.ColDenNgay,
            this.ColDuDauKy,
            this.ColPhatSinhTang,
            this.ColPhatSinhGiam,
            this.ColDuCuoiKy,
            this.ColKetChuyen});
            this.gridViewMaster.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupPanelText = "Thông tin kỳ kinh doanh";
            this.gridViewMaster.IndicatorWidth = 40;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsBehavior.Editable = false;
            this.gridViewMaster.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewMaster.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewMaster.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewMaster.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewMaster.OptionsSelection.MultiSelect = true;
            this.gridViewMaster.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewMaster.OptionsView.ColumnAutoWidth = true;
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gridViewMaster.OptionsView.RowAutoHeight = true;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = true;
            // 
            // ColTuNgay
            // 
            this.ColTuNgay.Caption = "Từ ngày";
            this.ColTuNgay.Name = "ColTuNgay";
            this.ColTuNgay.OptionsColumn.ReadOnly = true;
            this.ColTuNgay.Visible = true;
            this.ColTuNgay.VisibleIndex = 0;
            this.ColTuNgay.Width = 52;
            // 
            // ColDenNgay
            // 
            this.ColDenNgay.Caption = "Đến ngày";
            this.ColDenNgay.Name = "ColDenNgay";
            this.ColDenNgay.OptionsColumn.AllowEdit = false;
            this.ColDenNgay.OptionsColumn.AllowFocus = false;
            this.ColDenNgay.OptionsColumn.ReadOnly = true;
            this.ColDenNgay.Visible = true;
            this.ColDenNgay.VisibleIndex = 1;
            this.ColDenNgay.Width = 59;
            // 
            // ColDuDauKy
            // 
            this.ColDuDauKy.Caption = "Số dư đầu kỳ (VNĐ)";
            this.ColDuDauKy.Name = "ColDuDauKy";
            this.ColDuDauKy.OptionsColumn.AllowEdit = false;
            this.ColDuDauKy.OptionsColumn.AllowFocus = false;
            this.ColDuDauKy.OptionsColumn.ReadOnly = true;
            this.ColDuDauKy.Visible = true;
            this.ColDuDauKy.VisibleIndex = 2;
            // 
            // ColPhatSinhTang
            // 
            this.ColPhatSinhTang.Caption = "Phát sinh tăng (VNĐ)";
            this.ColPhatSinhTang.Name = "ColPhatSinhTang";
            this.ColPhatSinhTang.OptionsColumn.ReadOnly = true;
            this.ColPhatSinhTang.Visible = true;
            this.ColPhatSinhTang.VisibleIndex = 3;
            this.ColPhatSinhTang.Width = 81;
            // 
            // ColPhatSinhGiam
            // 
            this.ColPhatSinhGiam.Caption = "Phát sinh giảm (VNĐ)";
            this.ColPhatSinhGiam.Name = "ColPhatSinhGiam";
            this.ColPhatSinhGiam.OptionsColumn.ReadOnly = true;
            this.ColPhatSinhGiam.Visible = true;
            this.ColPhatSinhGiam.VisibleIndex = 4;
            this.ColPhatSinhGiam.Width = 81;
            // 
            // ColDuCuoiKy
            // 
            this.ColDuCuoiKy.Caption = "Số dư cuối kỳ (VNĐ)";
            this.ColDuCuoiKy.Name = "ColDuCuoiKy";
            this.ColDuCuoiKy.OptionsColumn.ReadOnly = true;
            this.ColDuCuoiKy.Visible = true;
            this.ColDuCuoiKy.VisibleIndex = 5;
            this.ColDuCuoiKy.Width = 76;
            // 
            // ColKetChuyen
            // 
            this.ColKetChuyen.Caption = "Đã kết chuyển";
            this.ColKetChuyen.Name = "ColKetChuyen";
            this.ColKetChuyen.OptionsColumn.ReadOnly = true;
            this.ColKetChuyen.Visible = true;
            this.ColKetChuyen.VisibleIndex = 6;
            this.ColKetChuyen.Width = 82;
            // 
            // rep_GioPhongVan
            // 
            this.rep_GioPhongVan.AutoHeight = false;
            this.rep_GioPhongVan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rep_GioPhongVan.Mask.EditMask = "";
            this.rep_GioPhongVan.Name = "rep_GioPhongVan";
            // 
            // frmKyKinhDoanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 406);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.gridControlMaster);
            this.Name = "frmKyKinhDoanh";
            this.Text = "Kỳ kinh doanh";
            this.Load += new System.EventHandler(this.frmKyKinhDoanh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_GioPhongVan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.GridControl gridControlMaster;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        private DevExpress.XtraGrid.Columns.GridColumn ColTuNgay;
        private DevExpress.XtraGrid.Columns.GridColumn ColDenNgay;
        private DevExpress.XtraGrid.Columns.GridColumn ColDuDauKy;
        private DevExpress.XtraGrid.Columns.GridColumn ColPhatSinhTang;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit rep_GioPhongVan;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraGrid.Columns.GridColumn ColPhatSinhGiam;
        private DevExpress.XtraGrid.Columns.GridColumn ColKetChuyen;
        private DevExpress.XtraGrid.Columns.GridColumn ColDuCuoiKy;





    }
}