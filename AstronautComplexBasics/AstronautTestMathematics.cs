using AstronautComplex;
using System.IO;
using System.Reflection;
using System.Xml;
using System;
using System.Collections.Generic;

namespace AstronautComplexBasics
{
    /// <summary>
    /// Represents an astronaut mathematic test. Inherits from <see cref="AstronautTest"/>.
    /// </summary>
    public partial class AstronautTestMathematics : AstronautTest
    {
        public const string FileQuestions = @"\Data\mathematics.xml";
        public const string MessageUnableLoadFile = "Le fichier de données existe mais ses données sont invalides.";

        public List<Question> Questions = new List<Question>();

        /// <summary>
        /// Builds an astronaut mathematic test.
        /// </summary>
        public AstronautTestMathematics() : base("Mathématiques")
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads questions from the FileQuestions XML file.
        /// </summary>
        public void LoadQuestions()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + FileQuestions);
                foreach (XmlNode nodeQuestion in document.GetElementsByTagName("Question"))
                {
                    string title = nodeQuestion.SelectSingleNode("/descendant::Title[1]").InnerText;
                    int answer = int.Parse(nodeQuestion.Attributes["answer"].Value);
                    string[] answers = new string[4];
                    foreach (XmlNode nodeAnswer in nodeQuestion.SelectNodes("/descendant::Answers[1]/descendant::Answer"))
                    {
                        int id = int.Parse(nodeAnswer.Attributes["id"].Value);
                        answers[id] = nodeAnswer.InnerText;
                    }
                    Questions.Add(new Question(title, answer, answers));
                }
            }
            catch (Exception exception)
            {
                Form.DisplayError(string.Format("{0} ({1})", MessageUnableLoadFile, exception.Message));
            }
        }

        /// <summary>
        /// Called on control loading.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AstronautTestMathematics_Load(object sender, System.EventArgs e)
        {
            LoadQuestions();
        }
    }
}
