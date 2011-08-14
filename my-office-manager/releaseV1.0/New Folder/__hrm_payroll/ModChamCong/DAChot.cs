using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using System.Data;
namespace DAO
{
    public class DAChot
    {
        public static DAChot Instance = new DAChot();
        private DAChot ()
        {

        }
        public void ChotBangChamCong(DateTime []dsNgayChot,string TableName,string GenName)
        {
            foreach (DateTime item in dsNgayChot)
            {
                DOChot info = new DOChot
                {
                    ID = HelpDB.getDatabase().GetID(GenName),
                    Ngay = item
                };
                Chot(info,TableName);
            }
        }
        public void MoChotBangChamCong(DateTime []dsNgayMoChot,string TableName)
        {
            //foreach (DateTime item in dsNgayMoChot)
            //{
            //    DOChot info = new DOChot { Ngay = item };
            //    MoChot(info,TableName);
            //}
            QueryBuilder query = new QueryBuilder("DELETE FROM " + DAChamCongAutoChot.TABLE_MAP + " WHERE 1=1");
            query.addDateFromTo("NGAY", dsNgayMoChot[0], dsNgayMoChot[dsNgayMoChot.Length - 1]);
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(query.generateParamSQL());
            cmd.Parameters.AddRange(query.generateDbParam().ToArray());
            db.ExecuteNonQuery(cmd);
        }
        public bool TonTai(DateTime Ngay,string TableName)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string sql = "select * from " + TableName + " where NGAY = @NGAY" ;
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd,"@NGAY", DbType.DateTime,Ngay);
            DataSet ds = db.LoadDataSet(cmd,"AA");
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            return false;
        }
        public int Chot(DOChot info,string TableName)
        {
            if (!this.TonTai(info.Ngay,TableName))
            {
                string sql = "insert into " + TableName + "(ID,NGAY) values(@ID,@NGAY)";
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", System.Data.DbType.Int64, info.ID);
                db.AddInParameter(cmd, "@NGAY", System.Data.DbType.DateTime, info.Ngay);
                return db.ExecuteNonQuery(cmd);
            }
            return -1;
        }
        public int MoChot(DOChot info,string TableName)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string sql = "delete from " + TableName + " where NGAY = @NGAY";
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, info.Ngay);
            return db.ExecuteNonQuery(cmd);
        }
    }
}
