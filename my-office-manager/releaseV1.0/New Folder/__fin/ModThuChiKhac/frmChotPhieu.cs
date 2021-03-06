using System;
using System.Data;
using System.Data.Common;
using DAO;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;


namespace office
{
    public partial class frmChotPhieu : XtraFormPL
    {
        private string _IS_DONG_MO = "";
        string KieuChot = "THANG";

        public frmChotPhieu(string IS_DONG_MO)
        {
            InitializeComponent();
            btnThucHien.Image = FWImageDic.ADD_IMAGE20;
            btnThoat.Image = FWImageDic.CLOSE_IMAGE20;
            _IS_DONG_MO = IS_DONG_MO;
            if (IS_DONG_MO == "Y")
            {
                this.Text = "Chốt kỳ kinh doanh";
                btnThucHien.Text = "&Chốt";
            }
            else
            {
                this.Text = "Mở chốt kỳ kinh doanh";
                btnThucHien.Text = "&Mở chốt";
            }
            Init((IS_DONG_MO=="Y") ? "N" : "Y");
        }

        private void Init(string IS_DONG_MO)
        {
            DataTable KKDKhongChot = DAPhieuThuChi.getKyKinhDoanh(IS_DONG_MO);
            if (KKDKhongChot.Rows.Count > 0)
            {
                DataTable temp = new DataTable();
                temp.Columns.AddRange(new DataColumn[]{
                    new DataColumn("ID",Type.GetType("System.Int32")),
                    new DataColumn("NAME",Type.GetType("System.String"))
                });
                for (int i = 0; i < KKDKhongChot.Rows.Count; i++)
                {
                    DataRow dr = temp.NewRow();
                    dr["ID"] = int.Parse(KKDKhongChot.Rows[i]["ID"].ToString());
                    dr["NAME"] = "Từ " + ((DateTime)KKDKhongChot.Rows[i]["TU_NGAY"]).ToShortDateString() + " đến " + ((DateTime)KKDKhongChot.Rows[i]["DEN_NGAY"]).ToShortDateString();
                    temp.Rows.Add(dr);
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(temp);
                KyKinhDoanh._init(temp, "NAME", "ID");
            }
        }

        private void frmChotPhieu_Load(object sender, EventArgs e)
        {
            try
            {
                string LOAI_KY = "LOAI_KY";
                DatabaseFB db = HelpDB.getDatabase();
                DbCommand cmd = db.GetSQLStringCommand("select * from THAM_SO where TEN_THAM_SO = '" + LOAI_KY + "'");
                DataSet ds = new DataSet();
                db.LoadDataSet(cmd, ds, "AA");
                KieuChot = ds.Tables[0].Rows[0]["GIA_TRI"].ToString();
                if (KieuChot == "THANG")
                {
                    NgayChot.Visible = false;
                    lblKieuChot.Text = "Kỳ kinh doanh : ";
                }
                else
                {
                    KyKinhDoanh.Visible = false;
                    lblKieuChot.Text = "Chọn ngày : ";
                }
            }
            catch (Exception ex)
            {
                HelpMsgBox.ShowErrorMessage("Loại kỳ kinh doanh không tồn tại");
                this.Close();
            }
            HelpXtraForm.SetFix(this);
            btnThucHien.Image = FWImageDic.SAVE_IMAGE16;
            btnThoat.Image = FWImageDic.CLOSE_IMAGE16;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChot_Click(object sender, EventArgs e)
        {
            if (KieuChot == "THANG" && KyKinhDoanh._getSelectedID() == -1)
            {
                HelpMsgBox.ShowErrorMessage("Bạn chưa chọn kỳ kinh doanh để chốt");
                return;
            }
            if (KieuChot == "TUY_CHON" && NgayChot.DateTime == new DateTime(1, 1, 1))
            {
                HelpMsgBox.ShowErrorMessage("Bạn chưa chọn ngày để chốt");
                return;
            }
            if (TKThongKeThuChi.CapNhatThongKe(KyKinhDoanh._getSelectedID(), _IS_DONG_MO, NgayChot.DateTime))
                 this.Close();
        }
    }
}