using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class BombTile : BaseTile
    {
        public Bomb Bomb { private set; get; }
        public BombTile(Bomb bomb) : base(@"tex\Tile\grass.png") 
        {
            Bomb = bomb;
        }

        public override void Draw(Graphics g, int xTile, int yTile)
        {
            base.Draw(g, xTile, yTile);
            Bomb.Draw(g);
        }
    }
}
