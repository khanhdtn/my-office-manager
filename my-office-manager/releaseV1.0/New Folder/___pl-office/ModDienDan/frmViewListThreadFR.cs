using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAO;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

using office;
using office.Training.ModDienDan;
using DTO;

namespace office.Training.ModTinTuc
{
    public partial class frmViewListThreadFR : XtraFormPL
    {
        #region Các khai báo biến
        private long _ChuyenMuc_ID;
        private long BaiVietGocID;
        private long _NhomDD_ID;
        string _NhomDienDan = string.Empty;
        string _ChuyenMuc = string.Empty;
        private string _TieuDe = string.Empty;
        private long NguoiTaoBaiVietGoc;
        private int DefaultWidth;
        private ucBaiViet ucBaiVietGoc;
        List<ucBaiViet> listUCBV;

        public delegate void UpdateNumberOfAnswer(bool isIncrease);
        public event UpdateNumberOfAnswer _UpdateNumberOfAnswer;
        #endregion

        #region Hàm khởi tạo
        public frmViewListThreadFR(long ID, string NhomDienDan, string ChuyenMuc, long ChuyenMuc_ID, long NhomDD_ID, string TieuDe)
        {
            InitializeComponent();
            DienDanPermission.I.Init();
            listUCBV = new List<ucBaiViet>();
            BaiVietGocID = ID;
            _NhomDD_ID = NhomDD_ID;
            _NhomDienDan = NhomDienDan;
            _ChuyenMuc = ChuyenMuc;
            _ChuyenMuc_ID = ChuyenMuc_ID;
            _TieuDe = TieuDe;
            Load_bai_viet();
        }

        public frmViewListThreadFR()
        {
            InitializeComponent();
            DienDanPermission.I.Init();
        }
        #endregion

        #region Sự kiện Form và controls
        private void frmCapNhat_Load(object sender, EventArgs e)
        {
            DefaultWidth = flowLayoutPanel1.Width -15;
            foreach (ucBaiViet uc in listUCBV)
            {
                uc.Width = DefaultWidth;
                uc.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                flowLayoutPanel1.Controls.Add(uc);
            }
        }

        private void btnTL_Click_1(object sender, EventArgs e)
        {
            HelpXtraForm.CloseFormNoConfirm(this);
        }
        private void btn_TL_Click(object sender, EventArgs e)
        {
            frmReplyForum frm = new frmReplyForum(ucBaiVietGoc.DoBaiViet, true);
            frm.AfterAddSuccesfully += delegate(DTO.DOBaiViet BaiViet)
            {
                office.Training.ModDienDan.ucBaiViet baiViet = new office.Training.ModDienDan.ucBaiViet(this,
                NguoiTaoBaiVietGoc, BaiViet);
                baiViet.AfterDeleteSuccessfully += new office.Training.ModDienDan.ucBaiViet._AfterDeleteSuccessfully(baiViet_AfterDeleteSuccessfully);
                baiViet.AfterReplySuccessFully += new ucBaiViet._AfterReplySuccessFully(baiViet_AfterReplySuccessFully);
                flowLayoutPanel1.Controls.Add(baiViet);
                baiViet.Width = DefaultWidth;
                xtraScrollableControl1.ScrollControlIntoView(baiViet);
                DABaiViet.Instance.Update_TANG_SO_LAN_TRA_LOI(BaiVietGocID);
                if (_UpdateNumberOfAnswer != null) _UpdateNumberOfAnswer(true);
            };
            ProtocolForm.ShowModalDialog(this, frm);
        }

        private void baiViet_AfterReplySuccessFully(DTO.DOBaiViet BaiViet)
        {
            ucBaiViet newBaiViet = new ucBaiViet(this, NguoiTaoBaiVietGoc, BaiViet);
            DABaiViet.Instance.Update_TANG_SO_LAN_TRA_LOI(BaiVietGocID);
            newBaiViet.AfterDeleteSuccessfully += new ucBaiViet._AfterDeleteSuccessfully(baiViet_AfterDeleteSuccessfully);
            newBaiViet.AfterReplySuccessFully += new ucBaiViet._AfterReplySuccessFully(baiViet_AfterReplySuccessFully);
            newBaiViet.Width = DefaultWidth;
            newBaiViet.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(newBaiViet);
        }        

