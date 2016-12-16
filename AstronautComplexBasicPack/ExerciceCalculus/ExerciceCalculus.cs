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
        public int CurrentOperation { get; protected set; }

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
        /// <param name="operation">The operation type.</param>
        public void BuildOperation(ExerciceCalculusType operation)
        {
            string symbol = "";
            int operandLeft = 0;
            int operandRight = 0;
            int correct = 0;

            #region Initialization
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

            TextBox textBoxResult = new TextBox();
            textBoxResult.Anchor = AnchorStyles.Left;
            textBoxResult.Dock = DockStyle.None;
            textBoxResult.Font = new Font(FontFamily.GenericSansSerif, 18);
            textBoxResult.TextAlign = HorizontalAlignment.Right;
            textBoxResult.KeyPress += (sender, e) =>
            {
                int result;
                if (e.KeyChar == '\r' && int.TryParse(textBoxResult.Text, out result))
                {
                    Score.TotalAnswers++;

                    string message;
                    string caption;
                    MessageBoxIcon icon;
                    if (result == correct)
                    {
                        message = string.Format("Bonne réponse ! Il s'agissait bien de {0} !", correct);
                        caption = "Bravo !";
                        icon = MessageBoxIcon.Information;
                        Score.GoodAnswers++;
                    }
                    else
                    {
                        message = string.Format("Mauvaise réponse... Vous avez répondu {0} mais la bonne réponse était {1} !", result, correct);
                        caption = "Oups...";
                        icon = MessageBoxIcon.Error;
                    }

                    if (MessageBox.Show(message, caption, MessageBoxButtons.OK, icon) == DialogResult.OK)
                    {
                        if(CurrentOperation < 10)
                        {
                            BuildOperation(operation);
                        }
                        else
                        {
                            Form.FinishExercice(this);
                        }
                    }
                }
            };
            tableLayoutPanelSelection.Controls.Add(textBoxResult, 1, 0);
            tableLayoutPanelSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.0F));
            #endregion

            #region switch on operation
            switch (operation)
            {
                case ExerciceCalculusType.Addition:
                    symbol = "+";
                    operandLeft = Random.Next(100, 999);
                    operandRight = Random.Next(100, 999);
                    correct = operandLeft + operandRight;
                    break;

                case ExerciceCalculusType.Subtraction:
                    symbol = "-";
                    operandLeft = Random.Next(100, 999);
                    operandRight = Random.Next(10, operandLeft);
                    correct = operandLeft - operandRight;
                    break;

                case ExerciceCalculusType.Multiplication:
                    symbol = "*";
                    operandLeft = Random.Next(1, 99);
                    operandRight = Random.Next(1, 9);
                    correct = operandLeft * operandRight;
                    break;

                case ExerciceCalculusType.Division:
                    symbol = "/";
                    operandLeft = Random.Next(10, 999);
                    operandRight = Random.Next(1, 9);
                    correct = operandLeft / operandRight;
                    break;
            }
            #endregion

            labelOperation.Text = string.Format("{0} {1} {2} =", operandLeft, symbol, operandRight);

            CurrentOperation++;
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
                    BuildOperation(operation);
                }
            }
        }
    }
}
