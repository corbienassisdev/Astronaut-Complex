using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

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
        public char Letter { get; set; }
        public Shape Shape { get; protected set; }
        public Color Color { get; protected set; }
        public int Digit { get; protected set; }

        #region Statics attributes
        public static int shapeLength = 100;
        public static int minDigit = 0;
        public static int maxDigit = 9;
        private static Random r = new Random();
        #endregion

        public static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(r.Next(v.Length));
        } // Generic in case of a color enum
        
        public Component() {}

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


        /// <summary>
        /// Creates and returns a new random component with shape and color given.
        /// </summary>
        /// <param name="color">will be the color of the returned component</param>
        /// <param name="shape">will be the shape of the returned component</param>
        /// <returns>Returns a new component WITHOUT random letter and digit but with the shape and color in parameters</returns>
        public static Component RandomComponentWithoutBoth(Shape referenceShape, Color referenceColor)
        {
            Component c = new Component();
            //changing shape and color of component if it has both of the excluded characteristics
            do
            {
                c.Color = (r.Next(0, 2) == 0) ? Color.RoyalBlue : Color.Yellow; //transform to Enum ?;
                c.Shape = RandomEnumValue<Shape>();
            } while (c.Shape == referenceShape && c.Color == referenceColor);
            c.Digit = r.Next(minDigit, maxDigit = 1);

            c.Dock = DockStyle.Fill;

            return c;
        }

        /// <summary>
        /// Creates and returns a new random component with shape and color given.
        /// </summary>
        /// <param name="color">will be the color of the returned component</param>
        /// <param name="shape">will be the shape of the returned component</param>
        /// <returns>Returns a new component WITH random letter and digit but with the shape and color in parameters</returns>
        public static Component RandomComponentWith(Shape referenceShape, Color referenceColor)
        {
            Component c = new Component();
            c.Shape = referenceShape;
            c.Color = referenceColor;
            c.Digit = r.Next(minDigit, maxDigit + 1);

            c.Dock = DockStyle.Fill;

            return c;
        }

        
        protected override void OnPaint(PaintEventArgs pe)
        {
            #region Intializing local variables
            SolidBrush brush = new SolidBrush(this.Color);
            Graphics graphics = this.CreateGraphics();
            Pen pen = new Pen(Color.Black); //for shape outlines
            Font font = new Font("Arial", 20);
            StringFormat format = new StringFormat();
            Point center = new Point(Width / 2, Height / 2); //center of the panel
            Rectangle rectangle = new Rectangle(center.X - (shapeLength / 2), center.Y - (shapeLength / 2), shapeLength, shapeLength); //for shapes
            #endregion

            #region Setting Properties
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            #endregion

            //shape with color
            switch (this.Shape)
            {
                case Shape.Circle:
                    graphics.FillEllipse(brush, rectangle);
                    graphics.DrawEllipse(pen, rectangle);
                    break;
                case Shape.Square:
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(pen, rectangle);
                    break;
            }

            //lettre
            brush.Color = Color.Black;
            int letterWidth = TextRenderer.MeasureText(this.Letter.ToString(), font).Width;
            graphics.DrawString(this.Letter.ToString(), font, brush, center.X - (letterWidth / 2 - 3), center.Y - (shapeLength / 2 + 20 + 15), format); //15 is the margin between the letter and the shape
            //digit
            int digitWidth = TextRenderer.MeasureText(this.Digit.ToString(), font).Width;
            graphics.DrawString(this.Digit.ToString(), font, brush, center.X - (digitWidth / 2 - 3), center.Y - 20 + 4, format);
            //concrete values here correspond to margins or offsets in order to get the perfect center. They adapt to constant values like the font size, etc.


            brush.Dispose();
            graphics.Dispose();
        }
    }
}
