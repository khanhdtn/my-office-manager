using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using System.Windows.Forms;
using DAO;
using ProtocolVN.Framework.Core;
using System.Threading;
using System.IO;

using System.Data;
using System.Data.Common;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ProtocolVN.Framework.Win
{
    //PHUOCNT NC
    //TRANGDTT
    //- Kiểm tra xem nếu anh them 2 cột như vậy trên 1 grid thì thế nào ??? RẤT QUAN TRỌNG
    //- Còn một số chỗ NC chưa giải quyết
    //- Hình dạng cột chưa nói lên đây là cột Attachment
    //- Sự kiện còn ko chính xác khi Click
    //- Vấn đề phân quyền là thế nào 
    //- Hạn chế việc yêu cầu người dùng phải biết nhiều về cách làm việc của CotFile mới dùng được
    public class CotFile
    {
        #region Vùng Static
        public static CotFile Init(GridView Grid, GridColumn Column,
            String DataTb, String ColumnField, Int64 maxFilesize)
        {
            CotFile cot = new CotFile();
            cot._Init(Grid, Column, DataTb, ColumnField, maxFilesize);
            cot.Up_DownEventArgs += new CotFile.Up_DownEventHandler(cot.GetCurrentDO);

            return cot;
        }

        #endregion

        private GridView _gridview;
        private GridColumn _columnField;
        /// <summary>
        /// DataTb 
        ///     ID <LONG>
        ///     NOI_DUNG <BLOB>
        ///     TEN_FILE <A_STR_SHORT>
        ///     URL <String>
        /// </summary>
        private String _dataTb;
        private Int64 _maxFilesize;
        public RepositoryItemButtonEdit _repos;
        public DONoiDungTaiLieu _currentDONoiDungTaiLieu;
        /// <summary>
        /// Trả về một DONoidungtailieu để xử lý
        /// </summary>
        public delegate void Up_DownEventHandler(object sender, DONoiDungTaiLieu doNoidungtailieu);
        public event Up_DownEventHandler Up_DownEventArgs;

        private CotFile() { }

        public RepositoryItemButtonEdit _Init(GridView Grid, GridColumn Column, 
            String DataTb, String ColumnField, Int64 maxFilesize)
        {
            _columnField = Column;
            _columnField.FieldName = ColumnField;
            _columnField.OptionsColumn.ReadOnly = true;

            _dataTb = DataTb;
            _gridview = Grid;
            _maxFilesize = maxFilesize;
            
            RepositoryItemButtonEdit btnUp_Down = new RepositoryItemButtonEdit();
            Column.ColumnEdit = btnUp_Down;
            btnUp_Down.Click += new EventHandler(btnUp_Down_Click);
            _gridview.Click += new EventHandler(_gridview_Click);

            _repos = btnUp_Down;

            return btnUp_Down;
        }

        public void GetCurrentDO(object sender, DONoiDungTaiLieu doNoidungtailieu)
        {
            this._currentDONoiDungTaiLieu = doNoidungtailieu;
        }

        public bool Insert()
        {
            DONoiDungTaiLieu noiDungTaiLieu = this._currentDONoiDungTaiLieu;
            return DANoiDungTaiLieu.Insert(this._dataTb, noiDungTaiLieu);
        }
        public bool Update()
        {
            DONoiDungTaiLieu noiDungTaiLieu = this._currentDONoiDungTaiLieu;
            return DANoiDungTaiLieu.Update(this._dataTb, noiDungTaiLieu);
        }
        public bool Delete()
        {
            if (this._currentDONoiDungTaiLieu != null)
            {
                long ID = this._currentDONoiDungTaiLieu.ID;
                if (DANoiDungTaiLieu.Delete(this._dataTb, ID))
                {
                    this._currentDONoiDungTaiLieu = null;
                    return true;
                }
                return false;
            }
            else 
                return false;
        }

        private void btnUp_Down_Click(object sender, EventArgs e)
        {
            string path = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn file để cập nhật tài liệu:";
            DialogResult value = openFile.ShowDialog();
            if (value == DialogResult.OK)
            {
                path = openFile.FileName;
                //Kiểm tra độ lớn của file
                if (!HelpFile.CheckFileSize(path, _maxFilesize))
                {
                    //Độ lớn của file lớn hơn độ lớn qui định
                    HelpMsgBox.ShowNotificationMessage("Bạn không được chọn file lớn hơn " + _maxFilesize.ToString() + "MB.");
                    path = null;
                    btnUp_Down_Click(sender, e);
                }
            }
            else if(value == DialogResult.Cancel)
            {
                path = null;
                this._currentDONoiDungTaiLieu = null;
                return;
            }

            Thread.Sleep(200);
            if (path != null)
            {
                //Chuyển file sang byte[]
                byte[] bytes = HelpFile.FileToBytes(path);
                long ID = -1;
                //Nếu chưa có dữ liệu thì là thêm mới
                if (_gridview.GetRowCellValue(_gridview.FocusedRowHandle, _gridview.Columns[_columnField.FieldName]).ToString() == "")
                {
                    ID = HelpDB.getDatabase().GetID(HelpGen.G_FW_DM_ID);
                    _gridview.SetRowCellValue(_gridview.FocusedRowHandle, _columnField, ID);
                    this._currentDONoiDungTaiLieu = new DONoiDungTaiLieu(ID, bytes, Path.GetFileName(path),
                        FrameworkParams.TEMP_FOLDER + @"\" + Path.GetFileName(path));
                }
                else
                {
                    this._currentDONoiDungTaiLieu = new DONoiDungTaiLieu(
                        HelpNumber.ParseInt64(_gridview.GetRowCellValue(_gridview.FocusedRowHandle, _columnField)),
                        bytes, Path.GetFileName(path), FrameworkParams.TEMP_FOLDER + @"\" + Path.GetFileName(path));
                }
            }
        }

        private void _gridview_Click(object sender, EventArgs e)
        {
            string path = null;
            //Lấy ra vị trí click của Muose trên gridview
            GridHitInfo gHitInfo = _gridview.CalcHitInfo(_gridview.GridControl.PointToClient(Control.MousePosition));
            if (gHitInfo.InRowCell)//Nếu vị trí click là cell trong row
            {
                if (gHitInfo.Column.FieldName == _columnField.FieldName)//Nếu cell được click thuộc _columnField
                {
                    FileInfo fInfo;
                    DONoiDungTaiLieu nd = DANoiDungTaiLieu.getNOI_DUNG_TAI_LIEU(_dataTb,
                        HelpNumber.ParseInt64(_gridview.GetRowCellValue(_gridview.FocusedRowHandle, _columnField)));
                    if (nd == null) return;
                    //Lấy đường dẫn file ở máy local
                    path = nd.URL;
                    fInfo = new FileInfo(path);
                    if (fInfo.Exists)//File đã tồn tại ở máy local
                    {
                        //PHUOCNT NC Nếu tập tin có trên máy hỏi người dùng có cần lấy bản mới về ko ???
                        if (!HelpFile.OpenFile(path))
                            HelpMsgBox.ShowNotificationMessage("Không mở được file " + Path.GetFileName(path) + ".");
                    }
                    else if (HelpMsgBox.ShowConfirmMessage("File không tồn tại ở máy tính. Bạn có muốn lưu file về máy không?") 
                        == DialogResult.Yes)
                    {
                        path = null;
                        SaveFileDialog saveFile = new SaveFileDialog();
                        //Cấu hình các thuộc tính cho saveFile
                        saveFile.InitialDirectory = FrameworkParams.TEMP_FOLDER;
                        saveFile.Title = "Chọn thư mục để lưu file:";
                        //Lấy kiểu file
                        string[] typeFile = Path.GetFileName(nd.URL).Split(new char[] { '.' });
                        saveFile.Filter = "File type " + typeFile.GetValue(typeFile.Length - 1).ToString() 
                            + "(*." + typeFile.GetValue(typeFile.Length - 1).ToString() + ")" + "|*." 
                            + typeFile.GetValue(typeFile.Length - 1).ToString();
                        saveFile.FileName = typeFile.GetValue(typeFile.Length - 2).ToString();
                        if (saveFile.ShowDialog() == DialogResult.OK)
                        {
                            path = saveFile.FileName;
                        }
                        Thread.Sleep(200);
                        if (path != null)
                        {
                            byte[] bytes = nd.NOI_DUNG;
                            if (bytes == null)
                            {
                                HelpMsgBox.ShowNotificationMessage("Tài liệu không tồn tại, xin vui lòng cập nhật lại.");
                                return;
                            }

                            if (!HelpFile.BytesToFile(bytes, path))
                                HelpMsgBox.ShowNotificationMessage("Không lưu được file.");
                            else
                            {
                                //Gán tên file và đường dẫn file cho gridview
                                _gridview.GetDataRow(_gridview.FocusedRowHandle).BeginEdit();
                                _gridview.SetRowCellValue(gHitInfo.RowHandle, _gridview.Columns["TEN_FILE"], Path.GetFileName(path));
                                _gridview.SetRowCellValue(gHitInfo.RowHandle, _gridview.Columns["URL"], path);
                                //Cập nhật lại dữ liệu
                                DANoiDungTaiLieu.UpdateTEN_FILE(this._dataTb, new DONoiDungTaiLieu(
                                    HelpNumber.ParseInt64(_gridview.GetRowCellValue(_gridview.FocusedRowHandle, _columnField))
                                    , null, Path.GetFileName(path), path));
                                _gridview.UpdateCurrentRow();
                                //Mở file cho người dùng
                                HelpFile.OpenFile(path);
                            }
                        }
                    }
                }
            }
        }
    }

    public class DONoiDungTaiLieu : EventArgs
    {
        private long _ID;
        private byte[] _NOI_DUNG;
        private string _TEN_FILE;
        private string _URL;
        public long ID
        {
            get { return this._ID; }
            set { this._ID = value; }
        }

        public byte[] NOI_DUNG
        {
            get { return _NOI_DUNG; }
            set { _NOI_DUNG = value; }
        }

        public string TEN_FILE
        {
            get { return _TEN_FILE; }
            set { _TEN_FILE = value; }
        }

        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }

        public DONoiDungTaiLieu()
        {
        }

        public DONoiDungTaiLieu(long Id, byte[] NoiDung, string TenFile, string Url)
        {
            this._ID = Id;
            this._NOI_DUNG = NoiDung;
            this._TEN_FILE = TenFile;
            this._URL = Url;
        }
    }

    public class DANoiDungTaiLieu
    {
        public static DONoiDungTaiLieu getNOI_DUNG_TAI_LIEU(string TbName, long id)
        {
            DONoiDungTaiLieu DO = new DONoiDungTaiLieu();
            DataSet ds = HelpDB.getDatabase().LoadDataSet("select * from " + TbName + " where ID = " + id);
            if (ds.Tables.Count > 0)
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    DO.ID = HelpNumber.ParseInt64(row["ID"]);
                    DO.NOI_DUNG = (byte[])row["NOI_DUNG"];
                    DO.TEN_FILE = row["TEN_FILE"].ToString();
                    DO.URL = row["URL"].ToString();
                    return DO;
                }
            return null;
        }
        public static bool UpdateTEN_FILE(string TbName, DONoiDungTaiLieu doNoidungtailieu)
        {
            string strSQL = "Update "+ TbName+" set TEN_FILE = @ten_file, URL = @url Where ID=@id ";

            DatabaseFB db = HelpDB.getDatabase();
            DbCommand cmd = db.GetSQLStringCommand(strSQL);

            db.AddInParameter(cmd, "@id", DbType.Int64, doNoidungtailieu.ID);
            db.AddInParameter(cmd, "@ten_file", DbType.String, doNoidungtailieu.TEN_FILE);
            db.AddInParameter(cmd, "@url", DbType.String, doNoidungtailieu.URL);

            if (db.ExecuteNonQuery(cmd) > 0)
                return true;
            return false;
        }

        //PHUOCNT NC Có cách nào đưa các hàm xử lý vào bên trong CotFile ko ???
        #region Các hàm bên ngoài dùng
        public static bool Insert(string TbName, DONoiDungTaiLieu doNoidung)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cmd = db.GetSQLStringCommand("insert into "+ TbName +" values(@id, @noi_dung, @ten_file, @url)");

            db.AddInParameter(cmd, "@id", DbType.Int64, doNoidung.ID);
            db.AddInParameter(cmd, "@noi_dung", DbType.Binary, doNoidung.NOI_DUNG);
            db.AddInParameter(cmd, "@ten_file", DbType.String, doNoidung.TEN_FILE);
            db.AddInParameter(cmd, "@url", DbType.String, doNoidung.URL);
            try
            {
                int value = db.ExecuteNonQuery(cmd, dbTrans);
                db.CommitTransaction(dbTrans);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                db.RollbackTransaction(dbTrans);
                return false;
            }
            finally
            {
                db.Close();
            }
            return true;
        }
        public static bool Update(String TbName, DONoiDungTaiLieu doNoidung)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cmd = db.GetSQLStringCommand("Update " + TbName + " set NOI_DUNG = @noi_dung, TEN_FILE = @ten_file, URL = @url Where ID=@id ");

            db.AddInParameter(cmd, "@id", DbType.Int64, doNoidung.ID);
            db.AddInParameter(cmd, "@noi_dung", DbType.Binary, doNoidung.NOI_DUNG);
            db.AddInParameter(cmd, "@ten_file", DbType.String, doNoidung.TEN_FILE);
            db.AddInParameter(cmd, "@url", DbType.String, doNoidung.URL);
            try
            {
                int value = db.ExecuteNonQuery(cmd, dbTrans);
                db.CommitTransaction(dbTrans);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                db.RollbackTransaction(dbTrans);
                return false;
            }
            finally
            {
                db.Close();
            }
            return true;
        }
        public static bool Delete(String TbName, long id)
        {
            DatabaseFB db = HelpDB.getDatabase();
            DbTransaction dbTrans = db.BeginTransaction(db.OpenConnection());
            DbCommand cmd = db.GetSQLStringCommand("delete from " + TbName + " Where ID=@id");
            db.AddInParameter(cmd, "@id", DbType.Int64, id);
            try
            {
                int value = db.ExecuteNonQuery(cmd, dbTrans);
                db.CommitTransaction(dbTrans);
            }
            catch (Exception ex)
            {
                ex.StackTrace.ToString();
                db.RollbackTransaction(dbTrans);
                return false;
            }
            finally
            {
                db.Close();
            }
            return true;
        }
        #endregion
    }      
}
