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
    public partial class frmYeuCauFax : XtraFormPL
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
        DOHoTroFax do_Fax;
        DAHoTroFax da_Fax = new DAHoTroFax();
        private DOLuuTruTapTin do_luu_tru_tt = null;
        private DOTapTinFax do_TapTinInAn = new DOTapTinFax();
        public delegate void RefreshFrm(DOHoTroFax doHoTroFax);
        public event RefreshFrm RefreshFrbug;
        private System.IO.StreamReader read;
        #endregion

        #region Hàm dựng
        public frmYeuCauFax(long ID, bool? IsAdd)
        {
            InitializeComponent();
            Error = new DXErrorProvider();
            this.IsAdd = IsAdd;
            this._ID = ID;
            initform();
            this.Load += new EventHandler(frmYeuCauFax_Load);
        }

        void frmYeuCauFax_Load(object sender, EventArgs e)
        {
            PLTinhtrang.SelectedIndexChanged += new EventHandler(PLTinhtrang_SelectedIndexChanged);
        }

        void PLTinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsAdd == true) PLTinhtrang._setSelectedID(1);
        }

        public frmYeuCauFax() : this(-2, true) { }

        #endregion

        #region InitForm
        private void initform()
        {            
            AppCtrl.InitTreeChonNhanVien_Choice1(NguoiThucHien, true);
            DMCMucDoUuTien.I.InitCtrl(cboMuc_uu_tien, true, true);
            DMCTinhTrangFax.Instance.InitCtrl(PLTinhtrang);
            lblThoiGianGui.Text = HelpDB.getDatabase().GetSystemCurrentDateTime().ToString(PLConst.FORMAT_DATETIME_STRING);
            plMultiChoiceFiles1._Init(IsAdd, true);
            plMultiChoiceFiles1.repImageFax.Click += new EventHandler(repImageFax_Click);
            if (IsAdd == true)
            {
                do_Fax = DAHoTroFax.Instance.Load(-2);
                do_Fax.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                _ID = do_Fax.ID;
                do_luu_tru_tt = DALuuTruTapTin.Instance.LoadAll(-2);
                plMultiChoiceFiles1._DataSource = DALuuTruTapTin.Instance.GetTapTinByObjectID(-2, 11);
                btnLuu.Visible = true;
                lblNguoiGui.Text = DMNhanVienX.I.GetEmployeeFullName(FrameworkParams.currentUser.employee_id);
                PLTinhtrang._setSelectedID(1);
            }
            else
            {
                do_Fax = DAHoTroFax.Instance.Load(_ID);
                plMultiChoiceFiles1._DataSource = DALuuTruTapTin.Instance.GetTapTinByObjectID(_ID, 11);
                do_luu_tru_tt = DADocument.Instance.load_DOTapTin(_ID);
                NguoiThucHien._setSelectedID(HelpNumber.ParseInt64(do_Fax.NGUOI_NHAN_ID));
                cboMuc_uu_tien._setSelectedID(HelpNumber.ParseInt64(do_Fax.MUC_DO_UU_TIEN_ID));
                lblNguoiGui.Text = DMNhanVienX.I.GetEmployeeFullName(do_Fax.NGUOI_GUI_ID);
                txtGuiDenSo.Text = do_Fax.GUI_DEN_SO;
                txtNguoiNhan.Text = do_Fax.TEN_NGUOI_NHAN;
                memoNoiDung.Text = do_Fax.NOI_DUNG_KEM_THEO;
                PLTinhtrang._setSelectedID(do_Fax.TINH_TRANG_FAX_ID);
                if (do_Fax.ID == 0)
                {
                    HelpMsgBox.ShowErrorMessage("Dữ liệu đã bị mất.....");
                    if (HelpMsgBox.ShowConfirmMessage("Bạn có muốn thêm dữ liệu.") == DialogResult.No)
                        return;
                    else
                    {

                        do_Fax = DAHoTroFax.Instance.Load(-2);
                        btnLuu.Visible = true;
                        IsAdd = true;
                        return;
                    }
                }
                if (IsAdd == false)
                {
                    btnLuu.Visible = true;
                }
            }
        }
        Image pic; string Path_new;

        void repImageFax_Click(object sender, EventArgs e)
        {            
            DataRow row = plMultiChoiceFiles1.gridViewListFiles.GetDataRow(plMultiChoiceFiles1.gridViewListFiles.FocusedRowHandle);
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
                // Work out the number of lines per page, using the MarginBounds.
                linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
                //Iterate over the string using the StringReader, printing each line.
                while (count < linesPerPage && ((line = read.ReadLine()) != null))
                {
                    //calculate the next line position based on the height of the font according to the printing device
                    yPosition = topMargin + (count * printFont.GetHeight(ev.Graphics));
                    //draw the next line in the rich edit control
                    ev.Graphics.DrawString(line, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                    count++;
                }
                //If there are more lines, print another page.
                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
                myBrush.Dispose();
            }
            #endregion
        }            
        
        private bool IsValidate()
        {
            Error.ClearErrors();
            HelpInputData.ShowRequiredError(Error,
                   new object[]{
                        NguoiThucHien,"Người thực hiện",
                        txtGuiDenSo,"Gửi đến số",
                        txtNguoiNhan,"Người nhận",
                        memoNoiDung,"Nội dung"
                    }
               );
            if (cboMuc_uu_tien._getSelectedID() == -1)
                cboMuc_uu_tien.SetError(Error, "Vui lòng vào thông tin \"Độ ưu tiên\" !");
            if(PLTinhtrang._getSelectedID() == -1)
                PLTinhtrang.SetError(Error, "Vui lòng vào thông tin \"Tình trạng\" !");
            return !Error.HasErrors;
        }

        private void frmThem_TL_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            HelpInputData.SetMaxLength(new object[] {
                txtGuiDenSo,100,
                txtNguoiNhan,200,
                memoNoiDung,400
            });
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
            do_Fax.THOI_GIAN_CAP_NHAT = HelpDB.getDatabase().GetSystemCurrentDateTime();
            do_Fax.NGUOI_GUI_ID = do_Fax.NGUOI_GUI_ID > 0 ? do_Fax.NGUOI_GUI_ID : FrameworkParams.currentUser.employee_id;
            do_Fax.NGUOI_NHAN_ID = NguoiThucHien._getSelectedID();
            do_Fax.MUC_DO_UU_TIEN_ID = cboMuc_uu_tien._getSelectedID();
            do_Fax.TINH_TRANG_FAX_ID = PLTinhtrang._getSelectedID();
            do_Fax.GUI_DEN_SO = txtGuiDenSo.Text;
            do_Fax.TEN_NGUOI_NHAN = txtNguoiNhan.Text;
            do_Fax.NOI_DUNG_KEM_THEO = memoNoiDung.Text;
            do_Fax.DsFile = plMultiChoiceFiles1._DataSource;
            if (do_Fax.ID == 0)
            {
                do_Fax.ID = HelpDB.getDatabase().GetID("G_NGHIEP_VU");
                _ID = do_Fax.ID;
            }
            bool hople = true;
            if (IsValidate())
            {
                if (do_Fax.NOI_DUNG_KEM_THEO.Length > 500)
                {
                    HelpMsgBox.ShowErrorMessage("Vui lòng nhập mục đích tối đa 500 ký tự");
                    hople = false;
                }
                if (plMultiChoiceFiles1.popupContainerEdit1.Text.Trim() == "")
                {
                    HelpMsgBox.ShowErrorMessage("Vui lòng nhập ít nhất 1 file cần fax!");
                    hople = false;
                }
                if (hople)
                {
                    if (DAHoTroFax.Instance.Update(do_Fax))
                    {                       
                        if (RefreshFrbug != null)
                            this.RefreshFrbug(do_Fax);
                        HelpXtraForm.CloseFormNoConfirm(this);
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
                DAHoTroInAn.RemoveAllFilesPrint(do_Fax.ID);
                FWDBService.DeleteRecord("HO_TRO_FAX", "ID", do_Fax.ID);
                this.Close();
            }
        }

        #endregion
    }
}