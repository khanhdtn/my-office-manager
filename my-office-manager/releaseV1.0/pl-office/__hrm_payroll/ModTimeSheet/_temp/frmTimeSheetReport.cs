using ProtocolVN.Framework.Win;
using ProtocolVN.Plugin.TimeSheet.report;

namespace ProtocolVN.Plugin.TimeSheet
{
    public class frmTimeSheetReport: frmBaseReport
    {
        public frmTimeSheetReport()
            : base(PLTimeSheetReport.CreateReport())
        {
        }
    }
}
