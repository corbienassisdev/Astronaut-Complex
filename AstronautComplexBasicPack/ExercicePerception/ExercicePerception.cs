using AstronautComplex;
using System.Collections.Generic;
using System.Drawing;

namespace AstronautComplexBasicPack.ExercicePerception
{
    /// <summary>
    /// Represents an astronaut perception test.
    /// </summary>
    public partial class ExercicePerception : AstronautTest
    {
        public List<Mask> Masks { get; protected set; }
        public int CurrentMask { get; protected set; }

        /// <summary>
        /// Builds an astronaut perception test.
        /// </summary>
        public ExercicePerception() : base("Perception et mémoire associative")
        {
            InitializeComponent();
            Masks = new List<Mask>();
            CurrentMask = 0;
        }

        /// <summary>
        /// Builds an astronaut perception test.
        /// </summary>
        public void LoadMasks()
        {
            Component c1 = new Component('A', Color.Yellow, Shape.Circle, 3);
            Component c2 = new Component('B', Color.Blue, Shape.Square, 8);

            List<Component> components = new List<Component>();
            components.Add(c1);
            components.Add(c2);

            Mask mask1 = new Mask(components);
            // TODO: create a random generator according to the specifications, or an xml file
        }

        /// <summary>
        /// Displays the current mask with its components in the form.
        /// </summary>
        public void ShowMask()
        {
            Mask mask = Masks[CurrentMask];
            //foreach elements graphiques de type case de grid layout,
            //Dessiner le component correspondant à l'intérieur
        }

        /// <summary>
        /// Called on control loading.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AstronautTestPerception_Load(object sender, System.EventArgs e)
        {
            //TODO : show the mask 1
            Graphics surface = this.CreateGraphics();
            Pen p = new Pen(System.Drawing.Color.Turquoise, 5);
            Rectangle rectangle = new Rectangle(100, 100, 100, 100);
            surface.DrawRectangle(p, rectangle);
            SolidBrush myBrush = new SolidBrush(Color.Pink);
            surface.FillRectangle(myBrush, rectangle);
            this.Invalidate();
        }

    }
}
