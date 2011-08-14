using System;
using DTO;
using ProtocolVN.Framework.Core;
using System.Data;
using pl.office;

namespace DAO
{
    #region HomThuGopY Fields
    public class HomThuGopYFiedls {
        public static string ID = "ID";
        public static string TIEU_DE = "TIEU_DE";
        public static string NGAY = "NGAY";
        public static string NGUOI_GOP_Y = "NGUOI_GOP_Y";
        public static string NOI_DUNG = "NOI_DUNG";
        public static string NGUOI_NHAN_GOP_Y = "NGUOI_NHAN_GOP_Y";
        public static string IS_HIEN = "IS_HIEN";
    }
    #endregion
    public class DAHomThuGopY : DAPhieu<DOHomThuGopY>
    {
        #region Fields
        public static string KEY_FIELD_NAME = HomThuGopYFiedls.ID;
        public static string TABLE_MAP = "HOM_THU_GOP_Y";
        private object[] FIELD_MAP = new object[] {  
                HomThuGopYFiedls.ID,new IDConverter(),
                HomThuGopYFiedls.TIEU_DE,null,
                HomThuGopYFiedls.NGAY,null,
                HomThuGopYFiedls.NGUOI_GOP_Y,null,
                HomThuGopYFiedls.NOI_DUNG,null,
                HomThuGopYFiedls.NGUOI_NHAN_GOP_Y,null,
                HomThuGopYFiedls.IS_HIEN,null
        };
        public static DAHomThuGopY I = new DAHomThuGopY();
        public DAHomThuGopY() : base() { }
        #endregion
        #region Methods Override
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOHomThuGopY LoadAll(long IDKey)
        {
            DOHomThuGopY phieu = this.Load(IDKey);
            phieu.MasterDataSet = FWDBService.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
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
            return FWDBService.DeleteRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
        }

        public override DOHomThuGopY Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOHomThuGopY data = (DOHomThuGopY)this.Builder.CreateFilledObjectExt(typeof(DOHomThuGopY), reader);
                    return data;
                }
            }
            return new DOHomThuGopY();
        }

        public override bool Update(DOHomThuGopY data)
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
                        DataSet dsMain = FWDBService.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.ID);
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, dsMain, data.MasterDataSet);
                        if (data.ID == 0)
                            flag = HelpDB.Update2DataSet("G_NGHIEP_VU", dsMain, null, true);
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

        public override bool Validate(DOHomThuGopY element)
        {
            throw new NotImplementedException();
        }
        #endregion
        
    }
}
