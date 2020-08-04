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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            //Nakreslí prostřední čáru
            Graphics g = e.Graphics;
            for (int i = 0; i < 30; i++)
            {
                g.FillRectangle(Brushes.White, 498, i *25, 4, 20);
            }

            //Nakreslý každého hráče
            g.FillRectangle(Brushes.White, 60, 325, 20, 100);
            g.FillRectangle(Brushes.White, 900, 325, 20, 100);


        }
    }
}
