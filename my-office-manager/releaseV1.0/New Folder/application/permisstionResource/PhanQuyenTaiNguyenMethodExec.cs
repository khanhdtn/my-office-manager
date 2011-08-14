using ProtocolVN.Framework.Win;
using office;

namespace office
{
    public class PhanQuyenTaiNguyenMethodExec
    {
        public void ShowPhanQuyenNhanVienTaiLieu()
        {
            frmPhanQuyenNhanVienTaiNguyen cat =
                new frmPhanQuyenNhanVienTaiNguyen(LoaiTaiLieu_TaiLieu.I, "Phân quyền Nhân viên - Tài liệu");
            HelpProtocolForm.ShowWindow(FrameworkParams.MainForm, cat, false);
        }
    }
}