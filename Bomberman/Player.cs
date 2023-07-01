using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Player
    {
        IPlayerController controller;
        public Image Img { private set; get; }
        Image heart;
        public Direction Direction { private set; get; }
        public int Size { private set; get; } = 32;
        public float X;
        public float Y;
        // true if player just placed down a bomb
        public bool StandingOnBomb { private set; get; } = false;
        public int PlacedBombsCount = 0;
        public int Speed = 8;
        public int BombCapacity { private set; get; } = 1;
        public int BombPower = 2;
        public bool Kick = false;
        public int Life = 3;
        private int damageCooldown = 2000;
        private long lastDamage = -2000;
        // y axis shift for damage animation
        private int heartShift = 36;

        public Player(string path, float x, float y, IPlayerController contr)
        {
            Img = Image.FromFile(path);
            heart = Image.FromFile(@"tex\Other\heart.png");
            X = x;
            Y = y;
            controller = contr;
        }
        public void Draw(Graphics g, long time)
        {
            g.DrawImage(Img, X, Y, Size, Size);
            if (!IsTimeForDamage(time))
            {
                g.DrawImage(heart, X + Size / 4, Y - heartShift + Size/2, 16, 16);
                if (heartShift < 36)
                    heartShift += 3;
            }
        }
        public void UpdateDirection()
        {
            Direction = controller.GetDirection();
        }
        public void Move()
        {
            if (Direction != null)
            {
                int xTile = (int)(X + Size / 2) / Size;
                int yTile = (int)(Y + Size / 2) / Size;
                X += Direction.DX * Speed;
                Y += Direction.DY * Speed;
                if (xTile != (int)(X + Size / 2) / Size || yTile != (int)(Y + Size / 2) / Size)
                    StandingOnBomb = false;

            }
        }
        public bool DropBomb()
        {
            if (controller.HasDroppedBomb() && PlacedBombsCount < BombCapacity && !StandingOnBomb)
            {
                PlacedBombsCount += 1;
                StandingOnBomb = true;
                return true;
            }
            return false;
        }
        public bool IsTimeForDamage(long time)
        {
            return time - lastDamage >= damageCooldown;
        }
        public bool IsAlive()
        {
            return Life > 0;
        }
        public float XCenter()
        {
            return X / Size + 0.5f;
        }
        public float YCenter()
        {
            return Y / Size + 0.5f;
        }
        public void Hit(long time)
        {
            Life -= 1;
            lastDamage = time;
            heartShift = 0;
        }
        public void ExpandBombCapacity()
        {
            BombCapacity += BombCapacity == 10 ? 0 : 1;
        }
    }
}
