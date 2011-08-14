using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;

///CHAUTV : Xây dựng CheckEdit (Có kèm theo caption thể hiện)
namespace ProtocolVN.Framework.Win
{
    /// <summary>
    /// CheckEdit có caption thể hiện ở nhiều dạng.
    /// Control này ko có ý nghĩa khi sử dụng rộng rãi
    /// </summary>
    public class PLCheckEdit : CheckEdit
    {
        private CaptionType _type = CaptionType.REQUIRED;
        public PLCheckEdit() : base() {
            HelpControl.RedCheckEdit(this,false);
        }
        [Browsable(true), Category("_PROTOCOL"), Description("Loại nhãn hiện thị")]
        public CaptionType ZZZType
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
                switch (this._type)
                {
                    case CaptionType.OPTION:
                        base.Font = new Font(base.Font.FontFamily.Name, base.Font.Size, FontStyle.Underline);
                        this.ToolTip = ("Dữ liệu không bắt buộc nhập");
                        break;

                    case CaptionType.REQUIRED:
                        base.Font = new Font(base.Font.FontFamily.Name, base.Font.Size, FontStyle.Regular);
                        this.ToolTip = ("Dữ liệu bắt buộc nhập");
                        break;

                    case CaptionType.DESCRIPTION:
                        base.Font = new Font(base.Font.FontFamily.Name, base.Font.Size, FontStyle.Italic);
                        this.ToolTip = ("Dữ liệu hiển thị (tham khảo)");
                        break;
                }
            }
        }
    }

    public enum CaptionType
    {
        OPTION,
        REQUIRED,
        DESCRIPTION
    }
}
