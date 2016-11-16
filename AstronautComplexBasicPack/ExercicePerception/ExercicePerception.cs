using AstronautComplex;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace AstronautComplexBasicPack.ExercicePerception
{
    /// <summary>
    /// Represents an astronaut perception test.
    /// </summary>
    public partial class ExercicePerception : AstronautTest
    {
        public List<Component> Components { get; protected set; }

        /// <summary>
        /// Builds an astronaut perception test.
        /// </summary>
        public ExercicePerception() : base("Perception et mémoire associative")
        {
            Components = new List<Component>();
            InitializeComponent(); //not related to our component class
        }

        /// <summary>
        /// Called on control loading.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AstronautTestPerception_Load(object sender, System.EventArgs e)
        {
            
            
        }

        /// <summary>
        /// Displays the interface with all the components inside
        /// </summary>
        public void LoadComponents()
        {
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Square, 2));
            Components.Add(new Component('A', Color.Blue, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Blue, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 4));

            // TODO: create a random generator according to the specifications, or an xml file
        }

        /// <summary>
        /// Adds components form the list attribute in the tableLayoutPanel
        /// </summary>
        private void AddComponentsToLayout()
        {
            for (int i = 0; i < 3; i++) //TODO : rajouter attributs nbLignes et colonnes
            {
                for (int j = 0; j < 4; j++)
                {
                    tableLayoutPanelMask.Controls.Add(Components[0], i, j); //TODO : trouver formule
                }
            }

        }

        /// <summary>
        /// Displays the current interface with its components in the form.
        /// </summary>
        public void ShowComponents()
        {
            tableLayoutPanelMask.Refresh(); //call the onPaint method of each component in the tableLayoutPanel
        }

        private void ExercicePerception_Load(object sender, EventArgs e)
        {
            //TODO : Give the instructions
            //MessageBox.Show("Ceci est la consigne");

            //TODO : For 1 to 10, Display successive screens (2 or 4 seconds according to the difficulty) and increment answers
            for (int i = 0; i < 1; i++) //mettre valeur 10 en variable 10101010101010
            {
                //je remplis ma liste de 12 composants
                LoadComponents();
                //je les rajoute à mon tablelayoutpanel
                AddComponentsToLayout();
                //je les affiche 2 ou 4 secondes
                ShowComponents();
                //j'incremente les réponses
            }
        }
    }
}
