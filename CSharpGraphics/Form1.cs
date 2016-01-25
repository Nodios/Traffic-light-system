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
        private int pedLightColor { get; set; }
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

            #region Street lines
            Pen pen = new Pen(Color.Black);
            //Horizontal lines
            //e.Graphics.DrawLine(pen, x1, y1, x2, y2);
            e.Graphics.DrawLine(pen, 250, 220, 524, 220);
            e.Graphics.DrawLine(pen, 724, 220, 998, 220);

            e.Graphics.DrawLine(pen, 250, 420, 524, 420);
            e.Graphics.DrawLine(pen, 724, 420, 998, 420);

            //Vertical lines
            e.Graphics.DrawLine(pen, 524, 20, 524, 220);
            e.Graphics.DrawLine(pen, 524, 420, 524, 620);

            e.Graphics.DrawLine(pen, 724, 20, 724, 220);
            e.Graphics.DrawLine(pen, 724, 420, 724, 620);

            #endregion

            #region Horizontal traffic light
            //Left
            Rectangle rect = new Rectangle(400, 430, 110, 40);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rect);
            Rectangle rect1 = new Rectangle(472, 435, 30, 30);
            Rectangle rect2 = new Rectangle(440, 435, 30, 30);
            Rectangle rect3 = new Rectangle(408, 435, 30, 30);

            //Right
            Rectangle rectR = new Rectangle(740, 170, 110, 40);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rectR);
            Rectangle rectR1 = new Rectangle(748, 175, 30, 30);
            Rectangle rectR2 = new Rectangle(780, 175, 30, 30);
            Rectangle rectR3 = new Rectangle(812, 175, 30, 30);
            #endregion

            #region Vertical traffic light
            //Top
            Rectangle rect10 = new Rectangle(475, 90, 40, 110);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rect10);
            Rectangle rect11 = new Rectangle(480, 162, 30, 30);
            Rectangle rect22 = new Rectangle(480, 130, 30, 30);
            Rectangle rect33 = new Rectangle(480, 98, 30, 30);

            //Bottom
            Rectangle rectB10 = new Rectangle(734, 440, 40, 110);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, rectB10);
            Rectangle rectB11 = new Rectangle(739, 448, 30, 30);
            Rectangle rectB22 = new Rectangle(739, 480, 30, 30);
            Rectangle rectB33 = new Rectangle(739, 512, 30, 30);
            #endregion

            #region Horizontal pedestrian light
            //Left
            Rectangle pedRect = new Rectangle(400, 480, 75, 40);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, pedRect);
            Rectangle pedRect1 = new Rectangle(440, 485, 30, 30); //red
            Rectangle pedRect2 = new Rectangle(405, 485, 30, 30); //green

            //Right
            Rectangle pedRectPR = new Rectangle(775, 120, 75, 40);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, pedRectPR);
            Rectangle pedRectPR1 = new Rectangle(780, 125, 30, 30); //red
            Rectangle pedRectPR2 = new Rectangle(815, 125, 30, 30); //green
            #endregion

            #region Vertical pedestrian light
            //Top
            Rectangle pedRect10 = new Rectangle(425, 90, 40, 75);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, pedRect10);
            Rectangle pedRect11 = new Rectangle(430, 130, 30, 30); //red
            Rectangle pedRect22 = new Rectangle(430, 95, 30, 30); //green
            //Bottom
            Rectangle pedRectPB10 = new Rectangle(784, 475, 40, 75);
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, pedRectPB10);
            Rectangle pedRectPB11 = new Rectangle(789, 480, 30, 30); //red
            Rectangle pedRectPB22 = new Rectangle(789, 515, 30, 30); //green
            #endregion

            switch (lightColor)
            {
                case 1: 
                    #region Red - Horizontal
                    //Left
                    e.Graphics.FillEllipse(Brushes.Red, rect1);
                    e.Graphics.FillEllipse(Brushes.Black, rect2);
                    e.Graphics.FillEllipse(Brushes.Black, rect3);
                    //Right
                    e.Graphics.FillEllipse(Brushes.Red, rectR1);
                    e.Graphics.FillEllipse(Brushes.Black, rectR2);
                    e.Graphics.FillEllipse(Brushes.Black, rectR3);
                    #endregion

                    #region Green - Vertical
                    //Top
                    e.Graphics.FillEllipse(Brushes.Black, rect11);
                    e.Graphics.FillEllipse(Brushes.Black, rect22);
                    e.Graphics.FillEllipse(Brushes.Lime, rect33);

                    //Bottom
                    e.Graphics.FillEllipse(Brushes.Black, rectB11);
                    e.Graphics.FillEllipse(Brushes.Black, rectB22);
                    e.Graphics.FillEllipse(Brushes.Lime, rectB33);
                    #endregion

                    #region Pedestrian red - Horizontal
                    //Left
                    e.Graphics.FillEllipse(Brushes.Red, pedRect1);
                    e.Graphics.FillEllipse(Brushes.Black, pedRect2);
                    //Right
                    e.Graphics.FillEllipse(Brushes.Red, pedRectPR1);
                    e.Graphics.FillEllipse(Brushes.Black, pedRectPR2);
                    #endregion

                    #region Pedestrian green - vertical
                    //Top
                    e.Graphics.FillEllipse(Brushes.Black, pedRect11);
                    e.Graphics.FillEllipse(Brushes.Lime, pedRect22);
                    //Bottom
                    e.Graphics.FillEllipse(Brushes.Black, pedRectPB11);
                    e.Graphics.FillEllipse(Brushes.Lime, pedRectPB22);
                    #endregion

                    break;
                case 2:
                    #region Yellow - Horizontal
                    if (previousState == 1)
                    {
                        //Left
                        e.Graphics.FillEllipse(Brushes.Red, rect1);
                        //Right
                        e.Graphics.FillEllipse(Brushes.Red, rectR1);
                    }
                    else
                    {
                        //Left
                        e.Graphics.FillEllipse(Brushes.Black, rect1);
                        //Right
                        e.Graphics.FillEllipse(Brushes.Black, rectR1);
                    }
                    //Left
                    e.Graphics.FillEllipse(Brushes.Yellow, rect2);
                    e.Graphics.FillEllipse(Brushes.Black, rect3);
                    //Right
                    e.Graphics.FillEllipse(Brushes.Yellow, rectR2);
                    e.Graphics.FillEllipse(Brushes.Black, rectR3);
                    #endregion

                    #region Yellow - Vertical
                    if (previousState == 3)
                    {
                        //Top
                        e.Graphics.FillEllipse(Brushes.Red, rect11);
                        //Bottom
                        e.Graphics.FillEllipse(Brushes.Red, rectB11);
                    }
                    else
                    {
                        //Top
                        e.Graphics.FillEllipse(Brushes.Black, rect11);
                        //Bottom
                        e.Graphics.FillEllipse(Brushes.Black, rectB11);
                    }
                    //Top
                    e.Graphics.FillEllipse(Brushes.Yellow, rect22);
                    e.Graphics.FillEllipse(Brushes.Black, rect33);
                    //Bottom
                    e.Graphics.FillEllipse(Brushes.Yellow, rectB22);
                    e.Graphics.FillEllipse(Brushes.Black, rectB33);
                    #endregion

                    #region Pedestrian red/yellow - Horizontal
                    //Left
                    e.Graphics.FillEllipse(Brushes.Red, pedRect1);
                    e.Graphics.FillEllipse(Brushes.Black, pedRect2);
                    //Right
                    e.Graphics.FillEllipse(Brushes.Red, pedRectPR1);
                    e.Graphics.FillEllipse(Brushes.Black, pedRectPR2);
                    #endregion

                    #region Pedestrian red/yellow - vertical
                    //Top
                    e.Graphics.FillEllipse(Brushes.Red, pedRect11);
                    e.Graphics.FillEllipse(Brushes.Black, pedRect22);
                    //Bottom
                    e.Graphics.FillEllipse(Brushes.Red, pedRectPB11);
                    e.Graphics.FillEllipse(Brushes.Black, pedRectPB22);
                    #endregion

                    break;
                case 3:
                    #region Green - Horizontal
                    //Left
                    e.Graphics.FillEllipse(Brushes.Black, rect1);
                    e.Graphics.FillEllipse(Brushes.Black, rect2);
                    e.Graphics.FillEllipse(Brushes.Lime, rect3);
                    //Right
                    e.Graphics.FillEllipse(Brushes.Black, rectR1);
                    e.Graphics.FillEllipse(Brushes.Black, rectR2);
                    e.Graphics.FillEllipse(Brushes.Lime, rectR3);
                    #endregion

                    #region Red - Vertical
                    //Top
                    e.Graphics.FillEllipse(Brushes.Red, rect11);
                    e.Graphics.FillEllipse(Brushes.Black, rect22);
                    e.Graphics.FillEllipse(Brushes.Black, rect33);
                    //Bottom
                    e.Graphics.FillEllipse(Brushes.Red, rectB11);
                    e.Graphics.FillEllipse(Brushes.Black, rectB22);
                    e.Graphics.FillEllipse(Brushes.Black, rectB33);
                    #endregion

                    #region Pedestrian green - Horizontal
                    //Left
                    e.Graphics.FillEllipse(Brushes.Black, pedRect1);
                    e.Graphics.FillEllipse(Brushes.Lime, pedRect2);
                    //Right
                    e.Graphics.FillEllipse(Brushes.Black, pedRectPR1);
                    e.Graphics.FillEllipse(Brushes.Lime, pedRectPR2);
                    #endregion

                    #region Pedestrian red - vertical
                    //Top
                    e.Graphics.FillEllipse(Brushes.Red, pedRect11);
                    e.Graphics.FillEllipse(Brushes.Black, pedRect22);
                    //Bottom
                    e.Graphics.FillEllipse(Brushes.Red, pedRectPB11);
                    e.Graphics.FillEllipse(Brushes.Black, pedRectPB22);
                    #endregion

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
