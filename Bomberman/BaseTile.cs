﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    abstract class BaseTile : IMapTile
    {
        protected Image img;
        protected int size = 32;

        public BaseTile(string path)
        {
            img = Image.FromFile(path);
        }

        public virtual void Draw(Graphics g, int xTile, int yTile)
        {
            g.DrawImage(img, xTile * size, yTile * size, size, size);
        }
    }
}
