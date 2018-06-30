namespace SubmarineSimulator
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GameLogic = new System.Windows.Forms.Timer(this.components);
            this.TargetMovement = new System.Windows.Forms.Timer(this.components);
            this.TorpedoMovement = new System.Windows.Forms.Timer(this.components);
            this.ScoreCounter = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.FishMovement = new System.Windows.Forms.Timer(this.components);
            this.Highscore = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Label();
            this.GameName = new System.Windows.Forms.Label();
            this.NewGame = new System.Windows.Forms.Label();
            this.Background = new System.Windows.Forms.PictureBox();
            this.ExplosionGIF = new System.Windows.Forms.PictureBox();
            this.TextTimer = new System.Windows.Forms.Timer(this.components);
            this.GameOverLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplosionGIF)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLogic
            // 
            this.GameLogic.Enabled = true;
            this.GameLogic.Interval = 5;
            this.GameLogic.Tick += new System.EventHandler(this.GameLogic_Tick);
            // 
            // TargetMovement
            // 
            this.TargetMovement.Interval = 1;
            this.TargetMovement.Tick += new System.EventHandler(this.TargetMovement_Tick);
            // 
            // TorpedoMovement
            // 
            this.TorpedoMovement.Interval = 10;
            this.TorpedoMovement.Tick += new System.EventHandler(this.TorpedoMovement_Tick);
            // 
            // ScoreCounter
            // 
            this.ScoreCounter.AutoSize = true;
            this.ScoreCounter.BackColor = System.Drawing.Color.Transparent;
            this.ScoreCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreCounter.Location = new System.Drawing.Point(703, 9);
            this.ScoreCounter.Name = "ScoreCounter";
            this.ScoreCounter.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ScoreCounter.Size = new System.Drawing.Size(92, 25);
            this.ScoreCounter.TabIndex = 0;
            this.ScoreCounter.Text = "Score: 0";
            // 
            // Timer
            // 
            this.Timer.AutoSize = true;
            this.Timer.BackColor = System.Drawing.Color.Transparent;
            this.Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer.Location = new System.Drawing.Point(12, 9);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(130, 25);
            this.Timer.TabIndex = 2;
            this.Timer.Text = "Time left: 90";
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // FishMovement
            // 
            this.FishMovement.Interval = 1;
            this.FishMovement.Tick += new System.EventHandler(this.FishMovement_Tick);
            // 
            // Highscore
            // 
            this.Highscore.AutoSize = true;
            this.Highscore.BackColor = System.Drawing.Color.Transparent;
            this.Highscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Highscore.Location = new System.Drawing.Point(498, 9);
            this.Highscore.Name = "Highscore";
            this.Highscore.Size = new System.Drawing.Size(145, 25);
            this.Highscore.TabIndex = 3;
            this.Highscore.Text = "Highscore: 0";
            // 
            // Reset
            // 
            this.Reset.AutoSize = true;
            this.Reset.BackColor = System.Drawing.Color.Transparent;
            this.Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset.Location = new System.Drawing.Point(368, 276);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(68, 25);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "Reset";
            this.Reset.Visible = false;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            this.Reset.MouseEnter += new System.EventHandler(this.Reset_MouseEnter);
            this.Reset.MouseLeave += new System.EventHandler(this.Reset_MouseLeave);
            // 
            // GameName
            // 
            this.GameName.AutoSize = true;
            this.GameName.BackColor = System.Drawing.Color.Transparent;
            this.GameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameName.Location = new System.Drawing.Point(223, 129);
            this.GameName.Name = "GameName";
            this.GameName.Size = new System.Drawing.Size(265, 31);
            this.GameName.TabIndex = 5;
            this.GameName.Text = "Submarine Simulator";
            // 
            // NewGame
            // 
            this.NewGame.AutoSize = true;
            this.NewGame.BackColor = System.Drawing.Color.Transparent;
            this.NewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewGame.Location = new System.Drawing.Point(350, 251);
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(120, 25);
            this.NewGame.TabIndex = 6;
            this.NewGame.Text = "Start Game";
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            this.NewGame.MouseEnter += new System.EventHandler(this.NewGame_MouseEnter);
            this.NewGame.MouseLeave += new System.EventHandler(this.NewGame_MouseLeave);
            // 
            // Background
            // 
            this.Background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Background.Image = global::SubmarineSimulator.Properties.Resources.GameBackground;
            this.Background.Location = new System.Drawing.Point(0, 0);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(850, 516);
            this.Background.TabIndex = 7;
            this.Background.TabStop = false;
            this.Background.Paint += new System.Windows.Forms.PaintEventHandler(this.Background_Paint);
            // 
            // ExplosionGIF
            // 
            this.ExplosionGIF.BackColor = System.Drawing.Color.Transparent;
            this.ExplosionGIF.Image = global::SubmarineSimulator.Properties.Resources.explode;
            this.ExplosionGIF.Location = new System.Drawing.Point(602, 368);
            this.ExplosionGIF.Name = "ExplosionGIF";
            this.ExplosionGIF.Size = new System.Drawing.Size(50, 50);
            this.ExplosionGIF.TabIndex = 8;
            this.ExplosionGIF.TabStop = false;
            this.ExplosionGIF.Visible = false;
            // 
            // TextTimer
            // 
            this.TextTimer.Interval = 500;
            this.TextTimer.Tick += new System.EventHandler(this.TextTimer_Tick);
            // 
            // GameOverLabel
            // 
            this.GameOverLabel.AutoSize = true;
            this.GameOverLabel.BackColor = System.Drawing.Color.Transparent;
            this.GameOverLabel.Location = new System.Drawing.Point(308, 144);
            this.GameOverLabel.Name = "GameOverLabel";
            this.GameOverLabel.Size = new System.Drawing.Size(61, 13);
            this.GameOverLabel.TabIndex = 9;
            this.GameOverLabel.Text = "Game Over";
            this.GameOverLabel.Visible = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SubmarineSimulator.Properties.Resources.GameBackground;
            this.ClientSize = new System.Drawing.Size(850, 516);
            this.Controls.Add(this.GameOverLabel);
            this.Controls.Add(this.ExplosionGIF);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.ScoreCounter);
            this.Controls.Add(this.Highscore);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.NewGame);
            this.Controls.Add(this.GameName);
            this.Controls.Add(this.Background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GameWindow";
            this.Text = "Submarine Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GameWindow_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExplosionGIF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameLogic;
        private System.Windows.Forms.Timer TargetMovement;
        private System.Windows.Forms.Timer TorpedoMovement;
        private System.Windows.Forms.Label ScoreCounter;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer FishMovement;
        private System.Windows.Forms.Label Highscore;
        private System.Windows.Forms.Label Reset;
        private System.Windows.Forms.Label GameName;
        private System.Windows.Forms.Label NewGame;
        private System.Windows.Forms.PictureBox Background;
        private System.Windows.Forms.PictureBox ExplosionGIF;
        private System.Windows.Forms.Timer TextTimer;
        private System.Windows.Forms.Label GameOverLabel;
    }
}

