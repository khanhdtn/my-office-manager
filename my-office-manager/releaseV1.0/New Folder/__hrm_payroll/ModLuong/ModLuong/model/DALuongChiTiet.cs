using System.Data.Common;
using System.Data;
using DTO;

using System;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;


namespace DAO
{
    public class DALuongChiTiet
    {
        public static DataSet ChiTietThang(long LuongID)
        {
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand("select lct.LUONG_ID,lct.TU_NGAY,lct.DEN_NGAY,lct.IS_THU_VIEC,lct.PHAN_TRAM || '%' AS PHAN_TRAM,lct.MUC_LUONG,lct.THU_NHAP,lct.SO_NGAY, iif(lct.HINH_THUC='3','Trợ cấp',iif(lct.HINH_THUC='2','Không lương',iif(lct.HINH_THUC='1','Bán thời gian',iif(lct.IS_THU_VIEC = 'Y','Thử việc','Chính thức')))) as HINH_THUC  from BANG_LUONG_CT lct where lct.LUONG_ID = " + LuongID.ToString() + " order by lct.TU_NGAY");
                DataSet ds = new DataSet();
                db.LoadDataSet(cmd, ds, "BANG_LUONG_CT");
                return ds;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return null;
        }
        public static bool IsTonTai(long ID, DateTime TuNgay, DateTime DenNgay)
        {
            return false;
        }
        public static bool ThemDong(DOLuongChiTiet luong)
        {
            bool Kq = false;
            try
            {
                //if (IsTonTai(luong.LUONG_ID,luong.TU_NGAY,luong.DEN_NGAY) == true)
                //{
                //    XtraMessageBox.Show("Đã tồn tại");
                //    return false;
                //}
                //Sql
                string Insertsql = "";
                if (luong.HINH_THUC == "0") //Toan thoi gian
                {
                    if (luong.IS_THU_VIEC == "Y")
                        Insertsql = "insert into BANG_LUONG_CT(LUONG_ID,TU_NGAY,DEN_NGAY,HINH_THUC,IS_THU_VIEC,PHAN_TRAM,MUC_LUONG,THU_NHAP,SO_NGAY)"
                                  + "values(@LUONG_ID,@TU_NGAY,@DEN_NGAY,'0','Y',@PHAN_TRAM,@MUC_LUONG,@THU_NHAP,@SO_NGAY)";
                    else
                        Insertsql = "insert into BANG_LUONG_CT(LUONG_ID,TU_NGAY,DEN_NGAY,HINH_THUC,IS_THU_VIEC,MUC_LUONG,THU_NHAP,SO_NGAY)"
                                  + "values(@LUONG_ID,@TU_NGAY,@DEN_NGAY,'0','N',@MUC_LUONG,@THU_NHAP,@SO_NGAY)";
                }
                else if (luong.HINH_THUC == "1") //Ban thoi gian
                {
                    Insertsql = "insert into BANG_LUONG_CT(LUONG_ID,TU_NGAY,DEN_NGAY,HINH_THUC,MUC_LUONG,THU_NHAP,SO_NGAY)"
                              + "values(@LUONG_ID,@TU_NGAY,@DEN_NGAY,'1',@MUC_LUONG,@THU_NHAP,@SO_NGAY)";
                }
                else if (luong.HINH_THUC == "3") //Tro cap
                    Insertsql = "insert into BANG_LUONG_CT(LUONG_ID,TU_NGAY,DEN_NGAY,HINH_THUC,MUC_LUONG,THU_NHAP,SO_NGAY) "
                              + "values(@LUONG_ID,@TU_NGAY,@DEN_NGAY,'3',@MUC_LUONG,@THU_NHAP,@SO_NGAY)";
                else //Khong luong
                    Insertsql = "insert into BANG_LUONG_CT(LUONG_ID,TU_NGAY,DEN_NGAY,HINH_THUC,MUC_LUONG,THU_NHAP,SO_NGAY) "
                              + "values (@LUONG_ID,@TU_NGAY,@DEN_NGAY,'2',0,0,@SO_NGAY)";

                //Params
                DatabaseFB db = HelpDB.getDatabase();
                System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(Insertsql);
                db.AddInParameter(cmd, "@LUONG_ID", DbType.Int64, luong.LUONG_ID);
                db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, luong.TU_NGAY);
                db.AddInParameter(cmd, "@DEN_NGAY", DbType.DateTime, luong.DEN_NGAY);

                if (luong.HINH_THUC == "0") //Toan thoi gian
                {
                    if (luong.IS_THU_VIEC == "Y") //Thu viec
                    {
                        db.AddInParameter(cmd, "@PHAN_TRAM", DbType.Int32, luong.PHAN_TRAM);
                    }
                    db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, luong.MUC_LUONG);
                    db.AddInParameter(cmd, "@THU_NHAP", DbType.Decimal, luong.THU_NHAP);
                    db.AddInParameter(cmd, "@SO_NGAY", DbType.Double, luong.SO_NGAY);
                }
                else if (luong.HINH_THUC == "1") //Ban thoi gian
                {
                    db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, luong.MUC_LUONG);
                    db.AddInParameter(cmd, "@THU_NHAP", DbType.Decimal, luong.THU_NHAP);
                    db.AddInParameter(cmd, "@SO_NGAY", DbType.Double, luong.SO_NGAY);
                }
                else if (luong.HINH_THUC == "3") //Tro cap
                {
                    db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, luong.MUC_LUONG);
                    db.AddInParameter(cmd, "@THU_NHAP", DbType.Decimal, luong.THU_NHAP);
                    db.AddInParameter(cmd, "@SO_NGAY", DbType.Double, luong.SO_NGAY);
                }
                else
                    db.AddInParameter(cmd, "@SO_NGAY", DbType.Double, luong.SO_NGAY);

                if (db.ExecuteNonQuery(cmd) > 0)
                    Kq = true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return Kq;
        }
        public static void SuaDong(DOLuongChiTiet luong)
        {
            DatabaseFB db = HelpDB.getDatabase();
            string cautruyvan = "update BANG_LUONG_CT set SO_NGAY=@SO_NGAY,THU_NHAP=@THU_NHAP WHERE LUONG_ID=@LUONG_ID and TU_NGAY=@TU_NGAY";
            DbCommand update = db.GetSQLStringCommand(cautruyvan);
            db.AddInParameter(update, "@LUONG_ID", DbType.Int64, luong.LUONG_ID);
            db.AddInParameter(update, "@TU_NGAY", DbType.DateTime, luong.TU_NGAY);
            db.AddInParameter(update, "@SO_NGAY", DbType.Double, luong.SO_NGAY);
            db.AddInParameter(update, "@THU_NHAP", DbType.Decimal, luong.THU_NHAP);            
            db.ExecuteNonQuery(update);
        }
        public static bool XoaDong(long LUONG_ID)
        {
            string er = string.Empty;
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                string cautruyvan = "delete from BANG_LUONG_CT where LUONG_ID=" + LUONG_ID + " ";
                DbCommand delete = db.GetSQLStringCommand(cautruyvan);
                db.ExecuteNonQuery(delete);
            }
            catch (System.Exception ex)
            {
                er = ex.Message;
                PLException.AddException(ex);
            }
            if (er == string.Empty)
                return true;
            return false;
        }
    }
}
