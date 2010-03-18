using System;
using System.Collections.Generic;
using System.Text;
using SMRPGED.DataStructures;

namespace SMRPGED.Compression
{
    public class LSCompression
    {
        const int MAX_SIZE = 0x10000; // Max size of a buffer compressed or decompressed
        const uint COMPRESSION_GAIN_THRESHHOLD = 0; // Throw out any compression routine that gives improvement less than COMPRESSION_GAIN_RATIO. 0 is optimal compression, higher is faster but worse.
        const float COMPRESSSION_RATIO_THRESHOLD = 2.0f; // Throw out any compression routine that gives a compression ratio of less than COMPRESSION_RATIO_THRESHOLD.
        const bool EXHAUSTIVE_SEARCH = true; // true is optimal compression, but takes much longer. Determines whether we search for patterns within patterns or not
        const bool USE_FIRST_POSITIVE_RESULT = false; // false is optimal compression, but takes longer. Determines whether we accept the first positive pattern match, or continue to search for a more optimal match.
        const int COMPRESSION_ROUTINE_NOT_VALID = -1;

        StreamBuf data, worker = new StreamBuf(new byte[MAX_SIZE]);
        private StreamBuf result = new StreamBuf(new byte[512]);
        private StreamBuf optimalResult = new StreamBuf(new byte[512]);

        bool working = true;
        public int bufCounter = 0;
        public int frameCounter = 0;

        public byte[] CompressFramePublic(StreamBuf buf)
        {
            this.worker.Reset();

            CompressFrame(buf);
            return worker.ToArray(worker.Index);
        }

        private enum CompressionRoutine
        {
            Case_0_AppendXChars4Bit,
            Case_1_AppendXChars,
            Case_2_AppendByteByte4Bit,
            Case_3_AppendByteByte,
            Case_4_AppendByteByteByte,
            Case_5_AppendByteRead,
            Case_6_AppendByteByteRead,
            Case_7_AppendByteByteByteRead,
            Case_8_AppendAscending,
            Case_9_AppendDescending,
            Case_10_AppendSum,
            Case_11_AppendSum16Bit,
            Case_12_AppendSubArr12BitOffset,
            Case_13_AppendSubArray8BitOffset,
            Case_14_AppendSubArray4BitOffset,
            Case_15_Complete,
            Case_16_SimpleStore
        };

        public LSCompression(byte[] data)
        {
            this.data = new StreamBuf(data);
        }
        public LSCompression()
        {
            this.data = null;
        }

        #region Public Compression Methods
        /**
         * Decompress from rom image data at offset
         **/
        public byte[] Decompress(int offset, int size)
        {
            if (this.data == null)
                throw new Exception("ERROR: LSCompression does not have an image loaded.\nPlease report this.");

            this.data.Index = offset;
            LSDecompress(this.data);

            return this.worker.ToArray(size);
        }
        public StreamBuf Decompress(int offset, int size, bool streambuf)
        {
            if (this.data == null)
                throw new Exception("ERROR: LSCompression does not have an image loaded.\nPlease report this.");

            this.data.Index = offset;
            LSDecompress(this.data);

            StreamBuf ret = new StreamBuf(this.worker.ToArray(size));
            ret.Index = this.worker.Index;

            return ret;
        }
        public byte[] Decompress(byte[] source, int size)
        {
            StreamBuf temp = new StreamBuf(source);
            temp.Index = 0;
            temp.Used = source.Length;

            LSDecompress(temp);

            return this.worker.ToArray(size);
        }
        /**
         * Compress buf into rom image at offset
         */
        public int Compress(byte[] source, int offset)
        {
            if (this.data == null)
                throw new Exception("ERROR: LSCompression does not have an image loaded.\nPlease report this.");

            StreamBuf temp = new StreamBuf(source);
            temp.Used = source.Length;

            LSCompress(temp);
            temp.Buffer = null;

            BitManager.SetByteArray(this.data.Buffer, offset, this.worker.Buffer, 0, this.worker.Used);

            return this.worker.Used;
        }
        /**
         * Compress buf into dest at offset
         */
        public int Compress(byte[] source, byte[] dest, int offset)
        {
            StreamBuf temp = new StreamBuf(source);
            temp.Used = source.Length;
            temp.Index = 0;

            LSCompress(temp);
            temp.Buffer = null;

            if (dest == null)
                return this.worker.Used;
            if (dest.Length - offset < this.worker.Used)
                throw new Exception("LSCompression: Destination buffer for compressed data too small. Report this.\nDest Buffer Size: " + dest.Length + "\nDest Offset: " + offset + "\nCompressed Size: " + this.worker.Used);

            BitManager.SetByteArray(dest, offset, this.worker.Buffer, 0, this.worker.Used);

            return this.worker.Used;
        }
        #endregion

