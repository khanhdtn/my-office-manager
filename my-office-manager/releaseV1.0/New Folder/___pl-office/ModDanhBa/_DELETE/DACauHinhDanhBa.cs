using System;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using DevExpress.XtraEditors;
using DTO;
using System.Collections.Generic;
using System.Text;
namespace DAO
{
    class DACauHinhDanhBa:DAPhieu<DOCauHinhDanhBa>
    {
        private static string KEY_FIELD_NAME = "LOAI_DANH_BA";
        object[] FIELD_MAP = new object[]{
            "LOAI_DANH_BA",new IDConverter(),
            "FIELD_NAME",null,
            "MO_TA",null,
            "STT",null
        };
        public static DACauHinhDanhBa Instance = new DACauHinhDanhBa();
        #region DAPhieu Members
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOCauHinhDanhBa LoadAll(long IDKey)
        {
            DOCauHinhDanhBa data = Load(IDKey);
            QueryBuilder query = new QueryBuilder(@"SELECT * FROM CAU_HINH_DANH_BA where 1=1");
            query.addID("LOAI_DANH_BA", IDKey);
            query.setAscOrderBy("STT");
            //data.DetailDataSet = DatabaseFB.LoadDataSet("CAU_HINH_DANH_BA", "LOAI_DANH_BA", IDKey);
            data.DetailDataSet = DABase.getDatabase().LoadDataSet(query, "CAU_HINH_DANH_BA");
            return data;
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
            throw new NotImplementedException();
        }

        public override DOCauHinhDanhBa Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("CAU_HINH_DANH_BA", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOCauHinhDanhBa data = (DOCauHinhDanhBa)this.Builder.CreateFilledObject(typeof(DOCauHinhDanhBa), reader);
                    return data;
                }
            }
            return new DOCauHinhDanhBa();
        }

        public override bool Update(DOCauHinhDanhBa data)
        {
            DatabaseFB db = DABase.getDatabase();
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

        public override bool Validate(DOCauHinhDanhBa element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Business Function(s)
        /// <summary>
        /// Inserts a new configuration directory
        /// </summary>
        /// <param name="Loai_Danh_Ba">Name of directory type </param>
        /// <param name="Checked_List">Field names belong to directory type</param>
        /// <returns></returns>
        public bool InsertDanhBaFields(long IDLoaiDanhBa, CheckedListBoxControl checklistField_Name)
        {
            try
            {
                BaseCheckedListBoxControl.CheckedIndexCollection Checked_List = checklistField_Name.CheckedIndices;
                DOCauHinhDanhBa phieuDanhBaFields = DACauHinhDanhBa.Instance.LoadAll(-2);
                for (int i = 0; i < Checked_List.Count; i++)
                {
                    DataRow row = phieuDanhBaFields.DetailDataSet.Tables[0].NewRow();
                    row["LOAI_DANH_BA"] = IDLoaiDanhBa;
                    row["FIELD_NAME"] = checklistField_Name.CheckedItems[checklistField_Name.CheckedIndices.IndexOf(Checked_List[i])].ToString();
                    phieuDanhBaFields.DetailDataSet.Tables[0].Rows.Add(row);
                }
                return DACauHinhDanhBa.Instance.Update(phieuDanhBaFields);
            }
            catch (Exception ex) {
                PLException.AddException(ex);
                return false;
            }
        }
        public void SortCheckedList(ref CheckedListBoxControl Checked_List)
        {
            //for (int i = 0; i < Checked_List.Count - 1; i++) {
            //    for (int j = 0; j < Checked_List.Count; j++) { 
                  
            //    }
            //}
        }
        public bool DeleteDanhBaFields(long LoaiDanhBa, List<string> ListFieldName)
        {
            if (ListFieldName.Count == 0) return true;//Ko có field để xóa
            StringBuilder Field_Names = new StringBuilder("'");
            StringBuilder Update_Sql = new StringBuilder(" set ");
            foreach (string item in ListFieldName)
            {
                Field_Names.Append(item + "','");
                Update_Sql.Append(item + "=null,");
            }
            Field_Names.Remove(Field_Names.Length - 2, 2);
            Update_Sql.Remove(Update_Sql.Length - 1, 1);
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cmd = db.GetStoredProcCommand("SP_XOA_TT_CU");
            db.AddInParameter(cmd, "@LOAI_DANH_BA", DbType.Int64, LoaiDanhBa);
            db.AddInParameter(cmd, "@FIELD_NAME", DbType.String, Field_Names.ToString());
            db.AddInParameter(cmd, "@UPDATE_SQL", DbType.String, Update_Sql.ToString());
            try
            {
                db.ExecuteNonQuery(cmd, dbTrans);
                db.CommitTransaction(dbTrans);
                return true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                db.RollbackTransaction(dbTrans);
                return false;
            }
        }
        public bool AddDanhBaFields(long LoaiDanhBa, List<string> ListFieldName)
        {            
            if (ListFieldName.Count == 0) return true;// Ko có field để thêm mới
            DOCauHinhDanhBa phieuDanhBaFields = DACauHinhDanhBa.Instance.LoadAll(-2);
            foreach (string item in ListFieldName)
            {
                DataRow row = phieuDanhBaFields.DetailDataSet.Tables[0].NewRow();
                row["LOAI_DANH_BA"] = LoaiDanhBa;
                row["FIELD_NAME"] = item;
                phieuDanhBaFields.DetailDataSet.Tables[0].Rows.Add(row);
            }
            return DACauHinhDanhBa.Instance.Update(phieuDanhBaFields);
        }
        #endregion


    }

}
