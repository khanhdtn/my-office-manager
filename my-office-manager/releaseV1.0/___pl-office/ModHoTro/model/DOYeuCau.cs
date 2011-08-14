using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using System.Data;

namespace DAO
{
    public class DOYeuCau : EventArgs
    {
        #region 1. Thuộc tính bảng YEU_CAU

            private long _ID;
            private long _NGUOI_GUI_ID;
            private string _NGUOI_NHAN_ID;
            private long _LOAI_YEU_CAU_ID;
            private int _MUC_UU_TIEN;
            private string _CHU_DE;
            private byte[] _NOI_DUNG;
            private DateTime _NGAY_GUI;
            private long _NGUOI_CAP_NHAT_ID;
            private DateTime _NGAY_CAP_NHAT;
            private int _TINH_TRANG;
            private DataSet _DSTapTinDinhKem;

            

        #endregion

        #region 2. Định nghĩa thuộc tính
        
            public long ID
            {
                get { return this._ID; }
                set { this._ID = value; }
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

            public long LOAI_YEU_CAU_ID
            {
                get { return _LOAI_YEU_CAU_ID; }
                set { _LOAI_YEU_CAU_ID = value; }
            }

            public int MUC_UU_TIEN
            {
                get { return _MUC_UU_TIEN; }
                set { _MUC_UU_TIEN = value; }
            }

            public string CHU_DE
            {
                get { return _CHU_DE; }
                set { _CHU_DE = value; }
            }
            
            public byte[] NOI_DUNG
            {
                get { return _NOI_DUNG; }
                set { _NOI_DUNG = value; }
            }

            public DateTime NGAY_GUI
            {
                get { return _NGAY_GUI; }
                set { _NGAY_GUI = value; }
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

            public int TINH_TRANG
            {
                get { return _TINH_TRANG; }
                set { _TINH_TRANG = value; }
            }

            public DataSet DSTapTinDinhKem
            {
                get { return _DSTapTinDinhKem; }
                set { _DSTapTinDinhKem = value; }
            }
        #endregion

        #region 3. Khởi tạo

            public DOYeuCau() { }

            public DOYeuCau
            (
                long Id,
                long NguoiGuiId,
                string NguoiNhanId,
                long LoaiYeuCauId,
                int MucUuTien,
                string ChuDe,
                byte[] NoiDung,
                DateTime NgayGui,
                long NguoiCapNhatId,
                DateTime NgayCapNhat,
                int TinhTrang
            )
            {
                this._ID = Id;
                this._NGUOI_GUI_ID = NguoiGuiId;
                this._NGUOI_NHAN_ID = NguoiNhanId;
                this._LOAI_YEU_CAU_ID = LoaiYeuCauId;
                this._MUC_UU_TIEN = MucUuTien;
                this._CHU_DE = ChuDe;
                this._NOI_DUNG = NoiDung;
                this._NGAY_GUI = NgayGui;
                this._NGUOI_CAP_NHAT_ID = NguoiCapNhatId;
                this._NGAY_CAP_NHAT = NgayCapNhat;
                this._TINH_TRANG = TinhTrang;
            }

        #endregion
    }
}
