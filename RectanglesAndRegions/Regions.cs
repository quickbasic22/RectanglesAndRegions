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
        public Regions()
        {
            InitializeComponent();
        }

        private void Regions_Paint(object sender, PaintEventArgs e)
        {
            if (options == 1)
            {
                PointF pt = new PointF(30.8f, 20.7f);
                SizeF sz = new SizeF(60.0f, 40.0f);
                RectangleF rect2 = new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);
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
                rect4.Location = new Point(50, 50);
                rect4.X = 30;
                rect4.Y = 40;
                Rectangle unionRect = Rectangle.Union(rect4, rect5);
                e.Graphics.DrawRectangle(Pens.Green, unionRect);
            }
            if (options == 2)
            {
                Point pt = new Point(0, 0);
                Size sz = new Size(200, 200);
                Rectangle bigRect = new Rectangle(pt, sz);
                Rectangle smallRect = new Rectangle(30, 20, 100, 100);
                //if (bigRect.Contains(smallRect) )
                ////	MessageBox.Show("Rectangle "+smallRect.ToString() 
                //	+" is inside Rectangle "+ bigRect.ToString() );
                e.Graphics.DrawRectangle(Pens.Green, bigRect);
            }
            e.Graphics.SetClip(new Rectangle(0, 0, 50, 50));
            textBox1.Text = e.Graphics.ClipBounds.ToString();
            textBox2.Text = e.Graphics.VisibleClipBounds.ToString();
        }

        private void entersectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);

            Rectangle rect1 = new Rectangle(20, 20, 60, 80);
            Rectangle rect2 = new Rectangle(50, 30, 60, 80);
            Region rgn1 = new Region(rect1);
            Region rgn2 = new Region(rect2);
            g.DrawRectangle(Pens.Green, rect1);
            g.DrawRectangle(Pens.Black, rect2);
            // Complement can take a Rectangle, RectangleF,
            // Region or a GraphicsPath as an argument
            rgn1.Intersect(rgn2);
            // rgn1.Complement(rect2);			
            g.FillRegion(Brushes.Blue, rgn1);

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
            if (e.Button == MouseButtons.Left)
            {
                Point pt = new Point(0, 0);
                Size sz = new Size(200, 200);
                Rectangle bigRect = new Rectangle(pt, sz);
                if (bigRect.Contains(new Point(e.X, e.Y)))
                    MessageBox.Show("Clicked inside rectangle");
                else
                    MessageBox.Show("Clicked outside rectangle");
            }
        }

        private void constructToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            // Create two rectangle
            Rectangle rect1 =
                new Rectangle(20, 20, 60, 80);
            RectangleF rect2 =
                new RectangleF(100, 20, 60, 100);
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

        }

        private void complementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics
            Graphics g = this.CreateGraphics();
            // Create two Rectangles
            Rectangle rect1 = new Rectangle(20, 20, 60, 80);
            Rectangle rect2 = new Rectangle(50, 30, 60, 80);
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
            g.Dispose();
        }

        private void emptyAndOthersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(20, 20, 200, 200);
            Rectangle rect2 = new Rectangle(100, 100, 200, 200);
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
            g.Dispose();

        }

        private void translateClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create a RectangleF
            RectangleF rect1 =
                new RectangleF(20.0f, 20.0f, 200.0f, 200.0f);
            // Create a Region
            Region rgn1 = new Region(rect1);
            // Call SetClip
            g.SetClip(rgn1, CombineMode.Exclude);
            float h = 20.0f;
            float w = 30.0f;
            // Call TranslateClip
            g.TranslateClip(h, w);
            // Fill rectangle
            g.FillRectangle(Brushes.Green, 20, 20, 300, 300);
        }

        private void excludeClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles
            Rectangle rect1 = new Rectangle(20, 20, 60, 80);
            Rectangle rect2 = new Rectangle(100, 100, 30, 40);
            // Create a Region
            Region rgn1 = new Region(rect2);
            // Exclued Clip
            g.ExcludeClip(rect1);
            g.ExcludeClip(rgn1);
            // Fill rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 200, 200);
            // Dispose 
            g.Dispose();
        }

        private void setClipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(20, 20, 200, 200);
            Rectangle rect2 = new Rectangle(100, 100, 200, 200);
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
            g.Dispose();
        }

        private void exclToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create the Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles and Regions
            Rectangle rect1 = new Rectangle(20, 20, 200, 200);
            Rectangle rect2 = new Rectangle(100, 100, 200, 200);
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
            g.Dispose();
        }

        private void xorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles
            Rectangle rect1 = new Rectangle(20, 20, 60, 80);
            Rectangle rect2 = new Rectangle(50, 30, 60, 80);
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
            g.Dispose();
        }

        private void unionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);

            Rectangle rect1 = new Rectangle(20, 20, 60, 80);
            Rectangle rect2 = new Rectangle(50, 30, 60, 80);
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
            g.Dispose();
        }

        private void excludeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics object
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            // Create Rectangles
            Rectangle rect1 = new Rectangle(20, 20, 60, 80);
            Rectangle rect2 = new Rectangle(100, 100, 30, 40);
            // Create a Region
            Region rgn1 = new Region(rect2);
            // Exclued Clip
            g.ExcludeClip(rect1);
            g.ExcludeClip(rgn1);
            // Fill rectangle
            g.FillRectangle(Brushes.Red, 0, 0, 200, 200);
            // Dispose 
            g.Dispose();
        }
    }
}
