using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

namespace ProtocolVN.Plugin.TimeSheet.report
{
    public partial class CT_TONGHOPDUAN : XtraUserControl, IReportFilter
    {
        public CT_TONGHOPDUAN()
        {
            InitializeComponent();
        }

        #region IReportFilter Members

        public Dictionary<string, object> GetParamFieldValue()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            return dic;
        }

        public void ValidateFilter(DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Error)
        {
            if (PLcbdu_an._getSelectedID() == -1)
                PLcbdu_an.SetError(Error, "Vui lòng chọn Dự Án!");
        }

        public DataSet getDataSet()
        {
            DataSet ds = PLTimeSheetReport.GetIN_ST_RPT_TONGHOP(PLcbdu_an._getSelectedID());
            return ds;
           
        }

        public DataSet[] getSubReports()
        {
            return null;
        }

        #endregion

        private void CT_TONGHOPDUAN_Load(object sender, EventArgs e)
        {
            PLTimeSheetCtrl.ChonLoaiCongViec(PLcbdu_an);
        }
    }
}
