using PongLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PongUI
{
    public partial class MainForm : Form
    {
        const int playerWidth = 20;
        const int playerHeight = 100;        
        const int firstPlayerStartingX = 60;
        const int secondPlayerStartingX = 900;
        const int firstPlayerY = 325;
        const int secondPlayerY = 325;
        const int playerSpeed = 10;

        PlayerModel firstPlayer = new PlayerModel { Score = 0, X = firstPlayerStartingX, Y = firstPlayerY, Heigth = playerHeight, Width = playerWidth, MovingSpeed = playerSpeed };
        PlayerModel secondPlayer = new PlayerModel { Score = 0, X = secondPlayerStartingX, Y = secondPlayerY, Heigth = playerHeight, Width = playerWidth, MovingSpeed = playerSpeed };

        PlayersMovingManager manager;
        public MainForm()
        {
            InitializeComponent();
            manager = new PlayersMovingManager(this,firstPlayer ,secondPlayer );            
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //Nakreslí prostřední čáru
            Graphics g = e.Graphics;
            for (int i = 0; i < 30; i++)
            {
                g.FillRectangle(Brushes.Black, 498, i *25, 4, 20);
            }

            //Nakreslý každého hráče
            g.FillRectangle(Brushes.Black, firstPlayerStartingX, firstPlayer.Y, firstPlayer.Width, firstPlayer.Heigth);
            g.FillRectangle(Brushes.Black, secondPlayerStartingX, secondPlayer.Y, secondPlayer.Width, secondPlayer.Heigth);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            this.Refresh();
            manager.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            manager.Stop();
        }
    }
}
