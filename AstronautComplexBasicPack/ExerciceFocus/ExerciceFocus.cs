using System;
using AstronautComplex;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Threading.Tasks;
using System.Timers;

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
        }

        private void DisplayCurrentComponent()
        {
            componentFocusPanel.Controls.Clear();

            if (CurrentComponent == 0)
            {
                DisplaySeriesRule();
                buttonSameColor.Visible = false;
                buttonSameDotNumber.Visible = false;
            }
            else
            {
                if(Difficulty == ExerciceDifficulty.Hard)
                    timer.Start();
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
            timer.Stop();

            if (CurrentComponent != 0)
            {
                Score.TotalAnswers++;
                CheckAnswer((Button) sender);
            }
            PreviousComponent = CurrentComponent;
            IncrementCurrentComponentOrSeries();
            DisplayCurrentComponent();
        }
       
        private void buttonSameDotNumber_Click(object sender, EventArgs e)
        {
            timer.Stop();

            if (CurrentComponent != 0)
            {
                Score.TotalAnswers++;
                CheckAnswer((Button) sender);
            }
            PreviousComponent = CurrentComponent;
            IncrementCurrentComponentOrSeries();
            DisplayCurrentComponent();
        }

        private void buttonOther_Click(object sender, EventArgs e)
        {
            timer.Stop();

            if (CurrentComponent != 0)
            {
                Score.TotalAnswers++;
                CheckAnswer((Button)sender);
            }
            PreviousComponent = CurrentComponent;
            IncrementCurrentComponentOrSeries();
            DisplayCurrentComponent();
        }

        private void CheckAnswer(Button button)
        {
            ComponentFocus current = Series[CurrentSeries].Components[CurrentComponent];
            ComponentFocus previous = Series[CurrentSeries].Components[PreviousComponent];

            bool isRight = false;

            switch (button.Name)
            {
                case "buttonSameColor":
                    isRight = (current.Color == previous.Color);
                    break;
                case "buttonSameShape":
                    isRight = (current.Shape == previous.Shape);
                    break;
                case "buttonSameDotNumber":
                    isRight = (current.DotNumber == previous.DotNumber);
                    break;
                case "buttonOther":
                    isRight = (current.Color != previous.Color && current.DotNumber != previous.DotNumber);
                    break;
                default:
                    break;
            }

            if(isRight)
            {
                Score.GoodAnswers++;
                MessageBox.Show("Bonne réponse !");
            }
            else
            {
                int buttonNumber = FindGoodAnswer();
                MessageBox.Show("Mauvaise réponse ! Il fallait cliquer sur le bouton " + buttonNumber + ".");
            }
        }

        private int FindGoodAnswer()
        {
            ComponentFocus current = Series[CurrentSeries].Components[CurrentComponent];
            ComponentFocus previous = Series[CurrentSeries].Components[PreviousComponent];

            if (current.Color == previous.Color)
                return 1;
            if (current.DotNumber == previous.DotNumber)
                return 2;
            else
                return 3;
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
                Form.FinishExercice(this);
            }
        }

        private void DisplaySeriesRule()
        {
            MessageBox.Show("ceci est la consigne de la serie");   
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Score.TotalAnswers++;
            int buttonNumber = FindGoodAnswer();
            MessageBox.Show("Temps écoulé. Il fallait cliquer sur le bouton " + buttonNumber + ".");
            IncrementCurrentComponentOrSeries();
            DisplayCurrentComponent();
        }
    }
}
