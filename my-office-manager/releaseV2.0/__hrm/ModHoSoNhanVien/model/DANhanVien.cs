using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using ProtocolVN.Framework.Core;
namespace DAO
{
    public class DANhanVien
    {
        public static DANhanVien Instance = new DANhanVien();
        DatabaseFB db = null;
        System.Data.Common.DbCommand cmd = null;
        DataSet ds = null;
        QueryBuilder query = null;

        private DANhanVien()
        {

        }
        public DataTable getTableNhanVien()
        {
            DataSet Kq = DABase.getDatabase().LoadDataSet("SELECT * FROM DM_NHAN_VIEN WHERE VISIBLE_BIT='Y'");
            if (Kq != null)
                return Kq.Tables[0];
            return null;
        }
    }
}
