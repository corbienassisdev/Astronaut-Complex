using AstronautComplex;
using System;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    /// <summary>
    /// Represents a multiple-answer question.
    /// </summary>
    public abstract class Question
    {
        public string TitleFormat { get; protected set; }
        public string Title { get; protected set; }
        public int Answer { get; protected set; }
        public string[] Answers { get; protected set; }

        /// <summary>
        /// Builds a multiple-answer question.
        /// </summary>
        /// <param name="titleFormat">The question title format.</param>
        public Question(string titleFormat)
        {
            TitleFormat = titleFormat;
        }

        /// <summary>
        /// Builds the question, setting the possible answers and the good answer, depending on the difficulty. Needs to be implemented.
        /// </summary>
        /// <param name="difficulty">The exercice difficulty.</param>
        /// <param name="random">The exercice random number generator.</param>
        public abstract void Build(ExerciceDifficulty difficulty, Random random);
    }
}
