using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab4Bits
{
    enum BitOrder
    {
        LeftToRight = 0,
        RightToLeft = 1
    }
    class BitReader : IDisposable
    {

        BufferedStream s = null;
        MemoryStream ms = null;

        bool disposed = false;
        byte? b = null;
        int pos = 0;

        public BitOrder bitOrder = BitOrder.LeftToRight;
        public bool EndOfStream;

        public BitReader(BufferedStream _s)
        {
            s = _s;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // Dispose managed resources
                if (disposing)
                {
                    if (this.s != null)
                    {
                        s.Close();
                    }

                    if (this.ms != null)
                    {
                        ms.Close();
                    }
                }

                // Dispose unmanaged resources
                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

    }
}
