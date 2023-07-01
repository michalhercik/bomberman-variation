using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class BombImg
    {
        static BombImg instance = new BombImg();
        public static BombImg Instance
        {
            get { return instance; }
        }

        public Image[] Images { private set; get; } = new Image[6];

        public BombImg()
        {
            for (int i = 0; i < Images.Length; ++i)
                Images[i] = Image.FromFile(@"tex\Bomb\" + (i + 1) + ".png");
        }
    }
}
