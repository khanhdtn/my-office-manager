using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolVN.Framework.Core;
using DTO;
using System.Data;
using System.Data.Common;

namespace DAO
{
    public class DABangChamCong64 : DAPhieu<DOBangChamCong64>
    {
        #region Khai báo biến sử dụng
        public static string TABLE = "BANG_CHAM_CONG_64";
        public static string KEY_FIELD = "ID";
        private object[] FIELD_MAP = new object[] { 
            "ID",new IDConverter(),
            "EMP_ID",new IDConverter(),
            "THANG_NAM",null,
            "N01_SANG",null,
            "N02_SANG",null,
            "N03_SANG",null,
            "N04_SANG",null,
            "N05_SANG",null,
            "N06_SANG",null,
            "N07_SANG",null,
            "N08_SANG",null,
            "N09_SANG",null,
            "N10_SANG",null,
            "N11_SANG",null,
            "N12_SANG",null,
            "N13_SANG",null,
            "N14_SANG",null,
            "N15_SANG",null,
            "N16_SANG",null,
            "N17_SANG",null,
            "N18_SANG",null,
            "N19_SANG",null,
            "N20_SANG",null,
            "N21_SANG",null,
            "N22_SANG",null,
            "N23_SANG",null,
            "N24_SANG",null,
            "N25_SANG",null,
            "N26_SANG",null,
            "N27_SANG",null,
            "N28_SANG",null,
            "N29_SANG",null,
            "N30_SANG",null,
            "N31_SANG",null,

            "N01_CHIEU",null,
            "N02_CHIEU",null,
            "N03_CHIEU",null,
            "N04_CHIEU",null,
            "N05_CHIEU",null,
            "N06_CHIEU",null,
            "N07_CHIEU",null,
            "N08_CHIEU",null,
            "N09_CHIEU",null,
            "N10_CHIEU",null,
            "N11_CHIEU",null,
            "N12_CHIEU",null,
            "N13_CHIEU",null,
            "N14_CHIEU",null,
            "N15_CHIEU",null,
            "N16_CHIEU",null,
            "N17_CHIEU",null,
            "N18_CHIEU",null,
            "N19_CHIEU",null,
            "N20_CHIEU",null,
            "N21_CHIEU",null,
            "N22_CHIEU",null,
            "N23_CHIEU",null,
            "N24_CHIEU",null,
            "N25_CHIEU",null,
            "N26_CHIEU",null,
            "N27_CHIEU",null,
            "N28_CHIEU",null,
            "N29_CHIEU",null,
            "N30_CHIEU",null,
            "N31_CHIEU",null,

            "NGHI_CO_PHEP",null,
            "NGHI_KHONG_PHEP",null,
            "SO_NGAY_LAM_VIEC",null,
            "SO_NGAY_KHONG_LUONG",null,
            "SO_NGAY_TRO_CAP",null,
            "SO_NGAY_HUONG_LUONG",null
        };

        public static DABangChamCong64 I = new DABangChamCong64(); 
        #endregion

        private DABangChamCong64() : base() { 
        }
        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            return null;
        }

        public override DOBangChamCong64 LoadAll(long IDKey)
        {
            DOBangChamCong64 phieu = this.Load(IDKey);
            QueryBuilder query = new QueryBuilder("SELECT * FROM " + TABLE + " WHERE 1=1");
            query.addID(KEY_FIELD,IDKey);
            phieu.MasterDataSet = HelpDB.getDBService().LoadDataSet(query, TABLE);
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
            return FWDBService.DeleteRecord(TABLE, KEY_FIELD, IDKey);
        }

        public override DOBangChamCong64 Load(long IDKey)
        {
            IDataReader reader = FWDBService.LoadRecord(TABLE, KEY_FIELD, IDKey);
            using (reader) {
                if (reader.Read()) {
                    return (DOBangChamCong64)this.Builder.CreateFilledObjectExt(typeof(DOBangChamCong64), reader);
                }
            }
            return
                new DOBangChamCong64();
        }

        public override bool Update(DOBangChamCong64 data)
        {
            return true;
        }

        public override bool Validate(DOBangChamCong64 element)
        {
            return true;
        }

        /// <summary>
        /// Gán giá trị cho Field của bảng chấm công 64 dựa vào ngày
        /// </summary>
        public void _setField(DOBangChamCong64 element, DateTime date, object Value) {
            string Field = "N" + ((date.Day > 10) ? date.Day.ToString() : ("0" + date.Day.ToString()));
            element.GetType().GetField(Field + "_SANG").SetValue(element, Value);
            element.GetType().GetField(Field + "_CHIEU").SetValue(element, Value);
        }
        #region Extension(s)
        public bool UpdateDataSet(DataSet dsData) {
            DatabaseFB db = DABase.getDatabase();
            db.OpenConnection();
            return db.UpdateDataSet(dsData);
        }
        #endregion
    }
}
