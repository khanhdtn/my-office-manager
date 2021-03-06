#region using
using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraBars;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DTO;
using ProtocolVN.DanhMuc;
using office;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using ProtocolVN.App.Office;
using ProtocolVN.Framework.Win.Trial;
using DevExpress.XtraEditors;
using pl.office;
#endregion

namespace ProtocolVN.Plugin.TimeSheet
{
    public partial class frmTimeInOutQL :PhieuQuanLy10Change, IDuyetSupport,IFormRefresh
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

        #region Các khai báo biến
        private PhieuQuanLy10Fix Fix;
        private BarButtonItem bangChamCong, dieuChinhTG, bangChamCong64;
        #endregion

        #region Các hàm khởi tạo
        public static FormStatus Status = FormStatus.OK_TEST;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTimeInOutQL).FullName,
                "Thời gian làm việc",
                ParentID, true,
                typeof(frmTimeInOutQL).FullName,
                false, IsSep, "mnbPhieuMuaHang.png", true, "", "");
        }
        public frmTimeInOutQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "NGAY_LAM_VIEC";
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
            barButtonItemDuyet.ItemClick += new ItemClickEventHandler(barButtonItemDuyet_ItemClick);
            barButtonItemK_Duyet.ItemClick += new ItemClickEventHandler(barButtonItemK_Duyet_ItemClick);
            barSubItem1.Visibility = BarItemVisibility.Always;
            barSubItem1.Enabled = true;
            barButtonItemDuyet.Visibility = BarItemVisibility.Never;
            barButtonItemK_Duyet.Visibility = BarItemVisibility.Never;
            barButtonItemAdd.Visibility = BarItemVisibility.Never;
        }

        private void frmTimeInOutQL_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region Methods of Framework
        public override void InitColumnMaster()
        {
            ID.FieldName = "ID";
            XtraGridSupportExt.TextLeftColumn(Cot_TenNV, "NAME");
            HelpGridColumn.CotPLTimeEdit(Cot_NgayLamViec, "NGAY_LAM_VIEC", "ddd, dd/MM/yyyy");
            HelpGridColumn.CotPLTimeEdit(Cot_GioBatDau, "GIO_BAT_DAU","HH:mm:ss");
            HelpGridColumn.CotPLTimeEdit(Cot_GioKetThuc, "GIO_KET_THUC", "HH:mm:ss");
            HelpGridColumn.CotPLTimeEdit(CotTG_LV, "THOI_GIAN_LAM_VIEC","HH:mm"); 
            HelpGridColumn.CotPLImageCheck(Cot_Cham_Cong, "IS_CHAM_CONG");
            XtraGridSupportExt.TextCenterColumn(Cot_N_Bs, "THOI_GIAN_SANG");
            XtraGridSupportExt.TextCenterColumn(Cot_N_BC, "THOI_GIAN_CHIEU");
            XtraGridSupportExt.BitGridColumn(Cot_NP_Nam, "NGHI_PHEP_NAM");
            XtraGridSupportExt.BitGridColumn(Cot_NP_KL, "NGHI_KHONG_LUONG");
            Cot_NP_Nam.Visible = false;
            Cot_NP_KL.Visible = false;
            XtraGridSupportExt.TextLeftColumn(CotLoaiDT_VS, "LOAI_DI_TRE_VE_SOM");
            CotLoaiDT_VS.Visible = false;
            XtraGridSupportExt.TextLeftColumn(Cot_Noi_Dung, "NOI_DUNG");
            HelpGridExt1.colMultiline(Cot_Noi_Dung, "NOI_DUNG");
            XtraGridSupportExt.TextLeftColumn(CotLoai, "LOAI");
            XtraGridSupportExt.TextLeftColumn(CotIP_Address, "IP_ADDRESS");
            CotIP_Address.Caption = "Địa chỉ máy";
            CotTG_LV.Caption = "Thời gian làm việc (hh:mm)";
            Cot_N_Bs.Caption = "Sáng (hh:mm)";
            Cot_N_BC.Caption = "Chiều (hh:mm)";
            PLGUIUtil.BestFitMasterColumns(this.gridViewMaster);
            Cot_Cham_Cong.Visible = false;
            CotIP_Address.Visible = false;
            gridViewMaster.OptionsView.ShowGroupPanel = false;
            gridViewMaster.OptionsView.RowAutoHeight = true;
            //Sort cột ngày làm việc và nhân viên tăng dần
            Cot_NgayLamViec.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            Cot_TenNV.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

        }
        public void InitState(bool State)
        {
            barButtonItemDuyet.Enabled = State;
            barButtonItemK_Duyet.Enabled = State;
        }
        public override void InitColumDetail()
        {
            //Format dòng không phải là thời gian làm việc.
            StyleFormatCondition conditionNotWork = new StyleFormatCondition(FormatConditionEnum.NotEqual, CotLoai, null,((Int32)TimeInOutType.GhiThoiGian).ToString());
            conditionNotWork.Appearance.ForeColor = Color.Red;
            conditionNotWork.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
            conditionNotWork.Column = CotLoai;
            conditionNotWork.ApplyToRow = true;
            //Format cột thời gian bắt đầu
            /* Nếu giờ bắt đầu > thời gian bắt đầu sáng 1 giây
             * hoặc chỉ làm 1 buối trong ngày và ngày đó không phải là thứ 7 ==> tô màu
             * GetDayOfWeek([NGAY_LAM_VIEC] != '6') ==> không phải thứ 7
             */
            StyleFormatCondition conditionGBD = new StyleFormatCondition();
            conditionGBD.Appearance.Options.UseForeColor = true;
            conditionGBD.Appearance.ForeColor = Color.Red;
            conditionGBD.Condition = FormatConditionEnum.Expression;
//            conditionGBD.Expression = string.Format(@"
//            (GetTimeOfDay(AddTimeSpan(Today(),[GIO_BAT_DAU])) >= GetTimeOfDay(AddTimeSpan(Today(), #{0}#))
//               OR (GetTimeOfDay(AddTimeSpan(Today(),[THOI_GIAN_LAM_VIEC])) <=  GetTimeOfDay(AddTimeSpan(Today(), #{1}#))
//                AND GetDayOfWeek([NGAY_LAM_VIEC]) != '6'))  AND [THOI_GIAN_LAM_VIEC] != ?"
//                , AppGetSysParam.GetGIO_BAT_DAU_SANG.Add(new TimeSpan(0, 0, 0, 1)),AppGetSysParam.GetGIO_KET_THUC_SANG - AppGetSysParam.GetGIO_BAT_DAU_SANG);
            conditionGBD.Expression = string.Format(@"
            (GetTimeOfDay(AddTimeSpan(Today(),[GIO_BAT_DAU])) >= GetTimeOfDay(AddTimeSpan(Today(), #{0}#)))"//  AND [THOI_GIAN_LAM_VIEC] != ?"
                , AppGetSysParam.GetGIO_BAT_DAU_SANG.Add(new TimeSpan(0, 0, 0, 1)));
            conditionGBD.Column = Cot_GioBatDau;
            //Format cột thời gian kết thúc
            StyleFormatCondition conditionGKT = new StyleFormatCondition();
            conditionGKT.Appearance.Options.UseForeColor = true;
            conditionGKT.Appearance.ForeColor = Color.Red;
            conditionGKT.Condition = FormatConditionEnum.Expression;
            /* Nếu giờ kết thúc trong khoảng từ lúc bắt đầu sáng cho tới trước khi kết 
             * hoặc chỉ làm 1 buối trong ngày và ngày đó không phải là thứ 7 ==> tô màu
             * GetDayOfWeek([NGAY_LAM_VIEC] != '6') ==> không phải thứ 7
             */
            conditionGKT.Expression = string.Format(@"
            (GetTimeOfDay(AddTimeSpan(Today(),[GIO_KET_THUC])) > GetTimeOfDay(AddTimeSpan(Today(), #{0}#))
                AND (GetTimeOfDay(AddTimeSpan(Today(),[GIO_KET_THUC])) < GetTimeOfDay(AddTimeSpan(Today(), #{1}#)) AND GetDayOfWeek([NGAY_LAM_VIEC]) != '6'))"
                , AppGetSysParam.GetGIO_BAT_DAU_SANG, AppGetSysParam.GetGIO_KET_THUC_CHIEU);
            conditionGKT.Column = Cot_GioKetThuc;
            /* Nếu giờ kết thúc trong > giờ kết thúc buổi trưa và là ngày thứ 7 ==> tô lại màu đen
             * vì thứ 7 chỉ làm buổi sáng
             * GetDayOfWeek([NGAY_LAM_VIEC] == '6') ==> thứ 7
             */
//            StyleFormatCondition conditionNLV = new StyleFormatCondition();
//            conditionNLV.Appearance.ForeColor = Color.Black;
//            conditionNLV.Appearance.Options.UseForeColor = true;
//            conditionNLV.Condition = FormatConditionEnum.Expression;
//            conditionNLV.Expression = string.Format(@"
//            GetTimeOfDay(AddTimeSpan(Today(),[GIO_KET_THUC])) > GetTimeOfDay(AddTimeSpan(Today(), #{0}#))
//                AND GetDayOfWeek([NGAY_LAM_VIEC]) == '6'"
//                                        , AppGetSysParam.GetGIO_KET_THUC_SANG);
//            conditionNLV.Column = Cot_GioKetThuc;
            //
            gridViewMaster.FormatConditions.AddRange(new StyleFormatCondition[] { conditionNotWork, conditionGBD, conditionGKT });

        }

        void gridViewMaster_CustomDrawRowPreview(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            e.Appearance.ForeColor = Color.Red;
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            e.Appearance.Font = new Font("Tahoma", 8.25F, FontStyle.Italic);
        }
        public override void PLLoadFilterPart()
        {
            //ShowFooter();
            PLTimeSheetUtil.InVisibleShowNumOfRecord(gridControlMaster);
            //DMNhanVienX.I.InitCtrl(PLNhanVien, true, true);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            HelpControl.RedCheckEdit(chkDaChamCong,false);
            HelpControl.RedCheckEdit(chkChuaChamCong,false);
            HelpControl.RedCheckEdit(chkDi_tre,false);
            HelpControl.RedCheckEdit(chkVe_som,false);
            HelpControl.RedCheckEdit(chkBinhThuong, false);
            HelpControl.RedCheckEdit(chkChamCong,false);
            HelpControl.RedCheckEdit(chkIPMay,false);
            //ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromDateToDate;
            chkDaChamCong.Checked = chkChuaChamCong.Checked = true;
            chkDi_tre.Checked = chkVe_som.Checked = chkBinhThuong.Checked = true;
            PLTimeSheetUtil.PermissionForControl(NhanVien, barButtonItemDuyet.Visibility == BarItemVisibility.Always, NhanVien.Visible == true);
            HelpGridExt1.SetDefaultGroupPanel(this.gridViewMaster);
            //----
            chkDaChamCong.CheckedChanged += delegate(object check, EventArgs checkedChanged) {
                if (chkDaChamCong.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkChuaChamCong.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    chkDaChamCong.Checked = true;
            };
            chkChuaChamCong.CheckedChanged += delegate(object check, EventArgs checkedChanged)
            {
                if (chkChuaChamCong.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkDaChamCong.CheckState == System.Windows.Forms.CheckState.Unchecked)
                    chkChuaChamCong.Checked = true;
            };
            chkDi_tre.CheckedChanged += delegate(object check, EventArgs checkedChanged)
            {
                if (chkDi_tre.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkVe_som.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkBinhThuong.CheckState == CheckState.Unchecked)
                    chkDi_tre.Checked = true;
            };
            chkVe_som.CheckedChanged += delegate(object check, EventArgs checkedChanged)
            {
                if (chkVe_som.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkDi_tre.CheckState == System.Windows.Forms.CheckState.Unchecked
                    && chkBinhThuong.CheckState == CheckState.Unchecked)
                    chkVe_som.Checked = true;
            };
            chkBinhThuong.CheckStateChanged += delegate(object check, EventArgs checkedChanged)
            {
                if (chkBinhThuong.CheckState == CheckState.Unchecked
                    && chkDi_tre.CheckState == CheckState.Unchecked
                    && chkVe_som.CheckState == CheckState.Unchecked)
                    chkBinhThuong.Checked = true;
            };
            //----
            if (barSubItem1.ItemLinks.Count > 0) {
                bangChamCong = barSubItem1.ItemLinks[0].Item as BarButtonItem;
                dieuChinhTG = barSubItem1.ItemLinks[1].Item as BarButtonItem;
                bangChamCong64 = barSubItem1.ItemLinks[2].Item as BarButtonItem;
            }
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg msg = new FWWaitingMsg();
            QueryBuilder filter = new QueryBuilder(UpdateRow());
            filter.addID("NLV.NV_ID", NhanVien._getSelectedID());
            if (this.getISChamCong().Length == 3)
                filter.addCondition("(IS_CHAM_CONG in ('Y','N','') or IS_CHAM_CONG is null )");
            else
                filter.addIn("IS_CHAM_CONG", this.getISChamCong());
            if (chkBinhThuong.Checked ==  true &&
                chkDi_tre.Checked == true && chkVe_som.Checked == true) goto Nhan; 
            StringBuilder s_condition = new StringBuilder("");
            if (chkDi_tre.Checked)
                s_condition.Append("GIO_BAT_DAU>='" + AppGetSysParam.GetGIO_BAT_DAU_SANG.ToString() + "'");
            if (chkVe_som.Checked && chkDi_tre.Checked)
                s_condition.Append(" OR GIO_KET_THUC<CASE WHEN EXTRACT(WEEKDAY FROM NLV.NGAY_LAM_VIEC)=6 THEN '" + AppGetSysParam.GetGIO_KET_THUC_SANG.ToString() + "' ELSE '" + ((DateTime)frmAppParamsHelp.GetThamSo("GIO_KET_THUC_CHIEU")).TimeOfDay.ToString() + "' END");
            else if (chkVe_som.Checked)
                s_condition.Append("GIO_KET_THUC<CASE WHEN EXTRACT(WEEKDAY FROM NLV.NGAY_LAM_VIEC)=6 THEN '" + AppGetSysParam.GetGIO_KET_THUC_SANG.ToString() + "' ELSE '" + ((DateTime)frmAppParamsHelp.GetThamSo("GIO_KET_THUC_CHIEU")).TimeOfDay.ToString() + "' END");
            if (s_condition.Length > 0)
            {
                if (chkBinhThuong.Checked)
                    s_condition.Append(" OR (GIO_BAT_DAU<'" + AppGetSysParam.GetGIO_BAT_DAU_SANG.ToString() + "' AND GIO_KET_THUC >=CASE WHEN EXTRACT(WEEKDAY FROM NLV.NGAY_LAM_VIEC)=6 THEN '" + AppGetSysParam.GetGIO_KET_THUC_SANG.ToString() + "' ELSE '" + ((DateTime)frmAppParamsHelp.GetThamSo("GIO_KET_THUC_CHIEU")).TimeOfDay.ToString() + "'END)");
            }
            else {
                if (chkBinhThuong.Checked)
                    s_condition.Append("(GIO_BAT_DAU<'" + AppGetSysParam.GetGIO_BAT_DAU_SANG.ToString() + "' AND GIO_KET_THUC >=CASE WHEN EXTRACT(WEEKDAY FROM NLV.NGAY_LAM_VIEC)=6 THEN '" + AppGetSysParam.GetGIO_KET_THUC_SANG.ToString() + "' ELSE '" + ((DateTime)frmAppParamsHelp.GetThamSo("GIO_KET_THUC_CHIEU")).TimeOfDay.ToString() + "' END)");
            }
            filter.addCondition(s_condition.ToString());
            //if (this.chkDi_tre.Checked || chkVe_som.Checked)
                //filter.addID("LOAI", 1);
            Nhan:
            if (ngayLamViec.Types != SelectionTypes.None)
                filter.addDateFromTo("NLV.NGAY_LAM_VIEC", ngayLamViec.FromDate, ngayLamViec.ToDate);
            filter.setDescOrderBy("NLV.NGAY_LAM_VIEC");
            filter.setAscOrderBy("NAME");
            msg.Finish();
            return filter;
        }
        public override void ShowViewForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
            {
                frmNghiPhep frm = new frmNghiPhep(id, null);
                HelpProtocolForm.ShowModalDialog(this, frm);
                
            }
            else if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.XacNhanLamViec)
            {
                frmPhieuXNLamViec frm = new frmPhieuXNLamViec(row["ID"], null);
                HelpProtocolForm.ShowModalDialog(this, frm);
            }
            else if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.RaVaoCongTy)
            {
                frmPhieuRaVaoCty frm = new frmPhieuRaVaoCty(row["ID"], null);
                HelpProtocolForm.ShowModalDialog(this, frm);
            }
            else
            {
                frmTimeInOut frm = new frmTimeInOut(HelpNumber.ParseInt64(row["NV_ID"]), (DateTime)row["NGAY_LAM_VIEC"], null);
                HelpProtocolForm.ShowModalDialog(this, frm);
            }
        }
        public override void ShowUpdateForm(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
            {
                frmNghiPhep frm = new frmNghiPhep(id, false);
                HelpProtocolForm.ShowModalDialog(this, frm);
            }
            else if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.XacNhanLamViec)
            {
                frmPhieuXNLamViec frm = new frmPhieuXNLamViec(row["ID"], false);
                HelpProtocolForm.ShowModalDialog(this, frm);
            }
            else if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.RaVaoCongTy)
            {
                frmPhieuRaVaoCty frm = new frmPhieuRaVaoCty(row["ID"], false);
                HelpProtocolForm.ShowModalDialog(this, frm);
            }
            else
            {
                frmTimeInOut frm = new frmTimeInOut(HelpNumber.ParseInt64(row["NV_ID"]), (DateTime)row["NGAY_LAM_VIEC"], false);
                frm.ReFindData += new frmTimeInOut.RefreshGird(PLBuildQueryFilter);
                HelpProtocolForm.ShowModalDialog(this, frm);
            }
        }
        public override long[] ShowAddForm()
        {
            frmTimeInOut frm = new frmTimeInOut();
            //frm.ReFindData += new frmTimeInOut.RefreshGird(PLBuildQueryFilter);
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }
        public override bool XoaAction(long id)
        {
            return DATimeInOut.Instance.Delete(id);

        }

        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                new string[] { "Kết chuyển dữ liệu sang bảng chấm công","Điều chỉnh thời gian chấm công" ,"Kết chuyển dữ liệu sang bảng chấm công 64 (Đang phát triển)" },
                new string[] { "mnsMoveTimeInOut.png", "fwEdit.png", "mnsMoveTimeInOut.png" },
                "ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    FKetChuyenData,
                    ThaydoiGDBGKT,
                    FKetChuyenData64
               }, new PermissionItem[]{
                        AppPermission.FQuanTriThoiGianLamViec.GetPermissionItem(PermissionType.EDIT),
                        AppPermission.FQuanTriThoiGianLamViec.GetPermissionItem(PermissionType.EDIT),
                        AppPermission.FQuanTriThoiGianLamViec.GetPermissionItem(PermissionType.EDIT)
                    }
               );
            return menu;
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
            return @"SELECT NLV.ID,NLV.NGAY_LAM_VIEC
                            ,NLV.GIO_BAT_DAU,NLV.GIO_KET_THUC,
                            NLV.IS_CHAM_CONG,
                            NGHI_BUOI_CHIEU,
                            NGHI_BUOI_SANG,
                            NOI_DUNG,LOAI,DUYET,
                            THOI_GIAN_LAM_VIEC,NLV.NV_ID,(SELECT NAME FROM DM_NHAN_VIEN WHERE ID = NLV.NV_ID) NAME,NGHI_PHEP_NAM,NGHI_KHONG_LUONG,IP_ADDRESS,
                            CASE 
                                WHEN (THOI_GIAN_SANG = 'N' AND NGHI_PHEP_NAM = 'Y') THEN 'Nghỉ phép năm'
                                WHEN (THOI_GIAN_SANG = 'N' AND NGHI_KHONG_LUONG = 'Y') THEN 'Nghỉ không lương'
                                ELSE  THOI_GIAN_SANG
                            END THOI_GIAN_SANG,
                             CASE 
                                WHEN ( THOI_GIAN_CHIEU = 'N' AND NGHI_PHEP_NAM = 'Y') THEN 'Nghỉ phép năm'
                                WHEN ( THOI_GIAN_CHIEU = 'N' AND NGHI_KHONG_LUONG = 'Y') THEN 'Nghỉ không lương'
                                ELSE  THOI_GIAN_CHIEU
                            END THOI_GIAN_CHIEU
                            ,THOI_GIAN_SANG AS TGS
                            ,THOI_GIAN_CHIEU AS TGC
                           ,CASE LOAI_DI_TRE_VE_SOM
                                WHEN 1 THEN 'Trễ buổi sáng'
                                WHEN 2 THEN 'Trễ buổi chiều'
                                WHEN 3 THEN 'Về sớm buổi sáng'
                                WHEN 4 THEN 'Về sớm buổi chiều'
                            END LOAI_DI_TRE_VE_SOM 
                           ,EXTRACT(HOUR FROM THOI_GIAN_LAM_VIEC) + cast((EXTRACT(MINUTE FROM THOI_GIAN_LAM_VIEC)) as numeric(15,2))/60 TG,
                            CASE NLV.GIO_BAT_DAU
                                WHEN NLV.GIO_KET_THUC THEN 'Tự động kết thúc'                                  
                                ELSE 'Có kết thúc'
                            END AUTOTHEEND
                          FROM CAPNHAT_NGAYLAMVIEC NLV WHERE 1=1";
        }
        public override void HookFocusRow()
        {
            barSubItem1.Enabled = true;
            if (dieuChinhTG != null) dieuChinhTG.Enabled = true;
            decimal ThoiGian = HelpNumber.ParseDecimal(CotTG_LV.SummaryItem.SummaryValue);
            CotTG_LV.SummaryItem.DisplayFormat = ThoiGian + " giờ " + "(" + HelpNumber.RoundDecimal((ThoiGian / 8), 4) + " ngày)";
            if (gridViewMaster.DataSource != null && gridViewMaster.RowCount > 0)
            {
                DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                if (row == null) return;
                if ((string.Compare(row["LOAI"].ToString(),((Int32)TimeInOutType.GhiThoiGian).ToString()) == 0
                    || string.Compare(row["LOAI"].ToString(), ((Int32)TimeInOutType.NghiPhep).ToString()) == 0)
                    && row["IS_CHAM_CONG"].ToString() == "Y"){
                    barButtonItemUpdate.Enabled = barButtonItemDelete.Enabled = false;
                    if (bangChamCong != null) bangChamCong.Enabled = false;
                    
                    if (bangChamCong64 != null) bangChamCong64.Enabled = false;
                }
                else if ((string.Compare(row["LOAI"].ToString(), ((Int32)TimeInOutType.GhiThoiGian).ToString()) == 0
                    || string.Compare(row["LOAI"].ToString(), ((Int32)TimeInOutType.NghiPhep).ToString()) == 0)
                    && row["IS_CHAM_CONG"].ToString() != "Y")
                {
                    if (bangChamCong != null) bangChamCong.Enabled = true;
                    //if (dieuChinhTG != null) dieuChinhTG.Enabled = false;
                    if (bangChamCong64 != null) bangChamCong64.Enabled = true;
                }
                else
                {
                    if (row["LOAI"].ToString() != ((Int32)TimeInOutType.GhiThoiGian).ToString() && gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle) == false)
                    {
                        if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.ChoDuyet).ToString())
                            barButtonItemUpdate.Enabled = barButtonItemDelete.Enabled = true;
                        else if (row["DUYET"].ToString() == ((Int32)DuyetSupportStatus.Duyet).ToString())
                            barButtonItemUpdate.Enabled = barButtonItemDelete.Enabled = false;
                        else
                            barButtonItemUpdate.Enabled = barButtonItemDelete.Enabled = true;
                    }
                    if (bangChamCong != null) bangChamCong.Enabled = false;
                    //if (dieuChinhTG != null) dieuChinhTG.Enabled = false;
                    if (bangChamCong64 != null) bangChamCong64.Enabled = false;
                }
                /*if (HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.XacNhanLamViec 
                    || HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.RaVaoCongTy
                    || HelpNumber.ParseInt32(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep)
                {
                    barButtonItemUpdate.Enabled = false;
                    barButtonItemDelete.Enabled = false;
                    barButtonItemDuyet.Enabled = false;
                    barButtonItemK_Duyet.Enabled = false;
                }*/
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
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
                    if (DuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                    {
                        row[PLConst.FIELD_DUYET] = ((Int32)DuyetSupportStatus.Duyet).ToString();
                        barButtonItemUpdate.Enabled = false;
                        barButtonItemDelete.Enabled = false;
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
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc không duyệt dữ liệu đang chọn không?") == System.Windows.Forms.DialogResult.Yes)
                    if (KhongDuyetAction(HelpNumber.ParseInt64(row["ID"]), FrameworkParams.currentUser.employee_id, DABase.getDatabase().GetSystemCurrentDateTime()))
                    {
                        row[PLConst.FIELD_DUYET] = ((Int32)DuyetSupportStatus.KhongDuyet).ToString();
                        barButtonItemUpdate.Enabled = true;
                        barButtonItemDelete.Enabled = true;
                    }
            }
        }

        private void ThaydoiGDBGKT(List<object> ids)
        {
            frmChangeTimeInOut frm = new frmChangeTimeInOut();
            HelpProtocolForm.ShowModalDialog(this, frm);
            Fix.PLRefresh();
        }
        private void XinNghiPhep(List<object> ids)
        {
            if (ids != null)
            {
                if (ids != null)
                {
                    frmNghiPhep frm = new frmNghiPhep();
                    HelpProtocolForm.ShowModalDialog(this, frm);
                    Fix.PLRefresh();
                }
            }
        }
       
        //Chuyển dữ liệu tập trung cả 2 loại : Ghi thời gian và nghỉ phép
        private void ChuyenDenBangChamCongAuto(List<object> ids)
        {
            bool bFlag = true;
            if (ids != null)
            {
                try
                {
                    Application.DoEvents();
                    FrameworkParams.wait = new WaitingMsg();
                    foreach (DataRow row in ((DataView)gridViewMaster.DataSource).Table.Rows)
                    {
                        bool IsChamCong = (row["IS_CHAM_CONG"].ToString() != "Y");
                        if ((HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.GhiThoiGian && IsChamCong) || (HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep && IsChamCong))
                        {
                            long NV_ID = HelpNumber.ParseInt64(row["NV_ID"]);
                            DOChamCongAuto phieu = DAChamCongAuto.Instance.LoadAll(NV_ID, (DateTime)row["NGAY_LAM_VIEC"]);
                            if (phieu.DetailDataSet.Tables[0].Select("NV_ID=" + NV_ID + " and NGAY='" + System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]) + "'").Length == 0)
                            {
                                phieu.NV_ID = NV_ID;
                                phieu.NGAY = System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]);
                            }
                            if (HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.GhiThoiGian)
                            {
                                if (row["THOI_GIAN_SANG"] != null && row["THOI_GIAN_SANG"].ToString() != string.Empty)
                                {
                                    string[] TGSang = row["THOI_GIAN_SANG"].ToString().Split(':');
                                    phieu.SANG = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal((HelpNumber.ParseInt32(TGSang[0]) + (HelpNumber.ParseInt32(TGSang[1]) / 60.0))), 2).ToString();
                                }
                                if (row["THOI_GIAN_CHIEU"] != null && row["THOI_GIAN_CHIEU"].ToString() != string.Empty)
                                {
                                    string[] TGChieu = row["THOI_GIAN_CHIEU"].ToString().Split(':');
                                    phieu.CHIEU = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal((HelpNumber.ParseInt32(TGChieu[0]) + (HelpNumber.ParseInt32(TGChieu[1]) / 60.0))), 2).ToString(); 
                                }
                            }
                            else
                            {
                                if (row["THOI_GIAN_SANG"] != null && row["THOI_GIAN_SANG"].ToString() != string.Empty) phieu.SANG = row["THOI_GIAN_SANG"].ToString();
                                if (row["THOI_GIAN_CHIEU"] != null && row["THOI_GIAN_CHIEU"].ToString() != string.Empty) phieu.CHIEU = row["THOI_GIAN_CHIEU"].ToString();
                            }
                            bool bflag = DAChamCongAuto.Instance.Update(phieu);
                            #region Cập nhật tình trạng chấm công tự động
                            if (bFlag)
                            {
                                DOTimeInOut doPhieu = DATimeInOut.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                doPhieu.IS_CHAM_CONG = "Y";
                                if (DATimeInOut.Instance.Update(doPhieu))
                                    DATimeInOut.Instance.UpdatePhieu(doPhieu);
                            }
                            #endregion
                        }
                    }
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                    HelpMsgBox.ShowErrorMessage("Thực hiện không thành công!");
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                    Fix.PLRefresh();
                }
            }
        }

        private void FKetChuyenData64(List<object> ids)
        {
            try
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc chuyển tất cả dữ liệu đang xem qua bảng chấm công 64 không?") == DialogResult.Yes)
                {
                    Application.DoEvents();
                    FrameworkParams.wait = new WaitingMsg();
                    DateTime tuNgay = DateTime.Parse(gridViewMaster.GetDataRow((gridControlMaster.DataSource as DataTable).Rows.Count - 1)["NGAY_LAM_VIEC"].ToString());
                    DateTime denNgay = DateTime.Parse(gridViewMaster.GetDataRow(0)["NGAY_LAM_VIEC"].ToString());
                    DATimeInOut.Instance.ToChamCong(this.gridViewMaster, tuNgay, denNgay);
                    Fix.PLRefresh();
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpMsgBox.ShowErrorMessage("Thực hiện không thành công!");
            }
            finally
            {
                if (FrameworkParams.wait != null)
                    FrameworkParams.wait.Finish();
            }
        }
        private void FKetChuyenData(List<object> ids) {
            try
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc chuyển tất cả dữ liệu đang xem qua bảng chấm công không?") == DialogResult.Yes)
                {
                    Application.DoEvents();
                    FrameworkParams.wait = new WaitingMsg();
                    MoveTimeInOut(ids);
                    MoveNghiPhep(ids);
                    Fix.PLRefresh();
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpMsgBox.ShowErrorMessage("Thực hiện không thành công!");
            }
            finally {
                if (FrameworkParams.wait != null)
                    FrameworkParams.wait.Finish();
            }
        }
        //Chỉ chuyển dữ liệu thời gian làm việc
        private void MoveTimeInOut(List<object> ids)
        {
            bool bFlag = true;

            if (ids != null)
            {
                DataSet forDBTime = new DataSet();
                DataSet forDBChamCongAuto = new DataSet();

                FWDBService db = null;
                DbTransaction trans = null;
                FWTransaction fwTrans = null;
                try
                {
                    db = HelpDB.getDBService();
                    trans = FWTransaction.BeginTrans(db);
                    fwTrans = new FWTransaction(db, trans);
                    fwTrans.LoadDataSet(forDBTime, "SELECT * FROM " + DATimeInOut.TABLE_MAP, DATimeInOut.TABLE_MAP);
                    fwTrans.LoadDataSet(forDBChamCongAuto, "SELECT * FROM " + DAChamCongAuto.TABLE_MAP, DAChamCongAuto.TABLE_MAP);
                    foreach (DataRow row in ((DataView)gridViewMaster.DataSource).Table.Rows)
                    {
                        bool IsChamCong = (row["IS_CHAM_CONG"].ToString() != "Y");
                        if ((HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.GhiThoiGian && IsChamCong))
                        {
                            long NV_ID = HelpNumber.ParseInt64(row["NV_ID"]);
                            DOChamCongAuto phieu = DAChamCongAuto.Instance.LoadAll(fwTrans, NV_ID, (DateTime)row["NGAY_LAM_VIEC"]);
                            if (phieu.DetailDataSet.Tables[0].Select("NV_ID=" + NV_ID + " and NGAY='" + System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]) + "'").Length == 0)
                            {
                                phieu.NV_ID = NV_ID;
                                phieu.NGAY = System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]);
                            }
                            if (HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.GhiThoiGian)
                            {
                                phieu.SANG = "";
                                phieu.CHIEU = "";
                                if (row["THOI_GIAN_SANG"] != null && row["THOI_GIAN_SANG"].ToString() != string.Empty)
                                {
                                    string[] TGSang = row["THOI_GIAN_SANG"].ToString().Split(':');
                                    phieu.SANG = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal((System.Convert.ToInt32(TGSang[0]) + (System.Convert.ToInt32(TGSang[1]) / 60.0))), 2).ToString();
                                }
                                if (row["THOI_GIAN_CHIEU"] != null && row["THOI_GIAN_CHIEU"].ToString() != string.Empty)
                                {
                                    string[] TGChieu = row["THOI_GIAN_CHIEU"].ToString().Split(':');
                                    phieu.CHIEU = HelpNumber.RoundDecimal(HelpNumber.ParseDecimal((System.Convert.ToInt32(TGChieu[0]) + (System.Convert.ToInt32(TGChieu[1]) / 60.0))), 2).ToString();
                                }
                            }
                            bool bflag = DAChamCongAuto.Instance.MergeDataSet(forDBChamCongAuto, phieu);

                            #region Cập nhật tình trạng chấm công tự động
                            if (bFlag)
                            {
                                DOTimeInOut doPhieu = DATimeInOut.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                doPhieu.IS_CHAM_CONG = "Y";
                                bFlag = DATimeInOut.Instance.MergeDataSet(forDBTime, doPhieu);
                            }
                            #endregion
                        }
                    }
                    bFlag = db.UpdateDataSet(forDBChamCongAuto, trans);
                    bFlag = db.UpdateDataSet(forDBTime, trans);
                    FWTransaction.Commit(trans);
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                    FWTransaction.Rollback(trans);
                }
            }
        }
        //Chỉ chuyển dữ liệu xin phép
        private void MoveNghiPhep(List<object> ids)
        {
            bool bFlag = true;
            if (ids != null)
            {

                DataSet forDBTime = new DataSet();//DABase.getDatabase().LoadTable(DATimeInOut.TABLE_MAP);
                DataSet forDBChamCongAuto = new DataSet();//DABase.getDatabase().LoadTable(DAChamCongAuto.TABLE_MAP);

                FWDBService db = null;
                DbTransaction trans = null;
                FWTransaction fwTrans = null;
                try
                {
                    db = HelpDB.getDBService();
                    trans = FWTransaction.BeginTrans(db);
                    fwTrans = new FWTransaction(db, trans);
                    fwTrans.LoadDataSet(forDBTime, "SELECT * FROM " + DATimeInOut.TABLE_MAP, DATimeInOut.TABLE_MAP);
                    fwTrans.LoadDataSet(forDBChamCongAuto, "SELECT * FROM " + DAChamCongAuto.TABLE_MAP, DAChamCongAuto.TABLE_MAP);
                    foreach (DataRow row in ((DataView)gridViewMaster.DataSource).Table.Rows)
                    {
                        bool IsChamCong = (row["IS_CHAM_CONG"].ToString() != "Y");
                        bool Duyet = (row["DUYET"] != null && row["DUYET"].ToString() == "2");
                        if ((HelpNumber.ParseInt64(row["LOAI"]) == (Int32)TimeInOutType.NghiPhep && IsChamCong && Duyet))
                        {
                            long NV_ID = HelpNumber.ParseInt64(row["NV_ID"]);
                            DOChamCongAuto phieu = DAChamCongAuto.Instance.LoadAll(fwTrans, NV_ID, (DateTime)row["NGAY_LAM_VIEC"]);
                            if (phieu.DetailDataSet.Tables[0].Select("NV_ID=" + NV_ID + " and NGAY='" + System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]) + "'").Length == 0)
                            {
                                phieu.NV_ID = NV_ID;
                                phieu.NGAY = System.Convert.ToDateTime(row["NGAY_LAM_VIEC"]);
                            }

                            if (row["NGHI_BUOI_SANG"] != null
                                && row["NGHI_BUOI_SANG"].ToString() != string.Empty
                                && row["NGHI_BUOI_SANG"].ToString() == "Y") phieu.SANG = string.Compare(row["NGHI_PHEP_NAM"].ToString(), "Y") == 0 ? "4" : "N";
                            if (row["NGHI_BUOI_CHIEU"] != null 
                                && row["NGHI_BUOI_CHIEU"].ToString() != string.Empty
                                && row["NGHI_BUOI_CHIEU"].ToString() == "Y") phieu.CHIEU = string.Compare(row["NGHI_PHEP_NAM"].ToString(), "Y") == 0 ? "4" : "N";

                            bool bflag = DAChamCongAuto.Instance.MergeDataSet(forDBChamCongAuto, phieu);
                            #region Cập nhật tình trạng chấm công tự động
                            if (bFlag)
                            {
                                DOTimeInOut doPhieu = DATimeInOut.Instance.LoadAll(HelpNumber.ParseInt64(row["ID"]));
                                doPhieu.IS_CHAM_CONG = "Y";
                                bFlag = DATimeInOut.Instance.MergeDataSet(forDBTime, doPhieu);
                            }
                            #endregion
                        }
                    }


                    bFlag = db.UpdateDataSet(forDBChamCongAuto, trans);
                    bFlag = db.UpdateDataSet(forDBTime, trans);
                    FWTransaction.Commit(trans);
                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                    FWTransaction.Rollback(trans);
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                }
            }
        }

        /// <summary>Lấy tình trạng chọn xem những người đã chấm công, chưa chấm công
        /// ....
        /// </summary>
        public string[] getISChamCong()
        {
            if ((chkDaChamCong.Checked && chkChuaChamCong.Checked)
                || (chkChuaChamCong.Checked == false && chkDaChamCong.Checked == false))
                return new string[] { "'Y'", "'N'", "''" };
            if (chkDaChamCong.Checked)
                return new string[] { "'Y'" };
            else
                return new string[] { "'N'" };
        }
        public void ShowFooter()
        {
            gridViewMaster.OptionsView.ShowFooter = true;
            CotTG_LV.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "0 giờ {0:#.###}(ngày)");
            HelpGridExt.SetFontFooter(gridViewMaster, new string[] { "THOI_GIAN_LAM_VIEC" }, Color.Blue, Color.Empty, FontStyle.Regular);
        }
        /// <summary>
        ///CHAUTV : Phân quyền xem dữ liệu
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="featureName"></param>
        private void ApplyPermissionData(PLDMGrid Input, string featureName)
        {
            List<Feature> features = Permission.loadAllFeatureByUser(FrameworkParams.currentUser.username);
            bool IsFull = false;
            foreach (Feature f in features)
            {
                if ((f.featureName == featureName && f.isRead == true) || FrameworkParams.currentUser.username.Equals("admin"))
                {
                    IsFull = true;
                    break;
                }
            }
            if (FrameworkParams.isPermision.getPublicForm().Contains(typeof(frmTimeInOutQL).FullName) == false && !IsFull)
            {
                Input._setSelectedID(FrameworkParams.currentUser.employee_id);
                Input.Enabled = false;
            }
        }
        #endregion

        #region IDuyetSupport Members

        public bool DuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.Duyet))
            {
                barButtonItemDuyet.Enabled = false;
                barButtonItemK_Duyet.Enabled = true;
                return true;
            }
            return false;
        }

        public bool KhongDuyetAction(long ID, long NguoiDuyetID, DateTime NgayDuyet)
        {
            if (PLGUIUtil.UpdateDuyetPhieu("CAPNHAT_NGAYLAMVIEC", "ID", ID, NguoiDuyetID, NgayDuyet, DuyetSupportStatus.KhongDuyet))
            {
                barButtonItemDuyet.Enabled = true;
                barButtonItemK_Duyet.Enabled = false;
                return true;
            }
            return false;
        }

        #endregion

        private void ShowColumns(object sender, EventArgs e)
        {
            CheckEdit chk = (sender as CheckEdit);
            if (chk.Tag.ToString().Equals("ChamCong"))
            {
                this.Cot_Cham_Cong.Visible = chk.Checked;
                if (chk.Checked)
                {
                    if (this.CotIP_Address.Visible == true)
                    {
                        this.CotIP_Address.VisibleIndex = this.Cot_Noi_Dung.VisibleIndex + 2;
                        this.Cot_Cham_Cong.VisibleIndex = this.Cot_Noi_Dung.VisibleIndex + 1;
                    }
                    else this.Cot_Cham_Cong.VisibleIndex = this.Cot_Noi_Dung.VisibleIndex + 1;
                }
            }
            if (chk.Tag.ToString().Equals("IPMay"))
            {
                this.CotIP_Address.Visible = chk.Checked;
                if (chk.Checked)
                {
                    if(this.Cot_Cham_Cong.Visible == true)
                        this.CotIP_Address.VisibleIndex = this.Cot_Noi_Dung.VisibleIndex + 2;
                    else this.CotIP_Address.VisibleIndex = this.Cot_Noi_Dung.VisibleIndex + 1;
                }
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