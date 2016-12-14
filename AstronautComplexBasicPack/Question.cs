using AstronautComplex;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AstronautComplexBasicPack
{
    /// <summary>
    /// Represents a multiple-answer question.
    /// </summary>
    public abstract class Question
    {
        public string TitleFormat { get; protected set; }
        public string SuffixeAnswer { get; protected set; }

        public string Title { get; protected set; }
        public int Answer { get; protected set; }
        public object[] Answers { get; protected set; }

        /// <summary>
        /// Builds a multiple-answer question.
        /// </summary>
        /// <param name="titleFormat">The question title format.</param>
        /// <param name="suffixeAnswers">The answer suffixe (usually a measure unit).</param>
        public Question(string titleFormat, string suffixeAnswer)
        {
            TitleFormat = titleFormat;
            SuffixeAnswer = suffixeAnswer;
        }

        /// <summary>
        /// Generates the question title based on its format.
        /// </summary>
        /// <param name="args">The question format arguments.</param>
        public void GenerateTitle(params object[] argsQuestion)
        {
            Title = string.Format(TitleFormat, argsQuestion);
        }

        /// <summary>
        /// Generates the question answers, with a range based on the correct answer.
        /// </summary>
        /// <param name="correctAnswer">The correct answer.</param>
        /// <param name="randomRange">The random range in which the function can select random values.</param>
        /// <param name="minAnswers">The answers minimum number.</param>
        /// <param name="maxAnswers">The answers maximum number.</param>
        /// <param name="random">The exercice random number generator.</param>
        public void GenerateAnswersWithRange(decimal correctAnswer, decimal randomRange, byte minAnswers, byte maxAnswers, Random random)
        {
            Answers = new string[random.Next(minAnswers, maxAnswers)];
            Answer = random.Next(0, Answers.Length);

            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i] = string.Format("{0}{1}", correctAnswer + ((i - Answer) * randomRange), SuffixeAnswer);
            }
        }

        /// <summary>
        /// Builds the question, setting the possible answers and the good answer, depending on the difficulty. Needs to be implemented.
        /// </summary>
        /// <param name="difficulty">The exercice difficulty.</param>
        /// <param name="random">The exercice random number generator.</param>
        public abstract void Build(ExerciceDifficulty difficulty, Random random);

        /// <summary>
        /// Builds the question drawing. Needs to be implemented.
        /// </summary>
        /// <param name="graphics">The calling form graphics.</param>
        /// <param name="containerWidth">The container width.</param>
        /// <param name="containerHeight">The container height.</param>
        public abstract void BuildDrawing(Graphics graphics, int containerWidth, int containerHeight);
    }
}
