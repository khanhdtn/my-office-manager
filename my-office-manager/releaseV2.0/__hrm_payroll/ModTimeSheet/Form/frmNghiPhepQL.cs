using System;
using System.Data;
using DevExpress.XtraBars;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using ProtocolVN.DanhMuc;
using pl.office.form;
using System.Drawing;
using pl.office;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmNghiPhepQL :  PhieuQuanLy10Change,IDuyetSupport
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
        //private DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //private DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //protected DevExpress.XtraBars.BarSubItem barSubItem1;
        //#endregion

         #region Các khai báo biến 
             private PhieuQuanLy10Fix Fix;
             #region Các hằng số khởi tạo giờ bắt đầu,kết thúc và nghỉ trưa                            
            #endregion
         #endregion

         #region Các hàm khởi tạo
         public static FormStatus Status = FormStatus.OK_TEST;
        public static string MenuItem(string ParentID, bool IsSep)
         {
             return MenuBuilder.CreateItem(typeof(frmTimeInOutQL).FullName,
                 "Theo dõi nghỉ phép",
                 ParentID, true,
                 typeof(frmTimeInOutQL).FullName,
                 false, IsSep, "ATinhTrangBaoHanh.png", true, "", "");
         }
        public frmNghiPhepQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "ID";
            Fix = new PhieuQuanLy10Fix(this);            
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            Cot_Noi_Dung.Visible = true;
            InitState(false);
            this.barButtonItemDuyet.Glyph = FWImageDic.COMMIT_IMAGE16;
            this.barButtonItemK_Duyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemDuyet.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            this.barButtonItemK_Duyet.Glyph = FWImageDic.UNCOMMIT_IMAGE16;
            this.barButtonItemPrint.Visibility = BarItemVisibility.Never;            
            gridViewMaster.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(gridViewMaster_CustomDrawCell);
            barButtonItemDuyet.ItemClick += new ItemClickEventHandler(barButtonItemDuyet_ItemClick);
            barButtonItemK_Duyet.ItemClick += new ItemClickEventHandler(barButtonItemK_Duyet_ItemClick);
            barSubItem1.Visibility = BarItemVisibility.Always;
        }

        void gridViewMaster_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;
            GridViewInfo vieww = view.GetViewInfo() as GridViewInfo;
            GridDataRowInfo t = vieww.GetGridRowInfo(e.RowHandle) as GridDataRowInfo;
            object NoiDung = view.GetRowCellValue(e.RowHandle, Cot_Noi_Dung);
            if (NoiDung.ToString().Length > 0) {
                t.Cells[Cot_Noi_Dung].Appearance.ForeColor = Color.Red;
            }
            gridViewMaster.Appearance.Reset();
        }                
                
        private void frmTimeInOutQL_Load(object sender, EventArgs e)
        {          
        }     
        #endregion                  

         #region Methods of Framework 
        public override void InitColumnMaster()
        {
            ID.FieldName = "ID";
            XtraGridSupportExt.TextLeftColumn(Cot_TenNV, "TEN_NV");
            XtraGridSupportExt.DateTimeGridColumn(Cot_NgayLamViec, "NGAY_LAM_VIEC");
            HelpGridColumn.CotPLImageCheck(Cot_N_Bs, "NGHI_BUOI_SANG");
            HelpGridColumn.CotPLImageCheck(Cot_N_BC, "NGHI_BUOI_CHIEU");
            HelpGridColumn.CotPLImageCheck(Cot_NP_Nam, "NGHI_PHEP_NAM");
            HelpGridColumn.CotPLImageCheck(Cot_NP_KL, "NGHI_KHONG_LUONG");               
            XtraGridSupportExt.TextLeftColumn(Cot_Noi_Dung, "NOI_DUNG");
            Cot_Noi_Dung.Caption = "Lý do nghỉ";
            HelpGridColumn.CotCombobox(HelpGridColumn.ThemCot(this.gridViewMaster, "Người duyệt", 8, 100),"DM_NHAN_VIEN","ID","NAME","NGUOI_DUYET");
            XtraGridSupportExt.TextLeftColumn(CotLoai, "LOAI");                                 
            PLGUIUtil.BestFitMasterColumns(this.gridViewMaster);
        }
        public void InitState(bool State)
        {
            barButtonItemDuyet.Enabled = State;
            barButtonItemK_Duyet.Enabled = State;
        }
        public override void InitColumDetail()
        {                                                       
        }
       
        public override void PLLoadFilterPart()
        {
            ShowFooter();
            DMNhanVienX.I.InitCtrl(PLNhanVien, true, true);                                
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            filter.addID("NLV.NV_ID", PLNhanVien._getSelectedID());
            filter.addCondition("NLV.LOAI=" + (Int32)TimeInOutType.NghiPhep);
            filter.addDateFromTo("NLV.NGAY_LAM_VIEC", TuNgay.DateTime, DenNgay.DateTime);            
            filter.setDescOrderBy("NLV.NGAY_LAM_VIEC");
            filter.setAscOrderBy("NV.TEN_NV");
            filter.addDuyet(PLDBUtil.FIELD_DUYET, DuyetSelect.layTrangThai());
            return filter;
        }
        public override void ShowViewForm(long id)
        {                     
            frmNghiPhep frm = new frmNghiPhep(id, null);
            ProtocolForm.ShowModalDialog(this, frm);              
        }
        public override void ShowUpdateForm(long id)
        {            
            frmNghiPhep frm = new frmNghiPhep(id, false);
            frm.RefreshData += new frmNghiPhep.RefreshNghiPHep(Fix.PLRefresh);
            ProtocolForm.ShowModalDialog(this, frm);             
        }
        public override long[] ShowAddForm()
        {
            frmNghiPhep frm = new frmNghiPhep();
            frm.RefreshData += new frmNghiPhep.RefreshNghiPHep(Fix.PLRefresh);
            ProtocolForm.ShowModalDialog(this, frm);           
            return null;
        }
        public override bool XoaAction(long id)
        {
            return DATimeInOut.Instance.Delete(id); 
           
        }
        
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
               new string[] { "Gửi mail xin phép"},
               new string[] { "mnbmessage.gif"},
               "ID",
               new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    SendMail
               });
            return menu;           
        }
        private void SendMail(List<object> ids) {
            frmSendClient form = new frmSendClient();
            ProtocolForm.ShowModalDialog(this, form);                       
        }
        public override _Print InAction(long[] ids)
        {
            return null;
        }       
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        public override string UpdateRow()
        {
            return @"SELECT NLV.ID,NLV.NGAY_LAM_VIEC,NLV.GIO_BAT_DAU,NLV.GIO_KET_THUC,
                            NGHI_BUOI_CHIEU,NGHI_BUOI_SANG,NOI_DUNG,LOAI,DUYET,NGUOI_GHI_NHAN,NGUOI_DUYET,
                            NLV.NV_ID,NV.TEN_NV,NGHI_PHEP_NAM,NGHI_KHONG_LUONG,THOI_GIAN_SANG,THOI_GIAN_CHIEU                                                                                 
                           ,EXTRACT(HOUR FROM THOI_GIAN_LAM_VIEC) + cast((EXTRACT(MINUTE FROM THOI_GIAN_LAM_VIEC)) as numeric(15,2))/60 TG                                       
                          FROM CAPNHAT_NGAYLAMVIEC NLV, DM_NHAN_VIEN NV WHERE
                          NV.ID = NLV.NV_ID 
                          AND 1=1";
        }            
        public override void HookFocusRow()
        {
            if (gridViewMaster.DataSource != null && gridViewMaster.RowCount > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (row == null) return;
                if (row["LOAI"].ToString() != ((Int32)TimeInOutType.GhiThoiGian).ToString() && gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle) == false)
                {
                    if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                    {
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDuyet.Enabled = true;
                    }
                    else if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                    {
                        barButtonItemK_Duyet.Enabled = true;
                        barButtonItemDuyet.Enabled = false;
                    }
                    else
                    {
                        barButtonItemK_Duyet.Enabled = false;
                        barButtonItemDuyet.Enabled = true;
                    }
                }
                else
                {
                    InitState(false);
                }
                barSubItem1.Enabled = true;
            }
        }
        #endregion
        
         #region Khác
        void barButtonItemDuyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DateTime Ngay_duyet = DABase.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (PLGUIUtil.IsDuyet(row[PLDBUtil.FIELD_DUYET]))
                {
                    PLMessageBox.ShowNotificationMessage("Thông tin nghỉ phép của '" + row["TEN_NV"] + "' đã duyệt!");                   
                }
                else
                {
                    if (PLMessageBox.ShowConfirmMessage("Duyệt thông tin nghỉ phép của '" + row["TEN_NV"] + "' ?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (DuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                        {
                            row[PLDBUtil.FIELD_DUYET] = ((Int32)DuyetSupportStatus.Duyet).ToString();
                            barButtonItemDelete.Enabled = false;
                            barButtonItemUpdate.Enabled = false;
                        }
                    }                   
                }
            }
        }
        void barButtonItemK_Duyet_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] Selected_row = gridViewMaster.GetSelectedRows();
            DateTime Ngay_duyet = DABase.getDatabase().GetSystemCurrentDateTime();
            foreach (int i in Selected_row)
            {
                DataRow row = gridViewMaster.GetDataRow(i);
                if (PLGUIUtil.IsKhongDuyet(row[PLDBUtil.FIELD_DUYET]))
                {
                    PLMessageBox.ShowNotificationMessage("Thông tin nghỉ phép của '" + row["TEN_NV"] + "' đã không duyệt!");                    
                }
                else
                {
                    if (PLMessageBox.ShowConfirmMessage("Không duyệt thông tin nghỉ phép của '" + row["TEN_NV"] + "' ?") == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (KhongDuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                        {
                            row[PLDBUtil.FIELD_DUYET] = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();
                            barButtonItemDelete.Enabled = true;
                            barButtonItemUpdate.Enabled = true;
                        }
                    }                 
                }
            }
        }                                                       
        /// <summary>Lấy tình trạng chọn xem những người đã chấm công, chưa chấm công
         /// ....
         /// </summary>        
        public void ShowFooter()
        {
            gridViewMaster.OptionsView.ShowFooter = true;                
            CotTG_LV.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "Thời gian: {0:#.###}(giờ)");
            HelpGridExt .SetFontFooter(gridViewMaster, new string[] { "THOI_GIAN_LAM_VIEC" }, Color.Blue, Color.Empty, FontStyle.Regular);
        }
        #endregion
       
        #region IDuyetSupport Members

        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.Duyet))
            {
                DataTable tb = ((DataView)this.gridViewMaster.DataSource).Table;
                tb.Rows[this.gridViewMaster.FocusedRowHandle]["NGUOI_DUYET"] = NguoiDuyetID;
                barButtonItemK_Duyet.Enabled = true;
                barButtonItemDuyet.Enabled = false;
                return true;
            }
            return false;
        }

        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.KhongDuyet))
            {
                DataTable tb = ((DataView)this.gridViewMaster.DataSource).Table;
                tb.Rows[this.gridViewMaster.FocusedRowHandle]["NGUOI_DUYET"] = NguoiDuyetID;
                barButtonItemK_Duyet.Enabled = false;
                barButtonItemDuyet.Enabled = true;
                return true;
            }
            return false;
        }

        #endregion       
    }
}