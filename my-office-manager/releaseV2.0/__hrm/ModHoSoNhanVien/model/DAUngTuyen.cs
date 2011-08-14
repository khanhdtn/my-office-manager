using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.Common;
using System.Data;
using ProtocolVN.Framework.Core;

namespace DAO
{
    public class DAUngTuyen
    {
        public static bool Insert(DOUngTuyen dto)
        {
            string sql = "Insert into RESUME_UNG_TUYEN(ID,R_ID,VTUT_ID) values(@ID,@R_ID,@VTUT_ID)";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, db.GetID("GEN_RESUME_UNG_TUYEN_ID"));
            db.AddInParameter(cmd, "@R_ID", DbType.Int64,dto.UV_ID );
            db.AddInParameter(cmd, "@VTUT_ID", DbType.Int32, dto.VTUT_ID);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public static bool Delete(long UngVienID)
        {
            string sql = "delete from RESUME_UNG_TUYEN where R_ID = @R_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@R_ID", DbType.Int64, UngVienID);
            int iCmd = db.ExecuteNonQuery(cmd);
            if (iCmd > 0)
                return true;
            return false;
        }
        public static bool Delete(DOUngTuyen UngTuyen)
        {
            string sql = "delete from RESUME_UNG_TUYEN where R_ID = @R_ID and VTUT_ID = @VTUT_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@R_ID", DbType.Int64, UngTuyen.UV_ID);
            db.AddInParameter(cmd, "@VTUT_ID", DbType.Int64, UngTuyen.VTUT_ID);
            int iCmd = db.ExecuteNonQuery(cmd);
            if (iCmd > 0)
                return true;
            return false;
        }
        public static bool Update(DOUngTuyen UngTuyen)
        {
            string sql = "update RESUME_UNG_TUYEN set VTUT_ID = @VTUT_ID where R_ID = @R_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@R_ID", DbType.Int64, UngTuyen.UV_ID);
            db.AddInParameter(cmd, "@VTUT_ID", DbType.Int64, UngTuyen.VTUT_ID);
            int iCmd = db.ExecuteNonQuery(cmd);
            if (iCmd > 0)
                return true;
            return false;
        }
        public static DataTable getVTUngTuyenUngVien(long UngVienID)
        {
            string sql = "select uvut.ID,vt.NAME,uvut.VTUT_ID from RESUME_UNG_TUYEN uvut,DM_VI_TRI_UNG_TUYEN vt where uvut.R_ID = @R_ID and uvut.VTUT_ID = vt.ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@R_ID", DbType.Int64, UngVienID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            return ds.Tables[0];
        }
        public static bool ExistsRow(DOUngTuyen UngTuyen)
        {
            string sql = "select * from RESUME_UNG_TUYEN where R_ID = @R_ID and VTUT_ID = @VTUT_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@R_ID", DbType.Int64, UngTuyen.UV_ID);
            db.AddInParameter(cmd, "@VTUT_ID", DbType.Int64, UngTuyen.VTUT_ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            return false;
        }
    }
}
