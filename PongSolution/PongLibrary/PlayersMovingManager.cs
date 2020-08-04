using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Input;

namespace PongLibrary
{
    public class PlayersMovingManager
    {
        PlayerModel firstPlayer;
        PlayerModel secondPlayer;
        Form form; 
        
        private delegate bool delIsKeyDown(Key key);
        private delegate void delMakeMove();

        delIsKeyDown DelIsKeyDown;
        delMakeMove DelFirstPlayerUp;
        delMakeMove DelFirstPlayerDown;
        delMakeMove DelSecondPlayerUp;
        delMakeMove DelSecondPlayerDown;

        System.Timers.Timer playerOneTimer = new System.Timers.Timer(20);
        System.Timers.Timer playerTwoTimer = new System.Timers.Timer(20);

        public PlayersMovingManager(IPlayerMovementRequestor requestor, PlayerModel firstPlayer, PlayerModel secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.form = (Form)requestor;

            DelIsKeyDown = new delIsKeyDown(Keyboard.IsKeyDown);

            DelFirstPlayerUp = new delMakeMove(requestor.FirstPlayerUp);
            DelFirstPlayerDown = new delMakeMove(requestor.FirstPlayerDown);
            playerOneTimer.Elapsed += CheckKeysPlayerOne;

            DelSecondPlayerUp = new delMakeMove(requestor.SecondPlayerUp);
            DelSecondPlayerDown = new delMakeMove(requestor.SecondPlayerDown);
            playerTwoTimer.Elapsed += CheckKeysPlayerTwo;
        }

        //(bool)form.Invoke(DelIsKeyDown, Key.W)
        public void CheckKeysPlayerOne(Object source, ElapsedEventArgs e)
        {
            try
            {
                if ((bool)form.Invoke(DelIsKeyDown, Key.W) && firstPlayer.Y > 0)
                {

                    form.Invoke(DelFirstPlayerUp);
                    firstPlayer.Y -= 8;
                }
                else if ((bool)form.Invoke(DelIsKeyDown, Key.S) && firstPlayer.Y < 610)
                {
                    form.Invoke(DelFirstPlayerDown);
                    firstPlayer.Y += 8;
                }
            }
            catch { }
            
        }

        public void CheckKeysPlayerTwo(Object source, ElapsedEventArgs e)
        {
            try
            {
                if ((bool)form.Invoke(DelIsKeyDown, Key.Up) && secondPlayer.Y > 0)
                {
                    form.Invoke(DelSecondPlayerUp);
                    secondPlayer.Y -= 8;
                }
                else if ((bool)form.Invoke(DelIsKeyDown, Key.Down) && secondPlayer.Y < 610)
                {
                    form.Invoke(DelSecondPlayerDown);
                    secondPlayer.Y += 8;
                }
            }
            catch { }
        }

        public void Start()
        {
            playerOneTimer.Start();
            playerTwoTimer.Start();
        }

        public void Stop()
        {
            playerOneTimer.Stop();
            playerTwoTimer.Stop();
        }

    }
}
