using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using System.Reflection;
using System.IO;
using pl.office.__hrm_payroll.ModTimeSheet.Report.file;

namespace ProtocolVN.Plugin.TimeSheet.report
{
    public class PLTimeSheetReport
    {
        public static string GetPluginFolder()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string CreateReport()
        {
            return @"<?xml version='1.0' encoding='utf-8' standalone='yes'?>
                <report>
                    <group id='2' vn='Báo cáo công việc' en='Group A'>
                        <item id='2.1' vn='Theo Dự án' en='' caption='Báo cáo' 
                            filtercontrol='"+typeof(CT_RPT_DUAN).FullName+@"' 
                            reportfile='EMB" + typeof(RPT_DuAnQL).FullName + @"' />
                        <item id='2.2' vn='Theo Nhân viên' en='' caption='Báo cáo' 
                            filtercontrol='" +typeof(CT_RPT_NHANVIEN).FullName+@"' 
                            reportfile='EMB" + typeof(RPT_NhanVien).FullName + @"' />
                        <item id='2.3' vn='Tổng hợp ngày làm việc' en='' caption='Báo cáo' 
                            filtercontrol='" +typeof(CT_TONGHOP).FullName+@"' 
                            reportfile='EMB" + typeof(RPT_NgayLamViec).FullName + @"' />
                        <item id='2.4' vn='Tổng hợp dự án' en='' caption='Báo cáo' 
                            filtercontrol='"+typeof(CT_TONGHOPDUAN).FullName+@"' 
                            reportfile='EMB" + typeof(RPT_TimeSheetDuAn).FullName + @"' />
                    </group>
                </report>";
        }

        #region DỰ ÁN
        public static DataSet GetIN_ST_RPT_DUAN(long ID_DA, DateTime TUNGAY, DateTime DENNGAY)
        {
            string store = "ST_RPT_DUAN";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand(store);
            db.AddInParameter(cmd, "@TUNGAY", DbType.Date, TUNGAY);
            db.AddInParameter(cmd, "@DENNGAY", DbType.Date, DENNGAY);
            db.AddInParameter(cmd, "@DUAN", DbType.Int64, ID_DA);
            db.LoadDataSet(cmd, ds, store); 
            return ds;
        }
      
        #endregion

        #region NHÂN VIÊN
        public static DataSet GetIN_ST_RPT_NHANVIEN(long NV_ID, DateTime BAT_DAU, DateTime KET_THUC)
        {
            string store = "ST_RPT_NHANVIEN";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand(store);
            db.AddInParameter(cmd, "@NV_ID", DbType.Int64, NV_ID);
            db.AddInParameter(cmd, "@BAT_DAU", DbType.Int64, BAT_DAU);
            db.AddInParameter(cmd, "@KET_THUC", DbType.Int64, KET_THUC);
            db.LoadDataSet(cmd, ds, store);
            return ds;
        }

        #endregion

        #region TỔNG HỢP
        internal static DataSet GetIN_ST_RPT_NGAYLAMVIEC(DateTime TUNGAY, DateTime DENNGAY)
        {
            string store = "ST_RPT_NGAYLAMVIEC";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand(store);
            db.AddInParameter(cmd, "@TUNGAY", DbType.Date, TUNGAY);
            db.AddInParameter(cmd, "@DENNGAY", DbType.Date, DENNGAY);
            db.LoadDataSet(cmd, ds, store);
            return ds;
        }

        #endregion

        #region TỔNG HỢP DỰ ÁN
        internal static DataSet GetIN_ST_RPT_TONGHOP(long DA_ID)
        {
            string store = "ST_TONGHOPTIMESHEET_DUAN";
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand(store);
            db.AddInParameter(cmd, "@TUNGAY", DbType.UInt64, DA_ID);
            db.LoadDataSet(cmd, ds, store);
            return ds;
        }

        #endregion
    }
}
