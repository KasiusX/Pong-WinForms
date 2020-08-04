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
        IPlayerMovementRequestor requestor;
        Form form; 
        
        private delegate bool delIsKeyDown(Key key);
        private delegate void delMakeMove();

        delIsKeyDown DelIsKeyDown;
        delMakeMove DelFirstPlayerUp;
        delMakeMove DelFirstPlayerDown;

        System.Timers.Timer playerOneTimer = new System.Timers.Timer(20);

        public PlayersMovingManager(IPlayerMovementRequestor requestor, PlayerModel firstPlayer, PlayerModel secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
            this.requestor = requestor;
            this.form = (Form)requestor;

            delIsKeyDown DelIsKeyDown = new delIsKeyDown(Keyboard.IsKeyDown);
            delMakeMove DelFirstPlayerUp = new delMakeMove(requestor.FirstPlayerUp);
            delMakeMove DelFirstPlayerDown = new delMakeMove(requestor.FirstPlayerDown);
            //playerOneTimer.Elapsed += CheckKeysPlayerOne;            
            

        }
        //(bool)form.Invoke(DelIsKeyDown, Key.W)
        public void CheckKeysPlayerOne()
        {
            //bool test = (bool)form.Invoke(DelIsKeyDown, Key.W);
            if ((bool)form.Invoke(DelIsKeyDown, Key.W))
            {
                MessageBox.Show("Test");
                //form.Invoke(DelFirstPlayerUp);

            }
            else if((bool)form.Invoke(DelIsKeyDown, Key.S))
            {
                form.Invoke(DelFirstPlayerDown);
            }
        }

        private void FirstPlayerTimer(Object source, ElapsedEventArgs e)
        {
            
        }

        public void Start()
        {
            //playerOneTimer.Start();
            CheckKeysPlayerOne();
        }
    }
}
