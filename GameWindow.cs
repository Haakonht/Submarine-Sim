using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using WMPLib;
using SubmarineSimulator.Properties;
using System.IO;
using System.Reflection;

namespace SubmarineSimulator
{
    public partial class GameWindow : Form
    {
        //PIXEL FONT
        private PrivateFontCollection pfc = new PrivateFontCollection();
        //BOOLEANS
        private Boolean menuScreen = true;
        private Boolean gameRunning = true;
        private Boolean explosion = false;
        //GRAPHICS INIT
        private Graphics g;
        //RANDOM CLASS
        private Random rand = new Random();
        //GAMEOBJECTS
        private List<Boats> targets = new List<Boats>();
        private List<Torpedo> torpedos = new List<Torpedo>();
        private List<Fish> fishies = new List<Fish>();
        private List<Bomb> bombs = new List<Bomb>();
        private PowerUp powerUp = null;
        private Submarine sub;
        //GAME VARIABLES
        private int highscore = 0;
        private int score;
        private int timeLeft = 90;
        private int explosionTime = 0;
        private int maxTorpedos = 1;
        //GAME SOUNDS
        System.Media.SoundPlayer explosionSound = new System.Media.SoundPlayer(Resources.ExplosionSound);

        public GameWindow()
        {
            InitializeComponent();
            DoubleBuffered = true;
            pfc.AddFontFile("Resources/PixelFont.ttf");
            Font pixelFont = new Font(pfc.Families[0], 10.0F);
            Font largePixelFont = new Font(pfc.Families[0], 16.0F);
            sub = new Submarine(Width/2-60, Height-120);
            GameLogic.Enabled = true;
            TextTimer.Enabled = true;
            highscore = new Highscore().getScore();
            GameName.Font = largePixelFont;
            Highscore.Font = pixelFont;
            ScoreCounter.Font = pixelFont;
            NewGame.Font = pixelFont;
            GameOverLabel.Font = largePixelFont;
            Reset.Font = pixelFont;
            Timer.Font = pixelFont;
            Highscore.Text = "Highscore: " + highscore;
        }

        private void GameLogic_Tick(object sender, EventArgs e)
        {
            int boatGen = rand.Next(1, 100);
            int fishGen = rand.Next(1, 200);
            int powerGen = rand.Next(0, 300);
            Refresh();
            ScoreCounter.Text = "Score: " + score;
            if (explosion)
            {
                explosionTime++;
            }
            if (menuScreen)
            {
                GameTimer.Enabled = false;

                
            }
            if (powerGen == 22 && powerUp == null)
            {
                powerUp = new PowerUp(rand.Next(Height/2, Height));
                Console.WriteLine("Power up dropped");
            }
            if (timeLeft == 0)
            {
                Timer.Text = "Time left: 0";
                gameOver();
            }
            if (targets.Count > 0)
            {
                targets = targets.OrderBy(y => y.getY()).ToList();
            }
            if (targets.Count < 4 && boatGen == 25)
            {
                int selector = rand.Next(1, 4);
                int z = rand.Next(0, 16);
                if (selector ==1)
                {
                    targets.Add(new SmallBoat(Height / 3 - z));
                }
                else if (selector ==2)
                {
                    targets.Add(new MediumBoat(Height / 3 - z));
                }
                else
                {
                    targets.Add(new LargeBoat(Height / 3 - z));
                }
            }
            if (fishies.Count < 20 && fishGen == 66)
            {
                int y = rand.Next(Height / 3 + 60, Height);
                fishies.Add(new Fish(y));
                Console.WriteLine("Fish added");
            }
            if (explosionTime > 15)
            {
                ExplosionGIF.Visible = false;
                explosion = false;
                explosionTime = 0;
            }
            if (gameRunning)
            {
                TargetMovement.Enabled = true;
                TorpedoMovement.Enabled = true;
                FishMovement.Enabled = true;
                GameTimer.Enabled = true;
            }
            else
            {
                TargetMovement.Enabled = false;
                TorpedoMovement.Enabled = false;
                FishMovement.Enabled = false;
                GameTimer.Enabled = false;
            }
            if (powerUp != null)
            {
                if (powerUp.getHitbox().IntersectsWith(sub.getHitbox()))
                {
                    if (maxTorpedos < 4)
                    {
                        maxTorpedos++;
                        powerUp = null;
                        Console.WriteLine("Torpedo count increased");
                    }  
                }
            } 
            for (int i = 0; i < targets.Count; i++)
            {
                Boats boat = targets.ElementAt(i);
                Rectangle hitbox = boat.getHitbox();
                for (int o = 0; o < torpedos.Count; o++)
                {
                    Torpedo torp = torpedos.ElementAt(o);
                    Rectangle hit = torp.getHitbox();
                    if (hitbox.IntersectsWith(hit))
                    {
                        Console.WriteLine("Kill confirmed!");
                        torpedos.Remove(torp);
                        if (!explosion)
                        {
                            int h = torp.getY() -20;
                            int j = torp.getX();
                            ExplosionGIF.Location = new Point(j, h);
                            ExplosionGIF.Visible = true;
                            explosion = true;
                            explosionSound.Play();
                        }
                        targets.Remove(boat);
                        score = score + boat.getScore();
                    }
                }
            }
            if (!menuScreen)
            {
                for (int i = 0; i < fishies.Count; i++)
                {
                    Fish fish = fishies.ElementAt(i);
                    Rectangle hitbox = fish.getHitbox();
                    if (hitbox.IntersectsWith(sub.getHitbox()))
                    {
                        gameOver();
                    }
                }
                for (int i = 0; i < bombs.Count; i++)
                {
                    Bomb bomb = bombs.ElementAt(i);
                    Rectangle hitbox = bomb.getHitbox();
                    if (hitbox.IntersectsWith(sub.getHitbox()))
                    {
                        gameOver();
                    }
                }
            }
        }

