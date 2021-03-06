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
using ProtocolVN.App.Office;
using DevExpress.XtraGrid.Views.Grid;
using System.Text;
using ProtocolVN.Plugin.TimeSheet;
using DevExpress.XtraBars;

namespace office
{
    public partial class frmChamCongAutoQL : XtraFormPL ,IFormRefresh
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
            return MenuBuilder.CreateItem(typeof(frmChamCongAutoQL).FullName,
                "Bảng chấm công",
                ParentID, true,
                typeof(frmChamCongAutoQL).FullName,
                true, IsSep, "", true, "", "");
        }
        public frmChamCongAutoQL()
        {
            InitializeComponent();
            HelpGrid.ShowNumOfRecord(gridControlDetails);
            ConditionsAdjustment(null);
            this.Text = "Bảng chấm công";
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            ShowImageMenu();
            ChonNgay = new DateTime[] {DateTime.Now};
            this.barCheckItemFilter.Glyph = FWImageDic.FILTER_IMAGE20;
            ngayLamViec.Default = ProtocolVN.Framework.Win.Trial.SelectionTypes.FromDateToDate;
            //DMNhanVienX.I.InitCtrl(PLMulNhanVien,true,true);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            PLTimeSheetUtil.PermissionForControl(NhanVien, barButtonItem_Chot.Visibility == BarItemVisibility.Always, NhanVien.Visible == true);
            XemBangChamCong(true);
            popupControlContainerFilter.Visible = true;
            this.barButtonItemAdd.Glyph = FWImageDic.SAVE_ALL_IMAGE16;
            HelpGrid.SetTitle((GridView)this.gridViewDetails, "BẢNG CHẤM CÔNG");
            HelpControl.RedCheckEdit(XemChiTietHuongLuong, false);
            barButtonItem_Chot.Glyph = FWImageDic.CHOICE_IMAGE20;
            barButtonItem_Chot.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            
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
        }
        #endregion

        #region 2.Ham dung bang (Tạo bảng động theo số ngày chọn)
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
            BThu[0].Caption = "Nhân viên";
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
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa dữ liệu đang chọn không ?") == DialogResult.Yes)
            {
                DataRow dr = gridViewDetails.GetDataRow(gridViewDetails.FocusedRowHandle);
                for (int i = 0; i < ChonNgay.Length; i++)
                {
                    DOChamCongAuto phieu = DAChamCongAuto.Instance.LoadAll(HelpNumber.ParseInt64(dr["NV_ID"]), ChonNgay[i]);
                    if(phieu!=null && phieu.ID>0)
                        DAChamCongAuto.Instance.Delete(phieu.ID);
                }
                gridViewDetails.DeleteRow(gridViewDetails.FocusedRowHandle);
                ((DataTable)gridControlDetails.DataSource).AcceptChanges();
                barButtonItemAdd.Enabled = true;
            }
        }
        #endregion

        #region 4.Lay danh sach ID nhan vien
        public DataTable GetNhanVien(long IDs) {
            QueryBuilder query = new QueryBuilder(@"SELECT NV_ID FROM BANG_CHAM_CONG_AUTO WHERE 1=1");
            query.addGroupBy("NV_ID");
            query.addID("NV_ID", IDs);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            return ds.Tables[0];
        }

        public DataTable GetNV_ID(long id)
        {
            DatabaseFB fb = HelpDB.getDatabase();
            string sql = "";
            if (id == -1)
                sql = "select NV_ID from BANG_CHAM_CONG_AUTO group by NV_ID";
            else
                sql = "select NV_ID from BANG_CHAM_CONG_AUTO where NV_ID = " + id.ToString() + " group by NV_ID";
            DbCommand cmd = fb.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            fb.LoadDataSet(cmd, ds, "BANG_CHAM_CONG_AUTO");
            return ds.Tables[0];
        }
        #endregion

        #region 5.Truyen du lieu
        public void LoadData(params object[] isLoadForm)
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
            if (isLoadForm.Length > 0) {
                this.CreateGridViewDetail(fields, new String[] { "", "" }, ChonNgay);
                gridControlDetails.DataSource = Kq;
                goto _Label;
            }
            //DataTable Nv = GetNV_ID(PLNhanVien._getSelectedID());
            DataTable Nv = GetNhanVien(this.NhanVien._getSelectedID());
            #endregion

            #region 5.3.Đưa dữ liệu vào bảng 
            FWDBService fb = HelpDB.getDBService();
            QueryBuilder sql = new QueryBuilder(@"SELECT BCC.NV_ID,BCC.NGAY,BCC.SANG,BCC.CHIEU,NV.NAME 
                            FROM BANG_CHAM_CONG_AUTO BCC INNER JOIN DM_NHAN_VIEN NV ON NV.ID = BCC.NV_ID 
                            WHERE 1=1");
            sql.addDateFromTo("NGAY", ngayLamViec.FromDate, ngayLamViec.ToDate);
            sql.setAscOrderBy("NGAY");
            DataSet bangChamCongThang = new DataSet();
            fb.LoadDataSet(bangChamCongThang, sql, "BANG_CHAM_CONG_AUTO");
            if (bangChamCongThang != null && bangChamCongThang.Tables.Count > 0 && bangChamCongThang.Tables[0].Rows.Count > 0)
            {
                for (int row = 0; row < Nv.Rows.Count; row++)
                {
                    Application.DoEvents();
                    #region 5.3.1.Lấy dữ liệu của nhân viên row và sắp tăng theo ngày
                    FWDBService fbNhanVien = HelpDB.getDBService();
                    sql = new QueryBuilder(@"SELECT BCC.NV_ID,BCC.NGAY,BCC.SANG,BCC.CHIEU,NV.NAME 
                            FROM BANG_CHAM_CONG_AUTO BCC INNER JOIN DM_NHAN_VIEN NV ON NV.ID = BCC.NV_ID 
                            WHERE 1=1");
                    sql.addDateFromTo("NGAY", ngayLamViec.FromDate, ngayLamViec.ToDate);
                    sql.setAscOrderBy("NGAY");
                    sql.addID("NV_ID", long.Parse(Nv.Rows[row]["NV_ID"].ToString()));
                    DataSet ds = new DataSet();
                    fbNhanVien.LoadDataSet(ds, sql, "BANG_CHAM_CONG_AUTO");
                    #endregion
                    #region 5.3.2.Đưa dữ liệu lên bảng Kq

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int sc = 0;
                        DataRow dr = Kq.NewRow();
                        for (int col = 0; col < ChonNgay.Length; col++)
                        {
                            dr["NV_ID"] = long.Parse(ds.Tables[0].Rows[0]["NV_ID"].ToString());
                            dr["NAME"] = ds.Tables[0].Rows[0]["NAME"].ToString();
                            string sang = "";
                            string chieu = "";
                            foreach (DataRow r in ds.Tables[0].Rows)
                            {
                                if (NgayBangNgay((DateTime)r["NGAY"], ChonNgay[col]))
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
            }
            #endregion

            #region 5.4.Tạo lưới và hiển thị dữ liệu lên lưới
            this.CreateGridViewDetail(fields, new String[] { "", "" }, ChonNgay);

            gridControlDetails.DataSource = Kq;
            #endregion

            CapNhatThongKe();
            if (Kq == null || Kq.Rows.Count == 0)
            {
                this.barButtonItem_Chot.Enabled = false;
            }
            ShowFooter();
        _Label: ;
        }
        #endregion

        #region 6.Lưu dữ liệu 
        private bool UpdateChamCong() {
            bool bFlag = true;
            DataSet forDB = HelpDB.getDatabase().LoadDataSet(
                            @"SELECT * FROM " + DAChamCongAuto.TABLE_MAP + " WHERE 1=1", 
                            DAChamCongAuto.TABLE_MAP);
            try
            {
                DataTable tb = (DataTable)gridControlDetails.DataSource;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    int sc = 0;
                    for (int j = 0; j < ChonNgay.Length; j++)
                    {
                        DOChamCongAuto dto = DAChamCongAuto.Instance.LoadAll(HelpNumber.ParseInt64(tb.Rows[i]["NV_ID"]), ChonNgay[j]);
                        dto.NV_ID = HelpNumber.ParseInt64(tb.Rows[i]["NV_ID"]);
                        dto.NGAY = ChonNgay[j];
                        dto.SANG = (tb.Rows[i][sc]!=null)?  tb.Rows[i][sc].ToString() : "";
                        sc++;
                        dto.CHIEU = (tb.Rows[i][sc]!=null)?tb.Rows[i][sc].ToString() :"";
                        sc++;
                        if(dto.ID>0  || (dto.SANG!="" || dto.CHIEU!=""))
                            bFlag = DAChamCongAuto.Instance.MergeDataSet(forDB, dto);
                        if (bFlag == false) return bFlag;
                    }
                }
                if (bFlag){
                    bFlag = DABase.getDatabase().UpdateDataSet(forDB);
                }
            }
            catch (Exception ex)
            {
                bFlag = false;
                HelpMsgBox.ShowErrorMessage(ex.Message);
            }
            return bFlag;
        }
        #endregion

        #region 7.Ham bo sung nhan vien vao danh sách còn thiếu
        public DataTable LocNhanVien()
        {
            int i = 0;
            string sql = "select ID from DM_NHAN_VIEN nv where VISIBLE_BIT = 'Y'";
            StringBuilder dsID = new StringBuilder("(");
            DataTable ds_NV_ID = (DataTable)gridControlDetails.DataSource;
            if (ds_NV_ID.Rows.Count > 0)
            {
                for (i = 0; i < ds_NV_ID.Rows.Count; i++)
                {
                    dsID.Append(ds_NV_ID.Rows[i]["NV_ID"].ToString());
                    dsID.Append(",");
                }
                dsID = dsID.Remove(dsID.Length - 1, 1);
                dsID.Append(")");
                sql += " and nv.ID not in " + dsID.ToString() + " order by nv.NAME ";
            }
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand select = db.GetSQLStringCommand(sql);
            DataSet ds_BoSung = new DataSet();
            db.LoadDataSet(select, ds_BoSung, "TABLE");
            return ds_BoSung.Tables[0];
        }
        public bool? ThemNhanVien()
        {
            try
            {
                DateTime[] selectedDate = GetSelectedDate(ngayLamViec.FromDate, ngayLamViec.ToDate);
                SoNgayChon = selectedDate.Length;
                if (SoNgayChon > 31){
                    HelpMsgBox.ShowNotificationMessage("Số ngày chọn không được vượt quá 31 ngày!");
                    return false;
                }
                else
                {
                    DataTable Kq = ((DataTable)gridControlDetails.DataSource);
                    DataTable NVBoSung = this.LocNhanVien();
                    if (NVBoSung == null || NVBoSung.Rows.Count == 0)
                        return null;
                    if (NVBoSung.Rows.Count > 0)
                    {
                        for (int i = 0; i < NVBoSung.Rows.Count; i++)
                        {
                            Application.DoEvents();
                            for (int j = 0; j < SoNgayChon; j++)
                            {
                                DOChamCongAuto phieu = DAChamCongAuto.Instance.LoadAll(HelpNumber.ParseInt64(NVBoSung.Rows[i]["ID"]), ChonNgay[j]);
                                phieu.NV_ID = HelpNumber.ParseInt64(NVBoSung.Rows[i]["ID"]);
                                phieu.NGAY = ChonNgay[j];
                                if (phieu.ID == 0)
                                {
                                    phieu.SANG = "";
                                    phieu.CHIEU = "";
                                }
                                if (DAChamCongAuto.Instance.Update(phieu) == false) return false;
                            }
                        }
                        barButtonItemAdd.Enabled = true;
                        CapNhatThongKe();
                    }
                    return true;
                }
            }
            catch { return false; }
        }
        #endregion

        #region 8.Cập nhật dữ liệu hàng thống kê
        public bool IsNumber(string str)
        {
            bool bFlag = true;
            try
            {
                decimal value =Decimal.Parse(str);
            }
            catch (Exception ex)
            {
                bFlag = false;
            }
            return bFlag;
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
            //Thực hiện làm tròn 4 chữ số
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
        /// <summary>
        /// Xu ly tinh toan lien quan den dieu chinh luong
        /// </summary>
        /// <param name="row"></param>
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
                //Thực hiện làm tròn 4 chữ số
                dr["KL"] = HelpNumber.RoundDecimal(KL / 8,4);
                dr["HL"] = HelpNumber.RoundDecimal(HL / 8,4);
                dr["TC"] = HelpNumber.RoundDecimal(TC / 8,4);
              
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
        private void XemBangChamCong(params object[] isLoadForm)
        {
            try
            {
                barButtonItemAdd.Enabled = false;
                DateTime[] selectedDate = GetSelectedDate(ngayLamViec.FromDate, ngayLamViec.ToDate);
                SoNgayChon = selectedDate.Length;
                if (SoNgayChon > 31)
                    HelpMsgBox.ShowNotificationMessage("Số ngày chọn không được vượt quá 31 ngày!");
                else
                {
                    ChonNgay = new DateTime[SoNgayChon];
                    int i = 0;
                    foreach (DateTime item in selectedDate)
                    {
                        ChonNgay[i] = item;
                        i++;
                    }
                    //SortDateTime(ref ChonNgay);
                    LoadData(isLoadForm);
                    this.XemChiTietLamViec(XemChiTietHuongLuong.Checked);
                    this.gridViewDetails.Focus();
                    ConditionsAdjustment(null);
                }
            }
            catch{}
        }
        private void barButtonItemAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Application.DoEvents();
                FrameworkParams.wait = new WaitingMsg();
                if (UpdateChamCong())
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
                Application.DoEvents();
                FrameworkParams.wait = new WaitingMsg();
                if(ThemNhanVien()==true)
                    XemBangChamCong();
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
            string sql = "select NGAY from BANG_CHAM_CONG_AUTO_CHOT";
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

            //Nếu số lượng ngày chốt bằng đúng số ngày đã mở thì Chốt = true
            if (DanhSachCotDaChot.Count == 2 * ChonNgay.Length)
            {
                DaChot = true;
                barButtonItem_Chot.Enabled = false;
            }
            else { 
                DaChot = false;
                barButtonItem_Chot.Enabled = true;
            }
            if (this.gridControlDetails.DataSource == null || this.gridViewDetails.RowCount <= 0) {
                barButtonItem_Chot.Enabled = false;
            }

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
                if (string.Compare(barButtonItem_Chot.Caption, "Chốt") == 0)
                {
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc chốt bảng chấm công đang xem không?") == DialogResult.Yes)
                    {
                        Application.DoEvents();
                        FrameworkParams.wait = new WaitingMsg();
                        if (barButtonItemAdd.Enabled == true) UpdateChamCong();
                        DAChot.Instance.ChotBangChamCong(ChonNgay, DAChamCongAutoChot.TABLE_MAP, PLConst.G_NGHIEP_VU);
                        DAChamCongAutoChot.Instance.Duyet(ChonNgay);
                        ConditionsAdjustment(true);
                        this.Refresh();
                        XemBangChamCong();
                        this.DaChot = true;
                        if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                        HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                        barButtonItem_Chot.Enabled = true;
                        barButtonItem_Chot.Caption = "Không chốt";
                        barButtonItem_Chot.Glyph = FWImageDic.NO_CHOICE_IMAGE20;
                    }
                }
                else {
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc không chốt bảng chấm công đang xem không?") == DialogResult.Yes)
                    {
                        Application.DoEvents();
                        FrameworkParams.wait = new WaitingMsg();
                        if (barButtonItemAdd.Enabled == true) UpdateChamCong();
                        DAChot.Instance.MoChotBangChamCong(ChonNgay, DAChamCongAutoChot.TABLE_MAP);
                        ConditionsAdjustment(false);
                        this.Refresh();
                        XemBangChamCong();
                        this.DaChot = false;
                        if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                        HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                        barButtonItem_Chot.Enabled = true;
                        barButtonItem_Chot.Caption = "Chốt";
                        barButtonItem_Chot.Glyph = FWImageDic.CHOICE_IMAGE20;
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }
        private void barButtonItem_KhongChot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }
        #endregion


        private void gridViewDetails_RowCountChanged(object sender, EventArgs e)
        {
            if (gridViewDetails.RowCount <= 0)
            {
                barButtonItem_Chot.Enabled = false;
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
                Application.DoEvents();
                FrameworkParams.wait = new WaitingMsg();
                XemBangChamCong();
            }
            catch (Exception ex)
            {

            }
            finally {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
            
        }

        

        /// <summary>
        ///CHAUTV : Phân quyền xem dữ liệu
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="featureName"></param>
        private void ApplyPermissionData(PLDMTreeGroup Input, string featureName)
        {
            List<Feature> features = Permission.loadAllFeatureByUser(FrameworkParams.currentUser.username);
            bool IsFull = false;
            foreach (Feature f in features)
            {
                if ((f.featureName == featureName && f.isRead == true)|| FrameworkParams.currentUser.username.Equals("admin"))
                {
                    IsFull = true;
                    break;
                }
            }
            if (FrameworkParams.isPermision.getPublicForm().Contains(typeof(frmChamCongAutoQL).FullName)==false &&!IsFull)
            {
                Input._setSelectedID(FrameworkParams.currentUser.employee_id);
                Input.Enabled = false;
            }
        }

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            //DMNhanVienX.I.InitCtrl(PLMulNhanVien, true, true);
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            return null;
        }

        #endregion

        private DateTime[] GetSelectedDate(DateTime from, DateTime to) {
            List<DateTime> selectedDate = new List<DateTime>();
            do
            {
                selectedDate.Add(from);
                from = from.AddDays(1);
            } while (from <= to);
            return selectedDate.ToArray();
        }
    }
}
