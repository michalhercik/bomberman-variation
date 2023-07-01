using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    abstract class BasePowerUp
    {
        Image img;
        int size = 32;

        public BasePowerUp(string path)
        {
            img = Image.FromFile(path);
        }
        public void Draw(Graphics g, int xTile, int yTile)
        {
            g.DrawImage(img, xTile * size, yTile * size, size, size);
        }
        public abstract void Action(Player player);
    }
}
