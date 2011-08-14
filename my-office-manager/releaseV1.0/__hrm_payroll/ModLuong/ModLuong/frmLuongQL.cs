#region using
using System;
using System.Data;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

using DevExpress.XtraGrid.Columns;
using DAO;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DA;
using System.Collections.Generic;
using ProtocolVN.App.Office;
using ProtocolVN.App.Office.__hrm_payroll.ModLuong.report;
using LumiSoft.Net.Mime;
using System.IO;
using LumiSoft.Net.SMTP.Client;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using DevExpress.XtraBars;

#endregion

namespace office
{
    public partial class frmLuongQL : PhieuQuanLyChange, IFormRefresh
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
        //private DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //protected DevExpress.XtraBars.BarSubItem barSubItem1;
        //#endregion

        #region Vung dat Static
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmLuongQL).FullName,
                "Tiền lương",
                ParentID, true,
                typeof(frmLuongQL).FullName,
                true, IsSep, "mnbTinhLuong.gif", true, "", "");
        }
        #endregion

        #region Khởi tạo
        private bool IsChamCongAuto = true;
        private bool accessPermision;
        private bool isLoadTG, isLoadNV;
        private StringBuilder strThangNam;
        private BarButtonItem tinhLuong, thanhToanLuong, ketChuyenTamUng;
        public frmLuongQL()
        {
            InitializeComponent();
            this.IDField = "ID";
            this.DisplayField = "NAME";
            accessPermision = DALuong.ApplyPermissionData();
            new PhieuQuanLyFix(this);
            barButtonItemSearch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridViewMaster.OptionsView.ColumnAutoWidth = false;
            barButtonItemChot.Glyph = FWImageDic.CHOICE_IMAGE20;
            barButtonItemChot.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            gridViewMaster.OptionsView.ShowGroupedColumns = false;
            this.gridViewMaster.OptionsCustomization.AllowGroup = true;
            strThangNam = new StringBuilder(",");
        }

        public override void InitColumnMaster()
        {
            XtraGridSupportExt.TextLeftColumn(CotHoTen, "NAME");
            CotSoNgay.FieldName = "SO_NGAY";
            XtraGridSupportExt.DecimalGridColumn(CotTongThuNhap, "TONG_THU_NHAP", 0);
            XtraGridSupportExt.DecimalGridColumn(CotTamUng, "TAM_UNG", 0);
            HelpGridColumn.CotCalcEdit(CotConLai, "TT_CON_LAI", 0);
            HelpGridColumn.CotPLImageCheck(CotKetChuyenTU, "IS_KET_CHUYEN");
            XtraGridSupportExt.DecimalGridColumn(CotKetChuyenSoTienTU, "KET_CHUYEN_TAM_UNG", 0);
            HelpGridColumn.CotCalcEdit(
               cotDaThanhToan, "DA_THANH_TOAN", 0);
            GridInteraction.AddCalc(this.gridViewMaster, "TT_CON_LAI",
               new string[] { "TONG_THU_NHAP", "TAM_UNG", "DA_THANH_TOAN" }, EditData);
            CotLuongCB.Visible = false;
            CotLuongTL.Visible = false;
            CotPhanTramTV.Visible = false;
            HelpTreeColumn.CotCheckEdit(CotTreeChot, "IS_CHOT");
            CotTreeChot.OptionsColumn.ReadOnly = true;
            CotKetChuyenTU.Visible = false;
        }
        public override void InitColumDetail()
        {
            #region Chi tiết lương
            GridColumn Cot_TuNgay = HelpGridColumn.ThemCot(gridViewDetail, "Từ ngày", 0, 150);
            XtraGridSupportExt.DateTimeGridColumn(Cot_TuNgay, "TU_NGAY");
            GridColumn Cot_DenNgay = HelpGridColumn.ThemCot(gridViewDetail, "Đến ngày", 1, 150);
            XtraGridSupportExt.DateTimeGridColumn(Cot_DenNgay, "DEN_NGAY");
            GridColumn Cot_HinhThuc = HelpGridColumn.ThemCot(gridViewDetail, "Hình thức", 2, 150);
            XtraGridSupportExt.TextLeftColumn(Cot_HinhThuc, "HINH_THUC");
            GridColumn Cot_PhanTram = HelpGridColumn.ThemCot(gridViewDetail, "Phần trăm", 3, 100);
            XtraGridSupportExt.TextRightColumn(Cot_PhanTram, "PHAN_TRAM");
            GridColumn Cot_MucLuong = HelpGridColumn.ThemCot(gridViewDetail, "Mức lương (VNĐ)", 4, 150);
            XtraGridSupportExt.DecimalGridColumn(Cot_MucLuong, "MUC_LUONG", 0);
            GridColumn Cot_SoNgay = HelpGridColumn.ThemCot(gridViewDetail, "Số ngày làm việc", 5, 100);
            Cot_SoNgay.FieldName = "SO_NGAY";
            GridColumn Cot_ThuNhap = HelpGridColumn.ThemCot(gridViewDetail, "Thu nhập (VNĐ)", 6, 150);
            XtraGridSupportExt.DecimalGridColumn(Cot_ThuNhap, "THU_NHAP", 0);
            #endregion

            #region Chi tiết tạm ứng
            HelpGridColumn.CotCalcEdit(colTU_SoTien, PhieuTamUngFields.SO_TIEN_XIN_UNG, 0);
            HelpGridColumn.CotDateEdit(col_NgayDeNghi, PhieuTamUngFields.NGAY_XIN_TAM_UNG);
            HelpGridColumn.CotCombobox(colTU_NguoiDuyet, "DM_NHAN_VIEN", "ID", "NAME", PhieuTamUngFields.NGUOI_DUYET);
            HelpGridColumn.CotTextLeft(colTU_LyDo, PhieuTamUngFields.LY_DO);
            #endregion

        }
        public override void PLLoadFilterPart()
        {
            ShowFooter();
            popupControlContainerFilter.Visible = false;
            barButtonItemUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barButtonItemXem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.gridViewDetailTamUng.OptionsBehavior.Editable = false;
            this.gridViewDetailTamUng.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.gridViewDetailTamUng.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridViewDetail.OptionsSelection.EnableAppearanceFocusedCell = false;
            HelpGridExt1.SetDefaultGroupPanel(this.gridViewMaster);
            barSubItem1.Enabled = true;
            if (barSubItem1.ItemLinks.Count > 0)
            {
                tinhLuong = barSubItem1.ItemLinks[0].Item as BarButtonItem;
                thanhToanLuong = barSubItem1.ItemLinks[1].Item as BarButtonItem;
                ketChuyenTamUng = barSubItem1.ItemLinks[2].Item as BarButtonItem;
            }
        }
        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder filter;
            if (xtraTabControl1.SelectedTabPageIndex == 1)//Tab Nhân viên
            {
                filter = GetDataTreeList2(IdNhanVien);
                CotHoTen.Group();
                barButtonItemChot.Enabled = false;
                if (!isLoadNV) { 
                    InitDanhSachNhanVienLeft();
                    isLoadNV = true;
                }
            }
            else
            {
                filter = GetDataTreeList1(strBangLuong);
                Thang.Group();
                if (treeListBangLuong.FocusedNode != null)
                    barButtonItemChot.Enabled = treeListBangLuong.FocusedNode.GetDisplayText("THANG_NAM").Contains("Năm") ? false : true;
                else barButtonItemChot.Enabled = false;
            }
            gridControlMaster.DataSource = HelpDB.getDatabase().LoadDataSet(filter).Tables[0];
            return null;
        }
        public override void ShowViewForm(long id)
        {
        }
        public override void ShowUpdateForm(long id)
        {
        }
        public override long[] ShowAddForm()
        {
            //Tạo bảng lương rỗng với dữ liệu ban đầu chỉ có : Tên nhân viên + Số tiền tạm ứng trong tháng (Lấy từ quản lý tạm ứng qua)
            ProtocolForm.ShowModalDialog(this, new frmCreatePayRoll(strThangNam));
            gridViewMaster.Focus();
            treeListBangLuong.ClearNodes();
            this.InitDanhSachThangTinhLuongLeft();

            return null;
        }
        public override bool XoaAction(long id)
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row["IS_CHOT"].ToString() == "Y")
            {
                return false;
            }
            if (DALuong.Ins.XoaDong(id))
                return true;
            return false;
        }
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
                new string[] {  
                                "Tính lương",
                                "Thanh toán lương",
                                "Kết chuyển tạm ứng",
                                "Thông báo lương"
                             },
                new string[] { "fwEdit.png", "fwEdit.png", "fwEdit.png", "DonViTinh.png" },
                "ID",
                new DelegationLib.CallFunction_MulIn_NoOut[]{    
                    FTinhLuong,
                    FThanhToanLuong,
                    FKetChuyenTamUng,
                    FThongBaoLuong
                }, null);
        
    return menu;
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        public override _Print InAction(long[] ids)
        {
            //string[] Ngay_thang = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["THANG_NAM"].ToString().Split('/');
            //double Ngay_trong_thang = XL_LUONG.Ins.NgayCuoiThang(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])).Day - XL_LUONG.Ins.SoNgayChuNhat(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])) - (1.0 * XL_LUONG.Ins.SoNgayThuBay(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])) / 2);
            //DatabaseFB db = DABase.getDatabase();
            //System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("ST_TINHLUONG");
            //db.AddInParameter(cmd, "@ITHANG_CHAM_CONG", DbType.String, gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["THANG_NAM"].ToString());
            //db.AddInParameter(cmd, "@INHAN_VIEN", DbType.Int64, (long)gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle)["NV_ID"]);
            //DataSet ds = new DataSet();
            //db.LoadDataSet(cmd, ds, "ST_TINHLUONG");
            //_Print print = new _Print();
            ////Sử dụng kiểu mới này ko cần Output file báo biểu
            //print.ReportNameFile = "EMB" + typeof(RPT_TinhLuong).FullName;
            //print.MainForm = this;
            //foreach (DataRow item in ds.Tables[0].Rows)
            //{
            //    item["NGAY_TRONG_THANG"] = Ngay_trong_thang;
            //}
            //print.MainDataset = ds;
            //print.SubDataset = null;
            return null;
        }
        public override string UpdateRow()
        {
            return @"SELECT l.*,nv.NAME ,
                            (select SUM(ct.SO_NGAY) from BANG_LUONG_CT ct where l.ID = ct.LUONG_ID) as SO_NGAY   FROM BANG_LUONG l
                            LEFT JOIN DM_NHAN_VIEN nv on l.NV_ID = nv.ID
                            WHERE 1=1";
        }
        public override void HookFocusRow()
        {
            
            barButtonItemDelete.Enabled = treeListBangLuong.FocusedNode.GetValue("IS_CHOT").Equals("Y") ? false : true;
        }
        public override DataTable PLLoadDataDetailPart(long MasterID)
        {
            DOBangLuong data = DABangLuong.Instance.LoadAll(MasterID);
            this.gridControlDetailTamUng.DataSource = DAPhieuTamUng.I.GetPhieu(data.NV_ID, data.THANG_NAM);
            return DALuongChiTiet.ChiTietThang(MasterID).Tables[0];
        }
        #endregion

        #region 2.Phần xử lý tính lương
        private DataTable DataTableLuoi()
        {
            DataTable tb = new DataTable("KQ");
            tb.Columns.Add("TU_NGAY", Type.GetType("System.DateTime"));
            tb.Columns.Add("DEN_NGAY", Type.GetType("System.DateTime"));
            tb.Columns.Add("HINH_THUC", Type.GetType("System.String"));
            tb.Columns.Add("PHAN_TRAM", Type.GetType("System.Int32"));
            tb.Columns.Add("MUC_LUONG", Type.GetType("System.Int64"));
            tb.Columns.Add("SO_NGAY", Type.GetType("System.Double"));
            tb.Columns.Add("THU_NHAP", Type.GetType("System.Decimal"));
            tb.Columns.Add("NV_ID", Type.GetType("System.Int64"));

            return tb;
        }
        private DataTable MoveData_DIEU_CHINH_LUONG_LUONGCT(string ThangNam, long NV_ID)
        {
            #region 1.0 Lay du lieu ben bang DIEU_CHINH_LUONG qua
            DataTable KetQua = this.DataTableLuoi();
            int Thang = int.Parse(ThangNam.Substring(0, 2));
            int Nam = int.Parse(ThangNam.Substring(3, 4));
            string sql = "SELECT dcl.TU_NGAY,dcl.PHAN_TRAM,dcl.MUC_LUONG ,iif(dcl.HINH_THUC=3,'Trợ cấp',iif(dcl.HINH_THUC=2,'Không lương',iif(dcl.HINH_THUC=1,'Bán thời gian',iif(dcl.IS_THU_VIEC = 'Y','Thử việc','Chính thức')))) as HINH_THUC FROM DIEU_CHINH_LUONG dcl WHERE dcl.NV_ID =" + NV_ID + " and extract(Year from dcl.TU_NGAY)=" + Nam + " and extract (Month from dcl.TU_NGAY)=" + Thang + " order by TU_NGAY";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "DIEU_CHINH_LUONG");
            #endregion

            #region 2.0 Them cot den ngay
            ds.Tables[0].Columns.Add("DEN_NGAY", Type.GetType("System.DateTime"));
            ds.Tables[0].Columns.Add("NV_ID", Type.GetType("System.Int64"));
            #endregion

            #region 3.0 Tìm ngày ngay trước ngày điều chỉnh lương lần đầu tiên trong tháng đang xem
            DataSet dsNgayDau = new DataSet();
            DatabaseFB fb = DABase.getDatabase();
            cmd = fb.GetSQLStringCommand("SELECT dcl.TU_NGAY,dcl.PHAN_TRAM,dcl.MUC_LUONG ,iif(dcl.HINH_THUC=3,'Trợ cấp',iif(dcl.HINH_THUC=2,'Không lương',iif(dcl.HINH_THUC=1,'Bán thời gian',iif(dcl.IS_THU_VIEC = 'Y','Thử việc','Chính thức')))) as HINH_THUC FROM DIEU_CHINH_LUONG dcl WHERE dcl.NV_ID =" + NV_ID + " and dcl.TU_NGAY < @TU_NGAY ORDER BY dcl.TU_NGAY DESC");
            db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, new DateTime(Nam, Thang, 1));
            fb.LoadDataSet(cmd, dsNgayDau, "DIEU_CHINH_LUONG");
            #endregion

            #region 4.0 Xu ly hien thi

            //Nếu không có điều chỉnh lương trong tháng
            if (ds.Tables[0].Rows.Count == 0)
            {
                //Xet ngay truoc do co dieu chinh luong
                //Neu khong co dieu chinh luong nao het thi KetQua khong co dong nao
                if (dsNgayDau.Tables[0].Rows.Count == 0)
                    return KetQua;
                else //Tao mot thang co dieu chinh luong la thang truoc do
                {
                    DataRow row = dsNgayDau.Tables[0].Rows[0];
                    DataRow _r = KetQua.NewRow();
                    _r["NV_ID"] = NV_ID;
                    _r["TU_NGAY"] = new DateTime(Nam, Thang, 1);
                    _r["DEN_NGAY"] = XL_LUONG.Ins.NgayCuoiThang(Thang, Nam);
                    _r["HINH_THUC"] = row["HINH_THUC"];
                    _r["PHAN_TRAM"] = row["PHAN_TRAM"];
                    _r["MUC_LUONG"] = row["MUC_LUONG"];
                    _r["SO_NGAY"] = 0;
                    _r["THU_NHAP"] = 0;
                    KetQua.Rows.Add(_r);
                    ThongKe(ref KetQua);
                    return KetQua;
                }
            }
            else //Co dieu chinh luong trong thang dang xet
            {
                //Duyet bo sung DEN_NGAY
                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i - 1]["NV_ID"] = NV_ID;
                    DateTime DenNgay = (DateTime)ds.Tables[0].Rows[i]["TU_NGAY"];
                    DenNgay = DenNgay.AddDays(-1);
                    ds.Tables[0].Rows[i - 1]["DEN_NGAY"] = DenNgay;
                }
                ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["DEN_NGAY"] = XL_LUONG.Ins.NgayCuoiThang(Thang, Nam);
                ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["NV_ID"] = NV_ID;
                //Neu ngay dieu chinh luong chinh la ngay dau thang
                if ((DateTime)ds.Tables[0].Rows[0]["TU_NGAY"] == new DateTime(Nam, Thang, 1))
                {
                    //Them cot vao ds
                    ds.Tables[0].Columns.Add(new DataColumn("SO_NGAY", Type.GetType("System.Decimal")));
                    ds.Tables[0].Columns.Add(new DataColumn("THU_NHAP", Type.GetType("System.Decimal")));
                    DataTable Kq = ds.Tables[0];
                    ThongKe(ref Kq);
                    return Kq;
                }
                else
                {
                    DataRow dr = KetQua.NewRow();
                    if (dsNgayDau.Tables[0].Rows.Count > 0)
                    {
                        DataRow r = dsNgayDau.Tables[0].Rows[0];
                        dr["NV_ID"] = NV_ID;
                        dr["TU_NGAY"] = new DateTime(Nam, Thang, 1);
                        dr["HINH_THUC"] = r["HINH_THUC"];
                        dr["MUC_LUONG"] = r["MUC_LUONG"];
                        dr["PHAN_TRAM"] = r["PHAN_TRAM"];
                        dr["SO_NGAY"] = 0;
                        dr["THU_NHAP"] = 0;
                        KetQua.Rows.Add(dr);
                    }
                    else
                    {
                        dr["NV_ID"] = NV_ID;
                        dr["TU_NGAY"] = new DateTime(Nam, Thang, 1);
                        dr["HINH_THUC"] = "Không lương";
                        dr["MUC_LUONG"] = 0;
                        dr["SO_NGAY"] = 0;
                        dr["THU_NHAP"] = 0;
                        KetQua.Rows.Add(dr);
                    }
                    //Sao chep qua
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        dr = KetQua.NewRow();
                        dr["NV_ID"] = item["NV_ID"];
                        dr["TU_NGAY"] = item["TU_NGAY"];
                        dr["DEN_NGAY"] = item["DEN_NGAY"];
                        dr["HINH_THUC"] = item["HINH_THUC"];
                        dr["PHAN_TRAM"] = item["PHAN_TRAM"];
                        dr["MUC_LUONG"] = item["MUC_LUONG"];
                        dr["SO_NGAY"] = 0;
                        dr["THU_NHAP"] = 0;
                        KetQua.Rows.Add(dr);
                    }
                    KetQua.Rows[0]["DEN_NGAY"] = ((DateTime)ds.Tables[0].Rows[0]["TU_NGAY"]).AddDays(-1);
                    KetQua.Rows[KetQua.Rows.Count - 1]["DEN_NGAY"] = XL_LUONG.Ins.NgayCuoiThang(Thang, Nam);
                }
                ThongKe(ref KetQua);
                return KetQua;
            }


            #endregion

        }
        private int[] GetThangNam(DateTime Ng)
        {
            int[] Kq = new int[2];
            Kq[0] = Ng.Month;
            Kq[1] = Ng.Year;
            return Kq;
        }
        private string GetStringThangNam(DateTime Ng)
        {
            if (Ng.Month < 10)
                return "0" + Ng.Month.ToString() + "/" + Ng.Year.ToString();
            else
                return Ng.Month.ToString() + "/" + Ng.Year.ToString();
        }
        private void ThongKeDong(ref DataTable tb, int row)
        {
            DataRow dr = tb.Rows[row];
            DateTime TuNgay = (DateTime)dr["TU_NGAY"];
            DateTime DenNgay = (DateTime)dr["DEN_NGAY"];
            long NV_ID = long.Parse(dr["NV_ID"].ToString());

            double SoNgayLamViec = XL_LUONG.Ins.SoNgayLamViec_NhanVien(TuNgay, DenNgay, NV_ID);
            if (this.IsChamCongAuto)
                SoNgayLamViec = HelpLuongAuto.GetSumDaysWorked(TuNgay, DenNgay, NV_ID);

            dr["SO_NGAY"] = SoNgayLamViec;
            int[] ThangNam = GetThangNam((DateTime)dr["TU_NGAY"]);
            decimal MucLuong = 0;
            decimal PhanTram = 0;
            double SoNgayThang = 0;
            switch (dr["HINH_THUC"].ToString().Trim())
            {
                case "Không lương":
                    MucLuong = 0;
                    PhanTram = 0;
                    SoNgayThang = 1;
                    break;
                case "Chính thức":
                    MucLuong = HelpNumber.ParseDecimal(dr["MUC_LUONG"].ToString());
                    PhanTram = 1;
                    SoNgayThang = XL_LUONG.Ins.SoNgayLamViecMax(ThangNam[0], ThangNam[1], true);

                    break;
                case "Thử việc":
                    MucLuong = HelpNumber.ParseDecimal(dr["MUC_LUONG"].ToString());
                    PhanTram = HelpNumber.ParseDecimal(dr["PHAN_TRAM"].ToString()) / 100;
                    SoNgayThang = XL_LUONG.Ins.SoNgayLamViecMax(ThangNam[0], ThangNam[1], true);

                    break;
                case "Bán thời gian":
                    MucLuong = HelpNumber.ParseDecimal(dr["MUC_LUONG"].ToString());
                    PhanTram = 1;
                    SoNgayThang = XL_LUONG.Ins.SoNgayLamViecMax(ThangNam[0], ThangNam[1], false);

                    break;
                case "Trợ cấp":
                    MucLuong = HelpNumber.ParseDecimal(dr["MUC_LUONG"].ToString());
                    PhanTram = 1;
                    SoNgayThang = 1;

                    break;
            }
            decimal ThuNhap = XL_LUONG.Ins.ThuNhap(MucLuong, SoNgayThang, SoNgayLamViec, PhanTram);
            dr["THU_NHAP"] = ThuNhap;


        }
        private void ThongKe(ref DataTable tb)
        {
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                ThongKeDong(ref tb, i);
            }
        }
        private decimal TongThuNhap(DataTable tb, string fieldname)
        {
            decimal Kq = 0;
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                Kq += HelpNumber.ParseDecimal(tb.Rows[i][fieldname].ToString());
            }
            return Kq;
        }
        #endregion

        #region Tìm kiếm độc lập theo tên nhân viên / Tháng tính lương
        private long IdNhanVien = -1;
        private string strBangLuong = "";
        public void InitTreeLeft()
        {
            //InitDanhSachNhanVienLeft();
            InitDanhSachThangTinhLuongLeft();
            gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            //gridViewMaster.OptionsView.ColumnAutoWidth = true;
        }
        public void InitDanhSachNhanVienLeft()
        {
            #region Lấy dữ liệu
            bool? IsAdd = true;
            QueryBuilder query = null;
            if (IsAdd == true)
                query = new QueryBuilder("SELECT * FROM DM_NHAN_VIEN Nv where VISIBLE_BIT = 'Y' AND 1=1");
            else
                query = new QueryBuilder("SELECT * FROM DM_NHAN_VIEN Nv where 1=1");
            query.setAscOrderBy("NAME");
            DataSet ds_NV = HelpDB.getDatabase().LoadDataSet(query);
            query = new QueryBuilder("Select ID,NAME from DEPARTMENT where PARENT_ID is not null and 1=1");
            //treeList2.ParentFieldName = "NAME";
            DataSet ds_PB = DABase.getDatabase().LoadDataSet(query);

            
            foreach (DataRow row_PB in ds_PB.Tables[0].Rows)
            {
                TreeListNode n = treeListNhanVien.AppendNode(new object[] { row_PB["NAME"].ToString(), -1 * HelpNumber.ParseInt64(row_PB["ID"]) }, -1);
                foreach (DataRow row_NV in ds_NV.Tables[0].Rows)
                {
                    if (row_PB["ID"].ToString() == row_NV["DEPARTMENT_ID"].ToString())
                    {
                        if (accessPermision == false && string.Compare(row_NV["ID"].ToString(), FrameworkParams.currentUser.employee_id.ToString()) == 0)
                            treeListNhanVien.AppendNode(new object[] { row_NV["NAME"].ToString(), row_NV["ID"].ToString() }, n.Id);
                        else if (accessPermision)
                            treeListNhanVien.AppendNode(new object[] { row_NV["NAME"].ToString(), row_NV["ID"].ToString() }, n.Id);
                    }
                }
            }
            treeListNhanVien.ExpandAll();

            #endregion

            #region Tạo sự kiện
            treeListNhanVien.FocusedNodeChanged += delegate(object sender, FocusedNodeChangedEventArgs e)
            {
                IdNhanVien = HelpNumber.ParseInt64(e.Node.GetValue(ID));
                gridControlMaster.DataSource = DABase.getDatabase().LoadDataSet(GetDataTreeList2(IdNhanVien)).Tables[0];
            };

            #endregion
        }
        private QueryBuilder GetDataTreeList2(long ID)
        {
            QueryBuilder filter = null;
            //            string _SQL = @"SELECT l.*,nv.NAME ,
            //                            (select SUM(ct.SO_NGAY) from BANG_LUONG_CT ct where l.ID = ct.LUONG_ID) as SO_NGAY   FROM BANG_LUONG l
            //                            LEFT JOIN DM_NHAN_VIEN nv on l.NV_ID = nv.ID
            //                            WHERE 1=1";
            filter = new QueryBuilder(UpdateRow());
            if (IdNhanVien < 0)
            {
                filter.addID("nv.DEPARTMENT_ID", -1 * IdNhanVien);
                if (!accessPermision) filter.addID("nv.ID", FrameworkParams.currentUser.employee_id);
            }
            else
                filter.addID("nv.ID", IdNhanVien);
            //filter.addBoolean("nv.VISIBLE_BIT", true);
            filter.setAscOrderBy("nv.NAME");
            filter.setAscOrderBy("THANG_NAM");
            //DatabaseFB db = DABase.getDatabase();
            //DataSet ds1 = new DataSet();
            //ds1 = db.LoadDataSet(filter);
            //gridControlMaster.DataSource = ds1.Tables[0];
            //if (ds1.Tables[0].Rows.Count > 0)
            //    gridViewMaster.FocusedRowHandle = 0;
            return filter;
        }
        public void InitDanhSachThangTinhLuongLeft()
        {
            #region Lấy dữ liệu
            QueryBuilder query = new QueryBuilder("select thang_nam , right(thang_nam,4) as nam, is_chot from bang_luong where 1=1");
            query.setDescOrderBy("THANG_NAM");
            query.addGroupBy("THANG_NAM,IS_CHOT");

            DataSet ds = HelpDB.getDatabase().LoadDataSet(query, "BANG_LUONG");
            DataTable Kq = new XLSortThangNam().Sort(ds.Tables[0]);
            treeListBangLuong.ParentFieldName = "NAM";
            query = new QueryBuilder("select right(thang_nam,4) as nam from bang_luong where 1=1");
            query.setDescOrderBy("NAM");
            query.addGroupBy("NAM");

            DataSet dsyy = DABase.getDatabase().LoadDataSet(query, "BANG_LUONG");

            foreach (DataRow dong in dsyy.Tables[0].Rows)
            {
                TreeListNode n = treeListBangLuong.AppendNode(new object[] { "Năm " + dong["NAM"].ToString(), "N" }, -1);
                foreach (DataRow item in Kq.Rows)
                {
                    if (HelpNumber.ParseInt32(item["NAM"]) == HelpNumber.ParseInt32(dong["NAM"]))
                    {
                        treeListBangLuong.AppendNode(new object[] { item["THANG_NAM"], item["IS_CHOT"] }, n.Id);
                        strThangNam.Append(item["THANG_NAM"].ToString() + ",");
                    }
                }
            }
            if (treeListBangLuong.FocusedNode != null)
            {
                barButtonItemChot.Enabled = treeListBangLuong.FocusedNode.GetDisplayText("THANG_NAM").Contains("Năm") ? false : true;
                strBangLuong = treeListBangLuong.FocusedNode.FirstNode.GetValue("THANG_NAM").ToString();
                treeListBangLuong.SetFocusedNode(treeListBangLuong.FocusedNode.FirstNode);
            }
            treeListBangLuong.ExpandAll();

            #endregion

            #region Tạo sự kiện
            treeListBangLuong.FocusedNodeChanged += new FocusedNodeChangedEventHandler(treeList1_FocusedNodeChanged);
            #endregion
        }
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null)
            {
                #region Ẩn hiện chốt
                if (e.Node.GetDisplayText("THANG_NAM").Contains("Năm"))
                {
                    barButtonItemChot.Enabled = false;
                }
                else{
                    barButtonItemChot.Enabled =true;
                    if (e.Node.GetValue("IS_CHOT").Equals("Y"))
                    {
                        barButtonItemChot.Caption = "Mở chốt";
                        barButtonItemChot.Glyph = FWImageDic.NO_CHOICE_IMAGE20;
                        if (tinhLuong != null) tinhLuong.Enabled = false;
                        if (thanhToanLuong != null) thanhToanLuong.Enabled = false;
                        if (ketChuyenTamUng != null) ketChuyenTamUng.Enabled = false;
                    }
                    else
                    {
                        barButtonItemChot.Caption = "Chốt";
                        barButtonItemChot.Glyph = FWImageDic.CHOICE_IMAGE20;
                        if (tinhLuong != null) tinhLuong.Enabled = true;
                        if (thanhToanLuong != null) thanhToanLuong.Enabled = true;
                        if (ketChuyenTamUng != null) ketChuyenTamUng.Enabled = true;
                    }
                }
                #endregion
                strBangLuong = e.Node.GetValue("THANG_NAM").ToString();
                gridControlMaster.DataSource = HelpDB.getDatabase().LoadDataSet(GetDataTreeList1(strBangLuong)).Tables[0];
            }
        }
        private QueryBuilder GetDataTreeList1(string strBangLuong)
        {
            QueryBuilder filter = null;
            //            string _SQL = @"SELECT l.*,nv.NAME ,
            //                            (select SUM(ct.SO_NGAY) from BANG_LUONG_CT ct where l.ID = ct.LUONG_ID) as SO_NGAY   FROM BANG_LUONG l
            //                            LEFT JOIN DM_NHAN_VIEN nv on l.NV_ID = nv.ID
            //                            WHERE 1=1";
            filter = new QueryBuilder(UpdateRow());
            if (!accessPermision) filter.addID("l.NV_ID", FrameworkParams.currentUser.employee_id);
            //filter.addBoolean("nv.VISIBLE_BIT", true);
            if (strBangLuong.Contains("Năm"))
                strBangLuong = strBangLuong.Substring(strBangLuong.IndexOf(' ') + 1);
            filter.addLike("THANG_NAM", strBangLuong.Trim());
            filter.setAscOrderBy("THANG_NAM");
            filter.setAscOrderBy("nv.NAME");
            //DatabaseFB db = DABase.getDatabase();
            //DataSet ds1 = new DataSet();
            //ds1 = db.LoadDataSet(filter);
            //gridControlMaster.DataSource = ds1.Tables[0];
            //if (ds1.Tables[0].Rows.Count > 0)
            //    gridViewMaster.SelectRow(0);
            return filter;
        }
        #endregion

        #region Khác
        public void ShowFooter()
        {
            gridViewMaster.OptionsView.ShowFooter = true;
            if (CotTamUng.SummaryItem.SummaryValue != null && CotTamUng.SummaryItem.SummaryValue.ToString() != "0")
                CotTamUng.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:#,###}");
            if (CotTongThuNhap.SummaryItem.SummaryValue != null && CotTongThuNhap.SummaryItem.SummaryValue.ToString() != "0")
                CotTongThuNhap.SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:#,###}");
            CotSoNgay.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        }
        #endregion

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

            gridViewMaster.OptionsCustomization.AllowGroup = true;
            this.gridViewMaster.ClearGrouping();
            //if (xtraTabControl1.SelectedTabPageIndex == 1)//Tab Nhân viên
            //{
            //    GetDataTreeList2(IdNhanVien);
            //    CotHoTen.Group();
            //}
            //else
            //{
            //    GetDataTreeList1(strBangLuong);
            //    Thang.Group();
            //}
            //gridControlMaster.RefreshDataSource();
            PLBuildQueryFilter();
            this.gridViewMaster.BestFitColumns();
        }

        private object EditData(DataRow row, string[] Fields)
        {
            row["TT_CON_LAI"] = HelpNumber.ParseDecimal(row["TONG_THU_NHAP"]) - HelpNumber.ParseDecimal(row["TAM_UNG"]) - HelpNumber.ParseDecimal(row["DA_THANH_TOAN"]);
            return row["TT_CON_LAI"];
        }

        #region Menu nghiệp vụ
        private void FChot(List<object> ids)
        {
            //Chốt tháng chọn tại danh sách bên trái
            string Month = treeListBangLuong.FocusedNode.GetDisplayText("THANG_NAM");
            DABangLuong.Instance.FChotLuong(Month, true);
            treeListBangLuong.ClearNodes();
            this.InitDanhSachThangTinhLuongLeft();
        }

        private void FMoChot(List<object> ids)
        {
            //Mở chốt tháng chọn tại danh sách bên trái
            string Month = treeListBangLuong.FocusedNode.GetDisplayText("THANG_NAM");
            DABangLuong.Instance.FChotLuong(Month, false);
            treeListBangLuong.ClearNodes();
            this.InitDanhSachThangTinhLuongLeft();
        }

        private void FTaoBangLuong(List<object> ids)
        {
            //Tạo bảng lương rỗng với dữ liệu ban đầu chỉ có : Tên nhân viên + Số tiền tạm ứng trong tháng (Lấy từ quản lý tạm ứng qua)
            //ProtocolForm.ShowModalDialog(this, new frmCreatePayRoll());
            //gridViewMaster.Focus();
            //treeListBangLuong.ClearNodes();
            //this.InitDanhSachThangTinhLuongLeft();
        }

        private void FTinhLuong(List<object> ids)
        {
            try
            {
                if (ids.Count == 0)
                {
                    HelpMsgBox.ShowNotificationMessage("Vui lòng chọn nhân viên để tính lương.");
                    return;
                }
                if (HelpMsgBox.ShowConfirmMessage("Bạn có đồng ý tính lương trên những người đã chọn không?") == System.Windows.Forms.DialogResult.No)
                    return;

                //Chọn nhân viên để tính lương (Dựa vào nhân viên + Tháng đang chọn)
                Application.DoEvents();
                FrameworkParams.wait = new WaitingMsg();
                foreach (object IDKey in ids)
                {
                    #region Xử lý phần lương
                    DOBangLuong phieu = DABangLuong.Instance.LoadAll(HelpNumber.ParseInt64(IDKey));
                    phieu.TONG_THU_NHAP = DABangLuong.Instance.GetTongThuNhap(phieu.NV_ID, phieu.THANG_NAM);
                    //CHAUTV : Theo yêu cầu anh Lộc lúc này mới chuyển tạm ứng qua
                    phieu.TAM_UNG = DABangLuong.Instance.GetSoTienTamUng(phieu.NV_ID, phieu.THANG_NAM);
                    //
                    phieu.IS_CHOT = "N";
                    phieu.DA_THANH_TOAN = 0;
                    #endregion

                    #region Xử lý phần chi tiết
                    DataTable tbLuongChiTiet = this.MoveData_DIEU_CHINH_LUONG_LUONGCT(phieu.THANG_NAM, phieu.NV_ID);
                    if (tbLuongChiTiet.Rows.Count > 0)
                    {
                        phieu.TONG_THU_NHAP = TongThuNhap(tbLuongChiTiet, "THU_NHAP");
                        phieu.TT_CON_LAI = phieu.TONG_THU_NHAP - phieu.TAM_UNG - phieu.DA_THANH_TOAN;
                        if (phieu.ID > 0) DABangLuongChiTiet.Instance.DeletePhieu(phieu.ID);
                        if (DABangLuong.Instance.Update(phieu))
                        {
                            decimal SoNgay = 0;
                            DataTable Tb = (DataTable)tbLuongChiTiet;
                            foreach (DataRow var in Tb.Rows)
                            {
                                DOLuongChiTiet phieuChiTiet = new DOLuongChiTiet();
                                phieuChiTiet.LUONG_ID = phieu.ID;
                                phieuChiTiet.PHAN_TRAM = var["PHAN_TRAM"].ToString().Length > 0 ? int.Parse(var["PHAN_TRAM"].ToString()) : 0;
                                phieuChiTiet.MUC_LUONG = (var["MUC_LUONG"].ToString().Length > 0) ? HelpNumber.ParseDecimal(var["MUC_LUONG"].ToString()) : 0;
                                phieuChiTiet.SO_NGAY = HelpNumber.ParseDecimal(var["SO_NGAY"].ToString());
                                phieuChiTiet.TU_NGAY = (DateTime)var["TU_NGAY"];
                                phieuChiTiet.DEN_NGAY = (DateTime)var["DEN_NGAY"];
                                phieuChiTiet.THU_NHAP = HelpNumber.ParseDecimal(var["THU_NHAP"].ToString());

                                string HinhThuc = var["HINH_THUC"].ToString();
                                HinhThuc = HinhThuc.Trim();
                                switch (HinhThuc)
                                {
                                    case "Không lương":
                                        phieuChiTiet.HINH_THUC = "2";
                                        break;
                                    case "Bán thời gian":
                                        phieuChiTiet.HINH_THUC = "1";
                                        break;
                                    case "Thử việc":
                                        phieuChiTiet.PHAN_TRAM = int.Parse(var["PHAN_TRAM"].ToString());
                                        phieuChiTiet.HINH_THUC = "0";
                                        phieuChiTiet.IS_THU_VIEC = "Y";
                                        break;
                                    case "Chính thức":
                                        phieuChiTiet.IS_THU_VIEC = "N";
                                        phieuChiTiet.HINH_THUC = "0";
                                        break;
                                    case "Trợ cấp":
                                        phieuChiTiet.HINH_THUC = "3";
                                        break;
                                }
                                SoNgay += phieuChiTiet.SO_NGAY;
                                DALuongChiTiet.ThemDong(phieuChiTiet);
                            }
                            DABangLuong.Instance.Update(phieu);
                            //Theo yêu cầu của anh Lộc 
                            DAPhieuTamUng.I.UpdatePhieuDuyet(phieu.NV_ID, phieu.THANG_NAM);
                        }
                    }
                    #endregion

                    else
                    {
                        //Trường hợp không có chi tiết lương, nghĩa là chỉ có bên tạm ứng
                        //Cập nhật tạm ứng
                        phieu.TONG_THU_NHAP = 0;
                        phieu.TT_CON_LAI = phieu.TONG_THU_NHAP - phieu.TAM_UNG - phieu.DA_THANH_TOAN;
                        DABangLuong.Instance.Update(phieu);
                        DAPhieuTamUng.I.UpdatePhieuDuyet(phieu.NV_ID, phieu.THANG_NAM);
                    }
                }
            }
            catch (Exception ex)
            {
                HelpSysLog.AddException(ex, "Tính lương.");
                ErrorMsg.ErrorSave("Lưu không thành công.");
            }
            finally
            {
                //gridViewMaster.Focus();
                //treeListBangLuong.ClearNodes();
                //this.InitDanhSachThangTinhLuongLeft();
                if (xtraTabControl1.SelectedTabPageIndex == 1)
                    gridControlMaster.DataSource = HelpDB.getDatabase().LoadDataSet(GetDataTreeList2(HelpNumber.ParseInt64(treeListNhanVien.FocusedNode.GetValue(ID)))).Tables[0];
                else
                    gridControlMaster.DataSource = DABase.getDatabase().LoadDataSet(GetDataTreeList1(treeListBangLuong.FocusedNode.GetValue("THANG_NAM").ToString())).Tables[0];
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }

        private void FKetChuyenTamUng(List<object> ids)
        {
            //Chuyển dữ liệu tạm ứng của nhân viên sang tháng kế tiếp (Với những dữ liệu lãnh tiền dư)
            //Mở form tạm ứng lên với dữ liệu ban đầu 
            //+ Nhân viên xin tạm ứng
            //+ Số tiền xin tạm ứng
            if (ids.Count > 0)
            {
                DOBangLuong data = DABangLuong.Instance.LoadAll(HelpNumber.ParseInt64(ids[0]));
                if (data.TT_CON_LAI < 0)
                {
                    DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
                    if (row["IS_KET_CHUYEN"].ToString() != "Y")
                    {
                        ProtocolForm.ShowModalDialog(this, new frmPhieuTamUng("-2", true, row));
                        //gridViewMaster.Focus();
                        //treeListBangLuong.ClearNodes();
                        //this.InitDanhSachThangTinhLuongLeft();
                        if (xtraTabControl1.SelectedTabPageIndex == 1)
                            gridControlMaster.DataSource = HelpDB.getDatabase().LoadDataSet(GetDataTreeList2(HelpNumber.ParseInt64(treeListNhanVien.FocusedNode.GetValue(ID)))).Tables[0];
                        else
                            gridControlMaster.DataSource = DABase.getDatabase().LoadDataSet(GetDataTreeList1(treeListBangLuong.FocusedNode.GetValue("THANG_NAM").ToString())).Tables[0];
                    }
                    else HelpMsgBox.ShowNotificationMessage("Đã kết chuyển tạm ứng cho nhân viên \"" + row["NAME"] + "\"!");
                }
                else HelpMsgBox.ShowNotificationMessage("Không thể kết chuyển tạm ứng!");
            }
        }

        private void FThanhToanLuong(List<object> ids)
        {
            try
            {
                if (ids.Count == 0)
                {
                    HelpMsgBox.ShowNotificationMessage("Vui lòng chọn nhân viên để tính lương.");
                    return;
                }
                if (HelpMsgBox.ShowConfirmMessage("Bạn có đồng ý thanh toán lương trên những người đã chọn không?") == DialogResult.Yes)
                {
                    Application.DoEvents();
                    FrameworkParams.wait = new WaitingMsg();
                    foreach (object IDKey in ids)
                    {
                        DOBangLuong phieu = DABangLuong.Instance.LoadAll(HelpNumber.ParseInt64(IDKey));
                        if (phieu.TT_CON_LAI > 0)
                        {
                            phieu.DA_THANH_TOAN = phieu.TT_CON_LAI;
                            phieu.TT_CON_LAI = 0;
                            DABangLuong.Instance.Update(phieu);
                        }
                        else HelpMsgBox.ShowNotificationMessage("Chỉ được thanh toán lương khi \"Còn lại (VNĐ)\" > 0!");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMsg.ErrorSave("Thanh toán lương không thành công.");
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Thanh toán lương.");
            }
            finally
            {
                gridViewMaster.Focus();
                //treeListBangLuong.ClearNodes();
                //this.InitDanhSachThangTinhLuongLeft();
                if (xtraTabControl1.SelectedTabPageIndex == 1)
                    gridControlMaster.DataSource = HelpDB.getDatabase().LoadDataSet(GetDataTreeList2(HelpNumber.ParseInt64(treeListNhanVien.FocusedNode.GetValue(ID)))).Tables[0];
                else
                    gridControlMaster.DataSource = DABase.getDatabase().LoadDataSet(GetDataTreeList1(treeListBangLuong.FocusedNode.GetValue("THANG_NAM").ToString())).Tables[0];
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }
        private void FThongBaoLuong(List<object> ids)
        {
            Application.DoEvents();
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc gửi thông báo lương của những người đã chọn không?") == DialogResult.Yes)
            {
                FrameworkParams.wait = new WaitingMsg();
                int[] indexs = gridViewMaster.GetSelectedRows();
                try
                {
                    foreach (int index in indexs)
                    {
                        if (gridViewMaster.IsGroupRow(index)) continue;
                        DataRow row = gridViewMaster.GetDataRow(index);
                        if (row == null) continue;
                        string thang_nam = row["THANG_NAM"].ToString();
                        long nv_id = HelpNumber.ParseInt64(row["NV_ID"]);
                        GuiThongBaoLuong("Thong bao luong " + thang_nam, SendThongBaoLuong(thang_nam, nv_id), nv_id);
                    }
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                }
                catch
                {
                    //HelpMsgBox.ShowNotificationMessage("Gửi thông báo lương thành công!");
                }
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }

        private void GuiThongBaoLuong(string subject, string fileName, long idNguoiNhan)
        {
            Mime message = new Mime();
            MimeEntity texts_enity = null;
            MimeEntity attachments_entity = null;
            message.MainEntity.ContentType = MediaType_enum.Multipart_mixed;
            texts_enity = message.MainEntity.ChildEntities.Add();
            texts_enity.ContentType = MediaType_enum.Multipart_alternative;
            attachments_entity = message.MainEntity;
            //File đính kèm
            MimeEntity attachment_entity = attachments_entity.ChildEntities.Add();
            attachment_entity.ContentType = MediaType_enum.Application_octet_stream;
            attachment_entity.ContentTransferEncoding = ContentTransferEncoding_enum.Base64;
            attachment_entity.ContentDisposition = ContentDisposition_enum.Attachment;
            attachment_entity.ContentDisposition_FileName = Path.GetFileName(fileName);
            attachment_entity.Data = File.ReadAllBytes(fileName);
            //Thông tin mail
            AddressList to = new AddressList();
            to.Add(new MailboxAddress("PL-Office", "info@protocolvn.net"));
            message.MainEntity.From = to;
            message.MainEntity.To = HelpZPLOEmail.GetAddressList(new long[] { idNguoiNhan });
            message.MainEntity.Subject = subject;
            message.MainEntity.Bcc = to;
            //Nội dung
            MimeEntity text_entity = texts_enity.ChildEntities.Add();
            text_entity.ContentType = MediaType_enum.Text_plain;
            text_entity.ContentType_CharSet = "utf-8";
            text_entity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
            text_entity.DataText = "Vui lòng xem chi tiết lương trong tập tin đính kèm email này.";
            //Gửi mail
            SmtpClientEx.QuickSendSmartHost("protocolvn.net", 25, "", message);
        }
        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            this.PLLoadFilterPart();
            return null;
        }

        #endregion

        private void frmLuongQL_Load(object sender, EventArgs e)
        {
            InitTreeLeft();
            xtraTabControl1.SelectedTabPageIndex = 0;//Tab Thời gian
            gridViewDetailTamUng.BestFitColumns();
            barButtonItemDelete.Caption = "&Xóa chi tiết lương";
            barButtonItemInTongHop.Glyph = FWImageDic.PRINT_IMAGE20;
            barButtonItemInTongHop.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            //Tô đỏ cho tháng đã chốt trong năm
            treeListBangLuong.CustomDrawNodeCell += delegate(object treeList, CustomDrawNodeCellEventArgs drawNode)
            {
                if (drawNode.Node.GetValue("IS_CHOT").Equals("Y")) drawNode.Appearance.ForeColor = Color.Red;
            };
            gridViewMaster.FocusedRowChanged += delegate(object gridView, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs rowChanged)
            {
                DataRow row = gridViewMaster.GetFocusedDataRow();
                //if (row == null || gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle)) barButtonItemInChiTiet.Enabled = false;
                //else barButtonItemInChiTiet.Enabled = true;
                barButtonItemInTongHop.Enabled = row != null;
                barButtonItemInChiTiet.Enabled = row != null;
            };

        }

        private string SendThongBaoLuong(string thang_nam, long nv_id)
        {
            string[] Ngay_thang = thang_nam.Split('/');
            double Ngay_trong_thang = XL_LUONG.Ins.NgayCuoiThang(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])).Day - XL_LUONG.Ins.SoNgayChuNhat(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])) - (1.0 * XL_LUONG.Ins.SoNgayThuBay(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])) / 2);
            DatabaseFB db = HelpDB.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("ST_TINHLUONG_CHITIET");
            db.AddInParameter(cmd, "@ITHANG_CHAM_CONG", DbType.String, thang_nam);
            db.AddInParameter(cmd, "@INHAN_VIEN", DbType.Int64, nv_id);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "ST_TINHLUONG_CHITIET");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                item["NGAY_TRONG_THANG"] = Ngay_trong_thang;
            }

            DatabaseFB dbS = DABase.getDatabase();
            System.Data.Common.DbCommand cmdS = db.GetStoredProcCommand("ST_TINHLUONG_CHITIET_SUB");

            DataSet dsS = new DataSet();
            dbS.LoadDataSet(cmdS, dsS, "ST_TINHLUONG_CHITIET_SUB");

            XRPT_TinhLuong_ChiTiet xr = new XRPT_TinhLuong_ChiTiet();
            xr.DataSource = ds;
            xr.xrSubreport1.ReportSource.DataSource = dsS;
            xr.xrSubreport2.ReportSource.DataSource = dsS;
            xr.ShowOne = true;
            string fileName = FrameworkParams.TEMPLETE_FOLDER + @"\Bang_luong_thang_" + thang_nam.Replace("/", "_") + ".png";
            xr.ExportToImage(fileName);
            return fileName;
        }

        private void barButtonItemChot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (barButtonItemChot.Caption.Equals("Chốt"))
            {
                //Chốt tháng chọn tại danh sách bên trái
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc chốt bảng lương đang chọn không?") == DialogResult.No)
                    return;
                Application.DoEvents();
                string Month = treeListBangLuong.FocusedNode.GetDisplayText("THANG_NAM");
                DABangLuong.Instance.FChotLuong(Month, true);
                treeListBangLuong.FocusedNode.SetValue("IS_CHOT", "Y");
                barButtonItemChot.Caption = "Mở chốt";
                barButtonItemChot.Glyph = FWImageDic.NO_CHOICE_IMAGE20;
                //treeListBangLuong.ClearNodes();
                //this.InitDanhSachThangTinhLuongLeft();
                treeListBangLuong.Refresh();
                HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                if (tinhLuong != null) tinhLuong.Enabled = false;
                if (thanhToanLuong != null) thanhToanLuong.Enabled = false;
                if (ketChuyenTamUng != null) ketChuyenTamUng.Enabled = false;
            }
            else {
                //Mở chốt tháng chọn tại danh sách bên trái
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc mở chốt bảng lương đang chọn không?") == DialogResult.No)
                    return;
                Application.DoEvents();
                string Month = treeListBangLuong.FocusedNode.GetDisplayText("THANG_NAM");
                DABangLuong.Instance.FChotLuong(Month, false);
                treeListBangLuong.FocusedNode.SetValue("IS_CHOT", "N");
                barButtonItemChot.Caption = "Chốt";
                barButtonItemChot.Glyph = FWImageDic.CHOICE_IMAGE20;
                //treeListBangLuong.ClearNodes();
                //this.InitDanhSachThangTinhLuongLeft();
                treeListBangLuong.Refresh();
                HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                if (tinhLuong != null) tinhLuong.Enabled = true;
                if (thanhToanLuong != null) thanhToanLuong.Enabled = true;
                if (ketChuyenTamUng != null) ketChuyenTamUng.Enabled = true;
            }
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row != null && !gridViewMaster.IsGroupRow(gridViewMaster.FocusedRowHandle))
                barButtonItemDelete.Enabled = !barButtonItemDelete.Enabled;
        }

        private void barButtonItemInTongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewMaster.SelectedRowsCount == 0) return;
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.GetSelectedRows()[0]);
            if (row == null) return;
            string thang_nam = row["THANG_NAM"].ToString();
            long nv_id = HelpNumber.ParseInt64(row["NV_ID"]);
            string[] Ngay_thang = thang_nam.Split('/');
            double Ngay_trong_thang = XL_LUONG.Ins.NgayCuoiThang(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])).Day - XL_LUONG.Ins.SoNgayChuNhat(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])) - (1.0 * XL_LUONG.Ins.SoNgayThuBay(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])) / 2);
            DatabaseFB db = HelpDB.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("ST_TINHLUONG_CHITIET");
            db.AddInParameter(cmd, "@ITHANG_CHAM_CONG", DbType.String, thang_nam);
            db.AddInParameter(cmd, "@INHAN_VIEN", DbType.Int64, nv_id);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "ST_TINHLUONG_CHITIET");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                item["NGAY_TRONG_THANG"] = Ngay_trong_thang;
            }

            DatabaseFB dbS = DABase.getDatabase();
            System.Data.Common.DbCommand cmdS = db.GetStoredProcCommand("ST_TINHLUONG_CHITIET_SUB");
          
            DataSet dsS = new DataSet();
            dbS.LoadDataSet(cmdS, dsS, "ST_TINHLUONG_CHITIET_SUB");

            XRPT_TinhLuong_ChiTiet xr = new XRPT_TinhLuong_ChiTiet();
            xr.DataSource = ds;
            xr.xrSubreport1.ReportSource.DataSource = dsS;
            xr.xrSubreport2.ReportSource.DataSource = dsS;
            xr.ShowPreview();
        }

        private void barButtonItemInChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridViewMaster.SelectedRowsCount == 0) return;
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.GetSelectedRows()[0]);
            if (row == null) return;
            string thang_nam = row["THANG_NAM"].ToString();
            string[] Ngay_thang = thang_nam.Split('/');
            double Ngay_trong_thang = XL_LUONG.Ins.NgayCuoiThang(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])).Day - XL_LUONG.Ins.SoNgayChuNhat(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])) - (1.0 * XL_LUONG.Ins.SoNgayThuBay(HelpNumber.ParseInt32(Ngay_thang[0]), HelpNumber.ParseInt32(Ngay_thang[1])) / 2);
            DatabaseFB db = HelpDB.getDatabase();
            System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("ST_BANG_LUONG");
            db.AddInParameter(cmd, "@ITHANG_CHAM_CONG", DbType.String, thang_nam);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "ST_BANG_LUONG");
            XRPT_BangLuong xr = new XRPT_BangLuong();
            xr.so_ngay.Value = Ngay_trong_thang;
            xr.thang_nam.Value = thang_nam;
            xr.RequestParameters = false;
            xr.DataSource = ds;
            xr.ShowPreview();
        }
    }
    ///Chú thích bổ sung cột Đã thanh toán : Phiên bản cuối 4325 (frmLuongQL), 1365 (DALuong)
}