using System;
using DevExpress.XtraEditors;


namespace DevExpress.XtraRichEdit.Demos {
    #region DocumentRestrictionsModule
    /// <summary>
    ///CHAUTV: Control nhập liệu dạng html
    /// </summary>
    public partial class PLRichTextBox : XtraUserControl {

        public PLRichTextBox()
        {
            InitializeComponent();
            richEditControl.Focus();
            richEditControl.Options.Changed += new DevExpress.Utils.Controls.BaseOptionChangedEventHandler(Options_Changed);
        }

        void Options_Changed(object sender, DevExpress.Utils.Controls.BaseOptionChangedEventArgs e)
        {
            ///NOOP
        }
        #region Properties
        public RichEditControl PrintingRichEditControl { get { return richEditControl; } }
        public bool IsHideDisabled { get { return true; } }
        public bool IsReloadDocument { get { return true; } }
        public string CurrentFileName { get { return richEditControl.Options.DocumentSaveOptions.CurrentFileName; } }
        #endregion

        //protected override void DoShow() {
        //    base.DoShow();
        //    richEditControl.Focus();
        //}

        #region Hendlers
        void OnAllowCharacterFormatting(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.CharacterFormatting = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowCharacterStyle(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.CharacterStyle = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowParagraph(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.Paragraphs = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowParagraphPraperties(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.ParagraphFormatting = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowParagraphStyle(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.ParagraphStyle = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowParagraphTabs(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.ParagraphTabs = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowHyperlinks(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.Hyperlinks = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowBookmarks(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.Bookmarks = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowBulletNumbering(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.Numbering.Bulleted = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowSimpleNumbering(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.Numbering.Simple = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowMultiLevelNumbering(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.Numbering.MultiLevel = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowPicture(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.InlinePictures = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowSymbolTabs(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.TabSymbol = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowSections(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.Sections = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnAllowHeadersFooters(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.HeadersFooters = GetOptionValue(sender);
            ReloadDocument();
        }
        void OnApplyRestrictions(object sender, EventArgs e) {
            ReloadDocument();
        }
        void OnEdtAllowTables(object sender, EventArgs e) {
            richEditControl.Options.DocumentCapabilities.Tables = GetOptionValue(sender);
            ReloadDocument();
        }
        #endregion

        void ReloadDocument() {
            if (IsReloadDocument && !String.IsNullOrEmpty(CurrentFileName))
                richEditControl.LoadDocument(CurrentFileName);
        }
        DocumentCapability GetOptionValue(object sender) {
            if (((CheckEdit)sender).Checked)
                return DocumentCapability.Enabled;
            if (IsHideDisabled)
                return DocumentCapability.Hidden;
            return DocumentCapability.Disabled;
        }

        #region GET & SET
        /// <summary>
        /// Lấy giá trị đã chuyển sang kiểu byte
        /// </summary>
        public byte[] _getValue() {
            return System.Text.UTF8Encoding.UTF8.GetBytes(this.richEditControl.RtfText);
        }
        /// <summary>
        /// Gán giá trị vào từ kiểu byte (dữ liệu được nhập từ RichTextBox)
        /// </summary>
        public void _setValue(byte[] valueRtf) {
            this.richEditControl.RtfText = System.Text.UTF8Encoding.UTF8.GetString(valueRtf);
        }


        /// <summary>
        /// Lấy dữ liệu ra
        /// </summary>
        [Obsolete("Khuyến cáo không nên dùng, nên sử dụng Hàm _getValue() để thay thế")]
        public string _getTextRtf() {
            return this.richEditControl.RtfText;
        }
        /// <summary>
        /// Đưa dữ liệu vào RichTextBox
        /// </summary>
        [Obsolete("Khuyến cáo không nên dùng, nên sử dụng Hàm _setValue(byte[] valueRtf) để thay thế")]
        public void _setTextRtf(string textRtf) {
            this.richEditControl.RtfText = textRtf;
        }

        
        #endregion

        #region Load file
        public void LoadRtf(String fileName)
        {
            richEditControl.LoadDocument(fileName, DocumentFormat.Rtf);
        }
        public void LoadXml(String fileName)
        {
            richEditControl.LoadDocument(fileName, DocumentFormat.OpenXml);
        }
        public void LoadHtml(String fileName)
        {
            richEditControl.LoadDocument(fileName, DocumentFormat.Html);
        } 
        #endregion

        private void PLRichTextBox_Load(object sender, EventArgs e)
        {

        }
    }
    #endregion
}
