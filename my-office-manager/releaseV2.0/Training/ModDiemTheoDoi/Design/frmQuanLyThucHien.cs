using System;
using System.Data;
using ProtocolVN.Framework.Core;
using DTO;
using DAO;
using ProtocolVN.Framework.Win;


namespace office
{
    public partial class frmQuanLyThucHien : DevExpress.XtraEditors.XtraForm
    {
        DOQuanLyThucHien qLyThucHien;
        int loaiCongViec = 0;

        #region "khởi tạo"
        public frmQuanLyThucHien()
        {   
            InitializeComponent();
            qLyThucHien = new DOQuanLyThucHien(gbNgay, gridControl1, advBGridView1, barTuan, listBangTheoDoi);

            //thể hiện list bảng theo dỏi
            qLyThucHien.listBTD.ValueMember = "BTD_ID";
            qLyThucHien.listBTD.DisplayMember = "NAME";
            qLyThucHien.listBTD.DataSource = HelpDB.getDatabase().LoadDataSet("select BTD_ID, MA_BTD,NAME from BANG_THEO_DOI").Tables[0];
            //thể hiện ngày
            qLyThucHien.barTime.EditValue = DateTime.Today;
            if(loaiCongViec == 1)
                DAQuanLyThucHienLenLop.initQLTH(this.colNhanSu, qLyThucHien);
            if(loaiCongViec == 2)
                DAQuanLyThucHienNopBai.initQLTH(this.colNhanSu,qLyThucHien);
        }
        #endregion

        #region "Xử lý sự kiện"
        private void barTuan_EditValueChanged(object sender, EventArgs e)
        {
            gbNgay.Caption = HelpDateExt.GetDayOfWeekVN(Convert.ToDateTime(qLyThucHien.barTime.EditValue)) + " : " + Convert.ToDateTime(qLyThucHien.barTime.EditValue).ToShortDateString();
            if(loaiCongViec == 1)
                DAQuanLyThucHienLenLop.reLoadData(long.Parse(qLyThucHien.listBTD.GetItemValue(qLyThucHien.listBTD.SelectedIndex).ToString()), Convert.ToDateTime(qLyThucHien.barTime.EditValue), qLyThucHien.gridControl);
            if(loaiCongViec == 2)
                DAQuanLyThucHienNopBai.reLoadData(long.Parse(qLyThucHien.listBTD.GetItemValue(qLyThucHien.listBTD.SelectedIndex).ToString()), Convert.ToDateTime(qLyThucHien.barTime.EditValue), qLyThucHien.gridControl);
        }

        private void listBangTheoDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            long btd_id = long.Parse(qLyThucHien.listBTD.GetItemValue(qLyThucHien.listBTD.SelectedIndex).ToString());
            int loaiCongViecTemp = 0;
            DataSet ds = HelpDB.getDatabase().LoadDataSet("select BTD_ID from DIEM_THEO_DOI_LEN_LOP where BTD_ID = " + btd_id);
            if (ds.Tables[0].Rows.Count > 0)
                loaiCongViecTemp = 1;
            ds.Clear();
            ds = DABase.getDatabase().LoadDataSet("select BTD_ID from DIEM_THEO_DOI_NOP_BAI where BTD_ID = " + btd_id);
            if (ds.Tables[0].Rows.Count > 0)
                loaiCongViecTemp = 2;
            if (loaiCongViec != loaiCongViecTemp)
            {
                loaiCongViec = loaiCongViecTemp;
                if (loaiCongViec == 0)
                    DAQuanLyThucHien.clearFullColumn(qLyThucHien.gridControl,qLyThucHien.gridBand,colNhanSu);
                
                if (loaiCongViec == 1)
                    DAQuanLyThucHienLenLop.initQLTH(colNhanSu, qLyThucHien);
                if (loaiCongViec == 2)
                    DAQuanLyThucHienNopBai.initQLTH(colNhanSu, qLyThucHien);
            }
            else
            {
                if (loaiCongViecTemp == 1)
                    DAQuanLyThucHienLenLop.reLoadData(long.Parse(qLyThucHien.listBTD.GetItemValue(qLyThucHien.listBTD.SelectedIndex).ToString()), Convert.ToDateTime(qLyThucHien.barTime.EditValue), qLyThucHien.gridControl);
                if (loaiCongViecTemp == 2)
                    DAQuanLyThucHienNopBai.reLoadData(long.Parse(qLyThucHien.listBTD.GetItemValue(qLyThucHien.listBTD.SelectedIndex).ToString()), Convert.ToDateTime(qLyThucHien.barTime.EditValue), qLyThucHien.gridControl);
            }
        }

        private void advBGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(loaiCongViec == 1)
                if (DAQuanLyThucHienLenLop.dangNhap(qLyThucHien.gridView, qLyThucHien.gridControl))
                    DAQuanLyThucHienLenLop.reLoadData(long.Parse(qLyThucHien.listBTD.GetItemValue(qLyThucHien.listBTD.SelectedIndex).ToString()), Convert.ToDateTime(qLyThucHien.barTime.EditValue), qLyThucHien.gridControl);
            if(loaiCongViec == 2)
                if (DAQuanLyThucHienNopBai.dangNhap(qLyThucHien.gridView, qLyThucHien.gridControl, qLyThucHien.barTime)) 
                    DAQuanLyThucHienNopBai.reLoadData(long.Parse(qLyThucHien.listBTD.GetItemValue(qLyThucHien.listBTD.SelectedIndex).ToString()), Convert.ToDateTime(qLyThucHien.barTime.EditValue), qLyThucHien.gridControl);
        }
        #endregion
    }
}