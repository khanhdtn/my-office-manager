using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;

namespace ProtocolVN.Plugin.TimeSheet
{
    public class PLTimeSheetMenu
    {
        public static string BuildMenu(GenID G, string gRoot)
        {
            string gTimeSheet = G.NewGroup();
            StringBuilder str = new StringBuilder("");
            MenuBuilder.CreateItem(str, gTimeSheet, "Nhật ký làm việc", gRoot, true, "", true, false, "mnbToChuc.png", false, "", "", true);

            //Chức năng
            
            MenuBuilder.CreateItem(str, G.NewItem(), "Lên kế hoạch", gTimeSheet, true, typeof(frmKeHoachLamViec).FullName, false,false, "mnsNhanVien.png", false, "", "", true);

            //Theo dõi
            //MenuBuilder.CreateItem(str, G.NewItem(), "Quản lý nhật ký", gTimeSheet, true, typeof(frmTimeRecordQL).FullName, true, true, "mnsNhanVien.png", false, "", "", true);
            //MenuBuilder.CreateItem(str, G.NewItem(), "Quản lý kế hoạch", gTimeSheet, true, typeof(frmKeHoachLamViecQL).FullName, true, true, "mnsNhanVien.png", false, "", "", true);
            
            //Báo cáo
            MenuBuilder.CreateItem(str, G.NewItem(), "Báo cáo", gTimeSheet, true, typeof(frmTimeSheetReport).FullName, true, true, "mnsNhanVien.png", false, "", "", true);
            
            //Danh mục
            MenuBuilder.CreateItem(str, G.NewItem(), "Danh mục", gTimeSheet, true, typeof(frmTimeSheetDM).FullName, true, false, "mnsNhanVien.png", false, "", "", true);
            return str.ToString();
        }
    }
}
