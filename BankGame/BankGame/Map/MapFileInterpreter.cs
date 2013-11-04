using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BankGame.Map
{
    class MapFileInterpreter
    {
        File mapFile;

        public MapFileInterpreter()
        {
            mapFile = null;
        }

        public MapFileInterpreter(File mapFile)
        {
            this.mapFile = mapFile;
        }

        public List<Tile> GenerateTileList()
        {
            List<Tile> mapTileList = new List<Tile>();



            return mapTileList;
        }

        // Tile Texture Mode    _________________________
        // 0 - Top Left         |       |       |       |
        // 1 - Top              |   0   |   1   |   2   |
        // 2 - Top Right        |_______|_______|_______|
        // 3 - Left             |       |       |       |
        // 4 - Center           |   3   |   4   |   5   |
        // 5 - Right            |_______|_______|_______|
        // 6 - Bottom Left      |       |       |       |
        // 7 - Bottom           |   6   |   7   |   8   |
        // 8 - Bottom Right     |_______|_______|_______|

    }
}
