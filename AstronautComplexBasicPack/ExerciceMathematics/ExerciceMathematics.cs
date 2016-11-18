using AstronautComplex;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    /// <summary>
    /// Represents an astronaut mathematic exercice. Inherits from <see cref="Exercice"/>.
    /// </summary>
    public partial class ExerciceMathematics : Exercice
    {
        public static readonly Question[] PossibleQuestions = new Question[]
        {
            new QuestionPercentage("Hors saison, un hôtel propose un chambre double à {0}€. En pleine saison, le prix augmente de {1}%. Quel est le prix d'une chambre double en pleine saison ?"),
            new QuestionPercentage("Ma facture d'électricité a augmenté de {1}% ! Avant, elle était de {0}€. Combien vais-je devoir payer maintenant ?")
        };

        public List<Question> Questions { get; protected set; }
        public int CurrentQuestion { get; protected set; }

        /// <summary>
        /// Builds an astronaut mathematic exercice.
        /// </summary>
        public ExerciceMathematics() : base("Mathématiques")
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the exercice.
        /// </summary>
        public override void Initialize()
        {
            Score = new ExerciceScore();
            Score.GoodAndswers = 0;
            Questions = new List<Question>();
            CurrentQuestion = 0;
            GenerateQuestions(20);
            AskQuestion();
        }

        /// <summary>
        /// Generates a set of questions to ask to the user.
        /// </summary>
        /// <param name="nbQuestions">The number of questions to generate.</param>
        public void GenerateQuestions(int nbQuestions)
        {
            bool[] generated = new bool[PossibleQuestions.Length];
            for (int i = 0; i < nbQuestions; i++)
            {
                int index = Random.Next(0, PossibleQuestions.Length);
                if(!generated[index])
                {
                    Question question = PossibleQuestions[index];
                    Questions.Add(question);
                    generated[index] = true;
                }
            }
        }

        /// <summary>
        /// Asks a question to the user.
        /// </summary>
        public void AskQuestion()
        {
            labelTitle.Text = string.Format("{0} ({1})", Title, Difficulty.ToString());
            
            if (CurrentQuestion < Questions.Count)
            {
                Question question = Questions[CurrentQuestion];
                question.Build(Difficulty, Random);

                textBoxQuestion.Text = question.Title;
                tableLayoutPanelAnswers.Controls.Clear();
                tableLayoutPanelAnswers.ColumnStyles.Clear();
                tableLayoutPanelAnswers.ColumnCount = 0;

                for (int j = 0; j < question.Answers.Length; j++)
                {
                    Button button = new Button();
                    button.Text = question.Answers[j];
                    button.Anchor = AnchorStyles.None;
                    button.TabIndex = j;
                    button.Click += (sender, e) =>
                    {
                        AnswerQuestion(((Control)sender).TabIndex);
                    };
                    tableLayoutPanelAnswers.ColumnCount++;
                    tableLayoutPanelAnswers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0F));
                    tableLayoutPanelAnswers.Controls.Add(button, tableLayoutPanelAnswers.ColumnCount - 1, 0);
                }
            }
            else
            {
                Finish();
            }
        }

        /// <summary>
        /// Called when the user answers a question.
        /// </summary>
        /// <param name="index">The answer index.</param>
        public void AnswerQuestion(int index)
        {
            Score.TotalAnswers++;
            Question question = Questions[CurrentQuestion];
            string correctAnswer = question.Answers[question.Answer];
            string message;
            string caption;
            MessageBoxIcon icon;
            if (question.Answer == index)
            {
                message = string.Format("Bonne réponse ! Il s'agissait bien de {0} !", correctAnswer);
                caption = "Bravo !";
                icon = MessageBoxIcon.Information;
                Score.GoodAndswers++;
            }
            else
            {
                message = string.Format("Mauvaise réponse... Vous avez répondu {0} mais la bonne réponse était {1} !", question.Answers[index], correctAnswer);
                caption = "Oups...";
                icon = MessageBoxIcon.Error;
            }

            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);

            CurrentQuestion++;
            AskQuestion();
        }
    }
}
