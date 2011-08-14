using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Plugin;
using ProtocolVN.Plugin.WarningSystem;
using ProtocolVN.Framework.Win;
using System.Windows.Forms;


namespace ProtocolVN.WarningType.WarningShowMessage
{
    public class WarningMain : AWarningDefine
    {
        /// <summary>
        /// Chú ý khi sửa thông tin _name, _des, và _type thì phải sửa lại
        /// DB của những User đã dùng FW_WARNINGINFO do đó tốt hơn hết làm 
        /// chạy tốt trên admin sau đó hãy apply thử nghiệm ở các user khác.
        /// </summary>
        public WarningMain()
        {            
            _name = "Cảnh báo loại 1";
            _des = "Hiện thông báo";
            _type = WarningExecType.LoopTime;
        }

        public override PLOut getOutputType()
        {
            return SystemTrayOut.Instance();
            //return RibbonStatusOut.Instance();
        }
        public override int getPeriod()
        {
            return 1000;
        }

        public override void SetParams(List<object> param)
        {
            
        }

        public override bool Install()
        {
            Console.WriteLine("Install");
            return true;
        }
        public override bool Uninstall()
        {
            Console.WriteLine("UnInstall");
            return true;
        }

        public override bool Start()
        {
            Console.WriteLine("Start");
            return true;
        }

        public override bool Stop()
        {
            Console.WriteLine("Stop");
            return true;
        }

        public override bool CheckConfig()
        {
            Console.WriteLine("CheckConfig");
            return true;
        }

        public override void ShowConfig(int war_id)
        {
            Console.WriteLine("ShowConfig :" + war_id);
        }


        private int i = 0;
        private bool asc = true;
        public override object Supervise()
        {
            string result = "";

            if (i > 40)
            {
                result = "Kết quả tốt";
            }
            else if (i > 20)
            {
                result = "Kết quả khá";
            }
            else if (i > 10)
            {
                result = "";
            }
            if (asc) { i++; }
            else { i--; }
            if (i == 45 || i == 0) asc = !asc;
            
            return result;
        }
    }

    public class WarningCheckMail : AWarningDefine
    {
        /// <summary>
        /// Chú ý khi sửa thông tin _name, _des, và _type thì phải sửa lại
        /// DB của những User đã dùng FW_WARNINGINFO do đó tốt hơn hết làm 
        /// chạy tốt trên admin sau đó hãy apply thử nghiệm ở các user khác.
        /// </summary>
        public WarningCheckMail()
        {
            _name = "Cảnh báo mail";
            _des = "Check mail.";
            _type = WarningExecType.LoopTime;
        }

        public override PLOut getOutputType()
        {
            return SystemTrayOut.Instance();
        }
        public override int getPeriod()
        {
            return 1000;
        }

        public override void SetParams(List<object> param)
        {

        }

        public override bool Install()
        {
            Console.WriteLine("Install");
            return true;
        }
        public override bool Uninstall()
        {
            Console.WriteLine("UnInstall");
            return true;
        }

        public override bool Start()
        {
            Console.WriteLine("Start");
            return true;
        }

        public override bool Stop()
        {
            Console.WriteLine("Stop");
            return true;
        }

        public override bool CheckConfig()
        {
            Console.WriteLine("CheckConfig");
            return true;
        }

        public override void ShowConfig(int war_id)
        {
            Console.WriteLine("ShowConfig :" + war_id);
        }


        private int i = 0;
        private bool asc = true;
        public override object Supervise()
        {
            string result = "";

            if (i > 50)
            {
                //Check xem có bao nhiêu mail mới và hiện thông báo lên....
                //Đã OK-->Thông tin lấy theo cấu hình OptionServer
                Chilkat.MailMan mailman = new Chilkat.MailMan();
                mailman.UnlockComponent("UnlockCode");
                mailman.MailHost = frmConfigServer._GetServer().PRIVATE_MAIL_HOST;
                mailman.PopUsername = FrameworkParams.currentUser.username + "@" + frmConfigServer._GetServer().PRIVATE_MAIL_HOST;
                mailman.PopPassword = FrameworkParams.currentUser.password;
                long numMessages = mailman.CheckMail();
                result += "Bạn có {" + numMessages.ToString() + "} tin mới....";
            }
            else if (i > 20)
            {
                result = "Đang check mail.....";
            }
            if (asc) { i++; }
            else { i--; }
            if (i == 70 || i == 0) asc = !asc;

            return result;
        }
    }
}
