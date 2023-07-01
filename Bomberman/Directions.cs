using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Directions
    {
        static Directions instance = new Directions();
        public static Directions Instance
        {
            get { return instance; }
        }

        public Direction LEFT { private set; get; }
        public Direction UP { private set; get; }
        public Direction RIGHT { private set; get; }
        public Direction DOWN { private set; get; }
        
        private Directions()
        {
            LEFT = new Direction(-1, 0);
            UP = new Direction(0, -1);
            RIGHT = new Direction(1, 0);
            DOWN = new Direction(0, 1);
        }
    }
}
