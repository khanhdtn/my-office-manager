using ProtocolVN.DanhMuc;
using ProtocolVN.Framework.Core;

namespace office
{
    public class LoaiTaiLieu_TaiLieu : TaiNguyen
    {
        public static LoaiTaiLieu_TaiLieu I = new LoaiTaiLieu_TaiLieu();

        public LoaiTaiLieu_TaiLieu()
            : base("Tài liệu", "USER_LOAI_TAI_LIEU",
            "LTL_ID", "USER_TAI_LIEU", "TL_ID", "DM_LOAI_TAI_LIEU",
            "DM_TAI_LIEU", "LOAI_TAI_LIEU_ID", "IS_PERMISSION_TAILIEU",
            DMLoaiTaiLieu.I, DMTaiLieu.I)
        {
        }
    }
}