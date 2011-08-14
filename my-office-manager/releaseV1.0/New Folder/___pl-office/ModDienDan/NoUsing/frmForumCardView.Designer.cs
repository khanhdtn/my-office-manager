namespace office
{
    partial class frmForumCardView
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControlMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.ColNguoiCapNhat = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.ColNgayCapNhat = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_layoutViewColumn1_1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.ColNoiDung = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemRichTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.layoutViewField_layoutViewColumn1_3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.ColListFile = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemRichTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit();
            this.layoutViewField_layoutViewColumn1_4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.ColButtons = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.layoutViewField_layoutViewColumn1_2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            this.item2 = new DevExpress.XtraLayout.SimpleSeparator();
            this.item3 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.item4 = new DevExpress.XtraLayout.SimpleLabelItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnReply = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlMaster
            // 
            this.gridControlMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMaster.Location = new System.Drawing.Point(1, 1);
            this.gridControlMaster.MainView = this.gridViewMaster;
            this.gridControlMaster.Name = "gridControlMaster";
            this.gridControlMaster.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRichTextEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemRichTextEdit2});
            this.gridControlMaster.Size = new System.Drawing.Size(937, 398);
            this.gridControlMaster.TabIndex = 0;
            this.gridControlMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.CardHorzInterval = 1;
            this.gridViewMaster.CardMinSize = new System.Drawing.Size(714, 77);
            this.gridViewMaster.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.ColNguoiCapNhat,
            this.ColNgayCapNhat,
            this.ColNoiDung,
            this.ColListFile,
            this.ColButtons});
            this.gridViewMaster.GridControl = this.gridControlMaster;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsBehavior.ScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            this.gridViewMaster.OptionsCustomization.AllowFilter = false;
            this.gridViewMaster.OptionsCustomization.AllowSort = false;
            this.gridViewMaster.OptionsItemText.AlignMode = DevExpress.XtraGrid.Views.Layout.FieldTextAlignMode.CustomSize;
            this.gridViewMaster.OptionsItemText.TextToControlDistance = 0;
            this.gridViewMaster.OptionsMultiRecordMode.StretchCardToViewWidth = true;
            this.gridViewMaster.OptionsSingleRecordMode.StretchCardToViewWidth = true;
            this.gridViewMaster.OptionsView.CardArrangeRule = DevExpress.XtraGrid.Views.Layout.LayoutCardArrangeRule.AllowPartialCards;
            this.gridViewMaster.OptionsView.ContentAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.gridViewMaster.OptionsView.ShowCardCaption = false;
            this.gridViewMaster.OptionsView.ShowCardLines = false;
            this.gridViewMaster.OptionsView.ShowFieldHints = false;
            this.gridViewMaster.OptionsView.ShowHeaderPanel = false;
            this.gridViewMaster.OptionsView.ShowViewCaption = true;
            this.gridViewMaster.OptionsView.ViewMode = DevExpress.XtraGrid.Views.Layout.LayoutViewMode.Column;
            this.gridViewMaster.TemplateCard = this.layoutViewCard1;
            this.gridViewMaster.ViewCaption = "Chủ đề: Đi tìm tình yêu";
            this.gridViewMaster.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Layout.Events.LayoutViewCustomRowCellEditEventHandler(this.layoutView1_CustomRowCellEdit);
            // 
            // ColNguoiCapNhat
            // 
            this.ColNguoiCapNhat.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ColNguoiCapNhat.AppearanceCell.Options.UseFont = true;
            this.ColNguoiCapNhat.LayoutViewField = this.layoutViewField_layoutViewColumn1;
            this.ColNguoiCapNhat.Name = "ColNguoiCapNhat";
            this.ColNguoiCapNhat.OptionsColumn.AllowEdit = false;
            this.ColNguoiCapNhat.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.ColNguoiCapNhat.OptionsFilter.AllowAutoFilter = false;
            this.ColNguoiCapNhat.OptionsFilter.AllowFilter = false;
            // 
            // layoutViewField_layoutViewColumn1
            // 
            this.layoutViewField_layoutViewColumn1.EditorPreferredWidth = 152;
            this.layoutViewField_layoutViewColumn1.Location = new System.Drawing.Point(95, 0);
            this.layoutViewField_layoutViewColumn1.Name = "layoutViewField_layoutViewColumn1";
            this.layoutViewField_layoutViewColumn1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_layoutViewColumn1.Size = new System.Drawing.Size(158, 22);
            this.layoutViewField_layoutViewColumn1.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutViewField_layoutViewColumn1.TextSize = new System.Drawing.Size(0, 13);
            // 
            // ColNgayCapNhat
            // 
            this.ColNgayCapNhat.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ColNgayCapNhat.AppearanceCell.Options.UseFont = true;
            this.ColNgayCapNhat.LayoutViewField = this.layoutViewField_layoutViewColumn1_1;
            this.ColNgayCapNhat.Name = "ColNgayCapNhat";
            this.ColNgayCapNhat.OptionsColumn.AllowEdit = false;
            this.ColNgayCapNhat.OptionsFilter.AllowAutoFilter = false;
            this.ColNgayCapNhat.OptionsFilter.AllowFilter = false;
            // 
            // layoutViewField_layoutViewColumn1_1
            // 
            this.layoutViewField_layoutViewColumn1_1.EditorPreferredWidth = 152;
            this.layoutViewField_layoutViewColumn1_1.Location = new System.Drawing.Point(95, 22);
            this.layoutViewField_layoutViewColumn1_1.Name = "layoutViewField_layoutViewColumn1_1";
            this.layoutViewField_layoutViewColumn1_1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_layoutViewColumn1_1.Size = new System.Drawing.Size(158, 22);
            this.layoutViewField_layoutViewColumn1_1.TextLocation = DevExpress.Utils.Locations.Default;
            this.layoutViewField_layoutViewColumn1_1.TextSize = new System.Drawing.Size(0, 13);
            // 
            // ColNoiDung
            // 
            this.ColNoiDung.ColumnEdit = this.repositoryItemRichTextEdit1;
            this.ColNoiDung.LayoutViewField = this.layoutViewField_layoutViewColumn1_3;
            this.ColNoiDung.Name = "ColNoiDung";
            this.ColNoiDung.OptionsColumn.AllowEdit = false;
            this.ColNoiDung.OptionsColumn.ReadOnly = true;
            this.ColNoiDung.OptionsFilter.AllowAutoFilter = false;
            this.ColNoiDung.OptionsFilter.AllowFilter = false;
            // 
            // repositoryItemRichTextEdit1
            // 
            this.repositoryItemRichTextEdit1.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            this.repositoryItemRichTextEdit1.EncodingWebName = "utf-8";
            this.repositoryItemRichTextEdit1.MaxHeight = 1000000000;
            this.repositoryItemRichTextEdit1.Name = "repositoryItemRichTextEdit1";
            this.repositoryItemRichTextEdit1.OptionsVerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            // 
            // layoutViewField_layoutViewColumn1_3
            // 
            this.layoutViewField_layoutViewColumn1_3.EditorPreferredWidth = 738;
            this.layoutViewField_layoutViewColumn1_3.Location = new System.Drawing.Point(0, 44);
            this.layoutViewField_layoutViewColumn1_3.Name = "layoutViewField_layoutViewColumn1_3";
            this.layoutViewField_layoutViewColumn1_3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_layoutViewColumn1_3.Size = new System.Drawing.Size(744, 26);
            this.layoutViewField_layoutViewColumn1_3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutViewField_layoutViewColumn1_3.TextToControlDistance = 0;
            this.layoutViewField_layoutViewColumn1_3.TextVisible = false;
            // 
            // ColListFile
            // 
            this.ColListFile.ColumnEdit = this.repositoryItemRichTextEdit2;
            this.ColListFile.LayoutViewField = this.layoutViewField_layoutViewColumn1_4;
            this.ColListFile.Name = "ColListFile";
            this.ColListFile.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemRichTextEdit2
            // 
            this.repositoryItemRichTextEdit2.DocumentFormat = DevExpress.XtraRichEdit.DocumentFormat.Rtf;
            this.repositoryItemRichTextEdit2.EncodingWebName = "utf-8";
            this.repositoryItemRichTextEdit2.Name = "repositoryItemRichTextEdit2";
            // 
            // layoutViewField_layoutViewColumn1_4
            // 
            this.layoutViewField_layoutViewColumn1_4.EditorPreferredWidth = 355;
            this.layoutViewField_layoutViewColumn1_4.Location = new System.Drawing.Point(253, 0);
            this.layoutViewField_layoutViewColumn1_4.MaxSize = new System.Drawing.Size(500, 50);
            this.layoutViewField_layoutViewColumn1_4.MinSize = new System.Drawing.Size(26, 26);
            this.layoutViewField_layoutViewColumn1_4.Name = "layoutViewField_layoutViewColumn1_4";
            this.layoutViewField_layoutViewColumn1_4.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewField_layoutViewColumn1_4.Size = new System.Drawing.Size(361, 44);
            this.layoutViewField_layoutViewColumn1_4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutViewField_layoutViewColumn1_4.TextSize = new System.Drawing.Size(0, 20);
            this.layoutViewField_layoutViewColumn1_4.TextToControlDistance = 0;
            // 
            // ColButtons
            // 
            this.ColButtons.ColumnEdit = this.repositoryItemButtonEdit1;
            this.ColButtons.LayoutViewField = this.layoutViewField_layoutViewColumn1_2;
            this.ColButtons.Name = "ColButtons";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Xóa", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", "DELETE", null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Cập nhật", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", "UPDATE", null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // layoutViewField_layoutViewColumn1_2
            // 
            this.layoutViewField_layoutViewColumn1_2.EditorPreferredWidth = 126;
            this.layoutViewField_layoutViewColumn1_2.Location = new System.Drawing.Point(614, 0);
            this.layoutViewField_layoutViewColumn1_2.Name = "layoutViewField_layoutViewColumn1_2";
            this.layoutViewField_layoutViewColumn1_2.Size = new System.Drawing.Size(130, 44);
            this.layoutViewField_layoutViewColumn1_2.TextSize = new System.Drawing.Size(0, 20);
            this.layoutViewField_layoutViewColumn1_2.TextToControlDistance = 0;
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.CustomizationFormText = "TemplateCard";
            this.layoutViewCard1.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.GroupBordersVisible = false;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_layoutViewColumn1,
            this.layoutViewField_layoutViewColumn1_1,
            this.item2,
            this.item3,
            this.item4,
            this.layoutViewField_layoutViewColumn1_4,
            this.layoutViewField_layoutViewColumn1_3,
            this.layoutViewField_layoutViewColumn1_2});
            this.layoutViewCard1.Name = "layoutViewCard1";
            this.layoutViewCard1.OptionsItemText.TextToControlDistance = 0;
            this.layoutViewCard1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutViewCard1.Text = "TemplateCard";
            // 
            // item2
            // 
            this.item2.CustomizationFormText = "item2";
            this.item2.Location = new System.Drawing.Point(0, 70);
            this.item2.Name = "item2";
            this.item2.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.item2.Size = new System.Drawing.Size(744, 2);
            this.item2.Text = "item2";
            // 
            // item3
            // 
            this.item3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.item3.AppearanceItemCaption.Options.UseFont = true;
            this.item3.CustomizationFormText = "Người cập nhật";
            this.item3.Location = new System.Drawing.Point(0, 0);
            this.item3.Name = "item3";
            this.item3.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.item3.Size = new System.Drawing.Size(95, 22);
            this.item3.Text = "Người cập nhật";
            this.item3.TextSize = new System.Drawing.Size(73, 13);
            // 
            // item4
            // 
            this.item4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.item4.AppearanceItemCaption.Options.UseFont = true;
            this.item4.CustomizationFormText = "Ngày cập nhật";
            this.item4.Location = new System.Drawing.Point(0, 22);
            this.item4.Name = "item4";
            this.item4.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.item4.Size = new System.Drawing.Size(95, 22);
            this.item4.Text = "Ngày cập nhật";
            this.item4.TextSize = new System.Drawing.Size(70, 13);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.simpleButton1);
            this.flowLayoutPanel1.Controls.Add(this.btnReply);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(610, 405);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(331, 28);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(253, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Đóng";
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(172, 3);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(75, 23);
            this.btnReply.TabIndex = 0;
            this.btnReply.Text = "Trả lời";
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // frmForumCardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 436);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.gridControlMaster);
            this.Name = "frmForumCardView";
            this.Text = "Diễn đàn và Thảo luận";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRichTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_layoutViewColumn1_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item4)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlMaster;
        private DevExpress.XtraGrid.Views.Layout.LayoutView gridViewMaster;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn ColNguoiCapNhat;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn ColNgayCapNhat;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn ColNoiDung;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnReply;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn ColListFile;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn ColButtons;
        private DevExpress.XtraEditors.Repository.RepositoryItemRichTextEdit repositoryItemRichTextEdit2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_layoutViewColumn1_2;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        private DevExpress.XtraLayout.SimpleSeparator item2;
        private DevExpress.XtraLayout.SimpleLabelItem item3;
        private DevExpress.XtraLayout.SimpleLabelItem item4;
    }
}