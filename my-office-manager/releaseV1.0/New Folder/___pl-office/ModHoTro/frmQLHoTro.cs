using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DAO;
using ProtocolVN.DanhMuc;
using ProtocolVN.App.Office;
using System.Text;
using ProtocolVN.Plugin.TimeSheet;

namespace office
{

    public partial class frmYeuCauHoTroQL : PhieuQuanLy10Change, IFormRefresh
    {
    //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
    //public partial class frmYeuCauHoTroQL : XtraFormPL
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
    //    public DevExpress.XtraGrid.GridControl gridControlMaster;
    //    public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
    //    public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
    //#endregion
   
        #region Vùng đặt Static 
        public static FormStatus Status = FormStatus.FIX;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmYeuCauHoTroQL).FullName,
                "Quản trị Công việc",
                ParentID, true,
                typeof(frmYeuCauHoTroQL).FullName,
                true, IsSep, "mnbToChuc.png", true, "", "");
        }
        
        #endregion

        #region Các khai báo biến 
        PhieuQuanLy10Fix Fix;
        private DataTable dtRecipient = null;
        #endregion
       
        #region hàm khởi tạo 

        public frmYeuCauHoTroQL()
        {            
            InitializeComponent();
            IDField = "ID";
            DisplayField = "CHU_DE";
            Fix = new PhieuQuanLy10Fix(this);
            PMSupport.SetTitle(this, Status);
            this.barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barButtonItemCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemNoCommit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;           
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridViewMaster.OptionsView.RowAutoHeight = true;
            //Các thiết lập cho lưới phản hồi
            CotNguoiphanhoi.OptionsColumn.AllowEdit = false;
            CotNguoiphanhoi.OptionsColumn.AllowFocus = false;
            CotTG_PH.OptionsColumn.AllowEdit = false;
            CotTG_PH.OptionsColumn.AllowFocus = false;
            CotNoidung.ColumnEdit.ReadOnly = true; 
            /////////////////////////////////////
            popupControlContainerFilter.Visible = true;            
            this.splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
        }
        private void frmQLCongviecQL1N_Load(object sender, EventArgs e)
        {
            AppCtrl.InitTreeChonNhanVien(cmbNguoiNhan, false, false);
            cmbNguoiNhan._SelectedIDs = new long[] { FrameworkParams.currentUser.employee_id };
            AppCtrl.InitTreeChonNhanVien_Choice1(cmbNguoiYC, true);
            PLTimeSheetUtil.PermissionForControl(cmbNguoiYC, cmbNguoiYC.Visible == true, false);
            cmbNguoiNhan.Enabled = cmbNguoiYC.Enabled;
            PLTinhtrang._init(DAYeuCau.Bang_tinh_trang(), "NAME", "ID");
            DMCMucDoUuTien.I.InitCtrl(PLMucuutien, false, true);
            gridControlMaster.Load += new EventHandler(gridControlMaster_Load);
            gridControlThongTinLienHe.Load += new EventHandler(gridControlThongTinLienHe_Load);
            InitMRUEditYeuCau();
            mruEditYeuCau.Click += new EventHandler(mruEditYeuCau_Click);
        }

        void mruEditYeuCau_Click(object sender, EventArgs e)
        {
            InitMRUEditYeuCau();
        }

        void gridControlThongTinLienHe_Load(object sender, EventArgs e)
        {
            gridViewThongTinLienHe.BestFitColumns();
        }

        void gridControlMaster_Load(object sender, EventArgs e)
        {
            gridViewMaster.BestFitColumns();
        }
        #endregion

        #region Xác định các cột sẽ hiển thị trong gridView 
        public override void InitColumnMaster()
        {
            try
            {
                DataSet ds = HelpDB.getDatabase().LoadDataSet("Select * from DM_NHAN_VIEN");
                DataTable Bang_uu_tien = DAYeuCau.DmCMucDoUuTienDataSource();
                DataTable Bang_tinh_trang = DAYeuCau.Bang_tinh_trang();
                XtraGridSupportExt.ComboboxGridColumn(CotNguoigui, ds.Tables[0], "ID", "NAME", "NGUOI_GUI_ID");
                HelpGridColumn.CotReadOnlyDate(CotTG_gui, "NGAY_CAP_NHAT_CUOI", PLConst.FORMAT_DATETIME_STRING);
                HelpGridExt1.colMultiline(CotNguoinhan, "NGUOI_NHAN");
                HelpGridColumn.CotTextLeft(CotNguoinhan, "NGUOI_NHAN");
                XtraGridSupportExt.TextLeftColumn(CotYeucau, "CHU_DE");
                HelpGridColumn.CotCombobox(CotMuc_ut, Bang_uu_tien.DataSet, "ID", "NAME", "MUC_UU_TIEN");
                XtraGridSupportExt.TextLeftColumn(CotLoaiYC, "TEN_YEU_CAU");
                XtraGridSupportExt.TextCenterColumn(CotSoLanPH, "SO_LAN_PH");
                HelpGridColumn.CotCombobox(CotTinhTrang, Bang_tinh_trang.DataSet, "ID", "NAME", "TINH_TRANG");
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        #endregion

        #region Xác định các cột sẽ hiển thị trong phần detail 
        public override void InitColumDetail()
        {
            XtraGridSupportExt.TextLeftColumn(CotNguoiphanhoi, "NGUOI_GUI");
            HelpGridColumn.CotReadOnlyDate(CotTG_PH, "NGAY_GUI", PLConst.FORMAT_DATETIME_STRING);
            HelpGridColumn.CotMemoExEdit(CotNoidung, "ND");
        }
        #endregion

        #region Xác định các control trong filter part và Khởi tạo control trong phần filter 
        public override void PLLoadFilterPart()
        {
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gridViewThongTinLienHe.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            HelpGrid.SetUpperTitle(this.gridViewMaster, "DANH SÁCH YÊU CẦU HỖ TRỢ");
        }
        #endregion

        #region Cài đặt menu 
        public override _MenuItem GetBusinessMenuList()
        {
            return null;
        }
        
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        #region Xây dựng Query Buider cho việc tìm kiếm 
        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            if (dtRecipient == null) dtRecipient = HelpDB.getDatabase().LoadDataSet("SELECT ID,NAME FROM DM_NHAN_VIEN").Tables[0];
            QueryBuilder query = new QueryBuilder(UpdateRow());

            StringBuilder cond = new StringBuilder("");
            if (cmbNguoiYC._getSelectedID() != -1) cond.Append(string.Format("YC.NGUOI_GUI_ID = {0}", cmbNguoiYC._getSelectedID()));
            long[] arrNguoiNhan = cmbNguoiNhan._SelectedIDs;
            if (arrNguoiNhan.Length > 0 && cond.Length > 0) cond.Append(" OR ");
            int temp = arrNguoiNhan.Length;
            foreach (long id in arrNguoiNhan)
            {
                cond.Append(string.Format(@"(YC.NGUOI_NHAN_ID LIKE '{0}%') 
                        OR (YC.NGUOI_NHAN_ID LIKE '%,{0},%') OR (YC.NGUOI_NHAN_ID LIKE '%,{0}') 
                        OR (YCTL.NGUOI_NHAN_ID LIKE '{0}%') 
                        OR (YCTL.NGUOI_NHAN_ID LIKE '%,{0},%') OR (YCTL.NGUOI_NHAN_ID LIKE '%,{0}')", id));
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
            if (mruEditYeuCau.Text.Trim() != "" && mruEditYeuCau.Text.Trim() != null)
            {
                query.addCondition(string.Format("CHU_DE = '{0}'", mruEditYeuCau.Text.Trim()));
            }
            if (PLMucuutien._getSelectedID() != -1)
                query.add("MUC_UU_TIEN", Operator.Equal,PLMucuutien._getSelectedID() , DbType.Int32);            
            if (PLTinhtrang._getSelectedID() != -1)
                query.add("TINH_TRANG", Operator.Equal, PLTinhtrang._getSelectedID(), DbType.Int32);

            query.addDateFromTo("YC.NGAY_GUI", ngayLamViec.FromDate, ngayLamViec.ToDate);
            query.setDescOrderBy("YC.NGAY_GUI");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            foreach (DataRow  row in ds.Tables[0].Rows)
                row["NGUOI_NHAN"] = GetNameOfRecipient(row["NGUOI_NHAN_ID"].ToString());
            gridControlMaster.DataSource = ds.Tables[0];
            msg.Finish();
            return null;
        }
        #endregion

        #region Xác định các form xử lý khi chọn Thêm, Xem , Sửa 

        public override void ShowViewForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            frmViewThreadSupport frm = new frmViewThreadSupport(id, HelpNumber.ParseInt64(row["NGUOI_GUI_ID"]),
                row["NGUOI_NHAN_ID"].ToString(), HelpNumber.ParseInt64(row["TINH_TRANG"]));
            frm.AfterDeleteSuccessfully += new frmViewThreadSupport._AfterDeleteSuccessfully(AfterDeleteSuccessfully);
            frm.AfterUpdateStatusOfSupport += delegate(long TinhTrang, object[] infos) {
                row["TINH_TRANG"] = TinhTrang;
                if (infos != null && infos.Length > 0)
                {
                    row["LOAI_YEU_CAU_ID"] = HelpNumber.ParseInt64(infos[0]);
                    row["TEN_YEU_CAU"] = DAYeuCau.GetTenYeuCau(HelpNumber.ParseInt64(infos[0]));
                    row["CHU_DE"] = infos[1].ToString();
                    row["MUC_UU_TIEN"] = HelpNumber.ParseInt64(infos[2]);
                    row["NGUOI_NHAN"] = GetNameOfRecipient(infos[3].ToString());
                    row["NGAY_CAP_NHAT"] = infos[4];
                    gridViewMaster.RefreshData();
                }
                else row["SO_LAN_PH"] = (int)row["SO_LAN_PH"] + 1;
            };
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        void AfterDeleteSuccessfully(bool isDeleteSupport)
        {
            if (isDeleteSupport)
                gridViewMaster.DeleteRow(gridViewMaster.FocusedRowHandle);
            else
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                row["SO_LAN_PH"] = (int)row["SO_LAN_PH"] - 1;
            }
        }

        public override void ShowUpdateForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (string.Compare(row["TINH_TRANG"].ToString(), "4") == 0) {
                HelpMsgBox.ShowNotificationMessage("Không cho phép sửa hỗ trợ khi tình trạng đã hoàn tất.");
                return;
            }
            if (HelpNumber.ParseInt32(row["SO_LAN_PH"]) > 0) {
                HelpMsgBox.ShowNotificationMessage("Không cho phép sửa hỗ trợ khi đã có phản hồi.");
                return;
            }
            frmHotro frm = new frmHotro(id, false);
            frm.RefreshAfterInsert += new frmHotro.RefreshData(frm_RefreshAfterInsert);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        void frm_RefreshAfterInsert(DOYeuCau doYeuCau)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            row["LOAI_YEU_CAU_ID"] = doYeuCau.LOAI_YEU_CAU_ID;
            row["TEN_YEU_CAU"] = DAYeuCau.GetTenYeuCau(doYeuCau.LOAI_YEU_CAU_ID);
            row["CHU_DE"] = doYeuCau.CHU_DE;
            row["NGUOI_GUI_ID"] = doYeuCau.NGUOI_GUI_ID;
            row["NGUOI_NHAN"] = GetNameOfRecipient(doYeuCau.NGUOI_NHAN_ID);
            row["NGAY_CAP_NHAT"] = doYeuCau.NGAY_CAP_NHAT;
            row["TINH_TRANG"] = doYeuCau.TINH_TRANG;
            row["MUC_UU_TIEN"] = doYeuCau.MUC_UU_TIEN;
            gridViewMaster.RefreshData();
        }


        public override long[] ShowAddForm()
        {
            frmHotro frm = new frmHotro();
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }

        private void Refresh_Data(object sender, DOYeuCau e)
        {
            
        }

        #endregion

        #region Xác định các hành động trên form 

        public override bool XoaAction(long id)
        {       
            return DAYeuCau.Delete(id); 
        }

        public override _Print InAction(long[] ids)
        {
            return null;
        }

        #endregion

        #region Các hàm xử lý khác 

        private void InitMRUEditYeuCau()
        {
            mruEditYeuCau.Text = "";
            mruEditYeuCau.Properties.Items.Clear();
            QueryBuilder sql = new QueryBuilder(@"SELECT CHU_DE FROM YEU_CAU YC LEFT JOIN YEU_CAU_TRA_LOI YCTL ON YCTL.YEU_CAU_ID = YC.ID WHERE 1=1");
            sql.addDateFromTo("YC.NGAY_GUI", ngayLamViec.FromDate, ngayLamViec.ToDate);
            StringBuilder cond = new StringBuilder("");
            if (cmbNguoiYC._getSelectedID() != -1) cond.Append(string.Format("YC.NGUOI_GUI_ID = {0}", cmbNguoiYC._getSelectedID()));
            long[] arrNguoiNhan = cmbNguoiNhan._SelectedIDs;
            if (arrNguoiNhan.Length > 0 && cond.Length > 0) cond.Append(" OR ");
            int temp = arrNguoiNhan.Length;
            foreach (long id in arrNguoiNhan)
            {
                cond.Append(string.Format(@"(YC.NGUOI_NHAN_ID LIKE '{0}%') 
                        OR (YC.NGUOI_NHAN_ID LIKE '%,{0},%') OR (YC.NGUOI_NHAN_ID LIKE '%,{0}') 
                        OR (YCTL.NGUOI_NHAN_ID LIKE '{0}%') 
                        OR (YCTL.NGUOI_NHAN_ID LIKE '%,{0},%') OR (YCTL.NGUOI_NHAN_ID LIKE '%,{0}')", id));
                temp--;
                if (temp > 0)
                {
                    cond.Append(" OR ");
                }
            }
            if (cond.Length > 0)
            {
                sql.addCondition(cond.ToString());
            }
            if (PLTinhtrang._getSelectedID() > 0)
            {
                sql.addID("TINH_TRANG", PLTinhtrang._getSelectedID());
            }
            if (PLMucuutien._getSelectedID() > 0)
            {
                sql.addID("MUC_UU_TIEN", PLMucuutien._getSelectedID());
            }
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                mruEditYeuCau.Properties.Items.Add(row["CHU_DE"]);
            }
        }
        private string GetNameOfRecipient(string RecipientIDs) {
            if (RecipientIDs.Length == 0) return string.Empty;
            DataRow[] rows = dtRecipient.Select(string.Format("ID in ({0})",RecipientIDs));
            StringBuilder stringName = new StringBuilder("");
            foreach (DataRow row in rows)
            {
                stringName.Append(row["NAME"].ToString());
                stringName.Append("\n");
            }
            if (stringName.Length == 0) return string.Empty;
            return stringName.ToString().Remove(stringName.ToString().LastIndexOf("\n"));
        }
       
        private string Convert_String(string HTML)
        {
            string[] tag = { "</A>", "</EM>", "</U>", "</FONT>", "</STRONG>", "</P>", "</body>" };
            //Delete tags </A>,</EM>,</U>...
            for (int i = 0; i < tag.Length; i++)
            {
                if (HTML.IndexOf(tag[i]) > 0)
                {
                    HTML = HTML.Remove(HTML.IndexOf(tag[i]));
                }
            }
            //Delete tag <IMG>
            while (HTML.IndexOf("<IMG") > 0)
            {
                char[] Str = HTML.ToCharArray();
                int i = HTML.IndexOf("<IMG");
                for (int j = i; j < HTML.Length; j++)
                {
                    if (Str[j] == '>')
                    {
                        HTML = HTML.Remove(i, j - i + 1);
                        break;
                    }
                }
            }
            //Delete tag <A>
            while (HTML.IndexOf("<A") > 0)
            {
                char[] Str = HTML.ToCharArray();
                int i = HTML.IndexOf("<A");
                for (int j = i; j < HTML.Length; j++)
                {
                    if (Str[j] == '>')
                    {
                        HTML = HTML.Remove(i, j - i + 1);
                        break;
                    }
                }
            }
            HTML = HTML.Remove(0, HTML.LastIndexOf('>') + 1);
            return HTML;
        }
       
        public override void HookFocusRow()
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row == null) return;
            //Chỉ cho sửa yêu cầu hỗ trợ của người đang đăng nhập
            barSubItem1.Enabled = barButtonItemDelete.Enabled = barButtonItemUpdate.Enabled = string.Compare(row["NGUOI_GUI_ID"].ToString(), FrameworkParams.currentUser.employee_id.ToString()) == 0;
        }       
        
        public override string UpdateRow()
        {
            return @"SELECT DISTINCT YC.*,DM_YC.NAME AS TEN_YEU_CAU,DM_NV_GUI.NAME AS NGUOI_GUI,'' AS NGUOI_NHAN,
                    (SELECT COUNT(YEU_CAU_TRA_LOI.YEU_CAU_ID) FROM YEU_CAU_TRA_LOI WHERE YEU_CAU_TRA_LOI.YEU_CAU_ID=YC.ID) SO_LAN_PH,
                    IIF((SELECT MAX(IIF(YT.NGAY_GUI >= YC.NGAY_GUI,YT.NGAY_GUI,YC.NGAY_GUI))
                    FROM YEU_CAU_TRA_LOI YT WHERE YT.YEU_CAU_ID=YC.ID) IS NULL,YC.NGAY_GUI,(SELECT MAX(IIF(YT.NGAY_GUI >= YC.NGAY_GUI,YT.NGAY_GUI,YC.NGAY_GUI))
                    FROM YEU_CAU_TRA_LOI YT WHERE YT.YEU_CAU_ID=YC.ID)) NGAY_CAP_NHAT_CUOI
                    FROM ((YEU_CAU YC INNER JOIN DM_LOAI_YEU_CAU DM_YC ON YC.LOAI_YEU_CAU_ID=DM_YC.ID)
                    INNER JOIN DM_NHAN_VIEN DM_NV_GUI ON DM_NV_GUI.ID=YC.NGUOI_GUI_ID)
                    LEFT JOIN YEU_CAU_TRA_LOI YCTL ON YCTL.YEU_CAU_ID = YC.ID
                    WHERE DM_YC.VISIBLE_BIT = 'Y' AND 1=1";
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