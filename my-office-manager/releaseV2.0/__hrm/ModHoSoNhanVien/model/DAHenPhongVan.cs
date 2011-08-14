using System;
using System.Collections.Generic;
using System.Text;
using DTO;

using System.Data.Common;
using System.Data;
using ProtocolVN.Framework.Core;
namespace DAO
{
    public class DAHenPhongVan
    {
        public static bool InsertKhongDat(DOHenPhongVan HenPhongVan)
        {
            try
            {
                string sql = "INSERT INTO HEN_PHONG_VAN "
                + "("
                    + "ID,R_ID,NGAY_GIO_PHONG_VAN,VONG_PHONG_VAN,LAN_MOI_PHONG_VAN,MOI_PHONG_VAN,"
                    + "UNG_VIEN_XAC_NHAN,UNG_VIEN_XAC_NHAN_GHI_CHU,THAM_DU,THAM_DU_GHI_CHU,KET_QUA,"
                    + "KET_QUA_GHI_CHU,THONG_BAO_KET_QUA,"
                    + "THONG_TIN_KHAC"
                 + ")"
                 + "VALUES"
                 + "("
                    + "@ID,@R_ID,@NGAY_GIO_PHONG_VAN,@VONG_PHONG_VAN,@LAN_MOI_PHONG_VAN,@MOI_PHONG_VAN,"
                    + "@UNG_VIEN_XAC_NHAN,@UNG_VIEN_XAC_NHAN_GHI_CHU,@THAM_DU,@THAM_DU_GHI_CHU,@KET_QUA,"
                    + "@KET_QUA_GHI_CHU,@THONG_BAO_KET_QUA,"
                    + "@THONG_TIN_KHAC"
                 + ")";
                DatabaseFB db = DABase.getDatabase();
                System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, db.GetID("GEN_HEN_PHONG_VAN_ID"));
                db.AddInParameter(cmd, "@R_ID", DbType.Int64, HenPhongVan.R_ID);
                db.AddInParameter(cmd, "@NGAY_GIO_PHONG_VAN", DbType.DateTime, HenPhongVan.NGAY_GIO_PHONG_VAN);
                db.AddInParameter(cmd, "@VONG_PHONG_VAN", DbType.String, HenPhongVan.VONG_PHONG_VAN);
                db.AddInParameter(cmd, "@LAN_MOI_PHONG_VAN", DbType.String, HenPhongVan.LAN_MOI_PHONG_VAN);
                db.AddInParameter(cmd, "@MOI_PHONG_VAN", DbType.String, HenPhongVan.MOI_PHONG_VAN);
                db.AddInParameter(cmd, "@UNG_VIEN_XAC_NHAN", DbType.String, HenPhongVan.UNG_VIEN_XAC_NHAN);
                db.AddInParameter(cmd, "@UNG_VIEN_XAC_NHAN_GHI_CHU", DbType.String, HenPhongVan.UNG_VIEN_XAC_NHAN_GHI_CHU);
                db.AddInParameter(cmd, "@THAM_DU", DbType.String, HenPhongVan.THAM_DU);
                db.AddInParameter(cmd, "@THAM_DU_GHI_CHU", DbType.String, HenPhongVan.THAM_DU_GHI_CHU);
                db.AddInParameter(cmd, "@KET_QUA", DbType.String, HenPhongVan.KET_QUA);
                db.AddInParameter(cmd, "@KET_QUA_GHI_CHU", DbType.String, HenPhongVan.KET_QUA_GHI_CHU);
                db.AddInParameter(cmd, "@THONG_BAO_KET_QUA", DbType.String, HenPhongVan.THONG_BAO_KET_QUA);
                db.AddInParameter(cmd, "@THONG_TIN_KHAC", DbType.String, HenPhongVan.THONG_TIN_KHAC);
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
        public static bool InsertDat(DOHenPhongVan HenPhongVan)
        {
            try
            {
                string sql = "INSERT INTO HEN_PHONG_VAN "
                + "("
                    + "ID,R_ID,NGAY_GIO_PHONG_VAN,VONG_PHONG_VAN,LAN_MOI_PHONG_VAN,MOI_PHONG_VAN,"
                    + "UNG_VIEN_XAC_NHAN,UNG_VIEN_XAC_NHAN_GHI_CHU,THAM_DU,THAM_DU_GHI_CHU,KET_QUA,"
                    + "NGAY_BAT_DAU,THOI_GIAN_LAM_VIEC,KET_QUA_GHI_CHU,"
                    + "UNG_VIEN_DA_CHAP_NHAN,THONG_BAO_KET_QUA,"
                    + "MUC_LUONG,THONG_TIN_KHAC"
                    //+ ",ISHL_TV_TT,SO_NGAY,DEN_NGAY" //Them
                 + ")"
                 + "VALUES"
                 + "("
                    + "@ID,@R_ID,@NGAY_GIO_PHONG_VAN,@VONG_PHONG_VAN,@LAN_MOI_PHONG_VAN,@MOI_PHONG_VAN,"
                    + "@UNG_VIEN_XAC_NHAN,@UNG_VIEN_XAC_NHAN_GHI_CHU,@THAM_DU,@THAM_DU_GHI_CHU,@KET_QUA,"
                    + "@NGAY_BAT_DAU,@THOI_GIAN_LAM_VIEC,@KET_QUA_GHI_CHU,"
                    + "@UNG_VIEN_DA_CHAP_NHAN,@THONG_BAO_KET_QUA,"
                    + "@MUC_LUONG,@THONG_TIN_KHAC"
                    //+ ",@ISHL_TV_TT,@SO_NGAY,@DEN_NGAY"
                 + ")";
                DatabaseFB db = DABase.getDatabase();
                System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, db.GetID("GEN_HEN_PHONG_VAN_ID"));
                db.AddInParameter(cmd, "@R_ID", DbType.Int64, HenPhongVan.R_ID);
                db.AddInParameter(cmd, "@NGAY_GIO_PHONG_VAN", DbType.DateTime, HenPhongVan.NGAY_GIO_PHONG_VAN);
                db.AddInParameter(cmd, "@VONG_PHONG_VAN", DbType.String, HenPhongVan.VONG_PHONG_VAN);
                db.AddInParameter(cmd, "@LAN_MOI_PHONG_VAN", DbType.String, HenPhongVan.LAN_MOI_PHONG_VAN);
                db.AddInParameter(cmd, "@MOI_PHONG_VAN", DbType.String,HenPhongVan.MOI_PHONG_VAN );
                db.AddInParameter(cmd, "@UNG_VIEN_XAC_NHAN", DbType.String, HenPhongVan.UNG_VIEN_XAC_NHAN);
                db.AddInParameter(cmd, "@UNG_VIEN_XAC_NHAN_GHI_CHU", DbType.String, HenPhongVan.UNG_VIEN_XAC_NHAN_GHI_CHU);
                db.AddInParameter(cmd, "@THAM_DU", DbType.String, HenPhongVan.THAM_DU);
                db.AddInParameter(cmd, "@THAM_DU_GHI_CHU", DbType.String, HenPhongVan.THAM_DU_GHI_CHU);
                db.AddInParameter(cmd, "@KET_QUA", DbType.String, HenPhongVan.KET_QUA);
                db.AddInParameter(cmd, "@NGAY_BAT_DAU", DbType.DateTime, HenPhongVan.NGAY_BAT_DAU);
                db.AddInParameter(cmd, "@THOI_GIAN_LAM_VIEC", DbType.String, HenPhongVan.THOI_GIAN_LAM_VIEC);
                db.AddInParameter(cmd, "@KET_QUA_GHI_CHU", DbType.String, HenPhongVan.KET_QUA_GHI_CHU);
                db.AddInParameter(cmd, "@UNG_VIEN_DA_CHAP_NHAN", DbType.String, HenPhongVan.UNG_VIEN_DA_CHAP_NHAN);
                db.AddInParameter(cmd, "@THONG_BAO_KET_QUA", DbType.String, HenPhongVan.THONG_BAO_KET_QUA);
                db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, HenPhongVan.MUC_LUONG);
                db.AddInParameter(cmd, "@THONG_TIN_KHAC", DbType.String, HenPhongVan.THONG_TIN_KHAC);

                //Them
                //db.AddInParameter(cmd, "@ISHL_TV_TT", DbType.String, HenPhongVan.ISHL_TV_TT);
                //db.AddInParameter(cmd, "@SO_NGAY", DbType.Int64, HenPhongVan.SO_NGAY);
                //db.AddInParameter(cmd, "@DEN_NGAY", DbType.DateTime, HenPhongVan.DEN_NGAY);
                int iCmd = db.ExecuteNonQuery(cmd);

                //Xử lý phần Quản lý danh sách Training,...

                if (iCmd > 0)
                    return true;
                return false;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static bool InsertChoKetQua(DOHenPhongVan HenPhongVan)
        {
            try
            {
                string sql = "INSERT INTO HEN_PHONG_VAN "
                + "("
                    + "ID,R_ID,NGAY_GIO_PHONG_VAN,VONG_PHONG_VAN,LAN_MOI_PHONG_VAN,MOI_PHONG_VAN,"
                    + "UNG_VIEN_XAC_NHAN,UNG_VIEN_XAC_NHAN_GHI_CHU,THAM_DU,THAM_DU_GHI_CHU,KET_QUA,"
                    + "KET_QUA_GHI_CHU,"
                    + "THONG_TIN_KHAC"
                 + ")"
                 + "VALUES"
                 + "("
                    + "@ID,@R_ID,@NGAY_GIO_PHONG_VAN,@VONG_PHONG_VAN,@LAN_MOI_PHONG_VAN,@MOI_PHONG_VAN,"
                    + "@UNG_VIEN_XAC_NHAN,@UNG_VIEN_XAC_NHAN_GHI_CHU,@THAM_DU,@THAM_DU_GHI_CHU,@KET_QUA,"
                    + "@KET_QUA_GHI_CHU,"
                    + "@THONG_TIN_KHAC"
                 + ")";
                DatabaseFB db = DABase.getDatabase();
                System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, db.GetID("GEN_HEN_PHONG_VAN_ID"));
                db.AddInParameter(cmd, "@R_ID", DbType.Int64, HenPhongVan.R_ID);
                db.AddInParameter(cmd, "@NGAY_GIO_PHONG_VAN", DbType.DateTime, HenPhongVan.NGAY_GIO_PHONG_VAN);
                db.AddInParameter(cmd, "@VONG_PHONG_VAN", DbType.String, HenPhongVan.VONG_PHONG_VAN);
                db.AddInParameter(cmd, "@LAN_MOI_PHONG_VAN", DbType.String, HenPhongVan.LAN_MOI_PHONG_VAN);
                db.AddInParameter(cmd, "@MOI_PHONG_VAN", DbType.String, HenPhongVan.MOI_PHONG_VAN);
                db.AddInParameter(cmd, "@UNG_VIEN_XAC_NHAN", DbType.String, HenPhongVan.UNG_VIEN_XAC_NHAN);
                db.AddInParameter(cmd, "@UNG_VIEN_XAC_NHAN_GHI_CHU", DbType.String, HenPhongVan.UNG_VIEN_XAC_NHAN_GHI_CHU);
                db.AddInParameter(cmd, "@THAM_DU", DbType.String, HenPhongVan.THAM_DU);
                db.AddInParameter(cmd, "@THAM_DU_GHI_CHU", DbType.String, HenPhongVan.THAM_DU_GHI_CHU);
                db.AddInParameter(cmd, "@KET_QUA", DbType.String, HenPhongVan.KET_QUA);
                db.AddInParameter(cmd, "@KET_QUA_GHI_CHU", DbType.String, HenPhongVan.KET_QUA_GHI_CHU);
                db.AddInParameter(cmd, "@THONG_TIN_KHAC", DbType.String, HenPhongVan.THONG_TIN_KHAC);
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
        public static bool DeleteByUngVien(long R_ID)
        {
            try
            {
                string sql = "DELETE FROM HEN_PHONG_VAN "
                            + "WHERE R_ID = @R_ID";
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@R_ID", DbType.Int64,R_ID);
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
        public static bool Update(DOHenPhongVan HenPhongVan)
        {
            try
            {

                string sql = "UPDATE HEN_PHONG_VAN "
                + "SET "
                    + "NGAY_GIO_PHONG_VAN =@NGAY_GIO_PHONG_VAN ,"
                    + "VONG_PHONG_VAN=@VONG_PHONG_VAN,"
                    + "LAN_MOI_PHONG_VAN = @LAN_MOI_PHONG_VAN,"
                    + "MOI_PHONG_VAN = @MOI_PHONG_VAN,"
                    + "UNG_VIEN_XAC_NHAN =@UNG_VIEN_XAC_NHAN,"
                    + "UNG_VIEN_XAC_NHAN_GHI_CHU = @UNG_VIEN_XAC_NHAN_GHI_CHU,"
                    + "THAM_DU = @THAM_DU,"
                    + "THAM_DU_GHI_CHU = @THAM_DU_GHI_CHU,"
                    + "KET_QUA = @KET_QUA,"
                    + "NGAY_BAT_DAU = @NGAY_BAT_DAU,"
                    + "THOI_GIAN_LAM_VIEC = @THOI_GIAN_LAM_VIEC,"
                    + "KET_QUA_GHI_CHU = @KET_QUA_GHI_CHU,"
                    + "UNG_VIEN_DA_CHAP_NHAN = @UNG_VIEN_DA_CHAP_NHAN,"
                    + "THONG_BAO_KET_QUA = @THONG_BAO_KET_QUA,"
                    + "MUC_LUONG = @MUC_LUONG, "
                    + "THONG_TIN_KHAC = @THONG_TIN_KHAC "
                    //+ ",SO_NGAY=@SO_NGAY, "
                    //+ "DEN_NGAY = @DEN_NGAY "
                 + "WHERE R_ID=@R_ID";
                 
                DatabaseFB db = DABase.getDatabase();
                System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@R_ID", DbType.Int64, HenPhongVan.R_ID);
                db.AddInParameter(cmd, "@NGAY_GIO_PHONG_VAN", DbType.DateTime, HenPhongVan.NGAY_GIO_PHONG_VAN);
                db.AddInParameter(cmd, "@VONG_PHONG_VAN", DbType.String, HenPhongVan.VONG_PHONG_VAN);
                db.AddInParameter(cmd, "@LAN_MOI_PHONG_VAN", DbType.String, HenPhongVan.LAN_MOI_PHONG_VAN);
                db.AddInParameter(cmd, "@MOI_PHONG_VAN", DbType.String, HenPhongVan.MOI_PHONG_VAN);
                db.AddInParameter(cmd, "@UNG_VIEN_XAC_NHAN", DbType.String, HenPhongVan.UNG_VIEN_XAC_NHAN);
                db.AddInParameter(cmd, "@UNG_VIEN_XAC_NHAN_GHI_CHU", DbType.String, HenPhongVan.UNG_VIEN_XAC_NHAN_GHI_CHU);
                db.AddInParameter(cmd, "@THAM_DU", DbType.String, HenPhongVan.THAM_DU);
                db.AddInParameter(cmd, "@THAM_DU_GHI_CHU", DbType.String, HenPhongVan.THAM_DU_GHI_CHU);
                db.AddInParameter(cmd, "@KET_QUA", DbType.String, HenPhongVan.KET_QUA);
                if(HenPhongVan.NGAY_BAT_DAU== new DateTime(1900,1,1))
                    db.AddInParameter(cmd, "@NGAY_BAT_DAU", DbType.DateTime, DBNull.Value);
                else
                    db.AddInParameter(cmd, "@NGAY_BAT_DAU", DbType.DateTime, HenPhongVan.NGAY_BAT_DAU);
                db.AddInParameter(cmd, "@THOI_GIAN_LAM_VIEC", DbType.String, HenPhongVan.THOI_GIAN_LAM_VIEC);
                
                db.AddInParameter(cmd, "@KET_QUA_GHI_CHU", DbType.String, HenPhongVan.KET_QUA_GHI_CHU);
                
                db.AddInParameter(cmd, "@UNG_VIEN_DA_CHAP_NHAN", DbType.String, HenPhongVan.UNG_VIEN_DA_CHAP_NHAN);
                db.AddInParameter(cmd, "@THONG_BAO_KET_QUA", DbType.String, HenPhongVan.THONG_BAO_KET_QUA);
                db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, HenPhongVan.MUC_LUONG);
                db.AddInParameter(cmd, "@THONG_TIN_KHAC", DbType.String, HenPhongVan.THONG_TIN_KHAC);

                //them
                //db.AddInParameter(cmd, "@SO_NGAY", DbType.Int64, HenPhongVan.SO_NGAY);
                //db.AddInParameter(cmd, "@DEN_NGAY", DbType.DateTime, HenPhongVan.DEN_NGAY);

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
        public static DOHenPhongVan getHenPhongVan_NOTD(long R_ID)
        {
            string sql = "select * from HEN_PHONG_VAN where R_ID = " + R_ID.ToString() + "and 1=1";
            QueryBuilder query = new QueryBuilder(sql);
            DataSet ds = DABase.getDatabase().LoadDataSet(query, "AA");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            DOHenPhongVan HenPhongVan = new DOHenPhongVan();
            HenPhongVan.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            HenPhongVan.R_ID = R_ID;
            HenPhongVan.NGAY_GIO_PHONG_VAN = (DateTime)ds.Tables[0].Rows[0]["NGAY_GIO_PHONG_VAN"];
            HenPhongVan.VONG_PHONG_VAN = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["VONG_PHONG_VAN"]);
            HenPhongVan.LAN_MOI_PHONG_VAN = HelpNumber.ParseInt32(ds.Tables[0].Rows[0]["LAN_MOI_PHONG_VAN"]);
            HenPhongVan.MOI_PHONG_VAN = ds.Tables[0].Rows[0]["MOI_PHONG_VAN"].ToString();
            HenPhongVan.UNG_VIEN_XAC_NHAN = ds.Tables[0].Rows[0]["UNG_VIEN_XAC_NHAN"].ToString();
            HenPhongVan.UNG_VIEN_XAC_NHAN_GHI_CHU = ds.Tables[0].Rows[0]["UNG_VIEN_XAC_NHAN_GHI_CHU"].ToString();
            HenPhongVan.THAM_DU = ds.Tables[0].Rows[0]["THAM_DU"].ToString();
            HenPhongVan.THAM_DU_GHI_CHU = ds.Tables[0].Rows[0]["THAM_DU_GHI_CHU"].ToString();
            HenPhongVan.KET_QUA = ds.Tables[0].Rows[0]["KET_QUA"].ToString();
            HenPhongVan.NGAY_BAT_DAU = (ds.Tables[0].Rows[0]["NGAY_BAT_DAU"].ToString() != "") ? (DateTime)ds.Tables[0].Rows[0]["NGAY_BAT_DAU"] : new DateTime(1900, 1, 1);
            HenPhongVan.THOI_GIAN_LAM_VIEC = ds.Tables[0].Rows[0]["THOI_GIAN_LAM_VIEC"].ToString();
            HenPhongVan.KET_QUA_GHI_CHU = ds.Tables[0].Rows[0]["KET_QUA_GHI_CHU"].ToString();
            HenPhongVan.UNG_VIEN_DA_CHAP_NHAN = ds.Tables[0].Rows[0]["UNG_VIEN_DA_CHAP_NHAN"].ToString();
            HenPhongVan.THONG_BAO_KET_QUA = ds.Tables[0].Rows[0]["THONG_BAO_KET_QUA"].ToString();
            HenPhongVan.MUC_LUONG = HelpNumber.DecimalToInt64(ds.Tables[0].Rows[0]["MUC_LUONG"]);
            HenPhongVan.THONG_TIN_KHAC = ds.Tables[0].Rows[0]["THONG_TIN_KHAC"].ToString();
           
            //HenPhongVan.DEN_NGAY = (ds.Tables[0].Rows[0]["DEN_NGAY"].ToString() != "") ? (DateTime)ds.Tables[0].Rows[0]["DEN_NGAY"] : new DateTime(1900, 1, 1);
            //HenPhongVan.SO_NGAY = HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["SO_NGAY"]);

            return HenPhongVan;
        }
        public static DOHenPhongVan getHenPhongVan(long UV_ID)
        {
            string sql = "select * from HEN_PHONG_VAN where R_ID = " + UV_ID.ToString() +  " and 1=1";
            QueryBuilder query = new QueryBuilder(sql);
            DataSet ds =  DABase.getDatabase().LoadDataSet(query, "AA");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            DOHenPhongVan HenPhongVan = new DOHenPhongVan();
            HenPhongVan.ID = long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            HenPhongVan.R_ID = UV_ID;
            HenPhongVan.NGAY_GIO_PHONG_VAN = (DateTime)ds.Tables[0].Rows[0]["NGAY_GIO_PHONG_VAN"];
            HenPhongVan.VONG_PHONG_VAN =int.Parse( ds.Tables[0].Rows[0]["VONG_PHONG_VAN"].ToString());
            HenPhongVan.LAN_MOI_PHONG_VAN = int.Parse(ds.Tables[0].Rows[0]["LAN_MOI_PHONG_VAN"].ToString());
            HenPhongVan.MOI_PHONG_VAN = ds.Tables[0].Rows[0]["MOI_PHONG_VAN"].ToString();
            HenPhongVan.UNG_VIEN_XAC_NHAN = ds.Tables[0].Rows[0]["UNG_VIEN_XAC_NHAN"].ToString();
            HenPhongVan.UNG_VIEN_XAC_NHAN_GHI_CHU = ds.Tables[0].Rows[0]["UNG_VIEN_XAC_NHAN_GHI_CHU"].ToString();
            HenPhongVan.THAM_DU = ds.Tables[0].Rows[0]["THAM_DU"].ToString();
            HenPhongVan.THAM_DU_GHI_CHU = ds.Tables[0].Rows[0]["THAM_DU_GHI_CHU"].ToString();
            HenPhongVan.KET_QUA = ds.Tables[0].Rows[0]["KET_QUA"].ToString();
            HenPhongVan.NGAY_BAT_DAU = (ds.Tables[0].Rows[0]["NGAY_BAT_DAU"].ToString()!="") ? (DateTime)ds.Tables[0].Rows[0]["NGAY_BAT_DAU"] : new DateTime(1,1,1);
            HenPhongVan.THOI_GIAN_LAM_VIEC = ds.Tables[0].Rows[0]["THOI_GIAN_LAM_VIEC"].ToString();
            HenPhongVan.KET_QUA_GHI_CHU = ds.Tables[0].Rows[0]["KET_QUA_GHI_CHU"].ToString();
            HenPhongVan.UNG_VIEN_DA_CHAP_NHAN = ds.Tables[0].Rows[0]["UNG_VIEN_DA_CHAP_NHAN"].ToString();
            HenPhongVan.THONG_BAO_KET_QUA = ds.Tables[0].Rows[0]["THONG_BAO_KET_QUA"].ToString();
            HenPhongVan.MUC_LUONG = HelpNumber.ParseDecimal(ds.Tables[0].Rows[0]["MUC_LUONG"].ToString());
            HenPhongVan.THONG_TIN_KHAC = ds.Tables[0].Rows[0]["THONG_TIN_KHAC"].ToString();

            //HenPhongVan.DEN_NGAY = (ds.Tables[0].Rows[0]["DEN_NGAY"].ToString() != "") ? (DateTime)ds.Tables[0].Rows[0]["DEN_NGAY"] : new DateTime(1900, 1, 1);
            //HenPhongVan.SO_NGAY = HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["SO_NGAY"]);

            return HenPhongVan;
        }
        public static bool Exist(long IDUV)
        {
            string sql = "select * from HEN_PHONG_VAN where R_ID = @R_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@R_ID", DbType.Int64,IDUV);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            return false;
        }
        public static bool ExistRecord(long R_ID)
        {
            string sql = "select * from HEN_PHONG_VAN where R_ID = @R_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@R_ID", DbType.Int64, R_ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            return false;
        }
        public static bool Delete(long IDUngVien)
        {
            string sql = "delete  from HEN_PHONG_VAN where R_ID = @R_ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@R_ID", DbType.Int64, IDUngVien);
            if(db.ExecuteNonQuery(cmd)>0)
                return true;
            return false;
        }
        public static bool DeleteByID(long ID)
        {
            string sql = "delete  from HEN_PHONG_VAN where ID = @ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
    }
}
