using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AstronautComplexBasicPack.ExerciceFocus
{
    public enum Shape
    {
        Square,
        Rectangle,
        Circle
    }

    public class ComponentFocus : Panel
    {
        public Shape Shape { get; set; }
        public Color Color { get; set; }
        public int DotNumber { get; set; }

        public ComponentFocus(Shape shape, Color color, int dotNumber)
        {
            this.Shape = shape;
            this.Color = color;
            this.DotNumber = dotNumber;
        }


    }
}
