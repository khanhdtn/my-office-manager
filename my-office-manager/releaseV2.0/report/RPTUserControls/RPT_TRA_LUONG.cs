using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;

namespace pl.office.Report
{
    public partial class RPT_TRA_LUONG : XtraUserControl, IReportFilter
    {
        public RPT_TRA_LUONG()
        {
            InitializeComponent();
        }

        #region IReportFilter Members

        public Dictionary<string, object> GetParamFieldValue()
        {
            throw new NotImplementedException();
        }

        public void ValidateFilter(DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Error)
        {
            throw new NotImplementedException();
        }

        public DataSet getDataSet()
        {
            throw new NotImplementedException();
        }

        public DataSet[] getSubReports()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
