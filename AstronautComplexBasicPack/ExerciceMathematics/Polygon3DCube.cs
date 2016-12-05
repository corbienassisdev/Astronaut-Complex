using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    /// <summary>
    /// Represents a 3D cube.
    /// </summary>
    public class Polygon3DCube : Polygon3D
    {
        public decimal Width { get; set; }

        /// <summary>
        /// Builds the cube.
        /// </summary>
        /// <param name="name">The width.</param>
        public Polygon3DCube(decimal width) : base("Cube")
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
        public override decimal ComputeVolume()
        {
            return (decimal)Math.Pow((double)Width, 3);
        }

        /// <summary>
        /// Draws the polygon.
        /// </summary>
        /// <param name="graphics">The graphics context in which to draw the polygon.</param>
        /// <param name="x">The x center coordinate.</param>
        /// <param name="y">The y center coordinate.</param>
        /// <param name="z">The zoom factor.</param>
        public override void Draw(Graphics graphics, int x, int y, int z = 1)
        {
            Pen pen = new Pen(Color.Navy, 1);
            int widthScaled = (int)(Width * z);
            graphics.DrawRectangle(pen, x - widthScaled / 2, y - widthScaled, widthScaled, widthScaled);
        }
    }
}
