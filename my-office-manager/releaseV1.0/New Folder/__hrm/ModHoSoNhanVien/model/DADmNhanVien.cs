using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using office;

namespace DAO
{
    public class DADmNhanVien : DAPhieu<DODmNhanVien>
    {
        #region Fields
        public static string KEY_FIELD_NAME = "ID";
        public static string TABLE_MAP = "DM_NHAN_VIEN";
        private object[] FIELD_MAP = new object[] {  
                "ID", new IDConverter(),
                "MA_NV",null,
                "CMND",null,
                "NGAY_SINH",null,
                "DIEN_THOAI",null,
                "DIA_CHI",null,
                "EMAIL",null,
                "VISIBLE_BIT",null,
                "DEPARTMENT_ID",new IDConverter(),
                "NAME",null
        };
        public static DADmNhanVien Instance = new DADmNhanVien();
        private DADmNhanVien() : base() { }
        #endregion

        #region Method override
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            throw new NotImplementedException();
        }

        public override DODmNhanVien LoadAll(long IDKey)
        {
            DODmNhanVien phieu = this.Load(IDKey);
            phieu.DetailDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            phieu.DetailDataSet.Tables[0].TableName = TABLE_MAP;
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

        public override DODmNhanVien Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DODmNhanVien data = (DODmNhanVien)this.Builder.CreateFilledObjectExt(typeof(DODmNhanVien), reader);

                    return data;
                }
            }
            return new DODmNhanVien();
        }

        public override bool Update(DODmNhanVien data)
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
                            flag = DatabaseFB.Update2DataSet(PLConst.G_DANH_MUC, dsMain, null, true);
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

        public override bool Validate(DODmNhanVien element)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Others

        public bool MergeDataSet(DataSet forDB, DODmNhanVien data)
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
                    data.ID = HelpDB.getDatabase().GetID(PLConst.G_DANH_MUC);
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
        #endregion

    }
}
