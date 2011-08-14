using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.Common;
using ProtocolVN.Framework.Core;

namespace DAO
{
    public class DAViTriUngTuyen
    {
        public static string DanhSachVTUT(long IDUngVien)
        {
            string sql = "select vtut.NAME from DM_VI_TRI_UNG_TUYEN vtut,RESUME_UNG_TUYEN uvut  "
                        + "where uvut.VTUT_ID = vtut.ID "
                        + "and uvut.R_ID = @IDUV";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@IDUV", DbType.Int64, IDUngVien);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            string Kq = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Kq += ds.Tables[0].Rows[i]["NAME"].ToString();
                    if (i < ds.Tables[0].Rows.Count - 1)
                        Kq += ",";
                }
            }
            return Kq;
        }
        public static DataTable getAllTable()
        {
            return DABase.getDatabase().LoadTable("DM_VI_TRI_UNG_TUYEN").Tables[0];
        }
        public static DataTable getData(long ID)
        {
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand("select * from DM_VI_TRI_UNG_TUYEN where ID = @ID");
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "DM_VI_TRI_UNG_TUYEN");
            return ds.Tables[0];
        }
        public static string getName(long ID)
        {
            DataTable data = getData(ID);
            if (data.Rows.Count == 0)
                return "";
            else
                return data.Rows[0]["NAME"].ToString();
        }
    }
}
