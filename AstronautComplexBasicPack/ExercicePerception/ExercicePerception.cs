﻿using AstronautComplex;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using Microsoft.VisualBasic;

namespace AstronautComplexBasicPack.ExercicePerception
{
    /// <summary>
    /// Represents an astronaut perception test.
    /// </summary>
    public partial class ExercicePerception : Exercice
    {
        public Mask CurrentMask { get; set; }

        public static int numberOfMasks = 10;

        public static int timeHard = 2;
        public static int timeEasy = 4;

        /// <summary>
        /// Builds an astronaut perception test.
        /// </summary>
        public ExercicePerception() : base("Perception et mémoire associative")
        {
            InitializeComponent(); //not related to our component class
        }

        /// <summary>
        /// Initialize the current exercice. An overrided method.
        /// </summary>
        public override void Initialize()
        {
            Form.MinimumSize = new Size(500, 600);

            Score = new ExerciceScore();
            CurrentMask = new Mask();

        }

        /// <summary>
        /// Launches the current exercice. An overrided method.
        /// </summary>
        public override void Run()
        {
            for (int i = 0; i < numberOfMasks; i++)
            {
                CurrentMask.SetRandomReferenceShapeAndColor();
                GiveInstructions();
                CurrentMask.ResetMask(tableLayoutPanel);
                CurrentMask.ShowMask(Difficulty, tableLayoutPanel);
                GetAnswers();
            }

            Form.FinishExercice(this);
        }

        /// <summary>
        /// Returns global instructions for the exercice.
        /// </summary>
        /// <returns>Instruction</returns>
        public override string GetInstructions()
        {
            string secondes = (Difficulty == ExerciceDifficulty.Easy) ? timeEasy.ToString() : timeHard.ToString();
            return "Lors de ce test, des figures de forme et de couleur différentes vont être affichées à l'écran pendant " + secondes + " secondes.\n"
                 + "Sur chaque figure est écrit un nombre variant de 0 à 9.\n\n"
                 + "Votre but est de retenir uniquement les nombres contenus dans les figures de forme X et de couleur Y\n\n"
                 + "Exemple : Retenez la valeur des cercles jaunes";
        }

        /// <summary>
        /// Displays instructions for the current mask in a MessageBox.
        /// </summary>
        private void GiveInstructions()
        {
            string shape;

            switch(CurrentMask.ReferenceShape)
            {
                case Shape.Circle:
                    shape = "cercle";
                    break;
                case Shape.Square:
                    shape = "carré";
                    break;
                default:
                    throw new NotImplementedException();
            }

            string color = (CurrentMask.ReferenceColor == Color.Yellow)? "jaune":"bleu";

            string instruction = "Retenez la valeur des " + shape + "s " + color + "s.";

            MessageBox.Show(instruction, "Instruction", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        /// <summary>
        /// Asks the answer and increment Scores.
        /// </summary>
        private void GetAnswers()
        {
            foreach(ComponentPerception c in CurrentMask.Components)
            {
                if(c.Shape == CurrentMask.ReferenceShape && c.Color == CurrentMask.ReferenceColor)
                {
                    int n = AskDigitOfComponent(c);

                    if(n == c.Digit)
                        Score.GoodAnswers++;

                    Score.TotalAnswers++;
                }
            }
        }

        /// <summary>
        /// Displays a prompt in which the user can enter his answer.
        /// </summary>
        /// <param name="c">Component related to the answer asked.</param>
        /// <returns>Number answered by the user.</returns>
        private int AskDigitOfComponent(ComponentPerception c)
        {
            Form form = new Form();
            Label label = new Label();
            NumericUpDown updown = new NumericUpDown();
            Button buttonOk = new Button();

            #region Form creation
            form.Text = "Figure " + c.Letter.ToString();
            label.Text = "Quelle était la valeur associée\n à la figure " + c.Letter.ToString() + " ?";
            updown.ResetText();

            Panel buttonOkPanel = new Panel(); //only about aesthectics
            buttonOkPanel.Dock = DockStyle.Bottom;
            buttonOkPanel.Height = 50;
            buttonOkPanel.BackColor = Color.WhiteSmoke;

            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;

            label.Dock = DockStyle.Top;
            label.Font = new Font("Arial", 11);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Dock = DockStyle.Top;
            label.Height = 50;
            label.BackColor = Color.White;

            updown.Location = new Point(105, 60);
            updown.Width = 75;
            updown.TextAlign = HorizontalAlignment.Center;
            updown.Minimum = 0;
            updown.Maximum = 9;

            buttonOk.Location = new Point(191, 13);
            buttonOk.Width = 75;
            buttonOk.Height = 25;
            buttonOk.Text = "OK";

            buttonOkPanel.Controls.Add(buttonOk);

            form.ClientSize = new Size(280, 158);
            form.Controls.AddRange(new Control[] { label, updown, buttonOkPanel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.White;
            form.AcceptButton = buttonOk;
            #endregion

            form.ShowDialog();

            return (int)updown.Value;
        }

        /// <summary>
        /// Refresh the TableLayoutPanel when resize.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tableLayoutPanelMask_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel.Refresh();
        }
    }
}
