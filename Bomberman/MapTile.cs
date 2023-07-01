using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman
{
    class MapTile
    {
        string powerUpPath = @"tex\PowerUp\";
        string tilePath = @"tex\Tile\";
        string explosionPath = @"tex\Explosion\";
        string grassPath = @"tex\Tile\grass.png";
        static MapTile instance = new MapTile();
        public static MapTile Instance
        {
            get { return instance; }
        }
        public GrassTile GRASS { private set; get; }
        public WallTile WALL { private set; get; }
        public WallTile SIDEWALL { private set; get; }
        public BoxTile BOX { private set; get; }
        public ExplosionTile EXPLOSIONTOP { private set; get; }
        public ExplosionTile EXPLOSIONRIGHT { private set; get; }
        public ExplosionTile EXPLOSIONBOTTOM { private set; get; }
        public ExplosionTile EXPLOSIONLEFT { private set; get; }
        public ExplosionTile EXPLOSIONMIDDLE { private set; get; }
        public ExplosionTile EXPLOSIONVERTICAL { private set; get; }
        public ExplosionTile EXPLOSIONHORIZONTAL { private set; get; }
        public PowerUpTile FIREUP { private set; get; }
        public PowerUpTile BOMBUP { private set; get; }
        public PowerUpTile KICK { private set; get; }
        public PowerUpTile SKATE { private set; get; }
        public ExplosionPowerUpTile FIREUPEXPLOSIONTOP { private set; get; }
        public ExplosionPowerUpTile FIREUPEXPLOSIONRIGHT { private set; get; }
        public ExplosionPowerUpTile FIREUPEXPLOSIONBOTTOM { private set; get; }
        public ExplosionPowerUpTile FIREUPEXPLOSIONLEFT { private set; get; }
        public ExplosionPowerUpTile FIREUPEXPLOSIONHORIZONTAL { private set; get; }
        public ExplosionPowerUpTile FIREUPEXPLOSIONVERTICAL { private set; get; }
        public ExplosionPowerUpTile BOMBUPEXPLOSIONTOP { private set; get; }
        public ExplosionPowerUpTile BOMBUPEXPLOSIONRIGHT { private set; get; }
        public ExplosionPowerUpTile BOMBUPEXPLOSIONBOTTOM { private set; get; }
        public ExplosionPowerUpTile BOMBUPEXPLOSIONLEFT { private set; get; }
        public ExplosionPowerUpTile BOMBUPEXPLOSIONHORIZONTAL { private set; get; }
        public ExplosionPowerUpTile BOMBUPEXPLOSIONVERTICAL { private set; get; }
        public ExplosionPowerUpTile KICKEXPLOSIONTOP { private set; get; }
        public ExplosionPowerUpTile KICKEXPLOSIONRIGHT { private set; get; }
        public ExplosionPowerUpTile KICKEXPLOSIONBOTTOM { private set; get; }
        public ExplosionPowerUpTile KICKEXPLOSIONLEFT { private set; get; }
        public ExplosionPowerUpTile KICKEXPLOSIONHORIZONTAL { private set; get; }
        public ExplosionPowerUpTile KICKEXPLOSIONVERTICAL { private set; get; }
        public ExplosionPowerUpTile SKATEEXPLOSIONTOP { private set; get; }
        public ExplosionPowerUpTile SKATEEXPLOSIONRIGHT { private set; get; }
        public ExplosionPowerUpTile SKATEEXPLOSIONBOTTOM { private set; get; }
        public ExplosionPowerUpTile SKATEEXPLOSIONLEFT { private set; get; }
        public ExplosionPowerUpTile SKATEEXPLOSIONHORIZONTAL { private set; get; }
        public ExplosionPowerUpTile SKATEEXPLOSIONVERTICAL { private set; get; }
        public ExplosionTile[] EXPLOSIONENDINGS { private set; get; } = new ExplosionTile[4];
        public ExplosionPowerUpTile[] FIREUPEXPLOSIONENDINGS { private set; get; } = new ExplosionPowerUpTile[4];
        public ExplosionPowerUpTile[] BOMBUPEXPLOSIONENDINGS { private set; get; } = new ExplosionPowerUpTile[4];
        public ExplosionPowerUpTile[] KICKEXPLOSIONENDINGS { private set; get; } = new ExplosionPowerUpTile[4];
        public ExplosionPowerUpTile[] SKATEEXPLOSIONENDINGS { private set; get; } = new ExplosionPowerUpTile[4];

        private MapTile()
        {
            GRASS = new GrassTile(grassPath);
            WALL = new WallTile(tilePath + "wall.png");
            SIDEWALL = new WallTile(tilePath + "sidewall.png");
            BOX = new BoxTile(tilePath + "box.png");
            EXPLOSIONTOP = new ExplosionTile(grassPath, explosionPath + "top.png");
            EXPLOSIONRIGHT = new ExplosionTile(grassPath, explosionPath + "right.png");
            EXPLOSIONBOTTOM = new ExplosionTile(grassPath, explosionPath + "bottom.png");
            EXPLOSIONLEFT = new ExplosionTile(grassPath, explosionPath + "left.png");
            EXPLOSIONMIDDLE = new ExplosionTile(grassPath, explosionPath + "middle.png");
            EXPLOSIONVERTICAL = new ExplosionTile(grassPath, explosionPath + "vertical.png");
            EXPLOSIONHORIZONTAL = new ExplosionTile(grassPath, explosionPath + "horizontal.png");
            FireUpPowerUp fireUp = new FireUpPowerUp(powerUpPath + "fireup.png");
            BombUpPowerUp bombUp = new BombUpPowerUp(powerUpPath + "bombup.png");
            KickPowerUp kick = new KickPowerUp(powerUpPath + "kick.png");
            SkatePowerUp skate = new SkatePowerUp(powerUpPath + "skate.png");
            FIREUP = new PowerUpTile(grassPath, fireUp);
            BOMBUP = new PowerUpTile(grassPath, bombUp);
            KICK = new PowerUpTile(grassPath, kick);
            SKATE = new PowerUpTile(grassPath, skate);
            FIREUPEXPLOSIONTOP = new ExplosionPowerUpTile(grassPath, explosionPath + "top.png", fireUp);
            FIREUPEXPLOSIONRIGHT = new ExplosionPowerUpTile(grassPath, explosionPath + "right.png", fireUp);
            FIREUPEXPLOSIONBOTTOM = new ExplosionPowerUpTile(grassPath, explosionPath + "bottom.png", fireUp);
            FIREUPEXPLOSIONLEFT = new ExplosionPowerUpTile(grassPath, explosionPath + "left.png", fireUp);
            FIREUPEXPLOSIONHORIZONTAL = new ExplosionPowerUpTile(grassPath, explosionPath + "horizontal.png", fireUp);
            FIREUPEXPLOSIONVERTICAL = new ExplosionPowerUpTile(grassPath, explosionPath + "vertical.png", fireUp);
            BOMBUPEXPLOSIONTOP = new ExplosionPowerUpTile(grassPath, explosionPath + "top.png", bombUp);
            BOMBUPEXPLOSIONRIGHT = new ExplosionPowerUpTile(grassPath, explosionPath + "right.png", bombUp);
            BOMBUPEXPLOSIONBOTTOM = new ExplosionPowerUpTile(grassPath, explosionPath + "bottom.png", bombUp);
            BOMBUPEXPLOSIONLEFT = new ExplosionPowerUpTile(grassPath, explosionPath + "left.png", bombUp);
            BOMBUPEXPLOSIONHORIZONTAL = new ExplosionPowerUpTile(grassPath, explosionPath + "horizontal.png", bombUp);
            BOMBUPEXPLOSIONVERTICAL = new ExplosionPowerUpTile(grassPath, explosionPath + "vertical.png", bombUp);
            KICKEXPLOSIONTOP = new ExplosionPowerUpTile(grassPath, explosionPath + "top.png", kick);
            KICKEXPLOSIONRIGHT = new ExplosionPowerUpTile(grassPath, explosionPath + "right.png", kick);
            KICKEXPLOSIONBOTTOM = new ExplosionPowerUpTile(grassPath, explosionPath + "bottom.png", kick);
            KICKEXPLOSIONLEFT = new ExplosionPowerUpTile(grassPath, explosionPath + "left.png", kick);
            KICKEXPLOSIONHORIZONTAL = new ExplosionPowerUpTile(grassPath, explosionPath + "horizontal.png", kick);
            KICKEXPLOSIONVERTICAL = new ExplosionPowerUpTile(grassPath, explosionPath + "vertical.png", kick);
            SKATEEXPLOSIONTOP = new ExplosionPowerUpTile(grassPath, explosionPath + "top.png", skate);
            SKATEEXPLOSIONRIGHT = new ExplosionPowerUpTile(grassPath, explosionPath + "right.png", skate);
            SKATEEXPLOSIONBOTTOM = new ExplosionPowerUpTile(grassPath, explosionPath + "bottom.png", skate);
            SKATEEXPLOSIONLEFT = new ExplosionPowerUpTile(grassPath, explosionPath + "left.png", skate);
            SKATEEXPLOSIONHORIZONTAL = new ExplosionPowerUpTile(grassPath, explosionPath + "horizontal.png", skate);
            SKATEEXPLOSIONVERTICAL = new ExplosionPowerUpTile(grassPath, explosionPath + "vertical.png", skate);
            EXPLOSIONENDINGS[0] = EXPLOSIONRIGHT;
            EXPLOSIONENDINGS[1] = EXPLOSIONLEFT;
            EXPLOSIONENDINGS[2] = EXPLOSIONBOTTOM;
            EXPLOSIONENDINGS[3] = EXPLOSIONTOP;
            FIREUPEXPLOSIONENDINGS[0] = FIREUPEXPLOSIONRIGHT;
            FIREUPEXPLOSIONENDINGS[1] = FIREUPEXPLOSIONLEFT;
            FIREUPEXPLOSIONENDINGS[2] = FIREUPEXPLOSIONBOTTOM;
            FIREUPEXPLOSIONENDINGS[3] = FIREUPEXPLOSIONTOP;
            BOMBUPEXPLOSIONENDINGS[0] = BOMBUPEXPLOSIONRIGHT;
            BOMBUPEXPLOSIONENDINGS[1] = BOMBUPEXPLOSIONLEFT;
            BOMBUPEXPLOSIONENDINGS[2] = BOMBUPEXPLOSIONBOTTOM;
            BOMBUPEXPLOSIONENDINGS[3] = BOMBUPEXPLOSIONTOP;
            KICKEXPLOSIONENDINGS[0] = KICKEXPLOSIONRIGHT;
            KICKEXPLOSIONENDINGS[1] = KICKEXPLOSIONLEFT;
            KICKEXPLOSIONENDINGS[2] = KICKEXPLOSIONBOTTOM;
            KICKEXPLOSIONENDINGS[3] = KICKEXPLOSIONTOP;
            SKATEEXPLOSIONENDINGS[0] = SKATEEXPLOSIONRIGHT;
            SKATEEXPLOSIONENDINGS[1] = SKATEEXPLOSIONLEFT;
            SKATEEXPLOSIONENDINGS[2] = SKATEEXPLOSIONBOTTOM;
            SKATEEXPLOSIONENDINGS[3] = SKATEEXPLOSIONTOP;
        }
    }
}
