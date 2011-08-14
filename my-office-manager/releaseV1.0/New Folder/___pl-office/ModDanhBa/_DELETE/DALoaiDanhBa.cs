using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using System.Data.Common;
using DevExpress.XtraNavBar;
using DTO;
using office;
using ProtocolVN.Framework.Win;
namespace DAO
{
    class DALoaiDanhBa:DAPhieu<DOLoaiDanhBa>
    {
        private static string KEY_FIELD_NAME = "ID";
        private static string _New_Name = string.Empty;

        public static string New_Name
        {
            get { return DALoaiDanhBa._New_Name; }
            set { DALoaiDanhBa._New_Name = value; }
        }
        object[] FIELD_MAP = new object[]{
            "ID",new IDConverter(),
            "TEN_LOAI",null
        };
        public static DALoaiDanhBa Instance = new DALoaiDanhBa();
        #region DAPhieu Members               
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOLoaiDanhBa LoadAll(long IDKey)
        {
            DOLoaiDanhBa data = Load(IDKey);
            data.DetailDataSet = DatabaseFB.LoadDataSet("LOAI_DANH_BA", "ID", IDKey);
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
            return DatabaseFB.DeleteRecord("LOAI_DANH_BA", "ID", IDKey);
        }

        public override DOLoaiDanhBa Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("LOAI_DANH_BA", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOLoaiDanhBa data = (DOLoaiDanhBa)this.Builder.CreateFilledObject(typeof(DOLoaiDanhBa), reader);
                    return data;
                }
            }
            return new DOLoaiDanhBa();
        }

        public override bool Update(DOLoaiDanhBa data)
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

        public override bool Validate(DOLoaiDanhBa element)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Business Function(s)
        /// <summary>
        /// Inserts a new Danh Ba
        /// </summary>
        /// <param name="data">Data object</param>
        /// <param name="Ten_Loai">Name of object</param>
        /// <returns></returns>
        public bool InsertLoaiDanhBa(DOLoaiDanhBa data,string Name)
        {
            try
            {
                data.ID = DABase.getDatabase().GetID(HelpGen.G_FW_DM_ID);
                DataRow row = data.DetailDataSet.Tables[0].NewRow();
                row["ID"] = data.ID;
                row["TEN_LOAI"] = Name;
                data.DetailDataSet.Tables[0].Rows.Add(row);
                return DALoaiDanhBa.Instance.Update(data);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Thêm mới loại danh bạ");
                return false;
            }
        }
        public bool RenameLoaiDanhBa(long ID,string Name)
        {
            try
            {
                DatabaseFB db = DABase.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand("Update LOAI_DANH_BA set Ten_Loai=@Ten_Loai where ID=@ID");
                db.AddInParameter(cmd, "@Ten_Loai", DbType.String, Name);
                db.AddInParameter(cmd, "@ID", DbType.Int16, ID);
                return db.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }
        public bool isDuplicateNameDirectory(List<NavBarItem> ListItem,string value)
        {            
            try 
	        {
                foreach (NavBarItem item in ListItem)               
                    if (item.Caption.ToLower()== value.ToLower())
                        return true;                               
	        }
	        catch (Exception ex)
	        {
		        PLException.AddException(ex);                
	        }
            return false ;
            
        }
        #endregion
    }
}
