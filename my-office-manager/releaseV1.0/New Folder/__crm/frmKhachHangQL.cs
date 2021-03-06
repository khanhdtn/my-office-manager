using System;
using System.Data;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using ProtocolVN.DanhMuc;
using System.Windows.Forms;
using ProtocolVN.App.Office;
using System.Collections.Generic;
using DTO;
using DevExpress.XtraTab;
using System.Drawing;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using System.Text;
using DevExpress.XtraBars;
using System.Data.Common;
using System.IO;
using DevExpress.XtraGrid;
namespace office
{

    public partial class frmKhachHangQL : PhieuQuanLyChange1N, IFormRefresh
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //public partial class frmKhachHangQL : XtraFormPL
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
        //    public DevExpress.XtraGrid.GridControl gridControlMaster;
        //    public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmKhachHangQL).FullName,
                "Quản trị quan hệ khách hàng",
                ParentID, true,
                typeof(frmKhachHangQL).FullName,
                true, IsSep, "mnbHSoUngVien.png", true, "", "");
        }
        private PhieuQuanLyFix1N Fix;
        private DOKhachHang _KhachHang;
        private StringBuilder selectecdIDNodes;
        BarButtonItem barItemThemCV, barItemThemDA, barItemThemTL, barItemThemNK;
       
        #endregion

        #region hàm khởi tạo
        public frmKhachHangQL()
        {
            InitializeComponent();
            this.IDField = "KH_ID";
            this.DisplayField = "TEN_KHACH_HANG";
            this._UsingExportToFileItem = false;
            selectecdIDNodes = new StringBuilder();
            Fix = new PhieuQuanLyFix1N(this);
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;            
            this.gridViewMaster.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gridViewCongviec.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

        }
        private void frmQL_Load(object sender, EventArgs e)
        {            
            gridViewMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(gridViewMaster_FocusedRowChanged);
            barButtonItemSearch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            
            treeListNhomKH.FocusedNodeChanged += new FocusedNodeChangedEventHandler(treeListNhomKH_FocusedNodeChanged);
            treeListNhomKH.SetFocusedNode(treeListNhomKH.MoveFirst());
            this.splitContainerControl1.Panel1.MinSize = 180;
        }
        void treeListNhomKH_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                if (!isRefresh)
                {
                    selectecdIDNodes = new StringBuilder();
                    PLBuildQueryFilter();
                }
            }
            catch { }
        }      
        
        public void InitDanhSachNhom_KHLeft()
        {            
            #region Lấy dữ liệu
            DataTable dtParent = HelpDB.getDatabase().LoadDataSet(@"SELECT ID,NAME 
            FROM DM_KHACH_HANG_NHOM 
            WHERE ID_CHA =1 AND VISIBLE_BIT = 'Y'").Tables[0];
            DataTable dtChild = HelpDB.getDatabase().LoadDataSet(@"SELECT ID,NAME,ID_CHA 
            FROM DM_KHACH_HANG_NHOM 
            WHERE ID_CHA !=1 AND  ID_CHA != 0 AND VISIBLE_BIT = 'Y'").Tables[0];
            foreach (DataRow parentRow in dtParent.Rows)
            {
                TreeListNode parentNode = treeListNhomKH.AppendNode(new object[] { parentRow["NAME"], parentRow["ID"]}, -1);
                parentNode.StateImageIndex = 0;
                foreach (DataRow childRow in dtChild.Rows)
                {
                    if (parentRow["ID"].ToString().Equals(childRow["ID_CHA"].ToString()))
                        treeListNhomKH.AppendNode(new object[] { childRow["NAME"], childRow["ID"] }, parentNode.Id).StateImageIndex = 0;
                }
            }
            treeListNhomKH.SetFocusedNode(treeListNhomKH.MoveLast());            
            #endregion
        }
        bool isRefresh = false;
        void barRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            isRefresh = true;
            treeListNhomKH.Nodes.Clear();
            InitDanhSachNhom_KHLeft();
            isRefresh = false;
            treeListNhomKH.SetFocusedNode(treeListNhomKH.MoveFirst());
        }
        public void InitData(long id)
        {
            this._KhachHang = DAKhachHangX.Instance.LoadAll(id);
            if (_KhachHang.KH_ID == 0)
                _KhachHang.KH_ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");     
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
            gridViewMaster.OptionsSelection.MultiSelect = false;
            HelpGridColumn.CotTextLeft(colTenkhachhang, "TEN_KHACH_HANG");
            HelpGridColumn.CotMemoExEdit(colDiachi, "DIA_CHI");
            HelpGridColumn.CotTextLeft(colDienThoai, "DIEN_THOAI");
            HelpGridColumn.CotTextLeft(colFax, "FAX");
            HelpGridColumn.CotTextLeft(colEmail, "EMAIL");
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            gridViewMaster.OptionsBehavior.Editable = false;
            HelpGrid.SetReadOnlyHaveMemoCtrl(gridViewMaster);
            InitDanhSachNhom_KHLeft();
            gridControlDuAn.MouseMove += new MouseEventHandler(gridControlDuAn_MouseMove);
        }
        
        #endregion

        #region Step 2 : Xác định các cột sẽ hiển thị trong phần detail
        public override void InitColumDetail()
        {
            #region grid Công việc
             HelpGridColumn.CotTextLeft(CotLoaiCongViec, "LCV_ID");
            HelpGridColumn.CotTextLeft(CongViec, "CONG_VIEC");
            HelpGridColumn.CotTextLeft(Cotnguoigiao, "NGUOI_GIAO");
            HelpGridExt1.colMultiline(CotNguoiThucHien, "NV_THAM_GIA");
            HelpGridColumn.CotTextCenter(CotTienDo, "TONG_TIEN_DO");
            HelpGridColumn.CotDateEdit(Cotbatdau, "NGAY_BAT_DAU");
            HelpGridColumn.CotDateEdit(Cotngayketthuc, "NGAY_KET_THUC");
            HelpGridColumn.CotDateEdit(cotNgayKTTT, "NGAY_KTTT");
            cotNgayKTTT.OptionsColumn.AllowEdit = false;
            HelpGridColumn.CotDateEdit(CotTGdutinh, "THOI_GIAN_DU_KIEN");
            XtraGridSupportExt.TextLeftColumn(CotDouutien, "TEN_MUC_UU_TIEN");
            XtraGridSupportExt.TextLeftColumn(CotTinhtrang, "TINH_TRANG");
            ///////////////////////////////////
            StyleFormatCondition conditionBlue = new StyleFormatCondition();
            conditionBlue.Appearance.Options.UseForeColor = true;
            conditionBlue.Appearance.ForeColor = Color.Blue;
            conditionBlue.Condition = FormatConditionEnum.Expression;
            conditionBlue.Expression = "([NGAY_KET_THUC] >= [NGAY_KTTT] and not(IsNull([NGAY_KTTT]))) or(IsNull([NGAY_KET_THUC]) and not(IsNull([NGAY_KTTT]))) ";
            conditionBlue.ApplyToRow = true;

            StyleFormatCondition conditionRed = new StyleFormatCondition();
            conditionRed.Appearance.Options.UseForeColor = true;
            conditionRed.Appearance.ForeColor = Color.Red;
            conditionRed.Condition = FormatConditionEnum.Expression;
            conditionRed.Expression = "[NGAY_KET_THUC] < [NGAY_KTTT] and not(IsNull([NGAY_KET_THUC]))";
            conditionRed.ApplyToRow = true;
            gridViewCongviec.FormatConditions.AddRange(new StyleFormatCondition[] { conditionBlue, conditionRed });
            #endregion

            #region layout tài liệu
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            XtraGridSupportExt.TextLeftColumn(cotID, "ID");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "LUU_FILE");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "MO_FILE");
            HelpGridColumn.CotTextLeft(lvSize, "SIZE");
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            #endregion

            #region layout Dự án

            XtraGridSupportExt.TextLeftColumn(colTen_DA, "NAME");
            XtraGridSupportExt.TextLeftColumn(colLoaiDA, "TEN_DA");
            XtraGridSupportExt.TextLeftColumn(colNguoi_QL, "TEN_NGUOI_QL");
            XtraGridSupportExt.TextLeftColumn(colT_trang, "TINH_TRANG");
            XtraGridSupportExt.TextLeftColumn(colNgay_BD_DA, "NGAY_BAT_DAU");
            XtraGridSupportExt.TextLeftColumn(colNgayKTDK, "NGAY_KET_THUC");
            XtraGridSupportExt.TextLeftColumn(colNgayKT, "NGAY_KET_THUC_THUC_TE");
            XtraGridSupportExt.TextLeftColumn(codT_do_DA, "TIEN_DO");
            XtraGridSupportExt.TextLeftColumn(colXemDA, "XEM_DA");
            XtraGridSupportExt.TextLeftColumn(colTaoCV, "TAO_CV");
            layoutViewDuAn.OptionsHeaderPanel.EnableCustomizeButton = false;
            layoutViewDuAn.OptionsCustomization.AllowSort = false;
            layoutViewDuAn.OptionsCustomization.AllowFilter = false;
            layoutViewDuAn.OptionsBehavior.AllowSwitchViewModes = true;
            layoutViewDuAn.OptionsBehavior.AllowExpandCollapse = true;
            layoutViewDuAn.OptionsView.ShowCardCaption = true;
            layoutViewDuAn.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            #endregion

            #region grid GhiNhatKy
            HelpGridColumn.CotReadOnlyDate(colTGCapNhat, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            HelpGridColumn.CotTextLeft(colNguoiCapNhat, "NGUOI_THUC_HIEN");
            HelpGridColumn.CotMemoExEdit(colNoiDung, "GHI_CHU");
            colTGCapNhat.OptionsColumn.AllowFocus = false;
            colTGCapNhat.OptionsColumn.AllowEdit = false;
            colTGCapNhat.OptionsColumn.ReadOnly = true;
            colNoiDung.OptionsColumn.AllowEdit = true;
            gridViewNhatKy.OptionsBehavior.Editable = true;
            gridViewNhatKy.BestFitColumns();
            #endregion
        }
        #endregion
     
        #region Step 3 : Xác định các control trong filter part và Khởi tạo control trong phần filter.
        public override void PLLoadFilterPart()
        {           
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            InitDanhSachNhom_KHLeft();
        }
        public override DataTable[] PLLoadDataDetailParts(long MasterID)
        {
            return null;
        }
        #endregion

        #region Step 4 : Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                new string[] { "Thêm công việc", "Thêm dự án", "Thêm tài liệu", "Ghi nhật ký" },
                new string[] { "add.png", "add.png", "add.png", "NghiepVu005.png" },
                "KH_ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    Them_Cong_Viec,Them_Du_An,Them_Tai_Lieu ,Them_Nhat_Ky
               });
            return menu;

        }

        private void Them_Cong_Viec(List<object> ids) {
            Congviec frm = new Congviec(-2, true);
            frm.UpdateCongViec_KhachHang += new Congviec.UpdateKH_DA_CV(InsertKhachHang_CongViec);
            HelpProtocolForm.ShowModalDialog(this, frm);
            LoadGridCongViec();
        }
        long duAn_id;
        private void Them_Du_An(List<object> ids){
            frmDuAn frm = new frmDuAn();
            frm.UpdateDuAn_KhachHang += new frmDuAn.UpdateKH_DA_CV(InsertKhachHang_DuAn);
            HelpProtocolForm.ShowModalDialog(this, frm);
            decimal tiendo = 0;
            int phanTram = 0;
            DataTable v = DADuAn.LoadCongViec(duAn_id);
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
            DADuAn.CapNhatTienDoDuAn(duAn_id, tiendo);
            LoadCardViewDuAn();       
        }

        private void Them_Tai_Lieu(List<object> ids) {
            frmThemTaiLieu frm = new frmThemTaiLieu(-2, true, _KhachHang.KH_ID, (long)LoaiTapTin.KhachHangTaptin);
            HelpProtocolForm.ShowModalDialog(this, frm);
            LoadCardViewTaiLieu();
        }

        private void Them_Nhat_Ky(List<object> ids) {
            frmNhatKyKhachHang frm = new frmNhatKyKhachHang(_KhachHang.KH_ID);
            HelpProtocolForm.ShowModalDialog(this, frm);
            LoadNhatKy();
        }

        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        #region Step 5 : Xây dựng Query Buider cho việc tìm kiếm
        public override QueryBuilder PLBuildQueryFilter()
        {
            Application.DoEvents();
            FWWaitingMsg msg = new FWWaitingMsg();
            try
            {
                QueryBuilder query = new QueryBuilder(UpdateRow());
                string[] ids = GetChildOfFocusedNode(treeListNhomKH.FocusedNode).TrimEnd(' ').Split(' ');
                StringBuilder strIds = new StringBuilder();
                foreach (string id in ids)
                    strIds.Append(string.Format("NKH_ID LIKE '%,{0},%' OR ", id));
                query.addCondition(strIds.ToString().TrimEnd(' ', 'R', 'O'));
                DataSet ds = HelpDB.getDatabase().LoadDataSet(query, "KHACH_HANG");
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    gridViewMaster.FocusedRowHandle = 0;
                    gridControlMaster.DataSource = ds.Tables[0];
                }
                else
                {
                    gridViewMaster.FocusedRowHandle = 0;
                    gridControlMaster.DataSource = null;
                }
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (barSubItem1.ItemLinks.Count > 0 && barItemThemCV == null)
                {
                    barItemThemCV = barSubItem1.ItemLinks[0].Item as BarButtonItem;
                    barItemThemDA = barSubItem1.ItemLinks[1].Item as BarButtonItem;
                    barItemThemTL = barSubItem1.ItemLinks[2].Item as BarButtonItem;
                    barItemThemNK = barSubItem1.ItemLinks[3].Item as BarButtonItem;
                }
                if (row != null)
                {
                    InitData(HelpNumber.ParseInt64(row["KH_ID"]));
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                    barButtonItemXem.Enabled = barButtonItemUpdate.Enabled = barButtonItemDelete.Enabled = true;
                    if (barSubItem1.ItemLinks.Count > 0)
                        barItemThemCV.Enabled = barItemThemDA.Enabled = barItemThemNK.Enabled = barItemThemTL.Enabled = true;
                    LoadDataForSelectedTab(false);
                }
                else
                {
                    gridControlCongviec.DataSource = gridControlTaiLieu.DataSource = null;
                    splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
                    gridControlMaster.DataSource = gridControlNhatKy.DataSource = null;
                    barButtonItemXem.Enabled = barButtonItemUpdate.Enabled = barButtonItemDelete.Enabled = false;
                    if (barSubItem1.ItemLinks.Count > 0)
                        barItemThemCV.Enabled = barItemThemDA.Enabled = barItemThemNK.Enabled = barItemThemTL.Enabled = false;
                }
            }
            catch
            {
                gridControlMaster.DataSource = gridControlCongviec.DataSource = gridControlTaiLieu.DataSource = null;
                barButtonItemXem.Enabled = barButtonItemUpdate.Enabled = barButtonItemDelete.Enabled = false;
            }
            finally { if (msg != null) msg.Finish(); }
            return null;
        }
        #endregion

        #region Step 7 : Xác định các form xử lý khi chọn Thêm, Xem , Sửa
        public override void ShowViewForm(long id)
        {
            frmTaoKhachHangMoi frm = new frmTaoKhachHangMoi(id, null);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        public override void ShowUpdateForm(long id)
        {
            frmTaoKhachHangMoi frm = new frmTaoKhachHangMoi(id, false);
            frm.RefreshUpdate += new frmTaoKhachHangMoi.RefreshData(frm_RefreshUpdate);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        void frm_RefreshUpdate(DOKhachHang doKhachHang)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            row["TEN_KHACH_HANG"] = doKhachHang.TEN_KHACH_HANG;
            row["DIA_CHI"] = doKhachHang.DIA_CHI;
            row["DIEN_THOAI"] = doKhachHang.DIEN_THOAI;
            row["FAX"] = doKhachHang.FAX;
            row["EMAIL"] = doKhachHang.EMAIL;
        }
       
        public override long[] ShowAddForm()
        {
            frmTaoKhachHangMoi frm = new frmTaoKhachHangMoi(-2, true);
            HelpProtocolForm.ShowModalDialog(this, frm); 
            return null;
        }

        void frm_RefreshInsert(DOKhachHang doKhachHang)
        {
            Fix.PLRefresh();
        }       
       
        #endregion

        #region Step 8 : Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            try
            {
                FWDBService db = HelpDB.getDBService();
                DbCommand cmd = db.GetSQLStringCommand(string.Format("DELETE FROM KHACH_HANG WHERE KH_ID = {0}", id));
                if (db.ExecuteNonQuery(cmd) > 0) {
                    LoadDataForSelectedTab(false);
                    return true;
                }
                return false;   
            }
            catch (Exception ex) {
                if (ex.Message.GetHashCode() == 724613018)//Lỗi do ràng buộc trigger
                    HelpMsgBox.ShowNotificationMessage("Đã có \"Dự án\" hoặc \"Phân công công việc\" hoặc \"Tập tin\" cho khách hàng, không cho phép xóa!");
                return false;   
            }
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        
        public override object HookAfterExecAdvQuery(DataSet dataSet)
        {
            return dataSet;
        }
        private void gridViewCongviec_DoubleClick(object sender, EventArgs e)
        {
            PLGridView grid = (PLGridView)sender;
            if (grid.RowCount <= 0) return;
            else if (!grid.IsGroupRow(grid.FocusedRowHandle))
            {
                FWWaitingMsg m = new FWWaitingMsg();
                Congviec obj = new Congviec(HelpNumber.ParseInt64(grid.GetDataRow(grid.FocusedRowHandle)["PCCV_ID"]), null);
                m.Finish();
                HelpProtocolForm.ShowModalDialog(this, obj);
                
            }
        }
        #endregion

        #region HookFocusRow
        public override void HookFocusRow()
        {
        }
        void gridViewMaster_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (dr != null && !gridViewMaster.IsGroupRow(e.FocusedRowHandle))
            {
                gridControlCongviec.DataSource = null;
                gridControlTaiLieu.DataSource = null;
                InitData(Int64.Parse(dr["KH_ID"].ToString()));
                gridControlCongviec.DataSource=gridControlNhatKy.DataSource=gridControlTaiLieu.DataSource=gridControlDuAn.DataSource=null;
                LoadDataForSelectedTab(false);
            }
        }
        #endregion

        #region UpdateRow
        public override string UpdateRow()
        {
            return @"SELECT DISTINCT KH.KH_ID, KH.TEN_KHACH_HANG, KH.DIA_CHI,KH.EMAIL,
                            KH.DIEN_THOAI , KH.FAX ,KH.NKH_ID
                            FROM KHACH_HANG KH LEFT JOIN THONG_TIN_LIEN_HE TT ON TT.KH_ID = KH.KH_ID      
                            WHERE  1=1";
        }
        #endregion
        
        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        } 

        #endregion

        #region Sự kiện trên các grid

        private void LoadGridCongViec() {
            DataSet ds = HelpDB.getDatabase().LoadDataSet(@"SELECT DISTINCT PC.PCCV_ID,PC.LCV_ID, PC.CONG_VIEC, PC.CHI_TIET_CONG_VIEC,KH_DA_CV.KH_ID,KH_DA_CV.DU_AN_ID,
                                  PC.NGAY_BAT_DAU, PC.NGAY_KET_THUC_DU_KIEN NGAY_KET_THUC,PC.NGAY_KET_THUC NGAY_KTTT,
                                  IIF(PC.IS_NGAY ='Y',(PC.THOI_GIAN_DU_KIEN * 8) ||' Giờ', PC.THOI_GIAN_DU_KIEN ||' Giờ') THOI_GIAN_DU_KIEN,
                                  PC.MUC_UU_TIEN,
                                  (CASE PC.MUC_UU_TIEN WHEN 1 THEN 'Cao nhất' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 2 THEN 'Cao' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 3 THEN 'Trung bình' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 4 THEN 'Thấp' ELSE(
                                  CASE PC.MUC_UU_TIEN WHEN 5 THEN 'Thấp nhất' ELSE NULL END) END ) END ) END) END) TEN_MUC_UU_TIEN,
                                   '' TONG_TIEN_DO,
                                  PC.NGUOI_GIAO, TT.NAME AS TINH_TRANG,PC.TINH_TRANG AS TINH_TRANG_ID,
                                  IIF(LCV.NAME IS NOT NULL,(SELECT CV.NAME FROM DM_LOAI_CONG_VIECN CV WHERE PC.LCV_ID = CV.ID ),'Loại công việc khác') TEN_LCV,                                     
                                  (SELECT N.NAME FROM DM_NHAN_VIEN N WHERE PC.NGUOI_GIAO = N.ID) TEN_NGUOI_GIAO
                                  FROM  ((PHAN_CONG_CONG_VIEC PC LEFT JOIN DM_TINH_TRANG TT ON PC.TINH_TRANG = TT.ID )
                                  INNER JOIN DM_LOAI_CONG_VIECN LCV ON PC.LCV_ID = LCV.ID) LEFT JOIN CHI_TIET_PHAN_CONG CT ON PC.PCCV_ID = CT.PCCV_ID
                                  LEFT JOIN KH_DA_CV ON KH_DA_CV.PCCV_ID = PC.PCCV_ID
                                  WHERE KH_DA_CV.KH_ID = " + _KhachHang.KH_ID, "CONG_VIEC_KHACH_HANG");
            DAKhachHangX.Instance.GetDetailDataSetCV(ds);
            gridControlCongviec.DataSource = ds.Tables[0];
        }

        private void LoadCardViewTaiLieu()
        {
            try
            {
                string qr = string.Format(@"SELECT LUU_TRU_TAP_TIN.*,
                (SELECT NAME FROM DM_NHAN_VIEN WHERE ID = LUU_TRU_TAP_TIN.NGUOI_CAP_NHAT) TEN_NGUOI_CN 
                FROM LUU_TRU_TAP_TIN 
                WHERE ID IN (SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID=8)", _KhachHang.KH_ID);
                 DataSet   ds = HelpDB.getDatabase().LoadDataSet(qr);
                ds.Tables[0].Columns.Add("MO_FILE", typeof(Image));
                ds.Tables[0].Columns.Add("LUU_FILE", typeof(Image));
                ds.Tables[0].Columns.Add("SIZE", typeof(String));
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    r["MO_FILE"] = FWImageDic.VIEW_IMAGE20;
                    r["LUU_FILE"] = FWImageDic.SAVE_IMAGE20;
                    byte[] a = r["NOI_DUNG"] as byte[];
                    r["SIZE"] = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal(a.Length) / 1024, 3).ToString();
                } 
                gridControlTaiLieu.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "");
            }
        }

        private void LoadCardViewDuAn()
        {
            DataTable dt = new DataTable();
            string chuoi = @"SELECT ID,NAME,B.NGUOI_QUAN_LY,B.NGUOI_THUC_HIEN,
                    (SELECT NAME FROM DM_NHAN_VIEN NV WHERE NV.ID=B.NGUOI_QUAN_LY) TEN_NGUOI_QL,
                    (SELECT NAME FROM DM_LOAI_DU_AN DA WHERE DA.ID=B.LOAI_DU_AN) TEN_DA,
                    NGAY_BAT_DAU,NGAY_KET_THUC,NGAY_KET_THUC_THUC_TE NGAY_KTTT,
                   iif(B.TINH_TRANG = 5, NGAY_KET_THUC_THUC_TE,NGAY_KET_THUC) NGAY_KET_THUC_THUC_TE,
                   TIEN_DO || '%' TIEN_DO,B.TINH_TRANG ID_TT,
                  (CASE B.TINH_TRANG WHEN 1 THEN 'Mới đề xuất' ELSE (
                   CASE B.TINH_TRANG WHEN 2 THEN 'Đang lập kế hoạch' ELSE (
                   CASE B.TINH_TRANG WHEN 3 THEN 'Đang xử lý' ELSE (
                   CASE B.TINH_TRANG WHEN 4 THEN 'Tạm dừng' ELSE(
                   CASE B.TINH_TRANG WHEN 5 THEN 'Hoàn thành' ELSE NULL END) END ) END ) END) END) TINH_TRANG                    
                    FROM DU_AN B 
                    INNER JOIN KH_DA_CV KH ON KH.DU_AN_ID=B.ID
                    WHERE KH.KH_ID=" + _KhachHang.KH_ID + " AND 1=1";
            dt = HelpDB.getDatabase().LoadDataSet(chuoi).Tables[0];
            dt.Columns.Add("XEM_DA", typeof(Image));
            dt.Columns.Add("TAO_CV", typeof(Image));
            foreach (DataRow row in dt.Rows) {
                row["XEM_DA"] = FWImageDic.VIEW_IMAGE20;
                row["TAO_CV"] = FWImageDic.ADD_IMAGE20;
            }
            gridControlDuAn.DataSource = dt;
        }

        private void LoadNhatKy()
        {
            DataTable dtNhatKy = HelpDB.getDatabase().LoadDataSet(@"SELECT CT.* ,NV.NAME AS NGUOI_THUC_HIEN
                                                FROM NHAT_KY_KH_DA_CV CT 
                                                LEFT JOIN DM_NHAN_VIEN NV ON CT.MA_NV = NV.ID WHERE CT.KH_ID = " + _KhachHang.KH_ID + " AND 1=1").Tables[0];

            gridControlNhatKy.DataSource = dtNhatKy;
        }

        void gridControlDuAn_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo layouthit = layoutViewDuAn.CalcHitInfo(layoutViewDuAn.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
            {
                if (layouthit.Column.Name == "colXemDA")
                {
                    toolTip1.Show("Xem dự án", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
                if (layouthit.Column.Name == "colTaoCV")
                {
                    toolTip1.Show("Tạo công việc", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
            }
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

        #region Xử lý nút trên CardView
        /// <summary>
        /// Mở tập tin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }
        /// <summary>
        /// Lưu tập tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rep_luufile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }
        /// <summary>
        /// Xem dự án.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repImage_Click(object sender, EventArgs e)
        {
            DataRow row = layoutViewDuAn.GetDataRow(layoutViewDuAn.FocusedRowHandle);
            if (row != null)
            {
                frmDuAn frm = new frmDuAn(HelpNumber.ParseInt64(row["ID"]), null);
                HelpProtocolForm.ShowDialog(this, frm);
            }
        }
        /// <summary>
        /// Tạo công việc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repImageTaoCV_Click(object sender, EventArgs e)
        {
            DataRow row = layoutViewDuAn.GetDataRow(layoutViewDuAn.FocusedRowHandle);
            if (row != null)
            {
                if (HelpNumber.ParseInt32(row["ID_TT"]) != 5)
                {
                    Congviec frm = new Congviec(-2, true, DADuAn.Instance.GetLongNguoiThucHien(row["NGUOI_THUC_HIEN"].ToString()));
                    frm.UpdateCongViec_DuAn += new Congviec.UpdateKH_DA_CV(InsertDuAn_CongViec);
                    HelpProtocolForm.ShowModalDialog(this, frm);

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
                    
                    LoadCardViewDuAn();
                }

                else
                {
                    HelpMsgBox.ShowNotificationMessage("Dự án đã hoàn thành không tạo thêm công việc được!");
                }
            }
        }
        #endregion
        private string GetChildOfFocusedNode(TreeListNode node) {
            selectecdIDNodes.Append(node.GetValue("ID").ToString() + " ");
            if (node.HasChildren)
            {
                node.ExpandAll();
                TreeListNode childNode = node.NextVisibleNode;
                while (childNode.Level != node.Level) {
                    selectecdIDNodes.Append(childNode.GetValue("ID").ToString() + " ");
                    childNode = childNode.NextVisibleNode;
                }
                return selectecdIDNodes.ToString();
            }
            else {
                return selectecdIDNodes.ToString();
            }
        }
        #endregion

        #region Xử lý load dữ liệu khi chọn tab
        private void xtraTabControlDetail_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            LoadDataForSelectedTab(true);
        }
        /// <summary>
        /// True: when called in TagPageChanged event, otherwise: false.
        /// </summary>
        /// <param name="isSelectedTab"></param>
        private void LoadDataForSelectedTab(bool isSelectedTab)
        {
            switch (xtraTabControlDetail.SelectedTabPageIndex)
            {
                case 0:
                    if (isSelectedTab && gridControlCongviec.DataSource == null)
                        LoadGridCongViec();
                    else if
                        (!isSelectedTab) LoadGridCongViec();
                    break;
                case 1:
                    if (isSelectedTab && gridControlDuAn.DataSource == null) LoadCardViewDuAn();
                    else if (!isSelectedTab) LoadCardViewDuAn();
                    break;
                case 2:
                    if (isSelectedTab && gridControlNhatKy.DataSource == null) LoadNhatKy();
                    else if (!isSelectedTab) LoadNhatKy();
                    break;
                default:
                    if (isSelectedTab && gridControlTaiLieu.DataSource == null) LoadCardViewTaiLieu();
                    else if (!isSelectedTab) LoadCardViewTaiLieu();
                    break;
            }
        }

        private void InsertKhachHang_CongViec(long congviecID)
        {
            DACongViec.InsertKhachHang_CongViec(congviecID, _KhachHang.KH_ID);
        }

        private void InsertKhachHang_DuAn(long duanID)
        {
            duAn_id = duanID;
            DAKhachHangX.InsertKhachHang_DuAn(duanID, _KhachHang.KH_ID);
        }

        private void InsertDuAn_CongViec(long congviecID)
        {
            DataRow row = layoutViewDuAn.GetDataRow(layoutViewDuAn.FocusedRowHandle);
            DADuAn.InsertDuAn_CongViec(HelpNumber.ParseInt64(row["ID"]), congviecID);
        }     
        #endregion        
    }
}