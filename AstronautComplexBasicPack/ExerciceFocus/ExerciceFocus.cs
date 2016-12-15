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

        public Button buttonSameColor = new Button();
        public Button buttonSameShape = new Button();
        public Button buttonSameDotNumber = new Button();
        public Button buttonOther = new Button();

        public ExerciceFocus() : base("Attention et concentration")
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            Form.MinimumSize = new Size(420, 300);

            Score = new ExerciceScore();

            InitializeButtons();
            
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

        private void InitializeButtons()
        {
            List<Button> buttons = new List<Button>();
            buttons.Add(buttonSameColor);
            buttons.Add(buttonSameShape);
            buttons.Add(buttonSameDotNumber);
            buttons.Add(buttonOther);
            
            foreach (Button button in buttons)
            {
                button.Size = new Size(110, 40);
                button.Anchor = AnchorStyles.None;
            }

            buttonSameColor.Name = "buttonSameColor";
            buttonSameShape.Name = "buttonSameShape";
            buttonSameDotNumber.Name = "buttonSameDotNumber";
            buttonOther.Name = "buttonOther";

            buttonSameColor.Click += new EventHandler(buttonSameColor_Click);
            buttonSameShape.Click += new EventHandler(buttonSameShape_Click);
            buttonSameDotNumber.Click += new EventHandler(buttonSameDotNumber_Click);
            buttonOther.Click += new EventHandler(buttonOther_Click);
        }
        

        private void DisplayCurrentComponent()
        {
            componentFocusPanel.Controls.Clear();

            if (CurrentComponent == 0)
            {
                StartASeries();
                foreach(Button button in tlpButtons.Controls)
                {
                    if (tlpButtons.GetRow(button) != tlpButtons.RowCount - 1)
                        button.Visible = false;
                }
            }
            else
            {
                if(Difficulty == ExerciceDifficulty.Hard)
                    timer.Start();

                foreach (Button button in tlpButtons.Controls)
                {
                    if (tlpButtons.GetRow(button) != tlpButtons.RowCount - 1)
                        button.Visible = true;
                }
            }
            
            componentFocusPanel.Controls.Add(Series[CurrentSeries].Components[CurrentComponent]);

            componentFocusPanel.Refresh();
        }

        private void StartASeries()
        {
            ArrangeButtons();
            DisplaySeriesRule();
        }

        private void ArrangeButtons()
        {
            tlpButtons.Controls.Clear();

            int counter = 0;

            foreach(Button button in Series[CurrentSeries].Buttons)
            {
                tlpButtons.Controls.Add(button, 0, counter);
                counter++;
                button.Text = "Bouton " + counter;
            }
        }

        private List<SingleSeries> GetSeriesFromXml(string path)
        {
            List<SingleSeries> xmlSeries = new List<SingleSeries>();

            List<ComponentFocus> components = new List<ComponentFocus>();
            List<Button> buttons = new List<Button>();

            buttons.Add(buttonSameColor);
            buttons.Add(buttonSameShape);
            buttons.Add(buttonOther);

            components.Add(new ComponentFocus(Shape.Rectangle, Color.Blue, 2));
            components.Add(new ComponentFocus(Shape.Circle, Color.Blue, 3));
            components.Add(new ComponentFocus(Shape.Square, Color.Yellow, 3));
            components.Add(new ComponentFocus(Shape.Rectangle, Color.Red, 2));
            components.Add(new ComponentFocus(Shape.Rectangle, Color.Blue, 2));

            xmlSeries.Add(new SingleSeries(components, buttons));

            buttons.Clear();
            components.Clear();

            buttons.Add(buttonSameDotNumber);
            buttons.Add(buttonOther);
            buttons.Add(buttonSameShape);

            components.Add(new ComponentFocus(Shape.Circle, Color.Red, 2));
            components.Add(new ComponentFocus(Shape.Circle, Color.Yellow, 3));
            components.Add(new ComponentFocus(Shape.Circle, Color.Blue, 2));
            components.Add(new ComponentFocus(Shape.Rectangle, Color.Red, 2));
            components.Add(new ComponentFocus(Shape.Circle, Color.Blue, 3));

            xmlSeries.Add(new SingleSeries(components, buttons));

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

        private void buttonSameShape_Click(object sender, EventArgs e)
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

            switch (button.Name) //switch on the button we clicked
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
                    isRight = true;
                    if (tlpButtons.Contains(buttonSameColor))
                        if (current.Color == previous.Color)
                            isRight = false;
                    if (tlpButtons.Contains(buttonSameDotNumber))
                        if (current.DotNumber == previous.DotNumber)
                            isRight = false;
                    if (tlpButtons.Contains(buttonSameShape))
                        if (current.Shape == previous.Shape)
                            isRight = false;
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

            if (current.Color == previous.Color && tlpButtons.Contains(buttonSameColor))
                return tlpButtons.GetRow(buttonSameColor) + 1;
            else if (current.DotNumber == previous.DotNumber && tlpButtons.Contains(buttonSameDotNumber))
                return tlpButtons.GetRow(buttonSameDotNumber) + 1;
            else if (current.Shape == previous.Shape && tlpButtons.Contains(buttonSameShape))
                return tlpButtons.GetRow(buttonSameShape) + 1;
            else
                return tlpButtons.GetRow(buttonOther) + 1;
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
            string associations = "";
            string role;

            int counter = 1;

            foreach(Button button in Series[CurrentSeries].Buttons)
            {
                switch(button.Name)
                {
                    case "buttonSameColor":
                        role = "même couleur";
                        break;
                    case "buttonSameShape":
                        role = "même forme";
                        break;
                    case "buttonSameDotNumber":
                        role = "même nombre de points";
                        break;
                    case "buttonOther":
                        role = "autre";
                        break;
                    default:
                        throw new NotImplementedException();
                }
                associations += "Bouton " + counter + " : " + role + " \n";
                counter++;
            }

            MessageBox.Show(associations);   
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
