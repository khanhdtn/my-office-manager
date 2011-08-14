using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtocolVN.Framework.Win;
using System.Data;
using ProtocolVN.Framework.Core;

namespace ProtocolVN.DanhMuc
{
    public class DMLoaiVanDe
    {
        public static DMLoaiVanDe I = new DMLoaiVanDe();
        public static String N = typeof(DMLoaiVanDe).FullName;
        public static bool isPermission = false;

        #region IDanhMuc Members       
        public DMLoaiVanDe() { }
        public string Item()
        {
                return
                @"<cat table='" + PL.FURL(N, "Init") + @"' type='action' picindex='newspaper.gif'>
                  <lang id='vn'>Loại vấn đề</lang>
                  <lang id='en'></lang>
                </cat>";
        }

        public string MenuItem(string MainCat, string ParentID, bool IsSep)
        {
            return MenuItem(MainCat, "Loại vấn đề", ParentID, IsSep);
        }

        public string MenuItem(string MainCat, string Title, string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(N, Title, ParentID, true,
                           PL.FURL(MainCat, N, "Init"), true, IsSep, "newspaper.gif", false, "", "");
        }

        #region Init      
       
        public DevExpress.XtraEditors.XtraUserControl Init()
        {
            DMGrid basic = new DMGrid("DM_LOAI_VAN_DE",true);
            if (isPermission) basic.DefinePermission(DanhMucParams.GetPermission(basic, N, "Danh má»¥c loáº¡i váº¥n Ä‘á»"));
            return basic;
        }

        public void InitCtrl(PLCombobox Input, bool? IsAdd)
        {
            string sql;
            if (IsAdd == true)
                sql = "SELECT ID,NAME FROM DM_LOAI_VAN_DE WHERE VISIBLE_BIT='Y' ORDER BY NAME";
            else
                sql = "SELECT ID,NAME FROM DM_LOAI_VAN_DE ORDER BY NAME";
            DataSet dsNV = HelpDB.getDatabase().LoadDataSet(sql);
            Input._init(dsNV.Tables[0], "NAME", "ID");
        }
        #endregion

        #endregion
    }
}
