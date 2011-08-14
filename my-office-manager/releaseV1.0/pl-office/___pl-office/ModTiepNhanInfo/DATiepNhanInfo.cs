using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using System.Data.Common;
using ProtocolVN.Framework.Win;

namespace DAO
{

    #region DATA
// * CREATE TABLE TIEP_NHAN_INFO (
//    ID                A_BIG_ID NOT NULL /* A_BIG_ID = BIGINT */,
//    NGUON_THONG_TIN   A_BIG_ID /* A_BIG_ID = BIGINT */,
//    VAN_DE_TIEP_NHAN  A_STR_MEDIUM /* A_STR_MEDIUM = VARCHAR(200) */,
//    NOI_DUNG          A_IMAGE /* A_IMAGE = BLOB SUB_TYPE 0 SEGMENT SIZE 80 */,
//    NGUOI_CAP_NHAT    A_BIG_ID /* A_BIG_ID = BIGINT */,
//    NGAY_CAP_NHAT     A_DATE_TIME /* A_DATE_TIME = TIMESTAMP */,
//    NGUOI_XU_LY       A_BIG_ID /* A_BIG_ID = BIGINT */
//);




///******************************************************************************/
///***                              Primary Keys                              ***/
///******************************************************************************/

//ALTER TABLE TIEP_NHAN_INFO ADD CONSTRAINT PK_TIEP_NHAN_INFO PRIMARY KEY (ID);


///******************************************************************************/
///***                              Foreign Keys                              ***/
///******************************************************************************/

//ALTER TABLE TIEP_NHAN_INFO ADD CONSTRAINT FK_TIEP_NHAN_INFO_1 FOREIGN KEY (NGUON_THONG_TIN) REFERENCES DM_NGUON_THONG_TIN (ID);
//ALTER TABLE TIEP_NHAN_INFO ADD CONSTRAINT FK_TIEP_NHAN_INFO_2 FOREIGN KEY (NGUOI_XU_LY) REFERENCES DM_NHAN_VIEN (ID);
//ALTER TABLE TIEP_NHAN_INFO ADD CONSTRAINT FK_TIEP_NHAN_INFO_3 FOREIGN KEY (NGUOI_CAP_NHAT) REFERENCES DM_NHAN_VIEN (ID);
#endregion

    public class DATiepNhanInfo  : DAPhieu<DOTiepNhanInfo>
    {
        private static string KEY_FIELD_NAME = "ID";
        public static string TABLE_MAP = "TIEP_NHAN_INFO";
        object[] FIELD_MAP = new object[] { 
            TiepNhanInfoFields.ID,new IDConverter(),
            TiepNhanInfoFields.NGUON_THONG_TIN,new IDConverter(),
            TiepNhanInfoFields.VAN_DE_TIEP_NHAN,null,
            TiepNhanInfoFields.NOI_DUNG,null,
            TiepNhanInfoFields.NGUOI_XU_LY,null,
            TiepNhanInfoFields.NGUOI_CAP_NHAT,new IDConverter(),
            TiepNhanInfoFields.NGAY_CAP_NHAT,null,
            TiepNhanInfoFields.TINH_TRANG,null
        };

        public static DATiepNhanInfo I = new DATiepNhanInfo();

        private DATiepNhanInfo() : base() { 

        }
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOTiepNhanInfo LoadAll(long IDKey)
        {
            DOTiepNhanInfo Obj = this.Load(IDKey);
            Obj.DataSetMaster = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            return Obj;
        }

        public override bool UpdateDetail(System.Data.DataSet Detail, System.Data.DataSet Grid)
        {
            return true;
        }

        public override bool ValidateDetail(System.Data.DataRow row)
        {
            return true;
        }

        public override DataTypeBuilder DefineDataTypeBuilder()
        {
            return new DataTypeBuilder(FIELD_MAP);
        }

        public override bool Delete(long IDKey)
        {
            return FWDBService.DeleteRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
        }

        public override DOTiepNhanInfo Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOTiepNhanInfo data = (DOTiepNhanInfo)this.Builder.CreateFilledObjectExt(typeof(DOTiepNhanInfo), reader);

                    return data;
                }
            }
            return new DOTiepNhanInfo();
        }

        public override bool Update(DOTiepNhanInfo data)
        {
            bool flag = false;
            DatabaseFB db = DABase.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            try
            {
                DataSet MainDS = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.ID);
                if (MainDS.Tables[0].Rows.Count == 1)
                {
                    HelpDataSet.UpdataDataRowExt(MainDS.Tables[0].Rows[0], FIELD_MAP, data);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                else
                {
                    DataRow row = MainDS.Tables[0].NewRow();
                    row[KEY_FIELD_NAME] = data.ID;
                    HelpDataSet.UpdataDataRowExt(row, FIELD_MAP, data);
                    MainDS.Tables[0].Rows.Add(row);
                    flag = db.UpdateDataSet(MainDS, dbTrans);
                }
                db.CommitTransaction(dbTrans);
            }
            catch (Exception ex)
            {
                flag = false;
                db.RollbackTransaction(dbTrans);
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Hàm cập nhật dữ liệu \"Tiếp nhận thông tin\"");
            }
            return flag;
        }

        public override bool Validate(DOTiepNhanInfo element)
        {
            return true;
        }
        #region Extensions
        public string GetNameOfProcessor(string ProcessorIDs,DataTable dtProcessor,string symbol)
        {
            if (ProcessorIDs.Length == 0) return string.Empty;
            DataRow[] rows = dtProcessor.Select(string.Format("ID in ({0})", ProcessorIDs));
            StringBuilder stringName = new StringBuilder("");
            foreach (DataRow row in rows)
            {
                stringName.Append(row["NAME"].ToString());
                stringName.Append(symbol);
            }
            if (stringName.Length == 0) return string.Empty;
            return stringName.ToString().Remove(stringName.ToString().LastIndexOf(symbol));
        }
        #endregion
    }
}
