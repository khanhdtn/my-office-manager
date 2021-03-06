using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Text.RegularExpressions;
using ProtocolVN.DanhMuc;

namespace office
{
    /// <summary>Nơi chứa các thao tác chung liên quan đến giao diện của dự án
    /// </summary>
    public class PLGUIUtil
    {
        #region Những phương thức đặt chưa đúng chỗ
        
        #endregion

        #region Đối tượng Form
        public static void setDefaultSize(XtraForm frm) {
            frm.Size = PLConst.SIZE_POPUP_FORM;
            setKey(frm);
        }
        public static void setKey(XtraForm frm) {
            PLKey key = new PLKey(frm);
            key.Add(Keys.F12, frm.Close);
        }
        public static void ClosePhieu(XtraForm frm, bool? isAdd, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (frm.Tag != null && frm.Tag.Equals("Q")) { e.Cancel = false; return; }
            if (isAdd == null) { e.Cancel = false; return; }
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes) e.Cancel = false;
            else e.Cancel = true;
        }
        public static void ClosePhieu(XtraForm frm, bool? skipInfo)
        {
            if (skipInfo == true) frm.Tag = "Q";
            frm.Close();
        }
        public static bool XoaPhieu(XtraForm frm)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa ?") == DialogResult.Yes)
                return true;
            return false;
        }
        public static void HuyForm(XtraForm form)
        {
            ErrorMsg.ErrorDeleted();
            throw new Exception();
        }
        public static void DongForm(XtraForm frm)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng ?") == DialogResult.Yes)
            {
                frm.Close();
            }
        }

        public static void InitBtnPhieu(XtraForm frm, bool? IsAdd, DropDownButton NghiepVu, DropDownButton InPhieu, DropDownButton Chon,
                                        SimpleButton Save, SimpleButton Delete, SimpleButton Close)
        {
            try { //Save.Image = FWImageDic.SAVE_IMAGE16; 
            }
            catch { }
            try { //Delete.Image = FWImageDic.DELETE_IMAGE16; 
            }
            catch { }
            try { //Close.Image = FWImageDic.CLOSE_IMAGE16; 
            }
            catch { }
            if (IsAdd == null)
            {
                if (Delete != null) Delete.Visible = false;
                if (Save != null) Save.Visible = false;
                if (NghiepVu != null) NghiepVu.Enabled = true;
                if (InPhieu != null) InPhieu.Enabled = true;
                if (Chon != null) Chon.Enabled = false;
            }
            else if (IsAdd == true)
            {
                if (Delete != null) Delete.Enabled = false;
                if (Save != null) Save.Enabled = true;
                if (NghiepVu != null) NghiepVu.Enabled = false;
                if (InPhieu != null) InPhieu.Enabled = false;
                if (Chon != null) Chon.Enabled = true;
            }
            else
            {
                if (Delete != null) Delete.Enabled = true;
                if (Save != null) Save.Enabled = true;
                if (NghiepVu != null) NghiepVu.Enabled = false;
                if (InPhieu != null) InPhieu.Enabled = false;
                if (Chon != null) Chon.Enabled = true;
            }
        }

        /// <summary>Mở nút nghiệp vụ ở phiếu quản lý : PhieuQuanLy10Change
        /// Do FW chưa hỗ trợ
        /// </summary>
        public static void InitBtnNghiepVu(PhieuQuanLy10Change that) {
            that.gridViewMaster.FocusedRowChanged += delegate(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
            {
                if ((that.gridViewMaster.DataSource as DataView).Table.Rows.Count > 0)
                    that.barSubItem1.Enabled = true;
                else that.barSubItem1.Enabled = false;
            };
        }
        #endregion

        #region Đối tượng Grid
        /// <summary>Chỉnh độ rộng của cột theo dạng đẹp nhất có thể
        /// </summary>
        public static void BestFitMasterColumns(GridView gridView) {
            gridView.GridControl.Load += delegate(object sender, EventArgs e)
            {
                gridView.BestFitColumns();
            };
        }
        public static void TrimSpaceForGrid(GridView gridView, params string[] fieldName)
        {
            gridView.CellValueChanged += delegate(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
            {
                GridView grid = (GridView)sender;
                DataRow row = grid.GetDataRow(e.RowHandle);
                for (int i = 0; i < fieldName.Length; i++)
                {
                    if (e.Column.FieldName == fieldName[i])
                    {
                        row[fieldName[i]] = e.Value.ToString().Trim();
                        break;
                    }
                }
            };
        }
        #endregion

        #region Đối tượng khác
        public static void UpdateSoPhieu(TextEdit SoPhieu, string Value)
        {
            SoPhieu.Text = Value;
            SoPhieu.Properties.ReadOnly = false;
        }
        /// <summary>CHAUTV : Cập nhật trạng thái DUYỆT/KHÔNG DUYỆT của Phiếu
        /// </summary>
        public static bool UpdateDuyetPhieu(String PhieuTable, string KeyName, long IDKey, long NguoiDuyetID, DateTime NgayDuyet, DuyetSupportStatus TinhTrang)
        {
            DatabaseFB db = DABase.getDatabase();
            string SQL = string.Format(@"UPDATE {0}
                                         SET    NGAY_DUYET = @NGAY_DUYET,
                                                DUYET = @DUYET,
                                                NGUOI_DUYET = @NGUOI_DUYET
                                        WHERE   {1} = {2}",PhieuTable,KeyName,IDKey);
            DbCommand cmd = db.GetSQLStringCommand(SQL);
            db.AddInParameter(cmd, "@NGAY_DUYET", DbType.DateTime, NgayDuyet);
            db.AddInParameter(cmd, "@DUYET", DbType.String, ((Int64)TinhTrang).ToString());
            db.AddInParameter(cmd, "@NGUOI_DUYET", DbType.Int64, (Int64)NguoiDuyetID);
            try
            {
                db.ExecuteNonQuery(cmd);
                return true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Cập nhật trạng thái duyệt của phiếu : " + IDKey);
                return false;
            }
        }

        public static DuyetSupportStatus getDuyet(object value) {
            return (DuyetSupportStatus)HelpNumber.ParseInt32(value);
        }
        public static bool IsDuyet(object value) {
            return getDuyet(value) == DuyetSupportStatus.Duyet;
        }
        public static bool IsKhongDuyet(object value)
        {
            return getDuyet(value) == DuyetSupportStatus.KhongDuyet;
        }
        public static bool IsChoDuyet(object value)
        {
            return getDuyet(value) == DuyetSupportStatus.ChoDuyet;
        }
        /// <summary>
        /// Chuyển chuỗi HTML sang chuỗi dạng text
        /// </summary>
        /// <param name="HTML"></param>
        /// <returns></returns>
        public static string HTMLtoText(string HTML)
        {
            Regex reg = new Regex("<[^>]*>");
            string s = reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");
        }
        #endregion

        #region FW Controls
        public static void HelpSetID(PLDMGrid Input, long ID)
        {
            Input._setSelectedID(ID);
            System.Reflection.FieldInfo duyetInfo = Input.GetType().GetField("\a", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (duyetInfo != null) duyetInfo.SetValue(Input, ID);
        }

        public static void SetInfoBoxExt(PLInfoBox Info, long NGUOI_CAP_NHAT, DateTime? NGAY_CAP_NHAT)
        {
            if (NGUOI_CAP_NHAT > 0)
            {
                Info._init(DMFWNhanVien.GetFullName(NGUOI_CAP_NHAT), NGAY_CAP_NHAT.ToString());
                Info.Enabled = true;
            }
            else
            {
                Info.Enabled = false;
            }
        }
        #endregion

        #region PLRichTextBox
        public static void Customizebar_PLRichTextBox(DevExpress.XtraRichEdit.Demos.PLRichTextBox control)
        {
            control.pageSetupBar1.OptionsBar.DrawDragBorder = false;
            control.paragraphBar1.OptionsBar.DrawDragBorder = false;
            control.headerFooterBar1.OptionsBar.DrawDragBorder = false;
            control.headerFooterToolsDesignCloseBar1.OptionsBar.DrawDragBorder = false;
            control.headerFooterToolsDesignNavigationBar1.OptionsBar.DrawDragBorder = false;
            control.headerFooterToolsDesignOptionsBar1.OptionsBar.DrawDragBorder = false;
            control.stylesBar1.OptionsBar.DrawDragBorder = false;
            control.commonBar1.OptionsBar.DrawDragBorder = false;
            control.linksBar1.OptionsBar.DrawDragBorder = false;
            control.fontBar1.OptionsBar.DrawDragBorder = false;
            control.illustrationsBar1.OptionsBar.DrawDragBorder = false;
            control.PrintingRichEditControl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
        }
        #endregion
    }

    
}