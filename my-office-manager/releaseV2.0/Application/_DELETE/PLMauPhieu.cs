using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;

namespace ProtocolVN.Framework.Win
{
    public class PLMauPhieu : IMauPhieu
    {
        public Dictionary<int, string> GetMauPhieu() {
            Dictionary<int, string> list = new Dictionary<int, string>();
            list.Add(1, "MA_PTU;tạm ứng");
            list.Add(2, "MA_PTH;thu");
            list.Add(3, "MA_PCH;chi");
            list.Add(4, "MA_PUV;hồ sơ ứng viên");
            //list.Add(5, "MA_PRV;phiếu ra vào");
            //list.Add(6, "MA_PXN;phiếu xác nhận làm việc");
            return list;
        }
    }
}
