using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using office;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
/*
 * Author : Trần Văn Châu
 * Email : chautv@protocolvn.net
 */
namespace DAO
{
    public class DABangLuong : DAPhieu<DOBangLuong>
    {
        #region Fields
        public static string KEY_FIELD_NAME = "ID";
        public static string TABLE_MAP = "BANG_LUONG";
        private object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),
                "NV_ID",new IDConverter(),
                "THANG_NAM",null,
                "TONG_THU_NHAP",null,
                "TAM_UNG",null,
                "IS_CHOT",null,
                "DA_THANH_TOAN",null,
                "TT_CON_LAI",null,
                "IS_KET_CHUYEN",null
        };
        public static DABangLuong Instance = new DABangLuong();
        private DABangLuong() : base() { }
        #endregion

        #region Method override
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            throw new NotImplementedException();
        }

        public override DOBangLuong LoadAll(long IDKey)
        {
            DOBangLuong phieu = this.Load(IDKey);
            phieu.DetailDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            phieu.DetailDataSet.Tables[0].TableName = TABLE_MAP;
            return phieu;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, Detail, Grid);
            return HelpDB.getDatabase().UpdateTable(Detail, TABLE_MAP) > 0;
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

        public override DOBangLuong Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOBangLuong data = (DOBangLuong)this.Builder.CreateFilledObjectExt(typeof(DOBangLuong), reader);

                    return data;
                }
            }
            return new DOBangLuong();
        }

        public override bool Update(DOBangLuong data)
        {
            bool flag = false;
            try
            {
                if (data.DetailDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in data.DetailDataSet.Tables[0].Rows)
                    {
                        flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    }
                }
                else
                {
                    DataRow row = data.DetailDataSet.Tables[0].NewRow();
                    //data.ID = PLDBUtil.GetGenIDNghiepVu();
                    //row["ID"] = data.ID;
                    data.DetailDataSet.Tables[0].Rows.Add(row);
                    flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                }
                if (flag)
                {
                    try
                    {
                        DataSet dsMain = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.ID);
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, dsMain, data.DetailDataSet);
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

        public override bool Validate(DOBangLuong element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Others

        public bool MergeDataSet(DataSet forDB, DOBangLuong data)
        {
            bool flag = false;
            try
            {
                if (data.DetailDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in data.DetailDataSet.Tables[0].Rows)
                    {
                        flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    }
                }
                else
                {
                    DataRow row = data.DetailDataSet.Tables[0].NewRow();
                    data.ID = HelpDB.getDatabase().GetID(PLConst.G_NGHIEP_VU);
                    row[KEY_FIELD_NAME] = data.ID;
                    flag = HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
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

        public DOBangLuong Load(long IDKeyNV, string Month)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(@"
                SELECT * 
                FROM " + TABLE_MAP + @" 
                WHERE NV_ID = @NV_ID AND THANG_NAM = @THANG_NAM AND 1=1"
            );
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, IDKeyNV);
            db.AddInParameter(cmd, "@THANG_NAM", DbType.String, Month);
            IDataReader reader = db.ExecuteReader(cmd);
            using (reader)
            {
                if (reader.Read())
                {
                    DOBangLuong data = (DOBangLuong)this.Builder.CreateFilledObjectExt(typeof(DOBangLuong), reader);
                    return data;
                }
            }
            return new DOBangLuong();
        }

        public DOBangLuong LoadAll(long IDKeyNV, string Month)
        {

            DOBangLuong phieu = this.Load(IDKeyNV, Month);
            DatabaseFB db = HelpDB.getDatabase();
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM " + TABLE_MAP + @" WHERE 1=1");
            query.add("NV_ID", Operator.Equal, IDKeyNV, DbType.Int64);
            query.add("THANG_NAM", Operator.Equal, Month, DbType.String);
            phieu.DetailDataSet = db.LoadDataSet(query);
            phieu.DetailDataSet.Tables[0].TableName = TABLE_MAP;
            return phieu;
        }

        //Lấy danh sách nhân viên trong bảng chấm công tự động ra
        public DataSet GetEmployeeChamCongAuto(string Month) {
            string[] M = Month.Split('/');
            int mm = HelpNumber.ParseInt32(M[0]);
            int yy = HelpNumber.ParseInt32(M[1]);
            QueryBuilder query = new QueryBuilder(@"SELECT NV_ID FROM " + DAChamCongAuto.TABLE_MAP + " WHERE 1=1");
            query.addDateFromTo("NGAY", HelpDate.GetStartOfMonth(mm, yy), HelpDate.GetEndOfMonth(mm, yy));
            query.addGroupBy("NV_ID");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query, DAChamCongAuto.TABLE_MAP);
            return ds;
        }

        //Lấy số tiền tạm ứng của nhân viên + tháng tạm ứng
        public decimal GetSoTienTamUng(long employeeId, string Month) {
            QueryBuilder query = new QueryBuilder(@"SELECT SUM(" + PhieuTamUngFields.SO_TIEN_XIN_UNG + ") as SO_TIEN FROM " + DAPhieuTamUng.TABLE_MAP + " WHERE 1=1");
            query.addID(PhieuTamUngFields.NGUOI_DE_NGHI_ID , employeeId);
            query.add(PhieuTamUngFields.THANG_TAM_UNG, Operator.Equal, Month, DbType.String);
            query.add(PhieuTamUngFields.DUYET, Operator.Equal,((Int32)DuyetSupportStatus.Duyet).ToString(), DbType.String);
            query.addCondition(string.Format("{0} IS NULL", PhieuTamUngFields.LY_DO));
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query, DAPhieuTamUng.TABLE_MAP);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count == 1)
                return HelpNumber.ParseDecimal(ds.Tables[0].Rows[0]["SO_TIEN"]);
            return 0;
        }

        /// <summary>Lấy tổng thu nhập của nhân viên trong tháng
        /// </summary>
        public decimal GetTongThuNhap(long employeeId, string Month) {
            return 0;
        }

        public bool FChotLuong(string Month, bool IsChot)
        {
            string cmdUpdate = "UPDATE BANG_LUONG SET IS_CHOT=" + ((IsChot == true) ? "'Y'" : "'N'") 
                             + " WHERE THANG_NAM='" + Month + "'";
            DatabaseFB fb = HelpDB.getDatabase();
            DbCommand cmd = fb.GetSQLStringCommand(cmdUpdate);
            int update = fb.ExecuteNonQuery(cmd);
            return (update >= 0);
        }
        /// <summary>
        /// Update cột "IS_KET_CHUYEN" trong trường hợp kết chuyển tạm ứng.
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool UpdateIsKetChuyenTamUng(DataRow row)
        {
            DatabaseFB fb = HelpDB.getDatabase();
            string Sql = string.Format(@"UPDATE BANG_LUONG 
                                         SET IS_KET_CHUYEN='Y',
                                             TT_CON_LAI=0,
                                             KET_CHUYEN_TAM_UNG=@KET_CHUYEN_TAM_UNG
                                         WHERE ID=@ID");
            DbCommand cmd = fb.GetSQLStringCommand(Sql);
            fb.AddInParameter(cmd,"@KET_CHUYEN_TAM_UNG",DbType.Decimal,Math.Abs(HelpNumber.ParseDecimal(row["TT_CON_LAI"])));          
            fb.AddInParameter(cmd,"@ID",DbType.Int64,HelpNumber.ParseInt64(row["ID"]));
            return fb.ExecuteNonQuery(cmd) >= 0;
        }

        public void ChonThangLuong(ImageComboBoxEdit Input, bool? status)
        {
            QueryBuilder query = null;
            string strWhereAdd = "";
            if (status == true) strWhereAdd = " (is_chot ='N' or is_chot = '') and 1=1";
            else if (status == false) strWhereAdd = " is_chot='Y' and 1=1";
            else strWhereAdd = " 1=1";

            query = new QueryBuilder("select thang_nam, right(thang_nam,4) as nam , is_chot from bang_luong where " + strWhereAdd);
            query.setDescOrderBy("THANG_NAM");
            query.addGroupBy("THANG_NAM,IS_CHOT");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);

            DataTable Kq = new XLSortThangNam().Sort(ds.Tables[0]);
            Input.Properties.Items.Clear();
            Input.Properties.Items.Add(new ImageComboBoxItem("", "-1"));
            foreach (DataRow row in Kq.Rows)
            {
                Input.Properties.Items.Add(new ImageComboBoxItem(row["THANG_NAM"].ToString(), row["THANG_NAM"]));
            }
        }
        #endregion

    }

    public class ThangNam
    {
        public int mm;
        public int yy;
        public string chot;
        public ThangNam(int t, int n, string chot) { mm = t; yy = n; this.chot = chot; }
    }

    public class XLSortThangNam
    {
        private ThangNam[] dsThangNam = null;
        private void HoanVi(ref ThangNam a, ref ThangNam b)
        {
            ThangNam temp = a;
            a = b;
            b = temp;
        }

        public DataTable Sort(DataTable tb1)
        {
            //Tao danh sach
            DataTable tb = tb1.Copy();
            dsThangNam = new ThangNam[tb.Rows.Count];
            int i = 0;
            int j = 0;
            foreach (DataRow row in tb.Rows)
            {
                if (row["THANG_NAM"] != null && row["THANG_NAM"].ToString() != "")
                {
                    string[] M = row["THANG_NAM"].ToString().Split('/');
                    dsThangNam[i] = new ThangNam(HelpNumber.ParseInt32(M[0]),
                        HelpNumber.ParseInt32(M[1]), row["IS_CHOT"].ToString());
                    i++;
                }
            }
            //Duyet nam
            for (i = 0; i < dsThangNam.Length - 1; i++)
            {
                for (j = i + 1; j < dsThangNam.Length; j++)
                {
                    if (dsThangNam[i].yy < dsThangNam[j].yy)
                        HoanVi(ref dsThangNam[i], ref dsThangNam[j]);
                }
            }
            //Duyet thang
            for (i = 0; i < dsThangNam.Length - 1; i++)
            {
                for (j = i + 1; j < dsThangNam.Length; j++)
                {
                    if (dsThangNam[i].yy == dsThangNam[j].yy &&
                        dsThangNam[i].mm < dsThangNam[j].mm)
                        HoanVi(ref dsThangNam[i], ref dsThangNam[j]);
                }
            }
            //Do lai db
            tb.Rows.Clear();
            foreach (ThangNam item in dsThangNam)
            {
                DataRow r = tb.NewRow();
                string value = (item.mm > 9) ? item.mm.ToString() : ("0" + item.mm.ToString());
                value += "/" + item.yy.ToString();
                r["THANG_NAM"] = value;
                r["NAM"] = item.yy;
                r["IS_CHOT"] = item.chot;
                tb.Rows.Add(r);
            }
            //
            return tb;
        }
    }

}
