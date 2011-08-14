using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraReports.UI;
using CrystalDecisions.Shared;
using System.Drawing.Printing;

namespace ProtocolVN.Framework.Win
{
    public class _PrintXtra
    {
        // Fields
        private DataSet mainDataset=null;
        private XtraReport mainReport=null;
        private Dictionary<string, object> parametres;
        //private string reportNameFile;
        private DataSet[] subDataset=null;
        private List<XtraReport> SubReport;

        //private string[] subReportFileNames;
        //private _ConfigPrinter thietDatIn;
        public _PrintXtra()
        { 
            
        }
        public _PrintXtra(XtraReport Report)
        {
            mainReport = Report;
            SubReport = GetSubReport(getBands(mainReport));
        }
        /// <summary>
        /// set and get SubDataSet
        /// </summary>
        public DataSet[] _SubDataSet
        {
            set { this.subDataset = value; }
            get { return subDataset; }
        }
        /// <summary>
        /// set and get MainReport
        /// </summary>
        public XtraReport _MainReport
        {
            set {
                this.mainReport = value;
                this.SubReport = GetSubReport(this.mainReport.Bands);
            }
            get { return this.mainReport; }
        }
        // Properties
        /// <summary>
        /// set and get MainDataSet for MainReport
        /// </summary>
        public DataSet _MainDataset
        {
            get
            {
                return this.mainDataset;
            }
            set
            {
                this.mainDataset = value;
            }
        }
        /// <summary>
        /// set and get Parameters for MainReport
        /// </summary>
        public Dictionary<string, object> _Parametres
        {
            get
            {
                return this.parametres;
            }
            set
            {
                this.parametres = value;
            }
        }
        //public _ConfigPrinter ThietDatIn
        //{
        //    get
        //    {
        //        return this.thietDatIn;
        //    }
        //    set
        //    {
        //        this.thietDatIn = value;
        //    }
        //}
        //Hàm này không sài nữa
        private BandCollection getBands(XtraReport xtraReport)
        {
            BandCollection collection = new BandCollection(new XtraReport());
            foreach (Band band in xtraReport.Bands)
            {
                if ((band.Name != "PageHeader") && (band.Name != "PageFooter"))
                {
                    collection.Add(band);
                }
            }
            return collection;
        }
        //Hàm này không sài nữa
        private List<XtraReport> GetSubReport(BandCollection ListBand)
        {       
            List<XtraReport> subreport = new  List<XtraReport>();
            foreach (Band band in ListBand)
            {
                foreach (XRControl xrControl in band.Controls)
                {
                    if (xrControl is XRSubreport)
                    {
                        subreport.Add(((XRSubreport)xrControl).ReportSource); 
                    }
                }
            }
            return subreport;
        
        }
        /// <summary>
        /// Init Parameter for MainReport
        /// </summary>
        /// <param name="report"></param>

        private void InitParameter(XtraReport report)
        {
            if (this.parametres != null &&  report.Parameters != null)
            {
                foreach (string str in this.parametres.Keys)
                {
                    object obj2;
                    this.parametres.TryGetValue(str, out obj2);
                    DevExpress.XtraReports.Parameters.Parameter field = report.Parameters[str];
                    field.Value = obj2;                  
                }
            }
        }
        private void InitDataSourceForSubReport()
        {
            if (this.subDataset != null&& this.SubReport!=null)
            {
                for (int i = 0; i < subDataset.Length; i++)
                { 
                    foreach(XtraReport itemreport in this.SubReport)
                    {
                        try
                        {
                            //DataSet ds=(DataSet)itemreport.DataSource;
                            if (itemreport.DataMember.ToUpper().Equals(subDataset[i].Tables[0].TableName))
                            {
                                itemreport.DataSource = subDataset[i].Tables[0];
                                break;
                            }
                        }
                        catch { }
                    }
                }
            }
        }
        private void InitMainReport()
        {
            if(this.mainDataset!=null&& this.mainDataset.Tables.Count>0)
                this.mainReport.DataSource = this.mainDataset.Tables[0];
            InitDataSourceForSubReport();
            InitParameter(this.mainReport);
        }
        // private void InitThietLapMayIn()
        //{
        //    if (this.thietDatIn.PrinterName != "")
        //    {
        //        this.mainReport.PrinterName = this.mPrinterName;
        //    }
        //    if (this.thietDatIn.PageSize != "")
        //    {
        //        this.mainReport.PageSize = (PaperSize)Enum.Parse(typeof(PaperSize), thietDatIn.PageSize);
        //    }
        //    if ((((this.mMarginLeft > 0) && (this.mMarginRight > 0)) && (this.mMarginTop > 0)) && (this.mMarginBottom > 0))
        //    {
        //        PageMargins margin = new PageMargins(this.mMarginLeft, this.mMarginTop, this.mMarginRight, this.mMarginBottom);
        //        document1.PrintOptions.ApplyPageMargins(margin);
        //    }
        //}

        //private void 
        // Methods
        public void execDirectlyPrint()
        {           
            if (PrinterSettings.InstalledPrinters.Count != 0)// co may in de in
            {
                this.mainReport.Print(FrameworkParams.option.printerName);
            }
            else
            {
                HelpMsgBox.ShowNotificationMessage("Không tồn tại máy in nào");
            }
        }

        public void execPintShowDialog()
        {
            InitMainReport();
            this.mainReport.PrintDialog();
        }
        /// <summary>
        /// Xem trước khi in
        /// </summary>
        public void execPreviewWith()
        {            
            InitMainReport();
            mainReport.ShowPreview();
        }

        

        //public string ReportNameFile
        //{
        //    get
        //    {
        //        return this.reportNameFile;
        //    }
        //    set
        //    {
        //        this.reportNameFile = RadParams.RUNTIME_PATH + ┌.£ҳ() + value;
        //    }
        //}

       

        //public string[] SubReportFileName
        //{
        //    get
        //    {
        //        return this.subReportFileNames;
        //    }
        //    set
        //    {
        //        this.subReportFileNames = value;
        //    }
        //}

       
    }


}
