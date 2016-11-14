using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AstronautComplexBasicPack.ExercicePerception
{
    public enum Shape
    {
        Square,
        Circle
    }

    /// <summary>
    /// Is a colored shape with the letter and digit associated
    /// </summary>
    class Component
    {
        public char Letter { get; protected set; }
        public Color Color { get; protected set; }
        public Shape Shape { get; protected set; }
        public int Digit { get; protected set; }
    }
}
