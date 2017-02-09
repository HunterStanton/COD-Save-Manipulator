using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODSaveManipulator
{
    /// <summary>
    /// Class for handling the rehash option for save manipulator.
    /// </summary>
    class Rehash
    {
        static public void RehashSavegame(EndianReader reader, EndianWriter writer)
        {
            // Get the savegame version
            uint ver = reader.ReadUInt32();

            // Get the gamesave offset
            uint offset = Offsets.GetDataOffset(ver);

            // Storage variable for the calculated checksum
            uint sum = 0;

            // Get the original checksum from the file and store it
            reader.BaseStream.Position = 8;
            uint origChecksum = reader.ReadUInt32();

            // Put the entire savegame after 0x400 (which is the data that is checksummed by the game) into a buffer
            reader.BaseStream.Position = offset;
            byte[] buffer = reader.ReadBlock((int)(reader.BaseStream.Length - offset));

            // Calculate adler32 checksum of buffer
            Adler adler32 = new Adler();
            adler32.Update(buffer);

            // Overwrite the adler32 sum that is stored in the savegame
            writer.BaseStream.Position = 0x8;

            sum = (uint)adler32.Value;
            writer.WriteUInt32(sum);

            // Print new checksum and original
            System.Console.WriteLine("Savegame checksum updated!\nOriginal: " + origChecksum + " (" + origChecksum.ToString("X2") + ")" + "\nNew: " + sum + " (" + sum.ToString("X2") + ")");

            return;
        }
    }
}
