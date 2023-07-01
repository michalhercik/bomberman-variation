using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    class Map
    {
        public IMapTile[,] Tiles { private set; get; } = new IMapTile[15, 13];
        HashSet<Bomb> bombs = new HashSet<Bomb>();
        public MapTile Tile { private set; get; } = MapTile.Instance;
        public bool TwoPlayersMode { private set; get; }
        public Player[] Players { private set; get; }
        public List<Player> LivePlayers { private set; get; }
        public int[,] ExplosionCounter { private set; get; } = new int[15, 13];

        public Map(string name, bool twoPlayersMode)
        {
            TwoPlayersMode = twoPlayersMode;
            LoadMap("maps\\" + name + ".map");
            string playerPath = "tex/Player/";
            Players = new Player[twoPlayersMode ? 2 : 4];
            Players[0] = new Player(playerPath + "1.png", 32, 32, new KeyboardController(Keys.Left, Keys.Up, Keys.Right, Keys.Down, Keys.ShiftKey));
            Players[1] = new Player(playerPath + "2.png", 416, 352, new KeyboardController(Keys.A, Keys.W, Keys.D, Keys.S, Keys.Q));
            if (!twoPlayersMode)
            {
                Players[2] = new Player(playerPath + "3.png", 32, 352, new KeyboardController(Keys.F, Keys.T, Keys.H, Keys.G, Keys.V));
                Players[3] = new Player(playerPath + "4.png", 416, 32, new KeyboardController(Keys.J, Keys.I, Keys.L, Keys.K, Keys.P));
            }
            LivePlayers = Players.ToList<Player>();
        }
        private void LoadMap(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                for (int i = 0; i < Tiles.GetLength(1); ++i)
                {
                    if ((line = sr.ReadLine()) == null)
                        return;
                    for (int j = 0; j < Tiles.GetLength(0); ++j)
                    {
                        if (j >= line.Length)
                            return;
                        if (line[j] == '0')
                        {
                            Tiles[j, i] = Tile.GRASS;
                        }
                        else if (line[j] == '1')
                        {
                            Tiles[j, i] = Tile.BOX;
                        }
                        else if (line[j] == '2')
                        {
                            Tiles[j, i] = Tile.WALL;
                        }
                        else if (line[j] == '3')
                        {
                            Tiles[j, i] = Tile.SIDEWALL;
                        }
                    }
                }
            }
        }

        private void Collision(Player player, int xTile, int yTile, bool xAxis)
        {
            // move player close to a obstacle
            void MoveToObstacle()
            {
                if (xAxis)
                    player.X = (xTile - player.Direction.DX) * player.Size;
                else
                    player.Y = (yTile - player.Direction.DY) * player.Size;
            }
            if (xTile >= 0 && xTile < Tiles.GetLength(0) && yTile >= 0 && yTile < Tiles.GetLength(1)
                && Tiles[xTile, yTile] is not WallTile 
                && Tiles[xTile, yTile] is not BoxTile
                && (Tiles[xTile, yTile] is not BombTile || player.StandingOnBomb || player.Kick))
            {
                if (Tiles[xTile, yTile] is BombTile && player.Kick && !player.StandingOnBomb)
                {
                    if (Tiles[xTile + player.Direction.DX, yTile + player.Direction.DY] is GrassTile)
                        ((BombTile)Tiles[xTile, yTile]).Bomb.SetMovement(player.Direction);
                    else
                    {
                        MoveToObstacle();
                        return;
                    }

                }
                // player aligment to a row or a column
                if (xAxis)
                    player.Y = yTile * player.Size;
                else
                    player.X = xTile * player.Size;
                player.Move();
                if (Tiles[xTile, yTile] is PowerUpTile)
                {
                    ((PowerUpTile)Tiles[xTile, yTile]).powerUp.Action(player);
                    Tiles[xTile, yTile] = Tile.GRASS;
                }
            }
            else
            {
                MoveToObstacle();
            }
        }

        public void UpdatePlayersPosition()
        {
            foreach (Player player in LivePlayers)
            {
                player.UpdateDirection();
                if (player.Direction != null)
                {
                    float x = (player.X + player.Direction.DX * player.Speed);
                    float y = (player.Y + player.Direction.DY * player.Speed);
                    float xTile = x / player.Size;
                    float yTile = y / player.Size;
                    if (player.Direction.DX == 1)
                    {
                        Collision(player, (int)xTile + 1, (int)(yTile + 0.5f), true);
                    }
                    else if (player.Direction.DX == -1)
                    {
                        Collision(player, (int)Math.Floor(xTile), (int)(yTile + 0.5f), true);
                    }
                    else if (player.Direction.DY == 1)
                    {
                        Collision(player, (int)(xTile + 0.5f), (int)(yTile + 1), false);
                    }
                    else if (player.Direction.DY == -1)
                    {
                        Collision(player, (int)(xTile + 0.5f), (int)Math.Floor(yTile), false);
                    }
                }
            }
        }
        private bool BombCanMove(int x, int y)
        {
            if (Tiles[x, y] is not GrassTile)
                return false;
            foreach (Player player in LivePlayers)
            {
                if (x == (int)Math.Floor(player.XCenter()) && y == (int)Math.Floor(player.YCenter()))
                    return false;
            }
            return true;
        }
        public void UpdateBombs(long time)
        {
            foreach (Bomb bomb in bombs)
            {
                if (bomb.IsTimeForNextPhase(time))
                {
                    if (bomb.NextPhase(this, time))
                        bombs.Remove(bomb);
                }
                if (bomb.Movement)
                {
                    int x = bomb.XTile + bomb.Direction.DX;
                    int y = bomb.YTile + bomb.Direction.DY;
                    if (BombCanMove(x, y))
                    {
                        Tiles[x, y] = Tiles[bomb.XTile, bomb.YTile];
                        Tiles[bomb.XTile, bomb.YTile] = Tile.GRASS;
                        bomb.Move();
                    }
                    else
                        bomb.StopMovement();
                }
            }
            foreach (Player player in LivePlayers)
            {
                if (player.DropBomb())
                {
                    int xTile = (int)(player.X + player.Size / 2) / player.Size;
                    int yTile = (int)(player.Y + player.Size / 2) / player.Size;
                    Bomb bomb = new Bomb(player, time, xTile, yTile);
                    bombs.Add(bomb);
                    Tiles[xTile, yTile] = new BombTile(bomb);
                }
            }
        }
        public void Draw(Graphics g, long time)
        {
            for (int i = 0; i < Tiles.GetLength(0); ++i)
            {
                for (int j = 0; j < Tiles.GetLength(1); ++j)
                {
                    Tiles[i, j].Draw(g, i, j);
                    foreach (Player player in LivePlayers)
                    {
                        
                        if ((Math.Floor(player.X / player.Size) == i || Math.Ceiling(player.X / player.Size) == i) 
                            && (Math.Floor(player.Y / player.Size) == j || Math.Ceiling(player.Y / player.Size) == j))
                            player.Draw(g, time);
                    }
                }
            }
        }
        public void PlayersDamage(long time)
        {
            Func<float, int> Convert = x => (int)Math.Floor(x);
            foreach (Player player in LivePlayers)
            {
                if ((Tiles[Convert(player.XCenter() + 0.4f), Convert(player.YCenter())] is ExplosionTile
                    || Tiles[Convert(player.XCenter() - 0.4f), Convert(player.YCenter())] is ExplosionTile
                    || Tiles[Convert(player.XCenter()), Convert(player.YCenter() + 0.4f)] is ExplosionTile
                    || Tiles[Convert(player.XCenter()), Convert(player.YCenter() - 0.4f)] is ExplosionTile)
                    && player.IsTimeForDamage(time))
                    player.Hit(time);
            }
        }
        public bool IsOnlyOnePlayerAlive()
        {
            int counter = 0;
            for (int i = LivePlayers.Count - 1; i >= 0; --i)
            {
                if (LivePlayers[i].IsAlive())
                    ++counter;
                else
                    LivePlayers.RemoveAt(i);
            }
            return counter < 2;
        }
    }
}
