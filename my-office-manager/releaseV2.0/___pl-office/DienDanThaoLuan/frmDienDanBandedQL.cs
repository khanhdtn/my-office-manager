using System.Data;
using DevExpress.XtraGrid.Columns;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors;

namespace ProtocolVN.Framework.Win
{
    public partial class frmDienDanBandedQL : PhieuQuanLyBandedChange
    {
        #region Các biến của form Quan Ly Tuyệt đối không thay đổi
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
        #endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmDienDanBandedQL).FullName,
                HelpDebug.UpdateTitle("Diễn đàn thảo luận", Status),
                ParentID, true,
                typeof(frmDienDanBandedQL).FullName,
                true, IsSep, "", true, "", "");
        }
        #endregion

        public frmDienDanBandedQL()
        {
            InitializeComponent();
            IDField = "ID";
            new PhieuQuanLyBandedFix(this);
        }

        /// <summary>Step 1: Xác định các cột sẽ hiển thị trong phần master gridView 
        /// Chú ý không được khởi tạo qua phần giao diện kéo thả ( Chỉ Viết Code )
        /// </summary>
        public override void InitColumnMaster()
        {
                     
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
            QueryBuilder query = null;
            return query;
        }

        /// <summary>Step 6: Hàm lấy dữ liệu cho phần detail
        /// Hàm trả về dữ liệu phần Detail của phần từ trong Master
        /// </summary>        
        public override DataTable PLLoadDataDetailPart(long MasterID)
        {
            //QueryBuilder query = null;
            //query = new QueryBuilder(
            //    "SELECT * " + 
            //    "FROM TEST_PRODUCT " + 
            //    "WHERE 1=1"         
            //);
            //query.addID( "CAT_ID", MasterID);
            //if( query != null)
            //    return DABase.getDatabase().LoadDataSet(query, "DETAIL").Tables[0];            
            return null;
        }

        #region Step 7: Xác định các form xử lý khi chọn Thêm, Xem , Sửa

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

        #endregion

        #region Step 8 : Xác định các hành động trên form
        /// <summary>Thực hiện câu lệnh để xóa phiếu có id = id 
        /// </summary>        
        public override bool XoaAction(long id)
        {
            return true;
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
            return "";
        }
    }
}