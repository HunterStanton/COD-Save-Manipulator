using System;
// Implements Adler32 checksumming, used in calculation of Ghosts savegame checksum

namespace GhostsChecksumFixer
{
    class Adler
    {
        private static uint MOD_ADLER = 65521;
        private uint Checksum;

        public long Value
        {
            get
            {
                return (long)this.Checksum;
            }
        }

        public Adler()
        {
            this.Reset();
        }

        public void Reset()
        {
            this.Checksum = 1U;
        }

        /// <summary>
        /// Shorthand version of Update.
        /// </summary>
        /// <param name="buff">The buffer of data that will be checksummed.</param>
        public void Update(byte[] buff)
        {
            this.Update(buff, buff.Length);
        }

        /// <summary>
        /// Calculates Adler32 checksum of input buffer.
        /// </summary>
        /// <param name="buff">The buffer of data that will be checksummed.</param>
        /// <param name="length">How much of the buffer to checksum.</param>
        public void Update(byte[] buff, int length)
        {
            int offset = 0;

            if (buff == null)
            {
                // Buffer should never be null, if is throw error
                throw new ArgumentNullException("buf");
            }

            uint check1 = this.Checksum & (uint)ushort.MaxValue;
            uint check2 = this.Checksum >> 16;
            while (length > 0)
            {
                int check3 = 3800;

                if (check3 > length)
                {
                    check3 = length;
                }

                length -= check3;

                while (--check3 >= 0)
                {
                    check1 += (uint)buff[offset++] & (uint)byte.MaxValue;
                    check2 += check1;
                }

                check1 %= Adler.MOD_ADLER;
                check2 %= Adler.MOD_ADLER;
            }
            this.Checksum = check2 << 16 | check1;
        }
    }
}
