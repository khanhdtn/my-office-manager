using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Win;

namespace DAO
{
    /// <summary>
    /// Lớp hỗ trợ In ấn
    /// </summary>
    public class DATapTinInAn : DAPhieu<DOTapTinInAn>
    {
        #region Khởi tạo        
        public static DATapTinInAn Instance = new DATapTinInAn();
        public DATapTinInAn() : base()
        { 
        }
        #endregion

        #region Cấu hình dữ liệu
        private static string KEY_FIELD_NAME = "HO_TRO_IN_AN_ID";
        object[] FIELD_MAP = new object[] {
            "HO_TRO_IN_AN_ID",new IDConverter(),  
                "TAP_TIN_ID", new IDConverter(),                               
               	                                           										               	                
                "SO_TO",null,
                "YEU_CAU",null
        };
        #endregion

        #region Phương thức override
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOTapTinInAn LoadAll(long IDKey)
        {
            return null;
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

        public override DOTapTinInAn Load(long IDKey)
        {
            return null;
        }

        public override bool Update(DOTapTinInAn data)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = FWDBService.LoadDataSet("TAP_TIN_IN_AN",KEY_FIELD_NAME, data.HO_TRO_IN_AN_ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.HO_TRO_IN_AN_ID;//= DABase.getDatabase().GetID("G_NGHIEP_VU");
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
            //return true;
        }

        public override bool Validate(DOTapTinInAn element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Phương thức khác
        public DOTapTinInAn Load(long IDKey,long hoTroInAnID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(@"select * from TAP_TIN_IN_AN where TAP_TIN_ID = @IDTT and HO_TRO_IN_AN_ID = @HTIN");
            db.AddInParameter(cmd, "@IDTT", DbType.Int64, IDKey);
            db.AddInParameter(cmd, "@HTIN", DbType.Int64, hoTroInAnID);
            IDataReader reader = db.ExecuteReader(cmd);
            using (reader)
            {
                if (reader.Read())
                {
                    DOTapTinInAn data = (DOTapTinInAn)this.Builder.CreateFilledObject(typeof(DOTapTinInAn), reader);
                    return data;
                }
            }
            return new DOTapTinInAn();
        }
        public static int Update_taptin_inan(DOTapTinInAn doTapTinInAn)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans=db.BeginTransaction(db.OpenConnection());
           
            DbCommand cmd = db.GetSQLStringCommand("update TAP_TIN_IN_AN set SO_TO = @so_to, YEU_CAU = @yeu_cau1 where HO_TRO_IN_AN_ID = @id_HoTroInAn and TAP_TIN_ID=@ID_TapTin");

            db.AddInParameter(cmd, "@id_HoTroInAn", DbType.Int64, doTapTinInAn.HO_TRO_IN_AN_ID);
            db.AddInParameter(cmd, "@ID_TapTin", DbType.Int64, doTapTinInAn.TAP_TIN_ID);
            db.AddInParameter(cmd, "@so_to", DbType.Int32, doTapTinInAn.SO_TO);
            db.AddInParameter(cmd, "@yeu_cau1", DbType.String, doTapTinInAn.YEU_CAU);           

            int value = db.ExecuteNonQuery(cmd, dbTrans);
            if (value == 1) db.CommitTransaction(dbTrans);
            else
                db.RollbackTransaction(dbTrans);
            return value;
        }
        public static void delete_taptin_tinan(DOTapTinInAn doTapTinInAn)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm= db.GetSQLStringCommand("delete tap_tin_in_an ttia where ttia.tap_tin_id=@id_taptin and ttia.ho_tro_in_an_id=@id_HoTroInAn");
            db.AddInParameter(cm, "@id_taptin", DbType.Int64, doTapTinInAn.TAP_TIN_ID);
            db.AddInParameter(cm, "@id_HoTroInAn", DbType.Int64, doTapTinInAn.HO_TRO_IN_AN_ID);
            if (db.ExecuteNonQuery(cm, dbTrans) == 1)
                db.CommitTransaction(dbTrans);
            else
                db.RollbackTransaction(dbTrans);
        }
        public static void InitCtrl(PLImgCombobox Input)
        {
            DataSet ds = new DataSet();
            DataTable dt = HelpDataSetExt.CreateDataTable(
                                                        new string[] { "ID", "NAME" },
                                                        new string[] { "Int64", "" },
                                                        new object[] { 1, "Chờ in", 
                                                                       3, "Đã in",
                                                                       4, "Không in"
                                                                     }
                                                      );
            ds.Tables.Add(dt);
            Input._init(ds.Tables[0], "NAME", "ID");
        }
        #endregion

        #region các hàm xử lý trình trạng in ấn     
        public static bool ExistsTT(long id, long tt)
        {
            int kq = 0;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cm = db.GetSQLStringCommand("select count(*) from HO_TRO_IN_AN where ID='" + id + "' and TINH_TRANG_IN_ID='" + tt + "'");
            kq = (int)db.ExecuteScalar(cm);
            if (kq > 0) return true;
            return false;
        }
        public static long IDTT(long id)
        {

            long kq = 0;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cm = db.GetSQLStringCommand("select TINH_TRANG_IN_ID from HO_TRO_IN_AN where ID='" + id + "'");

            kq = (long)db.ExecuteScalar(cm);
            return kq;
        }
        #endregion
    }
}
