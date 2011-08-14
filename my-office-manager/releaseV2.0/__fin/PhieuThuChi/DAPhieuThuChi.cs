using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;

namespace DAO
{
    public class PhieuThuChiExtFields { 
        public const string PTC_ID="PTC_ID";
        public const string CODE = "CODE";
        public const string LCP_ID = "LCP_ID";
        public const string NGAY_PHAT_SINH = "NGAY_PHAT_SINH";
        public const string NGAY_TAO_PHIEU = "NGAY_TAO_PHIEU";
        public const string NGUOI_TAO_PHIEU = "NGUOI_TAO_PHIEU";
        public const string EMP_ID = "EMP_ID";
        public const string SO_TIEN_THU = "SO_TIEN_THU";
        public const string SO_TIEN_CHI = "SO_TIEN_CHI";
        public const string DON_VI_LIEN_QUAN = "DON_VI_LIEN_QUAN";
        public const string DIEN_GIAI = "DIEN_GIAI";
        public const string KKD_ID = "KKD_ID";
        public const string THU_CHI_BIT = "THU_CHI_BIT";
    }
    
    public class DAPhieuThuChiExt : DAPhieu<DOPhieuThuChiExt>
    {
        public static string KEY_FIELD_NAME = "PTC_ID";
        public static string TABLE_MAP = "PHIEU_THU_CHI";
        private object[] FIELD_MAP = new object[] { 
            PhieuThuChiExtFields.PTC_ID,new IDConverter(),
            PhieuThuChiExtFields.CODE,null,
            PhieuThuChiExtFields.LCP_ID,new IDConverter(),
            PhieuThuChiExtFields.NGAY_PHAT_SINH,null,
            PhieuThuChiExtFields.NGAY_TAO_PHIEU,null,
            PhieuThuChiExtFields.NGUOI_TAO_PHIEU,null,
            PhieuThuChiExtFields.EMP_ID, new IDConverter(),
            PhieuThuChiExtFields.SO_TIEN_THU,null,
            PhieuThuChiExtFields.SO_TIEN_CHI,null,
            PhieuThuChiExtFields.DIEN_GIAI,null,
            PhieuThuChiExtFields.DON_VI_LIEN_QUAN,null,
            PhieuThuChiExtFields.KKD_ID,new IDConverter(),
            PhieuThuChiExtFields.THU_CHI_BIT,null
        };
        public static DAPhieuThuChiExt Instance = new DAPhieuThuChiExt();

        public DAPhieuThuChiExt():base() { }

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOPhieuThuChiExt LoadAll(long IDKey)
        {
            DOPhieuThuChiExt phieu = this.Load(IDKey);
            phieu.MasterDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            return phieu;
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
            return DatabaseFB.DeleteRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
        }

        public override DOPhieuThuChiExt Load(long IDKey)
        {
            IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
            using (reader)
            {
                if (reader.Read())
                {
                    DOPhieuThuChiExt data = (DOPhieuThuChiExt)this.Builder.CreateFilledObjectExt(typeof(DOPhieuThuChiExt), reader);

                    return data;
                }
            }
            return new DOPhieuThuChiExt();
        }

        public override bool Update(DOPhieuThuChiExt data)
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
                        DataSet dsMain = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, data.PTC_ID);
                        HelpDataSet.MergeDataSet(new string[] { KEY_FIELD_NAME }, dsMain, data.MasterDataSet);
                        if (data.PTC_ID == 0)
                            flag = DatabaseFB.Update2DataSet("G_NGHIEP_VU", dsMain, null, true);
                        else
                        {
                            flag = DABase.getDatabase().UpdateDataSet(dsMain);
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

        public override bool Validate(DOPhieuThuChiExt element)
        {
            return true;
        }
        public string GetCodePhieu(bool IsTC) { 
            if(IsTC)
                return DatabaseFB.getSoPhieu(TABLE_MAP, PhieuThuChiExtFields.CODE, DatabaseFB.GetThamSo("MA_PTH"));
            else
                return DatabaseFB.getSoPhieu(TABLE_MAP, PhieuThuChiExtFields.CODE, DatabaseFB.GetThamSo("MA_PCH"));
        }
    }
}
