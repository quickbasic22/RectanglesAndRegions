using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RectanglesAndRegions
{
    public partial class GridPratice : Form
    {
        public GridPratice()
        {
            InitializeComponent();
        }

        private void GridPratice_Paint(object sender, PaintEventArgs e)
        {
            // Create array of two points.
            Point[] points = { new Point(0, 0), new Point(100, 50) };

            e.Graphics.DrawString(points[0].ToString(), this.Font, Brushes.Blue, 400, 200);
            e.Graphics.DrawString(points[1].ToString(), this.Font, Brushes.Blue, 400, 250);

            // Draw line connecting two untransformed points.
            e.Graphics.DrawLine(new Pen(Color.Blue, 3), points[0], points[1]);

            e.Graphics.ResetTransform();

            Debug.WriteLine($"Device coordinates: {e.Graphics.VisibleClipBounds}");
            Matrix matrix = e.Graphics.Transform;
            Debug.WriteLine($"World coordinates:");
            Debug.WriteLine($"  {matrix.Elements[0]}, {matrix.Elements[1]}, {matrix.Elements[2]}");
            Debug.WriteLine($"  {matrix.Elements[3]}, {matrix.Elements[4]}, {matrix.Elements[5]}");
            Debug.WriteLine($"  {0}, {0}, {1}");
            Debug.WriteLine($"Page coordinates: {e.Graphics.PageUnit}, {e.Graphics.PageScale}");


            // Set world transformation of Graphics object to translate.
            e.Graphics.TranslateTransform(40, 30);
            e.Graphics.PageUnit = GraphicsUnit.Document;
            

            // Transform points in array from world to page coordinates.
            e.Graphics.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, points);

            e.Graphics.DrawString(points[0].ToString(), this.Font, Brushes.Blue, 400, 400);
            e.Graphics.DrawString(points[1].ToString(), this.Font, Brushes.Blue, 400, 450);

            Debug.WriteLine($"Device coordinates: {e.Graphics.VisibleClipBounds}");
            Matrix matrix2 = e.Graphics.Transform;
            Debug.WriteLine($"World coordinates:");
            Debug.WriteLine($"  {matrix2.Elements[0]}, {matrix2.Elements[1]}, {matrix2.Elements[2]}");
            Debug.WriteLine($"  {matrix2.Elements[3]}, {matrix2.Elements[4]}, {matrix2.Elements[5]}");
            Debug.WriteLine($"  {0}, {0}, {1}");
            Debug.WriteLine($"Page coordinates: {e.Graphics.PageUnit}, {e.Graphics.PageScale}");


            // Reset world transformation.
            e.Graphics.ResetTransform();

            // Draw line that connects transformed points.
            e.Graphics.DrawLine(new Pen(Color.Red, 3), points[0], points[1]);

            //e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;

            //e.Graphics.DrawString(e.ClipRectangle.ToString(), this.Font, Brushes.DarkBlue, 300f, 300f);

            //Pen bluePen = new Pen(Brushes.Blue, 12f);
            //Point halfWay = new Point(this.Width / 2, this.Height / 2);
            //e.Graphics.DrawLine(bluePen, new Point(0, 0), halfWay);
        }

        private void GridPratice_MouseMove(object sender, MouseEventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //g.Clear(this.BackColor);
            //Font blueFont = new Font("Arial", 20f);

            //if (e.X > 1390)
            //    g.DrawString(e.Location.ToString(), blueFont, Brushes.Magenta, new PointF(e.X - 200, e.Y - 100));
            //else
            //    g.DrawString(e.Location.ToString(), blueFont, Brushes.Magenta, new PointF(e.X + 30, e.Y - 100));


        }
    }
}
