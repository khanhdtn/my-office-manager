using System;
using System.Collections.Generic;
using System.Text;
using ProtocolVN.Framework.Core;
using System.Data;

namespace DTO
{
    [Serializable]
    public class DOChamCongAutoChot : DOPhieu
    {
        #region Fields
        public long ID;
        public DateTime NGAY;
        public DataSet DetailDataSet;
        #endregion

        #region Gets
        public long GetID()
        {
            return this.ID;
        }
        public DateTime GetNGAY()
        {
            return this.NGAY;
        }
        public DataSet GetDetailDataSet()
        {
            return (this.DetailDataSet != null) ? this.DetailDataSet : new DataSet();
        }

        #endregion

        #region Contructor
        public DOChamCongAutoChot() { }        
        #endregion
    }
}
