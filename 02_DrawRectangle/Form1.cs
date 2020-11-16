using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02_DrawRectangle
{
    public partial class Form1 : Form
    {
        bool isDrawing = false;
        Rectangle currentRect;
        List<Rectangle> rectangles;
        public Form1()
        {
            InitializeComponent();

            rectangles = new List<Rectangle>();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            foreach (var r in rectangles)
            {
                g.DrawRectangle(Pens.Red, r);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            currentRect.Location = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;

            if (e.X > currentRect.X)
                currentRect.Width = e.X - currentRect.X;
            else
            {
                currentRect.Width = currentRect.X - e.X;
                currentRect.X = e.X;
            }

            if (e.Y > currentRect.Y)
                currentRect.Height = e.Y - currentRect.Y;
            else
            {
                currentRect.Height = currentRect.Y - e.Y;
                currentRect.Y = e.Y;
            }

            rectangles.Add(currentRect);
            this.CreateGraphics().DrawRectangle(Pens.Red, currentRect);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (isDrawing)
            //{
            //    Graphics g = this.CreateGraphics();
            //
            //    g.DrawRectangle(Pens.White, currentRect);
            //
            //    if (e.X > currentRect.X)
            //        currentRect.Width = e.X - currentRect.X;
            //    else
            //    {
            //        currentRect.Width = currentRect.X - e.X;
            //        currentRect.X = e.X;
            //    }
            //
            //    if (e.Y > currentRect.Y)
            //        currentRect.Height = e.Y - currentRect.Y;
            //    else
            //    {
            //        currentRect.Height = currentRect.Y - e.Y;
            //        currentRect.Y = e.Y;
            //    }
            //
            //    g.DrawRectangle(Pens.Red, currentRect);
            //}
        }
    }
}
