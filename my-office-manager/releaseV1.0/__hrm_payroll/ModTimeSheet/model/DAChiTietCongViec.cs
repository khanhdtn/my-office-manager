using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using ProtocolVN.Plugin.TimeSheet.bo;
using System.Data.Common;
using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Plugin.TimeSheet;
using office;

namespace DAO
{
    
    public class DAChiTietCongViec : DAPhieu<DOChiTietCongViec>
    {        
        private static string KEY_FIELD_NAME = "CTCCV_ID";
        object[] FIELD_MAP = new object[] {  
                "CTCCV_ID", new IDConverter(),                                
                "NV_ID", new IDConverter(),
	            "MO_TA",null,
                "BAT_DAU",null,
                "KET_THUC",null,
                "THOI_GIAN_THUC_HIEN",new IDConverter(),
				"NGAY_LAM_VIEC", null,	
				"NGAY_CAP_NHAT", null,				
				"NGUOI_CAP_NHAT", null,
                "DUYET",null,
                "NGAY_DUYET",null,
                "NGUOI_DUYET",null,
                "LCV_ID",new IDConverter()
        };
        public static DAChiTietCongViec Instance = new DAChiTietCongViec();
        private DAChiTietCongViec() : base() { }

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }
        
        public override bool ValidateDetail(System.Data.DataRow row)
        {
            throw new NotImplementedException();
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return FWDBService.DeleteRecord("CHI_TIET_CONG_VIEC", KEY_FIELD_NAME, IDKey);

        }

