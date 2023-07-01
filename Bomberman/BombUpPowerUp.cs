using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class BombUpPowerUp : BasePowerUp
    {
        public BombUpPowerUp(string path) : base(path) { }

        public override void Action(Player player)
        {
            player.ExpandBombCapacity();
        }
    }
}
