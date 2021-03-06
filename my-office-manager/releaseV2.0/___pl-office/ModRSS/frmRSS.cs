using System.Data;
using DevExpress.XtraGrid.Columns;
using ProtocolVN.Framework.Core;
using System;
using System.Text;
using System.Data.Common;
using System.Xml;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Net;
using DevExpress.XtraBars.Demos.BrowserDemo;
using System.Windows.Forms;
using office;
namespace ProtocolVN.Framework.Win
{
    public partial class frmRSS : PhieuQuanLyChange1N,IFormRefresh
    {
        //#region Các biến của form Quan Ly Tuyệt đối không thay đổi
        //public DevExpress.XtraBars.BarManager barManager1;
        //public DevExpress.XtraBars.Bar MainBar;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        //public DevExpress.XtraBars.BarDockControl barDockControlTop;
        //public DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //public DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //public DevExpress.XtraBars.BarDockControl barDockControlRight;
        //public DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        //public DevExpress.XtraGrid.GridControl gridControlMaster;
        //public DevExpress.XtraGrid.Views.Grid.PLGridView gridViewMaster;
        //public DevExpress.XtraTab.XtraTabControl xtraTabControlDetail;
        //public DevExpress.XtraBars.PopupControlContainer popupControlContainerFilter;
        //public DevExpress.XtraBars.BarStaticItem barStaticItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem2;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemCommit;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemNoCommit;
        //public DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        //public DevExpress.XtraBars.BarSubItem barSubItem1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemXem;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        //public DevExpress.XtraBars.PopupMenu popupMenuFilter;
        //public DevExpress.XtraBars.BarCheckItem barCheckItemFilter;
        //public DevExpress.XtraBars.BarButtonItem barButtonItemSearch;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem3;
        //public DevExpress.XtraBars.PopupMenu popupMenu1;
        //public DevExpress.XtraBars.BarButtonItem barButtonItem4;
        //#endregion

