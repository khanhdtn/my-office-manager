using System;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Data;
using ProtocolVN.Framework.Core;
namespace DAO
{
    public class DAQuanLyThucHien
    {
        //xóa cộtv trên gridBand
        public static void clearAllColumn(GridBand gridBand, DevExpress.XtraGrid.Columns.GridColumn cotNhanSu)
        {
            gridBand.Width = 250;
            for (int i = gridBand.Columns.Count - 1; i > 0; i--)
            {
                gridBand.Columns.RemoveAt(i);
            }
            cotNhanSu.Width = 250;
            cotNhanSu.Caption = "Nhân sự";
        }

        public static void clearFullColumn(DevExpress.XtraGrid.GridControl gridControl,GridBand gridBand, DevExpress.XtraGrid.Columns.GridColumn cotNhanSu)
        {
            gridBand.Width = 700;
            for (int i = gridBand.Columns.Count - 1; i > 0; i--)
            {
                gridBand.Columns.RemoveAt(i);
            }
            cotNhanSu.Width = 700;
            cotNhanSu.Caption = "Chưa có điểm theo dỏi nào trong bảng này";
            gridControl.DataSource = null;
        }
        //kiểm tra thông tin đang nhập
        public static bool checkLogin(String userName, String pwd, long nhanSu)//kiểm tra đăng nhập
        {
            String sqlString = "select USERNAME,PWD ,EMPLOYEE_ID from user_cat";
            DataSet ds = DABase.getDatabase().LoadDataSet(sqlString);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["USERNAME"].ToString() == userName)
                    if (long.Parse(dr["EMPLOYEE_ID"].ToString()) == nhanSu)
                    {
                        if (dr["PWD"].ToString() == pwd)
                            return true;
                    }
                    else
                        return false;

            }
            return false;
        }
    }
}
