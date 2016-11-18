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
        public List<Component> Components { get; protected set; }

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
            Components = new List<Component>();

            string startingInstruction = "Lors de ce test, des figures de forme et de couleur différentes vont être affichées à l'écran pendant X secondes.\n"
                + "Sur chaque figure est écrit un nombre variant de 0 à 9.\n\n"
                + "Votre but est de retenir uniquement les nombres contenus dans les figures de forme X et de couleur Y\n"
                + "Exemple : Retenez les nombres des figures de forme carrée et de couleur jaune).";
            MessageBox.Show(startingInstruction, "Consigne générale", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public override void Run()
        {
            for (int i = 0; i < numberOfMasks; i++)
            {
                GiveInstructions();
                ResetMask();
                ShowMask();
                GetAnswers();
            }
            Finish();
        }

        private void GiveInstructions()
        {
            MessageBox.Show("Retenez le nombre associé aux carrés jaunes", "Instruction", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void ResetMask()
        {
            Components.Clear();
            tableLayoutPanelMask.Controls.Clear();

            GenerateRandomComponents(12);
            ShuffleComponents();
            AddLetterToComponents();
            
            AddComponentsToLayout();
        }

        private void ShowMask()
        {
            tableLayoutPanelMask.Refresh();

            switch (Difficulty)
            {
                case ExerciceDifficulty.Easy:
                    System.Threading.Thread.Sleep(2000); // Wait 2 seconds without blocking
                    //System.Threading.Tasks.Task.Delay(2000); //Needs the Microsoft .NET framework 4.5 and higher.
                    break;
                case ExerciceDifficulty.Hard:
                    Thread.Sleep(4000);
                    //System.Threading.Tasks.Task.Delay(4000); //Needs the Microsoft .NET framework 4.5 and higher.
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void GetAnswers()
        {
            MessageBox.Show("Je veux des réponses", "Réponses", MessageBoxButtons.OK, MessageBoxIcon.None);
            //throw new NotImplementedException();
        }

        private void GenerateRandomComponents(int numberOfComponents)
        {
            Color askedColor = Color.Yellow;
            Shape askedShape = Shape.Square;
            int numberOfFixedComponents = 4;

            //generate and add to the list of components 3 or 4 components with specified color and shape
            for (int i = 0; i < numberOfFixedComponents; i++)
                Components.Add(Component.RandomComponentWith(askedColor, askedShape));

            for (int i = 0; i < numberOfComponents - numberOfFixedComponents; i++)
            { 
                Components.Add(Component.RandomComponentWithoutBoth(askedColor, askedShape));
            }
        }

        /// <summary>
        /// Generates a random permutation of the components. Fisher–Yates logic.
        /// </summary>
        private void ShuffleComponents()
        {
            int n = Components.Count;
            while (n > 1)
            {
                n--;
                int k = new Random().Next(n + 1);
                Component c = Components[k];
                Components[k] = Components[n];
                Components[n] = c;
            }
        }

        /// <summary>
        /// Affects to each component in the list a letter from A to Z. This method implies that the number of components is less than 25
        /// </summary>
        private void AddLetterToComponents()
        {
            if(Components.Count > 26)
                throw new NotImplementedException();

            int AsciiIndex = 65;

            foreach(Component c in Components)
            {
                c.Letter = (char)AsciiIndex;
                AsciiIndex++;
            }
        }

        /// <summary>
        /// Adds components form the list attribute in the tableLayoutPanel
        /// </summary>
        private void AddComponentsToLayout()
        {
            int index = 0;
            for (int i = 0; i < tableLayoutPanelMask.RowCount; i++)
            {
                for (int j = 0; j < tableLayoutPanelMask.ColumnCount; j++)
                {
                    tableLayoutPanelMask.Controls.Add(Components[index], j, i);
                    index++;
                }
            }
        }

        /// <summary>
        /// Displays the current interface with its components in the form.
        /// </summary>
        public void ShowComponents()
        {
            //tableLayoutPanelMask.Refresh(); //call the onPaint method of each component in the tableLayoutPanel
        }

        private void tableLayoutPanelMask_Resize(object sender, EventArgs e)
        {
            tableLayoutPanelMask.Refresh();
        }
    }
}
