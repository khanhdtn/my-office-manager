using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;

using System.Data.Common;
using ProtocolVN.Framework.Core;
namespace DAO
{
    public class DAChonPhongVan
    {
        public static List<DOChonPhongVan> getDanhSach()
        {
            List<DOChonPhongVan> arr = new List<DOChonPhongVan>();
            DatabaseFB db = DABase.getDatabase();
            DbCommand select = db.GetSQLStringCommand("select * from BANG_CHON_PV");
            IDataReader reader = db.ExecuteReader(select);
            while (reader.Read())
            {
                DOChonPhongVan bcpv = new DOChonPhongVan((int)reader["ID"], reader["NAME"].ToString());
                arr.Add(bcpv);
            }
            return arr;
        }
        public static bool Insert(DOChonPhongVan ChonPhongVan)
        {
            try
            {
                string sql = "INSERT INTO BANG_CHON_PV "
                            + "(ID,NAME) VALUES "
                            + "(@ID,@NAME)";
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, ChonPhongVan.getID());
                db.AddInParameter(cmd, "@NAME", DbType.String, ChonPhongVan.getName());
                int iCmd = db.ExecuteNonQuery(cmd);
                if (iCmd > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static bool Delete(int IDChonPhongVan)
        {
            try
            {
                string sql = "DELETE FROM BANG_CHON_PV "
                            + "WHERE ID = @ID";
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, IDChonPhongVan);
                int iCmd = db.ExecuteNonQuery(cmd);
                if (iCmd > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static bool Update(DOChonPhongVan ChonPhongVan)
        {
            try
            {
                string sql = "UPDATE BANG_CHON_PV SET "
                            + "NAME = @NAME "
                            + "WHERE ID = @ID";
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, ChonPhongVan.getID());
                db.AddInParameter(cmd, "@NAME", DbType.String, ChonPhongVan.getName());
                int iCmd = db.ExecuteNonQuery(cmd);
                if (iCmd > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
