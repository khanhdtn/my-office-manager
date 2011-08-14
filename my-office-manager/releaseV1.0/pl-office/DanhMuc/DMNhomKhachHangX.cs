using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace ProtocolVN.DanhMuc
{
    public class DMNhomKhachHangX : IDanhMuc
    {
        public static DMNhomKhachHangX I = new DMNhomKhachHangX();
        public static String N = typeof(DMNhomKhachHangX).FullName;
        public static bool isPermission = false;
        #region IDanhMuc Members

        public string Item()
        {
            return
            @"<cat table='" + PL.FURL(N, "Init") + @"' type='action' picindex='navPhongBan.png'>
              <lang id='vn'>Nhóm khách hàng</lang>
              <lang id='en'></lang>
            </cat>";
        }

        public string MenuItem(string MainCat, string ParentID, bool IsSep)
        {
            return MenuItem(MainCat, "Nhóm khách hàng", ParentID, IsSep);
        }

        public string MenuItem(string MainCat, string Title, string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(N, Title, ParentID, true,
                           PL.FURL(MainCat, N, "Init"), true, IsSep, "navPhongBan.png", false, "", "");
        }

        #region Init

        public DevExpress.XtraEditors.XtraUserControl Init()
        {
            DMTreeGroup dmTree = new DMTreeGroup();
            dmTree.Init(GroupElementType.ONLY_INPUT, "DM_KHACH_HANG_NHOM", "ID", "ID_CHA",
                new string[] { "NAME" }, new String[] { "Tên nhóm" }, HelpGen.G_FW_DM_ID,
                null,
                new FieldNameCheck[] { 
                    new FieldNameCheck("NAME",
                        new CheckType[]{ CheckType.Required, CheckType.RequireMaxLength },
                        "Tên nhóm", 
                    new object[]{ null, 200 })
                }
            );
            if (isPermission) dmTree.DefinePermission(DanhMucParams.GetPermission(dmTree, N, "Danh má»¥c Nhóm Khách hàng"));
            return dmTree;
        }
        #endregion

        #endregion
    }
}
