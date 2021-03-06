using DevExpress.XtraGrid.Columns;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.DanhMuc;
using DTO;
using DevExpress.XtraBars;
namespace office
{
    public partial class frmPhieuThuChiMan : PhieuQuanLy10Change,IFormRefresh
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
        //protected DevExpress.XtraGrid.GridControl gridControlDetail;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewDetail;
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

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhieuThuChiMan).FullName,
                "Phiếu thu/chi",
                ParentID, true,
                typeof(frmPhieuThuChiMan).FullName,
                true, IsSep, "mnbThuChi.png", true, "", "");
        }

        public frmPhieuThuChiMan()
        {
            InitializeComponent();
            this.IDField = PhieuThuChiExtFields.PTC_ID;
            this.DisplayField = PhieuThuChiExtFields.CODE;
            new PhieuQuanLy10Fix(this,typeof(frmPhieuThuChiMan).FullName,this.UpdateRow());
            this.barButtonItemAdd.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.chkLocKKD.CheckedChanged += new System.EventHandler(chkLocKKD_CheckedChanged);
            this.cmbKyKD.SelectedIndexChanged += new System.EventHandler(cmbKyKD_SelectedIndexChanged);
            this.Text = "Phiếu thu/chi";
            this.barSubItem2.Glyph = FWImageDic.ADD_IMAGE20;
        }

        private void cmbKyKD_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DOKyKinhDoanhPTC KyKD = DAKyKinhDoanhPTC.Instance.LoadAll(this.cmbKyKD._getSelectedID());
            HelpDate.SetDateEdit(this.dateFrom, KyKD.TU_NGAY);
            this.dateTo.EditValue = KyKD.DEN_NGAY;
        }

        private void chkLocKKD_CheckedChanged(object sender, System.EventArgs e)
        {
            this.cmbKyKD.Enabled = chkLocKKD.Checked;
            this.dateFrom.Enabled = !chkLocKKD.Checked;
            this.dateTo.Enabled = !chkLocKKD.Checked;
            this.cmbKyKD._setSelectedID(-1);
            this.dateFrom.EditValue = null;
            this.dateTo.EditValue = null;
        }

        /// <summary>Step 1: Xác định các cột sẽ hiển thị trong phần master gridView 
        /// Chú ý không được khởi tạo qua phần giao diện kéo thả ( Chỉ Viết Code )
        /// </summary>
        public override void InitColumnMaster()
        {
            HelpGridColumn.CotTextLeft(colMasterCode, PhieuThuChiExtFields.CODE);
            HelpGridColumn.CotCombobox(colMasterLcp, "DM_LOAI_CHI_PHI", "ID", "NAME", PhieuThuChiExtFields.LCP_ID);
            HelpGridColumn.CotDateEdit(cplMasterNgayPs, PhieuThuChiExtFields.NGAY_PHAT_SINH);
            HelpGridColumn.CotDateEdit(colMasterNgayTao, PhieuThuChiExtFields.NGAY_TAO_PHIEU);
            HelpGridColumn.CotCombobox(colMasterNguoiTao, "DM_NHAN_VIEN", "ID", "NAME", PhieuThuChiExtFields.NGUOI_TAO_PHIEU);
            HelpGridColumn.CotCombobox(colMasterEmp, "DM_NHAN_VIEN", "ID", "NAME", PhieuThuChiExtFields.EMP_ID);
            HelpGridColumn.CotTextLeft(colMasterDonVi, PhieuThuChiExtFields.DON_VI_LIEN_QUAN);
            HelpGridColumn.CotCalcEdit(colMasterTienThu, PhieuThuChiExtFields.SO_TIEN_THU,0);
            HelpGridColumn.CotCalcEdit(colMasterTienChi, PhieuThuChiExtFields.SO_TIEN_CHI,0);
            HelpGridColumn.CotTextLeft(colMasterDienGiai, PhieuThuChiExtFields.DIEN_GIAI);
            HelpGridColumn.CotPLImageCheck(colMasterThuChiBit, PhieuThuChiExtFields.THU_CHI_BIT);
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
            DMNhanVienX.I.InitCtrl(this.cmbEmp, true, null);
            HelpControl.RedCheckEdit(this.chkChi);
            HelpControl.RedCheckEdit(this.chkThu);
            DAKyKinhDoanhPTC.Instance.InitKyKinhDoanhPTC(this.cmbKyKD);
            this.cmbKyKD.Enabled = false;
            this.gridViewMaster.OptionsView.ShowFooter = true;
            colMasterLcp.Group();
            this.colMasterTienChi.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colMasterTienThu.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
            HelpGridExt1.SetDefaultGroupPanel(this.gridViewMaster);
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
            query = new QueryBuilder(
                "SELECT * " + 
                "FROM PHIEU_THU_CHI " + 
                "WHERE 1=1"         
            );
            query.addDateFromTo(PhieuThuChiExtFields.NGAY_PHAT_SINH, this.dateFrom.DateTime, this.dateTo.DateTime);
            query.addSoPhieu(PhieuThuChiExtFields.CODE, this.txtCode.Text.Trim());
            query.addID(PhieuThuChiExtFields.EMP_ID, this.cmbEmp._getSelectedID());
            if (this.chkThu.Checked != this.chkChi.Checked)
            {
                if(this.chkThu.Checked)
                    query.addBoolean(PhieuThuChiExtFields.THU_CHI_BIT, true);
                else
                    query.addBoolean(PhieuThuChiExtFields.THU_CHI_BIT, false);
            }
            query.addCondition("(1=1)");
            return query;
        }

        #region Step 7: Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            ProtocolForm.ShowModalDialog(this,
               new frmPhieuThuChiEdit(id,null));
        }

        public override void ShowUpdateForm(long id)
        {
            DOPhieuThuChiExt phieu = DAPhieuThuChiExt.Instance.LoadAll(id);
            DOKyKinhDoanhPTC KKD = DAKyKinhDoanhPTC.Instance.LoadAll(phieu.KKD_ID);
            if (KKD.KHOA_SO_BIT!=null &&KKD.KHOA_SO_BIT.Equals("Y"))
            {
                HelpMsgBox.ShowErrorMessage("Kỳ kinh doanh này đã bị khóa sổ.");
                return;
            }
            ProtocolForm.ShowModalDialog(this,
               new frmPhieuThuChiEdit(id,false));
        }

        public override long[] ShowAddForm()
        {
            ProtocolForm.ShowModalDialog(this,
               new frmPhieuThuChiEdit("-2", true));
            return null;
        }

        #endregion

        #region Step 8 : Xác định các hành động trên form
        /// <summary>Thực hiện câu lệnh để xóa phiếu có id = id 
        /// </summary>        
        public override bool XoaAction(long id)
        {
            DOPhieuThuChiExt phieu = DAPhieuThuChiExt.Instance.LoadAll(id);
            if (DAKyKinhDoanhPTC.Instance.LoadAll(phieu.KKD_ID).KHOA_SO_BIT.Equals("Y"))
            {
                HelpMsgBox.ShowErrorMessage("Kỳ kinh doanh này đã bị khóa sổ.");
                return false;
            }
            return DAPhieuThuChiExt.Instance.Delete(id);
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
            return @"SELECT * " + 
                "FROM PHIEU_THU_CHI " + 
                "WHERE 1=1";
        }
        private void InitSaveQueryDialog()
        {
            HelpControl.addSaveQueryDialog(this, this.barManager1, this.gridControlMaster, this.gridViewMaster._GetPLGUI(), this.UpdateRow());
        }

        private void itemAdd_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Name == this.barButtonItemThu.Name)
            {
                ProtocolForm.ShowModalDialog(FrameworkParams.MainForm,
                new frmPhieuThu());
            }
            else {
                ProtocolForm.ShowModalDialog(FrameworkParams.MainForm,
                new frmPhieuChi());
            }
        }




        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        }

        #endregion
    }
}