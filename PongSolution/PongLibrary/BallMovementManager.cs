using System;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows.Forms;
using static PongLibrary.Enums;

namespace PongLibrary
{
    public class BallMovementManager
    {
        PlayerModel firstPlayer;
        PlayerModel secondPlayer;
        BallModel ball;
        Form form;

        const int refreshRate = 20;

        LeftRight leftRight = new LeftRight();
        UpDown upDown = new UpDown();

        private delegate void refresh();
        refresh Refresh;

        System.Timers.Timer ballTimer = new System.Timers.Timer(refreshRate);


        public BallMovementManager(Form form,PlayerModel firstPlayer, PlayerModel secondPlayer, BallModel ball)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.ball = ball;
            this.form = form;

            Refresh = form.Refresh;
            ballTimer.Elapsed += MakeMove;
        }

        private void MakeMove(object source, ElapsedEventArgs e)
        {
            //checking for correct x of ball to contact with the first player
            if (ball.X >= (firstPlayer.X + firstPlayer.Width) && ball.X <= (firstPlayer.X + firstPlayer.Width + ball.BallSpeedSide))
            {
                //checking for correct y of ball to contact with the first player
                if ((ball.Y > firstPlayer.Y && firstPlayer.Y + firstPlayer.Heigth > ball.Y) || (ball.Y < firstPlayer.Y && firstPlayer.Y < ball.Y + ball.WidthHeight))
                {
                    leftRight = LeftRight.Right;                    
                }
            }            
            




            if (leftRight == LeftRight.Left)
                ball.X -= ball.BallSpeedSide;
            else
                ball.X += ball.BallSpeedSide;
            if (upDown == UpDown.Up)
                ball.Y -= ball.BallSpeedHeight;
            else
                ball.Y += ball.BallSpeedHeight;
            
            try
            {
                form.Invoke(Refresh);
            }
            catch { }
            
        }

        private void GenerateRandomStart()
        {
            Random random = new Random();
            int left = random.Next(0, 2);
            if (left == 0)
                leftRight = LeftRight.Left;
            else
                leftRight = LeftRight.Right;
            int up = random.Next(0, 2);
            if (up == 0)
                upDown = UpDown.Up;
            else
                upDown = UpDown.Down;            
        }

        public void Start()
        {
            //GenerateRandomStart();
            leftRight = LeftRight.Left;
            upDown = UpDown.Down;
            ballTimer.Start();
        }

    }
}
