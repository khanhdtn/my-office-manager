using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data.Common;
using office;

using System.Windows.Forms;
using DTO;
using CrystalDecisions.Enterprise;
using System.IO;

namespace DAO
{
    public class DADocument : DAPhieu<DODocument>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                
                "NAME", null,	                                           										
				"PHIEN_BAN", null,
                "MO_TA",null, 
                "LOAI_TAI_LIEU_ID", null,	
                "VISIBLE_BIT",null,                             
                "NGUOI_CAP_NHAT",null,
                "NGAY_CAP_NHAT",null,
                "DATA_ID",null
        };
        public static DADocument Instance = new DADocument();

        private DADocument() : base() { }


        #region Xử lý dữ liệu
        public static string HTMLtoText(string HTML)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string s = reg.Replace(HTML, "");
            return s.Replace("&nbsp;", " ");
        }
        public static DataTable getDM_TAI_LIEU(long loai_tai_lieu_id)
        {
            //string strSQL = "SELECT TL.* FROM DM_TAI_LIEU TL WHERE TL.LOAI_TAI_LIEU_ID='" + loai_tai_lieu_id + "'";
            //if (loai_tai_lieu_id == 1)
            //{
            //    strSQL = "SELECT TL.* FROM DM_TAI_LIEU TL ORDER BY LOAI_TAI_LIEU_ID";
            //}
            //DataSet ds = null;
            //if (FrameworkParams.currentUser.username != "admin")
            //{
            //    //DUYVT: Dùng hàm Load DataSet có phân quyền trên tài nguyên
            //    ds = Test.FW.LoadDataSetWithPermissionOnRes(strSQL, "DM_TAI_LIEU", "TL.ID");
            //}else ds = DABase.getDatabase().LoadDataSet(strSQL);

            //CHAUTV
            string str = @"SELECT TL.ID,TL.NAME,TL.PHIEN_BAN,TL.NGUOI_CAP_NHAT,TL.NGAY_CAP_NHAT, TL.LOAI_TAI_LIEU_ID 
                            FROM DM_TAI_LIEU TL                         
                            WHERE TL.VISIBLE_BIT = 'Y' AND 1=1";
            QueryBuilder query = new QueryBuilder(str);
            query.addID("LOAI_TAI_LIEU_ID", loai_tai_lieu_id);
            //DataSet ds = HelpDB.getDBService().LoadDataSet(query);
            //if (FrameworkParams.currentUser.username != "admin")
            //{
            //    //DUYVT: Dùng hàm Load DataSet có phân quyền trên tài nguyên
            //    ds = Test.FW.LoadDataSetWithPermissionOnRes(query, "DM_TAI_LIEU", "TL.ID");
            //}
            //else ds = DABase.getDatabase().LoadDataSet(query);

            // Khanhdtn: Load phân quyền mới
            DataSet ds = TaiLieuPermission.I._LoadDataSetWithResPermission(query, "DM_TAI_LIEU", "TL.ID");

            //END
            DataTable dt = null;
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];
            return dt;
        }
        public bool Update_tinh_trang(long ID, string Duyet)
        {
            string sql = "";
            sql = "Update DM_TAI_LIEU set DUYET='" + Duyet + "' where ID=" + ID;
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            return (db.ExecuteNonQuery(cmd) > 0);
        }
        public static DataTable getDM_TAI_LIEU()
        {
            string strSQL = "select *  from DM_TAI_LIEU";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(strSQL);
            DataTable dt = null;
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];
            return dt;
        }

        public static byte[] getDM_NOI_DUNG_TAI_LIEU(long tai_lieu_id)
        {
            string strSQL = "select NOI_DUNG from DM_NOI_DUNG_TAI_LIEU where TAI_LIEU_ID =" + tai_lieu_id;
            DataSet ds = HelpDB.getDatabase().LoadDataSet(strSQL);
            DataTable dt = null;
            byte[] bytes = null;
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];
            if (dt.Rows.Count == 1)
                bytes = (byte[])dt.Rows[0][0];
            return bytes;
        }

        public static DataTable getDM_NHAN_VIEN()
        {
            string strSQL = "select *  from DM_NHAN_VIEN";
            DataSet ds = HelpDB.getDatabase().LoadDataSet(strSQL);
            DataTable dt = null;
            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];
            return dt;
        }

        public static void Insert(DatabaseFB db, DbTransaction dbTrans, DODocument doTailieu)
        {
            DbCommand cmd = db.GetSQLStringCommand("insert into DM_TAI_LIEU values(@id, @NAME, @phien_ban, @mo_ta, @loai_tai_lieu_id, @visible_bit, @nguoi_gui, @ngay_gui, @nguoi_cap_nhat, @ngay_cap_nhat, @data_id)");

            db.AddInParameter(cmd, "@id", DbType.Int64, doTailieu.ID);
            db.AddInParameter(cmd, "@NAME", DbType.String, doTailieu.NAME);
            db.AddInParameter(cmd, "@phien_ban", DbType.String, doTailieu.PHIEN_BAN);
            db.AddInParameter(cmd, "@mo_ta", DbType.String, doTailieu.MO_TA);
            db.AddInParameter(cmd, "@loai_tai_lieu_id", DbType.Int64, doTailieu.LOAI_TAI_LIEU_ID);
            db.AddInParameter(cmd, "@visible_bit", DbType.String, doTailieu.VISIBLE_BIT);
            db.AddInParameter(cmd, "@nguoi_cap_nhat", DbType.Int64, doTailieu.NGUOI_CAP_NHAT);
            db.AddInParameter(cmd, "@ngay_cap_nhat", DbType.Binary, doTailieu.NGAY_CAP_NHAT);
            db.AddInParameter(cmd, "@data_id", DbType.Int64, doTailieu.DATA_ID);

            int value = db.ExecuteNonQuery(cmd, dbTrans);
        }
        public bool INSERT_TAI_LIEU_TAP_TIN(long ID_TAI_LIEU, long ID_TAP_TIN)
        {
            string sql = string.Format(@"INSERT INTO OBJECT_TAP_TIN VALUES({0},{1},3)", ID_TAP_TIN, ID_TAI_LIEU);
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            try
            {
                return db.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex) { HelpMsgBox.ShowConfirmMessage(ex.ToString()); return false; }
        }

        public DOLuuTruTapTin load_DOTapTin(Int64 ID_TaiLieu)
        {
            DOLuuTruTapTin dott = new DOLuuTruTapTin();
            DataSet ds = HelpDB.getDatabase().LoadDataSet(string.Format(@"SELECT LUU_TRU_TAP_TIN.* 
            FROM LUU_TRU_TAP_TIN 
            WHERE ID IN (SELECT TAP_TIN_ID FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID = 3)", ID_TaiLieu));
            if (ds.Tables[0].Rows.Count > 0)
                dott = DALuuTruTapTin.Instance.Load(HelpNumber.ParseInt64(ds.Tables[0].Rows[0][0]));
            return dott;

        }
        public static void Update(DatabaseFB db, DbTransaction dbTrans, DODocument doTailieu)
        {
            DbCommand cmd = db.GetSQLStringCommand("update DM_TAI_LIEU set NAME = @NAME, PHIEN_BAN = @phien_ban, MO_TA = @mo_ta, VISIBLE_BIT = @visible_bit, NGUOI_CAP_NHAT = @nguoi_cap_nhat, NGAY_CAP_NHAT = @ngay_cap_nhat where ID = @id");

            db.AddInParameter(cmd, "@id", DbType.Int64, doTailieu.ID);
            db.AddInParameter(cmd, "@NAME", DbType.String, doTailieu.NAME);
            db.AddInParameter(cmd, "@phien_ban", DbType.String, doTailieu.PHIEN_BAN);
            db.AddInParameter(cmd, "@mo_ta", DbType.String, doTailieu.MO_TA);
            db.AddInParameter(cmd, "@visible_bit", DbType.String, doTailieu.VISIBLE_BIT);
            db.AddInParameter(cmd, "@nguoi_cap_nhat", DbType.Int64, doTailieu.NGUOI_CAP_NHAT);
            db.AddInParameter(cmd, "@ngay_cap_nhat", DbType.Binary, doTailieu.NGAY_CAP_NHAT);

            int value = db.ExecuteNonQuery(cmd, dbTrans);
        }

        public static void Update(DatabaseFB db, DbTransaction dbTrans, long id)
        {
            DbCommand cmd = db.GetSQLStringCommand("delete DM_TAI_LIEU where ID = @id");

            db.AddInParameter(cmd, "@id", DbType.Int64, id);

            int value = db.ExecuteNonQuery(cmd, dbTrans);
        }
        public void Open_file_from_byte(byte[] Noi_dung, string Ten_tap_tin)
        {
            try
            {
                string Path_new = FrameworkParams.TEMP_FOLDER + @"\" + Ten_tap_tin;
                HelpByte.BytesToFile(Noi_dung, Path_new);
                HelpFile.OpenFile(Path_new);
            }
            catch
            {
                HelpMsgBox.ShowNotificationMessage("Tập tin đã bị xóa hoặc không tồn tại !");
            }
        }
        public string GetPathFileFromByte(byte[] NoiDung, string TenTapTin)
        {
            try
            {
                string PathFile = FrameworkParams.TEMP_FOLDER + @"\" + TenTapTin;

                HelpByte.BytesToFile(NoiDung, PathFile);
                object Target = new object();
                if (Path.GetExtension(PathFile).ToLower().Equals(".doc"))
                    Target = PathFile.Replace(".doc", ".rtf");
                if (Path.GetExtension(PathFile).ToLower().Equals(".docx"))
                    Target = PathFile.Replace(".docx", ".rtf");
                ConvertFromDocToRtf(PathFile, Target);
                return Target.ToString();
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return string.Empty;
            }
        }
        public void ConvertFromDocToRtf(string PathSource, object Target)
        {
            FileInfo fi = new FileInfo(Target.ToString());
            if (fi.Exists) return;
            Word.Application newApp = new Word.Application();
            // specifying the Source & Target file names
            object Source = PathSource;
            // Use for the parameter whose type are not known or  
            // say Missing
            object Unknown = Type.Missing;
            Application.DoEvents();
            // Source document open here
            // Additional Parameters are not known so that are  
            // set as a missing type            
            newApp.Documents.Open(ref Source, ref Unknown,
                 ref Unknown, ref Unknown, ref Unknown,
                 ref Unknown, ref Unknown, ref Unknown,
                 ref Unknown, ref Unknown, ref Unknown,
                 ref Unknown);
            Application.DoEvents();
            // Specifying the format in which you want the output file 
            object format = Word.WdSaveFormat.wdFormatRTF;

            //Changing the format of the document
            newApp.ActiveDocument.SaveAs(ref Target, ref format,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown,
                    ref Unknown, ref Unknown, ref Unknown);
            Application.DoEvents();
            // for closing the application
            newApp.ActiveDocument.Close(ref Unknown, ref Unknown, ref Unknown);
            newApp.Quit(ref Unknown, ref Unknown, ref Unknown);
            Application.DoEvents();
            //Kill tiến trình word hiện tại.
            List<System.Diagnostics.Process> lstProcess = new List<System.Diagnostics.Process>(System.Diagnostics.Process.GetProcesses());
            foreach (var item in lstProcess)
            {
                if (string.Compare(item.ProcessName, "WINWORD.EXE") == 0 &&
                    item.StartTime.AddMinutes(1) >= DateTime.Now)
                    //string.Compare(DateTime.Now.ToString("dd/MM/yyyy HH:mm"), item.StartTime.ToString("dd/MM/yyyy HH:mm")) == 0)
                    item.Kill();
            }
        }
        public void Save_file_from_byte(byte[] Noi_dung, string Ten_tap_tin)
        {
            int i = Ten_tap_tin.LastIndexOf('.');
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FilterIndex = -1;
            saveFileDialog1.AddExtension = false;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.Title = "Save as";
            saveFileDialog1.FileName = Ten_tap_tin;
            saveFileDialog1.Filter = "All files|*.*";
            saveFileDialog1.InitialDirectory = FrameworkParams.TEMP_FOLDER + @"\";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    HelpByte.BytesToFile(Noi_dung, saveFileDialog1.FileName + Ten_tap_tin.Substring(i, Ten_tap_tin.Length - i));
                }
                catch
                {
                    HelpMsgBox.ShowNotificationMessage("Lưu tập tin không thành công !");
                }
            }
        }
        public bool Xoa_DM_TAI_LIEU(long ma)
        {
            try
            {
                if (TaiLieuPermission.I._checkPermissionRes(ma, PermissionOfResource.RES_PERMISSION_TYPE.DELETE) == false)
                {
                    HelpMsgBox.ShowNotificationMessage("Bạn không có quyền xóa tài liệu này!");
                    return false;
                }
                DatabaseFB db = HelpDB.getDatabase();
                DbTransaction trans = db.BeginTransaction(db.OpenConnection());
                DbCommand cm = db.GetSQLStringCommand("delete from DM_TAI_LIEU where ID='" + ma + "'");
                bool ok = db.ExecuteNonQuery(cm, trans) > 0;
                if (ok)
                    FWTransaction.Commit(trans);
                else
                    FWTransaction.Rollback(trans);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Xoa_tap_tin_tai_lieu(long id_tl)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format(@"Delete from LUU_TRU_TAP_TIN WHERE ID IN
            (SELECT LIST(TAP_TIN_ID) FROM OBJECT_TAP_TIN WHERE OBJECT_ID = {0} AND TYPE_ID = 3)", id_tl));
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static void Luu_TaiLieu_TapTin(long ID_TaiLieu, long ID_TapTin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(@"INSERT INTO OBJECT_TAP_TIN VALUES(@TAI_LIEU_ID,@TAP_TIN_ID,@TYPE_ID)");
            db.AddInParameter(cm, "@TAI_LIEU_ID", DbType.Int64, ID_TaiLieu);
            db.AddInParameter(cm, "@TAP_TIN_ID", DbType.Int64, ID_TapTin);
            db.AddInParameter(cm, "@TYPE_ID", DbType.Int32, 3);
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static void Xoa_tailieu_taptin(long id_taptin)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format("DELETE FROM OBJECT_TAP_TIN WHERE TAP_TIN_ID={0} AND TYPE_ID = 3", id_taptin));
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public static bool check_exists_taptin_in_tailieu(long id_tl)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet(string.Format(@"SELECT * 
            FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID = 3", id_tl));
            return ds.Tables[0].Rows.Count > 0;
        }
        #endregion

        //PHUOCNT NC Đoạn code này để làm gì ????
        //TRANGDTT NC Kiểm tra dùm anh
        #region Kiểm tra quyền

        /// <summary>
        /// Kiểm tra xem người dùng có quyền Read, Insert, Update, Delete hay không.
        ///     2. Quyền Read
        ///     3. Quyền Insert
        ///     4. Quyền Update
        ///     5. Quyền Delete
        /// </summary>
        public static bool checkUserId(string frmName, int grantValue, long nguoi_gui)
        {
            //Người đăng nhập là người gửi tài liệu thì có toàn quyền
            if (FrameworkParams.currentUser.employee_id == nguoi_gui)
                return true;
            else // Người đăng nhập không phải là người gửi tài liệu
            {
                if (getGrantUser(frmName, FrameworkParams.currentUser.id, grantValue))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm quyền của currentUser, với Id là ID của currentUser và 
        ///     2. Quyền Read
        ///     3. Quyền Insert
        ///     4. Quyền Update
        ///     5. Quyền Delete
        /// </summary>
        public static bool getGrantUser(string frmName, long user_id, int grantValue)
        {
            string strSQL = "select uft.featureid, uft.userid, uft.isread_bit, uft.isinsert_bit, uft.isupdate_bit, uft.isdelete_bit" +
                            " from user_feature_rel uft inner join feature_cat ft on uft.featureid = ft.id" +
                            " where uft.userid = " + user_id +
                            " and ft.name = '" + frmName + "'";

            DataTable dt = HelpDB.getDatabase().LoadDataSet(strSQL).Tables[0];
            if (dt.Rows.Count > 0)
                if (dt.Rows[0][grantValue].ToString() == "Y")
                    return true;
            return false;
        }

        #endregion
        #region Các hàm kế thừa

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DODocument LoadAll(long IDKey)
        {
            DODocument phieu = this.Load(IDKey);
            //phieu.DetailDataSet = DABase.getDatabase().LoadDataSet("DM_TAI_LIEU", "ID", IDKey);
            //DUYVT: Dùng hàm Load DataSet có phân quyền trên tài nguyên
            //phieu.DetailDataSet = Test.FW.LoadDataSetWithPermissionOnRes("DM_TAI_LIEU", "ID", IDKey);

            //KHANHDTN:Dùng hàm load phân quyền mới
            phieu.DetailDataSet = new DataSet();
            TaiLieuPermission.I._LoadDataSetWithResPermission(phieu.DetailDataSet, "DM_TAI_LIEU", "ID", IDKey);
            //
            return phieu;
        }

        public override bool UpdateDetail(DataSet Detail, DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateDetail(DataRow row)
        {
            return HelpInputData.ValidateRow(null, row, GetRule());
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            throw new NotImplementedException();
        }

        public override DODocument Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("DM_TAI_LIEU", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DODocument data = (DODocument)this.Builder.CreateFilledObject(typeof(DODocument), reader);
                    return data;
                }
            }
            return new DODocument();
        }

        public override bool Update(DODocument data)
        {
            bool flag = false;
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DataSet MainDS = FWDBService.LoadDataSet("DM_TAI_LIEU", KEY_FIELD_NAME, data.ID);
            if (MainDS.Tables[0].Rows.Count == 1)
            {
                //DUYVT: Kiểm tra quyền cập nhật trên tài nguyên thuộc loại tài liệu
                //if (!LoaiTaiLieu_TaiLieu.I._checkPermissionResGroup(
                //    data.LOAI_TAI_LIEU_ID, PERMISSION_RES.UPDATE))
                //{
                //    HelpMsgBox.ShowNotificationMessage(
                //        "Bạn không có quyền cập nhật trên tài nguyên thuộc loại tài liệu này!");
                //    return false;
                //}
                //
                HelpDataSet.UpdataDataRow(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            else
            {
                //DUYVT: Kiểm tra quyền tạo mới tài nguyên thuộc loại tài liệu
                //if (!LoaiTaiLieu_TaiLieu.I._checkPermissionResGroup(
                //    data.LOAI_TAI_LIEU_ID, PERMISSION_RES.CREATE))
                //{
                //    HelpMsgBox.ShowNotificationMessage(
                //        "Bạn không có quyền tạo mới tài nguyên thuộc loại tài liệu này!");
                //    return false;
                //}
                //
                DataRow row = MainDS.Tables[0].NewRow();
                row[KEY_FIELD_NAME] = data.ID;//= DABase.getDatabase().GetID("G_NGHIEP_VU");
                HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                MainDS.Tables[0].Rows.Add(row);
                flag = db.UpdateDataSet(MainDS, dbTrans);
            }
            if (flag == true)
            {
                db.CommitTransaction(dbTrans);
                data.ID = HelpNumber.ParseInt64(MainDS.Tables[0].Rows[0][KEY_FIELD_NAME]);
            }
            else db.RollbackTransaction(dbTrans);
            return flag;
        }

        public void Xoa_all_taptin_tailieu(long id_tl)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand(string.Format(@"DELETE FROM OBJECT_TAP_TIN WHERE OBJECT_ID={0} AND TYPE_ID=3", id_tl));
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }
        public override bool Validate(DODocument element)
        {
            throw new NotImplementedException();
        }
        public FieldNameCheck[] GetRule()
        {
            return new FieldNameCheck[] { 
                new FieldNameCheck("NAME",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Tên tài liệu")}, 
                    new object[]{ }),
                new FieldNameCheck("MO_TA",
                    new CheckType[]{ CheckType.Required},
                    new string[]{ HelpErrorMsg.errorRequired("Mô tả")}, 
                    new object[]{ }),
                new FieldNameCheck("PHIEN_BAN",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Phiên bản")}, 
                    new object[]{ }),
                new FieldNameCheck("LOAI_TAI_LIEU_ID",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Loại tài liệu")}, 
                    new object[]{ }),
                new FieldNameCheck("NGUOI_GUI",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Người gửi")}, 
                    new object[]{ }),
                new FieldNameCheck("NGAY_GUI",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Ngày gửi")}, 
                    new object[]{ }),
                new FieldNameCheck("NGUOI_CAP_NHAT",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Người cập nhật")}, 
                    new object[]{ }),
                new FieldNameCheck("TEN_FILE",
                    new CheckType[]{ CheckType.Required },
                    new string[]{ HelpErrorMsg.errorRequired("Tên file")}, 
                    new object[]{ })
            };
        }
        #endregion

        public static void InitCtrl(PLCombobox Input, bool? IsAdd)
        {
            string sql = "SELECT ID,NAME FROM DM_LOAI_TAI_LIEU WHERE 1=1";
            QueryBuilder query = new QueryBuilder(sql);
            if (IsAdd == true)
                query.addCondition("VISIBLE_BIT='Y'");
            query.setAscOrderBy("NAME");
            DataSet dsNV = TaiLieuPermission.I._LoadDataSetWithResGroupPermission(query, "ID");
            Input._init(dsNV.Tables[0], "NAME", "ID");
        }
    }
}
