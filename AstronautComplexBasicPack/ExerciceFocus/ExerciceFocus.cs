using System;
using AstronautComplex;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AstronautComplexBasicPack.ExerciceFocus
{
    public partial class ExerciceFocus : Exercice
    {
        //public List<Series> Series { get; set; }

        public ExerciceFocus() : base("Attention et concentration")
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            Score = new ExerciceScore();
            string startingInstruction = "Ceci est une consigne générale.";
            MessageBox.Show(startingInstruction, "Consigne générale", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public override void Run()
        {
            //For i from 1 to 3 (cause there is 3 series)
            //For j from 1 to 5 (cause there is 5 objects for 1 serie)
            //display object of serie i and at position j
            //display buttons
            //onclick buttons check answers
            //end for
            //end for
        }
    }
}
