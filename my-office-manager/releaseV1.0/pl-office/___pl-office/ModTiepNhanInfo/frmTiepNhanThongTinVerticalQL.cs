using System.Data;
using DevExpress.XtraGrid.Columns;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors;
using DTO;
using ProtocolVN.DanhMuc;
using DAO;
using DevExpress.XtraBars;
using DevExpress.XtraRichEdit;
using System.Text;
using ProtocolVN.App.Office;
using ProtocolVN.Plugin.TimeSheet;

namespace office
{
    public partial class frmTiepNhanThongTinVerticalQL : PhieuQuanLyChange1N, IFormRefresh
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //protected DevExpress.XtraBars.BarManager barManager1;
        //protected DevExpress.XtraBars.Bar MainBar;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        //protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        //protected DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        //private System.ComponentModel.IContainer components;
        //private DevExpress.XtraBars.BarSubItem barSubItem1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTiepNhanThongTinVerticalQL).FullName,
                PMSupport.UpdateTitle("Tiếp nhận thông tin", Status),
                ParentID, true,
                typeof(frmTiepNhanThongTinVerticalQL).FullName,
                true, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion
        private DataTable dtProcessor = null;
        public frmTiepNhanThongTinVerticalQL()
        {
            InitializeComponent();
            this.IDField = TiepNhanInfoFields.ID;
            this.DisplayField = TiepNhanInfoFields.VAN_DE_TIEP_NHAN;
            this._UsingExportToFileItem = false;
            new PhieuQuanLyFix1N(this,typeof(frmTiepNhanThongTinVerticalQL).FullName,this.UpdateRow());
            gridViewMaster.OptionsView.RowAutoHeight = true;
        }

        /// <summary>Step 1: Xác định các cột sẽ hiển thị trong phần master gridView 
        /// Chú ý không được khởi tạo qua phần giao diện kéo thả ( Chỉ Viết Code )
        /// </summary>
        public override void InitColumnMaster()
        {
            HelpGridColumn.CotTextLeft(cotVanDeTiepNhan, TiepNhanInfoFields.VAN_DE_TIEP_NHAN);
            HelpGridColumn.CotCombobox(cotNguonThongTin, "DM_NGUON_THONG_TIN", "ID", "NAME", TiepNhanInfoFields.NGUON_THONG_TIN);
            HelpGridExt1.colMultiline(cotNguoiXuLy, "TEN_NGUOI_XU_LY");
            HelpGridColumn.CotReadOnlyDate(cotNgayTiepNhan, TiepNhanInfoFields.NGAY_CAP_NHAT, FrameworkParams.option.DateTimeFomat);
            HelpGridColumn.CotCombobox(cotNguoiTiepNhan, "DM_NHAN_VIEN", "ID", "NAME", TiepNhanInfoFields.NGUOI_CAP_NHAT);
            HelpGridColumn.CotCombobox(cotTinhTrang, DAYeuCau.Bang_tinh_trang().DataSet, "ID", "NAME", TiepNhanInfoFields.TINH_TRANG).NullText = string.Empty;
        }

        /// <summary>Step 2: Xác định các cột sẽ hiển thị trong phần detail  
        /// Chú ý không được khởi tạo qua phần giao diện kéo thả ( Chỉ Viết Code )
        /// </summary>
        public override void InitColumDetail()
        {
            
        }

        /// <summary>Step 3: Xác định các control trong filter part và Khởi tạo control trong phần filter.
        /// Các control trong phần filter này là những control chỉ chọn
        /// </summary>
        public override void PLLoadFilterPart()
        {
            this._RefreshAction(null);
            HelpGrid.SetTitle(this.gridViewMaster, "DANH SÁCH THÔNG TIN TIẾP NHẬN");
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewMaster.BestFitColumns();
            webBrowserNoiDung.AllowNavigation = true;
            webBrowserNoiDung.IsWebBrowserContextMenuEnabled = false;
            ngayLamViec.Types = ProtocolVN.Framework.Win.Trial.SelectionTypes.All;
            PLTimeSheetUtil.PermissionForControl(cmbNguoiXuLy, cmbNguoiXuLy.Visible == true, cmbNguoiXuLy.Visible == true);
        }

