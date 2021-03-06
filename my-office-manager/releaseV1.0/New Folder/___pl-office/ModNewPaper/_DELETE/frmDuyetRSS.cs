using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using System.Net;
using System.Text.RegularExpressions;

namespace office
{
    public partial class frmDuyetRSS : XtraFormPL
    {
        #region init
        string Home = "";
        DateTime tChectLast = new DateTime();
        public frmDuyetRSS()
        {
            InitializeComponent();
        }
        private void frmDuyetRSS_Load(object sender, EventArgs e)
        {
            load_du_lieu();
            gridView1.ExpandAllGroups();
            dockManager1.DockingOptions.ShowCloseButton = false;
        }
        public void load_du_lieu()
        {
            DataSet ds = HelpDB.getDatabase().LoadDataSet(@"SELECT TM_RSS.NAME,LK_RSS.NAME,LK_RSS.ID, LINK
                                FROM DM_LIEN_KET_RSS LK_RSS INNER JOIN DM_THU_MUC_RSS TM_RSS
                                    ON LK_RSS.PHAN_LOAI = TM_RSS.ID
                                        WHERE TM_RSS.VISIBLE_BIT='Y'");
            if (ds.Tables.Count > 0)
            {

                gridControl1.DataSource = ds.Tables[0];               
            }
        }
        #endregion

        #region các hàm xử lý chính
        public string ReadRSS(string ID, string url)
        {
            string sql = "SELECT NOI_DUNG,NGAY_CAP_NHAT FROM DM_LIEN_KET_RSS WHERE ID=@ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand command = db.GetSQLStringCommand(sql);
            db.AddInParameter(command, "@ID", DbType.String, ID);
            DataSet ds = db.LoadDataSet(command);
            DateTime ngay_cap_nhat = convert_day(ds.Tables[0].Rows[0][1].ToString());
            StringBuilder sb = new StringBuilder();
            try
            {
                XmlDocument RSSXml = new XmlDocument();
                RSSXml.Load(url);

                XmlNodeList RSSNodeList = RSSXml.SelectNodes("rss/channel/item");
                XmlNode nodeLast = RSSXml.SelectSingleNode("rss/channel/item/pubDate");
                string datelass = nodeLast != null ? nodeLast.InnerText : "";
                string P_isDanTri = "dantri";
                Regex isDanTri = new Regex(P_isDanTri);
                bool dt = false; 
                if (isDanTri.IsMatch(url))
                {
                    dt = true;
                   tChectLast = convert_day2(datelass);

                }
                else
                {
                    tChectLast = convert_day(datelass);
                }           
                              
                foreach (XmlNode RSSNode in RSSNodeList)
                {
                    XmlNode RSSSubNode;
                    RSSSubNode = RSSNode.SelectSingleNode("title");
                    string title = RSSSubNode != null ? RSSSubNode.InnerText : "";
                    RSSSubNode = RSSNode.SelectSingleNode("link");
                    string link = RSSSubNode != null ? RSSSubNode.InnerText : "";
                    RSSSubNode = RSSNode.SelectSingleNode("description");
                    string desc = RSSSubNode != null ? RSSSubNode.InnerText : "";
                    RSSSubNode = RSSNode.SelectSingleNode("pubDate");
                    string pubdate = RSSSubNode != null ? RSSSubNode.InnerText : "";
                    DateTime pdate = new DateTime();
                    
                    if (dt)
                    {
                        
                        pdate = convert_day2(pubdate);
                    }
                    else
                    {
                        pdate = convert_day(pubdate);
                    }
                    if (DateTime.Compare(pdate, tChectLast) == 1)
                    {
                        tChectLast = pdate;
                    }  
                                    
                    if (DateTime.Compare(pdate, ngay_cap_nhat) == 1)
                    {                        
                        sb.Append("<font face='arial'><p><b>");                  
                        sb.Append("<font color='red'size='2'>");
                        sb.Append(title);
                        sb.Append("</font>");
                        sb.Append("<a href='");
                        sb.Append(link);
                        sb.Append("'>");
                        sb.Append("<font size='2'> xem chi tiết</a> </font>");
                        sb.Append("<br/><font size='1'>");
                        sb.Append(pdate.ToString());
                        sb.Append("<br/></font>");
                        sb.Append("</b><font size='2'>");
                        sb.Append(desc);
                        sb.Append("</p></font></font>");
                    }
                }
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
            }
            return sb.ToString();
        }
        //hàm chuyển đổi ngày
        public DateTime convert_day(string date)
        {
            DateTimeConverter con = new DateTimeConverter();

            return (DateTime)con.ConvertFromString(date);
          

        }
        public DateTime convert_day2(string date)
        {
            DateTimeConverter con = new DateTimeConverter();
            string[] mang_ngay = date.Split('/', ' ',':');
            int ngay=int.Parse(mang_ngay[1]);
            int thang=int.Parse(mang_ngay[0]);
            int nam=int.Parse(mang_ngay[2]);
            int gio = int.Parse(mang_ngay[3]);
            int phut = int.Parse(mang_ngay[4]);
            int giay = int.Parse(mang_ngay[5]);
            if (mang_ngay[6] == "PM")
            {
                gio += 12;
            }
            DateTime kq = new DateTime(nam,thang,ngay,gio,phut,giay);
            return kq;         
         }

        // kết hợp rss cũ và mới
        public string RSS_new_old(string ID, string url)
        {
            string tin_moi = "";
            //kiem tra ket noi internet
            if (Connected())
            {
                
                tin_moi = ReadRSS(ID, url);
            }
            

            string tin_da_luu;
            string sql = "SELECT NOI_DUNG FROM DM_LIEN_KET_RSS WHERE ID=@ID";
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand command = db.GetSQLStringCommand(sql);
            db.AddInParameter(command, "@ID", DbType.Int32, int.Parse(ID));
            DataSet ds = db.LoadDataSet(command);
            if (ds.Tables[0].Rows[0][0].ToString() == "")
                tin_da_luu = "";
            else
                tin_da_luu = HelpByte.BytesToUTF8String((byte[])ds.Tables[0].Rows[0][0]);
            string tin_tong_hop = tin_moi + tin_da_luu;
            if (tin_moi != "")
            {
                SaveRSS(ID, tin_tong_hop);
            }
            return tin_tong_hop;
        }

        //kiểm tra địa chỉ
        public string TestURL(ref string url)
        {
            string patern = "^http://";
            Regex re = new Regex(patern);
            if (re.IsMatch(url))
                return url;
            else
            {
                MessageBox.Show("http://" + url);
                return "http://" + url;

            }

        }

        #endregion

        #region lưu xuống database
        public void SaveRSS(string ID, string noi_dung)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand command = db.GetStoredProcCommand("UPDATE_RSS");
            db.AddInParameter(command, "@ID", DbType.Int32, int.Parse(ID));
            db.AddInParameter(command, "@NOI_DUNG", DbType.Byte, HelpByte.UTF8StringToBytes(noi_dung));
            db.AddInParameter(command, "@NGAY_CAP_NHAT", DbType.DateTime, tChectLast);
            db.ExecuteNonQuery(command);
        }        
        #endregion

