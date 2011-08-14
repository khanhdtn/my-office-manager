using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using ProtocolVN.Plugin;

namespace ProtocolVN.Plugin.PrivateMsg
{
    public class PlugIn : IPlugin
    {
        #region Đoạn code bắt buộc không thay đổi
        private System.Reflection.Assembly getAssemblyHelp()
        {
            return System.Reflection.Assembly.GetCallingAssembly();
        }

        public System.Reflection.Assembly getAssembly()
        {
            return getAssemblyHelp();
        }
        #endregion

        private string m_strName;
        private string m_strDes;

        public PlugIn()
        {
            m_strName = "Email";
            m_strDes = "Ung dung mail noi bo";
        }

        public string Name
        {
            get { return m_strName; }
            set { m_strName = value; }
        }

        public string Description
        {
            get { return m_strDes; }
            set { m_strDes = value; }
        }

        public bool CheckOK()
        {
            return true;
        }

        public bool Install()
        {
            frmInstallDB db = new frmInstallDB(new InstallDB());
            //frmInstallDB.Install = true;
            //ProtocolForm.ShowModalDialog(db);
            
            return true;
        }

        public bool UnInstall()
        {
            frmInstallDB db = new frmInstallDB(new InstallDB());
            //frmInstallDB.Install = false;
            //ProtocolForm.ShowModalDialog(db);

            return true;
        }

        public string BuildMenu()
        {
            return @"<Item>
                    <ID>MAIN_MAIL_PLUGIN</ID>
                    <Name>Mail nội bộ</Name>
                    <Parents>PLUGIN</Parents>
                    <Enable>Y</Enable>
                    <Form>pl.mail.frmMessage</Form>
                    <MDI>N</MDI>
                    <Sep></Sep>
                    <ImageName></ImageName>
                    <Waiting></Waiting>
                    <HelpPage></HelpPage>
                    <ToolTip></ToolTip>
                  </Item>";
        }
        
        public bool InitPlugin()
        {
            return true;
        }

        public bool DisposePlugin()
        {
            return true;
        }

        public bool HookShowForm(DevExpress.XtraEditors.XtraForm frm)
        {
            return true;
        }

        #region IPlugin Members


        public bool HookHideForm(DevExpress.XtraEditors.XtraForm frm)
        {
            return true;
        }

        #endregion

        #region IPlugin Members


        public IFormat GetFormat()
        {
            return null;
        }

        public IPermission GetPermission()
        {
            return null;
        }

        #endregion
    }
}
