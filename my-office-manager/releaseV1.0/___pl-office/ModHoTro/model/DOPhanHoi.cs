using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DAO
{
    public class DOPhanHoi : System.EventArgs
    {
        #region 1. Thuộc tính bảng PHAN_HOI

            private long _ID;
            private long _YEU_CAU_ID;
            private long _NGUOI_GUI_ID;
            private string _NGUOI_NHAN_ID;
            private DateTime _NGAY_GUI;
            private byte[] _NOI_DUNG;
            private long _NGUOI_CAP_NHAT_ID;
            private DateTime _NGAY_CAP_NHAT;
            private DataSet _DSTapTinDinhKem;

            

        #endregion

        #region 2. Định nghĩa thuộc tính
            public long ID
            {
                get { return _ID; }
                set { _ID = value; }
            }
            public long YEU_CAU_ID
            {
                get { return this._YEU_CAU_ID; }
                set { this._YEU_CAU_ID = value; }
            }

            public long NGUOI_GUI_ID
            {
                get { return _NGUOI_GUI_ID; }
                set { _NGUOI_GUI_ID = value; }
            }

            

            public string NGUOI_NHAN_ID
            {
                get { return _NGUOI_NHAN_ID; }
                set { _NGUOI_NHAN_ID = value; }
            }


            public DateTime NGAY_GUI
            {
                get { return _NGAY_GUI; }
                set { _NGAY_GUI = value; }
            }

            public byte[] NOI_DUNG
            {
                get { return _NOI_DUNG; }
                set { _NOI_DUNG = value; }
            }

            public long NGUOI_CAP_NHAT_ID
            {
                get { return _NGUOI_CAP_NHAT_ID; }
                set { _NGUOI_CAP_NHAT_ID = value; }
            }

            public DateTime NGAY_CAP_NHAT
            {
                get { return _NGAY_CAP_NHAT; }
                set { _NGAY_CAP_NHAT = value; }
            }

            public DataSet DSTapTinDinhKem
            {
                get { return _DSTapTinDinhKem; }
                set { _DSTapTinDinhKem = value; }
            }
        #endregion

        #region 3. Khởi tạo

            public DOPhanHoi() { }

            public DOPhanHoi
            (
                long YeuCauId,
                long NguoiGuiId,
                string NguoiNhanId,
                DateTime NgayGui,
                byte[] NoiDung,
                long NguoiCapNhatId,
                DateTime NgayCapNhat
            )
            {
                this._YEU_CAU_ID = YeuCauId;
                this._NGUOI_GUI_ID = NguoiGuiId;
                this._NGUOI_NHAN_ID = NguoiNhanId;
                this._NGAY_GUI = NgayGui;
                this._NOI_DUNG = NoiDung;
                this._NGUOI_CAP_NHAT_ID = NguoiCapNhatId;
                this._NGAY_CAP_NHAT = NgayCapNhat;
            }

        #endregion
    }
}
