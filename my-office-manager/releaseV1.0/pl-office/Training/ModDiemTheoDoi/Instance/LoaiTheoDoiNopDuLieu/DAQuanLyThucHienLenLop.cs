using System;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data;
using System.Data.Common;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DTO;
using office;


namespace DAO
{
    public class DAQuanLyThucHienLenLop : DAQuanLyThucHien
    {
        #region "thể hiện ban đầu"

        public static void initQLTH(DevExpress.XtraGrid.Columns.GridColumn cotNhanSu, DOQuanLyThucHien qlThucHien)
        {
           
            initGrid(cotNhanSu, qlThucHien.gridView, qlThucHien.gridBand);
            reLoadData(long.Parse(qlThucHien.listBTD.GetItemValue(qlThucHien.listBTD.SelectedIndex).ToString()), Convert.ToDateTime(qlThucHien.barTime.EditValue), qlThucHien.gridControl);
        }
        #endregion
        #region "lưới thể hiện quản lý lên lớp"
        private static void initGrid(DevExpress.XtraGrid.Columns.GridColumn cotNhanSu, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView, GridBand gridBandMain)
        {
            clearAllColumn(gridBandMain,cotNhanSu);
            XtraGridSupportExt.IDGridColumn(cotNhanSu, "ID", "TEN_NV", "DM_NHAN_VIEN", "NHAN_SU");
            BandedGridColumn colThoiGianBatDau = gridView.Columns.Add();
            colThoiGianBatDau.Caption = "Thời gian bắt đầu";
            colThoiGianBatDau.Visible = true;
            colThoiGianBatDau.Width = 150;
            colThoiGianBatDau.OptionsColumn.AllowEdit = false;
            HelpGridColumn.CotPLTimeEdit(colThoiGianBatDau, "THOI_GIAN_BAT_DAU");

            BandedGridColumn colThoiGianKetThuc = gridView.Columns.Add();
            colThoiGianKetThuc.Caption = "Thời gian kết thúc";
            colThoiGianKetThuc.Visible = true;
            colThoiGianKetThuc.Width = 150;
            colThoiGianKetThuc.OptionsColumn.AllowEdit = false;
            HelpGridColumn.CotPLTimeEdit(colThoiGianKetThuc, "THOI_GIAN_KET_THUC");

            BandedGridColumn colDanhGia = gridView.Columns.Add();
            colDanhGia.Caption = "Đánh giá";
            colDanhGia.FieldName = "DANH_GIA";
            colDanhGia.Visible = true;
            colDanhGia.Width = 150;
            colDanhGia.OptionsColumn.AllowEdit = false;

            gridBandMain.Columns.Add(colThoiGianBatDau);
            gridBandMain.Columns.Add(colThoiGianKetThuc);
            gridBandMain.Columns.Add(colDanhGia);
        }
        #endregion
        #region "Load dữ liệu"
        public static void reLoadData(long btd_id, DateTime date, GridControl gridControl)
        {
            DataSet ds = DABase.getDatabase().LoadDataSet("select DTD_ID, NHAN_SU, NGAY_LEN_LOP, THOI_GIAN_BAT_DAU, THOI_GIAN_KET_THUC, iif(THUC_HIEN is NULL,0,THUC_HIEN) as THUC_HIEN, iif(DANH_GIA is NULL,'',DANH_GIA) as DANH_GIA  from DIEM_THEO_DOI_LEN_LOP where(BTD_ID = " + btd_id + " and NGAY_LEN_LOP = '" + date.Month + "/" + date.Day + "/" + date.Year + "')");
            gridControl.DataSource = ds.Tables[0];
        }
        #endregion
        /* 
        #region "Thay đổi lưới thể hiện tùy theo ngày (Lên Lớp)"
        //tạo lưới thể hiện
        public static void initGrid(long btd_id, DateTime date, DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView, GridBand gridBandMain)
        {
            removeColOfGridBand(gridBandMain);
            int socot = maxCot(btd_id,date);
            int width = 0;
            if (socot > 0)
            {
                width = (gridBandMain.Width - 150) / socot - 2;
                GridBand[] gridband = new GridBand[socot+1];
                gridband[0] = new GridBand();
                gridband[0].Caption = "Nhân sự";
                gridband[0].Width = 150;
                BandedGridColumn col = gridView.Columns.Add();
                col.Caption = "";
                col.Visible = true;
                col.Width = 150;
                gridband[0].Columns.Add(col);
                for (int i = 1; i <= socot; i++)
                {
                    gridband[i] = new GridBand();
                    gridband[i].Width = width;
                    gridband[i].Caption = "Lần " + (i).ToString();

                    BandedGridColumn col1 = gridView.Columns.Add();
                    BandedGridColumn col2 = gridView.Columns.Add();
                    col1.Caption = "Bắt đầu";
                    col2.Caption = "Kết thúc";
                    col1.Width = width / 2;
                    col1.Visible = true;
                    col2.Width = width / 2;
                    col2.Visible = true;
                    gridband[i].Columns.Add(col1);
                    gridband[i].Columns.Add(col2);
                }
                gridBandMain.Children.AddRange(gridband);
            }
            
        }

        public static void removeColOfGridBand(GridBand gridBand)
        {
            int size = gridBand.Width;
            for (int i = gridBand.Children.Count-1; i >= 0 ; i--)
                gridBand.Children.RemoveAt(i);
            gridBand.Width = size;
        }

        //số lần lên lớp nhiều nhất trong ngày
        public static int maxCot(long btd_id, DateTime date)
        {
            String sqlString = "select count(THOI_GIAN_BAT_DAU) as SO_DONG from diem_theo_doi_len_lop where (BTD_ID = " + btd_id + " and NGAY_LEN_LOP = '" + date.Month + "/" + date.Day + "/" + date.Year + "') group by NHAN_SU";
            DataTable dt = DABase.getDatabase().LoadDataSet(sqlString).Tables[0];
            int max = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (int.Parse(dr["SO_DONG"].ToString()) > max)
                    max = int.Parse(dr["SO_DONG"].ToString());
            }
            return max;
        }
        #endregion
        */
        #region "Đăng nhập lên lớp và kết thúc"
        public static bool dangNhap(DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView gridView, GridControl gridControl1)
        {
            //vị trí click trên gridview
            GridHitInfo gHitInfo = gridView.CalcHitInfo(gridView.GridControl.PointToClient(Control.MousePosition));
            if (gHitInfo.InRowCell) //nếu vị trí click là ceel trong row
            {
                if (gHitInfo.Column.FieldName == "THOI_GIAN_BAT_DAU")
                {
                    long nhanSu = long.Parse(gridView.GetFocusedRowCellValue(gridView.Columns["NHAN_SU"]).ToString());
                    DataTable dt = (gridControl1.DataSource as DataTable);
                    if (checkTimeLogin(Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["NGAY_LEN_LOP"].ToString()), Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["THOI_GIAN_BAT_DAU"].ToString()), Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["THOI_GIAN_KET_THUC"].ToString()), true, int.Parse(dt.Rows[gHitInfo.RowHandle]["THUC_HIEN"].ToString())))
                    {
                        frmDangNhap dangNhap = new frmDangNhap();
                        dangNhap.ShowDialog();

                        if (checkLogin(dangNhap.getUserName(), dangNhap.getPassWord(), nhanSu))
                        {
                            long dtd_id = long.Parse(dt.Rows[gHitInfo.RowHandle]["DTD_ID"].ToString());
                            updateKetQuaLenLop(dtd_id, 1, danhGiaThucHienLenLop(Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["THOI_GIAN_BAT_DAU"].ToString()), Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["THOI_GIAN_KET_THUC"].ToString()), true, dt.Rows[gHitInfo.RowHandle]["DANH_GIA"].ToString()));
                            HelpMsgBox.ShowNotificationMessage("Thông tin cập nhật thành công ");
                            return true;
                        }
                        else
                        {
                            HelpMsgBox.ShowNotificationMessage("Đăng nhập thất bại");
                            return false;
                        }
                    }
                    else
                    {
                        HelpMsgBox.ShowNotificationMessage("Không thể cập nhật");
                        return false;
                    }
                }
                if (gHitInfo.Column.FieldName == "THOI_GIAN_KET_THUC")
                {
                    long nhanSu = long.Parse(gridView.GetFocusedRowCellValue(gridView.Columns["NHAN_SU"]).ToString());
                    DataTable dt = (gridControl1.DataSource as DataTable);
                    if (checkTimeLogin(Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["NGAY_LEN_LOP"].ToString()), Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["THOI_GIAN_BAT_DAU"].ToString()), Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["THOI_GIAN_KET_THUC"].ToString()), false, int.Parse(dt.Rows[gHitInfo.RowHandle]["THUC_HIEN"].ToString())))
                    {
                        frmDangNhap dangNhap = new frmDangNhap();
                        dangNhap.ShowDialog();
                        if (checkLogin(dangNhap.getUserName(), dangNhap.getPassWord(), nhanSu))
                        {
                            long dtd_id = long.Parse(dt.Rows[gHitInfo.RowHandle]["DTD_ID"].ToString());

                            updateKetQuaLenLop(dtd_id, 2, danhGiaThucHienLenLop(Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["THOI_GIAN_BAT_DAU"].ToString()), Convert.ToDateTime(dt.Rows[gHitInfo.RowHandle]["THOI_GIAN_KET_THUC"].ToString()), false, dt.Rows[gHitInfo.RowHandle]["DANH_GIA"].ToString()));
                            HelpMsgBox.ShowNotificationMessage("Thông tin cập nhật thành công");
                            return true;
                        }
                        else
                        {
                            HelpMsgBox.ShowNotificationMessage("Đăng nhập thất bại");
                            return false;
                        }
                    }
                    else
                    {
                        HelpMsgBox.ShowNotificationMessage("Không thể cập nhật");
                        return false;
                    }
                }
            }
            return false;
        }

        //kiểm tra tính hợp lệ khi đăng nhập....trangthai(true : bắt đầu -----false : kết thúc) 
        private static bool checkTimeLogin(DateTime ngayThucHien, DateTime thoiGianBD, DateTime thoiGianKT, bool trangThai, int thucHien)
        {
            DateTime bd = Convert.ToDateTime(thoiGianBD.ToShortTimeString());
            DateTime kt = Convert.ToDateTime(thoiGianKT.ToShortTimeString());
            DateTime ht = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            DateTime ngayTH = Convert.ToDateTime(ngayThucHien.ToShortDateString());
            DateTime ngayHT = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            if (ngayTH != ngayHT) return false;

            if (trangThai)
            {
                if (ht >= kt) return false;
                if ((thucHien == 1) || (thucHien == 2)) return false;
            }
            else
            {
                if (ht <= bd) return false;
                if (thucHien != 1) return false;
            }
            return true;
        }

        #endregion
        #region "Đánh giá thực hiện lên lớp"
        //chuổi đáng giá...trangthai(true : bắt đầu -----false : kết thúc) 
        private static String danhGiaThucHienLenLop(DateTime thoiGianBatDau, DateTime thoiGianKetThuc, bool trangThai, String danhGiaHienTai)
        {
            if (trangThai)
            {
                DateTime thoiGianBD = Convert.ToDateTime(thoiGianBatDau.ToShortTimeString());
                DateTime thoiGianHT = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                if (thoiGianHT > thoiGianBD)
                {
                    int chenhLechTGBD = (thoiGianHT.Hour - thoiGianBD.Hour) * 60 + (thoiGianHT.Minute - thoiGianBD.Minute);
                    return danhGiaHienTai + "Tới trễ " + chenhLechTGBD.ToString() + " phút";
                }
                return danhGiaHienTai + "Tới đúng giờ";
            }
            else
            {
                DateTime thoiGianKT = Convert.ToDateTime(thoiGianKetThuc.ToShortTimeString());
                DateTime thoiGianHT = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                if (thoiGianHT < thoiGianKT)
                {
                    int chenhLechTGKT = (thoiGianKT.Hour - thoiGianHT.Hour) * 60 + (thoiGianKT.Minute - thoiGianHT.Minute);
                    return danhGiaHienTai + "- Về sớm " + chenhLechTGKT.ToString() + " phút";
                }
                return danhGiaHienTai + " - Về đúng giời";
            }
        }
        #endregion

        #region "Cập nhật lên lớp"
        private static void updateKetQuaLenLop(long dtd_id, int thucHien, String danhGia)//Update kết quả lên lớp
        {
            String sqlString = @"update DIEM_THEO_DOI_LEN_LOP set THUC_HIEN = @THUC_HIEN, DANH_GIA = @DANH_GIA where DTD_ID = @DTD_ID";
            try
            {
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sqlString);
                db.AddInParameter(cmd, "@THUC_HIEN", DbType.Int16, thucHien);
                db.AddInParameter(cmd, "@DANH_GIA", DbType.String, danhGia);
                db.AddInParameter(cmd, "@DTD_ID", DbType.Int64, dtd_id);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        #endregion
    }
}