        private void baiViet_AfterDeleteSuccessfully(office.Training.ModDienDan.ucBaiViet sender)
        {
            DABaiViet.Instance.Update_GIAM_SO_LAN_TRA_LOI(BaiVietGocID);
            if (_UpdateNumberOfAnswer != null) _UpdateNumberOfAnswer(false);
            if (sender.DoBaiViet.ID == BaiVietGocID)
                HelpXtraForm.CloseFormNoConfirm(this);
        }
        private void ucBaiVietGoc_AfterUpdateSuccessfully(ucBaiViet sender)
        {
            string oldtext = _NhomDienDan + "/" + _ChuyenMuc;
            this._TieuDe = sender.DoBaiViet.CHU_DE;
            if (this._NhomDD_ID != sender.DoBaiViet.ID_NHOM_DIEN_DAN)
            {
                this._NhomDD_ID = sender.DoBaiViet.ID_NHOM_DIEN_DAN;
                DataSet ds = HelpDB.getDatabase().LoadDataSet(string.Format("select name from NHOM_DIEN_DAN where id={0}", this._NhomDD_ID));
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    this._NhomDienDan = ds.Tables[0].Rows[0][0].ToString();
                    
                }
            }
            if (this._ChuyenMuc_ID != sender.DoBaiViet.ID_CHUYEN_MUC)
            {
                this._ChuyenMuc_ID = sender.DoBaiViet.ID_CHUYEN_MUC;
                DataSet dss = HelpDB.getDatabase().LoadDataSet(string.Format("select name from CHUYEN_MUC where id={0}", this._ChuyenMuc_ID));
                if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                {
                    this._ChuyenMuc = dss.Tables[0].Rows[0][0].ToString();
                }
            }
            this.Text = this.Text.Replace(oldtext, _NhomDienDan + "/" + _ChuyenMuc);
        }
      
        #endregion

        #region Hàm hỗ trợ
       

