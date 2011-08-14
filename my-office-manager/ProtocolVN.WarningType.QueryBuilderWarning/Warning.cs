using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Plugin;
using ProtocolVN.Plugin.WarningSystem;
using ProtocolVN.Framework.Core;

namespace ProtocolVN.WarningType.QueryBuilderWarning
{
    public class Warning:IWarning
    {
        #region IWarning Members

        public List<IWarningDefine> GetWarning()
        {
            List<IWarningDefine> lstWarning = new List<IWarningDefine>();
            lstWarning.Add(new QueryBuilderWarning(
                new QueryBuilder("select * from USER_CAT where 1=1"),
                1
                ));
            return lstWarning;
        }

        #endregion
    }
}
