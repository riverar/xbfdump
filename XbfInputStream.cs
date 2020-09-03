using System.IO;

namespace xbfdump
{
    class XbfInputStream : BaseXbfStream, IStreamType
    {
        public XbfInputStream(string filePath)
        {
            _backingStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        public StreamType StreamType {  get { return StreamType.Input;  } }
    }
}
