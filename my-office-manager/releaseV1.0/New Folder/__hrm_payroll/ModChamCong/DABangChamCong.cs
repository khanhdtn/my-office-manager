using System;
using DTO;
using System.Data.Common;
using System.Data;
using ProtocolVN.Framework.Core;
namespace DAO
{
    public class DABangChamCong
    {
        public static DABangChamCong Ins = new DABangChamCong();
        
        public DABangChamCong()
        { 

        }
        public Boolean IsTonTai(long NV_ID, DateTime Ngay)
        {
            string sql = "select * from BANG_CHAM_CONG where NV_ID = @NV_ID and NGAY = @NGAY";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, Ngay);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "BANG_CHAM_CONG");
            if (ds.Tables[0].Rows.Count>0)
                return true;
            return false;
        }
        public Boolean ThemDong(DOBangChamCong dto)
        {
            string sql = "insert into BANG_CHAM_CONG(ID,NV_ID,NGAY,SANG,CHIEU) values(@ID,@NV_ID,@NGAY,@SANG,@CHIEU)";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd,"@ID",DbType.Int64, db.GetID("GEN_BANG_CHAM_CONG_ID"));
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, dto.NV_ID);
           
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, dto.NGAY);
            db.AddInParameter(cmd, "@SANG", DbType.String, dto.SANG);
            db.AddInParameter(cmd, "@CHIEU", DbType.String, dto.CHIEU);
            if (db.ExecuteNonQuery(cmd)> 0)
                return true;
            return false;
        }
        public Boolean LuuDong(DOBangChamCong dto)
        {
            string sql = "update BANG_CHAM_CONG set SANG = @SANG, CHIEU = @CHIEU where NV_ID = @NV_ID and NGAY = @NGAY";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, dto.NV_ID);
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, dto.NGAY);
            db.AddInParameter(cmd, "@SANG", DbType.String, dto.SANG);
            db.AddInParameter(cmd, "@CHIEU", DbType.String, dto.CHIEU);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public Boolean XoaDong(DOBangChamCong dto)
        {
            string sql = "delete from BANG_CHAM_CONG where NV_ID = @NV_ID and NGAY = @NGAY";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, dto.NV_ID);
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, dto.NGAY);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public Boolean Duyet(bool IsChot,DateTime[]DanhSachNgay )
        {
            string sql = "update BANG_CHAM_CONG set IS_CHOT = @GiaTri where ";
            for (int i = 0; i < DanhSachNgay.Length; i++)
            {
                if (i < DanhSachNgay.Length - 1)
                    sql += " NGAY = @NGAY" + i.ToString() + " or ";
                else
                    sql += " NGAY = @NGAY" + i.ToString();
            }

            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            for (int j = 0; j < DanhSachNgay.Length; j++)
            {
                db.AddInParameter(cmd, "@NGAY" + j.ToString(), DbType.DateTime, DanhSachNgay[j]);
            }
            string GiaTri = "";
            if (IsChot) GiaTri = "Y";
            else GiaTri = "N";
            db.AddInParameter(cmd, "@GiaTri", DbType.String, GiaTri);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public DataSet DsChamCongNhanVien(string strThangNam,string Table)
        {
            string[] M = strThangNam.Split('/');
            int mm = HelpNumber.ParseInt32(M[0]);
            int yy = HelpNumber.ParseInt32(M[1]);
            QueryBuilder query = new QueryBuilder(@"SELECT NV_ID FROM " + Table + " WHERE 1=1" );
            query.addDateFromTo("NGAY", HelpDate.GetStartOfMonth(mm, yy), HelpDate.GetEndOfMonth(mm, yy));
            query.addGroupBy("NV_ID");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query, Table);
            return ds;
        }

        //Chuyen thoi gian lam viec cua nhan vien vao db
        public bool UpdateThoiGianLamViec(long NVID, DateTime NgayLamViec, double ThoiGian)
        {
            DataSet DatailDataSet = new DataSet();
            QueryBuilder query = new QueryBuilder( "select * from BANG_CHAM_CONG where 1=1");
            query.addID("NV_ID", NVID);
            query.add(new Condition("NGAY", Operator.Equal,NgayLamViec.Date, DbType.Date));
            HelpDB.getDatabase().LoadDataSet(query, "BANG_CHAM_CONG", DatailDataSet);

            if(DatailDataSet.Tables[0].Rows.Count>0 && ThoiGian!=-1)
            {
                DatailDataSet.Tables[0].Rows[0]["THOI_GIAN_LAM_VIEC"] = ThoiGian;
            }
            DatabaseFB db = DABase.getDatabase();
            db.OpenConnection();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            try
            {
                if (db.UpdateDataSet(DatailDataSet, dbTrans) == false) return false;
            }
            catch
            {
                db.RollbackTransaction(dbTrans);
            }
            db.CommitTransaction(dbTrans);
            return true;
        }
    }
}
