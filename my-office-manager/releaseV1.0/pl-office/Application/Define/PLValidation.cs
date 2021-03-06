using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using office.model;
using ProtocolVN.Framework.Win;

namespace pl.office
{   
    public class PLValidation
    {
        public static FieldNameCheck[] GetRule(string tableName)
        {
            FieldNameCheck[] Rules = null;
            if (tableName == "DIEM_THEO_DOI_NOP_BAI")
            {
                Rules = DANopBai.Instance.DIEM_THEO_DOI_NOP_BAI() ;
            }
            else if (tableName == "DIEM_THEO_DOI_LEN_LOP")
            {
                Rules = DALenLop.Instance.DIEM_THEO_DOI_LEN_LOP();
            }
            return Rules;
        }
        public static void CheckDuplicate(GridView grid, DataSet GridDataSet, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e, string tableName)
        {
            if (tableName == "DIEM_THEO_DOI_NOP_BAI")
                DANopBai.Instance.CheckDuplicateDIEM_THEO_DOI_NOP_BAI(grid, GridDataSet, e);
            else if (tableName == "DIEM_THEO_DOI_LEN_LOP")
                DALenLop.Instance.CheckDuplicateDIEM_THEO_DOI_LEN_LOP(grid, GridDataSet, e);
        }
    }
}
