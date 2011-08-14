using System;
using System.Collections.Generic;
using DTO;
using System.Data.Common;
using System.Data;
using pl.office;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Text;
using pl.office.Report;


namespace DAO
{
    public class DAResume
    {
        public static bool Insert(DOResume dto)
        {
            string sql = "";
            if (dto.NGAY_SINH != null)
                sql = "Insert into RESUME" +
                            "(ID,MA_HO_SO,HO_TEN,DIA_CHI,DIEN_THOAI,EMAIL,GIOI_TINH,TRINH_DO_CHUYEN_MON,QUA_TRINH_CONG_TAC,QUA_TRINH_DAO_TAO,TINH_TRANG_HON_NHAN,LUONG_MONG_DOI,TRINH_DO_NGOAI_NGU,THONG_TIN_KHAC,NGAY_CAP_NHAT_HO_SO,LOAI_HO_SO,NGAY_SINH,TTHS_ID) " +
                            "values" +
                            "(@ID,@MA_HO_SO,@TEN,@DIA_CHI,@DIEN_THOAI,@EMAIL,@GIOI_TINH,@TRINH_DO_CHUYEN_MON,@QUA_TRINH_CONG_TAC,@QUA_TRINH_DAO_TAO,@TINH_TRANG_HON_NHAN,@LUONG_MONG_DOI,@TRINH_DO_NGOAI_NGU,@THONG_TIN_KHAC,@NGAY_CAP_NHAT_HO_SO,@LOAI_HO_SO,@NGAY_SINH,@TINH_TRANG_HO_SO)";
            else
                sql = "Insert into RESUME" +
                            "(ID,MA_HO_SO,HO_TEN,DIA_CHI,DIEN_THOAI,EMAIL,GIOI_TINH,TRINH_DO_CHUYEN_MON,QUA_TRINH_CONG_TAC,QUA_TRINH_DAO_TAO,TINH_TRANG_HON_NHAN,LUONG_MONG_DOI,TRINH_DO_NGOAI_NGU,THONG_TIN_KHAC,NGAY_CAP_NHAT_HO_SO,LOAI_HO_SO,TTHS_ID) " +
                            "values" +
                            "(@ID,@MA_HO_SO,@TEN,@DIA_CHI,@DIEN_THOAI,@EMAIL,@GIOI_TINH,@TRINH_DO_CHUYEN_MON,@QUA_TRINH_CONG_TAC,@QUA_TRINH_DAO_TAO,@TINH_TRANG_HON_NHAN,@LUONG_MONG_DOI,@TRINH_DO_NGOAI_NGU,@THONG_TIN_KHAC,@NGAY_CAP_NHAT_HO_SO,@LOAI_HO_SO,@TINH_TRANG_HO_SO)";

            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, dto.ID);
            db.AddInParameter(cmd, "@MA_HO_SO", DbType.String, dto.MA_HO_SO);
            db.AddInParameter(cmd, "@TEN", DbType.String, PLHeplString.PLHelpFortmatName(dto.TEN));
            db.AddInParameter(cmd, "@DIA_CHI", DbType.String, dto.DIA_CHI);
            db.AddInParameter(cmd, "@DIEN_THOAI", DbType.String, dto.DIEN_THOAI);
            db.AddInParameter(cmd, "@EMAIL", DbType.String, dto.EMAIL);
            db.AddInParameter(cmd, "@GIOI_TINH", DbType.String, dto.GIOI_TINH);
            db.AddInParameter(cmd, "@TRINH_DO_CHUYEN_MON", DbType.Binary, HelpByte.UTF8StringToBytes(dto.TRINH_DO_CHUYEN_MON));
            db.AddInParameter(cmd, "@QUA_TRINH_CONG_TAC", DbType.Binary, HelpByte.UTF8StringToBytes(dto.QUA_TRINH_CONG_TAC));
            db.AddInParameter(cmd, "@QUA_TRINH_DAO_TAO", DbType.Binary, HelpByte.UTF8StringToBytes(dto.QUA_TRINH_DAO_TAO));
            db.AddInParameter(cmd, "@TINH_TRANG_HON_NHAN", DbType.String, dto.TINH_TRANG_HON_NHAN);
            db.AddInParameter(cmd, "@LUONG_MONG_DOI", DbType.String, dto.LUONG_MONG_DOI);
            db.AddInParameter(cmd, "@TRINH_DO_NGOAI_NGU", DbType.Binary, HelpByte.UTF8StringToBytes(dto.TRINH_DO_NGOAI_NGU));
            db.AddInParameter(cmd, "@THONG_TIN_KHAC", DbType.Binary, HelpByte.UTF8StringToBytes(dto.THONG_TIN_KHAC));
            db.AddInParameter(cmd, "@NGAY_CAP_NHAT_HO_SO", DbType.DateTime, dto.NGAY_CAP_NHAT_HO_SO);
            db.AddInParameter(cmd, "@LOAI_HO_SO", DbType.String, dto.LOAI_HO_SO);
            if (dto.TINH_TRANG_HO_SO != -1)
                db.AddInParameter(cmd, "@TINH_TRANG_HO_SO", DbType.Int64, dto.TINH_TRANG_HO_SO);
            else
                db.AddInParameter(cmd, "@TINH_TRANG_HO_SO", DbType.Int64, DBNull.Value);
            if (dto.NGAY_SINH != null)
                db.AddInParameter(cmd, "@NGAY_SINH", DbType.DateTime, dto.NGAY_SINH);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }

