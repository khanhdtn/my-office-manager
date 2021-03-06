using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.DanhMuc;
using DTO;
using System.Drawing;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using ProtocolVN.App.Office;
using DevExpress.XtraGrid;
using System.IO;
using System.Text;
using ProtocolVN.Plugin.TimeSheet;


namespace office
{

    public partial class frmBugProductQL : PhieuQuanLy10Change, IFormRefresh
    {
        //public partial class frmBugProductQL : XtraFormPL
        //{
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //public DevExpress.XtraBars.BarManager barManager1;
        //public DevExpress.XtraBars.Bar MainBar;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //public DevExpress.XtraBars.BarDockControl barDockControlTop;
        //public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //public DevExpress.XtraBars.BarDockControl barDockControlRight;
        //public DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //public DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //public DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //public DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //public DevExpress.XtraBars.BarSubItem barSubItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //public DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //public DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //public DevExpress.XtraBars.PopupMenu popupMenu1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //public SplitContainerControl splitContainerControl1;
        //public DevExpress.XtraGrid.GridControl gridControlMaster;
        //public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.FIX;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmBugProductQL).FullName,
                "Quản lý vấn đề",
                ParentID, true,
                typeof(frmBugProductQL).FullName,
                true, IsSep, "mnbToChuc.png", true, "", "");
        }
        private PhieuQuanLy10Fix Fix;
        private DataTable dtRecipient = null;
        #endregion

        #region hàm khởi tạo

        public frmBugProductQL()
        {
            DataSet ds_init = new DataSet();
            InitializeComponent();
            IDField = "ID";
            DisplayField = "NAME";
            Fix = new PhieuQuanLy10Fix(this);
        }
        private void frmQLCongviecQL1N_Load(object sender, EventArgs e)
        {
            Web_Mo_Ta.DocumentText = null; 
            colNguoi_nhan_PH.Visible = false;
            gridControlMaster.DataSourceChanged += new EventHandler(gridViewMaster_DataSourceChanged);
            gridControlThongTinLienHe.Load += new EventHandler(gridControlThongTinLienHe_Load);
            gridViewThongTinLienHe.DoubleClick += new EventHandler(gridViewThongTinLienHe_DoubleClick);
           
            this.XtraTabPageDetail.Size = new System.Drawing.Size(869, 285);
            //
            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;            
        }

        void gridControlThongTinLienHe_Load(object sender, EventArgs e)
        {
            gridViewThongTinLienHe.BestFitColumns();
        }
        #endregion

        #region Step 1 : Xác định các cột sẽ hiển thị trong gridView
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(colTenBug, "NAME");
            HelpGridColumn.CotReadOnlyDate(colNgay_Gui, "NGAY_GUI", PLConst.FORMAT_DATETIME_STRING);
            XtraGridSupportExt.TextLeftColumn(colNguoi_Gui, "TEN_NGUOI_GUI");
            HelpGridExt1.colMultiline(colNguoi_Nhan, "TEN_NGUOI_NHAN");
            XtraGridSupportExt.TextLeftColumn(colT_trang, "TEN_TT");
            HelpGridColumn.CotCombobox(colLoaiVanDe,DABase.getDatabase().LoadDataSet(@"SELECT ID,NAME 
            FROM DM_LOAI_VAN_DE WHERE VISIBLE_BIT = 'Y'"),"ID","NAME","LOAI_VAN_DE");
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            gridViewMaster.OptionsView.RowAutoHeight = true;
        }
        #endregion

        #region Step 2 : Xác định các cột sẽ hiển thị trong phần detail
        public override void InitColumDetail()
        {
            #region column phản hồi
            XtraGridSupportExt.TextLeftColumn(colNguoi_gui_PH, "N_GUI");
            XtraGridSupportExt.TextLeftColumn(colNguoi_nhan_PH, "N_NHAN");
            HelpGridColumn.CotReadOnlyDate(colTG_Gui_PH, "NGAY_GUI", PLConst.FORMAT_DATETIME_STRING);
            #endregion
            #region column layout tài liệu
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotCalcEditDec(lvSize, "SIZE", 3, true);
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            repositoryItemMemoExEdit1.ReadOnly = true;
            repositoryItemMemoExEdit1.ScrollBars = ScrollBars.Both;
            StyleFormatCondition conditionRed = new StyleFormatCondition();
            conditionRed.Appearance.Options.UseForeColor = true;
            conditionRed.Appearance.ForeColor = Color.Red;
            conditionRed.Condition = FormatConditionEnum.Expression;
            conditionRed.Expression = "[TYPE_ID] == 10";
            conditionRed.Column = lvFile_dinh_kem;
            layoutView1.FormatConditions.Add(conditionRed);
            #endregion


        }
        #endregion

        #region Step 3 : Xác định các control trong filter part và Khởi tạo control trong phần filter.
        public override void PLLoadFilterPart()
        {
            //Khởi tạo dữ liệu cho các control trong phần lọc                                        
            DMLoaiVanDe.I.InitCtrl(loaiVanDe, true);
            HelpDanhMuc.ChonTinhTrang(Tinh_Trang);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            PLTimeSheetUtil.PermissionForControl(NhanVien, NhanVien.Visible == true, NhanVien.Visible == true);
            AppCtrl.InitTreeChonNhanVien(cmbNguoiNhan, false, false);
            cmbNguoiNhan._SelectedIDs = new long [] { (FrameworkParams.currentUser.employee_id) };
            cmbNguoiNhan.Enabled = NhanVien.Enabled;
            this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            toolTip1.BackColor = Color.LightYellow;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        
        #endregion

        #region Step 4 : Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            return null;
        }
      
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        #region Step 5 : Xây dựng Query Buider cho việc tìm kiếm
        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg wait = new FWWaitingMsg();
            if (dtRecipient == null) dtRecipient = HelpDB.getDatabase().LoadDataSet("SELECT ID,NAME FROM DM_NHAN_VIEN").Tables[0];
            DataSet ds;
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            StringBuilder cond = new StringBuilder("");
            if (NhanVien._getSelectedID() != -1) cond.Append(string.Format("NGUOI_GUI = {0}", NhanVien._getSelectedID()));
            long[] arrNguoiNhan = cmbNguoiNhan._SelectedIDs;
            if (arrNguoiNhan.Length > 0 && cond.Length > 0) cond.Append(" OR ");
            int temp = arrNguoiNhan.Length;
            foreach (long id in arrNguoiNhan)
            {
                cond.Append(string.Format(@"(NGUOI_NHAN LIKE '{0}%') 
                        OR (NGUOI_NHAN LIKE '%,{0},%') OR (NGUOI_NHAN LIKE '%,{0}')", id));
                temp--;
                if (temp > 0)
                {
                    cond.Append(" OR ");
                }
            }
            if (cond.Length > 0)
            {
                filter.addCondition(cond.ToString());
            }
            filter.addID("LOAI_VAN_DE", loaiVanDe._getSelectedID());
            filter.addID("TINH_TRANG", Tinh_Trang._getSelectedID());
            filter.addDateFromTo("NGAY_GUI", ngayLamViec.FromDate, ngayLamViec.ToDate);
            ds = HelpDB.getDatabase().LoadDataSet(filter, "BUG");
            DataTable Bang_tinh_trang = DAYeuCau.Bang_tinh_trangBug();
            ds.Tables.AddRange(new DataTable[] {  Bang_tinh_trang.Copy() });

            ds.Relations.Add("TEN_TINH_TRANG", ds.Tables["DMC_TINH_TRANG"].Columns["ID"], ds.Tables["BUG"].Columns["TINH_TRANG"]);
            ds.Tables[0].Columns.Add("TEN_TT", Type.GetType("System.String"), "Parent(TEN_TINH_TRANG).NAME");
            foreach (DataRow row in ds.Tables[0].Rows)
                row["TEN_NGUOI_NHAN"] = GetNameOfRecipient(row["NGUOI_NHAN"].ToString());
            gridControlMaster.DataSource = ds.Tables[0];

            Web_Mo_Ta.DocumentText = null;
            wait.Finish();
            return null;
        }
        #endregion

        #region Step 7 : Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if(row == null)return;
            frmViewThreadIssue frm = new frmViewThreadIssue(id,HelpNumber.ParseInt64(row["NGUOI_GUI"])
                ,row["NGUOI_NHAN"].ToString(),HelpNumber.ParseInt64(row["TINH_TRANG"]));
            frm.AfterDeleteSuccessfully += delegate() {
                gridViewMaster.DeleteRow(gridViewMaster.FocusedRowHandle);
            };
            frm.AfterUpdateStatusOfIssue += delegate(long TinhTrang,object[] infos) {
                row["TINH_TRANG"] = TinhTrang;
                if (infos != null && infos.Length > 0) {
                    row["LOAI_VAN_DE"] = infos[0];
                    row["NAME"] = infos[1];
                    row["TINH_TRANG"] = infos[2];
                    row["NGAY_GUI"] = infos[3];
                    row["NGUOI_NHAN"] = infos[4];
                    row["TEN_NGUOI_NHAN"] = GetNameOfRecipient(infos[4].ToString());
                    gridViewMaster.RefreshData();
                }
            };
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        public override void ShowUpdateForm(long id)
        {
            if (DAReplyBugProduct.TThoantat(id))
            {
                HelpMsgBox.ShowNotificationMessage("Không cho phép sửa vấn đề khi tình trạng đã \"Hoàn tất\".");
                return;
            }
            else if (DAReplyBugProduct.HasReplyIssue(id))
            {
                HelpMsgBox.ShowNotificationMessage("Không cho phép sửa vấn đề khi đã có phản hồi.");
                return;
            }

            frmBugProduct fbug = new frmBugProduct(id, false);
            fbug.AfterAddIssueSuccessfully += new frmBugProduct._AfterAddIssueSuccessfully(frm_AfterAddIssueSuccessfully);
            HelpProtocolForm.ShowModalDialog(this, fbug);
        }
        public override long[] ShowAddForm()
        {
            frmBugProduct frm = new frmBugProduct(-2, true);
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }

        void frm_AfterAddIssueSuccessfully(DOBugProduct doBugProduct)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            dr["LOAI_VAN_DE"] = doBugProduct.LOAI_VAN_DE;
            dr["NGUOI_GUI"] = doBugProduct.NGUOI_GUI;
            dr["NGUOI_NHAN"] = doBugProduct.NGUOI_NHAN;
            dr["TEN_NGUOI_NHAN"] = GetNameOfRecipient(doBugProduct.NGUOI_NHAN);
            dr["NGAY_GUI"] = doBugProduct.NGAY_GUI;
            dr["TINH_TRANG"] = doBugProduct.TINH_TRANG;
            dr["NAME"] = doBugProduct.NAME;
            gridViewMaster.RefreshData();
        }

        #endregion

        #region Step 8 : Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            if (!DAReplyBugProduct.TThoantat(HelpNumber.ParseInt64(id)))
            {
                HelpMsgBox.ShowNotificationMessage("Chỉ cho phép xóa vấn đề khi tình trạng đã \"Hoàn tất\".");
                return false;
            }
            else return DABugProduct.Instance.Delete(id);
        }

        public override _Print InAction(long[] ids)
        {
            return null;
        }
        #endregion

        #region HookFocusRow
        public override void HookFocusRow()
        {
            
        }
        #endregion

        #region UpdateRow
        public override string UpdateRow()
        {
            return @"SELECT B.ID,B.NAME,NGUOI_GUI,NGUOI_NHAN,NV.NAME TEN_NGUOI_GUI,
                    NGAY_GUI,''TEN_NGUOI_NHAN,
                    MUC_UT,TINH_TRANG,MO_TA_BUG,LOAI_VAN_DE
                    FROM BUG B INNER JOIN DM_NHAN_VIEN NV ON B.NGUOI_GUI = NV.ID
                    WHERE 1=1";
        }
        public void frm_UpdateTapTin(object sender, DOLuuTruTapTin doLuuTruTapTin)
        {
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            DAReplyBugProduct.Luu_TaiLieu_TapTin(HelpNumber.ParseInt64(r["ID"]), doLuuTruTapTin.ID);
        }
        #endregion

        #region Khác

        private string GetNameOfRecipient(string RecipientIDs)
        {
            if (RecipientIDs.Length == 0) return string.Empty;
            DataRow[] rows = dtRecipient.Select(string.Format("ID in ({0})", RecipientIDs));
            StringBuilder stringName = new StringBuilder("");
            foreach (DataRow row in rows)
            {
                stringName.Append(row["NAME"].ToString());
                stringName.Append("\n");
            }
            if (stringName.Length == 0) return string.Empty;
            return stringName.ToString().Remove(stringName.ToString().LastIndexOf("\n"));
        }

        private string HTMLtoText(string HTML)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string s = reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");
        }
        private void gridViewMaster_DataSourceChanged(object sender, EventArgs e)
        {
            if (gridViewMaster.DataSource != null)
            {
                DataView dv = (DataView)gridViewMaster.DataSource;
                if (dv.Table.Rows.Count > 0)
                {
                    DataRow r = dv.Table.Rows[0];

                    Web_Mo_Ta.DocumentText = HelpByte.BytesToUTF8String((byte[])r["MO_TA_BUG"]);
                }
            }
        }

        private void gridViewThongTinLienHe_DoubleClick(object sender, EventArgs e)
        {
        }


        #endregion

        #region su kien
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            try
            {
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
                DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }

        private void rep_luu_file_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            try
            {
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
                DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }

        private void xtraTabControlDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        private void gridControlTaiLieu_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo layouthit = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
            {
                try
                {
                    if (layouthit.Column.Name == "cot_mofile")
                    {
                        toolTip1.Show("Mở tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                    }
                    if (layouthit.Column.Name == "cot_luufile")
                    {
                        toolTip1.Show("Lưu tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
            }
        }

        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        }

        #endregion
    }
}