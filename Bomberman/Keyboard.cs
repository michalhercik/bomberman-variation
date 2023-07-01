using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    class Keyboard
    {
        static Keyboard instance = new Keyboard();
        public static Keyboard Instance
        {
            get { return instance; }
        }
        public ConsoleKeyInfo? keyInfo { private set; get; }
        public HashSet<Keys> Pressed { private set; get; } = new HashSet<Keys>();
        public HashSet<Keys> Released { private set; get; } = new HashSet<Keys>();
        private Keyboard() { }

        public bool IsPressed(Keys key)
        {
            return Pressed.Contains(key);
        }
        public bool IsReleased(Keys key)
        {
            return Released.Contains(key);
        }
    }
}
