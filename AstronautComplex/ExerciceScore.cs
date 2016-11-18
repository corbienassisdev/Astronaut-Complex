using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstronautComplex
{
    public class ExerciceScore
    {
        public int GoodAnswers { get; set; }
        public int TotalAnswers { get; set; }

        /// <summary>
        /// Creates an ExerciceScore object initializing values at 0. VS does it by default but here, it's clearer.
        /// </summary>
        public ExerciceScore()
        {
            GoodAnswers = 0;
            TotalAnswers = 0;
        }

        public override string ToString()
        {
            return ((double)GoodAnswers / TotalAnswers) * 100 + " %";
        }
    }
}