        public override DOChiTietCongViec Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("CHI_TIET_CONG_VIEC", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOChiTietCongViec data = (DOChiTietCongViec)this.Builder.CreateFilledObject(typeof(DOChiTietCongViec), reader);
                    return data;
                }

            }
            return new DOChiTietCongViec();

        }

        public override DOChiTietCongViec LoadAll(long IDKey)
        {
            DOChiTietCongViec phieu = this.Load(IDKey);
            phieu.DetailDataset = DatabaseFB.LoadDataSet("CHI_TIET_CONG_VIEC", "CTCCV_ID", IDKey);
            return phieu;

        }

        public override bool Update(DOChiTietCongViec data)
        {
            throw new NotImplementedException();
        }

        public override bool UpdateDetail(DataSet Detail, DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(DOChiTietCongViec element)
        {
            return true;
        }

        public  DOChiTietCongViec GetCTCV(DateTime ngaylamviec, long nv_id,long CTCV_ID)
        {
            DOChiTietCongViec ctcv = null;
            try
            {
                string sql = "";
                if (CTCV_ID == -1)
                    sql = "select NGAY_CAP_NHAT,NGUOI_CAP_NHAT  from CHI_TIET_CONG_VIEC where NGAY_LAM_VIEC='" + ngaylamviec.ToString("MM/dd/yyyy") + "'and NV_ID=" + nv_id;
                else
                    sql = "select *  from CHI_TIET_CONG_VIEC where CTCCV_ID=" + CTCV_ID;
                ctcv = new DOChiTietCongViec();
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(sql);
                DataSet ds = new DataSet();
                db.LoadDataSet(cmd, ds, "a");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ctcv._NGAY_CAP_NHAT = Convert.ToDateTime(dr["NGAY_CAP_NHAT"]);
                    ctcv._NGUOI_CAP_NHAT = HelpNumber.ParseInt64(dr["NGUOI_CAP_NHAT"].ToString());
                    break;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ctcv;
        }

        public  void ChonCongViec(PLCombobox input, long id)
        {

            string sql = "select * from cong_viec where loai_du_an=" + id;
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            input.DataSource = ds.Tables[0];
            input.DisplayField = "NAME";
            input.ValueField = "ID";
            input._setSelectedID(-1);
            input._init();

        }
        public  bool UpdateDuyet(long IDKeyCTCCV,string Duyet,long? IDKeyNVUpdate)
        {            
            string sql="";
            if (IDKeyNVUpdate == null)
                sql = "Update CHI_TIET_CONG_VIEC set DUYET='" + Duyet + "',NGUOI_CAP_NHAT=" + DAChiTietCongViec.Instance.GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ",NGAY_CAP_NHAT='" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "' where CTCCV_ID=" + IDKeyCTCCV;
            else
                sql = "Update CHI_TIET_CONG_VIEC set DUYET='" + Duyet + "',NGUOI_CAP_NHAT=" + DAChiTietCongViec.Instance.GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ",NGAY_CAP_NHAT='" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "',NGUOI_DUYET=" + DAChiTietCongViec.Instance.GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ",NGAY_DUYET='" + DABase.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "' where CTCCV_ID=" + IDKeyCTCCV;
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            return (db.ExecuteNonQuery(cmd)>0);
        }
        public  void DeleteCTCV(long IDKeyCTCCV)
        {
            string sql = "delete from CHI_TIET_CONG_VIEC where CTCCV_ID =@CTCCV_ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@CTCCV_ID", DbType.Int64, IDKeyCTCCV);            
            db.ExecuteNonQuery(cmd);
        }

        public DataSet GetLoaiCV()
        {
            string sql = "select * from DM_LOAI_CONG_VIECN where visible_bit='Y'";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "LOAI_CONG_VIEC");
            return ds;
        }
        

        public long GetNVID(long usercat)
        {
            string sql = "select EMPLOYEE_ID from USER_CAT where USERID=" + usercat;
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "USER");
            if (ds.Tables[0].Rows.Count > 0)
                return HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0].ToString());
            else
                return -1;
        }

        public DataSet GetData(DateTime ngaylamviec,long nv_id)
        {
            DataSet ds = new DataSet();            
            string sql = "select CTCCV_ID,LCV_ID,NV_ID,MO_TA,BAT_DAU,KET_THUC,THOI_GIAN_THUC_HIEN,NGAY_LAM_VIEC,NGAY_CAP_NHAT  from CHI_TIET_CONG_VIEC where NGAY_LAM_VIEC='" + ngaylamviec.ToString("MM/dd/yyyy") + "'and NV_ID=" + nv_id;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);            
            db.LoadDataSet(cmd, ds, "CTCV");
            return ds;
        }

        public  DataSet GetData_Update(long CTCV_ID)
        {
            DataSet ds = new DataSet();
            string sql = "select CTCCV_ID,LCV_ID,NV_ID,MO_TA,BAT_DAU,KET_THUC,THOI_GIAN_THUC_HIEN,NGAY_LAM_VIEC,NGAY_CAP_NHAT  from CHI_TIET_CONG_VIEC where CTCCV_ID=" + CTCV_ID;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "CTCV");
            return ds;
        }
        

        public bool InsertCTCV(object CTCCV_ID, object LCV_ID, object NV_ID, string MO_TA, object TGTH, object NGAY_LAM, int count)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction tran = db.BeginTransaction(db.OpenConnection());
            string sql = "";
            if (count == 1)
            {
                sql = "Insert into CHI_TIET_CONG_VIEC(CTCCV_ID,LCV_ID,NV_ID,MO_TA,THOI_GIAN_THUC_HIEN,NGAY_LAM_VIEC,NGAY_CAP_NHAT,NGUOI_CAP_NHAT) values(" + HelpNumber.ParseInt64(DABase.getDatabase().GetID(PLConst.G_NGHIEP_VU)) + "," + HelpNumber.ParseInt64(LCV_ID) + "," + NV_ID + ",'" + MO_TA + "','01/01/0001 " + Convert.ToDateTime(TGTH).ToString("HH:mm:ss") + "','" + Convert.ToDateTime(NGAY_LAM).ToString("MM/dd/yyyy") + "','" + DABase.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "'," + FrameworkParams.currentUser.id + ")";
            }           
            else if (count == 2)
            {
                    sql = "Update CHI_TIET_CONG_VIEC set LCV_ID = " + HelpNumber.ParseInt64(LCV_ID) + ",NV_ID = " + HelpNumber.ParseInt64(NV_ID) + ",MO_TA='" + MO_TA + "',THOI_GIAN_THUC_HIEN = '01/01/0001 " + Convert.ToDateTime(TGTH).ToString("HH:mm:ss") + "',NGAY_CAP_NHAT ='" + DABase.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "',NGUOI_CAP_NHAT =" + DAChiTietCongViec.Instance.GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ",NGAY_LAM_VIEC='" + System.Convert.ToDateTime(NGAY_LAM).ToString("MM/dd/yyyy") + "' where CTCCV_ID = " + HelpNumber.ParseInt64(CTCCV_ID);
            }           
            else if (count == 3)
            {
                //delete
                sql = "delete from CHI_TIET_CONG_VIEC where CTCCV_ID = " + HelpNumber.ParseInt64(CTCCV_ID);
            }
            try
            {
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.ExecuteNonQuery(cmd, tran);
                db.CommitTransaction(tran);
                return true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                db.RollbackTransaction(tran);
                return false;
            }

        }

        public  bool Update_CTCV(DataSet ds,long NV_ID,DateTime NgayNhap,DOChiTietCongViec chitietcongviec)
        {

            bool flag = true;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.RowState == DataRowState.Added)
                {
                    flag = DAChiTietCongViec.Instance.InsertCTCV("", row["LCV_ID"], NV_ID
                                 , row["MO_TA"].ToString()
                                 , row["THOI_GIAN_THUC_HIEN"], NgayNhap, 1);
                }
                //else if (row.RowState == DataRowState.Deleted)
                //{
                //    DataSet dsCV = null;
                //    dsCV = DAChiTietCongViec.Instance.GetData(NgayNhap, NV_ID);
                //    string d = row["CTCCV_ID"].ToString();
                //    //foreach (DataRow r in dsCV.Tables[0].Rows)
                //    //{
                //    //    DataRow[] deleterow = ds.Tables[0].Select("CTCCV_ID != " + r["CTCCV_ID"].ToString());
                //    //    if (deleterow.Length == 0)
                //    //    {
                //    //        flag = DAChiTietCongViec.Instance.InsertCTCV(r["CTCCV_ID"], "", "", "", "", "", "", 3);
                //    //    }
                //    //    return flag;
                //    //}
                //}
                else if (row.RowState == DataRowState.Modified || row.RowState ==DataRowState.Unchanged)
                {
                    flag = DAChiTietCongViec.Instance.InsertCTCV(row["CTCCV_ID"], row["LCV_ID"], NV_ID
                                 , row["MO_TA"].ToString()
                                 , row["THOI_GIAN_THUC_HIEN"], NgayNhap, 2);
                }
            }
            return flag;  
            
        }
        public  DataSet CheckDuplicate(DateTime Ngaylamviec,long NV_ID)
        {
            string sql = "select ctccv_id,lcv_id,mo_ta from chi_tiet_cong_viec where nv_id=" + NV_ID + "and NGAY_LAM_VIEC='" + Ngaylamviec.ToString("MM/dd/yyyy") +"'";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            return ds;
        }
        public  DataSet GetNAME(long NV_ID)
        {            
            string sql = "select NAME from dm_nhan_vien nv where nv.id=" + NV_ID;
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            return ds;
        }
        public  DataSet GetID_NV(long User_ID)
        {
            string sql = "select id from dm_nhan_vien nv inner join user_cat uc on uc.employee_id=nv.id where uc.userid=" + User_ID ;
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            return ds;
        }
    }


}
