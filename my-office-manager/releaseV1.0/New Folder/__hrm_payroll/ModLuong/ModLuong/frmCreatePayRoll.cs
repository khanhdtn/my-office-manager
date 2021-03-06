using System;
using System.Data;
using ProtocolVN.Framework.Win;
using DAO;
using DTO;
using ProtocolVN.Framework.Core;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

///CHAUTV : chautv@protocolvn.net

namespace office
{
    public partial class frmCreatePayRoll : XtraFormPL
    {
        #region Properties
        StringBuilder strThangNam; 
        #endregion

        public frmCreatePayRoll(StringBuilder strThangNam)
        {
            InitializeComponent();
            this.InitData();
            this.strThangNam = new StringBuilder(strThangNam.ToString());
        }

        private void InitData() {
        }

        private void frmCreatePayRoll_Load(object sender, EventArgs e)
        {
            HelpXtraForm.SetCloseForm(this, this.btnClose, null);
            HelpXtraForm.SetFix(this);
            this.btnSave.Image = FWImageDic.SAVE_IMAGE16;
            this.btnClose.Image = FWImageDic.CLOSE_IMAGE16;
            plMonth._timeEdit.Time = DateTime.Today.AddMonths(-1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                string Month = this.plMonth._timeEdit.Text;
                if (strThangNam.ToString().Contains("," + Month + ","))
                {
                    HelpMsgBox.ShowNotificationMessage(string.Format("Bảng lương của tháng \"{0}\" đã được tạo, vui lòng chọn tháng khác!", Month));
                    return;
                }
                Application.DoEvents();
                FrameworkParams.wait = new FWWaitingMsg();
                ///1.Lấy danh sách nhân viên trong bảng chấm công tự động 
                DataSet dsEmployee = DABangLuong.Instance.GetEmployeeChamCongAuto(Month);
                List<string> l = new List<string>();
                foreach (DataRow row in dsEmployee.Tables[0].Rows)
                {
                    ///2.Lấy thông tin tạm ứng của nhân viên trong bảng tạm ứng của tháng cần tính lương
                    DOBangLuong phieu = DABangLuong.Instance.LoadAll(HelpNumber.ParseInt64(row["NV_ID"]), Month);
                    //phieu.TAM_UNG = DABangLuong.Instance.GetSoTienTamUng(HelpNumber.ParseInt64(row["NV_ID"]), Month); //CHAUTV : Chuyển qua nút Tính lương
                    
                    phieu.NV_ID = HelpNumber.ParseInt64(row["NV_ID"]);
                    l.Add(phieu.NV_ID.ToString());
                    phieu.THANG_NAM = Month;
                    phieu.IS_CHOT = "N";
                    ///3.Tạo dữ liệu trống cho bảng lương
                    DABangLuong.Instance.Update(phieu);
                    ///4.Cập nhật đã chuyển qua bảng lương cho dữ liệu tạm ứng (Chuyển qua nút Tính lương)
                    //DAPhieuTamUng.I.UpdatePhieuDuyet(phieu.NV_ID, phieu.THANG_NAM);
                }
                //Add các nhân viên có tạm ứng được duyệt mà không có trong bảng chấm công
                string notIn = "";
                if (l.Count > 0) {
                    for (int i = 0; i < l.Count-1; i++)
                    {
                        notIn += l[i] + ",";
                    }
                    notIn += l[l.Count - 1];
                }
                //BỔ SUNG
                if (notIn == "") notIn = "-1";
                QueryBuilder query = new QueryBuilder("SELECT NGUOI_DE_NGHI_ID FROM PHIEU_TAM_UNG WHERE 1=1");
                query.addCondition("(NGUOI_DE_NGHI_ID not in (" + notIn + "))");
                query.addCondition("DUYET='2'");
                query.add("THANG_TAM_UNG", Operator.Equal, Month, DbType.String);
                query.addGroupBy("NGUOI_DE_NGHI_ID");
                DataSet ds = HelpDB.getDatabase().LoadDataSet(query);
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    DOBangLuong phieu = DABangLuong.Instance.LoadAll(HelpNumber.ParseInt64(item["NGUOI_DE_NGHI_ID"]), Month);
                    phieu.NV_ID = HelpNumber.ParseInt64(item["NGUOI_DE_NGHI_ID"]);
                    phieu.THANG_NAM = Month;
                    phieu.IS_CHOT = "N";
                    DABangLuong.Instance.Update(phieu);
                }
                PLGUIUtil.ClosePhieu(this, true);
            }
            catch (Exception ex)
            {
                HelpSysLog.AddException(ex, "Tạo/Cập nhật bảng lương.");
                ErrorMsg.ErrorSave("Lưu không thành công.");
            }
            finally {
                if (FrameworkParams.wait != null) FrameworkParams.wait.Finish();
            }
        }
    }
}