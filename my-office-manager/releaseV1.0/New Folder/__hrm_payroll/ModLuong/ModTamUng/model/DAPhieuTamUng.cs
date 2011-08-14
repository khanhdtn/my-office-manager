using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using office;
using System.Data.Common;
using ProtocolVN.Framework.Win;
using LumiSoft.Net.Mime;
using ProtocolVN.DanhMuc;
using ProtocolVN.App.Office;

//CHAUTV :
namespace DAO
{
    #region Database
    //CREATE TABLE PHIEU_TAM_UNG (
    //    ID                    A_BIG_ID NOT NULL /* A_BIG_ID = BIGINT */,
    //    MA_PHIEU              A_STR_SHORT /* A_STR_SHORT = VARCHAR(100) */,
    //    NGUOI_DE_NGHI_ID      A_BIG_ID /* A_BIG_ID = BIGINT */,
    //    NGAY_XIN_TAM_UNG      A_DATE /* A_DATE = DATE */,
    //    BP_ID                 A_BIG_ID /* A_BIG_ID = BIGINT */,
    //    SO_TIEN_XIN_UNG       A_DOUBLE /* A_DOUBLE = NUMERIC(15,2) default 0 */,
    //    SO_TIEN_NHAN          A_DOUBLE /* A_DOUBLE = NUMERIC(15,2) default 0 */,
    //    DA_NHAN_BIT           A_BOOL_NULL /* A_BOOL_NULL = CHAR(1) */,
    //    NGUOI_NHAN_ID         A_BIG_ID /* A_BIG_ID = BIGINT */,
    //    NGAY_NHAN             A_DATE /* A_DATE = DATE */,
    //    GHI_CHU               A_STR_LONG /* A_STR_LONG = VARCHAR(7000) */,
    //    NGUOI_DUYET           A_BIG_ID /* A_BIG_ID = BIGINT */,
    //    NGAY_DUYET            A_DATE /* A_DATE = DATE */,
    //    DUYET                 A_BOOL_NULL /* A_BOOL_NULL = CHAR(1) */,
    //    CHUYEN_DEN_LUONG_BIT  A_BOOL_NULL /* A_BOOL_NULL = CHAR(1) */
    //);
    //ALTER TABLE PHIEU_TAM_UNG ADD CONSTRAINT PK_PHIEU_TAM_UNG PRIMARY KEY (ID);
    #endregion

    #region Fields phiếu tạm ứng
    public class PhieuTamUngFields {
        public static string ID = "ID";
        /// <summary>Mã phiếu phát sinh theo cấu hình phiếu dạng tham số ứng dụng
        /// </summary>
        public static string MA_PHIEU = "MA_PHIEU";

        public static string NGUOI_DE_NGHI_ID = "NGUOI_DE_NGHI_ID";
        public static string NGAY_XIN_TAM_UNG = "NGAY_XIN_TAM_UNG";
        public static string BP_ID = "BP_ID";
        public static string SO_TIEN_XIN_UNG = "SO_TIEN_XIN_UNG";
        public static string LY_DO = "LY_DO";

        public static string SO_TIEN_NHAN = "SO_TIEN_NHAN";
        public static string DA_NHAN_BIT = "DA_NHAN_BIT";
        public static string NGUOI_NHAN_ID = "NGUOI_NHAN_ID";
        public static string NGAY_NHAN = "NGAY_NHAN";
        public static string GHI_CHU = "GHI_CHU";
        
        public static string NGUOI_DUYET = "NGUOI_DUYET";
        public static string NGAY_DUYET = "NGAY_DUYET";
        public static string DUYET = "DUYET";
        public static string CHUYEN_DEN_LUONG_BIT = "CHUYEN_DEN_LUONG_BIT";
        public static string THANG_TAM_UNG = "THANG_TAM_UNG";        
        public static string KET_CHUYEN_TU_LUONG="KET_CHUYEN_TU_LUONG";
    }
    #endregion

    public class DAPhieuTamUng : DAPhieu<DOPhieuTamUng>
    {
        #region Fields
        public static string KEY_FIELD_NAME = PhieuTamUngFields.ID;
        public static string TABLE_MAP = "PHIEU_TAM_UNG";
        private object[] FIELD_MAP = new object[] {  
                PhieuTamUngFields.ID, new IDConverter(),
                PhieuTamUngFields.MA_PHIEU,null,
                PhieuTamUngFields.NGUOI_DE_NGHI_ID,new IDConverter(),
                PhieuTamUngFields.NGAY_XIN_TAM_UNG,null,
                PhieuTamUngFields.BP_ID,null,
                PhieuTamUngFields.SO_TIEN_XIN_UNG,null,
                PhieuTamUngFields.LY_DO,null,
                PhieuTamUngFields.SO_TIEN_NHAN,null,
                PhieuTamUngFields.DA_NHAN_BIT,null,
                PhieuTamUngFields.NGUOI_NHAN_ID,new IDConverter(),
                PhieuTamUngFields.NGAY_NHAN,null,
                PhieuTamUngFields.GHI_CHU,null,
                PhieuTamUngFields.NGUOI_DUYET,new IDConverter(),
                PhieuTamUngFields.NGAY_DUYET,null,
                PhieuTamUngFields.DUYET,null,
                PhieuTamUngFields.CHUYEN_DEN_LUONG_BIT,null,
                PhieuTamUngFields.THANG_TAM_UNG,null,               
                PhieuTamUngFields.KET_CHUYEN_TU_LUONG,null
        };
        public static DAPhieuTamUng I = new DAPhieuTamUng();
        public DAPhieuTamUng():base(){}
        #endregion

