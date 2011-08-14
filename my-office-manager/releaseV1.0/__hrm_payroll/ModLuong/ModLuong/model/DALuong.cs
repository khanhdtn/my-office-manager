using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.Common;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using ProtocolVN.App.Office;

namespace DAO
{
    public class DALuong
    {
        public static DALuong Ins = new DALuong();
        private DALuong()
        {

        }
        public  bool DeleteBangLuong(string ThangNam)
        {
            string sql = "Delete from bang_luong where thang_nam ='" + ThangNam + "'";
            DatabaseFB fb = HelpDB.getDatabase();
            DbCommand cmd = fb.GetSQLStringCommand(sql);
            if (fb.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public DataTable LayDong(long ID)
        {
            try
            {
                QueryBuilder query = new QueryBuilder("select l.*, nv.NAME from BANG_LUONG l , DM_NHAN_VIEN nv where l.ID = " + ID.ToString() + " and nv.ID = l.NV_ID and 1=1");
                DataSet ds = HelpDB.getDatabase().LoadDataSet(query, "BANG_LUONG");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return null;
        }
        public DataSet TimKiem(long NV_ID, string ThangNam)
        {
            DataSet ds = new DataSet();
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand("select l.*, nv.NAME,l.tong_thu_nhap-l.tam_ung con_lai from BANG_LUONG l , DM_NHAN_VIEN nv where NV_ID = " + NV_ID + " and THANG_NAM = '" + ThangNam + "' and nv.ID = l.NV_ID order by nv.NAME");

                db.LoadDataSet(cmd,ds, "BANG_LUONG");
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return ds;
        }
        public DataSet LayThang(string ThangNam)
        {
            try
            {
                QueryBuilder query = new QueryBuilder("select l.*, nv.NAME,l.tong_thu_nhap-l.tam_ung con_lai from BANG_LUONG l , DM_NHAN_VIEN nv where  l.THANG_NAM = '" + ThangNam + "' and nv.ID = l.NV_ID and 1=1");
                query.setAscOrderBy("nv.NAME");
                DataSet ds = HelpDB.getDatabase().LoadDataSet(query, "BANG_LUONG");
                return ds;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return null;
        }
        public long GetID()
        {
            return HelpDB.getDatabase().GetID("GEN_BANG_LUONG_ID");
        }
        public bool IsTonTai(long NV_ID, string ThangNam)
        {
            bool Kq = false;
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                string Sql = "select * from BANG_LUONG where NV_ID = @NV_ID and THANG_NAM = @THANG_NAM";
                DbCommand Select = db.GetSQLStringCommand(Sql);
                db.AddInParameter(Select, "@NV_ID", DbType.Int32, NV_ID);
                db.AddInParameter(Select, "@THANG_NAM", DbType.String, ThangNam);
                DataSet ds = new DataSet();
                db.LoadDataSet(Select, ds, "BANG_LUONG");
                if(ds.Tables[0].Rows.Count >0)
                    Kq = true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return Kq;
        }
        public bool ThemDong(DOLuong luong)
        {
            bool Kq = false;
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                string InsertSql = "insert into BANG_LUONG(ID,NV_ID,THANG_NAM,TONG_THU_NHAP,TAM_UNG,IS_CHOT,DA_THANH_TOAN,TT_CON_LAI) values(@ID,@NV_ID,@THANG_NAM,@TONG_THU_NHAP,@TAM_UNG,'N',0,@TT_CON_LAI)";
                DbCommand insert = db.GetSQLStringCommand(InsertSql);
                db.AddInParameter(insert, "@ID", DbType.Int32, luong.ID);
                db.AddInParameter(insert, "@NV_ID", DbType.Int32, luong.NV_ID);
                db.AddInParameter(insert, "@THANG_NAM", DbType.String, luong.THANG_NAM);
                db.AddInParameter(insert, "@TONG_THU_NHAP", DbType.Decimal, luong.TONG_THU_NHAP);
                db.AddInParameter(insert, "@TAM_UNG", DbType.Decimal, luong.TAM_UNG);
                db.AddInParameter(insert, "@TT_CON_LAI", DbType.Decimal, luong.TONG_THU_NHAP-luong.TAM_UNG-0);
                if (db.ExecuteNonQuery(insert) > 0)
                    Kq = true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return Kq;
            
        }
        public bool SuaDong(DOLuong luong)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string cautruyvan = @"update BANG_LUONG set TONG_THU_NHAP=@TONG_THU_NHAP,TAM_UNG=@TAM_UNG,TT_CON_LAI = @TT_CON_LAI - DA_THANH_TOAN WHERE ID=@ID ";
            DbCommand update = db.GetSQLStringCommand(cautruyvan);
            db.AddInParameter(update, "@ID", DbType.Int32, luong.ID);
            db.AddInParameter(update, "@TONG_THU_NHAP", DbType.Decimal, luong.TONG_THU_NHAP);
            db.AddInParameter(update, "@TAM_UNG", DbType.Decimal, luong.TAM_UNG);
            db.AddInParameter(update, "@TT_CON_LAI", DbType.Decimal, luong.TONG_THU_NHAP-luong.TAM_UNG);
            if (db.ExecuteNonQuery(update) > 0)
                return true;
            return false;
        }
        public long GetLuong_ID(long NV_ID, string ThangNam)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string cautruyvan = "select ID from BANG_LUONG where NV_ID = @NV_ID and THANG_NAM = @THANG_NAM";
            DbCommand select = db.GetSQLStringCommand(cautruyvan);
            db.AddInParameter(select, "@NV_ID", DbType.Int32, NV_ID);
            db.AddInParameter(select, "@THANG_NAM", DbType.String, ThangNam);
            DataSet ds = new DataSet();
            db.LoadDataSet(select, ds, "BANG_LUONG");
            if (ds.Tables[0].Rows.Count > 0)
                return long.Parse( ds.Tables[0].Rows[0]["ID"].ToString());
            return -1;
        }
        public bool XoaDong(long ID)
        {
            string er = string.Empty;
            try
            {
                DALuongChiTiet.XoaDong(ID);
                DatabaseFB db = HelpDB.getDatabase();
                string DelSql = "delete from BANG_LUONG where ID=" + ID.ToString();
                DbCommand delete = db.GetSQLStringCommand(DelSql);
                db.ExecuteNonQuery(delete);
            }
            catch (Exception ex)
            {
                er = ex.Message;
                PLException.AddException(ex);
            }
            if (er == string.Empty)
                return true;
            return false;

        }
        public bool getStatusChot(string BangLuong)
        {
            QueryBuilder query = new QueryBuilder("select is_chot from bang_luong where 1=1");
            query.addCondition("thang_nam='" + BangLuong + "'");
            DatabaseFB fb = HelpDB.getDatabase();
            DataSet ds = new DataSet();
            fb.LoadDataSet(ds,query, "BANG_LUONG");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IS_CHOT"].ToString() == "Y")
                    return true;
            }
            return false;
        }
        public bool IsChotBangLuong(string BangLuong, bool? status)
        {
            string sqlUpdate = @"update bang_luong set is_chot =" + ((status == true) ? "'Y'" : "'N'")
                            + " where thang_nam = '" + BangLuong + "'";
            DatabaseFB fb = HelpDB.getDatabase();
            DbCommand cmd = fb.GetSQLStringCommand(sqlUpdate);
            int update = fb.ExecuteNonQuery(cmd);
            return (update >= 0);
        }

        public static bool ApplyPermissionData()
        {
            Feature fQuanTriTienLuong = Permission.loadFeature(AppPermission.FQuanTriTienLuong.id
                , AppPermission.FQuanTriTienLuong.featureName, FrameworkParams.currentUser.username);
            return fQuanTriTienLuong.isRead;
        }
    }
}
