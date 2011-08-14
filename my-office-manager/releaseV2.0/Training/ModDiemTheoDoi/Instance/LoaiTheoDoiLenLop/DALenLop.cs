using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using office;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Views.Grid;

namespace office.model
{
    public class DALenLop
    {
        public static DALenLop Instance = new DALenLop();
        private DALenLop() : base() { }

        public GridColumn[] InitColumnsLEN_LOP(GridView gridView)
        {
            XtraGridSupportExt.DateTimeGridColumn(XtraGridSupportExt.CreateGridColumn(gridView, "Ngày lên lớp", 1, 50), "NGAY_LEN_LOP");
            HelpGridColumn.CotPLTimeEdit(XtraGridSupportExt.CreateGridColumn(gridView, "Thời gian bắt đầu", 2, 50), "THOI_GIAN_BAT_DAU");
            HelpGridColumn.CotPLTimeEdit(XtraGridSupportExt.CreateGridColumn(gridView, "Thời gian kết thúc", 3, 50), "THOI_GIAN_KET_THUC");
            XtraGridSupportExt.IDGridColumn(XtraGridSupportExt.CreateGridColumn(gridView, "Người giao", 4, 50), "ID", "TEN_NV", "DM_NHAN_VIEN", "NGUOI_GIAO");
            HelpGridColumn.CotPLDate(XtraGridSupportExt.CreateGridColumn(gridView, "Ngày giao", 5, 50), "NGAY_GIAO", true);
            XtraGridSupportExt.TextLeftColumn(XtraGridSupportExt.CreateGridColumn(gridView, "Ghi chú", 6, 50), "GHI_CHU");
            HelpGridColumn.CotPLHienThi(XtraGridSupportExt.CreateGridColumn(gridView, "Thông báo", 7, 50), "THONG_BAO");

            GridColumn CotNguoiCapNhat = XtraGridSupportExt.CreateGridColumn(gridView, "Người cập nhật", 10, 50);
            CotNguoiCapNhat.OptionsColumn.AllowEdit = false;
            XtraGridSupportExt.IDGridColumn(CotNguoiCapNhat, "ID", "TEN_NV", "DM_NHAN_VIEN", "NGUOI_CAP_NHAT");

            GridColumn CotNgayCapNhat = XtraGridSupportExt.CreateGridColumn(gridView, "Ngày cập nhật", 11, 50);
            CotNgayCapNhat.OptionsColumn.AllowEdit = false;
            HelpGridColumn.CotPLDate(CotNgayCapNhat, "NGAY_CAP_NHAT", true);
            gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            return null;
        }
        public bool CheckDuplicateDIEM_THEO_DOI_LEN_LOP(GridView grid, DataSet gridDataSet, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow dataRow = grid.GetDataRow(e.RowHandle);
            if (Convert.ToDateTime(dataRow[2]).TimeOfDay > Convert.ToDateTime(dataRow[3]).TimeOfDay)
            {
                grid.SetColumnError(grid.Columns[2], "Thời gian bắt đầu lớn hơn thời gian kết thúc");
                e.Valid = false;
                return false;
            }
            for (int i = 0; i < gridDataSet.Tables[0].Rows.Count; i++)
            {
                if (long.Parse(dataRow[4].ToString()) == long.Parse(gridDataSet.Tables[0].Rows[i][4].ToString()))
                    if (Convert.ToDateTime(dataRow[1]) == Convert.ToDateTime(gridDataSet.Tables[0].Rows[i][1]))
                    {
                        if ((Convert.ToDateTime(dataRow[2]).TimeOfDay > Convert.ToDateTime(gridDataSet.Tables[0].Rows[i][2]).TimeOfDay) && (Convert.ToDateTime(dataRow[2]).TimeOfDay < Convert.ToDateTime(gridDataSet.Tables[0].Rows[i][3]).TimeOfDay))
                        {
                            grid.SetColumnError(grid.Columns[2], "Thời gian không hợp lý");
                            e.Valid = false;
                            return false;
                        }
                        if ((Convert.ToDateTime(dataRow[3]).TimeOfDay > Convert.ToDateTime(gridDataSet.Tables[0].Rows[i][2]).TimeOfDay) && (Convert.ToDateTime(dataRow[3]).TimeOfDay < Convert.ToDateTime(gridDataSet.Tables[0].Rows[i][3]).TimeOfDay))
                        {
                            grid.SetColumnError(grid.Columns[3], "Thời gian không hợp lý");
                            e.Valid = false;
                            return false;
                        }
                        if ((Convert.ToDateTime(dataRow[2]).TimeOfDay < Convert.ToDateTime(gridDataSet.Tables[0].Rows[i][2]).TimeOfDay) && (Convert.ToDateTime(dataRow[3]).TimeOfDay > Convert.ToDateTime(gridDataSet.Tables[0].Rows[i][3]).TimeOfDay))
                        {
                            grid.SetColumnError(grid.Columns[2], "Thời gian không hợp lý");
                            e.Valid = false;
                            return false;
                        }
                    }
            }
            return true;
        }
        public FieldNameCheck[] DIEM_THEO_DOI_LEN_LOP()
        {
            return new FieldNameCheck[] { 
                    new FieldNameCheck("NHAN_SU",
                        new CheckType[]{ CheckType.RequiredID },
                        new string[]{ ErrorMsgLib.errorRequired("Nhân sự")}, 
                        new object[]{ }),
                    new FieldNameCheck("NGAY_LEN_LOP",
                        new CheckType[]{ CheckType.RequireDate },
                        new string[]{ ErrorMsgLib.errorRequired("Ngày lên lớp")}, 
                        new object[]{ }),
                    new FieldNameCheck("THOI_GIAN_BAT_DAU",
                        new CheckType[]{ CheckType.RequireDate },
                        new string[]{ ErrorMsgLib.errorRequired("Thời gian bắt đầu")}, 
                        new object[]{ }),
                    new FieldNameCheck("THOI_GIAN_KET_THUC",
                        new CheckType[]{ CheckType.RequireDate },
                        new string[]{ ErrorMsgLib.errorRequired("Thời gian kết thúc")}, 
                        new object[]{ }),
                    new FieldNameCheck("NGUOI_GIAO",
                        new CheckType[]{ CheckType.RequiredID },
                        new string[]{ ErrorMsgLib.errorRequired("Người giao")}, 
                        new object[]{ }),
                    new FieldNameCheck("NGAY_GIAO",
                        new CheckType[]{ CheckType.RequireDate },
                        new string[]{ ErrorMsgLib.errorRequired("Ngày giao")}, 
                        new object[]{ })
                };
        }

