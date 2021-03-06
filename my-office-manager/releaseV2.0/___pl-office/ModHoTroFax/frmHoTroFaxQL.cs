using System;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using DAO;
using System.Drawing;
using DTO;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using System.Windows.Forms;
using ProtocolVN.App.Office;
using System.Text;
using ProtocolVN.Plugin.TimeSheet;

namespace office
{

    public partial class frmHoTroFaxQL : PhieuQuanLy10Change, IFormRefresh
    {
    //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
    //public partial class frmHoTroFaxQL : XtraFormPL
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
            return MenuBuilder.CreateItem(typeof(frmHoTroInAnQL).FullName,
                "Hỗ trợ fax",
                ParentID, true,
                typeof(frmHoTroInAnQL).FullName,
                true, IsSep, "mnbToChuc.png", true, "", "");
        }
        private PhieuQuanLy10Fix Fix;
        #endregion

        #region Hàm khởi tạo
        public frmHoTroFaxQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "NOI_DUNG_KEM_THEO";
            this._UsingExportToFileItem = false;
            Fix = new PhieuQuanLy10Fix(this, this.UpdateRow());
            toolTip1.BackColor = Color.LightYellow; 
            barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        private void frmHoTroInAnQL_Load(object sender, EventArgs e)
        {
        }

        #endregion

