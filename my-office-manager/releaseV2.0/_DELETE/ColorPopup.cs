namespace ProtocolVN.Framework.Win.Trial
{
    using DevExpress.Utils;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using DevExpress.XtraEditors.Popup;
    using DevExpress.XtraEditors.Repository;
    using DevExpress.XtraTab;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class ColorPopup
    {
        private PopupControlContainer container;
        private Color fResultColor;
        private static BarItem itemFontColor;
        private XtraTabControl tabControl;
        private ProtocolVN.Framework.Win.Trial.PLWord wordEditor;

        public ColorPopup(PopupControlContainer container, BarItem item, ProtocolVN.Framework.Win.Trial.PLWord editor)
        {
            this.wordEditor = editor;
            this.container = container;
            itemFontColor = item;
            this.fResultColor = Color.Empty;
            this.tabControl = this.CreateTabControl();
            this.tabControl.TabStop = false;
            this.tabControl.TabPages.AddRange(new XtraTabPage[] { new XtraTabPage(), new XtraTabPage(), new XtraTabPage() });
            for (int i = 0; i < this.tabControl.TabPages.Count; i++)
            {
                this.SetTabPageProperties(i);
            }
            this.tabControl.Dock = DockStyle.Fill;
            this.container.Controls.AddRange(new Control[] { this.tabControl });
            this.container.Size = this.CalcFormSize();
        }

        public Size CalcFormSize()
        {
            Size size = ColorCellsControlViewInfo.BestSize;
            size.Height = 0x71;
            return this.tabControl.CalcSizeByPageClient(size);
        }

        private ColorListBox CreateColorListBox()
        {
            return new ColorListBox();
        }

        private XtraTabControl CreateTabControl()
        {
            return new XtraTabControl();
        }

        private void OnEnterColor(Color clr)
        {
            this.container.HidePopup();
            this.wordEditor.CurrentRichText.SelectionColor = clr;
        }

        private void OnEnterColor(object sender, EnterColorEventArgs e)
        {
            this.ResultColor = e.Color;
            this.OnEnterColor(e.Color);
        }

        public static void SetImageColor(BarItem item, Color clr)
        {
            int num = item.ImageIndex;
            ImageCollection images = item.Images as ImageCollection;
            Bitmap image = (Bitmap) images.Images[num];
            Graphics graphics = Graphics.FromImage(image);
            Rectangle rect = new Rectangle(2, 12, 12, 3);
            graphics.FillRectangle(new SolidBrush(clr), rect);
            if (num == (images.Images.Count))
            {
                images.Images.RemoveAt(num);
            }
            graphics.Dispose();
            images.Images.Add(image);
            item.ImageIndex = (images.Images.Count - 1);
        }

        private void SetTabPageProperties(int pageIndex)
        {
            XtraTabPage page = this.tabControl.TabPages[pageIndex];
            ColorListBox box = null;
            BaseControl control = null;
            switch (pageIndex)
            {
                case 0:
                {
                    page.Text = Localizer.Active.GetLocalizedString(0);
                    control = new ColorCellsControl(null);
                    RepositoryItemColorEdit edit = new RepositoryItemColorEdit();
                    edit.ShowColorDialog  = false;
                    (control as ColorCellsControl).Properties = edit;
                    (control as ColorCellsControl).EnterColor += new EnterColorEventHandler(this.OnEnterColor);
                    control.Size = ColorCellsControlViewInfo.BestSize;
                    break;
                }
                case 1:
                    //page.Text = Localizer.Active.GetLocalizedString(0);
                    page.Text = "Màu web";
                    box = this.CreateColorListBox();
                    box.Items.AddRange(ColorListBoxViewInfo.WebColors);
                    box.EnterColor +=(new EnterColorEventHandler(this.OnEnterColor));
                    control = box;
                    break;

                case 2:
                    //page.Text = Localizer.Active.GetLocalizedString(0);
                    page.Text = "Màu hệ thống";
                    box = this.CreateColorListBox();
                    box.Items.AddRange(ColorListBoxViewInfo.SystemColors);
                    box.EnterColor +=new EnterColorEventHandler(this.OnEnterColor);
                    control = box;
                    break;
            }
            control.Dock = DockStyle.Fill;
            control.BorderStyle = BorderStyles.NoBorder;
            control.LookAndFeel.ParentLookAndFeel = (itemFontColor.Manager.GetController().LookAndFeel);
            page.Controls.Add(control);
        }

        private ColorCellsControl CellsControl
        {
            get
            {
                return (ColorCellsControl) this.tabControl.TabPages[0].Controls[0];
            }
        }

        private string CustomColorsName
        {
            get
            {
                return "CustomColors";
            }
        }

        public Color ResultColor
        {
            get
            {
                return this.fResultColor;
            }
            set
            {
                this.fResultColor = value;
                SetImageColor(itemFontColor, this.fResultColor);
            }
        }
    }
}

