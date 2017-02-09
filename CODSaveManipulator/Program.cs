using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CODSaveManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                System.Console.WriteLine("CODSaveManipulator\nA program for manipulating Call of Duty savegames in various ways.\n\nFunctions that are currently supported:\n\n-rehash\n    Fixes the checksum on a Call of Duty savegame\n    Usage: CODSavegameManipulator -rehash <savegame.svg>\n\n-info\n    Prints various information about a savegame\n    Usage: CODSavegameManipulator -info <savegame.svg>");
                return;
            }

            FileStream savegameStream = new FileStream(args[1], FileMode.Open, FileAccess.ReadWrite);

            // Open our binary reader so we can parse the saves
            var reader = new EndianReader(savegameStream, Endian.LittleEndian);
            var writer = new EndianWriter(savegameStream, Endian.LittleEndian);

            // Endian checker
            // If the first byte of the save is 0, this means it is big endian
            // After getting the endian, reset the stream.
            if (reader.ReadByte() == 0)
            {
                reader.Endianness = Endian.BigEndian;
                writer.Endianness = Endian.BigEndian;
            }
            reader.BaseStream.Position = 0;

            Console.WriteLine(reader.Endianness);
            Rehash.RehashSavegame(reader, writer);
            return;

        }
    }
}
