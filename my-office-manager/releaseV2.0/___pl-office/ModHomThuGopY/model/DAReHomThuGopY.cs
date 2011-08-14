using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using pl.office;

namespace DAO
{
    #region ReHomThuGopY Fields
    public class ReHomThuGopYFields
    {
        public static string ID = "ID";
        public static string GOP_Y_ID = "GOP_Y_ID";
        public static string NOI_DUNG_PHAN_HOI = "NOI_DUNG_PHAN_HOI";
        public static string NGUOI_PHAN_HOI_ID = "NGUOI_PHAN_HOI_ID";
        public static string NGAY = "NGAY";
    }
    #endregion
    class DAReHomThuGopY : DAPhieu<DOReHomThuGopY>
    {
        #region Fields
        public static string KEY_FIELD_NAME = ReHomThuGopYFields.ID;
        public static string TABLE_MAP = "RE_HOM_THU_GOP_Y";
        private object[] FIELD_MAP = new object[] {  
                HomThuGopYFiedls.ID,new IDConverter(),
                ReHomThuGopYFields.GOP_Y_ID,null,
                ReHomThuGopYFields.NOI_DUNG_PHAN_HOI,null,
                ReHomThuGopYFields.NGUOI_PHAN_HOI_ID,null,
                ReHomThuGopYFields.NGAY,null,
        };
        public static DAReHomThuGopY I = new DAReHomThuGopY();
        public DAReHomThuGopY() : base() { }
        #endregion
        #region Methods Override
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOReHomThuGopY LoadAll(long IDKey)
        {
            DOReHomThuGopY phieu = this.Load(IDKey);
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

        public override DOReHomThuGopY Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOReHomThuGopY data = (DOReHomThuGopY)this.Builder.CreateFilledObjectExt(typeof(DOReHomThuGopY), reader);
                    return data;
                }
            }
            return new DOReHomThuGopY();
        }

        public override bool Update(DOReHomThuGopY data)
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
                            flag = DatabaseFB.Update2DataSet("G_NGHIEP_VU", dsMain, null, true);
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

        public override bool Validate(DOReHomThuGopY element)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Ext methods
        public DOReHomThuGopY LoadAllByGopYId(long IDKey)
        {
            DOReHomThuGopY phieu = this.Load(-2);
            QueryBuilder query = new QueryBuilder("Select * from RE_HOM_THU_GOP_Y where 1=1");
            query.addID(ReHomThuGopYFields.GOP_Y_ID,IDKey);
            phieu.MasterDataSet = HelpDB.getDatabase().LoadDataSet(query);
            return phieu;
        }
        #endregion
    }
}
