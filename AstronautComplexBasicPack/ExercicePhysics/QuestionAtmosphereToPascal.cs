using AstronautComplex;
using System;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class QuestionAtmosphereToPascal : Question
    {
        public const int AtmosphereToPascal = 101325;

        /// <summary>
        /// Builds a multiple-answer question on a atmosphere to pascal conversion problem.
        /// </summary>
        /// <param name="titleFormat">The question title format.</param>
        /// <param name="suffixeAnswer">The answer suffixe (usually a measure unit).</param>
        public QuestionAtmosphereToPascal(string titleFormat, string suffixeAnswer) : base(titleFormat, suffixeAnswer)
        {

        }

        /// <summary>
        /// Builds the question, setting the possible answers and the good answer, depending on the difficulty.
        /// </summary>
        /// <param name="difficulty">The exercice difficulty.</param>
        /// <param name="random">The exercice random number generator.</param>
        public override void Build(ExerciceDifficulty difficulty, Random random)
        {
            decimal atmosphere = random.Next(0, 50) / 10.0M;
            decimal correctAnswer = atmosphere * AtmosphereToPascal;
            decimal randomRange = random.Next((int)correctAnswer / 10, (int)correctAnswer / 5);

            GenerateTitle(atmosphere);
            GenerateAnswersWithRange(correctAnswer, randomRange, 3, 6, random);
        }

        /// <summary>
        /// Builds the question drawing.
        /// </summary>
        /// <param name="graphics">The calling form graphics.</param>
        /// <param name="containerWidth">The container width.</param>
        /// <param name="containerHeight">The container height.</param>
        public override void BuildDrawing(Graphics graphics, int containerWidth, int containerHeight)
        {

        }
    }
}
