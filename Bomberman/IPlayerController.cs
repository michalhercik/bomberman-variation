﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    interface IPlayerController
    {
        public Direction? GetDirection();
        public bool HasDroppedBomb();
    }
}
