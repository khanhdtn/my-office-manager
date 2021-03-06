using System;
using System.Data;
using DAO;
using DTO;
using pl.helpdate;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;

namespace office
{
    public partial class frmThemLichTuan : XtraFormPL, IFormChild
    {

        #region 1.0.Danh sách biến toàn cục
        public delegate void ChuyenDuLieu(DOLichLamViec LichDTO);
        public event ChuyenDuLieu ThemMoiLichTuan;
        public DOLichLamViec Lich = null;
        #endregion

        #region 2.0.Hàm khởi tạo
        public frmThemLichTuan()
        {
            InitializeComponent();
            this.InitControl();
            this.InitData();
            this.InitEnabledControl();
            this.InitNghiepVu();
            this.InitButtonImage();
            this.btn_thoat.Image = FWImageDic.CLOSE_IMAGE16;
            this.btn_thuchien.Image = FWImageDic.SAVE_IMAGE16;
        }
        #region IFormChild Members

        public void InitControl()
        {

        }

        public void InitData()
        {
            dateEdit_NgayDauTuan.DateTime = HelpDateExt.MondayNextWeek();
        }

        public void InitEnabledControl()
        {

        }

        public void InitNghiepVu()
        {

        }

        public void InitButtonImage()
        {
            btn_thuchien.Image = FWImageDic.ADD_IMAGE20;
            
            btn_thoat.Image = FWImageDic.CLOSE_IMAGE20;
        }

       
        #endregion
        #endregion

        #region 3.0.Xử lý sự kiện (Lưu,Thêm,...)
        private void dateEdit_NgayDauTuan_EditValueChanged(object sender, EventArgs e)
        {
            string Thu = dateEdit_NgayDauTuan.DateTime.DayOfWeek.ToString();
            if (Thu != "Monday")
            {
                HelpMsgBox.ShowSystemErrorMessage("Bạn phải chọn ngày thứ hai đầu tuần làm việc");
            }
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            PLGUIUtil.DongForm(this);
        }
        private void btn_thuchien_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.DoEvents();
            DataTable LichCoDinh = DALichLamViec.Install.getLichCoDinh();
            if (LichCoDinh.Rows.Count == 0)
            {
                HelpMsgBox.ShowErrorMessage("Chưa có lịch làm việc cố định");
                return;
            }
            if (dateEdit_NgayDauTuan.DateTime.DayOfWeek.ToString() != "Monday")
            {
                HelpMsgBox.ShowErrorMessage("Bạn phải chọn thứ hai đầu tuần");
                return;
            }
            else
            {
                if (DALichLamViec.Install.Exist_LichTuan(HelpDateExt.DayFirstOfWeek(dateEdit_NgayDauTuan.DateTime)))
                {
                    HelpMsgBox.ShowErrorMessage("Lịch làm việc này đã có trong danh sách lịch làm việc");
                    return;
                }
                try
                {
                    for (int i = 0; i < LichCoDinh.Rows.Count; i++)
                    {
                        Lich = new DOLichLamViec();
                        Lich.ID = DALichLamViec.Install.getGenID();
                        Lich.NV_ID = long.Parse(LichCoDinh.Rows[i]["NV_ID"].ToString());
                        Lich.NGAY_DAU_TUAN = HelpDateExt.DayFirstOfWeek(dateEdit_NgayDauTuan.DateTime);
                        Lich.GHI_CHU = "";
                        int cn = -1;
                        for (int j = 2; j <= 8; j++)
                        {
                            Lich.NGAY[++cn] = LichCoDinh.Rows[i]["ST" + j.ToString()].ToString();
                            Lich.NGAY[++cn] = LichCoDinh.Rows[i]["CT" + j.ToString()].ToString();
                        }
                        DALichLamViec.Install.Insert_LichTuan(Lich);
                        if (i == LichCoDinh.Rows.Count - 1)
                        {
                            ThemMoiLichTuan(Lich);
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    HelpMsgBox.ShowErrorMessage(ex.Message);

                }
            }
        }
        private void frmThemLichTuan_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
        }
        #endregion

        #region 4.0.Phần mở rộng

        #endregion

        #region 5.0.Phần giữ chỗ


        #endregion

        #region 6.0.Phần xử lý Validation
        public bool IsValidate()
        {
            return true;
        }
        #endregion
    }
}