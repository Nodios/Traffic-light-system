using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Semafori;

namespace CSharpGraphics
{
    public partial class Form1 : Form
    {
        #region Properties
        private int timeRed=1, timeYellow=1, timeGreen=1;
        private int lightColor { get; set; }

        /// <summary>
        /// Used to obtain previous state of traffic light for correct changes between R-Y-G to G-Y-R
        /// 1: Red light
        /// 2: Yellow light
        /// 3: Green light
        /// </summary>
        private int previousState { get; set; }
        #endregion

        #region Initialize
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //e.Graphics.FillRectangle(Brushes.White, this.ClientRectangle);

            //Left traffic light
            Rectangle rect = new Rectangle(150, 20, 95, 200);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rect);
            Rectangle rect1 = new Rectangle(165, 30, 60, 60);
            Rectangle rect2 = new Rectangle(165, 90, 60, 60);
            Rectangle rect3 = new Rectangle(165, 150, 60, 60);

            //Right traffic light
            Rectangle rect10 = new Rectangle(350, 20, 95, 200);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rect10);
            Rectangle rect11 = new Rectangle(365, 30, 60, 60);
            Rectangle rect22 = new Rectangle(365, 90, 60, 60);
            Rectangle rect33 = new Rectangle(365, 150, 60, 60);

            switch (lightColor)
            {
                case 1:
                    //Red
                    e.Graphics.FillEllipse(Brushes.Red, rect1);
                    e.Graphics.FillEllipse(Brushes.Black, rect2);
                    e.Graphics.FillEllipse(Brushes.Black, rect3);

                    //Second light - Green
                    e.Graphics.FillEllipse(Brushes.Black, rect11);
                    e.Graphics.FillEllipse(Brushes.Black, rect22);
                    e.Graphics.FillEllipse(Brushes.Lime, rect33);
                    break;
                case 2:
                    //Yellow
                    e.Graphics.FillEllipse(Brushes.Black, rect1);
                    e.Graphics.FillEllipse(Brushes.Yellow, rect2);
                    e.Graphics.FillEllipse(Brushes.Black, rect3);

                    //Second light - Yellow
                    e.Graphics.FillEllipse(Brushes.Black, rect11);
                    e.Graphics.FillEllipse(Brushes.Yellow, rect22);
                    e.Graphics.FillEllipse(Brushes.Black, rect33);
                    break;
                case 3:
                    //Green
                    e.Graphics.FillEllipse(Brushes.Black, rect1);
                    e.Graphics.FillEllipse(Brushes.Black, rect2);
                    e.Graphics.FillEllipse(Brushes.Lime, rect3);

                    //Second light - Red
                    e.Graphics.FillEllipse(Brushes.Red, rect11);
                    e.Graphics.FillEllipse(Brushes.Black, rect22);
                    e.Graphics.FillEllipse(Brushes.Black, rect33);
                    break;
            }

        }

        //Exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Stop button
        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
        }

        //Start button
        private void btnStart_Click(object sender, EventArgs e)
        {
            #region initial form paint
            lightColor = 1;
            this.Invalidate();
            #endregion

            timeRed = (int)numericUpDown1.Value;
            timeYellow = (int)numericUpDown2.Value;
            timeGreen = (int)numericUpDown3.Value;

            //1000ms timer interval
            timer1.Interval = 1000; 
            timer2.Interval = 1000;
            timer3.Interval = 1000;

            //Start timer
            timer1.Start();

            //output remaining time to label
            timeLabel.Text = timeRed.ToString();


            #region working on click
            //lightColor++;
            //if (lightColor == 4)
            //    lightColor = 1;
            //this.Invalidate();
            #endregion
        }

        #region If form load do this
        private void Form1_Load(object sender, EventArgs e)
        {


        }
        #endregion

        #region Timer helpers
        //Red light time
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        //Yellow light time
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        //Green light time
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Time output
        //Used to output time between light changes
        private void timeLabel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Timers
        #region Red light
        //Red light timer_Tick
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            previousState = 1;
            timeRed--;
            if (timeRed == 0)
            {
                timer1.Stop();
                timer2.Start();
                timeYellow = (int)numericUpDown2.Value;
                lightColor = 2;
            }
            #region timeRed helper
            if (timeLabel.Text == "-1")
            {
                timeLabel.Text = "0";
            }
            #endregion
            timeLabel.Text = timeRed.ToString();
            this.Invalidate();
        }
        #endregion
        #region Yellow light
        //Yellow light timer_Tick
        private void timer2_Tick(object sender, EventArgs e)
        {
            timeYellow--;
            if (timeYellow == 0)
            {
                if(previousState == 1) //if previous light was red, next should be green
                {
                    lightColor = 3;
                    timeGreen = (int)numericUpDown3.Value;
                    timer2.Stop();
                    timer3.Start(); //Green timer start              
                }
                else if (previousState == 3) //if previous light was green, next should be red
                {
                    lightColor = 1;
                    timeRed = (int)numericUpDown1.Value;
                    timer2.Stop();
                    timer1.Start(); //Red timer start
                }
            }
            #region timeRed helper
            if (timeLabel.Text == "-1")
            {
                timeLabel.Text = "0";
            }
            #endregion
            timeLabel.Text = timeYellow.ToString();
            this.Invalidate();
        }
        #endregion
        #region Green light
        //Green light timer_Tick
        private void timer3_Tick(object sender, EventArgs e)
        {
            previousState = 3;
            timeGreen--;
            if (timeGreen == 0)
            {
                timer3.Stop();
                timer2.Start();
                timeYellow = (int)numericUpDown2.Value;
                lightColor = 2;
            }

            #region timeRed helper
            if (timeLabel.Text == "-1")
            {
                timeLabel.Text = "0";
            }
            #endregion
            timeLabel.Text = timeGreen.ToString();
            this.Invalidate();
        }
        #endregion
        #endregion



    }
}
