using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bomberman
{
    class Game
    {
        Stopwatch sw = new Stopwatch();
        public Map Map; 

        public Game() { }

        public void Start(Panel infoPanel)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (i < Map.Players.Length)
                        infoPanel.Controls[i * 4 + j + 2].Visible = true;
                    else
                        infoPanel.Controls[i * 4 + j + 2].Visible = false;
                }
            }
            sw.Start();
        }

        public void Stop()
        {
            sw.Stop();
            sw.Reset();
        }

        public void Pause()
        {
            sw.Stop();
        }
        public void Play()
        {
            sw.Start();
        }
        public void DrawGameInfo(Panel panel)
        {
            int size = 16;
            using (Graphics g = panel.CreateGraphics())
            {
                for (int i = 0; i < Map.Players.Length; ++i)
                {
                    g.DrawImage(Map.Players[i].Img, 5, 10 + i * 83);
                    for (int j = 0; j < Map.Players[i].Life; ++j)
                        g.DrawImage(Image.FromFile(@"tex\Other\heart.png"), j * 20 + 50, 18 + i * 83, size, size);
                    for (int j = 2; j >= Map.Players[i].Life; --j)
                        g.FillRectangle(Brushes.Black, j * 20 + 50, 18 + i * 83, size, size);
                }
            }
            for (int i = 0; i < Map.Players.Length; ++i)
            {
                panel.Controls[i * 4 + 3].Text = $"{Map.Players[i].BombPower}";
                panel.Controls[i * 4 + 5].Text = $"{Map.Players[i].BombCapacity}";
            }
            panel.Controls[panel.Controls.Count - 1].Text = String.Format("{0}:{1:00}", sw.Elapsed.Minutes, sw.Elapsed.Seconds);
        }

        public bool Run(Graphics g)
        {
            long time = sw.ElapsedMilliseconds;
            Map.UpdateBombs(time);
            Map.PlayersDamage(time);
            Map.UpdatePlayersPosition();
            Map.Draw(g, time);
            return Map.IsOnlyOnePlayerAlive();
        }
    }
}
