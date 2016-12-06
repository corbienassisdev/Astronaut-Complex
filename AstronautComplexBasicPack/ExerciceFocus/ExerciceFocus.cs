using System;
using AstronautComplex;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceFocus
{
    public partial class ExerciceFocus : Exercice
    {
        public List<Series> Series { get; set; }

        public ExerciceFocus() : base("Attention et concentration")
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            Score = new ExerciceScore();
            string startingInstruction = "Ceci est une consigne générale.";
            MessageBox.Show(startingInstruction, "Consigne générale", MessageBoxButtons.OK, MessageBoxIcon.None);
            Series = GetSeriesFromXml("series.xml");
            Console.WriteLine("test");
        }

        public override void Run()
        {
            ComponentFocus cf = new ComponentFocus(Shape.Circle, Color.Yellow, 3);
            componentFocusPanel.Controls.Add(cf);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {

                }
            }
            //For i from 1 to 3 (cause there is 3 series)
            //For j from 1 to 5 (cause there is 5 objects for 1 serie)
            //display object of serie i and at position j
            //display buttons
            //onclick buttons check answers
            //end for
            //end for
        }

        private List<Series> GetSeriesFromXml(string path)
        {
            List<Series> xmlSeries = new List<Series>();

            ComponentFocus c1 = new ComponentFocus(Shape.Circle, Color.Blue, 2);
            ComponentFocus c2 = new ComponentFocus(Shape.Square, Color.Red, 3);

            Series serie1 = new Series();

            return xmlSeries;
        }
    }
}
