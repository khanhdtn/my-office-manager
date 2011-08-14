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

namespace office
{
    public partial class frmTinTucQL : PhieuQuanLy10Change,IFormRefresh
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
        #endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTinTucQL).FullName,
                HelpDebug.UpdateTitle("Quản lý tin tức", Status),
                ParentID, true,
                typeof(frmTinTucQL).FullName,
                true, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private DOTinTuc do_TT;
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
            this._UsingExportToFileItem = false;
            TinTucPermission.I.Init();
            fix = new PhieuQuanLy10Fix(this);
            HelpDebug.SetTitle(this, Status);
            
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
            
            DataSet ds = DATinTuc.Instance.Get_5_tin(PLNhomTT._getSelectedID(), ngay.FromDate, ngay.ToDate,DuyetSelect);
            //Load tin tức nổi bật
            if (ds!= null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                do_TT = DATinTuc.Instance.get_TinTuc(HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["ID"]),false);
                do_TT.DSTapTinDinhKem = DALuuTruTapTin.Instance.GetTapTinByObjectID(do_TT.ID, 1);
                this.ThongTinNoiBat(do_TT);
                gridControlMaster.DataSource = ds.Tables[0];
                barSubItem1.Enabled = ds.Tables[0].Rows.Count > 0;
            }
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
                XtraGridSupportExt.ComboboxGridColumn(CotNhomtin, HelpDB.getDatabase().LoadDataSet("SELECT * FROM DM_NHOM_TIN_TUC").Tables[0], "ID", "NAME", "NHOM_TIN");
                XtraGridSupportExt.TextLeftColumn(CotTieude, "TIEU_DE");
                HelpGridColumn.CotReadOnlyDate(CotNgaytao, "NGAY_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
                GridColumn colHieuLuc = HelpGridColumn.CreateGridColumn(this.gridViewMaster, "Hiệu lực đến", 1, 100);
                HelpGridColumn.CotReadOnlyDate(colHieuLuc, "NGAY_HIEU_LUC", PLConst.FORMAT_DATETIME_STRING);
                XtraGridSupportExt.ComboboxGridColumn(CotNguoitao, DABase.getDatabase().LoadDataSet("SELECT * FROM DM_NHAN_VIEN WHERE VISIBLE_BIT='Y'").Tables[0], "ID", "NAME", "NGUOI_CAP_NHAT");
                CotNguoitao.Caption = "Người cập nhật";
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
            PLTinTuc.ChonNhomTin(PLNhomTT, true);
            HelpControl.RedCheckEdit(checkTin_noi_bat,false);
            //ngay.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromDateToDate;
            ngay.ReturnType = ProtocolVN.Framework.Win.Trial.TimeType.Date;
            //HelpDate.SetDateEdit(this.dateDenngay, HelpDB.getDatabase().GetSystemCurrentDateTime());

            checkTin_noi_bat.Checked = true;
            //Định dạng font chữ
            this.Chu_de.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Thoi_gian_cap_nhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNguoi_cap_nhat.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);

            this.DuyetSelect.unCheck(3);
            this.DuyetSelect.unCheck(2);
            this.DuyetSelect._initRedCheckEdit();
            this.DuyetSelect.unCheck(1);
            this.DuyetSelect.check(3);
            this.DuyetSelect.check(1);
            this.DuyetSelect.check(2);
            HelpGridExt1.DisableCaptionGroupCol(this.gridViewMaster);
        }
        #endregion

        #region Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                new string[] { "Thiết lập tin nổi bật", "Hủy thiết lập tin nổi bật" },
                new string[] { "star_red.png", "star_gray.png" },
                "ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    FNoiBat,FHuyNoiBat                    
               },new PermissionItem[]{
                   AppPermission.FQuanTriTinTuc.GetPermissionItem(PermissionType.VIEW_HIDE),
                   AppPermission.FQuanTriTinTuc.GetPermissionItem(PermissionType.VIEW_HIDE)
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
            FWWaitingMsg msg = new FWWaitingMsg();
            DataSet ds = new DataSet();
            long nhom_tin = PLNhomTT._getSelectedID();
            Feature fQuanTri = Permission.loadFeature(AppPermission.FQuanTriTinTuc.id
                , AppPermission.FQuanTriTinTuc.featureName, FrameworkParams.currentUser.username);
            if (!checkTin_noi_bat.Checked)
            {
                //Lấy tin nổi bật đã được duyệt.

                QueryBuilder query = new QueryBuilder
                    (
                        @" SELECT ID,PRIOR,NHOM_TIN,TIEU_DE, NGAY_CAP_NHAT,NGUOI_CAP_NHAT,DUYET, CASE WHEN SO_NGAY_HIEU_LUC > 0 THEN DATEADD(DAY,SO_NGAY_HIEU_LUC,NGAY_CAP_NHAT) ELSE NULL END AS NGAY_HIEU_LUC,
                     CASE WHEN PRIOR='Y' THEN 'Tin tức nổi bật' ELSE NULL END TIN_NOI_BAT
                     FROM TIN_TUC  WHERE PRIOR = 'Y' AND DUYET = '2' AND 1=1"
                    );
                query.addDateFromTo("NGAY_CAP_NHAT", ngay.FromDate, ngay.ToDate);
                if (fQuanTri.isRead)//(DATinTuc.Instance.getNguoiDuyet(DATinTuc.quyenDuyet).Contains(FrameworkParams.currentUser.employee_id))
                    query.addDuyet(PLConst.FIELD_DUYET, DuyetSelect.layTrangThai());
                else
                    query.addCondition(string.Format("1=1 or NGUOI_CAP_NHAT = {0}", FrameworkParams.currentUser.employee_id));
                query.addCondition("NHOM_TIN IN (SELECT ID FROM DM_NHOM_TIN_TUC WHERE VISIBLE_BIT ='Y')");
                ds = TinTucPermission.I._LoadDataSetWithResGroupPermission(query, "NHOM_TIN", nhom_tin);

                //Lấy tin mới nhất đã được duyệt.
                QueryBuilder query1 = new QueryBuilder
                    (
                        @" SELECT ID,PRIOR,NHOM_TIN,TIEU_DE, NGAY_CAP_NHAT,NGUOI_CAP_NHAT,DUYET,CASE WHEN SO_NGAY_HIEU_LUC > 0 THEN DATEADD(DAY,SO_NGAY_HIEU_LUC,NGAY_CAP_NHAT) ELSE NULL END AS NGAY_HIEU_LUC,
                     CASE WHEN PRIOR='Y' THEN 'Tin tức nổi bật' ELSE NULL END TIN_NOI_BAT
                     FROM TIN_TUC  WHERE PRIOR = 'N' AND DUYET = '2'
                     AND NGAY_CAP_NHAT = (SELECT MAX(NGAY_CAP_NHAT)
                                            FROM TIN_TUC
                                            WHERE PRIOR = 'N' AND DUYET = '2')  
                     AND 1=1"
                    );
                query1.addDateFromTo("NGAY_CAP_NHAT", ngay.FromDate, ngay.ToDate);
                query1.addCondition("NHOM_TIN IN (SELECT ID FROM DM_NHOM_TIN_TUC WHERE VISIBLE_BIT ='Y')");
                if (fQuanTri.isRead)//(DATinTuc.Instance.getNguoiDuyet(DATinTuc.quyenDuyet).Contains(FrameworkParams.currentUser.employee_id))
                    query1.addDuyet(PLConst.FIELD_DUYET, DuyetSelect.layTrangThai());
                else
                    query1.addCondition(string.Format("1=1 or NGUOI_CAP_NHAT = {0}", FrameworkParams.currentUser.employee_id));
                DataTable dtTT_Max = TinTucPermission.I._LoadDataSetWithResGroupPermission(query1, "NHOM_TIN", nhom_tin).Tables[0];

                //Lấy các tin còn lại
                QueryBuilder query2 = new QueryBuilder
                    (
                        @" SELECT ID,PRIOR,NHOM_TIN,TIEU_DE, NGAY_CAP_NHAT,NGUOI_CAP_NHAT,DUYET,CASE WHEN SO_NGAY_HIEU_LUC > 0 THEN DATEADD(DAY,SO_NGAY_HIEU_LUC,NGAY_CAP_NHAT) ELSE NULL END AS NGAY_HIEU_LUC,
                     CASE WHEN PRIOR='Y' THEN 'Tin tức nổi bật' ELSE NULL END TIN_NOI_BAT
                     FROM TIN_TUC  WHERE NGAY_CAP_NHAT <> (SELECT MAX(NGAY_CAP_NHAT)
                                            FROM TIN_TUC
                                            WHERE PRIOR = 'N' AND DUYET = '2')
                     AND 1=1"
                    );
                query2.addDateFromTo("NGAY_CAP_NHAT", ngay.FromDate, ngay.ToDate);
                query2.addCondition("NHOM_TIN IN (SELECT ID FROM DM_NHOM_TIN_TUC WHERE VISIBLE_BIT ='Y')");
                query2.setDescOrderBy("NGAY_CAP_NHAT");
                if (ds.Tables[0].Rows.Count > 0)
                    query2.addCondition(string.Format("ID != '{0}'", ds.Tables[0].Rows[0]["ID"].ToString()));
                if (fQuanTri.isRead)//(DATinTuc.Instance.getNguoiDuyet(DATinTuc.quyenDuyet).Contains(FrameworkParams.currentUser.employee_id))
                    query2.addDuyet(PLConst.FIELD_DUYET, DuyetSelect.layTrangThai());
                else
                    query2.addCondition(string.Format("{0}='2' or NGUOI_CAP_NHAT = {1}", PLConst.FIELD_DUYET, FrameworkParams.currentUser.employee_id));

                DataTable dtTT = TinTucPermission.I._LoadDataSetWithResGroupPermission(query2, "NHOM_TIN", nhom_tin).Tables[0];
                foreach (DataRow row in dtTT_Max.Rows) ds.Tables[0].ImportRow(row);
                foreach (DataRow row in dtTT.Rows) ds.Tables[0].ImportRow(row);
                gridControlMaster.DataSource = ds.Tables[0];
                barSubItem1.Enabled = ds.Tables[0].Rows.Count > 0;
                HookFocusRow();
            }
            else
            {
                ds = DATinTuc.Instance.Get_5_tin(PLNhomTT._getSelectedID(), ngay.FromDate, ngay.ToDate, DuyetSelect);
                barSubItem1.Enabled = ds.Tables[0].Rows.Count > 0;
                gridControlMaster.DataSource = ds.Tables[0];
                barSubItem1.Enabled = ds.Tables[0].Rows.Count > 0;
                HookFocusRow();
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                this.ThongTinNoiBat(null);
                barButtonItemDuyet.Enabled = false;
                barButtonItemK_Duyet.Enabled = false;
            }
            msg.Finish();
            return null;
        }

        #endregion

        #region Xác định các form xử lý khi chọn Thêm, Xem , Sửa
        
        public override void ShowViewForm(long id)
        {
            frmNewsPaper frm = new frmNewsPaper(id,null);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }
        
        public override void ShowUpdateForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row == null) return;
            if (TinTucPermission.I._checkPermissionRes(
                HelpNumber.ParseInt64(row["ID"]), PermissionOfResource.RES_PERMISSION_TYPE.UPDATE) == false)
            {
                HelpMsgBox.ShowNotificationMessage("Bạn không có quyền sửa tin tức này!");
                return;
            }
            frmNewsPaper frm = new frmNewsPaper(HelpNumber.ParseInt64(row["ID"]), false);  
            frm.AfterUpdateSuccessfully += new frmNewsPaper._AfterUpdateSuccessfully(frm_AfterUpdateSuccessfully);
            HelpProtocolForm.ShowModalDialog(this, frm);
            PLBuildQueryFilter();
        }

        void frm_AfterUpdateSuccessfully(DOTinTuc doTinTuc)
        {
            try
            {
                ThongTinNoiBat(doTinTuc);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }

        public override long[] ShowAddForm()
        {
            office.frmNewsPaper frm = new frmNewsPaper();
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }

        void frm_AfterAddSuccessfully(DOTinTuc doTinTu)
        {
            throw new NotImplementedException();
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
                        HelpMsgBox.ShowNotificationMessage("Dữ liệu đang chọn đã không duyệt!");
                    }
                    else
                    {
                        if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc không duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
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
                        HelpMsgBox.ShowNotificationMessage("Dữ liệu đang chọn đã duyệt!");
                    }
                    else
                    {
                        if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (DATinTuc.Instance.Update_tinh_trang(HelpNumber.ParseInt64(row["ID"]), ((Int32)DuyetSupportStatus.Duyet).ToString(), FrameworkParams.currentUser.employee_id, HelpDB.getDatabase().GetSystemCurrentDateTime()))
                            {
                                DOTinTuc obj = DATinTuc.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                DATinTuc.Instance._SendThongBao(obj, "DUYET");
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
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (row == null) return true;
                id = HelpNumber.ParseInt64(row["ID"]);
                if (TinTucPermission.I._checkPermissionRes(
                  id, PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa tin tức này!");
                    return false;
                }
                if (gridViewMaster.RowCount == 1)
                    ThongTinNoiBat(null);
                return (FWDBService.DeleteRecord("LUU_TRU_TAP_TIN", "ID", DATinTuc.Instance.TAP_TIN_ID(id)) && DatabaseFB.DeleteRecord("TIN_TUC", "ID", id));
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
                    do_TT = DATinTuc.Instance.get_TinTuc(HelpNumber.ParseInt64(row["ID"]),false);
                    do_TT.DSTapTinDinhKem = DALuuTruTapTin.Instance.GetTapTinByObjectID(do_TT.ID, 1);
                    this.ThongTinNoiBat(do_TT);
                }
                else
                {
                    this.ThongTinNoiBat(null);
                    barButtonItemDuyet.Enabled = false;
                    barButtonItemK_Duyet.Enabled = false;
                }
                SetState:
                if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                    {
                        barButtonItemDuyet.Enabled = true;
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDelete.Enabled = true;
                        barButtonItemUpdate.Enabled = true;
                    }
                    else if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                    {
                        barButtonItemDuyet.Enabled = false;
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDelete.Enabled = false;
                        barButtonItemUpdate.Enabled = false;
                    }
                    else
                    {
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

        private void ThongTinNoiBat(DOTinTuc TTNew)
        {
            try
            {
                flowLayoutPanel2.Controls.Clear();
                if (TTNew != null)
                {
                    do_TT = TTNew;
                    Chu_de.Text = TTNew.TIEU_DE;
                    if (do_TT.DSTapTinDinhKem != null && do_TT.DSTapTinDinhKem.Tables.Count > 0 && do_TT.DSTapTinDinhKem.Tables[0].Rows.Count > 0)
                    {

                        labelControl1.Visible = true;
                        int wi = 0;
                        foreach (DataRow r in do_TT.DSTapTinDinhKem.Tables[0].Rows)
                        {
                            Label lb = new Label();
                            lb.AutoSize = true;
                            lb.ForeColor = Color.Blue;
                            lb.Font = new Font(label5.Font, FontStyle.Underline);
                            lb.Cursor = System.Windows.Forms.Cursors.Hand;
                            lb.MouseHover += new EventHandler(lb_MouseHover);
                            lb.MouseLeave += new EventHandler(lb_MouseLeave);
                            lb.Click += new EventHandler(lb_Click);
                            lb.Text = r["TEN_FILE"].ToString();
                            if (r["NOI_DUNG"] != DBNull.Value)
                                lb.Tag = (byte[])r["NOI_DUNG"];
                            flowLayoutPanel2.Controls.Add(lb);
                            wi += lb.Width;
                            if (wi >= flowLayoutPanel2.Width)
                            {
                                flowLayoutPanel2.Height += lb.Height;
                                wi = 0;
                            }
                        }
                        xtraScrollableControl1.HorizontalScroll.Visible = false;
                    }
                    else
                    {
                        labelControl1.Visible = false;
                    }
                    lblNguoi_cap_nhat.Text = ProtocolVN.DanhMuc.DMFWNhanVien.GetFullName(TTNew.NGUOI_CAP_NHAT);
                    lbl_Thoi_gian_cap_nhat.Text = TTNew.NGAY_CAP_NHAT.ToString(PLConst.FORMAT_DATETIME_STRING).Trim();
                    AppCtrl.SetRichText(richEditControl, TTNew.NOI_DUNG,true);
                    popupControlContainer1.Visible =true;         
                }
                else
                {
                    popupControlContainer1.Visible = false;
                    richEditControl.RtfText = string.Empty;
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
        }
        private void lb_Click(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb.Tag == null) return;
            frmSaveOpen frm = new frmSaveOpen((byte[])lb.Tag, lb.Text);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }
        private void lb_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void lb_MouseHover(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Red;
        }
            
        #endregion                                                                                   
        
    
        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            PLTinTuc.ChonNhomTin(PLNhomTT, true);
            return null;
        }

        #endregion

    }
}