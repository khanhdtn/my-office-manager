using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;
using DTO;
using System.Data.Common;

namespace DAO
{
    public class DAPhongVan : DAPhieu<DOPhongVan>
    {
        private static string KEY_FIELD_NAME = "ID";
        object[] FIELD_MAP = new object[] {  
            "ID", new IDConverter(),                     
            "NGAY_GIO_PHONG_VAN", null,         
            "VONG_PHONG_VAN",null,             
            "LAN_MOI_PHONG_VAN",null,          
            "MOI_PHONG_VAN", null,    
            "UNG_VIEN_XAC_NHAN",null,
            "UNG_VIEN_XAC_NHAN_GHI_CHU",null,  
            "THAM_DU",null,                    
            "THAM_DU_GHI_CHU", null,            
            "KET_QUA",null,                    
            "NGAY_BAT_DAU",null,               
            "THOI_GIAN_LAM_VIEC",null,         
            "UNG_VIEN_DA_CHAP_NHAN",null,      
            "MUC_LUONG",null,                  
            "DTD_ID",new IDConverter(),                     
            "R_ID", new IDConverter(),                       
            "KET_QUA_GHI_CHU", null,            
            "THONG_BAO_KET_QUA",null,          
            "THONG_TIN_KHAC",null    
        };
        public static DAPhongVan Instance = new DAPhongVan();
        public DAPhongVan() : base() { }

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            throw new NotImplementedException();
        }

        public override DOPhongVan LoadAll(long IDKey)
        {
            throw new NotImplementedException();
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
            return new DataTypeBuilder(this.FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return DatabaseFB.DeleteRecord("HEN_PHONG_VAN", "ID", IDKey);
        }

        public override DOPhongVan Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord("HEN_PHONG_VAN", KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOPhongVan data = (DOPhongVan)this.Builder.CreateFilledObject(typeof(DOPhongVan), reader);
                    return data;
                }

            }
            return new DOPhongVan();
        }

        public override bool Update(DOPhongVan data)
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

        public override bool Validate(DOPhongVan element)
        {
            throw new NotImplementedException();
        }
        public bool UpdatePhieu(DOPhongVan data)
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
    }
}
