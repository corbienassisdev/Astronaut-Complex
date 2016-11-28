using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AstronautComplex;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class QuestionHypothenuse : Question
    {
        /// <summary>
        /// Builds a multiple-answer question on an hypothenuse problem.
        /// </summary>
        /// <param name="titleFormat">The question title format.</param>
        /// <param name="suffixeAnswers">The answer suffixe (usually a measure unit).</param>
        public QuestionHypothenuse(string titleFormat, string suffixeAnswer) : base(titleFormat, suffixeAnswer)
        {

        }
        
        /// <summary>
        /// Builds the question, setting the possible answers and the good answer, depending on the difficulty.
        /// </summary>
        /// <param name="difficulty">The exercice difficulty.</param>
        /// <param name="random">The exercice random number generator.</param>
        public override void Build(ExerciceDifficulty difficulty, Random random)
        {
            decimal sideA = random.Next(0, 20);
            decimal sideB = random.Next(0, 20);
            decimal correctAnswer = (decimal)Math.Round(Math.Sqrt(Math.Pow((double)sideA, 2) + Math.Pow((double)sideB, 2)), 2);
            decimal randomRange = random.Next((int)correctAnswer / 10, (int)correctAnswer / 5);

            GenerateTitle(sideA, sideB);
            GenerateAnswers(correctAnswer, randomRange, 3, 6, random);
        }
    }
}