        private void gameOver()
        {
            timeLeft = 0;
            gameRunning = false;
            Reset.Visible = true;
            Reset.Enabled = true;
            GameLogic.Enabled = false;
            TargetMovement.Enabled = false;
            TorpedoMovement.Enabled = false;
            FishMovement.Enabled = false;
            GameTimer.Enabled = false;
            GameOverLabel.Visible = true;
            if (score > highscore)
            {
                highscore = score;
                Highscore.Text = "Highscore: " + highscore;
            }
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (!menuScreen)
            {
                if (e.KeyCode == Keys.Left)
                {
                    if (sub.getX() > 20)
                    {
                        int x = sub.getX(); x--; x--; sub.setX(x);
                    }  
                }
                else if (e.KeyCode == Keys.Right)
                {
                    if (sub.getX() < Width-20)
                    {
                        int x = sub.getX(); x++; x++; sub.setX(x);
                    }          
                }
                else if (e.KeyCode == Keys.Up)
                {
                    if (sub.getY() > Height /3 + 75)
                    {
                        int y = sub.getY(); y--; y--; sub.setY(y);
                    }      
                }
                else if (e.KeyCode == Keys.Down)
                {
                    if (sub.getY() < Height-100)
                    {
                        int y = sub.getY(); y++; y++; sub.setY(y);
                    }  
                }
                else if (e.KeyCode == Keys.Space)
                {
                    if (torpedos.Count < maxTorpedos)
                    {
                        torpedos.Add(new Torpedo(sub.getX(), sub.getY()));
                    }
                }
                else if (e.KeyCode == Keys.P)
                {
                    if (gameRunning)
                    {
                        gameRunning = false;
                    }
                    else
                    {
                        gameRunning = true;
                    }
                }
            }
            
        }

