using PongLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongUI
{
    public partial class MainForm : Form, IPlayerMovementRequestor
    {
        const int playerWidth = 20;
        const int playerHeight = 100;        
        const int firstPlayerStartingX = 60;
        const int secondPlayerStartingX = 900;

        private int firstPlayerY = 325;
        private int secondPlayerY = 325;


        PlayersMovingManager manager;
        public MainForm()
        {
            InitializeComponent();
            manager = new PlayersMovingManager(this, new PlayerModel { Score = 0, X = firstPlayerStartingX, Y = firstPlayerY, Heigth = playerHeight, Width = playerWidth }, new PlayerModel { Score = 0, X = secondPlayerStartingX, Y = secondPlayerY, Heigth = playerHeight, Width = playerWidth });
        }

        public void FirstPlayerDown()
        {
            firstPlayerY += 8;
            this.Refresh();
        }

        public void FirstPlayerUp()
        {
            firstPlayerY -= 8;
            this.Refresh();
        }

        public void SecondPlayerDown()
        {
            secondPlayerY += 8;
            this.Refresh();
        }

        public void SecondPlayerUp()
        {
            secondPlayerY -= 8;
            this.Refresh();
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
            g.FillRectangle(Brushes.Black, firstPlayerStartingX, firstPlayerY, playerWidth, playerHeight);
            g.FillRectangle(Brushes.Black, secondPlayerStartingX, secondPlayerY, playerWidth, playerHeight);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            manager.Start();
        }
    }
}
