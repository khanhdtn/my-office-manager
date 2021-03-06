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

namespace office
{

    public partial class frmMeetingPlanQL : PhieuQuanLyChange1N, IDuyetSupport
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //{
        //public partial class frmMeetingPlanQL : XtraFormPL
        //public DevExpress.XtraBars.BarManager barManager1;
        //public DevExpress.XtraBars.Bar MainBar;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //public DevExpress.XtraBars.BarDockControl barDockControlTop;
        //public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //public DevExpress.XtraBars.BarDockControl barDockControlRight;
        //public DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //public DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //public DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //public DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        //public DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //public DevExpress.XtraBars.BarSubItem barSubItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //public DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //public DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //public DevExpress.XtraBars.PopupMenu popupMenu1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //public DevExpress.XtraGrid.GridControl gridControlMaster;
        //public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.FIX;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmMeetingPlanQL).FullName,
                "Lập kế hoạch họp",
                ParentID, true,
                typeof(frmMeetingPlanQL).FullName,
                true, IsSep, "mnbToChuc.png", true, "", "");
        }
        private PhieuQuanLyFix1N Fix;        
        #endregion        

        #region Hàm khởi tạo
        public frmMeetingPlanQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "NOI_DUNG";
            Fix = new PhieuQuanLyFix1N(this);
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            gridViewMaster.OptionsView.ShowGroupedColumns = false;          
        }      
        private void frmMeetingPlanQL_Load(object sender, EventArgs e)
        {
        
        }
        #endregion

        #region Step 1 : Xác định các cột sẽ hiển thị trong gridView
        public override void InitColumnMaster()
        {
            PLGUIUtil.BestFitMasterColumns(this.gridViewMaster);
            XtraGridSupportExt.TextCenterColumn(CotNgay, "NGAY");
            HelpGridColumn.CotPLTimeEdit(CotGBD, "GIO_BAT_DAU", PLConst.FORMAT_TIME_STRING);
            HelpGridColumn.CotPLTimeEdit(CotGKT, "GIO_KET_THUC", PLConst.FORMAT_TIME_STRING);
            XtraGridSupportExt.TextLeftColumn(CotNoiDung, "NOI_DUNG");
            XtraGridSupportExt.TextLeftColumn(CotDD, "DIA_DIEM");
            XtraGridSupportExt.ComboboxGridColumn(CotNguoiTC, DMNhanVienX.I.GetAll(), "ID", "NAME", "NGUOI_TO_CHUC_ID");
            XtraGridSupportExt.ComboboxGridColumn(CotTC, DMTinhChatMeeting.I.GetAll(), "ID", "NAME", "TC_MEETING_ID");
            XtraGridSupportExt.ComboboxGridColumn(CotLoai, DMLoaiMeeting.I.GetAll(), "ID", "NAME", "LOAI_MEETING_ID");
        }
        #endregion

        #region Step 2 : Xác định các cột sẽ hiển thị trong phần detail
        public override void InitColumDetail()
        {
            HelpGridColumn.CotTextLeft(colghichu, "GHI_CHU");
            HelpGridColumn.CotTextLeft(coltieude, "TIEU_DE");
            HelpGridColumn.CotTextLeft(coltenfile, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(cot_luu_file, "luu_file");
            XtraGridSupportExt.TextLeftColumn(colmofile, "mo_file");
        }
        #endregion

        #region Step 3 : Xác định các control trong filter part và Khởi tạo control trong phần filter.
        public override void PLLoadFilterPart()
        {
            DMNhanVienX.I.ChonNhanVienLamViec(PLcboNguoiToChuc, true, false);
            DMTinhChatMeeting.I.InitCtrl(PLcboTinhChat, false, true);
            DMLoaiMeeting.I.InitCtrl(PLcboLoai, false, true);
            HelpDate.OneWeekAgo(Tungay, denngay);
        }
        #endregion

        #region Step 4 : Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            return null;  
        }             
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        #region Step 5 : Xây dựng Query Buider cho việc tìm kiếm
        public override QueryBuilder PLBuildQueryFilter()
        {           
               QueryBuilder filter = new QueryBuilder(@"SELECT ID,NGAY,GIO_BAT_DAU,GIO_KET_THUC
                ,NOI_DUNG,DIA_DIEM,NGUOI_TO_CHUC_ID,TC_MEETING_ID,LOAI_MEETING_ID,DUYET
                FROM MEETING_MANAGEMENT WHERE 1=1");
            filter.addID("NGUOI_TO_CHUC_ID", PLcboNguoiToChuc._getSelectedID());
            filter.addID("TC_MEETING_ID", PLcboTinhChat._getSelectedID());
            filter.addID("LOAI_MEETING_ID", PLcboLoai._getSelectedID());
            filter.addDateFromTo("NGAY", Tungay.DateTime, denngay.DateTime);
            filter.addCondition("IS_MEETING='N'");
            filter.addDuyet(PLConst.FIELD_DUYET, DuyetSelect.layTrangThai());
            return filter;              
        }
        #endregion

        #region Step 7 : Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            frmMeetingPlan frm = new frmMeetingPlan(id,null);
            ProtocolForm.ShowModalDialog(this, frm);           
        }

        public override void ShowUpdateForm(long id)
        {
            frmMeetingPlan frm = new frmMeetingPlan(id, false);
            ProtocolForm.ShowModalDialog(this, frm);
            Fix.PLRefresh();
        }

        public override long[] ShowAddForm()
        {
            frmMeetingPlan frm = new frmMeetingPlan();
            ProtocolForm.ShowModalDialog(this, frm);
            //Fix.PLRefresh();
            return null;
        }
      
        #endregion

        #region Step 8 : Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            return DAMeeting.Instance.Delete(id) ;
        }

        public override _Print InAction(long[] ids)
        {
            return null;
        }


        #endregion

        #region Step 9 : HookFocusRow & lấy dữ liệu
        public override void HookFocusRow()
        {  
            
        }
        public override DataTable[] PLLoadDataDetailParts(long MasterID)
        {
            DataSet dsVanBanMeeting = null; ;
            QueryBuilder query = new QueryBuilder(@"SELECT LT.*,MM.ID FROM (OBJECT_TAP_TIN VB INNER JOIN MEETING_MANAGEMENT MM
            ON MM.ID=VB.OBJECT_ID) INNER JOIN LUU_TRU_TAP_TIN LT ON LT.ID=VB.TAP_TIN_ID WHERE MM.ID=" + MasterID + " AND TYPE_ID=6 AND 1=1");
            dsVanBanMeeting = HelpDB.getDatabase().LoadDataSet(query);
            dsVanBanMeeting.Tables[0].Columns.Add("hinh_anh", typeof(Image));
            dsVanBanMeeting.Tables[0].Columns.Add("mo_file", typeof(Image));
            dsVanBanMeeting.Tables[0].Columns.Add("luu_file", typeof(Image));                           
            foreach (DataRow r in dsVanBanMeeting.Tables[0].Rows)
            {
                r["hinh_anh"] = AppCtrl.mapToImage(r["TEN_FILE"].ToString());
                r["mo_file"] = imageList_layout.Images[0];
                r["luu_file"] = imageList_layout.Images[1];
            }
            HelpGridColumn.CotTextCenter(colfile, "hinh_anh");
            return new DataTable[] { dsVanBanMeeting.Tables[0] }; 
        }
        #endregion

        #region Step 10 : UpdateRow
        public override string UpdateRow()
        {
            return
                @"SELECT ID,NGAY,GIO_BAT_DAU,GIO_KET_THUC
                ,NOI_DUNG,DIA_DIEM,NGUOI_TO_CHUC_ID,TC_MEETING_ID,LOAI_MEETING_ID,DUYET
                FROM MEETING_MANAGEMENT WHERE 1=1";
        }
        #endregion 

            private void rep_mofile_Click(object sender, EventArgs e)
            {                
                DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
                DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);       
            }

            private void rep_luu_file_Click(object sender, EventArgs e)
            {
                DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
                DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
            }
        
        #region Các hàm khác                
        #endregion                                                   
    
            #region IDuyetSupport Members

            public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
            {
                if (PLGUIUtil.UpdateDuyetPhieu("MEETING_MANAGEMENT", "ID", ID, FrameworkParams.currentUser.employee_id, HelpDB.getDatabase().GetSystemCurrentDateTime(), DuyetSupportStatus.Duyet))
                {
                    return true;
                }
                return false;
            }

            public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
            {
                if (PLGUIUtil.UpdateDuyetPhieu("MEETING_MANAGEMENT", "ID", ID, FrameworkParams.currentUser.employee_id, HelpDB.getDatabase().GetSystemCurrentDateTime(), DuyetSupportStatus.KhongDuyet))
                {
                    return true;
                }
                return false;
            }

            #endregion
    }

}
