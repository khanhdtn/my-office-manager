using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAO;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;

using office;

namespace office
{
    public partial class frmViewThreadIssue : XtraFormPL
    {
        #region Các khai báo biến
        private long _ID;
        private long _NguoiGuiID;
        private string _NguoiNhanID;
        private long _TinhTrang;
        private ucReplyIssue ucReply1;
        private int DefaultWidth;

        public delegate void _AfterDeleteSuccessfully();
        public _AfterDeleteSuccessfully AfterDeleteSuccessfully;

        public delegate void _AfterUpdateStatusOfIssue(long TinhTrang, object[] infos);
        public event _AfterUpdateStatusOfIssue AfterUpdateStatusOfIssue;
        #endregion

        #region Hàm khởi tạo
        public frmViewThreadIssue(long ID,long NguoiGuiID,string NguoiNhanID, long TinhTrang)
        {
            InitializeComponent();
            _ID = ID;
            _NguoiGuiID = NguoiGuiID;
            _NguoiNhanID = NguoiNhanID;
            _TinhTrang = TinhTrang;
            btn_TL.Visible = TinhTrang == 3 ? false : true;
        }

        public frmViewThreadIssue()
        {
            InitializeComponent();
        }
        #endregion

        #region Sự kiện Form và controls
        private void frmCapNhat_Load(object sender, EventArgs e)
        {
            DefaultWidth = flowLayoutPanel1.Width - 15;
            Load_Van_De();
        }

