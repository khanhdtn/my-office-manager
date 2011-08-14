using System;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using System.Windows.Forms;
using System.Data;
using ProtocolVN.Framework.Win;
using System.Data.Common;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DTO;
using pl.office;
using office.model;
namespace DAO
{
    public class DABangTheoDoi 
    {
        public string KEY_FIELD_NAME = "BTD_ID";
        public object[] FIELD_MAP = new object[] {             
				"BTD_ID", null,	
				"MA_BTD", null,	
                "NAME", null,	
				"NGUOI_LAP", new IDConverter(),	
				"NGAY_LAP", null,
                "NGUOI_KY", new IDConverter(),	
				"NGAY_KY", null,
                "NGUOI_QUAN_LY", new IDConverter(),	
				"NGAY_HIEU_LUC", null,
                "TAI_LIEU", new IDConverter(),
	            "TEN_TAI_LIEU", null,	
				"TINH_TRANG", new IDConverter(),
                "HINH_THUC_THONG_BAO", null,	
				"GHI_CHU", null,
                "NGUOI_CAP_NHAT", new IDConverter(),	
				"NGAY_CAP_NHAT", null,
        };

        public static DABangTheoDoi Instance = new DABangTheoDoi();
        public DABangTheoDoi() : base() { }
        public DABangTheoDoi(string key_field_name, object[] field_map)
        {
            this.KEY_FIELD_NAME = key_field_name;
            this.FIELD_MAP = field_map;
        }
        public bool ValidateDetail(System.Data.DataRow row, string tableName)
        {
            return GUIValidation.ValidateRow(null, row, PLValidation.GetRule(tableName));
        }

