using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using ProtocolVN.Framework.Core;
using System.Data;
using office;
using System.Data.Common;

/*
 * Author : Trần Văn Châu
 * Email : chautv@protocolvn.net
 */
namespace DAO
{
    public class DAChamCongAutoChot : DAPhieu<DOChamCongAutoChot>
    {
        #region Fields
        public static string KEY_FIELD_NAME = "ID";
        public static string TABLE_MAP = "BANG_CHAM_CONG_AUTO_CHOT";
        private object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),
                "NGAY",null
        };
        public static DAChamCongAutoChot Instance = new DAChamCongAutoChot();
        private DAChamCongAutoChot() : base() { }
        #endregion

        #region Methods override
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            throw new NotImplementedException();
        }

        public override DOChamCongAutoChot LoadAll(long IDKey)
        {
            DOChamCongAutoChot phieu = this.Load(IDKey);
            phieu.DetailDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
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

        public override DOChamCongAutoChot Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOChamCongAutoChot data = (DOChamCongAutoChot)this.Builder.CreateFilledObjectExt(typeof(DOChamCongAutoChot), reader);

                    return data;
                }
            }
            return new DOChamCongAutoChot();
        }

        public override bool Update(DOChamCongAutoChot data)
        {
            bool flag = false;
            try
            {
                if (data.DetailDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in data.DetailDataSet.Tables[0].Rows)
                    {
                        flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    }
                }
                else
                {
                    DataRow row = data.DetailDataSet.Tables[0].NewRow();
                    row["ID"] = HelpDB.getDatabase().GetID(PLConst.G_NGHIEP_VU);
                    data.DetailDataSet.Tables[0].Rows.Add(row);
                    flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                }
                if (flag)
                {
                    try
                    {
                        DataSet dsMain = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.ID);
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, dsMain, data.DetailDataSet);
                        flag = DatabaseFB.Update2DataSet(PLConst.G_NGHIEP_VU, dsMain, null, true);
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

        public override bool Validate(DOChamCongAutoChot element)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Others
        public bool Duyet(DateTime[] array) {
            foreach (DateTime date in array)
            {
                DOChamCongAutoChot phieu = this.LoadAll(date);
                this.Update(phieu);
            }
            return true;
        }

        public bool MoDuyet(DateTime[] array) {
            foreach (DateTime date in array)
            {
                DOChamCongAutoChot phieu = this.LoadAll(date);
                if (phieu.ID != 0)
                    this.Delete(phieu.ID);
            }
            return true;
        }

        public DOChamCongAutoChot Load(DateTime date) {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(@"
                SELECT * 
                FROM BANG_CHAM_CONG_AUTO_CHOT 
                WHERE NGAY = @NGAY AND 1=1"
            );
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, date);
            IDataReader reader = db.ExecuteReader(cmd);
            using (reader)
            {
                if (reader.Read())
                {
                    DOChamCongAutoChot data = (DOChamCongAutoChot)this.Builder.CreateFilledObjectExt(typeof(DOChamCongAutoChot), reader);

                    return data;
                }
            }
            return new DOChamCongAutoChot();
        }

        public DOChamCongAutoChot LoadAll(DateTime date) {
            DOChamCongAutoChot phieu = this.Load(date);
            DatabaseFB db = HelpDB.getDatabase();
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM BANG_CHAM_CONG_AUTO_CHOT WHERE 1=1");
            query.add("NGAY", Operator.Equal, date, DbType.DateTime);
            phieu.DetailDataSet = db.LoadDataSet(query);
            phieu.DetailDataSet.Tables[0].TableName = TABLE_MAP;
            return phieu;
        }
        #endregion
    }
}
