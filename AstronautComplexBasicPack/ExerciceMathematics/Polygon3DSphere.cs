using System;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class Polygon3DSphere : Polygon3D
    {
        public double Diameter { get; set; }

        /// <summary>
        /// Builds the sphere.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="height">The height.</param>
        public Polygon3DSphere(double radius) : base("Sphere")
        {
            Diameter = radius;
        }

        /// <summary>
        /// Builds the sphere with random generation.
        /// </summary>
        /// <param name="random">The random number generator.</param>
        public Polygon3DSphere(Random random) : this(random.Next(1, 20))
        {

        }

        /// <summary>
        /// Computes the sphere volume.
        /// </summary>
        public override double ComputeVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Diameter / 2, 3.0);
        }

        /// <summary>
        /// Draws the sphere.
        /// </summary>
        /// <param name="graphics">The graphics context in which to draw the polygon.</param>
        /// <param name="x">The x center coordinate.</param>
        /// <param name="y">The y center coordinate.</param>
        /// <param name="z">The zoom factor.</param>
        public override void Draw(Graphics graphics, int x, int y, int z = 1)
        {
            Pen pen = new Pen(Color.Navy, 1);

            int radiusScaled = (int)(Diameter * z) / 2;
            Point ul = new Point(x - radiusScaled / 2, y - 2 * radiusScaled);
            Point bl = new Point(ul.X, ul.Y + 2 * radiusScaled);
            graphics.DrawEllipse(pen, ul.X, ul.Y, 2 * radiusScaled, 2 * radiusScaled);

            graphics.DrawString(string.Format("{0} \r\n - Radius = {1}", Name, Diameter / 2), SystemFonts.DefaultFont, new SolidBrush(Color.Navy), bl.X, bl.Y + 40);
        }
    }
}
