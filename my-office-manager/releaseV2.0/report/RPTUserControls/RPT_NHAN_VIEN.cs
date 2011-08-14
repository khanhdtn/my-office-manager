using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors;
using System.Data.Common;
using ProtocolVN.DanhMuc;

namespace pl.office.Report
{
    public partial class RPT_NHAN_VIEN : XtraUserControl,IReportFilter
    {
        public RPT_NHAN_VIEN()
        {
            InitializeComponent();
            DMFWNhanVien.I.InitCtrl(PLNhanVien,false,false);
        }

        #region IReportFilter Members

        public Dictionary<string, object> GetParamFieldValue()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("NV",PLNhanVien._getSelectedID());            
            return dic;
        }

        public void ValidateFilter(DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Error)
        {
           
        }

        public DataSet getDataSet()
        {
            string sql = null;            
            DatabaseFB db = DABase.getDatabase();
            DbCommand cmd = null;
            if (PLNhanVien._getSelectedID() != -1)
            {
                sql = "Select * From DM_NHAN_VIEN Where ID=@ID";
                cmd = db.GetSQLStringCommand(sql);
                db.AddInParameter(cmd, "@ID", DbType.Int64, PLNhanVien._getSelectedID());
            }
            else
            {
                sql = "Select * From DM_NHAN_VIEN";
                cmd = db.GetSQLStringCommand(sql);
            }
            DataSet ds =  db.LoadDataSet(cmd);
            return ds;            
        }

        public DataSet[] getSubReports()
        {
            return null;
        }
        #endregion

    }
}
