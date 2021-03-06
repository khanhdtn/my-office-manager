using System;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors.DXErrorProvider;
using DAO;


namespace office
{
    public partial class frmChotBangLuong : DevExpress.XtraEditors.XtraForm
    {
        private bool? status;
        private DXErrorProvider Error = null;

        public frmChotBangLuong() : this(null){}
        
        public frmChotBangLuong(bool? status)
        {
            InitializeComponent();
            HelpXtraForm.SetCloseForm(this, btnDong, true);
            this.status = status;
            if (!InitDataControl()) PLGUIUtil.HuyForm(this);
            InitCaptionSave();
            Error = new DXErrorProvider(this);
            this.btnLuu.Image = FWImageDic.SAVE_IMAGE16;
            this.btnDong.Image = FWImageDic.CLOSE_IMAGE16;
            
        }

        private void InitCaptionSave()
        {
            if (status == true) btnLuu.Text = "Chốt";
            else if (status == false) btnLuu.Text = "Mở chốt";
            else btnLuu.Text = "Lưu";
        }
        private bool ValidateData()
        {
            bool flag = true;
            Error.ClearErrors();
            if (BangLuong.SelectedIndex == -1)
            {
                Error.SetError(BangLuong, "Vui lòng chọn bảng lương"); flag = false;
            }
            return flag;
        }
        private bool InitDataControl()
        {
            DABangLuong.Instance.ChonThangLuong(BangLuong,this.status);
            return true;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (this.ValidateData())
            {
                if (DALuong.Ins.IsChotBangLuong(BangLuong.EditValue.ToString(), status))
                {
                      this.Close();
                }

            }
                
        }
        private void frmChotBangLuong_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetFix(this);
        }
    }
}