        public static bool Delete(long ID)
        {
           
            DAUngTuyen.Delete(ID);
            DAHenPhongVan.Delete(ID);
            string sql = "delete from RESUME where ID = @ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            int iCmd = db.ExecuteNonQuery(cmd);
            if (iCmd > 0)
                return true;
            return false;
        }
        public static long getTinhTrangHoSo(long ID)
        {
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand("select TTHS_ID from RESUME where ID = @ID");
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count == 0 || ds.Tables[0].Rows[0]["TTHS_ID"].ToString() == string.Empty)
                return -1;
            return (long)ds.Tables[0].Rows[0]["TTHS_ID"];
        }
                
        public static bool Update(long ID, long TTHS_ID,DateTime NgayCapNhat)
        {
            string sql = "update RESUME set TTHS_ID = @TINH_TRANG_HO_SO , NGAY_CAP_NHAT_HO_SO = @NCN where ID = @ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            db.AddInParameter(cmd, "@NCN", DbType.DateTime, NgayCapNhat);
            if(TTHS_ID!=-1)
                db.AddInParameter(cmd, "@TINH_TRANG_HO_SO", DbType.Int64, TTHS_ID);
            else
                db.AddInParameter(cmd, "@TINH_TRANG_HO_SO", DbType.Int64, DBNull.Value);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        public static bool Update(DOResume dto)
        {
            string sql = "update RESUME set " +
                        "MA_HO_SO=@MA_HO_SO,HO_TEN = @HO_TEN," +
                        "NGAY_SINH = @NGAY_SINH," +
                        "DIA_CHI = @DIA_CHI," +
                        "DIEN_THOAI = @DIEN_THOAI," +
                        "EMAIL = @EMAIL," +
                        "GIOI_TINH = @GIOI_TINH," +
                        "TRINH_DO_CHUYEN_MON = @TRINH_DO_CHUYEN_MON," +
                        "QUA_TRINH_CONG_TAC = @QUA_TRINH_CONG_TAC," +
                        "QUA_TRINH_DAO_TAO = @QUA_TRINH_DAO_TAO," +
                        "TINH_TRANG_HON_NHAN = @TINH_TRANG_HON_NHAN," +
                        "LUONG_MONG_DOI = @LUONG_MONG_DOI," +
                        "TRINH_DO_NGOAI_NGU = @TRINH_DO_NGOAI_NGU," +
                        "THONG_TIN_KHAC = @THONG_TIN_KHAC," +
                        "NGAY_CAP_NHAT_HO_SO = @NGAY_CAP_NHAT_HO_SO, " +
                        "LOAI_HO_SO = @LOAI_HO_SO, " +
                        "TTHS_ID = @TINH_TRANG_HO_SO " +
                        "where ID = @ID ";

            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, dto.ID);
            db.AddInParameter(cmd, "@MA_HO_SO", DbType.String, dto.MA_HO_SO);
            db.AddInParameter(cmd, "@HO_TEN", DbType.String, PLHeplString.PLHelpFortmatName(dto.TEN));
            if (dto.NGAY_SINH != null)
                db.AddInParameter(cmd, "@NGAY_SINH", DbType.DateTime, dto.NGAY_SINH);
            else
                db.AddInParameter(cmd, "@NGAY_SINH", DbType.DateTime, DBNull.Value);
            db.AddInParameter(cmd, "@DIA_CHI", DbType.String, dto.DIA_CHI);
            db.AddInParameter(cmd, "@DIEN_THOAI", DbType.String, dto.DIEN_THOAI);
            db.AddInParameter(cmd, "@EMAIL", DbType.String, dto.EMAIL);
            db.AddInParameter(cmd, "@GIOI_TINH", DbType.String, dto.GIOI_TINH);
            db.AddInParameter(cmd, "@TRINH_DO_CHUYEN_MON", DbType.Binary, HelpByte.UTF8StringToBytes(dto.TRINH_DO_CHUYEN_MON));
            db.AddInParameter(cmd, "@QUA_TRINH_CONG_TAC", DbType.Binary, HelpByte.UTF8StringToBytes(dto.QUA_TRINH_CONG_TAC));
            db.AddInParameter(cmd, "@QUA_TRINH_DAO_TAO", DbType.Binary, HelpByte.UTF8StringToBytes(dto.QUA_TRINH_DAO_TAO));
            db.AddInParameter(cmd, "@TINH_TRANG_HON_NHAN", DbType.String, dto.TINH_TRANG_HON_NHAN);
            db.AddInParameter(cmd, "@LUONG_MONG_DOI", DbType.String, dto.LUONG_MONG_DOI);
            db.AddInParameter(cmd, "@TRINH_DO_NGOAI_NGU", DbType.Binary, HelpByte.UTF8StringToBytes(dto.TRINH_DO_NGOAI_NGU));
            db.AddInParameter(cmd, "@THONG_TIN_KHAC", DbType.Binary, HelpByte.UTF8StringToBytes(dto.THONG_TIN_KHAC));
            db.AddInParameter(cmd, "@NGAY_CAP_NHAT_HO_SO", DbType.DateTime, dto.NGAY_CAP_NHAT_HO_SO);
            db.AddInParameter(cmd, "@LOAI_HO_SO", DbType.String, dto.LOAI_HO_SO);
            if (dto.TINH_TRANG_HO_SO != -1)
                db.AddInParameter(cmd, "@TINH_TRANG_HO_SO", DbType.Int64, dto.TINH_TRANG_HO_SO);
            else
                db.AddInParameter(cmd, "@TINH_TRANG_HO_SO", DbType.Int64, DBNull.Value);
            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }
        
        public static string getNameUngVien(long ID)
        {
            string sql = "select * from RESUME where ID = @ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count == 0)
                return "";
            return ds.Tables[0].Rows[0]["HO_TEN"].ToString();


        }
        public static DOResume getUngVien(long ID)
        {
            string sql = "select * from RESUME where ID = @ID";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count == 0)
                return null;
            DateTime? NgaySinh = null;
            if (ds.Tables[0].Rows[0]["NGAY_SINH"].ToString().Length > 0)
                NgaySinh = (DateTime)ds.Tables[0].Rows[0]["NGAY_SINH"];
            DOResume DR = new DOResume();
            DR.ID=long.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
            DR.MA_HO_SO = ds.Tables[0].Rows[0]["MA_HO_SO"].ToString();
            DR.TEN= PLHeplString.PLHelpFortmatName(ds.Tables[0].Rows[0]["HO_TEN"].ToString());
            DR.NGAY_SINH= NgaySinh;
            DR.DIA_CHI=ds.Tables[0].Rows[0]["DIA_CHI"].ToString();
            DR.DIEN_THOAI=ds.Tables[0].Rows[0]["DIEN_THOAI"].ToString();
            DR.EMAIL=ds.Tables[0].Rows[0]["EMAIL"].ToString();
            DR.GIOI_TINH=ds.Tables[0].Rows[0]["GIOI_TINH"].ToString();
            if (ds.Tables[0].Rows[0]["TRINH_DO_CHUYEN_MON"].ToString() != "")
                DR.TRINH_DO_CHUYEN_MON = HelpByte.BytesToUTF8String((Byte[])ds.Tables[0].Rows[0]["TRINH_DO_CHUYEN_MON"]);
            if (ds.Tables[0].Rows[0]["QUA_TRINH_CONG_TAC"].ToString() != "")
                DR.QUA_TRINH_CONG_TAC = HelpByte.BytesToUTF8String((Byte[])ds.Tables[0].Rows[0]["QUA_TRINH_CONG_TAC"]);
            if (ds.Tables[0].Rows[0]["QUA_TRINH_DAO_TAO"].ToString() != "")
                DR.QUA_TRINH_DAO_TAO = HelpByte.BytesToUTF8String((Byte[])ds.Tables[0].Rows[0]["QUA_TRINH_DAO_TAO"]);
            DR.TINH_TRANG_HON_NHAN=ds.Tables[0].Rows[0]["TINH_TRANG_HON_NHAN"].ToString();
            DR.LUONG_MONG_DOI=ds.Tables[0].Rows[0]["LUONG_MONG_DOI"].ToString();
            if (ds.Tables[0].Rows[0]["TRINH_DO_NGOAI_NGU"].ToString() != "")
                DR.TRINH_DO_NGOAI_NGU = HelpByte.BytesToUTF8String((Byte[])ds.Tables[0].Rows[0]["TRINH_DO_NGOAI_NGU"]);
            if (ds.Tables[0].Rows[0]["THONG_TIN_KHAC"].ToString() != "")
                DR.THONG_TIN_KHAC = HelpByte.BytesToUTF8String((Byte[])ds.Tables[0].Rows[0]["THONG_TIN_KHAC"]);
            DR.NGAY_CAP_NHAT_HO_SO=(DateTime)ds.Tables[0].Rows[0]["NGAY_CAP_NHAT_HO_SO"];
            DR.LOAI_HO_SO=(ds.Tables[0].Rows[0]["LOAI_HO_SO"].ToString().Length > 0) ? ds.Tables[0].Rows[0]["LOAI_HO_SO"].ToString() : "-1";
            DR.TINH_TRANG_HO_SO=(ds.Tables[0].Rows[0]["TTHS_ID"].ToString().Trim().Length > 0) ? long.Parse(ds.Tables[0].Rows[0]["TTHS_ID"].ToString()) : -1;
            return DR;
        }

        public static DataTable ThongKe(
            string MA_PHIEU,
            string I_HO_TEN,
            string I_EMAIL,
            string I_GIOI_TINH,
            int I_NAM_SINH_TU,
            int I_NAM_SINH_DEN,
            int I_DOT_TUYEN_DUNG_ID,
            long I_TINH_TRANG_HO_SO_ID,
            string I_VI_TRI_UNG_TUYEN_LIST_ID,
            string I_LOAI_HO_SO
        )
        {
            DataSet ds = new DataSet();
            DatabaseFB fb = DABase.getDatabase();
            DbCommand cmd = fb.GetStoredProcCommand("ST_FORM_UNGVIEN_N");
            fb.AddInParameter(cmd, "@I_HO_TEN", DbType.String, PLHeplString.PLHelpFortmatName(I_HO_TEN));
            fb.AddInParameter(cmd, "@I_MAPHIEU", DbType.String,MA_PHIEU);
            fb.AddInParameter(cmd, "@I_EMAIL", DbType.String, I_EMAIL.Trim());
            fb.AddInParameter(cmd, "@I_GIOI_TINH", DbType.String, I_GIOI_TINH);
            fb.AddInParameter(cmd, "@I_NAM_SINH_TU", DbType.String, I_NAM_SINH_TU);
            fb.AddInParameter(cmd, "@I_NAM_SINH_DEN", DbType.String, I_NAM_SINH_DEN);
            fb.AddInParameter(cmd, "@I_DOT_TUYEN_DUNG_ID", DbType.String, I_DOT_TUYEN_DUNG_ID);
            fb.AddInParameter(cmd, "@I_TINH_TRANG_HO_SO_ID", DbType.Int32, I_TINH_TRANG_HO_SO_ID);
            fb.AddInParameter(cmd, "@I_VI_TRI_UNG_TUYEN_LIST_ID", DbType.String, I_VI_TRI_UNG_TUYEN_LIST_ID);
            fb.AddInParameter(cmd, "@I_LOAI_HO_SO", DbType.String, I_LOAI_HO_SO);
            fb.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count >= 0)
                return ds.Tables[0];
            return null;
        }
        public static DataTable GuiThuPhongVan(List<object> ids)
        {
            DataSet ds = new DataSet();
            string sql = "select * from RESUME where ID in (";
            for (int i = 0; i < ids.Count; i++)
            {
                sql += ids[i].ToString();
                if (i < ids.Count - 1)
                    sql += ",";
            }
            sql += ")";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "AA");
            return ds.Tables[0];
        }
        public static List<DOResume> GuiThuChonPhongVan(List<object> ids)
        {
            List<DOResume> Kq = new List<DOResume>();
            DataSet ds = new DataSet();
            string sql = "select * from RESUME where ID in (";
            for (int i = 0; i < ids.Count; i++)
            {
                sql += ids[i].ToString();
                if (i < ids.Count - 1)
                    sql += ",";
            }
            sql += ")";
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.LoadDataSet(cmd, ds, "AA");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    DateTime? NgaySinh = null;
                    if(ds.Tables[0].Rows[row]["NGAY_SINH"].ToString().Length >0)
                        NgaySinh = (DateTime?)ds.Tables[0].Rows[row]["NGAY_SINH"] ;
                    DOResume Resume = new DOResume(HelpNumber.ParseInt64(ds.Tables[0].Rows[row]["ID"]),
                       ds.Tables[0].Rows[row]["MA_HO_SO"].ToString(),
                       ds.Tables[0].Rows[row]["HO_TEN"].ToString(),
                       NgaySinh    ,
                       ds.Tables[0].Rows[row]["DIA_CHI"].ToString(),
                       ds.Tables[0].Rows[row]["DIEN_THOAI"].ToString(),
                       ds.Tables[0].Rows[row]["EMAIL"].ToString(),
                       ds.Tables[0].Rows[row]["GIOI_TINH"].ToString(),
                       HelpByte.BytesToUTF8String((byte[])ds.Tables[0].Rows[row]["TRINH_DO_CHUYEN_MON"]),
                       HelpByte.BytesToUTF8String((byte[])ds.Tables[0].Rows[row]["QUA_TRINH_CONG_TAC"]),
                       HelpByte.BytesToUTF8String((byte[])ds.Tables[0].Rows[row]["QUA_TRINH_DAO_TAO"]),
                       ds.Tables[0].Rows[row]["TINH_TRANG_HON_NHAN"].ToString(),
                       ds.Tables[0].Rows[row]["LUONG_MONG_DOI"].ToString(),
                       HelpByte.BytesToUTF8String((byte[])ds.Tables[0].Rows[row]["TRINH_DO_NGOAI_NGU"]),
                       HelpByte.BytesToUTF8String((byte[])ds.Tables[0].Rows[row]["THONG_TIN_KHAC"]),
                       (DateTime)ds.Tables[0].Rows[row]["NGAY_CAP_NHAT_HO_SO"],
                       ds.Tables[0].Rows[row]["LOAI_HO_SO"].ToString(),
                       long.Parse(ds.Tables[0].Rows[row]["TTHS_ID"].ToString())
                   );
                    Kq.Add(Resume);
                }
            }
            return Kq;
        }

        public static void ThongTinResume(WebBrowser Output, string filename, DOResume TTUngVien)
        {
            try
            {
                StreamReader strr = new StreamReader(filename);
                string str = strr.ReadToEnd();
                str =
                    str.Replace("%NgayThucHien%",
                                TTUngVien.NGAY_CAP_NHAT_HO_SO.Day + "/" + TTUngVien.NGAY_CAP_NHAT_HO_SO.Month + "/" +
                                TTUngVien.NGAY_CAP_NHAT_HO_SO.Year);
                str = str.Replace("%HoTen%", PLHeplString.PLHelpFortmatName(TTUngVien.TEN));
                str = str.Replace("%GioiTinh%", (TTUngVien.GIOI_TINH == "Y") ? "Nam" : "Nữ");
                str =
                    str.Replace("%NgaySinh%", (TTUngVien.NGAY_SINH != null) ?
                    TTUngVien.NGAY_SINH.Value.Day + "/" + TTUngVien.NGAY_SINH.Value.Month + "/" + TTUngVien.NGAY_SINH.Value.Year : "");
                str = str.Replace("%DiaChi%", TTUngVien.DIA_CHI);
                string TinhTrangHonNhan = "Không rõ";
                if (TTUngVien.TINH_TRANG_HON_NHAN == "0") TinhTrangHonNhan = "Độc thân";
                else if (TTUngVien.TINH_TRANG_HON_NHAN == "1") TinhTrangHonNhan = "Kết hôn";
                str = str.Replace("%TinhTrangHonNhan%", TinhTrangHonNhan);
                str = str.Replace("%DienThoai%", TTUngVien.DIEN_THOAI);
                str = str.Replace("%Email%", TTUngVien.EMAIL);
                str = str.Replace("%LuongMongDoi%", TTUngVien.LUONG_MONG_DOI.ToString());
                str = str.Replace("%QuaTrinhDaoTao%", TTUngVien.QUA_TRINH_DAO_TAO);
                str = str.Replace("%QuaTrinhCongTac%", TTUngVien.QUA_TRINH_CONG_TAC);
                str = str.Replace("%TrinhDoChuyenMon%", TTUngVien.TRINH_DO_CHUYEN_MON);
                str = str.Replace("%TrinhDoNgoaiNgu%", TTUngVien.TRINH_DO_NGOAI_NGU);
                str = str.Replace("%ThongTinKhac%", TTUngVien.THONG_TIN_KHAC);
                str = str.Replace("%ViTriUngTuyen%", DAViTriUngTuyen.DanhSachVTUT(TTUngVien.ID));
                Output.DocumentText = str;
                strr.Close();
                

            }
            catch (Exception ex)
            {
                PLMessageBox.ShowErrorMessage(ex.Message);

            }
        }
        #region Report
        public static _Print GetPrintObj(XtraForm frmMain, long IDs)
        {
            _Print print = new _Print();
            DataSet Resume = PLReport.GetThongTinUV(IDs);
            DataTable Resume_Ung_Tuyen = DABase.getDatabase().LoadDataSet(
                @"SELECT REUT.R_ID,REUT.VTUT_ID,NAME FROM RESUME_UNG_TUYEN REUT INNER JOIN DM_VI_TRI_UNG_TUYEN VT ON REUT.VTUT_ID=VT.ID
                    WHERE REUT.R_ID=" + IDs).Tables[0];
            StringBuilder Str = new StringBuilder("");
            foreach (DataRow row in Resume_Ung_Tuyen.Rows)
                Str.Append(row["NAME"].ToString() + ",");
            if (Str.Length > 0) Str.Remove(Str.Length - 1, 1);
            Resume.Tables[0].Rows[0]["VT_TUYEN_DUNG"] = Str.ToString();            
            foreach (DataRow dr in Resume.Tables[0].Rows)
            {                
                dr.BeginEdit();
                dr["QTDT"] = HelpByte.BytesToUTF8String((byte[])dr["QUA_TRINH_DAO_TAO"]);
                dr["QTCT"] = HelpByte.BytesToUTF8String((byte[])dr["QUA_TRINH_CONG_TAC"]);
                dr["TTCM"] = HelpByte.BytesToUTF8String((byte[])dr["TRINH_DO_CHUYEN_MON"]);
                dr["TTNN"] = HelpByte.BytesToUTF8String((byte[])dr["TRINH_DO_NGOAI_NGU"]);               
                dr.EndEdit();
            }
            print.ReportNameFile = "EMB" + typeof(InThongTinUngVienForm).FullName;
            print.MainForm = frmMain;
            print.MainDataset = Resume;
            print.SubDataset = new DataSet[] { PLReport.HeaderDataSet() };            
            return print;
        }     
        #endregion

    }

}
