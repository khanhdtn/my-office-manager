using System;
using System.Data;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data.Common;

namespace DAO
{
    public class TienMatKKDPTCFields
    {
        public const string KKD_ID = "KKD_ID";
        public const string TM_DAU_KY = "TM_DAU_KY";
        public const string PHAT_SINH_TANG = "PHAT_SINH_TANG";
        public const string PHAT_SINH_GIAM = "PHAT_SINH_GIAM";
        public const string TM_CUOI_KY = "TM_CUOI_KY";
    }
    public class DATienMatKKDPTCPTC : DAPhieu<DOTienMatKKDPTC>
    {
        public static string KEY_FIELD_NAME = KyKinhDoanhPTCFields.KKD_ID;
        public static string TABLE_MAP = "TM_KY_KINH_DOANH_PTC";
        private object[] FIELD_MAP = new object[] { 
            TienMatKKDPTCFields.KKD_ID,new IDConverter(),
            TienMatKKDPTCFields.TM_DAU_KY,null,
            TienMatKKDPTCFields.PHAT_SINH_TANG,null,
            TienMatKKDPTCFields.PHAT_SINH_GIAM,null,
            TienMatKKDPTCFields.TM_CUOI_KY,null
        };
        public static DATienMatKKDPTCPTC Instance = new DATienMatKKDPTCPTC();

        public DATienMatKKDPTCPTC() : base() { }

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOTienMatKKDPTC LoadAll(long IDKey)
        {
            DOTienMatKKDPTC phieu = this.Load(IDKey);
            phieu.MasterDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            return phieu;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            return true;
        }

        public override bool ValidateDetail(System.Data.DataRow row)
        {
            return true;
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
        }

        public override DOTienMatKKDPTC Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOTienMatKKDPTC data = (DOTienMatKKDPTC)this.Builder.CreateFilledObjectExt(typeof(DOTienMatKKDPTC), reader);

                    return data;
                }
            }
            return new DOTienMatKKDPTC();
        }

        public override bool Update(DOTienMatKKDPTC data)
        {
            bool flag = false;
            try
            {
                if (data.MasterDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in data.MasterDataSet.Tables[0].Rows)
                    {
                        flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    }
                }
                else
                {
                    DataRow row = data.MasterDataSet.Tables[0].NewRow();
                    data.MasterDataSet.Tables[0].Rows.Add(row);
                    flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                }
                if (flag)
                {
                    try
                    {
                        DataSet dsMain = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.KKD_ID);
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, dsMain, data.MasterDataSet);
                        if (data.KKD_ID == 0)
                        {
                            flag = DatabaseFB.Update2DataSet("G_NGHIEP_VU", dsMain, null,true);
                        }
                        else
                        {
                            flag = HelpDB.getDatabase().UpdateDataSet(dsMain);
                        }
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return flag;
        }

        public override bool Validate(DOTienMatKKDPTC element)
        {
            return true;
        }

        public bool UpdateExce(DOTienMatKKDPTC data)
        {
            bool flag = false;
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(@"
                    INSERT INTO TM_KY_KINH_DOANH_PTC
                    VALUES(@KKD_ID,@TM_DAU_KY,@PHAT_SINH_TANG,@PHAT_SINH_GIAM,@TM_CUOI_KY)
                ");
                db.AddInParameter(cmd, "@KKD_ID", DbType.Int64, DAKyKinhDoanhPTC.Instance.getKyKDMax().KKD_ID);
                db.AddInParameter(cmd, "@TM_DAU_KY", DbType.Decimal, data.TM_DAU_KY);
                db.AddInParameter(cmd, "@PHAT_SINH_TANG", DbType.Decimal, data.PHAT_SINH_TANG);
                db.AddInParameter(cmd, "@PHAT_SINH_GIAM", DbType.Decimal, data.PHAT_SINH_GIAM);
                db.AddInParameter(cmd, "@TM_CUOI_KY", DbType.Decimal, data.TM_CUOI_KY);
                flag = (db.ExecuteNonQuery(cmd) > 0);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return flag;
        }


    }
}
