using System;
namespace office
{
    partial class frmDocument
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.LoaiTaiLieu = new ProtocolVN.Framework.Win.DMTreeGroup();
            this.grdThongtinTL = new ProtocolVN.Framework.Win.DMGrid();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItemThem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSua = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemXoa = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLuu = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemKLuu = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.LoaiTaiLieu);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.grdThongtinTL);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(615, 471);
            this.splitContainerControl1.SplitterPosition = 199;
            this.splitContainerControl1.TabIndex = 189;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // LoaiTaiLieu
            // 
            this.LoaiTaiLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoaiTaiLieu.Location = new System.Drawing.Point(0, 0);
            this.LoaiTaiLieu.Name = "LoaiTaiLieu";
            this.LoaiTaiLieu.Size = new System.Drawing.Size(199, 471);
            this.LoaiTaiLieu.TabIndex = 0;
            // 
            // grdThongtinTL
            // 
            this.grdThongtinTL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdThongtinTL.Location = new System.Drawing.Point(0, 0);
            this.grdThongtinTL.Name = "grdThongtinTL";
            this.grdThongtinTL.Size = new System.Drawing.Size(410, 471);
            this.grdThongtinTL.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemThem,
            this.barButtonItemSua,
            this.barButtonItemXoa,
            this.barButtonItemLuu,
            this.barButtonItemKLuu});
            this.barManager1.MaxItemId = 5;
            // 
            // barButtonItemThem
            // 
            this.barButtonItemThem.Caption = "&Thêm";
            this.barButtonItemThem.Id = 0;
            this.barButtonItemThem.Name = "barButtonItemThem";
            // 
            // barButtonItemSua
            // 
            this.barButtonItemSua.Caption = "&Xóa";
            this.barButtonItemSua.Id = 1;
            this.barButtonItemSua.Name = "barButtonItemSua";
            // 
            // barButtonItemXoa
            // 
            this.barButtonItemXoa.Caption = "&Sửa";
            this.barButtonItemXoa.Id = 2;
            this.barButtonItemXoa.Name = "barButtonItemXoa";
            // 
            // barButtonItemLuu
            // 
            this.barButtonItemLuu.Caption = "&Lưu";
            this.barButtonItemLuu.Id = 3;
            this.barButtonItemLuu.Name = "barButtonItemLuu";
            // 
            // barButtonItemKLuu
            // 
            this.barButtonItemKLuu.Caption = "&Không Lưu";
            this.barButtonItemKLuu.Id = 4;
            this.barButtonItemKLuu.Name = "barButtonItemKLuu";
            // 
            // frmTailieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 471);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTailieu";
            this.Text = "Quản lý tài liệu";
            this.Load += new System.EventHandler(this.frmTailieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemThem;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSua;
        private DevExpress.XtraBars.BarButtonItem barButtonItemXoa;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLuu;
        private DevExpress.XtraBars.BarButtonItem barButtonItemKLuu;
        private ProtocolVN.Framework.Win.DMTreeGroup LoaiTaiLieu;
        private ProtocolVN.Framework.Win.DMGrid grdThongtinTL;
    }
}