        private void btnTL_Click_1(object sender, EventArgs e)
        {
            HelpXtraForm.CloseFormNoConfirm(this);
        }
        private void btn_TL_Click(object sender, EventArgs e)
        {
            frmBugProduct frm = new frmBugProduct(_ID, true);
            frm.AfterAddReplyIssueSuccessfully += delegate(DTO.DOReplyBugProduct doReplyBugProduct)
            {
                ucReplyIssue ucReply1 = new ucReplyIssue(this,
                       doReplyBugProduct.ID, doReplyBugProduct.NGUOI_GUI, doReplyBugProduct.NGAY_GUI
                       , doReplyBugProduct.NOI_DUNG, doReplyBugProduct.DSFile, "TEN_FILE", "NOI_DUNG", _TinhTrang);
                flowLayoutPanel1.Controls.Add(ucReply1);
                ucReply1.Width = DefaultWidth;
                xtraScrollableControl1.ScrollControlIntoView(ucReply1);
                ucReplyIssue ucReplyIssue1 = (ucReplyIssue)this.flowLayoutPanel1.Controls[0];
                ucReplyIssue1.btnUpdate.Visible = false;
            };
            frm.AfterUpdateStatusOfIssue += delegate(long TinhTrang,object[] infos) {
                ucReplyIssue ucReplyIssue1 = (ucReplyIssue)this.flowLayoutPanel1.Controls[0];
                switch (TinhTrang)
                {
                    case 1:
                        ucReplyIssue1.lblTinhTrang.Text = "Mới tạo";
                        break;
                    case 2:
                        ucReplyIssue1.lblTinhTrang.Text = "Đang xử lý";
                        break;
                    default:
                        ucReplyIssue1.lblTinhTrang.Text = "Hoàn tất";
                        ucReplyIssue1.btnUpdate.Visible = false;
                        for (int i = 1; i < this.flowLayoutPanel1.Controls.Count; i++)
                        {
                            ucReplyIssue _ucReplyIssue = (ucReplyIssue)this.flowLayoutPanel1.Controls[i];
                            _ucReplyIssue.btnUpdate.Visible = false;
                            this.btn_TL.Visible = false;
                        }
                        break;
                }
                UpdateIssue(TinhTrang, infos);
            };
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        #endregion

        #region Hàm hỗ trợ

        public void UpdateIssue(long TinhTrang, object[] infos) {
            if (AfterUpdateStatusOfIssue != null) AfterUpdateStatusOfIssue(TinhTrang, infos);
        }

        private DataTable Cac_Van_De_Lien_Quan(long ID)
        {
            string sql = @"SELECT PH.*
                                FROM PHAN_HOI_BUG PH                                 
                                WHERE PH.BUG_ID=@ID";

            FWDBService db = HelpDB.getDBService();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "PHAN_HOI_BUG");
            return ds.Tables[0];
        }
        private DataTable GetAllFile(long ID)
        {
            string sqlFile = string.Format(@"SELECT OBJ.OBJECT_ID,LT.ID,LT.TEN_FILE,LT.NOI_DUNG
                        FROM OBJECT_TAP_TIN OBJ
                        INNER JOIN LUU_TRU_TAP_TIN LT ON LT.ID=OBJ.TAP_TIN_ID
                        WHERE OBJ.TYPE_ID=9 AND
                        (OBJ.OBJECT_ID IN 
                        (SELECT ID FROM BUG WHERE ID={0})
                        OR OBJ.OBJECT_ID IN (SELECT ID FROM PHAN_HOI_BUG WHERE BUG_ID={1}))", ID, ID);
            DataSet dsFile = HelpDB.getDBService().LoadDataSet(sqlFile);
            return dsFile.Tables[0];
        }

        private void Load_Van_De()
        {
            DataTable dtVanDe = DABugProduct.Get_Bang_Van_De(_ID);
            this.Text = dtVanDe.Rows[0]["NAME"].ToString();
            DataTable Dt = Cac_Van_De_Lien_Quan(_ID);
            DataTable dtListFile = GetAllFile(_ID);
            DataRow[] Dr = new DataRow[1];
            if (dtVanDe.Rows.Count > 0)
            {
                Dr = dtVanDe.Select("1=1");
                DataSet dsListFile = new DataSet();
                dtListFile.DefaultView.RowFilter = string.Format("OBJECT_ID={0}", _ID);
                dsListFile.Tables.Add(dtListFile.DefaultView.ToTable());
                //Add issue 
                this.ucReply1 = new ucReplyIssue(this,
                    HelpNumber.ParseInt64(Dr[0]["ID"]), _NguoiGuiID,
                    Convert.ToDateTime(Dr[0]["NGAY_GUI"]), Dr[0]["MO_TA_BUG"],
                  dsListFile, "TEN_FILE", "NOI_DUNG", _TinhTrang, new string[] { this.Text, dtVanDe.Rows[0]["TEN_TINH_TRANG"].ToString() });
                this.ucReply1.AfterDeleteSuccessfully += new ucReplyIssue._AfterDeleteSuccessfully(ucReply1_AfterDeleteSuccessfully);
                this.ucReply1.Width = DefaultWidth;
                if (this.ucReply1.btnUpdate.Visible == true)
                    this.ucReply1.btnUpdate.Visible = !(Dt.Rows.Count > 0);
                this.ucReply1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                this.flowLayoutPanel1.Controls.Add(this.ucReply1);
                //Add replies of issue
                foreach (DataRow row in Dt.Rows)
                {
                    DataSet dsListFileC = new DataSet();
                    dtListFile.DefaultView.RowFilter = string.Format("OBJECT_ID={0}", HelpNumber.ParseInt64(row["ID"]));
                    dsListFileC.Tables.Add(dtListFile.DefaultView.ToTable());

                    this.ucReply1 = new ucReplyIssue(this,
                        HelpNumber.ParseInt64(row["ID"]), HelpNumber.ParseInt64(row["NGUOI_GUI"]),
                        Convert.ToDateTime(row["NGAY_GUI"]), row["NOI_DUNG"],
                      dsListFileC, "TEN_FILE", "NOI_DUNG",_TinhTrang);

                    this.ucReply1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    this.ucReply1.Width = DefaultWidth;
                    this.flowLayoutPanel1.Controls.Add(this.ucReply1);
                }
            }
            #endregion
        }

        void ucReply1_AfterDeleteSuccessfully()
        {
            if (this.AfterDeleteSuccessfully != null) this.AfterDeleteSuccessfully();
        }
        
    }
}