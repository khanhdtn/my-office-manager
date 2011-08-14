using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using System.Data;

namespace ProtocolVN.DanhMuc
{
    public class DMVanDeGopY : IDanhMuc
    {

        public static string TABLE_MAP = "DM_VAN_DE_GOP_Y";
        public static DMVanDeGopY I = new DMVanDeGopY();
        public static bool isPermission = false;
        public static string N = typeof(DMVanDeGopY).FullName;

        public DMVanDeGopY() { }

        #region IDanhMuc Members

        public DevExpress.XtraEditors.XtraUserControl Init()
        {
            DMGrid basic = new DMGrid(TABLE_MAP, true);
            if (isPermission) basic.DefinePermission(DanhMucParams.GetPermission(basic, N, "NhÃ³m gÃ³p Ã½"));
            return basic;
        }

        public string Item()
        {
            return
            @"<cat table='" + ProtocolVN.DanhMuc.PL.FURL(N, "Init") + @"' type='action' picindex='Document.png'>
                  <lang id='vn'>Vấn đề góp ý</lang>
                  <lang id='en'></lang>
                </cat>";
        }

        public string MenuItem(string MainCat, string ParentID, bool IsSep)
        {
            return MenuItem(MainCat, "Vấn đề góp ý", ParentID, IsSep);
        }

        public string MenuItem(string MainCat, string Title, string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(N, Title, ParentID, true,
                           ProtocolVN.DanhMuc.PL.FURL(MainCat, N, "Init"), true, IsSep, "Document.png", false, "", "");
        }
        public void InitCtrl(PLComboboxAdd Input, bool? IsAdd)
        {
            QueryBuilder query = null;
            if (IsAdd == true)
                query = new QueryBuilder("SELECT * FROM DM_VAN_DE_GOP_Y where VISIBLE_BIT = 'Y' AND 1=1");
            else
                query = new QueryBuilder("SELECT * FROM DM_VAN_DE_GOP_Y where 1=1");
            query.setAscOrderBy("NAME");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
        }

        public void InitCtrl(PLCombobox Input, bool? IsAdd)
        {
            QueryBuilder query = null;
            if (IsAdd == true)
                query = new QueryBuilder("SELECT * FROM DM_VAN_DE_GOP_Y where VISIBLE_BIT = 'Y' AND 1=1");
            else
                query = new QueryBuilder("SELECT * FROM DM_VAN_DE_GOP_Y where 1=1");
            query.setAscOrderBy("NAME");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            Input._init(ds.Tables[0], "NAME", "ID");
        }
        #endregion
    }
}
