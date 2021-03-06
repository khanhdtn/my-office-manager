using System;
using System.Collections.Generic;
using System.Threading;
using ProtocolVN.Framework.Core;
using ProtocolVN.Framework.Win;
using office;
using System.Net.Mail;

using DevExpress.XtraPivotGrid.Demos;
using DevExpres.Tutor;
namespace pl.office
{
    public class AppMain : CustomProject
    {
        AlertBroadCast alertthongbao = null;
        #region Cố định
        public override System.Reflection.Assembly getAssemblyHelp()
        {
            return System.Reflection.Assembly.GetExecutingAssembly();
        }

        [STAThread]
        public static void Main()
        {
            LDAPConfig.I.LDAP_PATH = "LDAP://protocolvn.net";

            FrameworkParams.Custom = new AppMain();
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
            FrameworkParams.isFormat = new AppFormat();

            FrameworkParams.CustomerName = "Công ty phần mềm P R O T O C O L";
            FrameworkParams.ProductName = "PL-OFFICE";
            FrameworkParams.Report = PLReport.CreateReport();
            FrameworkParams.Category = AppDanhMuc.CreateDanhMuc();
            FrameworkParams.defineAppParamExec = typeof(AppMethodExec).FullName;
            ProtocolMenu.init(new AppR1Menu());
            FrameworkParams.isLog = new AppLog();
            FrameworkParams.isPermision = new PLPermission();

            FrameworkParams.desktopForm = typeof(frmDesktopNewsPaper).FullName;

            FrameworkParams.UsingLDAP = true;
            RadParams.HELP_FILE = RadParams.RUNTIME_PATH + @"\Help.doc";

            //FrameworkParams.imageStore = new PLOImageCollectionMan();

            //CHAUTV : Đăng ký log4net 
            //@TODO PHUOCNT : đặt hàm đăng ký này tại một nơi sau khi đăng nhập thành công 
            //thì file log mới lấy UserName đăng nhập được. Còn đặt ở đây thì trong tên file log username = ''
            //Tên file log : PROTOCOLVN-UserName-MM-dd-yyyy.txt
            //Nếu chưa đưa vào FW được thì đặt trong phương thức khởi tạo của form [Giới thiệu] là OK
            HelpSysLog.RegisterConfig();
            FrameworkParams.plAssemblies.Add(ProtocolVN.DanhMuc.DanhMucAssembly.getAssembly());
            FrameworkParams.plAssemblies.Add(ProtocolVN.App.Office.AppOffice.getAssembly());
            HelpApplication.initDevelop();
            //HelpApplication.initReleaseType1();
        }

        public override void InitResAfterLogin()
        {
            base.InitResAfterLogin();
            Test.FrameworkParams.isPermissionRes = new PLPermissionRes();
            //PermissionOfResource.Running.FrameworkParams.iPermissionData = new AppPermissionResource();
            FrameworkParamsExt.ConfigEmail = new ConfigEmail();

        }

        public override void InitAferShowDesktop()
        {
            alertthongbao = new AlertBroadCast(
                FrameworkParams.MainForm, AppGetSysParam.GetSO_PHUT_LAP_LAI_THONG_BAO);
            PermissionOfResource.Running.FrameworkParams.iPermissionData = new AppPermissionData();
           
        }
        public override void ReleaseResAfterLogout()
        {
            alertthongbao.Stop();
            alertthongbao = null;
        }
        
    }
}
