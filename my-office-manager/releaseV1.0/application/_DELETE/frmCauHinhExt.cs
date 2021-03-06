using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using DevExpress.XtraEditors;
namespace ProtocolVN.Framework.Win
{
    public interface IMauPhieu {
        Dictionary<int, string> GetMauPhieu();
    }
    public partial class frmCauHinhExt : XtraFormPL
    {
        private DXErrorProvider Error;
        private Dictionary<int, string> ListMaPhieu;
        public static IMauPhieu iMauPhieu = null;
        public frmCauHinhExt()
        {
            InitializeComponent();
            this.Error = GUIValidation.GetErrorProvider(this);
            InitList();
            InitControl();
            this.Load += delegate(object sender, EventArgs e)
            {
                HelpXtraForm.SetFix(this);
            };
        }
     
        private void InitList()
        {
            //Khai báo đúng dạng bên dưới
            ListMaPhieu = iMauPhieu.GetMauPhieu();        
        }
        private void InitControl()
        {

            if (ListMaPhieu.Count == 0)
            {
                HelpMsgBox.ShowNotificationMessage("Chưa có mã phiếu để cấu hình!");
                HelpXtraForm.CloseFormHasConfirm(this);
                return;
            }
            int x = 7;
            int y = 25;

            foreach (int key in ListMaPhieu.Keys)
            {
                Label lbl = new Label();
                lbl.Text = "Mẫu phiếu " + ListMaPhieu[key].Split(';')[1];
                lbl.Location = new System.Drawing.Point(x, y + 5);
                //lbl.AutoSize = false;
                lbl.Size = new System.Drawing.Size(150, lbl.Size.Height);
                this.groupControlConfig.Controls.Add(lbl);

                PatternSelect ps = new PatternSelect();
                ps.Name = "PS" + key;
                ps.Location = new System.Drawing.Point(x + lbl.Size.Width + 20, y);
                this.groupControlConfig.Controls.Add(ps);
               
                ps.f_setValue(ListMaPhieu[key].Split(';')[0]);

                TextEdit txt = new TextEdit();
                txt.Name = "TXT" + key;
                txt.Location = new System.Drawing.Point(x, y + 3);
                txt.Properties.ReadOnly = true;
                txt.Size = new System.Drawing.Size(154, 20);
                this.groupControlExample.Controls.Add(txt);

                txt.Text = DatabaseFB.getSoPhieu(ps.f_getValue());

                y += 25;
            }

            groupControlConfig.Location = new System.Drawing.Point(12, 6);

            groupControlConfig.Size = new System.Drawing.Size(
                 groupControlConfig.Controls[groupControlConfig.Controls.Count - 1].Location.X + groupControlConfig.Controls[groupControlConfig.Controls.Count - 1].Size.Width + 10,
                 groupControlConfig.Controls[groupControlConfig.Controls.Count - 1].Location.Y + 30);

            groupControlExample.Location = new System.Drawing.Point(groupControlConfig.Size.Width + 40, 6);
            groupControlExample.Size = new System.Drawing.Size(groupControlExample.Controls[0].Size.Width + 10,
                groupControlConfig.Size.Height);
            this.Size = new System.Drawing.Size(
                groupControlConfig.Location.X + groupControlConfig.Size.Width + groupControlExample.Size.Width + 40,
                groupControlConfig.Location.Y + groupControlConfig.Size.Height + flowLayoutPanel1.Size.Height + 30);

        }

        private void btnXemTruoc_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (int key in ListMaPhieu.Keys)
                {
                    PatternSelect ps = groupControlConfig.Controls["PS" + key] as PatternSelect;
                    TextEdit txt = groupControlExample.Controls["TXT" + key] as TextEdit;
                    txt.Text = DatabaseFB.getSoPhieu(ps.f_getValue());
                }
            }
            catch { }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn đóng?") == DialogResult.Yes)
                this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateData()==true )
            {
                if (HelpMsgBox.ShowConfirmMessage("Bạn có chắc muốn lưu?") == DialogResult.Yes)
                {
                    if (Save() == true)
                        this.Close();
                    else HelpMsgBox.ShowNotificationMessage("Lưu cấu hình mã phiếu không thành công!");
                }
            }
        }       
        private bool Save()
        {        

            foreach (int key in ListMaPhieu.Keys)
            {
                PatternSelect ps = groupControlConfig.Controls["PS" + key] as PatternSelect;
                if (DatabaseFB.SetThamSo(ListMaPhieu[key].Split(';')[0], ps.f_getValue()) == false)
                    return false;
            }
            
            return true;
        }


        public bool ValidateData()
        {
            Error.ClearErrors();
            foreach (int key in ListMaPhieu.Keys)
            {
                PatternSelect ps = groupControlConfig.Controls["PS" + key] as PatternSelect;
                ps.f_checkInput(Error);
            }
            if (Error.HasErrors) return false;
            return true;
        }

       

        
    }
}