        private void Load_bai_viet()
        {
            DABaiViet.Instance.Update_TANG_SO_LAN_XEM(BaiVietGocID);
            this.Text = _NhomDienDan + "/" + _ChuyenMuc;
            DataTable Dt = DABaiViet.Instance.GetAllBaiVietByBaiVietGoc (BaiVietGocID);
            DataTable dtListFile = DABaiViet.Instance.GetAllFileByBaiVietGoc(BaiVietGocID);
            DataRow[] Dr = new DataRow[1];
            if (Dt.Rows.Count > 0)
            {
                Dr = Dt.Select(string.Format("ID={0}", BaiVietGocID));
                DataSet dsListFile = new DataSet();
                dtListFile.DefaultView.RowFilter = string.Format("OBJECT_ID={0}", BaiVietGocID);
                dsListFile.Tables.Add(dtListFile.DefaultView.ToTable());
                //Thêm bài viết gốc 
                NguoiTaoBaiVietGoc = HelpNumber.ParseInt64(Dr[0]["NGUOI_GUI"]);
                DOBaiViet bv = new DOBaiViet(BaiVietGocID, Dr[0]["CHU_DE"].ToString(),
                    (byte[])Dr[0]["NOI_DUNG"], HelpNumber.ParseInt64(Dr[0]["SO_LAN_XEM"]),
                   HelpNumber.ParseInt64(Dr[0]["SO_LAN_TRA_LOI"]),
                    (DateTime)Dr[0]["NGAY_GUI"], HelpNumber.ParseInt64(Dr[0]["NGUOI_GUI"]),
                    HelpNumber.ParseInt64(Dr[0]["ID_NHOM_DIEN_DAN"]), 
                    HelpNumber.ParseInt64(Dr[0]["ID_CHUYEN_MUC"]),
                    HelpNumber.ParseInt64(Dr[0]["ID_BAI_VIET_PARENT"]));
                bv.DSTapTinDinhKem = dsListFile;
                this.ucBaiVietGoc = new office.Training.ModDienDan.ucBaiViet(this,NguoiTaoBaiVietGoc, bv);
                ucBaiVietGoc.AfterDeleteSuccessfully += new office.Training.ModDienDan.ucBaiViet._AfterDeleteSuccessfully(baiViet_AfterDeleteSuccessfully);
                ucBaiVietGoc.AfterReplySuccessFully += new ucBaiViet._AfterReplySuccessFully(baiViet_AfterReplySuccessFully);
                ucBaiVietGoc.AfterUpdateSuccessfully += new ucBaiViet._AfterUpdateSuccessfully(ucBaiVietGoc_AfterUpdateSuccessfully);
                listUCBV.Add(ucBaiVietGoc);
                //    
                ucBaiViet ucBaiViet1 = null;
                foreach (DataRow row in Dt.Rows)
                {
                    if (HelpNumber.ParseInt64(row["ID"]) == BaiVietGocID) continue;//Thêm nhưng trừ bài viết gốc                  

                    DataSet dsListFileC = new DataSet();
                    dtListFile.DefaultView.RowFilter = string.Format("OBJECT_ID={0}", HelpNumber.ParseInt64(row["ID"]));
                    dsListFileC.Tables.Add(dtListFile.DefaultView.ToTable());
                    bv = new DOBaiViet(HelpNumber.ParseInt64(row["ID"]), row["CHU_DE"].ToString(),
                    (byte[])row["NOI_DUNG"], HelpNumber.ParseInt64(row["SO_LAN_XEM"]),
                   HelpNumber.ParseInt64(row["SO_LAN_TRA_LOI"]),
                    (DateTime)row["NGAY_GUI"], HelpNumber.ParseInt64(row["NGUOI_GUI"]),
                    HelpNumber.ParseInt64(row["ID_NHOM_DIEN_DAN"]),
                    HelpNumber.ParseInt64(row["ID_CHUYEN_MUC"]),
                    HelpNumber.ParseInt64(row["ID_BAI_VIET_PARENT"]));
                    bv.DSTapTinDinhKem = dsListFileC;
                    ucBaiViet1 = new office.Training.ModDienDan.ucBaiViet(this, NguoiTaoBaiVietGoc,
                       bv);
                    ucBaiViet1.AfterDeleteSuccessfully += new office.Training.ModDienDan.ucBaiViet._AfterDeleteSuccessfully(baiViet_AfterDeleteSuccessfully);
                    ucBaiViet1.AfterReplySuccessFully += new ucBaiViet._AfterReplySuccessFully(baiViet_AfterReplySuccessFully);
                    ucBaiVietGoc.AfterUpdateSuccessfully += new ucBaiViet._AfterUpdateSuccessfully(ucBaiVietGoc_AfterUpdateSuccessfully);
                    listUCBV.Add(ucBaiViet1);
                }
            }
        }

    

      
      
