using System;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Core;
using DTO;


namespace DAO
{
    public class DANoiDungTapTin
    {
        public static DONoiDungTapTin getNoiDungTapTin(string TableName,long id)
        {
            DONoiDungTapTin nd = new DONoiDungTapTin();
            DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from " + TableName + " where ID=" + id);
            if(ds.Tables.Count>0)
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    nd.ID=HelpNumber.ParseInt64(row["ID"]);
                    nd.NOI_DUNG=(byte[])row["NOI_DUNG"];
                    nd.TEN_FILE = row["TEN_FILE"].ToString();
                    nd.URL=row["URL"].ToString();
                    return nd; 
                }
            return null;                                      
        }

        public static bool Insert(DONoiDungTapTin doND,string tableName)
        {
            string str = "insert into " + tableName + " values(@ID,@NOI_DUNG,@TEN_FILE,@URL)";
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cmd = db.GetSQLStringCommand(str);

            db.AddInParameter(cmd,"@ID",DbType.Int64,doND.ID);
            db.AddInParameter(cmd,"@NOI_DUNG",DbType.Binary,doND.NOI_DUNG);
            db.AddInParameter(cmd,"@TEN_FILE",DbType.String,doND.TEN_FILE);
            db.AddInParameter(cmd,"@URL",DbType.String,doND.URL);
            try
            {
                int a = db.ExecuteNonQuery(cmd, trans);
                db.CommitTransaction(trans);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                db.RollbackTransaction(trans);
                return false;
            }
            finally
            {
                db.Close();
            }

            return true;            
        }

        public static bool UpdateTenFile(string nameTable,DONoiDungTapTin _doNoiDungTapTin)
        { 
            string str="update " + nameTable + "set ten_file=@ten_file, url=@url where id=@id";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(str);

            db.AddInParameter(cmd,"@id",DbType.Int64,_doNoiDungTapTin.ID);
            db.AddInParameter(cmd, "@ten_file", DbType.String, _doNoiDungTapTin.TEN_FILE);
            db.AddInParameter(cmd,"@url",DbType.String,_doNoiDungTapTin.URL);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
    }
}
