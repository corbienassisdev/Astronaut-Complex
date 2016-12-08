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

    /// <summary>
    /// Is a colored shape with some dots inside.
    /// </summary>
    public class ComponentFocus : Panel
    {
        public Shape Shape { get; set; }
        public Color Color { get; set; }
        public int DotNumber { get; set; }

        private int shapeWidth;
        private int shapeHeight;

        public ComponentFocus(Shape shape, Color color, int dotNumber)
        {
            this.Shape = shape;
            this.Color = color;
            this.DotNumber = dotNumber;

            Dock = DockStyle.Fill;
        }

        public ComponentFocus() {}

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Shape == Shape.Circle || Shape == Shape.Square)
            {
                shapeWidth = shapeHeight = (int)(this.Width / 2.5);
            }
            else //Rectangle
            {
                shapeHeight = (int)(this.Height / 2.5);
                shapeWidth = (int)(shapeHeight * 1.8);
            }

            SolidBrush brush = new SolidBrush(this.Color);
            Graphics graphics = this.CreateGraphics();

            DrawShape(graphics, brush);
            DrawDots(graphics, brush);

            brush.Dispose();
            graphics.Dispose();
        }

        private void DrawShape(Graphics graphics, SolidBrush brush)
        {
            Rectangle rectangle = new Rectangle((this.Width - shapeWidth) / 2, (this.Height - shapeHeight) / 2, shapeWidth, shapeHeight);

            switch (Shape)
            {
                case Shape.Circle:
                    graphics.FillEllipse(brush, rectangle);
                    graphics.DrawEllipse(Pens.Black, rectangle);
                    break;
                case Shape.Square:
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(Pens.Black, rectangle);
                    break;
                case Shape.Rectangle:
                    graphics.FillRectangle(brush, rectangle);
                    graphics.DrawRectangle(Pens.Black, rectangle);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void DrawDots(Graphics graphics, SolidBrush brush)
        {
            brush.Color = Color.Black;

            int dotSize = shapeHeight / 20;

            int xCenter = this.Width / 2;
            int yCenter = this.Height / 2;

            int x = 0;
            int y = 0;

            /*for (int i = 0; i < DotNumber; i++)
            {
                double teta = ((2 * Math.PI) / DotNumber) * (i + 0.0);
                x = (int)Math.Sin(teta) * shapeWidth / 2 + xCenter;
                y = (int)Math.Cos(teta) * shapeHeight / 2 + yCenter;
                
            }

            x = x - dotSize / 2; y = y - dotSize / 2;
            graphics.FillEllipse(brush, new Rectangle(x, y, dotSize, dotSize));*/

            switch (DotNumber)
            {
                case 1:
                    x = xCenter;
                    y = yCenter;
                    x = x - dotSize / 2; y = y - dotSize / 2;
                    graphics.FillEllipse(brush, new Rectangle(x, y, dotSize, dotSize));
                    break;
                case 2:
                    x = xCenter - (shapeWidth / 4);
                    y = yCenter;
                    x = x - dotSize / 2; y = y - dotSize / 2;
                    graphics.FillEllipse(brush, new Rectangle(x, y, dotSize, dotSize));
                    x = xCenter + (shapeWidth / 4);
                    y = yCenter;
                    x = x - dotSize / 2; y = y - dotSize / 2;
                    graphics.FillEllipse(brush, new Rectangle(x, y, dotSize, dotSize));
                    break;
                case 3:
                    x = xCenter;
                    y = yCenter - (int)((shapeHeight / 4) / Math.Sqrt(2));
                    x = x - dotSize / 2; y = y - dotSize / 2;
                    graphics.FillEllipse(brush, new Rectangle(x, y, dotSize, dotSize));
                    x = xCenter - (int)((shapeWidth / 4) / Math.Sqrt(2));
                    y = yCenter + (int)((shapeHeight / 4) / Math.Sqrt(2));
                    x = x - dotSize / 2; y = y - dotSize / 2;
                    graphics.FillEllipse(brush, new Rectangle(x, y, dotSize, dotSize));
                    x = xCenter + (int)((shapeWidth / 4) / Math.Sqrt(2));
                    y = yCenter + (int)((shapeHeight / 4) / Math.Sqrt(2));
                    x = x - dotSize / 2; y = y - dotSize / 2;
                    graphics.FillEllipse(brush, new Rectangle(x, y, dotSize, dotSize));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            this.Refresh();
        }
    }
}
