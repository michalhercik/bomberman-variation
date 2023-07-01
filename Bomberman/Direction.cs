using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Direction
    {
        public int DX { private set; get; }
        public int DY { private set; get; }
        public Direction(int dX, int dY)
        {
            DX = dX;
            DY = dY;
        }
    }
}
