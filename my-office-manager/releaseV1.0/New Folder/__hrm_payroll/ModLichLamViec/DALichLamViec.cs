using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using System.Data.Common;
using DTO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace DAO
{
    public class DALichLamViec
    {
        private DatabaseFB db = null;
        private DbCommand cmd = null;
        private DataSet ds = null;
        public static DALichLamViec Install = new DALichLamViec();
        private DALichLamViec()
        {

        }
        public DataTable getLichMoiNhat()
        {
            string sql = "SELECT llv.*,nv.NAME "
                        + "FROM LICH_LAM_VIEC llv , DM_NHAN_VIEN nv "
                        + "WHERE nv.ID = llv.NV_ID "
                        + "AND llv.NGAY_DAU_TUAN = (SELECT MAX(llv1.NGAY_DAU_TUAN) FROM  LICH_LAM_VIEC  llv1) "
                        + "AND 1=1 ORDER BY nv.NAME DESC";
            db = HelpDB.getDatabase();
            ds = db.LoadDataSet(sql,"AA");
            if (ds != null)
                return ds.Tables[0];
            return null;
        }
        public long getGenID()
        {
            return HelpGen.DT();
        }
        public DataSet getLoadAll()
        {
            return HelpDB.getDatabase().LoadTable("LICH_LAM_VIEC");
        }
        public DataTable getLichCoDinh()
        {
            try
            {
                string sql = "select llv.*, nv.NAME "
                            + "from LICH_LAM_VIEC llv, DM_NHAN_VIEN nv "
                            + "where nv.ID = llv.NV_ID "
                            + "and NGAY_DAU_TUAN is null order by nv.NAME";
                ds = new DataSet();
                db = HelpDB.getDatabase();
                cmd = db.GetSQLStringCommand(sql);
                db.LoadDataSet(cmd, ds, "LICH_LAM_VIEC");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public DataTable TimKiem(DateTime InputNgayDauTuan)
        {
            try
            {
                string sql = "select llv.*, nv.NAME from LICH_LAM_VIEC llv, DM_NHAN_VIEN nv where nv.ID = llv.NV_ID and NGAY_DAU_TUAN = @NGAY_DAU_TUAN order by nv.NAME";
                ds = new DataSet();
                db = HelpDB.getDatabase();
                cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@NGAY_DAU_TUAN", System.Data.DbType.DateTime, InputNgayDauTuan);
                db.LoadDataSet(cmd, ds, "LICH_LAM_VIEC");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        public bool Insert_LichCoDinh(DOLichLamViec dto)
        {
            if (this.Exist_LCDNhanVien(dto.NV_ID))
                return false;
            string sql = "Insert into LICH_LAM_VIEC(ID,NV_ID,ST2,CT2,ST3,CT3,ST4,CT4,ST5,CT5,ST6,CT6,ST7,CT7,ST8,CT8,GHI_CHU) values(@ID,@NV_ID,";
            for (int i = 0; i < dto.NGAY.Length; i++)
            {
                sql += "'" + dto.NGAY[i] + "',";
            }
            sql += "@GHI_CHU)";
            db = HelpDB.getDatabase();
            cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", System.Data.DbType.Int64, dto.ID);
            db.AddInParameter(cmd, "@NV_ID", System.Data.DbType.Int64, dto.NV_ID);
            db.AddInParameter(cmd, "@GHI_CHU", System.Data.DbType.String, dto.GHI_CHU);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;

        }
        public bool Insert_LichTuan(DOLichLamViec dto)
        {
            if (Exist_LichTuanNhanVien(dto.NGAY_DAU_TUAN, dto.NV_ID))
                return false;
            string sql = "Insert into LICH_LAM_VIEC(ID,NV_ID,NGAY_DAU_TUAN,ST2,CT2,ST3,CT3,ST4,CT4,ST5,CT5,ST6,CT6,ST7,CT7,ST8,CT8,GHI_CHU) values(@ID,@NV_ID,@NGAY_DAU_TUAN,";
            for (int i = 0; i < dto.NGAY.Length; i++)
            {
                sql += "'" + dto.NGAY[i] + "',";
            }
            sql += "'" + dto.GHI_CHU + "')";
            db = HelpDB.getDatabase();
            cmd = db.GetSQLStringCommand(sql);
            if (dto.ID.ToString() != "")
                db.AddInParameter(cmd, "@ID", System.Data.DbType.Int64, dto.ID);
            else
                db.AddInParameter(cmd, "@ID", System.Data.DbType.Int64, getGenID());
            db.AddInParameter(cmd, "@NV_ID", System.Data.DbType.Int64, dto.NV_ID);
            db.AddInParameter(cmd, "@NGAY_DAU_TUAN", System.Data.DbType.DateTime, dto.NGAY_DAU_TUAN);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public bool Exist_LichTuan(DateTime InputNgayDauTuan)
        {
            if (TimKiem(InputNgayDauTuan).Rows.Count > 0)
                return true;
            return false;
        }
        public bool Exist_LichCoDinh()
        {
            if (this.getLichCoDinh().Rows.Count >= 1)
                return true;
            return false;
        }
        public bool Exist_LichTuanNhanVien(DateTime Ngay, long NV_ID)
        {
            string sql = "select * from LICH_LAM_VIEC where NV_ID = @NV_ID and NGAY_DAU_TUAN = @NGAY";
            db = HelpDB.getDatabase();
            cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, Ngay);
            if (db.LoadDataSet(cmd, "AA").Tables[0].Rows.Count > 0)
                return true;
            return false;
        }
        public bool Exist_LCDNhanVien(long NV_ID)
        {
            string sql = "select * from LICH_LAM_VIEC where NV_ID = @NV_ID and NGAY_DAU_TUAN is null";
            db = HelpDB.getDatabase();
            cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            return false;
        }
        public bool DeleteRow(long ID, long NV_ID)
        {
            string sql = "delete from LICH_LAM_VIEC where NV_ID = @NV_ID and ID = @ID";
            db = HelpDB.getDatabase();
            cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public int CountRecord(string TableName)
        {
            return HelpDB.getDatabase().LoadTable(TableName).Tables[0].Rows.Count;
        }
        public bool Create_LichCoDinh(DataTable Input_dsNhanVien)
        {
            if (this.Exist_LichCoDinh() == true)
            {
                HelpMsgBox.ShowErrorMessage("Lịch cố định đã tồn tại, bạn không thể tạo");
                return false;
            }
            else
            {
                try
                {
                    FrameworkParams.wait = new WaitingMsg();
                    if (Input_dsNhanVien == null || Input_dsNhanVien.Rows.Count == 0)
                    {
                        HelpMsgBox.ShowErrorMessage("Chưa có nhân viên trong csdl");
                        return false;
                    }
                    foreach (DataRow dr in Input_dsNhanVien.Rows)
                    {
                        DOLichLamViec lcdDTO = new DOLichLamViec();
                        lcdDTO.ID = this.getGenID();
                        lcdDTO.GHI_CHU = "";
                        lcdDTO.NV_ID = int.Parse(dr["ID"].ToString());
                        lcdDTO.NGAY = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                        this.Insert_LichCoDinh(lcdDTO);
                    }
                }
                finally
                {
                    if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
                }
            }
            return true;
        }
        public void DeleteRows(Dictionary<int, DOLichLamViec> Inputs)
        {
            for (int i = 0; i < Inputs.Count; i++)
            {
                DOLichLamViec Lich = (DOLichLamViec)Inputs[i];
                this.DeleteRow(Lich.ID, Lich.NV_ID);
            }
        }
        public bool UpdateRow(DOLichLamViec Lich)
        {
            string sql = "Update LICH_LAM_VIEC set ";
            int cn = 0;
            for (int i = 2; i <= 8; i++)
            {
                sql += "ST" + i.ToString() + "= '" + Lich.NGAY[cn] + "', "; cn++;
                sql += "CT" + i.ToString() + "= '" + Lich.NGAY[cn] + "', "; cn++;
            }
            sql += "GHI_CHU = '" + Lich.GHI_CHU + "'";
            sql += " where ID = @ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, Lich.ID);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public bool UpdateDataSet(DataSet ds, bool b_LCD)
        {
            string er = string.Empty;
            ds.AcceptChanges();
            try
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        dr.SetModified();
                        DOLichLamViec lichDTO = new DOLichLamViec();
                        lichDTO.ID = long.Parse(dr["ID"].ToString());
                        lichDTO.NV_ID = long.Parse(dr["NV_ID"].ToString());
                        int cn = 0;
                        for (int i = 2; i <= 8; i++)
                        {
                            lichDTO.NGAY[cn] = dr["ST" + i.ToString()].ToString(); cn++;
                            lichDTO.NGAY[cn] = dr["CT" + i.ToString()].ToString(); cn++;
                        }
                        lichDTO.GHI_CHU = dr["GHI_CHU"].ToString();
                        if ((b_LCD && DALichLamViec.Install.Exist_LCDNhanVien(long.Parse(dr["NV_ID"].ToString())))
                            || (!b_LCD && DALichLamViec.Install.Exist_LichTuanNhanVien((DateTime)dr["NGAY_DAU_TUAN"], long.Parse(dr["NV_ID"].ToString())))
                        )
                        {
                            UpdateRow(lichDTO);
                        }
                        else
                        {
                            if (b_LCD)
                                Insert_LichCoDinh(lichDTO);
                            else
                            {
                                lichDTO.NGAY_DAU_TUAN = (DateTime)dr["NGAY_DAU_TUAN"];
                                Insert_LichTuan(lichDTO);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                er = ex.Message;
                throw new Exception(ex.Message);
            }
            if (er == string.Empty)
                return true;
            return false;
        }
        public string getTenNhanVien(long ID)
        {
            return HelpDB.getDatabase().LoadDataSet(new QueryBuilder("select NAME from DM_NHAN_VIEN where ID = " + ID.ToString() + "and 1=1"), "DM_NHAN_VIEN").Tables[0].Rows[0]["NAME"].ToString();
        }
        public static DataSet SortDataSet(DataSet ds,DataView view)
        {
            ds.Clear();
            DataRow dr;
            foreach (DataRowView row in view)
            {
                dr = ds.Tables[0].NewRow();
                dr["ID"] = row["ID"];
                dr["NV_ID"] = row["NV_ID"];
                dr["TEN_NV"] = row["TEN_NV"];
                dr["NGAY_DAU_TUAN"] = row["NGAY_DAU_TUAN"];
                dr["ST2"] = row["ST2"];
                dr["CT2"] = row["CT2"];
                dr["ST3"] = row["ST3"];
                dr["CT3"] = row["CT3"];
                dr["ST4"] = row["ST4"];
                dr["CT4"] = row["CT4"];
                dr["ST5"] = row["ST5"];
                dr["CT5"] = row["CT5"];
                dr["ST6"] = row["ST6"];
                dr["CT6"] = row["CT6"];
                dr["ST7"] = row["ST7"];
                dr["CT7"] = row["CT7"];
                if(ds.Tables[0].Select("NV_ID=" + HelpNumber.ParseInt64(row["NV_ID"])).Length==0)
                    ds.Tables[0].Rows.Add(dr);
            }
            return ds;
        }
    }
}
