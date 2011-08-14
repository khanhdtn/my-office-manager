using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;

namespace office
{
    public class frmPhieuChi : frmPhieuThuChiEdit
    {
        public frmPhieuChi() : base(false) { }
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmPhieuChi).FullName,
                "Tạo phiếu chi",
                ParentID, true,
                typeof(frmPhieuChi).FullName,
                false, IsSep, "add.png", true, "", "");
        }
    }
}
