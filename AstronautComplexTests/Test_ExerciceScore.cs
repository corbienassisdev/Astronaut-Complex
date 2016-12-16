using AstronautComplex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AstronautComplexTests
{
    [TestClass]
    public class Test_ExerciceScore
    {
        protected ExerciceScore score;

        [TestMethod]
        public void Test_NTotalAnswers_ToString()
        {
            score = new ExerciceScore();
            score.GoodAnswers = 5;
            score.TotalAnswers = 10;
            Assert.AreEqual("50 %", score.ToString());
        }

        [TestMethod]
        public void Test_0TotalAnswers_ToString()
        {
            score = new ExerciceScore();
            score.GoodAnswers = 5;
            score.TotalAnswers = 0;
            Assert.AreEqual("∞ %", score.ToString());
        }

        [TestMethod]
        public void Test_NotEnoughTotalAnswers_ToString()
        {
            score = new ExerciceScore();
            score.GoodAnswers = 5;
            score.TotalAnswers = 1;
            Assert.AreEqual("500 %", score.ToString());
        }
    }
}
