using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using DTO;
using office;

namespace DAO
{
    public class DAWebsite:DAPhieu<DOWebsite>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                                					
				"PHAN_LOAI", null,
                "DIA_CHI",null,
                "MO_TA",null                            
        };
        public static DAWebsite Instance = new DAWebsite();

        private DAWebsite() : base() { }
        #region Các hàm kế thừa 
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOWebsite LoadAll(long IDKey)
        {
            return Load(IDKey);
        }

        public override bool UpdateDetail(DataSet Detail, DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateDetail(DataRow row)
        {
            throw new NotImplementedException();
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord("DANH_BA_WEBSITE", KEY_FIELD_NAME, IDKey);
        }

        public override DOWebsite Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("DANH_BA_WEBSITE", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOWebsite data = (DOWebsite)this.Builder.CreateFilledObject(typeof(DOWebsite), reader);
                    return data;
                }
            }
            return new DOWebsite();
        }

        public override bool Update(DOWebsite data)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = DatabaseFB.LoadDataSet("DANH_BA_WEBSITE", KEY_FIELD_NAME, data.ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.ID = DABase.getDatabase().GetID("G_NGHIEP_VU");
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
        }

        public override bool Validate(DOWebsite element)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Các hàm khác 
        public static void InitChonPhanLoai(PLComboboxAdd PhanLoai)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT * FROM DM_WEBSITE where VISIBLE_BIT = 'Y' AND ID_CHA is not null and 1=1");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            PhanLoai._init(ds.Tables[0], "NAME", "ID");
        }
        public static void InitChonPhanLoai(PLCombobox PhanLoai)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT * FROM DM_WEBSITE where 1=1");
            query.addCondition("VISIBLE_BIT = 'Y' AND ID<>ID_ROOT");
            query.setAscOrderBy("NAME");
            DataSet ds = WebsitesPermission.I._LoadDataSetWithResGroupPermission(query, "ID");
            PhanLoai._init(ds.Tables[0], "NAME", "ID");
        }
        public bool CheckExists(DOWebsite data,long PhanLoaiID, string Website,bool? IsAdd)
        {
            bool IsExists = false;
            DatabaseFB db = DABase.getDatabase();
            StringBuilder Str = new StringBuilder("Select * from DANH_BA_WEBSITE where PHAN_LOAI=@PHANLOAI and DIA_CHI=@DIACHI");
            try
            {
                if (IsAdd == true)
                {
                    DbCommand cmd = db.GetSQLStringCommand(Str.ToString());
                    db.AddInParameter(cmd, "@PHANLOAI", DbType.Int64, PhanLoaiID);
                    db.AddInParameter(cmd, "@DIACHI", DbType.String, Website);
                    IsExists = db.LoadDataSet(cmd).Tables[0].Rows.Count > 0;
                }
                else {
                    Str.Append(" and ID <> @ID");
                    DbCommand cmd = db.GetSQLStringCommand(Str.ToString());
                    db.AddInParameter(cmd, "@PHANLOAI", DbType.Int64, PhanLoaiID);
                    db.AddInParameter(cmd, "@DIACHI", DbType.String, Website);
                    db.AddInParameter(cmd, "@ID", DbType.Int64, data.ID);
                    IsExists = db.LoadDataSet(cmd).Tables[0].Rows.Count > 0;
                } 
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
            return IsExists;
        }
        public static string RegexWebsite(string LinkWeb)
        {            
            string[] tmp = LinkWeb.Split('.');
            string[] ht = LinkWeb.Split(':');
            if (ht[0] == "http")
            {
                if (tmp[0] == "http://www")
                    return @"((http\://|https\://|ftp\://)|(www.))+(([a-zA-Z0-9\.-]+\.[a-zA-Z]{2,4})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9%:/-_\?\.'~]*)?";
                else
                   return @"((http\://|https\://|ftp\://)|(www.))+(([a-zA-Z0-9\.-]+\.[a-zA-Z]{2,4})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9%:/-_\?\.'~]*)?";
            }
            else if (tmp[0] == "www")
                return @"(www.)+(([a-zA-Z0-9\.-]+\.[a-zA-Z]{2,4})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9%:/-_\?\.'~]*)?";
            else
                return @"^(([a-zA-Z0-9\.-]+\.[a-zA-Z]{2,4})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(/[a-zA-Z0-9%:/-_\?\.'~]*)?";

        }
        #endregion
    }
}
