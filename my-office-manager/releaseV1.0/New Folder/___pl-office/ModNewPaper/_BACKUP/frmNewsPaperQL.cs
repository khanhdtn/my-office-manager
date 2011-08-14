using System;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data;
using DAO;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DTO;
using LumiSoft.Net.Mime;
using ProtocolVN.App.Office;
using ProtocolVN.DanhMuc;

namespace pl.office.form
{
    public partial class frmTinTucQL : PhieuQuanLy10Change
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
        //protected DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
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
        //protected DevExpress.XtraGrid.GridControl gridControlMaster;
        //protected DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        //protected DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //protected DevExpress.XtraTab.XtraTabPage xtraTabPageDetail;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTinTucQL).FullName,
                PMSupport.UpdateTitle("Quản lý tin tức", Status),
                ParentID, true,
                typeof(frmTinTucQL).FullName,
                true, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private DOTinTuc do_TT;
        private DOLuuTruTapTin do_luu_tru_tt;
        private bool IsLoad = false ;
        PhieuQuanLy10Fix fix = null;
        BarButtonItem item_TL;
        BarButtonItem item_HuyTL;
        #endregion

        #region Các hàm khởi tạo
        public frmTinTucQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "TIEU_DE";
            fix = new PhieuQuanLy10Fix(this);
            PMSupport.SetTitle(this, Status);
            PLTinTuc.ChonNhomTin(PLNhomTT, false);
            this.barButtonItemSet.Glyph = FWImageDic.BUSINESS_IMAGE20;
            this.barButtonItemUnSet.Glyph = FWImageDic.BUSINESS_IMAGE20;
            this.barButtonItemSet.Enabled = false;
            this.barButtonItemUnSet.Enabled = false;
            this.barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.barButtonItemPrint.Visibility = BarItemVisibility.Never;
            this.barButtonItemDuyet.Glyph = FWImageDic.COMMIT_IMAGE16;
            this.barButtonItemK_Duyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDuyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemK_Duyet.Glyph = FWImageDic.UNCOMMIT_IMAGE16;
            this.Load += new EventHandler(frmTinTucQL_Load);
            gridViewMaster.OptionsView.ColumnAutoWidth = true;
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            gridViewMaster.OptionsSelection.MultiSelect = true;
        }        
        private void frmTinTucQL_Load(object sender, EventArgs e)
        {
            IsLoad = true;
            gridControlMaster.Load += new EventHandler(gridControlMaster_Load);            
            //Thiết lập cho menu nghiệp vụ
            if (barSubItem1.ItemLinks.Count > 0)
            {
                item_TL = barSubItem1.ItemLinks[0].Item as BarButtonItem;
                item_HuyTL = barSubItem1.ItemLinks[1].Item as BarButtonItem;
            }
                //Gán sự kiện cho các nút
            lbl_TTDK.Click += delegate(object lbl_TTDK1, System.EventArgs Click)
            {
                frmSaveOpen frm = new frmSaveOpen(do_luu_tru_tt.NOI_DUNG, do_luu_tru_tt.TEN_FILE);
                ProtocolForm.ShowModalDialog(this, frm);
            };
            lbl_TTDK.MouseMove += delegate(object lbl_TTDK2, MouseEventArgs M_Move)
            {
                lbl_TTDK.ForeColor = Color.Red;
            };
            lbl_TTDK.MouseLeave += delegate(object lbl_TTDK3, System.EventArgs M_Leave)
            {
                lbl_TTDK.ForeColor = Color.Blue;
            };
            DataSet ds = DATinTuc.Instance.Get_5_tin(PLNhomTT._getSelectedID(), dateTungay.DateTime, dateDenngay.DateTime,DuyetSelect);
            //Load tin tức nổi bật
            if (ds.Tables[0].Rows.Count > 0)
            {
                do_TT = DATinTuc.Instance.get_TinTuc(HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["ID"]));
                if (do_TT != null) do_luu_tru_tt = DATinTuc.Instance.get_TapTin(do_TT.ID);
                this.ThongTinNoiBat(do_TT, do_luu_tru_tt);
                barSubItem1.Enabled = true;
                gridControlMaster.DataSource = ds.Tables[0];
            }
            else barSubItem1.Enabled = false;
            barButtonItemDuyet.ItemClick += new ItemClickEventHandler(barButtonItemDuyet_ItemClick);
            barButtonItemK_Duyet.ItemClick += new ItemClickEventHandler(barButtonItemK_Duyet_ItemClick);
            HookFocusRow();
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
                XtraGridSupportExt.ComboboxGridColumn(CotNhomtin, DABase.getDatabase().LoadDataSet("Select * from DM_NHOM_TIN_TUC").Tables[0], "ID", "NAME", "NHOM_TIN");
                XtraGridSupportExt.TextLeftColumn(CotTieude, "TIEU_DE");
                HelpGridColumn.CotReadOnlyDate(CotNgaytao, "NGAY_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
                XtraGridSupportExt.ComboboxGridColumn(CotNguoitao, DABase.getDatabase().LoadDataSet("Select * from DM_NHAN_VIEN where VISIBLE_BIT='Y'").Tables[0], "ID", "NAME", "NGUOI_CAP_NHAT");
                XtraGridSupportExt.TextLeftColumn(CotPrior, "PRIOR");
                XtraGridSupportExt.TextLeftColumn(CotTin_Noi_Bat, "TIN_NOI_BAT");
                GridColumn column = new GridColumn();
                XtraGridSupportExt.CreateDuyetGridColumn(column);
                this.gridViewMaster.Columns.Add(column);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
               
        }

        void gridViewMaster_CustomDrawRowPreview(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Red;
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            e.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Italic);
        }

        public override void InitColumDetail()
        {
            StyleFormatCondition cn = new StyleFormatCondition(FormatConditionEnum.Equal, CotPrior, null, "Y");
            cn.Appearance.ForeColor = Color.Red;
            cn.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            cn.ApplyToRow = true;
            gridViewMaster.FormatConditions.Add(cn);           
        }

        #endregion

        #region Xác định các control trong filter part và Khởi tạo control trong phần filter.        
        public override void PLLoadFilterPart()
        {
            HelpControl.RedCheckEdit(checkTin_noi_bat);
            checkTin_noi_bat.Checked = true;
            //Định dạng font chữ
            this.Chu_de.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Thoi_gian_cap_nhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNguoi_cap_nhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbl_TTDK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
        }
        #endregion

        #region Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                new string[] { "Thiết lập tin nổi bật", "Hủy thiết lập tin nổi bật" },
                new string[] { "FNoiBat", "FHuyNoiBat" },
                "ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    FNoiBat,FHuyNoiBat                    
               },new PermissionItem[]{
                   AppPermission.FThietLapTinNoiBat.GetPermissionItem(PermissionType.VIEW_HIDE),
                   AppPermission.FThietLapTinNoiBat.GetPermissionItem(PermissionType.VIEW_HIDE)
               } );
            return menu;            
        }
        private void FNoiBat(List<object> ids)
        {
            try
            {
                if (ids != null && ids.Count > 0)
                {
                    DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                    DATinTuc.Instance.Update_tin_noi_bat(HelpNumber.ParseInt64(row["ID"]), "Y");
                    if (item_TL != null)
                        item_TL.Visibility = BarItemVisibility.Never;
                    if (item_HuyTL != null)
                        item_HuyTL.Visibility = BarItemVisibility.Always;
                    DataTable dt = new DataTable();
                    //Xóa tin nổi bật trước đó
                    dt = gridControlMaster.DataSource as DataTable;
                    foreach (DataRow row_1 in dt.Rows)
                    {
                        row_1["PRIOR"] = "N";
                    }
                    //Thiếp lập tin nổi bật
                    row["PRIOR"] = "Y";
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        private void FHuyNoiBat(List<object> ids)
        {
            try
            {
                if (ids != null && ids.Count > 0)
                {
                    DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                    DATinTuc.Instance.Update_tin_noi_bat(HelpNumber.ParseInt64(row["ID"]), "N");
                    if (item_TL != null)
                        item_TL.Visibility = BarItemVisibility.Always;
                    if(item_HuyTL!=null)
                        item_HuyTL.Visibility = BarItemVisibility.Never;
                    row["PRIOR"] = "N";
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        #region Xây dựng Query Buider cho việc tìm kiếm
        
        public override QueryBuilder PLBuildQueryFilter()
        {
            DataSet ds;
            if (!checkTin_noi_bat.Checked)
            {
                QueryBuilder query = new QueryBuilder
                (
                    " SELECT ID,PRIOR,TT.NHOM_TIN,TIEU_DE, NGAY_CAP_NHAT,TT.NGUOI_CAP_NHAT,NHOM_TIN,DUYET," +
                    " CASE WHEN PRIOR='Y' THEN 'Tin tức nổi bật' ELSE NULL END TIN_NOI_BAT" +
                    " FROM TIN_TUC TT WHERE 1=1"
                );
                query.addID("NHOM_TIN", PLNhomTT._getSelectedID());
                query.addDateFromTo("NGAY_CAP_NHAT", dateTungay.DateTime, dateDenngay.DateTime);
                query.setDescOrderBy("NGAY_CAP_NHAT");
                if (DATinTuc.Instance.getNguoiDuyet(DATinTuc.quyenDuyet).Contains(FrameworkParams.currentUser.employee_id))
                    query.addDuyet(PLDBUtil.FIELD_DUYET, DuyetSelect.layTrangThai());
                else
                    query.addCondition(string.Format("{0} = 2 or NGUOI_CAP_NHAT = {1}", PLDBUtil.FIELD_DUYET, FrameworkParams.currentUser.employee_id));
                ds = DABase.getDatabase().LoadDataSet(query);
                barSubItem1.Enabled = ds.Tables[0].Rows.Count > 0;
                gridControlMaster.DataSource = ds.Tables[0];
                HookFocusRow();
            }
            else
            {
                ds = DATinTuc.Instance.Get_5_tin(PLNhomTT._getSelectedID(), dateTungay.DateTime, dateDenngay.DateTime,DuyetSelect);
                barSubItem1.Enabled = ds.Tables[0].Rows.Count > 0;
                gridControlMaster.DataSource = ds.Tables[0];
                HookFocusRow();
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                this.ThongTinNoiBat(null, null);
                barButtonItemDuyet.Enabled = false;
                barButtonItemK_Duyet.Enabled = false;
            }
            return null;
        }

        #endregion

        #region Xác định các form xử lý khi chọn Thêm, Xem , Sửa
        
        public override void ShowViewForm(long id)
        {
            frmNewsPaper frm = new frmNewsPaper(id,null);
            ProtocolForm.ShowModalDialog(this, frm);
        }
        
        public override void ShowUpdateForm(long id)
        {            
            frmNewsPaper frm = new frmNewsPaper(id,false);  
            frm.Refresh_Data += new frmNewsPaper.Update_Data(UpDate_TinTuc);
            ProtocolForm.ShowModalDialog(this, frm);
            PLBuildQueryFilter();
        }
        
        public override long[] ShowAddForm()       
        {
            pl.office.form.frmNewsPaper frm = new frmNewsPaper();
            frm.Refresh_Data += new frmNewsPaper.Update_Data(UpDate_TinTuc);
            ProtocolForm.ShowModalDialog(this, frm);            
            return null;
        }
        void barButtonItemK_Duyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int[] Selected_row = gridViewMaster.GetSelectedRows();
                foreach (int i in Selected_row)
                {
                    DataRow row = gridViewMaster.GetDataRow(i);
                    if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.KhongDuyet).ToString())
                    {
                        PLMessageBox.ShowNotificationMessage("Tin '" + row["TIEU_DE"] + "' đã không duyệt!");
                    }
                    else
                    {
                        if (PLMessageBox.ShowConfirmMessage("Bạn có chắc không duyệt: " + row["TIEU_DE"] + "?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (DATinTuc.Instance.Update_tinh_trang(HelpNumber.ParseInt64(row["ID"]), ((Int32)DuyetSupportStatus.KhongDuyet).ToString(),FrameworkParams.currentUser.employee_id,HelpDB.getDatabase().GetSystemCurrentDateTime()))
                            {
                                DOTinTuc obj = DATinTuc.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                DATinTuc.Instance._SendThongBao(obj, "KHONG_DUYET");
                                row["DUYET"] = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();
                                barButtonItemK_Duyet.Enabled = false;
                                barSubItem1.Enabled = false;
                                barButtonItemDuyet.Enabled = true;
                                barButtonItemUpdate.Enabled = true;
                                barButtonItemDelete.Enabled = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }        

        void barButtonItemDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                int[] Selected_row = gridViewMaster.GetSelectedRows();
                foreach (int i in Selected_row)
                {
                    DataRow row = gridViewMaster.GetDataRow(i);
                    if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                    {
                        PLMessageBox.ShowNotificationMessage("Tin '" + row["TIEU_DE"] + "' đã duyệt!");
                    }
                    else
                    {
                        if (PLMessageBox.ShowConfirmMessage("Bạn có chắc duyệt: " + row["TIEU_DE"] + "?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (DATinTuc.Instance.Update_tinh_trang(HelpNumber.ParseInt64(row["ID"]), ((Int32)DuyetSupportStatus.Duyet).ToString(), FrameworkParams.currentUser.employee_id, HelpDB.getDatabase().GetSystemCurrentDateTime()))
                            {
                                DOTinTuc obj = DATinTuc.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                DATinTuc.Instance._SendThongBao(obj,"DUYET");
                                row["DUYET"] = ((Int32)DuyetSupportStatus.Duyet).ToString();
                                barButtonItemK_Duyet.Enabled = true;
                                barSubItem1.Enabled = true;
                                barButtonItemDuyet.Enabled = false;
                                barButtonItemUpdate.Enabled = false;
                                barButtonItemDelete.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }       
        #endregion

        #region Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            try
            {
                if (gridViewMaster.RowCount == 1)
                    ThongTinNoiBat(null, null);
                return (DatabaseFB.DeleteRecord("LUU_TRU_TAP_TIN", "ID", DATinTuc.Instance.TAP_TIN_ID(id)) && DatabaseFB.DeleteRecord("TIN_TUC", "ID", id));
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


        public override string UpdateRow()
        {
            return @"SELECT ID,PRIOR,(SELECT NAME FROM DM_NHOM_TIN_TUC NTT WHERE NTT.ID=TT.NHOM_TIN) NHOM_TT,TIEU_DE, NGAY_CAP_NHAT,(SELECT NAME FROM DM_NHAN_VIEN NV WHERE NV.ID=TT.NGUOI_CAP_NHAT) NGUOI_CAP_NHAT,NHOM_TIN,DUYET" +
                    " FROM TIN_TUC TT WHERE 1=1";
        }
        public override void HookFocusRow()
        {            
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            try
            {
                if (row != null)
                {
                    barButtonItemDuyet.Enabled = true;
                    barButtonItemK_Duyet.Enabled = true;
                    barButtonItemXem.Enabled = true;
                    for (int i = 0; i < barSubItem1.ItemLinks.Count; i++)
                    {                        
                        if (row["PRIOR"].ToString() == "Y")
                        {
                            item_TL.Visibility = BarItemVisibility.Never;
                            item_HuyTL.Visibility = BarItemVisibility.Always;
                        }
                        else
                        {
                            item_TL.Visibility = BarItemVisibility.Always;
                            item_HuyTL.Visibility = BarItemVisibility.Never;
                        }
                        break;                        
                    }
                    if (IsLoad)
                    {
                        IsLoad = false;
                        goto SetState;
                    }
                    do_TT = DATinTuc.Instance.get_TinTuc(HelpNumber.ParseInt64(row["ID"]));
                    if (do_TT != null) do_luu_tru_tt = DATinTuc.Instance.get_TapTin(do_TT.ID);
                    this.ThongTinNoiBat(do_TT, do_luu_tru_tt);
                }
                else
                {
                    this.ThongTinNoiBat(null, null);
                    barButtonItemDuyet.Enabled = false;
                    barButtonItemK_Duyet.Enabled = false;
                }
                SetState:
                if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                    {
                        barSubItem1.Enabled = false;
                        barButtonItemDuyet.Enabled = true;
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDelete.Enabled = true;
                        barButtonItemUpdate.Enabled = true;
                    }
                    else if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                    {
                        barSubItem1.Enabled = true;
                        barButtonItemDuyet.Enabled = false;
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDelete.Enabled = false;
                        barButtonItemUpdate.Enabled = false;
                    }
                    else
                    {
                        barSubItem1.Enabled = false;
                        barButtonItemDuyet.Enabled = true;
                        barButtonItemK_Duyet.Enabled = false;
                        barButtonItemDelete.Enabled = true;
                        barButtonItemUpdate.Enabled = true;
                    }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }         
        #endregion

        #region Các xử lý khác

        private void ThongTinNoiBat(DOTinTuc TTNew,DOLuuTruTapTin TAP_TIN)
        {
            try
            {
                if (TTNew != null)
                {
                    do_TT = TTNew;
                    do_luu_tru_tt = TAP_TIN;
                    Chu_de.Text = TTNew.TIEU_DE;
                    if (TAP_TIN.TEN_FILE != string.Empty)
                    {                       
                        lbl_TTDK.Text = TAP_TIN.TEN_FILE;
                        lbl_TTDK.Visible = true;
                        labelControl1.Visible = true;                       
                    }
                    else
                    {
                        lbl_TTDK.Visible = false;
                        labelControl1.Visible = false;
                    }
                    lblNguoi_cap_nhat.Text = ProtocolVN.DanhMuc.DMFWNhanVien.GetFullName(TTNew.NGUOI_CAP_NHAT);
                    lbl_Thoi_gian_cap_nhat.Text = TTNew.NGAY_CAP_NHAT.ToString(PLConst.FORMAT_DATETIME_STRING).Trim();
                    Web_QuaTrinhDaoTao.DocumentText = HelpByte.BytesToUTF8String(TTNew.NOI_DUNG);                  
                    popupControlContainer1.Visible =true;
                    barSubItem1.Enabled = true;                    
                }
                else
                {
                    popupControlContainer1.Visible = false;
                    Web_QuaTrinhDaoTao.DocumentText = string.Empty;
                    barSubItem1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        private void UpDate_TinTuc(DOTinTuc doTinTuc,DOLuuTruTapTin doLuu_Tru)
        {
            try
            {
                ThongTinNoiBat(doTinTuc, doLuu_Tru);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }        
        #endregion                                                                                   
        
        #region CHAUTV : Chức năng bổ sung : Gửi email thông báo tin mới cho nhân viên
        /// <summary>
        /// Gửi thông báo duyệt tin trên Tin tức (KHÔNG DÙNG NỮA)
        /// </summary>
        private bool _SendThongBao(DataRow row,string STATUS) { 
            ///Thông tin SMTP
            DOServer o = DAServer.Instance.LoadAll(1);
            ///1.Nội dung
            DOTinTuc newPegeper = DATinTuc.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
            AddressList To = new AddressList();
            string temp = "";
            switch (STATUS) {
                case "DUYET":
                    temp = "Có 1 tin mới được cập nhật.";
                    //Gửi đến tất cả các nhân viên
                    To = PLHelpMail.GetAddressList(new long[] {});
                    break;
                case "ADD": 
                    temp = "Có 1 tin tạo mới đang chờ duyệt.";
                    //Gửi đến những người có quyền duyệt
                    To = PLHelpMail.GetAddressList(new long[] { });
                    break;
                case "EDIT":
                    temp = "Có 1 tin chỉnh sửa đang chờ duyệt.";
                    //Gửi đến những người có quyền duyệt
                    To = PLHelpMail.GetAddressList(new long[] { });
                    break;
                case "KHONG_DUYET":
                    temp = "Có 1 tin không được duyệt.";
                    //Gửi đến người tạo tin
                    To = PLHelpMail.GetAddressList(new long[] { newPegeper.NGUOI_CAP_NHAT });
                    break;
                case "CHO_DUYET":
                    //Gửi đến người đã tạo tin
                    To = PLHelpMail.GetAddressList(new long[] { newPegeper.NGUOI_CAP_NHAT });
                    break;
            }
            string Title = HelpStringBuilder.GetTitleMailNewPageper(temp);
            
            string NhomTin = HelpDB.getDatabase().LoadDataSet(new QueryBuilder(
               @"SELECT * FROM DM_NHOM_TIN_TUC WHERE ID=" + newPegeper.NHOM_TIN +" AND 1=1")).Tables[0].Rows[0]["NAME"].ToString();
            string Subject = HelpStringBuilder.GetDesMailNewPageper(DMFWNhanVien.GetFullName(newPegeper.NGUOI_CAP_NHAT) , newPegeper.NGAY_CAP_NHAT.ToString() ,NhomTin,newPegeper.TIEU_DE);
            ///3.Gửi mail
            return PLHelpMail._SendMail(o.SMTP, 25,"", Title, o.NAME,o.EMAIL,o.PASS, To, null, null, Subject, "");
        }
        #endregion
              
    }
}