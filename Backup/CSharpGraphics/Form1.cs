using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpGraphics
{
    public partial class Form1 : Form
    {
          

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
         
            //e.Graphics.FillRectangle(Brushes.White, this.ClientRectangle);
            
            Rectangle rect = new Rectangle(150, 20, 95, 200);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rect);
            Rectangle rect1 = new Rectangle(165, 30, 60, 60);
            Rectangle rect2 = new Rectangle(165, 90, 60, 60);
            Rectangle rect3 = new Rectangle(165, 150, 60, 60);
            switch (lightColor)
            {
                case 1:
                    e.Graphics.FillEllipse(Brushes.Red, rect1);
                    e.Graphics.FillEllipse(Brushes.Black, rect2);
                    e.Graphics.FillEllipse(Brushes.Black, rect3);
                    break;
                case 2:
                    e.Graphics.FillEllipse(Brushes.Black, rect1);
                    e.Graphics.FillEllipse(Brushes.Yellow, rect2);
                    e.Graphics.FillEllipse(Brushes.Black, rect3);
                    break;
                case 3:
                    e.Graphics.FillEllipse(Brushes.Black, rect1);
                    e.Graphics.FillEllipse(Brushes.Black, rect2);
                    e.Graphics.FillEllipse(Brushes.Lime, rect3);
                    break;
            }

            }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRed.Clear();
            txtYellow.Clear();
            txtGreen.Clear();
            txtRed.Focus();
            txtRed.SelectAll();

        }

        private void txtRed_TextChanged(object sender, EventArgs e)
        {
            txtRed.SelectAll();
           
        }

        private void btnLights_Click(object sender, EventArgs e)
        {
            lightColor++;
            if (lightColor == 4)
                lightColor = 1;
            this.Invalidate();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;

        }

        

    }
}
