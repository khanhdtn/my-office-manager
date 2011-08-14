using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using office;
using ProtocolVN.Framework.Core;

namespace Test
{
    public class FW
    {
        /// <summary>
        /// DUYVT: Cập nhật FW - Mở rộng thêm cho class DatabaseFB
        /// Hàm Load DataSet có filter theo tài nguyên mà người dùng có quyền
        /// </summary>
        /// <param name="query">Đối tượng QueryBuilder</param>
        /// <param name="TableRes">Tên bảng tài nguyên</param>
        /// <param name="KeyFieldRes">Trường khóa</param>
        /// <returns></returns>
        public static DataSet LoadDataSetWithPermissionOnRes(QueryBuilder query,
            string TableRes, string KeyFieldRes)
        {
            string filter_str = _getStrCollectionSQL(_getFilterResourceIds(TableRes));
            if (filter_str != "")
            {
                query.addCondition(KeyFieldRes + " in " + filter_str);
            }
            else
            {
                if (_checkIsPermission(TableRes))
                {
                    query.addCondition("-1=1");
                }                
            }

            return HelpDB.getDatabase().LoadDataSet(query, null);
        }

        /// <summary>
        /// DUYVT: Cập nhật FW - Mở rộng thêm cho class DatabaseFB
        /// Hàm Load DataSet có filter theo tài nguyên mà người dùng có quyền
        /// </summary>
        /// <param name="queryStr">Chuỗi truy vấn tài nguyên</param>
        /// <param name="TableRes">Tên bảng tài nguyên</param>
        /// <param name="KeyFieldRes">Trường khóa</param>
        /// <returns></returns>
        public static DataSet LoadDataSetWithPermissionOnRes(string queryStr,
            string TableRes, string KeyFieldRes)
        {
            string filter_str = _getStrCollectionSQL(_getFilterResourceIds(TableRes));
            if (filter_str != "")
                queryStr += " and " + KeyFieldRes + " in " + filter_str;
            else
            {
                if (_checkIsPermission(TableRes))
                {
                    queryStr += " and -1=1";
                }
            }

            DataSet dataSet = new DataSet();
            if (HelpDB.getDatabase().LoadDataSet(dataSet, queryStr, TableRes))
            {
                return dataSet;
            }
            return null;
        }

        /// <summary>
        /// DUYVT: Cập nhật FW - Mở rộng thêm cho class DatabaseFB 
        /// Hàm Load DataSet có filter theo tài nguyên mà người dùng có quyền
        /// </summary>
        /// <param name="TableRes">Tên bảng tài nguyên</param>
        /// <param name="KeyFieldRes">Trường khóa</param>
        /// <param name="IDKeyRes">Giá trị khóa</param>
        /// <returns></returns>
        public static DataSet LoadDataSetWithPermissionOnRes(string TableRes, string KeyFieldRes, long IDKeyRes)
        {
            DataSet ds = new DataSet();
            if (LoadDataSetWithPermissionOnRes(ds, TableRes, KeyFieldRes, IDKeyRes))
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// DUYVT: Cập nhật FW - Mở rộng thêm cho class DatabaseFB
        /// Hàm Load DataSet có filter theo tài nguyên mà người dùng có quyền
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="TableRes">Tên bảng tài nguyên</param>
        /// <param name="KeyFieldRes">Trường khóa</param>
        /// <param name="IDKeyRes">Giá trị khóa</param>
        /// <returns></returns>
        public static bool LoadDataSetWithPermissionOnRes(DataSet ds, string TableRes,
            string KeyFieldRes, long IDKeyRes)
        {
            if (ds == null)
            {
                return false;
            }
            try
            {
                string filter_str = _getStrCollectionSQL(_getFilterResourceIds(TableRes));
                QueryBuilder query = null;
                if (filter_str != "")
                {
                    query = new QueryBuilder("SELECT * FROM " + TableRes 
                        + " WHERE " + KeyFieldRes + " in " + filter_str + " and 1=1");
                }
                else
                {
                    if (!_checkIsPermission(TableRes))
                    {
                        query = new QueryBuilder("SELECT * FROM " + TableRes + " WHERE 1=1");
                    }
                    else
                    {
                        query = new QueryBuilder("SELECT * FROM " + TableRes + " WHERE -1=1");
                    }
                }
                if (IDKeyRes <= 0L)
                {
                    query.addCondition("-1=1");
                }
                else
                {
                    query.addID(KeyFieldRes, IDKeyRes);
                }
                return HelpDB.getDatabase().LoadDataSet(query, TableRes, ds);
            }
            catch (Exception exception)
            {
                PLException.AddException(exception);
                return false;
            }
        }

        /// <summary>
        /// DUYVT: Đưa vào FW - Hổ trợ cho hàm LoadDataSetWithPermission
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        private static string _getStrCollectionSQL(long[] ids)
        {
            if (ids != null && ids.Length > 0)
            {
                StringBuilder builder = new StringBuilder("(");
                for (int i = 0; i < ids.Length; i++)
                {
                    builder.Append(ids[i]);
                    if (i < ids.Length - 1)
                        builder.Append(",");
                }
                builder.Append(")");
                return builder.ToString();
            }
            return "";
        }

        /// <summary>
        /// DUYVT: Đưa vào FW - Hổ trợ cho hàm LoadDataSetWithPermission
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static long[] _getFilterResourceIds(string TableRes)
        {
            IPermissionRes perRes = FrameworkParams.isPermissionRes;
            List<TaiNguyen> tainguyenLst = perRes.getObjectResources();

            if (tainguyenLst != null)
            {
                foreach (TaiNguyen tainguyen in tainguyenLst)
                {
                    if (tainguyen.DMTableResName == TableRes)
                        return tainguyen._getPermissionResIDs(PERMISSION_RES.READ);
                    else if (tainguyen.DMTableResGroupName == TableRes)
                        return tainguyen._getPermissionResGroupIDs(PERMISSION_RES.READ);
                }
            }
            return null;
        }

        /// <summary>
        /// DUYVT: Đưa vào FW - Hổ trợ cho hàm LoadDataSetWithPermission
        /// </summary>
        /// <param name="TableRes"></param>
        /// <returns></returns>
        public static bool _checkIsPermission(string TableRes)
        {
            IPermissionRes perRes = FrameworkParams.isPermissionRes;
            List<TaiNguyen> tainguyenLst = perRes.getObjectResources();

            if (tainguyenLst != null)
            {
                foreach (TaiNguyen tainguyen in tainguyenLst)
                    if (tainguyen.DMTableResName == TableRes || tainguyen.DMTableResGroupName == TableRes)
                        return tainguyen.IsPermission;
            }
            return false;
        }
    }

    /// <summary>
    /// DUYVT: Đưa vào FW
    /// </summary>
    public interface IPermissionRes
    {
        List<TaiNguyen> getObjectResources();
    }

    /// <summary>
    /// DUYVT: Cập nhật FW - Mở rộng thêm cho class FrameworkParams
    /// </summary>
    public static class FrameworkParams
    {
        public static IPermissionRes isPermissionRes;
    }
}