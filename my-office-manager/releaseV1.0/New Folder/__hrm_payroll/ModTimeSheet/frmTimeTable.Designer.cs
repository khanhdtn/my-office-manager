namespace ProtocolVN.Plugin.TimeSheet
{
    partial class frmTimeTable
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeTable));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridViewDSCongviec = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotloai_cv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotnhanvien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotcongviec = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cotmota = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotTGTH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotDuyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CotXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rep_Xoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridDSCongviec = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.label2 = new System.Windows.Forms.PLLabel();
            this.ctMnuChonHangHoa = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemChonTuKho = new System.Windows.Forms.ToolStripMenuItem();
            this.itemXemTruoc = new System.Windows.Forms.ToolStripMenuItem();
            this.ctMnuInPhieu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NgayNhap = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.PLLabel();
            this.Duyet = new ProtocolVN.Framework.Win.PLDuyetCombobox();
            this.Info = new ProtocolVN.Framework.Win.PLInfoBox();
            this.label4 = new System.Windows.Forms.PLLabel();
            this.lblNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.lblThoiGianCapNhat = new DevExpress.XtraEditors.LabelControl();
            this.plLabel1 = new System.Windows.Forms.PLLabel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSCongviec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSCongviec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            this.ctMnuChonHangHoa.SuspendLayout();
            this.ctMnuInPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(446, 248);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 26);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(87, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Ðón&g";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(9, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(72, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "&Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gridViewDSCongviec
            // 
            this.gridViewDSCongviec.ActiveFilterEnabled = false;
            this.gridViewDSCongviec.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridViewDSCongviec.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridViewDSCongviec.Appearance.FooterPanel.Options.UseTextOptions = true;
            this.gridViewDSCongviec.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridViewDSCongviec.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDSCongviec.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDSCongviec.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.Cotloai_cv,
            this.cotnhanvien,
            this.Cotcongviec,
            this.Cotmota,
            this.CotTGTH,
            this.CotDuyet,
            this.CotXoa});
            this.gridViewDSCongviec.GridControl = this.gridDSCongviec;
            this.gridViewDSCongviec.IndicatorWidth = 40;
            this.gridViewDSCongviec.Name = "gridViewDSCongviec";
            this.gridViewDSCongviec.NewItemRowText = "Thêm mới ở đây";
            this.gridViewDSCongviec.OptionsCustomization.AllowFilter = false;
            this.gridViewDSCongviec.OptionsCustomization.AllowGroup = false;
            this.gridViewDSCongviec.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewDSCongviec.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDSCongviec.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDSCongviec.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDSCongviec.OptionsPrint.UsePrintStyles = true;
            this.gridViewDSCongviec.OptionsView.ColumnAutoWidth = false;
            this.gridViewDSCongviec.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDSCongviec.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewDSCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridViewDSCongviec.OptionsView.ShowGroupedColumns = true;
            this.gridViewDSCongviec.OptionsView.ShowGroupPanel = false;
            this.gridViewDSCongviec.OptionsView.ShowViewCaption = true;
            this.gridViewDSCongviec.ViewCaption = "DANH SÁCH CÔNG VIỆC";
            this.gridViewDSCongviec.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewDSCongviec_CellValueChanged);
            this.gridViewDSCongviec.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridViewDSCongviec_ValidateRow);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 23;
            // 
            // Cotloai_cv
            // 
            this.Cotloai_cv.Caption = "Loại công việc";
            this.Cotloai_cv.MinWidth = 153;
            this.Cotloai_cv.Name = "Cotloai_cv";
            this.Cotloai_cv.Visible = true;
            this.Cotloai_cv.VisibleIndex = 0;
            this.Cotloai_cv.Width = 153;
            // 
            // cotnhanvien
            // 
            this.cotnhanvien.Caption = "Nhân viên";
            this.cotnhanvien.Name = "cotnhanvien";
            this.cotnhanvien.Width = 60;
            // 
            // Cotcongviec
            // 
            this.Cotcongviec.Caption = "Công việc";
            this.Cotcongviec.Name = "Cotcongviec";
            this.Cotcongviec.Width = 59;
            // 
            // Cotmota
            // 
            this.Cotmota.Caption = "Công việc";
            this.Cotmota.MinWidth = 225;
            this.Cotmota.Name = "Cotmota";
            this.Cotmota.Visible = true;
            this.Cotmota.VisibleIndex = 1;
            this.Cotmota.Width = 225;
            // 
            // CotTGTH
            // 
            this.CotTGTH.Caption = "Thời gian thực hiện(hh:mm)";
            this.CotTGTH.MinWidth = 142;
            this.CotTGTH.Name = "CotTGTH";
            this.CotTGTH.Visible = true;
            this.CotTGTH.VisibleIndex = 2;
            this.CotTGTH.Width = 146;
            // 
            // CotDuyet
            // 
            this.CotDuyet.Caption = "Duyet";
            this.CotDuyet.Name = "CotDuyet";
            this.CotDuyet.Width = 41;
            // 
            // CotXoa
            // 
            this.CotXoa.ColumnEdit = this.rep_Xoa;
            this.CotXoa.MinWidth = 32;
            this.CotXoa.Name = "CotXoa";
            this.CotXoa.Visible = true;
            this.CotXoa.VisibleIndex = 3;
            this.CotXoa.Width = 32;
            // 
            // rep_Xoa
            // 
            this.rep_Xoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", 20, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, false)});
            this.rep_Xoa.Name = "rep_Xoa";
            this.rep_Xoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.rep_Xoa.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.rep_Xoa_ButtonClick);
            // 
            // gridDSCongviec
            // 
            this.gridDSCongviec.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridDSCongviec.BackgroundImage")));
            this.gridDSCongviec.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridDSCongviec.Location = new System.Drawing.Point(7, 57);
            this.gridDSCongviec.MainView = this.gridViewDSCongviec;
            this.gridDSCongviec.Name = "gridDSCongviec";
            this.gridDSCongviec.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.rep_Xoa});
            this.gridDSCongviec.Size = new System.Drawing.Size(601, 185);
            this.gridDSCongviec.TabIndex = 27;
            this.gridDSCongviec.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDSCongviec});
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Duyệt",
            "Chưa Duyệt",
            "Chờ Duyệt"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Ngày làm việc";
            this.label2.ToolTip = "Dữ liệu bắt buộc nhập";
            this.label2.ZZZType = System.Windows.Forms.PLLabel.LabelType.REQUIRED;
            // 
            // ctMnuChonHangHoa
            // 
            this.ctMnuChonHangHoa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemChonTuKho});
            this.ctMnuChonHangHoa.Name = "contextMenuStrip1";
            this.ctMnuChonHangHoa.Size = new System.Drawing.Size(199, 26);
            // 
            // itemChonTuKho
            // 
            this.itemChonTuKho.Name = "itemChonTuKho";
            this.itemChonTuKho.Size = new System.Drawing.Size(198, 22);
            this.itemChonTuKho.Text = "Chọn từ phiếu xuất kho";
            // 
            // itemXemTruoc
            // 
            this.itemXemTruoc.Name = "itemXemTruoc";
            this.itemXemTruoc.Size = new System.Drawing.Size(161, 22);
            this.itemXemTruoc.Text = "Xem trước khi in";
            // 
            // ctMnuInPhieu
            // 
            this.ctMnuInPhieu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemXemTruoc});
            this.ctMnuInPhieu.Name = "contextMenuStrip2";
            this.ctMnuInPhieu.Size = new System.Drawing.Size(162, 26);
            // 
            // NgayNhap
            // 
            this.NgayNhap.EditValue = null;
            this.NgayNhap.Location = new System.Drawing.Point(79, 9);
            this.NgayNhap.Name = "NgayNhap";
            this.NgayNhap.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.NgayNhap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.NgayNhap.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.NgayNhap.Size = new System.Drawing.Size(166, 20);
            this.NgayNhap.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(270, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Người cập nhật";
            this.label1.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // Duyet
            // 
            this.Duyet.Enabled = false;
            this.Duyet.Location = new System.Drawing.Point(69, 248);
            this.Duyet.Name = "Duyet";
            this.Duyet.Size = new System.Drawing.Size(176, 20);
            this.Duyet.TabIndex = 31;
            this.Duyet.Visible = false;
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(710, 10);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(21, 21);
            this.Info.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.label4.Appearance.Options.UseFont = true;
            this.label4.Location = new System.Drawing.Point(270, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Thời gian cập nhật";
            this.label4.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNhanVien.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.Appearance.Options.UseFont = true;
            this.lblNhanVien.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblNhanVien.Location = new System.Drawing.Point(365, 12);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(154, 13);
            this.lblNhanVien.TabIndex = 82;
            this.lblNhanVien.Text = "Lâm Trần Thiên Lộc";
            // 
            // lblThoiGianCapNhat
            // 
            this.lblThoiGianCapNhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianCapNhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianCapNhat.Appearance.Options.UseFont = true;
            this.lblThoiGianCapNhat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThoiGianCapNhat.Location = new System.Drawing.Point(365, 31);
            this.lblThoiGianCapNhat.Name = "lblThoiGianCapNhat";
            this.lblThoiGianCapNhat.Size = new System.Drawing.Size(143, 20);
            this.lblThoiGianCapNhat.TabIndex = 82;
            this.lblThoiGianCapNhat.Text = "Chưa xác định";
            // 
            // plLabel1
            // 
            this.plLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic);
            this.plLabel1.Appearance.Options.UseFont = true;
            this.plLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.plLabel1.Location = new System.Drawing.Point(7, 250);
            this.plLabel1.Name = "plLabel1";
            this.plLabel1.Size = new System.Drawing.Size(56, 19);
            this.plLabel1.TabIndex = 21;
            this.plLabel1.Text = "Tình trạng";
            this.plLabel1.Visible = false;
            this.plLabel1.ZZZType = System.Windows.Forms.PLLabel.LabelType.DESCRIPTION;
            // 
            // frmTimeTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 280);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.plLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NgayNhap);
            this.Controls.Add(this.gridDSCongviec);
            this.Controls.Add(this.Duyet);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.lblThoiGianCapNhat);
            this.Controls.Add(this.label4);
            this.Name = "frmTimeTable";
            this.Text = "Nhật ký làm việc";
            this.Load += new System.EventHandler(this.frmTimeTable_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDSCongviec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep_Xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDSCongviec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            this.ctMnuChonHangHoa.ResumeLayout(false);
            this.ctMnuInPhieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgayNhap.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDSCongviec;
        private DevExpress.XtraGrid.GridControl gridDSCongviec;
        private  System.Windows.Forms.PLLabel  label2;
        private System.Windows.Forms.ContextMenuStrip ctMnuChonHangHoa;
        private System.Windows.Forms.ToolStripMenuItem itemChonTuKho;
        private System.Windows.Forms.ToolStripMenuItem itemXemTruoc;
        private System.Windows.Forms.ContextMenuStrip ctMnuInPhieu;
        private DevExpress.XtraEditors.DateEdit NgayNhap;
        private DevExpress.XtraGrid.Columns.GridColumn Cotcongviec;
        private DevExpress.XtraGrid.Columns.GridColumn Cotmota;
        private DevExpress.XtraGrid.Columns.GridColumn CotTGTH;
        private DevExpress.XtraGrid.Columns.GridColumn Cotloai_cv;
        private DevExpress.XtraGrid.Columns.GridColumn cotnhanvien;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private  System.Windows.Forms.PLLabel  label1;
        private ProtocolVN.Framework.Win.PLDuyetCombobox Duyet;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private ProtocolVN.Framework.Win.PLInfoBox Info;
        private DevExpress.XtraGrid.Columns.GridColumn CotDuyet;
        private DevExpress.XtraGrid.Columns.GridColumn CotXoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rep_Xoa;
        private System.Windows.Forms.PLLabel label4;
        private DevExpress.XtraEditors.LabelControl lblNhanVien;
        private DevExpress.XtraEditors.LabelControl lblThoiGianCapNhat;
        private System.Windows.Forms.PLLabel plLabel1;

    }
}