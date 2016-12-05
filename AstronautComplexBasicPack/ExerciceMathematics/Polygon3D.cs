using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    /// <summary>
    /// Represents a 3D polygon.
    /// </summary>
    public abstract class Polygon3D
    {
        public string Name { get; protected set; }

        /// <summary>
        /// Builds the polygon.
        /// </summary>
        /// <param name="name">The name. Optional.</param>
        public Polygon3D(string name = "")
        {
            Name = name;
        }

        /// <summary>
        /// Gets the polygon name.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }

        /// <summary>
        /// Computes the polygon volume. Needs to be implemented.
        /// </summary>
        public abstract decimal ComputeVolume();

        /// <summary>
        /// Draws the polygon.
        /// </summary>
        /// <param name="name">The graphics context in which to draw the polygon.</param>
        /// <param name="x">The x center coordinate.</param>
        /// <param name="y">The y center coordinate.</param>
        /// <param name="z">The zoom factor.</param>
        public abstract void Draw(Graphics graphics, int x, int y, int z = 1);
    }
}
