using ProtocolVN.Framework.Win;

namespace ProtocolVN.Plugin.TimeSheet
{
    public class frmTimeSheetDM : frmCategory
    {
        public frmTimeSheetDM()
            : base(PLTimeSheetDanhMuc.CreateDanhMuc())
        {            
        }
    }
}
