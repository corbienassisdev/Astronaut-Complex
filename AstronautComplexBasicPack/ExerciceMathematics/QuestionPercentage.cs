using AstronautComplex;
using System;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class QuestionPercentage : Question
    {
        /// <summary>
        /// Builds a multiple-answer question on a percentage problem.
        /// </summary>
        /// <param name="titleFormat">The question title format.</param>
        public QuestionPercentage(string titleFormat) : base(titleFormat)
        {

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
            decimal correctAnswer = startPrice + (percentage / 100) * startPrice;
            decimal randomRange = random.Next((int)correctAnswer / 10, (int)correctAnswer / 5);

            Title = string.Format(TitleFormat, startPrice, percentage);
            Answers = new string[random.Next(3, 6)];
            Answer = random.Next(0, Answers.Length);

            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i] = string.Format("{0}€", correctAnswer + ((i - Answer) * randomRange));
            }
        }
    }
}
