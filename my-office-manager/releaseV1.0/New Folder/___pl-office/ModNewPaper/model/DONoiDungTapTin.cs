using ProtocolVN.Framework.Core;

namespace DTO
{
    public class DONoiDungTapTin:DOPhieu
    {
        private long _id;
        private byte[] _noiDung;
        private string _tenFile;
        private string _url;

        public long ID
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public byte[] NOI_DUNG
        {
            get { return this._noiDung; }
            set { this._noiDung = value; }
        }

        public string TEN_FILE
        {
            get { return this._tenFile; }
            set { this._tenFile = value; }
        }

        public string URL
        {
            get { return this._url; }
            set { this._url = value; }
        }

        public DONoiDungTapTin()
        {

        }

        public DONoiDungTapTin(long id,byte[] NoiDung,string TenFile,string Url)
        {
            this._id = id;
            this._noiDung = NoiDung;
            this._tenFile = TenFile;
            this._url = Url;            
        }
    }
}
