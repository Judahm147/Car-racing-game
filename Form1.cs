using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_racing_game
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int gameSpeed = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gameSpeed);            
        }

        

        void moveline(int speed)
        {
            if (pictureBox1.Top >= 500)
                pictureBox1.Top = 0;
            else
                pictureBox1.Top += speed;

            if (pictureBox2.Top >= 500)
                pictureBox2.Top = 0;
            else
                pictureBox2.Top += speed;

            if (pictureBox3.Top >= 500)
                pictureBox3.Top = 0;
            else
                pictureBox3.Top += speed;

            if (pictureBox4.Top >= 500)
                pictureBox4.Top = 0;
            else
                pictureBox4.Top += speed;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && pictureBoxPlayer.Location.X >= -5 && gameSpeed > 0)
            {
                pictureBoxPlayer.Left += -4;
            }

            if (e.KeyCode == Keys.Right && pictureBoxPlayer.Location.X <= 328 && gameSpeed > 0)
            {
                pictureBoxPlayer.Left += 4;
            }

            if (e.KeyCode == Keys.Up && gameSpeed < 10)
                gameSpeed++;

            if (e.KeyCode == Keys.Down && gameSpeed > 0)
                gameSpeed--;

        }
    }
}
