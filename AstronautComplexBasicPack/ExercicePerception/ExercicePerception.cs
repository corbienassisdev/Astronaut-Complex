using AstronautComplex;
using System.Collections.Generic;
using System.Drawing;
using System;
using System.Windows.Forms;

namespace AstronautComplexBasicPack.ExercicePerception
{
    /// <summary>
    /// Represents an astronaut perception test.
    /// </summary>
    public partial class ExercicePerception : Exercice
    {
        public List<Component> Components { get; protected set; }

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
            //TODO : For 1 to 10, Display successive screens (2 or 4 seconds according to the difficulty) and increment answers
            for (int i = 0; i < 3; i++)
            {
                //TODO : Give the instructions
                MessageBox.Show("Retenez le nombre associé aux carrés jaunes", "Instruction", MessageBoxButtons.OK, MessageBoxIcon.None);
                //je remplis ma liste de 12 composants
                Components.Clear();
                tableLayoutPanelMask.Controls.Clear();
                GenerateRandomComponents(12);
                //TODO : shuffleComponents and AddLetterToComponents
                //je les rajoute à mon tablelayoutpanel
                AddComponentsToLayout();
                tableLayoutPanelMask.Refresh();
                System.Threading.Thread.Sleep(2000);
                //je les affiche 2 ou 4 secondes
                ShowComponents();

                //j'incremente les réponses
            }
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
