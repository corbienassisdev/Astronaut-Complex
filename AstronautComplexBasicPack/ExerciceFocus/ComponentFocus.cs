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
    /// Is a colored shape with the letter and digit associated
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

            this.Dock = DockStyle.Fill;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            this.shapeWidth = this.Width / 2;
            this.shapeHeight = shapeWidth;

            SolidBrush brush = new SolidBrush(Color.Red);
            Graphics graphics = this.CreateGraphics();
            Rectangle rectangle = new Rectangle((this.Width - shapeWidth) / 2, (this.Height - shapeHeight) / 2, shapeHeight, shapeWidth);
            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(Pens.Black, rectangle);
            DrawDots(graphics, brush);

            brush.Dispose();
            graphics.Dispose();
        }

        private void DrawDots(Graphics graphics, SolidBrush brush)
        {
            brush.Color = Color.Black;
            int xCenter = this.Width / 2;
            int yCenter = this.Height / 2;

            int x;
            int y;

            DotNumber = 3;

            switch (DotNumber)
            {
                case 1:
                    x = xCenter;
                    y = yCenter;
                    graphics.FillEllipse(brush, new Rectangle(x, y, 10, 10));
                    break;
                case 2:
                    x = xCenter - (shapeWidth / 4);
                    y = yCenter;
                    graphics.FillEllipse(brush, new Rectangle(x, y, 10, 10));
                    x = xCenter + (shapeWidth / 4);
                    y = yCenter;
                    graphics.FillEllipse(brush, new Rectangle(x, y, 10, 10));
                    break;
                case 3:
                    x = xCenter;
                    y = yCenter - (shapeHeight / 4);
                    graphics.FillEllipse(brush, new Rectangle(x, y, 10, 10));
                    x = xCenter - (shapeWidth / 4);
                    y = yCenter + (shapeHeight / 4);
                    graphics.FillEllipse(brush, new Rectangle(x, y, 10, 10));
                    x = xCenter + (shapeWidth / 4);
                    y = yCenter + (shapeHeight / 4);
                    graphics.FillEllipse(brush, new Rectangle(x, y, 10, 10));
                    break;
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            this.Refresh();
        }

    }
}
