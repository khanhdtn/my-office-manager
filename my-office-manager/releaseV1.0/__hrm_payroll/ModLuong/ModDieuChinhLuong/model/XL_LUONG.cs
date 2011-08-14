using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using ProtocolVN.Framework.Core;


namespace DA
{
    public class XL_LUONG
    {
        public static XL_LUONG Ins = new XL_LUONG();
        public XL_LUONG() { }
        public double ThuNhapTroCap(double LuongNgay, int SoNgay)
        {
            return LuongNgay * SoNgay;
        }
        public decimal ThuNhap(decimal MucLuong, double SoNgayThang, double SoNgayLamViec,decimal PhanTram)
        {
            if (SoNgayThang == 0)
                SoNgayThang = 1;
            return (MucLuong * (PhanTram / (decimal) SoNgayThang)) * (decimal) SoNgayLamViec;
        }
        readonly int[] MaxNgThang = new int[] {0,31,28,31,30,31,30,31,31,30,31,30,31 };
        public bool NamNhuan(int Thang, int Nam)
        {
            if (Thang != 2)
                return false;
            if (Nam % 100 == 0 || Nam % 4 == 0)
                return true;
            return false;

        }
        public DateTime NgayCuoiThang(int Thang, int Nam)
        {
            int Ng = this.SoNgayMaxThang(Thang, Nam);
            return new DateTime(Nam, Thang, Ng);
        }
        public int SoNgayMaxThang(int Thang, int Nam)
        {
            return (NamNhuan(Thang, Nam)) ? (MaxNgThang[Thang] + 1) : MaxNgThang[Thang];
        }
        public int SoNgayThuBay(int Thang, int Nam)
        {
            int Kq = 0;
            for (int i = 1; i <= SoNgayMaxThang(Thang,Nam); i++)
            {
                if (new DateTime(Nam, Thang, i).DayOfWeek.ToString() == "Saturday")
                    Kq++;

            }
            return Kq;
        }
        public int SoNgayChuNhat(int Thang, int Nam)
        {
            int Kq = 0;
            for (int i = 1; i <= SoNgayMaxThang(Thang, Nam); i++)
            {
                if (new DateTime(Nam, Thang, i).DayOfWeek.ToString() == "Sunday")
                    Kq++;

            }
            return Kq;
        }
        public double SoNgayLamViecMax(int Thang, int Nam, bool b_fptime)
        {
            double Kq = SoNgayMaxThang(Thang, Nam) -  SoNgayChuNhat(Thang, Nam);
            if (b_fptime==true)
                Kq -= 1.0*SoNgayThuBay(Thang,Nam)/2;
            return Kq;
        }
        public bool IsNumber(string var)
        {
            string er = string.Empty;
            try
            {
                double Num = double.Parse(var);
            }
            catch (Exception ex)
            {
                er = ex.Message;

            }
            if (er == string.Empty)
                return true;
            return false;
        }
        //CHAUTV : Cập nhật distinct
        public double SoNgayLamViec_NhanVien(DateTime TuNgay, DateTime DenNgay, long NV_ID)
        {
            DatabaseFB fb = HelpDB.getDatabase();
            DbCommand cmd = fb.GetSQLStringCommand("select distinct NV_ID,NGAY,SANG,CHIEU from BANG_CHAM_CONG where NV_ID = @NV_ID and (NGAY between @TU_NGAY and @DEN_NGAY )");
            fb.AddInParameter(cmd, "@NV_ID", System.Data.DbType.Int64, NV_ID);
            fb.AddInParameter(cmd, "@TU_NGAY", System.Data.DbType.Date, TuNgay);
            fb.AddInParameter(cmd, "@DEN_NGAY", System.Data.DbType.Date, DenNgay);
            DataSet ds = new DataSet();
            fb.LoadDataSet(cmd, ds, "BANG_CHAM_CONG");
            //Duyet
            double DemVang = 0;
            double SoGio = 0;
            double DemNghi = 0;
            //Duyet
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["SANG"].ToString() == "V")
                    DemVang++;
                if (ds.Tables[0].Rows[i]["CHIEU"].ToString() == "V")
                    DemVang++;
                if (ds.Tables[0].Rows[i]["SANG"].ToString() == "N")
                    DemNghi++;
                if (ds.Tables[0].Rows[i]["CHIEU"].ToString() == "N")
                    DemNghi++;

                if (IsNumber(ds.Tables[0].Rows[i]["SANG"].ToString()))
                    SoGio += double.Parse(ds.Tables[0].Rows[i]["SANG"].ToString());
                if (IsNumber(ds.Tables[0].Rows[i]["CHIEU"].ToString()))
                    SoGio += double.Parse(ds.Tables[0].Rows[i]["CHIEU"].ToString());

            }
            //Xu ly
         
            return Math.Round(SoGio / 8 - DemVang/2,4);
        }
        public double SoNgayTrongDoan(DateTime TuNgay, DateTime DenNgay,bool b_fpTime)
        {
            double Kq = 0;
            while (TuNgay < DenNgay)
            {
                if(TuNgay.DayOfWeek.ToString()!="Sunday")
                    Kq++;
                if (TuNgay.DayOfWeek.ToString() == "Saturday" && b_fpTime)
                    Kq -= 0.5;
                TuNgay = TuNgay.AddDays(1);
            }
            return Kq;
        }
    }
}
