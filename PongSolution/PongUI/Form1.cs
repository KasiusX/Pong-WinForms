using PongLibrary;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PongUI
{
    public partial class MainForm : Form
    {
        //player properties
        const int playerWidth = 20;
        const int playerHeight = 100;        
        const int firstPlayerStartingX = 60;
        const int secondPlayerStartingX = 900;
        const int firstPlayerY = 325;
        const int secondPlayerY = 325;
        const int playerSpeed = 10;

        //ball properties
        const int WidthHeight = 20;
        const int ballSpeedSide = 3;
        const int ballSpeedHeight = 1;

        //line properties
        const int lineWidth = 4;
        const int lineHeight = 20;
        const int spaceBetweenLines = 5;
        
        PlayerModel firstPlayer = new PlayerModel { Score = 0, X = firstPlayerStartingX, Y = firstPlayerY, Heigth = playerHeight, Width = playerWidth, MovingSpeed = playerSpeed };
        PlayerModel secondPlayer = new PlayerModel { Score = 0, X = secondPlayerStartingX, Y = secondPlayerY, Heigth = playerHeight, Width = playerWidth, MovingSpeed = playerSpeed };

        BallModel ball;

        PlayersMovingManager movementManager;
        BallMovementManager ballManager;
        public MainForm()
        {
            InitializeComponent();
            ball = new BallModel { BallSpeedSide = ballSpeedSide,BallSpeedHeight=ballSpeedHeight, WidthHeight = WidthHeight, X = ClientSize.Width / 2 - WidthHeight / 2, Y = ClientSize.Height / 2 - WidthHeight / 2 };

            movementManager = new PlayersMovingManager(this,firstPlayer ,secondPlayer );
            ballManager = new BallMovementManager(this, firstPlayer, secondPlayer, ball);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //Nakreslí prostřední čáru
            Graphics g = e.Graphics;
            for (int i = 0; i < 30; i++)
            {
                g.FillRectangle(Brushes.Black, ClientSize.Width /2 - lineWidth /2, i * (lineHeight + spaceBetweenLines), lineWidth, lineHeight);
            }

            //Nakreslý každého hráče
            g.FillRectangle(Brushes.Black, firstPlayerStartingX, firstPlayer.Y, firstPlayer.Width, firstPlayer.Heigth);
            g.FillRectangle(Brushes.Black, secondPlayerStartingX, secondPlayer.Y, secondPlayer.Width, secondPlayer.Heigth);

            //Nakreslý míček
            g.FillRectangle(Brushes.Black,ball.X , ball.Y, WidthHeight, WidthHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            this.Refresh();
            movementManager.Start();
            ballManager.Start();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            movementManager.Stop();
        }
    }
}
