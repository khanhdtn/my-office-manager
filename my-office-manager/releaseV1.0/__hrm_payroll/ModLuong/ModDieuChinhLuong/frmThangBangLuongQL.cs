using System;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using System.Collections.Generic;
using System.Data;
using ProtocolVN.App.Office;
using DTO;
using ProtocolVN.Plugin.TimeSheet;

namespace office
{
    public partial class frmThangBangLuongQL :PhieuQuanLy10Change,IFormRefresh
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
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
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

        #region Vung dat Static
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmThangBangLuongQL).FullName,
                "Thang bảng lương",
                ParentID, true,
                typeof(frmThangBangLuongQL).FullName,
                true, IsSep, "mnbDieuChinhLuong.png", true, "", "");
        }
        #endregion

        #region 1.Phần chỉ được thay đổi code trong phương thức không được thay đổi tên phương thức, kiểu dữ liệu, tham số
        PhieuQuanLy10Fix that;
        private bool IsUpdate = false;
        private DataSet dsThangBangLuong;
        private DODieuChinhLuong doLuong;
        public frmThangBangLuongQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "NAME";
            that = new PhieuQuanLy10Fix(this);//(this,typeof(frmThangBangLuongQL).FullName,this.UpdateRow());
            this.splitContainerControl1.SplitterPosition = 0;
            doLuong = new DODieuChinhLuong();
            this.Text = "Thang bảng lương";
        }
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(Cot_HoTen, "NAME");
            XtraGridSupportExt.DateTimeGridColumn(Cot_TuNgay, "TU_NGAY");
            XtraGridSupportExt.DecimalGridColumn(Cot_MucLuong, "MUC_LUONG",0);
            XtraGridSupportExt.TextCenterColumn(Cot_PhanTram, "PHAN_TRAM");
            XtraGridSupportExt.TextCenterColumn(Cot_HinhThuc, "HINH_THUC");
            XtraGridSupportExt.DecimalGridColumn(CotLuongThucLanh, "LUONG_TL", 0);
            Cot_HinhThuc.Caption = "Hình thức";
        }
        public override void InitColumDetail()
        {
           
        }
        public override void PLLoadFilterPart()
        {
            AppCtrl.InitTreeChonNhanVien_Choice1(Filter_TenNhanVien, true);
            PLTimeSheetUtil.PermissionForControl(Filter_TenNhanVien, barSubItem1.Visibility == DevExpress.XtraBars.BarItemVisibility.Always, Filter_TenNhanVien.Visible == true);
            HelpControl.RedCheckEdit(LuongHienTai,false);
            LuongHienTai.Checked = true;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            HelpGridColumn.SetNumDisplayFormat(Cot_MucLuong, 0);
            HelpGridColumn.SetNumDisplayFormat(CotLuongThucLanh, 0);
            Cot_MucLuong.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Cot_MucLuong.SummaryItem.FieldName = Cot_MucLuong.FieldName;
            CotLuongThucLanh.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            CotLuongThucLanh.SummaryItem.FieldName = CotLuongThucLanh.FieldName;
            Cot_HoTen.Group();
            //HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            HelpGridExt1.SetDefaultGroupPanel(this.gridViewMaster);
            gridViewMaster.RowCountChanged += new EventHandler(gridViewMaster_RowCountChanged);
        }

        void gridViewMaster_RowCountChanged(object sender, EventArgs e)
        {
            if (IsUpdate) {
                IsUpdate = false;
                gridControlMaster.DataSource = dsThangBangLuong.Tables[0].Copy();
                if (doLuong == null) return;
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                switch (int.Parse(doLuong.HINH_THUC)) { 
                    case 0:
                        if (doLuong.IS_THU_VIEC == "Y")
                        {
                            row["MUC_LUONG"] = doLuong.MUC_LUONG;
                            row["LUONG_TL"] = (doLuong.PHAN_TRAM * doLuong.MUC_LUONG) / 100;
                            row["PHAN_TRAM"] = doLuong.PHAN_TRAM.ToString() + "%";
                            row["HINH_THUC"] = "Thử việc";
                        }
                        else
                        {
                            row["HINH_THUC"] = "Chính thức";
                            row["PHAN_TRAM"] = string.Empty;
                            row["MUC_LUONG"] = doLuong.MUC_LUONG;
                            row["LUONG_TL"] = doLuong.MUC_LUONG;
                        }
                        break;
                    case 1:
                        row["HINH_THUC"] = "Bán thời gian";
                        row["PHAN_TRAM"] = string.Empty;
                        row["MUC_LUONG"] = doLuong.MUC_LUONG;
                        row["LUONG_TL"] = doLuong.MUC_LUONG;
                        break;
                    case 2:
                        row["HINH_THUC"] = "Không lương";
                        row["PHAN_TRAM"] = string.Empty;
                        row["MUC_LUONG"] = DBNull.Value;
                        row["LUONG_TL"] = DBNull.Value;
                        break;
                    default:
                        row["HINH_THUC"] = "Trợ cấp";
                        row["PHAN_TRAM"] = string.Empty;
                        row["MUC_LUONG"] = doLuong.MUC_LUONG; 
                        row["LUONG_TL"] = doLuong.MUC_LUONG;
                        break;
                }
            }
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            filter.addCondition("(1=1)");
            filter.addID("nv.ID", Filter_TenNhanVien._getSelectedID());
            if (LuongHienTai.Checked)
            {
                filter.addCondition("dcl.TU_NGAY = (select max(d.TU_NGAY) from DIEU_CHINH_LUONG d where d.NV_ID=nv.ID)");
                gridViewMaster.ClearGrouping();
            }
            else
            {
                filter.addDateFromTo("dcl.TU_NGAY", ngayLamViec.FromDate, ngayLamViec.ToDate);
                Cot_HoTen.Group();
                Cot_HoTen.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            }
            filter.setAscOrderBy("nv.NAME");
            dsThangBangLuong = HelpDB.getDatabase().LoadDataSet(filter);
            this.splitContainerControl1.SplitterPosition = 700;
            return filter;
        }
        public override void ShowViewForm(long id)
        {
            DateTime TuNgay = (DateTime)gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["TU_NGAY"];
            frmDieuChinhLuong obj = new frmDieuChinhLuong(id, TuNgay,null,false);
            HelpProtocolForm.ShowModalDialog(this, obj);
        }
        public override void ShowUpdateForm(long id)
        {
            IsUpdate = true;
            doLuong = null;
            DateTime TuNgay = (DateTime)gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["TU_NGAY"];
            frmDieuChinhLuong obj = new frmDieuChinhLuong(id, TuNgay, false,false);
            obj._AfterUpdateSuccessfully += new frmDieuChinhLuong.AfterUpdateSuccessfully(obj__AfterUpdateSuccessfully);
            HelpProtocolForm.ShowModalDialog(this, obj);
        }

        void obj__AfterUpdateSuccessfully(DODieuChinhLuong doLuong)
        {
            this.doLuong = doLuong;
        }
        public override long[] ShowAddForm()
        {
            frmDieuChinhLuong obj = new frmDieuChinhLuong(-1, new DateTime(1900,1,1), true,false);
            HelpProtocolForm.ShowDialog(this, obj);
            return null;
        }
        public override bool XoaAction(long id)
        {
            return DADieuChinhLuong.Ins.XoaDong(id, (DateTime)gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["TU_NGAY"]);
        }
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                 new string[] { "Nâng lương" },
                 new string[] { "mnsNangluong.png" },
                 "ID",
                 new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    Nangluong                    
               }, null);
            return menu;          
        }
        public override void HookFocusRow()
        {
            if (gridViewMaster.DataSource != null && gridViewMaster.RowCount > 0)
                barSubItem1.Enabled = true;
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
            
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }
        public override string UpdateRow()
        {
            return @"select nv.ID,nv.NAME,dcl.PHAN_TRAM || '%' AS PHAN_TRAM,dcl.MUC_LUONG ,dcl.TU_NGAY, 
                            iif(dcl.HINH_THUC='3','Trợ cấp',iif(dcl.HINH_THUC='2','Không lương',iif(dcl.HINH_THUC='1','Bán thời gian',iif(dcl.IS_THU_VIEC = 'Y','Thử việc','Chính thức')))) as HINH_THUC 
                            ,iif(dcl.IS_THU_VIEC='Y',dcl.MUC_LUONG*dcl.PHAN_TRAM/100,dcl.MUC_LUONG) as LUONG_TL 
                            from DM_NHAN_VIEN nv inner join DIEU_CHINH_LUONG dcl on nv.ID=dcl.NV_ID 
                            where nv.VISIBLE_BIT='Y' and 1=1";
        }        
        #endregion

        #region 2.Phần mở rộng 
        private void frmTestPhieuQuanLy_Load(object sender, EventArgs e)
        {
            LuongHienTai.CheckedChanged += delegate(object checkEdit, EventArgs checkdChanged) {
                ngayLamViec.Enabled = !LuongHienTai.Checked;
            };
        }

        private void Nangluong(List<object> ids)
        {
            if (ids != null)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                DateTime TuNgay = (DateTime)row["TU_NGAY"];
                frmDieuChinhLuong obj = new frmDieuChinhLuong(HelpNumber.ParseInt64(row["ID"]), TuNgay, false, true);
                HelpProtocolForm.ShowModalDialog(this, obj);
                that.PLRefresh();
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