using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

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
    public class Component : Panel
    {
        public char Letter { get; protected set; }
        public Color Color { get; protected set; }
        public Shape Shape { get; protected set; }
        public int Digit { get; protected set; }

        /// <summary>
        /// Builds a component with a lettern color, shape and digit given.
        /// </summary>
        /// <param name="letter">The letter of the component. Will always start with A and decrease until the last component.</param>
        /// <param name="color">The color of the component.</param>
        /// <param name="shape">The shape of the component (square or circle).</param>
        /// <param name="digit">The digit displayed on the shape [0~9].</param>
        public Component(char letter, Color color, Shape shape, int digit)
        {
            Letter = letter;
            Color = color;
            Shape = shape;
            Digit = digit;

            this.Dock = DockStyle.Fill;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            SolidBrush myBrush = new SolidBrush(this.Color);
            Graphics formGraphics = this.CreateGraphics();
            switch (this.Shape)
            {
                case Shape.Circle:
                    formGraphics.FillEllipse(myBrush, new Rectangle(Width / 2 - 50, Height / 2 - 50, 100, 100)); //Mettre des constantes
                    break;
                case Shape.Square:
                    formGraphics.FillRectangle(myBrush, new Rectangle(Width / 2 - 50, Height / 2 - 50, 100, 100)); //Mettre des constantes
                    break;
            }
            myBrush.Dispose();
            formGraphics.Dispose();
        }
    }
}
