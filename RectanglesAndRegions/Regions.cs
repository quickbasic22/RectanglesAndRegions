using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace RectanglesAndRegions
{
    public partial class Regions : Form
    {
        private int options = 0;
        private Rectangle containRect;
        RectangleF rectf = new RectangleF(800.0f, 200.0f, 800.0f, 800.0f);
        public Regions()
        {
            InitializeComponent();
        }

        private void Regions_Paint(object sender, PaintEventArgs e)
        {

            DrawPolygon(e.Graphics);

            e.Graphics.Clear(this.BackColor);
            if (options == 1)
            {
                PointF pt = new PointF(90.8f, 60.7f);
                SizeF sz = new SizeF(180.0f, 120.0f);
                RectangleF rect2 = new RectangleF(120.2f, 120.6f, 300.5f, 300.0f);
                RectangleF rect1 = new RectangleF(pt, sz);

                Rectangle rect3 = Rectangle.Ceiling(rect1);
                Rectangle rect4 = Rectangle.Truncate(rect1);
                Rectangle rect5 = Rectangle.Round(rect2);
                e.Graphics.DrawRectangle(Pens.Black, rect3);
                e.Graphics.DrawRectangle(Pens.Red, rect5);
                Rectangle isectRect = Rectangle.Intersect(rect3, rect5);
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), isectRect);
                Size inflateSize = new Size(0, 40);
                isectRect.Inflate(inflateSize);
                e.Graphics.DrawRectangle(Pens.Blue, isectRect);
                rect4 = Rectangle.Empty;
                rect4.Location = new Point(150, 150);
                rect4.X = 90;
                rect4.Y = 120;
                Rectangle unionRect = Rectangle.Union(rect4, rect5);
                e.Graphics.DrawRectangle(Pens.Green, unionRect);
                string str12 = @"
                  PointF pt = new PointF(90.8f, 60.7f);
                SizeF sz = new SizeF(180.0f, 120.0f);
                RectangleF rect2 = new RectangleF(120.2f, 120.6f, 300.5f, 300.0f);
                RectangleF rect1 = new RectangleF(pt, sz);

                Rectangle rect3 = Rectangle.Ceiling(rect1);
                Rectangle rect4 = Rectangle.Truncate(rect1);
                Rectangle rect5 = Rectangle.Round(rect2);
                e.Graphics.DrawRectangle(Pens.Black, rect3);
                e.Graphics.DrawRectangle(Pens.Red, rect5);
                Rectangle isectRect = Rectangle.Intersect(rect3, rect5);
                e.Graphics.FillRectangle(new SolidBrush(Color.Blue), isectRect);
                Size inflateSize = new Size(0, 40);
                isectRect.Inflate(inflateSize);
                e.Graphics.DrawRectangle(Pens.Blue, isectRect);
                rect4 = Rectangle.Empty;
                rect4.Location = new Point(150, 150);
                rect4.X = 90;
                rect4.Y = 120;
                Rectangle unionRect = Rectangle.Union(rect4, rect5);
                e.Graphics.DrawRectangle(Pens.Green, unionRect);
                 ";
                e.Graphics.DrawString(str12, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            }
            if (options == 2)
            {
                Point pt = new Point(0, 0);
                Size sz = new Size(600, 600);
                Rectangle bigRect = new Rectangle(pt, sz);
                Rectangle smallRect = new Rectangle(90, 60, 300, 300);
                //if (bigRect.Contains(smallRect) )
                ////	MessageBox.Show("Rectangle "+smallRect.ToString() 
                //	+" is inside Rectangle "+ bigRect.ToString() );
                e.Graphics.DrawRectangle(Pens.Green, bigRect);

                string str13 = @"
              Point pt = new Point(0, 0);
				Size sz = new Size(600, 600);
				Rectangle bigRect = new Rectangle(pt, sz);
				Rectangle smallRect = new Rectangle(90, 60, 300, 300);
				//if (bigRect.Contains(smallRect) )
				////	MessageBox.Show(""Rectangle ""+smallRect.ToString() 
					//	+"" is inside Rectangle ""+ bigRect.ToString() );
				e.Graphics.DrawRectangle(Pens.Green, bigRect);
             ";

                e.Graphics.DrawString(str13, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            }


        }

        private void entersectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);

            Rectangle rect1 = new Rectangle(60, 60, 120, 240);
            Rectangle rect2 = new Rectangle(150, 90, 180, 240);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Complement can take a Rectangle, RectangleF,
            // Region or a GraphicsPath as an argument
            rgn1.Intersect(rgn2);
            // rgn1.Complement(rect2);			
            g.FillRegion(Brushes.Blue, rgn1);

            string str1 = @"
              Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(150, 90, 180, 240);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Complement can take a Rectangle, RectangleF,
            // Region or a GraphicsPath as an argument
            rgn1.Intersect(rgn2);
            // rgn1.Complement(rect2);			
            g.FillRegion(Brushes.Blue, rgn1);
             ";
            g.DrawString(str1, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);

            // Dispose 
            g.Dispose();
        }

        private void roundTruncateAndOtherMethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            options = 1;
            this.Invalidate(this.ClientRectangle);

        }

        private void containsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            options = 2;
            this.Invalidate(this.ClientRectangle);
        }

        private void Regions_MouseDown(object sender, MouseEventArgs e)
        {
            var g = this.CreateGraphics();
            g.Clear(this.BackColor);

            if (e.Button == MouseButtons.Left)
            {
                Point pt = new Point(0, 0);
                Size sz = new Size(600, 600);
                Rectangle bigRect = new Rectangle(pt, sz);
                if (bigRect.Contains(new Point(e.X, e.Y)))
                    MessageBox.Show("Clicked inside rectangle");
                else
                    MessageBox.Show("Clicked outside rectangle");
                string str14 = @"
                 Point pt = new Point(0, 0);
                Size sz = new Size(600, 600);
                Rectangle bigRect = new Rectangle(pt, sz);
                if (bigRect.Contains(new Point(e.X, e.Y)))
                    MessageBox.Show(""Clicked inside rectangle"");
                else
                    MessageBox.Show(""Clicked outside rectangle"");
                 ";
                g.DrawString(str14, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);

            }
        }

        private void constructToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);

            // Create two rectangle
            Rectangle rect1 =
                new Rectangle(60, 60, 180, 240);
            RectangleF rect2 =
                new RectangleF(300, 60, 180, 300);
            // Create a Graphics path
            GraphicsPath path = new GraphicsPath();
            // Add a rectangle to graphics path
            path.AddRectangle(rect1);
            // Create a Region from rect1
            Region rectRgn1 = new Region(rect1);
            // Create a Region from rect2
            Region rectRgn2 = new Region(rect2);
            // Create a Region from GraphicsPath
            Region pathRgn = new Region(path);
            // Fill rect1 with blue color

            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.FillRegion(blueBrush, rectRgn1);

            // Fill rect2 with red color
            SolidBrush redBrush = new SolidBrush(Color.Red);
            g.FillRegion(redBrush, rectRgn2);

            // Fill the GraphicsPath with green color
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            g.FillRegion(greenBrush, pathRgn);

            string str15 = @"
             // Create two rectangle
            Rectangle rect1 =
                new Rectangle(60, 60, 120, 240);
            RectangleF rect2 =
                new RectangleF(300, 60, 180, 300);
            // Create a Graphics path
            GraphicsPath path = new GraphicsPath();
            // Add a rectangle to graphics path
            path.AddRectangle(rect1);
            // Create a Region from rect1
            Region rectRgn1 = new Region(rect1);
            // Create a Region from rect2
            Region rectRgn2 = new Region(rect2);
            // Create a Region from GraphicsPath
            Region pathRgn = new Region(path);
            // Fill rect1 with blue color

            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            g.FillRegion(blueBrush, rectRgn1);

            // Fill rect2 with red color
            SolidBrush redBrush = new SolidBrush(Color.Red);
            g.FillRegion(redBrush, rectRgn2);

            // Fill the GraphicsPath with green color
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            g.FillRegion(greenBrush, pathRgn);
             ";
            g.DrawString(str15, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);

        }

        private void complementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create two Rectangles
            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(150, 90, 180, 240);
            // Create two Regions
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Draw rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Complement can take a Rectangle, RectangleF,
            // Region or a GraphicsPath as an argument
            rgn1.Complement(rgn2);
            // rgn1.Complement(rect2);			
            g.FillRegion(Brushes.Blue, rgn1);


            string str16 = @"
               // Create two Rectangles
            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(150, 90, 180, 240);
            // Create two Regions
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Draw rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Complement can take a Rectangle, RectangleF,
            // Region or a GraphicsPath as an argument
            rgn1.Complement(rgn2);
            // rgn1.Complement(rect2);			
            g.FillRegion(Brushes.Blue, rgn1);
            // Dispose 
            g.Dispose();";
            g.DrawString(str16, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            // Dispose 
            g.Dispose();
        }

        private void emptyAndOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(60, 60, 600, 600);
            Rectangle rect2 = new Rectangle(300, 300, 600, 600);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            // Call IntersetClip
            g.IntersectClip(rgn2);
            // Fill Rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 300, 300);
            // ResetClip
            g.ResetClip();
            // Draw rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Yellow, rect2);

            string str17 = @"
             // Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(60, 60, 600, 600);
            Rectangle rect2 = new Rectangle(300, 300, 600, 600);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            // Call IntersetClip
            g.IntersectClip(rgn2);
            // Fill Rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 600, 600);
            // ResetClip
            g.ResetClip();
            // Draw rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Yellow, rect2);
            // Dispose 
            g.Dispose();";
            g.DrawString(str17, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            // Dispose 
            g.Dispose();
        }

        private void translateClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create a RectangleF
            RectangleF rect1 =
                new RectangleF(60.0f, 60.0f, 600.0f, 600.0f);
            // Create a Region
            Region rgn1 = new Region(rect1);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            float h = 60.0f;
            float w = 90.0f;
            // Call TranslateClip
            g.TranslateClip(h, w);
            // Fill rectangle
            g.FillRectangle(Brushes.Green, 60, 60, 600, 600);
            string str18 = @" // Create a RectangleF
            RectangleF rect1 =
                new RectangleF(60.0f, 60.0f, 600.0f, 600.0f);
            // Create a Region
            Region rgn1 = new Region(rect1);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            float h = 60.0f;
            float w = 90.0f;
            // Call TranslateClip
            g.TranslateClip(h, w);
            // Fill rectangle
            g.FillRectangle(Brushes.Green, 60, 60, 600, 600);";
            g.DrawString(str18, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
        }

        private void excludeClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles
            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(300, 300, 90, 120);
            // Create a Region
            Region rgn1 = new Region(rect2);
            // Exclued Clip
            g.ExcludeClip(rect1);
            g.ExcludeClip(rgn1);
            // Fill rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 600, 600);

            string str19 = @"// Create Rectangles
            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(300, 300, 90, 120);
            // Create a Region
            Region rgn1 = new Region(rect2);
            // Exclued Clip
            g.ExcludeClip(rect1);
            g.ExcludeClip(rgn1);
            // Fill rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 600, 600);
            // Dispose 
            g.Dispose();";
            g.DrawString(str19, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            // Dispose 
            g.Dispose();
        }

        private void setClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(60, 60, 600, 600);
            Rectangle rect2 = new Rectangle(300, 300, 600, 600);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            // Call IntersetClip
            g.IntersectClip(rgn2);
            // Fill Rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 600, 600);
            // ResetClip
            g.ResetClip();
            // Draw rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Yellow, rect2);

            string str20 = @"// Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(60, 60, 600, 600);
            Rectangle rect2 = new Rectangle(300, 300, 600, 600);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            // Call IntersetClip
            g.IntersectClip(rgn2);
            // Fill Rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 600, 600);
            // ResetClip
            g.ResetClip();
            // Draw rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Yellow, rect2);
            // Dispose 
            g.Dispose();";
            g.DrawString(str20, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            // Dispose 
            g.Dispose();
        }

        private void exclToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(60, 60, 400, 400);
            Rectangle rect2 = new Rectangle(300, 300, 400, 400);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            // Call IntersetClip
            g.IntersectClip(rgn2);
            // Fill Rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 300, 300);
            // ResetClip
            g.ResetClip();
            // Draw rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Yellow, rect2);

            string str21 = @"// Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(60, 60, 400, 400);
            Rectangle rect2 = new Rectangle(300, 300, 400, 400);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            // Call IntersetClip
            g.IntersectClip(rgn2);
            // Fill Rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 300, 300);
            // ResetClip
            g.ResetClip();
            // Draw rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Yellow, rect2);
            // Dispose 
            g.Dispose();";
            g.DrawString(str21, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            // Dispose 
            g.Dispose();
        }

        private void xorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles
            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(150, 90, 180, 240);
            // Create Regions
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Draw Rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Xoring two regions
            rgn1.Xor(rgn2);
            // Fill the region after Xoring
            g.FillRegion(Brushes.Blue, rgn1);
            // Dispose 


            var str = @"
                        // Create Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles
            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(150, 90, 180, 240);
            // Create Regions
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            // Draw Rectangles
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Xoring two regions
            rgn1.Xor(rgn2);
            // Fill the region after Xoring
            g.FillRegion(Brushes.Blue, rgn1);
            // Dispose   
               ";

            g.DrawString(str, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            g.Dispose();
        }

        private void unionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);

            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(150, 90, 180, 240);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Complement can take a Rectangle, RectangleF,
            // Region or a GraphicsPath as an argument
            rgn1.Union(rgn2);
            // rgn1.Complement(rect2);			
            g.FillRegion(Brushes.Blue, rgn1);


            string str24 = @" Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(150, 90, 180, 240);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Complement can take a Rectangle, RectangleF,
            // Region or a GraphicsPath as an argument
            rgn1.Union(rgn2);
            // rgn1.Complement(rect2);			
            g.FillRegion(Brushes.Blue, rgn1);

            // Dispose 
            g.Dispose();";
            g.DrawString(str24, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            // Dispose 
            g.Dispose();
        }

        private void excludeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles
            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(300, 300, 90, 120);
            // Create a Region
            Region rgn1 = new Region(rect2);
            // Exclued Clip
            g.ExcludeClip(rect1);
            g.ExcludeClip(rgn1);
            // Fill rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 600, 600);

            string str25 = @"// Create Rectangles
            Rectangle rect1 = new Rectangle(60, 60, 180, 240);
            Rectangle rect2 = new Rectangle(300, 300, 90, 120);
            // Create a Region
            Region rgn1 = new Region(rect2);
            // Exclued Clip
            g.ExcludeClip(rect1);
            g.ExcludeClip(rgn1);
            // Fill rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 600, 600);
            // Dispose 
            g.Dispose();";
            g.DrawString(str25, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            // Dispose 
            g.Dispose();
        }

        private void rectangeFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create a starting point
            PointF pt = new PointF(90.8f, 60.7f);
            // Create a size
            SizeF sz = new SizeF(180.0f, 120.0f);
            // Create a rectangle from a point and 
            // a size
            RectangleF rect1 = new RectangleF(pt, sz);
            // Create a rectangle from floating points
            RectangleF rect2 = new RectangleF(120.2f, 120.6f, 300.5f, 300.0f);

            g.FillRectangle(Brushes.Blue, rect1);
            g.FillRectangle(Brushes.Red, rect2);

            string str26 = @"// Create a starting point
            PointF pt = new PointF(90.8f, 60.7f);
            // Create a size
            SizeF sz = new SizeF(180.0f, 120.0f);
            // Create a rectangle from a point and 
            // a size
            RectangleF rect1 = new RectangleF(pt, sz);
            // Create a rectangle from floating points
            RectangleF rect2 = new RectangleF(120.2f, 120.6f, 300.5f, 300.0f);
            g.FillRectangle(Brushes.Blue, rect1);
            g.FillRectangle(Brushes.Red, rect2);";
            g.DrawString(str26, new Font("Arial", 12.0f, FontStyle.Bold), Brushes.BlueViolet, rectf);
            g.Dispose();
        }

        private void DrawPolygon(Graphics e)
        {


            // Create array of two points.
            Point[] points = { new Point(0, 0), new Point(100, 50) };

            // Draw line connecting two untransformed points.
            e.DrawLine(new Pen(Color.Blue, 3), points[0], points[1]);

            // Set world transformation of Graphics object to translate.
            e.TranslateTransform(40, 30);

            // Transform points in array from world to page coordinates.
            e.TransformPoints(CoordinateSpace.Page, CoordinateSpace.World, points);

            // Draw line that connects transformed points.
            e.DrawLine(new Pen(Color.Red, 25f), points[0], points[1]);

        }
    }
}
