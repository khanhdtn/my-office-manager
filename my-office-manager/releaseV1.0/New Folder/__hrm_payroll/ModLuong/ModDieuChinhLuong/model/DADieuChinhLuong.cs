using System;
using DTO;
using System.Data.Common;
using System.Data;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;


namespace DAO
{
    public class DADieuChinhLuong
    {
        public static DADieuChinhLuong Ins = new DADieuChinhLuong();
        private DADieuChinhLuong()
        {

        }
        public  DataSet IsTonTai(long NV_ID, DateTime TuNgay)
        {
            string sql = "select * from DIEU_CHINH_LUONG where NV_ID = @NV_ID and TU_NGAY = @TU_NGAY";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, TuNgay);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "DIEU_CHINH_LUONG");
            if(ds.Tables[0].Rows.Count>0)
                return ds;
            return null;
        }
        public  bool ThemDong(DODieuChinhLuong dto)
        {
            bool Kq = false;
            try
            {
                if (IsTonTai(dto.NV_ID, dto.TU_NGAY) != null)
                {
                    HelpMsgBox.ShowNotificationMessage("Điều chỉnh lương của nhân viên \nnày đã có trong database");
                    return false;
                }
                string Insertsql = "";
                if (dto.HINH_THUC == "0") //Toan thoi gian
                {
                    if (dto.IS_THU_VIEC == "Y")
                        Insertsql = "insert into DIEU_CHINH_LUONG(NV_ID,TU_NGAY,HINH_THUC,IS_THU_VIEC,PHAN_TRAM,MUC_LUONG)"
                                  + "values(@NV_ID,@TU_NGAY,@HINH_THUC,'Y',@PHAN_TRAM,@MUC_LUONG)";
                    else 
                        Insertsql = "insert into DIEU_CHINH_LUONG(NV_ID,TU_NGAY,HINH_THUC,IS_THU_VIEC,MUC_LUONG)"
                                  + "values(@NV_ID,@TU_NGAY,@HINH_THUC,'N',@MUC_LUONG)";
                }
                else if (dto.HINH_THUC == "1") //Ban thoi gian
                {
                        Insertsql =  "insert into DIEU_CHINH_LUONG(NV_ID,TU_NGAY,HINH_THUC,MUC_LUONG)"
                                  +  "values(@NV_ID,@TU_NGAY,@HINH_THUC,@MUC_LUONG)";
                }else if (dto.HINH_THUC == "3") //Tro cap
                        Insertsql = "insert into DIEU_CHINH_LUONG(NV_ID,TU_NGAY,HINH_THUC,MUC_LUONG) "
                                  + "values(@NV_ID,@TU_NGAY,@HINH_THUC,@MUC_LUONG)";
                else //Khong luong
                        Insertsql = "insert into DIEU_CHINH_LUONG(NV_ID,TU_NGAY,HINH_THUC) "
                                  + "values (@NV_ID,@TU_NGAY,@HINH_THUC)";
                
                //Params
                DatabaseFB db = HelpDB.getDatabase();
                System.Data.Common.DbCommand cmd = db.GetSQLStringCommand(Insertsql);
                db.AddInParameter(cmd, "@NV_ID", DbType.Int32, dto.NV_ID);
                db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, dto.TU_NGAY);
                db.AddInParameter(cmd, "@HINH_THUC", DbType.String, dto.HINH_THUC);

                if (dto.HINH_THUC == "0") //Toan thoi gian
                {
                    if (dto.IS_THU_VIEC=="Y") //Thu viec
                    {
                        
                        db.AddInParameter(cmd, "@PHAN_TRAM", DbType.Int32, dto.PHAN_TRAM);
                        
                    }
                    db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, dto.MUC_LUONG);
                }
                else if (dto.HINH_THUC == "1") //Ban thoi gian
                {
                    db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, dto.MUC_LUONG);
                }else if (dto.HINH_THUC == "3") //Tro cap
                    db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, dto.MUC_LUONG);
                    
                if (db.ExecuteNonQuery(cmd) > 0)
                    Kq = true;
            }
            catch (Exception ex)
            {

                PLException.AddException(ex);
            }
            return Kq;

        }
        public  bool XoaDong(long NV_ID, DateTime TuNgay)
        {
            try
            {
                string sql = "delete from DIEU_CHINH_LUONG where NV_ID = @NV_ID and TU_NGAY = @TU_NGAY";
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
                db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, TuNgay);
                if (db.ExecuteNonQuery(cmd) > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return false;
            
        }
        public  bool CapNhatDong(DODieuChinhLuong dto)
        {
            bool Kq = false;
            try
            {
                //if (IsTonTai(dto.NV_ID, dto.TU_NGAY) == null)
                //{
                //    HelpMsgBox.ShowNotificationMessage("Điều chỉnh lương của nhân viên này chưa có trong database");
                //    return false;
                //}

                //Sql
                string  Updatesql = "";
                if (dto.HINH_THUC == "0") //Toan thoi gian
                {
                    if (dto.IS_THU_VIEC == "Y")
                        Updatesql = "Update DIEU_CHINH_LUONG set HINH_THUC = @HINH_THUC,IS_THU_VIEC = 'Y',PHAN_TRAM = @PHAN_TRAM,MUC_LUONG = @MUC_LUONG where NV_ID = @NV_ID and TU_NGAY = @TU_NGAY";
                    else
                        Updatesql = "Update DIEU_CHINH_LUONG set HINH_THUC = @HINH_THUC,IS_THU_VIEC = 'N',MUC_LUONG = @MUC_LUONG,PHAN_TRAM=null where NV_ID = @NV_ID and TU_NGAY = @TU_NGAY";
                }
                else if (dto.HINH_THUC == "1") //Ban thoi gian
                {
                    Updatesql = "Update DIEU_CHINH_LUONG set HINH_THUC = @HINH_THUC,MUC_LUONG = @MUC_LUONG where NV_ID = @NV_ID and TU_NGAY = @TU_NGAY";
                }
                else if (dto.HINH_THUC == "3") //Tro cap
                    Updatesql = " Update DIEU_CHINH_LUONG set HINH_THUC = @HINH_THUC,MUC_LUONG = @MUC_LUONG where NV_ID = @NV_ID and TU_NGAY = @TU_NGAY";
                else //Khong luong
                    Updatesql = " Update DIEU_CHINH_LUONG set HINH_THUC = @HINH_THUC, MUC_LUONG = null ,PHAN_TRAM = null where NV_ID = @NV_ID and TU_NGAY = @TU_NGAY";
                //Params
                DatabaseFB db = HelpDB.getDatabase();
                System.Data.Common.DbCommand cmd = db.GetSQLStringCommand( Updatesql);
                db.AddInParameter(cmd, "@NV_ID", DbType.Int32, dto.NV_ID);
                db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, dto.TU_NGAY);
                db.AddInParameter(cmd, "@HINH_THUC", DbType.String, dto.HINH_THUC);

                if (dto.HINH_THUC == "0") //Toan thoi gian
                {
                    if (dto.IS_THU_VIEC == "Y") //Thu viec
                    {

                        db.AddInParameter(cmd, "@PHAN_TRAM", DbType.Int32, dto.PHAN_TRAM);

                    }
                   
                    db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, dto.MUC_LUONG);
                }
                else if (dto.HINH_THUC == "1" || dto.HINH_THUC=="3") //Ban thoi gian,Tro cap
                {
                    db.AddInParameter(cmd, "@MUC_LUONG", DbType.Decimal, dto.MUC_LUONG);
                }
                if (db.ExecuteNonQuery(cmd) > 0)
                    Kq = true;
            }
            catch (Exception ex)
            {

                PLException.AddException(ex);
            }
            return Kq;
        }
        public DataSet TimKiem(long NV_ID, DateTime TuNgay, DateTime DenNgay)
        {
            DataSet ds = new DataSet();
            try
            {
                if (NV_ID == -1 && TuNgay == new DateTime(1, 1, 1) && DenNgay == new DateTime(1, 1, 1))
                    return null;

                #region Thông tin truy xuất
                string sql = "select nv.ID,nv.NAME,dcl.PHAN_TRAM,dcl.MUC_LUONG ,dcl.TU_NGAY, "
                            + "iif(dcl.HINH_THUC=3,'Trợ cấp',iif(dcl.HINH_THUC=2,'Không lương',iif(dcl.HINH_THUC=1,'Bán thời gian',iif(dcl.IS_THU_VIEC = 'Y','Thử việc','Chính thức')))) as HINH_THUC "
                            + "from DM_NHAN_VIEN nv, DIEU_CHINH_LUONG dcl "
                            + "where nv.ID=dcl.NV_ID ";
                #endregion
                
                #region Điều kiện where
                if (NV_ID != -1)
                {
                    sql += "and dcl.NV_ID = @NV_ID ";
                }
                if (TuNgay != new DateTime(1, 1, 1))
                {
                    sql += "and dcl.TU_NGAY >= @TU_NGAY ";
                }
                if (DenNgay != new DateTime(1, 1, 1))
                {
                    sql += "and dcl.TU_NGAY <= @DEN_NGAY";
                }
                sql += " order by TU_NGAY";
                #endregion

                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);

                #region Param
                if (NV_ID != -1)
                {
                    db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
                }
                if (TuNgay != new DateTime(1, 1, 1))
                {
                    db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, TuNgay);
                }
                if (DenNgay != new DateTime(1, 1, 1))
                {
                    db.AddInParameter(cmd, "@DEN_NGAY", DbType.DateTime, DenNgay);
                }
                #endregion
                
                db.LoadDataSet(cmd, ds, "KQ");
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                
            }
            return ds;
        }
    }
}
