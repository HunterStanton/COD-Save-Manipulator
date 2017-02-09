using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CODSaveManipulator
{
    /// <summary>
    /// A class that deals with fixing the Adler32 checksum on savegames and getting offsets for specific games.
    /// </summary>
    class SavegameFixer
    {
        /// <summary>
        /// Gets the data offset for the specific game.
        /// The data offset is the offset in the SVG file where the data that will be checksummed begins.
        /// Data offset --> EOF is the entire block that is checksummed.
        /// </summary>
        /// <param name="ver">The version stored in the savegame.svg. It is different per game, so we can use it to know which game the save is for.</param>
        /// <returns>The offset for the specific game.</returns>
        static uint GetDataOffset(uint ver)
        {
            switch (ver)
            {
                // The order in the comment is the order of the cases
                // Ghosts, Advanced Warfare, Modern Warfare: Remastered
                case 71:
                case 95:
                case 103:
                    return 0x500;

                // Infinite Warfare
                case 331:
                    return 0x400;

                // Modern Warfare 2, Modern Warfare 3
                case 461:
                case 40:
                    return 0x480;

                // Unknown game, default to 0x500 because that might work because 0x500 is the most common offset which is used in the most games.
                default:
                    Console.WriteLine("Unknown.");
                    return 500;
            }

            // Somehow the switch failed completely, so let's just return 0 ¯\_(ツ)_/¯
            return 0x0;
        }
    }
}
