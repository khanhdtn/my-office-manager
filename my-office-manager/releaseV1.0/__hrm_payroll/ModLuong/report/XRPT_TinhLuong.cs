using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ProtocolVN.App.Office.__hrm_payroll.ModLuong.report
{
    public partial class XRPT_TinhLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public XRPT_TinhLuong()
        {
            InitializeComponent();
        }
    

        private void xrLabel44_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           ((XRLabel)sender).Text = string.Format("{0:###,###}", (ProtocolVN.Framework.Core.HelpNumber.ParseDecimal(GetCurrentColumnValue("THU_NHAP"))
                - ProtocolVN.Framework.Core.HelpNumber.ParseDecimal(GetCurrentColumnValue("TAM_UNG"))));
        }


    }
}
