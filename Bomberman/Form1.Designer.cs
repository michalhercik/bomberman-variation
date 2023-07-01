
namespace Bomberman
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.GameMapPanel = new System.Windows.Forms.Panel();
            this.WinPanel = new System.Windows.Forms.Panel();
            this.OkBtn = new System.Windows.Forms.Button();
            this.GameInfoPanel = new System.Windows.Forms.Panel();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.FourPlayersRadioBtn = new System.Windows.Forms.RadioButton();
            this.MapLabel = new System.Windows.Forms.Label();
            this.TwoPlayersRadioBtn = new System.Windows.Forms.RadioButton();
            this.MapComboBox = new System.Windows.Forms.ComboBox();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.MenuPanel.SuspendLayout();
            this.GamePanel.SuspendLayout();
            this.GameMapPanel.SuspendLayout();
            this.WinPanel.SuspendLayout();
            this.GameInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.MenuPanel.Controls.Add(this.GamePanel);
            this.MenuPanel.Controls.Add(this.FourPlayersRadioBtn);
            this.MenuPanel.Controls.Add(this.MapLabel);
            this.MenuPanel.Controls.Add(this.TwoPlayersRadioBtn);
            this.MenuPanel.Controls.Add(this.MapComboBox);
            this.MenuPanel.Controls.Add(this.PlayBtn);
            this.MenuPanel.Controls.Add(this.HeadingLabel);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuPanel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Padding = new System.Windows.Forms.Padding(0, 50, 0, 0);
            this.MenuPanel.Size = new System.Drawing.Size(611, 415);
            this.MenuPanel.TabIndex = 0;
            // 
            // GamePanel
            // 
            this.GamePanel.Controls.Add(this.GameMapPanel);
            this.GamePanel.Controls.Add(this.GameInfoPanel);
            this.GamePanel.Location = new System.Drawing.Point(1, 0);
            this.GamePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(610, 417);
            this.GamePanel.TabIndex = 2;
            this.GamePanel.Visible = false;
            // 
            // GameMapPanel
            // 
            this.GameMapPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.GameMapPanel.Controls.Add(this.WinPanel);
            this.GameMapPanel.Location = new System.Drawing.Point(130, 0);
            this.GameMapPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GameMapPanel.Name = "GameMapPanel";
            this.GameMapPanel.Size = new System.Drawing.Size(480, 417);
            this.GameMapPanel.TabIndex = 0;
            // 
            // WinPanel
            // 
            this.WinPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WinPanel.Controls.Add(this.OkBtn);
            this.WinPanel.Location = new System.Drawing.Point(110, 88);
            this.WinPanel.Name = "WinPanel";
            this.WinPanel.Size = new System.Drawing.Size(390, 240);
            this.WinPanel.TabIndex = 0;
            // 
            // OkBtn
            // 
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.OkBtn.FlatAppearance.BorderSize = 0;
            this.OkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.OkBtn.Location = new System.Drawing.Point(142, 185);
            this.OkBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(107, 33);
            this.OkBtn.TabIndex = 2;
            this.OkBtn.Text = "Ok";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // GameInfoPanel
            // 
            this.GameInfoPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.GameInfoPanel.Controls.Add(this.PauseBtn);
            this.GameInfoPanel.Controls.Add(this.ExitBtn);
            this.GameInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.GameInfoPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GameInfoPanel.Name = "GameInfoPanel";
            this.GameInfoPanel.Size = new System.Drawing.Size(130, 417);
            this.GameInfoPanel.TabIndex = 0;
            // 
            // PauseBtn
            // 
            this.PauseBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.PauseBtn.FlatAppearance.BorderSize = 0;
            this.PauseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PauseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.PauseBtn.Location = new System.Drawing.Point(65, 382);
            this.PauseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(65, 33);
            this.PauseBtn.TabIndex = 1;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ExitBtn.Location = new System.Drawing.Point(0, 382);
            this.ExitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(65, 33);
            this.ExitBtn.TabIndex = 0;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // FourPlayersRadioBtn
            // 
            this.FourPlayersRadioBtn.AutoSize = true;
            this.FourPlayersRadioBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FourPlayersRadioBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.FourPlayersRadioBtn.Location = new System.Drawing.Point(119, 191);
            this.FourPlayersRadioBtn.Name = "FourPlayersRadioBtn";
            this.FourPlayersRadioBtn.Size = new System.Drawing.Size(114, 32);
            this.FourPlayersRadioBtn.TabIndex = 4;
            this.FourPlayersRadioBtn.Text = "4 Players";
            this.FourPlayersRadioBtn.UseVisualStyleBackColor = true;
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.MapLabel.Location = new System.Drawing.Point(287, 158);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(57, 25);
            this.MapLabel.TabIndex = 8;
            this.MapLabel.Text = "Map:";
            // 
            // TwoPlayersRadioBtn
            // 
            this.TwoPlayersRadioBtn.AutoSize = true;
            this.TwoPlayersRadioBtn.Checked = true;
            this.TwoPlayersRadioBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TwoPlayersRadioBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.TwoPlayersRadioBtn.Location = new System.Drawing.Point(119, 155);
            this.TwoPlayersRadioBtn.Name = "TwoPlayersRadioBtn";
            this.TwoPlayersRadioBtn.Size = new System.Drawing.Size(114, 32);
            this.TwoPlayersRadioBtn.TabIndex = 3;
            this.TwoPlayersRadioBtn.TabStop = true;
            this.TwoPlayersRadioBtn.Text = "2 Players";
            this.TwoPlayersRadioBtn.UseVisualStyleBackColor = true;
            // 
            // MapComboBox
            // 
            this.MapComboBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MapComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MapComboBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MapComboBox.FormattingEnabled = true;
            this.MapComboBox.Location = new System.Drawing.Point(353, 155);
            this.MapComboBox.Name = "MapComboBox";
            this.MapComboBox.Size = new System.Drawing.Size(183, 34);
            this.MapComboBox.Sorted = true;
            this.MapComboBox.TabIndex = 7;
            // 
            // PlayBtn
            // 
            this.PlayBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PlayBtn.FlatAppearance.BorderSize = 0;
            this.PlayBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PlayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PlayBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.PlayBtn.Location = new System.Drawing.Point(230, 321);
            this.PlayBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(133, 45);
            this.PlayBtn.TabIndex = 1;
            this.PlayBtn.Text = "Play";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeadingLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.HeadingLabel.Location = new System.Drawing.Point(0, 50);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(611, 67);
            this.HeadingLabel.TabIndex = 0;
            this.HeadingLabel.Text = "Bomberman";
            this.HeadingLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(611, 415);
            this.Controls.Add(this.MenuPanel);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Bomberman";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            this.GamePanel.ResumeLayout(false);
            this.GameMapPanel.ResumeLayout(false);
            this.WinPanel.ResumeLayout(false);
            this.GameInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Panel GameMapPanel;
        private System.Windows.Forms.Panel GameInfoPanel;
        private System.Windows.Forms.Button PauseBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Label MapLabel;
        private System.Windows.Forms.ComboBox MapComboBox;
        private System.Windows.Forms.RadioButton FourPlayersRadioBtn;
        private System.Windows.Forms.RadioButton TwoPlayersRadioBtn;
        private System.Windows.Forms.Panel WinPanel;
        private System.Windows.Forms.Button OkBtn;
    }
}

