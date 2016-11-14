namespace AstronautComplexBasicPack.ExerciceMathematics
{
    /// <summary>
    /// Represents a multiple-answer question.
    /// </summary>
    public class Question
    {
        public string Title { get; protected set; }
        public int Answer { get; protected set; }
        public string[] Answers { get; protected set; }

        /// <summary>
        /// Builds a multiple-answer question.
        /// </summary>
        /// <param name="title">The question title.</param>
        /// <param name="answer">The question correct answer id.</param>
        /// <param name="answers">The question possible answers.</param>
        public Question(string title, int answer, string[] answers)
        {
            Title = title;
            Answer = answer;
            Answers = answers;
        }


    }
}
