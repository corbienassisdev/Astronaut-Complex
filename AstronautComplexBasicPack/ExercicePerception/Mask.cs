using AstronautComplex;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstronautComplexBasicPack.ExercicePerception
{
    public class Mask
    {
        public List<ComponentPerception> Components { get; set; }
        public Shape ReferenceShape { get; set; } //the shape the user will have to memorize
        public Color ReferenceColor { get; set; } //the color the user will have to memorize

        public static int numberOfComponents = 12;


        public Mask()
        {
            Components = new List<ComponentPerception>();
        }

        
        /// <summary>
        /// Reset the mask
        /// </summary>
        /// <param name="tlp"></param>
        public void ResetMask(TableLayoutPanel tlp)
        {
            Components.Clear();
            tlp.Controls.Clear();

            GenerateRandomComponents();
            ShuffleComponents();
            AddLetterToComponents();

            AddComponentsToLayout(tlp);
        }

        /// <summary>
        /// Displays the current mask.
        /// </summary>
        /// <param name="difficulty"></param>
        /// <param name="tlp"></param>
        public void ShowMask(ExerciceDifficulty difficulty, TableLayoutPanel tlp)
        {
            tlp.Visible = true;

            tlp.Refresh();

            switch (difficulty)
            {
                case ExerciceDifficulty.Easy:
                    Thread.Sleep(ExercicePerception.timeEasy * 1000); // Wait 2 seconds, but freeze the thread (and UI)
                    break;
                case ExerciceDifficulty.Hard:
                    Thread.Sleep(ExercicePerception.timeHard * 1000);
                    //System.Threading.Tasks.Task.Delay(4000); //Needs the Microsoft .NET framework 4.5 and higher.
                    break;
                default:
                    throw new NotImplementedException();
            }

            tlp.Visible = false;
        }

        /// <summary>
        /// Set random shape and color for the current mask, which will be ask to memorize to the user.
        /// </summary>
        public void SetRandomReferenceShapeAndColor()
        {
            ReferenceShape = ComponentPerception.RandomEnumValue<Shape>();
            ReferenceColor = (new Random().Next(0, 2) == 0) ? Color.RoyalBlue : Color.Yellow;
        }

        /// <summary>
        /// Adds components form the list attribute in the tableLayoutPanel
        /// </summary>
        private void AddComponentsToLayout(TableLayoutPanel tlp)
        {
            int index = 0;
            for (int i = 0; i < tlp.RowCount; i++)
            {
                for (int j = 0; j < tlp.ColumnCount; j++)
                {
                    tlp.Controls.Add(Components[index], j, i);
                    index++;
                }
            }
        }

        /// <summary>
        /// Generates and adding to the list pseudo-random components (pseudo because they are according to the specifications)
        /// </summary>
        /// <param name="numberOfComponents">The number of components to generate</param>
        private void GenerateRandomComponents()
        {
            int numberOfFixedComponents = new Random().Next(3,5); //3 or 4 (cf. specifications)

            //generates and add to the list of components 3 or 4 components with specified color and shape
            for (int i = 0; i < numberOfFixedComponents; i++)
                Components.Add(ComponentPerception.RandomComponentWith(ReferenceShape, ReferenceColor));

            //generates the other components randomly, without the same reference color and shape as the first ones
            for (int i = 0; i < numberOfComponents - numberOfFixedComponents; i++)
            {
                Components.Add(ComponentPerception.RandomComponentWithoutBoth(ReferenceShape, ReferenceColor));
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
                ComponentPerception c = Components[k];
                Components[k] = Components[n];
                Components[n] = c;
            }
        }

        /// <summary>
        /// Affects to each component in the list a letter from A to Z. This method implies that the number of components is less than 25
        /// </summary>
        private void AddLetterToComponents()
        {
            if (Components.Count > 26)
                throw new NotImplementedException();

            int AsciiIndex = 65;

            foreach (ComponentPerception c in Components)
            {
                c.Letter = (char)AsciiIndex;
                AsciiIndex++;
            }
        }
    }
}
