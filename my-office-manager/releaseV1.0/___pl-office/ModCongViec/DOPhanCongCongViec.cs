using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    /// <summary>
    /// Phân công công việc quản lý
    /// </summary>
    public class DOPhanCongCongViec
    {
        #region 1.0 khai báo thuộc tính (declare properties)
        /// <summary>
        /// ID phân công công việc
        /// </summary>
        private long _PCCV_ID;

        /// <summary>
        /// Mã công việc cần phân công
        /// </summary>
        private long _LCV_ID;

        /// <summary>
        /// Mô tả cho công việc
        /// </summary>
        private string _MO_TA;

        /// <summary>
        /// Cấp độ ưu tiên của công việc
        /// </summary>
        private String _CONG_VIEC;

        private Int64 _MUC_UU_TIEN;

        /// <summary>
        /// Trạng thái của công việc
        /// </summary>
        private long _TINH_TRANG;

        /// <summary>
        /// Ngày bắt đầu thực hiện công việc
        /// </summary>
        private DateTime _NGAY_BAT_DAU;

        /// <summary>
        /// Ngày kết thúc công việc theo dự kiến
        /// </summary>
        private DateTime? _NGAY_KET_THUC_DU_KIEN;

        /// <summary>
        /// Ngày kết thúc công việc thực tế
        /// </summary>
        private DateTime? _NGAY_KET_THUC;

        /// <summary>
        /// Khoảng thời gian dự kiến để hoàn thành công việc
        /// </summary>
        private decimal? _THOI_GIAN_DU_KIEN;

        /// <summary>
        /// Đon vị thời gian dự kiến, ngày hoặc giờ
        /// </summary>
        private string _IS_NGAY;

        /// <summary>
        /// Người phân công công việc
        /// </summary>
        private long _NGUOI_GIAO;

        private string _IS_CONG_VIEC_KH;

        private byte[] _CHI_TIET_CONG_VIEC;
        #endregion

        #region 2.0 Hàm khởi tạo (constructor)
        /// <summary>
        /// Tạo mới một DOPhanCongCongViec
        /// </summary>
        public DOPhanCongCongViec()
        {
        }
       

        #endregion

        #region 3.0 Xây dựng thuộc tính
        /// <summary>
        /// ID phân công công việc
        /// </summary>
        public long PCCV_ID
        {
            get { return _PCCV_ID; }
            set { _PCCV_ID = value; }
        }

        /// <summary>
        /// Mã công việc cần phân công
        /// </summary>
        public long LCV_ID
        {
            get { return _LCV_ID; }
            set { _LCV_ID = value; }
        }

        /// <summary>
        /// Mô tả cho công việc
        /// </summary>
        public string MO_TA
        {
            get { return _MO_TA; }
            set { _MO_TA = value; }
        }
        public String CONG_VIEC
        {
            get { return _CONG_VIEC; }
            set { _CONG_VIEC = value; }
        }
        /// <summary>
        /// Cấp độ ưu tiên của công việc
        /// </summary>
        public Int64 MUC_UU_TIEN
        {
            get { return _MUC_UU_TIEN; }
            set { _MUC_UU_TIEN = value; }
        }

        /// <summary>
        /// Trạng thái của công việc
        /// </summary>
        public long TINH_TRANG
        {
            get { return _TINH_TRANG; }
            set { _TINH_TRANG = value; }
        }

        /// <summary>
        /// Ngày bắt đầu thực hiện công việc
        /// </summary>
        public DateTime NGAY_BAT_DAU
        {
            get { return _NGAY_BAT_DAU; }
            set { _NGAY_BAT_DAU = value; }
        }

        /// <summary>
        /// Ngày kết thúc công việc theo dự kiến
        /// </summary>
        public DateTime? NGAY_KET_THUC_DU_KIEN
        {
            get { return _NGAY_KET_THUC_DU_KIEN; }
            set { _NGAY_KET_THUC_DU_KIEN = value; }
        }

        /// <summary>
        /// Ngày kết thúc công việc thực tế
        /// </summary>
        public DateTime? NGAY_KET_THUC
        {
            get { return _NGAY_KET_THUC; }
            set { _NGAY_KET_THUC = value; }
        }

        /// <summary>
        /// Khoảng thời gian dự kiến để hoàn thành công việc
        /// </summary>
        public decimal? THOI_GIAN_DU_KIEN
        {
            get { return _THOI_GIAN_DU_KIEN; }
            set { _THOI_GIAN_DU_KIEN = value; }
        }

        /// <summary>
        /// Đon vị thời gian dự kiến, ngày hoặc giờ
        /// </summary>
        public string IS_NGAY
        {
            get { return _IS_NGAY; }
            set { _IS_NGAY = value; }
        }

        /// <summary>
        /// Người phân công công việc
        /// </summary>
        public long NGUOI_GIAO
        {
            get { return _NGUOI_GIAO; }
            set { _NGUOI_GIAO = value; }
        }

        public string IS_CONG_VIEC_KH
        {
            get { return _IS_CONG_VIEC_KH; }
            set { _IS_CONG_VIEC_KH = value; }
        }
        public byte[] CHI_TIET_CONG_VIEC
        {
            get { return _CHI_TIET_CONG_VIEC; }
            set { _CHI_TIET_CONG_VIEC = value; }
        }
        #endregion

    }
}
