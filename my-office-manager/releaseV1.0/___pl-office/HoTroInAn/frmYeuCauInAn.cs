using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DAO;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Controls;
using DTO;
using ProtocolVN.DanhMuc;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using System.Drawing.Printing;
using ProtocolVN.App.Office;
using System.IO;
using System.Reflection;

namespace office
{
    public partial class frmYeuCauInAn : XtraFormPL
    {
        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.NO_USE;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmYeuCauInAn).FullName,
                HelpDebug.UpdateTitle("Yêu cầu in ấn", Status),
                ParentID, true,
                typeof(frmYeuCauInAn).FullName,
                false, IsSep, "mnbCHinhHeThong.png", true, "", "");
        }
        #endregion

        #region Các khai báo biến
        private DXErrorProvider Error;
        private bool? IsAdd; //true = New, null = View, false = Edit
        private long _ID;
        DOHoTroInAn do_InAn;
        DAHoTroInAn da_InAn=new DAHoTroInAn();
        private System.IO.StreamReader read;
        private DOLuuTruTapTin do_luu_tru_tt = null;
        private List<DOTapTin_TapTinInAn> list_them_taptin = new List<DOTapTin_TapTinInAn>();
        private List<DOTapTin_TapTinInAn> list_sua_taptin = new List<DOTapTin_TapTinInAn>();
        private DOTapTinInAn do_TapTinInAn = new DOTapTinInAn();
        List<long> ID_taptin_dangxoa = new List<long>();
        bool is_update_taptin = false;
        public delegate void RefreshFrm(DOHoTroInAn doHoTroIn);
        public event RefreshFrm RefreshFrbug;
        
        #endregion

        #region Hàm dựng
        public frmYeuCauInAn(long ID, bool? IsAdd)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            this.IsAdd = IsAdd;
            this._ID = ID;
            InitForm();
            InitGrid();
            
            this.Load += new EventHandler(frmYeuCauInAn_Load);
        }

        void frmYeuCauInAn_Load(object sender, EventArgs e)
        {
            PLTinhtrang.SelectedIndexChanged += new EventHandler(PLTinhtrang_SelectedIndexChanged);
        }

        void PLTinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAdd == true) PLTinhtrang._setSelectedID(1);
        }

        public frmYeuCauInAn()
            : this(-2, true)
        {
        }

        #endregion

        #region InitForm
        private void InitForm()
        {            
            AppCtrl.InitTreeChonNhanVien_Choice1(NhanVien, true);
            DMCMucDoUuTien.I.InitCtrl(cboMuc_uu_tien, true, true);
            DATapTinInAn.InitCtrl(PLTinhtrang);
            lblThoiGianGui.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            if (IsAdd == true)
            {
                do_InAn = DAHoTroInAn.Instance.Load(-2);              
                do_InAn.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                _ID = do_InAn.ID;
                lblNguoiGui.Text = DACongViec.getNameNV(FrameworkParams.currentUser.employee_id);
                do_luu_tru_tt = DALuuTruTapTin.Instance.LoadAll(-2);
                btnLuu.Visible = true;
                btnThemTT.Visible = true;
                PLTinhtrang._setSelectedID(1);
            }
            else
            {
                do_InAn = DAHoTroInAn.Instance.Load(_ID);
                do_luu_tru_tt = DADocument.Instance.load_DOTapTin(_ID);
                NhanVien._setSelectedID(HelpNumber.ParseInt64(do_InAn.NGUOI_NHAN_ID));
                cboMuc_uu_tien._setSelectedID(HelpNumber.ParseInt64(do_InAn.MUC_DO_UU_TIEN_ID));
                lblNguoiGui.Text = DACongViec.getNameNV(do_InAn.NGUOI_GUI_ID);
                PLTinhtrang._setSelectedID(do_InAn.TINH_TRANG_IN_ID);
                memoMucDich.Text = do_InAn.MUC_DICH;
                if (do_InAn.ID == 0)
                {
                    HelpMsgBox.ShowErrorMessage("Dữ liệu đã bị mất.....");
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn thêm dữ liệu.") == DialogResult.No)
                        return;
                    else
                    {                       
                        do_InAn = DAHoTroInAn.Instance.Load(-2);
                        btnLuu.Visible = true;
                        IsAdd = true;
                        return;
                    }
                }
                if (IsAdd == false)
                {
                    btnLuu.Visible = true;
                    btnThemTT.Visible = true;
                }
                else
                {
                    cot_suafile.LayoutViewField.Visibility = cot_xoa.LayoutViewField.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnThemTT.Visible = false;
                    lblThoiGianGui.Text = do_InAn.THOI_GIAN_CAP_NHAT.ToString();
                    
                }
                LoadTapTin(_ID);
            }
        }
        public void InitGrid()
        {
            layoutView1.Appearance.CardCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lvGhi_chu.OptionsColumn.ReadOnly = true;
            toolTip1.BackColor = Color.LightYellow;
            layoutView1.OptionsCustomization.AllowSort = false;
            layoutView1.OptionsCustomization.AllowFilter = false;
            layoutView1.OptionsHeaderPanel.EnableCustomizeButton = false;
            layoutView1.OptionsBehavior.AllowSwitchViewModes = true;
            layoutView1.OptionsBehavior.AllowExpandCollapse = true;
            layoutView1.OptionsView.ShowCardCaption = true;
            XtraGridSupportExt.TextLeftColumn(lvTieuDe, "TIEU_DE");
            XtraGridSupportExt.TextLeftColumn(lvFile_dinh_kem, "TEN_FILE");
            XtraGridSupportExt.TextLeftColumn(lvNguoiCapNhat, "TEN_NGUOI_CN");
            XtraGridSupportExt.TextLeftColumn(lvNgayCapNhat, "NGAY_CAP_NHAT");
            HelpGridColumn.CotMemoExEdit(lvGhi_chu, "GHI_CHU");
            HelpGridColumn.CotMemoExEdit(lvYeuCau, "YEU_CAU");
            XtraGridSupportExt.TextLeftColumn(cot_xoa, "xoa_file");
            XtraGridSupportExt.TextLeftColumn(cot_luufile, "luu_file");
            XtraGridSupportExt.TextLeftColumn(cot_mofile, "mo_file");
            XtraGridSupportExt.TextCenterColumn(cot_suafile, "sua_file");
            XtraGridSupportExt.TextCenterColumn(lvIn, "in_file");
            XtraGridSupportExt.TextLeftColumn(cotID, "ID");
            XtraGridSupportExt.TextLeftColumn(cotID, "HO_TRO_IN_AN_ID");
            XtraGridSupportExt.DecimalGridColumn(lvSoBan, "SO_TO", 0);
            lvSoBan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
        }
        private bool IsValidate()
        {
            Error.ClearErrors();
            HelpInputData.ShowRequiredError(Error,
                     new object[]{
                        NhanVien,"Người thực hiện", 
                        memoMucDich,"Mục đích"                                                                                      
                    }
                 );
            if (cboMuc_uu_tien._getSelectedID() == -1)
                cboMuc_uu_tien.SetError(Error, "Vui lòng vào thông tin \"Độ ưu tiên\" !");
            if (PLTinhtrang._getSelectedID() == -1)
                PLTinhtrang.SetError(Error, "Vui lòng vào thông tin \"Tình trạng\" !");
            
            return !Error.HasErrors;
        }

        private void frmThem_TL_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
        }
        
        #endregion

        #region Xử lý nút

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (IsAdd == null)
            {
                this.Close();
            }
            else
                if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn đóng?") == DialogResult.Yes)
                {                  
                    this.Close();
                }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            do_InAn.THOI_GIAN_CAP_NHAT = HelpDB.getDatabase().GetSystemCurrentDateTime();
            do_InAn.NGUOI_NHAN_ID = NhanVien._getSelectedID();                
            do_InAn.MUC_DO_UU_TIEN_ID = cboMuc_uu_tien._getSelectedID();
            do_InAn.TINH_TRANG_IN_ID = PLTinhtrang._getSelectedID();
            do_InAn.NGUOI_GUI_ID = FrameworkParams.currentUser.employee_id;
            do_InAn.MUC_DICH = memoMucDich.Text;

            bool hople = true;
            if (IsValidate())
            {
                if (memoMucDich.Text.Length > 500)
                {
                    HelpMsgBox.ShowErrorMessage("Vui lòng nhập mục đích tối đa 500 ký tự");
                    hople = false;
                }
                if (layoutView1.DataSource == null || (layoutView1.DataSource as DataView).Count < 1)
                {
                    HelpMsgBox.ShowErrorMessage("Vui lòng nhập ít nhất 1 file đính kèm!");
                    hople = false;
                }
                if(hople)
                {                    
                    if (DAHoTroInAn.Instance.Update(do_InAn))
                    {
                        //lưu tập tin thêm mới
                        if (list_them_taptin != null)
                        {
                            //int i = 0;
                            foreach (DOTapTin_TapTinInAn do_tt in list_them_taptin)
                            {
                                da_InAn.UpdateTapTin(do_tt);
                            }
                        }
                        //lưu tập tin_Fax
                        foreach (DOTapTin_TapTinInAn do_taptin in list_them_taptin)
                        {
                            DAHoTroInAn.SaveFilePrint(do_taptin);
                        }
                        foreach (DOTapTin_TapTinInAn do_taptin in list_them_taptin)
                        {
                            DAHoTroInAn.SaveFilePrint(do_taptin);
                        }
                        //Lưu sửa tập tin
                        if (list_sua_taptin != null)
                        {
                            foreach (DOTapTin_TapTinInAn do_sua_tt in list_sua_taptin)
                            {
                                da_InAn.UpdateTapTin(do_sua_tt);
                                DAHoTroInAn.EditFilePrint(do_sua_tt);
                            }
                        }
                        foreach (long id_taptin in ID_taptin_dangxoa)
                        {
                            try
                            {
                                DAHoTroInAn.DeleteFilePrint(id_taptin);
                                //Xóa trong lưu trữ tập tin
                                DAHoTroInAn.DeleteLuuTruTapTin(id_taptin);
                            }
                            catch (Exception ex)
                            {
                                PLException.AddException(ex);
                            }
                        }
                        list_them_taptin.Clear();
                        if (RefreshFrbug != null)
                            this.RefreshFrbug(do_InAn);////

                        if (IsAdd == false)
                        {
                            this.Close();
                        }
                        else
                        {
                            HelpMsgBox.ShowNotificationMessage("Lưu thành công.");
                            btnThemTT.Visible = true;
                        }
                    }
                    else
                        HelpMsgBox.ShowNotificationMessage("Lưu không thành công !");
                }
            }
        }       
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn xóa không!") == DialogResult.Yes)
            {
               DAHoTroInAn.RemoveAllFilesPrint(do_InAn.ID);
                FWDBService.DeleteRecord("HO_TRO_IN_AN", "ID", do_InAn.ID);              
                this.Close();
            }
        }
        private void btnThemTT_Click(object sender, EventArgs e)
        {
            is_update_taptin = false;
            frmTapTinInAn frm = new frmTapTinInAn(-2, do_InAn.ID, true,null);
            frm.UpdateTapTinIn += new frmTapTinInAn.UpdateTapTinHandler(frm_UpdateTapTin);
            HelpProtocolForm.ShowModalDialog(this, frm);
            LoadTapTin(_ID);
        }
        
        public void frm_UpdateTapTin(object sender, DOTapTin_TapTinInAn do_TT_InAn)
        {
            if (is_update_taptin == false)
            {                
                for (int i = 0; i < list_them_taptin.Count; i++)
                {
                    if (list_them_taptin[i].ID == do_TT_InAn.ID)
                    {
                        list_them_taptin.Remove(list_them_taptin[i]);
                        list_them_taptin.Insert(i,do_TT_InAn);
                        return;
                    }
                }
                list_them_taptin.Add(do_TT_InAn);
            }
            else
            {
                list_sua_taptin.Add(do_TT_InAn);
            }
        }       
        #endregion

        #region sự kiện trên layout
        private void rep_mofile_Click(object sender, EventArgs e)
        {
            DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            // DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Open_file_from_byte( r["NOI_DUNG"] as byte[], r["TEN_FILE"].ToString());
        }

        private void rep_luufile_Click(object sender, EventArgs e)
        {
            DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            //DOLuuTruTapTin do_tt = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(row["ID"]));
            DADocument.Instance.Save_file_from_byte(r["NOI_DUNG"] as byte[], r["TEN_FILE"].ToString());
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
            read = new System.IO.StreamReader(Path_new, System.Text.Encoding.Default, true);
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
                ExcelApp.DisplayAlerts = false;
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

        private void rep_xoa_Click(object sender, EventArgs e)
        {
            if (IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa dữ liệu đang chọn không?") == DialogResult.Yes)
                    {
                        long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                        if (list_them_taptin.Count != 0)
                        {
                            for (int i = 0; i < list_them_taptin.Count; i++)
                            {
                                if (list_them_taptin[i].ID == id_taptin)
                                {
                                    list_them_taptin.Remove(list_them_taptin[i]);
                                    break;
                                }
                                else
                                {
                                    ID_taptin_dangxoa.Add(id_taptin);
                                }
                            }
                        }
                        else
                        { ID_taptin_dangxoa.Add(id_taptin); }
                        layoutView1.DeleteSelectedRows();
                    }
                }
            }
        }

        private void repSua_Click(object sender, EventArgs e)
        {
            DOTapTin_TapTinInAn do_TT_IN = new DOTapTin_TapTinInAn();
            frmTapTinInAn frm;
            if (IsAdd != null)
            {
                DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
                if (r != null)
                {
                    is_update_taptin = true;

                    long id_taptin = HelpNumber.ParseInt64(r["ID"]);
                    for (int i = 0; i < list_them_taptin.Count; i++)
                    {
                        if (list_them_taptin[i].ID == id_taptin)
                        {
                            is_update_taptin = false;
                            do_TT_IN = list_them_taptin[i];
                        }
                    }
                    if (is_update_taptin)
                    {
                         frm = new frmTapTinInAn(HelpNumber.ParseInt64(r["ID"]), HelpNumber.ParseInt64(r["HO_TRO_IN_AN_ID"]), false,null);
                    }
                    else
                    {
                         frm = new frmTapTinInAn(HelpNumber.ParseInt64(r["ID"]), HelpNumber.ParseInt64(r["HO_TRO_IN_AN_ID"]), false, do_TT_IN);
                    }                        

                    frm.UpdateTapTinIn += new frmTapTinInAn.UpdateTapTinHandler(frm_UpdateTapTin);
                    HelpProtocolForm.ShowModalDialog(this, frm);
                    LoadTapTin(_ID);
                }
            }
        }

        private void LoadTapTin(Int64 ID_htia)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet(@"select lttt.*,(SELECT NAME FROM DM_NHAN_VIEN WHERE ID = lttt.NGUOI_CAP_NHAT) TEN_NGUOI_CN,
                    tt.HO_TRO_IN_AN_ID,tt.SO_TO,tt.YEU_CAU from LUU_TRU_TAP_TIN lttt inner join TAP_TIN_IN_AN tt on lttt.ID=tt.TAP_TIN_ID
                where lttt.ID in(select TAP_TIN_ID from TAP_TIN_IN_AN where HO_TRO_IN_AN_ID=" + ID_htia + ")");

            ds.Tables[0].Columns.Add("mo_file", typeof(Image));
            ds.Tables[0].Columns.Add("luu_file", typeof(Image));
            ds.Tables[0].Columns.Add("xoa_file", typeof(Image));
            ds.Tables[0].Columns.Add("sua_file", typeof(Image));
            ds.Tables[0].Columns.Add("in_file", typeof(Image));
            ds.Tables[0].Columns.Add("SIZE", typeof(Decimal));
            HelpGridColumn.CotCalcEditDec(lvSize, "SIZE", 3, true);
            lvSize.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                r["mo_file"] = FWImageDic.VIEW_IMAGE20;
                r["luu_file"] = FWImageDic.SAVE_IMAGE20;
                r["xoa_file"] = FWImageDic.DELETE_IMAGE20;
                r["sua_file"] = FWImageDic.EDIT_IMAGE20;
                r["in_file"] = FWImageDic.PRINT_IMAGE20;
                byte[] a = r["NOI_DUNG"] as byte[];
                if (a != null)
                {
                    r["SIZE"] = HelpNumber.ParseDecimal(a.Length) / 1024;
                }
            }
            foreach (DOTapTin_TapTinInAn do_tt in list_them_taptin)
            {
                DataRow row = ds.Tables[0].NewRow();
                row["SO_TO"] = do_tt.SO_TO;
                row["YEU_CAU"] = do_tt.YEU_CAU;
                row["TIEU_DE"] = do_tt.TIEU_DE;
                row["TEN_FILE"] = do_tt.TEN_FILE;
                row["TEN_NGUOI_CN"] = DACongViec.getNameNV(HelpNumber.ParseInt64(do_tt.NGUOI_CAP_NHAT.ToString()));
                row["NGAY_CAP_NHAT"] = do_tt.NGAY_CAP_NHAT;
                row["NOI_DUNG"] = do_tt.NOI_DUNG;
                row["HO_TRO_IN_AN_ID"] = do_tt.HO_TRO_IN_AN_ID;
                row["GHI_CHU"] = do_tt.GHI_CHU;
                row["ID"] = do_tt.ID;
                row["mo_file"] = FWImageDic.VIEW_IMAGE20;
                row["luu_file"] = FWImageDic.SAVE_IMAGE20;
                row["xoa_file"] = FWImageDic.DELETE_IMAGE20;
                row["sua_file"] = FWImageDic.EDIT_IMAGE20;
                row["in_file"] = FWImageDic.PRINT_IMAGE20;
                byte[] a = do_tt.NOI_DUNG;
                if (a != null)
                {
                    row["SIZE"] = HelpNumber.ParseDecimal(a.Length) / 1024;
                }
                ds.Tables[0].Rows.Add(row);
            }
            foreach (DOTapTin_TapTinInAn do_tt in list_sua_taptin)
            {
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (do_tt.ID.ToString() == r["ID"].ToString())
                    {
                        r["YEU_CAU"] = do_tt.YEU_CAU;
                        r["SO_TO"] = do_tt.SO_TO;
                        r["TIEU_DE"] = do_tt.TIEU_DE;
                        r["TEN_FILE"] = do_tt.TEN_FILE;
                        r["HO_TRO_IN_AN_ID"] = do_tt.HO_TRO_IN_AN_ID;
                        r["NOI_DUNG"] = do_tt.NOI_DUNG;
                        r["NGAY_CAP_NHAT"] = do_tt.NGAY_CAP_NHAT;
                        r["TEN_NGUOI_CN"] = DACongViec.getNameNV(HelpNumber.ParseInt64(do_tt.NGUOI_CAP_NHAT.ToString()));
                        r["GHI_CHU"] = do_tt.GHI_CHU;
                        r["ID"] = do_tt.ID;
                        r["mo_file"] = FWImageDic.VIEW_IMAGE20;
                        r["luu_file"] = FWImageDic.SAVE_IMAGE20;
                        r["xoa_file"] = FWImageDic.DELETE_IMAGE20;
                        r["sua_file"] = FWImageDic.EDIT_IMAGE20;
                        r["in_file"] = FWImageDic.PRINT_IMAGE20;
                        byte[] a = do_tt.NOI_DUNG;
                        if (a != null)
                        {
                            r["SIZE"] = HelpNumber.ParseDecimal(a.Length) / 1024;
                        }
                    }
                }
            }

            foreach (long id_taptin in ID_taptin_dangxoa)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (HelpNumber.ParseInt64(row["ID"]) == id_taptin)
                    {
                        ds.Tables[0].Rows.Remove(row);
                        break;
                    }
                }
            }
            gridControlTaiLieu.DataSource = ds.Tables[0];
        }

        private void gridControlTaiLieu_MouseMove(object sender, MouseEventArgs e)
        {
            DataRow r = layoutView1.GetDataRow(layoutView1.FocusedRowHandle);
            LayoutViewHitInfo layouthit = layoutView1.CalcHitInfo(layoutView1.GridControl.PointToClient(Control.MousePosition));
            if (layouthit.Column != null)//Nếu vị trí click là cell trong row
            {
                if (layouthit.Column.Name == "cot_xoa")
                {
                    toolTip1.Show("Xoá tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_suafile")
                {
                    toolTip1.Show("Sửa tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_mofile")
                {
                    toolTip1.Show("Mở tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "cot_luufile")
                {
                    toolTip1.Show("Lưu tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
                if (layouthit.Column.Name == "lvIn")
                {
                    toolTip1.Show("In tập tin", this, MousePosition.X - this.Location.X, MousePosition.Y - this.Location.Y + 20, 500);
                }
            }
        }
        #endregion  
    }
}