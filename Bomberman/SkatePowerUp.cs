using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class SkatePowerUp : BasePowerUp
    {
        public SkatePowerUp(string path) : base(path) { }
        public override void Action(Player player)
        {
            player.Speed += 1;
        }
    }
}
