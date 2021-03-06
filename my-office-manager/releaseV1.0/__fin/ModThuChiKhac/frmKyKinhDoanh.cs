using System;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace office
{
    public partial class frmKyKinhDoanh : XtraFormPL
    {        
        public frmKyKinhDoanh()
        {
            InitializeComponent();
            InitGridColumns();
        }

        private void InitGridColumns()
        {
            XtraGridSupportExt.TextLeftColumn(ColTuNgay, "TU_NGAY");
            XtraGridSupportExt.TextLeftColumn(ColDenNgay, "DEN_NGAY");
            XtraGridSupportExt.DecimalGridColumn(ColDuDauKy, "SO_DU_DAU_KY",0);
            XtraGridSupportExt.DecimalGridColumn(ColPhatSinhTang, "PHAT_SINH_TANG",0);
            XtraGridSupportExt.DecimalGridColumn(ColPhatSinhGiam, "PHAT_SINH_GIAM",0);
            XtraGridSupportExt.DecimalGridColumn(ColDuCuoiKy, "SO_DU_CUOI_KY",0);
            HelpGridColumn.CotPLImageCheck(ColKetChuyen, "IS_KET_CHUYEN");
            ColPhatSinhTang.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            ColPhatSinhGiam.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
        }

        private void frmKyKinhDoanh_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetCloseForm(this, btnDong, null);
            btnDong.Image = FWImageDic.CLOSE_IMAGE20;

            string Sql = @"SELECT   
                                TU_NGAY,DEN_NGAY,SO_DU_DAU_KY,
                                PHAT_SINH_TANG,PHAT_SINH_GIAM,
                                SO_DU_CUOI_KY,IS_KET_CHUYEN
                           FROM DM_KY_KINH_DOANH INNER JOIN TIEN_MAT_DAU_KY ON ID=KKD_ID";
            DatabaseFB db = HelpDB.getDatabase();
            gridControlMaster.DataSource = db.LoadDataSet(Sql, "THONG_TIN_KKD").Tables[0];
            HelpXtraForm.SetFix(this);
        }
                  
    }
}