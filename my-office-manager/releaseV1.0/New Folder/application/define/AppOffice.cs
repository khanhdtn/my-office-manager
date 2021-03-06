using System;
using ProtocolVN.Framework.Win;

namespace ProtocolVN.App.Office
{
    public class AppOffice : CustomProject
    {
        public static System.Reflection.Assembly getAssembly()
        {
            return System.Reflection.Assembly.GetExecutingAssembly();
        }
        #region Cố định
        public override System.Reflection.Assembly getAssemblyHelp()
        {
            return System.Reflection.Assembly.GetExecutingAssembly();
        }

        [STAThread]
        public static void Main()
        {
            LDAPConfig.I.LDAP_PATH = "LDAP://protocolvn.net";
            
            FrameworkParams.Custom = new AppOffice();
            try
            {
                MainApp.Main();
            }
            catch 
            {                    
            }               
        }
        #endregion
        
        public override void initAppParam()
        {
            //    
        }

        public override void InitResourceForApplication()
        {
            base.InitResourceForApplication();
            //Khởi động một số tài nguyên cần thiết trước            
            /////////////////////////////////////////////
            this.IsFinishInitRes = true;
        }
    }
}
