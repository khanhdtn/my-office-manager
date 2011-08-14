using System;
using System.Collections.Generic;
using System.Text;
using DTO;

using System.Data.Common;
using System.Data;
using ProtocolVN.Framework.Core;
namespace DAO
{
    public class DADotTuyenDung
    {
        public static bool Insert(DODotTuyenDung DotTuyen)
        {
            try
            {
                string sql = "INSERT INTO DM_DOT_TUYEN_DUNG "
                            + "(ID,NAME) VALUES "
                            + "(@ID,@NAME)";
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, DotTuyen.getID());
                db.AddInParameter(cmd, "@NAME", DbType.String, DotTuyen.getName());
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
        public static bool Delete(long IDDotTuyen)
        {
            try
            {
                string sql = "DELETE FROM DM_DOT_TUYEN_DUNG "
                            + "WHERE ID = @ID";
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, IDDotTuyen);
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
        public static bool Update(DODotTuyenDung DotTuyen)
        {
            try
            {
                string sql = "UPDATE DM_DOT_TUYEN_DUNG SET "
                            + "NAME = @NAME "
                            + "WHERE ID = @ID";
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, DotTuyen.getID());
                db.AddInParameter(cmd, "@NAME", DbType.String, DotTuyen.getName());
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
