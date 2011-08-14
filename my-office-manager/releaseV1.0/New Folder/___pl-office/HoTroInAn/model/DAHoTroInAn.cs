using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using System.Data.Common;
using office;
using ProtocolVN.Framework.Win;

namespace DAO
{
    /// <summary>
    /// Lớp hỗ trợ In ấn
    /// </summary>
    public class DAHoTroInAn : DAPhieu<DOHoTroInAn>
    {
        #region Khởi tạo
        public static DAHoTroInAn Instance = new DAHoTroInAn();
        public DAHoTroInAn() : base() { }
        #endregion

        #region Cấu hình dữ liệu
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                
                "MUC_DICH", null,	                                           										
                "NGUOI_GUI_ID", new IDConverter(),
                "NGUOI_NHAN_ID",new IDConverter(), 
                "THOI_GIAN_CAP_NHAT", null,	                
                "TINH_TRANG_IN_ID",new IDConverter(),
                "MUC_DO_UU_TIEN_ID",new IDConverter()
        };
        object[] FIELD_MAP_TAP_TIN = new object[] {  
                "ID", new IDConverter(),                                
                "TIEU_DE", null,
	            "TEN_FILE",null,
                "NOI_DUNG",null,                										
				"NGUOI_CAP_NHAT", new IDConverter(),
                "NGAY_CAP_NHAT", null,	
                "GHI_CHU",null              
        };
        #endregion

        #region Phương thức Overrite
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOHoTroInAn LoadAll(long IDKey)
        {
            DOHoTroInAn phieu = this.Load(IDKey);
            phieu.DetailDataset = FWDBService.LoadDataSet("HO_TRO_IN_AN", "ID", IDKey);
            return phieu;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateDetail(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            throw new NotImplementedException();
        }

        public override DOHoTroInAn Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("HO_TRO_IN_AN", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOHoTroInAn data = (DOHoTroInAn)this.Builder.CreateFilledObject(typeof(DOHoTroInAn), reader);
                    return data;
                }
            }
            return new DOHoTroInAn();
        }

        public override bool Update(DOHoTroInAn data)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            try
            {
                DataSet MainDS = FWDBService.LoadDataSet("HO_TRO_IN_AN", KEY_FIELD_NAME, data.ID);
                if (MainDS.Tables[0].Rows.Count == 1)
                {
                    HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                else
                {
                    DataRow row = MainDS.Tables[0].NewRow();
                    row[KEY_FIELD_NAME] = data.ID;
                    HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                    MainDS.Tables[0].Rows.Add(row);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                db.CommitTransaction(dbTrans);
            }
            catch (Exception ex)
            {
                flag = false;
                db.RollbackTransaction(dbTrans);
                PLException.AddException(ex);
                HelpSysLog.AddException(ex,"Hàm cập nhật dữ liệu hỗ trợ in ấn");
            }
            return flag;
        }
        public bool UpdateDataset(DOHoTroInAn data)
        {
            DatabaseFB db = HelpDB.getDatabase();
            db.OpenConnection();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            try
            {
                if (db.UpdateDataSet(data.DetailDataset, dbTrans) == false) return false;
            }
            catch
            {
                db.RollbackTransaction(dbTrans);
            }
            db.CommitTransaction(dbTrans);
            return true;
        }
        public override bool Validate(DOHoTroInAn element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Phương thức khác
        public string HTMLtoText(string HTML)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string s = reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");
        }
        public static void DeleteLuuTruTapTin(long ID)
        {
            string sql = "delete from LUU_TRU_TAP_TIN where ID=@ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(sql);
            db.AddInParameter(cm, "@ID", DbType.Int64, ID);
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static bool SaveFilePrint(DOTapTin_TapTinInAn do_taptininan)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("insert into TAP_TIN_IN_AN(TAP_TIN_ID,HO_TRO_IN_AN_ID,SO_TO,YEU_CAU) values(@TAP_TIN_ID,@HO_TRO_IN_AN_ID,@SO_TO,@YEU_CAU)");
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, do_taptininan.ID);
            db.AddInParameter(cm, "@HO_TRO_IN_AN_ID", DbType.Int64, do_taptininan.HO_TRO_IN_AN_ID);
            db.AddInParameter(cm, "@SO_TO", DbType.Decimal, do_taptininan.SO_TO);
            db.AddInParameter(cm, "@YEU_CAU", DbType.String, do_taptininan.YEU_CAU);
            try
            {
                db.ExecuteNonQuery(cm, trans);
                db.CommitTransaction(trans);
                return true;
            }
            catch { return false; }
        }
        public static bool CapNhatTinhTrangIn(long hoTroInAn_ID,long tinhTrangIn_ID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("update HO_TRO_IN_AN set TINH_TRANG_IN_ID = @TINH_TRANG_IN_ID where ID=@ID");
            db.AddInParameter(cm, "@ID", DbType.Int64, hoTroInAn_ID);
            db.AddInParameter(cm, "@TINH_TRANG_IN_ID", DbType.Int64, tinhTrangIn_ID);
            try
            {
                db.ExecuteNonQuery(cm, trans);
                db.CommitTransaction(trans);
                return true;
            }
            catch { return false; }
        }
        public static bool CapNhatTinhTrangFax(long hoTroFax_ID, long tinhTrangFax_ID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("update HO_TRO_FAX set TINH_TRANG_FAX_ID = @TINH_TRANG_FAX_ID where ID=@ID");
            db.AddInParameter(cm, "@ID", DbType.Int64, hoTroFax_ID);
            db.AddInParameter(cm, "@TINH_TRANG_FAX_ID", DbType.Int64, tinhTrangFax_ID);
            try
            {
                db.ExecuteNonQuery(cm, trans);
                db.CommitTransaction(trans);
                return true;
            }
            catch { return false; }
        }
        
        public static bool EditFilePrint(DOTapTin_TapTinInAn do_taptininan)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(@"update TAP_TIN_IN_AN ttf set ttf.so_to = @SO_TO, ttf.yeu_cau = @YEU_CAU
                                                    where (TAP_TIN_ID = @TAP_TIN_ID) and (HO_TRO_IN_AN_ID = @HO_TRO_IN_AN_ID)");
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, do_taptininan.ID);
            db.AddInParameter(cm, "@HO_TRO_IN_AN_ID", DbType.Int64, do_taptininan.HO_TRO_IN_AN_ID);
            db.AddInParameter(cm, "@SO_TO", DbType.Decimal, do_taptininan.SO_TO);
            db.AddInParameter(cm, "@YEU_CAU", DbType.String, do_taptininan.YEU_CAU);
            try
            {
                db.ExecuteNonQuery(cm, trans);
                db.CommitTransaction(trans);
                return true;
            }
            catch { return false; }
        }
        public bool UpdateTapTin(DOTapTin_TapTinInAn data)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = FWDBService.LoadDataSet("LUU_TRU_TAP_TIN", "ID", data.ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP_TAP_TIN, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.ID;
                HelpDataSet.UpdataDataRow(row, FIELD_MAP_TAP_TIN, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
        }
        public static void DeleteFilePrint(long id_taptin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("delete from TAP_TIN_IN_AN where TAP_TIN_ID='" + id_taptin + "'");
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static void RemoveAllFilesPrint(long InAn_ID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("delete from TAP_TIN_IN_AN where HO_TRO_IN_AN_ID='" + InAn_ID + "'");
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        #endregion
    }
}
