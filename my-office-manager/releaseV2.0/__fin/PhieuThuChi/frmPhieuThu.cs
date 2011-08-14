using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;

namespace office
{
    public class frmPhieuThu : frmPhieuThuChiEdit
    {
        public frmPhieuThu() : base(true) { }
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhieuThu).FullName,
                "Tạo phiếu thu",
                ParentID, true,
                typeof(frmPhieuThu).FullName,
                false, IsSep, "add.png", true, "", "");
        }
    }
}
