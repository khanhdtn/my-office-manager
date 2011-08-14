using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using System.Data.Common;

namespace DAO
{
    /// <summary>
    /// Lớp hỗ trợ Fax
    /// </summary>
    public class DATapTinFax : DAPhieu<DOTapTinFax>
    {
        #region Khởi tạo        
        public static DATapTinFax Instance = new DATapTinFax();
        public DATapTinFax()
            : base()
        { 
        }
        #endregion

        #region Cấu hình dữ liệu
        private static string KEY_FIELD_NAME = "HO_TRO_FAX_ID";
        object[] FIELD_MAP = new object[] {
            "HO_TRO_FAX_ID",new IDConverter(),  
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

        public override DOTapTinFax LoadAll(long IDKey)
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

        public override DOTapTinFax Load(long IDKey)
        {
            return null;
        }

        public override bool Update(DOTapTinFax data)
        {
            bool flag = false;
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = DatabaseFB.LoadDataSet("TAP_TIN_FAX",KEY_FIELD_NAME, data.HO_TRO_FAX_ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.HO_TRO_FAX_ID;//= DABase.getDatabase().GetID("G_NGHIEP_VU");
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
            //return true;
        }

        public override bool Validate(DOTapTinFax element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Phương thức khác
        public DOTapTinFax Load(long IDKey, long hoTroInAnID)
        {           
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(@"select * from TAP_TIN_FAX where TAP_TIN_ID = @IDTT and HO_TRO_FAX_ID = @HTFAX");
            db.AddInParameter(cmd, "@IDTT", DbType.Int64, IDKey);
            db.AddInParameter(cmd, "@HTFAX", DbType.Int64, hoTroInAnID);
            IDataReader reader = db.ExecuteReader(cmd);
            using (reader)
            {
                if (reader.Read())
                {
                    DOTapTinFax data = (DOTapTinFax)this.Builder.CreateFilledObject(typeof(DOTapTinFax), reader);
                    return data;
                }
            }
            return new DOTapTinFax();
        }
        public static int Update_taptin_inan(DOTapTinFax doTapTinInAn)
        {
            DatabaseFB db=DABase.getDatabase();
            DbTransaction dbTrans=db.BeginTransaction(db.OpenConnection());
           
            DbCommand cmd = db.GetSQLStringCommand("update TAP_TIN_FAX set SO_TO = @so_to, YEU_CAU = @yeu_cau1 where HO_TRO_FAX_ID = @id_HoTroFax and TAP_TIN_ID=@ID_TapTin");

            db.AddInParameter(cmd, "@id_HoTroFax", DbType.Int64, doTapTinInAn.HO_TRO_FAX_ID);
            db.AddInParameter(cmd, "@ID_TapTin", DbType.Int64, doTapTinInAn.TAP_TIN_ID);
            db.AddInParameter(cmd, "@so_to", DbType.Int32, doTapTinInAn.SO_TO);
            db.AddInParameter(cmd, "@yeu_cau1", DbType.String, doTapTinInAn.YEU_CAU);           

            int value = db.ExecuteNonQuery(cmd, dbTrans);
            if (value == 1) db.CommitTransaction(dbTrans);
            else
                db.RollbackTransaction(dbTrans);
            return value;
        }
        public static void delete_taptin_tinan(DOTapTinFax doTapTinInAn)
        {
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm= db.GetSQLStringCommand("delete tap_tin_fax ttia where ttia.tap_tin_id=@id_taptin and ttia.ho_tro_fax_id=@id_HoTroFax");
            db.AddInParameter(cm, "@id_taptin", DbType.Int64, doTapTinInAn.TAP_TIN_ID);
            db.AddInParameter(cm, "@id_HoTroFax", DbType.Int64, doTapTinInAn.HO_TRO_FAX_ID);
            if (db.ExecuteNonQuery(cm, dbTrans) == 1)
                db.CommitTransaction(dbTrans);
            else
                db.RollbackTransaction(dbTrans);
        }
       
        #endregion
        #region các hàm xử lý trình trạng in ấn     
        public static bool ExistsTT(long id, long tt)
        {
            int kq = 0;
            DatabaseFB db = DABase.getDatabase();
            DbCommand cm = db.GetSQLStringCommand("select count(*) from HO_TRO_FAX where ID='" + id + "' and TINH_TRANG_IN_ID='" + tt + "'");
            kq = (int)db.ExecuteScalar(cm);
            if (kq > 0) return true;
            return false;
        }
        public static long IDTT(long id)
        {

            long kq = 0;
            DatabaseFB db = DABase.getDatabase();
            DbCommand cm = db.GetSQLStringCommand("select TINH_TRANG_IN_ID from HO_TRO_IN_AN where ID='" + id + "'");

            kq = (long)db.ExecuteScalar(cm);
            return kq;
        }
        #endregion
    }
}
