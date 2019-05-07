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
        private Bitmap enemyImage;
        private bool car_gone = true;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gameSpeed);
            if (random.Next(1, 100) == 5 && car_gone)
                generateYellowEnemy();
            switch (gameSpeed)
            {
                case 0:
                    enemyCar.Top -= 3;
                    break;
                case 1:
                case 2:
                    enemyCar.Top -= 2;
                    break;
                case 4:
                case 3:
                    enemyCar.Top -= 1;
                    break;            
                case 5:
                case 6:
                    enemyCar.Top += 1;
                    break;
                case 7:
                case 8:
                    enemyCar.Top += 2;
                    break;
                case 9:
                case 10:
                    enemyCar.Top += 3;
                    break;
                default:
                    break;
            }
            if (enemyCar.Location.Y > 429)
            {                
                enemyCar.Visible = false;
                car_gone = true;
            }
        }       
        
        public void generateYellowEnemy()
        {
            // Sets up an image object to be displayed.
            if (enemyImage != null)
            {
                enemyImage.Dispose();
            }

            // Stretches the image to fit the pictureBox.
            enemyCar.SizeMode = PictureBoxSizeMode.StretchImage;
            enemyImage = new Bitmap("C:\\Users\\Home\\source\\repos\\Car racing game\\Car racing game\\Images\\yellowOpponentCar.png");
            enemyCar.ClientSize = new Size(59, 102);
            enemyCar.SetBounds(32, -82, 59, 102);
            enemyCar.Image = (Image)enemyImage;
            enemyCar.Visible = true;
            car_gone = false;
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
