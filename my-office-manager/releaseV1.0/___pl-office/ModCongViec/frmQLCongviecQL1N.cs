using System;
using System.Data;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.DanhMuc;
using System.Windows.Forms;
using ProtocolVN.App.Office;
using System.Collections.Generic;
using DevExpress.XtraBars;
using System.Drawing;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DTO;
using System.IO;
using ProtocolVN.Framework.Win.Trial;
using ProtocolVN.Plugin.TimeSheet;
using System.Text;

namespace office
{

    public partial class frmQLCongviecQL1N : PhieuQuanLyChange1N, IFormRefresh
    {
    //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
    //public partial class frmQLCongviecQL1N : XtraFormPL
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
            return MenuBuilder.CreateItem(typeof(frmQLCongviecQL1N).FullName,
                "Quản trị công việc",
                ParentID, true,
                typeof(frmQLCongviecQL1N).FullName,
                true, IsSep, "pl-businessman.png", true, "", "");
        }
        public delegate void RefreshPhanCongCV();
        public RefreshPhanCongCV RefreshData;
        private PhieuQuanLyFix1N Fix;
        ToolTip toolTip1 = new ToolTip();
        DataSet GridDataSet = null;
        DataTable tableProjectName, tableCustomerName;
        long masterID = 0;
        BarButtonItem item_CapNhatTienDo;
        BarButtonItem item_ThemTaiLieu;
        BarButtonItem item_GhiNhatKy;
        BarButtonItem item_HoanTatCongViec;
        #endregion

        #region hàm khởi tạo
        public frmQLCongviecQL1N()
        {
            InitializeComponent();
            this.IDField = "PCCV_ID";
            this.DisplayField = "CONG_VIEC";
            this._UsingExportToFileItem = false;
            Fix = new PhieuQuanLyFix1N(this);
            this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        private void frmQLCongviecQL1N_Load(object sender, EventArgs e)
        {
            Tinhtrang.AutoSize = true;

            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            PLTimeSheetUtil.PermissionForControl(NhanVien, barSubItem1.Visibility == BarItemVisibility.Always, NhanVien.Visible == true);
            AppCtrl.InitTreeChonNhanVien(NguoiThucHien, false, false);
            NguoiThucHien.Enabled = NhanVien.Enabled;
            NguoiThucHien._SelectedIDs = new long[] { FrameworkParams.currentUser.employee_id };
            
            this.barbuttonCapNhatTienDo.Enabled = false;
            barbuttonCapNhatTienDo.Glyph = FWImageDic.CONFIG_IMAGE16;
            barbuttonCapNhatTienDo.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;

            this.barButtonNhatKyCongViec.Enabled = false;
            barButtonNhatKyCongViec.Glyph = FWImageDic.CONFIG_IMAGE16;
            barButtonNhatKyCongViec.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;

            gridControlMaster.Load += new EventHandler(gridControlMaster_Load);

            gridViewMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewMaster_FocusedRowChanged);
            this.splitContainerControl1.Panel1.MinSize = 50;
            rep_luufile.Click += new EventHandler(rep_luu_file_Click);
            rep_mofile.Click+=new EventHandler(rep_mofile_Click);
            toolTip1.BackColor = Color.LightYellow;
            InitMRUEditTenCongViec();
            ngayLamViec.Click+=new EventHandler(ngayLamViec_Click); 
        }

        void ngayLamViec_Click(object sender, EventArgs e)
        {
            InitMRUEditTenCongViec();
        }

