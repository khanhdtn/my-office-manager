using System;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Core;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.IO;
using office;
using DAO;


namespace DTO
{
    public class DAQuanLyThucHienNopBai : DAQuanLyThucHien
    {

        #region "Thể hiện ban đầu"
        public static void initQLTH(DevExpress.XtraGrid.Columns.GridColumn cotNhanSu, DOQuanLyThucHien qlThucHien)
        {
            initGrid(cotNhanSu, qlThucHien.gridView, qlThucHien.gridBand);
            reLoadData(long.Parse(qlThucHien.listBTD.GetItemValue(qlThucHien.listBTD.SelectedIndex).ToString()), Convert.ToDateTime(qlThucHien.barTime.EditValue), qlThucHien.gridControl);
        }
        #endregion

        #region "lưới thể hiện quản lý nộp bài"
        private static void initGrid(DevExpress.XtraGrid.Columns.GridColumn cotNhanSu, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView, GridBand gridBandMain)
        {
            clearAllColumn(gridBandMain,cotNhanSu);
            XtraGridSupportExt.IDGridColumn(cotNhanSu, "ID", "TEN_NV", "DM_NHAN_VIEN", "NHAN_SU");
            BandedGridColumn colHanNop = gridView.Columns.Add();
            colHanNop.Caption = "Hạn nộp";
            colHanNop.Visible = true;
            colHanNop.Width = 150;
            colHanNop.OptionsColumn.AllowEdit = false;
            HelpGridColumn.CotPLDate(colHanNop, "HAN_NOP",false);

            BandedGridColumn colNgayNop = gridView.Columns.Add();
            colNgayNop.Caption = "Ngày nộp";
            colNgayNop.Visible = true;
            colNgayNop.Width = 150;
            colNgayNop.OptionsColumn.AllowEdit = false;
            HelpGridColumn.CotPLDate(colNgayNop,"NGAY_NOP",false);

            BandedGridColumn colTaiLieu = gridView.Columns.Add();
            colTaiLieu.Caption = "Tài liệu";
            colTaiLieu.Visible = true;
            colTaiLieu.Width = 150;
            colTaiLieu.OptionsColumn.AllowEdit = false;
            HelpGridColumn.CotTextLeft(colTaiLieu,"TEN_TAI_LIEU");

            gridBandMain.Columns.Add(colHanNop);
            gridBandMain.Columns.Add(colNgayNop);
            gridBandMain.Columns.Add(colTaiLieu);
        }
        #endregion

        #region "load dữ liệu nộp bài"
        public static void reLoadData(long btd_id, DateTime date, GridControl gridControl)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet("select DTD_ID, HAN_NOP, NGAY_NOP, TEN_TAI_LIEU, NHAN_SU from DIEM_THEO_DOI_NOP_BAI where BTD_ID = " + btd_id + " and  HAN_NOP >= '" + date.Month + "/" + date.Day + "/" + date.Year + "'");
            gridControl.DataSource = ds.Tables[0];
        }
        #endregion