        #region xử lý sự kiện
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            webBrowser1.AllowNavigation = true;
            DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string url = r["LINK"].ToString();
            string ID = r["ID"].ToString();
            WaitingMsg m = new WaitingMsg();
            string strWeb = RSS_new_old(ID, url);
            if (strWeb == "")
                webBrowser1.DocumentText = "Chưa có dữ liệu và tin mới cho mục này";
            else
            {
                webBrowser1.DocumentText = strWeb;
                Home = strWeb;                
            }
            m.Finish();

        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.ToString() != "about:blank")
            {
                //webBrowser1.Stop();
                frmWebBrowser frm = new frmWebBrowser(e.Url.ToString());
                frm.Show();
                webBrowser1.AllowNavigation = false;
                webBrowser1.DocumentText = Home;
                webBrowser1.AllowNavigation = true;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            string ID = r["ID"].ToString();
            tChectLast = DateTime.Now;
            if (HelpMsgBox.ShowConfirmMessage("Xóa các mục tin RSS này trong cơ sở dữ liệu") == DialogResult.Yes)
            {
                SaveRSS(ID, "");
                HelpMsgBox.ShowNotificationMessage("Đã xóa RSS trong cơ sở dữ liệu");
                webBrowser1.DocumentText = "Chưa có tin mới và dữ liệu cho mục này";
                
            }
        }
        #endregion     

        #region kiểm tra kết nối internet
        private bool IsNetworkConnected()
        {
            bool connected = SystemInformation.Network;
            if (connected)
            {
                connected = false;
                System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher("SELECT NetConnectionStatus FROM Win32_NetworkAdapter");
                foreach (System.Management.ManagementObject networkAdapter in searcher.Get())
                {
                    if (networkAdapter["NetConnectionStatus"] != null)
                    {
                        if (Convert.ToInt32(networkAdapter["NetConnectionStatus"]).Equals(2))
                        {
                            connected = true;
                            break;
                        }
                    }
                }
                searcher.Dispose();
            }
            return connected;
        }
        //kiem tra ket noi internet
        private bool Connected()
        {
            bool iscon = false;
            string hostname = "www.google.com";
            try
            {
                
                IPAddress[] addrs = Dns.GetHostEntry(hostname).AddressList;
                if (addrs.Length > 0)
                    iscon = true;
            }
            catch (Exception)
            {
                iscon = false;
            }
            return iscon;

        }

        #endregion

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        
        }


    }
}