        private void InitMRUEditTenCongViec()
        {
            mruEditTenCongViec.Text = "";
            mruEditTenCongViec.Properties.Items.Clear();
            QueryBuilder sql = new QueryBuilder(@"SELECT CONG_VIEC FROM PHAN_CONG_CONG_VIEC where 1=1");
            sql.addDateFromTo("NGAY_BAT_DAU", ngayLamViec.FromDate, ngayLamViec.ToDate);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                mruEditTenCongViec.Properties.Items.Add(row["CONG_VIEC"]);
            }            
        }

        void xtraTabControlDetail_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            LoadDataForSelectedTab(true);
        }

        void gridControlThongTinLienHe_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
        {
            gridViewThongTinLienHe.BestFitColumns();
        }

        void gridControlMaster_Load(object sender, EventArgs e)
        {
            gridViewMaster.BestFitColumns();
        }
        #endregion

        #region Step 1 : Xác định các cột sẽ hiển thị trong gridView
        public override void InitColumnMaster()
        {
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewMaster.OptionsView.ColumnAutoWidth = true;
            gridViewThongTinLienHe.OptionsView.ColumnAutoWidth = true;

            gridViewMaster.OptionsSelection.MultiSelect = false;
            HelpGridColumn.CotTextLeft(CotCongViec, "CONG_VIEC");
            HelpGridExt1.colMultiline(CotNguoiThucHien, "NV_THAM_GIA");
            HelpGridColumn.CotTextLeft(CotTenDuAn, "TEN_DU_AN");
            HelpGridColumn.CotTextLeft(CotKhachHang, "TEN_KHACH_HANG");
            CotTenDuAn.Visible = false;
            CotKhachHang.Visible = false;
            CotNgayKetThucDuKien.Visible = false;
            HelpGridColumn.CotTextLeft(CotLoaiCongViec, "TEN_LCV");
            HelpGridColumn.CotTextCenter(CotDouutien, "TEN_MUC_UU_TIEN");
            HelpGridColumn.CotCombobox(CotTinhtrang,HelpDB.getDBService().LoadTable("DM_TINH_TRANG"),"ID","NAME","TINH_TRANG_ID");
            HelpGridColumn.CotTextRight(CotTienDo, "TONG_TIEN_DO");
            HelpGridColumn.CotTextLeft(Cotnguoigiao, "TEN_NGUOI_GIAO");
            XtraGridSupportExt.DateTimeGridColumn(Cotbatdau, "TU_NGAY");
            XtraGridSupportExt.DateTimeGridColumn(CotNgayKetThucDuKien, "DEN_NGAY");//ngay kt du kien
            XtraGridSupportExt.DateTimeGridColumn(Cotngayketthuc, "NGAY_KET_THUC");
            XtraGridSupportExt.TextCenterColumn(CotTGdutinh, "THOI_GIAN_DU_KIEN");
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            //////////////////////////////////////
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

            gridViewMaster.FormatConditions.AddRange(new StyleFormatCondition[] { conditionBlue, conditionRed  });
        }
        #endregion

        #region Step 2 : Xác định các cột sẽ hiển thị trong phần detail
        public override void InitColumDetail()
        {
            gridViewCTTD_ThucHien.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewCTTD_ThucHien.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewCTTD_ThucHien.OptionsBehavior.Editable = false;
            HelpGridColumn.CotTextLeft(colDetailNguoiThucHien, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotTextRight(colDetailMDThamGia, "PHAN_TRAM_THAM_GIA");
            HelpGridColumn.CotTextRight(colDetailTienDo, "TIEN_DO");
            HelpGridColumn.CotPLTimeEdit(colDetailTGCapNhat, "THOI_GIAN_CAP_NHAT");
            #region tiến dộ công việc
            gridViewThongTinLienHe.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            gridViewThongTinLienHe.OptionsBehavior.Editable = false;
            HelpGridColumn.CotTextLeft(colNguoiThucHien, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotPLTimeEdit(colNgayCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            HelpGridColumn.CotTextRight(colTienDoThucHien, "TIEN_DO");
            HelpGridColumn.CotMemoExEdit(colGhiChu, "GHI_CHU");
            HelpGrid.SetReadOnlyHaveMemoCtrl(gridViewThongTinLienHe);
            #endregion
            #region column layoutViewTaiLieu
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            XtraGridSupportExt.TextLeftColumn(lvSize, "SIZE");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            lvSize.OptionsColumn.AllowEdit = false;
            lvSize.OptionsColumn.AllowFocus = false;
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
            HelpGrid.SetReadOnlyHaveMemoCtrl(gridViewNhatKyCV);
            #endregion 
        }
        #endregion

        #region Step 3 : Xác định các control trong filter part và Khởi tạo control trong phần filter.
        public override void PLLoadFilterPart()
        {
            LoaiCV._init(DACongViec.chonLoaiCongViec(null), "NAME", "ID");
            DACongViec.ChonTinhTrang_Cbx(Tinhtrang, false);
            DMCMucDoUuTien.I.InitCtrl(cmbDoUuTien, false, true);
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
            ngayLamViec.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            HelpControl.RedCheckEdit(chkEditCV_DA, false);
            HelpControl.RedCheckEdit(chkEditCV_KH, false);
            HelpControl.RedCheckEdit(chekEditNgayKTDK, false);

            chkEditCV_KH.CheckedChanged += new EventHandler(chkEditCV_KH_CheckedChanged);
            chekEditNgayKTDK.CheckedChanged += new EventHandler(chekEditNgayKTDK_CheckedChanged);
            NguoiThucHien.popupContainerControl1.Width = 270;
        }

        void chekEditNgayKTDK_CheckedChanged(object sender, EventArgs e)
        {
            if (chekEditNgayKTDK.Checked)
            {
                CotNgayKetThucDuKien.Visible = true;
                if (chkEditCV_DA.Checked && chkEditCV_KH.Checked)
                    CotNgayKetThucDuKien.VisibleIndex = 7;
                else {
                    if (!chkEditCV_DA.Checked && !chkEditCV_KH.Checked) CotNgayKetThucDuKien.VisibleIndex = 5;
                    else CotNgayKetThucDuKien.VisibleIndex = 6;
                }
            }
            else
                CotNgayKetThucDuKien.Visible = false;
        }

        void chkEditCV_KH_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditCV_KH.Checked)
            {

                CotKhachHang.Visible = true;
                if (chkEditCV_DA.Checked) CotKhachHang.VisibleIndex = 2;
                else CotKhachHang.VisibleIndex = 1;
            }
            else CotKhachHang.Visible = false;
        }
        #endregion

        #region Step 4 : Cài đặt menu
        _MenuItem menu;
        public override _MenuItem GetBusinessMenuList()
        {
            menu = new _MenuItem(
                new string[] { "Cập nhật tiến độ","Thêm tài liệu", "Ghi nhật ký","Hoàn tất công việc" },
                new string[] { "mnbDSoBanHang.png", "add.png", "NghiepVu005.png", "fwDuyet.png" },
                "PCCV_ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    CapnhatTienDo,ThemTaiLieu,NhatKyCongViec,HoanTatCongViec                    
               });
            return menu; 
        }
        private void CapnhatTienDo(List<object> ids)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            frmCapNhatTienDo cntd = new frmCapNhatTienDo(HelpNumber.ParseInt64(dr["PCCV_ID"].ToString()));
            HelpProtocolForm.ShowModalDialog(this, cntd);
            dr["TONG_TIEN_DO"] = Capnhattiendo(HelpNumber.ParseInt64(dr["PCCV_ID"]));
            LoadDataForSelectedTab(false);
        }
        private decimal Capnhattiendo(long ID_CV)
        {
            string sql = string.Format(@"SELECT C.PCCV_ID,PHAN_TRAM_THAM_GIA,MAX(TIEN_DO) TIEN_DO,T.TONG_PHAN_TRAM
                            FROM CHI_TIET_PHAN_CONG C,
                            (SELECT PCCV_ID,SUM(PHAN_TRAM_THAM_GIA) TONG_PHAN_TRAM
                                FROM CHI_TIET_PHAN_CONG WHERE TIEN_DO = 0 GROUP BY PCCV_ID) T
                                    WHERE TIEN_DO > 0 AND T.PCCV_ID = C.PCCV_ID AND T.PCCV_ID = {0} AND
                                    C.THOI_GIAN_CAP_NHAT IN (SELECT MAX(CT.THOI_GIAN_CAP_NHAT) FROM CHI_TIET_PHAN_CONG CT WHERE CT.PCCV_ID=T.PCCV_ID GROUP BY CT.MA_NV)
                                          GROUP BY C.PCCV_ID,C.MA_NV,PHAN_TRAM_THAM_GIA,T.TONG_PHAN_TRAM", ID_CV);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            DataRow[] arrRow = ds.Tables[0].Select("1=1");
            decimal tongTienDo = 0;
            foreach (DataRow row in arrRow)
                tongTienDo += (HelpNumber.ParseInt64(row["TIEN_DO"]) * HelpNumber.ParseInt64(row["PHAN_TRAM_THAM_GIA"]));
            if (arrRow.Length > 0) tongTienDo /= HelpNumber.ParseInt64(arrRow[0]["TONG_PHAN_TRAM"]);
            return HelpNumber.RoundDecimal(tongTienDo, 2);
        }
        private void ThemTaiLieu(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, HelpNumber.ParseInt64(row["PCCV_ID"]), (long)LoaiTapTin.TapTinCongViec);
                HelpProtocolForm.ShowModalDialog(this, frm);
                LoadDataForSelectedTab(false);
            }
        }
        private void NhatKyCongViec(List<object> ids)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            frmNhatKyCongViec nkcv = new frmNhatKyCongViec(HelpNumber.ParseInt64(dr["PCCV_ID"].ToString()));
            HelpProtocolForm.ShowModalDialog(this, nkcv);
            LoadNhatKy(HelpNumber.ParseInt64(dr["PCCV_ID"]));
        }
        private void HoanTatCongViec(List<object> ids)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn hoàn tất công việc đang chọn không?") == DialogResult.Yes)
            {
                DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (DACongViec.CapNhatTinhTrangCongViec(HelpNumber.ParseInt64(dr["PCCV_ID"]), 4))
                {
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                    Fix.PLRefresh();
                }
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
            //Viết theo cách này không áp dụng tìm kiếm nâng cao được
            QueryBuilder query = new QueryBuilder(UpdateRow());
            query.addID("PC.LCV_ID", LoaiCV._getSelectedID());
            if (mruEditTenCongViec.Text.Trim() != "" && mruEditTenCongViec.Text.Trim() != null)
            {
                query.addCondition(string.Format("PC.CONG_VIEC = '{0}'", mruEditTenCongViec.Text.Trim()));
            }
            StringBuilder cond = new StringBuilder("");
            if (NhanVien._getSelectedID() != -1) cond.Append(string.Format("NGUOI_GIAO = {0}", NhanVien._getSelectedID()));
            long [] NTH_ID=NguoiThucHien._SelectedIDs;
            if (NTH_ID.Length > 0 && cond.Length > 0) cond.Append(" OR ");
            int temp = NTH_ID.Length;
            foreach (long id in NTH_ID)
            {
                cond.Append("CT.MA_NV = " + id + "");
                temp--;
                if (temp > 0)
                {
                    cond.Append(" OR ");
                }
            }
            if (cond.Length > 0)
            {
                query.addCondition(cond.ToString());
            }
            query.addID("TINH_TRANG", Tinhtrang._getSelectedID());
            query.addID("MUC_UU_TIEN", cmbDoUuTien._getSelectedID());
            query.setDescOrderBy("PC.NGAY_BAT_DAU");
            query.addDateFromTo("PC.NGAY_BAT_DAU", ngayLamViec.FromDate, ngayLamViec.ToDate);
            GridDataSet = HelpDB.getDatabase().LoadDataSet(query);
            GridDataSet.Tables[0].Columns.Add("NV_THAM_GIA");
            //DataSet dùng cho việc tính tiến độ công việc
            string sql = @"SELECT C.PCCV_ID,PHAN_TRAM_THAM_GIA,MAX(TIEN_DO) TIEN_DO,T.TONG_PHAN_TRAM
                            FROM CHI_TIET_PHAN_CONG C,
                            (SELECT PCCV_ID,SUM(PHAN_TRAM_THAM_GIA) TONG_PHAN_TRAM
                                FROM CHI_TIET_PHAN_CONG WHERE TIEN_DO = 0 GROUP BY PCCV_ID) T
                                    WHERE TIEN_DO > 0 AND T.PCCV_ID = C.PCCV_ID AND
                                    C.THOI_GIAN_CAP_NHAT IN (SELECT MAX(CT.THOI_GIAN_CAP_NHAT) FROM CHI_TIET_PHAN_CONG CT WHERE CT.PCCV_ID=T.PCCV_ID GROUP BY CT.MA_NV)
                                          GROUP BY C.PCCV_ID,C.MA_NV,PHAN_TRAM_THAM_GIA,T.TONG_PHAN_TRAM";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);

            foreach (DataRow dr in GridDataSet.Tables[0].Rows)
            {
                String ten = "";
                String sqlString = "SELECT CT.MA_NV, NV.NAME, CT.PHAN_TRAM_THAM_GIA FROM CHI_TIET_PHAN_CONG CT, DM_NHAN_VIEN NV WHERE CT.MA_NV = NV.ID AND CT.PCCV_ID = " + dr["PCCV_ID"].ToString() + " GROUP BY MA_NV,NAME, PHAN_TRAM_THAM_GIA";
                DataTable dt = HelpDB.getDatabase().LoadDataSet(sqlString).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (ten == "")
                        ten = ten + row["NAME"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                    else
                        ten = ten + "\n" + row["NAME"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                }
                dr["NV_THAM_GIA"] = ten;
                //Tính giá trị cho cột tính độ dựa vào DataSet (ds) ở trên
                long tam=HelpNumber.ParseInt64(dr["PCCV_ID"]);
                DataRow[] arrRow = ds.Tables[0].Select(string.Format("PCCV_ID = {0}", HelpNumber.ParseInt64(dr["PCCV_ID"])));
                decimal tongTienDo = 0;
                foreach (DataRow row in arrRow)
                    tongTienDo += (HelpNumber.ParseInt64(row["TIEN_DO"]) * HelpNumber.ParseInt64(row["PHAN_TRAM_THAM_GIA"]));
                if (arrRow.Length > 0) HelpNumber.RoundDecimal(tongTienDo /= HelpNumber.ParseInt64(arrRow[0]["TONG_PHAN_TRAM"]),2);
                dr["TONG_TIEN_DO"] = tongTienDo.ToString() + "%";
            }
            try
            {
                if (GridDataSet != null && GridDataSet.Tables[0].Rows.Count > 0)
                {
                    gridControlMaster.DataSource = GridDataSet.Tables[0];
                    splitContainerControl1.SplitterPosition = 171;
                }
                else
                {
                    gridControlMaster.DataSource = null;
                }
            }
            catch
            {}
            wait.Finish();
            return null;
        }
        #endregion

        #region Step 6: HookFocusRow
        public override void HookFocusRow()
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (dr == null) return;
            if (dr["TINH_TRANG_ID"].ToString() == "4")
            {
                barButtonItemUpdate.Enabled = false;
                this.barSubItem1.Enabled = false;
                barButtonItemDelete.Enabled = false;
            }
            else
            {
                barButtonItemUpdate.Enabled = true;
                this.barSubItem1.Enabled = true;
                barButtonItemDelete.Enabled = true;

            }
            gridControlCTTD_ThucHien.DataSource = gridControlNhatKyCV.DataSource = gridControlTaiLieu.DataSource = gridControlThongTinLienHe.DataSource = null;
            LoadDataForSelectedTab(false);
        }
        void gridViewMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (dr == null) return;
            string sqlString = @"sELECT CT.MA_NV, NV.NAME FROM CHI_TIET_PHAN_CONG CT, 
            DM_NHAN_VIEN NV WHERE CT.MA_NV = NV.ID AND CT.PCCV_ID = "
                + dr["PCCV_ID"].ToString() + "aND CT.MA_NV=" + FrameworkParams.currentUser.employee_id + " group by ma_nv,NAME";
            DataTable dt = HelpDB.getDatabase().LoadDataSet(sqlString).Tables[0];
            if (barSubItem1.ItemLinks.Count > 0)
            {
                item_CapNhatTienDo = barSubItem1.ItemLinks[0].Item as BarButtonItem;
                item_ThemTaiLieu = barSubItem1.ItemLinks[1].Item as BarButtonItem;
                item_GhiNhatKy = barSubItem1.ItemLinks[2].Item as BarButtonItem;
                item_HoanTatCongViec = barSubItem1.ItemLinks[3].Item as BarButtonItem;
            }
            for (int i = 0; i < barSubItem1.ItemLinks.Count; i++)
            {
                if (dt.Rows.Count > 0)
                {
                    item_CapNhatTienDo.Enabled = true;
                    item_ThemTaiLieu.Enabled = true;
                    item_GhiNhatKy.Enabled = true;
                }
                else
                {
                    item_CapNhatTienDo.Enabled = false;
                    item_ThemTaiLieu.Enabled = false;
                    item_GhiNhatKy.Enabled = false;

                }
                if (dr["NGUOI_GIAO"].ToString() == FrameworkParams.currentUser.employee_id.ToString() && dr["TONG_TIEN_DO"].ToString() == "100%")
                {
                    item_HoanTatCongViec.Enabled = true;
                }
                else
                {
                    item_HoanTatCongViec.Enabled = false;
                }
                break;
            }
        }
        #endregion

        #region Step 7 : Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            Congviec obj = new Congviec(id, null);
            HelpProtocolForm.ShowModalDialog(this, obj);
            gridViewMaster.SelectRow(gridViewMaster.FocusedRowHandle);
        }
        public override void ShowUpdateForm(long id)
        {
            Congviec obj = new Congviec(id, false);
            obj.RefreshAfterInsert += new Congviec.RefreshData(RefreshDataAfterInsert);
            HelpProtocolForm.ShowModalDialog(this, obj);            
        }
        public void RefreshDataAfterInsert(DOPhanCongCongViec doPhanCongCV, string nguoiThucHien, string tienDo)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            dr["TEN_LCV"] = DACongViec.getTenLoaiCV(doPhanCongCV.LCV_ID);
            dr["TU_NGAY"] = doPhanCongCV.NGAY_BAT_DAU;
            if (doPhanCongCV.NGAY_KET_THUC_DU_KIEN != null)
            {
                dr["DEN_NGAY"] = doPhanCongCV.NGAY_KET_THUC_DU_KIEN;
            }
            else
            {
                dr["DEN_NGAY"] = DBNull.Value;
            }

            if (doPhanCongCV.IS_NGAY == "Y")
            {                
                string a =HelpNumber.RoundDecimal(doPhanCongCV.THOI_GIAN_DU_KIEN.Value * 8 + HelpNumber.ParseDecimal(0.01),1) + " Giờ";
                string b = a.Replace(',', '.');
                dr["THOI_GIAN_DU_KIEN"] = b;
            }
            else
            {
                string a = HelpNumber.RoundDecimal(doPhanCongCV.THOI_GIAN_DU_KIEN.Value + HelpNumber.ParseDecimal(0.01), 1) + " Giờ";
                string b = a.Replace(',', '.');
                dr["THOI_GIAN_DU_KIEN"] = b;
            }
            dr["CONG_VIEC"] = doPhanCongCV.CONG_VIEC;
            dr["NGUOI_GIAO"] = doPhanCongCV.NGUOI_GIAO;
            dr["TINH_TRANG"] = DACongViec.getTinhTrang(doPhanCongCV.TINH_TRANG);
            dr["TEN_MUC_UU_TIEN"] = DACongViec.getMucUuTien(doPhanCongCV.MUC_UU_TIEN);
            dr["TONG_TIEN_DO"] = tienDo;
            dr["NV_THAM_GIA"] = nguoiThucHien;
        }

        public override long[] ShowAddForm()
        {
            Congviec obj = new Congviec(-2, true);
            HelpProtocolForm.ShowModalDialog(this, obj);
            return null;

        }
        public override object HookAfterExecAdvQuery(DataSet dataSet)
        {
            return dataSet;
        }      

        #endregion

        #region Step 8 : Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            return DACongViec.DeleteAction(id);
        }

        public override _Print InAction(long[] ids)
        {
            return null;
        }

        #endregion

        #region DataTable GridDetail
        public override DataTable[] PLLoadDataDetailParts(long MasterID)
        {
            DataTable dt =new DataTable();
            this.masterID = MasterID; 
            return new DataTable[] { dt };
        }

        #endregion

        #region UpdateRow
        public override string UpdateRow()
        {
            return @"SELECT DISTINCT PC.PCCV_ID,PC.LCV_ID, PC.CONG_VIEC, PC.CHI_TIET_CONG_VIEC,KH_DA_CV.KH_ID,KH_DA_CV.DU_AN_ID,
                                   PC.NGAY_BAT_DAU TU_NGAY, PC.NGAY_KET_THUC_DU_KIEN DEN_NGAY,pc.ngay_ket_thuc,
                                   IIF(PC.IS_NGAY ='Y',(PC.THOI_GIAN_DU_KIEN * 8) ||' Giờ', PC.THOI_GIAN_DU_KIEN ||' Giờ') THOI_GIAN_DU_KIEN,
                                   PC.MUC_UU_TIEN,
                                   (CASE PC.MUC_UU_TIEN WHEN 1 THEN 'Cao nhất' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 2 THEN 'Cao' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 3 THEN 'Trung bình' ELSE (
                                   CASE PC.MUC_UU_TIEN WHEN 4 THEN 'Thấp' ELSE(
                                   CASE PC.MUC_UU_TIEN WHEN 5 THEN 'Thấp nhất' ELSE NULL END) END ) END ) END) END) TEN_MUC_UU_TIEN,
                                   '' TONG_TIEN_DO,
