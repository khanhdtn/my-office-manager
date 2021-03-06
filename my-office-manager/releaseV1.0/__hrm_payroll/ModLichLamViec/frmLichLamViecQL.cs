using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DAO;
using DTO;
using pl.helpdate;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using Word;
using ProtocolVN.DanhMuc;
using ProtocolVN.App.Office.__hrm_payroll.ModLichLamViec.report;
using DevExpress.XtraGrid.Views.Grid;

//Phiên bản bỏ 3 thông tin về PC,LT,Số máy 5951

namespace office
{
    public partial class frmLichLamViecQL : XtraFormPL 
    {
        #region Các biến của form Quan Ly Tuyệt đối không thay đổi

        protected DevExpress.XtraBars.BarManager barManager1;
        protected DevExpress.XtraBars.Bar MainBar;
        protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarStaticItem barStaticItem1;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        public DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.ComponentModel.IContainer components;
        protected DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        #endregion

        public static FormStatus Status = FormStatus.OK_DEV;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmLichLamViecQL).FullName,
                "Lịch làm việc",
                ParentID, true,
                typeof(frmLichLamViecQL).FullName,
                true, IsSep, "mnbLichLamViec.png", true, "", "");
        }

        public frmLichLamViecQL()
        {
            InitializeComponent();
            this.repositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            PLGridViewFix(gridViewMaster);
            //gridViewMaster.OptionsView.ColumnAutoWidth = false;
            barButtonItemIN.Caption = "&In";
        }

        //PHUOCNT NC Hàm này làm gì ? Còn cần nữa ko 
        //TRANGDTT NC Hàm này làm gì ? Còn cần nữa ko 
        public static void PLGridViewFix(DevExpress.XtraGrid.Views.Grid.GridView grdView)
        {
            grdView.OptionsSelection.EnableAppearanceFocusedCell = false;
            grdView.OptionsView.EnableAppearanceEvenRow = true;
            grdView.OptionsView.EnableAppearanceOddRow = true;
            //grdView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            grdView.OptionsView.ShowFooter = true;
            //grdView.OptionsBehavior.Editable = false;
            grdView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            grdView.OptionsCustomization.AllowGroup = true;
            grdView.BestFitColumns();
            //XtraGridSupport.ShowNumOfRecord(grdView.GridControl);
            HelpGrid.ShowNumOfRecord(grdView.GridControl);
            for (int i = 0; i < grdView.Columns.Count; i++)
            {
                grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        #region 0.Phần khai báo biến sử dụng
        int SoMayMacDinh = 14;
        Dictionary<int, DOLichLamViec> dsDongXoa = new Dictionary<int, DOLichLamViec>();
        int Key = 0;
        Boolean LCoDinh = true;
        #endregion

        #region 1.Các hàm khởi tạo
        private void InitMenuBar()
        {
            this.barButtonItemAdd.Glyph = FWImageDic.ADD_IMAGE20;
            this.barButtonItemNoCommit.Glyph = FWImageDic.UNCOMMIT_IMAGE20;
            this.barSubItem1.Glyph = FWImageDic.BUSINESS_IMAGE20;
            this.barButtonItemClose.Glyph = FWImageDic.CLOSE_IMAGE20;
            this.barButtonItemThemLichTuan.Glyph = FWImageDic.ADD_IMAGE20;
            this.barButtonItemThemLichCoDinh.Glyph = FWImageDic.ADD_IMAGE20;
            this.barButtonItemThemNhanVien.Glyph = FWImageDic.ADD_IMAGE20;
            this.barButtonItemIN.Glyph = FWImageDic.PRINT_IMAGE20;
        }
        private void InitDefaultGridViewMaster()
        {
            for (int i = 2; i <= 8; i++)
            {
                gridViewMaster.Bands[i - 1].Children[0].Children[0].Columns.Add(gridViewMaster.Columns["ST" + i.ToString()]);
                gridViewMaster.Bands[i - 1].Children[0].Children[1].Columns.Add(gridViewMaster.Columns["CT" + i.ToString()]);
                gridViewMaster.Bands[i - 1].Children[0].Children[0].Width = 40;
                gridViewMaster.Bands[i - 1].Children[0].Children[1].Width = 40;
            }
            gridBandNhanVien.Width = 150;
            b_xoa.Width = 25;
        }
        private void Init()
        {
            DataTable tb = DALichLamViec.Install.getLichMoiNhat();
            if (tb == null || tb.Rows.Count == 0)
            {
                if (DALichLamViec.Install.Exist_LichCoDinh())
                {
                    tb = DALichLamViec.Install.getLichCoDinh();
                    LCoDinh = true;
                }
                else return;
            }
            else
            {
                bardateEdit_NgayDauTuan.EditValue = (DateTime)tb.Rows[0]["NGAY_DAU_TUAN"];
                LCoDinh = false;
            }
            tb.Columns.Add(new DataColumn("C", Type.GetType("System.Double")));
            gridControlMaster.DataSource = tb;
            ReportCount();
            DateTime currentWeek = DateTime.Today;
            if (tb.Rows[0]["NGAY_DAU_TUAN"] != DBNull.Value &&
                tb.Rows[0]["NGAY_DAU_TUAN"] != null)
                currentWeek = (DateTime)tb.Rows[0]["NGAY_DAU_TUAN"];
            bardateEdit_NgayDauTuan.EditValue = currentWeek;
            ShowBandInfo(currentWeek, LCoDinh);

        }
        private void ShowBandInfo(DateTime InputNgayDauTuan, bool b_LichCD)
        {
            if (!b_LichCD)
            {
                List<DateTime> LTuan = PLHelpDate.getNgayTuan(InputNgayDauTuan);

                for (int i = 1; i <= 7; i++)
                {
                    gridViewMaster.Bands[i].Children[0].Caption = LTuan[i - 1].ToShortDateString();
                }
                HelpGrid.SetTitle((GridView)this.gridViewMaster, "LỊCH LÀM VIỆC TỪ NGÀY " + InputNgayDauTuan.ToShortDateString() + " ĐẾN " + InputNgayDauTuan.AddDays(7).ToShortDateString());
            }
            else
            {
                for (int i = 1; i <= 7; i++)
                {
                    gridViewMaster.Bands[i].Children[0].Caption = "";
                }
                HelpGrid.SetTitle((GridView)this.gridViewMaster,"LỊCH LÀM VIỆC CỐ ĐỊNH");
            }
        }
        #endregion

        #region 2. Các hàm thống kê dòng & Cột
        private void ReportCount()
        {
            CountRows();
        }
        private int CountColum(DataTable tb, string col, string value)
        {
            int cn = 0;
            for (int row = 0; row < gridViewMaster.RowCount; row++)
            {
                if (tb.Rows[row][col].ToString() == value)
                    cn++;
            }
            return cn;
        }
        private void CountColumns()
        {
            //DataTable tb = ((DataView)gridViewMaster.DataSource).Table;
            //for (int i = 2; i <= 8; i++)
            //{
            //    int XSang = CountColum(tb, "ST" + i.ToString(), "x");
            //    int XChieu = CountColum(tb, "CT" + i.ToString(), "x");
            //    int OSang = CountColum(tb, "ST" + i.ToString(), "o");
            //    int OChieu = CountColum(tb, "CT" + i.ToString(), "o");
            //    gridViewMaster.Bands[i - 1].Children[0].Children[0].Caption = XSang.ToString();
            //    gridViewMaster.Bands[i - 1].Children[0].Children[1].Caption = XChieu.ToString();
            //    gridViewMaster.Bands[i - 1].Children[0].Children[0].Children[0].Caption = OSang.ToString();
            //    gridViewMaster.Bands[i - 1].Children[0].Children[1].Children[0].Caption = OChieu.ToString();
            //    int ChenhLechSang = SoMayMacDinh - XSang;
            //    int ChenhLechChieu = SoMayMacDinh - XChieu;
            //    gridViewMaster.Bands[i - 1].Children[0].Children[0].Children[0].Children[0].Caption = ChenhLechSang.ToString();
            //    gridViewMaster.Bands[i - 1].Children[0].Children[1].Children[0].Children[0].Caption = ChenhLechChieu.ToString();
            //}

        }
        private int CountRow(DataTable tb, int row, string value)
        {
            int cn = 0;
            for (int i = 2; i <= 8; i++)
            {
                if (tb.Rows[row]["ST" + i.ToString()].ToString() == value)
                    cn++;
                if (tb.Rows[row]["CT" + i.ToString()].ToString() == value)
                    cn++;
            }
            return cn;

        }
        private void CountRows()
        {
            DataTable tb = ((DataView)gridViewMaster.DataSource).Table;
            for (int row = 0; row < tb.Rows.Count; row++)
            {
                tb.Rows[row]["C"] = (Double) CountRow(tb, row, "x")/2 + (Double)CountRow(tb,row,"o")/2;
            }
        }
        #endregion
        
        #region 2.Phần xử lý sự kiện
        
        private void barButtonItemNoCommit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable LCD = DALichLamViec.Install.getLichCoDinh();
            if (LCD != null)
            {
                LCD.Columns.Add(new DataColumn("C", Type.GetType("System.Double")));
                gridControlMaster.DataSource = LCD;
                this.ReportCount();
                LCoDinh = true;
                ShowBandInfo(new DateTime(1900, 1, 1), LCoDinh);
            }
        }
        
        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrameworkParams.wait = new WaitingMsg();
                
                #region Xu ly update phan hien tai dang tren luoi
                DataSet ds = ((DataView)gridViewMaster.DataSource).Table.DataSet;
                if (DALichLamViec.Install.UpdateDataSet(ds, LCoDinh))
                {
                    barButtonItemAdd.Enabled = false;
                    
                }
                #endregion
            }
            finally
            {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }
        
        private void barButtonItemThemLichTuan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.barButtonItemAdd.Enabled == true)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn lưu lịch hiện tại không ?") == DialogResult.Yes)
                {
                    DataSet ds = ((DataView)gridViewMaster.DataSource).Table.DataSet;
                    if (DALichLamViec.Install.UpdateDataSet(ds,LCoDinh))
                    {
                        this.barButtonItemAdd.Enabled = false;
                    }
                }

            }
            frmThemLichTuan them = new frmThemLichTuan();
            them.ThemMoiLichTuan += new frmThemLichTuan.ChuyenDuLieu(them_ThemMoiLichTuan);
            ProtocolForm.ShowModalDialog(this, them);
        }
        
        void them_ThemMoiLichTuan(DOLichLamViec LichDTO)
        {
            DataTable tb = DALichLamViec.Install.TimKiem(LichDTO.NGAY_DAU_TUAN);
            tb.Columns.Add(new DataColumn("C", Type.GetType("System.Double")));
            gridControlMaster.DataSource = tb;
            bardateEdit_NgayDauTuan.EditValue = LichDTO.NGAY_DAU_TUAN;
        }
        
        void rep_XoaLich_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có thực sự muốn xóa không ?") == DialogResult.Yes)
            {
                int row = gridViewMaster.FocusedRowHandle;
                DOLichLamViec Lich = new DOLichLamViec();
                Lich.ID = long.Parse(gridViewMaster.GetDataRow(row)["ID"].ToString());
                Lich.NV_ID = long.Parse(gridViewMaster.GetDataRow(row)["NV_ID"].ToString());
                dsDongXoa.Add(Key, Lich);
                #region Xu ly phan da xoa
                DALichLamViec.Install.DeleteRows(dsDongXoa);
                dsDongXoa = new Dictionary<int, DOLichLamViec>();
                Key = 0;
                #endregion
                gridViewMaster.DeleteRow(row);
                ((DataTable)gridViewMaster.GridControl.DataSource).AcceptChanges();
                //barButtonItemAdd.Enabled = true;
            }
        }
        
        private void barButtonItemThemLichCoDinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DALichLamViec.Install.Create_LichCoDinh(DABase.getDatabase().LoadDataSet("SELECT * FROM DM_NHAN_VIEN WHERE VISIBLE_BIT='Y'").Tables[0]))
            {
                DataTable dt = DALichLamViec.Install.getLichCoDinh();
                dt.Columns.Add(new DataColumn("C", Type.GetType("System.Double")));
                gridControlMaster.DataSource = dt;
                barButtonItemThemLichCoDinh.Enabled = false;
                LCoDinh = true;
            }
        }
        
        private void frmLichLamViecQL_Load(object sender, EventArgs e)
        {
            InitMenuBar();
            InitDefaultGridViewMaster();
            Init();
            rep_XoaLich.Click += new EventHandler(rep_XoaLich_Click);
            barButtonItemAdd.Enabled = false;
        }
        private void barSubItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DALichLamViec.Install.Exist_LichCoDinh())
                barButtonItemThemLichCoDinh.Enabled = false;
            else
                barButtonItemThemLichCoDinh.Enabled = true;
        }
        #endregion

        #region 4.Bổ sung nhân viên vào danh sách
        private void barButtonItemThemNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrameworkParams.wait = new WaitingMsg();

                #region - Xu ly thong bao
                int RecordNhanVien = DALichLamViec.Install.CountRecord("DM_NHAN_VIEN");
                if ((RecordNhanVien > 0 && RecordNhanVien == gridViewMaster.RowCount) || RecordNhanVien==0)
                {
                    return;
                }
                if (DALichLamViec.Install.CountRecord("LICH_LAM_VIEC") == 0)
                {
                    HelpMsgBox.ShowNotificationMessage("Lịch làm việc không tồn tại");
                    return;
                }
                #endregion

                #region - Lấy danh sách nhân viên không có trên lưới
                String sql = null;
                DataTable DL = ((DataView)gridViewMaster.DataSource).Table;
                if (DL.Rows.Count == 0)
                {
                    sql = "select * from DM_NHAN_VIEN where VISIBLE_BIT = 'Y'";
                }
                else
                {
                    String NV_ID = "(";
                    for (int i = 0; i < DL.Rows.Count; i++)
                    {
                        if (DL.Rows[i].RowState != DataRowState.Deleted)
                        {
                            NV_ID += DL.Rows[i]["NV_ID"];
                            if (i < DL.Rows.Count - 1)
                                NV_ID += ",";
                            else
                                NV_ID += ")";
                        }
                    }
                    if (NV_ID != "(")
                    {
                        sql = "select * from DM_NHAN_VIEN where VISIBLE_BIT = 'Y' and ID not in " + NV_ID;
                    }
                }
                //Lay chuoi truyen qua ben form Them nhan vien
                //Sau khi chon xong form Them nhan vien se tra ve mot chuoi sql

                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                DataSet NhanVienThem = new DataSet();
                db.LoadDataSet(cmd, NhanVienThem, "AA");
                
                #endregion

                #region - Luu xuong va hien thi
                foreach (DataRow item in NhanVienThem.Tables[0].Rows)
                {
                    DOLichLamViec LichDTO = new DOLichLamViec();
                    LichDTO.ID = DALichLamViec.Install.getGenID();
                    LichDTO.NV_ID = long.Parse(item["ID"].ToString());
                    LichDTO.GHI_CHU = "";
                    LichDTO.NGAY = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                    if (LCoDinh)
                    {
                        DALichLamViec.Install.Insert_LichCoDinh(LichDTO);
                    }
                    else
                    {
                        LichDTO.NGAY_DAU_TUAN = HelpDateExt.DayFirstOfWeek((DateTime) bardateEdit_NgayDauTuan.EditValue);
                        DALichLamViec.Install.Insert_LichTuan(LichDTO);
                    }
                    DataRow dr = DL.NewRow();
                    dr["ID"] = LichDTO.ID;
                    LichDTO.NV_ID = long.Parse(item["ID"].ToString());
                    dr["NV_ID"] = LichDTO.NV_ID;
                    
                    for (int i = 2; i <= 8; i++)
                    {
                        dr["ST" + i.ToString()] = "";
                        dr["CT" + i.ToString()] = "";
                    }
                    dr["GHI_CHU"] = "";
                    dr["NAME"] = DALichLamViec.Install.getTenNhanVien(LichDTO.NV_ID);
                    if (!LCoDinh) dr["NGAY_DAU_TUAN"] = LichDTO.NGAY_DAU_TUAN;
                    DL.Rows.Add(dr);
                    barButtonItemAdd.Enabled = true;
                    ReportCount();
                }
                #endregion
            }
            finally
            {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }

        }
        #endregion

        #region 4.Mở rộng
        private void gridViewMaster_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CountRows();
            this.barButtonItemAdd.Enabled = true;
        }
    
        private void bardateEdit_NgayDauTuan_EditValueChanged(object sender, EventArgs e)
        {
            DateTime Input = HelpDateExt.DayFirstOfWeek((DateTime)bardateEdit_NgayDauTuan.EditValue);
            ShowBandInfo(Input, false);
            DataTable LichTuan = DALichLamViec.Install.TimKiem(Input);
            if (LichTuan != null)
            {
                LichTuan.Columns.Add(new DataColumn("C", Type.GetType("System.Double")));
                gridControlMaster.DataSource = LichTuan;
                this.ReportCount();
                LCoDinh = false;
            }
        }
        private void bardateEdit_NgayDauTuan_HiddenEditor(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bardateEdit_NgayDauTuan_EditValueChanged(sender, e);
        }
        #endregion

        #region 5.In ấn
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                System.Data.Common.DbCommand cmd = db.GetStoredProcCommand("ST_LICH_LAM_VIEC");
                DateTime NgayDauTuan = HelpDateExt.DayFirstOfWeek((DateTime)this.bardateEdit_NgayDauTuan.EditValue);

                if (LCoDinh == false)
                    db.AddInParameter(cmd, "@DNGAY_DAU_TUAN", DbType.DateTime, NgayDauTuan);
                else
                {
                    db.AddInParameter(cmd, "@DNGAY_DAU_TUAN", DbType.DateTime, null);
                    return;
                }
                DataSet ds = new DataSet();
                db.LoadDataSet(cmd, ds, "ST_LICH_LAM_VIEC");
                DataView view = ds.Tables[0].DefaultView;
                view.Sort = "TEN_NV ASC";
                DataSet dsCopy=ds.Copy();
                DataSet dsSort =DALichLamViec.SortDataSet(dsCopy,view);
                _Print print = new _Print();
                print.ReportNameFile = "EMB" + typeof(RPT_LichLamViec).FullName;
                
                print.MainForm = this;
                print.MainDataset = dsSort;
                print.SubDataset = new DataSet[] { HeaderDataSet() };
                print.execPreviewWith();
            }
            catch (Exception ex)
            {
                HelpMsgBox.ShowErrorMessage(ex.Message);
            }
            finally
            {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }
        public DataSet HeaderDataSet()
        {
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("HEADER_COMPANY");
            ds = db.LoadDataSet(cmd, "HEADER_COMPANY");
            return ds;
        }
        #endregion
    }
}