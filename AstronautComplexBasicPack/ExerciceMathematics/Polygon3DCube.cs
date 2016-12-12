using System;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    /// <summary>
    /// Represents a 3D cube.
    /// </summary>
    public class Polygon3DCube : Polygon3D
    {
        public double Width { get; set; }

        /// <summary>
        /// Builds the cube.
        /// </summary>
        /// <param name="width">The width.</param>
        public Polygon3DCube(double width) : base("Cube")
        {
            Width = width;
        }

        /// <summary>
        /// Builds the cube with random generation.
        /// </summary>
        /// <param name="random">The random number generator.</param>
        public Polygon3DCube(Random random) : this(random.Next(1, 20))
        {

        }

        /// <summary>
        /// Computes the cube volume.
        /// </summary>
        public override double ComputeVolume()
        {
            return Math.Pow(Width, 3);
        }

        /// <summary>
        /// Draws the cube.
        /// </summary>
        /// <param name="graphics">The graphics context in which to draw the polygon.</param>
        /// <param name="x">The x center coordinate.</param>
        /// <param name="y">The y center coordinate.</param>
        /// <param name="z">The zoom factor.</param>
        public override void Draw(Graphics graphics, int x, int y, int z = 1)
        {
            Pen pen = new Pen(Color.Navy, 1);

            int widthScaled = (int)(Width * z);
            int projection = widthScaled / 4;
            Point ul = new Point(x - widthScaled / 2, y - widthScaled);
            Point ur = new Point(ul.X + widthScaled, ul.Y);
            Point bl = new Point(ul.X, ul.Y + widthScaled);
            Point br = new Point(ul.X + widthScaled, ul.Y + widthScaled);
            Point ulp = new Point(ul.X + projection, ul.Y - projection);
            Point urp = new Point(ur.X + projection, ur.Y - projection);
            Point brp = new Point(ul.X + widthScaled + projection, ul.Y + widthScaled - projection);
            graphics.DrawRectangle(pen, ul.X, ul.Y, widthScaled, widthScaled);
            graphics.DrawLine(pen, ul, ulp);
            graphics.DrawLine(pen, ur, urp);
            graphics.DrawLine(pen, ulp, urp);
            graphics.DrawLine(pen, br, brp);
            graphics.DrawLine(pen, brp, urp);

            graphics.DrawString(string.Format("{0} \r\n - Width = {1}", Name, Width), SystemFonts.DefaultFont, new SolidBrush(Color.Navy), bl.X, bl.Y + 40);
        }
    }
}
