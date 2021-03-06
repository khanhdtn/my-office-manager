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
using System.Drawing.Printing;
using System.Text;
using ProtocolVN.Plugin.TimeSheet;
using System.IO;
using System.Reflection;

namespace office
{
    public partial class frmHoTroInAnQL : PhieuQuanLyChange1N, IFormRefresh
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //public partial class frmHoTroInAnQL : XtraFormPL
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
        //    public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //    public DevExpress.XtraGrid.GridControl gridControlMaster;
        //    public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.FIX;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmHoTroInAnQL).FullName,
                "Hỗ trợ in ấn",
                ParentID, true,
                typeof(frmHoTroInAnQL).FullName,
                true, IsSep, "mnbToChuc.png", true, "", "");
        }
        private PhieuQuanLyFix1N Fix;
        private System.IO.StreamReader read;
        #endregion

        #region Hàm khởi tạo
        public frmHoTroInAnQL()
        {
            InitializeComponent();
            IDField = "ID";
            DisplayField = "MUC_DICH";
            this._UsingExportToFileItem = false;
            Fix = new PhieuQuanLyFix1N(this, this.UpdateRow());
            toolTip1.BackColor = Color.LightYellow;
        }
        private void frmHoTroInAnQL_Load(object sender, EventArgs e)
        {
            barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        #endregion

        #region Step 1 : Xác định các cột sẽ hiển thị trong gridView
        public override void InitColumnMaster()
        {
            DataSet ds_nv = HelpDB.getDatabase().LoadDataSet("Select * from DM_NHAN_VIEN");
            XtraGridSupportExt.ComboboxGridColumn(colNguoi_gui, ds_nv.Tables[0], "ID", "NAME", "NGUOI_GUI_ID");
            HelpGridColumn.CotReadOnlyDate(colThoi_gian, "THOI_GIAN_CAP_NHAT", PLConst.FORMAT_DATETIME_STRING);
            XtraGridSupportExt.ComboboxGridColumn(colNguoi_nhan, ds_nv.Tables[0], "ID", "NAME", "NGUOI_NHAN_ID");
            XtraGridSupportExt.ComboboxGridColumn(colT_trang, DMCTinhTrangInAn.I(), "ID", "NAME", "TINH_TRANG_IN_ID");
            HelpGridColumn.CotTextLeft(colMuc_dich, "MUC_DICH");
            XtraGridSupportExt.ComboboxGridColumn(colMuc_UT, HelpDB.getDatabase().LoadDataSet("SELECT * FROM DM_MUC_DO_UU_TIEN").Tables[0], "ID", "NAME", "MUC_DO_UU_TIEN_ID");
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewMaster.OptionsView.ShowGroupedColumns = false;
        }
        #endregion

        #region Step 2 : Xác định các cột sẽ hiển thị trong phần detail
        public override void InitColumDetail()
        {
            PMSupport.SetTitle(this, Status);
            HelpXtraForm.SetFix(this);
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            toolTip1.BackColor = Color.LightYellow;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            HelpGridColumn.CotMemoExEdit(lvYeuCau, "YEU_CAU");
            XtraGridSupportExt.DecimalGridColumn(lvSoBan, "SO_TO", 0);
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            XtraGridSupportExt.TextLeftColumn(lvIn, "in_file");
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            lvSoBan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        }
        #endregion

        #region Step 3 : Xác định các control trong filter part và Khởi tạo control trong phần filter.
        public override void PLLoadFilterPart()
        {
            this._RefreshAction(null);
            PLTimeSheetUtil.PermissionForControl(cboNguoi_gui
               , barSubItem1.Visibility == DevExpress.XtraBars.BarItemVisibility.Always
               , cboNguoi_gui.Visible == true);
            cboNguoi_nhan.Enabled = cboNguoi_gui.Enabled;
        }
        #endregion

        #region Step 4 : Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            _MenuItem menu = new _MenuItem(
               new string[] { "Đã in", "Không in" },
               new string[] { "fwDuyet.png", "fwKhongDuyet.png" },
               "ID",
               new DelegationLib.CallFunction_MulIn_NoOut[]{    
                   ThayDoi_TT_DaIn,ThayDoi_TT_KhongIn
               }
               );
            return menu;
        }
        private void ThayDoi_TT_KhongIn(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn thay đổi tình trạng của dữ liệu đang chọn không?") == DialogResult.Yes)
                {
                    int[] Selected_row = gridViewMaster.GetSelectedRows();
                    foreach (int i in Selected_row)
                    {
                        DataRow row = gridViewMaster.GetDataRow(i);
                        if (HelpNumber.ParseInt64(row["TINH_TRANG_IN_ID"]) != 3)
                        {
                            DAHoTroInAn.CapNhatTinhTrangIn(HelpNumber.ParseInt64(row["ID"]), 4);
                            row["TINH_TRANG_IN_ID"] = 4;
                        }
                    }
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                    HookFocusRow();
                }
            }
        }
        private void ThayDoi_TT_DaIn(List<object> ids)
        {
            if (ids != null && ids.Count > 0)
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn thay đổi tình trạng của dữ liệu đang chọn không?") == DialogResult.Yes)
                {
                    int[] Selected_row = gridViewMaster.GetSelectedRows();
                    foreach (int i in Selected_row)
                    {
                        DataRow row = gridViewMaster.GetDataRow(i);
                        if (HelpNumber.ParseInt64(row["TINH_TRANG_IN_ID"]) != 3)
                        {
                            DAHoTroInAn.CapNhatTinhTrangIn(HelpNumber.ParseInt64(row["ID"]), 3);
                            row["TINH_TRANG_IN_ID"] = 3;
                        }
                    }
                    HelpMsgBox.ShowNotificationMessage("Đã thực hiện thành công.");
                    HookFocusRow();
                }
            }
        }
        public void frm_refeshtt()
        {
            Fix.PLRefresh();
        }
        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        #region Step 5 : Xây dựng Query Buider cho việc tìm kiếm

        public override QueryBuilder PLBuildQueryFilter()
        {
            FWWaitingMsg wait = new FWWaitingMsg();
            QueryBuilder query = new QueryBuilder(UpdateRow());
            try
            {
                StringBuilder cond = new StringBuilder("");
                if (cboNguoi_gui._getSelectedID() != -1) cond.Append(string.Format("NGUOI_GUI_ID = {0}", cboNguoi_gui._getSelectedID()));
                long[] arrNguoiNhan = cboNguoi_nhan._SelectedIDs;
                if (arrNguoiNhan.Length > 0 && cond.Length > 0) cond.Append(" OR ");
                int temp = arrNguoiNhan.Length;
                foreach (long id in arrNguoiNhan)
                {
                    cond.Append(string.Format(@"(NGUOI_NHAN_ID LIKE '{0}%') 
                        OR (NGUOI_NHAN_ID LIKE '%,{0},%') OR (NGUOI_NHAN_ID LIKE '%,{0}')", id));
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

                query.addDateFromTo("THOI_GIAN_CAP_NHAT", ngayKT.FromDate, ngayKT.ToDate);
                query.addID("MUC_DO_UU_TIEN_ID", cboMuc_uu_tien._getSelectedID());
                query.addID("TINH_TRANG_IN_ID", PLImgTinhTrang._getSelectedID());
                query.addCondition(" 1=1 ");
                DataSet Master_ds = HelpDB.getDatabase().LoadDataSet(query);
                gridControlMaster.DataSource = Master_ds.Tables[0];
                if (splitContainerControl1.SplitterPosition == 308)
                    splitContainerControl1.SplitterPosition = 257;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            wait.Finish();
            return null;
        }
        #endregion

        #region Step 7 : Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            frmYeuCauInAn frm = new frmYeuCauInAn(id, null);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        public override void ShowUpdateForm(long id)
        {
            frmYeuCauInAn frm = new frmYeuCauInAn(id, false);
            frm.RefreshFrbug += new frmYeuCauInAn.RefreshFrm(frm_RefreshFrbug);
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        void frm_RefreshFrbug(DOHoTroInAn doHoTroIn)
        {
            DataRow dr = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            dr["NGUOI_GUI_ID"] = doHoTroIn.NGUOI_GUI_ID;
            dr["NGUOI_NHAN_ID"] = doHoTroIn.NGUOI_NHAN_ID;
            dr["THOI_GIAN_CAP_NHAT"] = doHoTroIn.THOI_GIAN_CAP_NHAT;
            dr["TINH_TRANG_IN_ID"] = doHoTroIn.TINH_TRANG_IN_ID;
            dr["MUC_DICH"] = doHoTroIn.MUC_DICH;
            dr["MUC_DO_UU_TIEN_ID"] = doHoTroIn.MUC_DO_UU_TIEN_ID;
        }

        public override long[] ShowAddForm()
        {
            frmYeuCauInAn frm = new frmYeuCauInAn();
            HelpProtocolForm.ShowModalDialog(this, frm);
            return null;
        }

        #endregion

        #region Step 8 : Xác định các hành động trên form

        public override bool XoaAction(long id)
        {
            try
            {
                int[] Selected_row = gridViewMaster.GetSelectedRows();
                DataRow[] row = new DataRow[Selected_row.Length];
                int j = 0;
                foreach (int i in Selected_row)
                {
                    row[j] = gridViewMaster.GetDataRow(i);
                    j++;
                }
                foreach (DataRow dr in row)
                {
                    if (HelpNumber.ParseInt64(dr["ID"]) == id && dr["TINH_TRANG_IN_ID"].ToString() == DMCTinhTrangInAn.Instance.DA_IN.ToString())
                    {
                        HelpMsgBox.ShowNotificationMessage("Yêu cầu này đã được in,không cho phép xóa!");
                        return false;
                    }
                }
                DAHoTroInAn.RemoveAllFilesPrint(id);
                return FWDBService.DeleteRecord("HO_TRO_IN_AN", "ID", id);
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
        #endregion

        #region Step 9 : HookFocusRow & lấy dữ liệu
        public override void HookFocusRow()
        {
            DataRow row = gridViewMaster.GetDataRow(gridViewMaster.FocusedRowHandle);
            if (row != null)
            {
                if (HelpNumber.ParseInt64(row["TINH_TRANG_IN_ID"]) == DMCTinhTrangInAn.Instance.DA_IN)
                {
                    barSubItem1.Enabled = false;
                    barButtonItemUpdate.Enabled = false;
                    barButtonItemDelete.Enabled = false;
                }
                else
                {
                    barSubItem1.Enabled = true;
                    barButtonItemUpdate.Enabled = true;
                    barButtonItemDelete.Enabled = true;
                }
            }
        }
        public override DataTable[] PLLoadDataDetailParts(long MasterID)
        {
            DataSet ds;
            try
            {
                ds = HelpDB.getDatabase().LoadDataSet(@"select lttt.*,(SELECT NAME FROM DM_NHAN_VIEN WHERE ID = lttt.NGUOI_CAP_NHAT) TEN_NGUOI_CN
                                ,tt.SO_TO,tt.YEU_CAU from LUU_TRU_TAP_TIN lttt inner join TAP_TIN_IN_AN tt on lttt.ID=tt.TAP_TIN_ID
                where lttt.ID in(select TAP_TIN_ID from TAP_TIN_IN_AN where HO_TRO_IN_AN_ID=" + MasterID + ")");
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return null;
            }
            ds.Tables[0].Columns.Add("mo_file", typeof(Image));
            ds.Tables[0].Columns.Add("luu_file", typeof(Image));
            ds.Tables[0].Columns.Add("in_file", typeof(Image));
            ds.Tables[0].Columns.Add("SIZE", typeof(Decimal));
            HelpGridColumn.CotCalcEditDec(lvSize, "SIZE", 3, true);
            lvSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                r["mo_file"] = FWImageDic.VIEW_IMAGE20;
                r["luu_file"] = FWImageDic.SAVE_IMAGE20;
                r["in_file"] = FWImageDic.PRINT_IMAGE20;
                byte[] a = r["NOI_DUNG"] as byte[];
                if (a != null)
                {
                    r["SIZE"] = HelpNumber.ParseDecimal(a.Length) / 1024;
                }
            }
            return new DataTable[] { ds.Tables[0] };
        }
        #endregion

        #region Step 10 : UpdateRow
        public override string UpdateRow()
        {
            return @"SELECT ID,NGUOI_GUI_ID,NGUOI_NHAN_ID,               
                            ht.THOI_GIAN_CAP_NHAT,
                            substring(ht.muc_dich from POSITION('*' IN ht.MUC_DICH) + 1 ) MUC_DICH,
                            ht.MUC_DO_UU_TIEN_ID,
                            ht.TINH_TRANG_IN_ID
                            FROM  HO_TRO_IN_AN ht 
                            WHERE 1=1";
        }
        #endregion

        #region sự kiện trên layout tài liệu
        private void rep_luu_file_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte(do_tt.NOI_DUNG, do_tt.TEN_FILE);
        }
        Image pic; string Path_new;
        private void repIn_Click(object sender, EventArgs e)
        {
            DataRow row = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            PrintDocument thePrint = new PrintDocument();
            PrintDialog print = new PrintDialog();
            print.Document = thePrint;
            thePrint.PrintPage += new PrintPageEventHandler(thePrint_PrintPage);
            Path_new = FrameworkParams.TEMP_FOLDER + @"\" + row["TEN_FILE"].ToString();

            byte[] a = row["NOI_DUNG"] as byte[];
            if (a == null || a.Length == 0) return;
            HelpByte.BytesToFile(a, Path_new);
            try
            {
                pic = Image.FromFile(Path_new);
            }
            catch
            { pic = null; }
            read = new System.IO.StreamReader(Path_new, Encoding.Default, true);
            #region print word file
            if (Path.GetExtension(Path_new).ToLower().Equals(".doc")
                || Path.GetExtension(Path_new).ToLower().Equals(".docx"))
            {
                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                object fileName = Path_new;
                object nullobj = Missing.Value;
                wordApp.Visible = true;
                Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(
                    ref fileName, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                    ref nullobj, ref nullobj, ref nullobj);
                doc.PrintPreview();   
            }
            #endregion

            #region print excel file
            else if (Path.GetExtension(Path_new).ToLower().Equals(".xls")
                || Path.GetExtension(Path_new).ToLower().Equals(".xlsx"))
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                ExcelApp.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook WBook = ExcelApp.Workbooks.Open(Path_new, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                object obj = true;
                WBook.PrintPreview(obj);
                WBook.Close(false, Missing.Value, Missing.Value);
                ExcelApp.Quit();
            }
            #endregion

            #region print .pdf file
            else if (Path.GetExtension(Path_new).ToLower().Equals(".pdf"))
            {
                System.Diagnostics.Process objProcess = new System.Diagnostics.Process();
                objProcess.StartInfo.FileName = Path_new; //file to print
                objProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                objProcess.StartInfo.UseShellExecute = true;
                objProcess.StartInfo.CreateNoWindow = false;
                objProcess.StartInfo.ErrorDialog = false;
                objProcess.StartInfo.Verb = "print";
                objProcess.Start();
            }
            #endregion

            #region print html file
            else if (Path.GetExtension(Path_new).ToLower().Equals(".htm")
                || Path.GetExtension(Path_new).ToLower().Equals(".html"))
            {
                WebBrowser browser = new WebBrowser();
                browser.DocumentText = read.ReadToEnd();
                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                browser.Parent = this;
                browser.ShowPrintPreviewDialog();
                browser.Dispose();
            }
            #endregion

            else if (print.ShowDialog() == DialogResult.OK)
            {
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                ppd.Document = thePrint;
                ((Form)ppd).WindowState = FormWindowState.Maximized;
                ppd.ShowDialog();
                //thePrint.Print();
            }
        }

        void thePrint_PrintPage(object sender, PrintPageEventArgs ev)
        {
            #region file image and text.
            if (pic != null)
            {
                Point point = new Point(0, 20);
                ev.Graphics.DrawImage(pic, point);
            }
            else
            {
                float linesPerPage = 0;
                float yPosition = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                string line = null;
                Font printFont = this.Font;
                SolidBrush myBrush = new SolidBrush(Color.Black);
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                while (count < linesPerPage && ((line = read.ReadLine()) != null))
                {
                    yPosition = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                    count++;
                }
                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
                myBrush.Dispose();
            }
            #endregion
        }
        private void gridControlTaiLieu_MouseMove(object sender, MouseEventArgs e)
        {
            LayoutViewHitInfo layouthit = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)
            {
                if (layouthit.Column.Name == "cot_mofile")
                {
                    toolTip1.Show("Mở tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
                if (layouthit.Column.Name == "cot_luufile")
                {
                    toolTip1.Show("Lưu tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
                if (layouthit.Column.Name == "lvIn")
                {
                    toolTip1.Show("In tập tin", this.MdiParent, MousePosition.X + 5, MousePosition.Y + 25, 500);
                }
            }
        }
        #endregion
        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            AppCtrl.InitTreeChonNhanVien_Choice1(cboNguoi_gui, true);
            AppCtrl.InitTreeChonNhanVien(cboNguoi_nhan, false, false);
            cboNguoi_gui._setSelectedID(FrameworkParams.currentUser.employee_id);
            cboNguoi_nhan._SelectedIDs = new long[] { FrameworkParams.currentUser.employee_id };
            DMCMucDoUuTien.I.InitCtrl(cboMuc_uu_tien, true, true);
            DATapTinInAn.InitCtrl(PLImgTinhTrang);
            return null;
        }
        #endregion
    }
}

