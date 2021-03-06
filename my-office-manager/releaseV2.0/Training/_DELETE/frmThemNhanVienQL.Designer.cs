namespace pl.office.form
{
    partial class frmThemNhanVienQL
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
            this.Cot_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_HoTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cot_Chon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_GioPhongVan = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.btn_DongY = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Dong = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_GioPhongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.EmbeddedNavigator.Name = "";
            this.gridControlMaster.Location = new System.Drawing.Point(6, 12);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rep_GioPhongVan});
            this.gridControlMaster.Size = new System.Drawing.Size(615, 282);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Cot_ID,
            this.Cot_HoTen,
            this.Cot_Chon});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.GroupPanelText = "Danh sách nhân viên cần bổ sung";
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewMaster.OptionsView.EnableAppearanceOddRow = true;
            // 
            // Cot_ID
            // 
            this.Cot_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_ID.Caption = "ID";
            this.Cot_ID.FieldName = "ID";
            this.Cot_ID.Name = "Cot_ID";
            this.Cot_ID.OptionsColumn.AllowEdit = false;
            this.Cot_ID.OptionsColumn.AllowFocus = false;
            this.Cot_ID.OptionsColumn.ReadOnly = true;
            // 
            // Cot_HoTen
            // 
            this.Cot_HoTen.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_HoTen.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_HoTen.Caption = "Họ tên";
            this.Cot_HoTen.FieldName = "EMAIL";
            this.Cot_HoTen.Name = "Cot_HoTen";
            this.Cot_HoTen.Visible = true;
            this.Cot_HoTen.VisibleIndex = 1;
            // 
            // Cot_Chon
            // 
            this.Cot_Chon.AppearanceHeader.Options.UseTextOptions = true;
            this.Cot_Chon.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Cot_Chon.Caption = "Chọn";
            this.Cot_Chon.FieldName = "CHON";
            this.Cot_Chon.Name = "Cot_Chon";
            this.Cot_Chon.Visible = true;
            this.Cot_Chon.VisibleIndex = 2;
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
            this.btn_DongY.Location = new System.Drawing.Point(466, 305);
            this.btn_DongY.Name = "btn_DongY";
            this.btn_DongY.Size = new System.Drawing.Size(75, 23);
            this.btn_DongY.TabIndex = 1;
            this.btn_DongY.Text = "Thực hiện";
            this.btn_DongY.Click += new System.EventHandler(this.btn_DongY_Click);
            // 
            // btn_Dong
            // 
            this.btn_Dong.Location = new System.Drawing.Point(547, 305);
            this.btn_Dong.Name = "btn_Dong";
            this.btn_Dong.Size = new System.Drawing.Size(75, 23);
            this.btn_Dong.TabIndex = 2;
            this.btn_Dong.Text = "Đóng";
            this.btn_Dong.Click += new System.EventHandler(this.btn_Dong_Click);
            // 
            // frmThemNhanVienQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 337);
            this.Controls.Add(this.btn_Dong);
            this.Controls.Add(this.btn_DongY);
            this.Controls.Add(this.gridControlMaster);
            this.Name = "frmThemNhanVienQL";
            this.Text = "Bổ sung thêm nhân viên";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_GioPhongVan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMaster;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_ID;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_Chon;
        private DevExpress.XtraEditors.SimpleButton btn_DongY;
        private DevExpress.XtraEditors.SimpleButton btn_Dong;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit rep_GioPhongVan;
        private DevExpress.XtraGrid.Columns.GridColumn Cot_HoTen;
    }
}