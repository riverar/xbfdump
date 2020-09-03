using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace xbfdump
{
    public class BaseXbfStream : IStream, IDisposable
    {
        protected Stream _backingStream;
        protected bool _disposed;
        public void Read(byte[] pv, int cb, IntPtr pcbRead)
        {
            Marshal.WriteInt32(pcbRead, _backingStream.Read(pv, 0, cb));
        }

        public void Write(byte[] pv, int cb, IntPtr pcbWritten)
        {
            _backingStream.Write(pv, 0, cb);
            Marshal.WriteInt32(pcbWritten, cb);
        }

        public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
        {
            Marshal.WriteInt64(plibNewPosition, _backingStream.Seek(dlibMove, (SeekOrigin)dwOrigin));
        }

        public void SetSize(long libNewSize)
        {
            _backingStream.SetLength(libNewSize);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _backingStream.Dispose();
                    _backingStream = null;
                }
                _disposed = true;
            }
        }

        public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
        {
            throw new NotImplementedException();
        }

        public void Commit(int grfCommitFlags)
        {
            throw new NotImplementedException();
        }

        public void Revert()
        {
            throw new NotImplementedException();
        }

        public void LockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new NotImplementedException();
        }

        public void UnlockRegion(long libOffset, long cb, int dwLockType)
        {
            throw new NotImplementedException();
        }

        public void Stat(out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, int grfStatFlag)
        {
            throw new NotImplementedException();
        }

        public void Clone(out IStream ppstm)
        {
            throw new NotImplementedException();
        }
    }
}
