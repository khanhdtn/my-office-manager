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
using ProtocolVN.Framework.Core.Trial;

namespace office
{
    public partial class frmHopDong : XtraFormPL
    {
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmHopDong).FullName,
                "Tạo mới",
                ParentID, true,
                typeof(frmHopDong).FullName,
                false, IsSep, "", true, "", "");
        }

        public frmHopDong()
        {
            InitializeComponent();
        }

        private void frmHopDong_Load(object sender, EventArgs e)
        {
            QueryBuilder query = new QueryBuilder("delete from LOAI_DANH_BA where 1=1");
            query.addID("ID", 10110);
            DBService db = new DABaseFb().SQLStmt;
            db.Begin();
            try
            {
                db.DbCommand.Parameters.AddRange(query.generateDbParam().ToArray());
                db.ExecuteCommand(query.generateParamSQL());
                db.Commit();
            }
            catch (Exception ex)
            {
                db.RollBack();
            } 
        }
    }
}