        #region Vùng đặt Static
        public static FormStatus Status = FormStatus.OK_DEV;
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmRSS).FullName,
                PMSupport.UpdateTitle("Tin tổng hợp RSS", Status),
                ParentID, true,
                typeof(frmRSS).FullName,
                true, IsSep, "Rss.png", true, "", "");
        }
        #endregion

        private string HomeRSS = "";

        public frmRSS()
        {
            InitializeComponent();
            this.DisplayField = "NAME";
            this.IDField = "ID";
            this.Text = "Tin tổng hợp RSS";
            this._UsingExportToFileItem = false;
            new PhieuQuanLyFix1N(this);
            HelpGridExt1.DisableCaptionGroupCol(gridViewMaster);
            this.gridControlMaster.BackgroundImage = null;
        }

        /// <summary>Step 1: Xác định các cột sẽ hiển thị trong phần master gridView 
        /// Chú ý không được khởi tạo qua phần giao diện kéo thả ( Chỉ Viết Code )
        /// </summary>
        public override void InitColumnMaster()
        {
            HelpGridColumn.CotTextLeft(this.cotID, "ID");
            HelpGridColumn.CotTextLeft(this.cotTen, "NAME");
            HelpGridColumn.CotTextLeft(cotTenNhom, "GROUP_NAME");
            HelpGridColumn.CotTextLeft(cotLink, "LINK");
        }

        /// <summary>Step 2: Xác định các cột sẽ hiển thị trong phần detail  
        /// Chú ý không được khởi tạo qua phần giao diện kéo thả ( Chỉ Viết Code )
        /// </summary>
        public override void InitColumDetail()
        {
                     
        }

        /// <summary>Step 3: Xác định các control trong filter part và Khởi tạo control trong phần filter.
        /// Các control trong phần filter này là những control chỉ chọn
        /// </summary>
        public override void PLLoadFilterPart()
        {
            //Ẩn các nút không sử dụng đến
            this.popupControlContainerFilter.Visible = false;
            this.splitContainerControl1.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Panel2.Visible = false;
            //this.barButtonItemXem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemSearch.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //Thay đổi cần thiết để đáp ứng
            this.barButtonItemUpdate.Caption = "&Cập nhật tin";
            this.barButtonItemAdd.Caption = "&Xóa tin";
            this.barButtonItemAdd.Glyph = FWImageDic.DELETE_IMAGE16;
            this.barButtonItemXem.Caption = "&In...";
            this.barButtonItemXem.Glyph = FWImageDic.PRINT_IMAGE16;
            this.gridViewMaster.OptionsBehavior.AutoExpandAllGroups = true;
            this.dockPanel1.Options.ShowCloseButton = false;
            this.gridViewMaster.OptionsSelection.MultiSelect = false;
            this.gridViewMaster.OptionsView.ShowIndicator = false;
            this.gridControlMaster.EmbeddedNavigator.TextStringFormat = "";

            //Load dữ liệu ngay khi load form không cần nhấn tìm kiếm
            FWDBService db = HelpDB.getDBService();
            this.PLBuildQueryFilter();
            this.webBrowserRSS.Visible = true;

            //Sự kiện cho webBrowserRSS
            this.webBrowserRSS.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(webBrowserRSS_Navigated);
        }


        #region Step 4 - Cài đặt menu
        public override _MenuItem GetBusinessMenuList()
        {
            return null;
        }

        public override _MenuItem GetMenuAppendGridList()
        {
            return null;
        }
        #endregion

        /// <summary>Step 5: Xây dựng Query Buider cho việc tìm kiếm
        /// Xây dựng một QueryBuilder từ những chọn lựa trong phần filter.
        /// Từ QueryBuilder này ta có thể lấy được dữ liệu thỏa điều kiện.
        /// Nếu hỗ trợ duyệt thì trong câu truy vấn trả về 
        /// phải có cột là DUYET_BIT
        /// </summary>
        public override QueryBuilder PLBuildQueryFilter()
        {
            QueryBuilder query = new QueryBuilder(this.UpdateRow());    
            query.addCondition("(1=1)");
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
            if (ds != null && ds.Tables.Count > 0)
                gridControlMaster.DataSource = ds.Tables[0];
            return null;
        }

        #region Step 7: Xác định các form xử lý khi chọn Thêm, Xem , Sửa

        public override void ShowViewForm(long id)
        {
            //NOOP : Tận dụng nút xem để tạo thành nút xóa. Lý do là ko xóa dữ liệu trên lưới mà chỉ xóa dữ liệu trong webBrowserRSS
            //in nội dung.....
             webBrowserRSS.ShowPrintPreviewDialog();

        }

        public override void ShowUpdateForm(long id)
        {
            DataRow dr = this.gridViewMaster.GetDataRow(this.gridViewMaster.FocusedRowHandle);
            if (dr == null) return;
           
            this.LoadRSS(HelpNumber.ParseInt64(dr["ID"]), true);
            //NOOP
        }

        public override long[] ShowAddForm()
        {
            //NOOP
            DataRow dr = this.gridViewMaster.GetDataRow(this.gridViewMaster.FocusedRowHandle);
            if (dr == null) return null;
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn xóa tin tức thuộc \"" + dr["NAME"].ToString() + "\" ?") == System.Windows.Forms.DialogResult.Yes)
            {               
                if (this.SetRSS(HelpNumber.ParseInt64(dr["ID"]), "", HelpDB.getDBService().GetSystemCurrentDateTime(),"Y"))
                    this.webBrowserRSS.DocumentText = "Vui lòng cập nhật tin mới.";
            }
            return null;
        }

        #endregion

        #region Step 8 : Xác định các hành động trên form
        /// <summary>Thực hiện câu lệnh để xóa phiếu có id = id 
        /// </summary>        
        public override bool XoaAction(long id)
        {
            return true;
        }

        /// <summary>Cấu hình thông tin In
        /// </summary>        
        public override _Print InAction(long []ids)
        {
            return null;
        }
        #endregion

        public override DataTable[] PLLoadDataDetailParts(long MasterID)
        {
            this.LoadRSS(MasterID, false);
            return null;
        }

        public override string UpdateRow()
        {
            return @"SELECT DM_THU_MUC_RSS.NAME AS GROUP_NAME,
                                                DM_LIEN_KET_RSS.NAME AS NAME,
                                                DM_LIEN_KET_RSS.ID,LINK 
                                       FROM DM_LIEN_KET_RSS, DM_THU_MUC_RSS 
                                       WHERE    DM_LIEN_KET_RSS.PHAN_LOAI=DM_THU_MUC_RSS.ID 
                                                AND DM_LIEN_KET_RSS.VISIBLE_BIT ='Y' 
                                                AND DM_THU_MUC_RSS.VISIBLE_BIT ='Y'
                                                AND 1=1";
        }

        #region CHAUTV: Các xử lý RSS

        void webBrowserRSS_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        {
            if (e.Url.ToString() != "about:blank")
            {
                bool NewTab = true;
                foreach (System.Windows.Forms.Form item in FrameworkParams.MainForm.MdiChildren)
                {
                    if (item is frmWebBrowser) {
                        ((frmWebBrowser)item)._Browser.Navigate(e.Url.ToString());
                        item.Activate();
                        NewTab = false;
                        break;
                    }
                }
                if (NewTab)
                {
                    frmWebBrowser frm = new frmWebBrowser(e.Url.ToString());
                    frm.Text = "Trình duyệt web";
                    HelpProtocolForm.ShowWindow(FrameworkParams.MainForm, frm, false);
                }
                this.webBrowserRSS.AllowNavigation = false;
                this.webBrowserRSS.DocumentText = HomeRSS;
                this.webBrowserRSS.AllowNavigation = true;
            }
        }

        public DateTime ConverterDate(string date,bool None)
        {
            DateTimeConverter con = new DateTimeConverter();
            if (None)
            {
                if (date.Contains("CH")) date = date.Replace("CH", "PM");
                if (date.Contains("SA")) date = date.Replace("SA", "AM");
                return (DateTime)con.ConvertFromString(date);
            }
            //Ngược lại
            string[] mang_ngay = date.Split('/', ' ', ':');
            int ngay = int.Parse(mang_ngay[1]);
            int thang = int.Parse(mang_ngay[0]);
            int nam = int.Parse(mang_ngay[2]);
            int gio = int.Parse(mang_ngay[3]);
            int phut = int.Parse(mang_ngay[4]);
            int giay = int.Parse(mang_ngay[5]);
            if (mang_ngay[6] == "PM" && gio != 12)
            {
                gio += 12;
            }
            DateTime kq = new DateTime(nam, thang, ngay, gio, phut, giay);
            return kq;
        }

        /// <summary>
        /// Lấy RSS từ DB|Net
        /// </summary>
        public string GetRSS(Int64 IDKey, string URL, bool IsUpdateNew) 
        {
            StringBuilder builder = new StringBuilder();
            QueryBuilder query = new QueryBuilder("SELECT NOI_DUNG FROM DM_LIEN_KET_RSS WHERE 1=1");
            query.addID("ID", IDKey);
            DataSet dsRSS = HelpDB.getDBService().LoadDataSet(query);
            DateTime checkLast = HelpDB.getDBService().GetSystemCurrentDateTime();

            //Lấy tin mới trên Net
            if (IsUpdateNew && this.Connected())
            {
                string newRSS = this.ReadRSSFromNet(IDKey, URL, ref checkLast);
                builder.Append(newRSS);
            }
            //Lấy tin có sẵn trong DB
            if ( dsRSS.Tables[0].Rows.Count==0 || dsRSS.Tables[0].Rows[0]["NOI_DUNG"] == DBNull.Value || dsRSS.Tables[0].Rows[0]["NOI_DUNG"].ToString() == "")
                builder.Append("");
            else
                builder.Append(HelpByte.BytesToUTF8String((byte[])dsRSS.Tables[0].Rows[0]["NOI_DUNG"]));

            //Save tin
            if (IsUpdateNew && this.Connected())
                this.SetRSS(IDKey, builder.ToString(), checkLast, "N");
            return builder.ToString();
        }

        /// <summary>
        /// Lấy RSS từ Internet
        /// </summary>
        public string ReadRSSFromNet(Int64 IDKey, string URL,ref DateTime checkLast)
        {
            FWDBService db = HelpDB.getDBService();
            DbCommand command = db.GetSQLStringCommand("SELECT NOI_DUNG,NGAY_CAP_NHAT FROM DM_LIEN_KET_RSS WHERE ID=@ID");
            db.AddInParameter(command, "@ID", DbType.Int64, IDKey);
            DataSet ds = db.LoadDataSet(command);
            DateTime NGAY_CAP_NHAT = ConverterDate(ds.Tables[0].Rows[0]["NGAY_CAP_NHAT"].ToString(),true);
            StringBuilder sb = new StringBuilder();
            try
            {
                XmlDocument RSSXml = new XmlDocument();
                RSSXml.Load(URL);
                XmlNodeList RSSNodeList = RSSXml.SelectNodes("rss/channel/item");
                XmlNode nodeLast = RSSXml.SelectSingleNode("rss/channel/item/pubDate");
                if (nodeLast == null) nodeLast = RSSXml.SelectSingleNode("rss/channel/item/pubdate");
                string datelass = nodeLast != null ? nodeLast.InnerText : "";
                string P_isDanTri = "dantri";
                Regex isDanTri = new Regex(P_isDanTri);
                bool dt = false;
                if (isDanTri.IsMatch(URL))
                {
                    dt = true;
                    checkLast = ConverterDate(datelass,false);
                }
                else
                {
                    checkLast = ConverterDate(datelass, true);
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
                    if (RSSSubNode == null) RSSSubNode = RSSNode.SelectSingleNode("pubdate");
                    string pubdate = RSSSubNode != null ? RSSSubNode.InnerText : "";
                    DateTime pdate = new DateTime();

                    if (dt)
                    {
                        pdate = ConverterDate(pubdate,false);
                    }
                    else
                    {
                        pdate = ConverterDate(pubdate,true);
                    }
                    if (DateTime.Compare(pdate, checkLast) == 1)
                    {
                        checkLast = pdate;
                    }

                    if (DateTime.Compare(pdate, NGAY_CAP_NHAT) == 1)
                    {
                        sb.Append("<font face='arial'><p><b>");
                        sb.Append("<font color='red'size='2'>");
                        sb.Append(title);
                        sb.Append("</font>");
                        sb.Append("<font size='2'><a href='");
                        sb.Append(link);
                        sb.Append("'>");
                        sb.Append(" xem chi tiết</a></font><br/>");
                        sb.Append("<font size='1'>");
                        sb.Append(pdate.ToString());
                        sb.Append("</font><br/>");
                        sb.Append("</b>");
                        sb.Append(GetDescription(desc));
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
        //DATHQ
        private string GetDescription(string desription) {
            
            //Converts HTMT to Text
            Regex reg = new Regex("<[^>]*>");
            StringBuilder strContext = new StringBuilder(reg.Replace(desription, ""));
            strContext = strContext.Replace("&nbsp;", " ");
            //--------------------
            //Gets link of image
            string linkImage = string.Empty;
            if (desription.Contains("<img"))
            {
                //Gets position of "scr"
                int imgPosition = desription.IndexOf("src=");
                //Gets link of "scr"
                linkImage = desription.Substring(imgPosition);
                linkImage = linkImage.Substring(0, linkImage.IndexOf(">"));
                //if images tag ends with ">", remove char '/'.
                if (linkImage.LastIndexOf('/') == linkImage.Length - 1) 
                    linkImage = linkImage.Remove(linkImage.Length - 1);
            }
            //--------------------
            string formatString = string.Empty;
            if (linkImage.Length > 0)
                formatString = string.Format(@"<img style='width:81px;height:72px' {0} align='left' style='margin-right:5px'/> 
                    <div style='float:center; height:72px'><font size='2'>{1}</font></div>", linkImage, strContext);
            else
                formatString = string.Format("<div style='float:center; height:45px'><font size='2'>{0}</font></div>", strContext);
            return formatString;
        }

        /// <summary>
        /// Save RSS
        /// </summary>
        public bool SetRSS(Int64 IDKey, string strRSS,DateTime checkLast,string isDelete)
        {
            try
            {
                FWDBService db = HelpDB.getDBService();
                DbCommand command = db.GetStoredProcCommand("UPDATE_RSS");
                db.AddInParameter(command, "@ID", DbType.Int64, IDKey);
                db.AddInParameter(command, "@NOI_DUNG", DbType.Byte, HelpByte.UTF8StringToBytes(strRSS));
                db.AddInParameter(command, "@NGAY_CAP_NHAT", DbType.DateTime, checkLast);
                db.AddInParameter(command, "@IS_DELETE", DbType.String, isDelete);
                db.ExecuteNonQuery(command);
                return true;
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                return false;
            }
        }

        /// <summary>
        /// Load RSS
        /// </summary>
        public void LoadRSS(Int64 IDKey, bool UpdateNew) {
            FrameworkParams.wait = new FWWaitingMsg();
            try
            {
                //Hiển thị dữ liệu khi Click vào lưới Master để hiển thị tin tức
                this.webBrowserRSS.AllowNavigation = true;
                DataRow dr = this.gridViewMaster.GetDataRow(this.gridViewMaster.FocusedRowHandle);
                string strRSS = this.GetRSS(IDKey, dr["LINK"].ToString(), UpdateNew);
                if (strRSS == "")
                    this.webBrowserRSS.DocumentText = "Vui lòng cập nhật tin mới.";
                else
                {
                    this.webBrowserRSS.DocumentText = strRSS;
                    this.HomeRSS = strRSS;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (FrameworkParams.wait != null)
                    FrameworkParams.wait.Finish();
            }
        }

        /// <summary>
        /// Kiểm tra kết nối Net
        /// </summary>
        /// <returns></returns>
        private bool Connected()
        {
            bool bFlag = false;
            string hostname = "www.google.com";
            try
            {
                IPAddress[] addrs = Dns.GetHostEntry(hostname).AddressList;
                if (addrs.Length > 0)
                    bFlag = true;
            }
            catch (Exception)
            {
                bFlag = false;
            }
            return bFlag;
        }
        #endregion

        #region IFormRefresh Members

        public object _RefreshAction(params object[] input)
        {
            FWDBService db = HelpDB.getDBService();
            this.gridControlMaster.DataSource = db.LoadDataSet(this.PLBuildQueryFilter()).Tables[0];
            return null;
        }

        #endregion
    }
}