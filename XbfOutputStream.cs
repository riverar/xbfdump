using System.IO;

namespace xbfdump
{
    public class XbfOutputStream : BaseXbfStream, IStreamType
    {
        public XbfOutputStream(string filePath)
        {
            _backingStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
        }

        public StreamType StreamType {  get { return StreamType.Output;  } }
    }
}
