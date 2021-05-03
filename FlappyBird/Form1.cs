using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class FlappyBird : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;
        public FlappyBird()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappy_bird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;


            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < - 180)
            {
                pipeTop.Left = 950;
                score++;
            }
            if (flappy_bird.Bounds.IntersectsWith(pipeBottom.Bounds)
                || flappy_bird.Bounds.IntersectsWith(pipeTop.Bounds)
                || flappy_bird.Bounds.IntersectsWith(ground.Bounds)
                || flappy_bird.Top < -25)
            {
                endGame();
            }
            if (score > 15)
            {
                pipeSpeed = 15;
            }

            
        }

        private void gamekeyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void gamekeyisUp(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }
        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game over!!!";

        }
    }
}
