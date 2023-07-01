using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class Bomb
    {
        public int XTile;
        public int YTile;
        public bool Movement { private set; get; }
        public Direction Direction { private set; get; }
        BombImg bombImg = BombImg.Instance;
        // to decide which image use and when to explode
        public int phase = 0;
        long timeForNextPhase;
        long phaseDuration = 600;
        int power;
        Image img;
        int size = 32;
        public Player Owner { private set; get; }

        public Bomb(Player owner, long time, int xTile, int yTile)
        {
            Owner = owner;
            power = owner.BombPower;
            timeForNextPhase = time + phaseDuration;
            img = bombImg.Images[phase];
            XTile = xTile;
            YTile = yTile;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(img, XTile * size, YTile * size, size, size);
        }
        public bool IsTimeForNextPhase(long time)
        {
            return time > timeForNextPhase;
        }
        public bool NextPhase(Map map, long time)
        {
            ++phase;
            if (phase < bombImg.Images.Length)
                img = bombImg.Images[phase];
            else if (phase == bombImg.Images.Length)
                Explode(map);
            else if (phase == 8)
            {
                Die(map);
                return true;
            }
            timeForNextPhase = time + phaseDuration;
            return false;
        }
        private void Explode(Map map)
        {
            map.Tiles[XTile, YTile] = map.Tile.EXPLOSIONMIDDLE;
            ++map.ExplosionCounter[XTile, YTile];
            int[,] directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            for (int j = 0; j < directions.GetLength(0); ++j)
            {
                for (int i = 0; i < power; ++i)
                {
                    int x = XTile + directions[j, 0] * i;
                    int y = YTile + directions[j, 1] * i;
                    if (map.Tiles[x, y] == map.Tile.WALL || map.Tiles[x, y] == map.Tile.SIDEWALL)
                        break;
                    ++map.ExplosionCounter[x, y];
                    if (map.Tiles[x, y] is BombTile bombTile)
                        bombTile.Bomb.ExplodeNow(map);
                    if (map.Tiles[x, y] is BoxTile boxTile)
                    {
                        boxTile.Destroy(x, y, j, map);
                        break;
                    }
                    if (i == power - 1)
                    {
                        if (map.Tiles[x, y] is PowerUpTile)
                        {
                            if (map.Tiles[x, y] == map.Tile.FIREUP)
                                map.Tiles[x, y] = map.Tile.FIREUPEXPLOSIONENDINGS[j];
                            else if (map.Tiles[x, y] == map.Tile.BOMBUP)
                                map.Tiles[x, y] = map.Tile.BOMBUPEXPLOSIONENDINGS[j];
                            else if (map.Tiles[x, y] == map.Tile.KICK)
                                map.Tiles[x, y] = map.Tile.KICKEXPLOSIONENDINGS[j];
                            else if (map.Tiles[x, y] == map.Tile.SKATE)
                                map.Tiles[x, y] = map.Tile.SKATEEXPLOSIONENDINGS[j];
                        }
                        else
                            map.Tiles[x, y] = map.Tile.EXPLOSIONENDINGS[j];
                        break;
                    }
                    if (map.Tiles[x,y] is GrassTile)
                        map.Tiles[x, y] = directions[j, 0] == 0 ? map.Tile.EXPLOSIONVERTICAL : map.Tile.EXPLOSIONHORIZONTAL;
                    if (map.Tiles[x, y] is PowerUpTile)
                    {
                        if (map.Tiles[x, y] == map.Tile.FIREUP)
                            map.Tiles[x, y] = directions[j, 0] == 0 ? map.Tile.FIREUPEXPLOSIONVERTICAL : map.Tile.FIREUPEXPLOSIONHORIZONTAL;
                        else if (map.Tiles[x, y] == map.Tile.BOMBUP)
                            map.Tiles[x, y] = directions[j, 0] == 0 ? map.Tile.BOMBUPEXPLOSIONVERTICAL : map.Tile.BOMBUPEXPLOSIONHORIZONTAL;
                        else if (map.Tiles[x, y] == map.Tile.KICK)
                            map.Tiles[x, y] = directions[j, 0] == 0 ? map.Tile.KICKEXPLOSIONVERTICAL : map.Tile.KICKEXPLOSIONHORIZONTAL;
                        else if (map.Tiles[x, y] == map.Tile.SKATE)
                            map.Tiles[x, y] = directions[j, 0] == 0 ? map.Tile.SKATEEXPLOSIONVERTICAL : map.Tile.SKATEEXPLOSIONHORIZONTAL;
                    }
                }
            }
        }
        private void Die(Map map)
        {
            --map.ExplosionCounter[XTile, YTile];
            if (map.ExplosionCounter[XTile, YTile] == 0)
                map.Tiles[XTile, YTile] = map.Tile.GRASS;
            int[,] directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            for (int j = 0; j < directions.GetLength(0); ++j)
            {
                for (int i = 0; i < power; ++i)
                {
                    int x = XTile + directions[j, 0] * i;
                    int y = YTile + directions[j, 1] * i;
                    if (map.Tiles[x, y] is WallTile || map.Tiles[x, y] is BoxTile)
                        break;
                    map.ExplosionCounter[x, y] -= map.ExplosionCounter[x, y] > 0 ? 1 : 0;
                    if (map.ExplosionCounter[x, y] == 0)
                    {
                        if (map.Tiles[x, y] is ExplosionPowerUpTile)
                        {
                            if (((ExplosionPowerUpTile)map.Tiles[x, y]).PowerUp is FireUpPowerUp)
                                map.Tiles[x, y] = map.Tile.FIREUP;
                            else if (((ExplosionPowerUpTile)map.Tiles[x, y]).PowerUp is BombUpPowerUp)
                                map.Tiles[x, y] = map.Tile.BOMBUP;
                            else if (((ExplosionPowerUpTile)map.Tiles[x, y]).PowerUp is KickPowerUp)
                                map.Tiles[x, y] = map.Tile.KICK;
                            else if (((ExplosionPowerUpTile)map.Tiles[x, y]).PowerUp is SkatePowerUp)
                                map.Tiles[x, y] = map.Tile.SKATE;
                        }
                        else
                            map.Tiles[x, y] = map.Tile.GRASS;
                    }
                }
            }
            Owner.PlacedBombsCount -= 1;
        }
        public void SetMovement(Direction d)
        {
            Movement = true;
            Direction = d;
        }
        public void StopMovement()
        {
            Movement = false;
        }
        public void Move()
        {
            XTile += Direction.DX;
            YTile += Direction.DY;
        }
        public void ExplodeNow(Map map)
        {
            phase = 6;
            Explode(map);
        }
    }
}
