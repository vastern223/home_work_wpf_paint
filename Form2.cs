using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawRectangle
{
    public partial class Form2 : Form
    {
        List<RectangleInfo> rectangles = new List<RectangleInfo>();
        List<EllipsInfo> ellips = new List<EllipsInfo>();
        List<Point> points = new List<Point>();
        List<LineInfo> line = new List<LineInfo>();
        RectangleInfo currentRect;
        EllipsInfo ellipsRect;
        LineInfo lineRect;
        Graphics graphics;      
        bool isDrawing = false;
        public int Thickness { get; set; }
        Brush ellip_cl = Brushes.Black;
        Brush rectangl_cl = Brushes.Black;
        Brush point_cl = Brushes.Black;
        Brush line_cl = Brushes.Black;
        public Color cl_line;
        bool dottedLine = false;
        public Form2()
        {
            InitializeComponent();

            graphics = this.CreateGraphics();

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (toolStripMenuItem19.Checked)
            {
                currentRect = new RectangleInfo(rectangl_cl, e.Location);
            }
            else if (toolStripMenuItem20.Checked)
            {
                ellipsRect = new EllipsInfo(ellip_cl, e.Location);
            }
            else if (toolStripMenuItem22.Checked)
            {
                lineRect = new LineInfo(line_cl, e.Location, dottedLine, Thickness, cl_line);
            }
            isDrawing = true;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
            if (toolStripMenuItem19.Checked)
            {
                currentRect.SetSize(e.Location);
                currentRect.Print(graphics);
                rectangles.Add(currentRect);
            }
            else if (toolStripMenuItem20.Checked)
            {
                ellipsRect.SetSize(e.Location);
                ellipsRect.Print(graphics);
                ellips.Add(ellipsRect);
            }
            else if (toolStripMenuItem22.Checked)
            {
                lineRect.SetSize(e.Location);
                lineRect.Print(graphics);
                line.Add(lineRect);
            }
            }

        private void PrintRectangles(Graphics graphics)
        {
            foreach (var r in rectangles)
            {
                r.Print(graphics);
            }
        }
        private void Printellips(Graphics graphics)
        {
            foreach (var r in ellips)
            {
                r.Print(graphics);
            }
        }

        private void Printline(Graphics graphics)
        {
            foreach (var r in line)
            {
                r.Print(graphics);
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            PrintRectangles(e.Graphics);
            Printellips(e.Graphics);
            PrintFigures(e.Graphics);
            Printline(e.Graphics);
        }
        private void PrintFigures(Graphics g)
        {
            foreach (Point p in points)
                g.FillEllipse(Brushes.Black, p.X - 5, p.Y - 5, 10F, 10F);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                if ( toolStripMenuItem19.Checked)
                {

                    currentRect.Clear(graphics);
                    currentRect.SetSize(e.Location);
                    currentRect.Print(graphics);
                }
                else if (toolStripMenuItem20.Checked)
                {
                    ellipsRect.Clear(graphics);
                    ellipsRect.SetSize(e.Location);
                    ellipsRect.Print(graphics);
                }
               
            }
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
          
            if (toolStripMenuItem21.Checked)
            {
                Point point = e.Location;
                points.Add(point);
                this.CreateGraphics().FillEllipse(point_cl, point.X - 5, point.Y - 5, 10F, 10F);
            }
        }

        private void toolStripMenuItem19_Click(object sender, System.EventArgs e)
        {
            toolStripMenuItem19.Checked = true;
            toolStripMenuItem20.Checked = false;
            toolStripMenuItem21.Checked = false;
            toolStripMenuItem22.Checked = false;
        }

        private void toolStripMenuItem20_Click(object sender, System.EventArgs e)
        {
            toolStripMenuItem19.Checked = false;
            toolStripMenuItem20.Checked = true;
            toolStripMenuItem21.Checked = false;
            toolStripMenuItem22.Checked = false;
        }

        private void toolStripMenuItem21_Click(object sender, System.EventArgs e)
        {
            toolStripMenuItem19.Checked = false;
            toolStripMenuItem20.Checked = false;
            toolStripMenuItem21.Checked = true;
            toolStripMenuItem22.Checked = false;
        }

        private void toolStripMenuItem22_Click(object sender, System.EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                ellip_cl = new SolidBrush(color.Color);
                rectangl_cl = new SolidBrush(color.Color);
                point_cl = new SolidBrush(color.Color);
                line_cl = new SolidBrush(color.Color);
                cl_line = color.Color;
            }
        }

        private void toolStripMenuItem1_Click(object sender, System.EventArgs e)
        {      
            toolStripMenuItem19.Checked = false;
            toolStripMenuItem20.Checked = false;
            toolStripMenuItem21.Checked = false;
            toolStripMenuItem22.Checked = true;
        }

        private void toolStripMenuItem4_Click(object sender, System.EventArgs e)
        {
            dottedLine = true;
        }

        private void toolStripMenuItem5_Click(object sender, System.EventArgs e)
        {
            dottedLine = false;
        }

        private void toolStripComboBox1_TextChanged(object sender, System.EventArgs e)
        {
            Thickness = int.Parse(toolStripComboBox1.Text);
        }
    }
}
