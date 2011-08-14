using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using DTO;

namespace DAO
{
    
    public class DABangLuongChiTiet : DAPhieu<DOLuongChiTiet>
    {
        public static string TABLE_MAP = "BANG_LUONG_CT";
        public static DABangLuongChiTiet Instance = new DABangLuongChiTiet();
        
        public DABangLuongChiTiet():base() { }

        public override DataTypeBuilder DefineDetailDataTypeBuilder()
        {
            throw new NotImplementedException();
        }

        public override DOLuongChiTiet LoadAll(long IDKey)
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
            return new DataTypeBuilder();

        }

        public override bool Delete(long IDKey)
        {
            throw new NotImplementedException();
        }

        public override DOLuongChiTiet Load(long IDKey)
        {
            throw new NotImplementedException();
        }

        public override bool Update(DOLuongChiTiet data)
        {
            throw new NotImplementedException();
        }

        public override bool Validate(DOLuongChiTiet element)
        {
            throw new NotImplementedException();
        }

        public bool DeletePhieu(long luongId) {
            DatabaseFB fb = HelpDB.getDatabase();
            DbCommand cmd = fb.GetSQLStringCommand(@"DELETE FROM " + TABLE_MAP + " WHERE LUONG_ID =" + luongId);
            if (fb.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }

    }
}
