namespace pl.office.form
{
    partial class frmLoaiCongViec
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
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cotLCVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotMALCV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cotNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.retxtNAME = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.cotMO_TA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repchkHienThi = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Error = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.btnKhongLuu = new DevExpress.XtraEditors.SimpleButton();
            this.panel_Center = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.retxtNAME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchkHienThi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.panel_Center.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.Location = new System.Drawing.Point(520, 9);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(64, 23);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(660, 9);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(64, 23);
            this.btnDong.TabIndex = 14;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView2;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.retxtNAME,
            this.repositoryItemCheckEdit1,
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit1,
            this.repchkHienThi,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(727, 314);
            this.gridControl1.TabIndex = 47;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cotLCVID,
            this.cotMALCV,
            this.cotNAME,
            this.cotMO_TA,
            this.gridColumn5});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView2.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanging);
            this.gridView2.RowCountChanged += new System.EventHandler(this.gridView2_RowCountChanged);
            this.gridView2.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView2_ValidateRow);
            // 
            // cotLCVID
            // 
            this.cotLCVID.Caption = "Loại công việc ID";
            this.cotLCVID.FieldName = "LCV_ID";
            this.cotLCVID.Name = "cotLCVID";
            this.cotLCVID.OptionsColumn.AllowEdit = false;
            this.cotLCVID.Visible = true;
            this.cotLCVID.VisibleIndex = 0;
            // 
            // cotMALCV
            // 
            this.cotMALCV.Caption = "Mã loại công việc";
            this.cotMALCV.ColumnEdit = this.repositoryItemTextEdit1;
            this.cotMALCV.FieldName = "MA_LCV";
            this.cotMALCV.Name = "cotMALCV";
            this.cotMALCV.OptionsColumn.AllowEdit = false;
            this.cotMALCV.Visible = true;
            this.cotMALCV.VisibleIndex = 1;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // cotNAME
            // 
            this.cotNAME.Caption = "Tên loại công việc";
            this.cotNAME.ColumnEdit = this.retxtNAME;
            this.cotNAME.FieldName = "NAME";
            this.cotNAME.Name = "cotNAME";
            this.cotNAME.Visible = true;
            this.cotNAME.VisibleIndex = 2;
            // 
            // retxtNAME
            // 
            this.retxtNAME.AutoHeight = false;
            this.retxtNAME.Name = "retxtNAME";
            // 
            // cotMO_TA
            // 
            this.cotMO_TA.Caption = "Mô tả";
            this.cotMO_TA.FieldName = "MO_TA";
            this.cotMO_TA.Name = "cotMO_TA";
            this.cotMO_TA.Visible = true;
            this.cotMO_TA.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Hiển thị";
            this.gridColumn5.ColumnEdit = this.repchkHienThi;
            this.gridColumn5.FieldName = "VISIBLE_BIT";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // repchkHienThi
            // 
            this.repchkHienThi.AutoHeight = false;
            this.repchkHienThi.Name = "repchkHienThi";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // Error
            // 
            this.Error.ContainerControl = this;
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.btnKhongLuu);
            this.panel_Bottom.Controls.Add(this.btnDong);
            this.panel_Bottom.Controls.Add(this.btnLuu);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 314);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(727, 39);
            this.panel_Bottom.TabIndex = 48;
            // 
            // btnKhongLuu
            // 
            this.btnKhongLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKhongLuu.Location = new System.Drawing.Point(590, 9);
            this.btnKhongLuu.Name = "btnKhongLuu";
            this.btnKhongLuu.Size = new System.Drawing.Size(64, 23);
            this.btnKhongLuu.TabIndex = 15;
            this.btnKhongLuu.Text = "Không lưu";
            this.btnKhongLuu.Click += new System.EventHandler(this.btnKhongLuu_Click);
            // 
            // panel_Center
            // 
            this.panel_Center.Controls.Add(this.gridControl1);
            this.panel_Center.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Center.Location = new System.Drawing.Point(0, 0);
            this.panel_Center.Name = "panel_Center";
            this.panel_Center.Size = new System.Drawing.Size(727, 314);
            this.panel_Center.TabIndex = 49;
            // 
            // frmLoaiCongViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 353);
            this.Controls.Add(this.panel_Center);
            this.Controls.Add(this.panel_Bottom);
            this.Name = "frmLoaiCongViec";
            this.Text = "frmLoaiCongViec";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.retxtNAME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repchkHienThi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Center.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn cotLCVID;
        private DevExpress.XtraGrid.Columns.GridColumn cotMALCV;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn cotNAME;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit retxtNAME;
        private DevExpress.XtraGrid.Columns.GridColumn cotMO_TA;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repchkHienThi;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Error;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Panel panel_Center;
        private DevExpress.XtraEditors.SimpleButton btnKhongLuu;
    }
}