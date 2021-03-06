using System;
using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using ProtocolVN.DanhMuc;
using DAO;
using DevExpress.XtraEditors;
namespace office
{
    public partial class frmTheoDoi_TT_HL_TVQL :   PhieuQuanLy10Change
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //protected DevExpress.XtraBars.BarManager barManager1;
        //protected DevExpress.XtraBars.Bar MainBar;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemView;
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
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemTaoPhieuMuaHang;
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
        
        public static string MenuItem(string ParentID, bool IsSep)
         {
             return MenuBuilder.CreateItem(typeof(frmTheoDoi_TT_HL_TVQL).FullName,
                 "Huấn luyện-Thử việc-Thực tập",
                 ParentID, true,
                 typeof(frmTheoDoi_TT_HL_TVQL).FullName,
                 true, IsSep, "mnbPhieuMuaHang.png", true, "1", "");
         }
        private PhieuQuanLy10Fix Fix;

        public frmTheoDoi_TT_HL_TVQL()
        {
            InitializeComponent();
            Fix = new PhieuQuanLy10Fix(this);
            this.Text = "Quản lý Huấn luyện-Thử việc-Thực tập";
            this.IDField = "R_ID";
            this.DisplayField = "R_ID";
            this.gridViewMaster.GroupPanelText = "Danh sách ứng viên";
        }      
     
        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(Cot_TenUngVien, "HO_TEN");
            XtraGridSupportExt.TextCenterColumn(Cot_MaHoSo, "MA_HO_SO");
            XtraGridSupportExt.TextLeftColumn(Cot_TTHS, "TTHS");
            XtraGridSupportExt.DecimalGridColumn(Cot_SoNgay, "SO_NGAY");
            XtraGridSupportExt.DateTimeGridColumn(Cot_TuNgay, "NGAY_BAT_DAU");
            XtraGridSupportExt.DateTimeGridColumn(Cot_DenNgay, "NGAY_KET_THUC");
            XtraGridSupportExt.DecimalGridColumn(Cot_SoNgayLamViec, "SO_NGAY_LAM_VIEC", 4);
            XtraGridSupportExt.DecimalGridColumn(Cot_SoNgayConLai, "SO_NGAY_CON_LAI", 4);
            Cot_GhiChu.Visible = false;
            Cot_GhiChu.Visible = false;
            Cot_KetThuc.Visible = false;
        }

        public override void InitColumDetail()
        {
           
        }

        public override void PLLoadFilterPart()
        {
            DMTinhTrangHoSo.I.InitCtrl(TinhTrangHoSo, false, null);
            DMFWNhanVien.I.InitCtrl(TenUngVien, false, null);
            //DMTinhTrangHoSo.I.InitCtrl_ThucTap_HuanLuyen_ThuViec(TinhTrangHoSo, null);
            //PLCtrl.ChonUngVienHL_TV_TT(TenUngVien, null);
        }

        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder filter = null;
            string sql = @"SELECT r.HO_TEN,r.MA_HO_SO,TT.ID,TT.NAME as TTHS, H.* FROM DS_HL_TV_TT H,RESUME r,DM_TINH_TRANG_HO_SO TT WHERE
                         r.id = H.r_id 
                         and r.tths_id = TT.ID
                         and 1=1";
            filter = new QueryBuilder(sql);
            filter.addLike("r.MA_HO_SO", MaHoSo.Text.Trim().ToUpper());
            filter.addIn("r.TTHS_ID", DMTinhTrangHoSo.I.dsID_TT_HL_TRN());
            filter.addDateFromTo("H.NGAY_BAT_DAU", TuNgay.DateTime, DenNgay.DateTime);
            filter.addID("r.TTHS_ID", TinhTrangHoSo._getSelectedID());
            filter.addID("r.ID", TenUngVien._getSelectedID());
            if(SoNgayKetThuc.EditValue!=null)
                filter.addDateFromTo("H.NGAY_KET_THUC", TuNgay.DateTime, DateTime.Today.AddDays((double)SoNgayKetThuc.Value));
            return filter;
            
        }

        public override void ShowViewForm(long id)
        {
        }
        public override void ShowUpdateForm(long id)
        {
        }
        
        public override long[] ShowAddForm()
        {
            return null;
        }

        public override bool XoaAction(long id)
        {
            return DAHuanLuyenThuViecThucTap.Instance.Delete(id);
        }
        public override _MenuItem GetBusinessMenuList()
        {
            return null;
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }       
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }

        #region IDuyetSupport Members

        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            return true;   
        }

        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            return true;            
        }

        #endregion
        
        public override string UpdateRow()
        {
            string sql = @"SELECT r.HO_TEN,r.MA_HO_SO,TT.ID,TT.NAME as TTHS, H.* FROM DS_HL_TV_TT H,RESUME r,DM_TINH_TRANG_HO_SO TT WHERE
                         r.id = H.r_id 
                         and r.tths_id = TT.ID
                         and 1=1";
            return sql;
        }

        public override void HookFocusRow()
        {
           
        }
    }
}