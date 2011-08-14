using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;

namespace office
{
    public class frmConfigCode : frmCauHinhMauPhieu
    {
        #region Khai báo MenuItem
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmConfigCode).FullName,
                "Câu hình mẫu phiếu",
                ParentID, true,
                typeof(frmConfigCode).FullName,
                false, IsSep, "", true, "", "");
        }
        #endregion
        public override void InitList()
        {
            this.ListMaPhieu = new Dictionary<int, string>();
            this.ListMaPhieu.Add(1, "MA_PTU;tạm ứng");
            this.ListMaPhieu.Add(2, "MA_PTH;thu");
            this.ListMaPhieu.Add(3, "MA_PCH;chi");
            this.ListMaPhieu.Add(4, "MA_PUV;hồ sơ ứng viên");
        }
    }
}
