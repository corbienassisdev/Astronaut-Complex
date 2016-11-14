﻿using AstronautComplex;
using System.IO;
using System.Reflection;
using System.Xml;
using System;
using System.Collections.Generic;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    /// <summary>
    /// Represents an astronaut mathematic test. Inherits from <see cref="AstronautTest"/>.
    /// </summary>
    public partial class ExerciceMathematics : AstronautTest
    {
        public List<Question> Questions { get; protected set; }
        public int CurrentQuestion { get; protected set; }

        /// <summary>
        /// Builds an astronaut mathematic test.
        /// </summary>
        public ExerciceMathematics() : base("Mathématiques")
        {
            InitializeComponent();
            Questions = new List<Question>();
            CurrentQuestion = 0;
        }

        /// <summary>
        /// Loads questions from the FileQuestions XML file.
        /// </summary>
        public void LoadQuestions()
        {
            /*TODO Implement different question types */

            ShuffleQuestions();
        }

        public void ShuffleQuestions()
        {
            int n = Questions.Count;
            while(n > 1)
            {
                n--;
                int random = Random.Next(n + 1);
                Question holder = Questions[random];
                Questions[random] = Questions[n];
                Questions[n] = holder;
            }
        }

        public void AskQuestion()
        {
            Question question = Questions[CurrentQuestion];
            labelTitle.Text = string.Format("{0} ({1})", Title, Difficulty.ToString());
            textBoxQuestion.Text = question.Title;
        }

        /// <summary>
        /// Called on control loading.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AstronautTestMathematics_Load(object sender, System.EventArgs e)
        {
            LoadQuestions();
            AskQuestion();
        }
    }
}