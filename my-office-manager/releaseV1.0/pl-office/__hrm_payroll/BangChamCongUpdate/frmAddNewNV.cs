using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace office
{
    public partial class frmAddNewNV : XtraFormPL
    {
        private List<object> lstNhanVien;
        public delegate void ListAddedNhanvien(long[] lstAddedNhanVien);
        public ListAddedNhanvien GetList;
        public frmAddNewNV(List<object> lstNhanVien)
        {
            InitializeComponent();
            this.lstNhanVien = lstNhanVien;
            this.Load += new EventHandler(frmAddNewNV_Load);
            this.btnOK.Click += new EventHandler(btnOK_Click);
            HelpXtraForm.SetCloseForm(this, btnThoat, null);
        }

        void frmAddNewNV_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
            StringBuilder strNhanVien = new StringBuilder();
            foreach (object item in lstNhanVien) {
                strNhanVien.Append(item.ToString());
                strNhanVien.Append(",");
            }
            string sql = string.Format(@"SELECT ID,NAME FROM DM_NHAN_VIEN WHERE ID IN 
                                (SELECT NV_ID FROM CAPNHAT_NGAYLAMVIEC) AND ID NOT IN ({0})", strNhanVien.Remove(strNhanVien.Length - 1, 1));
            PLMulNhanVien._init(DABase.getDatabase().LoadDataSet(sql).Tables[0], "NAME", "ID");
        }

        void btnOK_Click(object sender, EventArgs e)
        {
            if (GetList != null) {
                GetList(PLMulNhanVien._getSelectedIDs());
            }
            HelpXtraForm.CloseFormNoConfirm(this);
        }
    }
}