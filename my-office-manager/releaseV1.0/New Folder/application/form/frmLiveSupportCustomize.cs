using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using System.IO;

namespace office
{
    public partial class frmLiveSupportCustomize :  XtraFormPL
    {
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmLiveSupportCustomize).FullName,
                "Hỗ trợ trực tuyến",
                ParentID, true,
                typeof(frmLiveSupportCustomize).FullName,
                true, IsSep, "icon_yahoo.png", true, "", "");
        }
        public frmLiveSupportCustomize()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {

            try
            {
                FileStream fs = new FileStream("Yhms.txt", FileMode.Open);
                webBrowser1.DocumentStream = fs;
            }
            catch
            {
              //  webBrowser1.DocumentText = "KHÔNG TÌM THẤY YAHOO...";
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //webBrowser1.DocumentText = memoEdit1.Text;
            webBrowser1.Refresh();
        }
      
    }
}