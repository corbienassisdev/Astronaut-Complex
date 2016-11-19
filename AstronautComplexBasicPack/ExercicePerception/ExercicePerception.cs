using AstronautComplex;
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

        public static int numberOfMasks = 1;

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
                + "Exemple : Retenez la valeur des cercles jaunes";
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
            foreach(Component c in CurrentMask.Components)
            {
                if(c.Shape == CurrentMask.ReferenceShape && c.Color == CurrentMask.ReferenceColor)
                {
                    int i = AskDigitOfComponent(c);
                }
            }

            //récupération des bonnes lettres
            
            MessageBox.Show("Je veux des réponses", "Réponses", MessageBoxButtons.OK, MessageBoxIcon.None);

            //pour chaque composant de forme ReferenceShape et de couleur ReferenceColor,
            //demander la valeur avec une boîte de dialogue en donnant la lettre
            //si valeur correspond, Score.GoodAnswer++;
            //fin pour
            //Score.TotalAnswers++;
            //throw new NotImplementedException();
        }

        private int AskDigitOfComponent(Component c)
        {
            string input = Interaction.InputBox("Prompt", "Title", "Default", -1, -1);
            return 1;
        }

        private void tableLayoutPanelMask_Resize(object sender, EventArgs e)
        {
            tableLayoutPanel.Refresh();
        }
    }
}
