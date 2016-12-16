using AstronautComplex;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AstronautComplexBasicPack.ExerciceCalculus
{
    /// <summary>
    /// Represents an astronaut calculus exercice. Inherits from <see cref="Exercice"/>.
    /// </summary>
    public partial class ExerciceCalculus : Exercice
    {
        private TextBox textBoxResult;

        public int CorrectAnswer { get; protected set; }
        public int CurrentOperation { get; protected set; }
        public ExerciceCalculusType CurrentOperationType { get; protected set; }

        /// <summary>
        /// Builds an astronaut calculus exercice.
        /// </summary>
        public ExerciceCalculus() : base("Calcul mental")
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the exercice.
        /// </summary>
        public override void Initialize()
        {
            Score = new ExerciceScore();
            CurrentOperation = 0;
        }

        /// <summary>
        /// Runs the exercice.
        /// </summary>
        public override void Run()
        {
            labelTitle.Text = "Calcul mental";
        }

        /// <summary>
        /// Gets the exercice instructions. Needs to be implemented.
        /// </summary>
        /// <returns>The instructions.</returns>
        public override string GetInstructions()
        {
            return "Dans ce test, vous devrez calculer de tête différentes opérations, générées aléatoirement, qui vous serons posées. Au début, vous avez le choix entre une série de 10 additions, soustractions, multiplications ou divisions.";
        }

        /// <summary>
        /// Builds an operation.
        /// </summary>
        public void BuildOperation()
        {
            string symbol = "";
            int operandLeft = 0;
            int operandRight = 0;
            
            tableLayoutPanelSelection.Controls.Clear();
            tableLayoutPanelSelection.RowStyles.Clear();
            tableLayoutPanelSelection.RowCount = 1;
            tableLayoutPanelSelection.ColumnStyles.Clear();
            tableLayoutPanelSelection.ColumnCount = 2;

            Label labelOperation = new Label();
            labelOperation.AutoSize = true;
            labelOperation.Dock = DockStyle.Right;
            labelOperation.Font = new Font(FontFamily.GenericSansSerif, 18);
            labelOperation.TextAlign = ContentAlignment.MiddleRight;
            tableLayoutPanelSelection.Controls.Add(labelOperation, 0, 0);
            tableLayoutPanelSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));

            textBoxResult = new TextBox();
            textBoxResult.Anchor = AnchorStyles.Left;
            textBoxResult.Dock = DockStyle.None;
            textBoxResult.Font = new Font(FontFamily.GenericSansSerif, 18);
            textBoxResult.TextAlign = HorizontalAlignment.Right;
            textBoxResult.KeyPress += (sender, e) =>
            {
                if(e.KeyChar == '\r')
                {
                    Answer();
                }
            };
            tableLayoutPanelSelection.Controls.Add(textBoxResult, 1, 0);
            tableLayoutPanelSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));

            switch (CurrentOperationType)
            {
                case ExerciceCalculusType.Addition:
                    symbol = "+";
                    operandLeft = Random.Next(100, 999);
                    operandRight = Random.Next(100, 999);
                    CorrectAnswer = operandLeft + operandRight;
                    break;

                case ExerciceCalculusType.Subtraction:
                    symbol = "-";
                    operandLeft = Random.Next(100, 999);
                    operandRight = Random.Next(10, operandLeft);
                    CorrectAnswer = operandLeft - operandRight;
                    break;

                case ExerciceCalculusType.Multiplication:
                    symbol = "*";
                    operandLeft = Random.Next(1, 99);
                    operandRight = Random.Next(1, 9);
                    CorrectAnswer = operandLeft * operandRight;
                    break;

                case ExerciceCalculusType.Division:
                    symbol = "/";
                    operandLeft = Random.Next(10, 999);
                    operandRight = Random.Next(1, 9);
                    CorrectAnswer = (int)Math.Round(operandLeft / (double)operandRight);
                    break;
            }

            labelOperation.Text = string.Format("{0} {1} {2} =", operandLeft, symbol, operandRight);

            if (Difficulty == ExerciceDifficulty.Hard)
            {
                timer.Start();
            }

            CurrentOperation++;
        }

        /// <summary>
        /// Calls the question answering.
        /// </summary>
        /// <param name="correct">The correct answer.</param>
        public void Answer()
        {
            if (Difficulty == ExerciceDifficulty.Hard)
            {
                timer.Stop();
            }

            int result = -1;
            int.TryParse(textBoxResult.Text, out result);

            string message;
            string caption;
            MessageBoxIcon icon;
            if (result == CorrectAnswer)
            {
                message = string.Format("Bonne réponse ! Il s'agissait bien de {0} !", CorrectAnswer);
                caption = "Bravo !";
                icon = MessageBoxIcon.Information;
                Score.GoodAnswers++;
            }
            else
            {
                if(result > 0)
                {
                    message = string.Format("Mauvaise réponse... Vous avez répondu {0} mais la bonne réponse était {1} !", result, CorrectAnswer);
                    caption = "Oups...";
                    icon = MessageBoxIcon.Error;
                }
                else
                {
                    message = string.Format("Vous n'avez spécifié aucune réponse ! La bonne réponse était {0} !", CorrectAnswer);
                    caption = "Oups...";
                    icon = MessageBoxIcon.Error;
                }
            }

            Score.TotalAnswers++;

            if (MessageBox.Show(message, caption, MessageBoxButtons.OK, icon) == DialogResult.OK)
            {
                if (CurrentOperation < 10)
                {
                    BuildOperation();
                }
                else
                {
                    Form.FinishExercice(this);
                }
            }
        }

        /// <summary>
        /// Called on clicking a selection button.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void buttonSelection_Click(object sender, EventArgs e)
        {
            foreach(ExerciceCalculusType operation in Enum.GetValues(typeof(ExerciceCalculusType)))
            {
                if (sender != null && ((Button)sender).Name.Replace("buttonSelection", "") == operation.ToString())
                {
                    CurrentOperationType = operation;
                    BuildOperation();
                }
            }
        }

        /// <summary>
        /// Called on timer tick.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            Answer();
        }
    }
}
