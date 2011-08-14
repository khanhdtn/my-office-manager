using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;

namespace ProtocolVN.App
{
    public class frmKhoDanhMuc : frmCategory
    {
        public frmKhoDanhMuc()
            : base(FrameworkParams.Category)
        {
            this.Text = "Quản lý danh mục";
        }
    }
}
