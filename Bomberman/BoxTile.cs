using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class BoxTile : BaseTile
    {
        Random rnd = new Random();
        public BoxTile(string path) : base(path) { }

        public void Destroy(int xTile, int yTile, int direction, Map map)
        {
            switch (rnd.Next(7))
            {
                case 0:
                    map.Tiles[xTile, yTile] = map.Tile.FIREUPEXPLOSIONENDINGS[direction];
                    break;
                case 1:
                    map.Tiles[xTile, yTile] = map.Tile.BOMBUPEXPLOSIONENDINGS[direction];
                    break;
                case 2:
                    map.Tiles[xTile, yTile] = map.Tile.KICKEXPLOSIONENDINGS[direction];
                    break;
                case 3:
                    map.Tiles[xTile, yTile] = map.Tile.SKATEEXPLOSIONENDINGS[direction];
                    break;
                default:
                    map.Tiles[xTile, yTile] = map.Tile.EXPLOSIONENDINGS[direction];
                    break;
            }
        }
    }
}
