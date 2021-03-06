using DevExpress.XtraGrid.Columns;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections.Generic;
using System;
using System.Data;
using DAO;
using office;
namespace pl.office
{
    public partial class frmBangChamCongBandedQL : PhieuQuanLy10BandedChange
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
        //protected DevExpress.XtraGrid.Views.BandedGrid.PLBandedGridView gridViewMaster;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
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
        public static FormStatus Status = FormStatus.OK_DEV;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmBangChamCongBandedQL).FullName,
                HelpDebug.UpdateTitle("Bảng chấm công", Status),
                ParentID, true,
                typeof(frmBangChamCongBandedQL).FullName,
                true, IsSep, "", true, "", "");
        }
        #endregion

        #region Fields
        private DataSet gridDataSet;
        private bool IsUpdate = false;
        #endregion

        public frmBangChamCongBandedQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "EMP_ID";
            new PhieuQuanLy10BandedFix(this);
            this.Text = "Bảng chấm công";
            this.barButtonItemSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemSave_ItemClick);
            this.barButtonItemNoSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(barButtonItemNoSave_ItemClick);
            this.gridViewMaster.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridViewMaster_ValidateRow);
        }

        

        

        /// <summary>Step 1: Xác định các cột sẽ hiển thị trong phần master gridView 
        /// Chú ý không được khởi tạo qua phần giao diện kéo thả ( Chỉ Viết Code )
        /// </summary>
        public override void InitColumnMaster()
        {
            //Do form này hơi đặc biệt nên sẽ không khởi tạo lưới Master ở đây.
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
            this.barButtonItemAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemXem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemSave.Enabled = this.barButtonItemNoSave.Enabled = false;
            this.barSubItem1.Enabled = true;
            PLMulNhanVien._init(DABase.getDatabase().LoadDataSet(@"SELECT ID,NAME FROM DM_NHAN_VIEN WHERE ID IN 
                                (SELECT NV_ID FROM CAPNHAT_NGAYLAMVIEC) AND 1=1").Tables[0], "NAME", "ID");
            dateThangNam._setMorthYear(DABase.getDatabase().GetSystemCurrentDateTime());
            barButtonItemSave.Glyph = FWImageDic.SAVE_IMAGE20;
            barButtonItemNoSave.Glyph = FWImageDic.NO_SAVE_IMAGE20;
            CreateGridMaster();
            gridDataSet = DABase.getDatabase().LoadDataSet("SELECT * FROM BANG_CHAM_CONG_64 WHERE ID = -1","BANG_CHAM_CONG_64");
            gridControlMaster.DataSource = gridDataSet.Tables[0];
        }

        #region Step 4 - Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem item = new _MenuItem(new string[] { "Bổ sung nhân viên", "Chốt sổ" },
                new string[] { "Add", "Khoa" }, "EMP_ID",
                new DelegationLib.CallFunction_MulIn_NoOut[] { AddEmp, KhoaSo },
                new PermissionItem[] { null, null });
            return item;
        }

        private void AddEmp(List<object> ids) {
            List<object> existNhanVien = new List<object>();
            DataRow[] rows = (gridControlMaster.DataSource as DataTable).Select("1=1");
            foreach (DataRow item in rows)
                existNhanVien.Add(item["EMP_ID"]);
            frmAddNewNV frm = new frmAddNewNV(existNhanVien);
            frm.GetList += new frmAddNewNV.ListAddedNhanvien(AddToChamCong);
            ProtocolForm.ShowModalDialog(this, frm);
        }
        private void KhoaSo(List<object> ids)
        {

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
            CreateGridMaster();//Khởi tạo lại cột tương ứng với thời gian được chọn.
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM BANG_CHAM_CONG_64 WHERE 1=1");
            query.addID("EMP_ID", PLMulNhanVien._getSelectedIDs());
            query.addLike("THANG_NAM", dateThangNam._timeEdit.Text);
            query.addCondition("1=1");
            
            return query;
        }

        #region Step 7: Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            this.IsUpdate = true;
            this.barButtonItemSave.Enabled = this.barButtonItemNoSave.Enabled = true;
            SetStateButton = false;
            this.gridViewMaster.OptionsBehavior.Editable = true;
        }

        public override void ShowUpdateForm(long id)
        {
            this.IsUpdate = true;
            this.barButtonItemSave.Enabled = this.barButtonItemNoSave.Enabled = true;
            this.gridViewMaster.OptionsBehavior.Editable = true;
        }

        public override long[] ShowAddForm()
        {
            
            return null;
        }

        #endregion

        #region Step 8 : Xác định các hành động trên form
        /// <summary>Thực hiện câu lệnh để xóa phiếu có id = id 
        /// </summary>        
        public override bool XoaAction(long id)
        {
            //Xóa là xóa nguyên dòng luôn
            return DatabaseFB.DeleteRecord("BANG_CHAM_CONG_64", "ID", id);
        }

        void barButtonItemNoSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridViewMaster.UpdateCurrentRow())
            {
                gridControlMaster.DataSource = DABase.getDatabase().LoadDataSet(PLBuildQueryFilter()).Tables[0];
                this.barButtonItemSave.Enabled = this.barButtonItemNoSave.Enabled = false;
                SetStateButton = true;
            }
            this.gridViewMaster.OptionsBehavior.Editable = false;
        }

        void barButtonItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridViewMaster.EditingValue != null)
                this.gridViewMaster.SetFocusedValue(this.gridViewMaster.EditingValue);
            if (this.gridViewMaster.UpdateCurrentRow()){
                DataSet dsData = DABase.getDatabase().LoadDataSet(UpdateRow(), "BANG_CHAM_CONG_64");
                int month=dateThangNam._getMorth();
                int year=dateThangNam._getYear();
                foreach (DataRow row in gridDataSet.Tables[0].Rows) {
                    row["NGHI_CO_PHEP"] = DATimeInOut.Instance.CountRow(row, "N")/2;
                    row["NGHI_KHONG_PHEP"] = DATimeInOut.Instance.CountRow(row, "V")/2;
                    row["SO_NGAY_LAM_VIEC"] = HelpNumber.RoundDecimal((decimal)(DATimeInOut.Instance.CountSoNgay(row) / 8), 4);
                    DATimeInOut.Instance.DuyetThongKe_TC_HL_KL(row, HelpDate.GetStartOfMonth(month,year), HelpDate.GetEndOfMonth(month, year));
                }
                HelpDataSet.MergeDataSet(new string[] { "ID" }, dsData, gridDataSet);
                if (DABangChamCong64.I.UpdateDataSet(dsData)) {
                    this.gridViewMaster.OptionsBehavior.Editable = false;
                    this.barButtonItemSave.Enabled = this.barButtonItemNoSave.Enabled = false;
                    SetStateButton = true;
                } 
            }
            this.gridViewMaster.OptionsBehavior.Editable = false;
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
            return "SELECT * FROM BANG_CHAM_CONG_64 WHERE 1=1";
        }

        public override void HookFocusRow()
        {
            this.barSubItem1.Enabled = true;
            if (IsUpdate) {
                SetStateButton = false;
                IsUpdate = false;
            } 
        }

        #region Khác
        /// <summary>
        /// Tạo band trong lưới
        /// </summary>
        private GridBand CreateBand(string caption, int index, int width, FixedStyle fix) {
            GridBand band = new GridBand();
            band.Caption = caption;
            band.Width = width;
            band.OptionsBand.FixedWidth = true;
            band.Fixed = fix;
            band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            band.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            band.AppearanceHeader.Options.UseTextOptions = true;
            return band;
        }
        private void CreateGridMaster() {
            //Xóa lưới đã tạo trước đó (nếu có)
            this.gridControlMaster.DataSource = null;
            this.gridViewMaster.Columns.Clear();
            this.gridViewMaster.Bands.Clear();
            //Định nghĩa danh sách cột
            List<BandedGridColumn> columns = new List<BandedGridColumn>();

            GridBand bID = CreateBand("ID", 0, 10, FixedStyle.None);
            BandedGridColumn cID = new BandedGridColumn();
            cID.FieldName = "ID";
            bID.Columns.Add(cID);
            cID.VisibleIndex = 0;
            columns.Add(cID);
            bID.Visible = false;

            GridBand bEmp = CreateBand("Nhân viên", 1, 200, FixedStyle.Left);
            BandedGridColumn cEmp = new BandedGridColumn();
            HelpBandedGrid.CotCombobox((GridColumn)cEmp, "DM_NHAN_VIEN", "ID", "NAME", "EMP_ID", "1=1");
            bEmp.Columns.Add(cEmp);
            cEmp.VisibleIndex = 1;
            columns.Add(cEmp);
            cEmp.OptionsColumn.AllowEdit = false;
            cEmp.OptionsColumn.AllowFocus = false;
            cEmp.OptionsColumn.ReadOnly = true;

            GridBand bNghiCoPhep = CreateBand("Nghỉ có phép", 63, 50, FixedStyle.None);
            BandedGridColumn cNghiCoPhep = new BandedGridColumn();
            HelpBandedGrid.CotCalcEdit(cNghiCoPhep, "NGHI_CO_PHEP", 2);
            bNghiCoPhep.Columns.Add(cNghiCoPhep);
            cNghiCoPhep.VisibleIndex = 63;
            columns.Add(cNghiCoPhep);

            GridBand bNghiKoPhep = CreateBand("Nghỉ không phép", 64, 50, FixedStyle.None);

            BandedGridColumn cNghiKoPhep = new BandedGridColumn();
            HelpBandedGrid.CotCalcEdit(cNghiKoPhep, "NGHI_KHONG_PHEP", 2);
            bNghiKoPhep.Columns.Add(cNghiKoPhep);
            cNghiKoPhep.VisibleIndex = 64;
            cNghiKoPhep.Caption = "";
            columns.Add(cNghiKoPhep);

            GridBand bSoNgay = CreateBand("Số ngày làm việc", 65, 50, FixedStyle.None);
            BandedGridColumn cSoNgay = new BandedGridColumn();
            HelpBandedGrid.CotCalcEdit(cSoNgay, "SO_NGAY_LAM_VIEC", 2);
            bSoNgay.Columns.Add(cSoNgay);
            cSoNgay.VisibleIndex = 65;
            cSoNgay.Caption = "";
            columns.Add(cSoNgay);

            GridBand bKhongLuong = CreateBand("Số ngày không lương", 66, 50, FixedStyle.None);
            BandedGridColumn cKhongLuong = new BandedGridColumn();
            HelpBandedGrid.CotCalcEdit(cKhongLuong, "SO_NGAY_KHONG_LUONG", 2);
            bKhongLuong.Columns.Add(cKhongLuong);
            cKhongLuong.VisibleIndex = 66;
            cKhongLuong.Caption = "";
            columns.Add(cKhongLuong);

            GridBand bTroCap = CreateBand("Số ngày trợ cấp", 67, 50, FixedStyle.None);
            BandedGridColumn cTroCap = new BandedGridColumn();
            HelpBandedGrid.CotCalcEdit(cTroCap, "SO_NGAY_TRO_CAP", 2);
            bTroCap.Columns.Add(cTroCap);
            cTroCap.VisibleIndex = 67;
            cTroCap.Caption = "";
            columns.Add(cTroCap);

            GridBand bHuongLuong = CreateBand("Số ngày hưởng lương", 68, 50, FixedStyle.None);
            BandedGridColumn cHuongLuong = new BandedGridColumn();
            HelpBandedGrid.CotCalcEdit(cHuongLuong, "SO_NGAY_HUONG_LUONG", 2);
            bHuongLuong.Columns.Add(cHuongLuong);
            cHuongLuong.VisibleIndex = 68;
            columns.Add(cHuongLuong);
            cHuongLuong.Caption = "";

            //Định nghĩa danh sách các ngày trong tháng được chọn
            List<GridBand> bNgay = new List<GridBand>();
            int cntIndex = 1;

            //Lấy ngày đầu tiên của tháng được chọn (Tạm thời chưa có control Filter nên lấy tạm tháng hiện tại)
            DateTime dateFirstMonth = HelpDate.GetStartOfMonth(dateThangNam._getMorth(), dateThangNam._getYear());
            int daysInMonth = CountDateInMonth(dateThangNam._getMorth(), dateThangNam._getYear());
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox rep_cbb = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            rep_cbb.Items.AddRange(new object[] { "N", "V", "4" });
            for (int i = 1; i <= daysInMonth; i++)
            {
                //Band thứ
                GridBand bItem = new GridBand();
                bItem.Caption = GetThuVN(dateFirstMonth.DayOfWeek.ToString());
                bItem.Name = "N" + ((i > 9) ? i.ToString() : ("0" + i));
                bItem.Width = 100;
                bItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bItem.AppearanceHeader.Options.UseTextOptions = true;
                bItem.OptionsBand.FixedWidth = true;
                bItem.OptionsBand.AllowSize = false;
                bNgay.Add(bItem);

                //Band ngày/tháng/năm
                GridBand bDate = new GridBand();
                bDate.Caption = dateFirstMonth.Date.ToShortDateString();
                bDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                bDate.AppearanceHeader.Options.UseTextOptions = true;
                bItem.Children.Add(bDate);

                //Cột sáng, chiều
                GridBand bSang = CreateBand("Sáng", 0, 50, FixedStyle.None);
                BandedGridColumn cSang = new BandedGridColumn();
                cSang.VisibleIndex = ++cntIndex;
                cSang.FieldName = "N" + ((i > 9) ? i.ToString() : ("0" + i)) + "_SANG";
                cSang.ColumnEdit = rep_cbb;
                bSang.Columns.Add(cSang);
                columns.Add(cSang);

                GridBand bChieu = CreateBand("Chiều", 0, 50, FixedStyle.None);
                BandedGridColumn cChieu = new BandedGridColumn();
                cChieu.VisibleIndex = ++cntIndex;
                cChieu.FieldName = "N" + ((i > 9) ? i.ToString() : ("0" + i)) + "_CHIEU";
                cChieu.ColumnEdit = rep_cbb;
                bChieu.Columns.Add(cChieu);
                columns.Add(cChieu);

                bDate.Children.Add(bSang);
                bDate.Children.Add(bChieu);

                //Tăng ngày lên
                dateFirstMonth = dateFirstMonth.AddDays(1);
            }
            
            this.gridViewMaster.Bands.Add(bID);
            this.gridViewMaster.Bands.Add(bEmp);
            this.gridViewMaster.Bands.AddRange(bNgay.ToArray());
            this.gridViewMaster.Bands.Add(bNghiCoPhep);
            this.gridViewMaster.Bands.Add(bNghiKoPhep);
            this.gridViewMaster.Bands.Add(bSoNgay);
            this.gridViewMaster.Bands.Add(bKhongLuong);
            this.gridViewMaster.Bands.Add(bTroCap);
            this.gridViewMaster.Bands.Add(bHuongLuong);
            this.gridViewMaster.Columns.AddRange(columns.ToArray());
            this.gridViewMaster.OptionsView.ShowColumnHeaders = true;
        }
        /// <summary>
        /// Lấy ngày đầu tiên của tháng được chọn
        /// </summary>
        private DateTime GetStartOfMonth(Int32 month, Int32 year) {
            return new DateTime(year, month, 1);
        }
        /// <summary>
        /// Lấy số ngày trong tháng
        /// </summary>
        private Int32 CountDateInMonth(Int32 month, Int32 year) {
            return DateTime.DaysInMonth(year,month);
        }

        private bool SetStateButton {
            set
            {
                this.barButtonItemDelete.Enabled = value;
                this.barButtonItemUpdate.Enabled = value;
                this.barSubItem1.Enabled = value;
                this.barButtonItemSearch.Enabled = value;
            }
        }

        void gridViewMaster_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            gridDataSet = (this.gridControlMaster.DataSource as DataTable).DataSet;
        }

        private void AddToChamCong(long[] lstNhanVien) {
            ShowUpdateForm(-1);
            gridDataSet = (gridControlMaster.DataSource as DataTable).DataSet;
            foreach (long item in lstNhanVien) {
                DataRow newRow = gridDataSet.Tables[0].NewRow();
                newRow["ID"] = DABase.getDatabase().GetID("G_NGHIEP_VU");
                newRow["EMP_ID"] = item;
                newRow["THANG_NAM"] = dateThangNam._timeEdit.Text;
                gridDataSet.Tables[0].Rows.Add(newRow);
            }
            SetStateButton = false;
            gridControlMaster.DataSource = gridDataSet.Tables[0];
        }
        private string GetThuVN(string thuEN) {
            switch (thuEN) { 
                case "Monday":
                    return "Thứ 2";
                case "Tuesday":
                    return "Thứ 3";
                case "Wednesday":
                    return "Thứ 4";
                case "Thursday":
                    return "Thứ 5";
                case "Friday":
                    return "Thứ 6";
                case "Saturday":
                    return "Thứ 7";
                default:
                    return "Chủ nhật";
            }
        }
        #endregion
    }
}