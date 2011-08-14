using System.Data;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace office
{
    public class PLDienDan
    {
        public static void InitChonDienDan(PLCombobox PLDien_Dan, bool? IsAdd)
        {
            QueryBuilder query = null;
            string sql = "";
            if (DienDanPermission.I.IsPermission)
            {
                string ndds = DienDanPermission.I._getPermissionResGroupStrIDs(PermissionOfResource.RES_PERMISSION_TYPE.READ);
                if (ndds == "") ndds = "-1";
                string ncms = DienDanPermission.I._getPermissionResStrIDs(PermissionOfResource.RES_PERMISSION_TYPE.READ);
                if (ncms == "") ncms = "-1";
                sql = @"select *
                        from nhom_dien_dan ndd where (ndd.id in (" + ndds + @")
                        or ndd.id in (select cm.id_nhom_dien_dan from chuyen_muc cm where cm.id in(" + ncms + "))) " + (IsAdd == true ? " AND VISIBLE_BIT='Y'" : "") + " and  ID<>ID_ROOT  and 1=1 ";
            }
            else
            {
                sql = "SELECT * FROM NHOM_DIEN_DAN where ID_CHA<>0 " + (IsAdd == true ? " AND VISIBLE_BIT='Y'" : "") + " and 1=1";


            }
            
            DataSet ds = HelpDB.getDatabase().LoadDataSet(sql);
            PLDien_Dan._init(ds.Tables[0], "NAME", "ID");
        }
        public static void InitChonDienDan(PLComboboxAdd PLDien_Dan,bool? IsAdd)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT * FROM NHOM_DIEN_DAN where  ID_CHA<>0 " + (IsAdd == true ? " AND VISIBLE_BIT='Y'" : "") + " and 1=1");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            PLDien_Dan._init(ds.Tables[0], "NAME", "ID");
        }
        public static void InitChonChuyenMuc(PLCombobox PLChuyenMuc,bool? IsAdd)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT * FROM CHUYEN_MUC where 1=1 " + (IsAdd == true ? " AND VISIBLE_BIT='Y'" : "") + " and 1=1");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            PLChuyenMuc._init(ds.Tables[0], "NAME", "ID");
        }
        public static void InitChonChuyenMuc(PLComboboxAdd PLChuyenMuc,long ID_Dien_Dan)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT * FROM CHUYEN_MUC where CHUYEN_MUC.VISIBLE_BIT='Y' AND ID_NHOM_DIEN_DAN=" + ID_Dien_Dan +" and 1=1" );
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            PLChuyenMuc._init(ds.Tables[0], "NAME", "ID");
        }
        public static void InitChonChuyenMuc(PLCombobox PLChuyenMuc, long ID_Dien_Dan)
        {
            QueryBuilder query = null;
            query = new QueryBuilder("SELECT * FROM CHUYEN_MUC where 1=1");
            query.addCondition("VISIBLE_BIT='Y'");
            query.addID("ID_NHOM_DIEN_DAN", ID_Dien_Dan);
            DataSet ds = DienDanPermission.I._LoadDataSetWithResPermission(query, "ID");
            PLChuyenMuc._init(ds.Tables[0], "NAME", "ID");
        }
    }
}
