using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;

namespace office
{
    public partial class ERPDesktop : XtraFormPL
    {
        public ERPDesktop()
        {
            InitializeComponent();
            this.Tag = "";
        }

        private void ERPDesktop_Resize(object sender, EventArgs e)
        {
            
        }
    }
}