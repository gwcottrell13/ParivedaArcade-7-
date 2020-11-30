using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Will_s_pariveda_7th_attempt
{
    public partial class PilotEscape : Form
    {
        //player moves
        //Little easter egg, I like to call the player BigAL
        int moveLeft = 0;
        
        //random plane movement generator
        Random rnd = new Random();
        
        //enemy movement is a random generator of +5 or -5
        // I make a method to make it easier
        
        int enemyMove = 0;

        //Missile Movement
        int MissileSpeed = 8;
        
        //score
        int score = 0;

        public PilotEscape()
        {
            //setting the game elements
            InitializeComponent();
            enemy1.Top = 320;
            enemy2.Top = 320;
            enemy3.Top = 320;

            Missile1.Top = enemy1.Top;
            Missile1.Left = enemy1.Left;
            Missile2.Top = enemy2.Top;
            Missile2.Left = enemy2.Left;
            Missile3.Top = enemy3.Top;
            Missile3.Left = enemy3.Left;

            

        }
        

        private void PilotEscape_Load(object sender, EventArgs e)
        {
            //start timers
            playTimer.Enabled = true;
            Missile1Timer.Enabled = true;
            Missile2Timer.Enabled = true;
            Missile3Timer.Enabled = true;

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left){
                if(BigAL.Location.X < 0)
                {
                    moveLeft = 0;
                }
                else
                {
                    moveLeft = -5;
                }
            }
            else if(e.KeyCode == Keys.Right)
            {
                if(BigAL.Location.X > 295)
                {
                    moveLeft = 0;
                }
                else
                {
                    moveLeft = 5;
                }
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                moveLeft = 0;
            }
            else if(e.KeyCode == Keys.Right)
            {
                moveLeft = 0;
            }
        }
private void playTimer_Tick(object sender, EventArgs e)
        {
            //player movement
            BigAL.Left += moveLeft;
            //Missile movement
            Missile1.Top -= MissileSpeed;
            Missile2.Top -= MissileSpeed;
            Missile3.Top -= MissileSpeed;
           
            //Score changing
            FlightTime.Text = "" + score;
            score = score + 5;

            //game ends if missile hits Big AL
            //need 3  Missiles
            //if((Missile1.Left == BigAL.Left && Missile1.Top == BigAL.Top)|| (Missile2.Left == BigAL.Left && Missile2.Top == BigAL.Top) || (Missile3.Left == BigAL.Left && Missile3.Top == BigAL.Top))
            if((BigAL.Bounds.IntersectsWith(Missile1.Bounds))|| (BigAL.Bounds.IntersectsWith(Missile2.Bounds)) || (BigAL.Bounds.IntersectsWith(Missile3.Bounds)))
            {
                GameOver();
            }

        }
        //thanks to stackoverflow for this entire method
       
        private void GameOver()
        {
            //Game over if a Missile hits Big AL
            playTimer.Enabled = false;
            Missile1Timer.Enabled = false;
            Missile2Timer.Enabled = false;
            Missile3Timer.Enabled = false;
            //reset missiles
            Missile1.Top = enemy1.Top;
            Missile2.Top = enemy2.Top;
            Missile3.Top = enemy3.Top;
            EnemyMovementTimer.Enabled = false;
            MessageBox.Show("Your score is " + score + "Play Again?");

           
            //reset the game
            score = 0;
            FlightTime.Text = "0";
            enemy1.Top = 320;
            enemy2.Top = 320;
            enemy3.Top = 320;


            //timers
            playTimer.Enabled = true;
            Missile1Timer.Enabled = true;
            Missile2Timer.Enabled = true;
            Missile3Timer.Enabled = true;
            EnemyMovementTimer.Enabled = true;
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //This is Missile 1 timer
            Missile1.Left = enemy1.Left + 50;
            Missile1.Top = enemy1.Top;
            
            Missile1Timer.Stop();
            if (Missile1.Top == 70)
            {
                Missile1Timer.Start();
            }
        }
        private void MissileTimer1_Tick(object sender, EventArgs e)
        {
            //This is Missile 1 timer
            Missile1.Left = enemy1.Left + 50;
            Missile1.Top = enemy1.Top;
        }


        private void EnemyMovementTimer_Tick(object sender, EventArgs e)
        {
            int randVar = rnd.Next(0, 2);
            if (randVar == 0)
            {
                if (enemy3.Left > 0)
                {
                    enemyMove = -25;
                }
            }
            if (randVar == 1)
            {
                if (enemy1.Left < 295)
                {
                    enemyMove = 25;
                }
            }

            enemy1.Left += enemyMove;
            enemy2.Left += enemyMove;
            enemy3.Left += enemyMove;
        }

        private void Missile2Timer_Tick(object sender, EventArgs e)
        {

            //This is Missile 2 timer
            Missile2.Left = enemy2.Left + 50;
            Missile2.Top = enemy2.Top;
        }

        private void Missile3Timer_Tick(object sender, EventArgs e)
        {
            //This is Missile 3 timer
            Missile3.Left = enemy3.Left + 50;
            Missile3.Top = enemy3.Top;
        }
    }
}