        #region Compression Routines
        /**
         * Handles all the compression
         * 
         * @param StreamBuf buf - Contains the data to be compressed with he .Index property pointing to it
         * - Fills StreamBuf worker with the compressed data
         */
        private void LSCompress(StreamBuf buf)
        {
            this.worker.Reset();
            this.working = true;

            this.frameCounter = 0;
            while (this.working)
            {
                CompressFrame(buf);
                this.frameCounter++;
            }
        }
        /**
         * Processes at least one compression frame, potentially 2
         * 
         * Will process a simple frame if there is no optimal complex frame pointed to initially by buf.Index
         * 
         * A Complex frame is processed if the simple frame is not of maximum length (0xF0)

         * @param buf - The buffer to compress with the .Index pointing to the current compression frame
         */
        private void CompressFrame(StreamBuf buf)
        {
            const int sizeUncompressedMin = 1, sizeUncompressedMax = 0xF0;
            int sizeUncompressed;
            int baseIndex = buf.Index;
            int nextFrameSize = 0;

            while ((buf.Index <= buf.Used) && // Data left to process
                (buf.Index - baseIndex < sizeUncompressedMax)) // Size limit
            {
                if ((nextFrameSize = UseOptimalRoutine(buf)) > 0)
                    break;
                buf.Index++;
            }

            sizeUncompressed = buf.Index - baseIndex;

            if (sizeUncompressed >= sizeUncompressedMin)
            {
                this.worker.AppendByte((byte)(sizeUncompressed - 1));
                this.worker.AppendArray(buf.ReadArray(baseIndex, sizeUncompressed));
            }
            if (nextFrameSize > 0)
            {
                this.worker.AppendArray(BitManager.GetByteArray(this.optimalResult.Buffer, 0, this.optimalResult.Used));
                buf.Index += nextFrameSize;
            }

            this.optimalResult.Reset();
            this.result.Reset();
        }
        /*
         * Determines the optimal compression routine, processes it, and stores the usable results in this.optimalResult
         * this.optimalResult.Used = length
         * 
         * @param StreamBuf buf with the .Index pointing to current compression frame
         * @return int size of optimalResult, or 0 if none
         */
        private int UseOptimalRoutine(StreamBuf buf)
        {
            int size, optimal = -1;
            float compressionRatio, optimalRatio = 0;

            if (buf.Index >= buf.Used)
                if ((size = CompressionRoutineDispatcher(buf, CompressionRoutine.Case_15_Complete)) >= 1)
                {
                    SwapResults();
                    return size;
                }

            for (int i = 0; i < 14; i++)
            {
                size = CompressionRoutineDispatcher(buf, (CompressionRoutine)i);
                if (size > 0)
                {
                    compressionRatio = (size / this.result.Used);
                    if (compressionRatio > optimalRatio && compressionRatio >= COMPRESSSION_RATIO_THRESHOLD)
                    {
                        optimalRatio = compressionRatio;
                        optimal = size;
                        SwapResults();
                    }
                }
            }

            if (optimal > 0)
                return optimal;

            this.optimalResult.Reset();
            return 0;
        }
        /*
         * Calls the correct compression routine and returns the size of the uncompressed result or -1 if unusable
         */
        private int CompressionRoutineDispatcher(StreamBuf buf, CompressionRoutine routine)
        {
            switch (routine)
            {
                case CompressionRoutine.Case_0_AppendXChars4Bit:
                    return Case_0_AppendXChars4Bit(buf);
                case CompressionRoutine.Case_1_AppendXChars:
                    return Case_1_AppendXChars(buf);
                case CompressionRoutine.Case_2_AppendByteByte4Bit:
                    return Case_2_AppendByteByte4Bit(buf);
                case CompressionRoutine.Case_3_AppendByteByte:
                    return Case_3_AppendByteByte(buf);
                case CompressionRoutine.Case_4_AppendByteByteByte:
                    return Case_4_AppendByteByteByte(buf);
                case CompressionRoutine.Case_5_AppendByteRead:
                    return Case_5_AppendByteRead(buf);
                case CompressionRoutine.Case_6_AppendByteByteRead:
                    return Case_6_AppendByteByteRead(buf);
                case CompressionRoutine.Case_7_AppendByteByteByteRead:
                    return Case_7_AppendByteByteByteRead(buf);
                case CompressionRoutine.Case_8_AppendAscending:
                    return Case_8_AppendAscending(buf);
                case CompressionRoutine.Case_9_AppendDescending:
                    return Case_9_AppendDescending(buf);
                case CompressionRoutine.Case_10_AppendSum:
                    return Case_10_AppendSum(buf);
                case CompressionRoutine.Case_11_AppendSum16Bit:
                    return Case_11_AppendSum16Bit(buf);
                case CompressionRoutine.Case_12_AppendSubArr12BitOffset:
                    return Case_12_AppendSubArr12BitOffset(buf);
                case CompressionRoutine.Case_13_AppendSubArray8BitOffset:
                    return Case_13_AppendSubArray8BitOffset(buf);
                case CompressionRoutine.Case_14_AppendSubArray4BitOffset:
                    return Case_14_AppendSubArray4BitOffset(buf);
                case CompressionRoutine.Case_15_Complete:
                    return Case_15_Complete(buf);
                default:
                    throw new Exception("Unknown Compression Routine");
            }
        }
        private void SwapResults()
        {
            StreamBuf swapBuf = this.optimalResult;
            this.optimalResult = this.result;
            this.result = swapBuf;
        }
        private int Case_0_AppendXChars4Bit(StreamBuf buf)
        {
            const int sizeUncompressedMin = 3, sizeUncompressedMax = 0x12, sizeCompressed = 2;
            int sizeUncompressed;
            int index = buf.Index;
            byte b;

            if (index >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);

            // Bottom 4 bits are size, Top 4 bits are Character
            if (b >= 0x10)
                return COMPRESSION_ROUTINE_NOT_VALID;

            //     Have data left   && terminate chain at 0x12
            while (index < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (b != buf.ReadByte(index))
                    break;
                index++;
            }
            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            b = (byte)(b << 4);
            b |= (byte)(sizeUncompressed - 3);
            this.result.AppendByte(0xF0);
            this.result.AppendByte(b);

            return sizeUncompressed;
        }
        private int Case_1_AppendXChars(StreamBuf buf)
        {
            const int sizeUncompressedMin = 4, sizeUncompressedMax = 0x103, sizeCompressed = 3;
            int sizeUncompressed;
            int index = buf.Index;
            byte b;

            if (index >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);

            //     Have data left && terminate chain at 0x103
            while (index < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (b != buf.ReadByte(index))
                    break;
                index++;
            }

            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;


            // Save results
            this.result.Reset();
            this.result.AppendByte(0xF1);
            this.result.AppendByte((byte)(sizeUncompressed - 4));
            this.result.AppendByte(b);

            return sizeUncompressed;
        }
        private int Case_2_AppendByteByte4Bit(StreamBuf buf)
        {
            const int sizeUncompressedMin = 4, sizeUncompressedMax = 0x202, sizeCompressed = 3;
            int sizeUncompressed;
            int index = buf.Index;
            byte b, c;

            if (index + 1 >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);

            if (b >= 0x10)
                return COMPRESSION_ROUTINE_NOT_VALID;

            c = buf.ReadByte(index++);

            if (c >= 0x10)
                return COMPRESSION_ROUTINE_NOT_VALID;

            //     Have data left   && terminate chain at 0x202
            while (index + 1 < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (buf.ReadByte(index) != b)
                    break;

                if (buf.ReadByte(index + 1) != c)
                    break;

                index += 2;
            }

            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            b |= (byte)(c << 4);
            this.result.AppendByte(0xF2);
            this.result.AppendByte((byte)((sizeUncompressed - sizeUncompressedMin) / 2));
            this.result.AppendByte(b);

            return sizeUncompressed;
        }
        private int Case_3_AppendByteByte(StreamBuf buf)
        {
            const int sizeUncompressedMin = 4, sizeUncompressedMax = 0x202, sizeCompressed = 4;
            int sizeUncompressed;
            int index = buf.Index;
            byte b, c;

            if (index + 1 >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);
            c = buf.ReadByte(index++);

            //     Have data left   && terminate chain at 0x202
            while (index + 1 < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (buf.ReadByte(index) != b)
                    break;

                if (buf.ReadByte(index + 1) != c)
                    break;

                index += 2;
            }

            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return -1;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xF3);
            this.result.AppendByte((byte)((sizeUncompressed - sizeUncompressedMin) / 2));
            this.result.AppendByte(b);
            this.result.AppendByte(c);

