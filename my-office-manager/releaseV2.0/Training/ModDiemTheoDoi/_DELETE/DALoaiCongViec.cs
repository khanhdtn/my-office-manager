using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Core;
using pl.office;
using ProtocolVN.Framework.Win;
using DTO;

namespace DAO
{
    public class DALoaiCongViec
    {
        
        public void Them(bool a, DOLoaiCongViec doLoaiCV)
        {
            string sql;
            if (a)
            {
                sql = "insert into LOAI_CONG_VIEC (LCV_ID, MA_LCV, NAME, MO_TA, VISIBLE_BIT) values (@LCV_ID, @MA_LCV, @NAME, @MO_TA, @VISIBLE_BIT)";
            }
            else
            {
                sql = "update LOAI_CONG_VIEC set MA_LCV = @MA_LCV, NAME = @NAME, MO_TA = @MO_TA, VISIBLE_BIT = @VISIBLE_BIT where LCV_ID = @LCV_ID";
            }

            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@LCV_ID", DbType.Int64, doLoaiCV.LCV_ID);
            db.AddInParameter(cmd, "@MA_LCV", DbType.String, doLoaiCV.MA_LCV);
            db.AddInParameter(cmd, "@NAME", DbType.String, doLoaiCV.NAME);
            db.AddInParameter(cmd, "@MO_TA", DbType.String, doLoaiCV.MO_TA);
            db.AddInParameter(cmd, "@VISIBLE_BIT", DbType.String, doLoaiCV.VISIBLE_BIT);
            db.ExecuteNonQuery(cmd);

        }

        public DataSet Load()
        {
            //return DABase.getDatabase().LoadDataSet("select LCV_ID,NAME,MO_TA,iif(VISIBLE_BIT = 1,'true','false') VISIBLE_BIT From LOAI_CONG_VIEC where VISIBLE_BIT='1'");
            return DABase.getDatabase().LoadDataSet("select * From LOAI_CONG_VIEC where VISIBLE_BIT = 'Y'");

        }

        public void Xoa(DOLoaiCongViec doLoaiCV)
        {
            string sql = "DELETE FROM LOAI_CONG_VIEC WHERE LCV_ID = @LCV_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@LCV_ID", DbType.Int64, doLoaiCV.LCV_ID);
            db.ExecuteNonQuery(cmd);
        }
      

        

    }
}
