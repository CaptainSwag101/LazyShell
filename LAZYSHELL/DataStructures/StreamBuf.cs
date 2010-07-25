using System;
using System.Collections.Generic;
using System.Text;

namespace LAZYSHELL.DataStructures
{
    public class StreamBuf
    {
        byte[] buf; public byte[] Buffer { get { return this.buf; } set { this.buf = value; } }
        int index; public int Index { get { return this.index; } set { this.index = value; if (this.used < this.index) this.used = this.index; } }
        int used; public int Used { get { return this.used; } set { this.used = value; } }

        public StreamBuf(byte[] buf)
        {
            this.buf = buf;
            this.index = 0;
            this.used = 0;
        }

        #region Read Access
        public byte ReadByte()
        {
            try
            {

                return this.buf[this.Index++];
            }
            catch (Exception ex)
            {
                throw new Exception("StreamBuf out of data.\nSize: " + this.buf.Length + "\nRequested Index: " + Index);
            }
        }
        public ushort ReadShort(int offset)
        {
            try
            {
                return Bits.GetShort(this.buf, offset);
            }
            catch (Exception ex)
            {
                throw new Exception("StreamBuf out of data.\nSize: " + this.buf.Length + "\nRequested Index: " + Index);
            }
        }
        public byte ReadByte(int offset)
        {
            try
            {
                return this.buf[offset];
            }
            catch (Exception ex)
            {
                throw new Exception("StreamBuf out of data.\nSize: " + this.buf.Length + "\nRequested Index: " + offset);
            }
        }
        public byte[] ReadArray(int len)
        {
            byte[] ret = Bits.GetByteArray(this.buf, this.Index, len);
            this.Index += len;
            return ret;
        }
        public byte[] ReadArray(int offset, int len)
        {
            return Bits.GetByteArray(this.buf, offset, len);
        }
        public byte[] ToArray(int padToSize)
        {
            byte[] ret = new byte[padToSize];

            for (int i = 0; i < this.Index; i++)
                ret[i] = this.buf[i];

            return ret;
        }
        #endregion
        #region Write Access
        public void WriteByte(byte b, int offset)
        {
            try
            {
                this.buf[offset] = b;
            }
            catch (Exception ex)
            {
                throw new Exception("StreamBuf out of data.\nSize: " + this.buf.Length + "\nRequested Index: " + Index);
            }
        }
        public void AppendByte(StreamBuf sbuf)
        {
            AppendByte(sbuf.ReadByte());
        }
        public void AppendByte(byte b)
        {
            try
            {
                this.buf[this.Index++] = b;
            }
            catch (Exception ex)
            {
                throw new Exception("StreamBuf out of data.\nSize: " + this.buf.Length + "\nRequested Index: " + Index);
            }
        }
        public void WriteArray(byte[] arr, int offset)
        {
            Bits.SetByteArray(this.buf, offset, arr);
        }
        public void AppendArray(StreamBuf sbuf, int len)
        {
            AppendArray(sbuf.ReadArray(len));
        }
        public void AppendArray(StreamBuf sbuf)
        {
            AppendArray(sbuf.ReadArray(0, sbuf.Used));
        }
        public void AppendArray(byte[] arr)
        {
            Bits.SetByteArray(this.buf, this.Index, arr);
            this.Index += arr.Length;
        }
        #endregion
        public void Reset()
        {
            this.used = 0;
            this.index = 0;
        }
    }
}