        #endregion
        /*Khanhdtn: nousing
        #region Author: Vo Thanh Duy - thanhduy2b@gmail.com
        /// <summary>
        /// Functions support for calculating dynamic document height
        /// Version: 1.0 (beta)
        /// </summary>

        #region duyvt - "Constants"
        private const int HEIGHT_EXT_1 = 120;   // Heigth extension 1 (by evaluating)
        private const int HEIGHT_EXT_2 = 73;    // Heigth extension 2 (by evaluating)
        private const int FONT_SIZE = 3;        // FontSize default
        #endregion

        #region duyvt - "Variables"
        private static string _NBSP = "&nbsp;";
        private static string _NBSP_IN_P_TAG = "<P>&nbsp;</P>";

        private static string P_TAG = "P";
        private static string P_TAG_CLOSE = "</P>";

        private static string FONT_TAG = "FONT";
        private static string FONT_TAG_CLOSE = "</FONT>";

        private static string SPAN_TAG = "SPAN";

        private static string IMG_TAG = "IMG";

        private static string ERROR_MESSAGE = "Có lỗi xảy ra.Vui lòng liên hệ PROTOCOLVN!";
        #endregion

        #region duyvt - "Functions"
        /// <summary>
        /// duyvt - Calculating document height in WebBrowser control(simple)
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <param name="widthControl">Container width</param>
        /// <param name="heightExt">Height extension(by evaluating)</param>
        /// <returns>Heigth after calculating</returns>
        private int CalHeigthDocument(string str, int widthControl, int heightExt)
        {
            try
            {
                Graphics graphics = this.CreateGraphics();
                return graphics.MeasureString(str, this.Font, widthControl).ToSize().Height * 2 +
                    this.FontHeight * GetStringCount(str, _NBSP_IN_P_TAG) + heightExt;
            }
            catch
            {
                HelpMsgBox.ShowErrorMessage(ERROR_MESSAGE);
                return 0;
            }
        }

        /// <summary>
        /// duyvt - Calculating document height in WebBrowser control by analysing HTML content
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <param name="widthControl">Container width</param>
        /// <returns>Heigth after calculating</returns>
        private int CalHeightDocunment2(string str, int widthControl, ref int maxWidth)
        {
            try
            {
                Graphics graphics = this.CreateGraphics();
                int height = 0;
                int startIndexP = str.IndexOf("<" + P_TAG);
                int startIndexPClose = str.IndexOf(P_TAG_CLOSE);
                if (startIndexP != -1)
                {
                    while (startIndexPClose < str.Length - 7)
                    {
                        int indexP = str.IndexOf("<" + P_TAG, startIndexP);
                        int indexPClose = str.IndexOf(P_TAG_CLOSE, startIndexPClose);
                        if (indexP != -1 && indexPClose != -1)
                        {
                            string str_content = str.Substring(indexP + GetNumCharTag(str, indexP, P_TAG),
                                indexPClose - indexP - GetNumCharTag(str, indexP, P_TAG));
                            this.TrimTag(ref str_content, SPAN_TAG);
                            int FontSize = FONT_SIZE;
                            if (str_content != _NBSP && str_content.IndexOf("<" + FONT_TAG) != -1)
                                FontSize = ExtractFontSizeExt(str_content);
                            height += graphics.MeasureString(str_content, this.Font, widthControl).ToSize().Height *
                                ((FontSize / FONT_SIZE) > 0 ? (FontSize / FONT_SIZE) : 1) * 2 +
                                this.FontHeight * ((FontSize / FONT_SIZE) > 0 ? (FontSize / FONT_SIZE) : 1) +
                                this.CalSumImageHeightInParagraph(str_content, ref maxWidth);

                            startIndexP = indexPClose + 4;
                            startIndexPClose = indexPClose + 4;
                        }
                        else
                            break;
                    }
                    return height + HEIGHT_EXT_2;
                }
                else
                {
                    int FontSize = ExtractFontSizeExt(ExtractTagString2(str, FONT_TAG));
                    this.TrimTag(ref str, "body");
                    return graphics.MeasureString(str, this.Font, widthControl).ToSize().Height *
                        ((FontSize / FONT_SIZE) > 0 ? (FontSize / FONT_SIZE) : 1) * 2 +
                        this.FontHeight * ((FontSize / FONT_SIZE) > 0 ? (FontSize / FONT_SIZE) : 1) +
                        this.CalSumImageHeightInParagraph(str, ref maxWidth) + HEIGHT_EXT_2;
                }
            }
            catch
            {
                HelpMsgBox.ShowErrorMessage(ERROR_MESSAGE);
                return 0;
            }
        }

        /// <summary>
        /// duyvt -  Count characters of tag <TagName> in first(Open-Tag)
        /// </summary>
        /// <param name="str_document">HTML content</param>
        /// <param name="startIndex">Start Index</param>
        /// <param name="TagName">TagName</param>
        /// <returns>Count</returns>
        private int GetNumCharTag(string str_document, int startIndex, string TagName)
        {
            int count = 0;
            int indexP = str_document.IndexOf("<" + TagName, startIndex);
            if (indexP != -1)
            {
                for (int i = indexP; i < str_document.Length; i++)
                {
                    count++;
                    if (str_document[i] == '>')
                        break;
                }
            }
            return count;
        }

        /// <summary>
        /// duyvt - Extracting FormatString FONT 
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <returns>FormatString FONT</returns>
        private string ExtractFontString(string str)
        {
            int indexOpen = str.IndexOf("<" + FONT_TAG);
            if (indexOpen != -1)
            {
                int indexClose = -1;
                for (int i = indexOpen; i < str.Length; i++)
                {
                    if (str[i] == '>')
                    {
                        indexClose = i;
                        break;
                    }
                }
                if (indexClose != -1)
                    return str.Substring(indexOpen, indexClose - indexOpen + 1);
            }
            return "";
        }

        /// <summary>
        /// duyvt - Extracting FontSize from HTML content (simple)
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <returns>FontSize</returns>
        private int ExtractFontSize(string str)
        {
            StringBuilder builder = new StringBuilder();
            if (str.IndexOf("<" + FONT_TAG) != -1)
            {
                string str_font = str.Substring(str.IndexOf("<" + FONT_TAG), str.IndexOf('>') + 1);
                int _index = str_font.IndexOf("size=");
                if (_index != -1)
                {
                    for (int i = _index + 5; i < str_font.Length; i++)
                    {
                        if (str_font[i] != '>' && str_font[i] != ' ')
                            builder.Append(str_font[i]);
                        else
                            break;
                    }
                }
                return HelpNumber.ParseInt32(builder.ToString() != "" ? builder.ToString() :
                    FONT_SIZE.ToString());
            }
            else
                return FONT_SIZE;
        }

        /// <summary>
        /// duyvt - Extracting FontSize (get MAX) from HTML content (advance)
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <returns>max FontSize</returns>
        private int ExtractFontSizeExt(string str)
        {
            Stack<TagIndexWithState> _stackIn = new Stack<TagIndexWithState>();
            int startIndexF = str.IndexOf("<" + FONT_TAG);
            int startIndexFClose = str.IndexOf(FONT_TAG_CLOSE);
            while (startIndexF < str.Length)
            {
                int indexF = str.IndexOf("<" + FONT_TAG, startIndexF);
                int indexFClose = str.IndexOf(FONT_TAG_CLOSE, startIndexFClose);
                if (indexF != -1 && indexFClose != -1)
                {
                    if (indexF < indexFClose)
                    {
                        _stackIn.Push(new TagIndexWithState(indexF, TagStateEnum.OPEN));
                        _stackIn.Push(new TagIndexWithState(indexFClose, TagStateEnum.CLOSE));
                    }
                    else
                    {
                        _stackIn.Push(new TagIndexWithState(indexFClose, TagStateEnum.CLOSE));
                        _stackIn.Push(new TagIndexWithState(indexF, TagStateEnum.OPEN));
                    }
                    startIndexF = indexF + 6;
                    startIndexFClose = indexFClose + 7;
                }
                else
                    break;
            }
            int MAX_FONT_SIZE = FONT_SIZE;
            if (_stackIn.Count > 0)
            {
                Stack<TagIndexWithState> _stackTmp = new Stack<TagIndexWithState>();
                while (_stackIn.Count > 0)
                {
                    TagIndexWithState obj = _stackIn.Pop();
                    if (_stackTmp.Count > 0)
                    {
                        TagIndexWithState _obj = _stackTmp.Peek();
                        if (obj.TagState != _obj.TagState)
                        {
                            _obj = _stackTmp.Pop();
                            int font_size = this.ExtractFontSize(str.Substring(
                                (obj.TagState == TagStateEnum.OPEN ? obj.Index : _obj.Index)));
                            if (font_size > MAX_FONT_SIZE)
                                MAX_FONT_SIZE = font_size;
                        }
                        else
                            _stackTmp.Push(obj);
                    }
                    else
                        _stackTmp.Push(obj);
                }
            }
            return MAX_FONT_SIZE;
        }

        /// <summary>
        /// duyvt - Extracting string follow TagType with all attributes without content (TagName without '<', '>')
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <param name="TagName">TagName</param>
        /// <returns>Result string</returns>
        private string ExtractTagString(string str, string TagName)
        {
            int indexOpen = str.IndexOf("<" + TagName);
            if (indexOpen != -1)
            {
                int indexClose = -1;
                for (int i = indexOpen; i < str.Length; i++)
                {
                    if (str[i] == '>')
                    {
                        indexClose = i;
                        break;
                    }
                }
                if (indexClose != -1)
                    return str.Substring(indexOpen, indexClose - indexOpen + 1);
            }
            return "";
        }

        /// <summary>
        /// duyvt - Extracting string follow TagType with all attributes with content (TagName without '<', '>')
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <param name="TagName">TagName</param>
        /// <returns>Result string</returns>
        private string ExtractTagString2(string str, string TagName)
        {
            int indexOpen = str.IndexOf("<" + TagName);
            if (indexOpen != -1)
            {
                int indexClose = -1;
                for (int i = indexOpen; i < str.Length; i++)
                {
                    if (str[i] == '>')
                    {
                        indexClose = i;
                        break;
                    }
                }
                if (indexClose != -1)
                    return str.Substring(indexOpen, str.LastIndexOf(
                        "</" + TagName + ">") - indexOpen + 7);
            }
            return "";
        }

        /// <summary>
        /// duyvt - Extracting image pathfile from HTML content
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <returns>PathFile</returns>
        private string ExtractImageURL(string str, ref int width, ref int height)
        {
            StringBuilder builder = new StringBuilder();
            if (str.StartsWith("<" + IMG_TAG))
            {
                string str_img = str.Substring(0, str.IndexOf('>') + 1);
                int _index = str_img.IndexOf("src=");
                if (_index != -1)
                {
                    for (int i = _index + 5; i < str_img.Length; i++)
                    {
                        if (str_img[i] != '>' && str_img[i] != '"')
                            builder.Append(str_img[i]);
                        else
                            break;
                    }
                }

                int _index_style = str.IndexOf("style=\"");
                if (_index_style != -1)
                {
                    string style = str.Substring(_index_style + 7, str.IndexOf("px\"") - 10);
                    string[] strSize = style.Split(';');
                    if (strSize.Length > 1)
                    {
                        width = HelpNumber.ParseInt32(strSize[0].Replace("WIDTH:", "").TrimEnd('p', 'x').Trim());
                        height = HelpNumber.ParseInt32(strSize[1].Replace("HEIGHT:", "").TrimEnd('p', 'x').Trim());
                    }
                }
                else
                {
                    int _index_height = str.IndexOf("height=");
                    if (_index_height != -1)
                    {
                        string strH = str.Remove(0, _index_height);
                        strH = strH.Replace("height=", "");
                        strH = strH.Substring(0, strH.IndexOf(' '));
                        height = HelpNumber.ParseInt32(strH);
                    }
                    int _index_width = str.IndexOf("width=");
                    if (_index_width != -1)
                    {
                        string strW = str.Remove(0, _index_width);
                        strW = strW.Replace("width=", "");
                        strW = strW.Substring(0, strW.IndexOf(' '));
                        height = HelpNumber.ParseInt32(strW);
                    }
                }

                return builder.ToString();
            }
            else
                return "";
        }

        /// <summary>
        /// duyvt - Count Child'string in Parent'string
        /// </summary>
        /// <param name="str_parent">Parent string</param>
        /// <param name="str_child">Child string</param>
        /// <returns>Count</returns>
        private int GetStringCount(string str_parent, string str_child)
        {
            if (str_parent.Length >= str_child.Length)
            {
                int count = 0;
                int j = 0;
                for (int i = 0; i < str_parent.Length; i++)
                {
                    if (str_parent[i] == str_child[j])
                    {
                        j++;
                        if (j == str_child.Length)
                        {
                            count++;
                            j = 0;
                        }
                    }
                    else
                    {
                        if (j > 0)
                            j = 0;
                    }
                }
                return count;
            }
            else
                return 0;
        }

        /// <summary>
        /// duyvt - Calculating height total of images in paragraph
        /// </summary>
        /// <param name="str">HTML content in paragraph</param>
        /// <returns>Total height</returns>
        private int CalSumImageHeightInParagraph(string str, ref int maxWidth)
        {
            int startIndexI = str.IndexOf("<" + IMG_TAG);
            int startIndexIClose = str.IndexOf(">", startIndexI != -1 ? startIndexI : 0);
            int sum = 0;
            if (startIndexI != -1 && startIndexIClose != -1)
            {
                while (startIndexI < str.Length)
                {
                    int indexI = str.IndexOf("<" + IMG_TAG, startIndexI);
                    int indexIClose = str.IndexOf(">", startIndexIClose);

                    if (indexI != -1 && indexIClose != -1 && indexIClose >= indexI)
                    {
                        Image igm = null;
                        int height = 0;
                        int width = 0;
                        string pathUri = ExtractImageURL(str.Substring(indexI, indexIClose - indexI + 1), ref width, ref height);
                        if (height <= 0 || width <= 0)
                        {
                            try
                            {

                                UriBuilder path = new UriBuilder(pathUri);
                                if (System.IO.File.Exists(path.Uri.LocalPath))
                                    igm = Image.FromFile(path.Uri.LocalPath);

                            }
                            catch
                            {
                            }
                            if (igm != null)
                            {
                                if (height <= 0) height = igm.Height;
                                if (width <= 0) width = igm.Width;
                            }
                        }
                        if (maxWidth < width)
                            maxWidth = width;


                        sum += height;
                        startIndexI = indexIClose + 1;
                        startIndexIClose = indexIClose + 1;

                    }
                    else
                        break;
                }
                return sum;
            }
            else
                return 0;
        }

        /// <summary>
        /// duyvt - Remove tag prefix
        /// </summary>
        /// <param name="str">HTML content</param>
        /// <param name="TagName">TagName</param>
        private void TrimTag(ref string str, string TagName)
        {
            if (str.StartsWith("<" + TagName))
                str = str.Substring(str.IndexOf(">") + 1, (str.IndexOf("</" + TagName) != -1 ?
                    (str.IndexOf("</" + TagName) - str.IndexOf(">") - 1) :
                    (str.Length - str.IndexOf(">") - 1)));
        }
        #endregion

        #region duyvt - "Classes"
        public enum TagStateEnum
        {
            /// <summary>
            /// Open tag
            /// </summary>
            OPEN,
            /// <summary>
            /// Close tag
            /// </summary>
            CLOSE
        }

        public class TagIndexWithState
        {
            private int index;          //index tag in HTML string

            private TagStateEnum tagState;  //tag state (Open or Close)

            public int Index
            {
                get { return index; }
                set { index = value; }
            }

            public TagStateEnum TagState
            {
                get { return tagState; }
                set { tagState = value; }
            }

            public TagIndexWithState() { }

            public TagIndexWithState(int index, TagStateEnum tagSate)
            {
                this.index = index;
                this.tagState = tagSate;
            }
        }
        #endregion

        #endregion
         * */
    }
}