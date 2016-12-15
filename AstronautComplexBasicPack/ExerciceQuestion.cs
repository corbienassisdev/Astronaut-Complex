using AstronautComplex;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using AstronautComplexBasicPack.ExerciceMathematics;

namespace AstronautComplexBasicPack
{
    /// <summary>
    /// Represents an astronaut question-type exercice. Inherits from <see cref="Exercice"/>.
    /// </summary>
    public abstract partial class ExerciceQuestion : Exercice
    {
        public int CurrentQuestion { get; protected set; }
        public List<Question> Questions { get; protected set; }
        public List<Question> PossibleQuestions { get; protected set; }

        /// <summary>
        /// Builds an astronaut mathematic exercice.
        /// </summary>
        public ExerciceQuestion(string name) : base(name)
        {
            InitializeComponent();
            PossibleQuestions = new List<Question>(GeneratePossibleQuestions());
        }

        /// <summary>
        /// Initializes the exercice.
        /// </summary>
        public override void Initialize()
        {
            Score = new ExerciceScore();
            Questions = new List<Question>();
            CurrentQuestion = 0;
            
            panelDrawing.Paint += (sender, e) =>
            {
                Graphics graphics = e.Graphics;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                if (Questions.Count > 0 && CurrentQuestion >= 0)
                {
                    Questions[CurrentQuestion].BuildDrawing(graphics, panelDrawing.Width, panelDrawing.Height);
                }
            };          
        }

        /// <summary>
        /// Runs the exercice.
        /// </summary>
        public override void Run()
        {
            GenerateQuestions(10);
            AskQuestion();
        }

        /// <summary>
        /// Gets the exercice instructions.
        /// </summary>
        /// <returns>The instructions.</returns>
        public override string GetInstructions()
        {
            return "Dans ce test, vous devrez répondre à différentes questions, générées aléatoirement, qui vous serons posées. Un nombre aléatoire de réponses est possible ; choisissez l'unique bonne réponse en cliquant dessus !";
        }

        /// <summary>
        /// Generates a set of questions to ask to the user.
        /// </summary>
        /// <param name="nbQuestions">The number of questions to generate.</param>
        public void GenerateQuestions(int nbQuestions)
        {
            bool[] generated = new bool[PossibleQuestions.Count];
            for (int i = 0; i < nbQuestions; i++)
            {
                int index = Random.Next(0, PossibleQuestions.Count);
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
            labelTitle.Text = string.Format("{0} ({1})", Title, ExerciceForm.GetLangString(Difficulty.ToString()));
            
            if (CurrentQuestion < Questions.Count)
            {
                Question question = Questions[CurrentQuestion];
                question.Build(Difficulty, Random);

                textBoxQuestion.Text = question.Title;
                //textBoxQuestion.Height = TextRenderer.MeasureText(textBoxQuestion.Text, textBoxQuestion.Font).Height * textBoxQuestion.Lines.Length;
                
                tableLayoutPanelAnswers.Controls.Clear();
                tableLayoutPanelAnswers.ColumnStyles.Clear();
                tableLayoutPanelAnswers.ColumnCount = 0;
                panelDrawing.Refresh();

                for (int j = 0; j < question.Answers.Length; j++)
                {
                    Button button = new Button();
                    button.Text = question.Answers[j].ToString();
                    button.Anchor = AnchorStyles.None;
                    button.TabIndex = j;
                    button.Click += (sender, e) =>
                    {
                        AnswerQuestion(((Control)sender).TabIndex);
                    };
                    tableLayoutPanelAnswers.ColumnCount++;
                    tableLayoutPanelAnswers.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
                    tableLayoutPanelAnswers.Controls.Add(button, tableLayoutPanelAnswers.ColumnCount - 1, 0);
                }
            }
            else
            {
                Form.FinishExercice(this);
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
            string correctAnswer = question.Answers[question.Answer].ToString();
            string message;
            string caption;
            MessageBoxIcon icon;
            if (question.Answer == index)
            {
                message = string.Format("Bonne réponse ! Il s'agissait bien de {0} !", correctAnswer);
                caption = "Bravo !";
                icon = MessageBoxIcon.Information;
                Score.GoodAnswers++;
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

        /// <summary>
        /// Generates all possible questions. Needs to be implemented.
        /// </summary>
        /// <returns>The possible questions for the exercice.</returns>
        public abstract Question[] GeneratePossibleQuestions();
    }
}
