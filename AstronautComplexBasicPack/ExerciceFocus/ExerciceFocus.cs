using System;
using AstronautComplex;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Xml;

namespace AstronautComplexBasicPack.ExerciceFocus
{
    public partial class ExerciceFocus : Exercice
    {
        public List<SingleSeries> Series { get; set; }
        public int CurrentSeries { get; set; }
        public int CurrentComponent { get; set; }
        public int PreviousComponent { get; set; }

        public ExerciceFocus() : base("Attention et concentration")
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            Form.MinimumSize = new Size(420, 300);

            Score = new ExerciceScore();
            
            string startingInstruction = "Ceci est une consigne générale.";
            MessageBox.Show(startingInstruction, "Consigne générale", MessageBoxButtons.OK, MessageBoxIcon.None);

            Series = GetSeriesFromXml("series.xml");

            CurrentSeries = 0;
            CurrentComponent = 0;
        }

        public override void Run()
        {
            DisplayCurrentComponent();
            //For i from 1 to 3 (cause there is 3 series)
            //For j from 1 to 5 (cause there is 5 objects for 1 serie)
            //display object of serie i and at position j
            //display buttons
            //onclick buttons check answers
            //end for
            //end for
        }

        private void DisplayCurrentComponent()
        {
            componentFocusPanel.Controls.Clear();

            if (CurrentComponent == 0)
            {
                buttonSameColor.Visible = false;
                buttonSameDotNumber.Visible = false;
            }
            else
            {
                buttonSameColor.Visible = true;
                buttonSameDotNumber.Visible = true;
            }
            
            componentFocusPanel.Controls.Add(Series[CurrentSeries].Components[CurrentComponent]);

            componentFocusPanel.Refresh();
        }

        //TODO :
        private List<SingleSeries> GetSeriesFromXml(string path)
        {
            List<SingleSeries> xmlSeries = new List<SingleSeries>();
            
            SingleSeries s1 = new SingleSeries();
            SingleSeries s2 = new SingleSeries();

            s1.Components.Add(new ComponentFocus(Shape.Rectangle, Color.Blue, 2));
            s1.Components.Add(new ComponentFocus(Shape.Circle, Color.Blue, 3));
            s1.Components.Add(new ComponentFocus(Shape.Square, Color.Yellow, 3));
            s1.Components.Add(new ComponentFocus(Shape.Rectangle, Color.Red, 2));
            s1.Components.Add(new ComponentFocus(Shape.Rectangle, Color.Blue, 2));

            s2.Components.Add(new ComponentFocus(Shape.Rectangle, Color.Red, 2));
            s2.Components.Add(new ComponentFocus(Shape.Circle, Color.Yellow, 3));
            s2.Components.Add(new ComponentFocus(Shape.Circle, Color.Blue, 2));
            s2.Components.Add(new ComponentFocus(Shape.Rectangle, Color.Red, 2));
            s2.Components.Add(new ComponentFocus(Shape.Circle, Color.Blue, 3));

            xmlSeries.Add(s1);
            xmlSeries.Add(s2);

            return xmlSeries;
        }

        private void buttonSameColor_Click(object sender, EventArgs e)
        {
            Score.TotalAnswers++;

            if (PreviousComponent != null)
            {
                ComponentFocus current = Series[CurrentSeries].Components[CurrentComponent];
                ComponentFocus previous = Series[CurrentSeries].Components[PreviousComponent];

                if (current.Color == previous.Color)
                    Score.GoodAnswers++;
            }

            PreviousComponent = CurrentComponent;
            IncrementCurrentComponentOrSeries();
            DisplayCurrentComponent();
        }

        private void buttonSameDotNumber_Click(object sender, EventArgs e)
        {
            Score.TotalAnswers++;

            if (PreviousComponent != null)
            {
                ComponentFocus current = Series[CurrentSeries].Components[CurrentComponent];
                ComponentFocus previous = Series[CurrentSeries].Components[PreviousComponent];

                if (current.DotNumber == previous.DotNumber)
                    Score.GoodAnswers++;
            }

            PreviousComponent = CurrentComponent;
            IncrementCurrentComponentOrSeries();
            DisplayCurrentComponent();
        }

        private void buttonOther_Click(object sender, EventArgs e)
        {
            Score.TotalAnswers++;

            if (PreviousComponent != null)
            {
                ComponentFocus current = Series[CurrentSeries].Components[CurrentComponent];
                ComponentFocus previous = Series[CurrentSeries].Components[PreviousComponent];

                if (current.DotNumber != previous.DotNumber && current.Color != previous.Color)
                    Score.GoodAnswers++;
            }

            PreviousComponent = CurrentComponent;
            IncrementCurrentComponentOrSeries();
            DisplayCurrentComponent();
        }

        private void IncrementCurrentComponentOrSeries()
        {
            if (CurrentComponent < Series[CurrentSeries].Components.Count - 1)
            {
                CurrentComponent++;
            }
            else if (CurrentSeries < Series.Count - 1)
            {
                CurrentSeries++;
                CurrentComponent = 0;
            }
            else
            {
                Finish();
            }
        }
    }
}
