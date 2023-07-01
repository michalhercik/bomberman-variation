using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class PowerUpTile : BaseTile
    {
        public BasePowerUp powerUp { private set; get; }
        public PowerUpTile(string tilePath, BasePowerUp powerUp) : base(tilePath)
        {
            this.powerUp = powerUp;       
        }

        public override void Draw(Graphics g, int xTile, int yTile)
        {
            base.Draw(g, xTile, yTile);
            powerUp.Draw(g, xTile, yTile);
        }
    }
}
