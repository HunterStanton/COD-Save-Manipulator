using System;
using System.Collections.Generic;
using System.Linq;
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
        }
    }
}
