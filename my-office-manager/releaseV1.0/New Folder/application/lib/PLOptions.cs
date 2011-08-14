using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System.Data;

namespace office
{
    //public class PLOptions
    //{
    //    public static DateTime TimeStart = new DateTime(1970, 1, 1, 8, 0, 0);
    //    public static int TimeInLater = 15;
    //    public static DateTime TimeEnd = new DateTime(1970, 1, 1, 17, 0, 0);
    //    public static int HeSoTruLuong = 3;
    //    /// <summary>
    //    /// 08:00:AM
    //    /// </summary>
    //    public static DateTime GIO_DI_TRE = System.Convert.ToDateTime("01/01/1970 08:00:00 AM");
    //    /// <summary>
    //    /// 17:00:00 PM
    //    /// </summary>
    //    public static DateTime GIO_VE_SOM = System.Convert.ToDateTime("01/01/1970 17:00:00 PM");
    //    /// <summary>
    //    /// 12:00:00 PM
    //    /// </summary>
    //    public static DateTime GIO_NGHI_TRUA = System.Convert.ToDateTime("01/01/1970 12:00:00 PM");
    //    /// <summary>
    //    /// 13:00:00 PM
    //    /// </summary>
    //    public static DateTime GIO_BD_CHIEU = System.Convert.ToDateTime("01/01/1970 13:00:00 PM");

    //    static PLOptions() {
            
    //    }
    //    public static void ReSetData() {
    //        //DOSystemParams phieu = DASystemParams.Instance.LoadAll(1);
    //        //GIO_DI_TRE = phieu.GIO_BAT_DAU_SANG;
    //        //GIO_NGHI_TRUA = phieu.GIO_KET_THUC_SANG;
    //        //GIO_BD_CHIEU = phieu.GIO_BAT_DAU_CHIEU;
    //        //GIO_VE_SOM = phieu.GIO_KET_THUC_CHIEU;
    //    }
    //}

    //public class DOSystemParams : DOPhieu {
    //    public long ID;
    //    public DateTime GIO_BAT_DAU_SANG;
    //    public DateTime GIO_KET_THUC_SANG;
    //    public DateTime GIO_BAT_DAU_CHIEU;
    //    public DateTime GIO_KET_THUC_CHIEU;
    //    public int THOI_GIAN_CHO_PHEP_TRE;
    //    public int HE_SO_TRU_LUONG;
    //    public DataSet DetailDataSet;
    //    public DOSystemParams() { }
    //}
    //public class DASystemParams : DAPhieu<DOSystemParams> {

    //    private static string KEY_FIELD_NAME = "ID";
    //    public static string TABLE_MAP = "FW_REPORT_PARAMS";
    //    object[] FIELD_MAP = new object[] {  
    //            "ID", new IDConverter(),
    //            "GIO_BAT_DAU_SANG", null,	
    //            "GIO_KET_THUC_SANG", null,				
    //            "GIO_BAT_DAU_CHIEU", null,
    //            "GIO_KET_THUC_CHIEU",null,
    //            "THOI_GIAN_CHO_PHEP_TRE",null,
    //            "HE_SO_TRU_LUONG",null,
    //    };

    //    public static DASystemParams Instance = new DASystemParams();
    //    public DASystemParams() : base() { }

    //    public override DataTypeBuilder DefineDetailDataTypeBuilder()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override DOSystemParams LoadAll(long IDKey)
    //    {
    //        DOSystemParams phieu = this.Load(IDKey);
    //        phieu.DetailDataSet = DatabaseFB.LoadDataSet(TABLE_MAP, KEY_FIELD_NAME, IDKey);
    //        return phieu;    
    //    }

    //    public override bool UpdateDetail(DataSet Detail, DataSet Grid)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool ValidateDetail(DataRow row)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override DataTypeBuilder DefineDataTypeBuilder()
    //    {
    //        return new DataTypeBuilder(FIELD_MAP);
    //    }

    //    public override bool Delete(long IDKey)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override DOSystemParams Load(long IDKey)
    //    {
    //        IDataReader reader = DatabaseFB.LoadRecord(TABLE_MAP, KEY_FIELD_NAME, IDKey);
    //        using (reader)
    //        {
    //            if (reader.Read())
    //            {
    //                DOSystemParams data = (DOSystemParams)this.Builder.CreateFilledObjectExt(typeof(DOSystemParams), reader);

    //                return data;
    //            }
    //        }
    //        return new DOSystemParams();
    //    }

    //    public override bool Update(DOSystemParams data)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override bool Validate(DOSystemParams element)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