        #region "Đăng nhập để nộp bài"
        public static bool dangNhap(DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView, GridControl gridControl,DevExpress.XtraBars.BarEditItem ngayThucHien)
        {
            GridHitInfo gridHitInfo = gridView.CalcHitInfo(gridView.GridControl.PointToClient(Control.MousePosition));
            if (gridHitInfo.InRowCell)
            {
                if (gridHitInfo.Column.FieldName == "TEN_TAI_LIEU")
                {
                    long nhanSu = long.Parse(gridView.GetFocusedRowCellValue(gridView.Columns["NHAN_SU"]).ToString());
                    DataTable dt = (gridControl.DataSource as DataTable);
                    if (checkTimeLogin(Convert.ToDateTime(dt.Rows[gridHitInfo.RowHandle]["HAN_NOP"]), Convert.ToDateTime(ngayThucHien.EditValue)))
                    {
                        frmDangNhap dangNhap = new frmDangNhap();
                        dangNhap.ShowDialog();
                        if (checkLogin(dangNhap.getUserName(), dangNhap.getPassWord(), nhanSu))
                        {
                            long dtd_id = long.Parse(dt.Rows[gridHitInfo.RowHandle]["DTD_ID"].ToString());
                            byte[] bytes = UpData(gridView);
                            if (bytes != null)
                            {
                                updateKetQuaNopBai(dtd_id, Convert.ToDateTime(ngayThucHien.EditValue), dt.Rows[gridHitInfo.RowHandle]["TEN_TAI_LIEU"].ToString(), bytes);
                                HelpMsgBox.ShowNotificationMessage("Cập nhật thành công");
                                return true;
                            }
                            else
                            {
                                HelpMsgBox.ShowNotificationMessage("Cập nhật thất bại");
                                return false;
                            }
                        }
                        else
                        {
                            HelpMsgBox.ShowNotificationMessage("Đăng nhập thất bại");
                            return false;
                        }
                    }
                    else
                    {
                        HelpMsgBox.ShowNotificationMessage("Không thể nộp bài");
                    }
                }
            }
            return false;
        }

        //kiểm tra thời gian hết hạn nộp 
        private static bool checkTimeLogin(DateTime hanNop, DateTime ngayThucHien)
        {
            DateTime hn = Convert.ToDateTime(hanNop.ToShortDateString());
            DateTime nth = Convert.ToDateTime(ngayThucHien.ToShortDateString());
            DateTime ht = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            if (hn < ht) return false;
            if (nth != ht) return false;
            return true;
        }

        #endregion

        #region "Cập nhật nộp bài"
        private static void updateKetQuaNopBai(long dtd_id,DateTime ngayNop,String tenTaiLieu ,byte[] noiDung)
        {
            DatabaseFB db = HelpDB.getDatabase();
            String sqlString = @"update DIEM_THEO_DOI_NOP_BAI set NGAY_NOP = @NGAY_NOP, TEN_TAI_LIEU = @TEN_TAI_LIEU, NOI_DUNG = @NOI_DUNG where DTD_ID = @DTD_ID";
            try
            {
                DbCommand cmd = db.GetSQLStringCommand(sqlString);
                db.AddInParameter(cmd, "@NGAY_NOP", DbType.Date, ngayNop);
                db.AddInParameter(cmd, "@TEN_TAI_LIEU", DbType.String, tenTaiLieu);
                db.AddInParameter(cmd, "@NOI_DUNG", DbType.Binary, noiDung);
                db.AddInParameter(cmd, "@DTD_ID",DbType.Int64,dtd_id);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                HelpMsgBox.ShowNotificationMessage(e.ToString());
            }
        }
        #endregion

        #region "Up load file tài liệu cần nộp "
        private static byte[] UpData(DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView view)
        {
            string path = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn file để cập nhật tài liệu:";
            DialogResult value = openFile.ShowDialog();
            if (value == DialogResult.OK)
            {
                path = openFile.FileName;
                //Kiểm tra độ lớn của file
                if (!HelpFile.CheckFileSize(path, 20))
                {
                    //Độ lớn của file lớn hơn độ lớn qui định
                    HelpMsgBox.ShowNotificationMessage("Bạn không được chọn file lớn hơn 20 MB.");
                    path = null;
                    UpData(view);
                }
            }
            else if (value == DialogResult.Cancel)
            {
                path = null;
                return null;
            }
            if (path != null)
            {
                byte[] bytes = null;
                bytes = HelpFile.FileToBytes(path);
                DataRow row = view.GetDataRow(view.FocusedRowHandle);
                if (row == null) HelpMsgBox.ShowNotificationMessage("Bạn chưa chọn nhân sự, vui lòng vào thông tin nhân sự!");
                else
                {
                    row["TEN_TAI_LIEU"] = Path.GetFileName(path);
                    row["NGAY_NOP"] = DateTime.Now;
                    return bytes;
                }
            }
            return null;
        }
        #endregion

       
    }
}