(SELECT TEN_KHACH_HANG FROM KHACH_HANG KH WHERE KH.KH_ID=KH_DA_CV.KH_ID
or KH.KH_ID IN
(SELECT KH_ID FROM kh_da_cv k WHERE k.du_an_id=KH_DA_CV.DU_AN_ID) ) TEN_KHACH_HANG,

(SELECT NAME FROM DU_AN DA WHERE DA.ID=KH_DA_CV.DU_AN_ID) TEN_DU_AN,
                                    PC.NGUOI_GIAO, TT.NAME AS TINH_TRANG,PC.TINH_TRANG AS TINH_TRANG_ID,
                                    IIF(LCV.NAME IS NOT NULL,(SELECT CV.NAME FROM DM_LOAI_CONG_VIECN CV WHERE PC.LCV_ID = CV.ID ),'Loại công việc khác') TEN_LCV,                                     
                                    (SELECT N.NAME FROM DM_NHAN_VIEN N WHERE PC.NGUOI_GIAO = N.ID) TEN_NGUOI_GIAO
                FROM  ((PHAN_CONG_CONG_VIEC PC LEFT JOIN DM_TINH_TRANG TT ON PC.TINH_TRANG = TT.ID )
                                  INNER JOIN DM_LOAI_CONG_VIECN LCV ON PC.LCV_ID = LCV.ID) LEFT JOIN CHI_TIET_PHAN_CONG CT ON PC.PCCV_ID = CT.PCCV_ID
                                  LEFT JOIN KH_DA_CV ON KH_DA_CV.PCCV_ID = PC.PCCV_ID
               WHERE LCV.VISIBLE_BIT = 'Y' AND 1=1";
        }
        #endregion       

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        }

        #endregion
        #region Load data cho detail grid
        
        private void LoadTaiLieu(long PCCV_ID)
        {
            try
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet(@"SELECT LUU_TRU_TAP_TIN.*,
            (SELECT NAME FROM DM_NHAN_VIEN WHERE ID = LUU_TRU_TAP_TIN.NGUOI_CAP_NHAT) TEN_NGUOI_CN  
            FROM LUU_TRU_TAP_TIN 
            WHERE ID IN (SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE TYPE_ID=5 AND OBJECT_ID='" + PCCV_ID + "')");

                ds.Tables[0].Columns.Add("mo_file", typeof(Image));
                ds.Tables[0].Columns.Add("luu_file", typeof(Image));
                ds.Tables[0].Columns.Add("SIZE", typeof(String));
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    r["mo_file"] = FWImageDic.VIEW_IMAGE20;
                    r["luu_file"] = FWImageDic.SAVE_IMAGE20;
                    byte[] a = r["NOI_DUNG"] as byte[];
                    r["SIZE"] = (HelpNumber.RoundDecimal((HelpNumber.ParseDecimal(a.Length) / 1024), 3)).ToString();

                }
                gridControlTaiLieu.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }

        private void LoadNhatKy(long PCCV_ID)
        {
            DataTable KQ = HelpDB.getDatabase().LoadDataSet(@"SELECT CT.PCCV_ID, CT.MA_NV, CT.GHI_CHU, CT.THOI_GIAN_CAP_NHAT ,NV.NAME AS NGUOI_THUC_HIEN
                                                FROM NHAT_KY_KH_DA_CV CT 
                                                LEFT JOIN DM_NHAN_VIEN NV ON CT.MA_NV = NV.ID WHERE CT.PCCV_ID = " + PCCV_ID + " AND 1=1").Tables[0];

            this.gridControlNhatKyCV.DataSource = KQ;
        }

        private void LoadTienDoCongViec(long MasterID)
        {            
            DataTable dt = HelpDB.getDatabase().LoadDataSet(string.Format(@"SELECT NV.ID AS EMP_ID, NV.NAME  NGUOI_THUC_HIEN,CT.THOI_GIAN_CAP_NHAT ,CT.TIEN_DO || '%' TIEN_DO , CT.GHI_CHU
                                                    FROM CHI_TIET_PHAN_CONG CT LEFT JOIN DM_NHAN_VIEN NV ON  CT.MA_NV = NV.ID
                                                    WHERE PCCV_ID = {0} AND CT.TIEN_DO > 0 ORDER BY THOI_GIAN_CAP_NHAT DESC", MasterID)).Tables[0];
          
            this.gridControlThongTinLienHe.DataSource = dt;
        }

        private void LoadCTTD_THUCHIEN(long MasterID)
        {
            string squery = string.Format(@"SELECT NV.ID AS EMP_ID, NV.NAME  NGUOI_THUC_HIEN,CT.THOI_GIAN_CAP_NHAT ,CT.TIEN_DO || '%' TIEN_DO, CT.PHAN_TRAM_THAM_GIA || '%' PHAN_TRAM_THAM_GIA
                                                                                FROM CHI_TIET_PHAN_CONG CT LEFT JOIN DM_NHAN_VIEN NV ON  CT.MA_NV = NV.ID
                                                                                WHERE CT.PCCV_ID={0}
                                                                                AND CT.THOI_GIAN_CAP_NHAT IN
                                                                                (SELECT MAX(CTPC.THOI_GIAN_CAP_NHAT) FROM CHI_TIET_PHAN_CONG CTPC
                                                                                WHERE CTPC.PCCV_ID={1}
                                                                                 GROUP BY CTPC.MA_NV
                                                                                )", MasterID, MasterID);
            gridControlCTTD_ThucHien.DataSource = HelpDB.getDatabase().LoadDataSet(squery).Tables[0];
        }

        
        private void chkEditCV_DA_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditCV_DA.Checked)
            {
                this.CotTenDuAn.Visible = true;
                CotTenDuAn.VisibleIndex = 1;               
            }
            else
            {
                this.CotTenDuAn.Visible = false;
            }
        }
        #endregion

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

        private void gridViewTaiLieu_MouseMove(object sender, MouseEventArgs e)
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
        #region Extensions
        private void LoadDataForSelectedTab(bool isTabChanged) 
        {            
            switch (xtraTabControlDetail.SelectedTabPageIndex) { 
                case 0:
                    if (isTabChanged && gridControlCTTD_ThucHien.DataSource == null)
                        LoadCTTD_THUCHIEN(masterID);
                    if(!isTabChanged) LoadCTTD_THUCHIEN(masterID);
                    break;
                case 1:
                    if (isTabChanged && gridControlThongTinLienHe.DataSource == null)
                        LoadTienDoCongViec(masterID);
                    if (!isTabChanged) LoadTienDoCongViec(masterID);
                    break;
                case 2:
                    if(isTabChanged && gridControlTaiLieu.DataSource == null)
                        LoadTaiLieu(masterID);
                    if (!isTabChanged) LoadTaiLieu(masterID);
                    break;
                default:
                    if (isTabChanged && gridControlNhatKyCV.DataSource == null)
                        LoadNhatKy(masterID);
                    if (!isTabChanged) LoadNhatKy(masterID);
                    break;
            }
        }
        #endregion
    }
}