using System;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class Polygon3DCylinder : Polygon3D
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        /// <summary>
        /// Builds the cylinder.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="height">The height.</param>
        public Polygon3DCylinder(double radius, double height) : base("Cylinder")
        {
            Radius = radius;
            Height = height;
        }

        /// <summary>
        /// Builds the cylinder with random generation.
        /// </summary>
        /// <param name="random">The random number generator.</param>
        public Polygon3DCylinder(Random random) : this(random.Next(1, 20), random.Next(1, 20))
        {

        }

        /// <summary>
        /// Computes the cylinder volume.
        /// </summary>
        public override double ComputeVolume()
        {
            return Math.PI * Math.Pow(Radius, 2.0) * Height;
        }

        /// <summary>
        /// Draws the cylinder.
        /// </summary>
        /// <param name="graphics">The graphics context in which to draw the polygon.</param>
        /// <param name="x">The x center coordinate.</param>
        /// <param name="y">The y center coordinate.</param>
        /// <param name="z">The zoom factor.</param>
        public override void Draw(Graphics graphics, int x, int y, int z = 1)
        {
            Pen pen = new Pen(Color.Navy, 1);

            int radiusScaled = (int)(Radius * z);
            int heightScaled = (int)(Height * z);
            Point ul = new Point(x - radiusScaled / 2, y - heightScaled);
            Point ur = new Point(ul.X + radiusScaled, ul.Y);
            Point bl = new Point(ul.X, ul.Y + heightScaled);
            Point br = new Point(ul.X + radiusScaled, ul.Y + heightScaled);
            graphics.DrawArc(pen, bl.X, bl.Y - radiusScaled / 8, radiusScaled, radiusScaled / 4, 0, 180);
            graphics.DrawLine(pen, bl.X, bl.Y, ul.X, ul.Y);
            graphics.DrawLine(pen, br.X, br.Y, ur.X, ur.Y);
            graphics.DrawArc(pen, ul.X, ul.Y - radiusScaled / 8, radiusScaled, radiusScaled / 4, 0, 180);
            graphics.DrawArc(pen, ul.X, ul.Y - radiusScaled / 8, radiusScaled, radiusScaled / 4, 0, -180);

            graphics.DrawString(string.Format("{0} \r\n - Radius = {1} \r\n - Height = {2}", Name, Radius, Height), SystemFonts.DefaultFont, new SolidBrush(Color.Navy), bl.X, bl.Y + 40);
        }
    }
}
