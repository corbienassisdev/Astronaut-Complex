using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AstronautComplex;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class QuestionVolume : Question
    {
        /// <summary>
        /// Builds a multiple-answer question on an hypothenuse problem.
        /// </summary>
        /// <param name="titleFormat">The question title format.</param>
        /// <param name="suffixeAnswers">The answer suffixe (usually a measure unit).</param>
        public QuestionVolume(string titleFormat, string suffixeAnswer) : base(titleFormat, suffixeAnswer)
        {

        }

        /// <summary>
        /// Builds the question, setting the possible answers and the good answer, depending on the difficulty.
        /// </summary>
        /// <param name="difficulty">The exercice difficulty.</param>
        /// <param name="random">The exercice random number generator.</param>
        public override void Build(ExerciceDifficulty difficulty, Random random)
        {
            SideA = random.Next(1, 20);
            SideB = random.Next(1, 20);

            decimal correctAnswer = (decimal)Math.Round(Math.Sqrt(Math.Pow((double)SideA, 2) + Math.Pow((double)SideB, 2)), 2);
            decimal randomRange = random.Next((int)correctAnswer / 10, (int)correctAnswer / 5);

            GenerateTitle();
            GenerateAnswersWithRange(correctAnswer, s, 4, 4, random);
        }

        /// <summary>
        /// Builds the question drawing.
        /// </summary>
        /// <param name="graphics">The calling form graphics.</param>
        /// <param name="containerWidth">The container width.</param>
        /// <param name="containerHeight">The container height.</param>
        public override void BuildDrawing(Graphics graphics, int containerWidth, int containerHeight)
        {
            Pen pen = new Pen(Color.Navy, 1);
        }
    }
}
