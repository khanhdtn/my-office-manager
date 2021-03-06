using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProtocolVN.Framework.Core;

namespace ProtocolVN.Framework.Win
{
    /// <summary>
    /// CHAUTV : Màn hình thêm mới note
    /// </summary>
    public partial class frmNote : XtraFormPL
    {
        #region Khai báo MenuItem
        public static string MenuItem(string ParentID, bool IsSep)
        {
            return MenuBuilder.CreateItem(typeof(frmNote).FullName,
                "Notes",
                ParentID, true,
                typeof(frmNote).FullName,
                false, IsSep, "fwAdd.png", true, "", "");
        }
        #endregion

        public frmNote()
        {
            InitializeComponent();
            HelpXtraForm.SetCloseForm(this, btnClose, null);
        }

        private DOFWNote note = null;
        private void frmNote_Load(object sender, EventArgs e)
        {
            this.btnSave.Image = FWImageDic.SAVE_IMAGE20;
            this.btnClose.Image = FWImageDic.CLOSE_IMAGE20;
            this.note = DAFWNote.I.LoadAllFromUser(FrameworkParams.currentUser.id);
            if (this.note != null)
                this.plWord1._set(this.note.NOI_DUNG);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                note.USERID = FrameworkParams.currentUser.id;
                note.NOI_DUNG = this.plWord1._GetByteContent();
                if (DAFWNote.I.Update(note))
                    HelpXtraForm.CloseFormNoConfirm(this);
            }
            catch (Exception ex)
            {
                PLException.AddException(ex);
                HelpSysLog.AddException(ex, "Ghi chú");
            }
        }
    }
}