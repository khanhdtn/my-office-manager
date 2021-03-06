using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;
using ProtocolVN.App.Office;

namespace pl.office
{
    public class PLCtrl : AppCtrl
    {
        public static void FormatTextEdit(TextEdit Input)
        {
            if (Input.EditValue!=null &&
                Input.EditValue.ToString()!="" &&
                HelpNumber.ParseDecimal(Input.EditValue) != 0)
            {
                Input.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                Input.Properties.DisplayFormat.FormatString = "{0:#,###}";
                Input.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                Input.Properties.Mask.EditMask = "n0";
            }
        }
    }

}
