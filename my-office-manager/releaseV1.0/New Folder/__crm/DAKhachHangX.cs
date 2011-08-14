using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Views.Grid;
using DTO;
using office;

namespace DAO
{
    public class DAKhachHangX : DAPhieu<DOKhachHang>
    {
        public static string KEY_FIELD_NAME = "KH_ID";
        object[] FIELD_MAP = new object[] {             
				"KH_ID", new IDConverter(),	
				"TEN_KHACH_HANG", new IDConverter(),	
                "DIA_CHI", new IDConverter(),	
                "DIEN_THOAI", null,	
                "FAX", null,	
                "EMAIL", null,	
				"WEBSITE", null,	
                "NKH_ID", null,	
				"LINH_VUC_HOAT_DONG", new IDConverter(),
                "THONG_TIN_THEM",null,
        };
        public static DAKhachHangX Instance = new DAKhachHangX();
        public static String N = typeof(DAKhachHangX).FullName;
        private DAKhachHangX() : base() { }
        public FieldNameCheck[] GetRuleCV()
        {

            return new FieldNameCheck[] { 
                new FieldNameCheck("LCV_ID",
                    new CheckType[]{ CheckType.RequiredID },
                    new string[]{ HelpErrorMsg.errorRequired("Loại công việc")}, 
                    new object[]{ }),
                new FieldNameCheck("NOI_DUNG",
                    new CheckType[]{ CheckType.Required},
                    new string[]{ HelpErrorMsg.errorRequired("Nội dung")}, 
                    new object[]{ }),
                new FieldNameCheck("DO_UU_TIEN",
                    new CheckType[]{ CheckType.IntGreater0 },
                    new string[]{ HelpErrorMsg.errorGreater0("Độ ưu tiên")}, 
                    new object[]{ }),                
                new FieldNameCheck("TINH_TRANG",
                    new CheckType[]{ CheckType.RequiredID},
                    new string[]{ HelpErrorMsg.errorRequired("Tình trạng")}, 
                    new object[]{ }),
                new FieldNameCheck("NGUOI_THUC_HIEN",
                    new CheckType[]{ CheckType.RequiredID },
                    new string[]{ HelpErrorMsg.errorRequired("Người thực hiện")}, 
                    new object[]{ }),
                new FieldNameCheck("NGUOI_LIEN_HE",
                    new CheckType[]{ CheckType.RequiredID},
                    new string[]{ HelpErrorMsg.errorRequired("Người liên hệ")}, 
                    new object[]{ }),
                new FieldNameCheck("TU_NGAY",
                    new CheckType[]{ CheckType.RequireDate},
                    new string[]{ HelpErrorMsg.errorRequired("Từ ngày")}, 
                    new object[]{ })
            };
        }
        public FieldNameCheck[] GetRuleTTLH()
        {
            return new FieldNameCheck[] { 
                new FieldNameCheck("HO_TEN",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Họ tên")}, 
                    new object[]{ }),
                new FieldNameCheck("DIA_CHI",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Địa chỉ")}, 
                    new object[]{ })
            };
        }
        public FieldNameCheck[] GetRuleTTLL()
        {
            return new FieldNameCheck[] { 
                new FieldNameCheck("BO_PHAN",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Bộ phận")}, 
                    new object[]{ }),
                new FieldNameCheck("DIA_CHI",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Địa chỉ")}, 
                    new object[]{ })
            };
        }
        public FieldNameCheck[] GetRuleTL()
        {
            return new FieldNameCheck[] { 
                new FieldNameCheck("TIEU_DE",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Tiêu đề")}, 
                    new object[]{ }),
                new FieldNameCheck("FILE_DINH_KEM",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("File đính kèm")}, 
                    new object[]{ })
            };
        }
        public FieldNameCheck[] GetMaxLengthTTLL()
        {
            return new FieldNameCheck[]{
                    new FieldNameCheck("BO_PHAN",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Bộ phận") },
                    new object[] { 200 }),
                    new FieldNameCheck("DIA_CHI",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Địa chỉ") },
                    new object[] { 7000 }),
                    new FieldNameCheck("DIEN_THOAI",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Điện thoại") },
                    new object[] { 100 }),
                    new FieldNameCheck("FAX",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Fax") },
                    new object[] { 200 }),
                    new FieldNameCheck("EMAIL",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Email") },
                    new object[] { 200 }),
                    new FieldNameCheck("THONG_TIN_KHAC",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Thông tin khác") },
                    new object[] { 4000 })
            };          
        }
        public FieldNameCheck[] GetMaxLengthTTLH()
        {
            return new FieldNameCheck[]{
                    new FieldNameCheck("HO_TEN",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Họ tên") },
                    new object[] { 200 }),
                    new FieldNameCheck("CHUC_VU",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Chức vụ") },
                    new object[] { 100 }),
                    new FieldNameCheck("BO_PHAN",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Bộ phận") },
                    new object[] { 200 }),
                    new FieldNameCheck("DIA_CHI",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Địa chỉ") },
                    new object[] { 7000 }),
                    new FieldNameCheck("DIEN_THOAI",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Điện thoại") },
                    new object[] { 100 }),
                    new FieldNameCheck("EMAIL",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Email") },
                    new object[] { 100 }),
                    new FieldNameCheck("FAX",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Fax") },
                    new object[] { 100 }),
                    new FieldNameCheck("THONG_TIN_KHAC",
                    new CheckType[] { CheckType.OptionMaxLength },
                    new string[] { HelpErrorMsg.errorMaxLength("Thông tin khác") },
                    new object[] { 4000 })
            };
        }
        public bool CkeckDuplicate(PLGridView view, DataSet ds, string columnField, string displayField)
        {
            int count = 0;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row[columnField].ToString() == view.GetDataRow(view.FocusedRowHandle)[columnField].ToString())
                    {
                        if (view.IsNewItemRow(view.FocusedRowHandle))
                        {
                            view.GetDataRow(view.FocusedRowHandle).SetColumnError(columnField, displayField + " này đã có trong danh sách, xin vui lòng kiểm tra lại.");
                            return true;
                        }
                        else
                        {
                            count++;
                            if (count == 2)
                            {
                                view.GetDataRow(view.FocusedRowHandle).SetColumnError(columnField, displayField + " này đã có trong danh sách, xin vui lòng kiểm tra lại.");
                                return true;
                            }
                        }
                    }
                }
            }
            view.GetDataRow(view.FocusedRowHandle).ClearErrors();
            return false;
        }
        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }
        public override DOKhachHang LoadAll(long IDKey)
        {
            DOKhachHang phieu = Load(IDKey);
            phieu.DetailDataSetTTLH = FWDBService.LoadDataSet("THONG_TIN_LIEN_HE", KEY_FIELD_NAME, IDKey);
            phieu.DetailDataSetTTLL = FWDBService.LoadDataSet("THONG_TIN_LIEN_LAC", KEY_FIELD_NAME, IDKey);
            phieu.DetailDataSetCV = HelpDB.getDatabase().LoadDataSet(@"SELECT DISTINCT PC.PCCV_ID,PC.LCV_ID, PC.CONG_VIEC, PC.CHI_TIET_CONG_VIEC,KH_DA_CV.KH_ID,KH_DA_CV.DU_AN_ID,
                                  PC.NGAY_BAT_DAU TU_NGAY, PC.NGAY_KET_THUC_DU_KIEN DEN_NGAY,PC.NGAY_KET_THUC,
                                  IIF(PC.IS_NGAY ='Y',(PC.THOI_GIAN_DU_KIEN * 8) ||' Giờ', PC.THOI_GIAN_DU_KIEN ||' Giờ') THOI_GIAN_DU_KIEN,
                                  PC.MUC_UU_TIEN,
                                  (CASE PC.MUC_UU_TIEN WHEN 1 THEN 'Cao nhất' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 2 THEN 'Cao' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 3 THEN 'Trung bình' ELSE (
                                  CASE PC.MUC_UU_TIEN WHEN 4 THEN 'Thấp' ELSE(
                                  CASE PC.MUC_UU_TIEN WHEN 5 THEN 'Thấp nhất' ELSE NULL END) END ) END ) END) END) TEN_MUC_UU_TIEN,
                                   '' TONG_TIEN_DO,
                                  PC.NGUOI_GIAO, TT.NAME AS TINH_TRANG,PC.TINH_TRANG AS TINH_TRANG_ID,
                                  IIF(LCV.NAME IS NOT NULL,(SELECT CV.NAME FROM DM_LOAI_CONG_VIECN CV WHERE PC.LCV_ID = CV.ID ),'Loại công việc khác') TEN_LCV,                                     
                                  (SELECT N.NAME FROM DM_NHAN_VIEN N WHERE PC.NGUOI_GIAO = N.ID) TEN_NGUOI_GIAO
                                  FROM  ((PHAN_CONG_CONG_VIEC PC LEFT JOIN DM_TINH_TRANG TT ON PC.TINH_TRANG = TT.ID )
                                  INNER JOIN DM_LOAI_CONG_VIECN LCV ON PC.LCV_ID = LCV.ID) LEFT JOIN CHI_TIET_PHAN_CONG CT ON PC.PCCV_ID = CT.PCCV_ID
                                  LEFT JOIN KH_DA_CV ON KH_DA_CV.PCCV_ID = PC.PCCV_ID
                                  WHERE KH_DA_CV.KH_ID = " + IDKey, "CONG_VIEC_KHACH_HANG");
            GetDetailDataSetCV(phieu.DetailDataSetCV);
            phieu.DetailDataSetTL = HelpDB.getDatabase().LoadDataSet(@"SELECT KHTT.TAP_TIN_ID,LTTT.*, KHTT.OBJECT_ID,(SELECT NAME FROM DM_NHAN_VIEN WHERE ID = LTTT.NGUOI_CAP_NHAT) AS TEN_NGUOI_CN 
            FROM LUU_TRU_TAP_TIN LTTT, OBJECT_TAP_TIN KHTT WHERE LTTT.ID = KHTT.TAP_TIN_ID AND TYPE_ID = 8 AND KHTT.OBJECT_ID = " + IDKey, "KHACH_HANG_TAP_TIN");
            return phieu;
        }
        public void GetDetailDataSetCV(DataSet DetailDataSetCV)
        {
            DetailDataSetCV.Tables[0].Columns.Add("NV_THAM_GIA");
            //DataSet dùng cho việc tính tiến độ công việc
            string sql = @"SELECT C.PCCV_ID,PHAN_TRAM_THAM_GIA,MAX(TIEN_DO) TIEN_DO,T.TONG_PHAN_TRAM
                            FROM CHI_TIET_PHAN_CONG C,
                            (SELECT PCCV_ID,SUM(PHAN_TRAM_THAM_GIA) TONG_PHAN_TRAM
                                FROM CHI_TIET_PHAN_CONG WHERE TIEN_DO = 0 GROUP BY PCCV_ID) T
                                    WHERE TIEN_DO > 0 AND T.PCCV_ID = C.PCCV_ID and 
                                    C.THOI_GIAN_CAP_NHAT IN (SELECT MAX(CT.THOI_GIAN_CAP_NHAT) FROM CHI_TIET_PHAN_CONG CT WHERE CT.PCCV_ID=T.PCCV_ID GROUP BY CT.MA_NV)
                                          GROUP BY C.PCCV_ID,C.MA_NV,PHAN_TRAM_THAM_GIA,T.TONG_PHAN_TRAM";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            foreach (DataRow dr in DetailDataSetCV.Tables[0].Rows)
            {
                String ten = "";
                String sqlString = "SELECT CT.MA_NV, NV.NAME, CT.PHAN_TRAM_THAM_GIA FROM CHI_TIET_PHAN_CONG CT, DM_NHAN_VIEN NV WHERE CT.MA_NV = NV.ID AND CT.PCCV_ID = " + dr["PCCV_ID"].ToString() + " GROUP BY MA_NV,NAME, PHAN_TRAM_THAM_GIA";
                DataTable dt = HelpDB.getDatabase().LoadDataSet(sqlString).Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (ten == "")
                        ten = ten + row["NAME"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                    else
                        ten = ten + "\n" + row["NAME"].ToString() + " (" + row["PHAN_TRAM_THAM_GIA"].ToString() + "%)";
                }
                dr["NV_THAM_GIA"] = ten;
                //Tính giá trị cho cột tính độ dựa vào DataSet (ds) ở trên
                long tam = HelpNumber.ParseInt64(dr["PCCV_ID"]);
                DataRow[] arrRow = ds.Tables[0].Select(string.Format("PCCV_ID = {0}", HelpNumber.ParseInt64(dr["PCCV_ID"])));
                decimal tongTienDo = 0;
                foreach (DataRow row in arrRow)
                    tongTienDo += (HelpNumber.ParseInt64(row["TIEN_DO"]) * HelpNumber.ParseInt64(row["PHAN_TRAM_THAM_GIA"]));
                if (arrRow.Length > 0) HelpNumber.RoundDecimal(tongTienDo /= HelpNumber.ParseInt64(arrRow[0]["TONG_PHAN_TRAM"]), 2);
                dr["TONG_TIEN_DO"] = tongTienDo.ToString() + "%";
            }
        }
        public override DOKhachHang Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("KHACH_HANG", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOKhachHang data = new DOKhachHang(HelpNumber.ParseInt64(reader["KH_ID"]), reader["TEN_KHACH_HANG"].ToString(), reader["DIA_CHI"].ToString(), reader["DIEN_THOAI"].ToString(), reader["FAX"].ToString(), reader["EMAIL"].ToString(), reader["WEBSITE"].ToString(), reader["NKH_ID"].ToString(), reader["LINH_VUC_HOAT_DONG"].ToString(), reader["THONG_TIN_THEM"].ToString());
                    return data;
                }
            }
            return new DOKhachHang();
        }
        public override bool Validate(DOKhachHang element)
        {
            throw new NotImplementedException();
        }
        public override bool ValidateDetail(DataRow row)
        {
            throw new NotImplementedException();
        }
        public bool ValidateDetail(DataRow row, string tableName)
        {
            FieldNameCheck[] field = null;
            if (tableName == "CONG_VIEC_QLKH")
                field = GetRuleCV();
            else if (tableName == "THONG_TIN_LIEN_HE")
                field = GetRuleTTLH();
            else if (tableName == "THONG_TIN_LIEN_LAC")
                field = GetRuleTTLL();
            else if (tableName == "TAI_LIEU")
                field = GetRuleTL();   
            return HelpInputData.ValidateRow(null, row, field);
        }
        public override bool UpdateDetail(DataSet Detail, DataSet Grid)
        {
            try
            {
                long ID;
                if (Detail.Tables[0].Rows.Count == 0)
                    ID = -1;
                else
                    ID = HelpNumber.ParseInt64(Detail.Tables[0].Rows[0][0]);
                Detail.Clear();
                FWDBService.LoadDataSet(Detail, Detail.Tables[0].TableName, KEY_FIELD_NAME, ID);
                HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, Detail, Grid, true);
                return true;
            }
            catch (Exception exception)
            {
                PLException.AddException(exception);
                return false;
            }
        }
        public override bool Update(DOKhachHang data)
        {
            bool flag = false;
            DataSet MainDS = FWDBService.LoadDataSet("KHACH_HANG", KEY_FIELD_NAME, data.KH_ID);
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
                if (flag) flag = db.UpdateDataSet(data.DetailDataSetTTLL, dbTrans);
                if (flag) flag = db.UpdateDataSet(data.DetailDataSetTTLH, dbTrans);
                if (flag) db.CommitTransaction(dbTrans);
            }
            else
            {
                DataRow row = MainDS.Tables[0].NewRow();
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                row[KEY_FIELD_NAME] = data.KH_ID;
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
                if (flag) db.CommitTransaction(dbTrans);
                db.Open();
                dbTrans = db.BeginTransaction(db.OpenConnection());
                if (flag) flag = db.UpdateDataSet(data.DetailDataSetTTLL, dbTrans);
                if (flag) flag = db.UpdateDataSet(data.DetailDataSetTTLH, dbTrans);
                if (flag) db.CommitTransaction(dbTrans);
            }
            if (flag == true)
                data.KH_ID = HelpNumber.ParseInt64(MainDS.Tables[0].Rows[0][KEY_FIELD_NAME].ToString());
            return flag;
        }
        public override bool Delete(long IDKey)
        {
            return FWDBService.DeleteRecord("KHACH_HANG", KEY_FIELD_NAME, IDKey);
        }
        public void Luu_TaiLieuKH(long ID_Khachhang, long ID_TapTin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("INSERT INTO OBJECT_TAP_TIN VALUES(@TAP_TIN_ID,@KH_ID,@TYPE_ID)");
            db.AddInParameter(cm, "@KH_ID", DbType.Int64, ID_Khachhang);
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, ID_TapTin);
            db.AddInParameter(cm, "@TYPE_ID", DbType.Int32, 8);
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static void Xoa_TaiLieuKH(long id_taptin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format(@"DELETE FROM OBJECT_TAP_TIN WHERE TAP_TIN_ID={0} AND TYPE_ID=8", id_taptin));
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }

        public static bool InsertKhachHang_DuAn(long DA_ID, long KH_ID)
        {
            string Sql = string.Format(@"INSERT INTO {0} VALUES ({1}, {2}, null)", PLConst.bangKH_DA_CV, KH_ID, DA_ID);
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(Sql);
                return db.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }

        public static bool IsExistsKH_DA_In_KH_DA_CV(long DA_ID, long KH_ID)
        {
            string Sql = string.Format(@"SELECT COUNT(*) FROM KH_DA_CV WHERE KH_ID = {0} AND DU_AN_ID = {1}",KH_ID, DA_ID);
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand(Sql);
                return (int)db.ExecuteScalar(cmd) > 0;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }
    }
}
