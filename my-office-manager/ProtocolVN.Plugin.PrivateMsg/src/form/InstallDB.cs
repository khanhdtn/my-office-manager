using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Win;

namespace ProtocolVN.Plugin.PrivateMsg
{
    public class InstallDB : IPLInstall
    {
        #region IPLInstall Members

        public string CheckSQL()
        {
            return @"
                ...
            ";
        }

        public string GetInstallSQL()
        {
            return @"
                ...
            ";
        }

        public string GetUnInstallSQL()
        {
            return @"
                ...
            ";
        }

        #endregion
    }
}
