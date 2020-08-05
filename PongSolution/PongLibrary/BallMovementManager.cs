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
        IScoreRequestor requestor;

        const int refreshRate = 20;

        LeftRight leftRight = new LeftRight();
        UpDown upDown = new UpDown();

        private delegate void refresh();
        refresh Refresh;
        refresh Scored;

        System.Timers.Timer ballTimer = new System.Timers.Timer(refreshRate);


        public BallMovementManager(IScoreRequestor form, PlayerModel firstPlayer, PlayerModel secondPlayer, BallModel ball)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.ball = ball;
            this.form = (Form)form;
            this.requestor = form;

            Refresh = this.form.Refresh;
            Scored = requestor.Scored;
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

            //check if first player missed the ball
            if(ball.X <= 0)
            {
                secondPlayer.Score += 1;
                form.Invoke(Scored);
            }

            //checking for correct x of ball to contact with the second player
            if (ball.X + ball.WidthHeight <= secondPlayer.X && ball.X + ball.WidthHeight + ball.BallSpeedSide >= secondPlayer.X)
            {
                //checking for correct y of ball to contact with the second player
                if ((ball.Y < secondPlayer.Y + secondPlayer.Heigth && ball.Y > secondPlayer.Y) || (ball.Y < secondPlayer.Y && ball.Y + ball.WidthHeight > secondPlayer.Y))
                {
                    leftRight = LeftRight.Left;
                }
            }

            //check if second player missed the ball
            if(ball.X + ball.WidthHeight >= form.ClientSize.Width)
            {
                firstPlayer.Score += 1;
                form.Invoke(Scored);
            }

            //checking if the ball hitted bottom edge
            if (ball.Y + ball.WidthHeight <= form.ClientSize.Height && ball.Y + ball.WidthHeight + ball.BallSpeedHeight >= form.ClientSize.Height)
            {
                upDown = UpDown.Up;
            }

            if (ball.Y >= 0 && ball.Y - ball.BallSpeedHeight < 0)
            {
                upDown = UpDown.Down;
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
            ball.BallSpeedHeight = random.Next(3, 8);
            ball.BallSpeedSide = random.Next(3, 8);
        }

        public void Start()
        {
            GenerateRandomStart();
            ballTimer.Start();
        }

        public void Stop()
        {
            ballTimer.Stop();
        }

    }
}
