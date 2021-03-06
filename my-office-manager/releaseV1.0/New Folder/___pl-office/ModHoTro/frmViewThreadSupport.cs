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
    public partial class frmViewThreadSupport : XtraFormPL
    {
        #region Các khai báo biến
        private long _ID;
        private long _NguoiGuiID;
        private string _NguoiNhanID;
        private long _TinhTrang;
        private ucReply ucReply1;
        private int DefaultWidth;

        public delegate void _AfterDeleteSuccessfully(bool isDeleteSupport);
        public _AfterDeleteSuccessfully AfterDeleteSuccessfully;

        public delegate void _AfterUpdateStatusOfSupport(long TinhTrang, object[] infos);
        public event _AfterUpdateStatusOfSupport AfterUpdateStatusOfSupport;
        #endregion

        #region Hàm khởi tạo
        public frmViewThreadSupport(long ID,long NguoiGuiID,string NguoiNhanID, long TinhTrang)
        {
            InitializeComponent();
            _ID = ID;
            _NguoiGuiID = NguoiGuiID;
            _NguoiNhanID = NguoiNhanID;
            _TinhTrang = TinhTrang;
            btn_TL.Visible = TinhTrang == 4 ? false : true;
        }

        public frmViewThreadSupport()
        {
            InitializeComponent();
        }
        #endregion

        #region Sự kiện Form và controls
        private void frmCapNhat_Load(object sender, EventArgs e)
        {
            DefaultWidth = flowLayoutPanel1.Width - 15;
            Load_Yeu_Cau();
        }

        private void btnTL_Click_1(object sender, EventArgs e)
        {
            HelpXtraForm.CloseFormNoConfirm(this);
        }
        private void btn_TL_Click(object sender, EventArgs e)
        {
            frmHotro frm = new frmHotro(_ID, _NguoiGuiID, _NguoiNhanID, _TinhTrang, true);
            frm.AfterAddReplySuccesfully += delegate(DAO.DOPhanHoi doPhanHoi)
            {
                ucReply ucReply1 = new ucReply(this,
                        doPhanHoi.ID, doPhanHoi.NGUOI_GUI_ID, doPhanHoi.NGUOI_NHAN_ID, doPhanHoi.NGAY_GUI, doPhanHoi.NOI_DUNG,
                      doPhanHoi.DSTapTinDinhKem, "TEN_FILE", "NOI_DUNG", _TinhTrang);
                flowLayoutPanel1.Controls.Add(ucReply1);
                ucReply1.Width = DefaultWidth;
                xtraScrollableControl1.ScrollControlIntoView(ucReply1);
                ucReply ucReplyIssue1 = (ucReply)this.flowLayoutPanel1.Controls[0];
                ucReplyIssue1.btnUpdate.Visible = false;
            };
            frm.AfterUpdateStatusOfSupport += delegate(long TinhTrang, object[] infos) {
                ucReply ucReply1 = (ucReply)this.flowLayoutPanel1.Controls[0];
                switch (TinhTrang)
                {
                    case 1:
                        ucReply1.lblTinhTrang.Text = "Mới tạo";
                        break;
                    case 2:
                        ucReply1.lblTinhTrang.Text = "Đang xử lý";
                        break;
                    case 3:
                        ucReply1.lblTinhTrang.Text = "Không hỗ trợ";
                        break;
                    case 4:
                        ucReply1.lblTinhTrang.Text = "Hoàn tất";
                        ucReply1.btnUpdate.Visible = false;
                        for (int i = 1; i < this.flowLayoutPanel1.Controls.Count; i++)
                        {
                            ucReply _ucReply = (ucReply)this.flowLayoutPanel1.Controls[i];
                            _ucReply.btnUpdate.Visible = false;
                            this.btn_TL.Visible = false;
                        }
                        break;
                }
                UpdateTinhTrang(TinhTrang, infos);
            };
            HelpProtocolForm.ShowModalDialog(this, frm);
        }

        #endregion

        #region Hàm hỗ trợ

        public void UpdateTinhTrang(long TinhTrang, object[] infos) {
            if (AfterUpdateStatusOfSupport != null) AfterUpdateStatusOfSupport(TinhTrang, infos);
        }

        private DataTable Cac_Yeu_Cau_Lien_Quan(long ID)
        {
            string sql = @"SELECT YCTL.*
                                FROM YEU_CAU_TRA_LOI YCTL                                 
                                WHERE YCTL.YEU_CAU_ID=@ID";

            FWDBService db = HelpDB.getDBService();
            DbCommand cmd = db.GetSQLStringCommand(sql);
            db.AddInParameter(cmd, "@ID", DbType.Int64, ID);
            DataSet ds = new DataSet();
            db.LoadDataSet(cmd, ds, "YEU_CAU_TRA_LOI");
            return ds.Tables[0];
        }
        private DataTable GetAllFile(long ID)
        {
            string sqlFile = string.Format(@"SELECT OBJ.OBJECT_ID,LT.ID,LT.TEN_FILE,LT.NOI_DUNG
            FROM OBJECT_TAP_TIN OBJ
            INNER JOIN LUU_TRU_TAP_TIN LT ON LT.ID=OBJ.TAP_TIN_ID
            WHERE OBJ.TYPE_ID=10
            AND (OBJ.OBJECT_ID IN (SELECT ID FROM YEU_CAU WHERE ID = {0}  )
            OR (OBJ.OBJECT_ID IN (SELECT ID FROM YEU_CAU_TRA_LOI YCTL  WHERE YCTL.YEU_CAU_ID={1})))", ID, ID);
            DataSet dsFile = HelpDB.getDBService().LoadDataSet(sqlFile);
            return dsFile.Tables[0];
        }

        private void Load_Yeu_Cau()
        {
            DataTable dtYeuCau = DAYeuCau.Get_Bang_yeu_cau(_ID);
            this.Text = dtYeuCau.Rows[0]["CHU_DE"].ToString();
            DataTable Dt = Cac_Yeu_Cau_Lien_Quan(_ID);
            DataTable dtListFile = GetAllFile(_ID);
            if (dtYeuCau.Rows.Count > 0)
            {
                DataRow Dr = dtYeuCau.Rows[0];
                DataSet dsListFile = new DataSet();
                dtListFile.DefaultView.RowFilter = string.Format("OBJECT_ID={0}", _ID);
                dsListFile.Tables.Add(dtListFile.DefaultView.ToTable());
                //Add support 
                this.ucReply1 = new ucReply(this,
                    HelpNumber.ParseInt64(Dr["ID"]), _NguoiGuiID,Dr["NGUOI_NHAN_ID"].ToString(),
                    Convert.ToDateTime(Dr["NGAY_GUI"]), Dr["NOI_DUNG"],
                  dsListFile, "TEN_FILE", "NOI_DUNG", _TinhTrang, new string[] { this.Text, dtYeuCau.Rows[0]["TEN_TINH_TRANG"].ToString() });
                this.ucReply1.AfterDeleteSuccessfully += new ucReply._AfterDeleteSuccessfully(ucReply1_AfterDeleteSuccessfully);
                this.ucReply1.Width = DefaultWidth;
                if (this.ucReply1.btnUpdate.Visible == true)
                    this.ucReply1.btnUpdate.Visible = !(Dt.Rows.Count > 0);
                this.ucReply1.label6.Text = "Người yêu cầu:";
                this.ucReply1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                this.flowLayoutPanel1.Controls.Add(this.ucReply1);
                //Add replies of support
                foreach (DataRow row in Dt.Rows)
                {
                    DataSet dsListFileC = new DataSet();
                    dtListFile.DefaultView.RowFilter = string.Format("OBJECT_ID={0}", HelpNumber.ParseInt64(row["ID"]));
                    dsListFileC.Tables.Add(dtListFile.DefaultView.ToTable());

                    this.ucReply1 = new ucReply(this,
                        HelpNumber.ParseInt64(row["ID"]), HelpNumber.ParseInt64(row["NGUOI_GUI_ID"]),row["NGUOI_NHAN_ID"].ToString(),
                        Convert.ToDateTime(row["NGAY_GUI"]), row["NOI_DUNG"],
                      dsListFileC, "TEN_FILE", "NOI_DUNG",_TinhTrang);
                    this.ucReply1.AfterDeleteSuccessfully += new ucReply._AfterDeleteSuccessfully(ucReply1_AfterDeleteSuccessfully);
                    this.ucReply1.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                    this.ucReply1.Width = DefaultWidth;
                    this.flowLayoutPanel1.Controls.Add(this.ucReply1);
                }
            }
            #endregion
        }

        void ucReply1_AfterDeleteSuccessfully(bool isDeleteSupport)
        {
            if (this.AfterDeleteSuccessfully != null) this.AfterDeleteSuccessfully(isDeleteSupport);
        }
    }
}