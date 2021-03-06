using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Data.Common;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DTO;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.DanhMuc;
using DevExpress.XtraGrid.Views.Grid;

namespace office
{
    public partial class frmChamCongQL : XtraFormPL ,IFormRefresh
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
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.PopupMenu popupMenuFilter;
        protected DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;


        #endregion

        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmChamCongQL).FullName,
                "Chấm công bằng tay",
                ParentID, true,
                typeof(frmChamCongQL).FullName,
                true, IsSep, "mnbChamCong.png", true, "", "");
        }
        public frmChamCongQL()
        {
            InitializeComponent();
            HelpGrid.ShowNumOfRecord(gridControlDetails);
            ConditionsAdjustment(null);
            this.Text = "Chấm công bằng tay";
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            ShowImageMenu();
            DMNhanVienX.I.Load_NV_LV(PLNhanVien);
            ChonNgay = new DateTime[] { DateTime.Today.AddDays(-1), DateTime.Today, DateTime.Today.AddDays(1) };
            dateNav.Selection.Clear();
            dateNav.Selection.Add(DateTime.Today.AddDays(-1));
            dateNav.Selection.Add(DateTime.Today);
            dateNav.Selection.Add(DateTime.Today.AddDays(1));
            XemBangChamCong();
            barButtonItemAdd.Enabled = false;
            popupControlContainerFilter.Visible = true;
            this.barButtonItemAdd.Glyph = FWImageDic.SAVE_ALL_IMAGE16;
            HelpGridExt1.DisableCaptionGroupCol((GridView) this.gridViewDetails);
        }

        #region 0.Biến
        private int SoNgayChon = 1;
        DateTime[] ChonNgay = new DateTime[]{DateTime.Now};
        #endregion

        #region 1.Ham gan hinh vao menu
        private void ShowImageMenu()
        {
            this.barButtonItemAdd.Glyph = FWImageDic.ADD_IMAGE20;
            this.barSubItem1.Glyph = FWImageDic.BUSINESS_IMAGE20;
            this.barButtonItemThemNhanVien.Glyph = FWImageDic.ADD_IMAGE16;
            barButtonItemTimKiem.Glyph = FWImageDic.FIND_IMAGE20;
            btnChon.Image = FWImageDic.CHOICE_IMAGE20;
        }
        #endregion

        #region 2.Ham dung bang
        private DataTable CreateTable(string []Fields)
        {
            DataTable Kq = new DataTable();
            foreach (String fieldname in Fields)
            {
                Kq.Columns.Add (new DataColumn(fieldname, Type.GetType("System.String")));
            }
            Kq.Columns.Add(new DataColumn("NV_ID", Type.GetType("System.Int64")));
            Kq.Columns.Add(new DataColumn("NAME", Type.GetType("System.String")));
            Kq.Columns.Add(new DataColumn("N", Type.GetType("System.Decimal")));
            Kq.Columns.Add(new DataColumn("V", Type.GetType("System.Decimal")));
            Kq.Columns.Add(new DataColumn("SO", Type.GetType("System.Decimal")));
            Kq.Columns.Add(new DataColumn("KL", Type.GetType("System.Decimal")));
            Kq.Columns.Add(new DataColumn("TC", Type.GetType("System.Decimal")));
            Kq.Columns.Add(new DataColumn("HL", Type.GetType("System.Decimal")));
            
            return Kq;
        }
        #endregion

        #region 3.Tao luoi Details
        private void CreateGridViewDetail(string[] fields, string[] caption ,DateTime[]dsNgay )
        {
            //Làm sạch lưới
            gridViewDetails.Bands.Clear();
            int k = 0;
            int cotphu = 0;
            int SoCotPhu = 7;
            string[] CotPhuField = new String[] { "N", "V", "SO", "KL", "TC", "HL","" };

            #region 3.0.Các band và cột sử dụng
            GridBand[] BThu = new GridBand[fields.Length / 2 + 1 + SoCotPhu];
            for (k = 0; k < BThu.Length; k++)
            {
                BThu[k] = new GridBand();

            }
           
            GridBand[] BNgay = new GridBand[fields.Length / 2];
            GridBand[] BSangChieu = new GridBand[fields.Length * 2];

            BandedGridColumn[] BColumn = new BandedGridColumn[fields.Length + 1 + SoCotPhu];
            for (k = 0; k < BColumn.Length; k++)
            {
                BColumn[k] = new BandedGridColumn();
                if (k == 0)
                {
                    BColumn[k].FieldName = "NAME";
                    BColumn[k].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }
                else if (k <= fields.Length)
                {
                    BColumn[k].FieldName = fields[k - 1];
                    BColumn[k].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    BColumn[k].SummaryItem.DisplayFormat = "{0}";
                    BColumn[k].FieldName = fields[k - 1];
                }
                else
                {
                    BColumn[k].FieldName = CotPhuField[cotphu];
                    BColumn[k].Name = CotPhuField[cotphu];
                    BColumn[k].OptionsColumn.ReadOnly = true;
                    cotphu++;
                }
                
            }
            #endregion

            #region 3.1.Gắn bands và cột lên lưới
            gridViewDetails.Bands.AddRange(BThu);
            gridViewDetails.Columns.AddRange(BColumn);
            for (k = 0; k < gridViewDetails.Columns.Count; k++)
            {
                gridViewDetails.Columns[k].Visible = true;
                gridViewDetails.Columns[k].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            #endregion

            #region 3.2.Tạo các caption & band chứa band, ...
            BThu[0].Columns.Add(BColumn[0]);
            BThu[0].Caption = "Tên nhân viên";
            int tt = 0;
            for (int i = 1; i < BThu.Length - SoCotPhu; i++)
            {
                BNgay[i - 1] = new GridBand();
                BThu[i].Children.Add(BNgay[i - 1]);

                BSangChieu[tt] = new GridBand();
                BSangChieu[tt].Caption = "Sáng";
                BSangChieu[tt].Width = BSangChieu[tt].Caption.Length;
                BSangChieu[tt].Columns.Add(BColumn[tt + 1]);
                BNgay[i - 1].Children.Add(BSangChieu[tt++]);


                BSangChieu[tt] = new GridBand();
                BSangChieu[tt].Caption = "Chiều";
                BSangChieu[tt].Width = BSangChieu[tt].Caption.Length;
                BSangChieu[tt].Columns.Add(BColumn[tt + 1]);
                BNgay[i - 1].Children.Add(BSangChieu[tt++]);

            }
           
            string[] CotPhuTen = new String[] { "Nghỉ có phép", "Nghỉ không phép", "Số ngày làm việc", "Số ngày không lương","Số ngày trợ cấp", "Số ngày hưởng lương", "" };
            int col = 0;
            for (k = BThu.Length - SoCotPhu; k < BThu.Length; k++)
            {
                BThu[k].Name = CotPhuField[col];
                BThu[k].Caption = CotPhuTen[col];
                BThu[k].Columns.Add(BColumn[tt + 1]);
                tt++;
                col++;
            }
            #endregion

            #region 3.3.Gắn các tool lên cột
            //Nut xoa
            DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit rep_xoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            rep_xoa.Buttons.Add(new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete));
            rep_xoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            BColumn[BColumn.Length - 1].ColumnEdit = rep_xoa;
            rep_xoa.Buttons[0].Width = 23;
            BColumn[BColumn.Length - 1].Width = 23;
            BThu[BThu.Length - 1].Width = 23;
            BThu[BThu.Length - 1].MinWidth = 23;
            BThu[BThu.Length - 1].OptionsBand.FixedWidth = true;
            BThu[BThu.Length - 1].OptionsBand.AllowSize = false;
            rep_xoa.Click += new EventHandler(rep_xoa_Click);
            //rep_cbb
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox rep_cbb = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            rep_cbb.Items.AddRange(new object[] {"N", "V", "4" });

            for (k = 1; k <= fields.Length; k++)
            {
                BColumn[k].ColumnEdit = rep_cbb;
                BColumn[k].MinWidth = BSangChieu[k - 1].Caption.Length;
                BColumn[k].Width = 40;
            }
            #endregion
               
            #region 3.4.Một số định dạng khác
            BColumn[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;
            BColumn[0].OptionsColumn.ReadOnly = true;
            BColumn[0].OptionsColumn.AllowEdit = false;
            BColumn[0].OptionsColumn.AllowFocus = false;
            
            gridViewDetails.Columns["KL"].OptionsColumn.AllowFocus = false;
            gridViewDetails.Columns["TC"].OptionsColumn.AllowFocus = false;
            gridViewDetails.Columns["N"].OptionsColumn.AllowFocus = false;
            gridViewDetails.Columns["V"].OptionsColumn.AllowFocus = false;
            gridViewDetails.Columns["SO"].OptionsColumn.AllowFocus = false;
            gridViewDetails.Columns["HL"].OptionsColumn.AllowFocus = false;

            gridViewDetails.Columns["SO"].Width = 40;
            gridViewDetails.Columns["SO"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewDetails.Columns["KL"].Width = 40;
            gridViewDetails.Columns["KL"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewDetails.Columns["V"].Width = 40;
            gridViewDetails.Columns["V"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewDetails.Columns["N"].Width = 40;
            gridViewDetails.Columns["N"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewDetails.Columns["TC"].Width = 40;
            gridViewDetails.Columns["TC"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewDetails.Columns["HL"].Width = 45;
            gridViewDetails.Columns["HL"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            for (k = 2; k <= 7; k++)
            {
                BThu[BThu.Length - k].AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            }

            
            BThu[0].Width = 150;
            BThu[0].OptionsBand.FixedWidth = true;
            BThu[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            BThu[BThu.Length - 1].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            for (k = BThu.Length -1 ; k>= BThu.Length - SoCotPhu; k--)
            {
                BThu[k].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            }
            for (k = 0; k < dsNgay.Length; k++)
            {
                BThu[k + 1].Caption = HelpDateExt.GetDayOfWeekVN(dsNgay[k]);
                BNgay[k].Caption = dsNgay[k].ToShortDateString();

            }
            for (k = 0; k < BThu.Length; k++)
            {
                BThu[k].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            int l = 0;
            for (k = 0; k < BNgay.Length; k++)
            {
                BNgay[k].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                BSangChieu[l++].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                BSangChieu[l++].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            
            gridViewDetails.OptionsView.ShowColumnHeaders = false;
           
            
            #endregion

        }

        void rep_xoa_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có thực sự muốn xóa không ?") == DialogResult.Yes)
            {
                DataRow dr = gridViewDetails.GetDataRow(gridViewDetails.FocusedRowHandle);
                for (int i = 0; i < ChonNgay.Length; i++)
                {
                    DOBangChamCong dto = new DOBangChamCong();
                    dto.NV_ID = long.Parse(dr["NV_ID"].ToString());
                    dto.NGAY = ChonNgay[i];
                    DABangChamCong.Ins.XoaDong(dto);
                }
                gridViewDetails.DeleteRow(gridViewDetails.FocusedRowHandle);
                ((DataTable)gridControlDetails.DataSource).AcceptChanges();
                barButtonItemAdd.Enabled = true;
            }
            
            
        }
        #endregion

        #region 4.Lay danh sach ID nhan vien
        public DataTable GetNV_ID(long id)
        {
            DatabaseFB fb = HelpDB.getDatabase();
            string sql = "";
            if (id == -1)
                sql = "select NV_ID from BANG_CHAM_CONG group by NV_ID";
            else
                sql = "select NV_ID from BANG_CHAM_CONG where NV_ID = " + id.ToString() + " group by NV_ID";
            DbCommand cmd = fb.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            fb.LoadDataSet(cmd, ds, "BANG_CHAM_CONG");
            return ds.Tables[0];
        }
        #endregion

        #region 5.Truyen du lieu
        public void LoadData()
        {
            String[] fields = new String[ChonNgay.Length * 2];
            string[] Params = new string[ChonNgay.Length];
            int i = 0;
            int cn = 0;

            #region 5.1.Tạo fields
            foreach (DateTime item in ChonNgay)
            {
                Params[cn] = "P" + cn.ToString();
                fields[i++] = "S" + cn.ToString();
                fields[i++] = "C" + cn.ToString();
                cn++;
            }
            #endregion

            #region 5.2.Tạo bảng tương ứng và lấy dánh sách nhân viên trong bảng chấm công
            DanhSachCotDaChot = new List<string>();
            DataTable Kq = CreateTable(fields);
            DataTable Nv = GetNV_ID(PLNhanVien._getSelectedID());
            #endregion

            #region 5.3.Đưa dữ liệu vào bảng 
            for (int row = 0; row < Nv.Rows.Count; row++)
            {
                #region 5.3.1.Lấy dữ liệu của nhân viên row và sắp tăng theo ngày
                string sql = "select bcc.NV_ID,bcc.NGAY,bcc.SANG,bcc.CHIEU,nv.NAME from BANG_CHAM_CONG bcc, DM_NHAN_VIEN nv where nv.ID = bcc.NV_ID and bcc.NV_ID = @NV_ID and (";

                for (i = 0; i < Params.Length; i++)
                {
                    sql += "NGAY = @" + Params[i];
                    if (i < Params.Length - 1)
                        sql += " Or ";

                }
                sql += ") order by NGAY asc";
                DatabaseFB fb = HelpDB.getDatabase();
                DbCommand cmd = fb.GetSQLStringCommand(sql);
                fb.AddInParameter(cmd, "@NV_ID", DbType.Int64, long.Parse(Nv.Rows[row]["NV_ID"].ToString()));
                for (i = 0; i < Params.Length; i++)
                {
                    fb.AddInParameter(cmd, "@" + Params[i], DbType.DateTime, (DateTime)ChonNgay[i]);

                }
                DataSet ds = new DataSet();
                fb.LoadDataSet(cmd, ds, "BANG_CHAM_CONG");

                #endregion
                #region 5.3.2.Đưa dữ liệu lên bảng Kq
             
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int sc = 0;
                    DataRow dr = Kq.NewRow();
                    for (int col = 0; col < ChonNgay.Length;col++)
                    {
                        dr["NV_ID"] = long.Parse(ds.Tables[0].Rows[0]["NV_ID"].ToString());
                        dr["NAME"] = ds.Tables[0].Rows[0]["NAME"].ToString();
                        string sang = "";
                        string chieu = "";
                        foreach (DataRow r in ds.Tables[0].Rows)
                        {
                            if (NgayBangNgay((DateTime)r["NGAY"],ChonNgay[col]))
                            {
                                sang = r["SANG"].ToString();
                                chieu = r["CHIEU"].ToString();
                                break;
                            }
                        }
                        dr[sc] = sang; sc++;
                        dr[sc] = chieu; sc++;

                    }
                    
                    Kq.Rows.Add(dr);
                }
                #endregion
            }
            #endregion

            #region 5.4.Tạo lưới và hiển thị dữ liệu lên lưới
            this.CreateGridViewDetail(fields, new String[] { "", "" }, ChonNgay);

            gridControlDetails.DataSource = Kq;
            #endregion

            CapNhatThongKe();
            ShowFooter();
        }
        #endregion

        #region 6.Lưu dữ liệu <????>
        private bool CapNhat()
        {
            string err = string.Empty;
            try
            {
                DataTable tb = (DataTable)gridControlDetails.DataSource;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int sc = 0;
                    for (int j = 0; j < ChonNgay.Length; j++)
                    {
                        DOBangChamCong dto = new DOBangChamCong();
                        dto.NGAY = ChonNgay[j];
                        dto.NV_ID = long.Parse(tb.Rows[i]["NV_ID"].ToString());
                        dto.SANG = tb.Rows[i][sc].ToString();
                        sc++;
                        dto.CHIEU = tb.Rows[i][sc].ToString();
                        sc++;
                        if (DABangChamCong.Ins.IsTonTai(dto.NV_ID, dto.NGAY))
                        {
                            if (dto.SANG.Length > 0 || dto.CHIEU.Length > 0)
                                DABangChamCong.Ins.LuuDong(dto);
                            else if (dto.SANG == "" && dto.CHIEU == "")
                                DABangChamCong.Ins.XoaDong(dto);
                        }
                        else
                        {
                            if(dto.SANG.Length>0 ||dto.CHIEU.Length>0)
                                DABangChamCong.Ins.ThemDong(dto);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                err = ex.Message;
                HelpMsgBox.ShowErrorMessage(ex.Message);
            }
            if (err == string.Empty)
                return true;
            return false;
            
        }
        #endregion

        #region 7.Ham bo sung nhan vien vao danh sách còn thiếu
        public DataTable LocNhanVien()
        {
            int i = 0;
            string sql = "select * from DM_NHAN_VIEN nv where VISIBLE_BIT = 'Y'";
            string dsID = "(";
            DataTable ds_NV_ID = (DataTable)gridControlDetails.DataSource;
            if (ds_NV_ID.Rows.Count > 0)
            {
                for (i = 0; i < ds_NV_ID.Rows.Count; i++)
                {
                    dsID += ds_NV_ID.Rows[i]["NV_ID"].ToString();
                    if (i < ds_NV_ID.Rows.Count - 1)
                        dsID += ",";
                    else
                        dsID += ")";
                }
                sql += "and nv.ID not in " + dsID + " order by nv.NAME ";
            }
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand select = db.GetSQLStringCommand(sql);
            DataSet ds_BoSung = new DataSet();
            db.LoadDataSet(select, ds_BoSung, "TABLE");
            return ds_BoSung.Tables[0];
        }
        public void ThemNhanVien()
        {
            //Xem lại hàm này bên chấm công tự động để sửa lại
            DataTable Kq = ((DataTable)gridControlDetails.DataSource);
            DataTable NVBoSung = this.LocNhanVien();
            if (NVBoSung.Rows.Count > 0)
            {
                for (int i = 0; i < NVBoSung.Rows.Count; i++)
                {
                    DataRow dr = Kq.NewRow();
                    dr["NV_ID"] = long.Parse(NVBoSung.Rows[i]["ID"].ToString());
                    dr["NAME"] = NVBoSung.Rows[i]["NAME"].ToString();
                    Kq.Rows.Add(dr);

                    //Ghi xuong csdl
                    for (int j = 0; j < SoNgayChon; j++)
                    {
                        DOBangChamCong dto = new DOBangChamCong();
                        dto.NV_ID = long.Parse(dr["NV_ID"].ToString());
                        dto.NGAY = ChonNgay[j];
                        dto.SANG = "";
                        dto.CHIEU = "";
                        dto.THANG_NAM = "";
                        DABangChamCong.Ins.ThemDong(dto);
                    }
                }
                barButtonItemAdd.Enabled = true;
                CapNhatThongKe();
            }
            
        }
        #endregion

        #region 8.Cập nhật dữ liệu hàng thống kê
        public bool IsNumber(string str)
        {
            decimal value = 0;
            string er = string.Empty;
            try
            {
                value = Decimal.Parse(str);

            }
            catch (Exception ex)
            {
                er = ex.Message;
                
            }
            if (er == string.Empty)
                return true;
            return false;
        }
        private bool NgayBangNgay(DateTime Ng1, DateTime Ng2)
        {
            if (Ng1.Date==Ng2.Date)
                return true;
            return false;
        }
        private decimal CountRow(int row, object value)
        {
            decimal Kq = 0;
            DataRow dr = gridViewDetails.GetDataRow(row);
            for (int i = 0; i < SoNgayChon*2; i++)
            {
                if (dr[i].ToString() == value.ToString())
                    Kq++;
            }
            return Kq;

        }
        private decimal CountSo(int row)
        {
            decimal Kq = 0;
            DataRow dr = gridViewDetails.GetDataRow(row);
            for (int i = 0; i < SoNgayChon * 2; i++)
            {
                decimal value = 0;
                string er = string.Empty;
                try
                {
                    value = Decimal.Parse(dr[i].ToString());

                }
                catch (Exception ex)
                {
                    er = ex.Message;
                    
                }
                if(er==string.Empty)
                    Kq += Decimal.Parse(dr[i].ToString());
            }
            return Kq;
        }
        private void CapNhatThongKeDong(int row)
        {
            DataRow dr = gridViewDetails.GetDataRow(row);
            dr["V"] = CountRow(row, (object)"V")/2;
            dr["N"] = CountRow(row, (object)"N")/2;
            //dr["SO"] = (decimal)(CountSo(row) / 8 - (CountRow(row, "V")/2));
            dr["SO"] = HelpNumber.RoundDecimal((decimal)(CountSo(row) / 8),4);
            
            
        }
        private void CapNhatThongKe()
        {

            for (int row = 0; row < gridViewDetails.RowCount; row++)
            {
                CapNhatThongKeDong(row);
                DuyetThongKe_TC_HL_KL(row);
            }
        }
        private ArrayList DsNgay(int HinhThuc,int row)
        {
            DataRow dr = gridViewDetails.GetDataRow(row);
            ArrayList list = new ArrayList();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand("select * from DIEU_CHINH_LUONG where NV_ID = @NV_ID and HINH_THUC = @HINH_THUC and (TU_NGAY between @TU_NGAY and @DEN_NGAY )");
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, long.Parse(dr["NV_ID"].ToString()));
            db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime,ChonNgay[0]);
            db.AddInParameter(cmd, "@DEN_NGAY", DbType.DateTime, ChonNgay[ChonNgay.Length - 1]);
            db.AddInParameter(cmd, "@HINH_THUC", DbType.String, HinhThuc.ToString());
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "DIEU_CHINH_LUONG");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    list.Add((DateTime)r["TU_NGAY"]);
                    
                }
                
            }
            list.Sort();
           
            return list;
        }
    
        #region Thong ke TC,HL,KL
        public ArrayList DsDieuChinhLuong(DateTime TuNgay, DateTime DenNgay,long NV_ID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand("select TU_NGAY,HINH_THUC from DIEU_CHINH_LUONG where NV_ID = @NV_ID and (TU_NGAY between @TU_NGAY and @DEN_NGAY ) order by TU_NGAY asc");
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, TuNgay);
            db.AddInParameter(cmd, "@DEN_NGAY", DbType.DateTime, DenNgay);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "DIEU_CHINH_LUONG");
            ArrayList Kq = new ArrayList();
            DataRow d;
            if (ds.Tables[0].Rows.Count > 0)
                d = CanDuoiNgay((DateTime)ds.Tables[0].Rows[0]["TU_NGAY"], NV_ID);
            else
                d = CanDuoiNgay(TuNgay, NV_ID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (d != null && !NgayBangNgay((DateTime)d["TU_NGAY"], (DateTime)ds.Tables[0].Rows[0]["TU_NGAY"]))
                    Kq.Add(d);
            }
            else if (d != null)
                Kq.Add(d);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Kq.Add(dr);
                }
            }
            return Kq;
        }
        public void DuyetThongKe_TC_HL_KL(int row)
        {
            try
            {
                DataRow dr = gridViewDetails.GetDataRow(row);
                long NV_ID = long.Parse(dr["NV_ID"].ToString());
                ArrayList list = DsDieuChinhLuong(ChonNgay[0], ChonNgay[ChonNgay.Length - 1], NV_ID);

                decimal TC = 0;
                decimal KL = 0;
                decimal HL = 0;

                //Duyet du lieu tren luoi
                int colNext = 1;
                int cnNgay = 0;
                for (int col = 0; col < 2 * ChonNgay.Length; col += 2)
                {
                    if (IsNumber(dr[col].ToString()) || IsNumber(dr[colNext].ToString()) || Vang(dr[col].ToString()) || Vang(dr[colNext].ToString()))
                    {

                        for (int i = list.Count - 1; i >= 0; i--)
                        {
                            DataRow r = (DataRow)list[i];

                            if (SoSanhNgay(ChonNgay[cnNgay], (DateTime)r["TU_NGAY"]))
                            {
                                if (int.Parse(r["HINH_THUC"].ToString()) == 0 || int.Parse(r["HINH_THUC"].ToString()) == 1)
                                {
                                    HL += Cong(dr[col].ToString(), dr[colNext].ToString());
                                    HL += Tru(dr[col].ToString(), dr[colNext].ToString());
                                }
                                else if (int.Parse(r["HINH_THUC"].ToString()) == 2)
                                {
                                    KL += Cong(dr[col].ToString(), dr[colNext].ToString());
                                    KL += Tru(dr[col].ToString(), dr[colNext].ToString());
                                }
                                else
                                {
                                    TC += Cong(dr[col].ToString(), dr[colNext].ToString());
                                    TC += Tru(dr[col].ToString(), dr[colNext].ToString());
                                }
                                break;
                            }
                        }
                    }
                    colNext += 2;
                    cnNgay++;
                }
                dr["KL"] = KL / 8;
                dr["HL"] = HL / 8;
                dr["TC"] = TC / 8;              
            }
            catch (Exception ex)
            {
                HelpMsgBox.ShowErrorMessage(ex.Message);
            }            
        }
        public decimal Tru(string a, string b)
        {
            decimal Kq = 0;
            if (a == "V")
                Kq -= 4; //-8 chuyển thành -4
            if (b == "V")
                Kq -= 4;
            return Kq;
        }
        private bool Vang(string str)
        {
            if (str == "V")
                return true;
            return false;
        }
        private decimal Cong(string a,string b)
        {
            decimal Kq = 0;
            if (IsNumber(a))
                Kq += decimal.Parse(a);
            if (IsNumber(b))
                Kq += decimal.Parse(b);
                    
            return Kq;
        }
        public DataRow CanDuoiNgay(DateTime Ngay,long NV_ID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand("select TU_NGAY,HINH_THUC from DIEU_CHINH_LUONG where NV_ID = @NV_ID and TU_NGAY < @NGAY order by TU_NGAY desc");
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, Ngay);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "DIEU_CHINH_LUONG");
            if(ds.Tables[0].Rows.Count>0)
                return ds.Tables[0].Rows[0];
            return null;
            
        }
        public bool SoSanhNgay(DateTime NgayTruoc, DateTime NgaySau)
        {
            if (NgayTruoc >= NgaySau)
                return true;
            return false;
        }
        #endregion

        #endregion

        #region 9.Xu ly hien thi thu bang tieng viet
        readonly String[] ThuVN = new String[] { "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy", "Chủ nhật" };
        readonly String[] ThuEN = new String[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        public string ThuTiengViet(string EN)
        {
            for (int i = 0; i < ThuVN.Length; i++)
            {
                if (EN == ThuEN[i])
                    return ThuVN[i];
            }
            return ThuVN[0];
        }
        #endregion

        #region 10.Xu ly sap ngay
        public void SortDateTime(ref DateTime[]Ngay)
        {
            ArrayList a = new ArrayList();
            for (int i = 0; i < Ngay.Length; i++)
            {
                a.Add(Ngay[i]);
            }
            a.Sort();
            ChonNgay = new DateTime[a.Count];
            a.CopyTo(Ngay, 0);
        }
        #endregion

        #region 11.Xem chi tiết làm việc
        public void XemChiTietLamViec(bool Xem)
        {
            string[] name = new String[] {"KL","TC","HL" };
            for (int i = 0; i < name.Length; i++)
            {
                gridViewDetails.Bands[name[i]].Visible = Xem;
            }
        }
                
        #endregion

        #region -->Su kien
        private void XemBangChamCong()
        {
            try
            {
                barButtonItemAdd.Enabled = false;
                SoNgayChon = dateNav.Selection.Count;
                ChonNgay = new DateTime[SoNgayChon];
                int i = 0;
                foreach (DateTime item in dateNav.Selection)
                {
                    ChonNgay[i] = item;
                    i++;
                }
                SortDateTime(ref ChonNgay);
                //FrameworkParams.wait = new WaitingMsg();
                LoadData();
                this.XemChiTietLamViec(XemChiTietHuongLuong.Checked);
                this.gridViewDetails.Focus();
                ConditionsAdjustment(null);
                
            }
            finally
            {
                //if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }
        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrameworkParams.wait = new WaitingMsg();
                if (CapNhat())
                {
                    barButtonItemAdd.Enabled = false;
                }
                else
                    HelpMsgBox.ShowNotificationMessage("Lưu không thành công");
            }
            finally
            {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }

            
        }

        private void barButtonItemThemNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrameworkParams.wait = new WaitingMsg();
                ThemNhanVien();
            }
            finally
            {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
            
        }

        private void gridViewDetails_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            if (e.RowHandle >= 0)
            {
                CapNhatThongKeDong(e.RowHandle);
                DuyetThongKe_TC_HL_KL(e.RowHandle);
                
            }
            barButtonItemAdd.Enabled = true;
        }

        private void gridViewDetails_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            CapNhatThongKeDong(e.RowHandle);
            DuyetThongKe_TC_HL_KL(e.RowHandle);
        }

        #endregion

        #region 12.Tạo footer (Cập nhật ngày 11/08/2008 bởi CHAUTV)
        private void ShowFooter()
        {
            gridViewDetails.OptionsView.ShowFooter = true;
            string[] CotPhuField = new String[] { "N", "V", "SO", "KL", "TC", "HL"};
            for (int i = 0; i < CotPhuField.Length; i++)
            {
                gridViewDetails.Columns[CotPhuField[i]].SummaryItem.DisplayFormat = "{0}";
                gridViewDetails.Columns[CotPhuField[i]].SummaryItem.FieldName = CotPhuField[i];
                gridViewDetails.Columns[CotPhuField[i]].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;    
            }
        }
        #endregion

        #region 13.Xu ly chot (Cap nhat thang 09/2008)
        private bool? DaChot = null;
        private List<DateTime> AllNgayChot()
        {
            List<DateTime> Kq = new List<DateTime>();
            DatabaseFB db = HelpDB.getDatabase();
            string sql = "select NGAY from BANG_CHAM_CONG_CHOT";
            DbCommand cmd = db.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            foreach (DataRow  dr in ds.Tables[0].Rows)
            {
                Kq.Add((DateTime)dr["NGAY"]);
            }
            return Kq;
        }
        List<string> DanhSachCotDaChot = new List<string>();
        private List<string> getDanhSachCotChot()
        {
            List<string> Kq = new List<string>();
            List<DateTime>_AllNgayChot = AllNgayChot();
            for (int i = 0; i < ChonNgay.Length; i++)
            {
                if(_AllNgayChot.Contains(ChonNgay[i]))
                {
                    Kq.Add("S" + i.ToString());
                    Kq.Add("C" + i.ToString());
                }
            }
            
            return Kq;
        }
        private void ConditionsAdjustment(bool?status)
        {
            DanhSachCotDaChot = getDanhSachCotChot();
            if (DanhSachCotDaChot.Count > 0) DaChot = true;
            else DaChot = false;
            gridViewDetails.CustomDrawCell += delegate(object sender, RowCellCustomDrawEventArgs e)
            {
                if (e.RowHandle == gridViewDetails.FocusedRowHandle) return;

                if (DanhSachCotDaChot.Contains(e.Column.FieldName))
                {
                    if(status == true || status==null)
                        e.Appearance.BackColor = Color.YellowGreen;
                    else
                        e.Appearance.BackColor = Color.White;
                }
            };
            gridViewDetails.ShowingEditor += delegate(object sender1, CancelEventArgs e1)
            {
                if (DanhSachCotDaChot.Contains(gridViewDetails.FocusedColumn.FieldName))
                {
                    e1.Cancel = true;
                }
            };
        }
        private void barButtonItem_Chot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrameworkParams.wait = new WaitingMsg();
                if (barButtonItemAdd.Enabled == true) CapNhat();
                DAChot.Instance.ChotBangChamCong(ChonNgay, "BANG_CHAM_CONG_CHOT", "GEN_BANG_CHAM_CONG_CHOT_ID");
                ConditionsAdjustment(true);
                this.Refresh();
                XemBangChamCong();
                this.DaChot = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }
        private void barButtonItem_KhongChot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrameworkParams.wait = new WaitingMsg();
                if (barButtonItemAdd.Enabled == true) CapNhat();
                DAChot.Instance.MoChotBangChamCong(ChonNgay, "BANG_CHAM_CONG_CHOT");
                ConditionsAdjustment(false);
                this.Refresh();
                XemBangChamCong();
                this.DaChot = false;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { if (FrameworkParams.wait != null) FrameworkParams.wait.Finish(); }
            
        }
        #endregion

        private void barSubItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DaChot==true)
            {
                barButtonItem_Chot.Enabled = false;
                barButtonItem_KhongChot.Enabled = true;
            }
            else
            {
                barButtonItem_Chot.Enabled = true;
                barButtonItem_KhongChot.Enabled = false;
            }
        }

        private void gridViewDetails_RowCountChanged(object sender, EventArgs e)
        {
            if (gridViewDetails.RowCount <= 0)
            {
                barButtonItem_Chot.Enabled = false;
                barButtonItem_KhongChot.Enabled = false;
            }
        }

        private void barCheckItemFilter_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.barCheckItemFilter.Checked)
            {
                this.popupControlContainerFilter.Show();
            }
            else
            {
                this.popupControlContainerFilter.Hide();
            }

        }

        private void barButtonItemTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                FrameworkParams.wait = new WaitingMsg();
                XemBangChamCong();
            }
            catch (Exception ex){}
            finally {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
            
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            popupContainerEdit1.ClosePopup();
        }

        #region chauvt : Ghi chú 
        /*
         * 0.Hiện tại chương trình chạy rất chậm 
         * 1.Cần tìm phương án tối ưu hơn trong việc truy xuất dữ liệu và lúc lưu
         * 2.Có thể sẽ thay lại bằng PhieuQuanLyChangeXN để xử lý đồng nhất hơn
        */
        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            DMNhanVienX.I.Load_NV_LV(PLNhanVien);
            return null;
        }

        #endregion
    }
}