        #region Step 4 - Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            return null;
        }

        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        /// <summary>Step 5: Xây dựng Query Buider cho việc tìm kiếm
        /// Xây dựng một QueryBuilder từ những chọn lựa trong phần filter.
        /// Từ QueryBuilder này ta có thể lấy được dữ liệu thỏa điều kiện.
        /// Nếu hỗ trợ duyệt thì trong câu truy vấn trả về 
        /// phải có cột là DUYET_BIT
        /// </summary>
        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            if (dtProcessor == null) dtProcessor = HelpDB.getDatabase().LoadDataSet("SELECT ID,NAME FROM DM_NHAN_VIEN").Tables[0];
            QueryBuilder query = new QueryBuilder(UpdateRow());
            query.addID(TiepNhanInfoFields.NGUON_THONG_TIN, cmbNguonTin._getSelectedID());
            if (cmbNguoiXuLy._CountSelectedIDs > 0) {
                StringBuilder sbSql = new StringBuilder();
                foreach (long  id in cmbNguoiXuLy._SelectedIDs)
                {
                    sbSql.Append(string.Format(@" {0} LIKE '{1}%'
                    OR ({0} LIKE '%,{1},%') OR ({0} LIKE '%,{1}') OR (", TiepNhanInfoFields.NGUOI_XU_LY, id));
                }
                sbSql = sbSql.Remove(sbSql.ToString().LastIndexOf("OR"), 4);
                query.addCondition(sbSql.ToString());
            }
            query.addID(TiepNhanInfoFields.TINH_TRANG,PLTinhtrang._getSelectedID());
            query.addDateFromTo(TiepNhanInfoFields.NGAY_CAP_NHAT, ngayLamViec.FromDate, ngayLamViec.ToDate);
            query.addCondition("1=1");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            foreach (DataRow row in ds.Tables[0].Rows)
                row["TEN_NGUOI_XU_LY"] = DATiepNhanInfo.I.GetNameOfProcessor(row["NGUOI_XU_LY"].ToString(), dtProcessor, "\n");
            gridControlMaster.DataSource = ds.Tables[0];
            msg.Finish();
            return null;
        }

        /// <summary>Step 6: Hàm lấy dữ liệu cho phần detail
        /// Hàm trả về dữ liệu phần Detail của phần từ trong Master
        /// </summary>        
        public override DataTable[] PLLoadDataDetailParts(long MasterID)
        {
            DOTiepNhanInfo Obj = DATiepNhanInfo.I.LoadAll(MasterID);
            RichEditControl rich = new RichEditControl();
            rich.RtfText = HelpByte.BytesToUTF8String(Obj.NOI_DUNG);
            this.webBrowserNoiDung.DocumentText = rich.HtmlText;
            return null;
        }

        #region Step 7: Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            HelpProtocolForm.ShowModalDialog(this,new frmTiepNhanThongTin(id,null));
        }

        public override void ShowUpdateForm(long id)
        {
            frmTiepNhanThongTin frm = new frmTiepNhanThongTin(id, false);
            frm._AfterUpdateSuccessfully += new frmTiepNhanThongTin.AfterUpdateSuccessfully(frm__AfterUpdateSuccessfully);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        void frm__AfterUpdateSuccessfully(DOTiepNhanInfo doData)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            row[TiepNhanInfoFields.VAN_DE_TIEP_NHAN] = doData.VAN_DE_TIEP_NHAN;
            row[TiepNhanInfoFields.NGUOI_XU_LY] = doData.NGUOI_XU_LY;
            row["TEN_NGUOI_XU_LY"] = DATiepNhanInfo.I.GetNameOfProcessor(doData.NGUOI_XU_LY, dtProcessor, "\n");
            row[TiepNhanInfoFields.NGUON_THONG_TIN] = doData.NGUON_THONG_TIN;
            row[TiepNhanInfoFields.NGUOI_CAP_NHAT] = doData.NGUOI_CAP_NHAT;
            row[TiepNhanInfoFields.NGAY_CAP_NHAT] = doData.NGAY_CAP_NHAT;
            row[TiepNhanInfoFields.TINH_TRANG] = doData.TINH_TRANG;
        }

        public override long[] ShowAddForm()
        {
            HelpProtocolForm.ShowModalDialog(this, new frmTiepNhanThongTin());
            return null;
        }

        #endregion

        #region Step 8 : Xác định các hành động trên form
        /// <summary>Thực hiện câu lệnh để xóa phiếu có id = id 
        /// </summary>        
        public override bool XoaAction(long id)
        {
            return DATiepNhanInfo.I.Delete(id);
        }

        /// <summary>Cấu hình thông tin In
        /// </summary>        
        public override _Print InAction(long []ids)
        {
            return null;
        }
        #endregion

        public override string UpdateRow()
        {
            return @"SELECT INFO.*,'' TEN_NGUOI_XU_LY 
                    FROM TIEP_NHAN_INFO INFO INNER JOIN DM_NHAN_VIEN NV ON INFO.NGUOI_CAP_NHAT = NV.ID
                    WHERE 1=1";
        }
       #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            DMNguonThongTin.I.InitCtrl(cmbNguonTin, false);
            AppCtrl.InitTreeChonNhanVien(this.cmbNguoiXuLy, false, false);
            PLTinhtrang._init(DAYeuCau.Bang_tinh_trang(), "NAME", "ID");
            cmbNguoiXuLy.popupContainerControl1.Width = cmbNguoiXuLy.Width;
            return null;
        }

        #endregion

        

    }
}