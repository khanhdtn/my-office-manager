using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ProtocolVN.Framework.Core;
using System.Data.Common;
using ProtocolVN.Framework.Win;

namespace ProtocolVN.App.Office
{
    public class AppReport
    {
        public static string FileHeaderReport = "PLHeader.rpt";
        public static DataSet HeaderDataSet()
        {
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("HEADER_COMPANY");
            ds = db.LoadDataSet(cmd, "HEADER_COMPANY");
            return ds;
        }

        #region Báo cáo chấm công
        public static DataSet GetChamCongTheoNgay(PLMultiCombobox NV_ID, DateTime TuNgay, DateTime DenNgay)
        {
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("IN_CHAM_CONG");
            db.AddInParameter(cmd, "@TUNGAY", DbType.DateTime, TuNgay);
            db.AddInParameter(cmd, "@DENNGAY", DbType.DateTime, DenNgay);
            db.LoadDataSet(cmd, ds, "IN_CHAM_CONG");
            #region Lọc lại dữ liệu trên DataSet
            DataRow[] dsrow = ds.Tables[0].Select("NV_ID in " + NV_ID._getStrSelectedIDs());
            DataSet NewDs = ds.Clone();
            foreach (DataRow item in dsrow)
                NewDs.Tables[0].ImportRow(item);
            #endregion
            return NewDs;
        }
        #endregion

        #region Báo cáo thời gian làm việc
        public static DataSet GetThoiGianLamViec(PLMultiCombobox NV_ID, bool LoaiLV, bool LoaiDTVS, bool LoaiNP, DateTime TuNgay, DateTime DenNgay)
        {
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("IN_THOI_GIAN_LAM_VIEC");
            db.AddInParameter(cmd, "@ILOAILV", DbType.Byte, LoaiLV == true ? 1 : 0);
            db.AddInParameter(cmd, "@ILOAIDTVS", DbType.Byte, LoaiDTVS == true ? 2 : 0);
            db.AddInParameter(cmd, "@ILOAINP", DbType.Byte, LoaiNP == true ? 3 : 0);
            db.AddInParameter(cmd, "@TUNGAY", DbType.DateTime, TuNgay);
            db.AddInParameter(cmd, "@DENNGAY", DbType.DateTime, DenNgay);
            db.LoadDataSet(cmd, ds, "IN_THOI_GIAN_LAM_VIEC");
            #region Lọc lại dữ liệu trên DataSet
            DataRow[] dsrow = ds.Tables[0].Select("NV_ID in " + NV_ID._getStrSelectedIDs());
            DataSet NewDs = ds.Clone();
            foreach (DataRow item in dsrow)
                NewDs.Tables[0].ImportRow(item);
            #endregion
            return NewDs;
        }
        #endregion

        #region Báo cáo nhật ký công việc
        public static DataSet GetNhatKyTheoNgay(PLMultiCombobox NV_ID, DateTime TuNgay, DateTime DenNgay)
        {
            DataSet ds = new DataSet();
            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetStoredProcCommand("IN_NHAT_KY_CONG_VIEC");
            db.AddInParameter(cmd, "@TUNGAY", DbType.DateTime, TuNgay);
            db.AddInParameter(cmd, "@DENNGAY", DbType.DateTime, DenNgay);
            db.LoadDataSet(cmd, ds, "IN_NHAT_KY_CONG_VIEC");
            #region Lọc lại dữ liệu trên DataSet
            DataRow[] dsrow = ds.Tables[0].Select("NV_ID in " + NV_ID._getStrSelectedIDs());
            DataSet NewDs = ds.Clone();
            foreach (DataRow item in dsrow)
                NewDs.Tables[0].ImportRow(item);
            #endregion
            return NewDs;
        }
        #endregion
    }
}
