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
using ProtocolVN.Plugin.TimeSheet.report;

namespace ProtocolVN.Plugin.TimeSheet.report
{
    public partial class CT_RPT_NHANVIEN : XtraUserControl, IReportFilter
    {
        public CT_RPT_NHANVIEN()
        {
            InitializeComponent();
        }

        private void CT_RPT_NHANVIEN_Load(object sender, EventArgs e)
        {
            PLTimeSheetCtrl.ChonNhanVienRPT(PLcbnhan_vien);
            DenNgay.DateTime = HelpDB.getDatabase().GetSystemCurrentDateTime();
        }

        #region IReportFilter Members

        public Dictionary<string, object> GetParamFieldValue()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("TN", this.TuNgay.DateTime);
            dic.Add("DN", this.DenNgay.DateTime);
            return dic;
        }

        public void ValidateFilter(DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider Error)
        {
            if (PLcbnhan_vien._getSelectedID() == -1)
                PLcbnhan_vien.SetError(Error, "Vui lòng chọn Nhân Viên!");
            if (HelpNumber.ParseInt32(TuNgay.DateTime.ToString("yyyy")) < 2000)
            {
                Error.SetError(TuNgay, "Mời bạn nhập từ ngày!");
            }
            if (HelpNumber.ParseInt32(DenNgay.DateTime.ToString("yyyy")) < 2000)
            {
                Error.SetError(TuNgay, "Mời bạn nhập từ ngày!");
            }
            if (!HelpIsCheck.IsALessEqualB(TuNgay.DateTime, DenNgay.DateTime))
                Error.SetError(TuNgay, "Từ ngày phải nhỏ hơn hoặc bằng ngày đến !");

            if (DenNgay.DateTime > HelpDB.getDatabase().GetSystemCurrentDateTime())
                Error.SetError(DenNgay, "Ngày đến phải nhỏ hơn hoặc bằng ngày hiện tại !");
            
        }

        public DataSet getDataSet()
        {
            return PLTimeSheetReport.GetIN_ST_RPT_NHANVIEN(HelpNumber.ParseInt64(PLcbnhan_vien._getSelectedID()),TuNgay.DateTime,DenNgay.DateTime);
        }

        public DataSet[] getSubReports()
        {
            return null;
        }       
        #endregion
    }
}