            return sizeUncompressed;
        }
        private int Case_4_AppendByteByteByte(StreamBuf buf)
        {
            const int sizeUncompressedMin = 6, sizeUncompressedMax = 0x303, sizeCompressed = 5;
            int sizeUncompressed;
            int index = buf.Index;
            byte b, c, d;

            if (index + 2 >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);
            c = buf.ReadByte(index++);
            d = buf.ReadByte(index++);

            //     Have data left   && terminate chain at 0x303
            while (index + 2 < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (buf.ReadByte(index) != b)
                    break;

                if (buf.ReadByte(index + 1) != c)
                    break;

                if (buf.ReadByte(index + 2) != d)
                    break;

                index += 3;
            }

            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xF4);
            this.result.AppendByte((byte)((sizeUncompressed - sizeUncompressedMin) / 3));
            this.result.AppendByte(b);
            this.result.AppendByte(c);
            this.result.AppendByte(d);

            return sizeUncompressed;
        }
        private int Case_5_AppendByteRead(StreamBuf buf)
        {
            const int sizeUncompressedMin = 8, sizeUncompressedMax = 0x206;
            int sizeUncompressed;
            int sizeCompressed; // 2 + SizeUncompressed/2
            int index = buf.Index;
            byte b;

            if (index >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);
            index++;

            //     Have data left       && terminate chain at 0x206
            while (index + 1 < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (buf.ReadByte(index) != b)
                    break;
                index += 2;
            }

            sizeUncompressed = index - buf.Index;
            sizeCompressed = 2 + (sizeUncompressed / 2);

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xF5);
            this.result.AppendByte((byte)((sizeUncompressed - sizeUncompressedMin) / 2));
            this.result.AppendByte(b);

            for (int i = buf.Index; i < index; )
            {
                i++;
                this.result.AppendByte(buf.ReadByte(i++));
            }
            return sizeUncompressed;
        }
        private int Case_6_AppendByteByteRead(StreamBuf buf)
        {
            const int sizeUncompressedMin = 9, sizeUncompressedMax = 0x306;
            int sizeUncompressed; // At least 9, at most 0x306
            int sizeCompressed; // Tag + byte1 + byte2 + SizeUncompressed/3
            int index = buf.Index;
            byte b, c;

            if (index + 1 >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);
            c = buf.ReadByte(index++);
            index++;

            //     Have data left       && terminate chain at 0x306
            while (index + 2 < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (buf.ReadByte(index) != b)
                    break;
                if (buf.ReadByte(index + 1) != c)
                    break;

                index += 3;
            }

            sizeUncompressed = index - buf.Index;
            sizeCompressed = 3 + (sizeUncompressed / 3);

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xF6);
            this.result.AppendByte((byte)((sizeUncompressed - sizeUncompressedMin) / 3));
            this.result.AppendByte(b);
            this.result.AppendByte(c);

            for (int i = buf.Index; i < index; )
            {
                i += 2;
                this.result.AppendByte(buf.ReadByte(i++));
            }

            return sizeUncompressed;
        }
        private int Case_7_AppendByteByteByteRead(StreamBuf buf)
        {
            const int sizeUncompressedMin = 8, sizeUncompressedMax = 0x404;
            int sizeUncompressed;
            int sizeCompressed; // 4 + SizeUncompressed/4
            int index = buf.Index;
            byte b, c, d;

            if (index + 2 >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);
            c = buf.ReadByte(index++);
            d = buf.ReadByte(index++);
            index++;
            //     Have data left       && terminate chain at 0x404
            while (index + 3 < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (buf.ReadByte(index) != b)
                    break;
                if (buf.ReadByte(index + 1) != c)
                    break;
                if (buf.ReadByte(index + 2) != d)
                    break;

                index += 4;
            }

            sizeUncompressed = index - buf.Index;
            sizeCompressed = 4 + (sizeUncompressed / 4);

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xF7);
            this.result.AppendByte((byte)((sizeUncompressed - sizeUncompressedMin) / 4));
            this.result.AppendByte(b);
            this.result.AppendByte(c);
            this.result.AppendByte(d);

            for (int i = buf.Index; i < index; )
            {
                i += 3;
                this.result.AppendByte(buf.ReadByte(i++));
            }

            return sizeUncompressed;
        }
        private int Case_8_AppendAscending(StreamBuf buf)
        {
            const int sizeUncompressedMin = 4, sizeUncompressedMax = 0x103;
            int sizeUncompressed;
            int sizeCompressed = 3;
            int index = buf.Index;
            byte b;

            if (index >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index);

            while (index < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (buf.ReadByte(index) != b)
                    break;
                index++;
                b++;
            }

            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xF8);
            this.result.AppendByte((byte)(sizeUncompressed - 4));
            this.result.AppendByte(buf.ReadByte(buf.Index));

            return sizeUncompressed;
        }
        private int Case_9_AppendDescending(StreamBuf buf)
        {
            const int sizeUncompressedMin = 4, sizeUncompressedMax = 0x103, sizeCompressed = 3;
            int sizeUncompressed;
            int index = buf.Index;
            byte b;

            if (index >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index);

            //     Have data left   && terminate chain at 0x103
            while (index < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                if (buf.ReadByte(index) != b)
                    break;

                index++;
                b--;
            }

            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xF9);
            this.result.AppendByte((byte)(sizeUncompressed - 4));
            this.result.AppendByte(buf.ReadByte(buf.Index));

            return sizeUncompressed;
        }
        private int Case_10_AppendSum(StreamBuf buf)
        {
            const int sizeUncompressedMin = 5, sizeUncompressedMax = 0x104, sizeCompressed = 4;
            int sizeUncompressed;
            int index = buf.Index;
            byte b, c;

            if (index + 1 >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            b = buf.ReadByte(index++);
            c = buf.ReadByte(index);

            if (c > b)
                c -= b;
            else
                c = (byte)(b - c);


            //     Have data left   && terminate chain at 0x104
            while (index < buf.Used && index - buf.Index < sizeUncompressedMax)
            {
                b += c;
                if (buf.ReadByte(index) != b)
                    break;
                index++;
            }

            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xFA);
            this.result.AppendByte((byte)(sizeUncompressed - sizeUncompressedMin));
            this.result.AppendByte(buf.ReadByte(buf.Index));
            this.result.AppendByte(c);

            return sizeUncompressed;
        }
        private int Case_11_AppendSum16Bit(StreamBuf buf)
        {
            const int sizeUncompressedMin = 0x05, sizeUncompressedMax = 0x104;
            int sizeUncompressed;
            int sizeCompressed = 4;
            int index = buf.Index;
            ushort value, sum;

            if (index + 3 >= buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            value = buf.ReadShort(index); index += 2;
            sum = (ushort)(buf.ReadShort(index) - value);
            //index += 2;

            if (sum >= 0x80 && sum < 0xFF80)
                return COMPRESSION_ROUTINE_NOT_VALID;

            while ((index + 1 < buf.Used) && // Have data left
                (index - buf.Index < sizeUncompressedMax)) // Havent crossed boundary
            {
                value += sum;
                if (buf.ReadShort(index) != value)
                    break;
                index += 2;
            }

            sizeUncompressed = index - buf.Index;

            if (sizeUncompressed < sizeUncompressedMin || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xFB);
            this.result.AppendByte((byte)((sizeUncompressed / 2) - 3));
            this.result.AppendByte(buf.ReadByte(buf.Index));
            this.result.AppendByte(buf.ReadByte(buf.Index + 1));
            this.result.AppendByte((byte)(sum & 0xFF));

            return sizeUncompressed;
        }
        private int Case_12_AppendSubArr12BitOffset(StreamBuf buf)
        {
            const int sizeUncompressedMin = 0x4, sizeUncompressedMax = 0x13, offsetMax = 0x1000; // Limits
            const int sizeCompressed = 3; // Tag + 12bit Negative Offset + 4bit Len
            int offset, sizeUncompressed;
            byte b;

            offset = buf.Index;
            offset = (offset > offsetMax) ? offset - offsetMax : 0; // Offset is always positive

            sizeUncompressed = PatternMatchSubArray(buf, sizeUncompressedMin, sizeUncompressedMax, offset, 1);
            offset = this.result.Index;

            if (sizeUncompressed <= sizeUncompressedMin || offset == -1 || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            offset = (buf.Index - (offset + 2)); // Calculate negative offset
            this.result.AppendByte(0xFC); // Tag
            this.result.AppendByte((byte)(offset & 0xFF)); // Negative offset
            b = (byte)((sizeUncompressed - sizeUncompressedMin) << 4); // calculate 4bit length
            b |= (byte)(offset >> 8); // Calculate 4 bit offset
            this.result.AppendByte(b); // Length and Offset

            return sizeUncompressed;
        }
        private int Case_13_AppendSubArray8BitOffset(StreamBuf buf)
        {
            const int sizeUncompressedMin = 0x14, sizeUncompressedMax = 0x100, offsetMax = 0x100; // Limits
            const int sizeCompressed = 3; // Tag + Negative Offset + Len
            int sizeUncompressed, offset;
            byte b;

            offset = buf.Index;
            offset = (offset >= offsetMax) ? offset - offsetMax : 0; // Offset is always positive

            sizeUncompressed = PatternMatchSubArray(buf, sizeUncompressedMin, sizeUncompressedMax, offset, 1);
            offset = this.result.Index;

            if (sizeUncompressed <= sizeUncompressedMin || offset == -1 || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            b = (byte)(buf.Index - (offset + 2)); // Calculate negative offset - Verify this, untested
            this.result.AppendByte(0xFD); // Tag
            this.result.AppendByte(b); // Negative offset
            this.result.AppendByte((byte)(sizeUncompressed - sizeUncompressedMin)); // Length

            return sizeUncompressed;
        }
        private int Case_14_AppendSubArray4BitOffset(StreamBuf buf)
        {
            const int sizeUncompressedMin = 0x03, sizeUncompressedMax = 0x12, offsetMax = 0x80; // Limits
            const int sizeCompressed = 2; // Tag + 4 Negative Offset + 4bit Len 
            int offset, sizeUncompressed;
            byte b;

            // Calculate range to scan
            offset = buf.Index;
            offset = (offset >= offsetMax) ? offset - offsetMax : offset & 7; // Offset is always positive

            sizeUncompressed = PatternMatchSubArray(buf, sizeUncompressedMin, sizeUncompressedMax, offset, 8);
            offset = this.result.Index;

            if (sizeUncompressed <= sizeUncompressedMin || offset == -1 || sizeUncompressed - sizeCompressed < COMPRESSION_GAIN_THRESHHOLD)
                return COMPRESSION_ROUTINE_NOT_VALID;

            // Save results
            this.result.Reset();
            offset = (buf.Index - offset - 8); // Calculate negative offset
            this.result.AppendByte(0xFE); // Tag
            b = (byte)((offset << 1) & 0xF0); // Offset
            b |= (byte)(sizeUncompressed - sizeUncompressedMin); // Len
            this.result.AppendByte(b);

            return sizeUncompressed;
        }
        private int Case_15_Complete(StreamBuf buf)
        {
            if (buf.Index < buf.Used)
                return COMPRESSION_ROUTINE_NOT_VALID;

            this.working = false;

            // Save results
            this.result.Reset();
            this.result.AppendByte(0xFF);

            return 1; // Not accurate, but doesnt matter anymore, were done
        }
        /**
         * Returns the length of match found or 0 if no match
         * Stores the offset of the match found in this.results.index, -1 if no match
         */
        private int PatternMatchSubArray(StreamBuf buf, int sizeUncompressedMin, int sizeUncompressedMax, int offset, int iterationSize)
        {
            int bestOffset = -1, index = buf.Index, scanner = 1, sizeUncompressed = 0;

            // Perform search
            for (; (offset < buf.Index) && // Still have more data to scan
                (index < buf.Used) &&  // Still have more data to match
                (sizeUncompressed < sizeUncompressedMax);  // Have not found optimal match
                offset += iterationSize, scanner = 1, index = buf.Index)
            {
                // Try to find a match in at this offset
                for (; (index < buf.Used) &&
                    (offset + scanner < buf.Index) && // Havent crossed boundary
                    (buf.ReadByte(offset + scanner) == buf.ReadByte(index)) && // While matching a subarray to the next line of bytes
                    (scanner < sizeUncompressedMax); // Havent found optimal match
                    scanner++, index++)
                {
                    if (scanner > sizeUncompressed) // If this match is larger than any before
                    {
                        bestOffset = offset;
                        sizeUncompressed = scanner;
                    }
                }

                //if (!EXHAUSTIVE_SEARCH)
                //    offset += scanner - (scanner % iterationSize);

                if (USE_FIRST_POSITIVE_RESULT && sizeUncompressed >= sizeUncompressedMin)
                    break;
            }

            if (sizeUncompressed <= sizeUncompressedMin)
            {
                this.result.Index = -1;
                this.result.Used = -1;
                return -1;
            }

            this.result.Index = bestOffset;
            this.result.Used = sizeUncompressed;

            return sizeUncompressed;
        }
        #endregion

        #region Decompression Routines
        /**
         * Handles all the decompression
         * 
         * @param StreamBuf buf - Contains the compressed data with the .Index property pointing to it
         * - Fills StreamBuf worker with the decompressed data
         * @return buffer containing decompressed data
         **/

        private byte lastRoutine = 0;
        private byte beforeLast = 0;
        public byte counter = 0;


        public byte pBuf = 1;
        public byte pRoutine = 0xFA;
        public int pIndex = 0x2F8;

        private void LSDecompress(StreamBuf buf)
        {
            int x, y, i;
            byte b, c, d, e;

            this.working = true;
            this.worker.Reset();


            while (working)
            {
                b = buf.ReadByte();
            
                if (b < 0xF0)
                {
                    this.worker.AppendArray(buf, ++b);
                    continue;
                }

                switch ((CompressionRoutine)(b & 0x0F)) // DECOMPRESSION SWITCH
                {
                    case CompressionRoutine.Case_0_AppendXChars4Bit: // Append X characters
                        b = buf.ReadByte(); // Read a byte
                        i = (b & 0x0F); // isolate low 4 bits
                        i += 3;     // calculate length by isolating top 4 bits
                        b = (byte)(b >> 4); // calculate character
                        Append(b, i);
                        break;
                    case CompressionRoutine.Case_1_AppendXChars: // Append X characters
                        b = buf.ReadByte(); // get length
                        c = buf.ReadByte(); // get character
                        i = b + 4; // add 4 to length
                        Append(c, i);
                        break;
                    case CompressionRoutine.Case_2_AppendByteByte4Bit: // Append 2 selective characters multiple times
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        i = b + 2;
                        d = (byte)(c >> 4);
                        c &= 0x0F;
                        AppendBB(c, d, i);
                        break;
                    case CompressionRoutine.Case_3_AppendByteByte: // Append 2 characters multiple times
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        d = buf.ReadByte();
                        i = b + 2;
                        AppendBB(c, d, i);
                        break;
                    case CompressionRoutine.Case_4_AppendByteByteByte: // Append 3 characters multiple timex
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        d = buf.ReadByte();
                        e = buf.ReadByte();
                        i = b + 2;
                        AppendBBB(c, d, e, i);
                        break;
                    case CompressionRoutine.Case_5_AppendByteRead: // Append a character followed by a character from the stream multiple times
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        i = b + 4;
                        AppendBR(c, i, buf);
                        break;
                    case CompressionRoutine.Case_6_AppendByteByteRead: // Append 2 characters followed by a character from the stream multiple times
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        d = buf.ReadByte();
                        i = b + 3;
                        AppendBBR(c, d, i, buf);
                        break;
                    case CompressionRoutine.Case_7_AppendByteByteByteRead: // Append 3 characters followed by a character from the stream multiple times
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        d = buf.ReadByte();
                        e = buf.ReadByte();
                        i = b + 2;
                        AppendBBBR(c, d, e, i, buf);
                        break;
                    case CompressionRoutine.Case_8_AppendAscending: // Append characters in ascending order
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        i = b + 4;
                        AppendAscending(c, i);
                        break;
                    case CompressionRoutine.Case_9_AppendDescending: // Append characters in descending order
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        i = b + 4;
                        AppendDescending(c, i);
                        break;
                    case CompressionRoutine.Case_10_AppendSum: // Append characters with an added value each character
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        d = buf.ReadByte();
                        i = b + 5;
                        AppendSum(c, d, i);
                        break;
                    case CompressionRoutine.Case_11_AppendSum16Bit:
                        b = buf.ReadByte(); // Length
                        c = buf.ReadByte(); // The bottom byte of baseValue
                        d = buf.ReadByte(); // The top byte of a baseValue
                        e = buf.ReadByte(); // The bottom byte of sum

                        i = b + 3; // Calc len

                        x = 0xFF00; // y = sum value
                        if (e < 0x80) // Treat as unsigned short
                            x = 0; // Treat as signed short

                        x |= e; // Calculate sum value 
                        y = d << 8; // y = base value
                        y |= c; // Calculate base value

                        AppendSum16Bit(y, x, i);
                        break;
                    case CompressionRoutine.Case_12_AppendSubArr12BitOffset: // Append a subarray from within worker to the end of worker, using a 12 bit negative offset
                        b = buf.ReadByte();
                        c = buf.ReadByte();

                        x = c >> 4; // Length is top 4 bits of 2nd byte
                        x += 4; // Min of 4, max of 0x103

                        y = c & 0x0F; // Isolate bottom 4 bits
                        y = y << 8;
                        y = y | b; // Use bottom 4 bits as extension to the negative offset

                        y = this.worker.Index - y;
                        y--;
                        if (y >= 0 && this.worker.Index + x <= MAX_SIZE)
                            AppendInternalSubArray(y, x);
                        else
                            this.working = false;
                        break;
                    case CompressionRoutine.Case_13_AppendSubArray8BitOffset: // Append a subarray from within worker to the end of worker using an 8 bit negative offset
                        b = buf.ReadByte();
                        c = buf.ReadByte();
                        x = c + 0x14; // Calculate length
                        y = this.worker.Index - b; // Calculate offset, ranges 0-0xFF
                        y--;

                        if (y >= 0 && this.worker.Index + x <= MAX_SIZE)
                            AppendInternalSubArray(y, x);
                        else
                            this.working = false;

                        break;
                    case CompressionRoutine.Case_14_AppendSubArray4BitOffset: // Append a subarray from within worker to the end of worker using a 4 bit negative offset
                        b = buf.ReadByte();

                        x = b & 0x0F; // Isolate bottom 4bits
                        x += 3; // Add 3 to len

                        b &= 0xF0; // Isolate top 4 bits
                        b = (byte)(b >> 1); // Divide by 2

                        y = this.worker.Index - b; // Calculate zero-indexed offset using negative offset
                        y -= 8; // Subtract 8 from offset

                        if (y >= 0 && this.worker.Index >= y + x)
                            AppendInternalSubArray(y, x);
                        else
                            this.working = false;
                        break;
                    case CompressionRoutine.Case_15_Complete: // Complete
                        this.working = false;
                        break;
                }

            }
        }
        private void Append(byte character, int len)
        {
            while (len > 0)
            {
                this.worker.AppendByte(character);
                len--;
            }
        }
        private void AppendBB(byte char1, byte char2, int num)
        {
            while (num > 0)
            {
                this.worker.AppendByte(char1);
                this.worker.AppendByte(char2);
                num--;
            }
        }
        private void AppendBBB(byte char1, byte char2, byte char3, int num)
        {
            while (num > 0)
            {
                this.worker.AppendByte(char1);
                this.worker.AppendByte(char2);
                this.worker.AppendByte(char3);
                num--;
            }
        }
        private void AppendBR(byte character, int num, StreamBuf buf)
        {
            while (num > 0)
            {
                this.worker.AppendByte(character);
                this.worker.AppendByte(buf);
                num--;
            }
        }
        private void AppendBBR(byte char1, byte char2, int num, StreamBuf buf)
        {
            while (num > 0)
            {
                this.worker.AppendByte(char1);
                this.worker.AppendByte(char2);
                this.worker.AppendByte(buf);
                num--;
            }
        }
        private void AppendBBBR(byte char1, byte char2, byte char3, int num, StreamBuf buf)
        {
            while (num > 0)
            {
                this.worker.AppendByte(char1);
                this.worker.AppendByte(char2);
                this.worker.AppendByte(char3);
                this.worker.AppendByte(buf);
                num--;
            }
        }
        private void AppendAscending(byte character, int num)
        {
            while (num > 0)
            {
                this.worker.AppendByte(character++);
                num--;
            }
        }
        private void AppendDescending(byte character, int num)
        {
            while (num > 0)
            {
                this.worker.AppendByte(character--);
                num--;
            }
        }
        private void AppendSum(byte character, byte add, int num)
        {
            while (num > 0)
            {
                this.worker.AppendByte(character);
                character += add;
                num--;
            }
        }
        private void AppendSum16Bit(int value, int sum, int len)
        {
            while (len > 0)
            {
                this.worker.AppendByte((byte)(value & 0xFF)); // Write least significant byte
                this.worker.AppendByte((byte)((value >> 8) & 0xFF)); // Write most signifcant byte
                value += sum;
                len--;
            }
        }
        /**
         * Appends an array of bytes of length len already existing in worker
         */
        private void AppendInternalSubArray(int offset, int len)
        {
            for (; len > 0; len--)
                this.worker.AppendByte(this.worker.ReadByte(offset++));
            //this.worker.AppendArray(this.worker.ReadArray(offset, len));
        }
        #endregion

    }
}
