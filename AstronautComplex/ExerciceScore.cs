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

        public override string ToString()
        {
            return ((double)GoodAnswers / TotalAnswers) * 100 + " %";
        }
    }
}
