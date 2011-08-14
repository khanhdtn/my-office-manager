using System;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using DTO;
using System.Drawing;

namespace DAO
{
    public class DADuAn:DAPhieu<DODuAn>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                                					
				"NAME", null,
                "LOAI_DU_AN",new IDConverter(),
                "NGUOI_QUAN_LY",new IDConverter(),
                "NGAY_BAT_DAU",null,
                "NGAY_KET_THUC",null,
                "TIEN_DO",null,
                "MUC_UU_TIEN",null,
                "TINH_TRANG",null,
                "MO_TA",null,
                "THONG_TIN_THEM",null
              
        };
        public static DADuAn Instance = new DADuAn();

        private DADuAn() : base() { }
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DODuAn LoadAll(long IDKey)
        {
            return Load(IDKey);
        }

        public override bool UpdateDetail(DataSet Detail, DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateDetail(DataRow row)
        {
            throw new NotImplementedException();
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord("DU_AN","ID",IDKey);
        }

        public override DODuAn Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("DU_AN", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DODuAn data = (DODuAn)this.Builder.CreateFilledObject(typeof(DODuAn), reader);
                    return data;
                }
            }
            return new DODuAn();
        }

        public override bool Update(DODuAn data)
        {
            bool flag = false;
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = DatabaseFB.LoadDataSet("DU_AN", KEY_FIELD_NAME, data.ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.ID;// = DABase.getDatabase().GetID("G_NGHIEP_VU");
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true) db.CommitTransaction(dbTrans);
            else db.RollbackTransaction(dbTrans);
            return flag;
        }

        public override bool Validate(DODuAn element)
        {
            throw new NotImplementedException();
        }
        public void UpdateDATT(long IDDuAn, long IDTapTin)
        {

            DatabaseFB db = DABase.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("insert into DU_AN_TAP_TIN values(@DU_AN_ID,@TAP_TIN_ID)");
            db.AddInParameter(cm, "@DU_AN_ID", DbType.Int64, IDDuAn);
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, IDTapTin);

            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static void luu_duan_congviec(long id_duan, long id_pccv)
        {
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("insert into CONG_VIEC_DU_AN values ('" + id_duan + "','" + id_pccv + "')");
            db.ExecuteNonQuery(cm, dbTrans);
            db.CommitTransaction(dbTrans);
        }
        public void DeleteDATT(long IDTapTin)
        {
            DALuuTruTapTin.Instance.Delete(IDTapTin);
            string sql2 = "delete from DU_AN_TAP_TIN where TAP_TIN_ID=@ID";
            DatabaseFB db1 = DABase.getDatabase();
            DbCommand command2 = db1.GetSQLStringCommand(sql2);
            db1.AddInParameter(command2, "@ID", DbType.Int64, IDTapTin);
            db1.ExecuteNonQuery(command2);
        }
        public static bool exists_ds_congviec(Int64 id)
        {
            if (id != 0)
            {
                DataSet ds = DABase.getDatabase().LoadDataSet("select * from PHAN_CONG_CONG_VIEC where PCCV_ID in(select da.PCCV_ID from CONG_VIEC_DU_AN da where da.DU_AN_ID='" + id + "')");
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }
        public static bool exists_ds_tailieu(Int64 id)
        {
            if (id != 0)
            {
                DataSet ds = DABase.getDatabase().LoadDataSet("select * from LUU_TRU_TAP_TIN where ID in(select TAP_TIN_ID from DU_AN_TAP_TIN  where DU_AN_ID='" + id + "')");
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }
        public static bool check_TrinhTrang_isHoanThanh(Int64 id)
        {
            if (id != 0)
            {
                DataSet ds = DABase.getDatabase().LoadDataSet("select * from DU_AN where TINH_TRANG=5 and ID='" + id + "'");
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
            }
            return false;
        }
        public static byte[] ImageToByteArray(Image image)
        {
            System.IO.MemoryStream mStream = new System.IO.MemoryStream();
            image.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] ret = mStream.ToArray();
            mStream.Close();
            return ret;
        }
        public static bool exists_DATT(long ID_TT)
        {
            if (ID_TT != 0)
            {



                DatabaseFB db = DABase.getDatabase();
                DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());

                DbCommand cm = db.GetSQLStringCommand("select count(*) from DU_AN_TAP_TIN where TAP_TIN_ID ='" + ID_TT + "'");
                int dem = (int)db.ExecuteScalar(cm, dbTrans);
                if (dem > 0)
                    return true;
            }
            return false;
        }
        public static DataTable loadDetail(long ID)
        {
            DataSet ds = new DataSet();
            QueryBuilder query = new QueryBuilder(
               @"SELECT distinct pc.pccv_id,pc.LCV_ID, pc.CONG_VIEC,DU_AN_ID,
                                   pc.ngay_bat_dau TU_NGAY, pc.ngay_ket_thuc_du_kien DEN_NGAY,
                                   iif(pc.is_ngay ='Y',pc.thoi_gian_du_kien ||' ngày', pc.thoi_gian_du_kien ||' giờ') THOI_GIAN_DU_KIEN,
                                   pc.muc_uu_tien,
                                   (case pc.muc_uu_tien when 3 then 'Cao nhất' else (
                                   case pc.muc_uu_tien when 1 then 'Cao' else (
                                   case pc.muc_uu_tien when 5 then 'Trung bình' else (
                                   case pc.muc_uu_tien when 2 then 'Thấp' else(
                                   case pc.muc_uu_tien when 4 then 'Thấp nhất' else null end) end ) end ) end) end) ten_muc_uu_tien,
                                   (select  iif(sum(cp.phan_tram_tham_gia)=0,0,cast((100 * sum(cast((cp.phan_tram_tham_gia * cp.tien_do) as numeric(15,1)) /cast(100 as numeric(15,1)))) as numeric(15,1))/ cast(sum(cp.phan_tram_tham_gia) as numeric(15,1)))
                                    from   chi_tiet_phan_cong cp
                                    where  cp.pccv_id = pc.pccv_id
                                    ) TIEN_DO_THUC_HIEN,
                                    pc.nguoi_giao, tt.NAME as TINH_TRANG,
                                    iif(LCV.NAME is not null,(select CV.name from DM_LOAI_CONG_VIECN CV where pc.LCV_ID = CV.ID ),'Loại công việc khác') TEN_LCV,                                     
                                    (select n.TEN_NV from dm_nhan_vien n where pc.nguoi_giao = n.id) ten_nguoi_giao
                            FROM  (((phan_cong_cong_viec pc LEFT JOIN dm_tinh_trang tt on pc.tinh_trang = tt.id )
                                  INNER JOIN DM_LOAI_CONG_VIECN LCV ON pc.LCV_ID = LCV.ID) left join chi_tiet_phan_cong ct on pc.pccv_id = ct.pccv_id)INNER JOIN CONG_VIEC_DU_AN on CONG_VIEC_DU_AN.PCCV_ID=pc.PCCV_ID
                            WHERE 1=1");

            query.addID("DU_AN_ID", ID);
            ds = DABase.getDatabase().LoadDataSet(query);
            ds.Tables[0].Columns.Add("NV_THAM_GIA");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                String ten = "";
                String sqlString = "select ct.ma_nv, nv.ten_nv, ct.phan_tram_tham_gia from chi_tiet_phan_cong ct, dm_nhan_vien nv where ct.ma_nv = nv.id and ct.pccv_id = " + dr["PCCV_ID"].ToString() + " group by ma_nv,ten_nv, phan_tram_tham_gia";
                DataTable dt = DABase.getDatabase().LoadDataSet(sqlString).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (ten == "")
                        ten = ten + row["TEN_NV"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                    else
                        ten = ten + "\n" + row["TEN_NV"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                }
                dr["NV_THAM_GIA"] = ten;
            }


            return ds.Tables[0];

        }  
    }
}
