using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolVN.Plugin.PLTimeMan
{
    public class PLTimePoint
    {
        //Yêu cầu
            //Người được yêu cầu
            //Thời gian bắt đầu ( ngày / giờ ) 
            //Thời gian kết thúc ( ngày / giờ ) 
            YeuCau yeuCau;
        //Thực hiện
            //Người thực hiện
            //Thời gian bắt đầu thực hiện
            //Thời gian kết thúc thực hiện
            //Kết quả thực hiện yêu cầu
            KetQua ketQua;
        //Công cụ buộc hỗ trợ cho người thực hiện
            //Chìa khoá phòng
            //Máy chiếu
        //Công cụ buộc cung cấp bởi người thực hiện
            //Thẻ giảng viên 
            //Thẻ sinh viên viên

        //Ràng buộc
            //Không cho vào điểm cuối khi điểm đầu chưa tạo
            //Cho phép / không cho phép người thực hiện phải đúng người được yêu cầu
            //Người thực hiện có thể là 1 tập thể chưa cụ thể cũng có thể là cá nhân cụ thể
            
    }

    public class Schedule
    {
        public List<PLTimePoint> _timePoints;
    }

    public class PLTime
    {
        //Ngày tạo
        //Người tạo
        //Ngày hiệu lực
        //Người quyết định
        //Người quản lý        
        Schedule schedule;

        //Xu ly 1 PLTimePoint - Ví dụ như vi phạm thời gian trừ điểm, trừ tiền hay phạt chẵn hạn
        //Tao schedule theo chu kỳ chỉ lên lịch 1 tuần (nhân ra nhiều tuần)
        //Tạo schedule từ danh sách đã phân công ( danh sách gác thi chẵn hạn)
        //Tạo schedule từ một nhóm người và thời gian kết thúc ( ngày 30/4 là kết thúc nộp đề thi người nộp là nhóm GV)
        //Cho phép 1 Lịch có thể có nhiều điểm theo dõi ( vị dụ chỉ có 1 lịch lên lớp mà có thể 
        //   theo dõi bởi nhân viên mượn máy chiếu, kiểm tra lên lớp, ...)
        //Tạo schedule từ danh sách excel       
        //Cho phép ghi nhận bắt đầu thực hiện tuỳ vào Yeu cầu, kết quả
        //Cho phep ghi nhận kết thúc thực hiện vào Yeu cầu, kết quả
        //Lich thực hiện của một thành viên theo thời gian
        //Lịch thực hiện theo 1 thời gian
        //Thống kê kết quả theo lịch của từng thành viên
    }

    #region Yêu cầu 
    public interface YeuCau
    {
        //Noi dung yeu cau
    }

    public class StringYeuCau : YeuCau
    {
        //Noi dung yeu cau
    }

    public class SendMailYeuCau : YeuCau
    {
        //Dia chi mail
    }
    #endregion

    #region Kết quả
    public interface KetQua
    {
        //Noi dung ket qua
    }
    public class StringKetQua : KetQua
    {
        //Noi dung ket qua
    }

    public class SendMailKetQua : KetQua
    {
        //Thông tin cần thiết de kiem là da nhan chua
    }
    #endregion

    public class PLTimeManSys
    {
        List<PLTime> _plTimes;

        //Lich thực hiện của 1 thành viên trên tất cả điểm theo dõi
        //Thống kê kết quả trên các điểm theo dõi
        //Kiểm tra tìm ra mâu thuẩn giữa các điểm theo dõi

    }
}
