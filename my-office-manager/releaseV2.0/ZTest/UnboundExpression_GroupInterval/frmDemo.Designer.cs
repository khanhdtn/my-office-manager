namespace pl.office.ZTest.UnboundExpression
{
    partial class frmDemo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDemo));
            this.gridControlDemo = new DevExpress.XtraGrid.GridControl();
            this.gridViewDemo = new DevExpress.XtraGrid.Views.Grid.PLGridView();
            this.cotID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cotDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDemo)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlDemo
            // 
            this.gridControlDemo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gridControlDemo.BackgroundImage")));
            this.gridControlDemo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.gridControlDemo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlDemo.Location = new System.Drawing.Point(14, 27);
            this.gridControlDemo.MainView = this.gridViewDemo;
            this.gridControlDemo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControlDemo.Name = "gridControlDemo";
            this.gridControlDemo.Size = new System.Drawing.Size(878, 448);
            this.gridControlDemo.TabIndex = 1;
            this.gridControlDemo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDemo});
            // 
            // gridViewDemo
            // 
            this.gridViewDemo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewDemo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewDemo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cotID,
            this.cotName,
            this.cotA,
            this.cotB,
            this.cotC,
            this.cotDate});
            this.gridViewDemo.GridControl = this.gridControlDemo;
            this.gridViewDemo.IndicatorWidth = 40;
            this.gridViewDemo.Name = "gridViewDemo";
            this.gridViewDemo.OptionsLayout.Columns.AddNewColumns = false;
            this.gridViewDemo.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewDemo.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridViewDemo.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewDemo.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewDemo.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewDemo.OptionsView.ShowGroupedColumns = true;
            // 
            // cotID
            // 
            this.cotID.Caption = "ID";
            this.cotID.Name = "cotID";
            this.cotID.Width = 23;
            // 
            // cotName
            // 
            this.cotName.Caption = "Tên";
            this.cotName.Name = "cotName";
            this.cotName.Visible = true;
            this.cotName.VisibleIndex = 0;
            this.cotName.Width = 30;
            // 
            // cotA
            // 
            this.cotA.Caption = "A";
            this.cotA.Name = "cotA";
            this.cotA.Visible = true;
            this.cotA.VisibleIndex = 1;
            this.cotA.Width = 20;
            // 
            // cotB
            // 
            this.cotB.Caption = "B";
            this.cotB.Name = "cotB";
            this.cotB.Visible = true;
            this.cotB.VisibleIndex = 2;
            this.cotB.Width = 20;
            // 
            // cotC
            // 
            this.cotC.Caption = "C";
            this.cotC.Name = "cotC";
            this.cotC.Visible = true;
            this.cotC.VisibleIndex = 3;
            this.cotC.Width = 20;
            // 
            // cotDate
            // 
            this.cotDate.Caption = "Ngày";
            this.cotDate.Name = "cotDate";
            this.cotDate.Visible = true;
            this.cotDate.VisibleIndex = 4;
            this.cotDate.Width = 37;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 525);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(463, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nhấn chuột phải lên cột : Chọn \'Tùy chọn gom nhóm (GroupInterval)\' để áp dụng";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(14, 501);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(379, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Áp dụng lưới sử dụng : Help.AppGroupInterval(GridView gridView)";
            // 
            // frmDemo
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 574);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControlDemo);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmDemo";
            this.Text = "Demo";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDemo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlDemo;
        private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDemo;
        private DevExpress.XtraGrid.Columns.GridColumn cotID;
        private DevExpress.XtraGrid.Columns.GridColumn cotName;
        private DevExpress.XtraGrid.Columns.GridColumn cotA;
        private DevExpress.XtraGrid.Columns.GridColumn cotB;
        private DevExpress.XtraGrid.Columns.GridColumn cotC;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn cotDate;
    }
}