        public void SaveLen_Lop(DataSet ds_DTDLL, GridControl gridControl1, long btd_id)
        {
            DOLenLop lenlop = new DOLenLop();
            DataTable dt_temp = DALenLop.loadDTDLL(btd_id).Tables[0];
            int i = 0;
            foreach (DataRow dr in (gridControl1.DataSource as DataTable).Rows)
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    lenlop = new DOLenLop(long.Parse(dr[0].ToString()), Convert.ToDateTime(dr[1]), Convert.ToDateTime(dr[2]), Convert.ToDateTime(dr[3]), long.Parse(dr[4].ToString()), long.Parse(dr[5].ToString()), Convert.ToDateTime(dr[6]), dr[7].ToString(), dr[8].ToString(), long.Parse(dr[9].ToString()), long.Parse(dr[10].ToString()), long.Parse(dr[11].ToString()), Convert.ToDateTime(dr[12]));
                    DALenLop.updateDTDLL(lenlop);
                }
                if (dr.RowState == DataRowState.Added)
                {
                    lenlop = new DOLenLop(long.Parse(HelpGen.ID("G_NGHIEP_VU").ToString()), Convert.ToDateTime(dr[1]), Convert.ToDateTime(dr[2]), Convert.ToDateTime(dr[3]), long.Parse(dr[4].ToString()), long.Parse(dr[5].ToString()), Convert.ToDateTime(dr[6]), dr[7].ToString(), dr[8].ToString(), long.Parse(dr[9].ToString()), long.Parse(dr[10].ToString()), long.Parse(dr[11].ToString()), Convert.ToDateTime(dr[12]));
                    DALenLop.insertDTD(lenlop);
                }
                if (dr.RowState == DataRowState.Deleted)
                    DALenLop.xoaDTDLL(long.Parse((dt_temp.Rows[i][0]).ToString()));
                i++;
            }
            ds_DTDLL = DALenLop.loadDTDLL(btd_id);
        }

        #region ------------cập nhật dữ liệu-------------

        //thêm 1 điểm theo dỏi lên lớp
        public static void insertDTD(DOLenLop lenlop)
        {
            String sqlString = @"insert into DIEM_THEO_DOI_LEN_LOP(DTD_ID,NGAY_LEN_LOP,THOI_GIAN_BAT_DAU,THOI_GIAN_KET_THUC,NHAN_SU,NGUOI_GIAO,NGAY_GIAO,GHI_CHU,THONG_BAO,BTD_ID,LCV_ID,NGUOI_CAP_NHAT,NGAY_CAP_NHAT) values(@DTD_ID,@NGAY_LEN_LOP,@THOI_GIAN_BAT_DAU,@THOI_GIAN_KET_THUC,@NHAN_SU,@NGUOI_GIAO,@NGAY_GIAO,@GHI_CHU,@THONG_BAO,@BTD_ID,@LCV_ID,@NGUOI_CAP_NHAT,@NGAY_CAP_NHAT)";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sqlString);
            db.AddInParameter(cmd, "@DTD_ID", DbType.Int64, lenlop.DTD_ID);
            db.AddInParameter(cmd, "@NGAY_LEN_LOP", DbType.DateTime, lenlop.NGAY_LEN_LOP);
            db.AddInParameter(cmd, "@THOI_GIAN_BAT_DAU", DbType.Time, lenlop.THOI_GIAN_BAT_DAU);
            db.AddInParameter(cmd, "@THOI_GIAN_KET_THUC", DbType.Time, lenlop.THOI_GIAN_KET_THUC);
            db.AddInParameter(cmd, "@NHAN_SU", DbType.Int64, lenlop.NHAN_SU);
            db.AddInParameter(cmd, "@NGUOI_GIAO", DbType.Int64, lenlop.NGUOI_GIAO);
            db.AddInParameter(cmd, "@NGAY_GIAO", DbType.Date, lenlop.NGAY_GIAO);
            db.AddInParameter(cmd, "@GHI_CHU", DbType.String, lenlop.GHI_CHU);
            db.AddInParameter(cmd, "@THONG_BAO", DbType.String, lenlop.THONG_BAO);
            db.AddInParameter(cmd, "@BTD_ID", DbType.Int64, lenlop.BTD_ID);
            db.AddInParameter(cmd, "@LCV_ID", DbType.Int64, lenlop.LCV_ID);
            db.AddInParameter(cmd, "@NGUOI_CAP_NHAT", DbType.Int64, lenlop.NGUOI_CAP_NHAT);
            db.AddInParameter(cmd, "@NGAY_CAP_NHAT", DbType.Date, lenlop.NGAY_CAP_NHAT);
            db.ExecuteNonQuery(cmd);
        }

        // update 1 diểm theo doi lên lớp
        public static void updateDTDLL(DOLenLop lenlop)
        {
            String sqlString = @"update DIEM_THEO_DOI_LEN_LOP set NGAY_LEN_LOP = @NGAY_LEN_LOP,THOI_GIAN_BAT_DAU = @THOI_GIAN_BAT_DAU,THOI_GIAN_KET_THUC = @THOI_GIAN_KET_THUC, NHAN_SU = @NHAN_SU,NGUOI_GIAO = @NGUOI_GIAO,NGAY_GIAO = @NGAY_GIAO,GHI_CHU = @GHI_CHU,THONG_BAO = @THONG_BAO,BTD_ID = @BTD_ID,LCV_ID = @LCV_ID,NGUOI_CAP_NHAT = @NGUOI_CAP_NHAT,NGAY_CAP_NHAT = @NGAY_CAP_NHAT WHERE DTD_ID = @DTD_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sqlString);
            db.AddInParameter(cmd, "@NGAY_LEN_LOP", DbType.DateTime, lenlop.NGAY_LEN_LOP);
            db.AddInParameter(cmd, "@THOI_GIAN_BAT_DAU", DbType.Time, lenlop.THOI_GIAN_BAT_DAU);
            db.AddInParameter(cmd, "@THOI_GIAN_KET_THUC", DbType.Time, lenlop.THOI_GIAN_KET_THUC);
            db.AddInParameter(cmd, "@NHAN_SU", DbType.Int64, lenlop.NHAN_SU);
            db.AddInParameter(cmd, "@NGUOI_GIAO", DbType.Int64, lenlop.NGUOI_GIAO);
            db.AddInParameter(cmd, "@NGAY_GIAO", DbType.Date, lenlop.NGAY_GIAO);
            db.AddInParameter(cmd, "@GHI_CHU", DbType.String, lenlop.GHI_CHU);
            db.AddInParameter(cmd, "@THONG_BAO", DbType.String, lenlop.THONG_BAO);
            db.AddInParameter(cmd, "@BTD_ID", DbType.Int64, lenlop.BTD_ID);
            db.AddInParameter(cmd, "@LCV_ID", DbType.Int64, lenlop.LCV_ID);
            db.AddInParameter(cmd, "@NGUOI_CAP_NHAT", DbType.Int64, lenlop.NGUOI_CAP_NHAT);
            db.AddInParameter(cmd, "@NGAY_CAP_NHAT", DbType.Date, lenlop.NGAY_CAP_NHAT);
            db.AddInParameter(cmd, "@DTD_ID", DbType.Int64, lenlop.DTD_ID);
            db.ExecuteNonQuery(cmd);
        }

        //Xóa 1 dòng trong bảng điểm theo dỏi lên lớp
        public static void xoaDTDLL(long id)
        {
            String sqlString = @"delete from DIEM_THEO_DOI_LEN_LOP where DTD_ID = @DTD_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sqlString);
            db.AddInParameter(cmd, "@DTD_ID", DbType.Int64, id);
            db.ExecuteNonQuery(cmd);
        }
        #endregion

        #region -----------load dử liệu--------------
        public static DataSet loadDTDLL(long btd_id)
        {
            DataSet ds;
            ds = DABase.getDatabase().LoadDataSet("select DTD_ID,NGAY_LEN_LOP,THOI_GIAN_BAT_DAU,THOI_GIAN_KET_THUC,NHAN_SU,NGUOI_GIAO,NGAY_GIAO,GHI_CHU,THONG_BAO,BTD_ID, LCV_ID, NGUOI_CAP_NHAT, NGAY_CAP_NHAT from DIEM_THEO_DOI_LEN_LOP where BTD_ID = " + btd_id);
            return ds;
        }
        #endregion
    }
}