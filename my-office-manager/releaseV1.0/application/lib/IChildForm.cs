using System;
using System.Collections.Generic;
using System.Text;

namespace office
{
    public interface IFormChild
    {
        #region Cấu trúc cho form con

        #region 1.0.Danh sách biến toàn cục

        #endregion

        #region 2.0.Hàm khởi tạo
        void InitControl();
        void InitData();
        void InitEnabledControl();
        void InitNghiepVu();
        void InitButtonImage();
        #endregion

        #region 3.0.Xử lý sự kiện (Lưu,Thêm,...)

        #endregion

        #region 4.0.Phần mở rộng

        #endregion

        #region 5.0.Phần giữ chỗ


        #endregion

        #region 6.0.Phần xử lý Validation
        bool IsValidate();
        #endregion

        #endregion
    }
}
