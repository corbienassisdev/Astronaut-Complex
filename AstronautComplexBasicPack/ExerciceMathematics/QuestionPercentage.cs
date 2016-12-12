using AstronautComplex;
using System;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class QuestionPercentage : Question
    {
        public QuestionPercentageType Type { get; protected set; }

        /// <summary>
        /// Builds a multiple-answer question on a percentage problem.
        /// </summary>
        /// <param name="titleFormat">The question title format.</param>
        /// <param name="suffixeAnswer">The answer suffixe (usually a measure unit).</param>
        /// <param name="type">The question variant type.</param>
        public QuestionPercentage(string titleFormat, string suffixeAnswer, QuestionPercentageType type) : base(titleFormat, suffixeAnswer)
        {
            Type = type;
        }

        /// <summary>
        /// Builds the question, setting the possible answers and the good answer, depending on the difficulty.
        /// </summary>
        /// <param name="difficulty">The exercice difficulty.</param>
        /// <param name="random">The exercice random number generator.</param>
        public override void Build(ExerciceDifficulty difficulty, Random random)
        {
            decimal startPrice = random.Next(50, 200);
            decimal percentage = random.Next(5, 30);
            percentage = (Type == QuestionPercentageType.Greater) ? percentage : -percentage;
            decimal correctAnswer = startPrice + (percentage / 100) * startPrice;
            decimal randomRange = random.Next((int)correctAnswer / 10, (int)correctAnswer / 5);

            GenerateTitle(startPrice, percentage);
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