        #region Method override
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOPhieuTamUng LoadAll(long IDKey)
        {
            DOPhieuTamUng phieu = this.Load(IDKey);
            phieu.MasterDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            return phieu;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            throw new NotImplementedException();
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
            return DatabaseFB.DeleteRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
        }

        public override DOPhieuTamUng Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOPhieuTamUng data = (DOPhieuTamUng)this.Builder.CreateFilledObjectExt(typeof(DOPhieuTamUng), reader);
                    return data;
                }
            }
            return new DOPhieuTamUng();
        }

        public override bool Update(DOPhieuTamUng data)
        {
            bool flag = false;
            try
            {
                if (data.MasterDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in data.MasterDataSet.Tables[0].Rows)
                    {
                        flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    }
                }
                else
                {
                    DataRow row = data.MasterDataSet.Tables[0].NewRow();
                    data.MasterDataSet.Tables[0].Rows.Add(row);
                    flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                }
                if (flag)
                {
                    try
                    {
                        DataSet dsMain = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.ID);
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, dsMain, data.MasterDataSet);
                        if (data.ID == 0)
                            flag = DatabaseFB.Update2DataSet(PLConst.G_NGHIEP_VU, dsMain, null, true);
                        else
                        {
                            flag = HelpDB.getDatabase().UpdateDataSet(dsMain);
                        }
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

        public override bool Validate(DOPhieuTamUng element)
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region Ext
        public bool ChuyenDenLuong(long ID_TamUng, long NV_ID, string ThangNam, decimal SoTienNhan, DatabaseFB db,DbTransaction dbTrans)
        {                        
            DbCommand cmd = db.GetStoredProcCommand("CHUYEN_TAM_UNG_TOI_LUONG");
            db.AddInParameter(cmd, "@ID_TAM_UNG", DbType.Int64, ID_TamUng);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);                   
            db.AddInParameter(cmd, "@THANG_NAM", DbType.String, ThangNam);
            db.AddInParameter(cmd, "@SO_TIEN_UNG", DbType.Decimal, SoTienNhan);            
            return db.ExecuteScalar(cmd, dbTrans).ToString() == "Y";
        }
        /// <summary>
        /// Kiểm tra tháng xin tạm ứng của nhân viên này đã chốt hay chưa.
        /// </summary>
        /// <param name="NV_ID"></param>
        /// <param name="Thang_nam"></param>
        /// <param name="IsChot"></param>
        /// <returns></returns>
        public string CheckIsChot(long NV_ID, string Thang_nam, string IsChot) {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("CHECK_TAM_UNG_THANG_DA_CHOT");
            db.AddInParameter(cmd, "@T_NAM", DbType.String, Thang_nam);
            db.AddInParameter(cmd, "@CHOT", DbType.String, IsChot);            
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);            
            return db.ExecuteScalar(cmd).ToString();
        }
        public string GetPhieuTamUng()
        {
            return DatabaseFB.getSoPhieu(TABLE_MAP, PhieuTamUngFields.MA_PHIEU, DatabaseFB.GetThamSo("MA_PTU"));
        }        
        public DataTable GetPhieu(long employeeId, string Month){
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM " + TABLE_MAP + " WHERE 1=1");
            query.addID(PhieuTamUngFields.NGUOI_DE_NGHI_ID, employeeId);
            query.add(PhieuTamUngFields.THANG_TAM_UNG, Operator.Equal, Month, DbType.String);
            query.addBoolean(PhieuTamUngFields.CHUYEN_DEN_LUONG_BIT, true);
            query.addCondition(string.Format("{0} IS NULL",PhieuTamUngFields.LY_DO));
            return HelpDB.getDatabase().LoadDataSet(query, TABLE_MAP).Tables[0];
        }
        public static DataRow getEmailNhanVien(long Id)
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from DM_NHAN_VIEN where ID=" + Id);
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0];
            return null;
        }
        public bool _GuiMailTamUng(object Obj,params long[] NguoiNhan) {
            ///1.Nội dung
            string Title = string.Empty;
            StringBuilder Subject = new StringBuilder("");
            long idPhieu = -1;
            if(Obj is DOPhieuTamUng){
                DOPhieuTamUng dataObj = (DOPhieuTamUng)Obj;
                if (dataObj.DUYET == "1")
                    Title = "Có phiếu xin tạm ứng đang chờ duyệt";
                else if(dataObj.DUYET == "3")
                    Title = "Có phiếu xin tạm ứng không được duyệt";
                DOPhieuTamUng Phieu = (DOPhieuTamUng)Obj;
                Subject.Append("<br>Người tạm ứng:&nbsp;" + DMFWNhanVien.GetFullName(Phieu.NGUOI_DE_NGHI_ID) + "<\br>");
                Subject.Append("<br>Ngày đề nghị:&nbsp;&nbsp;&nbsp;&nbsp;" + Phieu.NGAY_XIN_TAM_UNG.ToString() + "<\br>");
                Subject.Append("<br>Tạm ứng tháng:&nbsp;" + Phieu.THANG_TAM_UNG + "<\br>");
                Subject.Append("<br>Số tiền:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Phieu.SO_TIEN_XIN_UNG.ToString("#,###") + " (" + DecimalToString(Phieu.SO_TIEN_XIN_UNG) + ")<\br>");
                if (Phieu.LY_DO != null && Phieu.LY_DO.Length > 0)
                    Subject.Append("<br>Lý do:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + Phieu.LY_DO + "<\br>");
                else
                    Subject.Append("<br>Lý do:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tạm ứng lương<\br>");
                idPhieu = dataObj.ID;
            }
            else
            {
                
                DataRow row = (DataRow)Obj;
                if (row["DUYET"].ToString() == "2") Title = "Có phiếu xin tạm ứng không được duyệt";
                else if (row["DUYET"].ToString() == "3") Title = "Có phiếu xin tạm ứng được duyệt";
                Subject.Append("<br>Người tạm ứng:&nbsp;" + DMFWNhanVien.GetFullName(row[PhieuTamUngFields.NGUOI_DE_NGHI_ID]) + "<\br>");
                Subject.Append("<br>Ngày đề nghị:&nbsp;&nbsp;&nbsp;&nbsp;" + row[PhieuTamUngFields.NGAY_XIN_TAM_UNG].ToString() + "<\br>");
                Subject.Append("<br>Tạm ứng tháng:&nbsp;" + row[PhieuTamUngFields.THANG_TAM_UNG].ToString() + "<\br>");
                Subject.Append("<br>Số tiền:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + HelpNumber.ParseDecimal(row[PhieuTamUngFields.SO_TIEN_XIN_UNG]).ToString("#,###") + "<\br>");
                if (row[PhieuTamUngFields.LY_DO] != null && row[PhieuTamUngFields.LY_DO].ToString().Length > 0)
                    Subject.Append("<br>Lý do:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + row[PhieuTamUngFields.LY_DO].ToString() + "<\br>");
                else
                    Subject.Append("<br>Lý do:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tạm ứng lương<\br>");
                Subject.Append("<br>Người duyệt:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + DMFWNhanVien.GetFullName(FrameworkParams.currentUser.employee_id) + "<\br>");
                idPhieu = HelpNumber.ParseInt64(row["ID"]);
            }           
            ///2.Thông tin người nhận && CC
            AddressList To = HelpZPLOEmail.GetAddressList(NguoiNhan);
            Title = HelpStringBuilder.GetTitleMailNewPageper(Title);
            ///3.Gửi mail
            return HelpZPLOEmail.SendSmartHost(HelpAutoOpenForm.GeneratingCodeFromForm(typeof(frmPhieuTamUng).FullName,
                idPhieu),
            Title, null, To, null, null, Subject.ToString(), "");
        }

        public bool UpdatePhieuDuyet(long employeeId, string Month)
        {
            string cmdText = string.Format(@"UPDATE {0} 
                SET {1}='Y' 
                WHERE {2}={3} AND {4}='{5}' AND {6}='{7}' AND 1=1", TABLE_MAP,
                PhieuTamUngFields.CHUYEN_DEN_LUONG_BIT,
                PhieuTamUngFields.NGUOI_DE_NGHI_ID, employeeId, PhieuTamUngFields.THANG_TAM_UNG, Month, PhieuTamUngFields.DUYET, ((Int32)DuyetSupportStatus.Duyet));
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(cmdText);            
            return (db.ExecuteNonQuery(cmd) >= 0);
        }

        public static string DecimalToString(decimal Value)
        {
            if (Value <= 99999999999999)
            {
                StringBuilder Str = new StringBuilder(HelpNumber.DecimalNumberToString(Value));
                return Str.ToString().Substring(0, 1).ToUpper() + Str.ToString().Substring(1) + " đồng.";
            }
            else
                return "";
        }
        #endregion
    }

}
