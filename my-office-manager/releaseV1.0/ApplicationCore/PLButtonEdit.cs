using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using ProtocolVN.Framework.Win;
using ProtocolVN.Framework.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using office;

namespace ProtocolVN.Framework.Trial
{
    public partial class PLButtonEdit : XtraUserControl
    {
        public PLButtonEdit()
        {
            InitializeComponent();
        }

        private byte[] _Value = null;

        /// <summary>
        /// Kiểm tra kích thước file (Có:True, Không: Flase). Mặc định là True
        /// </summary>
        public bool checkSizeFile = true;
        /// <summary>
        /// Kích thước giới hạn cho file (Mặc định là 20MB)
        /// </summary>
        public Int64 _SizeFile = 20;

        private string _PathFile = "";

        #region GET & SET
        /// <summary>
        /// Lấy tên file nguồn đầy đủ
        /// </summary>
        public string _getFullFileName
        {
            get { return this._PathFile; }
        }
        /// <summary>
        /// Gán tên file (chỉ có phần tên)
        /// </summary>
        /// <param name="FileName"></param>
        public void _setFileName(string FileName,byte[] Value )
        {
            if (FileName == "")
            {
                this._buttonEdit.EditValue = null;
                this._Value = null;
            }
            else { 
                this._buttonEdit.EditValue = FileName;
                this._Value = Value;
            }
        }
        /// <summary>
        /// Lấy tên file (chỉ có phần tên)
        /// </summary>
        /// <returns></returns>
        public string _getFileName()
        {
            if (this._buttonEdit.EditValue == null)
                return "";
            return this._buttonEdit.EditValue.ToString();
        }
        /// <summary>
        /// Chuyển nội dung file sang dạng byte[]
        /// </summary>
        /// <returns></returns>
        public byte[] _getFileToBytes()
        {
            if (this._PathFile == "") return new byte[] { };
            return HelpByte.FileToBytes(this._PathFile);
        }

        /// <summary>
        /// Gán validation cho control
        /// </summary>
        /// <param name="error"></param>
        /// <param name="errorText"></param>
        public void SetError(DXErrorProvider error, string errorText) {
            error.SetError(this._buttonEdit, errorText);
        }

        public void ReadOnly(bool IsRead) {
            if (IsRead)
            {
                if (this._getFileName() == "") this._buttonEdit.Enabled = false;
                else {
                    this._buttonEdit.Properties.Buttons[0].Enabled = false;
                    this._buttonEdit.Properties.Buttons[1].Enabled = false;
                }
            }
        }

        #endregion

        private void _buttonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Tag.ToString()) {
                case "Delete":
                    this._PathFile = "";
                    this._buttonEdit.EditValue = null;
                    break;
                case "Get":
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Title = "Chọn tập tin";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        if (checkSizeFile) {
                            if (!HelpFile.CheckFileSize(dialog.FileName,_SizeFile))
                            {
                                HelpMsgBox._showNotificationMessage("Kích thước file không được vượt quá" + _SizeFile + " MB", false);
                                return;
                            }
                        }
                        this._PathFile = dialog.FileName;
                        string[] temp = dialog.FileName.Split('\\');
                        this._buttonEdit.EditValue = temp[temp.Length - 1];
                    }
                    break;
                case "Open":
                    if (this._PathFile != "")
                        HelpFile.OpenFile(this._PathFile);
                    else {
                        frmSaveOpen frm = new frmSaveOpen(this._Value, this._buttonEdit.EditValue.ToString());
                        HelpProtocolForm.ShowModalDialog((XtraForm)this.FindForm(), frm);
                    }

                    break;
            }
            this.ShowButton(e.Button.Tag.ToString());
        }

        private void ShowButton(string STATUS) {
            switch (STATUS) {
                case "Delete":
                    this._buttonEdit.Properties.Buttons[0].Enabled = false;
                    this._buttonEdit.Properties.Buttons[1].Enabled = true;
                    this._buttonEdit.Properties.Buttons[2].Enabled = false;
                    break;
                case "Get":
                    if (this._buttonEdit.EditValue != null)
                    {
                        this._buttonEdit.Properties.Buttons[0].Enabled = true;
                        this._buttonEdit.Properties.Buttons[1].Enabled = true;
                        this._buttonEdit.Properties.Buttons[2].Enabled = true;
                    }
                    break;
                case "Open": 
                    break;
            }
        }

        private void PLButtonEdit_Load(object sender, EventArgs e)
        {
            if (this._buttonEdit.EditValue == null) {
                this.ShowButton("Delete"); 
            }
        }
    }
}
