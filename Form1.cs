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
        private Bitmap yellowEnemyImage;
        private Bitmap whiteEnemyImage;
        private bool yellow_car_gone = true;
        private bool white_car_gone = true;

        public Form1()
        {
            InitializeComponent();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveline(gameSpeed);
            if (random.Next(1, 100) == 5 && yellow_car_gone)
                generateYellowEnemy();
            if (random.Next(1, 500) == 5 && white_car_gone)
                generateWhiteEnemy();
            switch (gameSpeed)
            {
                case 0:
                    yellowEnemyCar.Top -= 3;
                    whiteEnemyCar.Top -= 4;
                    break;
                case 1:
                case 2:
                    yellowEnemyCar.Top -= 2;
                    whiteEnemyCar.Top -= 3;
                    break;
                case 4:
                case 3:
                    yellowEnemyCar.Top -= 1;
                    whiteEnemyCar.Top -= 2;
                    break;            
                case 5:
                case 6:
                    yellowEnemyCar.Top += 1;
                    whiteEnemyCar.Top -= 1;
                    break;
                case 7:
                case 8:
                    yellowEnemyCar.Top += 2;
                    whiteEnemyCar.Top += 1;
                    break;
                case 9:
                case 10:
                    yellowEnemyCar.Top += 3;
                    whiteEnemyCar.Top += 2;
                    break;
                default:
                    break;
            }
            if (yellowEnemyCar.Location.Y > 429)
            {                
                yellowEnemyCar.Visible = false;
                yellow_car_gone = true;
            }
            if (whiteEnemyCar.Location.Y > 429)
            {
                whiteEnemyCar.Visible = false;
                white_car_gone = true;
            }
        }

        private void generateWhiteEnemy()
        {
            if (whiteEnemyImage != null)
            {
                whiteEnemyImage.Dispose();
            }

            // Stretches the image to fit the pictureBox.
            whiteEnemyCar.SizeMode = PictureBoxSizeMode.StretchImage;
            whiteEnemyImage = new Bitmap("C:\\Users\\Home\\source\\repos\\Car racing game\\Car racing game\\Images\\whiteOpponentCar.png");
            whiteEnemyCar.ClientSize = new Size(59, 102);
            int randomOpponentPosition_X = random.Next(30, 295);
            whiteEnemyCar.SetBounds(randomOpponentPosition_X, -82, 59, 102);
            whiteEnemyCar.Image = (Image)whiteEnemyImage;
            whiteEnemyCar.Visible = true;
            white_car_gone = false;
        }

        public void generateYellowEnemy()
        {
            // Sets up an image object to be displayed.
            if (yellowEnemyImage != null)
            {
                yellowEnemyImage.Dispose();
            }

            // Stretches the image to fit the pictureBox.
            yellowEnemyCar.SizeMode = PictureBoxSizeMode.StretchImage;
            yellowEnemyImage = new Bitmap("C:\\Users\\Home\\source\\repos\\Car racing game\\Car racing game\\Images\\yellowOpponentCar.png");
            yellowEnemyCar.ClientSize = new Size(59, 102);
            int randomOpponentPosition_X = random.Next(30, 295);
            yellowEnemyCar.SetBounds(randomOpponentPosition_X, -82, 59, 102);
            yellowEnemyCar.Image = (Image)yellowEnemyImage;
            yellowEnemyCar.Visible = true;
            yellow_car_gone = false;
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
