using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data.Common;
using System.Reflection;
using ProtocolVN.Framework.Win;
using office;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using pl.office;
using System.Windows.Forms;
namespace DAO
{
    public enum StateTheEnd
    {
        Auto = 1,
        IsEnd = 2
    }
    public class DATimeInOut : DAPhieu<DOTimeInOut>
    {
        private static string KEY_FIELD_NAME = "ID";
        public static string TABLE_MAP = "CAPNHAT_NGAYLAMVIEC";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),
                "NV_ID", new IDConverter(),	
				"NGAY_LAM_VIEC", null,	
				"GIO_BAT_DAU",new TimeConverter(),				
				"GIO_KET_THUC", new TimeConverter(),
                "THOI_GIAN_LAM_VIEC",new TimeConverter(),
                "IS_CHAM_CONG", null,
                "NGHI_BUOI_SANG",null,
                "NGHI_BUOI_CHIEU",null,
                "NGHI_PHEP_NAM",null,
                "NGHI_KHONG_LUONG",null,
                "NOI_DUNG",null,                            
                "NGUOI_GHI_NHAN",null,
                "THOI_GIAN_GHI_NHAN",null,
                "LOAI",null,
                "DUYET",null,
                "NGUOI_DUYET",null,
                "NGAY_DUYET",null,
                "IP_ADDRESS",null,
                "LOAI_DI_TRE_VE_SOM",null,
                "THOI_GIAN_SANG",null,
                "THOI_GIAN_CHIEU",null,
                "LOAI_XAC_NHAN",null,
                "TAI_DON_VI",null,
                "CONG_VIEC",null,
                "LY_DO",null
        };

        public static DATimeInOut Instance = new DATimeInOut();
        public DATimeInOut() : base() { }

        #region Methods of Framework

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOTimeInOut LoadAll(long IDKey)
        {
            DOTimeInOut phieu = this.Load(IDKey);
            phieu.DetailDataSet = DatabaseFB.LoadDataSet("CAPNHAT_NGAYLAMVIEC", KEY_FIELD_NAME, IDKey);
            return phieu;
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
            return DatabaseFB.DeleteRecord("CAPNHAT_NGAYLAMVIEC", KEY_FIELD_NAME, IDKey);
        }

        public override DOTimeInOut Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("CAPNHAT_NGAYLAMVIEC", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOTimeInOut data = (DOTimeInOut)this.Builder.CreateFilledObject(typeof(DOTimeInOut), reader);

                    return data;
                }
            }
            return new DOTimeInOut();
        }

        public override bool Update(DOTimeInOut data)
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

        public override bool Validate(DOTimeInOut element)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Mở rộng
        public bool UpdatePhieu(DOTimeInOut data)
        {
            DatabaseFB db = HelpDB.getDatabase();
            db.OpenConnection();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            try
            {
                if (db.UpdateDataSet(data.DetailDataSet, dbTrans) == false) return false;
            }
            catch (Exception ex)
            {
                HelpSysLog.AddException(ex, "Lưu thời gian làm việc không thành công.");
                db.RollbackTransaction(dbTrans);
            }
            db.CommitTransaction(dbTrans);
            return true;
        }
        public DOTimeInOut Load(long NV_ID, DateTime NgayLamViec, int LOAI)
        {
            DatabaseFB fb = HelpDB.getDatabase();
            string Sql = @"select * from CAPNHAT_NGAYLAMVIEC
                           where NV_ID = @NV_ID 
                           and NGAY_LAM_VIEC = @NGAY_LAM_VIEC 
                           and LOAI=@LOAI 
                           ";
            DbCommand cmd = fb.GetSQLStringCommand(Sql);
            fb.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            fb.AddInParameter(cmd, "@NGAY_LAM_VIEC", DbType.DateTime, NgayLamViec);
            fb.AddInParameter(cmd, "@LOAI", DbType.Int32, LOAI);
            IDataReader reader = fb.ExecuteReader(cmd);
            using (reader)
            {
                if (reader.Read())
                {
                    DOTimeInOut data = (DOTimeInOut)this.Builder.CreateFilledObject(typeof(DOTimeInOut), reader);
                    return data;
                }
            }
            return new DOTimeInOut();
        }
        public DOTimeInOut LoadAll(long NV_ID, DateTime NgayLamViec, int LOAI)
        {
            DOTimeInOut phieu = this.Load(NV_ID, NgayLamViec, 1);//chi lay nhung dong la ngay lam viec->*1*
            DatabaseFB fb = HelpDB.getDatabase();
            string Sql = @"select * from CAPNHAT_NGAYLAMVIEC
                           where NV_ID = @NV_ID 
                           and NGAY_LAM_VIEC = @NGAY_LAM_VIEC 
                           and LOAI=@LOAI  
                           ";
            DbCommand cmd = fb.GetSQLStringCommand(Sql);
            fb.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            fb.AddInParameter(cmd, "@NGAY_LAM_VIEC", DbType.DateTime, NgayLamViec);
            fb.AddInParameter(cmd, "@LOAI", DbType.Int32, LOAI);
            phieu.DetailDataSet = fb.LoadDataSet(cmd, "CAPNHAT_NGAYLAMVIEC");
            return phieu;

        }
        public bool Update_tinh_trang(long ID, string Duyet)
        {
            string sql = "";
            sql = "Update CAPNHAT_NGAYLAMVIEC set DUYET='" + Duyet + "',NGUOI_DUYET=" + DAChiTietCongViec.Instance.GetNVID(HelpNumber.ParseInt64(FrameworkParams.currentUser.id)) + ",NGAY_DUYET='" + HelpDB.getDatabase().GetSystemCurrentDateTime().ToString("MM/dd/yyyy HH:mm:ss") + "' where ID=" + ID;
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            return (db.ExecuteNonQuery(cmd) > 0);
        }
        public DataSet Load_detailDs(DateTime Ngay_lam_viec)
        {
            string sql = @"Select *
                            from CAPNHAT_NGAYLAMVIEC where LOAI=1 and 1=1";
            QueryBuilder query = new QueryBuilder(sql);
            query.addDateFromTo("NGAY_LAM_VIEC", Ngay_lam_viec, Ngay_lam_viec);
            return HelpDB.getDatabase().LoadDataSet(query, "CAPNHAT_NGAYLAMVIEC");
        }
        public void ChonLoaiDiTreVeSom(PLMultiCombobox Input, bool? IsAdd, bool ReadOnly)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(System.Int64));
            dt.Columns.Add("NAME", typeof(System.String));
            dt.Rows.Add(new object[] { 1, "Trễ buổi sáng" });
            dt.Rows.Add(new object[] { 2, "Trễ buổi chiều" });
            dt.Rows.Add(new object[] { 3, "Về sớm buổi sáng" });
            dt.Rows.Add(new object[] { 4, "Về sớm buổi chiều" });
            ds.Tables.Add(dt);
            Input._init(dt, "NAME", "ID");
        }

        /// <summary>CHAUTV : Dathq chú ý validation lại chỗ này
        /// </summary>
        public bool CheckExistDT_VS(long NVID, DateTime Ngay_DTVS, int LoaiDT_VS)
        {
            DatabaseFB fb = HelpDB.getDatabase();
            string Sql = @"Select ID from CapNhat_NgayLamViec where NV_ID=@NV_ID 
                and NGAY_LAM_VIEC=@NgayLamViec and LOAI=3 and LOAI_DI_TRE_VE_SOM=@LoaiDT_VS ";
            DbCommand cmd = fb.GetSQLStringCommand(Sql);
            fb.AddInParameter(cmd, "@NV_ID", DbType.Int64, NVID);
            fb.AddInParameter(cmd, "@NgayLamViec", DbType.DateTime, Ngay_DTVS);
            fb.AddInParameter(cmd, "@LoaiDT_VS", DbType.Int32, LoaiDT_VS);
            return fb.ExecuteReader(cmd).Read();
        }

        //CHAUTV : 
        public bool MergeDataSet(DataSet forDB, DOTimeInOut data)
        {
            bool flag = false;
            try
            {
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
                    data.ID = HelpDB.getDatabase().GetID(PLConst.G_NGHIEP_VU);
                    row["ID"] = data.ID;
                    flag = HelpDataSet.UpdataDataRow(row, FIELD_MAP, data);
                    data.DetailDataSet.Tables[0].Rows.Add(row);
                }
                if (flag)
                {
                    try
                    {
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, forDB, data.DetailDataSet);
                    }
                    catch (Exception ex)
                    {
                        PLException.AddException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return flag;
        }
        public DataSet LoaiXacNhan()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(System.Int64));
            dt.Columns.Add("NAME", typeof(System.String));
            dt.Rows.Add(new object[] { 1, "Công tác ngoài" });
            dt.Rows.Add(new object[] { 2, "Tại công ty" });
            ds.Tables.Add(dt);
            return ds;
        }
        public void DefaultDate(DateEdit from, DateEdit to)
        {
            DateTime Now = HelpDB.getDatabase().GetSystemCurrentDateTime();
            HelpDate.SetDateEdit(from, Now.AddDays(-7));
            HelpDate.SetDateEdit(to, Now.AddDays(7));
        }
        #endregion

        #region Tính thời gian làm việc
        public static TimeSpan getThoiGianLamViec(object gioStart, object gioEnd)
        {
            TimeSpan TG_LamViec = new TimeSpan(0, 0, 0);
            if (gioEnd != null)
            {
                TimeSpan timeE = TimeSpan.Parse(gioEnd.ToString());
                TimeSpan timeS = TimeSpan.Parse(gioStart.ToString());

                TimeSpan _DBSang = AppGetSysParam.GetGIO_BAT_DAU_SANG;
                TimeSpan _KTSang = AppGetSysParam.GetGIO_KET_THUC_SANG;
                TimeSpan _KTChieu = AppGetSysParam.GetGIO_KET_THUC_CHIEU;
                TimeSpan _DBChieu = AppGetSysParam.GetGIO_BAT_DAU_CHIEU; 
                if (timeS <= _DBSang) timeS = _DBSang;
                if (_KTSang <= timeS && timeS <= _DBChieu) timeS = _DBChieu;
                if (timeE > _KTChieu) timeE = _KTChieu;
                if (_KTSang <= timeE && timeE <= _DBChieu) timeE = _KTSang;
                if (timeE <= _DBChieu)
                    TG_LamViec = new TimeSpan((timeE - timeS).Hours, (timeE - timeS).Minutes, (timeE - timeS).Seconds);
                if (timeE > _DBChieu)
                {
                    if (timeS >= _DBChieu)
                    {
                        TG_LamViec = new TimeSpan((timeE - timeS).Hours, (timeE - timeS).Minutes, (timeE - timeS).Seconds);
                    }
                    else
                    {
                        TG_LamViec = new TimeSpan((timeE - timeS).Hours - 1, (timeE - timeS).Minutes, (timeE - timeS).Seconds);
                    }
                }
                if ((TG_LamViec.ToString().Contains("-")) || (TG_LamViec.Hours + TG_LamViec.Minutes + TG_LamViec.Seconds) == 0)
                    TG_LamViec = new TimeSpan(0, 0, 0);
            }
            return TG_LamViec;
        }
        #endregion

        #region Chuyển sang bảng chấm công 64
        public bool ToChamCong(GridView gridViewMaster,DateTime tuNgay,DateTime denNgay)
        {
            try
            {
                DataRow[] rowsThoiGianLV = ((DataView)gridViewMaster.DataSource).Table.Select("IS_CHAM_CONG ='N' AND LOAI = 1");
                DataRow[] rowsNghiPhep = ((DataView)gridViewMaster.DataSource).Table.Select("IS_CHAM_CONG='N' AND LOAI = 2 AND DUYET = '2'");
                if (rowsThoiGianLV.Length == 0 && rowsNghiPhep.Length == 0) return true;
                DataSet dsChamCong64 = HelpDB.getDatabase().LoadDataSet("SELECT * FROM BANG_CHAM_CONG_64 WHERE 1=1", "BANG_CHAM_CONG_64");
                DataSet dsTimeInOut = DABase.getDatabase().LoadDataSet("SELECT * FROM CAPNHAT_NGAYLAMVIEC WHERE 1=-1", "CAPNHAT_NGAYLAMVIEC");
                //Chuyển thời gian làm việc
                foreach (DataRow row in rowsThoiGianLV)
                {
                    Application.DoEvents();
                    StringBuilder fieldName = new StringBuilder(GetFieldName((DateTime)row["NGAY_LAM_VIEC"]));
                    if (!IsExistsChamCong64(HelpNumber.ParseInt64(row["NV_ID"]), ((DateTime)row["NGAY_LAM_VIEC"]).ToString("MM/yyyy")))
                    {
                        DataRow newRow = dsChamCong64.Tables[0].NewRow();
                        newRow["ID"] = DABase.getDatabase().GetID("G_NGHIEP_VU");
                        newRow["EMP_ID"] = row["NV_ID"];
                        newRow["THANG_NAM"] = ((DateTime)row["NGAY_LAM_VIEC"]).ToString("MM/yyyy");
                        newRow[fieldName.Append("_SANG").ToString()] = GetThoiGianLV(row["THOI_GIAN_SANG"]);
                        newRow[fieldName.Replace("_SANG", "_CHIEU").ToString()] = GetThoiGianLV(row["THOI_GIAN_CHIEU"]);
                        dsChamCong64.Tables[0].Rows.Add(newRow);
                        InsertNewRow(newRow, fieldName.Replace("_CHIEU", "_SANG").ToString(), fieldName.Replace("_SANG", "_CHIEU").ToString());
                    }
                    else
                    {
                        DataRow[] rowChamCong = dsChamCong64.Tables[0].Select(string.Format("EMP_ID = {0} AND THANG_NAM = '{1}'", row["NV_ID"], ((DateTime)row["NGAY_LAM_VIEC"]).ToString("MM/yyyy")));
                        rowChamCong[0][fieldName.Append("_SANG").ToString()] = GetThoiGianLV(row["THOI_GIAN_SANG"]);
                        rowChamCong[0][fieldName.Replace("_SANG", "_CHIEU").ToString()] = GetThoiGianLV(row["THOI_GIAN_CHIEU"]);
                    }
                    row["IS_CHAM_CONG"] = "Y";
                    dsTimeInOut.Tables[0].ImportRow(row);
                }
                //Chuyển nghỉ phép
                foreach (DataRow row in rowsNghiPhep)
                {
                    Application.DoEvents();
                    StringBuilder fieldName = new StringBuilder(GetFieldName((DateTime)row["NGAY_LAM_VIEC"]));
                    if (!IsExistsChamCong64(HelpNumber.ParseInt64(row["NV_ID"]), ((DateTime)row["NGAY_LAM_VIEC"]).ToString("MM/yyyy")))
                    {
                        DataRow newRow = dsChamCong64.Tables[0].NewRow();
                        newRow["ID"] = DABase.getDatabase().GetID("G_NGHIEP_VU");
                        newRow["EMP_ID"] = row["NV_ID"];
                        newRow["THANG_NAM"] = ((DateTime)row["NGAY_LAM_VIEC"]).ToString("MM/yyyy");
                        newRow[fieldName.Append("_SANG").ToString()] = row["NGHI_BUOI_SANG"];
                        newRow[fieldName.Replace("_SANG", "_CHIEU").ToString()] = row["NGHI_BUOI_CHIEU"];
                        dsChamCong64.Tables[0].Rows.Add(newRow);
                        InsertNewRow(newRow, fieldName.Replace("_CHIEU", "_SANG").ToString(), fieldName.Replace("_SANG", "_CHIEU").ToString());
                    }
                    else
                    {
                        DataRow[] rowChamCong = dsChamCong64.Tables[0].Select(string.Format("EMP_ID = {0} AND THANG_NAM = '{1}'", row["NV_ID"], ((DateTime)row["NGAY_LAM_VIEC"]).ToString("MM/yyyy")));
                        string fieldSang=fieldName.Append("_SANG").ToString();
                        string fiedlChieu=fieldName.Replace("_SANG", "_CHIEU").ToString();
                        if (string.Compare(row["NGHI_BUOI_SANG"].ToString(), "Y") == 0)
                            rowChamCong[0][fieldSang] = "N";
                        if (string.Compare(row["NGHI_BUOI_CHIEU"].ToString(), "Y") == 0)
                            rowChamCong[0][fiedlChieu] = "N";
                    }
                    row["IS_CHAM_CONG"] = "Y";
                    dsTimeInOut.Tables[0].ImportRow(row);
                }
                //Cập nhật dữ liệu
                DatabaseFB db = DABase.getDatabase();
                DbTransaction trans = db.BeginTransaction(db.OpenConnection());
                bool result = false;
                try
                {
                    DataSet dsDataChamCong64 = DABase.getDatabase().LoadDataSet("SELECT * FROM BANG_CHAM_CONG_64 WHERE 1=1", "BANG_CHAM_CONG_64");
                    foreach (DataRow row in dsChamCong64.Tables[0].Rows) {
                        row["NGHI_CO_PHEP"] = CountRow(row, "N") / 2;
                        row["NGHI_KHONG_PHEP"] = CountRow(row, "V") / 2;
                        row["SO_NGAY_LAM_VIEC"] = HelpNumber.RoundDecimal((decimal)(CountSoNgay(row) / 8), 4);
                        DuyetThongKe_TC_HL_KL(row, tuNgay, denNgay);
                    }
                    HelpDataSet.MergeDataSet(new string[] { "ID" }, dsDataChamCong64, dsChamCong64);

                    DataSet dsDataTimeInOut = DABase.getDatabase().LoadDataSet("SELECT * FROM CAPNHAT_NGAYLAMVIEC WHERE 1=1", "CAPNHAT_NGAYLAMVIEC");
                    HelpDataSet.MergeDataSet(new string[] { "ID" }, dsDataTimeInOut, dsTimeInOut);

                    result = db.UpdateDataSet(dsDataChamCong64, trans) && db.UpdateDataSet(dsDataTimeInOut, trans);
                    trans.Commit();
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                    return false;
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return true;
        }
        private bool IsExistsChamCong64(long idNV, string thangNam)
        {
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM BANG_CHAM_CONG_64 WHERE 1=1");
            query.addID("EMP_ID", idNV);
            query.addLike("THANG_NAM", thangNam);
            return HelpDB.getDatabase().LoadDataSet(query).Tables[0].Rows.Count > 0;
        }
        private string GetFieldName(DateTime date)
        {
            return "N" + ((date.Day >= 10) ? date.Day.ToString() : ("0" + date.Day.ToString()));
        }
        private void InsertNewRow(DataRow row, string fieldSang, string fieldChieu)
        {
            try
            {
                DatabaseFB db = HelpDB.getDatabase();
                string sql = string.Format(@"INSERT INTO BANG_CHAM_CONG_64 (ID,EMP_ID,THANG_NAM,{0},{1}) 
                                    VALUES ({2},{3},'{4}','{5}','{6}')"
                                        , fieldSang, fieldChieu, HelpNumber.ParseInt64(row["ID"]), HelpNumber.ParseInt64(row["EMP_ID"])
                                        , row["THANG_NAM"].ToString(), row[fieldSang], row[fieldChieu]);
                DbCommand cmd = db.GetSQLStringCommand(sql);
                db.ExecuteNonQuery(cmd);
            }
            catch
            {

            }
        }
        #endregion

        #region Các hàm tính ngày trong chấm công 64
        private string GetThoiGianLV(object obj) {
            if (string.Compare(obj.ToString(), string.Empty) == 0) return string.Empty;
            string[] s = obj.ToString().Split(':');
            if (s.Length == 1) return s[0].ToString();
            return (decimal.Parse(s[0]) + HelpNumber.RoundDecimal(decimal.Parse(s[1]) / 60,4)).ToString();
        }
        /// <summary>
        /// Tinh so ngay nghi co phep va khong phep tren 1 dong.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public decimal CountRow(DataRow row, object value)
        {
            decimal result = 0;
            for (int i = 3; i <= 64; i++)//3,64: Mac dinh la index cua cac cot ngay trong thang.
            {
                if (string.Compare(row[i].ToString(), value.ToString()) == 0)
                    result++;
            }
            return result;
        }
        /// <summary>
        /// Dem tong so ngay tren 1 dong.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public decimal CountSoNgay(DataRow row)
        {
            decimal result = 0;
            for (int i = 3; i <= 64; i++)
            {
                decimal value = 0;
                if (string.Compare(row[i].ToString(), string.Empty) == 0) continue;
                try
                {
                    value = decimal.Parse(row[i].ToString());

                }
                catch (Exception ex)
                {
                    PLException.AddException(ex);
                }
                //if (er == string.Empty)
                //    result += decimal.Parse(row[i].ToString());
            }
            return result;
        }

        public void DuyetThongKe_TC_HL_KL(DataRow row, DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                long nvID = long.Parse(row["EMP_ID"].ToString());
                ArrayList list = DsDieuChinhLuong(tuNgay, denNgay, nvID);

                decimal TC = 0;
                decimal KL = 0;
                decimal HL = 0;

                //int soNgay = (denNgay - tuNgay).Days;

                //Duyet du lieu tren luoi
                int colNext = 4;
                DateTime cnNgay = tuNgay;
                for (int col = 3; col <= 64; col += 2)
                {
                    Application.DoEvents();
                    if (IsNumber(row[col].ToString()) || IsNumber(row[colNext].ToString()) || Vang(row[col].ToString()) || Vang(row[colNext].ToString()))
                    {

                        for (int i = list.Count - 1; i >= 0; i--)
                        {
                            DataRow r = (DataRow)list[i];

                            if (SoSanhNgay(cnNgay, (DateTime)r["TU_NGAY"]))
                            {
                                if (int.Parse(r["HINH_THUC"].ToString()) == 0 || int.Parse(r["HINH_THUC"].ToString()) == 1)
                                {
                                    HL += Cong(row[col].ToString(), row[colNext].ToString());
                                    HL += Tru(row[col].ToString(), row[colNext].ToString());
                                }
                                else if (int.Parse(r["HINH_THUC"].ToString()) == 2)
                                {
                                    KL += Cong(row[col].ToString(), row[colNext].ToString());
                                    KL += Tru(row[col].ToString(), row[colNext].ToString());
                                }
                                else
                                {
                                    TC += Cong(row[col].ToString(), row[colNext].ToString());
                                    TC += Tru(row[col].ToString(), row[colNext].ToString());
                                }
                                break;
                            }
                        }
                    }
                    colNext += 2;
                    cnNgay.AddDays(1);
                }
                //Thực hiện làm tròn 4 chữ số
                row["SO_NGAY_KHONG_LUONG"] = HelpNumber.RoundDecimal(KL / 8, 4);
                row["SO_NGAY_HUONG_LUONG"] = HelpNumber.RoundDecimal(HL / 8, 4);
                row["SO_NGAY_TRO_CAP"] = HelpNumber.RoundDecimal(TC / 8, 4);

            }
            catch (Exception ex)
            {

                HelpMsgBox.ShowErrorMessage(ex.Message);
            }
        }

        public decimal Tru(string a, string b)
        {
            decimal result = 0;
            if (a == "V")
                result -= 4; //-8 chuyển thành -4
            if (b == "V")
                result -= 4;
            return result;
        }
        private bool Vang(string str)
        {
            if (str == "V")
                return true;
            return false;
        }
        private decimal Cong(string a, string b)
        {
            decimal result = 0;
            if (IsNumber(a))
                result += decimal.Parse(a);
            if (IsNumber(b))
                result += decimal.Parse(b);

            return result;
        }

        private bool IsNumber(string str)
        {
            bool bFlag = true;
            try
            {
                decimal value = Decimal.Parse(str);
            }
            catch (Exception ex)
            {
                bFlag = false;
            }
            return bFlag;
        }

        private bool SoSanhNgay(DateTime NgayTruoc, DateTime NgaySau)
        {
            if (NgayTruoc >= NgaySau)
                return true;
            return false;
        }

        private ArrayList DsDieuChinhLuong(DateTime tuNgay, DateTime denNgay, long nvID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand("select TU_NGAY,HINH_THUC from DIEU_CHINH_LUONG where NV_ID = @NV_ID and (TU_NGAY between @TU_NGAY and @DEN_NGAY ) order by TU_NGAY asc");
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, nvID);
            db.AddInParameter(cmd, "@TU_NGAY", DbType.DateTime, tuNgay);
            db.AddInParameter(cmd, "@DEN_NGAY", DbType.DateTime, denNgay);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "DIEU_CHINH_LUONG");
            ArrayList result = new ArrayList();
            DataRow row;
            if (ds.Tables[0].Rows.Count > 0)
                row = CanDuoiNgay((DateTime)ds.Tables[0].Rows[0]["TU_NGAY"], nvID);
            else
                row = CanDuoiNgay(tuNgay, nvID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (row != null && !NgayBangNgay((DateTime)row["TU_NGAY"], (DateTime)ds.Tables[0].Rows[0]["TU_NGAY"]))
                    result.Add(row);
            }
            else if (row != null)
                result.Add(row);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result.Add(dr);
                }
            }
            return result;
        }
        private DataRow CanDuoiNgay(DateTime ngay, long nvID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand("SELECT TU_NGAY,HINH_THUC FROM DIEU_CHINH_LUONG WHERE NV_ID = @NV_ID AND TU_NGAY < @NGAY ORDER BY TU_NGAY DESC");
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, nvID);
            db.AddInParameter(cmd, "@NGAY", DbType.DateTime, ngay);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "DIEU_CHINH_LUONG");
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0];
            return null;

        }
        private bool NgayBangNgay(DateTime ng1, DateTime ng2)
        {
            if (ng1.Date == ng2.Date)
                return true;
            return false;
        }
        #endregion

    }
}
