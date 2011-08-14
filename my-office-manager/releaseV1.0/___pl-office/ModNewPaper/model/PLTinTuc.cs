using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace office
{
    public class PLTinTuc
    {
        #region Chọn nhóm tin tức      
        public static void ChonNhomTin(PLComboboxAdd Input, bool? IsAdd)
        {
            DataSet dsNTT;
            //true:add, false:edit, null:xem
            QueryBuilder query = new QueryBuilder("select ID,NAME from DM_NHOM_TIN_TUC WHERE 1=1");
            if (IsAdd == true)
                query.addCondition("VISIBLE_BIT='Y'");
            query.setAscOrderBy("NAME");
            dsNTT = TinTucPermission.I._LoadDataSetWithResGroupPermission(query, "ID");
            Input._init(dsNTT.Tables[0], "NAME", "ID");
        }
        public static void ChonNhomTin(PLCombobox Input, bool? IsAdd)
        {
            DataSet dsNTT;
            //true:add, false:edit, null:xem
            QueryBuilder query=new QueryBuilder("select ID,NAME from DM_NHOM_TIN_TUC WHERE 1=1");
            if (IsAdd == true)
               query.addCondition("VISIBLE_BIT='Y'");
            query.setAscOrderBy("NAME");
            dsNTT = TinTucPermission.I._LoadDataSetWithResGroupPermission(query, "ID");

            Input._init(dsNTT.Tables[0], "NAME", "ID");
        }

        public static void ChonNhomTin(PLImgCombobox Input, bool? IsAdd)
        {
            DataSet dsNTT;
            //true:add, false:edit, null:xem
            QueryBuilder query = new QueryBuilder("select ID,NAME from DM_NHOM_TIN_TUC WHERE 1=1");
            if (IsAdd == true)
                query.addCondition("VISIBLE_BIT='Y'");
            query.setAscOrderBy("NAME");
            dsNTT = TinTucPermission.I._LoadDataSetWithResGroupPermission(query, "ID");
            Input._init(dsNTT.Tables[0], "NAME", "ID");
        }
        #endregion
    }
}
