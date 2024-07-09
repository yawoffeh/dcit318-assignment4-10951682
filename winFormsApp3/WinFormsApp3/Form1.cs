using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        private bool isDrawing;
        private Point previousPoint;
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;

        public Form1()
        {
            InitializeComponent();
            InitializeCanvas();
        }

        private void InitializeCanvas()
        {
            drawingBitmap = new Bitmap(panel1.Width, panel1.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White);
            panel1.BackgroundImage = drawingBitmap;
            panel1.BackgroundImageLayout = ImageLayout.None;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = true;
                previousPoint = e.Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                Point currentPoint = e.Location;
                Pen pen = new Pen(Color.Black, 2);
                drawingGraphics.DrawLine(pen, previousPoint, currentPoint);
                previousPoint = currentPoint;
                panel1.Invalidate();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDrawing = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(drawingBitmap, Point.Empty);
        }
    }
}
