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

            //TODO : Give the instructions
            //MessageBox.Show("Ceci est la consigne");

            //TODO : For 1 to 10, Display successive screens (2 or 4 seconds according to the difficulty) and increment answers
            //for (int i = 0; i < 1; i++) //mettre valeur 10 en variable 10101010101010
            //{
            //je remplis ma liste de 12 composants
            LoadComponents();
            //je les rajoute à mon tablelayoutpanel
            AddComponentsToLayout();
            //je les affiche 2 ou 4 secondes
            ShowComponents();
            //j'incremente les réponses
            //}
        }

        /// <summary>
        /// Displays the interface with all the components inside
        /// </summary>
        public void LoadComponents()
        {
            Components.Add(new Component('A', Color.Yellow, Shape.Circle, 2));
            Components.Add(new Component('B', Color.DodgerBlue, Shape.Square, 8));
            Components.Add(new Component('C', Color.Yellow, Shape.Square, 1));
            Components.Add(new Component('D', Color.Yellow, Shape.Circle, 8));
            Components.Add(new Component('E', Color.DodgerBlue, Shape.Circle, 7));
            Components.Add(new Component('F', Color.Yellow, Shape.Square, 1));
            Components.Add(new Component('G', Color.DodgerBlue, Shape.Circle, 5));
            Components.Add(new Component('H', Color.Yellow, Shape.Square, 2));
            Components.Add(new Component('I', Color.DodgerBlue, Shape.Square, 9));
            Components.Add(new Component('J', Color.Yellow, Shape.Circle, 8));
            Components.Add(new Component('K', Color.DodgerBlue, Shape.Circle, 7));
            Components.Add(new Component('L', Color.Yellow, Shape.Square, 1));

            // TODO: create a random generator according to the specifications, or an xml file
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

        //n'est plus appelé
        private void ExercicePerception_Load(object sender, EventArgs e)
        {
            //TODO : Give the instructions
            //MessageBox.Show("Ceci est la consigne");

            //TODO : For 1 to 10, Display successive screens (2 or 4 seconds according to the difficulty) and increment answers
            //for (int i = 0; i < 1; i++) //mettre valeur 10 en variable 10101010101010
            //{
                //je remplis ma liste de 12 composants
                LoadComponents();
                //je les rajoute à mon tablelayoutpanel
                AddComponentsToLayout();
                //je les affiche 2 ou 4 secondes
                ShowComponents();
                //j'incremente les réponses
            //}
        }

        private void tableLayoutPanelMask_Resize(object sender, EventArgs e)
        {
            tableLayoutPanelMask.Refresh();
        }
    }
}
