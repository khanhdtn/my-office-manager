namespace pl.office.form
{
    partial class frmViewForum
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
            this.gridControlForum = new DevExpress.XtraGrid.GridControl();
            this.gridViewForum = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.cotID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.cotNguoiThaoLuan = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.cotThoiGian = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.cotCapNhat = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.cotXoa = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.cotTraLoi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.cotFileDK = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.cotNoiDung = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlForum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewForum)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlForum
            // 
            this.gridControlForum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            
            this.gridControlForum.Location = new System.Drawing.Point(0, 0);
            this.gridControlForum.MainView = this.gridViewForum;
            this.gridControlForum.Name = "gridControlForum";
            this.gridControlForum.Size = new System.Drawing.Size(808, 434);
            this.gridControlForum.TabIndex = 0;
            this.gridControlForum.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewForum});
            // 
            // gridViewForum
            // 
            this.gridViewForum.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.gridViewForum.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.cotID,
            this.cotNoiDung,
            this.cotNguoiThaoLuan,
            this.cotThoiGian,
            this.cotCapNhat,
            this.cotTraLoi,
            this.cotXoa,
            this.cotFileDK});
            this.gridViewForum.GridControl = this.gridControlForum;
            this.gridViewForum.Name = "gridViewForum";
            this.gridViewForum.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridViewForum.OptionsView.ColumnAutoWidth = true;
            this.gridViewForum.OptionsView.ShowBands = false;
            this.gridViewForum.OptionsView.ShowColumnHeaders = false;
            this.gridViewForum.OptionsView.ShowGroupPanel = false;
            this.gridViewForum.OptionsView.ShowViewCaption = true;
            this.gridViewForum.ViewCaption = "Chủ đề";
            this.gridViewForum.Click += new System.EventHandler(this.gridViewForum_Click);
            this.gridViewForum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridViewForum_MouseMove);
            this.gridViewForum.MeasurePreviewHeight += new DevExpress.XtraGrid.Views.Grid.RowHeightEventHandler(this.gridViewForum_MeasurePreviewHeight);
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Mã số";
            this.gridBand1.Columns.Add(this.cotID);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Visible = false;
            this.gridBand1.Width = 75;
            // 
            // cotID
            // 
            this.cotID.Caption = "Mã số";
            this.cotID.Name = "cotID";
            this.cotID.RowCount = 4;
            this.cotID.Visible = true;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Thông tin";
            this.gridBand2.Columns.Add(this.cotNguoiThaoLuan);
            this.gridBand2.Columns.Add(this.cotThoiGian);
            this.gridBand2.Columns.Add(this.cotCapNhat);
            this.gridBand2.Columns.Add(this.cotXoa);
            this.gridBand2.Columns.Add(this.cotTraLoi);
            this.gridBand2.Columns.Add(this.cotFileDK);
            this.gridBand2.Columns.Add(this.cotNoiDung);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 736;
            // 
            // cotNguoiThaoLuan
            // 
            this.cotNguoiThaoLuan.Caption = "Người thảo luận";
            this.cotNguoiThaoLuan.Name = "cotNguoiThaoLuan";
            this.cotNguoiThaoLuan.Visible = true;
            this.cotNguoiThaoLuan.Width = 736;
            // 
            // cotThoiGian
            // 
            this.cotThoiGian.Caption = "Thời gian thảo luận";
            this.cotThoiGian.Name = "cotThoiGian";
            this.cotThoiGian.RowIndex = 1;
            this.cotThoiGian.Visible = true;
            this.cotThoiGian.Width = 736;
            // 
            // cotCapNhat
            // 
            this.cotCapNhat.Caption = "Cập nhật";
            this.cotCapNhat.Name = "cotCapNhat";
            this.cotCapNhat.RowIndex = 2;
            this.cotCapNhat.Visible = true;
            this.cotCapNhat.Width = 90;
            // 
            // cotXoa
            // 
            this.cotXoa.Caption = "Xóa";
            this.cotXoa.Name = "cotXoa";
            this.cotXoa.RowIndex = 2;
            this.cotXoa.Visible = true;
            this.cotXoa.Width = 73;
            // 
            // cotTraLoi
            // 
            this.cotTraLoi.Caption = "Trả lời";
            this.cotTraLoi.Name = "cotTraLoi";
            this.cotTraLoi.RowIndex = 2;
            this.cotTraLoi.Visible = true;
            this.cotTraLoi.Width = 78;
            // 
            // cotFileDK
            // 
            this.cotFileDK.Caption = "Tập tin đính kèm";
            this.cotFileDK.Name = "cotFileDK";
            this.cotFileDK.RowIndex = 2;
            this.cotFileDK.Visible = true;
            this.cotFileDK.Width = 495;
            // 
            // cotNoiDung
            // 
            this.cotNoiDung.Caption = "Nội dung";
            this.cotNoiDung.Name = "cotNoiDung";
            this.cotNoiDung.RowCount = 10;
            this.cotNoiDung.RowIndex = 3;
            this.cotNoiDung.Visible = true;
            this.cotNoiDung.Width = 736;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Nội dung";
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Visible = false;
            this.gridBand3.Width = 599;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "gridBand4";
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(719, 443);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đón&g";
            // 
            // frmViewForum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 475);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gridControlForum);
            this.Name = "frmViewForum";
            this.Text = "Diễn đàn thảo luận";
            this.Load += new System.EventHandler(this.frmViewForum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlForum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewForum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlForum;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridViewForum;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cotID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cotNoiDung;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cotNguoiThaoLuan;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cotThoiGian;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cotCapNhat;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cotTraLoi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cotFileDK;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn cotXoa;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;

    }
}