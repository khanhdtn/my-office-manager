﻿
using System;
using System.Data;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Data.Common;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DTO;
using System.Collections.Generic;
using office;
namespace DAO
{
    public class DADanhBaExt : DAPhieu<DODanhBaExt>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),                                
                "NAME", null,	                                           										
                "DIA_CHI", null,
                "SO_DIEN_THOAI",null, 
                "TEN_NGAN_HANG", null,	
                "SO_FAX",null,                           
                "NGUOI_DAI_DIEN",null,
                "CHUC_VU",null,
                "DI_DONG",null,
                "TAI_KHOAN",null,
                "LOAI_DANH_BA",null,
                "EMAIL",null
        };
        public static DADanhBaExt Instance = new DADanhBaExt();

        private DADanhBaExt() : base() { }

        #region Xử lý dữ liệu

        public static DataSet Load_danhba(long ID_LoaiDanhBa)
        {
            //  string sql = " LOAI_DANH_BA=+" + ID_LoaiDanhBa;

            QueryBuilder query = new QueryBuilder("select * from danh_ba where 1=1");
            query.addID("LOAI_DANH_BA", ID_LoaiDanhBa);
            //DataSet ds = //PermissionOfResource.Running.HelpPermissionResource.LoadDataSetWithPermissionOnRes(query, "DANH_BA", "ID");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            return ds;
        }
        public static void Xoa_DanhBa(long ID)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction trans = db.BeginTransaction(db.OpenConnection());
            DbCommand cm = db.GetSQLStringCommand("delete from DANH_BA where ID='" + ID + "'");
            db.ExecuteNonQuery(cm, trans);
            db.CommitTransaction(trans);
        }

        #endregion

        #region Các hàm kế thừa

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DODanhBaExt LoadAll(long IDKey)
        {
            DODanhBaExt phieu = this.Load(IDKey);
            phieu.DetailDataSet =FWDBService.LoadDataSet("DANH_BA", "ID", IDKey); // PermissionOfResource.Running.HelpPermissionResource.LoadDataSetWithPermissionOnRes("DANH_BA", "ID", IDKey); 
            return phieu;
        }

        public override bool UpdateDetail(DataSet Detail, DataSet Grid)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateDetail(DataRow row)
        {
            return true;
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            throw new NotImplementedException();
        }

        public override DODanhBaExt Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord("DANH_BA", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DODanhBaExt data = (DODanhBaExt)this.Builder.CreateFilledObject(typeof(DODanhBaExt), reader);
                    return data;
                }
            }
            return new DODanhBaExt();
        }


        public override bool Update(DODanhBaExt data)
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
        public override bool Validate(DODanhBaExt element)
        {
            throw new NotImplementedException();
        }
        public FieldNameCheck[] GetRule(DataRow[] Field_Name)
        {
            FieldNameCheck[] Rules = new FieldNameCheck[Field_Name.Length / Field_Name.Length];
            int i = 0;
            foreach (DataRow row in Field_Name)
            {
                List<object> lstRow = new List<object>(row.ItemArray);
                if (lstRow.Exists(delegate(object e)
                {
                    return string.Compare(e.ToString(), "NAME") == 0;
                }))
                {
                    Rules.SetValue(new FieldNameCheck("NAME",
                        new CheckType[] { CheckType.Required },
                        new string[] { HelpErrorMsg.errorRequired("Tên liên lạc") },
                        new object[] { }), i);
                    break;
                }
                if (lstRow.Exists(delegate(object e)
                {
                    return string.Compare(e.ToString(), "NGUOI_DAI_DIEN") == 0;
                }))
                {
                    Rules.SetValue(new FieldNameCheck("NGUOI_DAI_DIEN",
                        new CheckType[] { CheckType.Required },
                        new string[] { HelpErrorMsg.errorRequired("Người liên hệ") },
                        new object[] { }), i);
                    break;
                }
            }
            //Khanhdtn: Đoạn code kiểm tra nếu tất các rule trong Rules null thì cho nó ko có giá trị rule nào hết
            bool allNull = true;
            foreach (FieldNameCheck f in Rules)
            {
                if (f != null)
                {
                    allNull = false;
                    break;
                }
            }
            if (allNull) return new FieldNameCheck[0];
            return Rules;
        }
        public FieldNameCheck[] GetIsEmail(DataRow[] Field_Name)
        {
            FieldNameCheck[] Rules = new FieldNameCheck[1];
            int i = 0;
            foreach (DataRow row in Field_Name)
            {
                if (row["FIELD_NAME"].ToString() == "EMAIL")
                {
                    Rules.SetValue(new FieldNameCheck(row["FIELD_NAME"].ToString(),
                        new CheckType[] { CheckType.RequireEmail },
                        new string[] { HelpErrorMsg.errorEmail(row["MO_TA"].ToString()) },
                        new object[] { }), i);
                    i++;
                }
            }
            return Rules;
        }
        public FieldNameCheck[] GetIsNumber(DataRow[] Field_Name)
        {
            int Cot_so = 0;
            for (int j = Field_Name.Length - 1; j >= 0; j--)
            {
                if (Field_Name[j]["FIELD_NAME"].ToString().Substring(0, 2).ToLower() == "so")
                    Cot_so++;
            }
            FieldNameCheck[] Rules = new FieldNameCheck[Cot_so];
            int i = 0;
            foreach (DataRow row in Field_Name)
            {
                if (row["FIELD_NAME"].ToString().Substring(0, 2).ToLower() == "so")
                {
                    Rules.SetValue(new FieldNameCheck(row["FIELD_NAME"].ToString(),
                        new CheckType[] { CheckType.RequiredID },
                        new string[] { HelpErrorMsg.errorNumber(row["MO_TA"].ToString()) },
                        new object[] { }), i);
                    i++;
                }
            }
            return Rules;
        }
        public FieldNameCheck[] GetRule_MaxLength(DataRow[] Field_Name)
        {
            FieldNameCheck[] Rules = new FieldNameCheck[Field_Name.Length];
            int i = 0;
            foreach (DataRow row in Field_Name)
            {
                int Max_Length = HelpNumber.ParseInt32(row["COLUMN_SIZE"]);
                Rules.SetValue(new FieldNameCheck(row["FIELD_NAME"].ToString(),
                    new CheckType[] { CheckType.OptionMaxLength },
                    //new string[] { ErrorMsgLib.errorMaxLength(row["MO_TA"].ToString()) },
                    new string[] { string.Format("Vui lòng vào thông tin \"{0}\" ngắn hơn ({1} ký tự)!", row["MO_TA"].ToString(), Max_Length) },
                    new object[] { Max_Length }), i);
                i++;
            }
            return Rules;
        }
        public void CheckDuplicate(GridView view, DataSet GridDataSet, ValidateRowEventArgs e)
        {
            DataRow row = view.GetDataRow(e.RowHandle);
            int count_Name, count_Tk, count_NguoiLH;
            count_Name = count_Tk = count_NguoiLH = 0;
            foreach (DataRow r in GridDataSet.Tables[0].Rows)
            {
                if (r.RowState != DataRowState.Deleted)
                {
                    if (r["NAME"].ToString() == row["NAME"].ToString() && r["NAME"].ToString() != string.Empty)
                    {
                        if (view.IsNewItemRow(view.FocusedRowHandle))
                        {
                            row.SetColumnError("NAME", "Thông tin \"Tên liên lạc\" bị trùng, xin vui lòng kiểm tra lại!");
                            e.Valid = false;
                            return;
                        }
                        count_Name++;
                        if (count_Name > 1)
                        {
                            row.SetColumnError("NAME", "Thông tin \"Tên liên lạc\" bị trùng, xin vui lòng kiểm tra lại!");
                            e.Valid = false;
                            return;
                        }
                    }
                    if (r["NGUOI_DAI_DIEN"].ToString() == row["NGUOI_DAI_DIEN"].ToString() && r["NGUOI_DAI_DIEN"].ToString() != string.Empty)
                    {
                        if (view.IsNewItemRow(view.FocusedRowHandle))
                        {
                            row.SetColumnError("NGUOI_DAI_DIEN", "Thông tin \"Người liên hệ\" bị trùng, xin vui lòng kiểm tra lại!");
                            e.Valid = false;
                            return;
                        }                        
                        count_NguoiLH++;
                        if (count_NguoiLH > 1)
                        {
                            row.SetColumnError("NGUOI_DAI_DIEN", "Thông tin \"Người liên hệ\" bị trùng, xin vui lòng kiểm tra lại!");
                            e.Valid = false;
                            return;
                        }                        
                    }
                }
            }
        }
        #endregion
    }
}

