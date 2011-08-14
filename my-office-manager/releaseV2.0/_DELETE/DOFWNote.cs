using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace ProtocolVN.Framework.Win
{
    [Serializable]
    public class DOFWNote : DOPhieu
    {
        public long ID;
        public long USERID;
        public byte[] NOI_DUNG;

        public DataSet DataSetMaster = new DataSet();
        public DOFWNote() { }

    }
}
