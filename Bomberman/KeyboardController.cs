using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    class KeyboardController : IPlayerController
    {
        Keyboard keyboard = Keyboard.Instance;
        Directions directions = Directions.Instance;
        Keys[] controlKeys = new Keys[4];
        Keys bomb;

        public KeyboardController(Keys left, Keys up, Keys right, Keys down, Keys bomb)
        {
            controlKeys[0] = left;
            controlKeys[1] = up;
            controlKeys[2] = right;
            controlKeys[3] = down;
            this.bomb = bomb;
        }
        public Direction? GetDirection()
        {
            Direction direction = null;
            if (keyboard.IsPressed(controlKeys[0])) direction = directions.LEFT;
            if (keyboard.IsPressed(controlKeys[1])) direction = directions.UP;
            if (keyboard.IsPressed(controlKeys[2])) direction = directions.RIGHT;
            if (keyboard.IsPressed(controlKeys[3])) direction = directions.DOWN;
            if (keyboard.IsPressed(controlKeys[0]) && !keyboard.IsReleased(controlKeys[0])) direction = directions.LEFT;
            if (keyboard.IsPressed(controlKeys[1]) && !keyboard.IsReleased(controlKeys[1])) direction = directions.UP;
            if (keyboard.IsPressed(controlKeys[2]) && !keyboard.IsReleased(controlKeys[2])) direction = directions.RIGHT;
            if (keyboard.IsPressed(controlKeys[3]) && !keyboard.IsReleased(controlKeys[3])) direction = directions.DOWN;
            
            foreach (Keys key in controlKeys)
            {
                if (keyboard.IsReleased(key))
                {
                    keyboard.Pressed.Remove(key);
                    keyboard.Released.Remove(key);
                }
            }
            return direction;
        }
        public bool HasDroppedBomb()
        {
            if (keyboard.IsPressed(bomb))
            {
                keyboard.Pressed.Remove(bomb);
                keyboard.Released.Remove(bomb);
                return true;
            }
            return false;
        }
    }
}
