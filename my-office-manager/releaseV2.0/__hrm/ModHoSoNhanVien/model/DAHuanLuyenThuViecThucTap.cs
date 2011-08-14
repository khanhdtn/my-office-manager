using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using pl.office;
using ProtocolVN.DanhMuc;
namespace DAO
{
    public class DAHuanLuyenThuViecThucTap : DAPhieu<DOHuanLuyenThuViecThucTap>
    {
        public static string KEY_FIELD_NAME = "R_ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),	
				"R_ID", new IDConverter(),	
				"TTHS_ID", new IDConverter(),					
				"SO_NGAY", null,	
				"NGAY_BAT_DAU", null,				
				"NGAY_KET_THUC", null,				
				"GHI_CHU", null
        };
        public static DAHuanLuyenThuViecThucTap Instance = new DAHuanLuyenThuViecThucTap();
        private DAHuanLuyenThuViecThucTap() : base() { }
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOHuanLuyenThuViecThucTap LoadAll(long IDKey)
        {
            DOHuanLuyenThuViecThucTap phieu = Load(IDKey);
            phieu.DetailDataSet = DatabaseFB.LoadDataSet("DS_HL_TV_TT", KEY_FIELD_NAME, IDKey);
            return phieu;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            return true;
        }

        public override bool ValidateDetail(System.Data.DataRow row)
        {
            return true;
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord("DS_HL_TV_TT", KEY_FIELD_NAME, IDKey);
        }

        public override DOHuanLuyenThuViecThucTap Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("DS_HL_TV_TT", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOHuanLuyenThuViecThucTap data = (DOHuanLuyenThuViecThucTap)this.Builder.CreateFilledObject(typeof(DOHuanLuyenThuViecThucTap), reader);
                    return data;
                }
            }
            return new DOHuanLuyenThuViecThucTap();
        }

        public override bool Update(DOHuanLuyenThuViecThucTap data)
        {
            bool flag = false;
            if (data.DetailDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in data.DetailDataSet.Tables[0].Rows)
                {
                    flag = HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                }
            }
            else
            {
                DataRow row = data.DetailDataSet.Tables[0].NewRow();
                row["ID"] = data.ID;
                data.DetailDataSet.Tables[0].Rows.Add(row);
                flag = HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
            }
            return flag;
        }

        public override bool Validate(DOHuanLuyenThuViecThucTap element)
        {
            throw new NotImplementedException();
        }
        
        public bool UpdatePhieu(DOHuanLuyenThuViecThucTap data)
        {
            DatabaseFB db = HelpDB.getDatabase();
            db.OpenConnection();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            try
            {
                if (db.UpdateDataSet(data.DetailDataSet, dbTrans) == false) return false;
            }
            catch
            {
                db.RollbackTransaction(dbTrans);
            }
            db.CommitTransaction(dbTrans);
            return true;
        }

        public DOHuanLuyenThuViecThucTap Load(long R_ID,long TTHS_ID, int SoNgay, DateTime? NgayBatDau)
        {
            DatabaseFB fb = HelpDB.getDatabase();
            string Sql = @"select * from DS_HL_TV_TT 
                           where R_ID = @R_ID 
                           and TTHS_ID = @TTHS_ID 
                           and SO_NGAY = @SO_NGAY 
                           and NGAY_BAT_DAU=@NGAY_BAT_DAU ";
            DbCommand cmd = fb.GetSQLStringCommand(Sql);
            fb.AddInParameter(cmd, "@R_ID", DbType.Int64, R_ID);
            fb.AddInParameter(cmd, "@TTHS_ID", DbType.Int64, TTHS_ID);
            fb.AddInParameter(cmd, "@SO_NGAY", DbType.Int32, SoNgay);
            fb.AddInParameter(cmd, "@NGAY_BAT_DAU", DbType.DateTime, NgayBatDau);
            IDataReader reader = fb.ExecuteReader(cmd);
            using (reader)
            {
                if (reader.Read())
                {
                    DOHuanLuyenThuViecThucTap data = (DOHuanLuyenThuViecThucTap)this.Builder.CreateFilledObject(typeof(DOHuanLuyenThuViecThucTap), reader);

                    return data;
                }
            }
            return new DOHuanLuyenThuViecThucTap();
        }
        public DOHuanLuyenThuViecThucTap LoadAll(long R_ID, long TTHS_ID, int SoNgay, DateTime? NgayBatDau)
        {
            DOHuanLuyenThuViecThucTap phieu = this.Load(R_ID, TTHS_ID, SoNgay, NgayBatDau);
            DatabaseFB fb = HelpDB.getDatabase();
            string Sql = @"select * from DS_HL_TV_TT 
                           where R_ID = @R_ID 
                           and TTHS_ID = @TTHS_ID 
                           and SO_NGAY = @SO_NGAY 
                           and NGAY_BAT_DAU=@NGAY_BAT_DAU ";
            DbCommand cmd = fb.GetSQLStringCommand(Sql);
            fb.AddInParameter(cmd, "@R_ID", DbType.Int64, R_ID);
            fb.AddInParameter(cmd, "@TTHS_ID", DbType.Int64, TTHS_ID);
            fb.AddInParameter(cmd, "@SO_NGAY", DbType.Int32, SoNgay);
            fb.AddInParameter(cmd, "@NGAY_BAT_DAU", DbType.DateTime, NgayBatDau);
            phieu.DetailDataSet = fb.LoadDataSet(cmd, "DS_HL_TV_TT");
            return phieu;
        }

        public bool IsHuanLuyenThucTapThuViec(DOHuanLuyenThuViecThucTap data)
        {
            string[] dsID = DMTinhTrangHoSo.I.dsID_TT_HL_TRN();
            foreach (string item in dsID)
            {
                if (HelpNumber.ParseInt64(item) == data.TTHS_ID)
                    return true;
            }
            return false;
        }
    }
}
