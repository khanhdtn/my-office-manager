using System;
using System.Data.Common;
using System.Data;
using ProtocolVN.Framework.Core;
using DTO;
using office;
using ProtocolVN.Framework.Win;
using LumiSoft.Net.Mime;
using office;
using ProtocolVN.DanhMuc;
using System.Collections;
using System.Collections.Generic;
using ProtocolVN.App.Office;
namespace DAO
{
    public class DATinTuc : DAPhieu<DOTinTuc>
    {        
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                
                "TIEU_DE", null,
	            "NOI_DUNG",null,                                										
				"NGUOI_CAP_NHAT", new IDConverter(),
                "NGAY_CAP_NHAT", null,	
                "PRIOR",null,               
                "NHOM_TIN",new IDConverter(),
                "DUYET",null,
                "NGUOI_DUYET",null,
                "NGAY_DUYET",null,
                "SO_NGAY_HIEU_LUC",null
        };
        public static DATinTuc Instance = new DATinTuc();
        public static long quyenDuyet = 143;

        private DATinTuc() : base() { }
   
        #region Các hàm kế thừa 
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
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

        public override DOTinTuc Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("TIN_TUC", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOTinTuc data = (DOTinTuc)this.Builder.CreateFilledObject(typeof(DOTinTuc), reader);
                    return data;
                }
            }
            return new DOTinTuc();
        }
        public override DOTinTuc LoadAll(long IDKey)
        {
            DOTinTuc phieu = this.Load(IDKey);
            phieu.DetailDataSet = DatabaseFB.LoadDataSet("TIN_TUC", "ID", IDKey);
            phieu.DSTapTinDinhKem = DALuuTruTapTin.Instance.GetTapTinByObjectID(IDKey, 1);
            return phieu;
        }
        public override bool Update(DOTinTuc data)
        {
            DbTransaction dbTrans = null;
            FWDBService db = null;
            FWTransaction fwTrans = null;
            try
            {
                db = HelpDB.getDBService();
                dbTrans = FWTransaction.BeginTrans(db);
                fwTrans = new FWTransaction(db, dbTrans);
                if (data.DetailDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in data.DetailDataSet.Tables[0].Rows)
                    {
                        HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                    }
                }
                else
                {
                    DataRow row = data.DetailDataSet.Tables[0].NewRow();
                    data.ID = db.GetID(PLConst.G_NGHIEP_VU, dbTrans);
                    row["ID"] = data.ID;
                    data.DetailDataSet.Tables[0].Rows.Add(row);
                    HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);

                }           

                if (db.UpdateDataSet(data.DetailDataSet, dbTrans) == false)
                {
                    FWTransaction.Rollback(dbTrans);
                    return false;
                }
                else
                {
                    if (data.DSTapTinDinhKem != null && data.DSTapTinDinhKem.Tables.Count > 0)
                    {
                        DataSet DsLuuTruTapTin = data.DSTapTinDinhKem.Copy();

                        DataRow[] rows = data.DSTapTinDinhKem.Tables[0].Select("ID is null", "", DataViewRowState.Added);

                        List<long> taptinIDs = db.GetID("G_NGHIEP_VU", dbTrans, rows.Length);

                        int i = 0;
                        foreach (DataRow row in DsLuuTruTapTin.Tables[0].Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;
                            row["OBJECT_ID"] = data.ID;
                            row["TYPE_ID"] = (Int32)1;
                            row["TIEU_DE"] = data.TIEU_DE;
                            if (row["ID"] is DBNull)
                            {
                                row["TAP_TIN_ID"] = taptinIDs[i];
                                row["ID"] = row["TAP_TIN_ID"];
                                i++;
                            }
                        }
                        DataSet DsObjectTapTin = DsLuuTruTapTin.Copy();
                        DsObjectTapTin.Tables[0].TableName = "OBJECT_TAP_TIN";



                        DataSet DsLuuTruTapTinSource = new DataSet();
                        string sqlTaptin = string.Format(@"SELECT LT.*
                            from luu_tru_tap_tin LT
                            INNER JOIN object_tap_tin OBJ ON OBJ.tap_tin_id=LT.id
                            AND OBJ.type_id=1 and obj.object_id={0}", data.ID);
                        if (fwTrans.LoadDataSet(DsLuuTruTapTinSource, sqlTaptin, "LUU_TRU_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeDataSet(new string[] { "ID" }, DsLuuTruTapTinSource, DsLuuTruTapTin, true);

                        DataSet DsObjectTapTinSource = new DataSet();
                        string sqlObj = string.Format(@"SELECT OBJ.*
                            from object_tap_tin OBJ where OBJ.type_id=1 and obj.object_id={0}", data.ID);
                        if (fwTrans.LoadDataSet(DsObjectTapTinSource, sqlObj, "OBJECT_TAP_TIN") == false)
                        {
                            FWTransaction.Rollback(dbTrans);
                            return false;
                        }
                        HelpDataSet.MergeTable(new string[] { "TAP_TIN_ID" }, DsObjectTapTinSource.Tables[0], DsObjectTapTin.Tables[0], true, true);
                        if (db.UpdateDataSet(DsLuuTruTapTinSource, dbTrans))
                        {
                            //flag = db.UpdateDataSet(DsObjectTapTinSource, dbTrans);// bị lỗi ở đây
                            foreach (DataRow r in DsObjectTapTinSource.Tables[0].Rows)
                            {
                                DbCommand cmd = null;
                                if (r.RowState == DataRowState.Added)
                                {
                                    cmd = db.GetSQLStringCommand(string.Format(@"INSERT INTO OBJECT_TAP_TIN(TAP_TIN_ID,OBJECT_ID,TYPE_ID) VALUES({0},{1},{2})", r["TAP_TIN_ID"], r["OBJECT_ID"], r["TYPE_ID"]));
                                }
                                if (cmd != null)
                                {
                                    if (db.ExecuteNonQuery(cmd, dbTrans) <= 0)
                                    {
                                        FWTransaction.Rollback(dbTrans);
                                        return false;
                                    }
                                }
                            }

                        }
                    }
                }
                FWTransaction.Commit(dbTrans);
            }
            catch
            {
                FWTransaction.Rollback(dbTrans);
            }
            return true;
        }        
        public override bool Validate(DOTinTuc element)
        {
            throw new NotImplementedException();
        }
        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord("TIN_TUC", "ID", IDKey);
        }
        #endregion                                        

        #region Các hàm xử lý khác 
        public DOTinTuc get_TinTuc(long? Tin_tuc_ID, bool isDesktop)
        {

            QueryBuilder query = null;
            if (Tin_tuc_ID == null)//Tin tức nổi bật PRIOR=Y
            {
                query = new QueryBuilder(string.Format(@"SELECT * FROM TIN_TUC  
                        WHERE ((PRIOR='Y' AND DUYET='2') OR (NGAY_CAP_NHAT=(SELECT MAX(NGAY_CAP_NHAT) FROM TIN_TUC WHERE PRIOR<>'Y' AND DUYET='2')))" +
                            ((isDesktop == true) ? " AND (DATEADD(DAY,SO_NGAY_HIEU_LUC,NGAY_CAP_NHAT) >= '{0}' OR SO_NGAY_HIEU_LUC = 0) AND 1=1" : "")
                          , HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm")));
                query.setDescOrderBy("PRIOR");
            }
            else
            {
                query = new QueryBuilder(@"select * from TIN_TUC where 1=1");
                query.addID("ID", Tin_tuc_ID.Value);
            }
            query.addCondition("NHOM_TIN IN (SELECT ID FROM DM_NHOM_TIN_TUC WHERE VISIBLE_BIT ='Y')");
            DataSet ds = TinTucPermission.I._LoadDataSetWithResGroupPermission(query, "TIN_TUC", "NHOM_TIN");
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return Get_doTinTuc(ds);
        }
        public DOLuuTruTapTin get_TapTin(long Tin_tuc_ID)
        {
            string sql = string.Empty;
            sql = string.Format(@"SELECT TAP_TIN_ID,NOI_DUNG,TEN_FILE 
            FROM OBJECT_TAP_TIN T INNER JOIN LUU_TRU_TAP_TIN L ON T.TAP_TIN_ID=L.ID 
            WHERE OBJECT_ID={0} AND TYPE_ID = 1", Tin_tuc_ID);
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "TIN_TUC_TAP_TIN");
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            return Get_doLuuTru_TT(ds);
        }
        public DOTinTuc Get_doTinTuc(DataSet ds)
        {
            DOTinTuc DtoTT = new DOTinTuc();
            DtoTT.ID = HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["ID"].ToString());
            DtoTT.TIEU_DE = ds.Tables[0].Rows[0]["TIEU_DE"].ToString();
            if (ds.Tables[0].Rows[0]["NOI_DUNG"].ToString() != string.Empty)
                DtoTT.NOI_DUNG = (Byte[])ds.Tables[0].Rows[0]["NOI_DUNG"];                        
            DtoTT.NGUOI_CAP_NHAT = HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["NGUOI_CAP_NHAT"].ToString());
            DtoTT.NGAY_CAP_NHAT = (DateTime)ds.Tables[0].Rows[0]["NGAY_CAP_NHAT"];
            if (ds.Tables[0].Rows[0]["PRIOR"].ToString() != string.Empty)
                DtoTT.PRIOR = ds.Tables[0].Rows[0]["PRIOR"].ToString();
            DtoTT.NHOM_TIN = HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["NHOM_TIN"].ToString());
            return DtoTT;
        }
        public DOLuuTruTapTin Get_doLuuTru_TT(DataSet ds)
        {
            DOLuuTruTapTin doLT_TT = new DOLuuTruTapTin();
            doLT_TT.ID = HelpNumber.ParseInt64(ds.Tables[0].Rows[0]["TAP_TIN_ID"].ToString());
            if (ds.Tables[0].Rows[0]["NOI_DUNG"].ToString() != string.Empty)
                doLT_TT.NOI_DUNG = (Byte[])ds.Tables[0].Rows[0]["NOI_DUNG"];
            doLT_TT.TEN_FILE = ds.Tables[0].Rows[0]["TEN_FILE"].ToString();
            return doLT_TT;
        }
        public void Update_tin_noi_bat(long Id,string Prior)
        {
            string sql = "Update TIN_TUC set PRIOR=@PRIOR where ID=@ID" ;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, Id);
            db.AddInParameter(cmd, "@PRIOR", DbType.String, Prior);            
            try
            {
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex) { HelpMsgBox.ShowConfirmMessage(ex.ToString()); }
        }

        public DataSet Get_5_tin(long Nhom_tin,DateTime Tungay,DateTime Denngay,PLDuyetCheckbox TTDuyet)
        {
            DataSet ds = new DataSet();
            Feature fQuanTri = Permission.loadFeature(AppPermission.FQuanTriTinTuc.id
                , AppPermission.FQuanTriTinTuc.featureName, FrameworkParams.currentUser.username);
            //Lấy tin nổi bật đã được duyệt.
            QueryBuilder query = new QueryBuilder
                (
                    @" SELECT ID,PRIOR,NHOM_TIN,TIEU_DE, NGAY_CAP_NHAT,NGUOI_CAP_NHAT,DUYET,CASE WHEN SO_NGAY_HIEU_LUC > 0 THEN DATEADD(DAY,SO_NGAY_HIEU_LUC,NGAY_CAP_NHAT) ELSE NULL END AS NGAY_HIEU_LUC,
                     CASE WHEN PRIOR='Y' THEN 'Tin tức nổi bật' ELSE NULL END TIN_NOI_BAT
                     FROM TIN_TUC  WHERE PRIOR = 'Y' AND DUYET = '2' AND 1=1"
                );
            query.addCondition("NHOM_TIN IN (SELECT ID FROM DM_NHOM_TIN_TUC WHERE VISIBLE_BIT ='Y')");
            query.addDateFromTo("NGAY_CAP_NHAT", Tungay, Denngay);
            if (fQuanTri.isRead)//(DATinTuc.Instance.getNguoiDuyet(DATinTuc.quyenDuyet).Contains(FrameworkParams.currentUser.employee_id))
                query.addDuyet(PLConst.FIELD_DUYET, TTDuyet.layTrangThai());
            else
                query.addCondition(string.Format("1=1 or NGUOI_CAP_NHAT = {0}", FrameworkParams.currentUser.employee_id));
            ds=TinTucPermission.I._LoadDataSetWithResGroupPermission(query, "NHOM_TIN", Nhom_tin);
            //Lấy tin mới nhất đã được duyệt.
            QueryBuilder query1 = new QueryBuilder
                (
                    @" SELECT ID,PRIOR,NHOM_TIN,TIEU_DE, NGAY_CAP_NHAT,NGUOI_CAP_NHAT,DUYET,CASE WHEN SO_NGAY_HIEU_LUC > 0 THEN DATEADD(DAY,SO_NGAY_HIEU_LUC,NGAY_CAP_NHAT) ELSE NULL END AS NGAY_HIEU_LUC,
                     CASE WHEN PRIOR='Y' THEN 'Tin tức nổi bật' ELSE NULL END TIN_NOI_BAT
                     FROM TIN_TUC  WHERE PRIOR = 'N' AND DUYET = '2'
                     AND NGAY_CAP_NHAT = (SELECT MAX(NGAY_CAP_NHAT)
                                            FROM TIN_TUC
                                            WHERE PRIOR = 'N' AND DUYET = '2') 
                     AND 1=1"
                );
            query1.addDateFromTo("NGAY_CAP_NHAT", Tungay, Denngay);
            query1.addCondition("NHOM_TIN IN (SELECT ID FROM DM_NHOM_TIN_TUC WHERE VISIBLE_BIT ='Y')");
            if (fQuanTri.isRead)//(DATinTuc.Instance.getNguoiDuyet(DATinTuc.quyenDuyet).Contains(FrameworkParams.currentUser.employee_id))
                query1.addDuyet(PLConst.FIELD_DUYET, TTDuyet.layTrangThai());
            else
                query1.addCondition(string.Format("1=1 or NGUOI_CAP_NHAT = {0}", FrameworkParams.currentUser.employee_id));
            DataTable dtTT_Max = TinTucPermission.I._LoadDataSetWithResGroupPermission(query1, "NHOM_TIN", Nhom_tin).Tables[0];
            //Lấy các tin còn lại
            QueryBuilder query2 = new QueryBuilder
                (
                    string.Format(@" SELECT FIRST {0} ID,PRIOR,NHOM_TIN,TIEU_DE, NGAY_CAP_NHAT,NGUOI_CAP_NHAT,DUYET,CASE WHEN SO_NGAY_HIEU_LUC > 0 THEN DATEADD(DAY,SO_NGAY_HIEU_LUC,NGAY_CAP_NHAT) ELSE NULL END AS NGAY_HIEU_LUC,
                     CASE WHEN PRIOR='Y' THEN 'Tin tức nổi bật' ELSE NULL END TIN_NOI_BAT
                     FROM TIN_TUC  WHERE  NGAY_CAP_NHAT <> (SELECT MAX(NGAY_CAP_NHAT)
                                            FROM TIN_TUC
                                            WHERE PRIOR = 'N' AND DUYET = '2')
                     AND 1=1", 5 - (ds.Tables[0].Rows.Count + dtTT_Max.Rows.Count))
                );
            query2.addID("NHOM_TIN", Nhom_tin);
            query2.addDateFromTo("NGAY_CAP_NHAT", Tungay, Denngay);
            query2.addCondition("NHOM_TIN IN (SELECT ID FROM DM_NHOM_TIN_TUC WHERE VISIBLE_BIT ='Y')");
            query2.setDescOrderBy("NGAY_CAP_NHAT");
            if (ds.Tables[0].Rows.Count > 0)
                query2.addCondition(string.Format("ID != '{0}'",ds.Tables[0].Rows[0]["ID"].ToString()));
            
            if (fQuanTri.isRead)//(DATinTuc.Instance.getNguoiDuyet(DATinTuc.quyenDuyet).Contains(FrameworkParams.currentUser.employee_id))
                query2.addDuyet(PLConst.FIELD_DUYET, TTDuyet.layTrangThai());
            else
                query2.addCondition(string.Format("{0} ='2' or NGUOI_CAP_NHAT = {1}", PLConst.FIELD_DUYET, FrameworkParams.currentUser.employee_id));

            DataTable dtTT = TinTucPermission.I._LoadDataSetWithResGroupPermission(query2, "NHOM_TIN", Nhom_tin).Tables[0];
            foreach (DataRow row in dtTT_Max.Rows) ds.Tables[0].ImportRow(row);
            foreach (DataRow row in dtTT.Rows) ds.Tables[0].ImportRow(row);
            return ds;
        }

        public bool INSERT_TIN_TUC_TAP_TIN(long ID_TIN, long ID_TAP_TIN)
        {
            string sql = string.Format("INSERT INTO OBJECT_TAP_TIN VALUES({0},{1},1)", ID_TAP_TIN, ID_TIN);
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);                        
            try
            {
                return db.ExecuteNonQuery(cmd)>0;
            }
            catch (Exception ex) { PLException.AddException(ex); return false;     }
        }        
        public long TAP_TIN_ID(long ID)
        {
            string sql = string.Format("SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID = 1", ID);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            if (ds.Tables[0].Rows.Count > 0)
                return HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0]);
            else
                return -1;
        }
        public bool Update_tinh_trang(long id, string duyet,long nguoiDuyet,DateTime ngayDuyet)
        {
            string sql = string.Format(@"UPDATE TIN_TUC SET DUYET = '{0}',NGUOI_DUYET = {1},NGAY_DUYET = '{2}' 
                                            WHERE ID = {3}", duyet, nguoiDuyet, ngayDuyet.ToString("MM/dd/yyyy HH:mm"), id);
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            return (db.ExecuteNonQuery(cmd) > 0);
        }
        #endregion

        #region Xử lý gửi mail
        public bool _SendThongBao(DOTinTuc newPageper,string STATUS) { 
            ///1.Nội dung
            AddressList To = new AddressList();
            string temp = "";
            switch (STATUS) {
                case "DUYET":
                    temp = "Có tin mới được duyệt";
                    //Gửi đến tất cả các nhân viên
                    To = HelpZPLOEmail.GetAddressList(new long[] {});
                    break;
                case "ADD":
                    temp = "Có tin mới được cập nhật đang chờ duyệt";
                    //Gửi đến những người có quyền duyệt
                    To = HelpZPLOEmail.GetAddressList(getNguoiDuyetFromFeature("FDuyetTinTuc").ToArray());
                    break;
                case "EDIT":
                    temp = "Có tin mới được cập nhật đang chờ duyệt";
                    //Gửi đến những người có quyền duyệt
                    To = HelpZPLOEmail.GetAddressList(getNguoiDuyetFromFeature("FDuyetTinTuc").ToArray());
                    break;
                case "KHONG_DUYET":
                    temp = "Có tin không được duyệt";
                    //Gửi đến người tạo tin
                    To = HelpZPLOEmail.GetAddressList(new long[] { newPageper.NGUOI_CAP_NHAT });
                    break;
                case "CHO_DUYET":
                    //Gửi đến người đã tạo tin
                    temp = "Có được cập nhật đang chờ duyệt";
                    To = HelpZPLOEmail.GetAddressList(getNguoiDuyetFromFeature("FDuyetTinTuc").ToArray());
                    break;
            }
            string Title = HelpStringBuilder.GetTitleMailNewPageper(temp);
            
            string NhomTin = HelpDB.getDatabase().LoadDataSet(new QueryBuilder(
               @"SELECT * FROM DM_NHOM_TIN_TUC WHERE ID=" + newPageper.NHOM_TIN + " AND 1=1")).Tables[0].Rows[0]["NAME"].ToString();
            string Subject = HelpStringBuilder.GetDesMailNewPageper(DMFWNhanVien.GetFullName(newPageper.NGUOI_CAP_NHAT), newPageper.NGAY_CAP_NHAT.ToString(), NhomTin, newPageper.TIEU_DE);
            //3.Gửi mail
            return HelpZPLOEmail.SendSmartHost( HelpAutoOpenForm.GeneratingCodeFromForm(typeof(frmNewsPaper).FullName,newPageper.ID),
                Title, null, To, null, null, Subject, "");
        }
        public List<long> getNguoiDuyet(long KeyFEATURE)
        {
            List<long> list = new List<long>();
            QueryBuilder query = new QueryBuilder(@"
                SELECT  DISTINCT U.EMPLOYEE_ID AS ID FROM USER_CAT U,  FEATURE_CAT F
                WHERE
                (
                    (
                        U.USERID IN (SELECT USER_FEATURE_REL.USERID FROM USER_FEATURE_REL WHERE USER_FEATURE_REL.FEATUREID=F.ID AND USER_FEATURE_REL.ISREAD_BIT='Y')
                    )
                    OR
                    (
                        U.USERID IN (SELECT GROUP_USER_REL.USERID FROM GROUP_USER_REL WHERE GROUP_USER_REL.GROUPID IN(SELECT GROUP_FEATURE_REL.GROUPID FROM GROUP_FEATURE_REL WHERE GROUP_FEATURE_REL.FEATUREID=F.ID AND GROUP_FEATURE_REL.ISREAD_BIT='Y') )
                    )
                )
                AND 1=1");
            query.addID("F.ID", KeyFEATURE);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                list.Add(HelpNumber.DecimalToInt64(r["ID"]));
            }
            return list;
        }
        public List<long> getNguoiDuyetFromFeature(string FEATURE)
        {
            List<long> list = new List<long>();
            QueryBuilder query = new QueryBuilder(@"
                SELECT  DISTINCT U.EMPLOYEE_ID AS ID FROM USER_CAT U,  FEATURE_CAT F
                WHERE
                (
                    (
                        U.USERID IN (SELECT USER_FEATURE_REL.USERID FROM USER_FEATURE_REL WHERE USER_FEATURE_REL.FEATUREID=F.ID AND USER_FEATURE_REL.ISREAD_BIT='Y')
                    )
                    OR
                    (
                        U.USERID IN (SELECT GROUP_USER_REL.USERID FROM GROUP_USER_REL WHERE GROUP_USER_REL.GROUPID IN(SELECT GROUP_FEATURE_REL.GROUPID FROM GROUP_FEATURE_REL WHERE GROUP_FEATURE_REL.FEATUREID=F.ID AND GROUP_FEATURE_REL.ISREAD_BIT='Y') )
                    )
                )
                AND 1=1");
            query.add("F.NAME",Operator.Equal,FEATURE,DbType.String);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                list.Add(HelpNumber.DecimalToInt64(r["ID"]));
            }
            return list;
        }
        #endregion

    }
}
