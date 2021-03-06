﻿using System;
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
using System.Xml.Linq;

namespace AstronautComplexBasicPack.ExerciceFocus
{
    /// <summary>
    /// Represents an astronaut focus test.
    /// </summary>
    public partial class ExerciceFocus : Exercice
    {
        public List<SingleSeries> Series { get; set; }
        public int CurrentSeries { get; set; }
        public int CurrentComponent { get; set; }
        public int PreviousComponent { get; set; }

        #region Buttons declaration
        private Button buttonSameColor = new Button();
        private Button buttonSameShape = new Button();
        private Button buttonSameDotNumber = new Button();
        private Button buttonOther = new Button();
        #endregion

        public ExerciceFocus() : base("Attention et concentration")
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            Form.MinimumSize = new Size(420, 300);

            Score = new ExerciceScore();

            InitializeButtons();

            Series = GetSeriesFromXml("../../../AstronautComplexBasicPack/ExerciceFocus/series.xml");

            CurrentSeries = 0;
            CurrentComponent = 0;
        }
        
        public override void Run()
        {
            DisplayCurrentComponent();
        }

        public override string GetInstructions()
        {
            string instructions = "Des séries d'éléments vont vous être présentées. La forme de ces éléments, leur couleur, ou le nombre de points qu'elles contiennent va changer tout au long de chaque série.\n\n"
                + "Sur votre droite, trois boutons seront affichés. une consigne vous indiquera au début de chaque série quel est le rôle de chaque bouton, et vous devrez cliquer sur celui qui correspond au point commun entre l'élément que vous avez sous les yeux et le précédent.\n\n"
                + "Par exemple, Si le Bouton 1 correspond à la couleur, vous devrez cliquer dessus lorsque l'élément que vous voyez est de la même couleur que celui d'avant.";
            return instructions;
        }

        /// <summary>
        /// Initializes the 3 buttons (events, properties).
        /// </summary>
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

        /// <summary>
        /// Returns a list of series extracted form an xml file.
        /// </summary>
        /// <param name="path">Relative path to the file.</param>
        /// <returns>the list of series extracted.</returns>
        private List<SingleSeries> GetSeriesFromXml(string path)
        {
            List<SingleSeries> xmlSeries = new List<SingleSeries>();

            List<ComponentFocus> components = new List<ComponentFocus>();
            List<Button> buttons = new List<Button>();

            XDocument document = XDocument.Load(path);

            foreach (XElement a in document.Descendants("singleserie"))
            {
                buttons.Clear();
                components.Clear();

                foreach (XElement b in a.Descendants("buttons"))
                {
                    foreach (XElement c in b.Descendants("button"))
                    {
                        switch (c.Value)
                        {
                            case "color":
                                buttons.Add(this.buttonSameColor);
                                break;
                            case "dots":
                                buttons.Add(this.buttonSameDotNumber);
                                break;
                            case "shape":
                                buttons.Add(this.buttonSameShape);
                                break;
                            case "other":
                                buttons.Add(this.buttonOther);
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                    }
                }

                foreach (XElement b in a.Descendants("component"))
                {
                    Color color;
                    Shape shape;
                    int dots;

                    switch (b.Descendants("color").First().Value)
                    {
                        case "blue":
                            color = Color.RoyalBlue;
                            break;
                        case "red":
                            color = Color.Crimson;
                            break;
                        case "yellow":
                            color = Color.Yellow;
                            break;
                        case "green":
                            color = Color.LimeGreen;
                            break;
                        default:
                            color = Color.Black;
                            break;
                    }

                    switch (b.Descendants("shape").First().Value)
                    {
                        case "circle":
                            shape = Shape.Circle;
                            break;
                        case "square":
                            shape = Shape.Square;
                            break;
                        case "rectangle":
                            shape = Shape.Rectangle;
                            break;
                        case "triangle":
                            shape = Shape.Triangle;
                            break;
                        default:
                            shape = Shape.Circle;
                            break;
                    }

                    dots = int.Parse(b.Descendants("dotnumber").First().Value);

                    components.Add(new ComponentFocus(shape, color, dots));
                }

                xmlSeries.Add(new SingleSeries(components, buttons));
            }

            return xmlSeries;
        }

        /// <summary>
        /// Displays the current component according to its position in the series.
        /// </summary>
        private void DisplayCurrentComponent()
        {
            componentFocusPanel.Controls.Clear();

            if (CurrentComponent == 0)
            {
                StartASeries();
                foreach(Button button in tlpButtons.Controls)
                    if (tlpButtons.GetRow(button) != tlpButtons.RowCount - 1)
                        button.Visible = false;
            }
            else
            {
                if(Difficulty == ExerciceDifficulty.Hard)
                    timer.Start();

                foreach (Button button in tlpButtons.Controls)
                    if (tlpButtons.GetRow(button) != tlpButtons.RowCount - 1)
                        button.Visible = true;
            }
            
            componentFocusPanel.Controls.Add(Series[CurrentSeries].Components[CurrentComponent]);

            componentFocusPanel.Refresh();
        }

        /// <summary>
        /// Arrange or re-arrange the position of buttons and displays the rules for the current series.
        /// </summary>
        private void StartASeries()
        {
            ArrangeButtons();
            DisplaySeriesRule();
        }

        /// <summary>
        /// Place the buttons according to their position in the button list of the current series.
        /// </summary>
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
        
        /// <summary>
        /// Checks if the right button was clicked according to the context and increments scores.
        /// </summary>
        /// <param name="button">The clicked button.</param>
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
        
        /// <summary>
        /// Reserches and returns the number of the button which should have been clicked according to the context.
        /// </summary>
        /// <returns>number of the correct button</returns>
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

        /// <summary>
        /// Increments the current component according to its position in the series.
        /// </summary>
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

        /// <summary>
        /// Displays instructions in a MessageBox.
        /// </summary>
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
                        role = "Couleur identique.";
                        break;
                    case "buttonSameShape":
                        role = "Forme Identique";
                        break;
                    case "buttonSameDotNumber":
                        role = "Nombre de points identique.";
                        break;
                    case "buttonOther":
                        role = "Aucune des autres réponses.";
                        break;
                    default:
                        throw new NotImplementedException();
                }
                associations += "Bouton " + counter + "  -  " + role + " \n";
                counter++;
            }

            MessageBox.Show(associations, "Rôle de chaque bouton");   
        }

        /// <summary>
        /// Displays correct answer when time is up (available for the Hard difficulty).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
