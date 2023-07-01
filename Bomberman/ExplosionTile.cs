using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class ExplosionTile : BaseTile
    {
        protected Image explosion;

        public ExplosionTile(string tilePath, string explosionPath) : base(tilePath)
        {
            explosion = Image.FromFile(explosionPath);
        }
        public override void Draw(Graphics g, int xTile, int yTile)
        {
            base.Draw(g, xTile, yTile);
            g.DrawImage(explosion, xTile * size, yTile * size, size, size);
        }
    }
}
