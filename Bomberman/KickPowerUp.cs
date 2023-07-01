using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class KickPowerUp : BasePowerUp
    {
        public KickPowerUp(string path) : base(path) { }

        public override void Action(Player player)
        {
            player.Kick = true;
        }
    }
}
