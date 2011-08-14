using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.App.Office;

namespace pl.office.ZTest
{
    public partial class DemoControl : DevExpress.XtraEditors.XtraForm
    {
        #region Khai báo MenuItem
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(DemoControl).FullName,
               "RichTextBox",
                ParentID, true,
                typeof(DemoControl).FullName,
                false, IsSep, "", true, "", "");
        }
        #endregion

        public DemoControl()
        {
            InitializeComponent();
        }
        CurrentNews ctr = null;
        private void DemoControl_Load(object sender, EventArgs e)
        {
            DevExpress.XtraRichEdit.Demos.PLRichTextBox rich = new DevExpress.XtraRichEdit.Demos.PLRichTextBox();
            rich.Dock = DockStyle.Fill;
            this.panelControl1.Controls.Add(rich);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}