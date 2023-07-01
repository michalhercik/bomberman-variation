using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class ExplosionPowerUpTile : ExplosionTile
    {
        public BasePowerUp PowerUp { private set; get; }
        public ExplosionPowerUpTile(string tilePath, string explosionPath, BasePowerUp powerUp) : base(tilePath, explosionPath) 
        {
            PowerUp = powerUp;
        }

        public override void Draw(Graphics g, int xTile, int yTile)
        {
            g.DrawImage(img, xTile * size, yTile * size, size, size);
            PowerUp.Draw(g, xTile, yTile);
            g.DrawImage(explosion, xTile * size, yTile * size, size, size);
        }
    }
}