        #region Step 1 : Xác định các cột sẽ hiển thị trong gridView
        public override void InitColumnMaster()
        {
            DataSet ds_nv = HelpDB.getDatabase().LoadDataSet("Select * from DM_NHAN_VIEN WHERE 1=1");
            XtraGridSupportExt.ComboboxGridColumn(colNguoi_gui, ds_nv.Tables[0], "ID", "NAME", "NGUOI_GUI_ID");
            HelpGridColumn.CotReadOnlyDate(colThoi_gian, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            XtraGridSupportExt.ComboboxGridColumn(colNguoi_nhan, ds_nv.Tables[0], "ID", "NAME", "NGUOI_NHAN_ID");
            XtraGridSupportExt.ComboboxGridColumn(colT_trang, DMCTinhTrangFax.I(), "ID", "NAME", "TINH_TRANG_FAX_ID");
            HelpGridColumn.CotTextLeft(colMuc_dich, "NOI_DUNG_KEM_THEO");
            HelpGridColumn.CotTextLeft(colGuiDenSo, "GUI_DEN_SO");
            HelpGridColumn.CotTextLeft(colTenNguoiNhan, "TEN_NGUOI_NHAN");
            XtraGridSupportExt.ComboboxGridColumn(colMuc_UT, HelpDB.getDatabase().LoadDataSet("SELECT * FROM DM_MUC_DO_UU_TIEN").Tables[0], "ID", "NAME", "MUC_DO_UU_TIEN_ID");
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
        }
        #endregion

        #region Step 2 : Xác định các cột sẽ hiển thị trong phần detail
        public override void InitColumDetail()
        {
            PMSupport.SetTitle(this, Status);
            XtraGridSupportExt.DecimalGridColumn(lvSoBan, "SO_TO", 0);
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            toolTip1.BackColor = Color.LightYellow;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            HelpGridColumn.CotMemoExEdit(lvYeuCau, "YEU_CAU");
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            lvSoBan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }
        #endregion

        #region Step 3 : Xác định các control trong filter part và Khởi tạo control trong phần filter.
        public override void PLLoadFilterPart()
        {
            this._RefreshAction(null);
            PLTimeSheetUtil.PermissionForControl(cmbNguoiGui
                , barSubItem1.Visibility == DevExpress.XtraBars.BarItemVisibility.Always
                , cmbNguoiGui.Visible == true);
            cmbNguoiNhan.Enabled = cmbNguoiGui.Enabled;
        }
        #endregion

        #region Step 4 : Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
               new string[] { "Đã Fax", "Không Fax" },
               new string[] { "fwDuyet.png", "fwKhongDuyet.png" },
               "ID",
               new DelegationLib.CallFunction_MulIn_NoOut[]{    
                   ThayDoi_TT_DaFax,ThayDoi_TT_KhongFax
               }
               );
            return menu;
        }
        private void ThayDoi_TT_KhongFax(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn thay đổi tình trạng của dữ liệu đang chọn không?") == DialogResult.Yes)
                {
                    int[] Selected_row = gridViewMaster.GetSelectedRows();
                    foreach (int i in Selected_row)
                    {
                        DataRow row = gridViewMaster.GetDataRow(i);
                        if (HelpNumber.ParseInt64(row["TINH_TRANG_FAX_ID"]) != 3)
                        {
                            DAHoTroInAn.CapNhatTinhTrangFax(HelpNumber.ParseInt64(row["ID"]), 4);
                            row["TINH_TRANG_FAX_ID"] = 4;
                        }
                    }
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                    HookFocusRow();
                }
            }
        }
        private void ThayDoi_TT_DaFax(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn thay đổi tình trạng của dữ liệu đang chọn không?") == DialogResult.Yes)
                {
                    int[] Selected_row = gridViewMaster.GetSelectedRows();
                    foreach (int i in Selected_row)
                    {
                        DataRow row = gridViewMaster.GetDataRow(i);
                        if (HelpNumber.ParseInt64(row["TINH_TRANG_FAX_ID"]) != 3)
                        {
                            DAHoTroInAn.CapNhatTinhTrangFax(HelpNumber.ParseInt64(row["ID"]), 3);
                            row["TINH_TRANG_FAX_ID"] = 3;
                        }
                    }
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                    HookFocusRow();
                }
            }  
        }
        public void frm_refeshtt()
        {
            Fix.PLRefresh();
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        #region Step 5 : Xây dựng Query Buider cho việc tìm kiếm
        private void InitSaveQueryDialog()
        {
            string view =UpdateRow();
            HelpControl.addSaveQueryDialog(this, this.barManager1, this.gridControlMaster, this.gridViewMaster._GetPLGUI(), view);
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg wait = new FWWaitingMsg();
            QueryBuilder query = new QueryBuilder(UpdateRow());
            try
            {
                StringBuilder cond = new StringBuilder("");
                if (cmbNguoiGui._getSelectedID() != -1) cond.Append(string.Format("NGUOI_GUI_ID = {0}", cmbNguoiGui._getSelectedID()));
                long[] arrNguoiNhan = cmbNguoiNhan._SelectedIDs;
                if (arrNguoiNhan.Length > 0 && cond.Length > 0) cond.Append(" OR ");
                int temp = arrNguoiNhan.Length;
                foreach (long id in arrNguoiNhan)
                {
                    cond.Append(string.Format(@"(NGUOI_NHAN_ID LIKE '{0}%') 
                        OR (NGUOI_NHAN_ID LIKE '%,{0},%') OR (NGUOI_NHAN_ID LIKE '%,{0}')", id));
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
                query.addDateFromTo("THOI_GIAN_CAP_NHAT", ngayKT.FromDate, ngayKT.ToDate);
                query.addID("MUC_DO_UU_TIEN_ID", cmbMucUuTien._getSelectedID());
                query.addID("TINH_TRANG_FAX_ID", cmbTinhTrang._getSelectedID());
                query.addCondition(" 1=1 ");  
                DataSet Master_ds = HelpDB.getDatabase().LoadDataSet(query);
                gridControlMaster.DataSource = Master_ds.Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            wait.Finish();
            return null;
        }
        #endregion

        #region Step 7 : Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            frmYeuCauFax frm = new frmYeuCauFax(id, null);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        public override void ShowUpdateForm(long id)
        {
            frmYeuCauFax frm = new frmYeuCauFax(id, false);
            frm.RefreshFrbug += new frmYeuCauFax.RefreshFrm(frm_RefreshFrbug);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        void frm_RefreshFrbug(DOHoTroFax doHoTroFax)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            dr["NGUOI_GUI_ID"] = doHoTroFax.NGUOI_GUI_ID;
            dr["NGUOI_NHAN_ID"] = doHoTroFax.NGUOI_NHAN_ID;
            dr["THOI_GIAN_CAP_NHAT"] = doHoTroFax.THOI_GIAN_CAP_NHAT;
            dr["NOI_DUNG_KEM_THEO"] = doHoTroFax.NOI_DUNG_KEM_THEO;
            dr["TINH_TRANG_FAX_ID"] = doHoTroFax.TINH_TRANG_FAX_ID;
            dr["MUC_DO_UU_TIEN_ID"] = doHoTroFax.MUC_DO_UU_TIEN_ID;
            dr["TEN_NGUOI_NHAN"] = doHoTroFax.TEN_NGUOI_NHAN;
            dr["GUI_DEN_SO"] = doHoTroFax.GUI_DEN_SO;
        }

        public override long[] ShowAddForm()
        {
            frmYeuCauFax frm = new frmYeuCauFax();
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }

        #endregion

        #region Step 8 : Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            try
            {
                int[] Selected_row = gridViewMaster.GetSelectedRows();
                DataRow[] row = new DataRow[Selected_row.Length];
                int j = 0;
                foreach (int i in Selected_row)
                {
                    row[j] = gridViewMaster.GetDataRow(i);
                    j++;
                }
                foreach (DataRow dr in row)
                {
                    if (HelpNumber.ParseInt64(dr["ID"]) == id && dr["TINH_TRANG_FAX_ID"].ToString() == DMCTinhTrangFax.Instance.DA_FAX.ToString())
                    {
                        HelpMsgBox.ShowNotificationMessage("Yêu cầu này đã được fax,không cho phép xóa!");
                        return false;
                    }
                }
                DAHoTroInAn.RemoveAllFilesPrint(id);
                return FWDBService.DeleteRecord("HO_TRO_FAX", "ID", id);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }

        public override _Print InAction(long[] ids)
        {
            return null;
        }

        #endregion

        #region Step 9 : HookFocusRow & lấy dữ liệu
        public override void HookFocusRow()
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row != null)
            {
                if (HelpNumber.ParseInt64(row["TINH_TRANG_FAX_ID"]) == DMCTinhTrangFax.Instance.DA_FAX)
                {
                    barSubItem1.Enabled = false;
                    barButtonItemUpdate.Enabled = false;
                    barButtonItemDelete.Enabled = false;
                }
                else
                {
                    barSubItem1.Enabled = true;
                    barButtonItemUpdate.Enabled = true;
                    barButtonItemDelete.Enabled = true;
                }
            }
        }
        
        #endregion

        #region Step 10 : UpdateRow
        public override string UpdateRow()
        {
            return @"SELECT HT.*
                            FROM  HO_TRO_FAX HT 
                            WHERE 1=1";
        }
        #endregion

        #region sự kiện trên layout tài liệu
        
        private void rep_luu_file_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }

        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
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
        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            AppCtrl.InitTreeChonNhanVien_Choice1(cmbNguoiGui, true);
            AppCtrl.InitTreeChonNhanVien(cmbNguoiNhan,false,false);
            cmbNguoiNhan._SelectedIDs = new long[] { FrameworkParams.currentUser.employee_id };
            DMCMucDoUuTien.I.InitCtrl(cmbMucUuTien, true, true);
            DMCTinhTrangFax.Instance.InitCtrl(cmbTinhTrang);
            return null;
        }
        #endregion
    }
}
