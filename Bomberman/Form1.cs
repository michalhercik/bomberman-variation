using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomberman
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        Game game = new Game();
        Keyboard keyboard = Keyboard.Instance;
        public Form1()
        {
            InitializeComponent();
            // creating labels for info panel
            int sectionSize = 83;
            for (int i = 0; i < 4; ++i)
            {
                Label power = new Label();
                power.Text = "Power:";
                power.Location = new Point(10, 40 + i * sectionSize);
                GameInfoPanel.Controls.Add(power);
                Label powerValue = new Label();
                powerValue.Location = new Point(70, 40 + i * sectionSize);
                GameInfoPanel.Controls.Add(powerValue);
                Label capacity = new Label();
                capacity.Text = "Capacity:";
                capacity.Location = new Point(10, 65 + i * sectionSize);
                GameInfoPanel.Controls.Add(capacity);
                Label capacityValue = new Label();
                capacityValue.Location = new Point(87, 65 + i * sectionSize);
                GameInfoPanel.Controls.Add(capacityValue);
            }
            foreach (Object obj in GameInfoPanel.Controls)
            {
                if (obj is Label)
                {
                    Label label = (Label)obj;
                    label.ForeColor = Color.WhiteSmoke;
                    label.AutoSize = true;
                }
            }
            Label gameTime = new Label
            {
                Location = new Point(0, 349),
                AutoSize = false,
                Size = new Size(130, 35),
                Font = new Font("SegoeUI", 10),
                ForeColor = Color.WhiteSmoke,
                Text = "bla",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            GameInfoPanel.Controls.Add(gameTime);

            Controls.Add(GamePanel);
            Controls.Add(WinPanel);

            // creating labels for winner panel
            Label win = new Label
            {
                Text = "Winner",
                AutoSize = true,
                Font = new Font("SegoeUI", 16),
                Location = new Point(140, 32),
                ForeColor = Color.WhiteSmoke
            };
            WinPanel.Controls.Add(win);
            Label time = new Label
            {
                AutoSize = true,
                Font = new Font("SegoeUI", 11),
                Location = new Point(170, 80),
                ForeColor = Color.WhiteSmoke
            };
            WinPanel.Controls.Add(time);

            timer.Interval = 10;
            timer.Tick += Update;
        }
        private void TexturesCheck()
        {
            string errorMsg = "";
            void CheckFile(string path)
            {
                if (!File.Exists(path))
                    errorMsg += "\"" + path + "\"" + "is missing\n";
            }
            string[] folders = { "Explosion", "PowerUp", "Tile" };
            List<string[]> names = new List<string[]>
            {
                new string[] { "bottom", "horizontal", "left", "middle", "right", "top", "vertical" },
                new string[] { "bombup", "fireup", "kick", "skate" },
                new string[] { "box", "dirt", "grass", "sidewall", "wall" }
            };
            for (int i = 0; i < folders.Length; ++i)
            {
                foreach (string name in names[i])
                    CheckFile("tex/" + folders[i] + "/" + name + ".png");
            }
            for (int i = 1; i < 7; ++i)
            {
                CheckFile("tex/Bomb/" + i + ".png");   
            }
            for (int i = 1; i < 5; ++i)
            {
                CheckFile("tex/Player/" + i + ".png");
            }
            CheckFile("tex/Other/heart.png");
            if (errorMsg.Length > 0)
            {
                MessageBox.Show(errorMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void AddValidMaps()
        {
            FileInfo[] files = null;
            try
            {
                files = new DirectoryInfo(@"maps").GetFiles("*.map");
            }
            catch (DirectoryNotFoundException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            bool validFile;
            int lineCounter;
            string line;
            foreach (FileInfo file in files)
            {
                validFile = true;
                using (StreamReader sr = new StreamReader(file.FullName))
                {
                    lineCounter = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ++lineCounter;
                        if (!Regex.IsMatch(line, @"[0-3]{15}") || line.Length != 15)
                        {
                            validFile = false;
                            break;
                        }
                    }
                }
                if (validFile && lineCounter == 13)
                    MapComboBox.Items.Add(file.Name.Substring(0, file.Name.Length - 4));
            }
            if (MapComboBox.Items.Count > 0)
                MapComboBox.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TexturesCheck();
            AddValidMaps();
        }
        private void Update(object sender, System.EventArgs e)
        {
            bool gameOver;
            using (Graphics g = GameMapPanel.CreateGraphics())
            {
                gameOver = game.Run(g);
            }
            game.DrawGameInfo(GameInfoPanel);
            if (gameOver)
                GameOver();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keyboard.Pressed.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyboard.Released.Add(e.KeyCode);
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            game.Stop();
            GamePanel.Visible = false;
            MenuPanel.Visible = true;
        }
        private void GameOver()
        {
            timer.Stop();
            game.Stop();
            GamePanel.Visible = false;
            WinPanel.Controls[WinPanel.Controls.Count - 1].Text = GameInfoPanel.Controls[GameInfoPanel.Controls.Count - 1].Text;
            using (Graphics g = WinPanel.CreateGraphics())
                g.DrawImage(game.Map.LivePlayers[0].Img, 170, 130, 48, 48);
            WinPanel.Visible = true;
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            if (PauseBtn.Text == "Pause")
            {
                game.Pause();
                timer.Stop();
                PauseBtn.Text = "Play";
            }
            else
            {
                game.Play();
                timer.Start();
                PauseBtn.Text = "Pause";
            }
            GamePanel.Focus();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            WinPanel.Visible = false;
            GamePanel.Visible = false;
            MenuPanel.Visible = true;
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            if (MapComboBox.SelectedItem != null)
            {
                MenuPanel.Visible = false;
                GamePanel.Visible = true;
                game.Map = new Map((string)MapComboBox.SelectedItem, TwoPlayersRadioBtn.Checked);
                game.Start(GameInfoPanel);
                timer.Start();
            }
            else
            {
                MessageBox.Show("Map is not selected!", "Bomberman", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