        public DOBangTheoDoi LoadAll(long IDKey, string tableName)
        {
            DOBangTheoDoi doBangTheoDoi = Load(IDKey);
            DataTable tableArrayDTD = HelpDB.getDatabase().LoadDataSet(@"SELECT r.RDB$RELATION_NAME
                                                                        FROM RDB$RELATIONS r
                                                                        WHERE r.RDB$RELATION_NAME like 'DIEM_THEO_DOI%'").Tables[0];
            if(tableName == null && tableArrayDTD.Rows.Count > 0)
                doBangTheoDoi.DetailDataSet = FWDBService.LoadDataSet(tableArrayDTD.Rows[0][0].ToString(), KEY_FIELD_NAME, IDKey);
            else if(tableName != null)
                doBangTheoDoi.DetailDataSet = DatabaseFB.LoadDataSet(tableName, KEY_FIELD_NAME, IDKey);
            
            return doBangTheoDoi;
        }
        public DOBangTheoDoi Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("BANG_THEO_DOI", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOBangTheoDoi data = new DOBangTheoDoi(HelpNumber.ParseInt64(reader[KEY_FIELD_NAME].ToString()),
                                                             reader["MA_BTD"].ToString(),
                                                             reader["NAME"].ToString(),
                                                             Convert.ToDateTime(reader["NGAY_LAP"].ToString()),
                                                             HelpNumber.ParseInt64(reader["NGUOI_LAP"].ToString()),
                                                             Convert.ToDateTime(reader["NGAY_KY"].ToString()),
                                                             HelpNumber.ParseInt64(reader["NGUOI_KY"].ToString()),
                                                             Convert.ToDateTime(reader["NGAY_HIEU_LUC"].ToString()),
                                                             HelpNumber.ParseInt64(reader["NGUOI_QUAN_LY"].ToString()),
                                                             (reader["TAI_LIEU"].ToString() == "" ? null : (byte[])reader["TAI_LIEU"]),
                                                             reader["TEN_TAI_LIEU"].ToString(),
                                                             HelpNumber.ParseInt64(reader["TINH_TRANG"].ToString()),
                                                             HelpNumber.ParseInt32(reader["HINH_THUC_THONG_BAO"].ToString()),
                                                             reader["GHI_CHU"].ToString(),
                                                             HelpNumber.ParseInt64(reader["NGUOI_CAP_NHAT"].ToString()),
                                                             Convert.ToDateTime(reader["NGAY_CAP_NHAT"].ToString()));
                    return data;
                }
            }
            return new DOBangTheoDoi();
        }
        public static void ColseForm(XtraForm frm, bool? info)
        {
            if (info == true) frm.Tag = "Q";
            frm.Close();
        }
        public static void ColseForm(XtraForm frm, bool? isAdd, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (frm.Tag != null && frm.Tag.Equals("Q")) { e.Cancel = false; return; }
            if (isAdd == null) { e.Cancel = false; return; }
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes) e.Cancel = false;
            else e.Cancel = true;
        }
        public void gridView_Click(GridHitInfo gHitInfo, GridView view, bool? IsAdd, DataSet GridDataSet, string tableName)
        {
            if (tableName == "DIEM_THEO_DOI_NOP_BAI")
                DANopBai.Instance.processTEN_TAI_LIEU(gHitInfo, view, IsAdd, GridDataSet);
        }
        
        public bool? saveData(DataSet GridDataSet, DOBangTheoDoi doBangTheoDoi, bool? isAdd)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cmd = null;
            try
            {
                if (isAdd == true)
                    insert(cmd, dbTrans, db, doBangTheoDoi);
                else
                    update(cmd, dbTrans, db, doBangTheoDoi);
                if (GridDataSet.GetChanges() != null)
                    db.UpdateDataSet(GridDataSet, dbTrans);
                db.CommitTransaction(dbTrans);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                db.RollbackTransaction(dbTrans);
                return false;
            }
            return true;
        }
        public void insert(DbCommand cmd, DbTransaction dbTrans, DatabaseFB db, DOBangTheoDoi doBangTheoDoi)
        {
            cmd = db.GetSQLStringCommand("insert into BANG_THEO_DOI(btd_id,ma_btd,name,ngay_lap,nguoi_lap,ngay_ky,nguoi_ky,ngay_hieu_luc,nguoi_quan_ly,tai_lieu,ten_tai_lieu,tinh_trang,hinh_thuc_thong_bao,ghi_chu,nguoi_cap_nhat,ngay_cap_nhat) "
                                            + "values(@btd_id,@ma_btd,@name,@ngay_lap,@nguoi_lap,@ngay_ky,@nguoi_ky,@ngay_hieu_luc,@nguoi_quan_ly,@tai_lieu,@ten_tai_lieu,@tinh_trang,@hinh_thuc_thong_bao,@ghi_chu,@nguoi_cap_nhat,@ngay_cap_nhat)");
            db.AddInParameter(cmd, "@btd_id", DbType.Int64, doBangTheoDoi.BTD_ID);
            db.AddInParameter(cmd, "@ma_btd", DbType.String, doBangTheoDoi.MA_BTD);
            db.AddInParameter(cmd, "@name", DbType.String, doBangTheoDoi.NAME);
            db.AddInParameter(cmd, "@ngay_lap", DbType.DateTime, doBangTheoDoi.NGAY_LAP);
            db.AddInParameter(cmd, "@nguoi_lap", DbType.Int64, doBangTheoDoi.NGUOI_LAP);
            db.AddInParameter(cmd, "@ngay_ky", DbType.DateTime, doBangTheoDoi.NGAY_KY);
            db.AddInParameter(cmd, "@nguoi_ky", DbType.Int64, doBangTheoDoi.NGUOI_KY);
            db.AddInParameter(cmd, "@ngay_hieu_luc", DbType.DateTime, doBangTheoDoi.NGAY_HIEU_LUC);
            db.AddInParameter(cmd, "@nguoi_quan_ly", DbType.Int64, doBangTheoDoi.NGUOI_QUAN_LY);
            db.AddInParameter(cmd, "@tai_lieu", DbType.Binary, doBangTheoDoi.TAI_LIEU);
            db.AddInParameter(cmd, "@ten_tai_lieu", DbType.String, doBangTheoDoi.TEN_TAI_LIEU);
            db.AddInParameter(cmd, "@tinh_trang", DbType.Int64, doBangTheoDoi.TINH_TRANG);
            db.AddInParameter(cmd, "@hinh_thuc_thong_bao", DbType.Int32, doBangTheoDoi.HINH_THUC_THONG_BAO); 
            db.AddInParameter(cmd, "@ghi_chu", DbType.String, doBangTheoDoi.GHI_CHU);
            db.AddInParameter(cmd, "@nguoi_cap_nhat", DbType.Int64, doBangTheoDoi.NGUOI_CAP_NHAT);
            db.AddInParameter(cmd, "@ngay_cap_nhat", DbType.DateTime, doBangTheoDoi.NGAY_CAP_NHAT);
            int result2 = db.ExecuteNonQuery(cmd, dbTrans);
        }
        public void update(DbCommand cmd, DbTransaction dbTrans, DatabaseFB db, DOBangTheoDoi doBangTheoDoi)
        {
            cmd = db.GetSQLStringCommand("update BANG_THEO_DOI set name=@name,ngay_lap=@ngay_lap,nguoi_lap=@nguoi_lap,ngay_ky=@ngay_ky,nguoi_ky=@nguoi_ky,ngay_hieu_luc=@ngay_hieu_luc,nguoi_quan_ly=@nguoi_quan_ly,tai_lieu=@tai_lieu,ten_tai_lieu=@ten_tai_lieu,tinh_trang=@tinh_trang,hinh_thuc_thong_bao=@hinh_thuc_thong_bao,ghi_chu=@ghi_chu,nguoi_cap_nhat=@nguoi_cap_nhat,ngay_cap_nhat=@ngay_cap_nhat "
                                            + "where btd_id=@btd_id" );
            db.AddInParameter(cmd, "@btd_id", DbType.Int64, doBangTheoDoi.BTD_ID);
            db.AddInParameter(cmd, "@name", DbType.String, doBangTheoDoi.NAME);
            db.AddInParameter(cmd, "@ngay_lap", DbType.DateTime, doBangTheoDoi.NGAY_LAP);
            db.AddInParameter(cmd, "@nguoi_lap", DbType.Int64, doBangTheoDoi.NGUOI_LAP);
            db.AddInParameter(cmd, "@ngay_ky", DbType.DateTime, doBangTheoDoi.NGAY_KY);
            db.AddInParameter(cmd, "@nguoi_ky", DbType.Int64, doBangTheoDoi.NGUOI_KY);
            db.AddInParameter(cmd, "@ngay_hieu_luc", DbType.DateTime, doBangTheoDoi.NGAY_HIEU_LUC);
            db.AddInParameter(cmd, "@nguoi_quan_ly", DbType.Int64, doBangTheoDoi.NGUOI_QUAN_LY);
            db.AddInParameter(cmd, "@tai_lieu", DbType.Binary, doBangTheoDoi.TAI_LIEU);
            db.AddInParameter(cmd, "@ten_tai_lieu", DbType.String, doBangTheoDoi.TEN_TAI_LIEU);
            db.AddInParameter(cmd, "@tinh_trang", DbType.Int64, doBangTheoDoi.TINH_TRANG);
            db.AddInParameter(cmd, "@hinh_thuc_thong_bao", DbType.Int32, doBangTheoDoi.HINH_THUC_THONG_BAO);
            db.AddInParameter(cmd, "@ghi_chu", DbType.String, doBangTheoDoi.GHI_CHU);
            db.AddInParameter(cmd, "@nguoi_cap_nhat", DbType.Int64, doBangTheoDoi.NGUOI_CAP_NHAT);
            db.AddInParameter(cmd, "@ngay_cap_nhat", DbType.DateTime, doBangTheoDoi.NGAY_CAP_NHAT);
            int result2 = db.ExecuteNonQuery(cmd, dbTrans);
        }
        public bool Delete(long IDKey)
        {
            bool flag = false;
            DataTable tableArrayDTD = HelpDB.getDatabase().LoadDataSet(@"SELECT r.RDB$RELATION_NAME
                                                                        FROM RDB$RELATIONS r
                                                                        WHERE r.RDB$RELATION_NAME like 'DIEM_THEO_DOI%'").Tables[0];
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cmd;
            string sql;

            try
            {
                foreach (DataRow row in tableArrayDTD.Rows)
                {
                    sql = "delete from " + row[0] + " where " + KEY_FIELD_NAME + " = " + IDKey;
                    cmd = db.GetSQLStringCommand(sql);
                    cmd = db.GetSQLStringCommand(sql);
                    db.ExecuteNonQuery(cmd, dbTrans);
                }
                sql = "delete from BANG_THEO_DOI where " + KEY_FIELD_NAME + " = " + IDKey;
                cmd = db.GetSQLStringCommand(sql);
                db.ExecuteNonQuery(cmd, dbTrans);
                db.CommitTransaction(dbTrans);
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
                db.RollbackTransaction(dbTrans);
            }
            finally
            {
                db.Close();
            }
            return flag;
        }

      
    }
}
