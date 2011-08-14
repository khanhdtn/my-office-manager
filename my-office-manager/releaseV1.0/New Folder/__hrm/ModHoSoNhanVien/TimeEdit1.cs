using System;
using System.Windows.Forms;
using office;

namespace pl.hrm.form
{
    public partial class TimeEdit1 : DevExpress.XtraEditors.XtraUserControl
    {
        public TimeEdit1()
        {
            InitializeComponent();
        }

        private void timeEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void timeEdit2_KeyUp(object sender, KeyEventArgs e)
        {
            int temp = e.KeyValue;
            if (temp == 46 || temp == 110)
                this.TimeEditSub.Properties.Mask.EditMask = "\"\"";
            else
                this.TimeEditSub.Properties.Mask.EditMask = PLConst.FORMAT_TIME_STRING;
        }

        private void timeEdit2_Click(object sender, EventArgs e)
        {
            this.TimeEditSub.Properties.Mask.EditMask = PLConst.FORMAT_TIME_STRING;
        }

        private void TimeEdit1_Load(object sender, EventArgs e)
        {
            this.TimeEditSub.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.TimeEditSub.Properties.Mask.EditMask = PLConst.FORMAT_TIME_STRING;
        }
    }
}
