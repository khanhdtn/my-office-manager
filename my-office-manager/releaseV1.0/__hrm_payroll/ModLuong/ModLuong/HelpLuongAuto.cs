using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace office
{
    //Xử lý tính lương cho bảng chấm công tự động
    public class HelpLuongAuto
    {
        /// <summary>CHAUTV : Tính tổng số giờ nhân viên làm được trong khoảng thời gian xác định
        /// </summary>
        public static double GetSumDaysWorked(DateTime from, DateTime to, long employKey)
        {
            QueryBuilder query = new QueryBuilder(@"SELECT distinct NV_ID,NGAY,SANG,CHIEU
                                                    FROM BANG_CHAM_CONG_AUTO 
                                                    WHERE 1=1");
            query.addID("NV_ID", employKey);
            query.addDateFromTo("NGAY", from, to);
            DataSet ds = HelpDB.getDatabase().LoadDataSet(query, "BANG_CHAM_CONG_AUTO");
            
            double cntV = 0; 
            double sumTime = 0;
            double cntN = 0; 
            //Duyệt đếm thời gian, vắng, nghỉ
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["SANG"].ToString() == "V")
                    cntV++;
                if (ds.Tables[0].Rows[i]["CHIEU"].ToString() == "V")
                    cntV++;
                if (ds.Tables[0].Rows[i]["SANG"].ToString() == "N")
                    cntN++;
                if (ds.Tables[0].Rows[i]["CHIEU"].ToString() == "N")
                    cntN++;
                if (checkNumber(ds.Tables[0].Rows[i]["SANG"].ToString()))
                    sumTime += double.Parse(ds.Tables[0].Rows[i]["SANG"].ToString());
                if (checkNumber(ds.Tables[0].Rows[i]["CHIEU"].ToString()))
                    sumTime += double.Parse(ds.Tables[0].Rows[i]["CHIEU"].ToString());
            }
            //Làm tròn 4 chữ số
            return Math.Round(sumTime / 8 - cntV / 2, 4);
        }

        /// <summary>CHAUTV : Kiểm tra một chuỗi có là số thực không
        /// </summary>
        private static bool checkNumber(object value) {
            bool bFlag = true;
            try
            {
                double Num = double.Parse(value.ToString());
            }
            catch (Exception ex)
            {
                bFlag = false;
            }
            return bFlag;
        }

        /// <summary>CHAUTV : Lấy số ngày phải đi làm trong khoảng thời gian
        /// </summary>
        public static double GetSumDaysMustWork(DateTime from, DateTime to, bool fullTime)
        {
            double Kq = 0;
            DateTime temp = from;
            while (temp < to)
            {
                if (temp.DayOfWeek.ToString() != "Sunday")
                    Kq++;
                if (temp.DayOfWeek.ToString() == "Saturday" && fullTime)
                    Kq -= 0.5;
                temp = temp.AddDays(1);
            }
            return Kq;
        }

        /// <summary>Tổng số ngày trong tháng
        /// </summary>
        public static Int32 SumDayOfMonth(Int32 year, Int32 month) {
            return HelpDate.GetEndOfMonth(month, year).Day;
        }

        /// <summary>Đếm số ngày của tuần trong tháng
        /// </summary>
        public static Int32 CountDayOfWeek(Int32 year, Int32 month,DayOfWeek dayOfWeek)
        {
            Int32 cnt = 0;
            for (int i = 0; i < SumDayOfMonth(year,month); i++)
            {
                if (new DateTime(year, month, i).DayOfWeek == dayOfWeek)
                    cnt++;
            }
            return cnt;
        }
    }

    public enum LuongType { 
        /// <summary>
        /// 0.Toàn thời gian
        /// </summary>
        FullTime = 0,
        /// <summary>
        /// 1.Bán thời gian
        /// </summary>
        PartTime = 1,
        /// <summary>
        /// 2.Trợ cấp
        /// </summary>
        TroCap = 2,
        /// <summary>
        /// 3.Không lương
        /// </summary>
        KhongLuong  = 3
    }
}
