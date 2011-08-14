using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;
using office;

namespace pl.office
{
    public class AppLog : IPLLog
    {
        #region IPLLog Members

        public List<LogItem> Log(object main)
        {
            List<LogItem> log = new List<LogItem>();
            if (main is frmTiepNhanThongTinVerticalQL) {
                //Cấu hình chưa được???
                //log.Add(new LogItem(((frmTiepNhanThongTinVerticalQL)main), ((frmTiepNhanThongTinVerticalQL)main).Text));
            }
            return log;
        }

        #endregion
    }
}
