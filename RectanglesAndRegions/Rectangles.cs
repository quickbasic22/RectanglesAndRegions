namespace RectanglesAndRegions
{
    public partial class Rectangles : Form
    {
        public Rectangles()
        {
            InitializeComponent();
        }

        private void createRectanglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics object
            Graphics g = this.CreateGraphics();
            int x = 20;
            int y = 30;
            int height = 30;
            int width = 30;
            // Create a Point
            Point pt = new Point(10, 10);
            // Create a Size
            Size sz = new Size(60, 40);
            // Create a Rectangle from point
            // and size
            Rectangle rect1 = new Rectangle(pt, sz);
            Rectangle rect2 =
                new Rectangle(x, y, width, height);
            g.DrawRectangles(Pens.DarkBlue, new Rectangle[] {rect1, rect2 });
        }

        private void createRectangleFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics object
            Graphics g = this.CreateGraphics();
            // Create a Point
            PointF pt = new PointF(30.8f, 20.7f);
            // Create a Size
            SizeF sz = new SizeF(60.0f, 40.0f);
            // Create a Rectangle from a Point and 
            // a Size
            RectangleF rect1 = new RectangleF(pt, sz);
            // Create a Rectangle from floating points
            RectangleF rect2 =
                new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);
            g.DrawRectangles(Pens.DarkMagenta, new RectangleF[] { rect1, rect2 });
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Point
            PointF pt = new PointF(30.8f, 20.7f);
            // Create a Size
            SizeF sz = new SizeF(60.0f, 40.0f);
            // Create a Rectangle from a Point and 
            // a Size
            RectangleF rect1 = new RectangleF(pt, sz);
            // Create a Rectangle from floating points
            RectangleF rect2 =
              new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);
            // If rectangle is empty
            // Set its Location, Widht, and Height
            // Properties
            if (rect1.IsEmpty)
            {
                rect1.Location = pt;
                rect1.Width = sz.Width;
                rect1.Height = sz.Height;
            }
            // Read properties and display
            string str =
              "Location:" + rect1.Location.ToString();
            str += "X:" + rect1.X.ToString() + "\n";
            str += "Y:" + rect1.Y.ToString() + "\n";
            str += "Left:" + rect1.Left.ToString() + "\n";
            str += "Right:" + rect1.Right.ToString() + "\n";
            str += "Top:" + rect1.Top.ToString() + "\n";
            str += "Bottom:" + rect1.Bottom.ToString();
            MessageBox.Show(str);
        }

        private void methodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a Graphics object
            Graphics g = this.CreateGraphics();
            // Create a Point & Size
            PointF pt = new PointF(30.8f, 20.7f);
            SizeF sz = new SizeF(60.0f, 40.0f);
            // Create two rectangles
            RectangleF rect1 = new RectangleF(pt, sz);
            RectangleF rect2 =
              new RectangleF(40.2f, 40.6f, 100.5f, 100.0f);
            // Ceiling a rectangle
            Rectangle rect3 = Rectangle.Ceiling(rect1);
            // Truncate a rectangle
            Rectangle rect4 = Rectangle.Truncate(rect1);
            // Round a rectangle
            Rectangle rect5 = Rectangle.Round(rect2);
            // Draw rectangles
            g.DrawRectangle(Pens.Black, rect3);
            g.DrawRectangle(Pens.Red, rect5);
            // Intersect a rectangle
            Rectangle isectRect =
              Rectangle.Intersect(rect3, rect5);
            // Fill rectangle
            g.FillRectangle(
              new SolidBrush(Color.Blue), isectRect);
            // Inflate a recntangle
            Size inflateSize = new Size(0, 40);
            isectRect.Inflate(inflateSize);
            // Draw rectangle
            g.DrawRectangle(Pens.Blue, isectRect);
            // Empty rectangle and set its properties
            rect4 = Rectangle.Empty;
            rect4.Location = new Point(50, 50);
            rect4.X = 30;
            rect4.Y = 40;
            // Union rectangles
            Rectangle unionRect =
              Rectangle.Union(rect4, rect5);
            // Draw rectangle
            g.DrawRectangle(Pens.Green, unionRect);
            // Displose 
            g.Dispose();
        }
    }
}