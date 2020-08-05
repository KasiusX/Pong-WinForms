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
        //Players models with informations about them
        PlayerModel firstPlayer;
        PlayerModel secondPlayer;
        Form form;
        const int refreshRate = 10;
        
        //Delegates, on to call players movement and Keyboard.IsKeyDown
        private delegate bool delIsKeyDown(Key key);
        private delegate void refresh();

        //Instances of delegates to make them public
        delIsKeyDown DelIsKeyDown;        
        refresh Refresh;

        //Timer for each player
        System.Timers.Timer playerOneTimer = new System.Timers.Timer(refreshRate);
        System.Timers.Timer playerTwoTimer = new System.Timers.Timer(refreshRate);
                
        public PlayersMovingManager(Form form, PlayerModel firstPlayer, PlayerModel secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.form = form;

            DelIsKeyDown = new delIsKeyDown(Keyboard.IsKeyDown);
            Refresh = form.Refresh;
            
            playerOneTimer.Elapsed += CheckKeysPlayerOne;
            playerTwoTimer.Elapsed += CheckKeysPlayerTwo;
        }

        /// <summary>
        /// Check if any key for player one is pressed and if yes call the Method on thread which form lives on
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void CheckKeysPlayerOne(Object source, ElapsedEventArgs e)
        {
            try
            {
                if ((bool)form.Invoke(DelIsKeyDown, Key.W) && firstPlayer.Y > 0)
                {

                    form.Invoke(Refresh);
                    firstPlayer.Y -= firstPlayer.MovingSpeed;
                }
                else if ((bool)form.Invoke(DelIsKeyDown, Key.S) && firstPlayer.Y < 610)
                {
                    form.Invoke(Refresh);
                    firstPlayer.Y += firstPlayer.MovingSpeed;
                }
            }
            catch { }
            
        }

        /// <summary>
        /// Check if any key for player two is pressed and if yes call the Method on thread which form lives on
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void CheckKeysPlayerTwo(Object source, ElapsedEventArgs e)
        {
            try
            {
                if ((bool)form.Invoke(DelIsKeyDown, Key.Up) && secondPlayer.Y > 0)
                {
                    form.Invoke(Refresh);
                    secondPlayer.Y -= secondPlayer.MovingSpeed;
                }
                else if ((bool)form.Invoke(DelIsKeyDown, Key.Down) && secondPlayer.Y < 610)
                {
                    form.Invoke(Refresh);
                    secondPlayer.Y += secondPlayer.MovingSpeed;
                }
            }
            catch { }
        }

        /// <summary>
        /// Start both timers for players
        /// </summary>
        public void Start()
        {
            playerOneTimer.Start();
            playerTwoTimer.Start();
        }

        /// <summary>
        /// Stop both timers for players
        /// </summary>
        public void Stop()
        {
            playerOneTimer.Stop();
            playerTwoTimer.Stop();
        }

    }
}
