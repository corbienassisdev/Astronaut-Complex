using System;

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

        /// <summary>
        /// Converts the score to a readable string.
        /// </summary>
        /// <returns>The score value, in percentage.</returns>
        public override string ToString()
        {
            return Math.Round(((double)GoodAnswers / TotalAnswers) * 100 ,2) + " %"; //round value at 2 decimals
        }
    }
}
