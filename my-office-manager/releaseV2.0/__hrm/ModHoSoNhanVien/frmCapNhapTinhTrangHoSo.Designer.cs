namespace pl.office.form
{
    partial class frmCapNhatTinhTrangHoSo
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
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CotHoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTinhTrangHS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_GioPhongVan = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btn_DongY = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Dong = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.plFormTitle1 = new ProtocolVN.Framework.Win.PLFormTitle();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_GioPhongVan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMaster.Location = new System.Drawing.Point(6, 39);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_GioPhongVan});
            this.gridControlMaster.Size = new System.Drawing.Size(615, 255);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CotHoTen,
            this.CotTinhTrangHS});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupPanelText = "Danh sách ứng viên cập nhật tình trạng hồ sơ";
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            // 
            // CotHoTen
            // 
            this.CotHoTen.AppearanceHeader.Options.UseTextOptions = true;
            this.CotHoTen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotHoTen.Caption = "Họ tên";
            this.CotHoTen.Name = "CotHoTen";
            this.CotHoTen.OptionsColumn.AllowEdit = false;
            this.CotHoTen.OptionsColumn.AllowFocus = false;
            this.CotHoTen.OptionsColumn.ReadOnly = true;
            this.CotHoTen.Visible = true;
            this.CotHoTen.VisibleIndex = 0;
            // 
            // CotTinhTrangHS
            // 
            this.CotTinhTrangHS.AppearanceHeader.Options.UseTextOptions = true;
            this.CotTinhTrangHS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CotTinhTrangHS.Caption = "Tình trạng hồ sơ";
            this.CotTinhTrangHS.FieldName = "TTHS_ID";
            this.CotTinhTrangHS.Name = "CotTinhTrangHS";
            this.CotTinhTrangHS.Visible = true;
            this.CotTinhTrangHS.VisibleIndex = 1;
            // 
            // rep_GioPhongVan
            // 
            this.rep_GioPhongVan.AutoHeight = false;
            this.rep_GioPhongVan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.rep_GioPhongVan.Mask.EditMask = "";
            this.rep_GioPhongVan.Name = "rep_GioPhongVan";
            // 
            // btn_DongY
            // 
            this.btn_DongY.Location = new System.Drawing.Point(35, 9);
            this.btn_DongY.Name = "btn_DongY";
            this.btn_DongY.Size = new System.Drawing.Size(72, 23);
            this.btn_DongY.TabIndex = 1;
            this.btn_DongY.Text = "&Lưu";
            this.btn_DongY.Click += new System.EventHandler(this.btn_DongY_Click);
            // 
            // btn_Dong
            // 
            this.btn_Dong.Location = new System.Drawing.Point(116, 9);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(72, 23);
            this.btn_Dong.TabIndex = 2;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_Dong);
            this.panelControl1.Controls.Add(this.btn_DongY);
            this.panelControl1.Location = new System.Drawing.Point(421, 294);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(200, 42);
            this.panelControl1.TabIndex = 3;
            // 
            // plFormTitle1
            // 
            this.plFormTitle1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.plFormTitle1.Appearance.Options.UseFont = true;
            this.plFormTitle1.Appearance.Options.UseTextOptions = true;
            this.plFormTitle1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.plFormTitle1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.plFormTitle1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.plFormTitle1.Dock = System.Windows.Forms.DockStyle.Top;
            this.plFormTitle1.Location = new System.Drawing.Point(0, 0);
            this.plFormTitle1.Name = "plFormTitle1";
            this.plFormTitle1.Size = new System.Drawing.Size(625, 33);
            this.plFormTitle1.TabIndex = 37;
            this.plFormTitle1.Text = "CẬP NHẬT TÌNH TRẠNG HỒ SƠ";
            // 
            // frmCapNhatTinhTrangHoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 337);
            this.Controls.Add(this.plFormTitle1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControlMaster);
            this.Name = "frmCapNhatTinhTrangHoSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cập nhật tình trạng hồ sơ";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_GioPhongVan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMaster;
        private DevExpress.XtraGrid.Columns.GridColumn CotHoTen;
        private DevExpress.XtraEditors.SimpleButton btn_Dong;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit rep_GioPhongVan;
        private DevExpress.XtraGrid.Columns.GridColumn CotTinhTrangHS;
        public DevExpress.XtraEditors.SimpleButton btn_DongY;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private ProtocolVN.Framework.Win.PLFormTitle plFormTitle1;
    }
}