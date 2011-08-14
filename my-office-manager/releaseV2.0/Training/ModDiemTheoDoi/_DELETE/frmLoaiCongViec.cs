using System;
using System.Data;
using System.Windows.Forms;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DTO;
using DAO;



namespace pl.office.form
{
    public partial class frmLoaiCongViec : DevExpress.XtraEditors.XtraForm
    {
        DOLoaiCongViec doLoaiCV = null;
        DALoaiCongViec daLoaiCV = null;
        DataSet ds;
        
        public frmLoaiCongViec()
        {
            InitializeComponent();
            InitButtonImage();
            Load();
            
            repchkHienThi.ValueChecked = "Y";
            repchkHienThi.ValueUnchecked = "N";
            repchkHienThi.ValueGrayed = null;

            HelpGridColumn.CotMemoExEdit(cotMO_TA, "MO_TA");
            XtraGridSupportExt.CloseButton(gridControl1, gridView2);

            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
        }
        private void Load()
        {
            daLoaiCV = new DALoaiCongViec();
            ds = daLoaiCV.Load();
            gridControl1.DataSource = ds.Tables[0];

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daLoaiCV = new DALoaiCongViec();
                DataSet ds1 = daLoaiCV.Load();
                int i = 0;
                foreach (DataRow row in ((DataTable)gridControl1.DataSource).Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        doLoaiCV = new DOLoaiCongViec();
                        doLoaiCV.LCV_ID = long.Parse(row["LCV_ID"].ToString());
                        doLoaiCV.MA_LCV = row["MA_LCV"].ToString();
                        doLoaiCV.NAME = row["NAME"].ToString();
                        doLoaiCV.MO_TA = row["MO_TA"].ToString();
                        doLoaiCV.VISIBLE_BIT = row["VISIBLE_BIT"].ToString();
                        daLoaiCV.Them(false, doLoaiCV);
                    }
                    if (row.RowState == DataRowState.Added)
                    {
                        doLoaiCV = new DOLoaiCongViec();
                        doLoaiCV.LCV_ID = long.Parse(row["LCV_ID"].ToString());
                        doLoaiCV.MA_LCV = row["MA_LCV"].ToString();
                        doLoaiCV.NAME = row["NAME"].ToString();
                        doLoaiCV.MO_TA = row["MO_TA"].ToString();
                        doLoaiCV.VISIBLE_BIT = row["VISIBLE_BIT"].ToString();

                        daLoaiCV.Them(true, doLoaiCV);
                    }
                    if (row.RowState == DataRowState.Deleted)
                    {
                        doLoaiCV = new DOLoaiCongViec();
                        doLoaiCV.LCV_ID = long.Parse(ds1.Tables[0].Rows[i]["LCV_ID"].ToString());
                        daLoaiCV.Xoa(doLoaiCV);
                    }
                    i++;
                }

                Load();

                btnLuu.Enabled = false;
                btnKhongLuu.Enabled = false;
            }
            catch (Exception ex)
            {
                PLMessageBox.ShowNotificationMessage(ex.Message);
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsValidate()
        {
            bool flag = true;
            Error.ClearErrors();
            if (retxtNAME.ToString() == "")
            {
                Error.SetError(gridControl1, "Vui lòng nhập tên loại công việc");
                flag = false;
                
            }
            return flag;
        }

        private void LayMA(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow row = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            row.ClearErrors();
            if (row["NAME"].ToString() == "")
                row.SetColumnError(2, "Vui lòng nhập tên loại công việc");
            else
            {
                if (row["LCV_ID"].ToString() == "")
                {
                    string a = DatabaseFB.GetThamSo("MA_LCV").ToString();
                    gridView2.SetRowCellValue(e.RowHandle, cotLCVID, long.Parse(HelpGen.ID("G_NGHIEP_VU").ToString()));
                    gridView2.SetRowCellValue(e.RowHandle, cotMALCV, DatabaseFB.getSoPhieu("LOAI_CONG_VIEC", "MA_LCV", a));
                }
            }
        }
        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            LayMA(sender,e); 
           
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            if (PLMessageBox.ShowConfirmMessage("Bạn có chắc chắn muốn làm lại loại công việc không ? ") == DialogResult.Yes)
            {
                Load();
                btnLuu.Enabled = false;
                btnKhongLuu.Enabled = false;
            }
        }
        public void InitButtonImage()
        {
            btnLuu.Image = FWImageDic.ADD_IMAGE20;
            btnDong.Image = FWImageDic.CLOSE_IMAGE20;
            btnKhongLuu.Image = FWImageDic.DELETE_IMAGE20;
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
        }

        private void gridView2_RowCountChanged(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
        }

    }
}