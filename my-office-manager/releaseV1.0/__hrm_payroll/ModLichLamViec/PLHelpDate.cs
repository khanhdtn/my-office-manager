using System;
using System.Collections.Generic;
using System.Text;

namespace pl.helpdate
{
    public class PLHelpDate
    {
        public static String[] ThuVN = new string[]
        {
            "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
        };
        public static String[] ThuEN = new string[]
        {
            "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy", "Chủ nhật"
        };
        static int PositionThu(DateTime Input)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (Input.DayOfWeek.ToString() == ThuEN[i])
                    return i;
            }
            return -1;
        }
        public static Dictionary<string,string> getThuTuan(DateTime Input)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            DateTime dtemp = Input;
            for (int i = 0; i <= 7; i++)
            {
                string _ThuVN = ThuVN[PositionThu(dtemp)];
                dic.Add(dtemp.DayOfWeek.ToString(), _ThuVN);
                dtemp = dtemp.AddDays(1);
            }
            return dic;
        }
        public static List<DateTime> getNgayTuan(DateTime Input)
        {
            List<DateTime> ltemp = new List<DateTime>();
            DateTime dtemp = Input;
            for (int i = 0; i <= 7; i++)
            {
                ltemp.Add(dtemp);
                dtemp = dtemp.AddDays(1);
            }
            return ltemp;
        }





        #region Một số hàm Châu viết đã được đưa vào FW
        
        //PHUOCNT CHUYEN VAO HelpDateExt
        //public static string GetDayOfWeekVN(DateTime Date)
        //{
        //    string DayOfWeekEN = Date.DayOfWeek.ToString();
        //    switch (DayOfWeekEN)
        //    {
        //        case "Monday": return "Thứ hai";
        //        case "Tuesday": return "Thứ ba";
        //        case "Wednesday": return "Thứ tư";
        //        case "Thursday": return "Thứ năm";
        //        case "Friday": return "Thứ sáu";
        //        case "Saturday": return "Thứ bảy";
        //        case "Sunday": return "Chủ nhật";
        //    }
        //    return "";
        //}

        //PHUOCNT Chuyen vao HelpDateExt
        //public static DateTime MondayThisWeek()
        //{
        //    DateTime date = DateTime.Today;
        //    if (date.DayOfWeek.ToString() == "Monday")
        //        return date;
        //    while (date.DayOfWeek.ToString() != "Monday")
        //    {
        //        date = date.AddDays(-1);
        //    }
        //    return date;
        //}

        //PHUOCNT Chuyen vao HelpDateExt
        //public static DateTime DayFirstOfWeek(DateTime Input)
        //{
        //    DateTime date = Input;
        //    if (date.DayOfWeek.ToString() == "Monday")
        //        return date;
        //    while (date.DayOfWeek.ToString() != "Monday")
        //    {
        //        date = date.AddDays(-1);
        //    }
        //    return date;
        //}

        //PHUOCNT Chuyen vào HelpDateExt
        //public static DateTime MondayNextWeek()
        //{
        //    DateTime date = DateTime.Today;
        //    if (date.DayOfWeek.ToString() == "Monday")
        //        return date.AddDays(7);
        //    while (date.DayOfWeek.ToString() != "Monday")
        //    {
        //        date = date.AddDays(1);
        //    }
        //    return date;
        //}
        #endregion
    }
}
