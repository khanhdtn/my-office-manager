using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;

namespace office
{
    public class frmTaiLieuPermission : frmPhanQuyenNhanVienTaiNguyen
    {
        public frmTaiLieuPermission() : base(LoaiTaiLieu_TaiLieu.I, "Phân quyền Nhân viên - Tài liệu") { }
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmTaiLieuPermission).FullName,
                "Phân quyền NV - TL",
                ParentID, true,
                typeof(frmTaiLieuPermission).FullName,
                true, IsSep, "mnsKhoaMoSo.png", true, "", "");
        }
    }
}
