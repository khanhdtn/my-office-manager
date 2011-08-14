using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Plugin;
using ProtocolVN.Plugin.WarningSystem;

namespace ProtocolVN.WarningType.WarningShowMessage
{
    public class Warning :IWarning
    {
        #region IWarning Members

        public List<IWarningDefine> GetWarning()
        {
            List<IWarningDefine> lst = new List<IWarningDefine>();
            lst.Add(new WarningMain());
            lst.Add(new WarningCheckMail());
            return lst;
        }

        #endregion
    }
}
