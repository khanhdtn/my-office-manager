using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ProtocolVN.App.Office.__hrm_payroll.ModLuong.report
{
    public partial class XRPT_TinhLuong_ChiTiet : DevExpress.XtraReports.UI.XtraReport
    {
        public XRPT_TinhLuong_ChiTiet()
        {
            InitializeComponent();
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRPT_TinhLuong_ChiTiet_Sub)((XRSubreport)sender).ReportSource).Luong_ID.Value =
                ProtocolVN.Framework.Core.HelpNumber.ParseDecimal((this.GetCurrentColumnValue("ID")));
        }

        private void xrLabel44_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRLabel)sender).Text = string.Format("{0:###,###}", (ProtocolVN.Framework.Core.HelpNumber.ParseDecimal(GetCurrentColumnValue("TONG_THU_NHAP"))
                - ProtocolVN.Framework.Core.HelpNumber.ParseDecimal(GetCurrentColumnValue("TAM_UNG"))));
        }
        public bool ShowOne
        {
            set
            {
                xrTable3.Visible = !value;
                xrTable4.Visible = !value;
                xrSubreport2.Visible=!value;
            }
            get
            {
                return xrTable3.Visible == false 
                    && xrTable4.Visible == false &&
                    xrSubreport2.Visible == false;
            }
        }

    }
}
