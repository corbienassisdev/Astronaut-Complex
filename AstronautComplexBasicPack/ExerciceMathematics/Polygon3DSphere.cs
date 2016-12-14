using System;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class Polygon3DSphere : Polygon3D
    {
        public double Radius { get; set; }

        /// <summary>
        /// Builds the sphere.
        /// </summary>
        /// <param name="radius">The radius.</param>
        /// <param name="height">The height.</param>
        public Polygon3DSphere(double radius) : base("Sphere")
        {
            Radius = radius;
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
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3.0);
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

            int radiusScaled = (int)(Radius * z);
            Point ul = new Point(x - radiusScaled / 2, y - radiusScaled);
            Point bl = new Point(ul.X, ul.Y + radiusScaled);
            graphics.DrawEllipse(pen, ul.X, ul.Y, 2 * radiusScaled, 2 * radiusScaled);

            graphics.DrawString(string.Format("{0} \r\n - Radius = {1}", Name, Radius), SystemFonts.DefaultFont, new SolidBrush(Color.Navy), bl.X, bl.Y + 40);
        }
    }
}