        private void TargetMovement_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                Boats boat = targets.ElementAt(i);
                int x = boat.getX();
                if (x > Width)
                {
                    targets.Remove(boat);
                    Console.WriteLine("Target removed from list");
                }
                else
                {
                    if (boat.getType().Equals("Small"))
                    {
                        x++;
                        x++;
                        x++;
                    }
                    else if (boat.getType().Equals("Medium"))
                    {
                        x++;
                        x++;
                    }
                    else
                    {
                        int bomb = rand.Next(1, 200);
                        if (bomb == 45)
                        {
                            bombs.Add(new Bomb(boat.getX(), Height / 3));
                            Console.WriteLine("Bomb dropped");
                        }
                        x++;
                    }
                    boat.setX(x);
                }
            }
        }

        private void TorpedoMovement_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < torpedos.Count; i++)
            {
                Torpedo torp = torpedos.ElementAt(i);
                int y = torp.getY();
                if (y < 0+Height/3+15)
                {
                    score = score - 10;
                    torpedos.Remove(torp);
                    Console.WriteLine("Torpedo removed from list");
                }
                else
                {
                    y--;
                    y--;
                    torp.setY(y);
                }
            }
            if (bombs.Count > 0)
            {
                for (int i = 0; i < bombs.Count; i++)
                {
                    Bomb b = bombs.ElementAt(i);
                    int y = b.getY();
                    if (y > Height)
                    {
                        bombs.Remove(b);
                        Console.WriteLine("Bomb removed from list");
                    }
                    else
                    {
                        y++;
                        b.setY(y);
                    }
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Console.WriteLine("New game started");
            timeLeft = 90;
            powerUp = null;
            maxTorpedos = 1;
            fishies.Clear();
            targets.Clear();
            torpedos.Clear();
            bombs.Clear();
            score = 0;
            Reset.Visible = false;
            Reset.Enabled = false;
            GameLogic.Enabled = true;
            GameOverLabel.Visible = false;
            gameRunning = true;
            this.Focus();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            Timer.Text = "Time left: " + timeLeft;
            if (timeLeft !=0)
            {
                timeLeft--;
            }
        }

        private void FishMovement_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < fishies.Count; i++)
            {
                Fish fish = fishies.ElementAt(i);
                int x = fish.getX();
                if (x > Width)
                {
                    fishies.Remove(fish);
                    Console.WriteLine("Fish removed from list");
                }
                else
                {
                    x++;
                    fish.setX(x);
                }
            }
            if (powerUp != null)
            {
                if (powerUp.getX() > Width)
                {
                    powerUp = null;
                    Console.WriteLine("Power up removed");                }
                else
                {
                    int x = powerUp.getX();
                    x++;
                    powerUp.setX(x);
                }
            }
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Highscore().saveScore(highscore);
        }

        private void Reset_MouseEnter(object sender, EventArgs e)
        {
            Reset.ForeColor = Color.Red;
        }

        private void Reset_MouseLeave(object sender, EventArgs e)
        {
            Reset.ForeColor = Color.Black;
        }

        private void NewGame_MouseEnter(object sender, EventArgs e)
        {
            NewGame.ForeColor = Color.Red;
        }

        private void NewGame_MouseLeave(object sender, EventArgs e)
        {
            NewGame.ForeColor = Color.Black;
        } 

        private void NewGame_Click(object sender, EventArgs e)
        {
            menuScreen = false;
            GameName.Visible = false;
            NewGame.Visible = false;
            TextTimer.Enabled = false;
            powerUp = null;
            maxTorpedos = 1;
            targets.Clear();
            fishies.Clear();
            bombs.Clear();
        }

        private void Background_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //RENDER SUB
            sub.drawSub(g);
            //RENDER TORPEDO
            foreach (Torpedo t in torpedos)
            {
                t.drawTorpedo(g);
            }
            //RENDER BOMBS
            foreach (Bomb b in bombs)
            {
                b.drawBomb(g);
            }
            //RENDER POWER UP
            if (powerUp != null)
            {
                powerUp.drawPowerUp(g);
            }
            //RENDER TARGETS
            foreach (Boats b in targets)
            {
                b.drawBoat(g);
            }
            //RENDER FISHIES
            foreach (Fish f in fishies)
            {
                f.drawFish(g);
            }
        }

        private void TextTimer_Tick(object sender, EventArgs e)
        {
            Color randomColor = Color.FromArgb(rand.Next(0, 150), rand.Next(0, 150), rand.Next(0, 150));
            GameName.ForeColor = randomColor;
        }
    }
}
