using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;

namespace office
{
    public partial class frmLiveSupport :  XtraFormPL
    {
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmLiveSupport).FullName,
                "Hỗ trợ từ PROTOCOL",
                ParentID, true,
                typeof(frmLiveSupport).FullName,
                true, IsSep, "yahoo.png", true, "", "");
        }
        public frmLiveSupport()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            string text = @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"">
                        <!-- saved from url=(0014)about:internet -->
                        <html xmlns=""http://www.w3.org/1999/xhtml"" xml:lang=""en"" lang=""en"">                               
                            <body> 
                                <div align=""center"">
 		                         <object classid=""clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"" 
                                        codebase=""http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0""  width=""50%"" height=""100%"">
                                         <param name=""movie"" value=""http://wgweb.msg.yahoo.com/badge/Pingbox.swf"" />
                                         <param name=""quality"" value=""high"" />
                                         <param name=""wmode"" value=""transparent"" />
		                                 <param name=""flashvars"" value=""wid=GCFiEF.wRywLWhTnoyZnvhrorile""
                                         <embed src=""http://wgweb.msg.yahoo.com/badge/Pingbox.swf""  width=""50%"" height=""100% quality=""high""
		                                        pluginspage=""http://www.macromedia.com/go/getflashplayer"" 
		                                        type=""application/x-shockwave-flash""
		                                         wmode=""transparent"">
                                           </embed>
                                 </object>    
                                </div>                             
                            </body>
                        </html>";

           
            webBrowser1.DocumentText = text;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //webBrowser1.DocumentText = memoEdit1.Text;
            webBrowser1.Refresh();
        }
      
    }
}