using AstronautComplex;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace AstronautComplexBasicPack.ExercicePerception
{
    /// <summary>
    /// Represents an astronaut perception test.
    /// </summary>
    public partial class ExercicePerception : Exercice
    {
        public Mask CurrentMask { get; set; }

        public static int numberOfMasks = 3;

        /// <summary>
        /// Builds an astronaut perception test.
        /// </summary>
        public ExercicePerception() : base("Perception et mémoire associative")
        {
            InitializeComponent(); //not related to our component class
        }

        public override void Initialize()
        {
            Form.MinimumSize = new Size(500, 600);
            CurrentMask = new Mask();

            string secondes = (Difficulty == ExerciceDifficulty.Easy) ? "4" : "2";
            string startingInstruction = "Lors de ce test, des figures de forme et de couleur différentes vont être affichées à l'écran pendant " + secondes + " secondes.\n"
                + "Sur chaque figure est écrit un nombre variant de 0 à 9.\n\n"
                + "Votre but est de retenir uniquement les nombres contenus dans les figures de forme X et de couleur Y\n\n"
                + "Exemple : Retenez les nombres des figures de forme carrée et de couleur jaune).";
            MessageBox.Show(startingInstruction, "Consigne générale", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

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
            Finish();
        }

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

        private void GetAnswers()
        {
            MessageBox.Show("Je veux des réponses", "Réponses", MessageBoxButtons.OK, MessageBoxIcon.None);
            //throw new NotImplementedException();
        }

        private void tableLayoutPanelMask_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel.Refresh();
        }
    }
}
