using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using ProtocolVN.DanhMuc;
using DTO;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using ProtocolVN.App.Office;
using ProtocolVN.Plugin.TimeSheet;

namespace office
{
    public partial class frmDuAnQL : PhieuQuanLyChange1N, IFormRefresh
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //public partial class frmDuAnQL : XtraForm
        //{
        //    public DevExpress.XtraBars.BarManager barManager1;
        //    public DevExpress.XtraBars.Bar MainBar;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //    public DevExpress.XtraBars.BarDockControl barDockControlTop;
        //    public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //    public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //    public DevExpress.XtraBars.BarDockControl barDockControlRight;
        //    public DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //    public DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //    public DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //    public DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //    public DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //    public DevExpress.XtraBars.BarSubItem barSubItem1;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //    public DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //    public DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //    public DevExpress.XtraBars.PopupMenu popupMenu1;
        //    public DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //    public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //    public DevExpress.XtraGrid.GridControl gridControlMaster;
        //    public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.FIX;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDuAnQL).FullName,
                "Quản trị dự án",
                ParentID, true,
                typeof(frmDuAnQL).FullName,
                true, IsSep, "mnbToChuc.png", true, "", "");
        }
        private PhieuQuanLyFix1N Fix;
        DataSet GridDataSet = null;
        BarButtonItem item_ThemCongViec;
        BarButtonItem item_GhiNhatKyDA;
        BarButtonItem item_HoanTatDA;
        BarButtonItem item_ThemTaiLieu;

        long DA_ID = 0;
        #endregion

        #region hàm khởi tạo
        public frmDuAnQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "NAME";
            this._UsingExportToFileItem = false;
            Fix = new PhieuQuanLyFix1N(this);
            
        }
        private void frmDuAnQL_Load(object sender, EventArgs e)
        {
            HelpDebug.SetTitle(this, Status);
            _InitControl();
            gridControlThongTinLienHe.Load += new EventHandler(gridControlThongTinLienHe_Load);
            xtraTabControlDetail.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(xtraTabControlDetail_SelectedPageChanged);
            InitMRUTenDuAn();
            ngayBD.Click+=new EventHandler(ngayBD_Click); 
        }

        void ngayBD_Click(object sender, EventArgs e)
        {
            InitMRUTenDuAn();
        }

        private void InitMRUTenDuAn()
        {
            mruEditTenDuAn.Text = "";
            mruEditTenDuAn.Properties.Items.Clear();
            QueryBuilder sql = new QueryBuilder(@"SELECT NAME FROM DU_AN where 1=1");
            sql.addCondition(string.Format("((NGAY_BAT_DAU BETWEEN '{0}' AND '{1}') OR (NGAY_KET_THUC BETWEEN '{0}' AND '{1}'))", ngayBD.FromDate.ToString("MM/dd/yyyy"), ngayBD.ToDate.ToString("MM/dd/yyyy")));

            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                mruEditTenDuAn.Properties.Items.Add(row["NAME"]);
            }
        }       

        private void _InitControl()
        {
            toolTip1.BackColor = Color.LightYellow;
            DMLoaiDuAn.I.InitCtrl(LoaiDA, true, true);
            DMCMucDoUuTien.I.InitCtrl(mucuutien, false, false);
            DMCTinhTrangDuAn.Instance.InitCtrl(tintrang, false, true);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            
            tintrang._setSelectedID(-1);
        }

        void gridControlThongTinLienHe_Load(object sender, EventArgs e)
        {
            gridViewThongTinLienHe.BestFitColumns();
        }

        #endregion

        #region Step 1 : Xác định các cột sẽ hiển thị trong gridView
        public override void InitColumnMaster()
        {
            HelpGridColumn.CotTextLeft(colTen_DA, "NAME");
            HelpGridColumn.CotTextLeft(colLoaiDA, "TEN_DA");
            HelpGridColumn.CotTextLeft(colTenKhachHang, "TEN_KHACH_HANG");
            HelpGridColumn.CotTextLeft(colNguoi_QL, "TEN_NGUOI_QL");
            HelpGridColumn.CotTextLeft(colT_trang, "TEN_TT");
            HelpGridColumn.CotTextLeft(colMuc_UT, "TEN_MUC");
            XtraGridSupportExt.DateTimeGridColumn(colNgay_BD_DA, "NGAY_BAT_DAU");
            XtraGridSupportExt.DateTimeGridColumn(colNgayKT_DA_DuKien, "NGAY_KET_THUC");
            XtraGridSupportExt.DateTimeGridColumn(cotNgayKetThucTT, "NGAY_KET_THUC_THUC_TE");
            HelpGridColumn.CotTextCenter(codT_do_DA, "TIEN_DO_PT");
            //////////////////////////////////////////////
            StyleFormatCondition conditionBlue = new StyleFormatCondition();
            conditionBlue.Appearance.Options.UseForeColor = true;
            conditionBlue.Appearance.ForeColor = Color.Blue;
            conditionBlue.Condition = FormatConditionEnum.Expression;
            conditionBlue.Expression = "([NGAY_KET_THUC] >= [NGAY_KET_THUC_THUC_TE] and not(IsNull([NGAY_KET_THUC_THUC_TE]))) or(IsNull([NGAY_KET_THUC]) and not(IsNull([NGAY_KET_THUC_THUC_TE]))) ";
            conditionBlue.ApplyToRow = true;

            StyleFormatCondition conditionRed = new StyleFormatCondition();
            conditionRed.Appearance.Options.UseForeColor = true;
            conditionRed.Appearance.ForeColor = Color.Red;
            conditionRed.Condition = FormatConditionEnum.Expression;
            conditionRed.Expression = "[NGAY_KET_THUC] < [NGAY_KET_THUC_THUC_TE] and not(IsNull([NGAY_KET_THUC]))";
            conditionRed.ApplyToRow = true;

            gridViewMaster.FormatConditions.AddRange(new StyleFormatCondition[] { conditionBlue, conditionRed });

        }
        #endregion

        #region Step 2 : Xác định các cột sẽ hiển thị trong phần detail
        public override void InitColumDetail()
        {
            #region column gridViewCongViec
            gridViewThongTinLienHe.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewThongTinLienHe.OptionsView.ShowAutoFilterRow = false;
            gridViewThongTinLienHe.OptionsView.ColumnAutoWidth = true;
            gridViewCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;            
            HelpGridColumn.CotTextLeft(colCong_viec, "CONG_VIEC");
            HelpGridExt1.colMultiline(colNguoi_TH, "NV_THAM_GIA");
            HelpGridColumn.CotTextLeft(colLoaiCV, "TEN_LCV");
            HelpGridColumn.CotTextLeft(colDo_UT, "TEN_MUC_UU_TIEN");
            HelpGridColumn.CotTextLeft(colTinh_trang, "TINH_TRANG");
            HelpGridColumn.CotTextCenter(ColTien_Do, "TONG_TIEN_DO");
            HelpGridColumn.CotTextLeft(colNguoi_giao, "TEN_NGUOI_GIAO");
            XtraGridSupportExt.DateTimeGridColumn(colNgay_bat_dau, "TU_NGAY");
            XtraGridSupportExt.DateTimeGridColumn(colNgay_ket_thucDuKien, "DEN_NGAY");
            XtraGridSupportExt.DateTimeGridColumn(cotNgayKT, "NGAY_KET_THUC");
            XtraGridSupportExt.TextCenterColumn(colTG_DT, "THOI_GIAN_DU_KIEN");
            ////////////////////////////////////////////////
            StyleFormatCondition conditionBlue = new StyleFormatCondition();
            conditionBlue.Appearance.Options.UseForeColor = true;
            conditionBlue.Appearance.ForeColor = Color.Blue;
            conditionBlue.Condition = FormatConditionEnum.Expression;
            conditionBlue.Expression = "([DEN_NGAY] >= [NGAY_KET_THUC] and not(IsNull([NGAY_KET_THUC]))) or(IsNull([DEN_NGAY]) and not(IsNull([NGAY_KET_THUC]))) ";
            conditionBlue.ApplyToRow = true;

            StyleFormatCondition conditionRed = new StyleFormatCondition();
            conditionRed.Appearance.Options.UseForeColor = true;
            conditionRed.Appearance.ForeColor = Color.Red;
            conditionRed.Condition = FormatConditionEnum.Expression;
            conditionRed.Expression = "[DEN_NGAY] < [NGAY_KET_THUC] and not(IsNull([DEN_NGAY]))";
            conditionRed.ApplyToRow = true;
            gridViewThongTinLienHe.FormatConditions.AddRange(new StyleFormatCondition[] { conditionBlue, conditionRed });
            #endregion
            #region column layoutViewTaiLieu
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotTextLeft(lvSize, "SIZE");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            #endregion            
            #region Column gridGhiNhatKy
            HelpGridColumn.CotReadOnlyDate(colTGCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            HelpGridColumn.CotTextLeft(colNguoiCapNhat, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotMemoExEdit(colNoiDung, "GHI_CHU");
            HelpGrid.SetReadOnlyHaveMemoCtrl(gridViewNhatKyDA);
            #endregion          
            
        }
        #endregion               

        #region Step 3 : Xác định các control trong filter part và Khởi tạo control trong phần filter.
        public override void PLLoadFilterPart()
        {
            PLTimeSheetUtil.PermissionForControl(NhanVien, barSubItem1.Visibility == BarItemVisibility.Always, NhanVien.Visible == true);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            HelpGridExt1.SetDefaultGroupPanel(this.gridViewMaster);
            HelpGrid.SetUpperTitle(this.gridViewMaster, "DANH SÁCH DỰ ÁN");
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            gridViewMaster.OptionsView.ColumnAutoWidth = true;
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewThongTinLienHe.OptionsView.ShowGroupedColumns = false;
            this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            gridViewMaster.OptionsView.ShowFooter = true;
            HelpControl.RedCheckEdit(chkEditCV_KH, false);
            chkEditCV_KH.CheckedChanged += new EventHandler(chkEditCV_KH_CheckedChanged);
            if (barSubItem1.ItemLinks.Count > 0)
            {
                item_ThemCongViec = barSubItem1.ItemLinks[0].Item as BarButtonItem;
                item_ThemTaiLieu = barSubItem1.ItemLinks[1].Item as BarButtonItem;
                item_GhiNhatKyDA = barSubItem1.ItemLinks[2].Item as BarButtonItem;
                item_HoanTatDA = barSubItem1.ItemLinks[3].Item as BarButtonItem;
            }

        }

        void chkEditCV_KH_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditCV_KH.Checked)
            {
                colTenKhachHang.VisibleIndex = 1;
                colTenKhachHang.Visible = true;
            }
            else colTenKhachHang.Visible = false;
        }
        public override DataTable[] PLLoadDataDetailParts(long MasterID)
        {
            this.DA_ID = MasterID;
            return new DataTable[] { new DataTable() };

        }
        #endregion

        #region Step 4 : Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                new string[] { "Thêm công việc", "Thêm tài liệu","Ghi nhật ký","Hoàn tất dự án"},
                new string[] { "add.png", "add.png", "NghiepVu005.png", "fwDuyet.png" },
                "ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    Them_Cong_Viec,Them_Tai_Lieu ,NhatKyDuAn, HoanTatDuAn                  
               });
            return menu;    
        }
        private void NhatKyDuAn(List<object> ids)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            frmNhatKyDuAn nkcv = new frmNhatKyDuAn(HelpNumber.ParseInt64(dr["ID"].ToString()));
            HelpProtocolForm.ShowModalDialog(this, nkcv);
            LoadDataForSelectedTab(false);
        }
        private void HoanTatDuAn(List<object> ids)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn hoàn tất dự án đang chọn không?") == DialogResult.Yes)
            {
                DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (DADuAn.CapNhatTinhTrangDuAn(HelpNumber.ParseInt64(dr["ID"]), 5))
                {
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                    Fix.PLRefresh();
                }
            }
        }
        
        private void Them_Cong_Viec(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                Congviec frm = new Congviec(-2, true, DADuAn.Instance.GetLongNguoiThucHien(row["NGUOI_THUC_HIEN"].ToString()));
                frm.UpdateCongViec_DuAn += new Congviec.UpdateKH_DA_CV(InsertDuAn_CongViec);
                HelpProtocolForm.ShowModalDialog(this, frm);
                LoadDataForSelectedTab(false);
                decimal tiendo = 0;
                int phanTram = 0;
                DataView v = (DataView)gridViewThongTinLienHe.DataSource;
                foreach (DataRow r in v.Table.Rows)
                {
                    tiendo += (HelpNumber.ParseDecimal(r["TIEN_DO"]) * HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]));
                    phanTram += HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]);
                }
                if (phanTram > 0)
                {
                    tiendo = HelpNumber.RoundDecimal(tiendo /= phanTram, 2);
                }
                DADuAn.CapNhatTienDoDuAn(HelpNumber.ParseInt64(row["ID"]), tiendo);
                row["TIEN_DO"] = tiendo;
            }
            GridChange();
        }
        public void InsertDuAn_CongViec(long congviecID)
        {
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            DADuAn.InsertDuAn_CongViec(HelpNumber.ParseInt64(r["ID"]), congviecID);
        }        
        private void Them_Tai_Lieu(List <object>ids)
        {
            if (ids != null && ids.Count > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, HelpNumber.ParseInt64(row["ID"]), (long)LoaiTapTin.TapTinDuAn);
                HelpProtocolForm.ShowModalDialog(this, frm);
                LoadDataForSelectedTab(false);
            }
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
            try
            {
                QueryBuilder query = new QueryBuilder(UpdateRow());
                query.addID("LOAI_DU_AN", LoaiDA._getSelectedID());
                query.addID("MUC_UU_TIEN", mucuutien._getSelectedID());
                query.addID("TINH_TRANG", tintrang._getSelectedID());
                query.addID("NGUOI_QUAN_LY", NhanVien._getSelectedID());
                if (mruEditTenDuAn.Text.Trim() != "" && mruEditTenDuAn.Text.Trim() != null)
                {
                    query.addCondition(string.Format("NAME = '{0}'", mruEditTenDuAn.Text.Trim()));
                }
                query.addCondition(string.Format("((NGAY_BAT_DAU BETWEEN '{0}' AND '{1}') OR (NGAY_KET_THUC BETWEEN '{0}' AND '{1}'))", ngayBD.FromDate.ToString("MM/dd/yyyy"), ngayBD.ToDate.ToString("MM/dd/yyyy")));
                //Chỉ hiển thị loại dự án có "VISIBLE_BIT" = 'Y'
                query.addCondition("LOAI_DU_AN IN (SELECT ID FROM DM_LOAI_DU_AN WHERE VISIBLE_BIT = 'Y')");
                GridDataSet = HelpDB.getDatabase().LoadDataSet(query,"GridDataSet");
                DataTable Bang_uu_tien = DAYeuCau.Bang_uu_tien_new();
                DataTable Bang_tinh_trang = DAYeuCau.Bang_tinh_trang_DA_new();
                GridDataSet.Tables.AddRange(new DataTable[] { Bang_uu_tien, Bang_tinh_trang });
                GridDataSet.Relations.Add("MUC_UU_TIEN", Bang_uu_tien.Columns["ID"], GridDataSet.Tables[0].Columns["MUC_UU_TIEN"]);
                GridDataSet.Tables[0].Columns.Add("TEN_MUC", Type.GetType("System.String"), "Parent(MUC_UU_TIEN).NAME");
                GridDataSet.Relations.Add("TEN_TINH_TRANG", Bang_tinh_trang.Columns["ID"], GridDataSet.Tables[0].Columns["TINH_TRANG"]);
                GridDataSet.Tables[0].Columns.Add("TEN_TT", Type.GetType("System.String"), "Parent(TEN_TINH_TRANG).NAME");
                foreach (DataRow row in GridDataSet.Tables[0].Rows)
                {
                    decimal tiendo = 0;
                    int phanTram = 0;
                    DataTable v = DADuAn.LoadCongViec(HelpNumber.ParseInt64(row["ID"]));
                    foreach (DataRow r in v.Rows)
                    {
                        tiendo += (HelpNumber.ParseDecimal(r["TIEN_DO"]) * HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]));
                        phanTram += HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]);
                    }
                    if (phanTram > 0)
                    {
                        tiendo = HelpNumber.RoundDecimal(tiendo /= phanTram, 2);
                    }
                ////Hieutn: Lưu lại tiến độ khi thay đổi từ form công việc
                    DADuAn.CapNhatTienDoDuAn(HelpNumber.ParseInt64(row["ID"]), tiendo);
                    row["TIEN_DO_PT"] =DADuAn.LayTienDo(HelpNumber.ParseInt64(row["ID"]));
                }
                gridControlMaster.DataSource = GridDataSet.Tables[0];
                this.splitContainerControl1.SplitterPosition = 145;

                wait.Finish();
                return null;
            }
            catch {
                return null;
            }
        }
        
        #endregion

        #region Step 7 : Xác định các form xử lý khi chọn Thêm, Xem , Sửa
        public override void ShowViewForm(long id)
        {       
            frmDuAn f = new frmDuAn(id, null);
            HelpProtocolForm.ShowDialog(this, f);            
        }
        public override void ShowUpdateForm(long id)
         {
            frmDuAn f = new frmDuAn(id, false);
            HelpProtocolForm.ShowModalDialog(this, f);

            decimal tiendo = 0;
            int phanTram = 0;
            DataTable v = DADuAn.LoadCongViec(id);
            foreach (DataRow r in v.Rows)
            {
                tiendo += (HelpNumber.ParseDecimal(r["TIEN_DO"]) * HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]));
                phanTram += HelpNumber.ParseInt32(r["TONG_PHAN_TRAM_CV"]);
            }
            if (phanTram > 0)
            {
                tiendo = HelpNumber.RoundDecimal(tiendo /= phanTram, 2);
            }
            ////Hieutn: Lưu lại tiến độ khi thay đổi từ form công việc
            DADuAn.CapNhatTienDoDuAn(id, tiendo);
        }
        public override long[] ShowAddForm()
        {           
            frmDuAn frm = new frmDuAn();
            HelpProtocolForm.ShowModalDialog(this, frm);            
            return null;
        }
        public void RefreshAfterInsert()
        {
            Fix.PLRefresh();
        }
        #endregion

        #region Step 8 : Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            if (!DADuAn.tinhTrangChoXoa(id)){
                HelpMsgBox.ShowNotificationMessage("Dự án có tình trạng là \"Đang xử lý\" hoặc \"Hoàn thành\" thì không cho phép xóa!");
                return false;
            }
            else
            {
                if (DADuAn.exists_ds_congviec(id) || DADuAn.exists_ds_tailieu(id)){
                    HelpMsgBox.ShowNotificationMessage("Đã có \"Phân công công việc\" hoặc \"Tập tin\" cho dự án, không cho phép xóa!");
                    return false;
                }
                else return DADuAn.Instance.Delete(id);
            }
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        #endregion     

        #region HookFocusRow
        public override void HookFocusRow()
        {
            gridControlThongTinLienHe.DataSource = gridControlTaiLieu.DataSource = gridControlNhatKyDA.DataSource = null;
            LoadDataForSelectedTab(false);
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            item_ThemCongViec.Enabled = false;
            item_ThemTaiLieu.Enabled = false;
            item_GhiNhatKyDA.Enabled = false;
            item_HoanTatDA.Enabled = false;

            bool i = DADuAn.check_TrinhTrang_isHoanThanh(HelpNumber.ParseInt64(r["ID"]));
            if (i == true)
            {
                barButtonItemUpdate.Enabled = false;
                barButtonItemDelete.Enabled = false;
            }
            else
                GridChange();
        }
        private void GridChange()
        {            
            DataRow r = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            long ID = HelpNumber.ParseInt64(r["NGUOI_QUAN_LY"]);
            string id_NTH = r["NGUOI_THUC_HIEN"].ToString();
            string[] arr = id_NTH.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == FrameworkParams.currentUser.employee_id.ToString())
                {
                    item_GhiNhatKyDA.Enabled = true;
                    item_ThemTaiLieu.Enabled = true;
                }
            }
            if (ID == FrameworkParams.currentUser.employee_id)
            {
                barButtonItemUpdate.Enabled = true;
                barButtonItemDelete.Enabled = true;
                if (HelpNumber.ParseInt64(r["TIEN_DO"]) == 100)
                {                    
                    item_HoanTatDA.Enabled = true;                    
                }
                item_ThemCongViec.Enabled = true;
            }
            else
            {
                barButtonItemUpdate.Enabled = false;
                barButtonItemDelete.Enabled = false;
            }
            DataTable v = DADuAn.LoadCongViec(HelpNumber.ParseInt64(r["ID"]));
            foreach (DataRow ro in v.Rows)
            {
                long id = HelpNumber.ParseInt64(ro["ID_TT"]);
                if (id != 4)
                {
                    item_HoanTatDA.Enabled  = false;
                    break;
                }
            }  
        }
        #endregion
        
        #region UpdateRow
        public override string UpdateRow()
        {
            string chuoi = @"SELECT DISTINCT ID,NAME,B.NGUOI_QUAN_LY,B.NGUOI_THUC_HIEN,KH_DA_CV.KH_ID,
                    (SELECT NAME FROM DM_NHAN_VIEN NV WHERE NV.ID=B.NGUOI_QUAN_LY) TEN_NGUOI_QL,
                    (SELECT NAME FROM DM_LOAI_DU_AN DA WHERE DA.ID=B.LOAI_DU_AN) TEN_DA,
                    (SELECT TEN_KHACH_HANG FROM KHACH_HANG KH WHERE KH.KH_ID=KH_DA_CV.KH_ID) TEN_KHACH_HANG,
                    NGAY_BAT_DAU,NGAY_KET_THUC,NGAY_KET_THUC_THUC_TE,
                    MUC_UU_TIEN,TIEN_DO,TINH_TRANG,TIEN_DO || '%' TIEN_DO_PT
                    FROM DU_AN B LEFT JOIN KH_DA_CV ON (KH_DA_CV.DU_AN_ID = B.ID AND KH_DA_CV.KH_ID IS NOT NULL) WHERE 1=1";
            if (LoaiCV._getSelectedID() > 0)
                chuoi = @"SELECT DISTINCT ID,NAME,B.NGUOI_QUAN_LY,B.NGUOI_THUC_HIEN,KH_DA_CV.KH_ID,
                    (SELECT NAME FROM DM_NHAN_VIEN NV WHERE NV.ID=B.NGUOI_QUAN_LY) TEN_NGUOI_QL,
                    (SELECT NAME FROM DM_LOAI_DU_AN DA WHERE DA.ID=B.LOAI_DU_AN) TEN_DA,
                    (SELECT TEN_KHACH_HANG FROM KHACH_HANG KH WHERE KH.KH_ID=KH_DA_CV.KH_ID) TEN_KHACH_HANG,
                    NGAY_BAT_DAU,NGAY_KET_THUC,
                    MUC_UU_TIEN,TINH_TRANG,TIEN_DO,TIEN_DO || '%' TIEN_DO_PT
                    FROM DU_AN B LEFT JOIN KH_DA_CV ON (KH_DA_CV.DU_AN_ID = B.ID AND KH_DA_CV.KH_ID IS NOT NULL)
                    WHERE EXISTS(SELECT * FROM KH_DA_CV CVDA,PHAN_CONG_CONG_VIEC CV WHERE B.ID = CVDA.DU_AN_ID AND CVDA.PCCV_ID = CV.PCCV_ID AND CV.LCV_ID='" + LoaiCV._getSelectedID() + "') AND 1=1";
            return chuoi;
        }
        #endregion

        #region Sự kiện trên form & Grid công việc
        private void gridViewThongTinLienHe_DoubleClick(object sender, EventArgs e)
        {
            GuiMail mail = new GuiMail();
            DataRow drow = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            PLGridView grid = (PLGridView)sender;
            if (grid.RowCount <= 0) return;
            else if (!grid.IsGroupRow(grid.FocusedRowHandle))
            {
                FWWaitingMsg m = new FWWaitingMsg();
                string str = drow["NGUOI_THUC_HIEN"].ToString();
                Congviec obj = new Congviec(HelpNumber.ParseInt64(grid.GetDataRow(grid.FocusedRowHandle)["PCCV_ID"]), null, mail.GetLongNguoiThucHien(str));
                m.Finish();
                HelpProtocolForm.ShowModalDialog(this, obj);
                gridControlThongTinLienHe.DataSource = DADuAn.LoadCongViec(HelpNumber.ParseInt64(drow["ID"]));
            }
        }        
        private void LoaiDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Drawing.Size size = LoaiCV.MainCtrl.Size;
            if (LoaiDA._getSelectedID() != -1)
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet("SELECT DISTINCT CVN.ID,CVN.NAME FROM PHAN_CONG_CONG_VIEC CV, KH_DA_CV CVDA,DM_LOAI_CONG_VIECN CVN WHERE CVDA.DU_AN_ID IN(SELECT ID FROM DU_AN WHERE LOAI_DU_AN='" + LoaiDA._getSelectedID() + "') AND CVDA.PCCV_ID=CV.PCCV_ID AND CVN.ID=CV.LCV_ID");
                LoaiCV._init(ds.Tables[0], "NAME", "ID");
                LoaiCV.Enabled = true;
            }
            else {
                LoaiCV._setSelectedID(-1);
                LoaiCV.Enabled = false;
            }
            LoaiCV.MainCtrl.Size = size;

        }

        void xtraTabControlDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadDataForSelectedTab(true);
        }

        #endregion 

        #region sự kiện trên layout       

        private void gridControlTaiLieu_Click(object sender, EventArgs e)
        {
            DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            if (r != null)
            {
                LayoutViewHitInfo gHitInfo = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
                if (gHitInfo.Column == null) return;   
                if (gHitInfo.Column.FieldName == "TEN_FILE")//Nếu cell được click thuộc _columnField
                    {
                        FWWaitingMsg m = new FWWaitingMsg();
                        frmSaveOpen frm = new frmSaveOpen(DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(layoutView1.GetDataRow(layoutView1.FocusedRowHandle)["ID"])).NOI_DUNG, layoutView1.GetDataRow(layoutView1.FocusedRowHandle)["TEN_FILE"].ToString());
                        m.Finish();
                        HelpProtocolForm.ShowModalDialog(this, frm);
                    }
                
            }
        }
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }

        private void rep_luu_file_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }

        private void gridControlTaiLieu_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo layouthit = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
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
        }
        private void LoadGridViewTaiLieu(long object_id)
        {
            try
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet(@"SELECT LTTT.*,(SELECT NAME FROM DM_NHAN_VIEN WHERE ID = LTTT.NGUOI_CAP_NHAT) TEN_NGUOI_CN 
                FROM LUU_TRU_TAP_TIN LTTT WHERE LTTT.ID IN(SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE TYPE_ID=7 AND OBJECT_ID='" + object_id + "')");
                ds.Tables[0].Columns.Add("mo_file", typeof(Image));
                ds.Tables[0].Columns.Add("luu_file", typeof(Image));
                ds.Tables[0].Columns.Add("SIZE", typeof(String));
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    r["mo_file"] = FWImageDic.VIEW_IMAGE20;
                    r["luu_file"] = FWImageDic.SAVE_IMAGE20;
                    byte[] a = r["NOI_DUNG"] as byte[];
                    r["SIZE"] = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal(a.Length) / 1024, 3).ToString();
                }
                gridControlTaiLieu.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
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

        #region Extensions
        private void LoadDataForSelectedTab(bool isTabChanged)
        {
            switch (xtraTabControlDetail.SelectedTabPageIndex) { 
                case 0:
                    if (isTabChanged && gridControlThongTinLienHe.DataSource == null)
                    {
                        gridControlThongTinLienHe.DataSource = DADuAn.LoadCongViec(DA_ID);
                    }
                    if (!isTabChanged)
                    {
                        gridControlThongTinLienHe.DataSource = DADuAn.LoadCongViec(DA_ID);
                        
                    }
                    break;
                case 1:
                    if(isTabChanged && gridControlTaiLieu.DataSource == null)
                        LoadGridViewTaiLieu(DA_ID);
                    if (!isTabChanged) LoadGridViewTaiLieu(DA_ID);
                    break;
                default:
                    if (isTabChanged && gridControlNhatKyDA.DataSource == null)
                        gridControlNhatKyDA.DataSource = DADuAn.GetNhatKyDA(DA_ID);
                    if (!isTabChanged) gridControlNhatKyDA.DataSource = DADuAn.GetNhatKyDA(DA_ID);
                    break;
            }
        }
        #endregion
    }
}
